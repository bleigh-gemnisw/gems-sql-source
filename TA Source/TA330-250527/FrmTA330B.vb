Imports System.Data
Public Class FrmTA330B
  Inherits System.Windows.Forms.Form
  Dim MyLOGRE As LOGRE.myData
  Dim MyLOGPP As LOGPP.myData
  Dim MyLOGMV As LOGMV.myData
  Dim MyLOGSU As LOGSU.myData
  Dim MyLOGREQ As LOGREQ.myData
  Dim MyLOGPPQ As LOGPPQ.myData
  Dim MyLOGMVQ As LOGMVQ.myData
  Dim MyLOGSUQ As LOGSUQ.myData
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents DtPckFrom As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckTo As System.Windows.Forms.DateTimePicker
  Dim WrkTxType As String


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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents RbView1 As System.Windows.Forms.RadioButton
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA330B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.RbView1 = New System.Windows.Forms.RadioButton()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.DtPckFrom = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckTo = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(595, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(172, 48)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(113, 13)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(40, 16)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(67, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSU)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Controls.Add(Me.RbPP)
    Me.GroupBox1.Controls.Add(Me.RbRE)
    Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(464, 32)
    Me.GroupBox1.TabIndex = 25
    Me.GroupBox1.TabStop = False
    '
    'RbSU
    '
    Me.RbSU.Location = New System.Drawing.Point(344, 8)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(112, 16)
    Me.RbSU.TabIndex = 7
    Me.RbSU.Text = "S&upplemental MV"
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(232, 8)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(96, 16)
    Me.RbMV.TabIndex = 6
    Me.RbMV.Text = "&Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(104, 8)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(120, 16)
    Me.RbPP.TabIndex = 5
    Me.RbPP.Text = "P&ersonal Property"
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(8, 8)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(88, 16)
    Me.RbRE.TabIndex = 4
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "&Real Estate"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Position To"
    '
    'RbView1
    '
    Me.RbView1.Checked = True
    Me.RbView1.Location = New System.Drawing.Point(16, 80)
    Me.RbView1.Name = "RbView1"
    Me.RbView1.Size = New System.Drawing.Size(104, 16)
    Me.RbView1.TabIndex = 21
    Me.RbView1.TabStop = True
    Me.RbView1.Text = "&Owner's Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(498, 45)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(86, 48)
    Me.TxtPos.MaxLength = 20
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 19
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(8, 102)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(706, 344)
    Me.C1DataGrdList.TabIndex = 198
    '
    'DtPckFrom
    '
    Me.DtPckFrom.Checked = False
    Me.DtPckFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFrom.Location = New System.Drawing.Point(256, 48)
    Me.DtPckFrom.Name = "DtPckFrom"
    Me.DtPckFrom.ShowCheckBox = True
    Me.DtPckFrom.Size = New System.Drawing.Size(102, 20)
    Me.DtPckFrom.TabIndex = 199
    Me.DtPckFrom.Value = New Date(2014, 9, 26, 0, 0, 0, 0)
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(220, 51)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(30, 13)
    Me.Label3.TabIndex = 200
    Me.Label3.Text = "From"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(364, 51)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(20, 13)
    Me.Label4.TabIndex = 201
    Me.Label4.Text = "To"
    '
    'DtPckTo
    '
    Me.DtPckTo.Checked = False
    Me.DtPckTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTo.Location = New System.Drawing.Point(390, 48)
    Me.DtPckTo.Name = "DtPckTo"
    Me.DtPckTo.ShowCheckBox = True
    Me.DtPckTo.Size = New System.Drawing.Size(102, 20)
    Me.DtPckTo.TabIndex = 202
    Me.DtPckTo.Value = New Date(2014, 9, 26, 0, 0, 0, 0)
    '
    'FrmTA330B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(779, 459)
    Me.ControlBox = False
    Me.Controls.Add(Me.DtPckTo)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckFrom)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.RbView1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTA330B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA330B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyLOGRE = New LOGRE.mydata(MyDBConnect)
    MyLOGPP = New LOGPP.mydata(MyDBConnect)
    MyLOGMV = New LOGMV.mydata(MyDBConnect)
    MyLOGSU = New LOGSU.mydata(MyDBConnect)
    MyLOGREQ = New LOGREQ.mydata(MyDBConnect)
    MyLOGPPQ = New LOGPPQ.mydata(MyDBConnect)
    MyLOGMVQ = New LOGMVQ.mydata(MyDBConnect)
    MyLOGSUQ = New LOGSUQ.mydata(MyDBConnect)

    WrkTxType = "R"
  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
   Call ShowGrid()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "List No"
      .Splits(0).DisplayColumns(0).Width = 50
      .Columns(1).Caption = "Name"
      .Splits(0).DisplayColumns(1).Width = 220
      .Columns(2).Caption = "Address 1"
      .Splits(0).DisplayColumns(2).Width = 220
      .Columns(3).Caption = "Comment"
      .Splits(0).DisplayColumns(3).Width = 100
      .Columns(4).Caption = "Chg Date"
      .Splits(0).DisplayColumns(4).Width = 70
    End With

  End Sub
  Public Sub ShowGrid()
    Dim ds2 As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkFrom As Integer
    Dim WrkTo As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "name >= " & MyUtils.Quo(TxtPos.Text)
    If DtPckFrom.Checked Then
      WrkFrom = MyUtils.SetDBDate(DtPckFrom.Value)
      WrkQry = WrkQry & WrkAnd & "logdte >=" & WrkFrom
    End If
    If DtPckTo.Checked Then
      WrkTo = MyUtils.SetDBDate(DtPckTo.Value)
      WrkQry = WrkQry & WrkAnd & "logdte <=" & WrkTo
    End If
    WrkSort = "NAME"

    Select Case WrkTxType
    Case "M"
      ds2 = MyLOGMVQ.GetQryView(WrkSort, WrkQry, 500)
    Case "P"
      ds2 = MyLOGPPQ.GetQryView(WrkSort, WrkQry, 500)
    Case "R"
      ds2 = MyLOGREQ.GetQryView(WrkSort, WrkQry, 500)
    Case "S"
      ds2 = MyLOGSUQ.GetQryView(WrkSort, WrkQry, 500)
    End Select
    C1DataGrdList.DataSource = ds2.Tables(0)
    C1DataGrdList.Refresh()

    Select Case WrkTxType
    Case "M"
      MyLOGMVQ.CloseFile()
    Case "P"
      MyLOGPPQ.CloseFile()
    Case "R"
      MyLOGREQ.CloseFile()
    Case "S"
      MyLOGSUQ.CloseFile()
    End Select

  End Sub
  Private Sub FrmTA330B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA330.SbpScreen.Text = "TA330B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    WrkTxType = "R"
    FormatGrid()
  End Sub
  Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
    WrkTxType = "P"
    FormatGrid()
  End Sub
  Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click
    WrkTxType = "M"
    FormatGrid()
  End Sub
  Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
    WrkTxType = "S"
    FormatGrid()
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Dim WrkListNo As Integer
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmLOG = New FrmLOG
    MyFrmLOG.MdiParent = Me.ParentForm
    MyFrmLOG.WrkListNo = WrkListNo
    MyFrmLOG.WrkType = WrkTxType
    Select Case WrkTxType
    Case "R"
      MyFrmLOG.ds = MyLOGRE.GetAllList(WrkListno)
    Case "P"
      MyFrmLOG.ds = MyLOGPP.GetAllList(WrkListno)
    Case "M"
      MyFrmLOG.ds = MyLOGMV.GetAllList(WrkListno)
    Case "S"
      MyFrmLOG.ds = MyLOGSU.GetAllList(WrkListno)
    End Select
    MyFrmLOG.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    ShowFastPath()
    Exit Sub
  End If

  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub ShowFastPath()
    Dim WrkListno As Integer
    If TxtListNo.Text = "" Then Exit Sub

    WrkListno = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmLOG = New FrmLOG
    MyFrmLOG.MdiParent = Me.ParentForm
    MyFrmLOG.WrkListNo = WrkListno
    MyFrmLOG.WrkType = WrkTxType
    Select Case WrkTxType
    Case "R"
      MyFrmLOG.ds = MyLOGRE.GetAllList(WrkListno)
    Case "P"
      MyFrmLOG.ds = MyLOGPP.GetAllList(WrkListno)
    Case "M"
      MyFrmLOG.ds = MyLOGMV.GetAllList(WrkListno)
    Case "S"
      MyFrmLOG.ds = MyLOGSU.GetAllList(WrkListno)
    End Select
    MyFrmLOG.Show()
    TxtListNo.Text = ""
    Me.Hide()

End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
  If Asc(e.KeyChar) = Keys.Return Then
    Call FormatGrid()
  End If
  End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class






