
Imports System.Data.OleDb

Partial Class PwdChange
    Inherits System.Web.UI.Page

    Dim cn As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("libraryBooks.mdb"))

    Protected Sub ChangePwdButton_Click(sender As Object, e As EventArgs) Handles ChangePwdButton.Click
        If NewPasswordText.Text = ConfirmNewPasswordText.Text Then
            cn.Open()
            Dim Command As New OleDbCommand("Select pwd from pwdencryptedlol where ID = @id", cn)
            Command.Parameters.AddWithValue("id", "admin")
            Command.ExecuteNonQuery()
            Dim reader As OleDbDataReader = Command.ExecuteReader()
            While reader.Read
                Dim passwd As String = reader.Item("pwd")
                If passwd = OldPasswordText.Text Then
                    cn.Close()
                    Session("New") = passwd
                    Dim cmd As New OleDbCommand("update pwdencryptedlol SET pwd = @newpasswd where ID = @id", cn)
                    cmd.Parameters.AddWithValue("newpasswd", ConfirmNewPasswordText.Text)
                    cmd.Parameters.AddWithValue("id", "admin")
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Response.Redirect("Default.aspx")
                End If
            End While
            Label1.Text = "Incorrect password"
            cn.Close()
        Else
            Label1.Text = "New Password's do not match"
        End If
    End Sub
End Class
