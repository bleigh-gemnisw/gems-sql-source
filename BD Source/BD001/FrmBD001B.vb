Public Class FrmBD001B

  Inherits System.Windows.Forms.Form
  Dim myBDMAST As BDMAST.myData
  Dim myBDMASTL1 As BDMASTL1.myData
  Dim myBDMASTL2 As BDMASTL2.myData
  Dim myBDMASTL3 As BDMASTL3.myData
  Dim myBDMASTL4 As BDMASTL4.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents RbMap As System.Windows.Forms.RadioButton
  'General
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents TxtPermitNo As System.Windows.Forms.TextBox
  Dim WrkFastGrid As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkRecID As Long


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
  Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents RbLoc As System.Windows.Forms.RadioButton
  Friend WithEvents RbName As System.Windows.Forms.RadioButton
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBD001B))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbMap = New System.Windows.Forms.RadioButton()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtPermitNo = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.groupBox1.SuspendLayout()
    Me.groupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.RbMap)
    Me.groupBox1.Controls.Add(Me.BtnNext)
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.RbLoc)
    Me.groupBox1.Controls.Add(Me.RbName)
    Me.groupBox1.Controls.Add(Me.TxtPosNo)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(12, 10)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(376, 52)
    Me.groupBox1.TabIndex = 1
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
    '
    'RbMap
    '
    Me.RbMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMap.Location = New System.Drawing.Point(255, 32)
    Me.RbMap.Name = "RbMap"
    Me.RbMap.Size = New System.Drawing.Size(50, 16)
    Me.RbMap.TabIndex = 12
    Me.RbMap.Text = "Map"
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(322, 6)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 3
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "Ne&xt"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(272, 6)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(44, 24)
    Me.BtnFind.TabIndex = 2
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(112, 8)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(154, 20)
    Me.TxtPos.TabIndex = 4
    '
    'RbLoc
    '
    Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc.Location = New System.Drawing.Point(126, 32)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(112, 16)
    Me.RbLoc.TabIndex = 9
    Me.RbLoc.Text = "&Location#/Name"
    '
    'RbName
    '
    Me.RbName.Checked = True
    Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbName.Location = New System.Drawing.Point(8, 32)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(98, 16)
    Me.RbName.TabIndex = 8
    Me.RbName.TabStop = True
    Me.RbName.Text = "O&wner's Name"
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(72, 8)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtPosNo.TabIndex = 3
    Me.TxtPosNo.Visible = False
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(8, 16)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(64, 16)
    Me.label1.TabIndex = 3
    Me.label1.Text = "Position to"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtPermitNo)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(520, 10)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(193, 52)
    Me.groupBox2.TabIndex = 9
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(131, 19)
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
    Me.label2.Location = New System.Drawing.Point(12, 23)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(46, 13)
    Me.label2.TabIndex = 6
    Me.label2.Text = "Permit #"
    '
    'TxtPermitNo
    '
    Me.TxtPermitNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPermitNo.Location = New System.Drawing.Point(64, 19)
    Me.TxtPermitNo.MaxLength = 6
    Me.TxtPermitNo.Name = "TxtPermitNo"
    Me.TxtPermitNo.Size = New System.Drawing.Size(55, 22)
    Me.TxtPermitNo.TabIndex = 0
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(12, 68)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(701, 341)
    Me.DataGrdView.TabIndex = 34
    '
    'FrmBD001B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(725, 421)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.groupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD001B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select"
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmBD001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBDMAST = New BDMAST.mydata(MyDBConnect)
    myBDMASTL1 = New BDMASTL1.mydata(MyDBConnect)
    myBDMASTL2 = New BDMASTL2.mydata(MyDBConnect)
    myBDMASTL3 = New BDMASTL3.mydata(MyDBConnect)
    myBDMASTL4 = New BDMASTL4.mydata(MyDBConnect)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    MyFrmBD001.TBarDelete.Enabled = False
    MyFrmBD001.TBarPending.Enabled = False
    WrkRecID = 0
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()
    WrkFastGrid = False
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
    End With

    If RbName.Checked Then
      GridName()
    End If
    If RbLoc.Checked Then
      GridLocName()
    End If
    If RbMap.Checked Then
      GridMap()
    End If
  End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    Dim WrkPosNo As String
    Dim WrkMaxRecs As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkMaxRecs = 50
    WrkPos = Replace(TxtPos.Text, "'", "''")
    If RbName.Checked Then
      ds = myBDMASTL1.GetViewByName(WrkPos, WrkRecID, WrkMaxRecs, False)
    End If
    If RbLoc.Checked Then
      WrkPosNo = TxtPosNo.Text
      Do While Len(WrkPosNo) < 7 'Left pad with blanks
        WrkPosNo = " " & WrkPosNo
      Loop
      ds = myBDMASTL2.GetViewbyLoc(WrkPos, WrkPosNo, WrkRecID, WrkMaxRecs, False)
    End If
    If RbMap.Checked Then
      ds = myBDMASTL3.GetViewbyMap(WrkPos, WrkRecID, WrkMaxRecs, False)
    End If
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub GridName()
    With DataGrdView
      .Columns(1).HeaderText = "Name"
      .Columns(1).Width = 220
      .Columns(2).HeaderText = "Loc #"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Loc"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "Permit"
      .Columns(4).Width = 60
      .Columns(5).HeaderText = "Type"
      .Columns(5).Width = 50
    End With

  End Sub
  Private Sub GridLocName()
    With DataGrdView
      .Columns(1).HeaderText = "Loc #"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Location"
      .Columns(2).Width = 150
      .Columns(3).HeaderText = "Name"
      .Columns(3).Width = 220
      .Columns(4).HeaderText = "Permit"
      .Columns(4).Width = 60
      .Columns(5).HeaderText = "Type"
      .Columns(5).Width = 50
    End With

  End Sub
  Private Sub GridMap()
    With DataGrdView
      .Columns(1).HeaderText = "Map"
      .Columns(1).Width = 125
      .Columns(2).HeaderText = "Name"
      .Columns(2).Width = 220
      .Columns(3).HeaderText = "Loc #"
      .Columns(3).Width = 50
      .Columns(4).HeaderText = "Loc"
      .Columns(4).Width = 150
      .Columns(5).HeaderText = "Permit"
      .Columns(5).Width = 60
      .Columns(6).HeaderText = "Type"
      .Columns(6).Width = 50
    End With
  End Sub
  Private Sub RbLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoc.Click
    TxtPosNo.Visible = True
    FormatGrid()
  End Sub
  Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub Rbmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbMap.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub FrmBD001B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "BD001B"
    MyFrmBD001.TBarNew.Enabled = True
    MyFrmBD001.TBarSettings.Enabled = True
    MyFrmBD001.TBarChange.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    WrkRecID = DataGrdView.Item(0, I).Value + 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = DataGrdView.Item(1, I).Value
      TxtPos.Text = DataGrdView.Item(2, I).Value
    Else
      TxtPos.Text = DataGrdView.Item(1, I).Value
    End If

    FormatGrid()
    TxtPos.Text = ""
    TxtPosNo.Text = ""
    WrkRecID = 0

  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkRecID As Integer
    Dim WrkType As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    WrkRecID = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    If RbName.Checked Or RbLoc.Checked Then
      WrkType = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    Else
      WrkType = DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value
    End If
    If WrkFastGrid Then
      WrkType = DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value
    End If
    Select Case Trim(WrkType)
      Case "DEMO"
        MyFrmBD001CD = New FrmBD001CD
        MyFrmBD001CD.MdiParent = Me.ParentForm
        MyFrmBD001CD.WrkRecID = WrkRecID
        MyFrmBD001CD.WrkType = WrkType
        MyFrmBD001CD.WrkApp = False
        MyFrmBD001CD.Show()
      Case "ELECT"
        MyFrmBD001CE = New FrmBD001CE
        MyFrmBD001CE.MdiParent = Me.ParentForm
        MyFrmBD001CE.WrkRecID = WrkRecID
        MyFrmBD001CE.WrkType = WrkType
        MyFrmBD001CE.WrkApp = False
        MyFrmBD001CE.Show()
      Case "FLIQ", "HVAC"
        MyFrmBD001CH = New FrmBD001CH
        MyFrmBD001CH.MdiParent = Me.ParentForm
        MyFrmBD001CH.WrkRecID = WrkRecID
        MyFrmBD001CH.WrkType = WrkType
        MyFrmBD001CH.WrkApp = False
        MyFrmBD001CH.Show()
      Case "P&Z"
        MyFrmBD001CZ = New FrmBD001CZ
        MyFrmBD001CZ.MdiParent = Me.ParentForm
        MyFrmBD001CZ.WrkRecID = WrkRecID
        MyFrmBD001CZ.WrkType = WrkType
        MyFrmBD001CZ.WrkApp = False
        MyFrmBD001CZ.Show()
      Case Else
        MyFrmBD001C = New FrmBD001C
        MyFrmBD001C.MdiParent = Me.ParentForm
        MyFrmBD001C.WrkRecID = WrkRecID
        MyFrmBD001C.WrkType = WrkType
        MyFrmBD001C.WrkApp = False
        MyFrmBD001C.Show()
    End Select
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub TxtPosNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPosNo.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPos.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      Call FormatGrid()
    End If
  End Sub
  Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    Dim WrkType As String
    If MyUtils.CnvSng(TxtPermitNo.Text) = 0 Then Exit Sub

    ds = myBDMASTL4.GetViewbyPermit(MyUtils.CnvSng(TxtPermitNo.Text), "", 999, False)
    If ds.Tables(0).Rows.Count = 0 Then
      MsgBox("Permit No not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtPos.Text = ""
    TxtPosNo.Text = ""
    TxtPermitNo.Focus()
    If ds.Tables(0).Rows.Count > 1 Then
      ShowFastGrid()
      Exit Sub
    End If

    WrkType = Trim(ds.Tables(0).Rows(0).Item("type"))
    Select Case WrkType
      Case "DEMO"
        MyFrmBD001CD = New FrmBD001CD
        MyFrmBD001CD.WrkRecID = ds.Tables(0).Rows(0).Item("recid")
        MyFrmBD001CD.WrkType = WrkType
        MyFrmBD001CD.WrkApp = False
        MyFrmBD001CD.MdiParent = Me.ParentForm
        MyFrmBD001CD.Show()
      Case "ELECT"
        MyFrmBD001CE = New FrmBD001CE
        MyFrmBD001CE.WrkRecID = ds.Tables(0).Rows(0).Item("recid")
        MyFrmBD001CE.WrkType = WrkType
        MyFrmBD001CE.WrkApp = False
        MyFrmBD001CE.MdiParent = Me.ParentForm
        MyFrmBD001CE.Show()
      Case "FLIQ", "HVAC"
        MyFrmBD001CH = New FrmBD001CH
        MyFrmBD001CH.WrkRecID = ds.Tables(0).Rows(0).Item("recid")
        MyFrmBD001CH.WrkType = WrkType
        MyFrmBD001CH.WrkApp = False
        MyFrmBD001CH.MdiParent = Me.ParentForm
        MyFrmBD001CH.Show()
      Case "P&Z"
        MyFrmBD001CZ = New FrmBD001CZ
        MyFrmBD001CZ.WrkRecID = ds.Tables(0).Rows(0).Item("recid")
        MyFrmBD001CZ.WrkType = WrkType
        MyFrmBD001CZ.WrkApp = False
        MyFrmBD001CZ.MdiParent = Me.ParentForm
        MyFrmBD001CZ.Show()
      Case Else
        MyFrmBD001C = New FrmBD001C
        MyFrmBD001C.WrkRecID = ds.Tables(0).Rows(0).Item("recid")
        MyFrmBD001C.WrkType = WrkType
        MyFrmBD001C.WrkApp = False
        MyFrmBD001C.MdiParent = Me.ParentForm
        MyFrmBD001C.Show()
    End Select
    TxtPermitNo.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Public Sub ShowFastGrid()

    WrkFastGrid = True
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Map"
      .Columns(1).Width = 125
      .Columns(2).HeaderText = "Name"
      .Columns(2).Width = 220
      .Columns(3).HeaderText = "Loc #"
      .Columns(3).Width = 50
      .Columns(4).HeaderText = "Loc"
      .Columns(4).Width = 150
      .Columns(5).HeaderText = "Permit"
      .Columns(5).Width = 50
      .Columns(6).HeaderText = "Type"
      .Columns(6).Width = 50
    End With
    TxtPermitNo.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub TxtPermitNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPermitNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

    If Asc(e.KeyChar) = Keys.Enter Then
      ShowFastPath()
    End If
  End Sub
  Public Sub PermitType()
    MyFrmListTypes = New FrmListTypes
    MyFrmListTypes.MdiParent = MyFrmBD001B.ParentForm
    MyFrmListTypes.WrkRecID = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmListTypes.Show()
    Me.Hide()
  End Sub

End Class






