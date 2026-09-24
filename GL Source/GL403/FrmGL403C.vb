Public Class FrmGL403C

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLRBCH As GLRBCH.MyData
  Dim myGLRBCHL1 As GLRBCHL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkBatchNo As Integer
  Friend WrkBatchDate As Integer
  Friend WrkBatchHead As String

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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGL403C))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 12)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(408, 328)
    Me.C1DataGrdList.TabIndex = 8
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'FrmGL403C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 350)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL403C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmGL403B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLRBCH = New GLRBCH.MyData()
    myGLRBCH.MyDBConn = myDBConnect
    myGLRBCHL1 = New GLRBCHL1.MyData()
    myGLRBCHL1.MyDBConn = myDBConnect
    With MyFrmGL403
      .TBarCreate.Enabled = False
      .TBarChange.Enabled = False
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    ' Me.Text = Me.Text & " " & WrkBatchNo
    Me.Text = Me.Text & " " & WrkBatchNo & " - " & WrkBatchHead    ' kb changed to this 9/21/26
    Call FormatGrid()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "Tran #"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Total Debit"
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Total Credit"
      .Splits(0).DisplayColumns(2).Width = 70
      .Columns(3).Caption = "Type"
      .Columns(3).ValueItems.Values.Clear()
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Budget"))
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("E", "Encumbrance"))
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("T", "Transfer"))
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("X", "Adjustment"))
      .Columns(3).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("Z", "Orig Budget"))
      .Columns(3).ValueItems.Translate = True
      .Splits(0).DisplayColumns(3).Width = 100
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myGLRBCHL1.GetViewbyBatchTot(WrkBatchNo, 9999)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub FrmGL403C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL403.SbpScreen.Text = "GL403C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkReceiptDate As Date

    If C1DataGrdList.VisibleRows = 0 Then Exit Sub
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmGL403D = New FrmGL403D
    MyFrmGL403D.MdiParent = Me.ParentForm
    MyFrmGL403D.WrkBatchNo = WrkBatchNo
    MyFrmGL403D.WrkBatchDate = WrkBatchDate
    MyFrmGL403D.WrkTran = MyUtils.CnvSng(C1DataGrdList.Item(C1DataGrdList.Row, 0))
    MyFrmGL403D.Show()
    Me.Hide()
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = False
    Answer = MsgBox("Delete this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Cancel = True
      Exit Sub
    End If

    myGLRBCH.DeleteTran(WrkBatchNo, MyUtils.CnvSng(C1DataGrdList.Item(C1DataGrdList.Row, 0)))
    FormatGrid()
  End Sub
  Private Sub FrmGL403C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim WrkCount As Integer
    WrkCount = myGLRBCHL1.GetBatchCount(WrkBatchNo)
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._LSTUS = MyUserID
      ._STATS = "S"
      ._NBRRC = WrkCount
      .UpdateOneRecordP()
    End With
    With MyFrmGL403
      .TBarCreate.Enabled = True
      .TBarChange.Enabled = True
      .TBarNew.Enabled = False
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmGL403B.FormatGrid()
    MyFrmGL403B.Show()

  End Sub
  'Public Sub NewTran()
  '  Dim WrkReceiptDate As Date
  '  Dim WrkTran As Integer

  '  myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
  '  With myBCHHDR
  '    WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
  '  End With
  '  If ds.Tables(0).Rows.Count = 0 Then
  '    WrkTran = 1
  '  Else
  '    WrkTran = ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1).Item("trnbr") + 1
  '  End If
  '  With myGLRBCH
  '    .GetOneRecordP(WrkBatchNo, WrkTran, 0)
  '    ._BCHNO = WrkBatchNo
  '    ._TRNBR = WrkTran
  '    ._FDNBR = 0
  '    ._SFUND = 0
  '    ._DPNBR = 0
  '    ._OBNBR = 0
  '    ._FNPGM = 0
  '    ._SUBFN = 0
  '    ._DESCR = ""
  '    ._AMT = 0
  '    ._AMTTYP = String.Empty
  '    ._GLTYP = ""
  '    ._JACT8 = MyUtils.SetDBDate(WrkReceiptDate)
  '    ._JENT8 = MyUtils.SetDBDate(WrkReceiptDate)
  '    ._JRNSEQ = 0
  '    ._REFNO = 0
  '    ._TOTCR = 0
  '    ._TOTDR = 0
  '    .AddOneRecordP()
  '  End With

  'End Sub
End Class
