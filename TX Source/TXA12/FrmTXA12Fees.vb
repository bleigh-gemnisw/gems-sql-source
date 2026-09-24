Public Class FrmTXA12Fees
 Inherits System.Windows.Forms.Form
 Friend WrkListNo As Integer
 Friend WrkYear As Integer
 Friend WrkType As String
 Friend WrkCode1 As String
 Friend WrkCode2 As String
 Friend WrkCode3 As String
 Friend WrkCode4 As String
 Friend WrkCode5 As String
 Friend WrkAmt1 As Decimal
 Friend WrkAmt2 As Decimal
 Friend WrkAmt3 As Decimal
 Friend WrkAmt4 As Decimal
 Friend WrkAmt5 As Decimal
 Friend WrkMVFee As Decimal
 Friend WithEvents LblName As System.Windows.Forms.Label
 Friend WithEvents Label7 As System.Windows.Forms.Label
 Friend WithEvents LblType As System.Windows.Forms.Label
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents LblYear As System.Windows.Forms.Label
 Friend WithEvents LblList As System.Windows.Forms.Label
 Friend WithEvents Label5 As System.Windows.Forms.Label
 Friend WithEvents Label8 As System.Windows.Forms.Label
 Dim ds As DataSet = New DataSet
 Dim myTXPEN As TXPEN.myData
 Dim WrkCodes(4) As String
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
 Dim WrkAmts(4) As Decimal

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
 Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
 Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
 <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblName = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblList = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(104, 23)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(216, 16)
    Me.LblName.TabIndex = 170
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Location = New System.Drawing.Point(120, 3)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(32, 13)
    Me.Label7.TabIndex = 169
    Me.Label7.Text = "Type"
    '
    'LblType
    '
    Me.LblType.BackColor = System.Drawing.SystemColors.Control
    Me.LblType.Location = New System.Drawing.Point(156, 3)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(16, 16)
    Me.LblType.TabIndex = 168
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.SystemColors.Control
    Me.Label3.Location = New System.Drawing.Point(180, 3)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 12)
    Me.Label3.TabIndex = 167
    Me.Label3.Text = "Year"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.SystemColors.Control
    Me.LblYear.Location = New System.Drawing.Point(212, 3)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(48, 16)
    Me.LblYear.TabIndex = 166
    '
    'LblList
    '
    Me.LblList.BackColor = System.Drawing.SystemColors.Control
    Me.LblList.Location = New System.Drawing.Point(57, 3)
    Me.LblList.Name = "LblList"
    Me.LblList.Size = New System.Drawing.Size(48, 16)
    Me.LblList.TabIndex = 165
    '
    'Label5
    '
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Location = New System.Drawing.Point(12, 23)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(84, 12)
    Me.Label5.TabIndex = 164
    Me.Label5.Text = "Name of Owner"
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Location = New System.Drawing.Point(12, 3)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(36, 12)
    Me.Label8.TabIndex = 163
    Me.Label8.Text = "List #"
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
    Me.DataGrdView.Location = New System.Drawing.Point(12, 44)
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
    Me.DataGrdView.Size = New System.Drawing.Size(369, 138)
    Me.DataGrdView.TabIndex = 171
    '
    'FrmTXA12Fees
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(393, 194)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblList)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label8)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA12Fees"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Fee Codes/Amounts"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub

#End Region

 Private Sub FrmTXA09Fees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  myTXPEN = New TXPEN.mydata(MyDBConnect)
  LblList.Text = WrkListNo
  LblYear.Text = WrkYear
  LblType.Text = WrkType
  LblName.Text = MyFrmTXA12C.LblToName.Text
  WrkCodes(0) = WrkCode1
  WrkCodes(1) = WrkCode2
  WrkCodes(2) = WrkCode3
  WrkCodes(3) = WrkCode4
  WrkCodes(4) = WrkCode5
  WrkAmts(0) = WrkAmt1
  WrkAmts(1) = WrkAmt2
  WrkAmts(2) = WrkAmt3
  WrkAmts(3) = WrkAmt4
  WrkAmts(4) = WrkAmt5
  BuildDS()
  CreateGrid()

 End Sub

 Private Sub FrmTXA09Fees_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  myTXPEN.CloseFile()
  MyFrmTXA12C.Show()

 End Sub
 Private Sub FrmTXA09Fees_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA12.SbpScreen.Text = "TXA12Fees"
  MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub
 Private Sub BuildDS()
  Dim myTable As New DataTable
  With myTable
   .TableName = "mytable"
   .Columns.Add("Code", Type.GetType("System.String"))
   .Columns.Add("Descr", Type.GetType("System.String"))
   .Columns.Add("Amount", Type.GetType("System.Decimal"))
   .Columns.Add("Pay", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub CreateGrid()
 Dim myDr As Data.DataRow
 Dim WrkPay As Decimal
 Dim I As Integer

 WrkPay = MyUtils.CnvSng(MyFrmTXA12C.LblTransferFee.Text)
 If WrkMVFee > 0 Then
  myDr = ds.Tables(0).NewRow
  myDr("Code") = "MV"
  myTXPEN.GetOneRecordP("MV")
  If Not myTXPEN.RecordNotFound Then
   myDr("Descr") = Trim(myTXPEN._PNDESC)
  Else
   myDr("Descr") = String.Empty
  End If
  myDr("Amount") = WrkMVFee
  If WrkPay >= WrkMVFee Then
    myDr("Pay") = WrkMVFee
    WrkPay = WrkPay - WrkMVFee
  Else
    myDr("Pay") = WrkPay
    WrkPay = 0
  End If
  ds.Tables(0).Rows.Add(myDr)
 End If

 For I = 0 To 4
  If WrkCodes(I) = String.Empty Then Exit For
  myDr = ds.Tables(0).NewRow
  myDr("Code") = WrkCodes(I)
  myTXPEN.GetOneRecordP(WrkCodes(I))
  If Not myTXPEN.RecordNotFound Then
   myDr("Descr") = Trim(myTXPEN._PNDESC)
  Else
   myDr("Descr") = String.Empty
  End If
  myDr("Amount") = WrkAmts(I)
  If WrkPay >= WrkAmts(I) Then
    myDr("Pay") = WrkAmts(I)
    WrkPay = WrkPay - WrkAmts(I)
  Else
    myDr("Pay") = WrkPay
    WrkPay = 0
  End If
  ds.Tables(0).Rows.Add(myDr)
 Next

 With DataGrdView
  .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
  .RowHeadersWidth = 25
  .DataSource = ds.Tables(0)
  .Refresh()
  .Columns(0).HeaderText = "Code"
  .Columns(0).Width = 40
  .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
  .Columns(1).HeaderText = "Description"
  .Columns(1).Width = 190
  .Columns(2).HeaderText = "Amount"
  .Columns(2).Width = 50
  .Columns(3).HeaderText = "Pay"
  .Columns(3).Width = 50
 End With

 Windows.Forms.Cursor.Current = Cursors.Default

End Sub
 End Class






