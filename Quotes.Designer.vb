<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuotes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblQuote = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lstCategory = New System.Windows.Forms.ListBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.txtQuote = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAddCat = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(12, 9)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(84, 13)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.Text = "Quote Category:"
        '
        'lblQuote
        '
        Me.lblQuote.AutoSize = True
        Me.lblQuote.Location = New System.Drawing.Point(12, 134)
        Me.lblQuote.Name = "lblQuote"
        Me.lblQuote.Size = New System.Drawing.Size(39, 13)
        Me.lblQuote.TabIndex = 1
        Me.lblQuote.Text = "Quote:"
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Location = New System.Drawing.Point(12, 211)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(41, 13)
        Me.lblAuthor.TabIndex = 2
        Me.lblAuthor.Text = "Author:"
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(12, 240)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(44, 13)
        Me.lblSource.TabIndex = 3
        Me.lblSource.Text = "Source:"
        '
        'lstCategory
        '
        Me.lstCategory.FormattingEnabled = True
        Me.lstCategory.Location = New System.Drawing.Point(15, 25)
        Me.lstCategory.Name = "lstCategory"
        Me.lstCategory.Size = New System.Drawing.Size(120, 95)
        Me.lstCategory.TabIndex = 0
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(155, 25)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(94, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View Quote File"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(59, 208)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(311, 20)
        Me.txtAuthor.TabIndex = 2
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(59, 237)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(311, 20)
        Me.txtSource.TabIndex = 3
        '
        'txtQuote
        '
        Me.txtQuote.Location = New System.Drawing.Point(59, 131)
        Me.txtQuote.Multiline = True
        Me.txtQuote.Name = "txtQuote"
        Me.txtQuote.Size = New System.Drawing.Size(311, 71)
        Me.txtQuote.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(295, 263)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add Quote"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnAddCat
        '
        Me.btnAddCat.Location = New System.Drawing.Point(155, 97)
        Me.btnAddCat.Name = "btnAddCat"
        Me.btnAddCat.Size = New System.Drawing.Size(94, 23)
        Me.btnAddCat.TabIndex = 6
        Me.btnAddCat.Text = "Add Category"
        Me.btnAddCat.UseVisualStyleBackColor = True
        '
        'frmQuotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 292)
        Me.Controls.Add(Me.btnAddCat)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtQuote)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.lstCategory)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblQuote)
        Me.Controls.Add(Me.lblCategory)
        Me.Name = "frmQuotes"
        Me.Text = "Quotes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblQuote As System.Windows.Forms.Label
    Friend WithEvents lblAuthor As System.Windows.Forms.Label
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents lstCategory As System.Windows.Forms.ListBox
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtQuote As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddCat As System.Windows.Forms.Button

End Class
