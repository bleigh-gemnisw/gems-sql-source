Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

Public Class FrmFixB
  Inherits System.Windows.Forms.Form

  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL1 As TXHSTL1.MyData
  Dim myTXTYPE As TXTYPE.MyData

  Dim WrkList As Integer
  Dim WrkYear As Integer
  Dim WrkType As String
  Dim WrkRecId As Integer
  Dim TotalPamt As Decimal
  Dim Good As Boolean
  Friend WithEvents LblProperty2 As Label
  Friend WithEvents LblProperty As Label
  Friend WithEvents LblZip4 As Label
  Friend WithEvents LblZip5 As Label
  Friend WithEvents LblState As Label
  Friend WithEvents LblCity As Label
  Friend WithEvents LblAdd2 As Label
  Friend WithEvents LblAdd1 As Label
  Friend WithEvents LblSname As Label
  Friend WithEvents LblName As Label
  Friend WithEvents label37 As Label
  Friend WithEvents label10 As Label
  Friend WithEvents label9 As Label
  Friend WithEvents label8 As Label
  Friend WithEvents Label6 As Label
  Friend WithEvents DataGrdView As DataGridView
  Friend WithEvents Label11 As Label
  Friend WithEvents LblInvPaid As Label
  Friend WithEvents Label12 As Label
  Friend WithEvents LblHistPaid As Label
  Friend WithEvents ChkUpBal As CheckBox
  Friend WithEvents Label7 As Label
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
  '    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtDBName As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtType As System.Windows.Forms.TextBox
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents Label5 As Label
  Friend WithEvents TxtList As TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDBName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtType = New System.Windows.Forms.TextBox()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtList = New System.Windows.Forms.TextBox()
    Me.LblProperty2 = New System.Windows.Forms.Label()
    Me.LblProperty = New System.Windows.Forms.Label()
    Me.LblZip4 = New System.Windows.Forms.Label()
    Me.LblZip5 = New System.Windows.Forms.Label()
    Me.LblState = New System.Windows.Forms.Label()
    Me.LblCity = New System.Windows.Forms.Label()
    Me.LblAdd2 = New System.Windows.Forms.Label()
    Me.LblAdd1 = New System.Windows.Forms.Label()
    Me.LblSname = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.label37 = New System.Windows.Forms.Label()
    Me.label10 = New System.Windows.Forms.Label()
    Me.label9 = New System.Windows.Forms.Label()
    Me.label8 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblInvPaid = New System.Windows.Forms.Label()
    Me.LblHistPaid = New System.Windows.Forms.Label()
    Me.ChkUpBal = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 362)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(305, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Void History record, optionally update balance "
    '
    'TxtDBName
    '
    Me.TxtDBName.Location = New System.Drawing.Point(100, 23)
    Me.TxtDBName.Name = "TxtDBName"
    Me.TxtDBName.Size = New System.Drawing.Size(126, 20)
    Me.TxtDBName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 26)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Database name"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(43, 113)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(51, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "G/L Year"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(100, 110)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(39, 20)
    Me.TxtYear.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(63, 87)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 13)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "Type"
    '
    'TxtType
    '
    Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtType.Location = New System.Drawing.Point(100, 84)
    Me.TxtType.MaxLength = 1
    Me.TxtType.Name = "TxtType"
    Me.TxtType.Size = New System.Drawing.Size(22, 20)
    Me.TxtType.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(63, 57)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(30, 13)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "List#"
    '
    'TxtList
    '
    Me.TxtList.Location = New System.Drawing.Point(99, 54)
    Me.TxtList.MaxLength = 7
    Me.TxtList.Name = "TxtList"
    Me.TxtList.Size = New System.Drawing.Size(61, 20)
    Me.TxtList.TabIndex = 1
    '
    'LblProperty2
    '
    Me.LblProperty2.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty2.Location = New System.Drawing.Point(365, 143)
    Me.LblProperty2.Name = "LblProperty2"
    Me.LblProperty2.Size = New System.Drawing.Size(229, 25)
    Me.LblProperty2.TabIndex = 243
    '
    'LblProperty
    '
    Me.LblProperty.BackColor = System.Drawing.SystemColors.Control
    Me.LblProperty.Location = New System.Drawing.Point(365, 127)
    Me.LblProperty.Name = "LblProperty"
    Me.LblProperty.Size = New System.Drawing.Size(229, 16)
    Me.LblProperty.TabIndex = 242
    '
    'LblZip4
    '
    Me.LblZip4.BackColor = System.Drawing.SystemColors.Control
    Me.LblZip4.Location = New System.Drawing.Point(557, 103)
    Me.LblZip4.Name = "LblZip4"
    Me.LblZip4.Size = New System.Drawing.Size(36, 16)
    Me.LblZip4.TabIndex = 241
    '
    'LblZip5
    '
    Me.LblZip5.BackColor = System.Drawing.SystemColors.Control
    Me.LblZip5.Location = New System.Drawing.Point(517, 103)
    Me.LblZip5.Name = "LblZip5"
    Me.LblZip5.Size = New System.Drawing.Size(36, 16)
    Me.LblZip5.TabIndex = 240
    '
    'LblState
    '
    Me.LblState.BackColor = System.Drawing.SystemColors.Control
    Me.LblState.Location = New System.Drawing.Point(489, 103)
    Me.LblState.Name = "LblState"
    Me.LblState.Size = New System.Drawing.Size(24, 16)
    Me.LblState.TabIndex = 239
    '
    'LblCity
    '
    Me.LblCity.BackColor = System.Drawing.SystemColors.Control
    Me.LblCity.Location = New System.Drawing.Point(365, 103)
    Me.LblCity.Name = "LblCity"
    Me.LblCity.Size = New System.Drawing.Size(146, 16)
    Me.LblCity.TabIndex = 238
    '
    'LblAdd2
    '
    Me.LblAdd2.BackColor = System.Drawing.SystemColors.Control
    Me.LblAdd2.Location = New System.Drawing.Point(365, 87)
    Me.LblAdd2.Name = "LblAdd2"
    Me.LblAdd2.Size = New System.Drawing.Size(256, 16)
    Me.LblAdd2.TabIndex = 237
    '
    'LblAdd1
    '
    Me.LblAdd1.BackColor = System.Drawing.SystemColors.Control
    Me.LblAdd1.Location = New System.Drawing.Point(365, 63)
    Me.LblAdd1.Name = "LblAdd1"
    Me.LblAdd1.Size = New System.Drawing.Size(256, 20)
    Me.LblAdd1.TabIndex = 236
    Me.LblAdd1.UseMnemonic = False
    '
    'LblSname
    '
    Me.LblSname.BackColor = System.Drawing.SystemColors.Control
    Me.LblSname.Location = New System.Drawing.Point(365, 47)
    Me.LblSname.Name = "LblSname"
    Me.LblSname.Size = New System.Drawing.Size(256, 16)
    Me.LblSname.TabIndex = 235
    Me.LblSname.UseMnemonic = False
    '
    'LblName
    '
    Me.LblName.BackColor = System.Drawing.SystemColors.Control
    Me.LblName.Location = New System.Drawing.Point(365, 23)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(256, 16)
    Me.LblName.TabIndex = 234
    Me.LblName.UseMnemonic = False
    '
    'label37
    '
    Me.label37.BackColor = System.Drawing.SystemColors.Control
    Me.label37.Location = New System.Drawing.Point(273, 127)
    Me.label37.Name = "label37"
    Me.label37.Size = New System.Drawing.Size(64, 16)
    Me.label37.TabIndex = 233
    Me.label37.Text = "Property"
    '
    'label10
    '
    Me.label10.BackColor = System.Drawing.SystemColors.Control
    Me.label10.Location = New System.Drawing.Point(273, 103)
    Me.label10.Name = "label10"
    Me.label10.Size = New System.Drawing.Size(84, 12)
    Me.label10.TabIndex = 232
    Me.label10.Text = "City/State/Zip"
    '
    'label9
    '
    Me.label9.BackColor = System.Drawing.SystemColors.Control
    Me.label9.Location = New System.Drawing.Point(273, 63)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(84, 12)
    Me.label9.TabIndex = 231
    Me.label9.Text = "Mail Address"
    '
    'label8
    '
    Me.label8.BackColor = System.Drawing.SystemColors.Control
    Me.label8.Location = New System.Drawing.Point(273, 47)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(84, 12)
    Me.label8.TabIndex = 230
    Me.label8.Text = "Second Name"
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Location = New System.Drawing.Point(273, 23)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(84, 12)
    Me.Label6.TabIndex = 229
    Me.Label6.Text = "Name of Owner"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(145, 113)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(67, 13)
    Me.Label7.TabIndex = 244
    Me.Label7.Text = "(Press Enter)"
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
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrdView.Location = New System.Drawing.Point(30, 180)
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
    Me.DataGrdView.Size = New System.Drawing.Size(439, 179)
    Me.DataGrdView.TabIndex = 342
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Location = New System.Drawing.Point(475, 190)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(66, 13)
    Me.Label11.TabIndex = 343
    Me.Label11.Text = "Invoice Paid"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Location = New System.Drawing.Point(475, 214)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(63, 13)
    Me.Label12.TabIndex = 344
    Me.Label12.Text = "History Paid"
    '
    'LblInvPaid
    '
    Me.LblInvPaid.AutoSize = True
    Me.LblInvPaid.BackColor = System.Drawing.SystemColors.Control
    Me.LblInvPaid.Location = New System.Drawing.Point(547, 190)
    Me.LblInvPaid.Name = "LblInvPaid"
    Me.LblInvPaid.Size = New System.Drawing.Size(78, 13)
    Me.LblInvPaid.TabIndex = 345
    Me.LblInvPaid.Text = "<Invoice Paid>"
    '
    'LblHistPaid
    '
    Me.LblHistPaid.AutoSize = True
    Me.LblHistPaid.BackColor = System.Drawing.SystemColors.Control
    Me.LblHistPaid.Location = New System.Drawing.Point(547, 214)
    Me.LblHistPaid.Name = "LblHistPaid"
    Me.LblHistPaid.Size = New System.Drawing.Size(75, 13)
    Me.LblHistPaid.TabIndex = 346
    Me.LblHistPaid.Text = "<History Paid>"
    '
    'ChkUpBal
    '
    Me.ChkUpBal.AutoSize = True
    Me.ChkUpBal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkUpBal.Location = New System.Drawing.Point(478, 248)
    Me.ChkUpBal.Name = "ChkUpBal"
    Me.ChkUpBal.Size = New System.Drawing.Size(147, 17)
    Me.ChkUpBal.TabIndex = 347
    Me.ChkUpBal.Text = "Update Invoice Balance?"
    Me.ChkUpBal.UseVisualStyleBackColor = True
    '
    'FrmFixB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(648, 387)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkUpBal)
    Me.Controls.Add(Me.LblHistPaid)
    Me.Controls.Add(Me.LblInvPaid)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.DataGrdView)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblProperty2)
    Me.Controls.Add(Me.LblProperty)
    Me.Controls.Add(Me.LblZip4)
    Me.Controls.Add(Me.LblZip5)
    Me.Controls.Add(Me.LblState)
    Me.Controls.Add(Me.LblCity)
    Me.Controls.Add(Me.LblAdd2)
    Me.Controls.Add(Me.LblAdd1)
    Me.Controls.Add(Me.LblSname)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.label37)
    Me.Controls.Add(Me.label10)
    Me.Controls.Add(Me.label9)
    Me.Controls.Add(Me.label8)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtList)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtType)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtDBName)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.MaximizeBox = False
    Me.Name = "FrmFixB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmFixB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmFix.SbpScreen.Text = "FixB"
    CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    If Asc(e.KeyChar) = Keys.Return Then
      ValidateData()
    End If
  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Public Sub ValidateData()
    Dim WrkFamily As String

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()
    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL1 = New TXHSTL1.MyData(myDBConnect)
    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    WrkList = CnvSng(TxtList.Text)
    WrkType = TxtType.Text
    WrkYear = CnvSng(TxtYear.Text)
    With myTXINV
      myTXINV.GetOneRecordP(WrkList, WrkYear, WrkType)
      LblName.Text = Trim(._NAME)
      LblSname.Text = String.Empty
      If Not IsDBNull(._SNAME) Then
        LblSname.Text = Trim(._SNAME)
      End If
      LblAdd1.Text = Trim(._ADD1)
      LblAdd2.Text = String.Empty
      If Not IsDBNull(._ADD2) Then
        LblAdd2.Text = Trim(._ADD2)
      End If
      LblCity.Text = Trim(._CITY)
      LblState.Text = Trim(._STATE)
      LblZip5.Text = Format(._ZIP5, "00000")
      LblZip4.Text = Format(._ZIP4, "0000")
      LblProperty.Text = String.Empty
      LblProperty2.Text = String.Empty

      WrkFamily = GetTXTypeFamily(WrkType)
      Select Case WrkFamily
        Case "M", "S"
          LblProperty.Text = Trim(._IMVREG) & " - " & Trim(._IMVIDNo) 'Used by print
          LblProperty2.Text = Trim(._MAKE) & " - " & Trim(._MODEL) &
         " - " & ._MVYR & " - " & Format(._CLASS, "00")
        Case "P"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
        Case "R"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
          If Not IsDBNull(._MAP) Then
            LblProperty2.Text = Trim(._MAP)
          End If
        Case "A"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
        Case "U"
          If Not IsDBNull(._LOC) Then
            LblProperty.Text = Trim(._LOCNo) & " " & ._LOC
          End If
      End Select
      LblInvPaid.Text = Format(._PAYREC, "Fixed")
    End With

    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).Visible = False
      .Columns(1).HeaderText = "Status"
      .Columns(1).Width = 45
      .Columns(2).Visible = False
      .Columns(3).Visible = False
      .Columns(4).Visible = False
      .Columns(5).HeaderText = "Principal"
      .Columns(5).Width = 60
      .Columns(6).HeaderText = "Interest"
      .Columns(6).Width = 50
      .Columns(7).HeaderText = "Fee"
      .Columns(7).Width = 35
      .Columns(8).HeaderText = "Lien"
      .Columns(8).Width = 35
      .Columns(9).Visible = False
      .Columns(10).Visible = False
      .Columns(11).Visible = False
      .Columns(12).Visible = False
      .Columns(13).Visible = False
      .Columns(14).Visible = False
      .Columns(15).Visible = False
      .Columns(16).HeaderText = "Comment"
      .Columns(16).Width = 95
      .Columns(17).Visible = False
      .Columns(18).Visible = False
      .Columns(19).Visible = False
      .Columns(20).Visible = False
      .Columns(21).HeaderText = "Date"
      .Columns(21).Width = 60
      .Columns(22).Visible = False
      .Columns(23).Visible = False
      .Columns(24).Visible = False
      .Columns(25).Visible = False
      .Columns(26).Visible = False
      .Columns(27).Visible = False
      .Columns(28).Visible = False
      .Columns(29).Visible = False
    End With

  End Sub
  Public Sub ShowGrid()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    Dim ds As DataSet = New DataSet
    Dim dv As DataView
    ds = myTXHSTL1.GetbyList(WrkList, WrkYear, WrkType, 0)

    TotalPamt = 0
    If ds.Tables(0).Rows.Count > 0 Then
      TotalPamt = Convert.ToDecimal(ds.Tables(0).Compute("SUM(PAMT)", "Rcode not in ('I','V')"))
      LblHistPaid.Text = Format(TotalPamt, "Fixed")
    End If
    dv = New DataView(ds.Tables(0))
    dv.RowFilter = "chtime=0 and rcode<>'I' and rcode<>'V'" 'Only converted records
    DataGrdView.Columns.Clear()
    DataGrdView.DataSource = dv
    If DataGrdView.Rows.Count > 0 Then
      DataGrdView.Focus()
      DataGrdView.ClearSelection()
      DataGrdView.Rows(0).Selected = True
      DataGrdView.CurrentCell = DataGrdView.Rows(0).Cells(1)
    End If
    DataGrdView.Refresh()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub DataGrdView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.Click

  End Sub

  Public Sub UpdateFile()
    Dim WrkPrin As Decimal
    Dim WrkInt As Decimal

    If Not Good Then
      MyDBName = MyFrmFixB.TxtDBName.Text
      Good = Connect()
    End If
    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)

    If DataGrdView.Rows.Count > 0 Then
      WrkRecId = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
    Else
      Exit Sub
    End If

    With myTXHST
      .GetOneRecordP(WrkRecId)
      ._RCODE = "V"
      WrkPrin = ._PAMT
      WrkInt = ._IAMT
      .UpdateOneRecordP()
    End With

    If ChkUpBal.Checked Then
      With myTXINV
        .GetOneRecordP(WrkList, WrkYear, WrkType)
        ._PAYREC = ._PAYREC - WrkPrin
        ._BALD = ._BALD + WrkPrin
        ._INTPD = ._INTPD - WrkInt
        .UpdateOneRecordP()
      End With
    End If

    ClearScreen()
  End Sub
  Public Sub ClearScreen()
    LblName.Text = String.Empty
    LblSname.Text = String.Empty
    LblAdd1.Text = String.Empty
    LblAdd2.Text = String.Empty
    LblCity.Text = String.Empty
    LblState.Text = String.Empty
    LblZip5.Text = String.Empty
    LblZip4.Text = String.Empty
    LblProperty.Text = String.Empty
    LblProperty2.Text = String.Empty
    LblInvPaid.Text = String.Empty
    LblHistPaid.Text = String.Empty
    ChkUpBal.Checked = False
    DataGrdView.Columns.Clear()
  End Sub

  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim myTXTYPE As TXTYPE.MyData

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXTYPE.GetOneRecordP(Code)
    If Not myTXTYPE.RecordNotFound Then
      GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
    Else
      GetTXTypeFamily = "*** Unknown ***"
    End If
    myTXTYPE.CloseFile()
    myTXTYPE = Nothing
    Return GetTXTypeFamily

  End Function

  Private Sub FrmFixB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LblInvPaid.Text = ""
    LblHistPaid.Text = ""
  End Sub
End Class
