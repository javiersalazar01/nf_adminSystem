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
            string query = "SELECT * FROM usernf WHERE LOWER(name)=LOWER('" + Login1.UserName + "') AND LOWER(password)=LOWER('" + Login1.Password + "') AND userlevel != 4";
            DataTable dt = pg.consultar(query);
            Label1.Text = Convert.ToString(dt.Rows.Count);
            
            Session["algo"] = "algo";
            if (dt.Rows.Count == 1)
            {
                Label1.Text = "si jalo";
                Session["iID"] = dt.Rows[0][0];
                Session["name"] = dt.Rows[0][1];
                Session["password"] = dt.Rows[0][2];
                Session["mail"] = dt.Rows[0][3];
                Session["userlevel"] = dt.Rows[0][4];
                Session["institution_id"] = dt.Rows[0][5];
                Session["key"] = dt.Rows[0][6];
                Session["verified"] = dt.Rows[0][7];
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
            else
            {
                Label1.Text = "no jalo";
            }
            
        }
    }
}