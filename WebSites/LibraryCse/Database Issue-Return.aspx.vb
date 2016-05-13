Imports System.Data
Imports System.Data.OleDb

Partial Class Database_Issue_Return
    Inherits System.Web.UI.Page

    Dim cmd As OleDbCommand = Nothing
    Dim cn As OleDbConnection = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("New") = Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub

    Protected Sub IssueCatalog_Click(sender As Object, e As EventArgs) Handles IssueCatalog.Click
        Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
        Dim cn As OleDbConnection = New OleDbConnection(connectString)
        cn.Open()
        Dim selectString As String = Nothing
        selectString = "SELECT B.BookId, BookName, BookAuthor, BookPublisher, FORMAT(H.IssueDate,'DD-MM-YYYY') AS IssuedDate, H.USN FROM Books B, History H WHERE B.BookId=H.BookId and  H.IssueDate >= @issueDate and H.IssueDate <= @returnDate"
        Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
        cmd.Parameters.AddWithValue("@issueDate", IssueFrom.Text)
        cmd.Parameters.AddWithValue("@returnDate", IssueTo.Text)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter
        da.SelectCommand = cmd
        Dim newdataset As DataSet = New DataSet()
        da.Fill(newdataset)
        GridView1.DataSource = newdataset
        GridView1.DataBind()
        cn.Close()
    End Sub

    Private Sub ReturnCatalog_Click(sender As Object, e As EventArgs) Handles ReturnCatalog.Click
        Dim connectString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("libraryBooks.mdb")
        Dim cn As OleDbConnection = New OleDbConnection(connectString)
        cn.Open()
        Dim selectString As String = Nothing
        selectString = "SELECT B.BookId, BookName, BookAuthor, BookPublisher, FORMAT(H.ReturnDate,'DD-MM-YYYY') AS ReturndDate , H.USN FROM Books B, History H WHERE B.BookId=H.BookId and H.ReturnDate >= @fromDate and H.ReturnDate <= @toDate "
        Dim cmd As OleDbCommand = New OleDbCommand(selectString, cn)
        cmd.Parameters.AddWithValue("@fromDate", ReturnFrom.Text)
        cmd.Parameters.AddWithValue("@toDate", ReturnTo.Text)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter
        da.SelectCommand = cmd
        Dim newdataset As DataSet = New DataSet()
        da.Fill(newdataset)
        GridView1.DataSource = newdataset
        GridView1.DataBind()
        cn.Close()
    End Sub
    Protected Sub SignOut(sender As Object, e As EventArgs) Handles SignOutButton.Click
        Session("New") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
End Class