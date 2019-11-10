using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep
{
    public partial class FormularzLogowania : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
           
        }
    }
}