<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="nf_adminSystem.Calendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="assets/css/calendar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-wrapper">

            <div class="row">
                <!-- Page Header -->
                <div class="col-lg-12">
                    <h1 class="page-header">Calendario</h1>
                </div>
                <!--End Page Header -->
                   <div class="wrapper">
                       <div id="calendari"></div>   
                   </div>
            </div>

        </div>
        <!-- end page-wrapper -->
     <script src="assets/scripts/calendar.js"></script>
</asp:Content>
