using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace Sklep
{
    public partial class AlterowaniShop : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {

            connection = new MySqlConnection("Database=sql7311615;Data Source=sql7.freesqldatabase.com;User Id=sql7311615;Password=tm2pULbIKM");
            connection.Open();
            command = connection.CreateCommand();

           
            command.CommandText = "select * from products";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                var x = reader["name"];
                
            }

            reader.Close();
    }
}
}
