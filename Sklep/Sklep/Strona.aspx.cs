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

        //Tutaj ją deklaruje
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();
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
                    Debug.WriteLine(reader2["authorizationCode"]);
                    if (tbAuth.Text == reader2["authorizationCode"].ToString())
                    {
                        authCheck = 1;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Witaj na stronie " + tbName.Text + "')", true);
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

                }


            }
            else
            {


                if (hdLogRes.Value == "1")
                {
                    Debug.WriteLine("wszedłem do rejestrowania");
                    if (Page.IsValid)
                    {
                        Debug.WriteLine("rejestrowane zwalidowane");
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
                            string outputVal = Encode(tbPassword.Text, tbName.Text);
                            command.CommandText = "INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `type`) VALUES (NULL, '" + tbName.Text + "', '" + outputVal + "', '" + tbMail.Text + "', '0', " + authCode + ", 'user');";
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("wszedłem do logowania");
                    command.CommandText = "select * from users";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Debug.WriteLine("coś się prawie dzieje");
                        if (reader["name"].ToString() == tbName.Text)
                        {
                            Debug.WriteLine("coś się dzieje");
                            string outputVal = Encode(tbPassword.Text, tbName.Text);
                            if (outputVal == reader["password"].ToString())
                            {
                                Debug.WriteLine("kodzik:");
                                Debug.WriteLine(reader["authorized"].ToString());


                                if (reader["authorized"].ToString() == "True")
                                {

                                    Debug.WriteLine("działa na pewno");
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Witaj ponownie " + reader["name"].ToString() + "')", true);
                                    //e.Authenticated = true;

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



                }
            }
        }

        //SZYFROWANIE
        private string Encode(string pass, string name)
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
            string klucz = name;
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



    }
}