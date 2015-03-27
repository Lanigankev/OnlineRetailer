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
            <div class="col-md-2">
            <asp:Button id="btnAddToCart" Text="Add to Cart" runat="server" CssClass="btn btn-success btn-lg" OnClick="btnAddToCart_Click" />
                </div>
            <div class="col-md-2">
            <asp:Button id="btnAddReview" Text="Add Review" runat="server" CssClass="btn btn-success btn-lg" OnClick="Button1_Click" />

                </div>
            <div class="col-md-2">
                <asp:Button ID ="btnDeleteReview" Text="Delete Review" runat="server" CssClass="btn btn-danger btn-lg" OnClick="btnDeleteReview_Click" />
            </div>
             <div class="col-md-2">
                 <asp:Label runat="server" ID="lblReviewAverage" CssClass="h3" Text=""></asp:Label>
                 </div>
                         </div>
        <div class ="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">

                <asp:TextBox CssClass="textBox" ID="txtReview" runat="server" Width="400px" Height="105px" TextMode="MultiLine"></asp:TextBox>

            </div>
            <div class="col-md-3">
                <ul>
                    <li>
                        <asp:Label ID="lblWarning" runat="server" Text="You must select a rating!"></asp:Label></li>
                    <li><asp:RadioButton ID="rdo5" runat="server" Text="5 Stars" /></li>
                    <li><asp:RadioButton ID="rdo4" runat="server" Text="4 Stars" /></li>
                    <li><asp:RadioButton ID="rdo2" runat="server" Text="2 Stars" /></li>
                    <li><asp:RadioButton ID="rdo3" runat="server" Text="3 Stars" /></li>
                    <li><asp:RadioButton ID="rdo1" runat="server" Text="1 Star" /></li>
                </ul>
            </div>
            </div>
        <div class ="row">
            <div class="col-md-4"></div>
            <div class="col-md-6">

                

                <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" CssClass="btn btn-success btn-lg" OnClick="btnSubmitReview_Click"/>

                

            </div>
            </div>
        </div>

    <div class="panel panel-default transparancy">
        <div class="panel-body">
        
         
             <asp:ListView ID="ListView2" ItemType="RainforestBooks.Models.ProductReviewCustomer"
                 runat="server"
                 SelectMethod ="GetProductReview">
                 
                 <ItemTemplate>
                     <div class="row">
                         <div class ="col-md-12">
                             <h3 id="itemname">Product: <%#: Item.thisProduct.ProductTitle%></h3>
                         </div>
                     </div>
                     <div class="row">
                     <div class="col-sd-12 col-md-3">
  
  <h2 id="numStars"><%#: Item.thisReview.Stars%>/5</h2>
  <h4>Description : </h4>
                         </div>
                         <div class="col-md-6">
                             <h3>User : <%#: Item.thisCustomer.UserName %></h3>
                         <p id="itemdescription"><%#:Item.thisReview.ReviewText %></p>
                         </div>
                         </div>
                         <hr />
                             
                     </ItemTemplate>
                 </asp:ListView>
                     </div>
                     
        </div>

</asp:Content>
