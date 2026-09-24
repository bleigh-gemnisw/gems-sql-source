Public Class FrmGLA02B
		Inherits System.Windows.Forms.Form
    Dim myBCHHDR As BCHHDR.MyData
    Dim myBCHHDRL1 As BCHHDRL1.MyData
		Dim myTAXBCH As TAXBCH.myData
    Dim myNETGLBCH As NETGLBCH.myData
    Dim ds As DataSet = New DataSet
    Dim WrkBatchNo As Integer
  Friend WithEvents LblBatchesTotal As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkBatchTotal As Decimal

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
    Me.LblBatchesTotal = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblBatchesTotal
    '
    Me.LblBatchesTotal.Location = New System.Drawing.Point(374, 9)
    Me.LblBatchesTotal.Name = "LblBatchesTotal"
    Me.LblBatchesTotal.Size = New System.Drawing.Size(173, 17)
    Me.LblBatchesTotal.TabIndex = 9
    Me.LblBatchesTotal.Text = "Batches Total"
    Me.LblBatchesTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 60)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(554, 263)
    Me.DataGrdView.TabIndex = 206
    '
    'FrmGLA02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(578, 335)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblBatchesTotal)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmGLA02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmGLA02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myTAXBCH = New TAXBCH.MyData()
    myTAXBCH.MyDBConn = myDBConnect
    myNETGLBCH = New NETGLBCH.MyData()
    myNETGLBCH.MyDBConn = myDBConnect
    With MyFrmGLA02
      .TBarNew.Enabled = True
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
      .Columns(3).HeaderText = "Ref No"
      .Columns(3).Width = 45
      .Columns(4).HeaderText = "Dist"
      .Columns(4).Width = 30
      .Columns(5).HeaderText = "Fund"
      .Columns(5).Width = 30
      .Columns(6).HeaderText = "Description"
      .Columns(6).Width = 150
      .Columns(7).HeaderText = "Total"
      .Columns(7).Width = 75
      .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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

  Private Sub FrmGLA02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGLA02.SbpScreen.Text = "GLA02B"
    With MyFrmGLA02
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim PassSecurity As Boolean
    Dim WrkStatus As String

    PassSecurity = GetFNDSEC(DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value)
    If Not PassSecurity Then Exit Sub
    WrkStatus = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    If WrkStatus = "A" Then
      MsgBox("Batch is already active", MsgBoxStyle.Exclamation, "Active Batch not available")
      Exit Sub
    End If

    If WrkStatus = "P" Then
      MsgBox("Reports will show overpaid any previous posted records. Those accounts will be skipped.", MsgBoxStyle.Information, "Notice: Recovery mode reports")
      Exit Sub
    End If

    WrkBatchNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value

    OpenBatch()
    MyFrmGLA02.TBarNew.Enabled = False
    MyFrmGLA02.TBarDelete.Enabled = False
    MyFrmGLA02C = New FrmGLA02C
    MyFrmGLA02C.MdiParent = Me.ParentForm
    MyFrmGLA02C.WrkBatchNo = WrkBatchNo
    MyFrmGLA02C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 1) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Active"
          DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        Case "E"
          e.Value = "Edited"
        Case "P"
          e.Value = "Posted"
          DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
        Case "S"
          e.Value = "Suspended"
        Case Else
      End Select
    End If
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
    MyFrmDltBch.MdiParent = MyFrmGLA02B.ParentForm
    MyFrmDltBch.WrkBatchNo = WrkBatchNo
    MyFrmDltBch.Show()
    Me.Hide()
  End Sub
  Private Sub FrmGLA02B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmGLA02B = Nothing
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("PostDate", Type.GetType("System.DateTime"))
      .Columns.Add("RefNo", Type.GetType("System.Int16"))
      .Columns.Add("Dist", Type.GetType("System.Int16"))
      .Columns.Add("Fund", Type.GetType("System.Int16"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub CreateDS(ByVal ds2 As DataSet)
	Dim dr As Data.DataRow
	Dim WrkBatchNo As Integer
	Dim I As Integer

	Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  WrkBatchTotal = 0

	For I = 0 To (ds2.Tables(0).Rows.Count - 1)
		With ds2.Tables(0).Rows(I)
			WrkBatchNo = ds2.Tables(0).Rows(I).Item("bchno")
			dr = ds.Tables(0).NewRow
			dr("Batch") = WrkBatchNo
			dr("Status") = ds2.Tables(0).Rows(I).Item("stats")
      dr("PostDate") = MyUtils.GetDBDateMDY(ds2.Tables(0).Rows(I).Item("postdt"))
			myTAXBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
      dr("RefNo") = myTAXBCH._REFNO
      dr("Dist") = myTAXBCH._DIST
      dr("Fund") = myTAXBCH._FDNBR
			dr("Desc") = Trim(myTAXBCH._DESCR)
			dr("Total") = myTAXBCH._TOTCR
			ds.Tables(0).Rows.Add(dr)
      WrkBatchTotal = WrkBatchTotal + myTAXBCH._TOTCR
    End With
	Next
  LblBatchesTotal.Text = "Batches Total  " & Format(WrkBatchTotal, "Fixed")
	Windows.Forms.Cursor.Current = Cursors.Default

End Sub
End Class
