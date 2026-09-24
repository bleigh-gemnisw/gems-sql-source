Public Class FrmTX901B
  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myBCHHDRL1 As BCHHDRL1.MyData
  Dim myTSPBCH As TSPBCH.MyData
  Dim ds As DataSet = New DataSet
  Dim WrkBatchNo As Integer
  Dim WrkBatchDate As Date

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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX901B))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
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
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.Size = New System.Drawing.Size(224, 268)
    Me.C1DataGrdList.TabIndex = 8
    Me.ToolTip1.SetToolTip(Me.C1DataGrdList, "Yellow = Open Batch, Pink = AS400 Batch")
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'FrmTX901B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(242, 282)
    Me.ControlBox = False
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTX901B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTX901B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myBCHHDRL1 = New BCHHDRL1.MyData()
    myBCHHDRL1.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.MyData(myDBConnect)
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer
    Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .FetchRowStyles = True
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "Batch"
      .Splits(0).DisplayColumns(1).Width = 40
      .Columns(2).ValueItems.Values.Clear()
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Active"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Edited"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("P", "Posting"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Suspended"))
      .Columns(2).ValueItems.Translate = True
      .Columns(2).Caption = "Status"
      .Splits(0).DisplayColumns(2).Width = 70
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
      For I = 3 To 16
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Splits(0).DisplayColumns(17).Width = 70
      .Columns(17).NumberFormat = "##/##/####"
      .Columns(17).Caption = "Post Date"
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myBCHHDRL1.GetViewbyAppID(MyBatch, 999)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

    With MyFrmTX901
      If C1DataGrdList.RowCount = 0 Then
        .TBarChange.Enabled = False
        .TBarDelete.Enabled = False
        .TBarPrtEdits.Enabled = False
        .TBarPost.Enabled = False
      Else
        .TBarChange.Enabled = True
        .TBarDelete.Enabled = True
        .TBarPrtEdits.Enabled = True
        .TBarPost.Enabled = True
      End If
    End With
  End Sub

  Private Sub FrmTX901B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX901.SbpScreen.Text = "TX901B"
    With MyFrmTX901
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkStatus As String

    WrkStatus = C1DataGrdList.Item(C1DataGrdList.Row, 9)
    If WrkStatus = "A" Then
      MsgBox("Batch is already active", MsgBoxStyle.Exclamation, "Active Batch not available")
      Exit Sub
    End If

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    WrkBatchDate = C1DataGrdList.Item(C1DataGrdList.Row, 17)

    OpenBatch()
    MyFrmTX901.TBarNew.Enabled = False
    MyFrmTX901.TBarChange.Enabled = False
    MyFrmTX901.TBarDelete.Enabled = False
    MyFrmTX901C = New FrmTX901C
    MyFrmTX901C.MdiParent = Me.ParentForm
    MyFrmTX901C.WrkBatchNo = WrkBatchNo
    MyFrmTX901C.WrkBatchDate = WrkBatchDate
    MyFrmTX901C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub OpenBatch()

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "A"
    End With
    myBCHHDR.UpdateOneRecordP()

  End Sub
  Public Sub ChangeBatch()
    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)

    MyFrmTX901_BCH = New FrmTX901_BCH
    MyFrmTX901_BCH.MdiParent = MyFrmTX901B.ParentForm
    MyFrmTX901_BCH.WrkBatch = MyBatch
    MyFrmTX901_BCH.WrkBatchNo = WrkBatchNo
    MyFrmTX901_BCH.Show()
    MyFrmTX901B.Hide()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    WrkBatchNo = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    Cancel = False
    Answer = MsgBox("Delete batch " & WrkBatchNo & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete Batch")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    If Not myBCHHDR.RecordNotFound Then
      myBCHHDR.DeleteOneRecordP()
      myTSPBCH.DeleteBatch(WrkBatchNo)
    End If
    FormatGrid()
  End Sub
  Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
    If C1DataGrdList.Columns("stats").CellValue(e.Row) = "O" Then
      e.CellStyle.BackColor = System.Drawing.Color.Yellow
    End If
  End Sub
  Private Sub FrmTX901B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myBCHHDR = Nothing
    MyFrmTX901B = Nothing
  End Sub
End Class






