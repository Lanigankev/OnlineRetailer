<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="RainforestBooks.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron transparancy">
         <div class="row">
             <div class="col-sd-12 col-md-4">
                 <div class="thumbnail">
        <img id="itemimage" src="Content/BookCovers/gemini.jpg"/>
                 </div><!--/thumbnaildiv-->
                 </div>
             <div class="col-sd-12 col-md-6">
  <h2 id="itemname">Gemini</h2>
  <h4>Description:</h4><p id="itemdescription">This is a book about twins. Who against all odds, managed to go through the first 20 minutes of a party without being asked if their twin was an identical. New York Times heralded it as an emotional rollercoaster: "very difficult to put this book down". Chicago tribune said :"This is the best thing I've read since I looked at the ingredients of my cereal this morning"</p>
        <h4>Rating:<span id="itemrating">4/5</span></h4>
                 </div>
             </div>
        
        <div class="row">
            <div class="col-sd-12 col-md-5"></div>
            <div class="col-sd-12 col-md-2">
            <asp:Button id="b1" Text="Add to Cart" runat="server" CssClass="btn-primary" />
                </div>
            <div class="col-sd-12 col-md-2">
            <asp:Button id="Button1" Text="Add Review" runat="server" CssClass="btn-primary" />
                </div>
            </div>
  
</div>

    <div class="panel panel-default transparancy">
    <div class="panel-body">
        <h2>Reviews</h2>
        <hr />
        <div class ="row">
            <div class ="col-sd-6 col-md-1">
                <h3>User 1</h3>
            </div>
            <div class ="col-sd-6 col-md-2">
                
            </div>
            <div class ="col-sd-6 col-md-6">
                <h4>A great book</h4>
                <p>This is certainly a book alright, I often use it to appear smarter than I am. 10/10 books</p>
            </div>
            <div class ="col-sd-6 col-md-3">
                <p>5 Stars</p>
                </div>
        </div>
        <hr/>

        <div class ="row">
            <div class ="col-sd-6 col-md-1">
                <h3>User 2</h3>
            </div>
            <div class ="col-sd-6 col-md-2">
                
            </div>
            <div class ="col-sd-6 col-md-6">
                <h4>A great book</h4>
                <p>It's definitely a book I read this year. My 5 year old son didn't like it for bedtime stories though</p>
            </div>
            <div class ="col-sd-6 col-md-3">
                <p>3 Stars</p>
                </div>
        </div>
        <hr/>
        <div class ="row">
            <div class ="col-sd-6 col-md-1">
                <h3>User 3</h3>
            </div>
            <div class ="col-sd-6 col-md-2">
                
            </div>
            <div class ="col-sd-6 col-md-6">
                <h4>A great book</h4>
                <p>This is terrible, I burnt it in the fireplace</p>
            </div>
            <div class ="col-sd-6 col-md-3">
                <p>0 Stars</p>
                </div>
        </div>
        <hr/>
        </div>
        </div>
</asp:Content>
