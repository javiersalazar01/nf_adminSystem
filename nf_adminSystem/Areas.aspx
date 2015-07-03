<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="nf_adminSystem.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="page-wrapper">
            <div class="row">
                <!-- Page Header -->
                <div class="col-lg-12 margin-top-20">
                    <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                            <asp:ListItem>UNISON</asp:ListItem>
                            <asp:ListItem>ITH</asp:ListItem>
                            <asp:ListItem>UTH</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                            <asp:ListItem>Area 1</asp:ListItem>
                            <asp:ListItem>Area 2</asp:ListItem>
                            <asp:ListItem>Area 3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                            <asp:ListItem>SubArea 1</asp:ListItem>
                            <asp:ListItem>SubArea 2</asp:ListItem>
                            <asp:ListItem>SubArea 3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-1 col-lg-offset-3">   
                        <a href="#" class="btn btn-default">
                            <span class="fa fa-plus"></span>
                        </a>
                    </div>
                    <div class="col-md-1">   
                        <a href="#" class="btn btn-default">
                            <span class="fa fa-pencil-square-o"></span>
                        </a>
                    </div> 
                    <div class="col-md-1">   
                        <a href="#" class="btn btn-default">
                            <span class="fa fa-eraser"></span>
                        </a>
                    </div>   
                </div>
                <!--End Page Header -->
            </div>
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover margin-top-30"></asp:GridView>
     </div>

</asp:Content>
