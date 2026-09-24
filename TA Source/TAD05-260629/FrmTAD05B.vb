Imports System.Data
Public Class FrmTAD05B
  Inherits System.Windows.Forms.Form
  Dim MyTXREAA As TXREAA.myData
  Dim MyTXREAA1 As TXREAAL1.myData
  Dim MyTXREAA2 As TXREAAL2.myData
  Dim MyTXREAA5 As TXREAAL5.myData
  Dim MyTXREAAA As TXREAALA.myData
  Dim MyTXPPRAL1 As TXPPRAL1.myData
  Dim MyTXPPRAL2 As TXPPRAL2.myData
  Dim MyTXPPRAL4 As TXPPRAL4.myData
  Dim MyTXMVAL2 As TXMVAL2.myData
  Dim MyTXMVAL3 As TXMVAL3.myData
  Dim MyTXMVAL6 As TXMVAL6.myData
  Dim MyTXMVAL7 As TXMVAL7.myData
  Dim MyTXMVALS As TXMVALS.myData
  Dim MyTXSUPAL2 As TXSUPAL2.myData
  Dim MyTXSUPAL4 As TXSUPAL4.myData
  Dim MyTXSUPAL6 As TXSUPAL6.myData
  Dim MyTXSUPALS As TXSUPALS.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Dim WrkTxType As String
  Dim WrkReadForward As Boolean
  Dim WrkBlocking As Boolean
  Dim WrkListNo As Integer
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents BtnScan As Button
  Friend WithEvents CboSort As ComboBox
  Friend WithEvents DtPckDOB As DateTimePicker
  Friend WithEvents BtnNext As Button
  Friend WithEvents BtnFind As Button
  Friend WithEvents TxtPos As TextBox
  Friend WithEvents TxtPosNo As TextBox
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents RbSU As RadioButton
  Friend WithEvents RbMV As RadioButton
  Friend WithEvents RbPP As RadioButton
  Friend WithEvents RbRE As RadioButton
  Const WrkMax As Integer = 20

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAD05B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.GroupBox2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(594, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(173, 48)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(101, 13)
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
    Me.TxtListNo.Size = New System.Drawing.Size(55, 20)
    Me.TxtListNo.TabIndex = 1
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
    Me.C1DataGrdList.Size = New System.Drawing.Size(759, 344)
    Me.C1DataGrdList.TabIndex = 198
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(25, 36)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 219
    Me.TxtYear.TabStop = False
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(25, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 218
    Me.Label29.Text = "Year"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.BtnScan)
    Me.GroupBox3.Controls.Add(Me.CboSort)
    Me.GroupBox3.Controls.Add(Me.DtPckDOB)
    Me.GroupBox3.Controls.Add(Me.BtnNext)
    Me.GroupBox3.Controls.Add(Me.BtnFind)
    Me.GroupBox3.Controls.Add(Me.TxtPos)
    Me.GroupBox3.Controls.Add(Me.TxtPosNo)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(80, 44)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(460, 52)
    Me.GroupBox3.TabIndex = 221
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort By"
    '
    'BtnScan
    '
    Me.BtnScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnScan.Location = New System.Drawing.Point(385, 15)
    Me.BtnScan.Name = "BtnScan"
    Me.BtnScan.Size = New System.Drawing.Size(53, 24)
    Me.BtnScan.TabIndex = 197
    Me.BtnScan.Text = "S&can"
    '
    'CboSort
    '
    Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboSort.FormattingEnabled = True
    Me.CboSort.Location = New System.Drawing.Point(6, 14)
    Me.CboSort.Name = "CboSort"
    Me.CboSort.Size = New System.Drawing.Size(95, 21)
    Me.CboSort.TabIndex = 0
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(179, 15)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 3
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(331, 15)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 5
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "&Next"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(283, 15)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(44, 24)
    Me.BtnFind.TabIndex = 4
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(147, 15)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 2
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(107, 15)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtPosNo.TabIndex = 1
    Me.TxtPosNo.Visible = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbSU)
    Me.GroupBox1.Controls.Add(Me.RbMV)
    Me.GroupBox1.Controls.Add(Me.RbPP)
    Me.GroupBox1.Controls.Add(Me.RbRE)
    Me.GroupBox1.Location = New System.Drawing.Point(76, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(464, 32)
    Me.GroupBox1.TabIndex = 220
    Me.GroupBox1.TabStop = False
    '
    'RbSU
    '
    Me.RbSU.Location = New System.Drawing.Point(344, 8)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(112, 18)
    Me.RbSU.TabIndex = 7
    Me.RbSU.Text = "&Supplemental MV"
    '
    'RbMV
    '
    Me.RbMV.Location = New System.Drawing.Point(232, 8)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(96, 18)
    Me.RbMV.TabIndex = 6
    Me.RbMV.Text = "&Motor Vehicle"
    '
    'RbPP
    '
    Me.RbPP.Location = New System.Drawing.Point(104, 8)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(120, 18)
    Me.RbPP.TabIndex = 5
    Me.RbPP.Text = "&Personal Property"
    '
    'RbRE
    '
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(8, 8)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(88, 18)
    Me.RbRE.TabIndex = 4
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "&Real Estate"
    '
    'FrmTAD05B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(779, 459)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.GroupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTAD05B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD05B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkCheckYear As Integer
    Dim WrkIsPosted As Boolean

    MyTXREAA = New TXREAA.MyData(myDBConnect)
    MyTXREAA1 = New TXREAAL1.MyData(myDBConnect)
    MyTXREAA2 = New TXREAAL2.MyData(myDBConnect)
    MyTXREAA5 = New TXREAAL5.MyData(myDBConnect)
    MyTXREAAA = New TXREAALA.MyData(myDBConnect)
    MyTXPPRAL1 = New TXPPRAL1.MyData(myDBConnect)
    MyTXPPRAL2 = New TXPPRAL2.MyData(myDBConnect)
    MyTXPPRAL4 = New TXPPRAL4.MyData(myDBConnect)
    MyTXMVAL2 = New TXMVAL2.MyData(myDBConnect)
    MyTXMVAL3 = New TXMVAL3.MyData(myDBConnect)
    MyTXMVAL6 = New TXMVAL6.MyData(myDBConnect)
    MyTXMVAL7 = New TXMVAL7.MyData(myDBConnect)
    MyTXMVALS = New TXMVALS.MyData(myDBConnect)
    MyTXSUPAL2 = New TXSUPAL2.MyData(myDBConnect)
    MyTXSUPAL4 = New TXSUPAL4.MyData(myDBConnect)
    MyTXSUPAL6 = New TXSUPAL6.MyData(myDBConnect)
    MyTXSUPALS = New TXSUPALS.MyData(myDBConnect)

    WrkCheckYear = Date.Now.Year - 1
    WrkIsPosted = MyTXREAA.GetIsPosted(WrkCheckYear)
    If WrkIsPosted Then
      TxtYear.Text = WrkCheckYear
    Else
      WrkCheckYear = Date.Now.Year - 2
      WrkIsPosted = MyTXREAA.GetIsPosted(WrkCheckYear)
      If WrkIsPosted Then
        TxtYear.Text = WrkCheckYear
      End If
    End If

    DtPckDOB.Location = TxtPos.Location
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    WrkTxType = "R"
    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Location")
    CboSort.Items.Add("Map")
    CboSort.SelectedItem = "Owner's Name"
    WrkReadForward = True
    Call FormatGrid(True, False, False)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkListNo = 0
    Call FormatGrid(True, False, False)
    WrkReadForward = True
  End Sub
  Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnScan.Click
    Call FormatGrid(False, True, True)
    WrkReadForward = True
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    ShowGridNext()
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
      .Splits(0).DisplayColumns(0).Width = 65
    End With

    If RbRE.Checked Then
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name"
          GridNameLoc(WrkReadForward)
        Case "Second Name"
          GridSnameLoc(WrkReadForward)
        Case "Location"
          GridLocNameRE(WrkReadForward)
        Case "Map"
          GridMap(WrkReadForward)
      End Select
    End If
    If RbPP.Checked Then
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name"
          GridNameLoc(WrkReadForward)
        Case "Second Name"
          GridSnameLoc(WrkReadForward)
        Case "Location"
          GridLocNamePP(WrkReadForward)
      End Select
    End If
    If RbMV.Checked Then
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name", "DOB"
          GridNameMV(WrkReadForward)
        Case "Second Name"
          GridSNameMV(WrkReadForward)
        Case "Location"
          GridLocNameMV(WrkReadForward)
        Case "Reg No"
          GridRegno(WrkReadForward)
        Case "Vin No"
          GridVinno(WrkReadForward)
      End Select
    End If
    If RbSU.Checked Then
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name", "DOB"
          GridNameMV(WrkReadForward)
        Case "Second Name"
          GridSNameMV(WrkReadForward)
        Case "Reg No"
          GridRegno(WrkReadForward)
        Case "Vin No"
          GridVinno(WrkReadForward)
      End Select
    End If
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    Dim WrkPosNo As String
    Dim WrkDBDate As Integer

    WrkPosNo = MyUtils.JustifyRight(TxtPosNo.Text, 7)
    WrkPos = Replace(TxtPos.Text, "'", "''")
    Select Case WrkTxType
      Case "M"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXMVAL3.GetViewbyName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXMVALS.GetViewbySName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXMVAL7.GetViewbyLoc(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkPosNo, WrkListNo, WrkMax, WrkBlocking)
          Case "DOB"
            If DtPckDOB.Value.Date <> Date.Today Then
              WrkDBDate = MyUtils.SetDBDate(DtPckDOB.Value)
              ds = MyTXMVAL3.GetViewDOB(MyUtils.CnvSng(TxtYear.Text), WrkDBDate)
            Else
              ds.Clear()
            End If
          Case "Reg No"
            ds = MyTXMVAL6.GetViewbyRegNo(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
          Case "Vin No"
            ds = MyTXMVAL2.GetViewbyVIN(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
        End Select
      Case "P"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXPPRAL2.GetViewbyName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXPPRAL4.GetViewbySName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXPPRAL1.GetViewbyLoc(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkPosNo, WrkListNo, WrkMax, WrkBlocking)
        End Select
      Case "R"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXREAA2.GetViewbyName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXREAAA.GetViewbySName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXREAA1.GetViewbyLoc(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkPosNo, WrkListNo, WrkMax, WrkBlocking)
          Case "Map"
            ds = MyTXREAA5.GetViewbyMap(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
        End Select
      Case "S"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXSUPAL2.GetViewbyName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXSUPALS.GetViewbySName(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkListNo, WrkMax, WrkBlocking)
          Case "DOB"
            If DtPckDOB.Value.Date <> Date.Today Then
              WrkDBDate = MyUtils.SetDBDate(DtPckDOB.Value)
              ds = MyTXSUPAL2.GetViewDOB(MyUtils.CnvSng(TxtYear.Text), WrkDBDate)
            Else
              ds.Clear()
            End If
          Case "Reg No"
            ds = MyTXSUPAL6.GetViewbyRegNo(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
          Case "Vin No"
            ds = MyTXSUPAL4.GetViewbyVIN(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMax, WrkBlocking)
        End Select
    End Select
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Public Sub ShowGridNext()
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = Trim(C1DataGrdList.Item(I, 1))
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 2))
    Else
      TxtPos.Text = Trim(C1DataGrdList.Item(I, 1))
    End If
    WrkListNo = C1DataGrdList.Item(I, 0)
    FormatGrid(False, True, False)
  End Sub
  Public Sub ShowGridScan()
    Dim WrkMaxScan As Integer
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")

    WrkMaxScan = 100
    Select Case WrkTxType
      Case "M"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXMVAL3.GetViewbyNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Second Name"
            ds = MyTXMVALS.GetViewbySNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Location"
            'ds = MyTXMVAL7.GetViewbyLoc(MyUtils.CnvSng(TxtYear.Text), WrkPos, TxtPosNo.Text, WrkMaxScan, WrkBlocking)
          Case "Reg No"
            ds = MyTXMVAL6.GetViewbyRegNoScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Vin No"
            ds = MyTXMVAL2.GetViewbyVINScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
        End Select
      Case "P"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXPPRAL2.GetViewbyNamescan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
          Case "Second Name"
            ds = MyTXPPRAL4.GetViewbySNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
          Case "Location"
            ds = MyTXPPRAL1.GetViewbyLocScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, TxtPosNo.Text, WrkMaxScan)
        End Select
      Case "R"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXREAA2.GetViewbyNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
          Case "Second Name"
            ds = MyTXREAAA.GetViewbySNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan)
          Case "Location"
            ds = MyTXREAA1.GetViewbyLocScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, TxtPosNo.Text, WrkMaxScan)
        End Select
      Case "S"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXSUPAL2.GetViewbyNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Second Name"
            ds = MyTXSUPALS.GetViewbySNameScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Reg No"
            ds = MyTXSUPAL6.GetViewbyRegNoScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
          Case "Vin No"
            ds = MyTXSUPAL4.GetViewbyVINScan(MyUtils.CnvSng(TxtYear.Text), WrkPos, WrkMaxScan, WrkBlocking)
        End Select
    End Select
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmTAD05B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD05.SbpScreen.Text = "TAD05B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub GridNameLoc(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Owner Name"
      Else
        .Columns(1).Caption = "Owner Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 240
      .Columns(2).Caption = "Loc No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(3).Caption = "Location"
      .Splits(0).DisplayColumns(3).Width = 150
      If RbRE.Checked Then
        .Columns(4).Caption = "Unit#"
        .Splits(0).DisplayColumns(4).Width = 50
      Else
        .Columns(4).Caption = "Second Name"
        .Splits(0).DisplayColumns(4).Width = 230
      End If
    End With

  End Sub
  Private Sub GridNameMV(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Owner Name"
      Else
        .Columns(1).Caption = "Owner Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 250
      .Columns(2).Caption = "Reg No"
      .Splits(0).DisplayColumns(2).Width = 60
      .Columns(3).Caption = "Make"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Year"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 80
    End With

  End Sub
  Private Sub GridLocNameRE(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc No"
      .Splits(0).DisplayColumns(1).Width = 50
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      If WrkForward Then
        .Columns(2).Caption = "Location"
      Else
        .Columns(2).Caption = "Location (Reverse order)"
      End If
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "Unit#"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Owner Name"
      .Splits(0).DisplayColumns(4).Width = 250
    End With

  End Sub
  Private Sub GridLocNamePP(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc No"
      .Splits(0).DisplayColumns(1).Width = 50
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      If WrkForward Then
        .Columns(2).Caption = "Location"
      Else
        .Columns(2).Caption = "Location (Reverse order)"
      End If
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "Owner Name"
      .Splits(0).DisplayColumns(3).Width = 240
      .Columns(4).Caption = "Second Name"
      .Splits(0).DisplayColumns(4).Width = 230
    End With

  End Sub
  Private Sub GridLocNameMV(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc No"
      .Splits(0).DisplayColumns(1).Width = 50
      .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      If WrkForward Then
        .Columns(2).Caption = "Location"
      Else
        .Columns(2).Caption = "Location (Reverse order)"
      End If
      .Splits(0).DisplayColumns(2).Width = 150
      .Columns(3).Caption = "Reg No"
      .Splits(0).DisplayColumns(3).Width = 60
      .Columns(5).Caption = "Make"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 50
      .Columns(6).Caption = "Model"
      .Splits(0).DisplayColumns(6).Width = 80
      .Columns(7).Caption = "Name"
      .Splits(0).DisplayColumns(7).Width = 200
    End With

  End Sub
  Private Sub GridSnameLoc(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Second Name"
      Else
        .Columns(1).Caption = "Second Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 200
      .Columns(2).Caption = "Loc No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(3).Caption = "Location"
      .Splits(0).DisplayColumns(3).Width = 150
      If RbRE.Checked Then
        .Columns(4).Caption = "Unit#"
        .Splits(0).DisplayColumns(4).Width = 50
        .Columns(5).Caption = "Name"
        .Splits(0).DisplayColumns(5).Width = 200
      Else
        .Columns(4).Caption = "Name"
        .Splits(0).DisplayColumns(4).Width = 200
      End If
    End With

  End Sub
  Private Sub GridMap(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Map"
      Else
        .Columns(1).Caption = "Map (Reverse order)"
      End If
      .Columns(2).Caption = "Owner Name"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "Loc No"
      .Splits(0).DisplayColumns(3).Width = 50
      .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(4).Caption = "Location"
      .Splits(0).DisplayColumns(4).Width = 150
      .Columns(5).Caption = "Unit#"
      .Splits(0).DisplayColumns(5).Width = 50
    End With

  End Sub
  Private Sub GridRegno(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Reg No"
      Else
        .Columns(1).Caption = "Reg No (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Make"
      .Splits(0).DisplayColumns(2).Width = 50
      .Columns(3).Caption = "Year"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Model"
      .Splits(0).DisplayColumns(4).Width = 80
      .Splits(0).DisplayColumns(5).Visible = False
      .Columns(6).Caption = "Owner Name"
      .Splits(0).DisplayColumns(6).Width = 250
    End With

  End Sub
  Private Sub GridSNameMV(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Second Name"
      Else
        .Columns(1).Caption = "Second Name (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 250
      .Columns(2).Caption = "Reg No"
      .Splits(0).DisplayColumns(2).Width = 60
      .Columns(3).Caption = "Make"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Year"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 80
    End With

  End Sub
  Private Sub GridVinno(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      If WrkForward Then
        .Columns(1).Caption = "Vin No"
      Else
        .Columns(1).Caption = "Vin No (Reverse order)"
      End If
      .Splits(0).DisplayColumns(1).Width = 150
      .Columns(2).Caption = "Reg No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Columns(3).Caption = "Make"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Year"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 80
      .Columns(6).Caption = "Owner Name"
      .Splits(0).DisplayColumns(6).Width = 250
    End With

  End Sub

  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged

    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name", "Reg No", "Vin No"
        TxtPosNo.Visible = False
        FormatGrid(True, False, False)
        TxtPos.Visible = True
        DtPckDOB.Visible = False
        BtnNext.Enabled = True
        BtnScan.Enabled = True
      Case "DOB"
        TxtPosNo.Visible = False
        TxtPos.Visible = False
        DtPckDOB.Visible = True
        FormatGrid(True, False, False)
        DtPckDOB.Focus()
        BtnNext.Enabled = False
        BtnScan.Enabled = False
      Case "Location"
        TxtPosNo.Visible = True
        TxtPos.Visible = True
        DtPckDOB.Visible = False
        FormatGrid(True, False, False)
        TxtPosNo.Focus()
        BtnNext.Enabled = True
        BtnScan.Enabled = True
      Case "Map"
        TxtPosNo.Visible = False
        FormatGrid(True, False, False)
        TxtPos.Visible = True
        DtPckDOB.Visible = False
        BtnNext.Enabled = True
        BtnScan.Enabled = False
    End Select
  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    If WrkTxType <> "R" Then
      Dim WrkSaveSel As String
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name", "Second Name", "Location"
          WrkSaveSel = CboSort.SelectedItem.ToString
        Case Else
          WrkSaveSel = "Owner's Name"
      End Select
      WrkReadForward = True
      WrkTxType = "R"
      CboSort.Items.Clear()
      CboSort.Items.Add("Owner's Name")
      CboSort.Items.Add("Second Name")
      CboSort.Items.Add("Location")
      CboSort.Items.Add("Map")
      CboSort.SelectedItem = WrkSaveSel
      DtPckDOB.Visible = False
      BtnNext.Enabled = True
      BtnScan.Enabled = True
      FormatGrid(True, False, False)
    End If

  End Sub
  Private Sub RbPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPP.Click
    Dim WrkSaveSel As String
    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name", "Location"
        WrkSaveSel = CboSort.SelectedItem.ToString
      Case Else
        WrkSaveSel = "Owner's Name"
    End Select
    WrkReadForward = True
    WrkTxType = "P"
    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Location")
    CboSort.SelectedItem = WrkSaveSel
    DtPckDOB.Visible = False
    BtnNext.Enabled = True
    BtnScan.Enabled = True
    FormatGrid(True, False, False)
  End Sub
  Private Sub RbMV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbMV.Click

    Dim WrkSaveSel As String
    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name", "Location", "DOB", "Reg No", "Vin No"
        WrkSaveSel = CboSort.SelectedItem.ToString
      Case Else
        WrkSaveSel = "Owner's Name"
    End Select
    WrkReadForward = True
    WrkTxType = "M"
    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Location")
    CboSort.Items.Add("DOB")
    CboSort.Items.Add("Reg No")
    CboSort.Items.Add("Vin No")
    CboSort.SelectedItem = WrkSaveSel
    FormatGrid(True, False, False)
  End Sub
  Private Sub RbSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbSU.Click
    Dim WrkSaveSel As String
    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name", "DOB", "Reg No", "Vin No"
        WrkSaveSel = CboSort.SelectedItem.ToString
      Case Else
        WrkSaveSel = "Owner's Name"
    End Select
    WrkReadForward = True
    WrkTxType = "S"
    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("DOB")
    CboSort.Items.Add("Reg No")
    CboSort.Items.Add("Vin No")
    CboSort.SelectedItem = WrkSaveSel
    FormatGrid(True, False, False)
  End Sub
  Private Sub C1DataGrdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Select Case WrkTxType
      Case Is = "M"
        MyFrmTAD05MV = New FrmTAD05MV
        MyFrmTAD05MV.MdiParent = Me.ParentForm
        MyFrmTAD05MV.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTAD05MV.WrkYear = MyUtils.CnvSng(TxtYear.Text)
        MyFrmTAD05MV.WrkFastPath = False
        MyFrmTAD05MV.Show()
        Me.Hide()
      Case Is = "P"
        MyFrmTAD05PP = New FrmTAD05PP
        MyFrmTAD05PP.MdiParent = Me.ParentForm
        MyFrmTAD05PP.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTAD05PP.WrkYear = MyUtils.CnvSng(TxtYear.Text)
        MyFrmTAD05PP.WrkFastPath = False
        MyFrmTAD05PP.Show()
        Me.Hide()
      Case Is = "R"
        MyFrmTAD05RE = New FrmTAD05RE
        MyFrmTAD05RE.MdiParent = Me.ParentForm
        MyFrmTAD05RE.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTAD05RE.WrkYear = MyUtils.CnvSng(TxtYear.Text)
        MyFrmTAD05RE.WrkFastPath = False
        MyFrmTAD05RE.Show()
        Me.Hide()
      Case Is = "S"
        MyFrmTAD05SU = New FrmTAD05SU
        MyFrmTAD05SU.MdiParent = Me.ParentForm
        MyFrmTAD05SU.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTAD05SU.WrkYear = MyUtils.CnvSng(TxtYear.Text)
        MyFrmTAD05SU.WrkFastPath = False
        MyFrmTAD05SU.Show()
        Me.Hide()
    End Select
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub ShowFastPath()
    If TxtListNo.Text = "" Then Exit Sub

    If RbRE.Checked Then
      MyFrmTAD05RE = New FrmTAD05RE
      MyFrmTAD05RE.MdiParent = Me.ParentForm
      MyFrmTAD05RE.WrkListNo = TxtListNo.Text
      MyFrmTAD05RE.WrkYear = MyUtils.CnvSng(TxtYear.Text)
      MyFrmTAD05RE.WrkFastPath = True
      MyFrmTAD05RE.Show()
    End If
    If RbPP.Checked Then
      MyFrmTAD05PP = New FrmTAD05PP
      MyFrmTAD05PP.MdiParent = Me.ParentForm
      MyFrmTAD05PP.WrkListNo = TxtListNo.Text
      MyFrmTAD05PP.WrkYear = MyUtils.CnvSng(TxtYear.Text)
      MyFrmTAD05PP.WrkFastPath = True
      MyFrmTAD05PP.Show()
    End If
    If RbMV.Checked Then
      MyFrmTAD05MV = New FrmTAD05MV
      MyFrmTAD05MV.MdiParent = Me.ParentForm
      MyFrmTAD05MV.WrkListNo = TxtListNo.Text
      MyFrmTAD05MV.WrkYear = MyUtils.CnvSng(TxtYear.Text)
      MyFrmTAD05MV.WrkFastPath = True
      MyFrmTAD05MV.Show()
    End If
    If RbSU.Checked Then
      MyFrmTAD05SU = New FrmTAD05SU
      MyFrmTAD05SU.MdiParent = Me.ParentForm
      MyFrmTAD05SU.WrkListNo = TxtListNo.Text
      MyFrmTAD05SU.WrkYear = MyUtils.CnvSng(TxtYear.Text)
      MyFrmTAD05SU.WrkFastPath = True
      MyFrmTAD05SU.Show()
    End If
    TxtListNo.Text = ""
    Me.Hide()

  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      Call FormatGrid(True, False, False)
    End If
  End Sub

End Class






