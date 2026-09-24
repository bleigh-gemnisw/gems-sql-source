Public Class FrmListPenCd
  Inherits System.Windows.Forms.Form
  Dim myTXPEN As TXPEN.myData
  Dim ds As DataSet = New DataSet
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
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.LblCurrent = New System.Windows.Forms.Label()
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
    Me.BtnFind.Location = New System.Drawing.Point(208, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 29
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(72, 8)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 28
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(40, 36)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 32
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrdView.Location = New System.Drawing.Point(12, 46)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(304, 268)
    Me.DataGrdView.TabIndex = 434
    '
    'FrmListPenCd
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(328, 326)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCurrent)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListPenCd"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Penalty Code"
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
      .Columns(0).HeaderText = "Code"
      .Columns(0).Width = 40
      .Columns(1).HeaderText = "Description"
      .Columns(1).Width = 150
    End With

  End Sub
  Public Sub ShowGrid()
    If TxtPos.Text = "" Then
      ds = myTXPEN.GetAllData
    Else
      ds = myTXPEN.PosData(TxtPos.Text)
    End If
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmListCCReason_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA01.SbpScreen.Text = "ListPenCd"
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub
  Private Sub FrmListCCReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPEN = New TXPEN.mydata(MyDBConnect)
    LblCurrent.Text = "(" & WrkField & "=" & WrkCode & ")"
    FormatGrid()
  End Sub

  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTXA01D
      Select Case WrkField
        Case "1"
          .TxtFeeCd1.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd1, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "2"
          .TxtFeeCd2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd2, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "3"
          .TxtFeeCd3.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd3, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "4"
          .TxtFeeCd4.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd4, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "5"
          .TxtFeeCd5.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd5, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "6"
          .TxtFeeCd6.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd6, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
        Case "7"
          .TxtFeeCd7.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
          .Ttp1.SetToolTip(.TxtFeeCd7, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
      End Select
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmListPenCd_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	MyFrmTXA01D.Show()
End Sub
End Class






