Public Class FrmTO301B

  Inherits System.Windows.Forms.Form
  Dim myTXVEH As TXVEH.MyData
  Dim myTXVEHL1 As TXVEHL1.MyData
  Dim myTXVEHL2 As TXVEHL2.MyData
  Dim myTXVEHL3 As TXVEHL3.MyData
  Dim myTXVEHL4 As TXVEHL4.MyData
  Dim ds As DataSet = New DataSet
  'General
  Dim WrkAnd As String
  Friend WithEvents BtnFind As System.Windows.Forms.Button
  Friend WithEvents TxtPos As System.Windows.Forms.TextBox
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnFast As System.Windows.Forms.Button
  Friend WithEvents TxtVehID As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents CboSort As ComboBox
  Friend WithEvents Label2 As Label
  Dim WrkOr As String


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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO301B))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.BtnFind = New System.Windows.Forms.Button()
    Me.TxtPos = New System.Windows.Forms.TextBox()
    Me.label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.BtnFast = New System.Windows.Forms.Button()
    Me.TxtVehID = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.CboSort = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox2.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    Me.ImageList1.Images.SetKeyName(1, "select type_24.png")
    '
    'BtnFind
    '
    Me.BtnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFind.Location = New System.Drawing.Point(203, 2)
    Me.BtnFind.Name = "BtnFind"
    Me.BtnFind.Size = New System.Drawing.Size(44, 24)
    Me.BtnFind.TabIndex = 9
    Me.BtnFind.TabStop = False
    Me.BtnFind.Text = "&Find"
    '
    'TxtPos
    '
    Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPos.Location = New System.Drawing.Point(82, 6)
    Me.TxtPos.MaxLength = 25
    Me.TxtPos.Name = "TxtPos"
    Me.TxtPos.Size = New System.Drawing.Size(115, 20)
    Me.TxtPos.TabIndex = 12
    '
    'label1
    '
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.Location = New System.Drawing.Point(12, 9)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(64, 17)
    Me.label1.TabIndex = 10
    Me.label1.Text = "Position to"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BtnFast)
    Me.GroupBox2.Controls.Add(Me.TxtVehID)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(449, 6)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(147, 49)
    Me.GroupBox2.TabIndex = 27
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Fast Path-VehicleID"
    '
    'BtnFast
    '
    Me.BtnFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnFast.Location = New System.Drawing.Point(81, 19)
    Me.BtnFast.Name = "BtnFast"
    Me.BtnFast.Size = New System.Drawing.Size(53, 24)
    Me.BtnFast.TabIndex = 3
    Me.BtnFast.Text = "S&how"
    '
    'TxtVehID
    '
    Me.TxtVehID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVehID.Location = New System.Drawing.Point(11, 22)
    Me.TxtVehID.MaxLength = 9
    Me.TxtVehID.Name = "TxtVehID"
    Me.TxtVehID.Size = New System.Drawing.Size(64, 20)
    Me.TxtVehID.TabIndex = 1
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 57)
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
    Me.DataGrdView.Size = New System.Drawing.Size(584, 352)
    Me.DataGrdView.TabIndex = 430
    '
    'CboSort
    '
    Me.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboSort.FormattingEnabled = True
    Me.CboSort.Location = New System.Drawing.Point(82, 33)
    Me.CboSort.Name = "CboSort"
    Me.CboSort.Size = New System.Drawing.Size(124, 21)
    Me.CboSort.TabIndex = 431
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(12, 36)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 17)
    Me.Label2.TabIndex = 432
    Me.Label2.Text = "Sort By"
    '
    'FrmTO301B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(608, 421)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.CboSort)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.BtnFind)
    Me.Controls.Add(Me.TxtPos)
    Me.Controls.Add(Me.label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO301B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Select"
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO301B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXVEHL1 = New TXVEHL1.MyData(myDBConnect)
    myTXVEHL2 = New TXVEHL2.MyData(myDBConnect)
    myTXVEHL3 = New TXVEHL3.MyData(myDBConnect)
    myTXVEHL4 = New TXVEHL4.MyData(myDBConnect)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    MyFrmTO301.TBarDelete.Enabled = False
    CboSort.Items.Clear()
    CboSort.Items.Add("CustID Primary")
    CboSort.Items.Add("CustID Secondary")
    CboSort.Items.Add("Reg No")
    CboSort.Items.Add("Vin No")
    CboSort.SelectedItem = "CustID Primary"
    Call FormatGrid()
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      If CboSort.SelectedItem.ToString = "CustID Primary" Then
        .Columns(0).Visible = False
      Else
        .Columns(0).HeaderText = "Pri CustID"
        .Columns(0).Width = 70
      End If
      If CboSort.SelectedItem.ToString = "CustID Secondary" Then
        .Columns(1).Visible = False
      Else
        .Columns(1).HeaderText = "Sec CustID"
        .Columns(1).Width = 70
      End If
      .Columns(2).HeaderText = "Reg No"
      .Columns(2).Width = 70
      .Columns(3).HeaderText = "Vin No"
      .Columns(3).Width = 125
      .Columns(4).HeaderText = "Reg ID"
      .Columns(4).Width = 70
      .Columns(5).HeaderText = "Veh ID"
      .Columns(5).Width = 70
      .Columns(6).HeaderText = "Lease?"
      .Columns(6).Width = 60
      .Columns(7).HeaderText = "Chg Date"
      .Columns(7).DefaultCellStyle.Format = "##/##/####"
      .Columns(7).Width = 65
    End With
  End Sub
  Public Sub ShowGrid()
    Dim WrkMaxRecs As Integer

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    WrkMaxRecs = 50
    Select Case CboSort.SelectedItem.ToString
      Case "CustID Primary"
        ds = myTXVEHL2.GetViewbyPcust(MyUtils.CnvSng(TxtPos.Text), 99999999, WrkMaxRecs)
      Case "CustID Secondary"
        ds = myTXVEHL3.GetViewbyScust(MyUtils.CnvSng(TxtPos.Text), 99999999, WrkMaxRecs)
      Case "Reg No"
        ds = myTXVEHL1.GetViewRegNo(TxtPos.Text, WrkMaxRecs)
      Case "Vin No"
        ds = myTXVEHL4.GetViewVinno(TxtPos.Text, WrkMaxRecs)
    End Select
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub FrmTO301B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO301.SbpScreen.Text = "TO301B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub BtnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFind.Click
    Call FormatGrid()
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    MyFrmTO301C = New FrmTO301C
    MyFrmTO301C.WrkVehID = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
    MyFrmTO301C.MdiParent = Me.ParentForm
    MyFrmTO301C.Show()
    Me.Hide()
  End Sub
  Private Sub TxtPos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPos.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      Call FormatGrid()
    End If
  End Sub
  Private Sub TxtVehID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVehID.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ShowFastPath()
      Exit Sub
    End If

    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub BtnFast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFast.Click
    ShowFastPath()
  End Sub
  Private Sub ShowFastPath()
    If TxtVehID.Text = "" Then Exit Sub

    MyFrmTO301C = New FrmTO301C
    MyFrmTO301C.MdiParent = Me.ParentForm
    MyFrmTO301C.WrkVehID = TxtVehID.Text
    MyFrmTO301C.Show()
    TxtVehID.Text = ""
    Me.Hide()

  End Sub
  Private Sub CboSort_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboSort.SelectedValueChanged
    DataGrdView.DataSource = Nothing
    DataGrdView.Refresh()
  End Sub
End Class
