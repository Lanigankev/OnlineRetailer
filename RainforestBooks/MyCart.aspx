<%@ Page Title="" Language="C#" MasterPageFile="~/UserView.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="RainforestBooks.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default transparancy">
        <div class="panel-body">
            <asp:GridView runat="server" ID="gvShoppingCart" 
                AutoGenerateColumns="false" 
                EmptyDataText="There is nothing in your shopping cart." 
                GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" 
                DataKeyNames="ProductId" OnRowCommand="gvShoppingCart_RowCommand" 
                OnRowDataBound="gvShoppingCart_RowDataBound"
                CssClass="table table-hover table-striped" OnRowEditing="gvShoppingCart_RowEditing" OnRowUpdating="gvShoppingCart_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ProductId" HeaderText="Product Id" />
                    <asp:BoundField DataField="Title" HeaderText="Product Name" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                            <asp:LinkButton runat="server" ID="btnUpdate" Text="Update"
                                CommandName ="Update" CommandArgument='<%# Container.DataItemIndex %>'
                                OnClick="btnUpdate_Click"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" 
                                CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>' 
                   
                                AutoPostBack="true"
                                OnClick="btnRemove_Click"></asp:LinkButton>
 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UnitPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                </Columns>
               
            </asp:GridView>
            <div class="row">
                <div class="col-md-10">
            
            </div>
                <div class="col-md-2">
                    
                    <asp:Label ID="lblTotalCost" runat="server" Text ="0.00" ></asp:Label>
                    </div>
            </div>
            </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-10"></div>
                 <div class="col-md-2">
            <asp:Button ID="btnPurchase" runat="server" Text="Submit Purchase" OnClick="btnPurchase_Click" />
                 </div>
            </div>
            </div>
        </div>
</asp:Content>
