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
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=sql7311615;Data Source=sql7.freesqldatabase.com;User Id=sql7311615;Password=tm2pULbIKM");
            connection.Open();
            command = connection.CreateCommand();
        }
        
        protected void bLogin_Click(object sender, EventArgs e)
        {
            lLogin.Visible = true;
            lName.Visible = false;
            lPassword.Visible = false;
            lRepPass.Visible = false;
            lMail.Visible = false;
            tbName.Visible = false;
            tbPassword.Visible = false;
            tbRepPass.Visible = false;
            tbMail.Visible = false;
            bDoLogOrReg.Visible = false;
        }

        protected void bRegister_Click(object sender, EventArgs e)
        {
            lLogin.Visible = false;
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



        }

        protected void bDoLogOrReg_Click(object sender, EventArgs e)
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
                    SmtpClient client;
                    MailMessage message;
                    
                    Random generator = new Random();
                    int AuthCode = generator.Next(0, 99999);

                    try
                    {
                        message = new MailMessage("Alterowani.Shop@gmail.com", tbMail.Text);
                        message.Subject = "Rejestracja użytkowanika Alterowani Shop";
                        message.Body = "Witaj " + tbName.Text + ". Twój kod weryfikacyjny to: " + AuthCode + ". Dziękujemy za wybór naszego sklepu!";

                        client = new SmtpClient("smtp.gmail.com", 587);
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = true;
                        client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");


                        client.Send(message);
                        lName.Text = "Message sent";

                    }
                    catch (Exception ex)
                    {
                        lName.Text = "You can not send messages (" + ex.Message + ")";
                    }


                    string outputVal = Encode(tbPassword.Text, tbName.Text);
                    command.CommandText = "INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `type`) VALUES (NULL, '" + tbName.Text + "', '" + outputVal + "', '" + tbMail.Text + "', '0', "+AuthCode+", 'user');";
                    command.ExecuteNonQuery();
                }

            }
        }
        private string Encode(string pass,string name)
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
        protected void cvPassMatch_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbPassword.Text != tbRepPass.Text)
            {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        protected void lLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            command.CommandText = "select * from users";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine("coś się prawie dzieje");
                if (reader["name"].ToString() == lLogin.UserName)
                {
                    Debug.WriteLine("coś się dzieje");
                    string outputVal = Encode(lLogin.Password, lLogin.UserName);
                    if (outputVal == reader["password"].ToString())
                    {
                        Debug.WriteLine("działa na pewno");
                         e.Authenticated = true; 
                    }
                }
            }
        }
    }
}