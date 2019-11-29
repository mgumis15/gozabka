using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace Sklep
{
    public partial class AlterowaniShop : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        String User = "5";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();

            getData();
        }
        protected void getData()
        {
            command.CommandText = "SELECT COUNT(*) FROM products;";
            MySqlDataReader countReader = command.ExecuteReader();
            string elementsCount = "";
            while (countReader.Read()) elementsCount = countReader["COUNT(*)"].ToString();
            countReader.Close();
            command.CommandText = "select * from products";
            MySqlDataReader reader2 = command.ExecuteReader();
            int cellX = 0;
            int rowX = 0;
            int rowCount = Int32.Parse(elementsCount)/3;
            if (Int32.Parse(elementsCount) % 3 != 0) rowCount++;

        
            for(int i = 0; i < rowCount; i++)
            {
                TableRow row = new TableRow();
                tShop.Rows.Add(row);
            }
              
            while (reader2.Read())
            {

                if ((cellX % 3 == 0) && (cellX != 0)) rowX++;

                TableCell cell = new TableCell();

                Image photo = new Image();
                photo.ImageUrl = "Images/" + reader2["image"].ToString();
                photo.CssClass = "imgTable";
                cell.Controls.Add(photo);

                
                Label name = new Label();
                name.Text= reader2["name"].ToString();
                cell.Controls.Add(name);

                Label price = new Label();
                price.Text = reader2["price"].ToString();
                cell.Controls.Add(price);

                Label description = new Label();
                description.Text = reader2["description"].ToString();
                cell.Controls.Add(description);

                DropDownList select = new DropDownList();
                select.ID = "select/" + reader2["id"].ToString();

                string choosen = "";
                for (int i = 1; i <= 10; i++)
                {
                    ListItem option = new ListItem();
                    option.Text = i.ToString();
                    option.Value = i.ToString();
                    select.Items.Add(option);
                }
                cell.Controls.Add(select);

                Button addButton = new Button();
                addButton.ID = "add" + reader2["id"].ToString();
                addButton.CausesValidation = false;
                addButton.UseSubmitBehavior = false;
                addButton.Text = "DODAJ DO KOSZYKA";
                addButton.CommandName = "{ 'id':" + reader2["id"].ToString() + ",'cell':"+(cellX%3)+",'row':"+rowX+"}";
                addButton.Click += new EventHandler(this.addButton_Click);
                cell.Controls.Add(addButton);

                cell.ID = "cell" + reader2["id"].ToString();
                
                tShop.Rows[rowX].Cells.Add(cell);
                cellX++;


            }
            reader2.Close();
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            JObject jsonObject = JObject.Parse(bt.CommandName);
            int row = Int32.Parse(jsonObject["row"].ToString());
            int cell = Int32.Parse(jsonObject["cell"].ToString());
            DropDownList ddList = tShop.Rows[row].Cells[cell].Controls[4] as DropDownList;
           string ilosc =  ddList.SelectedValue.ToString();

            JObject koszykJSON = JObject.Parse("{}");
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                koszykJSON = JObject.Parse(reader["koszyk"].ToString());

            }
            reader.Close();
            string y = koszykJSON["data"].ToString();
            /*
            Array<JObject> x=y.ToArray<JObject>;
            Debug.WriteLine(x);
            
            string wynik = koszykJSON.ToString();
            wynik = wynik.Replace("\"", "");
            Debug.WriteLine(wynik);
            command.CommandText = "UPDATE `users` SET `koszyk` = '" + wynik + "' WHERE `users`.`id` = " + User;
            command.ExecuteNonQuery();*/

        }


    }
}


