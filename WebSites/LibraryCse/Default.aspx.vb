
Imports System.Data.OleDb

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim cn As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("libraryBooks.mdb"))

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles LogInButton.Click
        cn.Open()
        Dim Command As New OleDbCommand("Select pwd from pwdencryptedlol where ID = @id", cn)
        Command.Parameters.AddWithValue("id", "admin")
        Command.ExecuteNonQuery()
        Dim reader As OleDbDataReader = Command.ExecuteReader()
        While reader.Read
            Dim passwd As String = reader.Item("pwd")
            If passwd = UserPassword.Text Then
                cn.Close()
                Session("New") = passwd
                Response.Redirect("adminPage.aspx")
            End If
        End While
        Label1.Text = "Incorrect password"
        cn.Close()
    End Sub
    Protected Sub RegisterButton_Click(sender As Object, e As EventArgs) Handles RegisterButton.Click

        Response.Redirect("PwdChange.aspx")

    End Sub
End Class
