<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RainforestBooks.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron transparancy">
   <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="6000">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
       <h1>Simply Books</h1>
        <p>At Rainforest books, we're responsible for more rainforest destruction than any other major book retailer. We're simply devoted to the absolute annilhation of the amazon rainforest. From that we're able to provide books cheaper than all other retailers.</p>
       
    </div>

    <div class="item">
      <h1>We care..</h1>
        <p>About exploiting the indigenous tribes of all underdeveloped rainforests. It is our mission to oppress each and every last one of them. And we can, because we're a massive multinational corporation with no morals. Are you worried yet? You should be! </p>
    </div>

    <div class="item">
       <h1>Capitalism</h1>
        <p>We fully support capitalist greed. We support it so strongly that we're willing to keep ruthless dictators in power in the places, that you don't really care about. Want a starbucks? Come worship corporate greed with us Monday to Friday!</p>
    </div>

    
  </div>

  
</div>
            </div>
        

        <div class="panel panel-default transparancy">
        <div class="panel-body">
      
    <div class="row">
      <asp:ListView ID ="ProductListView" runat="server" ItemType="RainforestBooks.Models.Product" SelectMethod="GetProduct">
          <ItemTemplate>
      <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
        <a href ="Book.aspx?id=<%#:Item.ProductId %>"><img src="Content/BookCovers/<%#:Item.ProductImageRef %>" /></a>
          <div class="caption">
            <h3><%#:Item.ProductTitle %></h3>
          </div>
        </div>
      </div>
              </ItemTemplate>
          </asp:ListView>
    </div>
  

            </div>
            </div>

</asp:Content>
