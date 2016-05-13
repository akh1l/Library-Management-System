Imports System.Data.OleDb


Partial Class Issue__Return
    Inherits System.Web.UI.Page
    Dim cn As New OleDbConnection("PROVIDER = Microsoft.Jet.OLEDB.4.0; Data Source =" & Server.MapPath("libraryBooks.mdb"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("New") = Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub IssueButton_Click(sender As Object, e As EventArgs) Handles IssueButton.Click
        Try
            ''test condition to see if the borrower as already borrowed two books
            Dim command As New OleDbCommand("SELECT BookID from IssueDetails where StudentID = @studentId", cn)
            command.Parameters.AddWithValue("@studentId", StudentUSNI.Text)
            cn.Open()
            Dim reader As OleDbDataReader = command.ExecuteReader()
            Dim count As Integer = 0
            While reader.Read
                count = count + 1
            End While
            reader.Close()
            cn.Close()

            If count < 2 Then
                'test condition to check if the book is available in the catalog
                command = New OleDbCommand("SELECT BookID from Books where BookId = @BookID", cn)
                command.Parameters.AddWithValue("@BookID", BookIDI.Text)
                cn.Open()
                reader = command.ExecuteReader()
                count = 0
                While reader.Read
                    count = count + 1
                End While
                reader.Close()
                cn.Close()
                If count = 0 Then
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "catalogAvailability", "catalogAvailability();", True)
                    Label1.Text = "Book is not available in our Catalog!!!"
                Else
                    Dim availablecommand As New OleDbCommand("select BookID from IssueDetails where BookID=@Bookid", cn)
                    availablecommand.Parameters.AddWithValue("@Bookid", BookIDI.Text)
                    cn.Open()
                    Dim availablereader As OleDbDataReader = availablecommand.ExecuteReader()
                    'condition to check if the book is available
                    Dim available As Boolean = True
                    While availablereader.Read
                        available = False
                    End While
                    availablereader.Close()
                    cn.Close()

                    If available = False Then
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "availability", "availability();", True)
                        Label1.Text = "Book is not available!!!"
                    Else
                        'condition to see if the issue date is greater then the due date
                        Dim IssueDat As Date = IssueDateI.Text
                        Dim DueDat As Date = DueDate.Text
                        Dim num As Integer = DateDiff(DateInterval.Day, IssueDat, DueDat)
                        If num <= 0 Then
                            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "WrongDate", "WrongDate();", True)
                            Label1.Text = "Due Date should be greater then the Issue date!!!"
                            Return
                        End If

                        Dim cmd As New OleDbCommand("insert into IssueDetails(StudentID, BookID, IssueDate, DueDate) values (@a1,@a2,@a3,@a4)", cn)
                        cmd.Parameters.AddWithValue("a1", StudentUSNI.Text)
                        cmd.Parameters.AddWithValue("a2", BookIDI.Text)
                        cmd.Parameters.AddWithValue("a3", IssueDateI.Text)
                        cmd.Parameters.AddWithValue("a4", DueDate.Text)

                        Dim updateString As String = "UPDATE Books set Status='Issued',ReturnDate = '', IssueDate = '" + IssueDateI.Text + "', StudentUSN = '" + StudentUSNI.Text + "' WHERE BookID = @bookId"
                        Dim cmd1 As New OleDbCommand(updateString, cn)
                        cmd1.Parameters.AddWithValue("bookId", BookIDI.Text)

                        Dim cmd2 As New OleDbCommand("Insert into History(BookId, IssueDate, USN) values (@x1, @x2, @x3)", cn)
                        cmd2.Parameters.AddWithValue("x1", BookIDI.Text)
                        cmd2.Parameters.AddWithValue("x2", IssueDateI.Text)
                        cmd2.Parameters.AddWithValue("x3", StudentUSNI.Text)
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cmd1.ExecuteNonQuery()
                        cmd2.ExecuteNonQuery()
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "issueBox", "issueBox();", True)
                        Label1.Text = "Book " + BookIDI.Text + " Issued Successfully"
                        cn.Close()
                    End If

                End If
            Else
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "booksBorrowed", "booksBorrowed();", True)
                Label1.Text = "2 Books borrowed, cant borrow anymore!!!"
            End If

        Catch ex As Exception
            cn.Close()
            Label1.Text = ex.Message
        End Try
        StudentUSN_TextChanged(sender, e)
    End Sub

    Protected Sub BookIDI_TextChanged(sender As Object, e As EventArgs) Handles BookIDI.TextChanged
        IssueDateI.Text = Date.Today
        DueDate.Text = Date.Today.AddDays(14)
    End Sub

    Protected Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Label1.Text = ""
        Try
            Dim cmd1 As New OleDbCommand("UPDATE Books set Status='Available' WHERE BookID = @BookId", cn)
            ''condition to see if the Book Id is selected or not`
            If BookIDDropDownList.SelectedValue.ToString <> "Book ID" Then
                cmd1.Parameters.AddWithValue("BookId", BookIDDropDownList.SelectedValue.ToString)
                Dim cmd2 As New OleDbCommand("DELETE * FROM IssueDetails WHERE (IssueDetails.BookID)=@BookId And (IssueDetails.StudentID)=@StudentId", cn)
                cmd2.Parameters.AddWithValue("BookId", BookIDDropDownList.SelectedValue.ToString)
                cmd2.Parameters.AddWithValue("StudentId", StudentUSN.Text)

                Dim updateString As String = "UPDATE Books set Status='Available', IssueDate= ' ', ReturnDate = '" + ReturnDate.Text + "', StudentUSN = '" + StudentUSN.Text + "' WHERE BookID = @bookId"
                Dim cmd4 As New OleDbCommand(updateString, cn)
                cmd4.Parameters.AddWithValue("bookId", BookIDDropDownList.SelectedValue.ToString)

                Dim cmd3 As New OleDbCommand("Insert into History(BookID, ReturnDate, USN) values (@x1, @x2, @x3)", cn)
                cmd3.Parameters.AddWithValue("x1", BookIDDropDownList.SelectedValue.ToString)
                cmd3.Parameters.AddWithValue("x2", ReturnDate.Text)
                cmd3.Parameters.AddWithValue("x3", StudentUSN.Text)
                ''fine calculation
                Dim date1 As Date = DueDateR.Text
                Dim date2 As Date = ReturnDate.Text
                Dim num As Integer = DateDiff(DateInterval.Day, date1, date2)
                If (num > 0) Then
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "FineMessage", "FineMessage('" & num & "');", True)
                    If num = 1 Then
                        Label1.Text = "Book submitted after " + CType(num, String) + " day. Fine amount is " + CType(num * 2, String)
                    Else
                        Label1.Text = "Book submitted after " + CType(num, String) + " days. Fine amount is " + CType(num * 2, String)
                    End If
                End If
                cn.Open()
                cmd1.ExecuteNonQuery()
                cmd2.ExecuteNonQuery()
                cmd3.ExecuteNonQuery()
                cmd4.ExecuteNonQuery()
                cn.Close()
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "retunrBox", "retunrBox();", True)
                Label1.Text = Label1.Text + " Book " + BookIDDropDownList.SelectedValue.ToString + " Returned Successfully"
                BookIDDropDownList.Items.Remove(BookIDDropDownList.SelectedValue.ToString)
            Else
                'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "BookIDnotSelected", "BookIDnotSelected();", True)
                Label1.Text = "Please Select a Book ID!!!"
            End If
        Catch ex As Exception
            cn.Close()
            Label1.Text = ex.Message
        End Try
    End Sub

    Protected Sub SignOut(sender As Object, e As EventArgs) Handles SignOutButton.Click
        Session("New") = Nothing
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub StudentUSN_TextChanged(sender As Object, e As EventArgs) Handles StudentUSN.TextChanged
        ''removing the items from the drop down list
        For x As Integer = BookIDDropDownList.Items.Count - 1 To 0 Step -1
            Dim item As ListItem = BookIDDropDownList.Items(x)
            'remove the above line .. it is the reason for css bug of textbox resizing
            If item.ToString <> "Book ID" Then ''dont remove Book Id from drop down list
                BookIDDropDownList.Items.RemoveAt(x)
            End If
        Next

        cn.Open()
        Dim cmd As New OleDbCommand("SELECT BookId FROM IssueDetails WHERE  StudentID = @studentID", cn)
        cmd.Parameters.AddWithValue("@studentID", StudentUSN.Text)
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        Dim count As Integer = 0
        Dim BookIdArr() As String = {0, 0, 0}
        While reader.Read
            BookIdArr(count) = reader.Item("BookId")
            count = count + 1
        End While
        Dim firstBookId As ListItem = Nothing
        Dim secondBookId As ListItem = Nothing
        If BookIdArr(0) <> "0" Then
            firstBookId = New ListItem(BookIdArr(0), BookIdArr(0)) ''first element from the book Id array to the second item in the drop down
            BookIDDropDownList.Items.Add(firstBookId)
        End If
        If BookIdArr(1) <> "0" Then
            secondBookId = New ListItem(BookIdArr(1), BookIdArr(1))
            BookIDDropDownList.Items.Add(secondBookId)
        End If
        cn.Close()
    End Sub

    Private Sub BookIDDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BookIDDropDownList.SelectedIndexChanged
        ' Response.Write(BookIDDropDownList.SelectedValue.ToString)
        Dim DueDateString As String = Nothing
        cn.Open()
        Dim cmd As New OleDbCommand("SELECT DueDate FROM IssueDetails WHERE  BookID = @BookId", cn)
        cmd.Parameters.AddWithValue("@BookId", BookIDDropDownList.SelectedValue.ToString)
        Dim reader As OleDbDataReader = cmd.ExecuteReader()
        While reader.Read
            DueDateString = reader.Item("DueDate")
        End While
        DueDateR.Text = DueDateString
        ReturnDate.Text = Date.Today
    End Sub
End Class
