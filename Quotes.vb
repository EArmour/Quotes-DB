Imports System.IO

Public Class frmQuotes

    Dim dir As String = Environment.GetEnvironmentVariable("DropboxPath")
    Dim changed() As String

    Public Sub frmQuotes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dir = Nothing Then
            dir = Environment.GetEnvironmentVariable("USERPROFILE")
            dir = dir & "\Dropbox"
            If Directory.Exists(dir) = False Then
                dir = "C:\Dropbox"
                If Directory.Exists(dir) = False Then
                    Dim inputDir As String = InputBox("Dropbox directory not found! Enter full Dropbox directory (IE: C:\Users\John\Dropbox)", "Error")
                    dir = inputDir.Trim("\")
                End If
            End If
        End If
        RefreshCategories()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        ' Get category selection before RefreshCategories clears the list
        Dim selected As Integer = lstCategory.SelectedIndex
        ' Open quote files in system default .txt viewer
        Dim fileLoc() As String = RefreshCategories()
        Diagnostics.Process.Start(fileLoc(selected))
        lstCategory.SelectedIndex() = selected
    End Sub

    Private Sub btnAdd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSource.KeyPress, txtAuthor.KeyPress
        ' Listen for ENTER keypress in Author or Source (optional) textbox
        If e.KeyChar = Chr(13) And lstCategory.SelectedIndex = -1 Then
            MsgBox("Error! No category selected.", , "Error")
            Return
        End If
        If e.KeyChar = Chr(13) Then
            ' Get category selection before RefreshCategories recreates the list
            Dim selected As Integer = lstCategory.SelectedIndex
            Dim fileLoc() As String = RefreshCategories()
            Dim active As StreamWriter = New StreamWriter(fileLoc(selected), True)
            active.WriteLine(txtQuote.Text)
            active.WriteLine(vbTab & "~ " & txtAuthor.Text)
            ' Source optional
            If txtSource.TextLength > 0 Then
                active.WriteLine(vbTab & "  " & txtSource.Text)
            End If
            active.WriteLine("")
            active.Close()
            lstCategory.SelectedIndex() = selected
            txtQuote.Text = Nothing
            txtAuthor.Text = Nothing
            txtSource.Text = Nothing
            txtQuote.Focus()
        End If
    End Sub

    Private Sub btnAddCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCat.Click
        Dim catName As String = InputBox("Category Name:", "New Category")
        Dim newCat As StreamWriter
        ' Create new category .txt file
        If MsgBox("Is this for quotes by a person, as opposed to quotes on a subject?", MsgBoxStyle.YesNo, "Category Type") = MsgBoxResult.Yes Then
            'Add sorting characters so person quote files are always at bottom of list
            newCat = New StreamWriter(dir & "\Quotes\z!" & catName & ".txt")
        Else
            newCat = New StreamWriter(dir & "\Quotes\" & catName & ".txt")
        End If
        newCat.Close()
        ' Recreate list of categories to include new
        RefreshCategories()
    End Sub

    Function RefreshCategories()
        Dim newFiles() As String = Directory.GetFiles(dir & "\Quotes\")
        Dim newFile As String
        lstCategory.Items.Clear()
        For Each newFile In newFiles
            ' Remove directory structure
            If newFile.Contains("z!") = False Then
                newFile = newFile.Substring(dir.Length + 8)
            Else
                'Also remove sorting characters for person files
                newFile = newFile.Substring(dir.Length + 10)
            End If

            ' Remove .txt
            newFile = newFile.Remove(newFile.Length - 4)
            ' Populate list of categories
            Me.lstCategory.Items.Add(newFile)
        Next

        Return newFiles
    End Function
End Class