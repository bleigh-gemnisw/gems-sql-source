Public Class FrmListInv
  Inherits System.Windows.Forms.Form
	Dim myTXINVLE As TXINVLE.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkName As String
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As DataGridView
  Dim WrkListNo As Integer

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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(8, 40)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 49
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(280, 4)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 56
    Me.BtnNext.Text = "Ne&xt"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(18, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(220, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 52
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(86, 4)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(587, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(38, 16)
    Me.Label2.TabIndex = 202
    Me.Label2.Text = "Type "
    '
    'LblType
    '
    Me.LblType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblType.Location = New System.Drawing.Point(625, 12)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(19, 16)
    Me.LblType.TabIndex = 203
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(11, 46)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(633, 268)
    Me.DataGrdView.TabIndex = 434
    '
    'FrmListInv
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(656, 326)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListInv"
    Me.Text = "Select List Number"
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
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "List No"
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Year"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Type"
      .Columns(3).Width = 40
    End With

    GridNameLoc()

  End Sub
  Public Sub ShowGrid()
    WrkListNo = 0
    ds = myTXINVLE.GetViewbyType_Name(WrkType, TxtPos.Text, WrkListNo, 50)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmListInv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA01.SbpScreen.Text = "ListInv"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub GridNameLoc()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(4).HeaderText = "Owner Name"
      .Columns(4).Width = 250
      .Columns(5).Visible = False
      .Columns(6).HeaderText = "Loc No"
      .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(6).Width = 50
      .Columns(7).HeaderText = "Location"
      .Columns(7).Width = 150
    End With

  End Sub
  Private Sub FrmListInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXINVLE = New TXINVLE.mydata(MyDBConnect)
    LblType.Text = WrkType
    TxtPos.Text = WrkName
    FormatGrid()
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTXA01D
      .TxtList.Text = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
      .TxtYear.Text = DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value
      .TxtType.Text = DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      .LblName.Text = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
End Class






