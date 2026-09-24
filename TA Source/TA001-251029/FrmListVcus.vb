Public Class FrmListVcus
  Inherits System.Windows.Forms.Form
  Dim myTXVCUS1 As TXVCUSL1.myData
  Dim ds As DataSet = New DataSet
  Dim WrkBlocking As Boolean
  Friend WrkName As String
  Friend WrkDOB As Integer
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WrkPrimary As Boolean

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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblCurrent = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
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
    Me.BtnNext.Text = "&Next"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 4)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "Position To"
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
    Me.TxtPos.Location = New System.Drawing.Point(82, 4)
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(162, 20)
    Me.TxtPos.TabIndex = 1
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
    Me.DataGrdView.Location = New System.Drawing.Point(11, 34)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(646, 353)
    Me.DataGrdView.TabIndex = 57
    '
    'FrmListVcus
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(669, 399)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.LblCurrent)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmListVcus"
    Me.Text = "Select DMV Customer"
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
      .Columns(0).HeaderText = "Cust ID"
      .Columns(0).Width = 60
      .Columns(1).HeaderText = "Name"
      .Columns(1).Width = 175
      .Columns(2).HeaderText = "Address 1"
      .Columns(2).Width = 175
      .Columns(3).HeaderText = "City"
      .Columns(3).Width = 125
      .Columns(4).HeaderText = "DOB"
      .Columns(4).Width = 60
    End With
  End Sub
  Public Sub ShowGrid()
    ds = myTXVCUS1.GetViewbyName(TxtPos.Text, 250)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()

  End Sub
  Private Sub FrmListVCus_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA001.SbpScreen.Text = "ListVcus"
    MyUtils.CenterForm(Me.ParentForm, Me)
    TxtPos.Text = WrkName
    FormatGrid()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = DataGrdView.Item(1, I).Value
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Private Sub FrmListVcus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVCUS1 = New TXVCUSL1.mydata(MyDBConnect)
    MyFrmTA001.TBarSave.Enabled = False
    MyFrmTA001.TBarDelete.Enabled = False
    If MyServer = "SQL" Then
      WrkBlocking = False
    Else
      WrkBlocking = True
    End If
    FormatGrid()
  End Sub
Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    With MyFrmTA001DMV
      If WrkPrimary Then
        .TxtSSNo.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        .GetDMVPCust(.TxtSSNo.Text)
      Else
        .TxtSS2.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        .GetDMVSCust(.TxtSSNo.Text)
      End If
    End With

    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub
Private Sub FrmListVcus_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTA001DMV
      .Show()
    End With
    'Memory Cleanup
    myTXVCUS1 = Nothing
    MyFrmListVcus = Nothing
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub
End Class






