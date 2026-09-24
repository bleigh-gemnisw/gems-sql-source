Imports System.Data
Public Class FrmTA001B
  Inherits System.Windows.Forms.Form
  Dim MyTXREALL1 As TXREALL1.MyData
  Dim MyTXREALL2 As TXREALL2.MyData
  Dim MyTXREALL5 As TXREALL5.MyData
  Dim MyTXREALLA As TXREALLA.MyData
  Dim MyTXPPRPL1 As TXPPRPL1.MyData
  Dim MyTXPPRPL2 As TXPPRPL2.MyData
  Dim MyTXPPRPL4 As TXPPRPL4.MyData
  Dim MyTXMVDL2 As TXMVDL2.MyData
  Dim MyTXMVDL3 As TXMVDL3.MyData
  Dim MyTXMVDL6 As TXMVDL6.MyData
  Dim MyTXMVDL7 As TXMVDL7.MyData
  Dim MyTXMVDLS As TXMVDLS.MyData
  Dim MyTXSUPPL2 As TXSUPPL2.MyData
  Dim MyTXSUPPL4 As TXSUPPL4.MyData
  Dim MyTXSUPPL6 As TXSUPPL6.MyData
  Dim MyTXSUPPLS As TXSUPPLS.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Dim WrkTxType As String
  Dim WrkReadForward As Boolean
  Dim WrkBlocking As Boolean
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnScan As System.Windows.Forms.Button
  Friend WithEvents CboSort As System.Windows.Forms.ComboBox
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTA001B))
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(598, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(169, 48)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(110, 13)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 19)
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
    Me.TxtListNo.Size = New System.Drawing.Size(64, 20)
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
    Me.GroupBox3.Location = New System.Drawing.Point(12, 44)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(491, 52)
    Me.GroupBox3.TabIndex = 199
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort By"
    '
    'BtnScan
    '
    Me.BtnScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnScan.Location = New System.Drawing.Point(428, 15)
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
    Me.DtPckDOB.Location = New System.Drawing.Point(224, 15)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 3
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(374, 15)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 5
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "&Next"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(326, 15)
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
    Me.TxtPos.Size = New System.Drawing.Size(173, 20)
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
    'FrmTA001B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(779, 459)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.Name = "FrmTA001B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTA001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXREALL1 = New TXREALL1.MyData(myDBConnect)
    MyTXREALL2 = New TXREALL2.MyData(myDBConnect)
    MyTXREALL5 = New TXREALL5.MyData(myDBConnect)
    MyTXREALLA = New TXREALLA.MyData(myDBConnect)
    MyTXPPRPL1 = New TXPPRPL1.MyData(myDBConnect)
    MyTXPPRPL2 = New TXPPRPL2.MyData(myDBConnect)
    MyTXPPRPL4 = New TXPPRPL4.MyData(myDBConnect)
    MyTXMVDL2 = New TXMVDL2.MyData(myDBConnect)
    MyTXMVDL3 = New TXMVDL3.MyData(myDBConnect)
    MyTXMVDL6 = New TXMVDL6.MyData(myDBConnect)
    MyTXMVDL7 = New TXMVDL7.MyData(myDBConnect)
    MyTXMVDLS = New TXMVDLS.MyData(myDBConnect)
    MyTXSUPPL2 = New TXSUPPL2.MyData(myDBConnect)
    MyTXSUPPL4 = New TXSUPPL4.MyData(myDBConnect)
    MyTXSUPPL6 = New TXSUPPL6.MyData(myDBConnect)
    MyTXSUPPLS = New TXSUPPLS.MyData(myDBConnect)

    DtPckDOB.Location = TxtPos.Location
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    WrkTxType = "R"
    WrkReadForward = True
    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.Items.Add("Location")
    CboSort.Items.Add("Map")
    CboSort.SelectedItem = "Owner's Name"
    Call FormatGrid(True, False, False)
  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
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
    Dim WrkListno As Integer
    WrkListno = 0
    If C1DataGrdList.VisibleRows > 0 Then
      WrkListno = C1DataGrdList.Item(C1DataGrdList.VisibleRows - 1, 0)
    End If
    If Not WrkScan Then
      Call ShowGrid()
    Else
      Call ShowGridScan(WrkListno)
    End If

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "List No"
      .Splits(0).DisplayColumns(0).Width = 45
    End With

    If RbRE.Checked Then
      Select Case CboSort.SelectedItem.ToString
        Case "Owner's Name"
          GridNameLoc(WrkReadForward)
        Case "Second Name"
          GridSnameLoc(WrkReadForward)
        Case "Location"
          GridLocName(WrkReadForward, True)
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
          GridLocName(WrkReadForward, False)
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
    If WrkNext Then
      TxtPosNo.Text = ""
      TxtPos.Text = ""
    End If
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Public Sub ShowGrid(Optional ByVal WrkListNo As Integer = 0)
    Dim WrkPosNo As String
    Dim WrkDBDate As Integer
    Dim WrkPos As String

    WrkPos = TxtPos.Text
    WrkPos = Replace(WrkPos, "'", "''")
    WrkPosNo = MyUtils.JustifyRight(TxtPosNo.Text, 7)
    Select Case WrkTxType
      Case "M"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXMVDL3.GetViewbyName(WrkPos, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXMVDLS.GetViewbySName(WrkPos, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXMVDL7.GetViewbyLoc(WrkPos, WrkPosNo, WrkMax, WrkBlocking)
          Case "DOB"
            If DtPckDOB.Value.Date <> Date.Today Then
              WrkDBDate = MyUtils.SetDBDate(DtPckDOB.Value)
              ds = MyTXMVDL3.GetViewDOB(WrkDBDate, WrkBlocking)
            Else
              ds.Clear()
            End If
          Case "Reg No"
            ds = MyTXMVDL6.GetViewbyRegNo(WrkPos, WrkMax, WrkBlocking)
          Case "Vin No"
            ds = MyTXMVDL2.GetViewbyVIN(WrkPos, WrkMax, WrkBlocking)
        End Select
      Case "P"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXPPRPL2.GetViewbyName(WrkPos, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXPPRPL4.GetViewbySName(WrkPos, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXPPRPL1.GetViewbyLoc(WrkPos, WrkPosNo, WrkMax, WrkBlocking)
        End Select
      Case "R"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            If WrkListNo > 0 Then
              WrkPos = C1DataGrdList.Item(C1DataGrdList.VisibleRows - 1, 1)
            End If
            ds = MyTXREALL2.GetViewbyName(WrkPos, WrkListNo, WrkMax)
          Case "Second Name"
            ds = MyTXREALLA.GetViewbySName(WrkPos, WrkMax, WrkBlocking)
          Case "Location"
            ds = MyTXREALL1.GetViewbyLoc(WrkPos, WrkPosNo, WrkMax, WrkBlocking)
          Case "Map"
            ds = MyTXREALL5.GetViewbyMap(WrkPos, WrkMax, WrkBlocking)
        End Select
      Case "S"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXSUPPL2.GetViewbyName(WrkPos, WrkMax, WrkBlocking)
          Case "Second Name"
            ds = MyTXSUPPLS.GetViewbySName(WrkPos, WrkMax, WrkBlocking)
          Case "DOB"
            If DtPckDOB.Value.Date <> Date.Today Then
              WrkDBDate = MyUtils.SetDBDate(DtPckDOB.Value)
              ds = MyTXSUPPL2.GetViewDOB(WrkDBDate, WrkBlocking)
            Else
              ds.Clear()
            End If
          Case "Reg No"
            ds = MyTXSUPPL6.GetViewbyRegNo(WrkPos, WrkMax, WrkBlocking)
          Case "Vin No"
            ds = MyTXSUPPL4.GetViewbyVIN(WrkPos, WrkMax, WrkBlocking)
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
    FormatGrid(False, True, False)
  End Sub
  Public Sub ShowGridScan(Optional ByVal WrkListNo As Integer = 0)
    Dim WrkMaxScan As Integer
    Dim WrkPos As String

    WrkPos = TxtPos.Text
    WrkPos = Replace(WrkPos, "'", "''")
    WrkMaxScan = 100
    Select Case WrkTxType
      Case "M"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXMVDL3.GetViewbyNameScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Second Name"
            ds = MyTXMVDLS.GetViewbySNameScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Location"
            ds = MyTXMVDL7.GetViewbyLoc(WrkPos, TxtPosNo.Text, WrkMaxScan, WrkBlocking)
          Case "Reg No"
            ds = MyTXMVDL6.GetViewbyRegNoScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Vin No"
            ds = MyTXMVDL2.GetViewbyVINScan(WrkPos, WrkMaxScan, WrkBlocking)
        End Select
      Case "P"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXPPRPL2.GetViewbyNameScan(WrkPos, WrkMaxScan)
          Case "Second Name"
            ds = MyTXPPRPL4.GetViewbySNameScan(WrkPos, WrkMaxScan)
          Case "Location"
            ds = MyTXPPRPL1.GetViewbyLocScan(WrkPos, TxtPosNo.Text, WrkMaxScan)
        End Select
      Case "R"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXREALL2.GetViewbyNameScan(WrkPos, WrkListNo, WrkMaxScan)
          Case "Second Name"
            ds = MyTXREALLA.GetViewbySNameScan(WrkPos, WrkMaxScan)
          Case "Location"
            ds = MyTXREALL1.GetViewbyLocScan(WrkPos, TxtPosNo.Text, WrkMaxScan)
        End Select
      Case "S"
        Select Case CboSort.SelectedItem.ToString
          Case "Owner's Name"
            ds = MyTXSUPPL2.GetViewbyNameScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Second Name"
            ds = MyTXSUPPLS.GetViewbySNameScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Reg No"
            ds = MyTXSUPPL6.GetViewbyRegNoScan(WrkPos, WrkMaxScan, WrkBlocking)
          Case "Vin No"
            ds = MyTXSUPPL4.GetViewbyVINScan(WrkPos, WrkMaxScan, WrkBlocking)
        End Select
    End Select
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
  Private Sub FrmTA001B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "TA001B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub GridNameLoc(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Owner Name"
      .Splits(0).DisplayColumns(1).Width = 220
      .Columns(2).Caption = "Loc No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(3).Caption = "Location"
      .Splits(0).DisplayColumns(3).Width = 150
      If RbRE.Checked Then
        .Columns(4).Caption = "Unit#"
        .Splits(0).DisplayColumns(4).Width = 50
        .Columns(5).Caption = "Map"
        .Splits(0).DisplayColumns(5).Width = 70
        .Columns(6).Caption = "Gross"
        .Splits(0).DisplayColumns(6).Width = 50
      Else
        .Columns(4).Caption = "Second Name"
        .Splits(0).DisplayColumns(4).Width = 200
        .Columns(5).Caption = "Gross"
        .Splits(0).DisplayColumns(5).Width = 50
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
      .Columns(6).Caption = "Value"
      .Splits(0).DisplayColumns(6).Width = 50
    End With

  End Sub
  Private Sub GridLocName(ByVal WrkForward As Boolean, ByVal IsRE As Boolean)
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
      If IsRE Then
        .Columns(3).Caption = "Unit#"
        .Splits(0).DisplayColumns(3).Width = 50
        .Columns(4).Caption = "Owner Name"
        .Splits(0).DisplayColumns(4).Width = 220
        .Columns(5).Caption = "Map"
        .Splits(0).DisplayColumns(5).Width = 70
        .Columns(6).Caption = "Gross"
        .Splits(0).DisplayColumns(6).Width = 50
      Else
        .Columns(3).Caption = "Owner Name"
        .Splits(0).DisplayColumns(3).Width = 220
        .Columns(4).Caption = "Second Name"
        .Splits(0).DisplayColumns(4).Width = 200
        .Columns(5).Caption = "Gross"
        .Splits(0).DisplayColumns(5).Width = 50
      End If
    End With

  End Sub
  Private Sub GridLocNameMV(ByVal WrkForward As Boolean)
    With C1DataGrdList
      .Rebind(True)
      .Columns(1).Caption = "Loc No"
      .Splits(0).DisplayColumns(1).Width = 40
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
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Model"
      .Splits(0).DisplayColumns(6).Width = 70
      .Columns(7).Caption = "Name"
      .Splits(0).DisplayColumns(7).Width = 200
      .Columns(8).Caption = "Value"
      .Splits(0).DisplayColumns(8).Width = 50
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
      .Splits(0).DisplayColumns(1).Width = 180
      .Columns(2).Caption = "Loc No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(3).Caption = "Location"
      .Splits(0).DisplayColumns(3).Width = 150
      If RbRE.Checked Then
        .Columns(4).Caption = "Unit#"
        .Splits(0).DisplayColumns(4).Width = 50
        .Columns(5).Caption = "Name"
        .Splits(0).DisplayColumns(5).Width = 180
        .Columns(6).Caption = "Gross"
        .Splits(0).DisplayColumns(6).Width = 50
      Else
        .Columns(4).Caption = "Name"
        .Splits(0).DisplayColumns(4).Width = 200
        .Columns(5).Caption = "Gross"
        .Splits(0).DisplayColumns(5).Width = 50
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
      .Splits(0).DisplayColumns(1).Width = 70
      .Columns(2).Caption = "Owner Name"
      .Splits(0).DisplayColumns(2).Width = 200
      .Columns(3).Caption = "Loc No"
      .Splits(0).DisplayColumns(3).Width = 50
      .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
      .Columns(4).Caption = "Location"
      .Splits(0).DisplayColumns(4).Width = 150
      .Columns(5).Caption = "Unit#"
      .Splits(0).DisplayColumns(5).Width = 50
      .Columns(6).Caption = "Gross"
      .Splits(0).DisplayColumns(6).Width = 50
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
      .Columns(7).Caption = "Value"
      .Splits(0).DisplayColumns(7).Width = 50
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
      .Columns(6).Caption = "Value"
      .Splits(0).DisplayColumns(6).Width = 50
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
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 80
      .Columns(6).Caption = "Owner Name"
      .Splits(0).DisplayColumns(6).Width = 220
      .Columns(7).Caption = "Value"
      .Splits(0).DisplayColumns(7).Width = 50
    End With

  End Sub
  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged

    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name", "Reg No"
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
      Case "Map", "Vin No"
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
        MyFrmTA001MV = New FrmTA001MV
        MyFrmTA001MV.MdiParent = Me.ParentForm
        MyFrmTA001MV.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTA001MV.WrkFastPath = False
        MyFrmTA001MV.Show()
        Me.Hide()
      Case Is = "P"
        MyFrmTA001PP = New FrmTA001PP
        MyFrmTA001PP.MdiParent = Me.ParentForm
        MyFrmTA001PP.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTA001PP.WrkFastPath = False
        MyFrmTA001PP.Show()
        Me.Hide()
      Case Is = "R"
        MyFrmTA001RE = New FrmTA001RE
        MyFrmTA001RE.MdiParent = Me.ParentForm
        MyFrmTA001RE.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTA001RE.WrkFastPath = False
        MyFrmTA001RE.Show()
        Me.Hide()
      Case Is = "S"
        MyFrmTA001SU = New FrmTA001SU
        MyFrmTA001SU.MdiParent = Me.ParentForm
        MyFrmTA001SU.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmTA001SU.WrkFastPath = False
        MyFrmTA001SU.Show()
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

  Private Sub ShowFastPath()
    If TxtListNo.Text = "" Then Exit Sub

    If RbRE.Checked Then
      MyFrmTA001RE = New FrmTA001RE
      MyFrmTA001RE.MdiParent = Me.ParentForm
      MyFrmTA001RE.WrkListNo = TxtListNo.Text
      MyFrmTA001RE.WrkFastPath = True
      MyFrmTA001RE.Show()
    End If
    If RbPP.Checked Then
      MyFrmTA001PP = New FrmTA001PP
      MyFrmTA001PP.MdiParent = Me.ParentForm
      MyFrmTA001PP.WrkListNo = TxtListNo.Text
      MyFrmTA001PP.WrkFastPath = True
      MyFrmTA001PP.Show()
    End If
    If RbMV.Checked Then
      MyFrmTA001MV = New FrmTA001MV
      MyFrmTA001MV.MdiParent = Me.ParentForm
      MyFrmTA001MV.WrkListNo = TxtListNo.Text
      MyFrmTA001MV.WrkFastPath = True
      MyFrmTA001MV.Show()
    End If
    If RbSU.Checked Then
      MyFrmTA001SU = New FrmTA001SU
      MyFrmTA001SU.MdiParent = Me.ParentForm
      MyFrmTA001SU.WrkListNo = TxtListNo.Text
      MyFrmTA001SU.WrkFastPath = True
      MyFrmTA001SU.Show()
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






