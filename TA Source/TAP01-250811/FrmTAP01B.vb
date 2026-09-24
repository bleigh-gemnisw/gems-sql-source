Imports System.Data
Public Class FrmTAP01B
  Inherits System.Windows.Forms.Form
  Dim MyTXDCFRM As TXDCFRM.myData
  Dim MyTXDCPP As TXDCPP.myData
  Dim MyTXDCPPL1 As TXDCPPL1.myData
  Dim MyTXDCPPL2 As TXDCPPL2.MyData
  Dim MyTXMCTL As TXMCTL.MyData
  Friend WithEvents RbOwname As System.Windows.Forms.RadioButton
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnScan As System.Windows.Forms.Button
  Dim ds As DataSet = New DataSet
  Dim WrkReadForward As Boolean
  Dim WrkBlocking As Boolean
  Friend WithEvents RbDBA As System.Windows.Forms.RadioButton
  Const WrkMax As Integer = 100

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP01B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.RbOwname = New System.Windows.Forms.RadioButton()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.RbDBA = New System.Windows.Forms.RadioButton()
    Me.GroupBox2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(377, 9)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(185, 42)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(123, 12)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "&Show"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(18, 19)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 11)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(60, 16)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 20)
    Me.TxtListNo.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 71)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(59, 13)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = " Search for"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(239, 65)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(69, 67)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(164, 20)
    Me.TxtPos.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(295, 65)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 27
    Me.BtnNext.Text = "&Next"
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.AllowUpdateOnBlur = False
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(33, 113)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(493, 343)
    Me.C1DataGrdList.TabIndex = 196
    '
    'RbOwname
    '
    Me.RbOwname.AutoSize = True
    Me.RbOwname.Checked = True
    Me.RbOwname.Location = New System.Drawing.Point(33, 90)
    Me.RbOwname.Name = "RbOwname"
    Me.RbOwname.Size = New System.Drawing.Size(87, 17)
    Me.RbOwname.TabIndex = 197
    Me.RbOwname.TabStop = True
    Me.RbOwname.Text = "Owner Name"
    Me.RbOwname.UseVisualStyleBackColor = True
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(39, 34)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 216
    Me.Label29.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(80, 34)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 217
    Me.TxtYear.TabStop = False
    '
    'BtnScan
    '
    Me.BtnScan.Location = New System.Drawing.Point(354, 65)
    Me.BtnScan.Name = "BtnScan"
    Me.BtnScan.Size = New System.Drawing.Size(53, 24)
    Me.BtnScan.TabIndex = 218
    Me.BtnScan.Text = "Scan"
    '
    'RbDBA
    '
    Me.RbDBA.AutoSize = True
    Me.RbDBA.Location = New System.Drawing.Point(141, 90)
    Me.RbDBA.Name = "RbDBA"
    Me.RbDBA.Size = New System.Drawing.Size(47, 17)
    Me.RbDBA.TabIndex = 220
    Me.RbDBA.Text = "DBA"
    Me.RbDBA.UseVisualStyleBackColor = True
    '
    'FrmTAP01B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(574, 468)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbDBA)
    Me.Controls.Add(Me.BtnScan)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.RbOwname)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTAP01B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAP01B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXDCFRM = New TXDCFRM.MyData(myDBConnect)
    MyTXDCPP = New TXDCPP.MyData(myDBConnect)
    MyTXDCPPL1 = New TXDCPPL1.MyData(myDBConnect)
    MyTXDCPPL2 = New TXDCPPL2.MyData(myDBConnect)
    MyTXMCTL = New TXMCTL.MyData(myDBConnect)
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    MyTXDCFRM.GetOneRecordP(1)
    If Not MyTXDCFRM.RecordNotFound Then
      TxtYear.Text = MyTXDCFRM._CURRYR
    End If
    If MyBookPct = 0 Then
      myTXMCTL.GetOneRecordP(1)
      If Not myTXMCTL.RecordNotFound Then
        With myTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
    End If
    WrkReadForward = True
    Call FormatGrid(True, False, False)
  End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")
    If RbOwname.Checked Then
      ds = MyTXDCPPL1.GetViewOwname(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
    Else
      ds = MyTXDCPPL2.GetViewDBA(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
    End If
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Public Sub ShowGridNext()
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = Trim(C1DataGrdList.Item(I, 2))
    FormatGrid(False, True, False)
  End Sub
  Public Sub ShowGridScan()
    Dim WrkMaxScan As Integer
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")
    WrkMaxScan = 100
    If RbOwname.Checked Then
      ds = MyTXDCPPL1.GetViewOwnameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
    Else
      ds = MyTXDCPPL2.GetViewDBAScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
    End If
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()
  End Sub
  Private Sub FrmTAP01B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid(True, False, False)
    WrkReadForward = True
  End Sub
  Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnScan.Click
    Call FormatGrid(False, False, True)
    WrkReadForward = True
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    ShowGridNext()
  End Sub
  Public Sub ShowFastPath()
    Dim ds2 As DataSet = New DataSet
    Dim WrkListNo As Integer
    Dim WrkYear As Integer

    ErrProv.SetError(TxtYear, "")
    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    If WrkListNo = 0 Or WrkYear = 0 Then Exit Sub

    MyTXDCPP.GetOneRecordP(WrkListNo, WrkYear)
    If Not MyTXDCPP.RecordNotFound Then
      MyFrmTAP01C = New FrmTAP01C
      MyFrmTAP01C.MdiParent = Me.ParentForm
      MyFrmTAP01C.WrkListNo = WrkListNo
      MyFrmTAP01C.WrkYear = WrkYear
      MyFrmTAP01C.Show()
      TxtListNo.Text = ""
      Me.Hide()
    Else
      ErrProv.SetError(TxtYear, "Record not found")
    End If
  End Sub
  Public Sub FormatGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean, ByVal WrkScan As Boolean)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If Not WrkScan Then
      Call ShowGrid()
    Else
      Call ShowGridScan()
    End If

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "List No"
      .Splits(0).DisplayColumns(0).Width = 50
      .Columns(1).Caption = "Year"
      .Splits(0).DisplayColumns(1).Width = 50
      If RbOwname.Checked Then
        If WrkReadForward Then
          .Columns(2).Caption = "Owner Name"
        Else
          .Columns(2).Caption = "Owner Name (Reverse order)"
        End If
        .Splits(0).DisplayColumns(2).Width = 175
        .Columns(3).Caption = "DBA"
        .Splits(0).DisplayColumns(3).Width = 175
      Else
        If WrkReadForward Then
          .Columns(2).Caption = "DBA"
        Else
          .Columns(2).Caption = "DBA (Reverse order)"
        End If
        .Splits(0).DisplayColumns(2).Width = 175
        .Columns(3).Caption = "Owner Name"
        .Splits(0).DisplayColumns(3).Width = 175
      End If
    End With
    If WrkNext Then
      TxtPos.Text = ""
    End If
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTAP01C = New FrmTAP01C
    MyFrmTAP01C.MdiParent = Me.ParentForm
    MyFrmTAP01C.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmTAP01C.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    MyFrmTAP01C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub RbOwname_Click(sender As Object, e As EventArgs) Handles RbOwname.Click
    FormatGrid(True, False, False)
  End Sub
  Private Sub RbDBA_Click(sender As Object, e As EventArgs) Handles RbDBA.Click
    FormatGrid(True, False, False)
  End Sub
End Class






