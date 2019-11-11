using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.SessionState;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace Sklep
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string JQueryVer = "1.11.3";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/js/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/js/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            MySqlConnection connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from users";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine(reader["name"].ToString());

                //reader.GetString(0)
                //reader["column_name"].ToString()
            }
            reader.Close();
        }
    }
}