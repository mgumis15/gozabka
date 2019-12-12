﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.Timers;


namespace Sklep
{
    public partial class Panel_Klienta : System.Web.UI.Page
    {
        
        MySqlConnection connection;
        MySqlCommand command;

        //musi byc zmienna przy przejsciu miedzy ekranami o id usera
        string User ;
        float amount;
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
        protected void getData()
        {
            Debug.WriteLine(User);
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader readerKoszykowski = command.ExecuteReader();
            while (readerKoszykowski.Read())
            {
                lIlosc.Text = "Zalogowałeś się na naszą stronę już " + readerKoszykowski["logowania"].ToString() + " razy!";
                hfKoszyk.Value = readerKoszykowski["koszyk"].ToString();

            }
            readerKoszykowski.Close();
            Debug.WriteLine(hfKoszyk.Value);
            JObject jsonObject = JObject.Parse(hfKoszyk.Value);
            if (jsonObject["data"].ToString() == "[]")
            {
                lKoszyk.Text = "Twój koszyk jest pusty";
                bBuy.Visible = false;
                lPrice.Visible = false;
            }

            else
            {
                lKoszyk.Text = "Twój koszyk:";
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
                            cellID.Text = x.ToString();
                            cellID.CssClass = "aspLabel";
                            row.Cells.Add(cellID);

                            TableCell cellName = new TableCell();
                            cellName.CssClass = "aspLabel";
                            cellName.Text = reader2["name"].ToString();
                            row.Cells.Add(cellName);

                            TableCell cellPrice = new TableCell();
                            cellPrice.CssClass = "aspLabel";
                            cellPrice.Text = reader2["price"].ToString();
                            row.Cells.Add(cellPrice);

                            TableCell cellDescription = new TableCell();
                            cellDescription.CssClass = "aspLabel";
                            cellDescription.Text = reader2["description"].ToString();
                            row.Cells.Add(cellDescription);

                            //img do ogarniecia
                            TableCell cellPhoto = new TableCell();
                            cellPhoto.Text = string.Format("<img src='Images/" + reader2["image"] + "' class='imgTable'/>");
                            row.Cells.Add(cellPhoto);


                            DropDownList select = new DropDownList();
                            select.CssClass = "aspSelect";
                            select.ID = "select/" + reader2["id"].ToString();

                            ListItem priceItem = new ListItem();
                            priceItem.Value = reader2["price"].ToString();
                            priceItem.Enabled = false;
                            select.Items.Add(priceItem);

                            ListItem lastItem = new ListItem();
                            lastItem.Value = "1";
                            lastItem.Enabled = false;
                            select.Items.Add(lastItem);
                            for ( int i = 1; i <= 10; i++)
                            {
                                ListItem option = new ListItem();
                                option.Text = i.ToString();
                                option.Value = i.ToString();
                                if(i.ToString()== id["ilosc"].ToString())
                                {
                                    option.Selected = true;
                                    select.Items[1].Value = option.Value;
                                }
                                select.Items.Add(option);
                            }
                            
                           
                            select.SelectedIndexChanged += this.select_SelectedIndexChanged;
                            select.AutoPostBack = true;

                            TableCell cellSelect = new TableCell();
                            cellSelect.Controls.Add(select);
                            row.Cells.Add(cellSelect);


                            Button delButton = new Button();
                            delButton.CssClass = "aspButton";
                            delButton.ID = "delete" + reader2["id"].ToString();
                            delButton.CausesValidation = false;
                            delButton.UseSubmitBehavior = false;
                            delButton.Text = "USUŃ Z KOSZYKA";
                            delButton.CommandName = "{ 'id':" + reader2["id"].ToString()+",'row':"+x+ ",'data':"+ jsonObject["data"].ToString() + ",'price':'"+ reader2["price"].ToString() + "'}";
                            delButton.Click += new EventHandler(this.delButton_Click);
                            TableCell cellDelButt = new TableCell();
                            cellDelButt.Controls.Add(delButton);
                            row.Cells.Add(cellDelButt);

                            tKoszyk.Rows.Add(row);

                            amount += amountC * amountP;
                            
                        }
                    }
                  

                }
                reader2.Close();
                lPrice.Visible = true;
                lPrice.Text = "Łączna cena produktów: " + amount.ToString() + " zł";
            }
        }

        protected void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddp = sender as DropDownList;
            Debug.WriteLine(ddp.Items[0].Value);
            string[] x = ddp.ID.Split("/".ToCharArray());
            JObject jsonObject = JObject.Parse(hfKoszyk.Value);
            foreach (JObject element in jsonObject["data"])
            {
                if (element["id"].ToString() == x[1])
                {
                    element["ilosc"] = ddp.SelectedValue;
                }
            }
            string wynik = jsonObject.ToString();
            wynik = wynik.Replace("\"", "");
            command.CommandText = "UPDATE `users` SET `koszyk` = '" + wynik + "' WHERE `users`.`id` = " + User;
            command.ExecuteNonQuery();
            int cutHelp = Int32.Parse(ddp.Items[1].Value) - Int32.Parse(ddp.SelectedValue) ;
            float cut = cutHelp * float.Parse(ddp.Items[0].Value);
            amount -= cut;
            lPrice.Text = "Łączna cena produktów: " + amount.ToString() + " zł";

            ddp.Items[1].Value = ddp.SelectedValue;
        }
        protected void delButton_Click(object sender, EventArgs e)
        {

            lKoszyk.Text = "usunieto";
            Button btn = sender as Button;
            Debug.WriteLine(btn.CommandName);
            JObject jObject = JObject.Parse(btn.CommandName);
            foreach(JObject element in jObject["data"])
            {
                if(element["id"].ToString()== jObject["id"].ToString())
                {
                    
                    element.Remove();
                    break;
                }
            }
            DropDownList ddp = tKoszyk.Rows[int.Parse(jObject["row"].ToString())].Cells[5].Controls[0] as DropDownList;

            float cut = Int32.Parse(ddp.SelectedValue) * float.Parse(jObject["price"].ToString());
            amount -= cut;
            lPrice.Text = "Łączna cena produktów: " + amount.ToString() + " zł";
            tKoszyk.Rows.RemoveAt(int.Parse(jObject["row"].ToString()));
            JObject data = JObject.Parse("{data:" + jObject["data"].ToString() + "}");
            string dataStr=data.ToString();
            dataStr=dataStr.Replace("\"", "");
            command.CommandText = "UPDATE `users` SET `koszyk` = '"+ dataStr+"' WHERE `users`.`id` = "+User;
            command.ExecuteNonQuery();
            if (jObject["data"].ToString() == "[]")
            {
                bBuy.Visible = false;
                lPrice.Visible = false;
                lKoszyk.Text = "Twój koszyk jest pusty";
            }
           
        }



      


        protected void btHaslo_Click(object sender, EventArgs e)
        {
            rfvNew.Enabled = false;
            rfvOld.Enabled = false;
            rfvRepNew.Enabled = false;
            CompareValidator1.Enabled = false;
            revNew.Enabled = false;
            lMail.Visible = true;
            lName.Visible = true;
            tbName.Visible = true;
            tbMail.Visible = true;
            btConfirm.Visible = true;
            lInfo.Text = "";
            lOld.Visible = false;
            lNew.Visible = false;
            lNewRep.Visible = false;
            btPass.Visible = false;
            tbNew.Visible = false;
            tbOld.Visible = false;
            tbNewRep.Visible = false;
           

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                tbName.Text = reader["name"].ToString();

                tbMail.Text = reader["email"].ToString();

            }
            reader.Close();
        }

        //zmiana maila i nazwy z wyslaniem maila z autoryzacja
        protected void btConfirm_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            int authCode = generator.Next(0, 99999);

            command.CommandText = "UPDATE `users` SET `name` = '" + tbName.Text + "', `email` = '" + tbMail.Text + "', `authorized` = '0' , `authorizationCode` = '" + authCode + "' WHERE `users`.`id` = " + User + "";
            command.ExecuteNonQuery();
            
            SmtpClient client;
            MailMessage message;

            try
            {
                message = new MailMessage("Alterowani.Shop@gmail.com", tbMail.Text);
                message.Subject = "Zmiana danych w serwisie Alterowani Shop";
                message.Body = "Witaj " + tbName.Text + ". Twoje dane zostały pomyślnie zmienione. Twój kod weryfikacyjny to: " + authCode + ". Użyj tego kodu przy następnym logowaniu się do naszego sklepu, aby potwierdzić swoją tożsamość. Dziękujemy za wybór naszego sklepu!  Jeżeli nie zmieniałeś/łaś swoich danych, niezwłocznie skontaktuj się z naszym doradcą poprzez ten adres mailowy: Alterowani.Shop@gmail.com";

                client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");


                client.Send(message);
                lInfo.Text = "Wysłano wiadomość na podany adres email. Przy ponownym zalogowaniu podaj kod autoryzacyjny z maila.";


                /*
                 * ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wysłano wiadomość na podany adres email. Zaloguj się teraz na stronę i podaj kod autoryzacyjny z maila.')", true);
                        Session["name"] = null;
                        Session["id"] = null;
                        Session["type"] = null;
                System.Timers.Timer aTimer = new System.Timers.Timer(5000);
                aTimer.Elapsed += OnTimedEvent; 
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
                */
            }
            catch (Exception ex)
            {
                lInfo.Text = "You can not send messages (" + ex.Message + ")";
            }

        }

        //deklaracja zmiennych bo jak dam potem to nie dziala
        string old;
        string nazwa;
        string wpisane;
        //Zmiena hasla
        protected void btZmiana_Click(object sender, EventArgs e)
        {
            rfvNew.Enabled = true;
            rfvOld.Enabled = true;
            rfvRepNew.Enabled = true;
            CompareValidator1.Enabled = true;
            revNew.Enabled = true;
            lMail.Visible = false;
            lName.Visible = false;
            tbName.Visible = false;
            tbMail.Visible = false;
            btConfirm.Visible = false;
            lInfo.Text = "";
            lOld.Visible = true;
            lNew.Visible = true;
            lNewRep.Visible = true;
            btPass.Visible = true;
            tbNew.Visible = true;
            tbOld.Visible = true;
            tbNewRep.Visible = true;
           
        }

        //Szyfrowanie
        private string Encode(string pass)
        {
            List<char> printableChars = new List<char>();
            for (int i = char.MinValue; i <= char.MaxValue; i++)
            {
                char c = Convert.ToChar(i);
                if (!char.IsControl(c))
                {
                    printableChars.Add(c);
                }
            }
            List<char> ukryty = printableChars.ToList();
            List<List<char>> allAlf = new List<List<char>>();
            string old = pass;
            string outputVal = "";
            string klucz = "WróćDoMnie<3";
            klucz = klucz.Replace(" ", "");
            string result = string.Join("", klucz.ToCharArray().Distinct());
            foreach (char element in result)
            {
                for (int i = 0; i < ukryty.IndexOf(element); i++)
                {
                    char first = ukryty[0];
                    ukryty.RemoveAt(0);
                    ukryty.Add(first);

                }
                allAlf.Add(ukryty);
                ukryty = printableChars.ToList();
            }
            int x = 0;
            foreach (char a in pass)
            {
                outputVal += allAlf[x][printableChars.IndexOf(a)];
                x = x + 1;
                if (x == allAlf.Count()) x = 0;
            }
            return outputVal;
        }

        protected void btPass_Click(object sender, EventArgs e)
        {
            lInfo.Text = "accept.";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader reader = command.ExecuteReader();
            int authCode=0;
            string nowe="";
            Boolean update = false;
            while (reader.Read())
            {
                //Sprawdzenie czy stare haslo pasuje
                old = reader["password"].ToString();
                nazwa = reader["name"].ToString();
                wpisane = Encode(tbOld.Text);
                if (old == wpisane)
                {
                    
                    update = true;
                    lInfo.Text = "accept.";
                }
                else
                {
                    lInfo.Text = "nie.";
                }


                if (update)
                {
                    lInfo.Text = "jazda.";
                    //zapisanie nowego hasła + wyslanie emaila
                    nowe = Encode(tbNew.Text);
                    Random generator = new Random();
                    authCode = generator.Next(0, 99999);

                    lInfo.Text = "Zaktualizowano hasło, sprawdź maila i zaloguj się ponownie na strone.";
                    SmtpClient client;
                    MailMessage message;

                    try
                    {
                        message = new MailMessage("Alterowani.Shop@gmail.com",reader["email"].ToString());
                        message.Subject = "Zmiana hasła w serwisie Alterowani Shop";
                        message.Body = "Witaj " + reader["name"].ToString() + ". Twoje hasło zostało pomyślnie zmienione. Twój kod weryfikacyjny to: " + authCode + ". Użyj tego kodu przy następnym logowaniu się do naszego sklepu, aby potwierdzić swoją tożsamość. Dziękujemy za wybór naszego sklepu! Jeżeli nie zmieniałeś/łaś swojego hasła, niezwłocznie skontaktuj się z naszym doradcą poprzez ten adres mailowy: Alterowani.Shop@gmail.com";

                        client = new SmtpClient("smtp.gmail.com", 587);
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = true;
                        client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");

                        client.Send(message);
                        lInfo.Text = "Wysłano wiadomość na podany adres email. Przy ponownym zalogowaniu podaj kod autoryzacyjny z maila.";
                        /*
                        System.Timers.Timer aTimer = new System.Timers.Timer(5000);
                        aTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs ef)=>{
                            Session["name"] = null;
                            Session["id"] = null;
                            Session["type"] = null;
                        };
                        aTimer.AutoReset = false;
                        aTimer.Enabled = true;
                        */
                        
                    }
                    catch (Exception ex)
                    {
                        lInfo.Text = "You can not send messages (" + ex.Message + ")";
                    }
                }
                else
                {
                    lInfo.Text = "Stare hasło jest niepoprawne";
                }
            }

            reader.Close();
            if (update)
            {
                command.CommandText = "UPDATE `users` SET `password` = '" + nowe + "', `authorized` = '0' , `authorizationCode` = '" + authCode + "' WHERE `users`.`id` = " + User + "";
                command.ExecuteNonQuery();
            }

            /*
             void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs ef)
            {
                Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAA");
                Session["name"] = null;
                Session["id"] = null;
                Session["type"] = null;
                Response.Redirect("Logowanie.aspx");
            }
            */
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
        protected void bBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("platnosc.aspx");
        }
    }
}