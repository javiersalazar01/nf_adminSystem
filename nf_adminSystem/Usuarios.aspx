<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="nf_adminSystem.Usuarios" EnableEventValidation="False"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField2" runat="server" Value="123" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="123" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
             <div id="page-wrapper">
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 <asp:UpdatePanel ID="UpdatePanelTodo" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <!-- Page Header -->
                            <div class="col-lg-12 margin-top-20">
                                <div class ="col-lg-2" >
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                            
                                    </asp:DropDownList>
                                </div>
                                 <div class ="col-lg-2" >
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" >
                            
                                    </asp:DropDownList>
                                </div>
                                <div class ="col-lg-2" >
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                            
                                    </asp:DropDownList>
                                </div>


                                <div class="col-lg-1 col-lg-offset-3"> 
                                    <asp:LinkButton ID="newBtn" CssClass="btn btn-default fa fa-plus" OnClick="newBtn_Click" runat="server"></asp:LinkButton>
                                </div>

                                <div class="col-lg-1">   
                                    <asp:LinkButton ID="editBtn" CssClass="btn btn-default fa fa-pencil-square-o" OnClick="editBtn_Click" runat="server"></asp:LinkButton>

                                </div> 
                                <div class="col-lg-1"> 
                                    <asp:LinkButton ID="eraseBtn" CssClass="btn btn-default fa fa-eraser" OnClick="eraseBtn_Click" runat="server"></asp:LinkButton>
                                </div>   
                            </div>
                            <!--End Page Header -->
                        </div>

                 <%-- grid donde se muestra la informacion --%>
                         <asp:GridView ID="GridView1" runat="server" CssClass="bordered margin-top-30" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                             <Columns>
                             </Columns>
                         </asp:GridView>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                
         
                    </ContentTemplate>
                </asp:UpdatePanel>

                  <%--Mensage en caso de no seleccionar registro--%>
                
                 <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" style="display:none" >
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                <div class="header">
                                    <p><% Response.Write(headerText); %></p>
                                </div>
                                <div class="body">
                                    <p><% Response.Write(bodyText); %></p>
                                </div>
                                <div class="footer" style="text-align: right;">
                                    <asp:Button ID="Button1"  runat="server" Text="Acceptar" CssClass="yes" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>    
                 </asp:Panel>

                 <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server"  PopupControlID="Panel2" 
                     OkControlID="Button1" DropShadow="true" TargetControlID="HiddenField2" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                 <%-- Panel donde se muestra el mensage para eliminar un registro --%>
         
                     <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none"> 
                         <asp:UpdatePanel ID="PanelUpdate" runat="server" >
                            <ContentTemplate>
                                <div class="header">
                                    Confirmacion
                                </div>
                                <div class="body">
                                    <p>Si elimina este registro, se eliminaran todos los registros anidados <br />
                                        si esta seguro, porfavor introdusca su contraseña. <br />
                                    </p>
                    
                                    <asp:TextBox ID="securityPassword" TextMode="password" CssClass="centro form-control" runat="server" ></asp:TextBox> 
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="footer" style="text-align: right;" >
                                    <asp:Button ID="btnYes" runat="server" Text="Acceptar" CssClass="yes" OnClick="btnYes_Click" />
                                    <asp:Button ID="btnNo" runat="server" Text="Cancelar" CssClass="no"  OnClick="btnNo_Click"/>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </asp:Panel>
            
                 <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  PopupControlID="Panel1" 
                     CancelControlID="btnNo" DropShadow="true"  TargetControlID="HiddenField1" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


                 <%-- Panel Nuevo usuario  --%>
          
                     <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup" style="display:none; width: 170%;"> 
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                            <ContentTemplate>
                                <div class="header">
                                    Institucion
                                </div>
                                <div class="body">
                                    <asp:Label ID="Label3" runat="server" Text="nombre:"></asp:Label>
                                    <asp:TextBox ID="nameUsu" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox>
                                    <br />

                                    <asp:Label ID="Label4" runat="server" Text="Mail: "></asp:Label>
                                    <asp:TextBox ID="mailUsu" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox> 

                                    <br />
                                    <asp:Label ID="Label5" runat="server" Text="Contraseña:"></asp:Label>
                                    <asp:TextBox ID="passwordUsu" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox> 
                                    
                                </div>
                                <div class="footer" style="text-align: right;" >
                                    <asp:Button ID="submitEditarInstitution" runat="server" Text="Editar" CssClass="yes" OnClick="submitEditarInstitution_Click" />
                                    <asp:Button ID="btnEditarInsCancelar" runat="server" Text="Cancelar" CssClass="no" OnClick="btnEditarInsCancelar_Click"/>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </asp:Panel>
            
                 <cc1:ModalPopupExtender ID="mpeNuevoUsuario" runat="server"  PopupControlID="Panel3"
                     CancelControlID="btnEditarInsCancelar" DropShadow="true" TargetControlID="HiddenField3" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>


                 <%-- Panel Editar/crear Area y SubArea  --%>
                     <asp:Panel ID="Panel4" runat="server" CssClass="modalPopup" style="display:none; width: 170%;"> 
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                            <ContentTemplate>
                                <div class="header">
                                    <asp:Label ID="lblHeadrEditarCrear" runat="server" Text="Label"></asp:Label>
                                </div>
                                <div class="body">

                                    <asp:Label ID="Label6" runat="server" Text="nombre"></asp:Label>
                                    <asp:TextBox ID="nameAreaYsub" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox> 
                                    <br />

                                    <asp:Label ID="Label7" runat="server" Text="descripcion: "></asp:Label>
                                    <asp:TextBox ID="desAreaYsub" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox> 

                                    
                                </div>
                                <div class="footer" style="text-align: right;" >
                                    <asp:Button ID="submitEditarAreaYSubArea" runat="server" Text="Editar" CssClass="yes" OnClick="submitEditarInstitution_Click" />
                                    <asp:Button ID="btnEditarAreaSubCancelar" runat="server" Text="Cancelar" CssClass="no" OnClick="btnEditarAreaSubCancelar_Click"/>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </asp:Panel>
            
                 <cc1:ModalPopupExtender ID="mpuAreaYSubArea" runat="server"  PopupControlID="Panel4"
                      DropShadow="true" TargetControlID="HiddenField4" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

                 <%-- Panel Editar/crear Notification  --%>
         
                     <asp:Panel ID="Panel5" runat="server" CssClass="modalPopup" style="display:none; width: 170%;"> 
                         <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                            <ContentTemplate>
                                <div class="header">
                                    Notificacion
                                </div>
                                <div class="body">

                                    <asp:Label ID="Label9" runat="server" Text="Titulo"></asp:Label>
                                    <asp:TextBox ID="titleNoti" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox> 

                                    <br />
                                    <asp:Label ID="Label10" runat="server" Text="descripcion: "></asp:Label>
                                    <asp:TextBox ID="desNotifi" TextMode="MultiLine" style="resize:none;" CssClass="centro form-control" runat="server" Rows="7" ></asp:TextBox>
                                    

                                    <br />
                                    <asp:Label ID="Label12" runat="server" Text="Imagen: "></asp:Label>
                                    <asp:TextBox ID="imageNoti" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox>  

                                    <br />
                                    <asp:Label ID="Label13" runat="server" Text="Url: "></asp:Label>
                                    <asp:TextBox ID="urlNoti" TextMode="SingleLine" CssClass="centro form-control" runat="server" ></asp:TextBox>  

                                    
                                </div>
                                <div class="footer" style="text-align: right;" >
                                    <asp:Button ID="submitEditarNotification" runat="server" Text="Editar" CssClass="yes" OnClick="submitEditarInstitution_Click" />
                                    <asp:Button ID="btnEditarNotificationCancelar" runat="server" Text="Cancelar" CssClass="no" OnClick="btnEditarNotificationCancelar_Click"/>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                  </asp:Panel>
            
                 <cc1:ModalPopupExtender ID="mpeNotification" runat="server"  PopupControlID="Panel5"
                      DropShadow="true" TargetControlID="HiddenField5" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>

            </div>
        
   
</asp:Content>
