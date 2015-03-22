<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RainforestBooks.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="jumbotron transparancy">
        <h1>Simply Books</h1>
        <p>At Rainforest books, we're responsible for more rainforest destruction than any other major book retailer. We're simply devoted to the absolute annilhation of the amazon rainforest. From that we're able to provide books cheaper than all other retailers.</p>
       
      </div>
        <div class="jumbotron transparancy">
      
    <div class="row">
      
      <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
        <img src="Content/BookCovers/bootstrap.jpg" />
          <div class="caption">
            <h3>Thumbnail label</h3>
           
            
          </div>
        </div>
      </div>
      <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
            <a href="Book.aspx?id=1"><img src="Content/BookCovers/gemini.jpg" /></a>
          <div class="caption">
            <h3>Thumbnail label</h3>
             </div>
        </div>
      </div>
        <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
              <img src="Content/BookCovers/inspiralized.jpg" />
          <div class="caption">
            <h3>Thumbnail label</h3>
             </div>
        </div>
      </div>
        <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
                  <img src="Content/BookCovers/moodybitches.jpg" />
          <div class="caption">
            <h3>Thumbnail label</h3>
             </div>
        </div>
      </div>
        <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
                      <img src="Content/BookCovers/younger.jpg" />
          <div class="caption">
            <h3>Thumbnail label</h3>
             </div>
        </div>
      </div>
        <div class="col-sm-6 col-md-2">
        <div class="thumbnail">
            <img src="Content/BookCovers/inspiralized.jpg" class="bookdisplay"/>
          <div class="caption">
            <h3>Thumbnail label</h3>
             </div>
        </div>
      </div>
    </div>
  

            </div>

</asp:Content>
