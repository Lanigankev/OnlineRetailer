﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="RainforestBooks.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="row">
        

        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-heading"><h1 class="panel-title myTitle">Registration</h1>
            </div>
        <div class ="panel panel-default ">
            <div class ="panel panel-body transparancy">
        
            <div class="form form-vertical">
            <div class="form-group textBox">
    <label for="txtFName" class="col-sm-2 control-label">First Name</label>
      <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
          <asp:Label ID="lblFName" runat="server" Visible="False">** First name must not be empty</asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtLName" class="col-sm-2 control-label">Last Name</label>
      <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
          <asp:Label ID="lblLName" runat="server" Text="** Last name must not be empty" Visible="False"></asp:Label>
  </div>
        <div class="form-group textBox">
    <label for="txtAddress1" class="col-sm-2 control-label">Address1</label>
      <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress1" runat="server" Text="** Address must not be empty" Visible="False"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtAddress2" class="col-sm-2 control-label">Address2</label>
      <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress2" runat="server" Text="** Address must not be empty" Visible="False"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtCity" class="col-sm-2 control-label">City</label>    
      <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
          <asp:Label ID="lblCity" runat="server" Text="** City must not be empty" Visible="False"></asp:Label>   
  </div>

        <div class="form-group textBox">
    <label for="txtCountry" class="col-sm-2 control-label">Country</label>
      <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
          <asp:Label ID="lblCountry" runat="server" Text="** Country must not be empty" Visible="False"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtEmail" class="col-sm-2 control-label">Email</label>
      <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
          <asp:Label ID="lblEmail" runat="server" Visible="False"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtPhone" class="col-sm-2 control-label">Phone</label>
      <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
          <asp:Label ID="lblPhone" runat="server" Visible="False"></asp:Label>
  </div>
            
                <hr />
        
  <div class="form-group textBox">
      
    <label for="txtUserName" class="col-sm-2 control-label">User Name</label>
      <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
          <asp:Label ID="lblUserName" runat="server" Visible="False"></asp:Label>
  </div>
                <div class="form-group textBox">
                    <asp:CheckBox ID="chckChange" runat="server" Text="Change Password" AutoPostBack="true" />
  </div>

  <div class="form-group textBox">
    <label for="txtPassword" class="col-sm-2 control-label">Old Password</label>
      <asp:TextBox ID="txtOldPassword" runat="server" Enabled="False"></asp:TextBox>
       
        <asp:Label ID="lblOldPassword" runat="server" Text="** Incorrect password" Visible="False"></asp:Label>
       
  </div>

        <div class="form-group textBox">
    <label for="txtNewPassword" class="col-sm-2 control-label">New Password</label>
      <asp:TextBox ID="txtNewPassword" runat="server" Enabled="False"></asp:TextBox>
       
  </div>
               <div class="form-group textBox">
    <label for="txtConfirm" class="col-sm-2 control-label">Confirm Password</label>
      <asp:TextBox ID="txtConfirm" runat="server" Enabled="False"></asp:TextBox>
        <asp:Label ID="lblConfirm" runat="server" Text="** Passwords must match" Visible="False"></asp:Label>
  </div>

            <hr />
            <div class="row">
                <div class="col-md-8"></div>
                <div class="col-md-3">

  <div class="form-group textBox">
        <asp:Button CssClass="btn btn-success btn-lg" ID="btnRegister" runat="server" OnClick="Button1_Click" Text="Update" />
  </div>
   <div class="form-group textBox">
           <asp:Button CssClass="btn btn-success btn-lg" ID="btnSearch" runat="server" OnClick="Button2_Click" Text="Search" />
   </div>
   
                    </div>
                    </div>
                    </div>
                    </div>
            </div>
            
        </div>

        </div>
        <!--container-->


</asp:Content>
