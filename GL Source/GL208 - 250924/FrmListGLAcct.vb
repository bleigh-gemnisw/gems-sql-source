Public Class FrmListGLAcct
  Inherits System.Windows.Forms.Form
	Dim myGLAcct As GLACCT.myData
	Dim ds As DataSet = New DataSet
	Dim WrkSave As Boolean
	Dim WrkDelete As Boolean
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents TxtDpt As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfnd As System.Windows.Forms.TextBox
  Friend WithEvents TxtFnd As System.Windows.Forms.TextBox
  Friend WrkCode As String
  Friend WithEvents DataGrdView As DataGridView
  Friend WrkField As String

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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDpt = New System.Windows.Forms.TextBox()
    Me.TxtSfnd = New System.Windows.Forms.TextBox()
    Me.TxtFnd = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 30
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(334, 8)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 22)
    Me.BtnFind.TabIndex = 29
    Me.BtnFind.Text = "&Find"
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(66, 34)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 14)
    Me.LblCurrent.TabIndex = 32
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(283, 8)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 204
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(234, 8)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 203
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(196, 8)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 202
    '
    'TxtDpt
    '
    Me.TxtDpt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDpt.Location = New System.Drawing.Point(145, 8)
    Me.TxtDpt.MaxLength = 4
    Me.TxtDpt.Name = "TxtDpt"
    Me.TxtDpt.Size = New System.Drawing.Size(45, 22)
    Me.TxtDpt.TabIndex = 201
    '
    'TxtSfnd
    '
    Me.TxtSfnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfnd.Location = New System.Drawing.Point(107, 8)
    Me.TxtSfnd.MaxLength = 3
    Me.TxtSfnd.Name = "TxtSfnd"
    Me.TxtSfnd.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfnd.TabIndex = 200
    '
    'TxtFnd
    '
    Me.TxtFnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFnd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFnd.Location = New System.Drawing.Point(69, 8)
    Me.TxtFnd.MaxLength = 3
    Me.TxtFnd.Name = "TxtFnd"
    Me.TxtFnd.Size = New System.Drawing.Size(32, 22)
    Me.TxtFnd.TabIndex = 199
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
    Me.DataGrdView.Location = New System.Drawing.Point(11, 51)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(577, 263)
    Me.DataGrdView.TabIndex = 353
    '
    'FrmListGLAcct
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(600, 326)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.TxtSfcn)
    Me.Controls.Add(Me.TxtFcn)
    Me.Controls.Add(Me.TxtObj)
    Me.Controls.Add(Me.TxtDpt)
    Me.Controls.Add(Me.TxtSfnd)
    Me.Controls.Add(Me.TxtFnd)
    Me.Controls.Add(Me.LblCurrent)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListGLAcct"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select G/L Acct"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Fund"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Sfund"
      .Columns(1).Width = 40
      .Columns(2).HeaderText = "Dept"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Obj"
      .Columns(3).Width = 40
      .Columns(4).HeaderText = "Func"
      .Columns(4).Width = 40
      .Columns(5).HeaderText = "Sfcn"
      .Columns(5).Width = 40
      .Columns(6).HeaderText = "Description"
      .Columns(6).Width = 200
      .Columns(7).HeaderText = "Type"
      .Columns(7).Width = 80
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myGLAcct.GetViewbyAcct(MyUtils.CnvSng(TxtFnd.Text), MyUtils.CnvSng(TxtSfnd.Text), MyUtils.CnvSng(TxtDpt.Text),
        MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text), 250)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmListGLAcct_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL208.SbpScreen.Text = "ListGLAcct"
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub

  Private Sub FrmListGLAcct_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    MyFrmGL208.TBarPrint.Enabled = True
    MyFrmGL208B.Show()
  End Sub
  Private Sub FrmListGLAcct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGLAcct = New GLACCT.MyData()
    myGLAcct.MyDBConn = myDBConnect
    MyFrmGL208.TBarPrint.Enabled = False
    If WrkCode <> String.Empty Then
      TxtFnd.Text = MyUtils.CnvSng(Mid(WrkCode, 1, 3))
      TxtSfnd.Text = MyUtils.CnvSng(Mid(WrkCode, 5, 3))
      TxtDpt.Text = MyUtils.CnvSng(Mid(WrkCode, 9, 4))
      TxtObj.Text = MyUtils.CnvSng(Mid(WrkCode, 14, 3))
      TxtFcn.Text = MyUtils.CnvSng(Mid(WrkCode, 18, 4))
      TxtSfcn.Text = MyUtils.CnvSng(Mid(WrkCode, 23, 4))
      LblCurrent.Text = "(G/L Acct =" & WrkCode & ")"
    End If
    FormatGrid()
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 7) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "A"
          e.Value = "Asset"
        Case "H"
          e.Value = "Header"
        Case "L"
          e.Value = "Liability"
        Case "R"
          e.Value = "Revenue"
        Case "Q"
          e.Value = "Equity"
        Case "X"
          e.Value = "Expenditure"
        Case Else
      End Select
    End If
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmGL208B
      .TxtFundFrom.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .TxtSfundFrom.Text = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      .TxtDeptFrom.Text = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
      .TxtObjFrom.Text = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      .TxtFuncFrom.Text = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
      .TxtSfuncFrom.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
      .TTp1.SetToolTip(.TxtFundFrom, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
      .TxtFundTo.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .TxtSfundTo.Text = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      .TxtDeptTo.Text = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
      .TxtObjTo.Text = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      .TxtFuncTo.Text = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
      .TxtSfuncTo.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
      .TTp1.SetToolTip(.TxtFundTo, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    End With
    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
End Class
