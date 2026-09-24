Public Class FrmUB103C_AS
  Inherits System.Windows.Forms.Form
	Dim myUTRATEAS As UTRATEAS.myData
	Friend Wrkratype As String
  Friend WithEvents ChkYr1 As System.Windows.Forms.CheckBox
  Friend WithEvents RbDefault As System.Windows.Forms.RadioButton
  Friend WithEvents RbNoDelqBond As System.Windows.Forms.RadioButton
  Friend WithEvents RbPayEqual As System.Windows.Forms.RadioButton
  Friend WithEvents RbRedivide As System.Windows.Forms.RadioButton
  Friend WithEvents RbSimple As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtBond As System.Windows.Forms.TextBox
  Friend Wrkracode As String


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
Friend WithEvents txtdesc As System.Windows.Forms.TextBox
Friend WithEvents Txttype As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtPct As System.Windows.Forms.TextBox
Friend WithEvents TxtMnth As System.Windows.Forms.TextBox
Friend WithEvents TxtNoyr As System.Windows.Forms.TextBox
Friend WithEvents TxtFoot As System.Windows.Forms.TextBox
Friend WithEvents TxtPval As System.Windows.Forms.TextBox
Friend WithEvents TxtUnit As System.Windows.Forms.TextBox
Friend WithEvents TxtAcre As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Txttype = New System.Windows.Forms.TextBox()
    Me.txtdesc = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtPct = New System.Windows.Forms.TextBox()
    Me.TxtMnth = New System.Windows.Forms.TextBox()
    Me.TxtNoyr = New System.Windows.Forms.TextBox()
    Me.TxtFoot = New System.Windows.Forms.TextBox()
    Me.TxtPval = New System.Windows.Forms.TextBox()
    Me.TxtUnit = New System.Windows.Forms.TextBox()
    Me.TxtAcre = New System.Windows.Forms.TextBox()
    Me.LnkType = New System.Windows.Forms.LinkLabel()
    Me.ChkYr1 = New System.Windows.Forms.CheckBox()
    Me.RbNoDelqBond = New System.Windows.Forms.RadioButton()
    Me.RbPayEqual = New System.Windows.Forms.RadioButton()
    Me.RbRedivide = New System.Windows.Forms.RadioButton()
    Me.RbSimple = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.RbDefault = New System.Windows.Forms.RadioButton()
    Me.TxtBond = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Txttype
    '
    Me.Txttype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txttype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txttype.Location = New System.Drawing.Point(72, 16)
    Me.Txttype.MaxLength = 2
    Me.Txttype.Name = "Txttype"
    Me.Txttype.Size = New System.Drawing.Size(24, 22)
    Me.Txttype.TabIndex = 0
    '
    'txtdesc
    '
    Me.txtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtdesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtdesc.Location = New System.Drawing.Point(72, 48)
    Me.txtdesc.MaxLength = 25
    Me.txtdesc.Name = "txtdesc"
    Me.txtdesc.Size = New System.Drawing.Size(288, 22)
    Me.txtdesc.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(0, 48)
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
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode.Location = New System.Drawing.Point(184, 16)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(104, 16)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 24)
    Me.Label5.TabIndex = 1
    Me.Label5.Text = "Code"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(192, 93)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 29)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "No. of  Months between bills"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(286, 93)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 29)
    Me.Label6.TabIndex = 7
    Me.Label6.Text = "No. of Years"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(40, 168)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(40, 29)
    Me.Label7.TabIndex = 8
    Me.Label7.Text = "Front Foot"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(24, 93)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(48, 29)
    Me.Label9.TabIndex = 10
    Me.Label9.Text = "Bond Percent"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(120, 168)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(64, 29)
    Me.Label8.TabIndex = 11
    Me.Label8.Text = "Assessed Prop Value"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(224, 168)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(48, 29)
    Me.Label10.TabIndex = 12
    Me.Label10.Text = "Dwelling Unit"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(328, 168)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(40, 29)
    Me.Label11.TabIndex = 13
    Me.Label11.Text = "Acre"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TxtPct
    '
    Me.TxtPct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPct.Location = New System.Drawing.Point(16, 125)
    Me.TxtPct.MaxLength = 6
    Me.TxtPct.Name = "TxtPct"
    Me.TxtPct.Size = New System.Drawing.Size(72, 22)
    Me.TxtPct.TabIndex = 3
    Me.TxtPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtMnth
    '
    Me.TxtMnth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMnth.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMnth.Location = New System.Drawing.Point(222, 125)
    Me.TxtMnth.MaxLength = 2
    Me.TxtMnth.Name = "TxtMnth"
    Me.TxtMnth.Size = New System.Drawing.Size(24, 22)
    Me.TxtMnth.TabIndex = 5
    Me.TxtMnth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtNoyr
    '
    Me.TxtNoyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNoyr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNoyr.Location = New System.Drawing.Point(302, 125)
    Me.TxtNoyr.MaxLength = 2
    Me.TxtNoyr.Name = "TxtNoyr"
    Me.TxtNoyr.Size = New System.Drawing.Size(32, 22)
    Me.TxtNoyr.TabIndex = 6
    Me.TxtNoyr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtFoot
    '
    Me.TxtFoot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFoot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFoot.Location = New System.Drawing.Point(16, 200)
    Me.TxtFoot.MaxLength = 9
    Me.TxtFoot.Name = "TxtFoot"
    Me.TxtFoot.Size = New System.Drawing.Size(88, 22)
    Me.TxtFoot.TabIndex = 8
    Me.TxtFoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtPval
    '
    Me.TxtPval.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPval.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPval.Location = New System.Drawing.Point(112, 200)
    Me.TxtPval.MaxLength = 9
    Me.TxtPval.Name = "TxtPval"
    Me.TxtPval.Size = New System.Drawing.Size(88, 22)
    Me.TxtPval.TabIndex = 9
    Me.TxtPval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit
    '
    Me.TxtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUnit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit.Location = New System.Drawing.Point(208, 200)
    Me.TxtUnit.MaxLength = 9
    Me.TxtUnit.Name = "TxtUnit"
    Me.TxtUnit.Size = New System.Drawing.Size(88, 22)
    Me.TxtUnit.TabIndex = 10
    Me.TxtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAcre
    '
    Me.TxtAcre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcre.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcre.Location = New System.Drawing.Point(304, 200)
    Me.TxtAcre.MaxLength = 9
    Me.TxtAcre.Name = "TxtAcre"
    Me.TxtAcre.Size = New System.Drawing.Size(88, 22)
    Me.TxtAcre.TabIndex = 11
    Me.TxtAcre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LnkType
    '
    Me.LnkType.Location = New System.Drawing.Point(32, 16)
    Me.LnkType.Name = "LnkType"
    Me.LnkType.Size = New System.Drawing.Size(32, 23)
    Me.LnkType.TabIndex = 14
    Me.LnkType.TabStop = True
    Me.LnkType.Text = "Type"
    Me.LnkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'ChkYr1
    '
    Me.ChkYr1.AutoSize = True
    Me.ChkYr1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkYr1.Location = New System.Drawing.Point(340, 128)
    Me.ChkYr1.Name = "ChkYr1"
    Me.ChkYr1.Size = New System.Drawing.Size(99, 17)
    Me.ChkYr1.TabIndex = 7
    Me.ChkYr1.Text = "Bond 1st Year?"
    Me.ChkYr1.UseVisualStyleBackColor = True
    '
    'RbNoDelqBond
    '
    Me.RbNoDelqBond.AutoSize = True
    Me.RbNoDelqBond.Location = New System.Drawing.Point(126, 319)
    Me.RbNoDelqBond.Name = "RbNoDelqBond"
    Me.RbNoDelqBond.Size = New System.Drawing.Size(190, 17)
    Me.RbNoDelqBond.TabIndex = 16
    Me.RbNoDelqBond.Text = "No Delq Bond Interest (IE: CPACE)"
    '
    'RbPayEqual
    '
    Me.RbPayEqual.AutoSize = True
    Me.RbPayEqual.Location = New System.Drawing.Point(126, 297)
    Me.RbPayEqual.Name = "RbPayEqual"
    Me.RbPayEqual.Size = New System.Drawing.Size(304, 17)
    Me.RbPayEqual.TabIndex = 15
    Me.RbPayEqual.Text = "Payments Equal (Principal + Bond) Bond Interest is required"
    '
    'RbRedivide
    '
    Me.RbRedivide.AutoSize = True
    Me.RbRedivide.Location = New System.Drawing.Point(126, 277)
    Me.RbRedivide.Name = "RbRedivide"
    Me.RbRedivide.Size = New System.Drawing.Size(257, 17)
    Me.RbRedivide.TabIndex = 14
    Me.RbRedivide.Text = "Redivide (assessment left by number of years left)"
    '
    'RbSimple
    '
    Me.RbSimple.AutoSize = True
    Me.RbSimple.Location = New System.Drawing.Point(126, 257)
    Me.RbSimple.Name = "RbSimple"
    Me.RbSimple.Size = New System.Drawing.Size(215, 17)
    Me.RbSimple.TabIndex = 13
    Me.RbSimple.Text = "Simple (Principal same/Bond decreases)"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(6, 247)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(104, 50)
    Me.Label2.TabIndex = 15
    Me.Label2.Text = "Assessment Calculation Method: (Override default)"
    '
    'RbDefault
    '
    Me.RbDefault.AutoSize = True
    Me.RbDefault.Checked = True
    Me.RbDefault.Location = New System.Drawing.Point(126, 237)
    Me.RbDefault.Name = "RbDefault"
    Me.RbDefault.Size = New System.Drawing.Size(161, 17)
    Me.RbDefault.TabIndex = 12
    Me.RbDefault.TabStop = True
    Me.RbDefault.Text = "Use Method from Control File"
    '
    'TxtBond
    '
    Me.TxtBond.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBond.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBond.Location = New System.Drawing.Point(112, 123)
    Me.TxtBond.MaxLength = 10
    Me.TxtBond.Name = "TxtBond"
    Me.TxtBond.Size = New System.Drawing.Size(72, 22)
    Me.TxtBond.TabIndex = 4
    Me.TxtBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(112, 91)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(74, 29)
    Me.Label12.TabIndex = 24
    Me.Label12.Text = "Bond Fixed Amount"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'FrmUB103C_AS
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(458, 346)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtBond)
    Me.Controls.Add(Me.RbDefault)
    Me.Controls.Add(Me.RbNoDelqBond)
    Me.Controls.Add(Me.RbPayEqual)
    Me.Controls.Add(Me.RbRedivide)
    Me.Controls.Add(Me.RbSimple)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.ChkYr1)
    Me.Controls.Add(Me.LnkType)
    Me.Controls.Add(Me.TxtAcre)
    Me.Controls.Add(Me.TxtUnit)
    Me.Controls.Add(Me.TxtPval)
    Me.Controls.Add(Me.TxtFoot)
    Me.Controls.Add(Me.TxtNoyr)
    Me.Controls.Add(Me.TxtMnth)
    Me.Controls.Add(Me.TxtPct)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.txtdesc)
    Me.Controls.Add(Me.Txttype)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB103C_AS"
    Me.Text = "Assessment Rate Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB103C_AS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTRATEAS = New UTRATEAS.mydata(MyDBConnect)
  MyFrmUB103.TBarNew.Enabled = False
  MyFrmUB103.TBarSave.Enabled = True
  If Wrkratype <> "" Then
    MyFrmUB103.TBarDelete.Enabled = True
    LnkType.Enabled = False
    MyUtils.SetTxtReadOnly(Txttype)
    MyUtils.SetTxtReadOnly(TxtCode)
  End If
  MyFrmUB103.TBarPrint.Enabled = False
  myUTRATEAS.GetOneRecordP(Wrkratype, Wrkracode)
  Txttype.Text = Wrkratype
  TxtCode.Text = Wrkracode
  If myUTRATEAS.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmUB103.TBarSave.Visible = False
  End If

  With myUTRATEAS
    txtdesc.Text = Trim(._RADESC)
    TxtPct.Text = ._RAPCT
    TxtMnth.Text = ._RAMNTH
    TxtNoyr.Text = ._RANOYR
    TxtFoot.Text = ._RAFOOT
    TxtPval.Text = ._RAPVAL
    TxtUnit.Text = ._RAUNIT
    TxtAcre.Text = ._RAACRE
    ChkYr1.Checked = False
    If Trim(._RAYR1) = "Y" Then
      ChkYr1.Checked = True
    End If
    TxtBond.Enabled = False
    Select Case ._RAMORT
    Case "S"
      RbSimple.Checked = True
      TxtBond.Enabled = True
    Case "R"
      RbRedivide.Checked = True
    Case "P"
      RbPayEqual.Checked = True
    Case "N"
      RbNoDelqBond.Checked = True
      TxtBond.Enabled = True
    Case Else
      RbDefault.Checked = True
    End Select
    If ._RABOND > 0 Then
      TxtBond.Text = ._RABOND
    End If
    End With
End Sub
Private Sub FrmUB103C_AS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB103.SbpScreen.Text = "UB103C_AS"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB103
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB103C_AS_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB103.TBarNew.Enabled = True
  MyFrmUB103.TBarDelete.Enabled = False
  MyFrmUB103.TBarSave.Enabled = False
  MyFrmUB103.TBarPrint.Enabled = False
  MyFrmUB103.TBarSave.Visible = True   '#sec
  MyFrmUB103B.FormatGrid()
  MyFrmUB103B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
  Exit Sub
  End If
  WrkCancel = False
  myUTRATEAS.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myUTRATEAS.GetOneRecordP(Txttype.Text, TxtCode.Text)
  If Wrkratype = "" Or Wrkracode = "" Then
    If Not myUTRATEAS.RecordNotFound Then
      Me.ErrProv.SetError(Txttype, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrkratype <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEAS.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
    myUTRATEAS._RATYPE = Txttype.Text
    myUTRATEAS._RACODE = TxtCode.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEAS.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
  End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTRATEAS
    ._RADESC = txtdesc.Text
    ._RAPCT = MyUtils.CnvSng(TxtPct.Text)
    ._RAMNTH = MyUtils.CnvSng(TxtMnth.Text)
    ._RANOYR = MyUtils.CnvSng(TxtNoyr.Text)
    ._RAFOOT = MyUtils.CnvSng(TxtFoot.Text)
    ._RAPVAL = MyUtils.CnvSng(TxtPval.Text)
    ._RAUNIT = MyUtils.CnvSng(TxtUnit.Text)
    ._RAACRE = MyUtils.CnvSng(TxtAcre.Text)
    If ChkYr1.Checked Then
      ._RAYR1 = "Y"
    Else
      ._RAYR1 = "N"
    End If
    If RbSimple.Checked Then
      ._RAMORT = "S"
    End If
    If RbRedivide.Checked Then
      ._RAMORT = "R"
    End If
    If RbPayEqual.Checked Then
      ._RAMORT = "P"
    End If
    If RbNoDelqBond.Checked Then
      ._RAMORT = "N"
    End If
    If RbDefault.Checked Then
      ._RAMORT = ""
    End If
    ._RABOND = MyUtils.CnvSng(TxtBond.Text)
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim myUTTYPE As UTTYPE.myData
    Dim I As Integer

    myUTTYPE = New UTTYPE.mydata(MyDBConnect)
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    myUTTYPE.GetOneRecordP(Txttype.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "ratype"
      ErrorMsg(I) = "Invalid Utility Type"
      I = I + 1
    End If

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "racode"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    'If MyUtils.CnvSng(TxtPct.Text) > 0 And MyUtils.CnvSng(TxtBond.Text) > 0 Then
    '  ErrorField(I) = "rapct"
    '  ErrorMsg(I) = "Enter Percentage or Amount (not both)"
    '  I = I + 1
    'End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txttype, "")
  ErrProv.SetError(TxtCode, "")
  'ErrProv.SetError(TxtPct, "")
  'ErrProv.SetError(TxtBond, "")
  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "ratype"
      ErrProv.SetError(Txttype, ErrorMsg(I))
    Case "racode"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    'Case "rapct"
    '  ErrProv.SetError(TxtPct, ErrorMsg(I))
    '  ErrProv.SetError(TxtBond, ErrorMsg(I))
    Case Nothing
      Exit Sub
  End Select
  Next I
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPct.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtMnth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMnth.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtNoyr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNoyr.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtFoot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFoot.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtPval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPval.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtAcre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcre.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtBond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBond.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub LinkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  myFrmListType_A = New FrmListType_A
  myFrmListType_A.MdiParent = Me.ParentForm
  myFrmListType_A.Wrkratype = Txttype.Text
  myFrmListType_A.Show()
  Me.Hide()
End Sub
Private Sub RbDefault_Click(sender As Object, e As EventArgs) Handles RbDefault.Click
  TxtBond.Text = ""
  TxtBond.Enabled = False
End Sub
Private Sub RbSimple_Click(sender As Object, e As EventArgs) Handles RbSimple.Click
  TxtBond.Enabled = True
End Sub
Private Sub RbPayEqual_Click(sender As Object, e As EventArgs) Handles RbPayEqual.Click
  TxtBond.Enabled = True
  TxtBond.Text = ""
  TxtBond.Enabled = False
End Sub
Private Sub RbRedivide_Click(sender As Object, e As EventArgs) Handles RbRedivide.Click
  TxtBond.Text = ""
  TxtBond.Enabled = False
End Sub
Private Sub RbNoDelqBond_Click(sender As Object, e As EventArgs) Handles RbNoDelqBond.Click
  TxtBond.Enabled = True
End Sub

Private Sub RbPayEqual_CheckedChanged(sender As Object, e As EventArgs) Handles RbPayEqual.CheckedChanged

End Sub
End Class







