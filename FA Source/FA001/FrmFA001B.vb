Public Class FrmFA001B

  Inherits System.Windows.Forms.Form
  Dim myFAMSTR As FAMSTR.MyData
  Dim myFAMSTRL1 As FAMSTRL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents TxtTagNo As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents RbTag As RadioButton
  Dim WrkTagNo As String
  Const cMaxRecs As Integer = 100

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
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents RbSerial As System.Windows.Forms.RadioButton
  Friend WithEvents RbDesc As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFA001B))
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtTagNo = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbTag = New System.Windows.Forms.RadioButton()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbSerial = New System.Windows.Forms.RadioButton()
    Me.RbDesc = New System.Windows.Forms.RadioButton()
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
    Me.groupBox2.Controls.Add(Me.TxtTagNo)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(364, 8)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(204, 68)
    Me.groupBox2.TabIndex = 1
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtTagNo
    '
    Me.TxtTagNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTagNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTagNo.Location = New System.Drawing.Point(54, 24)
    Me.TxtTagNo.MaxLength = 9
    Me.TxtTagNo.Name = "TxtTagNo"
    Me.TxtTagNo.Size = New System.Drawing.Size(82, 22)
    Me.TxtTagNo.TabIndex = 8
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(142, 22)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(56, 24)
    Me.BtnShow.TabIndex = 7
    Me.BtnShow.TabStop = False
    Me.BtnShow.Text = "&Show"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(12, 28)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(36, 16)
    Me.label2.TabIndex = 6
    Me.label2.Text = "Tag #"
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.RbTag)
    Me.groupBox1.Controls.Add(Me.BtnNext)
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.RbSerial)
    Me.groupBox1.Controls.Add(Me.RbDesc)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(8, 8)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(356, 68)
    Me.groupBox1.TabIndex = 0
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
    '
    'RbTag
    '
    Me.RbTag.AutoSize = True
    Me.RbTag.Checked = True
    Me.RbTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTag.Location = New System.Drawing.Point(27, 40)
    Me.RbTag.Name = "RbTag"
    Me.RbTag.Size = New System.Drawing.Size(54, 17)
    Me.RbTag.TabIndex = 10
    Me.RbTag.TabStop = True
    Me.RbTag.Text = "&Tag #"
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
    Me.TxtPos.Location = New System.Drawing.Point(72, 16)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(168, 22)
    Me.TxtPos.TabIndex = 1
    '
    'RbSerial
    '
    Me.RbSerial.AutoSize = True
    Me.RbSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSerial.Location = New System.Drawing.Point(189, 40)
    Me.RbSerial.Name = "RbSerial"
    Me.RbSerial.Size = New System.Drawing.Size(61, 17)
    Me.RbSerial.TabIndex = 9
    Me.RbSerial.Text = "&Serial #"
    '
    'RbDesc
    '
    Me.RbDesc.AutoSize = True
    Me.RbDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbDesc.Location = New System.Drawing.Point(96, 40)
    Me.RbDesc.Name = "RbDesc"
    Me.RbDesc.Size = New System.Drawing.Size(78, 17)
    Me.RbDesc.TabIndex = 8
    Me.RbDesc.Text = "&Description"
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
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(35, 90)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(506, 338)
    Me.DataGrdView.TabIndex = 39
    '
    'FrmFA001B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(575, 440)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.groupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmFA001B"
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

  Private Sub FrmFA001B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFAMSTR = New FAMSTR.MyData()
    myFAMSTR.MyDBConn = myDBConnect
    myFAMSTRL1 = New FAMSTRL1.MyData(myDBConnect)
    Call FormatGrid(True, False)
  End Sub
  Public Sub FormatGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean)
    Call ShowGrid(WrkFind, WrkNext)
    GridDesc()
  End Sub
  Public Sub ShowGrid(ByVal WrkFind As Boolean, ByVal WrkNext As Boolean)
    Dim WrkPos As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkPos = Replace(TxtPos.Text, "'", "''")

    If RbTag.Checked Then
      ds = myFAMSTRL1.GetViewbyTag(WrkPos, cMaxRecs)
    End If
    If RbDesc.Checked Then
      ds = myFAMSTRL1.GetViewbyDesc(WrkPos, cMaxRecs)
    End If
    If RbSerial.Checked Then
      ds = myFAMSTRL1.GetViewbySerialNo(WrkPos, cMaxRecs)
    End If

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub GridDesc()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Tag #"
      .Columns(0).Width = 70
      .Columns(1).HeaderText = "Desciption"
      .Columns(1).Width = 220
      .Columns(2).HeaderText = "Serial #"
      .Columns(2).Width = 150
    End With

  End Sub
  Private Sub FrmFA001B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    End
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    ShowFastPath()
  End Sub
  Private Sub RbSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSerial.Click
    FormatGrid(True, False)
  End Sub
  Private Sub RbDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbDesc.Click
    FormatGrid(True, False)
  End Sub
  Private Sub RbTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbTag.Click
    FormatGrid(True, False)
  End Sub
  Private Sub FrmFA001B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFA001.SbpScreen.Text = "FA001B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkTagNo = ""
    Call FormatGrid(True, False)
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    ShowGridNext()
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmFA001C = New FrmFA001C
    MyFrmFA001C.AddMode = False
    MyFrmFA001C.WrkTagNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmFA001C.MdiParent = Me.ParentForm
    MyFrmFA001C.Show()
    Me.Hide()
  End Sub
  Private Sub ShowFastPath()
    If TxtTagNo.Text = "" Then Exit Sub

    myFAMSTR.GetOneRecordP(TxtTagNo.Text)
    If myFAMSTR.RecordNotFound Then
      MsgBox("Tag not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    With myFAMSTR
      TxtPos.Text = Trim(._FADESC)
    End With
    FormatGrid(True, False)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtPos.Text = ""
    TxtTagNo.Focus()
    MyFrmFA001C = New FrmFA001C

    With MyFrmFA001C
      .AddMode = False
      .WrkTagNo = TxtTagNo.Text
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtTagNo.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Public Sub ShowGridNext()
    Dim I As Integer
    Dim J As Integer
    I = ds.Tables(0).Rows.Count - 1
    If RbTag.Checked Then
      J = 0
    End If
    If RbDesc.Checked Then
      J = 1
    End If
    If RbSerial.Checked Then
      J = 2
    End If
    TxtPos.Text = Trim(DataGrdView.Item(J, I).Value)
    FormatGrid(False, True)
  End Sub
  Private Sub TxtTagNo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTagNo.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPos.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Enter Then
      WrkTagNo = ""
      Call FormatGrid(True, False)
    End If
  End Sub
  Private Sub TxtTagNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTagNo.KeyPress
    If Asc(e.KeyChar) = Keys.Enter Then
      ShowFastPath()
    End If
  End Sub
End Class
