<%@ Page Language="VB" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search</title>
     <link href="stylesheet.css" rel="stylesheet" type="text/css" />
     <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">

         <img class="image" src="logo.jpg" />
         <h1 class="Issue-ReturnBook">Search/Catalog</h1>
        <asp:Button Class ="buttons" ID="SignOutButton" runat="server" OnClick="SignOut"  Text="Sign Out" BackColor="#004466" ForeColor="White" Height="50px" Width="90px" />
         <div class="navbar">
             <tr>
                 <td>
                     <asp:Button Class="button" ID="Button4" runat="server" Text="Add Book/User" PostBackUrl="~/adminPage.aspx" />
                 </td>
                  <td>
                      <asp:Button Class="button" ID="Button1" runat="server" Text="Issue/Return Book" PostBackUrl="~/Issue--Return.aspx" />

                  </td>
                 <td>
                      <asp:Button Class="button" ID="Button3" runat="server" Text="Search Books" PostBackUrl="~/search.aspx" />
                 </td>
                 <td>
                     <asp:Button Class="button" ID="Button5" runat="server" Text="History" PostBackUrl="~/Database Issue-Return.aspx" />
                 </td>
             </tr>
        </div> 

        <div class ="searchDiv">
            <table class="searchTable">
                <tr>
                    <td>
                        <asp:TextBox ID="SearchBoxName" class="textboxes" Placeholder=" Search" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="SearchButton" CssClass="searchButtons" runat="server" Text="Search" />
                    </td>
                </tr>
            </table>
            <table class="RadioTable">
                <tr>
                    <td width="100px">
                        <asp:RadioButton ID="IdRadioButton" runat="server" GroupName="SearchRadioButtons" Text="ID" />
                    </td>
                    <td width="100px">
                        <asp:RadioButton ID="NameRadioButton" runat="server" GroupName="SearchRadioButtons" Text="Name" />
                    </td>
                    <td width="150px">
                        <asp:RadioButton ID="AuthorRadioButton" runat="server" GroupName="SearchRadioButtons" Text="Author" />
                    </td>
                    <td width="256px">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Search Available Books" />
                    </td>
                    <td width="250px">
                        <asp:Button ID="Button2" CssClass="searchButtons" runat="server" Text="Catalog" />
                    </td>
                    <td width="200px">
                        <asp:Button ID="AdvanceSearchButton" CssClass="searchButtons" runat="server" Text="Advance search" />
                    </td>
                </tr>
            </table>
        </div>
        <div class ="HistoryGrid">
            <asp:GridView CssClass="GridView" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CellSpacing="1" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="white" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#BFD0D9"  ForeColor="Black" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <br />
        </div>
 
    </form>
</body>
</html>
