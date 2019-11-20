using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class Products : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*connection = new MySqlConnection("Database=sql7311615;Data Source=sql7.freesqldatabase.com;User Id=sql7311615;Password=tm2pULbIKM");
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from products";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                Debug.WriteLine(reader["name"]);
              
            }
            reader.Close();
            */
            
            LiteralControl table = new LiteralControl();
            table.Text += @"<table>";
            string th = @"
        <tr>
            <th>
                Id
            </th>
            <th>
                Nazwa
            </th>
            <th>
                Cena
            </th>
            <th>
                Zdjęcie
            </th>
        </tr>";
            table.Text += th;


            string tr = @"";
            int x = 0;
            while (x<12)
            {
                tr = @"<tr><td>"+x.ToString() + "</td><td>"+ x.ToString() + "-Name</td><td>" + x.ToString() + "-Cena</td><td>" + x.ToString() + "-Zdjęcie</td></tr>";
                table.Text += tr;
                x++;
                
            }
            table.Text += @"</table>";
            dMain.Controls.Add(table);
        }
    }
}