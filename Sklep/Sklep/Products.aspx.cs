using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class Products : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;
        List<string> images = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
            connection.Open();
            command = connection.CreateCommand();
            Debug.WriteLine("KURCZE");
            getData();
       
        }

       
        protected void bAdd_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                command.CommandText = "select * from products";
                MySqlDataReader reader = command.ExecuteReader();
                Boolean check1 = true;
                while (reader.Read())
                {
                    if (reader["name"].ToString() == tbName.Text)
                    {
                        check1 = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Taki produkt już istnieje')", true);
                        break;
                    }
                }
                reader.Close();

                if (check1)
                {
                    string sPrice = tbPrice.Text;
                    sPrice = sPrice.Replace(",", ".");
                    float price = float.Parse(sPrice, CultureInfo.InvariantCulture.NumberFormat);
                    command.CommandText = "INSERT INTO `products` (`id`, `name`, `price`, `description`, `image`) VALUES (NULL, '" + tbName.Text + "', '" + price + "','" + tbDescription.Text + "','" + fUpload.FileName + "');";
                    command.ExecuteNonQuery();
                    tbName.Text = "";
                    tbPrice.Text = "";
                    tbDescription.Text = "";
                    string filename = Path.GetFileName(fUpload.FileName);
                    fUpload.SaveAs(Server.MapPath("Images/") + filename);
                    getData();
                }
               
            }
            else
            {

            }
        }


        protected void cvFile_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool x=false;
            if (fUpload.HasFile)
            {
                Regex rgx = new Regex(@"[\/.](gif|jpg|jpeg|tiff|png)$");
                x = rgx.IsMatch(fUpload.FileName) ? true : false;
                if (x)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            {
                if (x)
                {
                    args.IsValid = true;
                }
                else{
                    args.IsValid = false;
                }
                
            }
            
        }


        protected void getData()
        {
            for (int i = tProducts.Rows.Count-1; i >1; i--)
            {
                    tProducts.Rows.RemoveAt(i);
                
            }
            command.CommandText = "select * from products";
            MySqlDataReader reader = command.ExecuteReader();

            int x = 2;
            
            while (reader.Read())

            {

                TableRow row = new TableRow();

                TableCell cellID = new TableCell();
                cellID.Text = reader["id"].ToString();
                row.Cells.Add(cellID);

                TableCell cellName = new TableCell();
                cellName.Text = reader["name"].ToString();
                row.Cells.Add(cellName);

                TableCell cellPrice = new TableCell();
                cellPrice.Text = reader["price"].ToString();
                row.Cells.Add(cellPrice);

                TableCell cellDescription = new TableCell();
                cellDescription.Text = reader["description"].ToString();
                row.Cells.Add(cellDescription);

                TableCell cellPhoto = new TableCell();
                cellPhoto.Text = string.Format("<img src='Images/" + reader["image"] + "' class='imgTable'/>");
                row.Cells.Add(cellPhoto);

                
                Button delButton = new Button();
                delButton.ID = "delete" + reader["id"].ToString();
                delButton.CausesValidation = false;
                delButton.UseSubmitBehavior = false;
                delButton.Text = "USUŃ";
                delButton.CommandName = "{ 'id':" + reader["id"].ToString() + ",'row':"+x.ToString()+",'img':'" + reader["image"].ToString() + "'}";
                delButton.Click += new EventHandler(this.delButton_Click);

                images.Add(reader["image"].ToString());

                

                TableCell cellDelButt = new TableCell();
                cellDelButt.Controls.Add(delButton);
                row.Cells.Add(cellDelButt);


                tProducts.Rows.Add(row);
                x++;
            }
            reader.Close();
            }

            protected void delButton_Click(object sender, EventArgs e)
            {

                Button btn = sender as Button;
                Debug.WriteLine("KLIK");
                Debug.WriteLine(btn.CommandName);
                JObject jsonObject = JObject.Parse(btn.CommandName);
            
                command.CommandText = "DELETE FROM `products` WHERE `id` = "+ jsonObject["id"] + ";";
                command.ExecuteNonQuery();

                tProducts.Rows.RemoveAt(int.Parse(jsonObject["row"].ToString()));

            removeFiles(jsonObject["img"].ToString());
        }
           protected void removeFiles(string file)
        {
            int x = 0;
            foreach (string fileName in images)
            {
                if (file == fileName)
                {
                    images.RemoveAt(x);
                    break;
                }
                x++;
            }


           //ŚCIEŻKA DO ZMIANY 
            string path = "C:/Users/mateu/source/repos/gozabka/Sklep/Sklep/Images/";



           
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                string[] strlist = fileName.Split("/".ToCharArray());
                string lastOne = strlist[strlist.Length - 1];
                if (!images.Contains(lastOne))
                {
                    if ((System.IO.File.Exists(fileName)))
                    {
                        Debug.WriteLine("Usunięto plik: " + lastOne);
                        System.IO.File.Delete(fileName);
                    }
                }

            }
        }

    }
}