<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RainforestBooks.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default transparancy">
        <div class="panel-body">
           
             <div class="row spacer">
                <div class ="col-sm-4 col-md-3"></div>
                <div class ="col-sm-4 col-md-2">
                    <label for="txtLogin" class="col-sm-2 control-label">Username:</label>
                </div>
                <div class ="col-sm-4 col-md-4">
                    <asp:TextBox ID="txtUsername" runat="server">

                    </asp:TextBox></div>
            </div>
            
            <div class="row spacer">
                <div class ="col-sm-4 col-md-3"></div>
                <div class ="col-sm-4 col-md-2">
                    <label for="txtPassword" class="col-sm-2 control-label">Password:</label>
                </div>
                <div class ="col-sm-4 col-md-4">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></div>
                </div>
            <div class="row spacer">
                <div class ="col-sm-4 col-md-5"></div>
                <div class ="col-sm-4 col-md-4"><asp:Button CssClass="btn btn-success btn-lg" runat="server" Text="Login" OnClick="btnLogin_Click"/></div>
                <div class ="col-sm-4 col-md-2"></div>
            </div>
            
        </div>
        </div>
</asp:Content>
