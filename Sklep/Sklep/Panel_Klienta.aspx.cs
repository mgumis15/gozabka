using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace Sklep
{
    public partial class Panel_Klienta : System.Web.UI.Page
    {

        MySqlConnection connection;
        MySqlCommand command;

        //musi byc zmienna przy przejsciu miedzy ekranami o id usera
        String User = "22";

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=sql7311615;Data Source=sql7.freesqldatabase.com;User Id=sql7311615;Password=tm2pULbIKM");
            connection.Open();
            command = connection.CreateCommand();
        }

        protected void btHaslo_Click(object sender, EventArgs e)
        {
            lMail.Visible = true;
            lName.Visible = true;
            tbName.Visible = true;
            tbMail.Visible = true;
            btConfirm.Visible = true;

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
                message.Body = "Witaj " + tbName.Text + ". Twoje dane zostały pomyślnie zmienione. Twój kod weryfikacyjny to: " + authCode + ". Użyj tego kodu przy  logowaniu się do naszego sklepu, aby potwierdzić swoją tożsamość. Dziękujemy za wybór naszego sklepu!";

                client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("Alterowani.Shop@gmail.com", "ZAQ!2wsx");


                client.Send(message);
                lInfo.Text = "Wysłano wiadomość na podany adres email. Zaloguj się teraz na stronę i podaj kod autoryzacyjny z maila.";

            }
            catch (Exception ex)
            {
                lInfo.Text = "You can not send messages (" + ex.Message + ")";
            }

        }

        //deklaracja zmiennych bo jak dam potem to wydupca
        string old;
        string nazwa;
        string wpisane;
        //Zmiena hasla
        protected void btZmiana_Click(object sender, EventArgs e)
        {
            lMail.Visible = false;
            lName.Visible = false;
            tbName.Visible = false;
            tbMail.Visible = false;
            btConfirm.Visible = false;

            lOld.Visible = true;
            lNew.Visible = true;
            lNewRep.Visible = true;
            btPass.Visible = true;
            tbNew.Visible = true;
            tbOld.Visible = true;
            tbNewRep.Visible = true;

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from users where id='" + User + "'";
            MySqlDataReader reader = command.ExecuteReader();

            Boolean update = false;
            while (reader.Read())
            {
                //Sprawdzenie czy stare haslo pasuje
                 old = reader["password"].ToString();
                 nazwa = reader["name"].ToString();
                 wpisane = Encode(tbOld.Text, nazwa);
                if (old == wpisane) {
                    update = true;
                }


            if (update)
            {
                //zapisanie nowego hasła + wyslanie emaila


                string nowe = Encode(tbNew.Text, nazwa);

                Random generator = new Random();
                int authCode = generator.Next(0, 99999);

                command.CommandText = "UPDATE `users` SET `password` = '" + nowe + "', `authorized` = '0' , `authorizationCode` = '" + authCode + "' WHERE `users`.`id` = " + User + "";
                command.ExecuteNonQuery();



                lInfo.Text = "Zaktualizowano hasło, sprawdź maila i zaloguj się ponownie na strone.";

            }
                else
                {
                    lInfo.Text = "Stare hasło jest niepoprawne";
                }
            }
            reader.Close();
        }

        //Szyfrowanie
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
    }
}