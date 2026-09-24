Public Class FrmTX115C
  Inherits System.Windows.Forms.Form
  Dim myTXTYPE As TXTYPE.myData
  Friend WithEvents RbSU As System.Windows.Forms.RadioButton
  Friend WithEvents RbMV As System.Windows.Forms.RadioButton
  Friend WithEvents RbPP As System.Windows.Forms.RadioButton
  Friend WrkCode As String

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
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents GrpFamily As System.Windows.Forms.GroupBox
Friend WithEvents RbUS As System.Windows.Forms.RadioButton
Friend WithEvents RbRE As System.Windows.Forms.RadioButton
Friend WithEvents RbAS As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.GrpFamily = New System.Windows.Forms.GroupBox
Me.RbSU = New System.Windows.Forms.RadioButton
Me.RbMV = New System.Windows.Forms.RadioButton
Me.RbPP = New System.Windows.Forms.RadioButton
Me.RbUS = New System.Windows.Forms.RadioButton
Me.RbRE = New System.Windows.Forms.RadioButton
Me.RbAS = New System.Windows.Forms.RadioButton
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GrpFamily.SuspendLayout()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(56, 22)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Tax Type"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCode.Location = New System.Drawing.Point(72, 16)
Me.TxtCode.MaxLength = 2
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(24, 22)
Me.TxtCode.TabIndex = 0
'
'TxtDesc
'
Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDesc.Location = New System.Drawing.Point(72, 48)
Me.TxtDesc.MaxLength = 25
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(288, 22)
Me.TxtDesc.TabIndex = 1
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
'GrpFamily
'
Me.GrpFamily.Controls.Add(Me.RbSU)
Me.GrpFamily.Controls.Add(Me.RbMV)
Me.GrpFamily.Controls.Add(Me.RbPP)
Me.GrpFamily.Controls.Add(Me.RbUS)
Me.GrpFamily.Controls.Add(Me.RbRE)
Me.GrpFamily.Controls.Add(Me.RbAS)
Me.GrpFamily.Location = New System.Drawing.Point(72, 88)
Me.GrpFamily.Name = "GrpFamily"
Me.GrpFamily.Size = New System.Drawing.Size(253, 107)
Me.GrpFamily.TabIndex = 11
Me.GrpFamily.TabStop = False
Me.GrpFamily.Text = "Tax/UB Family"
'
'RbSU
'
Me.RbSU.Location = New System.Drawing.Point(6, 81)
Me.RbSU.Name = "RbSU"
Me.RbSU.Size = New System.Drawing.Size(121, 20)
Me.RbSU.TabIndex = 16
Me.RbSU.Text = "Supplemental MV"
'
'RbMV
'
Me.RbMV.Location = New System.Drawing.Point(6, 59)
Me.RbMV.Name = "RbMV"
Me.RbMV.Size = New System.Drawing.Size(111, 16)
Me.RbMV.TabIndex = 15
Me.RbMV.Text = "Motor Vehicle"
'
'RbPP
'
Me.RbPP.Location = New System.Drawing.Point(6, 37)
Me.RbPP.Name = "RbPP"
Me.RbPP.Size = New System.Drawing.Size(121, 16)
Me.RbPP.TabIndex = 14
Me.RbPP.Text = "Personal Property"
'
'RbUS
'
Me.RbUS.Location = New System.Drawing.Point(137, 37)
Me.RbUS.Name = "RbUS"
Me.RbUS.Size = New System.Drawing.Size(110, 19)
Me.RbUS.TabIndex = 13
Me.RbUS.Text = "Usage/Metered"
'
'RbRE
'
Me.RbRE.Checked = True
Me.RbRE.Location = New System.Drawing.Point(6, 15)
Me.RbRE.Name = "RbRE"
Me.RbRE.Size = New System.Drawing.Size(111, 16)
Me.RbRE.TabIndex = 12
Me.RbRE.TabStop = True
Me.RbRE.Text = "Real Estate"
'
'RbAS
'
Me.RbAS.Location = New System.Drawing.Point(137, 15)
Me.RbAS.Name = "RbAS"
Me.RbAS.Size = New System.Drawing.Size(88, 16)
Me.RbAS.TabIndex = 11
Me.RbAS.Text = "Assessment"
'
'FrmTX115C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(376, 206)
Me.Controls.Add(Me.GrpFamily)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX115C"
Me.Text = "Maintain Type Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GrpFamily.ResumeLayout(False)
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTX115C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    MyFrmTX115.TBarNew.Enabled = False
  MyFrmTX115.TBarSave.Enabled = True
  If WrkCode <> "" Then
    MyFrmTX115.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
  End If
  MyFrmTX115.TBarPrint.Enabled = False
  myTXTYPE.GetOneRecordP(WrkCode)
  TxtCode.Text = WrkCode
  If myTXTYPE.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTX115.TBarSave.Visible = False
  End If
  With myTXTYPE
    TxtDesc.Text = Trim(._TYDESC)
    Select Case Trim(._TXFAM)
    Case "A"
      RbAS.Checked = True
    Case "M"
      RbMV.Checked = True
    Case "P"
      RbPP.Checked = True
    Case "R"
      RbRE.Checked = True
    Case "S"
      RbSU.Checked = True
    Case "U"
      RbUS.Checked = True
    End Select
    GrpFamily.Enabled = False
  End With
End Sub
Private Sub FrmTX115C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTX115.SbpScreen.Text = "TX115C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmTX115
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmTX115C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTX115.TBarNew.Enabled = True
  MyFrmTX115.TBarDelete.Enabled = False
  MyFrmTX115.TBarSave.Enabled = False
  MyFrmTX115.TBarPrint.Enabled = False
  MyFrmTX115.TBarSave.Visible = True   '#sec
  MyFrmTX115B.FormatGrid()
  MyFrmTX115B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer

  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

  WrkCancel = False
  myTXTYPE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myTXTYPE.GetOneRecordP(TxtCode.Text)
  If WrkCode = "" Then
    If Not myTXTYPE.RecordNotFound Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
    Exit Sub
    End If
  End If
  If WrkCode <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXTYPE.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
    myTXTYPE._TYCODE = TxtCode.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
        myTXTYPE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myTXTYPE
    ._TYDESC = TxtDesc.Text
    If RbAS.Checked Then
      ._TXFAM = "A"
    End If
    If RbMV.Checked Then
      ._TXFAM = "M"
    End If
    If RbPP.Checked Then
      ._TXFAM = "P"
    End If
    If RbRE.Checked Then
      ._TXFAM = "R"
    End If
    If RbSU.Checked Then
      ._TXFAM = "S"
    End If
    If RbUS.Checked Then
      ._TXFAM = "U"
    End If
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtCode.Text = String.Empty Then
      ErrorField(I) = "code"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If
    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtDesc, "")
 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
  End Select
  Next I
End Sub
End Class

