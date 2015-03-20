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
    </div>
  </div>
        <div class="form-group">
    <label for="txtLName" class="col-sm-2 control-label">Last Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtAddress1" class="col-sm-2 control-label">Address1</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtAddress2" class="col-sm-2 control-label">Address2</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtAddress3" class="col-sm-2 control-label">Address3</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtAddress3" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtCity" class="col-sm-2 control-label">City</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtCountry" class="col-sm-2 control-label">Country</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtPhone" class="col-sm-2 control-label">Phone</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <label for="txtUserName" class="col-sm-2 control-label">User Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <label for="txtPassword" class="col-sm-2 control-label">Password</label>
    <div class="col-sm-10">
      <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </div>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      <asp:Button ID="btnSubmit" runat="server" Text="Register" OnClick="btnSubmit_Click" />
        
    </div>
  </div>
        </div>
        </div>
        <!--container-->
</asp:Content>
