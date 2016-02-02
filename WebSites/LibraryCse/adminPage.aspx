<%@ Page Language="VB" AutoEventWireup="false" CodeFile="adminPage.aspx.vb" Inherits="Default2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE LIBRARY</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
     <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css'/>
</head>
<body>
    <form id="form1" runat="server">
       <h1 class="welcomeHeader">Welcome admin</h1>
        <asp:Button Class ="buttons" ID="SignOutButton" runat="server" OnClick="SignOut"  Text="Sign Out" BackColor="#004466" ForeColor="White" Height="50px" Width="90px" />
        <div class="tableHeaderBook">Add Book</div>
        <div class="tableHeaderUser">Add User</div>
        <div class ="aroundTheTableadminBook">
         <table class="bookAddTable">
            <tr>
                <td>
        <asp:TextBox placeholder="Book ID" class="textboxes" ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:TextBox placeholder="Book Name" class="textboxes" ID="TextBox2" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:TextBox placeholder="Book Publisher" class="textboxes" ID="TextBox3" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:TextBox placeholder="Book Author" class="textboxes" ID="TextBox4" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="margin-left: 40px">
                    <asp:Button class="buttons" ID="AddBookButton" runat="server" Text="Add" BackColor="#004466" ForeColor="White" Height="50px" Width="190px"  />
                </td>
            </tr>
        </table>
        <br />
            </div>
        <div class ="aroundTheTableadminUser">
         <table class="userAddTable">
                 <tr>
                     <td>
                         <asp:TextBox placeholder="First Name" class="textboxes" ID="TextBox5" runat="server" Width="180px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:TextBox placeholder="Last Name" class="textboxes" ID="TextBox6" runat="server" Width="180px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style1">
                         <asp:TextBox placeholder="Branch" class="textboxes" ID="TextBox7" runat="server" Width="180px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:TextBox placeholder="Year" class="textboxes" ID="TextBox8" runat="server" Width="180px"></asp:TextBox>
                     </td>
                     <tr>
                         <td>
                             <asp:TextBox placeholder="USN" class="textboxes" ID="TextBox9" runat="server" Width="180px"></asp:TextBox>
                         </td>
                     </tr>
                 </tr>
                 <tr>
                     <td style="margin-left: 40px">
                         <asp:Button class="buttons" ID="addUserButton" runat="server" Text="Add" BackColor="#004466" ForeColor="White" Height="50px" Width="190px" />
                     </td>
                 </tr>
        </table>
        <br />
            </div>
        <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:Label ID="Label0" runat="server"></asp:Label>
            </p>
    </form>
</body>
</html>
