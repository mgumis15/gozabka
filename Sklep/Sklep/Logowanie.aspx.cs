using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Sklep
{
    public partial class FormularzLogowania : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        string nameS = "";
        string idS = "";
        string typeS = "";
        //Tutaj ją deklaruje
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();
            Session["name"] = null;
            Session["id"] = null;
            Session["type"] = null;
        }

        protected void bLogin_Click(object sender, EventArgs e)
        {
            lInfo.Text = "";
            hdLogRes.Value = "0";
            lName.Visible = true;
            lPassword.Visible = true;
            lRepPass.Visible = false;
            lMail.Visible = false;
            tbName.Visible = true;
            tbPassword.Visible = true;
            tbRepPass.Visible = false;
            tbMail.Visible = false;
            bDoLogOrReg.Visible = true;
            bDoLogOrReg.Text = "Zaloguj się";
            revPass.Enabled = false;
            rfvRepPass.Enabled = false;
            revEmail.Enabled = false;
            rfvMail.Enabled = false;
            cvPassMatch.Enabled = false;
        }

        protected void bRegister_Click(object sender, EventArgs e)
        {
            lInfo.Text = "";
            hdLogRes.Value = "1";
            lMail.Visible = true;
            lName.Visible = true;
            lPassword.Visible = true;
            lRepPass.Visible = true;
            tbName.Visible = true;
            tbPassword.Visible = true;
            tbRepPass.Visible = true;
            tbMail.Visible = true;
            bDoLogOrReg.Visible = true;
            bDoLogOrReg.Text = "Zarejestruj się";
            revPass.Enabled = true;
            rfvRepPass.Enabled = true;
            revEmail.Enabled = true;
            rfvMail.Enabled = true;
            cvPassMatch.Enabled = true;
        }

        protected void bDoLogOrReg_Click(object sender, EventArgs e)
        {
            //tutaj ją wypisuję i używam
            var authCheck = 0;
            
            if (tbAuth.Visible)
            {
                
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from users where name='" + tbName.Text + "'";
                MySqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())

                {
                    if (tbAuth.Text == reader2["authorizationCode"].ToString())
                    {
                        authCheck = 1;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Witaj na stronie " + tbName.Text + "')", true);
                        nameS = reader2["name"].ToString();
                        idS = reader2["id"].ToString();
                        typeS = reader2["type"].ToString();
                        break;
                    }
                    else
                    {

                        lInfo.Visible = true;
                        lInfo.Text = "Podano błędny kod autoryzacyjne. Wprowadź kod ponownie";
                        tbAuth.Text = "";
                    }
                }
                reader2.Close();
                if (authCheck == 1)
                {
                    command.CommandText = "UPDATE `users` SET `authorized` = '1' WHERE `users`.`name` ='" + tbName.Text + "'";
                    command.ExecuteNonQuery();
                    Session["name"] = nameS;
                    Session["id"] = idS;
                    Session["type"] = typeS;

                    Response.Redirect("AlterowaniShop.aspx");
                }


            }
            else
            {


                if (hdLogRes.Value == "1")
                {
                    if (Page.IsValid)
                    {
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandText = "select * from users";
                        MySqlDataReader reader = command.ExecuteReader();
                        Boolean check1 = true;
                        while (reader.Read())
                        {
                            if (reader["name"].ToString() == tbName.Text)
                            {
                                check1 = false;
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Taki użytkowik już istnieje')", true);

                                break;
                            }
                        }
                        reader.Close();
                        if (check1)
                        {
                            //wysylanie maila
                            int authCode = MailAuthSender(tbMail.Text, tbName.Text);
                            string outputVal = Encode(tbPassword.Text);
                            command.CommandText = "INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `type`,koszyk) VALUES (NULL, '" + tbName.Text + "', '" + outputVal + "', '" + tbMail.Text + "', '0', '" + authCode + "', 'user','{data:[]}');";
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    command.CommandText = "select * from users";
                    MySqlDataReader reader = command.ExecuteReader();
                    bool warunek = false;
                    
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == tbName.Text)
                        {
                            string outputVal = Encode(tbPassword.Text);
                            if (outputVal == reader["password"].ToString())
                            {


                                if (reader["authorized"].ToString() == "True")
                                {

                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Witaj ponownie " + reader["name"].ToString() + "')", true);
                                    //e.Authenticated = true;
                                    nameS = reader["name"].ToString();
                                    idS = reader["id"].ToString();
                                    typeS = reader["type"].ToString();
                                    warunek = true;
                                    

                                }
                                else
                                {
                                    lAuth.Visible = true;
                                    tbAuth.Visible = true;
                                    tbPassword.Visible = false;
                                    lPassword.Visible = false;
                                    rfvPassword.Enabled = false;
                                    revPass.Enabled = false;
                                    tbName.Enabled = false;  
                                }
                            }
                        }
                    }
                    reader.Close();
                    if (warunek)
                    {
                        command.Connection.Close();
                        connection.Close();


                        Session["name"] = nameS;
                        Session["id"] = idS;
                        Session["type"] = typeS;
                        if (Session["type"].ToString() == "admin")
                        {
                            Response.Redirect("Products.aspx");
                        }
                        else
                        {
                            Response.Redirect("AlterowaniShop.aspx");
                        }
                        
                    }



                }
            }
        }

        //SZYFROWANIE
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
        //WYSYŁANIE MAILA AUTORYZACYJNEGO
        private int MailAuthSender(string mail, string name)
        {
            SmtpClient client;
            MailMessage message;

            Random generator = new Random();
            int authCode = generator.Next(0, 99999);

            try
            {
                message = new MailMessage("Alterowani.Shop@gmail.com", mail);
                message.Subject = "Rejestracja użytkowanika Alterowani Shop";
                message.Body = "Witaj " + name + ". Twój kod weryfikacyjny to: " + authCode + ". Użyj tego kodu przy pierwszym logowaniu się do naszego sklepu, aby potwierdzić swoją tożsamość. Dziękujemy za wybór naszego sklepu!";

                client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");


                client.Send(message);
                lInfo.Text = "Wysłano wiadomość na podany adres email. Zaloguj się teraz na stronę i podaj kod autoryzacyjny z maila.";

            }
            catch (Exception ex)
            {
                lName.Text = "You can not send messages (" + ex.Message + ")";
            }
            return authCode;
        }
        protected void cvPassMatch_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbPassword.Text != tbRepPass.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
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
    }
}