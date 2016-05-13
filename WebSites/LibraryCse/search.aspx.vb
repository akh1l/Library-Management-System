Imports System.Data
Imports System.Data.OleDb

Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Session("New") = Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub
    Dim cmd As OleDbCommand = Nothing
    Dim cn As OleDbConnection = Nothing

    Protected Sub SignOut(sender As Object, e As EventArgs) Handles SignOutButton.Click
        Session("New") = Nothing
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        If IdRadioButton.Checked = True Then
            If SearchBoxName.Text <> Nothing Then
                Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
                Dim cn As OleDbConnection = New OleDbConnection(connectString)
                cn.Open()
                Dim selectString As String = Nothing
                If CheckBox1.Checked = True Then
                    selectString = "SELECT * FROM Books WHERE BookId = @Id and Status= 'Available' "
                Else
                    selectString = "SELECT * FROM Books WHERE BookId = @Id"
                End If
                Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
                cmd.Parameters.AddWithValue("@Id", SearchBoxName.Text)
                Dim da As OleDbDataAdapter = New OleDbDataAdapter
                da.SelectCommand = cmd
                Dim newdataset As DataSet = New DataSet()
                da.Fill(newdataset)
                GridView1.DataSource = newdataset
                GridView1.DataBind()
                cn.Close()
            End If

        ElseIf NameRadioButton.Checked = True Then
            If SearchBoxName.Text <> Nothing Then
                Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
                Dim cn As OleDbConnection = New OleDbConnection(connectString)
                cn.Open()
                Dim selectString As String = Nothing
                If CheckBox1.Checked = True Then
                    selectString = "SELECT * FROM Books WHERE BookName = @name and Status='Available' "
                Else
                    selectString = "SELECT * FROM Books WHERE BookName = @name"
                End If
                Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
                cmd.Parameters.AddWithValue("@name", SearchBoxName.Text)
                'Label1.Text = selectString
                Dim da As OleDbDataAdapter = New OleDbDataAdapter
                da.SelectCommand = cmd
                Dim newdataset As DataSet = New DataSet()
                da.Fill(newdataset)
                GridView1.DataSource = newdataset
                GridView1.DataBind()
                cn.Close()
            End If
        ElseIf AuthorRadioButton.Checked = True Then
            If SearchBoxName.Text <> Nothing Then
                Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
                Dim cn As OleDbConnection = New OleDbConnection(connectString)
                cn.Open()
                Dim selectString As String = Nothing
                If CheckBox1.Checked = True Then
                    selectString = "SELECT * FROM Books WHERE BookAuthor = @AuthorName and Status= 'Available' "
                Else
                    selectString = "SELECT * FROM Books WHERE BookAuthor = @AuthorName"
                End If
                Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
                cmd.Parameters.AddWithValue("@AuthorName", SearchBoxName.Text)
                Dim da As OleDbDataAdapter = New OleDbDataAdapter
                da.SelectCommand = cmd
                Dim newdataset As DataSet = New DataSet()
                da.Fill(newdataset)
                GridView1.DataSource = newdataset
                GridView1.DataBind()
                cn.Close()
            End If
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
        Dim cn As OleDbConnection = New OleDbConnection(connectString)
        cn.Open()
        Dim selectString As String = "SELECT * FROM Books ORDER BY BookName"
        Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter
        da.SelectCommand = cmd
        Dim newdataset As DataSet = New DataSet()
        da.Fill(newdataset)
        GridView1.DataSource = newdataset
        GridView1.DataBind()
        cn.Close()
    End Sub


    Protected Sub AdvanceSearchButton_Click(sender As Object, e As EventArgs) Handles AdvanceSearchButton.Click
        If NameRadioButton.Checked = True Then
            Dim str As String = SearchBoxName.Text
            'changing into lower case so that the search is not case sensitive... the data retrieved from DB is also changed to lower case
            str = str.ToLower()
            Dim strArr() As String = str.Split()
            Dim bookIdList(100) As String
            For i As Integer = 0 To 100
                bookIdList(i) = "'" & "0" & "'"
            Next
            Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
            Dim cn As OleDbConnection = New OleDbConnection(connectString)
            cn.Open()

            Dim selectString As String = "SELECT * FROM Books ORDER BY BookId"
            Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()



            Dim filterQueryString As String = "SELECT * FROM Books WHERE BookName = @name"
            Dim cmd1 As OleDbCommand = New OleDbCommand(filterQueryString, cn)
            cmd1.Parameters.AddWithValue("@name", SearchBoxName.Text)

            Dim counter As Integer = 0
            While reader.Read
                Dim Bookname As String = reader.Item("BookName")
                'changing it to lower case as done to str above
                Bookname = Bookname.ToLower()
                Dim BookID As String = reader.Item("BookId")
                Dim BookNameArr() As String = Bookname.Split()

                'check if the book already exists then no need to go for advance search
                If Bookname = str Then
                    bookIdList(counter) = "'" & BookID & "'"
                    counter = counter + 1
                    'if the textbox is empty, do not search
                ElseIf str <> Nothing Then
                    For i As Integer = 0 To BookNameArr.Length - 1
                        For j As Integer = 0 To strArr.Length - 1
                            If BookNameArr(i) = strArr(j) Then
                                'filterQueryString = filterQueryString + " UNION " + " SELECT BookId, BookName, BookAuthor, BookPublisher FROM Books WHERE BookId = @BookID"
                                'cmd.Parameters.AddWithValue("@Id", BookId)
                                bookIdList(counter) = "'" & BookID & "'"
                                counter = counter + 1
                                'write a code to exit the comparing when the first occurance matches
                            End If
                        Next
                    Next
                End If

            End While
            If CheckBox1.Checked = True Then
                filterQueryString = " SELECT * FROM Books WHERE " & "BookId in ({0}) and Status= 'Available' ORDER BY BookId "
                filterQueryString = String.Format(filterQueryString, String.Join(",", bookIdList))

            Else filterQueryString = " Select * FROM Books WHERE " & "BookId In ({0}) ORDER BY BookId "
                filterQueryString = String.Format(filterQueryString, String.Join(",", bookIdList))
            End If
            'cmd1.Parameters.AddWithValue("@BookID", i)
            'something wrong while parsing the query.. debug it
            'Label1.Text = filterQueryString
            reader.Close()
            cmd1 = New OleDbCommand(filterQueryString, cn)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter
            da.SelectCommand = cmd1
            Dim newdataset As DataSet = New DataSet()
            da.Fill(newdataset)
            GridView1.DataSource = newdataset
            GridView1.DataBind()
            cn.Close()

        ElseIf AuthorRadioButton.Checked = True Then
            Dim str As String = SearchBoxName.Text
            'changing into lower case so that the search is not case sensitive... the data retrieved from DB is also changed to lower case
            str = str.ToLower()
            Dim strArr() As String = str.Split()
            Dim bookIdList(100) As String
            For i As Integer = 0 To 100
                bookIdList(i) = "'" & "0" & "'"
            Next
            Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
            Dim cn As OleDbConnection = New OleDbConnection(connectString)
            cn.Open()
            Dim selectString As String = "SELECT * FROM Books ORDER BY BookId"
            Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()



            Dim filterQueryString As String = "SELECT * FROM Books WHERE BookAuthor = @Authorname"
            Dim cmd1 As OleDbCommand = New OleDbCommand(filterQueryString, cn)
            cmd1.Parameters.AddWithValue("@Authorname", SearchBoxName.Text)

            Dim counter As Integer = 0
            While reader.Read
                Dim Authorname As String = reader.Item("BookAuthor")
                'cahnging it to lower case as done to str above
                Authorname = Authorname.ToLower()
                Dim BookID As String = reader.Item("BookId")
                Dim BookNameArr() As String = Authorname.Split()

                'check if the book already exists then no need to go for advance search
                If Authorname = str Then
                    bookIdList(counter) = "'" & BookID & "'"
                    counter = counter + 1
                    'if the textbox is empty, do not search
                ElseIf str <> Nothing Then
                    For i As Integer = 0 To BookNameArr.Length - 1
                        For j As Integer = 0 To strArr.Length - 1
                            If BookNameArr(i) = strArr(j) Then
                                'filterQueryString = filterQueryString + " UNION " + " SELECT BookId, BookName, BookAuthor, BookPublisher FROM Books WHERE BookId = @BookID"
                                'cmd.Parameters.AddWithValue("@Id", BookId)
                                bookIdList(counter) = "'" & BookID & "'"
                                counter = counter + 1
                                'write a code to exit the comparing when the first occurance matches
                            End If
                        Next
                    Next
                End If
            End While
            If CheckBox1.Checked = True Then
                filterQueryString = " SELECT * FROM Books WHERE " & "BookId in ({0}) and Status= 'Available' ORDER BY BookId "
                filterQueryString = String.Format(filterQueryString, String.Join(",", bookIdList)) 'Change
            Else filterQueryString = " SELECT * FROM Books WHERE " & "BookId in ({0}) ORDER BY BookId "
                filterQueryString = String.Format(filterQueryString, String.Join(",", bookIdList)) 'Change
            End If
            'cmd1.Parameters.AddWithValue("@BookID", i)
            'something wrong while parsing the query.. debug it
            'Label1.Text = filterQueryString
            reader.Close()
            cmd1 = New OleDbCommand(filterQueryString, cn)
            Dim da As OleDbDataAdapter = New OleDbDataAdapter
            da.SelectCommand = cmd1
            Dim newdataset As DataSet = New DataSet()
            da.Fill(newdataset)
            GridView1.DataSource = newdataset
            GridView1.DataBind()
            cn.Close()
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
