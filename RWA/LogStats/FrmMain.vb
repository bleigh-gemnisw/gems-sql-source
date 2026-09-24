Imports System.io
Public Class FrmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckEnd As System.Windows.Forms.DateTimePicker
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents BthShow As System.Windows.Forms.Button
 Friend WithEvents TxtFileName As System.Windows.Forms.TextBox
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents LblTotCount As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker()
    Me.DtPckEnd = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BthShow = New System.Windows.Forms.Button()
    Me.TxtFileName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblTotCount = New System.Windows.Forms.Label()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 38)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(624, 394)
    Me.C1DataGrdList.TabIndex = 178
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    '
    'DtPckStart
    '
    Me.DtPckStart.Checked = False
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(12, 12)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.ShowCheckBox = True
    Me.DtPckStart.Size = New System.Drawing.Size(103, 20)
    Me.DtPckStart.TabIndex = 179
    '
    'DtPckEnd
    '
    Me.DtPckEnd.Checked = False
    Me.DtPckEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckEnd.Location = New System.Drawing.Point(143, 12)
    Me.DtPckEnd.Name = "DtPckEnd"
    Me.DtPckEnd.ShowCheckBox = True
    Me.DtPckEnd.Size = New System.Drawing.Size(98, 20)
    Me.DtPckEnd.TabIndex = 180
    Me.DtPckEnd.Value = New Date(2011, 8, 5, 9, 25, 48, 0)
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(121, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(16, 13)
    Me.Label1.TabIndex = 181
    Me.Label1.Text = "to"
    '
    'BthShow
    '
    Me.BthShow.Location = New System.Drawing.Point(256, 4)
    Me.BthShow.Name = "BthShow"
    Me.BthShow.Size = New System.Drawing.Size(56, 28)
    Me.BthShow.TabIndex = 182
    Me.BthShow.Text = "Show"
    Me.BthShow.UseVisualStyleBackColor = True
    '
    'TxtFileName
    '
    Me.TxtFileName.Location = New System.Drawing.Point(418, 9)
    Me.TxtFileName.Name = "TxtFileName"
    Me.TxtFileName.Size = New System.Drawing.Size(130, 20)
    Me.TxtFileName.TabIndex = 183
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(322, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(90, 13)
    Me.Label2.TabIndex = 184
    Me.Label2.Text = "Export File Name "
    '
    'LblTotCount
    '
    Me.LblTotCount.Location = New System.Drawing.Point(558, 12)
    Me.LblTotCount.Name = "LblTotCount"
    Me.LblTotCount.Size = New System.Drawing.Size(43, 13)
    Me.LblTotCount.TabIndex = 185
    Me.LblTotCount.Text = "<Total Count>"
    Me.LblTotCount.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'FrmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(640, 438)
    Me.Controls.Add(Me.LblTotCount)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFileName)
    Me.Controls.Add(Me.BthShow)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckEnd)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Name = "FrmMain"
    Me.Text = "Logs Statistics"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    BuildDS()
    BuildDSDtl()
    LblTotCount.Text = ""
  End Sub
Private Sub FindLogs()
    ds.Clear()
    dsDtl.Clear()
    If DtPckStart.Checked Then
      myStartDate = DtPckStart.Value.Date
    Else
      myStartDate = #1/1/1990#
    End If
    If DtPckEnd.Checked Then
      myEndDate = DtPckEnd.Value.Date
    Else
      myEndDate = Date.Today
    End If
    ReadDir(TxtFileName.Text)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Refresh()
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Width = 500
      .Splits(0).DisplayColumns(1).Width = 70
    End With
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int16"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSDtl()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Program", Type.GetType("System.String"))
      .Columns.Add("User", Type.GetType("System.String"))
      .Columns.Add("Date", Type.GetType("System.String"))
    End With
    dsDtl.Tables.Add(myTable)
  End Sub

Private Sub BthShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BthShow.Click
  FindLogs()
End Sub
Private Sub C1DataGrdList_DoubleClick(sender As Object, e As EventArgs) Handles C1DataGrdList.DoubleClick
  MyFrmMainB = New FrmMainB
  MyFrmMainB.MdiParent = Me.ParentForm
  MyFrmMainB.WrkDescr = C1DataGrdList.Item(C1DataGrdList.Row, 0)
  MyFrmMainB.ShowDialog()
End Sub

Private Sub C1DataGrdList_Click(sender As Object, e As EventArgs) Handles C1DataGrdList.Click

End Sub
End Class
