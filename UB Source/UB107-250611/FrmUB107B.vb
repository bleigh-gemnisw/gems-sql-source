Public Class FrmUB107B

  Inherits System.Windows.Forms.Form
	Dim myUTCUST As UTCUST.myData
	Dim myUTCUSTL1 As UTCUSTL1.myData
	Dim myUTCUSTL2 As UTCUSTL2.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Dim WrkListNo As Integer
  Dim WrkBlocking As Boolean

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
Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB107B))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.groupBox2.SuspendLayout()
    Me.groupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.BtnShow.Location = New System.Drawing.Point(116, 28)
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
    Me.label2.Location = New System.Drawing.Point(6, 32)
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
    Me.TxtList.Size = New System.Drawing.Size(65, 22)
    Me.TxtList.TabIndex = 0
    '
    'groupBox1
    '
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
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(296, 16)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 3
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "Ne&xt"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(248, 16)
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
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
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
    Me.DataGrdView.Location = New System.Drawing.Point(8, 82)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(536, 346)
    Me.DataGrdView.TabIndex = 34
    '
    'FrmUB107B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(554, 440)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.groupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB107B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select"
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    Me.groupBox1.ResumeLayout(False)
    Me.groupBox1.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

Private Sub FrmUB107B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTCUST = New UTCUST.mydata(MyDBConnect)
    myUTCUSTL1 = New UTCUSTL1.mydata(MyDBConnect)
    myUTCUSTL2 = New UTCUSTL2.mydata(MyDBConnect)
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    Call FormatGrid()
  End Sub
Public Sub FormatGrid()
  Call ShowGrid()
  GridName()
End Sub
Public Sub ShowGrid()
  Dim WrkPosNo As String
  Windows.Forms.Cursor.Current = Cursors.WaitCursor

  If RbName.Checked Then
      ds = myUTCUSTL1.GetViewbyName(TxtPos.Text, "", "", 20, WrkBlocking)
    End If
  If RbLoc.Checked Then
    WrkPosNo = TxtPosNo.Text
    Do While Len(WrkPosNo) < 7 'Left pad with blanks
      WrkPosNo = " " & WrkPosNo
    Loop
      ds = myUTCUSTL2.GetViewbyLoc(TxtPos.Text, WrkPosNo, "", 50, WrkBlocking)
    End If

  DataGrdView.DataSource = ds.Tables(0)
  DataGrdView.Refresh()
  Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub GridName()
With DataGrdView
  .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
  .RowHeadersWidth = 25
  .Columns(0).HeaderText = "Account"
  .Columns(0).Width = 70
  .Columns(1).HeaderText = "Name"
  .Columns(1).Width = 220
  .Columns(2).HeaderText = "Loc #"
  .Columns(2).Width = 50
  .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
  .Columns(3).HeaderText = "Location"
  .Columns(3).Width = 150
End With

End Sub
Private Sub GridLocName()
End Sub
Private Sub FrmUB107B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  End
End Sub
Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
  ShowFastPath()
End Sub
Private Sub RbLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoc.Click
  TxtPosNo.Visible = True
  FormatGrid()
End Sub
Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
  TxtPosNo.Visible = False
  FormatGrid()
End Sub
Private Sub RbReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  TxtPosNo.Visible = False
  FormatGrid()
End Sub
Private Sub FrmUB107B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB107.SbpScreen.Text = "UB107B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
  WrkListNo = 0
  Call FormatGrid()
End Sub
Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    WrkListNo = DataGrdView.Item(0, I).Value
    If TxtPosNo.Visible Then
      TxtPosNo.Text = DataGrdView.Item(2, I).Value
      TxtPos.Text = DataGrdView.Item(3, I).Value
    Else
      TxtPos.Text = DataGrdView.Item(1, I).Value
    End If

    FormatGrid()
    TxtPos.Text = ""
    TxtPosNo.Text = ""

  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
  MyFrmUB107C = New FrmUB107C
  MyFrmUB107C.WrkListNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
  MyFrmUB107C.WrkName = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
  MyFrmUB107C.MdiParent = Me.ParentForm
  MyFrmUB107C.Show()
  Me.Hide()
End Sub
Private Sub ShowFastPath()
  Dim WrkName As String

  If MyUtils.CnvSng(TxtList.Text) = 0 Then Exit Sub

  myUTCUST.GetOneRecordP(MyUtils.CnvSng(TxtList.Text))
  If myUTCUST.RecordNotFound Then
    MsgBox("List not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
    Exit Sub
  End If

  With myUTCUST
    TxtPos.Text = Trim(._CUNAM1)
    WrkName = Trim(._CUNAM1)
    If RbLoc.Checked Then
      TxtPosNo.Text = Trim(._CULOCNO)
      TxtPos.Text = Trim(._CULOC)
    End If
  End With
  FormatGrid()

  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  TxtPos.Text = ""
  TxtPosNo.Text = ""
  TxtList.Focus()
  MyFrmUB107C = New FrmUB107C

  With MyFrmUB107C
    .WrkListNo = TxtList.Text
    .WrkName = WrkName
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
    Call FormatGrid()
  End If
End Sub
End Class






