using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nf_adminSystem
{
    public partial class Inicio : System.Web.UI.Page
    {
        DataTable ins;
        PgConnector pg = PgConnector.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
            }
        }

        public void clear()
        {
            ins = pg.consultar("SELECT * FROM institution");
            DataTable insClon = ins.Copy();
            insClon.Columns.Remove("iID");
            GridView1.DataSource = insClon;
            GridView1.DataBind();
            DropDownList1.DataSource = ins;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "iID";
            DropDownList1.DataBind();
            ListItem l = new ListItem();
            l.Text = "--Todas Las Instituciones--";
            l.Value = "0";
            DropDownList1.Items.Insert(0, l);

            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Seleccione Institucion");
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("Seleccione Area");
        }


        public void cambio(DropDownList dwlSelect, string query)
        {
            string id = dwlSelect.SelectedValue;

            //Response.Write("<script>alert('"+query+"');</script>");
            DataTable instXArea = pg.consultar(query + id);
            DataTable Clon = instXArea.Copy();
            Clon.Columns.RemoveAt(0);
            GridView1.DataSource = Clon;
            GridView1.DataBind();
        }


        public void cambio(DropDownList dwlSelect, DropDownList dwlFill, string query,string msg)
        {
            string id = dwlSelect.SelectedValue;

            //Response.Write("<script>alert('"+query+"');</script>");
            DataTable instXArea = pg.consultar(query + id);
            DataTable Clon = instXArea.Copy();
            Clon.Columns.RemoveAt(0);
            GridView1.DataSource = Clon;
            GridView1.DataBind();

            dwlFill.DataSource = instXArea;
            dwlFill.DataTextField = "name";
            dwlFill.DataValueField = "iID";
            dwlFill.DataBind();

            ListItem l = new ListItem();
            l.Text = "--Todas Las " + msg + "--";
            l.Value = "0";
            dwlFill.Items.Insert(0, l);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click Para Seleccionar";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click Para Seleccionar";
                }
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "0")
            {
                cambio(
                   DropDownList1,
                   DropDownList2,
                   "select a.\"iID\",a.name,a.description from " +
                   "institution i, area a WHERE a.institution_id = i.\"iID\" AND i.\"iID\" = ",
                   "Areas"
                   );
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("Seleccione Area");
            }
            else
            {
                clear();
            }
            
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "0")
            {
                cambio(
                   DropDownList2,
                   DropDownList3,
                   "SELECT s.\"iID\",s.name,s.description FROM institution i, area a, subarea s " +
                    "where a.institution_id = i.\"iID\" AND a.\"iID\" = s.area_id AND a.\"iID\" = ",
                     "SubAreas"
                   );
            }
            else
            {
                cambio(
                   DropDownList1,
                   DropDownList2,
                   "select a.\"iID\",a.name,a.description from " +
                   "institution i, area a WHERE a.institution_id = i.\"iID\" AND i.\"iID\" = ",
                   "Areas"
                   );
            }
            
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "0")
            {
                cambio(DropDownList3,
                   "SELECT n.\"iID\",n.title,n.description,n.image,n.date " +
                   "FROM subarea s,notification n where s.\"iID\" = n.subarea_id AND s.\"iID\" = ");
            }
            else
            {
                cambio(
                   DropDownList2,
                   DropDownList3,
                   "SELECT s.\"iID\",s.name,s.description FROM institution i, area a, subarea s " +
                    "where a.institution_id = i.\"iID\" AND a.\"iID\" = s.area_id AND a.\"iID\" = ",
                     "SubAreas"
                   );
            }
            
        }


        protected void newBtn_Click(object sender, EventArgs e)
        {

        }

        protected void editBtn_Click(object sender, EventArgs e)
        {

        }

        protected void eraseBtn_Click(object sender, EventArgs e)
        {

        }

        
    }
}