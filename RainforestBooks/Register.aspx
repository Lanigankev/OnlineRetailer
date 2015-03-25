<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RainforestBooks.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="panel panel-default transparancy">
    <div class="panel-body">
        <div class="form-group">
    <label for="txtFName" class="col-sm-2 control-label">First Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
          <asp:Label ID="lblFName" runat="server" Visible="False">** First name must not be empty</asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtLName" class="col-sm-2 control-label">Last Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
          <asp:Label ID="lblLName" runat="server" Text="** Last name must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtAddress1" class="col-sm-2 control-label">Address1</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress1" runat="server" Text="** Address must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtAddress2" class="col-sm-2 control-label">Address2</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress2" runat="server" Text="** Address must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtCity" class="col-sm-2 control-label">City</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
          <asp:Label ID="lblCity" runat="server" Text="** City must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtCountry" class="col-sm-2 control-label">Country</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
          <asp:Label ID="lblCountry" runat="server" Text="** Country must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtEmail" class="col-sm-2 control-label">Email</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
          <asp:Label ID="lblEmail" runat="server" Visible="False"></asp:Label>
    </div>
  </div>
        <div class="form-group">
    <label for="txtPhone" class="col-sm-2 control-label">Phone</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
          <asp:Label ID="lblPhone" runat="server" Visible="False"></asp:Label>
    </div>
  </div>
  <div class="form-group">
    <label for="txtUserName" class="col-sm-2 control-label">User Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
          <asp:Label ID="lblUserName" runat="server" Visible="False"></asp:Label>
    </div>
  </div>
  <div class="form-group">
    <label for="txtPassword" class="col-sm-2 control-label">Password</label>
    <div class="col-sm-10">
      <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassword" runat="server" Text="** Password must not be empty" Visible="False"></asp:Label>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        
    </div>
  </div>
        </div>
        </div>
        <!--container-->
</asp:Content>
