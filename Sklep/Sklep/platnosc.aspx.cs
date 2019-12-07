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
        string User ;
        string kosz = "";
        float amount;
        MySqlConnection connection;
        MySqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                User = Session["id"].ToString();
                connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
                connection.Open();
                command = connection.CreateCommand();

                getData();
            }
            else
            {
                Response.Redirect("Logowanie.aspx");
            }
        }

        //pobranie koszyka
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
         

                command.CommandText = "select * from products";
                MySqlDataReader reader2 = command.ExecuteReader();
                int x = 0;
                while (reader2.Read())

                {
                    float amountP = float.Parse(reader2["price"].ToString());
                    foreach (JObject id in jsonObject["data"])
                    {
                        if (reader2["id"].ToString() == id["id"].ToString())
                        {
                            x++;

                            int amountC = Int32.Parse(id["ilosc"].ToString());

                            TableRow row = new TableRow();

                            TableCell cellID = new TableCell();
                            cellID.CssClass = "aspLabel";
                            cellID.Text = x.ToString();
                            row.Cells.Add(cellID);

                            TableCell cellName = new TableCell();
                            cellName.CssClass = "aspLabel";
                            cellName.Text = reader2["name"].ToString();
                            row.Cells.Add(cellName);
                            kosz += reader2["name"].ToString() + ", ";

                        TableCell cellCount = new TableCell();
                        cellCount.CssClass = "aspLabel";
                        cellCount.Text = id["ilosc"].ToString();
                        row.Cells.Add(cellCount);

                        TableCell cellPrice = new TableCell();
                            cellPrice.CssClass = "aspLabel";
                            cellPrice.Text = reader2["price"].ToString();
                            row.Cells.Add(cellPrice);

                            

                            //img do ogarniecia
                            TableCell cellPhoto = new TableCell();
                            cellPhoto.Text = string.Format("<img src='Images/" + reader2["image"] + "' class='imgTable'/>");
                            row.Cells.Add(cellPhoto);


                            tKoszyk.Rows.Add(row);



                            amount += amountC * amountP;

                        }
                    }


                }
                reader2.Close();
            lKoszyk.Text = "Łączna cena zakupów wynosi: " + amount.ToString() + " zł";
            
        }
        //wybor platnosci
        protected void rbDostawa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbDostawa.SelectedIndex == 1)
            {
                rbPlatnosc.SelectedIndex = 3;
                rbPlatnosc.Enabled = false;
            }
            else
            {
                rbPlatnosc.SelectedIndex = 0;
                rbPlatnosc.Enabled = true;
            }
        }
        protected void rbPlatnosc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbPlatnosc.SelectedIndex == 3)
            {
                rbDostawa.SelectedIndex = 1;
                rbDostawa.Enabled = false;
            }
            else
            {
                rbDostawa.SelectedIndex = 0;
                rbDostawa.Enabled = true;

            }
        }

        //confirm
        protected void btKup_Click(object sender, EventArgs e)
        {
            if(rbPlatnosc.SelectedIndex==3&&rbDostawa.SelectedIndex != 1)
            {
                lInfo.Text = "Wybierz poprawną formę płatnośći";
                rbPlatnosc.SelectedIndex = 0;
            }
            else
            {
                SmtpClient client;
                MailMessage message;
                string mail = "";
                string name = "";
                string dostawa = "";

                if (rbPlatnosc.SelectedIndex == 3)
                {
                    dostawa = "Wybrano płatność przy odbiorze.\nKwota do zapłaty to: " + amount.ToString()+".";
                }
                else
                {
                    dostawa = "Wybrano płatność internetową. Zrób przelew na kwotę " + amount.ToString() + " zł.\nNumer Konta to 00 0000 0000 0000 0000 0000 0000.\n";
                }

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from users where id='" + User + "'";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())

                {
                    mail = reader["email"].ToString();
                    name = reader["name"].ToString();
                }
                reader.Close();

                try
                {
                    message = new MailMessage("Alterowani.Shop@gmail.com", mail);
                    message.Subject = "Zakup produktów na Alterowani Shop";
                    message.Body = "Witaj " + name + ". Twoje zamówienie zostało złożone.\nKupione produkty: "+kosz+"\n"+dostawa+"Dziękujemy za zakupy w nasym sklepie";

                    client = new SmtpClient("smtp.gmail.com", 587);
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");


                    client.Send(message);
                    lInfo.Text = "Zamównienie zostało złożone. Wysłano wiadomość adres email.";

                }
                catch (Exception ex)
                {
                    lInfo.Text = "You can not send messages (" + ex.Message + ")";
                }
            }
        }
        protected void btRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlterowaniShop.aspx");
        }

        protected void btKoszyk_Click(object sender, EventArgs e)
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

        protected void btWyloguj_Click(object sender, EventArgs e)
        {
            Session["name"] = null;
            Session["id"] = null;
            Session["type"] = null;
            Response.Redirect("Logowanie.aspx");
        }


    }
}