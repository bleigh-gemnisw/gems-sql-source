Public Class FrmAP706C
  Inherits System.Windows.Forms.Form
  Dim myAP1099P As AP1099P.myData
  Friend WithEvents TxtPname As System.Windows.Forms.TextBox
  Friend WithEvents TxtPadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtPhon As System.Windows.Forms.TextBox
  Friend WithEvents TxtTaxID As System.Windows.Forms.TextBox
  Friend WithEvents TxtPadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtPadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtStID As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtRadr3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtRadr2 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtMisc As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtRname As System.Windows.Forms.TextBox
  Friend WrkYear As Integer
  Friend WithEvents TxtRadr4 As System.Windows.Forms.TextBox
  Friend WrkAcct As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtAcct As System.Windows.Forms.TextBox
Friend WithEvents TxtFedID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAcct = New System.Windows.Forms.TextBox()
    Me.TxtFedID = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtPadr2 = New System.Windows.Forms.TextBox()
    Me.TxtPadr1 = New System.Windows.Forms.TextBox()
    Me.TxtTaxID = New System.Windows.Forms.TextBox()
    Me.TxtPhon = New System.Windows.Forms.TextBox()
    Me.TxtPadr3 = New System.Windows.Forms.TextBox()
    Me.TxtPname = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtRname = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtMisc = New System.Windows.Forms.TextBox()
    Me.TxtRadr3 = New System.Windows.Forms.TextBox()
    Me.TxtRadr1 = New System.Windows.Forms.TextBox()
    Me.TxtRadr2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtStID = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtRadr4 = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(103, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(37, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Acct"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtAcct
    '
    Me.TxtAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAcct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAcct.Location = New System.Drawing.Point(148, 14)
    Me.TxtAcct.MaxLength = 20
    Me.TxtAcct.Name = "TxtAcct"
    Me.TxtAcct.Size = New System.Drawing.Size(184, 22)
    Me.TxtAcct.TabIndex = 1
    '
    'TxtFedID
    '
    Me.TxtFedID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFedID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFedID.Location = New System.Drawing.Point(112, 48)
    Me.TxtFedID.MaxLength = 10
    Me.TxtFedID.Multiline = True
    Me.TxtFedID.Name = "TxtFedID"
    Me.TxtFedID.Size = New System.Drawing.Size(90, 24)
    Me.TxtFedID.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(5, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Payer Federal ID"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtPadr2
    '
    Me.TxtPadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPadr2.Location = New System.Drawing.Point(112, 133)
    Me.TxtPadr2.MaxLength = 40
    Me.TxtPadr2.Multiline = True
    Me.TxtPadr2.Name = "TxtPadr2"
    Me.TxtPadr2.Size = New System.Drawing.Size(329, 24)
    Me.TxtPadr2.TabIndex = 5
    '
    'TxtPadr1
    '
    Me.TxtPadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPadr1.Location = New System.Drawing.Point(112, 108)
    Me.TxtPadr1.MaxLength = 40
    Me.TxtPadr1.Multiline = True
    Me.TxtPadr1.Name = "TxtPadr1"
    Me.TxtPadr1.Size = New System.Drawing.Size(329, 24)
    Me.TxtPadr1.TabIndex = 4
    '
    'TxtTaxID
    '
    Me.TxtTaxID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTaxID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTaxID.Location = New System.Drawing.Point(112, 218)
    Me.TxtTaxID.MaxLength = 11
    Me.TxtTaxID.Multiline = True
    Me.TxtTaxID.Name = "TxtTaxID"
    Me.TxtTaxID.Size = New System.Drawing.Size(104, 24)
    Me.TxtTaxID.TabIndex = 8
    '
    'TxtPhon
    '
    Me.TxtPhon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhon.Location = New System.Drawing.Point(112, 188)
    Me.TxtPhon.MaxLength = 15
    Me.TxtPhon.Multiline = True
    Me.TxtPhon.Name = "TxtPhon"
    Me.TxtPhon.Size = New System.Drawing.Size(136, 24)
    Me.TxtPhon.TabIndex = 7
    '
    'TxtPadr3
    '
    Me.TxtPadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPadr3.Location = New System.Drawing.Point(112, 158)
    Me.TxtPadr3.MaxLength = 40
    Me.TxtPadr3.Multiline = True
    Me.TxtPadr3.Name = "TxtPadr3"
    Me.TxtPadr3.Size = New System.Drawing.Size(329, 24)
    Me.TxtPadr3.TabIndex = 6
    '
    'TxtPname
    '
    Me.TxtPname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPname.Location = New System.Drawing.Point(112, 78)
    Me.TxtPname.MaxLength = 40
    Me.TxtPname.Multiline = True
    Me.TxtPname.Name = "TxtPname"
    Me.TxtPname.Size = New System.Drawing.Size(329, 24)
    Me.TxtPname.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(5, 76)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 24)
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "Payer Name"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(5, 108)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 24)
    Me.Label4.TabIndex = 18
    Me.Label4.Text = "Payer Address"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(5, 186)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(92, 24)
    Me.Label5.TabIndex = 19
    Me.Label5.Text = "Payer Phone"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(5, 218)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(92, 24)
    Me.Label6.TabIndex = 20
    Me.Label6.Text = "Recipient Tax ID"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(5, 248)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(92, 24)
    Me.Label7.TabIndex = 22
    Me.Label7.Text = "Recipient Name"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRname
    '
    Me.TxtRname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRname.Location = New System.Drawing.Point(112, 248)
    Me.TxtRname.MaxLength = 40
    Me.TxtRname.Multiline = True
    Me.TxtRname.Name = "TxtRname"
    Me.TxtRname.Size = New System.Drawing.Size(329, 24)
    Me.TxtRname.TabIndex = 9
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(5, 278)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(104, 24)
    Me.Label8.TabIndex = 24
    Me.Label8.Text = "Recipient Address"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtMisc
    '
    Me.TxtMisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMisc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMisc.Location = New System.Drawing.Point(112, 386)
    Me.TxtMisc.MaxLength = 30
    Me.TxtMisc.Multiline = True
    Me.TxtMisc.Name = "TxtMisc"
    Me.TxtMisc.Size = New System.Drawing.Size(104, 24)
    Me.TxtMisc.TabIndex = 14
    '
    'TxtRadr3
    '
    Me.TxtRadr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr3.Location = New System.Drawing.Point(112, 330)
    Me.TxtRadr3.MaxLength = 40
    Me.TxtRadr3.Multiline = True
    Me.TxtRadr3.Name = "TxtRadr3"
    Me.TxtRadr3.Size = New System.Drawing.Size(329, 24)
    Me.TxtRadr3.TabIndex = 12
    '
    'TxtRadr1
    '
    Me.TxtRadr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr1.Location = New System.Drawing.Point(112, 280)
    Me.TxtRadr1.MaxLength = 40
    Me.TxtRadr1.Multiline = True
    Me.TxtRadr1.Name = "TxtRadr1"
    Me.TxtRadr1.Size = New System.Drawing.Size(329, 24)
    Me.TxtRadr1.TabIndex = 10
    '
    'TxtRadr2
    '
    Me.TxtRadr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr2.Location = New System.Drawing.Point(112, 305)
    Me.TxtRadr2.MaxLength = 40
    Me.TxtRadr2.Multiline = True
    Me.TxtRadr2.Name = "TxtRadr2"
    Me.TxtRadr2.Size = New System.Drawing.Size(329, 24)
    Me.TxtRadr2.TabIndex = 11
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(5, 384)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(104, 24)
    Me.Label9.TabIndex = 28
    Me.Label9.Text = "Misc. Income"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(5, 417)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(104, 24)
    Me.Label10.TabIndex = 29
    Me.Label10.Text = "Payer State"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(112, 416)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Multiline = True
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(28, 24)
    Me.TxtState.TabIndex = 15
    '
    'TxtStID
    '
    Me.TxtStID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStID.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStID.Location = New System.Drawing.Point(247, 416)
    Me.TxtStID.MaxLength = 10
    Me.TxtStID.Multiline = True
    Me.TxtStID.Name = "TxtStID"
    Me.TxtStID.Size = New System.Drawing.Size(76, 24)
    Me.TxtStID.TabIndex = 16
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(160, 417)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(81, 24)
    Me.Label11.TabIndex = 31
    Me.Label11.Text = "Payer State ID"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtYear
    '
    Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(45, 14)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Multiline = True
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(52, 22)
    Me.TxtYear.TabIndex = 0
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(5, 12)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(34, 24)
    Me.Label12.TabIndex = 33
    Me.Label12.Text = "Year"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRadr4
    '
    Me.TxtRadr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRadr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRadr4.Location = New System.Drawing.Point(112, 356)
    Me.TxtRadr4.MaxLength = 40
    Me.TxtRadr4.Multiline = True
    Me.TxtRadr4.Name = "TxtRadr4"
    Me.TxtRadr4.Size = New System.Drawing.Size(329, 24)
    Me.TxtRadr4.TabIndex = 13
    '
    'FrmAP706C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(453, 459)
    Me.Controls.Add(Me.TxtRadr4)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtStID)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtRadr3)
    Me.Controls.Add(Me.TxtRadr1)
    Me.Controls.Add(Me.TxtRadr2)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtMisc)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtRname)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtPname)
    Me.Controls.Add(Me.TxtPadr3)
    Me.Controls.Add(Me.TxtPhon)
    Me.Controls.Add(Me.TxtTaxID)
    Me.Controls.Add(Me.TxtPadr1)
    Me.Controls.Add(Me.TxtPadr2)
    Me.Controls.Add(Me.TxtFedID)
    Me.Controls.Add(Me.TxtAcct)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmAP706C"
    Me.Text = "Maintain 1099"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmAP706C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myAP1099P = New AP1099P.MyData()
  myAP1099P.MyDBConn = myDBConnect
  MyFrmAP706.TBarNew.Enabled = False
  MyFrmAP706.TBarSave.Enabled = True
  If WrkAcct <> "" Then
    MyFrmAP706.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtYear)
    MyUtils.SetTxtReadOnly(TxtAcct)
  End If
  MyFrmAP706.TBarPrint.Enabled = False
  myAP1099P.GetOneRecordP(WrkYear, WrkAcct)
  TxtYear.Text = WrkYear
  TxtAcct.Text = WrkAcct
  If myAP1099P.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmAP706.TBarSave.Visible = False
  End If
  With myAP1099P
    TxtFedID.Text = Trim(._AFEDID)
    TxtPname.Text = Trim(._APNAME)
    TxtPadr1.Text = Trim(._APADR1)
    TxtPadr2.Text = Trim(._APADR2)
    TxtPadr3.Text = Trim(._APADR3)
    TxtPhon.Text = Trim(._APPHON)
    TxtTaxID.Text = Trim(._ATAXID)
    TxtRname.Text = Trim(._ARNAME)
    TxtRadr1.Text = Trim(._ARADR1)
    TxtRadr2.Text = Trim(._ARADR2)
    TxtRadr3.Text = Trim(._ARADR3)
    TxtRadr4.Text = Trim(._ARADR4)
    TxtMisc.Text = ._AMISAM
    TxtState.Text = Trim(._ASTCDE)
    TxtStID.Text = Trim(._ASTEID)
  End With
End Sub
Private Sub FrmAP706C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmAP706.SbpScreen.Text = "AP706C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmAP706
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmAP706C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmAP706.TBarNew.Enabled = True
  MyFrmAP706.TBarDelete.Enabled = False
  MyFrmAP706.TBarSave.Enabled = False
  MyFrmAP706.TBarPrint.Enabled = False
  MyFrmAP706.TBarSave.Visible = True   '#sec
  MyFrmAP706B.FormatGrid()
  MyFrmAP706B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
  myAP1099P.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myAP1099P.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text), TxtAcct.Text)
  If WrkAcct = "" Then
    If Not myAP1099P.RecordNotFound Then
      Me.ErrProv.SetError(TxtAcct, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkAcct <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myAP1099P.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myAP1099P._AYEAR = MyUtils.CnvSng(TxtYear.Text)
    myAP1099P._ARACCT = TxtAcct.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myAP1099P.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myAP1099P
    ._AFEDID = TxtFedID.Text
    ._APNAME = TxtPname.Text
    ._APADR1 = TxtPadr1.Text
    ._APADR2 = TxtPadr2.Text
    ._APADR3 = TxtPadr3.Text
    ._APPHON = TxtPhon.Text
    ._ATAXID = TxtTaxID.Text
    ._ARNAME = TxtRname.Text
    ._ARADR1 = TxtRadr1.Text
    ._ARADR2 = TxtRadr2.Text
    ._ARADR3 = TxtRadr3.Text
    ._ARADR4 = TxtRadr4.Text
    ._AMISAM = MyUtils.CnvSng(TxtMisc.Text)
    ._ASTCDE = TxtState.Text
    ._ASTEID = TxtStID.Text
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If
    If TxtAcct.Text = String.Empty Then
      ErrorField(I) = "acct"
      ErrorMsg(I) = "Acct is required"
      I = I + 1
    End If
    If TxtFedID.Text = String.Empty Then
      ErrorField(I) = "fedid"
      ErrorMsg(I) = "FedID is required"
      I = I + 1
    End If
    If TxtPname.Text = String.Empty Then
      ErrorField(I) = "pname"
      ErrorMsg(I) = "Payer Name is required"
      I = I + 1
    End If
    If TxtRname.Text = String.Empty Then
      ErrorField(I) = "rname"
      ErrorMsg(I) = "Recipient Name is required"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtYear, "")
  ErrProv.SetError(TxtAcct, "")
  ErrProv.SetError(TxtFedID, "")
  ErrProv.SetError(TxtPname, "")
  ErrProv.SetError(TxtRname, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "year"
      ErrProv.SetError(TxtYear, ErrorMsg(I))
    Case "acct"
      ErrProv.SetError(TxtAcct, ErrorMsg(I))
    Case "fedid"
      ErrProv.SetError(TxtFedID, ErrorMsg(I))
    Case "pname"
      ErrProv.SetError(TxtPname, ErrorMsg(I))
    Case "rname"
      ErrProv.SetError(TxtRname, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
  Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
    MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMisc.KeyPress
    MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
End Class

