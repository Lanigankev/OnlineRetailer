<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RainforestBooks.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default transparancy">
    <div class="panel-body">
         <asp:ListView ID="ProductDisplay" ItemType="RainforestBooks.Models.Product"
                 runat="server"
                 SelectMethod ="SearchMethod">
                 
                 <ItemTemplate>
        <div class="row">
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <img src="Content/BookCovers/<%#: Item.ProductImageRef %>"/>
                </div>
             </div>
            <div class="col-sm-6 col-md-2">
                
            </div>
            <div class="col-sm-6 col-md-6">
                <h3><%#:Item.ProductTitle %></h3>
                <p><%#:Item.ProductDescription %></p>
            </div>
            <div class="col-sm-6 col-md-2">
                <p>Price:<%#:Item.Cost %></p>
                <p>Review: 4 Stars</p>
            </div>
       </div>
        <hr/>
                     </ItemTemplate>
                     </asp:ListView>
        
  </div>
        </div>
</asp:Content>
