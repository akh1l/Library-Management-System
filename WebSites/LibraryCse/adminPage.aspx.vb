Imports System.Data.OleDb

Partial Class Default2
    Inherits System.Web.UI.Page

    Dim cn As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("libraryBooks.mdb"))


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("New") = Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub AddBookButton_Click(sender As Object, e As EventArgs) Handles AddBookButton.Click
        Try
            cn.Open()
            Dim Command As New OleDbCommand("Select BookId from Books where BookId = @Id", cn)
            Command.Parameters.AddWithValue("Id", TextBox1.Text)
            Command.ExecuteNonQuery()
            Dim reader As OleDbDataReader = Command.ExecuteReader()
            While reader.Read
                Dim BookID As String = reader.Item("BookId")
                If BookID = TextBox1.Text Then
                    Label1.Text = "book " + BookID + " ID exists"
                    Return
                End If
            End While
            cn.Close()

            Dim BookIDString As String = TextBox1.Text
            If BookIDString.Length <> 8 Then
                Label1.Text = "Invalid Book ID"
                Return
            End If
            If BookIDString.Length = 8 And Char.IsLetter(BookIDString(0)) And Char.IsLetter(BookIDString(1)) And Char.IsLetter(BookIDString(2)) And Char.IsLetter(BookIDString(3)) And Char.IsDigit(BookIDString(4)) And Char.IsDigit(BookIDString(5)) And Char.IsDigit(BookIDString(6)) And Char.IsDigit(BookIDString(7)) Then
                'will insert the books int o the db in the below section
            Else
                'Book will not be added as the control wont reach the code below
                Label1.Text = "Invalid BookID"
                Return
            End If

            Dim cmd As New OleDbCommand("insert into Books(BookId,BookName,BookAuthor,BookPublisher,Edition) values (@a1,@a2,@a3,@a4,@a5)", cn)
            cmd.Parameters.AddWithValue("a1", TextBox1.Text)
            cmd.Parameters.AddWithValue("a2", TextBox2.Text)
            cmd.Parameters.AddWithValue("a3", TextBox3.Text)
            cmd.Parameters.AddWithValue("a4", TextBox4.Text)
            cmd.Parameters.AddWithValue("a5", EditionTextBox.Text)
            Dim cmd1 As New OleDbCommand("UPDATE Books set Status='Available' WHERE BookId = @BookID", cn)
            cmd1.Parameters.AddWithValue("BookID", TextBox1.Text)
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            cn.Close()
            Label1.Text = "Book " + TextBox1.Text + " added successfully"
        Catch ex As Exception
            cn.Close()
            Label1.Text = ex.Message
        End Try
    End Sub
    Protected Sub addUserButton_Click(sender As Object, e As EventArgs) Handles addUserButton.Click
        Try
            cn.Open()
            Dim Command As New OleDbCommand("Select USN from users where USN = @usn", cn)
            Command.Parameters.AddWithValue("usn", TextBox9.Text)
            Command.ExecuteNonQuery()
            Dim reader As OleDbDataReader = Command.ExecuteReader()
            While reader.Read
                Dim usn As String = reader.Item("USN")
                If usn = TextBox9.Text Then
                    Label1.Text = "USN " + usn + " exists"
                    Return
                End If
            End While
            cn.Close()



            Dim USNString As String = TextBox9.Text
            If USNString.Length <> 10 Then
                Label1.Text = "Invalid USN"
                Return
            End If
            If USNString.Length = 10 And USNString(0) = "1" And USNString(1) = "T" Or USNString(1) = "t" And USNString(2) = "J" Or USNString(2) = "j" And Char.IsDigit(USNString(3)) And Char.IsDigit(USNString(4)) And Char.IsLetter(USNString(5)) And Char.IsLetter(USNString(6)) And Char.IsDigit(USNString(7)) And Char.IsDigit(USNString(8)) And Char.IsDigit(USNString(9)) Then
                'will insert the user into the db in the below section
            Else
                'user will not be added as the control wont reach the code below
                Label1.Text = "Invalid USN"
                Return
            End If


            Dim cmd1 As New OleDbCommand("insert into users(FirstName,LastName,Branch,_Year,USN) values (@b1,@b2,@b3,@b4,@b5)", cn)
            cmd1.Parameters.AddWithValue("b1", TextBox5.Text)
            cmd1.Parameters.AddWithValue("b2", TextBox6.Text)
            cmd1.Parameters.AddWithValue("b3", TextBox7.Text)
            cmd1.Parameters.AddWithValue("b4", TextBox8.Text)
            Dim modifiedUSN As String = TextBox9.Text
            modifiedUSN = modifiedUSN.ToUpper
            cmd1.Parameters.AddWithValue("b5", modifiedUSN)
            cn.Open()
            cmd1.ExecuteNonQuery()
            cn.Close()
            Label1.Text = "User " + TextBox9.Text + " Added successfully"
        Catch ex1 As Exception
            cn.Close()
            Label1.Text = ex1.Message
        End Try
    End Sub

    Protected Sub SignOut(sender As Object, e As EventArgs) Handles SignOutButton.Click
        Session("New") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
End Class
