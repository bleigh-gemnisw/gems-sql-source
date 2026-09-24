Public Class FrmUB501B

  Inherits System.Windows.Forms.Form
  Dim myUTCOEAL1 As UTCOEAL1.MyData
  Dim myUTCOEAL2 As UTCOEAL2.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnLookup As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents TxtPos As TextBox
  Friend WithEvents BtnNext As Button
  Friend WithEvents BtnFind As Button
  Friend WithEvents RbLoc As RadioButton
  Friend WithEvents RbName As RadioButton
  Friend WithEvents TxtPosNo As TextBox
  Friend WithEvents Label1 As Label
  Dim WrkUTTYPEL2 As String

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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtCCNo As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtCCNo = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnLookup = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.RbLoc = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
    Me.GroupBox2.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtCCNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(340, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(160, 48)
    Me.GroupBox2.TabIndex = 31
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(96, 16)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 4
    Me.BtnFast.Text = "S&how"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Adj #"
    '
    'TxtCCNo
    '
    Me.TxtCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCCNo.Location = New System.Drawing.Point(40, 16)
    Me.TxtCCNo.MaxLength = 5
    Me.TxtCCNo.Name = "TxtCCNo"
    Me.TxtCCNo.Size = New System.Drawing.Size(40, 20)
    Me.TxtCCNo.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtType)
    Me.GroupBox1.Controls.Add(Me.TxtYear)
    Me.GroupBox1.Controls.Add(Me.BtnLookup)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TxtList)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(327, 62)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(173, 55)
    Me.GroupBox1.TabIndex = 201
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "List Number Lookup"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(63, 31)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(80, 31)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnLookup
    '
    Me.BtnLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnLookup.Location = New System.Drawing.Point(122, 22)
    Me.BtnLookup.Name = "BtnLookup"
    Me.BtnLookup.Size = New System.Drawing.Size(43, 24)
    Me.BtnLookup.TabIndex = 7
    Me.BtnLookup.TabStop = False
    Me.BtnLookup.Text = "Find"
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(5, 14)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 16)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(6, 31)
    Me.TxtList.MaxLength = 7
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(57, 20)
    Me.TxtList.TabIndex = 0
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.AllowUserToResizeRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(7, 123)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(685, 348)
    Me.DataGrdView.TabIndex = 202
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.Label1)
    Me.GroupBox3.Controls.Add(Me.TxtPosNo)
    Me.GroupBox3.Controls.Add(Me.TxtPos)
    Me.GroupBox3.Controls.Add(Me.BtnNext)
    Me.GroupBox3.Controls.Add(Me.BtnFind)
    Me.GroupBox3.Controls.Add(Me.RbLoc)
    Me.GroupBox3.Controls.Add(Me.RbName)
    Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(314, 101)
    Me.GroupBox3.TabIndex = 206
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort Selection"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(6, 43)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 211
    Me.Label1.Text = "Position To"
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPosNo.Location = New System.Drawing.Point(76, 40)
    Me.TxtPosNo.MaxLength = 7
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(53, 20)
    Me.TxtPosNo.TabIndex = 0
    Me.TxtPosNo.Visible = False
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(135, 40)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 1
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(135, 66)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 208
    Me.BtnNext.Text = "Ne&xt"
    Me.BtnNext.Visible = False
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(79, 66)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 207
    Me.BtnFind.Text = "&Find"
    '
    'RbLoc
    '
    Me.RbLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLoc.Location = New System.Drawing.Point(135, 19)
    Me.RbLoc.Name = "RbLoc"
    Me.RbLoc.Size = New System.Drawing.Size(112, 16)
    Me.RbLoc.TabIndex = 206
    Me.RbLoc.Text = "&Location#/Name"
    '
    'RbName
    '
    Me.RbName.Checked = True
    Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbName.Location = New System.Drawing.Point(27, 19)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(104, 16)
    Me.RbName.TabIndex = 205
    Me.RbName.TabStop = True
    Me.RbName.Text = "O&wner's Name"
    '
    'FrmUB501B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(704, 483)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GroupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB501B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmUB501B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myUTCOEAL1 = New UTCOEAL1.MyData(myDBConnect)
    myUTCOEAL2 = New UTCOEAL2.MyData(myDBConnect)
    MyFrmUB501.TBarHist.Enabled = False
    MyFrmUB501.TBarPrint.Enabled = False
    Call FormatGrid(True)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    If RbLoc.Checked = True Then
      Call FormatGridLoc()
    Else
      Call FormatGrid(True)
    End If
  End Sub
  Public Sub FormatGrid(ByVal WrkName As Boolean)
    Dim I As Integer
    If WrkName Then
      Call ShowGridbyName()
    Else
      Call ShowGridByList()
    End If

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Adj No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "List No"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Type"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Name"
      .Columns(4).Width = 250
      If Not WrkName Then
        For I = 5 To 10
          .Columns(I).Visible = False
        Next
      End If
    End With
  End Sub
  Public Sub FormatGridLoc()
    Call ShowGridbyLoc()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Adj No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Year"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "List No"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Type"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Name"
      .Columns(4).Width = 250
      .Columns(3).HeaderText = "Type"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Name"
      .Columns(4).Width = 250
      .Columns(5).HeaderText = "Loc#"
      .Columns(5).Width = 50
      .Columns(6).HeaderText = "Location"
      .Columns(6).Width = 225
    End With
  End Sub
  Public Sub ShowGridbyName()
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")
    ds = myUTCOEAL2.GetViewbyName(WrkPos, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Public Sub ShowGridbyLoc()
    Dim WrkPos As String
    Dim wrksearch As String
    Dim wrksort As String

    ' if they enter loc# then  we want name like % and exact loc#  
    If (Trim(TxtPosNo.Text) > "") Then
      wrksearch = "CULOC LIKE '" + Replace(TxtPos.Text, "'", "''") + "%'"
      wrksearch = wrksearch + " AND CULOC# = '" + MyUtils.JustifyRight(TxtPosNo.Text, 7) + "'"
    Else
      wrksearch = "CULOC>= '" + Replace(TxtPos.Text, "'", "''") + "'"
    End If
    wrksort = "CULOC,CULOC#"
    WrkPos = Replace(TxtPos.Text, "'", "''")
    ds = myUTCOEAL2.GetViewByLocation(wrksearch, wrksort, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Public Sub ShowGridByList()
    ds = myUTCOEAL1.GetViewDescList(MyUtils.CnvSng(TxtList.Text), MyUtils.CnvSng(TxtYear.Text), TxtType.Text, 99999999, 999999, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmUB501B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB501.SbpScreen.Text = "UB501B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    Dim myUTCOEA As UTCOEA.MyData

    ErrProv.SetError(TxtCCNo, "")
    If TxtCCNo.Text = "" Then Exit Sub

    myUTCOEA = New UTCOEA.MyData(myDBConnect)
    myUTCOEA.GetOneRecordP(MyUtils.CnvSng(TxtCCNo.Text))
    If myUTCOEA.RecordNotFound Then
      ErrProv.SetError(TxtCCNo, "Invalid Adj Number")
      Exit Sub
    End If

    MyFrmUB501C = New FrmUB501C
    MyFrmUB501C.MdiParent = Me.ParentForm
    MyFrmUB501C.WrkCCNo = TxtCCNo.Text
    MyFrmUB501C.Show()

    TxtCCNo.Text = ""
    Me.Hide()

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If RbLoc.Checked = True Then
      TxtPos.Text = DataGrdView.Item(6, I).Value
      FormatGridLoc()
    Else
      TxtPos.Text = DataGrdView.Item(4, I).Value
      FormatGrid(True)
    End If

    TxtPos.Text = ""
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkUTTYPEL2 = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value

    MyFrmUB501C = New FrmUB501C
    MyFrmUB501C.MdiParent = Me.ParentForm
    MyFrmUB501C.WrkCCNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmUB501C.Show()

    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub TxtCCNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCCNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)

    If Asc(e.KeyChar) = Keys.Enter Then
      ShowFastPath()
    End If
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If Asc(e.KeyChar) = Keys.Enter Then
      If RbLoc.Checked = True Then
        FormatGridLoc()
      Else
        FormatGrid(True)

      End If

    End If
  End Sub
  Private Sub TxtList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
    'Move to next field after anything has been typed since it's only 1 char allowed
    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      FormatGrid(False)
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub BtnLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLookup.Click
    FormatGrid(False)
  End Sub

  Private Sub RbLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLoc.Click
    TxtPosNo.Visible = True
    FormatGridLoc()
  End Sub
  Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
    TxtPosNo.Visible = False
    FormatGrid(True)
  End Sub
End Class






