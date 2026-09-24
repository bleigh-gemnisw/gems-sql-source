Public Class FrmMR001B
  Inherits System.Windows.Forms.Form
  Dim myMRBCH As MRBCH.MyData
  Dim myMRBCHD As MRBCHD.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkBatchNo As Integer
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkBatchType As String

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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 10)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(446, 260)
    Me.DataGrdView.TabIndex = 41
    '
    'FrmMR001B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(470, 282)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmMR001B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmMR001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRBCHD = New MRBCHD.MyData()
    myMRBCHD.MyDBConn = myDBConnect
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Batch"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Status"
      .Columns(1).Width = 70
      .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      .Columns(2).HeaderText = "Description"
      .Columns(2).Width = 150
      .Columns(3).HeaderText = "Receipt Dt"
      .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      '.Columns(3).DefaultCellStyle.Format = "MM/dd/yyyy"
      .Columns(3).Width = 65
      .Columns(4).Width = 80
      .Columns(4).HeaderText = "Total"
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds2 As DataSet = New DataSet
    ds = myMRBCH.PosData(0)
    ds2 = PopulateGrid()
    DataGrdView.DataSource = ds2.Tables(0)
    DataGrdView.Refresh()
  End Sub

  Private Sub FrmMR001B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMR001.SbpScreen.Text = "MR001B"
    With MyFrmMR001
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkStatus As String
    Dim Answer As Integer

    If DataGrdView.RowCount = 0 Then Exit Sub
    WrkStatus = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    If WrkStatus = "A" Then
      Answer = MsgBox("Make sure nobody else has batch open", MsgBoxStyle.YesNo, "Open this active batch?")
      If Answer = MsgBoxResult.No Then Exit Sub
    End If

    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value

    OpenBatch()
    MyFrmMR001.TBarNew.Enabled = False
    MyFrmMR001.TBarDelete.Enabled = False
    MyFrmMR001C = New FrmMR001C
    MyFrmMR001C.MdiParent = Me.ParentForm
    MyFrmMR001C.WrkBatchNo = WrkBatchNo
    MyFrmMR001C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    myMRBCH.GetOneRecordP(WrkBatchNo)
    With myMRBCH
      ._STATUS = "A"
      .UpdateOneRecordP()
      MySelCodes = Trim(._CODES)
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    If MyFrmMR001B.DataGrdView.Rows.Count = 0 Then Exit Sub
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    Cancel = False
    Answer = MsgBox("Delete batch " & WrkBatchNo & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete Batch")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myMRBCH.GetOneRecordP(WrkBatchNo)
    If Not myMRBCH.RecordNotFound Then
      myMRBCH.DeleteOneRecordP()
      myMRBCHD.DeleteBatch(WrkBatchNo)
    End If
    FormatGrid()
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If DataGrdView.Columns(e.ColumnIndex).Name = "status" Then
      If e.Value = "P" Then
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
      End If
    End If

    If (e.ColumnIndex = 1) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Active"
        Case "E"
          e.Value = "Edited"
        Case "P"
          e.Value = "Posting"
        Case "S"
          e.Value = "Suspended"
        Case Else
      End Select
    End If
  End Sub
  Private Function PopulateGrid() As DataSet
    Dim dsGrid As New DataSet
    Dim myTable As New DataTable
    Dim dr As DataRow
    Dim I As Integer

    With myTable
      .TableName = "mytable"
      .Columns.Add("Bchno", Type.GetType("System.Int16"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Recdt", Type.GetType("System.DateTime"))
      .Columns.Add("Tamt", Type.GetType("System.Decimal"))
    End With
    dsGrid.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dsGrid.Tables(0).NewRow()
        dr = dsGrid.Tables(0).NewRow
        dr("bchno") = .Item("bchno")
        dr("status") = .Item("status")
        dr("descr") = .Item("descr")
        dr("recdt") = MyUtils.GetDBDate(.Item("recdt"))
        dr("tamt") = .Item("tamt")
        dsGrid.Tables(0).Rows.Add(dr)
      End With
    Next

    Return dsGrid
  End Function
  Private Sub FrmMR001B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myMRBCH = Nothing
    MyFrmMR001B = Nothing
  End Sub

  Private Sub DataGrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrdView.CellContentClick

  End Sub
End Class
