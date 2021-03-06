﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="RainforestBooks.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit User</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        

        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-heading"><h1 class="panel-title myTitle">Edit Account</h1>
            </div>
        <div class ="panel panel-default ">
            <div class ="panel panel-body transparancy">
        
            <div class="form form-vertical">
            <div class="form-group textBox">
    <label for="txtFName" class="col-sm-2 control-label">First Name</label>
      <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
          <asp:Label ID="lblFName" runat="server" Visible="False" ForeColor="Red">** First name must not be empty</asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtLName" class="col-sm-2 control-label">Last Name</label>
      <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
          <asp:Label ID="lblLName" runat="server" Text="** Last name must not be empty" Visible="False" ForeColor="Red"></asp:Label>
  </div>
        <div class="form-group textBox">
    <label for="txtAddress1" class="col-sm-2 control-label">Address1</label>
      <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress1" runat="server" Text="** Address must not be empty" Visible="False" ForeColor="Red"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtAddress2" class="col-sm-2 control-label">Address2</label>
      <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
          <asp:Label ID="lblAddress2" runat="server" Text="** Address must not be empty" Visible="False" ForeColor="Red"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtCity" class="col-sm-2 control-label">City</label>    
      <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
          <asp:Label ID="lblCity" runat="server" Text="** City must not be empty" Visible="False" ForeColor="Red"></asp:Label>   
  </div>

        <div class="form-group textBox">
    <label for="txtCountry" class="col-sm-2 control-label">Country</label>
      <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
          <asp:Label ID="lblCountry" runat="server" Text="** Country must not be empty" Visible="False" ForeColor="Red"></asp:Label>
  </div>

        <div class="form-group textBox">
    <label for="txtEmail" class="col-sm-2 control-label">Email</label>
      <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
  </div>

        <div class="form-group textBox">
    <label for="txtPhone" class="col-sm-2 control-label">Phone</label>
      <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
          <asp:Label ID="lblPhone" runat="server" Visible="False" ForeColor="Red"></asp:Label>
  </div>
            
                <hr />
        
  <div class="form-group textBox">
      
    <label for="txtUserName" class="col-sm-2 control-label">User Name</label>
      <asp:TextBox ID="txtUserName" runat="server" ReadOnly="True"></asp:TextBox>
  </div>
                <div class="form-group textBox">
                    <asp:CheckBox ID="chckChange" runat="server" Text="Change Password" AutoPostBack="true" OnCheckedChanged="chckChange_CheckedChanged1" />
  </div>

  <%--<div class="form-group textBox">
      <asp:Label ID="lblOldPassword" CssClass="col-sm-2 control-label" runat="server" Text="Old Password" Visible="False" Font-Bold="True"></asp:Label>
      <asp:TextBox ID="txtOldPassword" runat="server" Visible="False"></asp:TextBox>
       
        <asp:Label ID="lblOldPasswordWarning" runat="server" Text="** Incorrect password" Visible="False" ForeColor="Red"></asp:Label>
       </div>--%>

        <div class="form-group textBox">
            <asp:Label ID="lblNewPassword" CssClass="col-sm-2 control-label" runat="server" Text="New Password" Visible="False" Font-Bold="True"></asp:Label>
      <asp:TextBox ID="txtNewPassword" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
       
  </div>
               <div class="form-group textBox">
                   <asp:Label ID="lblConfirm" CssClass="col-sm-2 control-label" runat="server" Text="Confirm Password" Visible="False" Font-Bold="True"></asp:Label>
                    <asp:TextBox ID="txtConfirm" runat="server" Visible="False" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblConfirmWarning" runat="server" Text="** Passwords must match" Visible="False" ForeColor="Red"></asp:Label>
  </div>

            <hr />
            <div class="row">
                <div class="col-md-8"></div>
                <div class="col-md-3">

  <div class="form-group textBox">
        <asp:Button CssClass="btn btn-success btn-lg" ID="btnRegister" runat="server" OnClick="Button1_Click" Text="Update" />
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
