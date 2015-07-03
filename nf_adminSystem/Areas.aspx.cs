using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nf_adminSystem
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PgConnector pg = PgConnector.getInstance();
            if (!IsPostBack)
            {
                DataTable t = pg.consultar("select * from notification", "tabla");
                //t.Columns.Remove("iID");
                //t.Columns.RemoveAt(t.Columns.Count - 1);
                GridView1.DataSource = t;
                GridView1.DataBind();
            }
            else
            {

            }
            

            
        }
    }
}