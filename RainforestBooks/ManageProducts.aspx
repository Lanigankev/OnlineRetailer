<%@ Page Title="" Language="C#" MasterPageFile="~/AdminView.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="RainforestBooks.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
    <div class="panel panel-default transparancy">
        <div class="panel-body">
              <div class="row">
                  <div class="col-md-2"></div>
                    <div class="col-md-6">
                    <div class="form-group"> 
                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Books" />
                        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" Text="Book Accessories " />
                        <asp:Label ID="lblCatergory" runat="server" Visible="False" ForeColor="Red">** Select a category</asp:Label>
        
                        </div>
                    <div class="form-group">
                        <p><label for="txtName" class="control-label">Name</label>
                        </p>
      
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:Label ID="lblProduct" runat="server" Visible="False" ForeColor="Red"></asp:Label>
        
                    </div>
                    <div class="form-group">
                     <p><label for="txtGenre" class="control-label">Book Genre</label></p>
                     <asp:DropDownList ID="cmbGenre" runat="server">
                        <asp:ListItem>Action</asp:ListItem>
                        <asp:ListItem>Adventure</asp:ListItem>
                        <asp:ListItem>Romance</asp:ListItem>
                        <asp:ListItem>Science</asp:ListItem>
                         <asp:ListItem>NA</asp:ListItem>
                    </asp:DropDownList>

              </div>
  
                    <div class="form-group">
                        <p><label for="txtStock" class="control-label">Amount in Stock</label></p>
                        <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                        <asp:Label ID="lblStock" runat="server" Text="** Valid number not entered" Visible="False" ForeColor="Red"></asp:Label>
                    </div>
  
        

                <div class="form-group">
                        <p><label for="txtCost" class="control-label">Cost</label></p>
                        <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
                        <asp:Label ID="lblCost" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                </div>

                    <div class="form-group">
                    <label for="txtImage" class="control-label">Image Upload</label>
                     
                          <asp:HyperLink
                            ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink>
                        <asp:FileUpload ID="txtImageUpload" runat="server" />
                          <%--<asp:Button ID="btnUpload" runat="server" Text="Upload Image" OnClick="Button1_Click" />
                          <asp:Label ID="lblImage" runat="server" Text="** No image uploaded" Visible="False" ForeColor="Red"></asp:Label>--%>
                    </div>
                   
  
                <div class="form-group">
                     <p><label for="txtDescription" class="control-label">Description</label></p>      
                     <asp:TextBox ID="txtDescription" runat="server" Height="67px" TextMode="MultiLine" Width="234px"></asp:TextBox>
                     <asp:Label ID="lblDescription" runat="server" Text="** Description not entered" Visible="False" ForeColor="Red"></asp:Label>
                </div>
                       
            
        
                <div class="form-group">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-success btn-lg" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        
                </div>
                </div>
                </div> 
                </div>
                </div>
                </div>
</div>
</asp:Content>