Public Class FrmGL107DAR
  Inherits System.Windows.Forms.Form
  Dim myLEDGERAR As LEDGERAR.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData

  Friend WrkDate As Date
  Friend WrkBchno As Integer
  Friend WrkTramt As Decimal
  Friend WrkTdesc As String
  Friend WrkRefno As Integer
  Friend WrkPrf As String
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblTdesc As System.Windows.Forms.Label
  Friend WithEvents LblRefno As System.Windows.Forms.Label
  Friend WithEvents LblUser As System.Windows.Forms.Label
  Friend WithEvents LblDate As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents LblBatch As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents LblDebit As Label
  Friend WithEvents LblCredit As Label
  Friend WithEvents Label30 As Label
  Friend WithEvents Label29 As Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Dim WrkCredit As Decimal
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblTdesc = New System.Windows.Forms.Label()
    Me.LblRefno = New System.Windows.Forms.Label()
    Me.LblUser = New System.Windows.Forms.Label()
    Me.LblDate = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.LblBatch = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.LblDebit = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 27)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(69, 16)
    Me.Label3.TabIndex = 338
    Me.Label3.Text = "Reference"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 18)
    Me.Label2.TabIndex = 341
    Me.Label2.Text = "Description"
    '
    'LblTdesc
    '
    Me.LblTdesc.Location = New System.Drawing.Point(83, 9)
    Me.LblTdesc.Name = "LblTdesc"
    Me.LblTdesc.Size = New System.Drawing.Size(203, 18)
    Me.LblTdesc.TabIndex = 342
    Me.LblTdesc.Text = "<Description>"
    '
    'LblRefno
    '
    Me.LblRefno.Location = New System.Drawing.Point(83, 27)
    Me.LblRefno.Name = "LblRefno"
    Me.LblRefno.Size = New System.Drawing.Size(203, 16)
    Me.LblRefno.TabIndex = 343
    Me.LblRefno.Text = "<Refno>"
    '
    'LblUser
    '
    Me.LblUser.Location = New System.Drawing.Point(367, 43)
    Me.LblUser.Name = "LblUser"
    Me.LblUser.Size = New System.Drawing.Size(96, 16)
    Me.LblUser.TabIndex = 349
    Me.LblUser.Text = "<User>"
    '
    'LblDate
    '
    Me.LblDate.Location = New System.Drawing.Point(367, 9)
    Me.LblDate.Name = "LblDate"
    Me.LblDate.Size = New System.Drawing.Size(85, 18)
    Me.LblDate.TabIndex = 348
    Me.LblDate.Text = "<Post Date>"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(303, 9)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 16)
    Me.Label7.TabIndex = 347
    Me.Label7.Text = "Post Date"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(303, 43)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 346
    Me.Label8.Text = "User"
    '
    'LblBatch
    '
    Me.LblBatch.Location = New System.Drawing.Point(367, 27)
    Me.LblBatch.Name = "LblBatch"
    Me.LblBatch.Size = New System.Drawing.Size(85, 16)
    Me.LblBatch.TabIndex = 345
    Me.LblBatch.Text = "<Batch>"
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(303, 27)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(56, 16)
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
    Me.DataGrdView.TabIndex = 351
    '
    'LblDebit
    '
    Me.LblDebit.BackColor = System.Drawing.Color.Aqua
    Me.LblDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDebit.Location = New System.Drawing.Point(549, 11)
    Me.LblDebit.Name = "LblDebit"
    Me.LblDebit.Size = New System.Drawing.Size(89, 16)
    Me.LblDebit.TabIndex = 356
    Me.LblDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.Aqua
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(549, 27)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(89, 16)
    Me.LblCredit.TabIndex = 355
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(509, 27)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(34, 13)
    Me.Label30.TabIndex = 354
    Me.Label30.Text = "Credit"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(509, 14)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(32, 13)
    Me.Label29.TabIndex = 353
    Me.Label29.Text = "Debit"
    '
    'FrmGL107DAR
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(651, 391)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblDebit)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblUser)
    Me.Controls.Add(Me.LblDate)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.LblBatch)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.LblRefno)
    Me.Controls.Add(Me.LblTdesc)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL107DAR"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL107DAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim ds As DataSet = New DataSet
    Dim WrkDBDate As Integer
    If MyIsLedger Then
      myLEDGERAR = New LEDGERAR.MyData()
      myLEDGERAR.MyDBConn = myDBConnect
    Else
      myLEDHSTL1 = New LEDHSTL1.MyData()
      myLEDHSTL1.MyDBConn = myDBConnect
    End If

    WrkCredit = 0
    WrkDebit = 0
    WrkTramt = Math.Abs(WrkTramt)
    WrkDBDate = MyUtils.SetDBDate(WrkDate)
    If MyIsLedger Then
      ds = myLEDGERAR.GetRef(WrkDBDate, WrkBchno, WrkTramt, WrkTdesc, WrkRefno, WrkPrf, 999)
    Else
      ds = myLEDHSTL1.GetRef(WrkDBDate, WrkBchno, WrkTramt, WrkTdesc, WrkRefno, WrkPrf, 999)
    End If
    If ds.Tables(0).Rows.Count = 0 Then Exit Sub

    With ds.Tables(0).Rows(0)
      LblTdesc.Text = WrkTdesc
      LblDate.Text = WrkDate
      LblBatch.Text = WrkBchno
      LblRefno.Text = WrkRefno
      LblUser.Text = WrkPrf
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
      For I = 0 To 9
        .Columns(I).Visible = False
      Next
      .Columns(10).HeaderText = "Acct"
      .Columns(10).Width = 170
      .Columns(11).HeaderText = "Debit"
      .Columns(11).Width = 80
      .Columns(11).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(12).HeaderText = "Credit"
      .Columns(12).Width = 80
      .Columns(12).DefaultCellStyle.Format = "N2" 'Fixed 2 decimal
      .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns(13).HeaderText = "Acct Descr"
      .Columns(13).Width = 250
    End With
  End Sub
  Private Sub FrmGL107DAR_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL107C.Show()
  End Sub
  Private Sub FrmGL107DAR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL107.SbpScreen.Text = "GL107DAR"
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
        WrkCredit = WrkCredit + MyUtils.CnvSng(.Item("credit") & "")
        WrkDebit = WrkDebit + MyUtils.CnvSng(.Item("debit") & "")
      End With
    Next
  End Sub
End Class
