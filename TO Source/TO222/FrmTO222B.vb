Imports System.Data
Public Class FrmTO222B
  Inherits System.Windows.Forms.Form
  Dim MyTXOPMD1 As TXOPMD1L1.myData
  Dim ds As DataSet = New DataSet
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents BtnShow As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents TxtList As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents TxtFName As System.Windows.Forms.TextBox

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtLName As System.Windows.Forms.TextBox
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtLName = New System.Windows.Forms.TextBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.TxtFName = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.groupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(9, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "Last Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(213, 22)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 20
    Me.BtnFind.Text = "&Find"
    '
    'TxtLName
    '
    Me.TxtLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLName.Location = New System.Drawing.Point(79, 12)
    Me.TxtLName.Name = "TxtLName"
    Me.TxtLName.Size = New System.Drawing.Size(128, 20)
    Me.TxtLName.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(269, 22)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 27
    Me.BtnNext.Text = "&Next"
    '
    'TxtFName
    '
    Me.TxtFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFName.Location = New System.Drawing.Point(79, 32)
    Me.TxtFName.Name = "TxtFName"
    Me.TxtFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtFName.TabIndex = 197
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(9, 35)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 198
    Me.Label3.Text = "First Name"
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.TxtType)
    Me.groupBox2.Controls.Add(Me.TxtYear)
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtList)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(328, 2)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(190, 52)
    Me.groupBox2.TabIndex = 199
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtType.Location = New System.Drawing.Point(64, 30)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(16, 20)
    Me.TxtType.TabIndex = 1
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(80, 30)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 2
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(122, 14)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(43, 24)
    Me.BtnShow.TabIndex = 7
    Me.BtnShow.TabStop = False
    Me.BtnShow.Text = "&Show"
    '
    'label2
    '
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.Location = New System.Drawing.Point(5, 14)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(92, 16)
    Me.label2.TabIndex = 6
    Me.label2.Text = "List #/Type/Year"
    '
    'TxtList
    '
    Me.TxtList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtList.Location = New System.Drawing.Point(0, 30)
    Me.TxtList.MaxLength = 12
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(64, 20)
    Me.TxtList.TabIndex = 0
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
    Me.DataGrdView.Location = New System.Drawing.Point(48, 60)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(470, 288)
    Me.DataGrdView.TabIndex = 200
    '
    'FrmTO222B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(580, 360)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtFName)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtLName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTO222B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO222B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    MyTXOPMD1 = New TXOPMD1L1.MyData(myDBConnect)


    Call FormatGrid()

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "List No"
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Type"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Year"
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Last Name"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "First Name"
      .Columns(4).Width = 100
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXOPMD1.GetViewName(TxtLName.Text, TxtFName.Text, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmTO222B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO222.SbpScreen.Text = "TO222B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub FastPath()
    If TxtList.Text = "" Then Exit Sub

    MyFrmTO222C = New FrmTO222C
    MyFrmTO222C.MdiParent = Me.ParentForm
    MyFrmTO222C.WrkListNo = TxtList.Text
    MyFrmTO222C.WrkType = TxtType.Text
    MyFrmTO222C.WrkYear = TxtYear.Text
    MyFrmTO222C.Show()
    TxtList.Text = ""
    Me.Hide()

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtLName.Text = DataGrdView.Item(2, I).Value
    TxtFName.Text = DataGrdView.Item(3, I).Value
    FormatGrid()
    TxtLName.Text = ""
    TxtFName.Text = ""
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTO222C = New FrmTO222C
    MyFrmTO222C.MdiParent = Me.ParentForm
    MyFrmTO222C.WrkListNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTO222C.WrkType = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTO222C.WrkYear = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
    MyFrmTO222C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtList.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtType.KeyPress
  'Move to next field after anything has been typed since it's only 1 char allowed
  Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)

  If Asc(e.KeyChar) = Keys.Return Then
    FastPath()
  End If
End Sub

Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
	FastPath()
End Sub
End Class






