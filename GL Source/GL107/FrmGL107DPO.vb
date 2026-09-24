Public Class FrmGL107DPO

  Inherits System.Windows.Forms.Form
  Dim myLEDGERPO As LEDGERPO.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData

  Friend WrkDate As Date
  Friend WrkPonbr As Integer
  Friend WithEvents LblPOHdr As System.Windows.Forms.Label
  Friend WithEvents LblPONbr As System.Windows.Forms.Label
  Friend WithEvents LblUser As System.Windows.Forms.Label
  Friend WithEvents LblDate As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblBatch As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView

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
  Friend WithEvents LblVendor As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.LblVendor = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblPOHdr = New System.Windows.Forms.Label()
    Me.LblPONbr = New System.Windows.Forms.Label()
    Me.LblUser = New System.Windows.Forms.Label()
    Me.LblDate = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LblVendor
    '
    Me.LblVendor.AutoSize = True
    Me.LblVendor.Location = New System.Drawing.Point(72, 27)
    Me.LblVendor.Name = "LblVendor"
    Me.LblVendor.Size = New System.Drawing.Size(53, 13)
    Me.LblVendor.TabIndex = 321
    Me.LblVendor.Text = "<Vendor>"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(8, 27)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(41, 13)
    Me.Label1.TabIndex = 320
    Me.Label1.Text = "Vendor"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblPOHdr
    '
    Me.LblPOHdr.AutoSize = True
    Me.LblPOHdr.Location = New System.Drawing.Point(8, 43)
    Me.LblPOHdr.Name = "LblPOHdr"
    Me.LblPOHdr.Size = New System.Drawing.Size(39, 13)
    Me.LblPOHdr.TabIndex = 338
    Me.LblPOHdr.Text = "PO No"
    '
    'LblPONbr
    '
    Me.LblPONbr.AutoSize = True
    Me.LblPONbr.Location = New System.Drawing.Point(72, 43)
    Me.LblPONbr.Name = "LblPONbr"
    Me.LblPONbr.Size = New System.Drawing.Size(49, 13)
    Me.LblPONbr.TabIndex = 343
    Me.LblPONbr.Text = "<POnbr>"
    '
    'LblUser
    '
    Me.LblUser.AutoSize = True
    Me.LblUser.Location = New System.Drawing.Point(356, 43)
    Me.LblUser.Name = "LblUser"
    Me.LblUser.Size = New System.Drawing.Size(41, 13)
    Me.LblUser.TabIndex = 349
    Me.LblUser.Text = "<User>"
    '
    'LblDate
    '
    Me.LblDate.AutoSize = True
    Me.LblDate.Location = New System.Drawing.Point(356, 9)
    Me.LblDate.Name = "LblDate"
    Me.LblDate.Size = New System.Drawing.Size(66, 13)
    Me.LblDate.TabIndex = 348
    Me.LblDate.Text = "<Post Date>"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(292, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(54, 13)
    Me.Label7.TabIndex = 347
    Me.Label7.Text = "Post Date"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(292, 43)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(29, 13)
    Me.Label8.TabIndex = 346
    Me.Label8.Text = "User"
    '
    'LblBatch
    '
    Me.LblBatch.AutoSize = True
    Me.LblBatch.Location = New System.Drawing.Point(356, 27)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(47, 13)
    Me.LblBatch.TabIndex = 345
    Me.LblBatch.Text = "<Batch>"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(292, 27)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(35, 13)
    Me.Label10.TabIndex = 344
    Me.Label10.Text = "Batch"
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
    Me.DataGrdView.Location = New System.Drawing.Point(11, 62)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(628, 317)
    Me.DataGrdView.TabIndex = 350
    '
    'FrmGL107DPO
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(651, 391)
    Me.ControlBox = False
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblUser)
    Me.Controls.Add(Me.LblDate)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblPONbr)
    Me.Controls.Add(Me.LblPOHdr)
    Me.Controls.Add(Me.LblVendor)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL107DPO"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL107DPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim ds As DataSet = New DataSet
    Dim WrkDBDate As Integer
    If MyIsLedger Then
      myLEDGERPO = New LEDGERPO.MyData()
      myLEDGERPO.MyDBConn = myDBConnect
    Else
      myLEDHSTL1 = New LEDHSTL1.MyData()
      myLEDHSTL1.MyDBConn = myDBConnect
    End If

    WrkDBDate = MyUtils.SetDBDate(WrkDate)
    If MyIsLedger Then
      ds = myLEDGERPO.GetPO(WrkDBDate, 0, WrkPonbr, 999)
    Else
      ds = myLEDHSTL1.GetPO(WrkDBDate, 0, WrkPonbr, 999)
    End If

    If ds.Tables(0).Rows.Count = 0 Then Exit Sub

    With ds.Tables(0).Rows(0)
      '    LblInvoice.Text = WrkInvoice
      LblDate.Text = WrkDate
      LblVendor.Text = .Item("vendor")
      LblBatch.Text = .Item("batch")
      If .Item("po") = 0 Then
        LblPOHdr.Visible = False
        LblPONbr.Visible = False
      Else
        LblPONbr.Text = .Item("po")
      End If
      LblUser.Text = .Item("user")
    End With
    RefreshDs(ds)
    FormatGrid(ds)
  End Sub
  Public Sub FormatGrid(ByVal ds As DataSet)
    Dim I As Integer
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersVisible = False
      .DefaultCellStyle.SelectionBackColor = DataGrdView.DefaultCellStyle.BackColor
      .DefaultCellStyle.SelectionForeColor = DataGrdView.DefaultCellStyle.ForeColor
      For I = 0 To 9
        .Columns(I).Visible = False
      Next
      .Columns(10).HeaderText = "Acct"
      .Columns(10).Width = 160
      .Columns(11).HeaderText = "Credit"
      .Columns(11).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(11).Width = 85
      .Columns(12).HeaderText = "Debit"
      .Columns(12).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(12).Width = 85
      .Columns(13).HeaderText = "Acct Descr"
      .Columns(13).Width = 250
      .Columns(14).Visible = False
      .Columns(15).Visible = False
    End With
  End Sub
  Private Sub FrmGL107DPO_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL107C.Show()
  End Sub
  Private Sub FrmGL107DPO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL107.SbpScreen.Text = "GL107DPO"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmGL107
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub RefreshDs(ByRef ds As DataSet)
    Dim I As Integer
    Dim WrkAcct As String

    For I = 0 To (ds.Tables(0).Rows.Count - 1)
      With ds.Tables(0).Rows(I)
        WrkAcct = BuildAcct(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"), .Item("obnbr"), .Item("fnpgm"), .Item("subfn"))
        .Item("acct") = WrkAcct
        .Item("descr") = GetGLACCTDesc(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"), .Item("obnbr"), .Item("fnpgm"), .Item("subfn"))
      End With
    Next
  End Sub
End Class
