using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nf_adminSystem
{
    public partial class Usuarios : System.Web.UI.Page
    {
        DataTable ins;
        PgConnector pg = PgConnector.getInstance();
        public string bodyText = "";
        public string headerText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField1.Value = "123";
            if (!IsPostBack)
            {
                clear();
                int userlevel = Convert.ToInt32(Session["userlevel"]);
                string institution_id = Convert.ToString(Session["institution_id"]);
                string areaid;
                string usernfid;
                DataTable res;

                for (int i = 1; i <= userlevel; i++)
                {
                    if (userlevel == 3 && i == 2)
                    {
                        i++;
                    }

                    switch (i)
                    {
                        case 1:

                            DropDownList1.SelectedValue = institution_id;
                            DropDownList1.Enabled = false;

                            DropDownList1_SelectedIndexChanged(null, EventArgs.Empty);

                            GridView1.DataSource = null;
                            GridView1.DataBind();

                            if (DropDownList1.Items.Count > 0)
                            {
                                DropDownList2.SelectedIndex = 1;
                                DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);

                            }


                            break;

                        case 2:

                            usernfid = Convert.ToString(Session["iID"]);
                            res = pg.consultar("SELECT area_id FROM user_area WHERE usernf_id = " + usernfid);
                            areaid = Convert.ToString(res.Rows[0][0]);
                            DropDownList2.SelectedValue = areaid;
                            DropDownList2.Enabled = false;

                            DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);

                            ViewState["tipoTabla"] = "area";
                            Label2.Text = DropDownList2.SelectedValue;

                            GridView1.DataSource = null;
                            GridView1.DataBind();

                            if (DropDownList2.Items.Count > 0)
                            {
                                DropDownList3.SelectedIndex = 1;
                                DropDownList3_SelectedIndexChanged(null, EventArgs.Empty);

                            }

                            break;

                        case 3:

                            usernfid = Convert.ToString(Session["iID"]);
                            res = pg.consultar("SELECT area_id FROM user_subarea WHERE usernf_id = " + usernfid);
                            areaid = Convert.ToString(res.Rows[0][0]);
                            DropDownList2.SelectedValue = areaid;
                            DropDownList2.Enabled = false;

                            DropDownList2_SelectedIndexChanged(null, EventArgs.Empty);


                            res = pg.consultar("SELECT subarea_id FROM user_subarea WHERE usernf_id = " + usernfid);
                            areaid = Convert.ToString(res.Rows[0][0]);
                            DropDownList3.SelectedValue = areaid;
                            DropDownList3.Enabled = false;

                            DropDownList3_SelectedIndexChanged(null, EventArgs.Empty);

                            GridView1.DataSource = null;
                            GridView1.DataBind();


                            break;
                    }
                }
            }
        }

        public void clear()
        {
            GridView1.SelectedIndex = -1;

            //ins = pg.consultar("SELECT \"iID\",name,password,mail FROM usernf WHERE userlevel = 1");
            //GridView1.DataSource = ins;
            //GridView1.DataBind();

            ins = pg.consultar("SELECT * FROM institution");
            
            ViewState["tipoTabla"] = "";

            DropDownList1.DataSource = ins;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "iID";
            DropDownList1.DataBind();
            ListItem l = new ListItem();
            l.Text = "--Seleccione Institucion--";
            l.Value = "0";
            DropDownList1.Items.Insert(0, l);

            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("--Seleccione Institucion--");
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("--Seleccione Area--");

            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "No Existen Registros.";
                Label2.Font.Size = FontUnit.Larger;
            }
            else
            {
                Label2.Text = "";
                Label2.Font.Size = FontUnit.Medium;
            }
            
        }


        public void cambio(DropDownList dwlSelect, string query)
        {

            GridView1.SelectedIndex = -1;
            string id = dwlSelect.SelectedValue;

            //Response.Write("<script>alert('"+query+"');</script>");
            DataTable dt = pg.consultar(query + id);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "No Existen Registros.";
                Label2.Font.Size = FontUnit.Larger;
            }
            else
            {
                Label2.Text = "";
                Label2.Font.Size = FontUnit.Medium;
            }
        }


        public void cambio(DropDownList dwlSelect, DropDownList dwlFill, string query,string msg,string queryGrid)

        {
            GridView1.SelectedIndex = -1;
            string id = dwlSelect.SelectedValue;

            DataTable dt = pg.consultar(queryGrid + id);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            dt = pg.consultar(query + id);
            dwlFill.DataSource = dt;
            dwlFill.DataTextField = "name";
            dwlFill.DataValueField = "iID";
            dwlFill.DataBind();

            ListItem l = new ListItem();
            l.Text = "--Seleccione " + msg + "--";
            l.Value = "0";
            dwlFill.Items.Insert(0, l);

            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "No Existen Registros.";
                Label2.Font.Size = FontUnit.Larger;
            }
            else
            {
                Label2.Text = "";
                Label2.Font.Size = FontUnit.Medium;
            }
        }

        public void cambioSinReferencia(DropDownList dwlSelect, DropDownList dwlFill, string query, string msg, string queryGrid)
        {
            GridView1.SelectedIndex = -1;
            string id = dwlSelect.SelectedValue;

            DataTable dt = pg.consultar(queryGrid);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            dt = pg.consultar(query + id);
            dwlFill.DataSource = dt;
            dwlFill.DataTextField = "name";
            dwlFill.DataValueField = "iID";
            dwlFill.DataBind();

            ListItem l = new ListItem();
            l.Text = "--seleccione " + msg + "--";
            l.Value = "0";
            dwlFill.Items.Insert(0, l);

            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "No Existen Registros.";
                Label2.Font.Size = FontUnit.Larger;
            }
            else
            {
                Label2.Text = "";
                Label2.Font.Size = FontUnit.Medium;
            }
        }

        public void update() {
            string tipoTabla = ViewState["tipoTabla"].ToString();
            switch (tipoTabla)
            {
                case "subarea":
                    cambio(DropDownList3,
                        "select u.\"iID\",u.name,u.password,u.mail from usernf u, user_subarea us where u.\"iID\" = us.usernf_id AND userlevel = 3 AND us.subarea_id = ");
                    break;

                case "area":
                    cambio(
                       DropDownList2,
                       DropDownList3,
                       "SELECT s.\"iID\",s.name,s.description FROM area a, subarea s " +
                        "where a.\"iID\" = s.area_id AND a.\"iID\" = ",
                         "SubAreas",
                         "SELECT  u.\"iID\",u.name,u.password,u.mail FROM usernf u, user_area ua WHERE u.\"iID\" = ua.usernf_id  AND u.userlevel = 2 AND ua.area_id = "
                       );
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Add("Seleccione Area");
                    break;

                case "institution":
                    cambio(
                       DropDownList1,
                       DropDownList2,
                       "select a.\"iID\",a.name,a.description from " +
                       "institution i, area a WHERE a.institution_id = i.\"iID\" AND i.\"iID\" = ",
                       "Areas",
                       "select u.\"iID\",u.name,u.password,u.mail from usernf u where userlevel = 1 AND institution_id = ");
                    ViewState["tipoTabla"] = "institution";
                    DropDownList3.Items.Clear();
                    DropDownList3.Items.Add("Seleccione Area");
                    break;
            }
        }

        public void msgPopUp(string header, string body)
        {
            bodyText = body;
            headerText = header;
            ModalPopupExtender2.Show();

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
                   "Areas",
                   "select u.\"iID\",u.name,u.password,u.mail from usernf u where userlevel = 1 AND institution_id = ");
                ViewState["tipoTabla"] = "institution";
                DropDownList3.Items.Clear();
                DropDownList3.Items.Add("Seleccione Area");

                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {
                
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownList2.SelectedValue != "0")
            {
                cambio(
                   DropDownList2,
                   DropDownList3,
                   "SELECT s.\"iID\",s.name,s.description FROM area a, subarea s " +
                    "where a.\"iID\" = s.area_id AND a.\"iID\" = ",
                     "SubAreas",
                     "SELECT  u.\"iID\",u.name,u.password,u.mail FROM usernf u, user_area ua WHERE u.\"iID\" = ua.usernf_id  AND u.userlevel = 2 AND ua.area_id = "
                   );
                ViewState["tipoTabla"] = "area";

                DataTable dt = pg.consultar("SELECT s.\"iID\",s.name,s.description FROM area a, subarea s " +
                    "where a.\"iID\" = s.area_id AND a.\"iID\" = " + DropDownList2.SelectedValue);

                DropDownList4.DataSource = dt;
                DropDownList4.DataTextField = "name";
                DropDownList4.DataValueField = "iID";
                DropDownList4.DataBind();

                ListItem l = new ListItem();
                l.Text = "--Seleccione SubArea--";
                l.Value = "0";
                DropDownList4.Items.Insert(0, l);

                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {
                
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "0")
            {
                cambio(DropDownList3,
                   "select u.\"iID\",u.name,u.password,u.mail from usernf u, user_subarea us where u.\"iID\" = us.usernf_id AND userlevel = 3 AND us.subarea_id = ");
                ViewState["tipoTabla"] = "subarea";
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {
                
            }
            
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.SelectedIndex = -1;
            string id = DropDownList4.SelectedValue;

            //Response.Write("<script>alert('"+query+"');</script>");
            DataTable dt = pg.consultar("SELECT u.\"iID\",u.name,u.password,u.mail FROM subarea_user su,usernf u where u.\"iID\" = su.user_id AND subarea_id = " + id);

            GridView2.DataSource = dt;
            GridView2.DataBind();
            //if (GridView2.Rows.Count == 0)
            //{
            //    Label2.Text = "No Existen Registros.";
            //    Label2.Font.Size = FontUnit.Larger;
            //}
            //else
            //{
            //    Label2.Text = "";
            //}
        }

        private void nuevo(string header) {
            newHeader.Text = header;
            submitEditarInstitution.Text = "Crear";
            nameUsu.Text = "";
            mailUsu.Text = "";
            passwordUsu.Text = "";
            mpeNuevoUsuario.Show();
        }

        protected void newBtn_Click(object sender, EventArgs e)
        {
            string tabla = Convert.ToString(ViewState["tipoTabla"]);
            switch (tabla)
            {
                case "institution":
                    nuevo("Nuevo Usuario Institucion");
                    break;
                case "area":
                    nuevo("Nuevo Usuario Area");
                    break;
                case "subarea":
                    nuevo("Nuevo Usuario SubArea");
                    break;
            }
            ViewState["editarCrear"] = "crear";
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            string tabla = "";
            DataTable dt;
            string selectedId;

            if (GridView1.SelectedIndex == -1)
	        {
		        msgPopUp("Error","Seleccione un elemento.");
                ModalPopupExtender2.Show();
	        }
            else
	        {
                ViewState["editarCrear"] = "editar";
                selectedId = GridView1.SelectedRow.Cells[0].Text;
                tabla = Convert.ToString(ViewState["tipoTabla"]);
                switch (tabla)
                {
                    case "":
                        break;

                    default :
                        dt = pg.consultar("SELECT * FROM usernf WHERE \"iID\" = " + selectedId);
                        nameUsu.Text = Convert.ToString(dt.Rows[0][1]);
                        passwordUsu.Text = Convert.ToString(dt.Rows[0][2]);
                        mailUsu.Text = Convert.ToString(dt.Rows[0][3]);
                        submitEditarInstitution.Text = "Editar";
                        mpeNuevoUsuario.Show();
                        break;
                }
	        }
            
            //Label2.Text = GridView1.SelectedRow.Cells[0].Text;
            
        }

        protected void submitEditarInstitution_Click(object sender, EventArgs e)
        {
            string tabla = Convert.ToString(ViewState["tipoTabla"]);
            string editarOCrear = Convert.ToString(ViewState["editarCrear"]);
            string campo1;
            string campo2;
            string campo3;
            string querys;
            bool res;

            switch (editarOCrear)
            {
                case "editar":
                        string selectedId =  GridView1.SelectedRow.Cells[0].Text;
                      
                        switch (tabla)
                        {
                            case "":
                                
                                break;

                            default:
                                campo1 = nameUsu.Text;
                                campo2 = passwordUsu.Text;
                                campo3 = mailUsu.Text;
                                pg.modificar("UPDATE usernf SET name = " + campo1 + ", password=" + campo2 + ", mail = " + campo3 + " WHERE \"iID\" = " + selectedId);
                                update();
                                mpeNuevoUsuario.Hide();
                                break;
                        }
                    break;

                case "crear":
                    switch (tabla)
                    {
                        case "institution":
                                campo1 = nameUsu.Text;
                                campo2 = mailUsu.Text;
                                campo3 = passwordUsu.Text;
                                querys = "INSERT INTO usernf(name, password, mail, userlevel, institution_id, key, verified) VALUES ( '" + campo1 + "', '" + campo2 + "', '" + campo3 + "', 1, " + DropDownList1.SelectedValue + ", '', false);";
                                pg.modificar(querys);
                                Label2.Text = querys;
                                update();
                                DataTable ins = pg.consultar("SELECT \"iID\",name,password,mail FROM usernf WHERE userlevel = 1");
                                GridView1.DataSource = ins;
                                GridView1.DataBind();
                                mpeNuevoUsuario.Hide();
                            break;

                        case "area":
                                campo1 = nameUsu.Text;
                                campo2 = mailUsu.Text;
                                campo3 = passwordUsu.Text;
                                res = pg.nuevoUsuarioArea(campo1, campo3, campo2, 2, Convert.ToInt32(DropDownList1.SelectedValue), "", false, Convert.ToInt32(DropDownList2.SelectedValue));
                                if (res)
                                {
                                    update();
                                    mpeNuevoUsuario.Hide();
                                    msgAlerta.Text = "";
                                }
                                else
                                {
                                    msgAlerta.Text = "Mail de usuario ya existe";
                                }
                            break;

                        case "subarea":
                                campo1 = nameUsu.Text;
                                campo2 = mailUsu.Text;
                                campo3 = passwordUsu.Text;
                                res = pg.nuevoUsuarioSubArea(campo1, campo3, campo2, 3, Convert.ToInt32(DropDownList1.SelectedValue), "", false, Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue));

                                if (res)
                                {
                                    update();
                                    mpeNuevoUsuario.Hide();
                                    msgAlerta.Text = "";
                                }
                                else
                                {
                                    msgAlerta.Text = "Mail de usuario ya existe";
                                }
                            break;

                    }
                break;
            }
        }

        protected void eraseBtn_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex == -1)
            {
                msgPopUp("Error","Seleccione un elemento.");
                ModalPopupExtender2.Show();
            }
            else
            {
               //msgPopUp("Error", GridView1.SelectedIndex.ToString());
                Label1.Text = "";
                ModalPopupExtender1.Show();
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            
            string securityPass = securityPassword.Text;
            if (securityPass == "123")
            {
                
                string selectedID = GridView1.SelectedRow.Cells[0].Text;
                string query = "DELETE FROM usernf WHERE \"iID\"= " + selectedID;
                if (pg.modificar(query))
                {
                    //Response.Write("<script>alert('Restros Eliminados - " + query + "');</script>");
                    ModalPopupExtender1.Hide();
                    update();
                }
                else
                {
                    Response.Write("<script>alert('Restros No Eliminados');</script>");
                }
            }
            else
            {
                Label1.Text = "Contraseña Incorrecta";
                Label1.ForeColor = Color.Red;
            }
           
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click Para Seleccionar";
            }

            e.Row.Cells[0].Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = GridView1.SelectedIndex;
            
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

        protected void btnEditarInsCancelar_Click(object sender, EventArgs e)
        {
            mpeNuevoUsuario.Hide();
        }

        
        
    }
}