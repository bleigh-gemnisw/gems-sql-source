Imports System.Data
Public Class FrmAP101B
  Inherits System.Windows.Forms.Form
 Dim myVENDOR As VENDOR.MyData
  Dim myVENDORL1 As VENDORL1.MyData
  Dim wrktxtpos As String
  Dim ds As DataSet = New DataSet
  Dim wrktogglescan As Boolean
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
 Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
 Friend WithEvents BtnShow As System.Windows.Forms.Button
 Friend WithEvents label2 As System.Windows.Forms.Label
 Friend WithEvents TxtVendor As System.Windows.Forms.TextBox
  Friend WithEvents RBOmit As RadioButton
  Friend WithEvents RBAll As RadioButton
  Friend WithEvents BtnScan As Button
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents Label3 As System.Windows.Forms.Label

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
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.groupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.TxtVendor = New System.Windows.Forms.TextBox()
    Me.RBOmit = New System.Windows.Forms.RadioButton()
    Me.RBAll = New System.Windows.Forms.RadioButton()
    Me.BtnScan = New System.Windows.Forms.Button()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.groupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'BtnFind
    '
    Me.BtnFind.Location = New System.Drawing.Point(152, 10)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(41, 24)
    Me.BtnFind.TabIndex = 6
    Me.BtnFind.Text = "&Find"
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(199, 10)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(42, 24)
    Me.BtnNext.TabIndex = 7
    Me.BtnNext.Text = "&Next"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(63, 13)
    Me.Label3.TabIndex = 201
    Me.Label3.Text = "Vendor Sort"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(78, 12)
    Me.TxtPos.MaxLength = 7
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(64, 22)
    Me.TxtPos.TabIndex = 0
    '
    'groupBox2
    '
    Me.groupBox2.Controls.Add(Me.BtnShow)
    Me.groupBox2.Controls.Add(Me.label2)
    Me.groupBox2.Controls.Add(Me.TxtVendor)
    Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.groupBox2.Location = New System.Drawing.Point(308, 2)
    Me.groupBox2.Name = "groupBox2"
    Me.groupBox2.Size = New System.Drawing.Size(193, 38)
    Me.groupBox2.TabIndex = 202
    Me.groupBox2.TabStop = False
    Me.groupBox2.Text = "Fast Path"
    '
    'BtnShow
    '
    Me.BtnShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnShow.Location = New System.Drawing.Point(125, 12)
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
    Me.label2.Location = New System.Drawing.Point(12, 17)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(51, 13)
    Me.label2.TabIndex = 6
    Me.label2.Text = "Vendor #"
    '
    'TxtVendor
    '
    Me.TxtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVendor.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVendor.Location = New System.Drawing.Point(64, 12)
    Me.TxtVendor.MaxLength = 6
    Me.TxtVendor.Name = "TxtVendor"
    Me.TxtVendor.Size = New System.Drawing.Size(55, 22)
    Me.TxtVendor.TabIndex = 0
    '
    'RBOmit
    '
    Me.RBOmit.AutoSize = True
    Me.RBOmit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RBOmit.Location = New System.Drawing.Point(152, 40)
    Me.RBOmit.Name = "RBOmit"
    Me.RBOmit.Size = New System.Drawing.Size(96, 17)
    Me.RBOmit.TabIndex = 208
    Me.RBOmit.Text = "Omit Suspense"
    Me.RBOmit.UseVisualStyleBackColor = True
    '
    'RBAll
    '
    Me.RBAll.AutoSize = True
    Me.RBAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RBAll.Checked = True
    Me.RBAll.Location = New System.Drawing.Point(78, 40)
    Me.RBAll.Name = "RBAll"
    Me.RBAll.Size = New System.Drawing.Size(39, 17)
    Me.RBAll.TabIndex = 209
    Me.RBAll.TabStop = True
    Me.RBAll.Text = "All "
    Me.RBAll.UseVisualStyleBackColor = True
    '
    'BtnScan
    '
    Me.BtnScan.Location = New System.Drawing.Point(247, 10)
    Me.BtnScan.Name = "BtnScan"
    Me.BtnScan.Size = New System.Drawing.Size(41, 24)
    Me.BtnScan.TabIndex = 210
    Me.BtnScan.Text = "S&can"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(12, 63)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(1195, 641)
    Me.DataGrdView.TabIndex = 352
    '
    'FrmAP101B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(1231, 716)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.BtnScan)
    Me.Controls.Add(Me.RBAll)
    Me.Controls.Add(Me.RBOmit)
    Me.Controls.Add(Me.groupBox2)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnFind)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmAP101B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.groupBox2.ResumeLayout(False)
    Me.groupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmAP101B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    wrktxtpos = ""
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myVENDORL1 = New VENDORL1.MyData()
    myVENDORL1.MyDBConn = myDBConnect
    If Date.Today.Month <= 6 Then
      myFromDate = "#7/1/" & Date.Today.Year - 1 & "#"
    Else
      myFromDate = "#7/1/" & Date.Today.Year & "#"
    End If
    myToDate = Date.Today
    wrktogglescan = False
    Call FormatGrid()

  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    wrktogglescan = False
    wrktxtpos = TxtPos.Text
    Call FormatGrid()
  End Sub

  Public Sub FormatGrid()
    If wrktogglescan = True Then
      Call ShowGridscan()
    Else
      Call ShowGrid()
    End If

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Width = 50
      .Columns(1).HeaderText = "Vendor"
      .Columns(1).Width = 250
      .Columns(2).HeaderText = "Addr 1"
      .Columns(2).Width = 200
      .Columns(3).HeaderText = "Addr 2"
      .Columns(3).Width = 175
      .Columns(4).HeaderText = "Addr 3"
      .Columns(4).Width = 175
      .Columns(5).HeaderText = "Addr 4"
      .Columns(5).Width = 175
      .Columns(6).HeaderText = "Sort"
      .Columns(6).Width = 60
      .Columns(7).HeaderText = "Susp"
      .Columns(7).Width = 40
    End With

  End Sub
  Public Sub ShowGrid()
    Dim WrkSusp As Boolean
    If RBAll.Checked Then
      WrkSusp = True
    Else
      WrkSusp = False
    End If
    'ds = myVENDORL1.GetViewSort(TxtPos.Text, WrkSusp, 100)
    ds = myVENDORL1.GetViewSort(wrktxtpos, WrkSusp, 100)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Public Sub ShowGridscan()
    Dim WrkSusp As Boolean
    If RBAll.Checked Then
      WrkSusp = True
    Else
      WrkSusp = False
    End If
    ' ds = myVENDORL1.GetViewbyNameScan(TxtPos.Text, WrkSusp, 100)
    ds = myVENDORL1.GetViewbyNameScan(wrktxtpos, WrkSusp, 100)
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Private Sub FrmAP101B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmAP101.SbpScreen.Text = "AP101B"
    MyUtils.CenterForm(Me.ParentForm, Me)

  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
    Dim I As Integer
    I = ds.Tables(0).Rows.Count - 1
    wrktxtpos = DataGrdView.Item(6, I).Value
    'TxtPos.Text = DataGrdView.Item(6, I).Value

    Call FormatGrid()
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmAP101C = New FrmAP101C
    MyFrmAP101C.MdiParent = Me.ParentForm
    MyFrmAP101C.WrkVndnr = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    MyFrmAP101C.Show()
    Me.Hide()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub

  Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    If TxtVendor.Text = "" Then Exit Sub

    myVENDOR.GetOneRecordP(TxtVendor.Text)
    If myVENDOR.RecordNotFound Then
      MsgBox("Vendor No not found", MsgBoxStyle.Exclamation, "Fast Path information is not valid")
      Exit Sub
    End If

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmAP101C = New FrmAP101C
    MyFrmAP101C.WrkVndnr = TxtVendor.Text
    MyFrmAP101C.MdiParent = Me.ParentForm
    MyFrmAP101C.Show()
    TxtPos.Text = ""
    wrktxtpos = ""
    TxtVendor.Text = ""
    Windows.Forms.Cursor.Current = Cursors.Default
    Me.Hide()

  End Sub

  Private Sub RBAll_Click(sender As Object, e As EventArgs) Handles RBAll.Click
    Call FormatGrid()
  End Sub
  Private Sub RBOmit_Click(sender As Object, e As EventArgs) Handles RBOmit.Click
    Call FormatGrid()
  End Sub
  Private Sub DataGrdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGrdView.CellFormatting
    Dim Temp As String
    Temp = DataGrdView.Rows(e.RowIndex).Cells(7).Value.ToString()
    Select Case Temp
      Case "S"
        DataGrdView.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Pink
      Case Else
    End Select
  End Sub

  Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
    wrktogglescan = True
    Call FormatGrid()
  End Sub
End Class
