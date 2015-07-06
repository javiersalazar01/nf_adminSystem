<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="nf_adminSystem.Inicio" EnableEventValidation="False"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField2" runat="server" Value="123" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="123" />
    
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
                         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover margin-top-30" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                             <Columns>
                             </Columns>
                         </asp:GridView>

                
         
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
            </div>
        
   
</asp:Content>
