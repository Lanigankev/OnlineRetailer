<%@ Page Title="" Language="C#" MasterPageFile="~/AminView.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="RainforestBooks.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Product Title:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label2" runat="server" Text="Product Image:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtImage" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label3" runat="server" Text="Amount In Stock:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Cost:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label5" runat="server" Text="Description:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label6" runat="server" Text="Category:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label7" runat="server" Text="Genre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
<p>
</p>
</asp:Content>
