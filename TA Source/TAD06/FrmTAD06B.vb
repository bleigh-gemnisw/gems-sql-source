Imports System.Data
Public Class FrmTAD06B
  Inherits System.Windows.Forms.Form
  Dim myTXCOOA As TXCOOA.MyData
  Dim myTXCOOAL1 As TXCOOAL1.MyData
  Dim ds As DataSet = New DataSet
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents CboSort As ComboBox
  Friend WithEvents BtnNext As Button
  Friend WithEvents BtnFind As Button
  Friend WithEvents TxtPos As TextBox
  Friend WithEvents TxtYear As TextBox
  Friend WithEvents Label29 As Label
  Dim cMaxRecs As Integer = 50

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
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtDevlt As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtDevlt = New System.Windows.Forms.TextBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtDevlt)
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtListNo)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(487, 4)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(200, 48)
    Me.GroupBox2.TabIndex = 26
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path"
    '
    'TxtDevlt
    '
    Me.TxtDevlt.Location = New System.Drawing.Point(103, 16)
    Me.TxtDevlt.MaxLength = 6
    Me.TxtDevlt.Name = "TxtDevlt"
    Me.TxtDevlt.Size = New System.Drawing.Size(32, 20)
    Me.TxtDevlt.TabIndex = 2
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(141, 13)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "&Show"
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(8, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "List#"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(40, 16)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(57, 20)
    Me.TxtListNo.TabIndex = 1
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
    Me.DataGrdView.Location = New System.Drawing.Point(31, 54)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(641, 330)
    Me.DataGrdView.TabIndex = 39
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.CboSort)
    Me.GroupBox3.Controls.Add(Me.BtnNext)
    Me.GroupBox3.Controls.Add(Me.BtnFind)
    Me.GroupBox3.Controls.Add(Me.TxtPos)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(64, 0)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(390, 52)
    Me.GroupBox3.TabIndex = 200
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort By"
    '
    'CboSort
    '
    Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboSort.FormattingEnabled = True
    Me.CboSort.Location = New System.Drawing.Point(6, 14)
    Me.CboSort.Name = "CboSort"
    Me.CboSort.Size = New System.Drawing.Size(95, 21)
    Me.CboSort.TabIndex = 0
    '
    'BtnNext
    '
    Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnNext.Location = New System.Drawing.Point(334, 15)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(48, 24)
    Me.BtnNext.TabIndex = 5
    Me.BtnNext.TabStop = False
    Me.BtnNext.Text = "&Next"
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(286, 15)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(44, 24)
    Me.BtnFind.TabIndex = 4
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(107, 15)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(173, 20)
    Me.TxtPos.TabIndex = 2
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(12, 29)
    Me.TxtYear.MaxLength = 6
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 221
    Me.TxtYear.TabStop = False
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(12, 9)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 220
    Me.Label29.Text = "Year"
    '
    'FrmTAD06B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(699, 396)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTAD06B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD06B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkCheckYear As Integer
    Dim WrkIsPosted As Boolean
    myTXCOOA = New TXCOOA.MyData(myDBConnect)
    myTXCOOAL1 = New TXCOOAL1.MyData(myDBConnect)
    WrkCheckYear = Date.Now.Year - 1
    WrkIsPosted = myTXCOOA.GetIsPosted(WrkCheckYear)
    If WrkIsPosted Then
      TxtYear.Text = WrkCheckYear
    Else
      WrkCheckYear = Date.Now.Year - 2
      WrkIsPosted = myTXCOOA.GetIsPosted(WrkCheckYear)
      If WrkIsPosted Then
        TxtYear.Text = WrkCheckYear
      End If
    End If

    CboSort.Items.Clear()
    CboSort.Items.Add("Owner's Name")
    CboSort.Items.Add("Second Name")
    CboSort.SelectedItem = "Owner's Name"
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
      .Columns(1).HeaderText = "Dev Lot"
      .Columns(1).Width = 40
    End With

    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name"
        GridName()
      Case "Second Name"
        GridSname()
    End Select

  End Sub
  Public Sub ShowGrid()
    Dim WrkPos As String
    WrkPos = Replace(TxtPos.Text, "'", "''")
    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name"
        ds = myTXCOOAL1.GetViewbyName(MyUtils.CnvSng(TxtYear.Text), WrkPos, cMaxRecs)
      Case "Second Name"
        ds = myTXCOOAL1.GetViewbySName(MyUtils.CnvSng(TxtYear.Text), WrkPos, cMaxRecs)
    End Select
    DataGrdView.DataSource = Nothing
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmTAD06B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD06.SbpScreen.Text = "TAD06B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub GridName()
    With DataGrdView
      .Columns(2).HeaderText = "Owner Name"
      .Columns(2).Width = 220
      .Columns(3).HeaderText = "Second Name"
      .Columns(3).Width = 200
      .Columns(4).HeaderText = ""
      .Columns(4).Width = 80
    End With
  End Sub
  Private Sub GridSname()
    With DataGrdView
      .Columns(2).HeaderText = "Second Name"
      .Columns(2).Width = 220
      .Columns(3).HeaderText = "Owner Name"
      .Columns(3).Width = 200
      .Columns(4).HeaderText = ""
      .Columns(4).Width = 80
    End With
  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    If TxtListNo.Text = "" Then Exit Sub

    MyFrmTAD06C = New FrmTAD06C
    MyFrmTAD06C.MdiParent = Me.ParentForm
    MyFrmTAD06C.WrkListNo = TxtListNo.Text
    MyFrmTAD06C.WrkDevlt = TxtDevlt.Text
    MyFrmTAD06C.Show()
    TxtListNo.Text = ""
    Me.Hide()

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    TxtPos.Text = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    FormatGrid()
    TxtPos.Text = ""
  End Sub
  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged

    Select Case CboSort.SelectedItem.ToString
      Case "Owner's Name", "Second Name"
        FormatGrid()
      Case Else
    End Select
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTAD06C = New FrmTAD06C
    MyFrmTAD06C.MdiParent = Me.ParentForm
    MyFrmTAD06C.WrkListNo = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmTAD06C.WrkDevlt = DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value
    MyFrmTAD06C.WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyFrmTAD06C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    If (e.ColumnIndex = 4) Then
      Temp = DataGrdView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
      Select Case Temp
        Case "E"
          e.Value = "Elderly"
        Case "N"
          e.Value = "Construction"
        Case "T"
          e.Value = "Taxable"
        Case "V"
          e.Value = "Veteran"
        Case Else
      End Select
    End If
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
End Class






