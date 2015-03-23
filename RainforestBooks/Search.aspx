<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RainforestBooks.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default transparancy">
    <div class="panel-body">
        <div class="row">
            <div class="col-sm-2 col-md-3"></div>
            <div class="col-sm-2 col-md-4">
        <h2>Results for : 
            "<asp:Label ID="lblSearchTerm" runat="server" Text="..."></asp:Label>"
        </h2>
                </div>
            </div>
        <hr />
         <asp:ListView ID="ProductDisplay" ItemType="RainforestBooks.Models.Product"
                 runat="server"
                 SelectMethod ="SearchMethod">
                 
                 <ItemTemplate>
        <div class="row">
            <div class="col-sm-6 col-md-2">
                <div class="thumbnail">
                    <a href="Book.aspx?id=<%#:Item.ProductId %>"><img src="Content/BookCovers/<%#: Item.ProductImageRef %>"/></a>
                </div>
             </div>
            <div class="col-sm-6 col-md-2">
                
            </div>
            <div class="col-sm-6 col-md-6">
                <h3><%#:Item.ProductTitle %></h3>
                <p><%#:Item.ProductDescription %></p>
            </div>
            
            
            <div class="col-sm-6 col-md-2">
                <p>Price: &euro;<%#:Item.Cost %></p>
                <p>Review: 4 Stars</p>
                <asp:Button CssClass="btn btn-default" ID="btnAddToCart" runat="server" Text="Add to Cart" />
            </div>
       </div>
        <hr/>
                     </ItemTemplate>
                     </asp:ListView>
        
  </div>
        </div>
</asp:Content>
