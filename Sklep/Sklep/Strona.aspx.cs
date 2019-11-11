using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Sklep
{
    public partial class FormularzLogowania : System.Web.UI.Page
    {
        MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=sql7311615;Data Source=sql7.freesqldatabase.com;User Id=sql7311615;Password=tm2pULbIKM");
            connection.Open();
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
                    Debug.WriteLine(reader["name"].ToString());
                    if (reader["name"].ToString() == tbName.Text)
                    {
                        check1 = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Taki użytkowik już istnieje')", true);
                        break;
                    }
                    //reader.GetString(0)
                    //reader["column_name"].ToString()
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



                    command.CommandText = "INSERT INTO `users` (`id`, `name`, `password`, `email`, `authorized`, `authorizationCode`, `type`) VALUES (NULL, '" + tbName.Text + "', '" + tbPassword.Text + "', '" + tbMail.Text + "', '0', "+AuthCode+", 'user');";
                    command.ExecuteNonQuery();
                }

            }
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
    }
}