
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim userId As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles LogInButton.Click
        If UserIdText.Text = "admin" And UserPassword.Text = "admin" Then
            Session("New") = UserIdText.Text
            Response.Redirect("adminPage.aspx")
        End If
    End Sub
    Protected Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click

    End Sub
End Class
