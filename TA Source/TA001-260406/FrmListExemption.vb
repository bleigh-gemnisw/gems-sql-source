Public Class FrmListExemption
  Inherits System.Windows.Forms.Form
	Dim myTXExem As TXEXEM.myData
  Dim ds As DataSet = New DataSet
  Friend WrkType As String
  Friend WrkCode As String
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WrkFieldNo As Integer

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblCurrent
    '
    Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblCurrent.Location = New System.Drawing.Point(12, 32)
    Me.LblCurrent.Name = "LblCurrent"
    Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
    Me.LblCurrent.TabIndex = 38
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 36
    Me.Label1.Text = "Position To"
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(208, 0)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(53, 24)
    Me.BtnFind.TabIndex = 35
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Location = New System.Drawing.Point(72, 4)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(128, 20)
    Me.TxtPos.TabIndex = 34
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.AllowUserToResizeRows = False
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
    Me.DataGrdView.Size = New System.Drawing.Size(413, 260)
    Me.DataGrdView.TabIndex = 40
    '
    'FrmListExemption
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(436, 322)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblCurrent)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListExemption"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select Exempt Code"
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
      .Columns(1).Visible = False
      .Columns(2).HeaderText = "Fixed Amt"
      .Columns(2).Width = 40
      .Columns(3).HeaderText = "Pct"
      .Columns(3).Width = 30
      .Columns(4).Visible = False
      .Columns(5).Visible = False
      .Columns(6).HeaderText = "Description"
      .Columns(6).Width = 250
      .Columns(7).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    If TxtPos.Text = "" Then
      ds = myTXExem.GetAllData
    Else
      ds = myTXExem.PosData(TxtPos.Text)
    End If
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmListExemption_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "ListExempt"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmListExemption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXExem = New TXEXEM.mydata(MyDBConnect)
    LblCurrent.Text = "(Exemption Code " & WrkFieldNo & " = " & WrkCode & ")"
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    If WrkType = "M" Then
    With MyFrmTA001MV
    Select Case WrkFieldNo
    Case 1
      .TxtExempt1.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt1, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 2
      .TxtExempt2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt2, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 3
      .TxtExempt3.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt3, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 4
      .TxtExempt4.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt4, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 5
      .TxtExempt5.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt5, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    End Select
    .Show()
    End With
    End If

    If WrkType = "P" Then
    With MyFrmTA001PP
    Select Case WrkFieldNo
    Case 1
      .TxtExempt1.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt1, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 2
      .TxtExempt2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt2, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 3
      .TxtExempt3.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt3, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 4
      .TxtExempt4.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt4, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 5
      .TxtExempt5.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt5, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    End Select
    .Show()
    End With
    End If

    If WrkType = "R" Then
    With MyFrmTA001RE
    Select Case WrkFieldNo
    Case 1
      .TxtExempt1.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt1, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 2
      .TxtExempt2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt2, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 3
      .TxtExempt3.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt3, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 4
      .TxtExempt4.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt4, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 5
      .TxtExempt5.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt5, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 6
      .TxtExempt6.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt6, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 7
      .TxtExempt7.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt7, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    End Select
    .Show()
    End With
    End If

    If WrkType = "S" Then
    With MyFrmTA001SU
    Select Case WrkFieldNo
    Case 1
      .TxtExempt1.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt1, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 2
      .TxtExempt2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt2, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 3
      .TxtExempt3.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt3, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 4
      .TxtExempt4.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt4, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    Case 5
      .TxtExempt5.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      .Ttp1.SetToolTip(.TxtExempt5, DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
    End Select
    .Show()
    End With
    End If

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub FrmListExemption_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    'Memory Cleanup
    myTXExem = Nothing
    MyFrmListExemption = Nothing
End Sub
End Class






