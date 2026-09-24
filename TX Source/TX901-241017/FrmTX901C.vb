Public Class FrmTX901C

  Inherits System.Windows.Forms.Form
  Dim myBCHHDR As BCHHDR.MyData
  Dim myTSPBCH As TSPBCH.MyData
  Dim myTSPBCHL1 As TSPBCHL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkBatchNo As Integer
  Friend WrkBatchDate As Date

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
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTX901C))
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.groupBox2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.TxtType)
    Me.groupBox2.Controls.Add(Me.TxtYear)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtList)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(8, 0)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(294, 52)
    Me.groupBox2.TabIndex = 0
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(174, 24)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(190, 24)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(232, 21)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(56, 24)
    Me.BtnShow.TabIndex = 7
    Me.BtnShow.TabStop = False
    Me.BtnShow.Text = "&Show"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(4, 28)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(92, 16)
    Me.label2.TabIndex = 6
    Me.label2.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(96, 24)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(72, 20)
    Me.TxtList.TabIndex = 0
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
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 56)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(501, 328)
    Me.C1DataGrdList.TabIndex = 8
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'FrmTX901C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(525, 392)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.groupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX901C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Batch"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTX901B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.MyData(myDBConnect)
    myTSPBCHL1 = New TSPBCHL1.MyData(myDBConnect)
    With MyFrmTX901
      .TBarNew.Enabled = True
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    Call FormatGrid()
    Me.Text = Me.Text & " " & WrkBatchNo
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Columns(1).Caption = "List#"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Year"
      .Splits(0).DisplayColumns(2).Width = 40
      .Columns(3).Caption = "Type"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Reason"
      .Splits(0).DisplayColumns(4).Width = 50
      .Splits(0).DisplayColumns(5).Visible = False
      .Columns(6).Caption = "Name"
      .Splits(0).DisplayColumns(6).Width = 200
      .Columns(7).Caption = "Amount"
      .Splits(0).DisplayColumns(7).Width = 70
      .Splits(0).DisplayColumns(8).Visible = False
      .Splits(0).DisplayColumns(9).Visible = False
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myTSPBCHL1.GetViewbyBatch(WrkBatchNo, 9999)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
    myTSPBCHL1.CloseFile()
  End Sub
  Private Sub FrmTX901C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX901.SbpScreen.Text = "TX901C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkReceiptDate As Date

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      WrkReceiptDate = MyUtils.GetDBDate(._PSDT)
    End With

    MyFrmTX901D = New FrmTX901D
    MyFrmTX901D.MdiParent = Me.ParentForm
    MyFrmTX901D.WrkBatchNo = WrkBatchNo
    MyFrmTX901D.WrkList = MyUtils.CnvSng(C1DataGrdList.Item(C1DataGrdList.Row, 1))
    MyFrmTX901D.WrkYear = MyUtils.CnvSng(C1DataGrdList.Item(C1DataGrdList.Row, 2))
    MyFrmTX901D.WrkType = C1DataGrdList.Item(C1DataGrdList.Row, 3)
    MyFrmTX901D.Show()
    Me.Hide()
  End Sub
  Private Sub FrmTX901C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
    With myBCHHDR
      ._STATS = "S"
    End With
    myBCHHDR.UpdateOneRecordP()
    With MyFrmTX901
      .TBarNew.Text = "New Batch"
      .TBarNew.Enabled = True
      .TBarChange.Enabled = True
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmTX901B.FormatGrid()
    MyFrmTX901B.Show()

  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub
    If TxtType.Text = "" Then Exit Sub
    If MyUtils.CnvSng(TxtYear.Text) = 0 Then Exit Sub

    myTSPBCH.GetOneRecordP(WrkBatchNo, MyUtils.CnvSng(TxtList.Text),
      MyUtils.CnvSng(TxtYear.Text), TxtType.Text)
    If myTSPBCH.RecordNotFound Then
      MsgBox("List/Year/Type not found in Batch", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    FormatGrid()

    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    MyFrmTX901D = New FrmTX901D
    With MyFrmTX901D
      .WrkBatchNo = WrkBatchNo
      .MdiParent = Me.ParentForm
      .WrkList = MyUtils.CnvSng(TxtList.Text)
      .WrkYear = MyUtils.CnvSng(TxtYear.Text)
      .WrkType = TxtType.Text
      .Show()
    End With

    TxtList.Text = ""
    TxtType.Text = ""
    TxtYear.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub

  Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    Dim WrkBarCode As String

    If Asc(e.KeyChar) = Keys.Return Then
      WrkBarCode = TxtList.Text
      'Check for Bar code entry
      If Len(WrkBarCode) > 6 Then
        TxtList.Text = Mid(WrkBarCode, 1, 7)
        TxtType.Text = Mid(WrkBarCode, 7, 1)
        TxtYear.Text = Mid(WrkBarCode, 8, 4)
        ShowFastPath()
      Else 'Bar Code
        MyUtils.KeyEnter_isTab(Me, e)
      End If
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

  End Sub
End Class






