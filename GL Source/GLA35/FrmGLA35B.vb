Public Class FrmGLA35B
    Inherits System.Windows.Forms.Form
    Dim myBCHHDR As BCHHDR.myData
    Dim myBCHHDRL1 As BCHHDRL1.MyData
    Dim myMSCBCH As MSCBCH.myData
    Dim ds As DataSet = New DataSet
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
    Me.DataGrdView.Location = New System.Drawing.Point(2, 3)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(575, 317)
    Me.DataGrdView.TabIndex = 352
    '
    'FrmGLA35B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(578, 322)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmGLA35B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmGLA35B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myMSCBCH = New MSCBCH.MyData()
    myMSCBCH.MyDBConn = myDBConnect
    With MyFrmGLA35
      .TBarNew.Enabled = False
    End With
    BuildDS()
    Call FormatGrid()
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
      .Columns(2).HeaderText = "Last Used"
      .Columns(2).Width = 70
      .Columns(2).DefaultCellStyle.Format = "##/##/####"
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds2 As DataSet = New DataSet
    ds.Clear()
    ds2 = myBCHHDRL1.GetViewbyAppID(MyBatch, 999)
    CreateDS(ds2)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub

  Private Sub FrmGLA35B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA35.SbpScreen.Text = "GLA35B"
    With MyFrmGLA35
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If DataGrdView.Columns(e.ColumnIndex).Name = "status" Then
      If e.Value = "A" Then
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
      End If
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
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim Answer As Integer
    Dim WrkStatus As String

    '    PassSecurity = GetFNDSEC(MyFrmGL401B.C1DataGrdList.Item(MyFrmGL401B.C1DataGrdList.Row, 5))
    '    If Not PassSecurity Then Exit Sub
    WrkStatus = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    If WrkStatus = "A" Then
      Answer = MsgBox("Batch is already active", MsgBoxStyle.YesNo, "Work with Active Batch?")
      If Answer = MsgBoxResult.No Then
        Exit Sub
      End If
    End If

    If WrkStatus = "P" Then
      MsgBox("Reports will show overpaid any previous posted records. Those accounts will be skipped.", MsgBoxStyle.Information, "Notice: Recovery mode reports")
      Exit Sub
    End If

    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value

    OpenBatch()
    MyFrmGLA35.TBarNew.Enabled = False
    MyFrmGLA35.TBarDelete.Enabled = False
    MyFrmGLA35C = New FrmGLA35C
    MyFrmGLA35C.MdiParent = Me.ParentForm
    MyFrmGLA35C.WrkBatchNo = WrkBatchNo
    MyFrmGLA35C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "A"
      .UpdateOneRecordP()
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)

    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmDltBch = New FrmDltBch
    MyFrmDltBch.MdiParent = MyFrmGLA35B.ParentForm
    MyFrmDltBch.WrkBatchNo = WrkBatchNo
    MyFrmDltBch.Show()
    Me.Hide()
  End Sub
  Private Sub FrmGLA35B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmGLA35B = Nothing
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("PostDate", Type.GetType("System.Int32"))
      .Columns.Add("Fund", Type.GetType("System.Int16"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub CreateDS(ByVal ds2 As DataSet)
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
      dr("PostDate") = ds2.Tables(0).Rows(I).Item("postdt")
      myMSCBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
'      dr("Fund") = myMSCBCH._FDNBR
      dr("Total") = myMSCBCH._TOTCR
      ds.Tables(0).Rows.Add(dr)
    End With
  Next

  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class
