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

            }
        }

        public void clear()
        {
            GridView1.SelectedIndex = -1;

            ins = pg.consultar("SELECT \"iID\",name,password,mail FROM usernf WHERE userlevel = 1");
            GridView1.DataSource = ins;
            GridView1.DataBind();

            ins = pg.consultar("SELECT * FROM institution");
            
            ViewState["tipoTabla"] = "";

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

            GridView1.SelectedIndex = -1;
            string id = dwlSelect.SelectedValue;

            //Response.Write("<script>alert('"+query+"');</script>");
            DataTable dt = pg.consultar(query + id);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            l.Text = "--Todas Las " + msg + "--";
            l.Value = "0";
            dwlFill.Items.Insert(0, l);
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
            l.Text = "--Todas Las " + msg + "--";
            l.Value = "0";
            dwlFill.Items.Insert(0, l);
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
                    clear();
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
                   "SELECT s.\"iID\",s.name,s.description FROM area a, subarea s " +
                    "where a.\"iID\" = s.area_id AND a.\"iID\" = ",
                     "SubAreas",
                     "SELECT  u.\"iID\",u.name,u.password,u.mail FROM usernf u, user_area ua WHERE u.\"iID\" = ua.usernf_id  AND u.userlevel = 2 AND ua.area_id = "
                   );
                ViewState["tipoTabla"] = "area";
            }
            else
            {
                cambioSinReferencia(
                   DropDownList1,
                   DropDownList2,
                   "select a.\"iID\",a.name,a.description from " +
                   "institution i, area a WHERE a.institution_id = i.\"iID\" AND i.\"iID\" = ",
                   "Areas",
                   "SELECT u.\"iID\",u.name,u.password,u.mail FROM usernf u WHERE u.userlevel = 2 AND u.institution_id = " + DropDownList1.SelectedValue
                   );
                ViewState["tipoTabla"] = "";

            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue != "0")
            {
                cambio(DropDownList3,
                   "select u.\"iID\",u.name,u.password,u.mail from usernf u, user_subarea us where u.\"iID\" = us.usernf_id AND userlevel = 3 AND us.subarea_id = ");
                ViewState["tipoTabla"] = "subarea";

            }
            else
            {
                cambioSinReferencia(
                   DropDownList2,
                   DropDownList3,
                   "SELECT s.\"iID\",s.name,s.description FROM area a, subarea s " +
                    "where  a.\"iID\" = s.area_id AND a.\"iID\" = ",
                     "SubAreas",
                     "select  u.\"iID\",u.name,u.password,u.mail from usernf u, user_subarea us where u.\"iID\" = us.usernf_id AND userlevel = 3 AND userarea_id IN (select ua.\"iID\" from user_area ua where ua.area_id = " + DropDownList2.SelectedValue + ")"
                   );
                ViewState["tipoTabla"] = "";

            }
            
        }

        public void nuevo() {
            submitEditarInstitution.Text = "Crear";
            nameUsu.Text = "";
            mailUsu.Text = "";
            passwordUsu.Text = "";
            mpeNuevoUsuario.Show();
        }


        protected void newBtn_Click(object sender, EventArgs e)
        {
            string  tabla = Convert.ToString(ViewState["tipoTabla"]);
            switch (tabla)
            {
                case "institution":
                    nuevo();
                    break;

                case "area":
                    nuevo();
                    break;

                case "subarea":
                    nuevo();
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
                    case "institution":
                        //dt = pg.consultar("SELECT * FROM " + tabla + " WHERE \"iID\" = " + selectedId);
                        //nameIns.Text = Convert.ToString(dt.Rows[0][1]);
                        //descriptionIns.Text = Convert.ToString(dt.Rows[0][2]);
                        //imageIns.Text = Convert.ToString(dt.Rows[0][3]);
                        //submitEditarInstitution.Text = "Editar";
                        //mpeInstitution.Show();
                        break;

                    case "area":
                        dt = pg.consultar("SELECT * FROM " + tabla + " WHERE \"iID\" = " + selectedId);
                        nameAreaYsub.Text = Convert.ToString(dt.Rows[0][1]);
                        desAreaYsub.Text = Convert.ToString(dt.Rows[0][2]);
                        lblHeadrEditarCrear.Text = "Area";
                        submitEditarAreaYSubArea.Text = "Editar";
                        mpuAreaYSubArea.Show();
                        break;

                    case "subarea":
                        dt = pg.consultar("SELECT * FROM " + tabla + " WHERE \"iID\" = " + selectedId);
                        nameAreaYsub.Text = Convert.ToString(dt.Rows[0][1]);
                        desAreaYsub.Text = Convert.ToString(dt.Rows[0][2]);
                        lblHeadrEditarCrear.Text = "SubArea";
                        submitEditarAreaYSubArea.Text = "Editar";
                        mpuAreaYSubArea.Show();
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
            string campo4;
            string campo5;
            string querys;

            switch (editarOCrear)
            {
                case "editar":
                        string selectedId =  GridView1.SelectedRow.Cells[0].Text;
                      
                        switch (tabla)
                        {
                            case "institution":
                                //campo1 = nameIns.Text;
                                //campo2 = descriptionIns.Text;
                                //campo3 = imageIns.Text;
                                //pg.modificar("UPDATE " + tabla + " SET name = '" + campo1 + "' ,description = '" + campo2 + "',image = '" + campo3 + "' WHERE \"iID\" = " + selectedId);
                                //update();
                                //mpeInstitution.Hide();
                                break;

                            case "area":
                                campo1 = nameAreaYsub.Text;
                                campo2 = desAreaYsub.Text;
                                pg.modificar("UPDATE " + tabla + " SET name = '" + campo1 + "' ,description = '" + campo2 + "' WHERE \"iID\" = " + selectedId);
                                update();
                                mpuAreaYSubArea.Hide();
                                break;

                            case "subarea":
                                campo1 = nameAreaYsub.Text;
                                campo2 = desAreaYsub.Text;
                                pg.modificar("UPDATE " + tabla + " SET name = '" + campo1 + "' ,description = '" + campo2 + "' WHERE \"iID\" = " + selectedId);
                                update();
                                mpuAreaYSubArea.Hide();
                                break;

                            case "notification":
                                campo1 = titleNoti.Text;
                                campo2 = desNotifi.Text;
                                DateTime dt = DateTime.Now;
                                campo4 = imageNoti.Text;
                                campo5 = urlNoti.Text;
                                pg.modificar("UPDATE " + tabla + " SET title = '" + campo1 + "' ," +
                                                "description = '" + campo2 + "' ,date = '" + dt.ToString("yyyy-MM-dd") + "' ," +
                                                "image = '" + campo4 + "',url = '" + campo5 + "' WHERE \"iID\" = " + selectedId);
                                update();
                                mpeNotification.Hide();
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
                                querys = "INSERT INTO usernf(name, password, mail, userlevel, institution_id, key, verified) VALUES ( '" + campo1 + "', '" + campo2 + "', '" + campo3 + "', 2, " + DropDownList1.SelectedValue + ", '', false);";
                                pg.modificar(querys);
                                pg.modificar("INSERT INTO user_area (usernf_id, area_id) VALUES (?, ?, ?);");
                                update();
                                mpeNuevoUsuario.Hide();
                            break;

                        case "subarea":
                            campo1 = nameAreaYsub.Text;
                            campo2 = desAreaYsub.Text;
                            pg.modificar("INSERT INTO " + tabla + " (name, description, area_id) VALUES ( '" + campo1 + "', '" + campo2 + "', '" + DropDownList2.SelectedValue + "');");
                            update();
                            mpuAreaYSubArea.Hide();
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
                string tipoTabla = ViewState["tipoTabla"].ToString();
                string query = "DELETE FROM " + tipoTabla + " WHERE \"iID\"= " + selectedID;
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

        protected void btnEditarAreaSubCancelar_Click(object sender, EventArgs e)
        {
            mpuAreaYSubArea.Hide();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditarNotificationCancelar_Click(object sender, EventArgs e)
        {
            mpeNotification.Hide();
        }

        

        

     
        
    }
}