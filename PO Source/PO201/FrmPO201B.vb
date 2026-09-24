Public Class FrmPO201B
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim myRQEBCH As RQEBCH.MyData
  Dim myRQEBCHL1 As RQEBCHL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents BtnLoc As System.Windows.Forms.Button
  Friend WithEvents LblLocDesc As System.Windows.Forms.Label
  Friend WithEvents LblLlocn As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
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
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.BtnLoc = New System.Windows.Forms.Button()
    Me.LblLocDesc = New System.Windows.Forms.Label()
    Me.LblLlocn = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnLoc
    '
    Me.BtnLoc.Location = New System.Drawing.Point(8, 10)
    Me.BtnLoc.Name = "BtnLoc"
    Me.BtnLoc.Size = New System.Drawing.Size(90, 23)
    Me.BtnLoc.TabIndex = 9
    Me.BtnLoc.Text = "Set Location"
    Me.BtnLoc.UseVisualStyleBackColor = True
    '
    'LblLocDesc
    '
    Me.LblLocDesc.AutoSize = True
    Me.LblLocDesc.Location = New System.Drawing.Point(155, 15)
    Me.LblLocDesc.Name = "LblLocDesc"
    Me.LblLocDesc.Size = New System.Drawing.Size(62, 13)
    Me.LblLocDesc.TabIndex = 10
    Me.LblLocDesc.Text = "<LocDesc>"
    '
    'LblLlocn
    '
    Me.LblLlocn.AutoSize = True
    Me.LblLlocn.Location = New System.Drawing.Point(104, 15)
    Me.LblLlocn.Name = "LblLlocn"
    Me.LblLlocn.Size = New System.Drawing.Size(45, 13)
    Me.LblLlocn.TabIndex = 11
    Me.LblLlocn.Text = "<Llocn>"
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 39)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(373, 278)
    Me.DataGrdView.TabIndex = 204
    '
    'FrmPO201B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(397, 322)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblLlocn)
    Me.Controls.Add(Me.LblLocDesc)
    Me.Controls.Add(Me.BtnLoc)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmPO201B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPO201B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myRQEBCH = New RQEBCH.MyData()
    myRQEBCH.MyDBConn = myDBConnect
    myRQEBCHL1 = New RQEBCHL1.MyData()
    myRQEBCHL1.MyDBConn = myDBConnect
    LblLlocn.Text = ""
    LblLocDesc.Text = ""
    BuildDS()
    MyFrmPO201.TBarNew.Enabled = False
    MyFrmPO201.TBarDelete.Enabled = False
    MyFrmPO201.TBarPrtEdits.Enabled = False
    MyFrmPO201.TBarPost.Enabled = False
    If MyApproveMode Then
      MyFrmPO201.TBarPost.Visible = True
    Else
      MyFrmPO201.TBarPost.Visible = False
    End If
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

  Private Sub FrmPO201B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO201.SbpScreen.Text = "PO201B"
    With MyFrmPO201
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkStatus As String

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
    MyFrmPO201.TBarNew.Enabled = False
    MyFrmPO201.TBarDelete.Enabled = False
    MyFrmPO201D = New FrmPO201D
    MyFrmPO201D.MdiParent = Me.ParentForm
    MyFrmPO201D.WrkLlocn = Trim(LblLlocn.Text)
    MyFrmPO201D.WrkBatchNo = WrkBatchNo
    MyFrmPO201D.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value()
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      MyPostDate = MyUtils.GetDBDate(._PSDT)
      ._STATS = "A"
      .UpdateOneRecordP()
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
    MyFrmDltBch.MdiParent = MyFrmPO201B.ParentForm
    MyFrmDltBch.WrkLlocn = Trim(LblLlocn.Text)
    MyFrmDltBch.WrkBatchNo = WrkBatchNo
    MyFrmDltBch.Show()
    Me.Hide()
  End Sub
  Private Sub FrmPO201B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmPO201B = Nothing
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
    Dim WrkLlocn As String
    Dim WrkBatchNo As Integer
    Dim I As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    WrkLlocn = Trim(LblLlocn.Text)
    For I = 0 To (ds2.Tables(0).Rows.Count - 1)
      With ds2.Tables(0).Rows(I)
        WrkBatchNo = ds2.Tables(0).Rows(I).Item("bchno")
        ds3 = myRQEBCHL1.GetViewbyBatch(WrkLlocn, WrkBatchNo, 0)
        If ds3.Tables(0).Rows.Count > 0 Then
          dr = ds.Tables(0).NewRow
          dr("Batch") = WrkBatchNo
          dr("Status") = ds2.Tables(0).Rows(I).Item("stats")
          dr("numrecs") = ds3.Tables(0).Rows.Count
          dr("UserID") = ds2.Tables(0).Rows(I).Item("lstus")
          dr("PostDate") = ds2.Tables(0).Rows(I).Item("postdt")
          ds.Tables(0).Rows.Add(dr)
        Else
          If Trim(ds2.Tables(0).Rows(I).Item("entpm")) = WrkLlocn Then
            dr = ds.Tables(0).NewRow
            dr("Batch") = WrkBatchNo
            dr("Status") = ds2.Tables(0).Rows(I).Item("stats")
            dr("numrecs") = 0
            dr("UserID") = ds2.Tables(0).Rows(I).Item("lstus")
            dr("PostDate") = ds2.Tables(0).Rows(I).Item("postdt")
            ds.Tables(0).Rows.Add(dr)
          End If
        End If
      End With
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub BtnLoc_Click(sender As Object, e As EventArgs) Handles BtnLoc.Click
    ShowLocsec()
  End Sub
  Private Sub ShowLocsec()
    MyFrmListLocsec = New FrmListLocsec
    MyFrmListLocsec.MdiParent = Me.ParentForm
    MyFrmListLocsec.Show()
    Me.Hide()
  End Sub
End Class
