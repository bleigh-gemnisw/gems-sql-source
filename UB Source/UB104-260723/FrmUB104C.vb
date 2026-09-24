Public Class FrmUB104C
  Inherits System.Windows.Forms.Form
  Dim myUTMETER As UTMETER.MyData
  Dim myUTMUSER As UTMUSER.MyData
  Friend Wrkmttype As String
  Friend Wrkmtsize As String
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Rad5 As System.Windows.Forms.RadioButton
  Friend WithEvents Rad4 As System.Windows.Forms.RadioButton
  Friend WithEvents Rad3 As System.Windows.Forms.RadioButton
  Friend WithEvents Rad2 As System.Windows.Forms.RadioButton
  Friend WithEvents Rad1 As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbMult100 As System.Windows.Forms.RadioButton
  Friend WithEvents RbMult10 As System.Windows.Forms.RadioButton
  Friend WithEvents RbMult1 As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbChargeUnit As System.Windows.Forms.RadioButton
  Friend WithEvents RbChargeBase As System.Windows.Forms.RadioButton
  Friend WithEvents RbChargeMin As System.Windows.Forms.RadioButton
  Friend WithEvents Rad6 As System.Windows.Forms.RadioButton
  Friend WithEvents Rad7 As System.Windows.Forms.RadioButton
  Friend WithEvents TxtMtPct As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtEDU As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Rad8 As RadioButton
  Friend WithEvents TxtUser1 As TextBox
  Friend WithEvents LblUser1 As Label
  Friend WithEvents TxtUser3 As TextBox
  Friend WithEvents LblUser3 As Label
  Friend WithEvents TxtUser2 As TextBox
  Friend WithEvents LblUser2 As Label
  Dim checked As Boolean

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
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Txtmttype As System.Windows.Forms.TextBox
  Friend WithEvents Txtmtsize As System.Windows.Forms.TextBox
  Friend WithEvents txtmtdesc As System.Windows.Forms.TextBox
  Friend WithEvents Txtmtmin As System.Windows.Forms.TextBox
  Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Txtmttype = New System.Windows.Forms.TextBox()
    Me.txtmtdesc = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Txtmtsize = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Txtmtmin = New System.Windows.Forms.TextBox()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Rad8 = New System.Windows.Forms.RadioButton()
    Me.Rad7 = New System.Windows.Forms.RadioButton()
    Me.Rad6 = New System.Windows.Forms.RadioButton()
    Me.Rad5 = New System.Windows.Forms.RadioButton()
    Me.Rad4 = New System.Windows.Forms.RadioButton()
    Me.Rad3 = New System.Windows.Forms.RadioButton()
    Me.Rad2 = New System.Windows.Forms.RadioButton()
    Me.Rad1 = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbMult100 = New System.Windows.Forms.RadioButton()
    Me.RbMult10 = New System.Windows.Forms.RadioButton()
    Me.RbMult1 = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbChargeUnit = New System.Windows.Forms.RadioButton()
    Me.RbChargeBase = New System.Windows.Forms.RadioButton()
    Me.RbChargeMin = New System.Windows.Forms.RadioButton()
    Me.TxtMtPct = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtEDU = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtUser1 = New System.Windows.Forms.TextBox()
    Me.LblUser1 = New System.Windows.Forms.Label()
    Me.TxtUser2 = New System.Windows.Forms.TextBox()
    Me.LblUser2 = New System.Windows.Forms.Label()
    Me.TxtUser3 = New System.Windows.Forms.TextBox()
    Me.LblUser3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'Txtmttype
    '
    Me.Txtmttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmttype.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmttype.Location = New System.Drawing.Point(84, 19)
    Me.Txtmttype.MaxLength = 2
    Me.Txtmttype.Name = "Txtmttype"
    Me.Txtmttype.Size = New System.Drawing.Size(32, 20)
    Me.Txtmttype.TabIndex = 0
    '
    'txtmtdesc
    '
    Me.txtmtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtmtdesc.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtmtdesc.Location = New System.Drawing.Point(82, 48)
    Me.txtmtdesc.MaxLength = 25
    Me.txtmtdesc.Name = "txtmtdesc"
    Me.txtmtdesc.Size = New System.Drawing.Size(192, 20)
    Me.txtmtdesc.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 44)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Description"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(142, 20)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 19)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Size:"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Txtmtsize
    '
    Me.Txtmtsize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmtsize.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmtsize.Location = New System.Drawing.Point(188, 19)
    Me.Txtmtsize.MaxLength = 3
    Me.Txtmtsize.Name = "Txtmtsize"
    Me.Txtmtsize.Size = New System.Drawing.Size(30, 20)
    Me.Txtmtsize.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(20, 81)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 17)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Charge"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Txtmtmin
    '
    Me.Txtmtmin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmtmin.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtmtmin.Location = New System.Drawing.Point(82, 80)
    Me.Txtmtmin.MaxLength = 7
    Me.Txtmtmin.Name = "Txtmtmin"
    Me.Txtmtmin.Size = New System.Drawing.Size(64, 20)
    Me.Txtmtmin.TabIndex = 3
    Me.Txtmtmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(44, 19)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(32, 16)
    Me.LnkType.TabIndex = 17
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type:"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Rad8)
    Me.GroupBox1.Controls.Add(Me.Rad7)
    Me.GroupBox1.Controls.Add(Me.Rad6)
    Me.GroupBox1.Controls.Add(Me.Rad5)
    Me.GroupBox1.Controls.Add(Me.Rad4)
    Me.GroupBox1.Controls.Add(Me.Rad3)
    Me.GroupBox1.Controls.Add(Me.Rad2)
    Me.GroupBox1.Controls.Add(Me.Rad1)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 214)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(334, 177)
    Me.GroupBox1.TabIndex = 9
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Billing Code"
    '
    'Rad8
    '
    Me.Rad8.AutoSize = True
    Me.Rad8.Location = New System.Drawing.Point(6, 146)
    Me.Rad8.Name = "Rad8"
    Me.Rad8.Size = New System.Drawing.Size(192, 17)
    Me.Rad8.TabIndex = 24
    Me.Rad8.Text = "Annual: Drop 2 highest then double"
    '
    'Rad7
    '
    Me.Rad7.AutoSize = True
    Me.Rad7.Location = New System.Drawing.Point(6, 128)
    Me.Rad7.Name = "Rad7"
    Me.Rad7.Size = New System.Drawing.Size(105, 17)
    Me.Rad7.TabIndex = 23
    Me.Rad7.Text = "Annual: Full Year"
    '
    'Rad6
    '
    Me.Rad6.AutoSize = True
    Me.Rad6.Location = New System.Drawing.Point(6, 110)
    Me.Rad6.Name = "Rad6"
    Me.Rad6.Size = New System.Drawing.Size(220, 17)
    Me.Rad6.TabIndex = 22
    Me.Rad6.Text = "Annual: Double Winter and Drop Summer"
    '
    'Rad5
    '
    Me.Rad5.AutoSize = True
    Me.Rad5.Location = New System.Drawing.Point(6, 92)
    Me.Rad5.Name = "Rad5"
    Me.Rad5.Size = New System.Drawing.Size(277, 17)
    Me.Rad5.TabIndex = 21
    Me.Rad5.Text = "Qtr: Current + Previous + 2nd  (Usage equals reading)"
    '
    'Rad4
    '
    Me.Rad4.AutoSize = True
    Me.Rad4.Location = New System.Drawing.Point(6, 74)
    Me.Rad4.Name = "Rad4"
    Me.Rad4.Size = New System.Drawing.Size(227, 17)
    Me.Rad4.TabIndex = 20
    Me.Rad4.Text = "Qtr: Drop High Quarter + Annualize the rest"
    '
    'Rad3
    '
    Me.Rad3.AutoSize = True
    Me.Rad3.Location = New System.Drawing.Point(6, 56)
    Me.Rad3.Name = "Rad3"
    Me.Rad3.Size = New System.Drawing.Size(130, 17)
    Me.Rad3.TabIndex = 19
    Me.Rad3.Text = "Qtr: Current Quarter *4"
    '
    'Rad2
    '
    Me.Rad2.AutoSize = True
    Me.Rad2.Location = New System.Drawing.Point(6, 38)
    Me.Rad2.Name = "Rad2"
    Me.Rad2.Size = New System.Drawing.Size(130, 17)
    Me.Rad2.TabIndex = 18
    Me.Rad2.Text = "Qtr: Winter Quarter * 4"
    '
    'Rad1
    '
    Me.Rad1.AutoSize = True
    Me.Rad1.Checked = True
    Me.Rad1.Location = New System.Drawing.Point(6, 20)
    Me.Rad1.Name = "Rad1"
    Me.Rad1.Size = New System.Drawing.Size(129, 17)
    Me.Rad1.TabIndex = 17
    Me.Rad1.TabStop = True
    Me.Rad1.Text = "Qtr: Current - Previous"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbMult100)
    Me.GroupBox2.Controls.Add(Me.RbMult10)
    Me.GroupBox2.Controls.Add(Me.RbMult1)
    Me.GroupBox2.Location = New System.Drawing.Point(12, 397)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(159, 50)
    Me.GroupBox2.TabIndex = 10
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Reading Multiplier"
    '
    'RbMult100
    '
    Me.RbMult100.Location = New System.Drawing.Point(106, 23)
    Me.RbMult100.Name = "RbMult100"
    Me.RbMult100.Size = New System.Drawing.Size(51, 18)
    Me.RbMult100.TabIndex = 19
    Me.RbMult100.Text = "100"
    '
    'RbMult10
    '
    Me.RbMult10.Location = New System.Drawing.Point(50, 22)
    Me.RbMult10.Name = "RbMult10"
    Me.RbMult10.Size = New System.Drawing.Size(43, 19)
    Me.RbMult10.TabIndex = 18
    Me.RbMult10.Text = "10"
    '
    'RbMult1
    '
    Me.RbMult1.Checked = True
    Me.RbMult1.Location = New System.Drawing.Point(6, 20)
    Me.RbMult1.Name = "RbMult1"
    Me.RbMult1.Size = New System.Drawing.Size(38, 21)
    Me.RbMult1.TabIndex = 17
    Me.RbMult1.TabStop = True
    Me.RbMult1.Text = "1"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbChargeUnit)
    Me.GroupBox3.Controls.Add(Me.RbChargeBase)
    Me.GroupBox3.Controls.Add(Me.RbChargeMin)
    Me.GroupBox3.Location = New System.Drawing.Point(160, 78)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(239, 41)
    Me.GroupBox3.TabIndex = 4
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Charge Type"
    '
    'RbChargeUnit
    '
    Me.RbChargeUnit.Location = New System.Drawing.Point(165, 19)
    Me.RbChargeUnit.Name = "RbChargeUnit"
    Me.RbChargeUnit.Size = New System.Drawing.Size(65, 18)
    Me.RbChargeUnit.TabIndex = 19
    Me.RbChargeUnit.Text = "Per Unit "
    '
    'RbChargeBase
    '
    Me.RbChargeBase.Location = New System.Drawing.Point(97, 19)
    Me.RbChargeBase.Name = "RbChargeBase"
    Me.RbChargeBase.Size = New System.Drawing.Size(62, 20)
    Me.RbChargeBase.TabIndex = 18
    Me.RbChargeBase.Text = "Base "
    '
    'RbChargeMin
    '
    Me.RbChargeMin.Checked = True
    Me.RbChargeMin.Location = New System.Drawing.Point(6, 19)
    Me.RbChargeMin.Name = "RbChargeMin"
    Me.RbChargeMin.Size = New System.Drawing.Size(71, 20)
    Me.RbChargeMin.TabIndex = 17
    Me.RbChargeMin.TabStop = True
    Me.RbChargeMin.Text = "Minimum "
    '
    'TxtMtPct
    '
    Me.TxtMtPct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMtPct.Location = New System.Drawing.Point(272, 415)
    Me.TxtMtPct.MaxLength = 6
    Me.TxtMtPct.Name = "TxtMtPct"
    Me.TxtMtPct.Size = New System.Drawing.Size(45, 22)
    Me.TxtMtPct.TabIndex = 11
    Me.TxtMtPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(202, 417)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 24
    Me.Label1.Text = "MarkUp %"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TxtEDU
    '
    Me.TxtEDU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEDU.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEDU.Location = New System.Drawing.Point(82, 109)
    Me.TxtEDU.MaxLength = 7
    Me.TxtEDU.Name = "TxtEDU"
    Me.TxtEDU.Size = New System.Drawing.Size(64, 20)
    Me.TxtEDU.TabIndex = 5
    Me.TxtEDU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(20, 111)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(56, 14)
    Me.Label5.TabIndex = 26
    Me.Label5.Text = "EDU Rate"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TxtUser1
    '
    Me.TxtUser1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser1.Location = New System.Drawing.Point(82, 135)
    Me.TxtUser1.MaxLength = 7
    Me.TxtUser1.Name = "TxtUser1"
    Me.TxtUser1.Size = New System.Drawing.Size(64, 20)
    Me.TxtUser1.TabIndex = 6
    Me.TxtUser1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblUser1
    '
    Me.LblUser1.Location = New System.Drawing.Point(12, 135)
    Me.LblUser1.Name = "LblUser1"
    Me.LblUser1.Size = New System.Drawing.Size(64, 18)
    Me.LblUser1.TabIndex = 28
    Me.LblUser1.Text = "User 1"
    Me.LblUser1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtUser2
    '
    Me.TxtUser2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser2.Location = New System.Drawing.Point(82, 162)
    Me.TxtUser2.MaxLength = 7
    Me.TxtUser2.Name = "TxtUser2"
    Me.TxtUser2.Size = New System.Drawing.Size(64, 20)
    Me.TxtUser2.TabIndex = 7
    Me.TxtUser2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblUser2
    '
    Me.LblUser2.Location = New System.Drawing.Point(12, 162)
    Me.LblUser2.Name = "LblUser2"
    Me.LblUser2.Size = New System.Drawing.Size(64, 18)
    Me.LblUser2.TabIndex = 30
    Me.LblUser2.Text = "User 2"
    Me.LblUser2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtUser3
    '
    Me.TxtUser3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUser3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser3.Location = New System.Drawing.Point(82, 188)
    Me.TxtUser3.MaxLength = 7
    Me.TxtUser3.Name = "TxtUser3"
    Me.TxtUser3.Size = New System.Drawing.Size(64, 20)
    Me.TxtUser3.TabIndex = 8
    Me.TxtUser3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblUser3
    '
    Me.LblUser3.Location = New System.Drawing.Point(12, 190)
    Me.LblUser3.Name = "LblUser3"
    Me.LblUser3.Size = New System.Drawing.Size(64, 18)
    Me.LblUser3.TabIndex = 32
    Me.LblUser3.Text = "User 3"
    Me.LblUser3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FrmUB104C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(410, 452)
    Me.Controls.Add(Me.TxtUser3)
    Me.Controls.Add(Me.LblUser3)
    Me.Controls.Add(Me.TxtUser2)
    Me.Controls.Add(Me.LblUser2)
    Me.Controls.Add(Me.TxtUser1)
    Me.Controls.Add(Me.LblUser1)
    Me.Controls.Add(Me.TxtEDU)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtMtPct)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.Txtmtmin)
    Me.Controls.Add(Me.Txtmtsize)
    Me.Controls.Add(Me.txtmtdesc)
    Me.Controls.Add(Me.Txtmttype)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label3)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB104C"
    Me.Text = "Maintain Meter Size"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmUB104C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkMinc As String

    myUTMETER = New UTMETER.MyData(myDBConnect)
    myUTMUSER = New UTMUSER.MyData(myDBConnect)
    MyFrmUB104.TBarNew.Enabled = False
    MyFrmUB104.TBarSave.Enabled = True
    If Wrkmttype <> "" Then
      MyFrmUB104.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(Txtmttype)
      MyUtils.SetTxtReadOnly(Txtmtsize)
    End If
    MyFrmUB104.TBarPrint.Enabled = False
    myUTMETER.GetOneRecordP(Wrkmttype, Wrkmtsize)
    Txtmttype.Text = Wrkmttype
    Txtmtsize.Text = Wrkmtsize
    If myUTMETER.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmUB104.TBarSave.Visible = False
    End If
    With myUTMUSER
      .GetOneRecordP(1)
      If Not .RecordNotFound Then
        LblUser1.Text = Trim(._USER1)
        LblUser2.Text = Trim(._USER2)
        LblUser3.Text = Trim(._USER3)
      End If
    End With

    With myUTMETER
      Txtmtsize.Text = ._MTSIZE
      txtmtdesc.Text = Trim(._MTDESC)
      Txtmtmin.Text = ._MTMIN
      WrkMinc = ._MTMINC
      Select Case WrkMinc
        Case "N"
          RbChargeBase.Checked = True
        Case "U"
          RbChargeUnit.Checked = True
        Case "Y"
          RbChargeMin.Checked = True
      End Select
      TxtEDU.Text = ._MTEDU
      TxtUser1.Text = ._MTUSER1
      TxtUser2.Text = ._MTUSER2
      TxtUser3.Text = ._MTUSER3
      Rad1.Checked = True
      If ._MTBLCD = "A" Then
        Rad2.Checked = True
      End If
      If ._MTBLCD = "C" Then
        Rad3.Checked = True
      End If
      If ._MTBLCD = "H" Then
        Rad4.Checked = True
      End If
      If ._MTBLCD = "Q" Then
        Rad5.Checked = True
      End If
      If ._MTBLCD = "W" Then
        Rad6.Checked = True
      End If
      If ._MTBLCD = "Y" Then
        Rad7.Checked = True
      End If
      If ._MTBLCD = "D" Then
        Rad8.Checked = True
      End If
      RbMult1.Checked = True
      If ._MTMULT = 10 Then
        RbMult10.Checked = True
      End If
      If ._MTMULT = 100 Then
        RbMult100.Checked = True
      End If
      TxtMtPct.Text = ._MTPCT
    End With
  End Sub
  Private Sub FrmUB104C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB104.SbpScreen.Text = "UB104C"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmUB104
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub
  Private Sub FrmUB104C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB104.TBarNew.Enabled = True
    MyFrmUB104.TBarDelete.Enabled = False
    MyFrmUB104.TBarSave.Enabled = False
    MyFrmUB104.TBarPrint.Enabled = False
    MyFrmUB104.TBarSave.Visible = True   '#sec
    MyFrmUB104B.FormatGrid()
    MyFrmUB104B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer
    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    WrkCancel = False
    myUTMETER.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myUTMETER.GetOneRecordP(Txtmttype.Text, Txtmtsize.Text)
    If Wrkmttype = "" Then
      If Not myUTMETER.RecordNotFound Then
        Me.ErrProv.SetError(Txtmttype, "Record already exists")
        Exit Sub
      End If
    End If
    If Wrkmttype <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTMETER.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myUTMETER._MTTYPE = Txtmttype.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myUTMETER.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myUTMETER
      ._MTSIZE = Txtmtsize.Text
      ._MTDESC = txtmtdesc.Text
      ._MTMIN = MyUtils.CnvSng(Txtmtmin.Text)
      If RbChargeMin.Checked Then
        ._MTMINC = "Y"
      End If
      If RbChargeBase.Checked Then
        ._MTMINC = "N"
      End If
      If RbChargeUnit.Checked Then
        ._MTMINC = "U"
      End If
      ._MTEDU = MyUtils.CnvSng(TxtEDU.Text)
      ._MTUSER1 = MyUtils.CnvSng(TxtUser1.Text)
      ._MTUSER2 = MyUtils.CnvSng(TxtUser2.Text)
      ._MTUSER3 = MyUtils.CnvSng(TxtUser3.Text)
      ._MTBLCD = ""
      If Rad2.Checked Then
        ._MTBLCD = "A"
      End If
      If Rad3.Checked Then
        ._MTBLCD = "C"
      End If
      If Rad4.Checked Then
        ._MTBLCD = "H"
      End If
      If Rad5.Checked Then
        ._MTBLCD = "Q"
      End If
      If Rad6.Checked Then
        ._MTBLCD = "W"
      End If
      If Rad7.Checked Then
        ._MTBLCD = "Y"
      End If
      If Rad8.Checked Then
        ._MTBLCD = "D"
      End If
      ._MTMULT = 1
      If RbMult10.Checked Then
        ._MTMULT = 10
      End If
      If RbMult100.Checked Then
        ._MTMULT = 100
      End If
      ._MTPCT = MyUtils.CnvSng(TxtMtPct.Text)
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim myUTTYPE As UTTYPE.MyData
    Dim I As Integer

    myUTTYPE = New UTTYPE.MyData(myDBConnect)
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    myUTTYPE.GetOneRecordP(Txtmttype.Text)
    If myUTTYPE.RecordNotFound Or myUTTYPE._TYUTTP <> "M" Then
      ErrorField(I) = "mttype"
      ErrorMsg(I) = "Invalid Utility Type"
      I = I + 1
    End If

    If Txtmtsize.Text = String.Empty Then
      ErrorField(I) = "mtsize"
      ErrorMsg(I) = "Size is required"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(Txtmttype, "")
    ErrProv.SetError(Txtmtsize, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "mttype"
          ErrProv.SetError(Txtmttype, ErrorMsg(I))
        Case "mtsize"
          ErrProv.SetError(Txtmtsize, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub Txtmtmin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtmtmin.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub

  Private Sub Txtedu_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEDU.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtUser1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtUser2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtUser3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
    If Wrkmttype <> "" Then Exit Sub
    myFrmListType = New FrmListType
    myFrmListType.MdiParent = Me.ParentForm
    myFrmListType.Wrktytype = Txtmttype.Text
    myFrmListType.Show()
    Me.Hide()
  End Sub
  Private Sub TxtMtPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMtPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
End Class







