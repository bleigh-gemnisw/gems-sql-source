Public Class FrmPK120B

  Inherits System.Windows.Forms.Form
  Dim myPKTICK As PKTICK.myData
  Dim myPKTICKL1 As PKTICKL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents TxtTickNo As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkTickNo As Integer

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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents RbRegno As System.Windows.Forms.RadioButton
  Friend WithEvents RbName As System.Windows.Forms.RadioButton
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPK120B))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtTickNo = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.groupBox1 = New System.Windows.Forms.GroupBox()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.RbRegno = New System.Windows.Forms.RadioButton()
    Me.RbName = New System.Windows.Forms.RadioButton()
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
    Me.groupBox2.Controls.Add(Me.TxtTickNo)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(364, 8)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(199, 68)
    Me.groupBox2.TabIndex = 1
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtTickNo
    '
    Me.TxtTickNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTickNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTickNo.Location = New System.Drawing.Point(65, 24)
    Me.TxtTickNo.MaxLength = 9
    Me.TxtTickNo.Name = "TxtTickNo"
    Me.TxtTickNo.Size = New System.Drawing.Size(59, 22)
    Me.TxtTickNo.TabIndex = 8
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(130, 22)
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
    Me.label2.Location = New System.Drawing.Point(12, 28)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(47, 13)
    Me.label2.TabIndex = 6
    Me.label2.Text = "Ticket #"
    '
    'groupBox1
    '
    Me.groupBox1.Controls.Add(Me.BtnFind)
    Me.groupBox1.Controls.Add(Me.TxtPos)
    Me.groupBox1.Controls.Add(Me.RbRegno)
    Me.groupBox1.Controls.Add(Me.RbName)
    Me.groupBox1.Controls.Add(Me.label1)
    Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox1.Location = New System.Drawing.Point(8, 8)
    Me.groupBox1.Name = "groupBox1"
    Me.groupBox1.Size = New System.Drawing.Size(356, 68)
    Me.groupBox1.TabIndex = 0
    Me.groupBox1.TabStop = False
    Me.groupBox1.Text = "Sort By"
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
    'RbRegno
    '
    Me.RbRegno.AutoSize = True
    Me.RbRegno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRegno.Location = New System.Drawing.Point(78, 40)
    Me.RbRegno.Name = "RbRegno"
    Me.RbRegno.Size = New System.Drawing.Size(62, 17)
    Me.RbRegno.TabIndex = 9
    Me.RbRegno.Text = "&Reg No"
    '
    'RbName
    '
    Me.RbName.AutoSize = True
    Me.RbName.Checked = True
    Me.RbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbName.Location = New System.Drawing.Point(8, 40)
    Me.RbName.Name = "RbName"
    Me.RbName.Size = New System.Drawing.Size(53, 17)
    Me.RbName.TabIndex = 8
    Me.RbName.TabStop = True
    Me.RbName.Text = "&Name"
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
    Me.DataGrdView.Location = New System.Drawing.Point(44, 82)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(481, 346)
    Me.DataGrdView.TabIndex = 42
    '
    'FrmPK120B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(575, 440)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.groupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPK120B"
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

  Private Sub FrmPK120B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPKTICK = New PKTICK.MyData(myDBConnect)
    myPKTICKL1 = New PKTICKL1.MyData(myDBConnect)
    Call FormatGrid(True)
  End Sub
  Public Sub FormatGrid(ByVal Find As Boolean)
    Call ShowGrid(Find)
    If RbName.Checked Then
      GridName()
    Else
      GridRegNo()
    End If
  End Sub
  Public Sub ShowGrid(ByVal Find As Boolean)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    If RbName.Checked Then
      ds = myPKTICKL1.GetViewbyName(TxtPos.Text, 250)
    End If
    If RbRegno.Checked Then
      ds = myPKTICKL1.GetViewbyRegNo(TxtPos.Text, 250)
    End If

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub GridName()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Ticket #"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Name"
      .Columns(1).Width = 200
      .Columns(2).HeaderText = "Reg No"
      .Columns(2).Width = 75
      .Columns(3).HeaderText = "ST"
      .Columns(3).Width = 25
      .Columns(4).HeaderText = "Status"
      .Columns(4).Width = 75
    End With

  End Sub
  Private Sub GridRegNo()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Ticket #"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Reg No"
      .Columns(1).Width = 75
      .Columns(2).HeaderText = "ST"
      .Columns(2).Width = 25
      .Columns(3).HeaderText = "Name"
      .Columns(3).Width = 200
      .Columns(4).HeaderText = "Status"
      .Columns(4).Width = 75
    End With

  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 4) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "L"
          e.Value = "Override"
        Case "P"
          e.Value = "Paid"
        Case "V"
          e.Value = "Void"
        Case Else
      End Select
    End If
  End Sub
  Private Sub FrmPK120B_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Application.Exit()
  End Sub
  Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
    ShowFastPath()
  End Sub
  Private Sub RbRegno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbRegno.Click
    FormatGrid(True)
  End Sub
  Private Sub RbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbName.Click
    FormatGrid(True)
  End Sub
  Private Sub FrmPK120B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPK120.SbpScreen.Text = "PK120B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    WrkTickNo = 0
    Call FormatGrid(True)
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmPK120C = New FrmPK120C

    MyFrmPK120C.AddMode = False
    MyFrmPK120C.WrkTickNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmPK120C.MdiParent = Me.ParentForm
    MyFrmPK120C.Show()
    Me.Hide()
  End Sub
  Private Sub ShowFastPath()
    If TxtTickNo.Text = "" Then Exit Sub

    myPKTICK.GetOneRecordP(MyUtils.CnvSng(TxtTickNo.Text))
    If myPKTICK.RecordNotFound Then
      MsgBox("Ticket Number not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    FormatGrid(True)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    TxtPos.Text = ""
    TxtTickNo.Focus()
    MyFrmPK120C = New FrmPK120C

    With MyFrmPK120C
      .AddMode = False
      .WrkTickNo = TxtTickNo.Text
      .MdiParent = Me.ParentForm
      .Show()
    End With

    TxtTickNo.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub
  Private Sub TxtTickNo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTickNo.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPos.GotFocus
    MyUtils.ShowFocus(Me.ActiveControl)
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Enter Then
      WrkTickNo = 0
      Call FormatGrid(True)
    End If
  End Sub
  Private Sub TxtTickNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTickNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    If Asc(e.KeyChar) = Keys.Enter Then
      ShowFastPath()
    End If
  End Sub

End Class
