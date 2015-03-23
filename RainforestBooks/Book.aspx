<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="RainforestBooks.Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron transparancy">
         <div class="row">
             <asp:ListView ID="ProductDisplay" ItemType="RainforestBooks.Models.Product"
                 runat="server"
                 SelectMethod ="GetProduct">
                 
                 <ItemTemplate>
                     <div class="col-sd-12 col-md-4">
                         <div class="thumbnail">
                             
                             <img id="itemimage" src="Content/BookCovers/<%#:Item.ProductImageRef %>"/>
                         </div><!--/thumbnaildiv-->
                     </div><!--/col-sd-12 col-md-4-->
                     <div class="col-sd-12 col-md-6">
  <h2 id="itemname"><%#: Item.ProductTitle %></h2>
  <h4>Description:</h4><p id="itemdescription"><%#:Item.ProductDescription %></p>
        <h4>Rating:<span id="itemrating"><% %></span></h4>
                 </div>
                     </ItemTemplate>
                 
             </asp:ListView>
                     
                 
            </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-1">
            <asp:Button id="btnAddToCart" Text="Add to Cart" runat="server" CssClass="btn-primary" OnClick="btnAddToCart_Click" />
                </div>
            <div class="col-md-1">
            <asp:Button id="btnAddReview" Text="Add Review" runat="server" CssClass="btn-primary" OnClick="Button1_Click" />
                </div>
                         </div>
        <div class ="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

                <asp:TextBox CssClass="textBox" ID="txtReview" runat="server" Width="400px" Height="105px" TextMode="MultiLine"></asp:TextBox>

            </div>
            </div>
        <div class ="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

                

                <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" CssClass="btn btn-default" OnClick="btnSubmitReview_Click"/>

                

            </div>
            </div>
        </div>

    <div class="panel panel-default transparancy">
        <div class="panel-body">
        
         
             <asp:ListView ID="ListView2" ItemType="RainforestBooks.Models.Review"
                 runat="server"
                 SelectMethod ="GetReview">
                 
                 <ItemTemplate>
                     <div class="row">
                     <div class="col-sd-12 col-md-6">
  <h2 id="itemname"><%#: Item.Stars %>/5</h2>
  <h4>Description:</h4><p id="itemdescription"><%#:Item.ReviewText %></p>
                         </div>
                         </div>
                         <hr />
                             
                     </ItemTemplate>
                 </asp:ListView>
                     </div>
                     
        </div>

</asp:Content>
