<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Database Issue-Return.aspx.vb" Inherits="Database_Issue_Return" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>History</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
         <img class="image" src="logo.jpg" />
        <h1 class="HeaderIssue-ReturnDataBase">Database History</h1>
         <asp:Button Class="buttons" ID="SignOutButton" runat="server" OnClick="SignOut" Text="Sign Out" BackColor="#004466" ForeColor="White" Height="50px" Width="90px" />

      <div class="navbar">
            <asp:Button Class="button" ID="Button4" runat="server" Text="Add Book/User" PostBackUrl="~/adminPage.aspx" />
            <asp:Button Class="button" ID="Button1" runat="server" Text="Issue/Return Book" PostBackUrl="~/Issue--Return.aspx" />
            <asp:Button Class="button" ID="Button2" runat="server" Text="Search Books" PostBackUrl="~/search.aspx" />
            <asp:Button Class="button" ID="Button3" runat="server" Text="History" PostBackUrl="~/Database Issue-Return.aspx" />
        </div>
       
        <div class="headerDivLeft">
            <div class="HeaderIssueDatabase">Issue Database</div>
        </div>
       
        <div class="aroundIssueDatabase">
            <table class="IssueReturnTable">
                <tr>
                    <td>
                        <asp:TextBox placeholder="From" class="textboxes" ID="IssueFrom" runat="server" Width="190px" TextMode="SingleLine" onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox placeholder="To" class="textboxes" ID="IssueTo" runat="server" Width="190px" TextMode="SingleLine" onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="IssueCatalog" BackColor="#004466" ForeColor="White" CssClass="IssueCatalogButton" runat="server" Text="Issued Books Catalog" />
                    </td>
                </tr>
            </table>
        </div>
         <div class="headerDivRight">
            <div class="HeaderReturnDatabase">Return Database</div>
        </div>
        <div class="aroundReturnDatabase">
            <table class="IssueReturnTable">
                <tr>
                    <td>
                        <asp:TextBox placeholder="From" class="textboxes" ID="ReturnFrom" runat="server" Width="190px" TextMode="SingleLine" onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox placeholder="To" class="textboxes" ID="ReturnTo" runat="server" Width="190px" TextMode="SingleLine" onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ReturnCatalog" BackColor="#004466" ForeColor="White" CssClass="ReturnCatalogButton" runat="server" Text="Returned Books Catalog" />
            </table>
        </div>
        <div class="HistoryDiv">
            <asp:GridView CssClass="historyGridView" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px" CellSpacing="1" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="white" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#BFD0D9" ForeColor="Black" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
         </form>
</body>
</html>

