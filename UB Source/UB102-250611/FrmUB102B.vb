Public Class FrmUB102B

  Inherits System.Windows.Forms.Form
  Dim myUTCUST As UTCUST.myData
  Dim myUTCUSTL1 As UTCUSTL1.myData
  Dim myUTCUSTL2 As UTCUSTL2.myData
  Dim ds As DataSet = New DataSet
  Dim WrkListNo As Integer
  Dim WrkLoc As String
  Friend WithEvents BtnScan As System.Windows.Forms.Button
  Dim WrkLocNo As String
  Dim WrkReadForward As Boolean
  Dim WrkBlocking As Boolean
  Const cMax As Integer = 250

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
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
  Friend WithEvents RbName As System.Windows.Forms.RadioButton
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB102B))
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.BtnShow)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.TxtList)
        Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(364, 8)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(180, 68)
        Me.groupBox2.TabIndex = 1
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Fast Path"
        '
        'BtnShow
        '
        Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShow.Location = New System.Drawing.Point(116, 24)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(56, 24)
        Me.BtnShow.TabIndex = 7
        Me.BtnShow.TabStop = False
        Me.BtnShow.Text = "&Show"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(6, 30)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(39, 13)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Acct #"
        '
        'TxtList
        '
        Me.TxtList.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtList.Location = New System.Drawing.Point(45, 28)
        Me.TxtList.MaxLength = 7
        Me.TxtList.Name = "TxtList"
        Me.TxtList.Size = New System.Drawing.Size(63, 22)
        Me.TxtList.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.BtnScan)
        Me.groupBox1.Controls.Add(Me.BtnNext)
        Me.groupBox1.Controls.Add(Me.BtnFind)
        Me.groupBox1.Controls.Add(Me.TxtPos)
        Me.groupBox1.Controls.Add(Me.RbLoc)
        Me.groupBox1.Controls.Add(Me.RbName)
        Me.groupBox1.Controls.Add(Me.TxtPosNo)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(8, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(356, 68)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Sort By"
        '
        'BtnScan
        '
        Me.BtnScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnScan.Location = New System.Drawing.Point(296, 40)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(48, 24)
        Me.BtnScan.TabIndex = 200
        Me.BtnScan.Text = "Scan"
        '
        'BtnNext
        '
        Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.Location = New System.Drawing.Point(296, 10)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(48, 24)
        Me.BtnNext.TabIndex = 3
        Me.BtnNext.TabStop = False
        Me.BtnNext.Text = "Ne&xt"
        '
        'BtnFind
        '
        Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFind.Location = New System.Drawing.Point(248, 10)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(44, 24)
        Me.BtnFind.TabIndex = 2
        Me.BtnFind.TabStop = False
        Me.BtnFind.Text = "&Find"
        '
        'TxtPos
        '
        Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPos.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPos.Location = New System.Drawing.Point(112, 16)
        Me.TxtPos.MaxLength = 25
        Me.TxtPos.Name = "TxtPos"
        Me.TxtPos.Size = New System.Drawing.Size(128, 22)
        Me.TxtPos.TabIndex = 1
        '
        'RbLoc
        '
        Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLoc.Location = New System.Drawing.Point(116, 40)
        Me.RbLoc.Name = "RbLoc"
        Me.RbLoc.Size = New System.Drawing.Size(112, 16)
        Me.RbLoc.TabIndex = 9
        Me.RbLoc.Text = "&Location#/Name"
        '
        'RbName
        '
        Me.RbName.Checked = True
        Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbName.Location = New System.Drawing.Point(8, 40)
        Me.RbName.Name = "RbName"
        Me.RbName.Size = New System.Drawing.Size(104, 16)
        Me.RbName.TabIndex = 8
        Me.RbName.TabStop = True
        Me.RbName.Text = "O&wner's Name"
        '
        'TxtPosNo
        '
        Me.TxtPosNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPosNo.Location = New System.Drawing.Point(72, 16)
        Me.TxtPosNo.MaxLength = 7
        Me.TxtPosNo.Name = "TxtPosNo"
        Me.TxtPosNo.Size = New System.Drawing.Size(40, 22)
        Me.TxtPosNo.TabIndex = 0
        Me.TxtPosNo.Visible = False
        '
        'label1
        '
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(8, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 16)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Position to"
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
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(8, 84)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.Size = New System.Drawing.Size(536, 348)
        Me.C1DataGrdList.TabIndex = 8
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'FrmUB102B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(554, 440)
        Me.Controls.Add(Me.C1DataGrdList)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUB102B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmUB102B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myUTCUST = New UTCUST.MyData(myDBConnect)
        myUTCUSTL1 = New UTCUSTL1.MyData(myDBConnect)
        myUTCUSTL2 = New UTCUSTL2.MyData(myDBConnect)
        WrkLoc = ""
        WrkLocNo = ""
        If MyServer = "SQL" Then
            WrkBlocking = False
        Else
            WrkBlocking = True
        End If
        WrkReadForward = True
        Call FormatGrid(True, False, False)
    End Sub
    Public Sub FormatGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean, ByVal WrkScan As Boolean)
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Not WrkScan Then
            Call ShowGrid()
        Else
            Call ShowGridScan()
        End If
        If RbName.Checked Then
            GridName(WrkReadForward)
        Else
            GridLocName(WrkReadForward)
        End If
    End Sub
    Public Sub ShowGrid()
        Dim WrkPos As String
        Dim WrkPosNo As String
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        WrkPos = Replace(TxtPos.Text, "'", "''")
        If RbName.Checked Then
            ds = myUTCUSTL1.GetViewbyName(WrkPos, WrkLoc, WrkLocNo, cMax, WrkBlocking)
        End If
        If RbLoc.Checked Then
            WrkPosNo = MyUtils.JustifyRight(TxtPosNo.Text, 7)
            ds = myUTCUSTL2.GetViewbyLoc(WrkPos, WrkPosNo, "", cMax, WrkBlocking)
        End If

        C1DataGrdList.DataSource = ds.Tables(0)
        C1DataGrdList.Refresh()
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
    Public Sub ShowGridNext()
        Dim I As Integer
        I = ds.Tables(0).Rows.Count - 1
        If TxtPosNo.Visible Then
            TxtPosNo.Text = Trim(C1DataGrdList.Item(I, 2))
            TxtPos.Text = Trim(C1DataGrdList.Item(I, 3))
        Else
            TxtPos.Text = Trim(C1DataGrdList.Item(I, 1))
        End If
        FormatGrid(False, True, False)
    End Sub
    Public Sub ShowGridScan()
        Dim WrkMaxScan As Integer

        WrkMaxScan = 100
        If RbName.Checked Then
            ds = myUTCUSTL1.GetViewbyNameScan(TxtPos.Text, WrkMaxScan)
        End If
        If RbLoc.Checked Then
            ds = myUTCUSTL2.GetViewbyLocScan(TxtPos.Text, TxtPosNo.Text, WrkMaxScan)
        End If
        C1DataGrdList.DataSource = ds.Tables(0)
        C1DataGrdList.Refresh()

    End Sub
    Private Sub GridName(ByVal WrkForward As Boolean)
        With C1DataGrdList
            .Rebind(True)
            .Columns(0).Caption = "Account"
            .Splits(0).DisplayColumns(0).Width = 70
            If WrkForward Then
                .Columns(1).Caption = "Name"
            Else
                .Columns(1).Caption = "Name (Reverse order)"
            End If
            .Splits(0).DisplayColumns(1).Width = 220
            .Columns(2).Caption = "Loc #"
            .Splits(0).DisplayColumns(2).Width = 50
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            .Columns(3).Caption = "Location"
            .Splits(0).DisplayColumns(3).Width = 150
        End With

    End Sub
    Private Sub GridLocName(ByVal WrkForward As Boolean)
        With C1DataGrdList
            .Rebind(True)
            .Columns(0).Caption = "Account"
            .Splits(0).DisplayColumns(0).Width = 70
            .Columns(1).Caption = "Name"
            .Splits(0).DisplayColumns(1).Width = 220
            .Columns(2).Caption = "Loc #"
            .Splits(0).DisplayColumns(2).Width = 50
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            If WrkForward Then
                .Columns(3).Caption = "Location"
            Else
                .Columns(3).Caption = "Location (Reverse order)"
            End If
            .Splits(0).DisplayColumns(3).Width = 150
        End With

    End Sub
    Private Sub FrmUB102B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        FrmUB102.Close()
    End Sub
    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        ShowFastPath()
    End Sub
    Private Sub RbLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoc.Click
        TxtPosNo.Visible = True
        FormatGrid(True, False, False)
    End Sub
    Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
        TxtPosNo.Visible = False
        FormatGrid(True, False, False)
    End Sub
    Private Sub FrmUB102B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmUB102.SbpScreen.Text = "UB102B"
        MyUtils.CenterForm(Me.ParentForm, Me)
        With MyFrmUB102
            .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
            .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
        End With
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
    Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
        WrkLoc = ""
        WrkLocNo = ""
        MyFrmUB102C = New FrmUB102C

        MyFrmUB102C.AddMode = False

        MyFrmUB102C.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
        MyFrmUB102C.MdiParent = Me.ParentForm
        MyFrmUB102C.Show()
        Me.Hide()
    End Sub
    Private Sub ShowFastPath()
        If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub

        myUTCUST.GetOneRecordP(MyUtils.CnvSng(TxtList.Text))
        If myUTCUST.RecordNotFound Then
            MsgBox("List not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
            Exit Sub
        End If

        With myUTCUST
            TxtPos.Text = Trim(._CUNAM1)
            If RbLoc.Checked Then
                TxtPosNo.Text = Trim(._CULOCNO)
            End If
        End With
        FormatGrid(True, False, False)

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        TxtPos.Text = ""
        TxtPosNo.Text = ""
        TxtList.Focus()
        MyFrmUB102C = New FrmUB102C

        With MyFrmUB102C
            .AddMode = False
            .WrkListNo = TxtList.Text
            .MdiParent = Me.ParentForm
            .Show()
        End With

        TxtList.Text = ""
        Windows.Forms.Cursor.Current = Cursors.Default
        Me.Hide()

    End Sub
    Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
        e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

        If Asc(e.KeyChar) = Keys.Enter Then
            ShowFastPath()
        End If
    End Sub
    Private Sub TxtList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtList.GotFocus
        MyUtils.ShowFocus(Me.ActiveControl)
    End Sub
    Private Sub TxtPosNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosNo.GotFocus
        MyUtils.ShowFocus(Me.ActiveControl)
    End Sub
    Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPos.GotFocus
        MyUtils.ShowFocus(Me.ActiveControl)
    End Sub
    Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            WrkListNo = 0
            FormatGrid(True, False, False)
        End If
    End Sub

    Private Sub C1DataGrdList_Click(sender As Object, e As EventArgs) Handles C1DataGrdList.Click

    End Sub
End Class
