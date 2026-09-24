<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTA440C
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA440C))
        Me.TxTSearch = New System.Windows.Forms.TextBox()
        Me.C1TrueDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkPost = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxTSearch
        '
        Me.TxTSearch.Location = New System.Drawing.Point(81, 17)
        Me.TxTSearch.Name = "TxTSearch"
        Me.TxTSearch.Size = New System.Drawing.Size(86, 20)
        Me.TxTSearch.TabIndex = 0
        '
        'C1TrueDBGrid1
        '
        Me.C1TrueDBGrid1.AllowColMove = False
        Me.C1TrueDBGrid1.AllowDelete = True
        Me.C1TrueDBGrid1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1TrueDBGrid1.AllowUpdate = False
        Me.C1TrueDBGrid1.AlternatingRows = True
        Me.C1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1TrueDBGrid1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.C1TrueDBGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1TrueDBGrid1.Images.Add(CType(resources.GetObject("C1TrueDBGrid1.Images"), System.Drawing.Image))
        Me.C1TrueDBGrid1.Location = New System.Drawing.Point(12, 101)
        Me.C1TrueDBGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1TrueDBGrid1.Name = "C1TrueDBGrid1"
        Me.C1TrueDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1TrueDBGrid1.PreviewInfo.ZoomFactor = 75.0R
        Me.C1TrueDBGrid1.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1TrueDBGrid1.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1TrueDBGrid1.RowHeight = 16
        Me.C1TrueDBGrid1.Size = New System.Drawing.Size(816, 344)
        Me.C1TrueDBGrid1.TabIndex = 9
        Me.C1TrueDBGrid1.PropBag = resources.GetString("C1TrueDBGrid1.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "To delete a record click on row then use delete key"
        '
        'BtnFind
        '
        Me.BtnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFind.Location = New System.Drawing.Point(205, 14)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(61, 26)
        Me.BtnFind.TabIndex = 2
        Me.BtnFind.Text = "Find"
        Me.BtnFind.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Search Grid"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ChkPost)
        Me.GroupBox1.Location = New System.Drawing.Point(390, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(398, 50)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Posting will change the records below to Non Tax"
        '
        'ChkPost
        '
        Me.ChkPost.AutoSize = True
        Me.ChkPost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPost.Location = New System.Drawing.Point(277, 19)
        Me.ChkPost.Name = "ChkPost"
        Me.ChkPost.Size = New System.Drawing.Size(90, 17)
        Me.ChkPost.TabIndex = 14
        Me.ChkPost.TabStop = False
        Me.ChkPost.Text = "Post Change "
        Me.ChkPost.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.ChkPost.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnFind)
        Me.GroupBox2.Controls.Add(Me.TxTSearch)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(39, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(322, 50)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'FrmTA440C
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(840, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1TrueDBGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA440C"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.C1TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxTSearch As TextBox
    Friend WithEvents C1TrueDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFind As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ChkPost As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
