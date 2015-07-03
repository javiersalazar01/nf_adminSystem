<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Areas.aspx.cs" Inherits="nf_adminSystem.Inicio" EnableEventValidation="False"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="page-wrapper">
            <div class="row">
                <!-- Page Header -->
                <div class="col-lg-12 margin-top-20">
                    <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                            
                        </asp:DropDownList>
                    </div>
                     <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" >
                            <asp:ListItem>Area 1</asp:ListItem>
                            <asp:ListItem>Area 2</asp:ListItem>
                            <asp:ListItem>Area 3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class ="col-lg-2" >
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" >
                            <asp:ListItem>SubArea 1</asp:ListItem>
                            <asp:ListItem>SubArea 2</asp:ListItem>
                            <asp:ListItem>SubArea 3</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                    <div class="col-lg-1 col-lg-offset-3"> 
                        <asp:LinkButton ID="newBtn" CssClass="btn btn-default fa fa-plus" OnClick="newBtn_Click" runat="server"></asp:LinkButton>
                        <%--<asp:ImageButton ID="new" runat="server" CssClass="btn btn-default fa fa-plus" OnClick="new_Click" AlternateText=" " />--%> 
                    </div>

                    <div class="col-lg-1">   
                        <asp:LinkButton ID="editBtn" CssClass="btn btn-default fa fa-pencil-square-o" OnClick="editBtn_Click" runat="server"></asp:LinkButton>
                    </div> 
                    <div class="col-lg-1"> 
                        <asp:LinkButton ID="eraseBtn" CssClass="bnt btn-default fa fa-eraser" OnClick="eraseBtn_Click" runat="server"></asp:LinkButton>
                      
                    </div>   
                </div>
                <!--End Page Header -->
            </div>
         <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover margin-top-30" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
             <Columns>
             </Columns>
         </asp:GridView>
     </div>

</asp:Content>
