using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nf_adminSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(Session["iID"]) + "," + Convert.ToString(Session["name"]) + "," + Convert.ToString(Session["password"]) + "," +  Convert.ToString(Session["mail"]) + "," + Convert.ToString(Session["userlevel"]);
        }
    }
}