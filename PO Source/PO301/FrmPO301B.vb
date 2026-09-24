Public Class FrmPO301B
    Inherits System.Windows.Forms.Form
    Dim myBCHHDR As BCHHDR.MyData
    Dim myBCHHDRL1 As BCHHDRL1.MyData
    Dim myPOMBCH As POMBCH.MyData
    Dim myPOMBCHL1 As POMBCHL1.MyData
    Dim ds As DataSet = New DataSet
    Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
    Dim WrkBatchNo As Integer

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 12)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.Size = New System.Drawing.Size(373, 298)
    Me.DataGrdView.TabIndex = 203
    '
    'FrmPO301B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(397, 322)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmPO301B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

 Private Sub FrmPO301B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myBCHHDRL1 = New BCHHDRL1.MyData()
   myBCHHDRL1.MyDBConn = myDBConnect
   myPOMBCH = New POMBCH.MyData()
   myPOMBCH.MyDBConn = myDBConnect
   myPOMBCHL1 = New POMBCHL1.MyData()
   myPOMBCHL1.MyDBConn = myDBConnect
   BuildDS()
   MyFrmPO301.TBarNew.Enabled = True
   MyFrmPO301.TBarDelete.Enabled = True
   MyFrmPO301.TBarSave.Enabled = False
   MyFrmPO301.TBarPrtEdits.Enabled = True
   MyFrmPO301.TBarPost.Enabled = True
   FormatGrid()
 End Sub
Public Sub FormatGrid()
  Call ShowGrid()
  With DataGrdView
    .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    .RowHeadersWidth = 25
    .Columns(0).HeaderText = "Batch"
    .Columns(0).Width = 40
    .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    .Columns(1).HeaderText = "Status"
    .Columns(1).Width = 70
    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    .Columns(2).HeaderText = "No Recs"
    .Columns(2).Width = 50
    .Columns(3).HeaderText = "Last User"
    .Columns(3).Width = 100
    .Columns(4).HeaderText = "Post Date"
    .Columns(4).DefaultCellStyle.Format = "##/##/####"
    .Columns(4).Width = 70
  End With

End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 1) Then
    Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
      Case "A"
        e.Value = "Active"
      Case "E"
        e.Value = "Edited"
      Case "H"
        e.Value = "Hold"
      Case "P"
        e.Value = "Posting"
      Case "S"
        e.Value = "Suspend"
      Case Else
      End Select
    End If
  End Sub
Private Sub DataGrdView_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGrdView.RowPrePaint
  If DataGrdView.Rows(e.RowIndex).Cells.Item("status").Value = "A" Then
    DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
  End If
  If DataGrdView.Rows(e.RowIndex).Cells.Item("status").Value = "H" Then
    DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Yellow
  End If
  If DataGrdView.Rows(e.RowIndex).Cells.Item("status").Value = "P" Then
    DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = System.Drawing.Color.Pink
  End If
End Sub
    Public Sub ShowGrid()
      Dim ds2 As DataSet = New DataSet
      ds.Clear()
      ds2 = myBCHHDRL1.GetViewbyAppID(MyBatch, 999)
      CreateDS(ds2)
      DataGrdView.DataSource = ds.Tables(0)
      DataGrdView.Refresh()
    End Sub

  Private Sub FrmPO301B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO301.SbpScreen.Text = "PO301B"
    With MyFrmPO301
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkStatus As String

    '    PassSecurity = GetFNDSEC(MyFrmPO301B.DataGrdList.Item(MyFrmPO301B.DataGrdList.Row, 5))
    '    If Not PassSecurity Then Exit Sub

    If DataGrdView.RowCount = 0 Then Exit Sub

    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value()
    WrkStatus = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value()
    If WrkStatus = "A" Then
      SuspendBatch()
    End If

    If WrkStatus = "P" Then
      MsgBox("Reports will show overpaid any previous posted records. Those accounts will be skipped.", MsgBoxStyle.Information, "Notice: Recovery mode reports")
      Exit Sub
    End If

    OpenBatch()
    MyFrmPO301.TBarNew.Enabled = False
    MyFrmPO301.TBarDelete.Enabled = False
    MyFrmPO301D = New FrmPO301D
    MyFrmPO301D.MdiParent = Me.ParentForm
    MyFrmPO301D.WrkBatchNo = WrkBatchNo
    MyFrmPO301D.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value()
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      MyPostDate = MyUtils.GetDBDate(._PSDT)
      If ._STATS = "S" Then
        ._STATS = "A"
        .UpdateOneRecordP()
      End If
    End With

  End Sub
Public Sub SuspendBatch()
    Dim Answer As Integer

    Answer = MsgBox("You must suspend batch to edit", MsgBoxStyle.OkCancel, "Suspend Batch requested")
    If Answer = MsgBoxResult.Cancel Then
      Exit Sub
    End If
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value()
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
      .UpdateOneRecordP()
    End With
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)

  WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value()
    MyFrmDltBch = New FrmDltBch
    MyFrmDltBch.MdiParent = MyFrmPO301B.ParentForm
  MyFrmDltBch.WrkBatchNo = WrkBatchNo
  MyFrmDltBch.Show()
  Me.Hide()
End Sub
Private Sub FrmPO301B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  'Memory Cleanup
  myBCHHDR = Nothing
  MyFrmPO301B = Nothing
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("NumRecs", Type.GetType("System.Int16"))
      .Columns.Add("UserID", Type.GetType("System.String"))
      .Columns.Add("PostDate", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub CreateDS(ByVal ds2 As DataSet)
  Dim ds3 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkBatchNo As Integer
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  For I = 0 To (ds2.Tables(0).Rows.Count - 1)
    With ds2.Tables(0).Rows(I)
      WrkBatchNo = ds2.Tables(0).Rows(I).Item("bchno")
      dr = ds.Tables(0).NewRow
      dr("Batch") = WrkBatchNo
      dr("Status") = ds2.Tables(0).Rows(I).Item("stats")
      ds3 = myPOMBCHL1.GetViewbyBatch(WrkBatchNo, 0)
      dr("numrecs") = ds3.Tables(0).Rows.Count
      dr("UserID") = ds2.Tables(0).Rows(I).Item("lstus")
      dr("PostDate") = ds2.Tables(0).Rows(I).Item("postdt")
      ds.Tables(0).Rows.Add(dr)
    End With
  Next

  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub BtnLoc_Click(sender As Object, e As EventArgs)
  ShowLocsec()
End Sub
Private Sub ShowLocsec()
  MyFrmListLocsec = New FrmListLocsec
  MyFrmListLocsec.MdiParent = Me.ParentForm
  MyFrmListLocsec.Show()
  Me.Hide()
End Sub
End Class
