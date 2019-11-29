using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Script;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
namespace Sklep
{
    public partial class platnosc : System.Web.UI.Page
    {
        String User = "5";
        MySqlConnection connection;
        MySqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();
            getData();
        }


        protected void getData()
        {

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                hfPobierz.Value = reader["koszyk"].ToString();

            }
            reader.Close();
            JObject jsonObject = JObject.Parse(hfPobierz.Value);
            if (jsonObject["data"].ToString() == "[]")
            {
                lKoszyk.Text = "Twój koszyk jest pusty";
            }

            else
            {

                command.CommandText = "select * from products";
                MySqlDataReader reader2 = command.ExecuteReader();
                int x = 0;
                while (reader2.Read())

                {

                    foreach (JObject id in jsonObject["data"])
                    {
                        if (reader2["id"].ToString() == id["id"].ToString())
                        {
                            x++;
                            TableRow row = new TableRow();

                            TableCell cellID = new TableCell();
                            cellID.Text = x.ToString();
                            row.Cells.Add(cellID);

                            TableCell cellName = new TableCell();
                            cellName.Text = reader2["name"].ToString();
                            row.Cells.Add(cellName);

                            TableCell cellPrice = new TableCell();
                            cellPrice.Text = reader2["price"].ToString();
                            row.Cells.Add(cellPrice);

                            TableCell cellDescription = new TableCell();
                            cellDescription.Text = reader2["description"].ToString();
                            row.Cells.Add(cellDescription);

                            //img do ogarniecia
                            TableCell cellPhoto = new TableCell();
                            cellPhoto.Text = string.Format("<img src='Images/" + reader2["image"] + "' class='imgTable'/>");
                            row.Cells.Add(cellPhoto);


                            DropDownList select = new DropDownList();
                            select.ID = "select/" + reader2["id"].ToString();

                            string choosen = "";
                            foreach (JObject element in jsonObject["data"])
                            {
                                if (reader2["id"].ToString() == element["id"].ToString())
                                {
                                    choosen = element["ilosc"].ToString();
                                    break;
                                }
                            }
                            
                            TableCell cellSelect = new TableCell();
                            cellSelect.Controls.Add(select);
                            row.Cells.Add(cellSelect);



                            tKoszyk.Rows.Add(row);

                        }
                    }


                }
                reader2.Close();

            }
        }
    }
}