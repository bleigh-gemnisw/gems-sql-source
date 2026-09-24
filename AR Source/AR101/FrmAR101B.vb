Public Class FrmAR101B
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim ds As DataSet = New DataSet
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
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAR101B))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DataGrdList
        '
        Me.C1DataGrdList.AllowColSelect = False
        Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.C1DataGrdList.AllowUpdate = False
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(8, 7)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.Size = New System.Drawing.Size(399, 303)
        Me.C1DataGrdList.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.C1DataGrdList, "Yellow = Open Batch, Pink = Posting")
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'FrmAR101B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(418, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.C1DataGrdList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "FrmAR101B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Batch"
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmAR101B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    BuildDS()
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Columns(0).Caption = "Batch"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(1).ValueItems.Values.Clear()
      .Columns(1).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Active"))
      .Columns(1).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Edited"))
      .Columns(1).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "Posting"))
      .Columns(1).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspended"))
      .Columns(1).ValueItems.Translate = True
      .Columns(1).Caption = "Status"
      .Splits(0).DisplayColumns(1).Width = 70
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      .Columns(2).Caption = "Last User"
      .Splits(0).DisplayColumns(2).Width = 100
      .Columns(3).Caption = "Batch Date"
      .Splits(0).DisplayColumns(3).Width = 70
      .Columns(3).NumberFormat = "##/##/####"
      .Columns(4).Caption = "Records"
      .Splits(0).DisplayColumns(4).Width = 50
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds2 As DataSet = New DataSet
    ds.Clear()
    ds2 = myBCHHDRL1.GetViewbyAppID(MyBatch, 999)
    CreateDS(ds2)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub

  Private Sub FrmAR101B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAR101.SbpScreen.Text = "AR101B"
    With MyFrmAR101
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim Answer As Integer
    Dim WrkStatus As String

    '    PassSecurity = GetFNDSEC(MyFrmAR101B.C1DataGrdList.Item(MyFrmAR101B.C1DataGrdList.Row, 5))
    '    If Not PassSecurity Then Exit Sub
    WrkStatus = C1DataGrdList.Item(C1DataGrdList.Row, 1)
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

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)

    OpenBatch()
    MyFrmAR101.TBarDelete.Enabled = False
    MyFrmAR101.TBarPrinters.Enabled = False
    MyFrmAR101C = New FrmAR101C
    MyFrmAR101C.MdiParent = Me.ParentForm
    MyFrmAR101C.WrkBatchNo = WrkBatchNo
    MyFrmAR101C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()
    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "A"
      .UpdateOneRecordP()
    End With

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmDltBch = New FrmDltBch
    MyFrmDltBch.MdiParent = MyFrmAR101B.ParentForm
    MyFrmDltBch.WrkBatchNo = WrkBatchNo
    MyFrmDltBch.Show()
    Me.Hide()
  End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("status").CellValue(e.Row) = "A" Then
      e.CellStyle.BackColor = System.Drawing.Color.Yellow
    End If
    If C1DataGrdList.Columns("status").CellValue(e.Row) = "P" Then
      e.CellStyle.BackColor = System.Drawing.Color.Pink
    End If
  End Sub
  Private Sub FrmAR101B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmAR101B = Nothing
  End Sub

  Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("LastUser", Type.GetType("System.String"))
      .Columns.Add("PostDate", Type.GetType("System.Int32"))
      .Columns.Add("Records", Type.GetType("System.Int16"))
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
        dr("LastUser") = ds2.Tables(0).Rows(I).Item("lstus")
        dr("PostDate") = ds2.Tables(0).Rows(I).Item("postdt")
        dr("Records") = ds2.Tables(0).Rows(I).Item("nbrrc")
        ds.Tables(0).Rows.Add(dr)
      End With
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
End Class
