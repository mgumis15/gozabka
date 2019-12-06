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
    public partial class Users : System.Web.UI.Page
    {
        MySqlConnection connection;
        MySqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {
                if (Session["type"].ToString() == "admin")
                {
                    connection = new MySqlConnection("Database=gozabka;Data Source=localhost;User Id=root;Password=");
                    connection.Open();
                    command = connection.CreateCommand();
                    getData();
                }
                else
                {
                    Session["name"] = null;
                    Session["id"] = null;
                    Session["type"] = null;
                    Response.Redirect("Logowanie.aspx");
                }
            }
            else
            {
                Session["name"] = null;
                Session["id"] = null;
                Session["type"] = null;
                Response.Redirect("Logowanie.aspx");
            }
        }

       
      

        protected void getData()
        {
            for (int i = tUsers.Rows.Count-1; i >1; i--)
            {
                    tUsers.Rows.RemoveAt(i);
                
            }
            command.CommandText = "select * from users";
            MySqlDataReader reader = command.ExecuteReader();

            int x = 1;
            
            while (reader.Read())

            {
                if (reader["type"].ToString() != "admin")
                {

               
                TableRow row = new TableRow();

                TableCell cellID = new TableCell();
                cellID.CssClass = "ajdi";
                cellID.Text = reader["id"].ToString();
                row.Cells.Add(cellID);

                TableCell cellName = new TableCell();
                cellName.CssClass = "Title";
                cellName.Text = reader["name"].ToString();
                row.Cells.Add(cellName);

                TableCell cellLogowania = new TableCell();
                cellLogowania.CssClass = "Title";
                cellLogowania.Text = reader["logowania"].ToString();
                row.Cells.Add(cellLogowania);



                    Button delButton = new Button();
                delButton.CssClass = "aspButton";
                delButton.ID = "delete" + reader["id"].ToString();
                delButton.CausesValidation = false;
                delButton.UseSubmitBehavior = false;
                delButton.Text = "USUŃ";
                delButton.CommandName = "{ 'id':" + reader["id"].ToString() + ",'row':"+x.ToString()+"}";
                delButton.Click += new EventHandler(this.delButton_Click);
                TableCell cellDelButt = new TableCell();
                cellDelButt.Controls.Add(delButton);
                row.Cells.Add(cellDelButt);



                DropDownList select = new DropDownList();
                select.CssClass = "aspSelect";

                ListItem idItem = new ListItem();
                idItem.Value = reader["id"].ToString();
                idItem.Enabled = false;
                ListItem trueItem = new ListItem();
                trueItem.Value = "TRUE";
                ListItem falseItem = new ListItem();
                falseItem.Value = "FALSE";
                if (reader["enable"].ToString() == "TRUE")
                {
                    trueItem.Selected = true;
                }
                else
                {
                    falseItem.Selected = true;

                }

                select.Items.Add(idItem); 
                select.Items.Add(trueItem);
                select.Items.Add(falseItem);
                select.SelectedIndexChanged += this.select_SelectedIndexChanged;
                select.AutoPostBack = true;

                TableCell cellSelect = new TableCell();
                cellSelect.Controls.Add(select);
                row.Cells.Add(cellSelect);




                    tUsers.Rows.Add(row);
                x++;
                }
            }
            reader.Close();
            }


        protected void select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddp = sender as DropDownList;
           
            command.CommandText = "UPDATE `users` SET `enable` = '" + ddp.SelectedValue + "' WHERE `users`.`id` = " + ddp.Items[0];
            command.ExecuteNonQuery();
           
        }
        //BUTTON OD RPZEKAZANIA DANYCH USUWANIA
        protected void delButton_Click(object sender, EventArgs e)
            {

                Button btn = sender as Button;
                hField.Value = btn.CommandName;
                delDiv.Style.Add("display", "block");
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            JObject jsonObject = JObject.Parse(hField.Value);

            delDiv.Style.Add("display", "none");
            command.CommandText = "DELETE FROM `users` WHERE `id` = " + jsonObject["id"] + ";";
            command.ExecuteNonQuery();

            tUsers.Rows.RemoveAt(int.Parse(jsonObject["row"].ToString()));
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
    }
}