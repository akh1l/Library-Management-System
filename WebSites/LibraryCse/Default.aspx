<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CSE LIBRARY</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css'/>
</head>
<body style="height: 586px; margin-top: 15px">
    <form id="form1" runat="server">
      <h1 class ="TjitHeader">TJIT-CSE LIBRARY</h1>
      <div class ="aroundTheTable">
        <h1 class="LogInHeader">Log In!</h1>
        <table class="logInTable">
            <tr>        
                <td class="auto-style5">
                    <asp:TextBox class="textboxes" ID="UserIdText" placeholder="User ID" runat="server" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:TextBox class="textboxes" ID="UserPassword" runat="server" placeholder="Password" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Class ="buttons" ID="LogInButton" runat="server" OnClick="Button1_Click"  Text="Log In" BackColor="#004466" ForeColor="White" Height="50px" Width="90px" />
                    <asp:Button Class ="buttons" ID="RegisterButton" runat="server" Height="50px"  BackColor="#004466" ForeColor="White" Text="Register" Width="90px" />
                </td>
            </tr>
        </table>
    </div>
    <p>
        &nbsp;</p>

    </form>
    </body>
</html>
