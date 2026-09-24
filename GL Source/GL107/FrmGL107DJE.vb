Public Class FrmGL107DJE
  Inherits System.Windows.Forms.Form
  Dim myLEDGERJE As LEDGERJE.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData

  Friend WrkDate As Date
  Friend WrkBchno As Integer
  Friend WrkTran As Integer
  Friend WithEvents LblTran As System.Windows.Forms.Label
  Friend WithEvents LblDate As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblDebit As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Dim WrkCredit As Decimal
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents LblBatch As Label
  Friend WithEvents Label10 As Label
  Dim WrkDebit As Decimal

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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblTran = New System.Windows.Forms.Label()
    Me.LblDate = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblDebit = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(103, 13)
    Me.Label2.TabIndex = 341
    Me.Label2.Text = "Transaction Number"
    '
    'LblTran
    '
    Me.LblTran.AutoSize = True
    Me.LblTran.Location = New System.Drawing.Point(117, 9)
    Me.LblTran.Name = "LblTran"
    Me.LblTran.Size = New System.Drawing.Size(41, 13)
    Me.LblTran.TabIndex = 342
    Me.LblTran.Text = "<Tran>"
    '
    'LblDate
    '
    Me.LblDate.Location = New System.Drawing.Point(356, 9)
    Me.LblDate.Name = "LblDate"
    Me.LblDate.Size = New System.Drawing.Size(85, 18)
    Me.LblDate.TabIndex = 348
    Me.LblDate.Text = "<Post Date>"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(292, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 16)
    Me.Label7.TabIndex = 347
    Me.Label7.Text = "Post Date"
    '
    'LblDebit
    '
    Me.LblDebit.BackColor = System.Drawing.Color.Aqua
    Me.LblDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDebit.Location = New System.Drawing.Point(554, 11)
    Me.LblDebit.Name = "LblDebit"
    Me.LblDebit.Size = New System.Drawing.Size(89, 16)
    Me.LblDebit.TabIndex = 352
    Me.LblDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.Aqua
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(554, 27)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(89, 16)
    Me.LblCredit.TabIndex = 351
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(514, 27)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(34, 13)
    Me.Label30.TabIndex = 350
    Me.Label30.Text = "Credit"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(514, 14)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(32, 13)
    Me.Label29.TabIndex = 349
    Me.Label29.Text = "Debit"
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(11, 62)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(628, 317)
    Me.DataGrdView.TabIndex = 353
    '
    'LblBatch
    '
    Me.LblBatch.Location = New System.Drawing.Point(356, 24)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(85, 16)
    Me.LblBatch.TabIndex = 357
    Me.LblBatch.Text = "<Batch>"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(292, 24)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(56, 16)
    Me.Label10.TabIndex = 356
    Me.Label10.Text = "Batch"
    '
    'FrmGL107DJE
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(651, 391)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblDebit)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.LblDate)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblTran)
    Me.Controls.Add(Me.Label2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL107DJE"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL107DJE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim ds As DataSet = New DataSet
    Dim WrkDBDate As Integer

    If MyIsLedger Then
      myLEDGERJE = New LEDGERJE.MyData()
      myLEDGERJE.MyDBConn = myDBConnect
    Else
      myLEDHSTL1 = New LEDHSTL1.MyData()
      myLEDHSTL1.MyDBConn = myDBConnect
    End If

    LblTran.Text = ""
    LblDate.Text = ""
    WrkCredit = 0
    WrkDebit = 0
    WrkDBDate = MyUtils.SetDBDate(WrkDate)
    If MyIsLedger Then
      ds = myLEDGERJE.GetTran(WrkDBDate, WrkBchno, WrkTran, 999)
    Else
      ds = myLEDHSTL1.GetTran(WrkDBDate, WrkBchno, WrkTran, 999)
    End If
    If ds.Tables(0).Rows.Count = 0 Then Exit Sub

    With ds.Tables(0).Rows(0)
      LblTran.Text = WrkTran
      LblDate.Text = WrkDate
      LblBatch.Text = .Item("bchno")
    End With
    RefreshDs(ds)
    FormatGrid(ds)
    LblCredit.Text = Format(WrkCredit, "N")
    LblDebit.Text = Format(WrkDebit, "N")
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
      For I = 0 To 5
        .Columns(I).Visible = False
      Next
      .Columns(6).HeaderText = "Acct"
      .Columns(6).Width = 160
      .Columns(7).HeaderText = "Debit"
      .Columns(7).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(7).Width = 75
      .Columns(8).HeaderText = "Credit"
      .Columns(8).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(8).Width = 75
      .Columns(9).HeaderText = "Acct Descr"
      .Columns(9).Width = 200
      .Columns(10).HeaderText = "Descr"
      .Columns(10).Width = 200
      .Columns(11).HeaderText = "Batch"
      .Columns(11).Width = 50
      .Columns(12).HeaderText = "User"
      .Columns(12).Width = 90
    End With
  End Sub
  Private Sub FrmGL107DJE_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL107C.Show()
  End Sub
  Private Sub FrmGL107DJE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL107.SbpScreen.Text = "GL107DJE"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmGL107
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub RefreshDs(ByRef ds As DataSet)
    Dim I As Integer

    For I = 0 To (ds.Tables(0).Rows.Count - 1)
      With ds.Tables(0).Rows(I)
        .Item("descr") = GetGLACCTDesc(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"), .Item("obnbr"), .Item("fnpgm"), .Item("subfn"))
        WrkCredit = WrkCredit + .Item("credit")
        WrkDebit = WrkDebit + .Item("debit")
      End With
    Next
  End Sub
End Class
