using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace Sklep
{
    public partial class AlterowaniShop : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        string User=null ;
        JArray koszykArray;
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();
            if (Session["id"] != null)
            {
                User = Session["id"].ToString();
                btWyloguj.Text = "Wyloguj się";
            }

            getData();
        }
        protected void getData()
        {
            command.CommandText = "SELECT COUNT(*) FROM products;";
            MySqlDataReader countReader = command.ExecuteReader();
            string elementsCount = "";
            while (countReader.Read()) elementsCount = countReader["COUNT(*)"].ToString();
            countReader.Close();


            
                if (User != null)
                {
                    JObject koszykJSON = JObject.Parse("{}");
                    command.CommandText = "select * from users where id='" + User + "'";
                    MySqlDataReader readerKoszyk = command.ExecuteReader();
                    while (readerKoszyk.Read())

                    {
                        koszykJSON = JObject.Parse(readerKoszyk["koszyk"].ToString());

                    }
                    readerKoszyk.Close();


                    koszykArray = (JArray)koszykJSON["data"];
                }
               
           
           
           


            command.CommandText = "select * from products";
            MySqlDataReader readerProductsHomePage = command.ExecuteReader();
            int cellX = 0;
            int rowX = 0;
            int rowCount = Int32.Parse(elementsCount)/3;
            if (Int32.Parse(elementsCount) % 3 != 0) rowCount++;

        
            for(int i = 0; i < rowCount; i++)
            {
                TableRow row = new TableRow();
                tShop.Rows.Add(row);
            }
              
            while (readerProductsHomePage.Read())
            {

                if ((cellX % 3 == 0) && (cellX != 0)) rowX++;

                bool warunek = false;
                string ilosc = "";
                try
                {
                    foreach (var item in koszykArray)
                    {

                        if (item["id"].ToString() == readerProductsHomePage["id"].ToString())
                        {
                            warunek = true;
                            ilosc = item["ilosc"].ToString();
                        }
                    }
                }
                catch
                {
                    //Debug.WriteLine("Użytkownik nie jest zalogowany");
                }
              

                TableCell cell = new TableCell();

                Image photo = new Image();
                photo.ImageUrl = "Images/" + readerProductsHomePage["image"].ToString();
                photo.CssClass = "imgTable";
                cell.Controls.Add(photo);


                
                Label name = new Label();
                name.Text= readerProductsHomePage["name"].ToString();
                name.CssClass = "Title";
                cell.Controls.Add(name);

                Label description = new Label();
                description.Text = readerProductsHomePage["description"].ToString();
                description.CssClass = "desc";
                cell.Controls.Add(description);

                Label price = new Label();
                price.Text = readerProductsHomePage["price"].ToString() + " zł";
                price.CssClass = "price";
                cell.Controls.Add(price);

                if ((Session["type"] == null)||(Session["type"].ToString()!="admin"))
                {
                    DropDownList select = new DropDownList();
                    select.ID = "select/" + readerProductsHomePage["id"].ToString();

                    for (int i = 1; i <= 10; i++)
                    {
                        ListItem option = new ListItem();
                        option.Text = i.ToString();
                        option.Value = i.ToString();
                        if (warunek && (i.ToString() == ilosc)) option.Selected = true;
                        select.Items.Add(option);
                    }
                    cell.Controls.Add(select);
                }
               

                Button addButton = new Button();
                addButton.ID = "add" + readerProductsHomePage["id"].ToString();
                addButton.CausesValidation = false;
                addButton.UseSubmitBehavior = false;
                
                addButton.Text = "DODAJ DO KOSZYKA";
                if (warunek) addButton.Text = "UAKTUALNIJ ILOŚĆ";
                if (Session["type"] != null)
                {
                    if (Session["type"].ToString() == "admin") addButton.Text = "Modyfikuj produkt";
                }
                addButton.CommandName = "{ 'id':" + readerProductsHomePage["id"].ToString() + ",'cell':"+(cellX%3)+",'row':"+rowX+"}";
                addButton.Click += new EventHandler(this.addButton_Click);
                cell.Controls.Add(addButton);

               

                cell.ID = "cell" + readerProductsHomePage["id"].ToString();
                
                tShop.Rows[rowX].Cells.Add(cell);
                cellX++;


            }
            readerProductsHomePage.Close();
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {

            
            if (Session["type"].ToString() != "admin")
            {

           
                if (Session["name"] != null)
            {
                Button bt = sender as Button;
                JObject jsonObject = JObject.Parse(bt.CommandName);
                int row = Int32.Parse(jsonObject["row"].ToString());
                int cell = Int32.Parse(jsonObject["cell"].ToString());
                DropDownList ddList = tShop.Rows[row].Cells[cell].Controls[4] as DropDownList;
                string ilosc = ddList.SelectedValue.ToString();

                JObject koszykJSON = JObject.Parse("{}");
                command.CommandText = "select * from users where id='" + User + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())

                {
                    koszykJSON = JObject.Parse(reader["koszyk"].ToString());

                }
                reader.Close();
                JArray a = (JArray)koszykJSON["data"];
                bool warunek = true;
                foreach (var item in a)
                {

                    if (item["id"].ToString() == jsonObject["id"].ToString())
                    {
                        item["ilosc"] = ilosc;
                        warunek = false;
                    }
                }

                if (warunek)
                {
                    a.Add("{id:" + jsonObject["id"] + ",ilosc:" + ilosc + "}");
                    koszykJSON["data"] = a;
                }
                
                string wynik = koszykJSON.ToString();
                wynik = wynik.Replace("\"", "");
                command.CommandText = "UPDATE `users` SET `koszyk` = '" + wynik + "' WHERE `users`.`id` = " + User;
                command.ExecuteNonQuery();
                bt.Text = "UAKTUALNIJ ILOŚĆ";
            }
            else
            {
                Response.Redirect("Logowanie.aspx");
            }
            }
            else
            {
                command.Connection.Close();
                connection.Close();

                Response.Redirect("Products.aspx");
            }
            }
            else
            {
                command.Connection.Close();
                connection.Close();

                Response.Redirect("Logowanie.aspx");
            }
        }

        protected void btRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterowaniShop.aspx");
        }

        protected void btKoszyk_Click(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {
                if (Session["type"].ToString() != "admin")
                {
                    if (Session["name"] != null)
                    {
                        command.Connection.Close();
                        connection.Close();

                        Response.Redirect("Panel_Klienta.aspx");
                    }
                    else
                    {
                        command.Connection.Close();
                        connection.Close();

                        Response.Redirect("Logowanie.aspx");
                    }
                }
                else
                {
                    command.Connection.Close();
                    connection.Close();

                    Response.Redirect("Products.aspx");
                }
            }
            else
            {
                command.Connection.Close();
                connection.Close();

                Response.Redirect("Logowanie.aspx");
            }
            
        }

        protected void btWyloguj_Click(object sender, EventArgs e)

        {
            Session["name"] = null;
            Session["id"] = null;
            Session["type"] = null;
            Response.Redirect("Logowanie.aspx");

        }
    }
}


