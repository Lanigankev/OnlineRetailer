<%@ Page Title="" Language="C#" MasterPageFile="~/AdminView.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="RainforestBooks.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="panel panel-default transparancy">
    <div class="panel-body">
        <div class="form-group">
    <label for="rdoBook" class="col-sm-2 control-label">Product Type</label>
      <div class="col-sm-10">
          <asp:RadioButton ID="rdoBook" runat="server" Text="Book" GroupName="gender" OnCheckedChanged="RadioButton1_CheckedChanged" />
          <asp:RadioButton ID="rdoAccessory" runat="server" Text="Book Accessory" GroupName="gender" OnCheckedChanged="rdoAccessory_CheckedChanged" />
    </div>
  </div>
        <div class="form-group">
    <label for="txtName" class="col-sm-2 control-label">Name</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtStock" class="col-sm-2 control-label">Amount in Stock</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
    </div>
  </div>
        
        <div class="form-group">
            <label for="txtCost" class="col-sm-2 control-label">Cost</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
            </div>
  </div>
        <div class="form-group">
    <label for="txtDescription" class="col-sm-2 control-label">Description</label>
      <div class="col-sm-10">
      <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    </div>
  </div>
        <div class="form-group">
    <label for="txtImage" class="col-sm-2 control-label">Image Upload</label>
      <div class="col-sm-10">
          <asp:HyperLink
            ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        <asp:FileUpload ID="txtImageUpload" runat="server" />
          <asp:Button ID="btnUpload" runat="server" Text="Upload Image" OnClick="Button1_Click" />
    </div>
  </div> 
        <div class="form-group">
    <label for="txtGenre" class="col-sm-2 control-label">Book Genre</label>
      <div class="col-sm-10">
          <asp:DropDownList ID="cmbGenre" runat="server">
              <asp:ListItem>Action</asp:ListItem>
              <asp:ListItem>Adventure</asp:ListItem>
              <asp:ListItem>Romance</asp:ListItem>
              <asp:ListItem>Science</asp:ListItem>
          </asp:DropDownList>
    </div>
  </div>

        
  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        
    </div>
  </div>
        </div>
    </div>
        <!--container-->
</asp:Content>