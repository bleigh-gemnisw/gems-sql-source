Public Class FrmListRealC
  Inherits System.Windows.Forms.Form
	Dim myTXRELCL1 As TXRELCL1.myData
	Dim myTXRELCL2 As TXRELCL2.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
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
  Friend WithEvents LblCurrent As System.Windows.Forms.Label
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPosNo As System.Windows.Forms.TextBox
  Friend WithEvents RbView2 As System.Windows.Forms.RadioButton
  Friend WithEvents RbView1 As System.Windows.Forms.RadioButton
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtPosNo = New System.Windows.Forms.TextBox()
    Me.RbView2 = New System.Windows.Forms.RadioButton()
    Me.RbView1 = New System.Windows.Forms.RadioButton()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(8, 56)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 49
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(308, 4)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(53, 24)
    Me.BtnNext.TabIndex = 56
    Me.BtnNext.Text = "Ne&xt"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "Position To"
    '
    'TxtPosNo
    '
    Me.TxtPosNo.Location = New System.Drawing.Point(76, 4)
    Me.TxtPosNo.Name = "TxtPosNo"
    Me.TxtPosNo.Size = New System.Drawing.Size(41, 20)
    Me.TxtPosNo.TabIndex = 0
    Me.TxtPosNo.Visible = False
    '
    'RbView2
    '
    Me.RbView2.Location = New System.Drawing.Point(132, 36)
    Me.RbView2.Name = "RbView2"
    Me.RbView2.Size = New System.Drawing.Size(104, 16)
    Me.RbView2.TabIndex = 54
    Me.RbView2.Text = "Loc#/Location"
    '
    'RbView1
    '
    Me.RbView1.Checked = True
    Me.RbView1.Location = New System.Drawing.Point(12, 36)
    Me.RbView1.Name = "RbView1"
    Me.RbView1.Size = New System.Drawing.Size(104, 16)
    Me.RbView1.TabIndex = 53
    Me.RbView1.TabStop = True
    Me.RbView1.Text = "Owner's Name"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(252, 4)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 52
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(116, 4)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 1
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
    Me.DataGrdView.Location = New System.Drawing.Point(11, 75)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(633, 259)
    Me.DataGrdView.TabIndex = 67
    '
    'FrmListRealC
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(656, 346)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPosNo)
    Me.Controls.Add(Me.RbView2)
    Me.Controls.Add(Me.RbView1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListRealC"
    Me.Text = "Select RE List Number"
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
      .Columns(0).HeaderText = "List No"
      .Columns(0).Width = 50
    End With

    If RbView1.Checked Then
      GridNameLoc()
    End If
    If RbView2.Checked Then
      GridLocName()
    End If

  End Sub
  Public Sub ShowGrid()
      Dim WrkPosNo As String
      If RbView1.Checked Then
        ds = myTXRELCL2.GetViewbyName(TxtPos.Text, 100, False)
      End If
      If RbView2.Checked Then
        WrkPosNo = TxtPosNo.Text
        Do While Len(WrkPosNo) < 7 'Left pad with blanks
          WrkPosNo = " " & WrkPosNo
        Loop
        ds = myTXRELCL1.GetViewbyLoc(TxtPos.Text, WrkPosNo, 100)
      End If

    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmListReal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO221.SbpScreen.Text = "ListRealC"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub GridNameLoc()
    With DataGrdView
      .Columns(1).HeaderText = "Owner Name"
      .Columns(1).Width = 225
      .Columns(2).HeaderText = "Loc No"
      .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(2).Width = 50
      .Columns(3).HeaderText = "Location"
      .Columns(3).Width = 150
      .Columns(4).HeaderText = "Unit#"
      .Columns(4).Width = 50
    End With

End Sub
Private Sub GridLocName()
    With DataGrdView
      .Columns(1).HeaderText = "Loc No"
      .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(1).Width = 50
      .Columns(2).HeaderText = "Location"
      .Columns(2).Width = 150
    End With

End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    If TxtPosNo.Visible Then
      TxtPosNo.Text = DataGrdView.Item(1, I).Value
      TxtPos.Text = DataGrdView.Item(2, I).Value
    Else
      TxtPos.Text = DataGrdView.Item(1, I).Value
    End If
    FormatGrid()
    TxtPos.Text = ""
    TxtPosNo.Text = ""
  End Sub
  Private Sub FrmListReal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXRELCL1 = New TXRELCL1.mydata(MyDBConnect)
    myTXRELCL2 = New TXRELCL2.mydata(MyDBConnect)
    FormatGrid()
  End Sub
  Private Sub RbView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView1.Click
    TxtPosNo.Visible = False
    FormatGrid()
  End Sub
  Private Sub RbView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbView2.Click
    TxtPosNo.Visible = True
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTO221C
      .TxtListNo.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .GetListNo()
      .Show()
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub RbView1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbView1.CheckedChanged

End Sub
End Class








