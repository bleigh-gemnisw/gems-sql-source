Public Class FrmGL403B
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkBatchNo As Integer
  Dim WrkBatchDate As Integer
  Dim WrkBatchHead As String    ' kb added 9/21/26

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL403B))
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
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 7)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(559, 303)
    Me.C1DataGrdList.TabIndex = 8
    Me.ToolTip1.SetToolTip(Me.C1DataGrdList, "Yellow = Open Batch, Pink = Posting")
    '
    'FrmGL403B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(578, 322)
    Me.ControlBox = False
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmGL403B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmGL403B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    With MyFrmGL403
      .TBarNew.Enabled = False
    End With
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

      ' kb added 9/21/26 - show batch heading as Description after Status
      .Columns("Heading").Caption = "Description"
      .Splits(0).DisplayColumns("Heading").Width = 200

      .Columns("LastUser").Caption = "Last User"
      .Splits(0).DisplayColumns("LastUser").Width = 100

      .Columns("PostDate").Caption = "Last Used"
      .Splits(0).DisplayColumns("PostDate").Width = 70
      .Columns("PostDate").NumberFormat = "##/##/####"

      .Columns("Records").Caption = "Records"
      .Splits(0).DisplayColumns("Records").Width = 50
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

  Private Sub FrmGL403B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL403.SbpScreen.Text = "GL403B"
    With MyFrmGL403
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim Answer As Integer
    Dim WrkStatus As String

    '    PassSecurity = GetFNDSEC(MyFrmGL403B.C1DataGrdList.Item(MyFrmGL403B.C1DataGrdList.Row, 5))
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

    ' kb added 9/21/26 - pass batch description to detail screen
    WrkBatchHead = C1DataGrdList.Item(C1DataGrdList.Row, 5)

    OpenBatch()
    MyFrmGL403.TBarNew.Enabled = False
    MyFrmGL403.TBarDelete.Enabled = False
    MyFrmGL403C = New FrmGL403C
    MyFrmGL403C.MdiParent = Me.ParentForm
    MyFrmGL403C.WrkBatchNo = WrkBatchNo
    MyFrmGL403C.WrkBatchDate = WrkBatchDate
    MyFrmGL403C.WrkBatchHead = WrkBatchHead     ' kb added 9/21/26
    MyFrmGL403C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

  Private Sub OpenBatch()
    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)

    ' kb changed 9/21/26 - retain original PostDate column position
    WrkBatchDate = C1DataGrdList.Item(C1DataGrdList.Row, 3)

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "A"
      .UpdateOneRecordP()
    End With

  End Sub

  Public Sub DeleteData(ByRef Cancel As Boolean)

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmDltBch = New FrmDltBch
    MyFrmDltBch.MdiParent = MyFrmGL403B.ParentForm
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

  Private Sub FrmGL403B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmGL403B = Nothing
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

      ' kb added 9/21/26 - add Heading at end to preserve original column positions
      .Columns.Add("Heading", Type.GetType("System.String"))
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

        ' kb added 9/21/26 - batch description
        dr("Heading") = ds2.Tables(0).Rows(I).Item("headg")

        ds.Tables(0).Rows.Add(dr)
      End With
    Next

    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub

End Class