<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Issue--Return.aspx.vb" Inherits="Issue__Return" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue | Return</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700' rel='stylesheet' type='text/css'/>
   </head>
<body>
    <form id="form1" runat="server">
         <img class="image" src="logo.jpg" />
        <h1 class="Issue-ReturnBook">Issue/Return Book</h1>
        <asp:Button Class ="buttons" ID="SignOutButton" runat="server" OnClick="SignOut"  Text="Sign Out" BackColor="#004466" ForeColor="White" Height="50px" Width="90px" />
        <div class="navbar">
            <asp:Button Class="button" ID="Button4" runat="server" Text="Add Book/User" PostBackUrl="~/adminPage.aspx" />
            <asp:Button Class="button" ID="Button1" runat="server" Text="Issue/Return Book" PostBackUrl="~/Issue--Return.aspx" />
            <asp:Button Class="button" ID="Button2" runat="server" Text="Search Books" PostBackUrl="~/search.aspx" />
            <asp:Button Class="button" ID="Button3" runat="server" Text="History" PostBackUrl="~/Database Issue-Return.aspx" />
        </div> 
        <div class ="headerDivLeft">
            <div class="tableHeaderIssue">Issue Book</div>
        </div>
     
        <div class="aroundTheTableissue">
            <table class="StudentDetailsTable">
                <tr>
                    <td>
                        <asp:TextBox placeholder="Student USN" class="textboxes" ID="StudentUSNI" runat="server" Width="180px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox placeholder="Book ID" class="textboxes" ID="BookIDI" runat="server" Width="180px" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox placeholder="Issue Date" class="textboxes" ID="IssueDateI" runat="server" Width="180px" TextMode="SingleLine"  onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                        <!--<input name="date" type="text" onfocus="(this.type='date')" onfocusout="(this.type='text')"/>-->
                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:TextBox placeholder="Due Date" class="textboxes" ID="DueDate" runat="server" Width="180px" TextMode="SingleLine" onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="margin-left: 40px">
                        <asp:Button class="Submitbutton" ID="IssueButton" runat="server" Text="Submit" BackColor="#004466" ForeColor="White" Height="50px" Width="190px" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="headerDivRight">
            <div class="tableHeaderReturn">Return Book</div>
        </div>
        <div class="aroundTheTableReturn">
            <table class="StudentDetailsTable">
                <tr>
                    <td>
                        <asp:TextBox class="textboxes" placeholder="Student USN" ID="StudentUSN" runat="server" Width="180px" min-Width="180px" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList class="DropDownList" ID="BookIDDropDownList"  runat="server" ViewStateMode="Enabled" AutoPostBack="True">
                            <asp:ListItem Selected="True">Book ID</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="textboxes" placeholder="Due Date" ID="DueDateR" runat="server" Width="180px" TextMode="SingleLine"  onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox class="textboxes" placeholder="Return Date" ID="ReturnDate" runat="server" Width="180px" TextMode="SingleLine"  onfocus="(this.type='date')" onfocusout="(this.type='text')"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="margin-left: 40px">
                        <asp:Button class="Submitbutton" ID="ReturnButton" runat="server" Text="Submit" BackColor="#004466" ForeColor="White" Height="50px" Width="190px" />
                    </td>
                </tr>
            </table>
        </div>
        <table class="labels">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
          
    </form>
</body>
</html>
