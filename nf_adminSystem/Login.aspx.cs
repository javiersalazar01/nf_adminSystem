using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace nf_adminSystem
{
    public partial class Login : System.Web.UI.Page
    {
        PgConnector pg = PgConnector.getInstance();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM usernf WHERE LOWER(name)=LOWER('" + userName.Text + "') AND LOWER(password)=LOWER('" + password.Text + "') AND userlevel != 4";
            //string query = "SELECT * FROM usernf WHERE LOWER(name)=LOWER('usuari0o INstitucion uni') AND LOWER(password)=LOWER('123') AND userlevel != 4";
            DataTable dt = pg.consultar(query);

            Session["algo"] = "algo";
            if (dt.Rows.Count == 1)
            {
                Session["iID"] = dt.Rows[0][0];
                Session["name"] = dt.Rows[0][1];
                Session["password"] = dt.Rows[0][2];
                Session["mail"] = dt.Rows[0][3];
                Session["userlevel"] = dt.Rows[0][4];
                Session["institution_id"] = dt.Rows[0][5];
                Session["key"] = dt.Rows[0][6];
                Session["verified"] = dt.Rows[0][7];
                //FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                FormsAuthentication.RedirectFromLoginPage("usuari0o INstitucion uni", true);
            }
            else
            {

            }
        }
    }
}