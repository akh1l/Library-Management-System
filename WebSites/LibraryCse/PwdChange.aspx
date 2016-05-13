<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PwdChange.aspx.vb" Inherits="PwdChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE LIBRARY</title>
    
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css'/>
</head>
    
<body >
    <form id="form1" runat="server">
      <h1 class ="TjitHeader">TJIT-CSE LIBRARY</h1>
        
        <img style="position:absolute; border-radius:10px; TOP:90px; LEFT:50%; margin-left :-75px; WIDTH:150px; HEIGHT:130px" src="logo1.jpg"/>
      <div class ="aroundTheTable">
        <h1 class="LogInHeader">Change Password</h1>
        <table class="logInTable">
            <tr>        
                <td class="auto-style5">
                    <asp:TextBox class="textboxes" ID="OldPasswordText" placeholder="Old Password" runat="server" Width="180px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:TextBox class="textboxes" ID="NewPasswordText" runat="server" placeholder="New Password" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style5">
                    <asp:TextBox class="textboxes" ID="ConfirmNewPasswordText" runat="server" placeholder="Confirm New Password" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td>
                <asp:Button ID="ChangePwdButton" runat="server"  Height="50px"  BackColor="#004466" ForeColor="White" Text="Change Password" Width="190px"  OnClick="ChangePwdButton_Click"  />
                   
                </td>
            </tr>
        </table>
    </div>

         <table class="frontLabel">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
     </form>
    </body>
</html>

