Imports System.Data.OleDb

Partial Class Default2
    Inherits System.Web.UI.Page

    Dim cn As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("libraryBooks.mdb"))
    Dim cn1 As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("AddingnewUser.mdb"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("New") = Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub AddBookButton_Click(sender As Object, e As EventArgs) Handles AddBookButton.Click
        Try
            Dim cmd As New OleDbCommand("insert into Books(BookId,BookName,BookAuthor,BookPublisher) values (@a1,@a2,@a3,@a4)", cn)
            cmd.Parameters.AddWithValue("a1", TextBox1.Text)
            cmd.Parameters.AddWithValue("a2", TextBox2.Text)
            cmd.Parameters.AddWithValue("a3", TextBox3.Text)
            cmd.Parameters.AddWithValue("a4", TextBox4.Text)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Label0.Text = ""
            Label1.Text = "Book added successfully"
        Catch ex As Exception
            cn.Close()
            Label0.Text = ""
            Label1.Text = ex.Message
        End Try
    End Sub
    Protected Sub addUserButton_Click(sender As Object, e As EventArgs) Handles addUserButton.Click
        Try
            Dim cmd1 As New OleDbCommand("insert into users(FirstName,LastName,Branch,_Year,USN) values (@b1,@b2,@b3,@b4,@b5)", cn1)
            cmd1.Parameters.AddWithValue("b1", TextBox5.Text)
            cmd1.Parameters.AddWithValue("b2", TextBox6.Text)
            cmd1.Parameters.AddWithValue("b3", TextBox7.Text)
            cmd1.Parameters.AddWithValue("b4", TextBox8.Text)
            cmd1.Parameters.AddWithValue("b5", TextBox9.Text)
            cn1.Open()
            cmd1.ExecuteNonQuery()
            cn1.Close()
            Label1.Text = ""
            Label0.Text = "User Added successfully"
        Catch ex1 As Exception
            cn1.Close()
            Label1.Text = ""
            Label0.Text = ex1.Message
        End Try
    End Sub

    Protected Sub SignOut(sender As Object, e As EventArgs) Handles SignOutButton.Click
        Session("New") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
End Class
