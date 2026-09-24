Public Class FrmListCode
  Inherits System.Windows.Forms.Form
  Dim myMRCODE As MRCODE.MyData
  Dim myMRBCH As MRBCH.MyData
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WrkBatchNo As Integer

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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
    Me.BtnFind.Location = New System.Drawing.Point(120, 5)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 29
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(72, 8)
    Me.TxtPos.MaxLength = 3
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(40, 20)
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
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(11, 55)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(389, 260)
    Me.DataGrdView.TabIndex = 40
    '
    'FrmListCode
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(413, 326)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCurrent)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListCode"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Receipt Code"
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmListCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMRCODE = New MRCODE.MyData()
    myMRCODE.MyDBConn = myDBConnect
    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    BuildDS()
    FormatGrid()
  End Sub
  Private Sub FrmListCode_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMR001.SbpScreen.Text = "ListCode"
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Code"
      .Columns(0).Width = 45
      .Columns(1).HeaderText = "Description"
      .Columns(1).Width = 200
      .Columns(2).HeaderText = "Acct No"
      .Columns(2).Width = 100
    End With

  End Sub
  Public Sub ShowGrid()
    ds = myMRCODE.PosData(TxtPos.Text)
    RefreshDS()
    DataGrdView.DataSource = ds2.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Private Sub RefreshDS()
    Dim myDr As Data.DataRow
    Dim WrkSelCodes As String
    Dim I As Integer
    Dim Pos As Integer

    myMRBCH.GetOneRecordP(WrkBatchNo)
    WrkSelCodes = Trim(myMRBCH._CODES)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    For I = 0 To ds.Tables(0).Rows.Count - 1
      myDr = ds2.Tables(0).NewRow
      Pos = InStr(WrkSelCodes, ds.Tables(0).Rows(I).Item("code"))
      If WrkSelCodes = "" Or Pos > 0 Then
        myDr("Code") = ds.Tables(0).Rows(I).Item("code")
        myDr("Descr") = ds.Tables(0).Rows(I).Item("descr")
        myDr("Acct") = ds.Tables(0).Rows(I).Item("Acct")
        ds2.Tables(0).Rows.Add(myDr)
      End If
    Next

    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Refresh()
  End Sub
  Private Sub TxtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If e.KeyChar = MyUtils.VbKeyEnter Then
      FormatGrid()
    End If
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmMR001C
      .TxtCode.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtCode, DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmListCode_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMR001C.Show()
End Sub
End Class
