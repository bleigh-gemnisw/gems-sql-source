Public Class FrmUB103C_US
  Inherits System.Windows.Forms.Form
	Dim myUTRATEUS As UTRATEUS.myData
	Friend Wrkrutype As String
	Dim checked As Boolean
	Friend WithEvents TxtRuPct As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents TxtRuEDU As System.Windows.Forms.TextBox
 Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend Wrkrucode As String

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
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtRubase As System.Windows.Forms.TextBox
Friend WithEvents TxtRuunit As System.Windows.Forms.TextBox
Friend WithEvents TxtRufixt As System.Windows.Forms.TextBox
Friend WithEvents TxtRuxtra As System.Windows.Forms.TextBox
Friend WithEvents Txtrutype As System.Windows.Forms.TextBox
Friend WithEvents Txtrucode As System.Windows.Forms.TextBox
Friend WithEvents txtRudesc As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Txtrutype = New System.Windows.Forms.TextBox
Me.txtRudesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtrucode = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.TxtRubase = New System.Windows.Forms.TextBox
Me.TxtRuunit = New System.Windows.Forms.TextBox
Me.TxtRufixt = New System.Windows.Forms.TextBox
Me.TxtRuxtra = New System.Windows.Forms.TextBox
Me.LnkType = New System.Windows.Forms.LinkLabel
Me.TxtRuPct = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtRuEDU = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Txtrutype
'
Me.Txtrutype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtrutype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Txtrutype.Location = New System.Drawing.Point(72, 16)
Me.Txtrutype.MaxLength = 2
Me.Txtrutype.Name = "Txtrutype"
Me.Txtrutype.Size = New System.Drawing.Size(24, 22)
Me.Txtrutype.TabIndex = 0
'
'txtRudesc
'
Me.txtRudesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtRudesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtRudesc.Location = New System.Drawing.Point(72, 48)
Me.txtRudesc.MaxLength = 25
Me.txtRudesc.Name = "txtRudesc"
Me.txtRudesc.Size = New System.Drawing.Size(208, 22)
Me.txtRudesc.TabIndex = 2
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
'Label2
'
Me.Label2.Location = New System.Drawing.Point(112, 16)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(56, 24)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Code"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Txtrucode
'
Me.Txtrucode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtrucode.Location = New System.Drawing.Point(168, 16)
Me.Txtrucode.MaxLength = 3
Me.Txtrucode.Name = "Txtrucode"
Me.Txtrucode.Size = New System.Drawing.Size(32, 20)
Me.Txtrucode.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(16, 96)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(48, 16)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Base"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(88, 96)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(48, 16)
Me.Label5.TabIndex = 7
Me.Label5.Text = "Unit"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(243, 96)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(48, 16)
Me.Label6.TabIndex = 8
Me.Label6.Text = "Fixtures"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(315, 96)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(48, 16)
Me.Label7.TabIndex = 9
Me.Label7.Text = "Extras"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxtRubase
'
Me.TxtRubase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRubase.Location = New System.Drawing.Point(8, 120)
Me.TxtRubase.MaxLength = 8
Me.TxtRubase.Name = "TxtRubase"
Me.TxtRubase.Size = New System.Drawing.Size(64, 22)
Me.TxtRubase.TabIndex = 3
Me.TxtRubase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtRuunit
'
Me.TxtRuunit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRuunit.Location = New System.Drawing.Point(80, 120)
Me.TxtRuunit.MaxLength = 8
Me.TxtRuunit.Name = "TxtRuunit"
Me.TxtRuunit.Size = New System.Drawing.Size(64, 22)
Me.TxtRuunit.TabIndex = 4
Me.TxtRuunit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtRufixt
'
Me.TxtRufixt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRufixt.Location = New System.Drawing.Point(235, 120)
Me.TxtRufixt.MaxLength = 8
Me.TxtRufixt.Name = "TxtRufixt"
Me.TxtRufixt.Size = New System.Drawing.Size(64, 22)
Me.TxtRufixt.TabIndex = 6
Me.TxtRufixt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtRuxtra
'
Me.TxtRuxtra.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRuxtra.Location = New System.Drawing.Point(307, 120)
Me.TxtRuxtra.MaxLength = 8
Me.TxtRuxtra.Name = "TxtRuxtra"
Me.TxtRuxtra.Size = New System.Drawing.Size(64, 22)
Me.TxtRuxtra.TabIndex = 7
Me.TxtRuxtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(24, 16)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(32, 23)
Me.LnkType.TabIndex = 10
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type"
Me.LnkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxtRuPct
'
Me.TxtRuPct.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRuPct.Location = New System.Drawing.Point(378, 120)
Me.TxtRuPct.MaxLength = 6
Me.TxtRuPct.Name = "TxtRuPct"
Me.TxtRuPct.Size = New System.Drawing.Size(45, 22)
Me.TxtRuPct.TabIndex = 8
Me.TxtRuPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(375, 96)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(64, 16)
Me.Label1.TabIndex = 12
Me.Label1.Text = "MarkUp %"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxtRuEDU
'
Me.TxtRuEDU.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRuEDU.Location = New System.Drawing.Point(156, 120)
Me.TxtRuEDU.MaxLength = 8
Me.TxtRuEDU.Name = "TxtRuEDU"
Me.TxtRuEDU.Size = New System.Drawing.Size(64, 22)
Me.TxtRuEDU.TabIndex = 5
Me.TxtRuEDU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(164, 96)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(48, 16)
Me.Label8.TabIndex = 14
Me.Label8.Text = "EDU"
Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'FrmUB103C_US
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(447, 158)
Me.Controls.Add(Me.TxtRuEDU)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.TxtRuPct)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.TxtRuxtra)
Me.Controls.Add(Me.TxtRufixt)
Me.Controls.Add(Me.TxtRuunit)
Me.Controls.Add(Me.TxtRubase)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Txtrucode)
Me.Controls.Add(Me.txtRudesc)
Me.Controls.Add(Me.Txtrutype)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label3)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB103C_US"
Me.Text = "Maintain Usage Rate Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB103C_US_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTRATEUS = New UTRATEUS.mydata(MyDBConnect)
  MyFrmUB103.TBarNew.Enabled = False
  MyFrmUB103.TBarSave.Enabled = True
  If Wrkrutype <> "" Then
    MyFrmUB103.TBarDelete.Enabled = True
    LnkType.Enabled = False
    MyUtils.SetTxtReadOnly(Txtrutype)
    MyUtils.SetTxtReadOnly(Txtrucode)
  End If
  MyFrmUB103.TBarPrint.Enabled = False
  myUTRATEUS.GetOneRecordP(Wrkrutype, Wrkrucode)
  Txtrutype.Text = Wrkrutype
  If myUTRATEUS.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmUB103.TBarSave.Visible = False
  End If
  With myUTRATEUS
    Txtrucode.Text = ._RUCODE
    txtRudesc.Text = Trim(._RUDESC)
    TxtRubase.Text = ._RUBASE
    TxtRuunit.Text = ._RUUNIT
    TxtRuEDU.Text = ._RUEDU
    TxtRufixt.Text = ._RUFIXT
    TxtRuxtra.Text = ._RUXTRA
    TxtRuPct.Text = ._RUPCT
  End With
End Sub
Private Sub FrmUB103C_US_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB103.SbpScreen.Text = "UB103C_US"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB103
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB103C_US_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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
  myUTRATEUS.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myUTRATEUS.GetOneRecordP(Txtrutype.Text, Txtrucode.Text)
  If Wrkrutype = "" Then
    If Not myUTRATEUS.RecordNotFound Then
      Me.ErrProv.SetError(Txtrutype, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrkrutype <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEUS.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myUTRATEUS._RUTYPE = Txtrutype.Text
    myUTRATEUS._RUCODE = Txtrucode.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEUS.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTRATEUS
  ._RUDESC = txtRudesc.Text
  ._RUBASE = MyUtils.CnvSng(TxtRubase.Text)
  ._RUUNIT = MyUtils.CnvSng(TxtRuunit.Text)
  ._RUEDU = MyUtils.CnvSng(TxtRuEDU.Text)
  ._RUFIXT = MyUtils.CnvSng(TxtRufixt.Text)
  ._RUXTRA = MyUtils.CnvSng(TxtRuxtra.Text)
  ._RUPCT = MyUtils.CnvSng(TxtRuPct.Text)
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

    myUTTYPE.GetOneRecordP(Txtrutype.Text)
    If myUTTYPE.RecordNotFound Then
      ErrorField(I) = "rutype"
      ErrorMsg(I) = "Invalid Utility Type"
      I = I + 1
    End If

    If Txtrucode.Text = String.Empty Then
      ErrorField(I) = "rucode"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtrutype, "")
  ErrProv.SetError(Txtrucode, "")
  For I = 0 To ErrorField.GetUpperBound(0)

  Select Case ErrorField(I)
    Case "rutype"
    ErrProv.SetError(Txtrutype, ErrorMsg(I))
    Case "rucode"
    ErrProv.SetError(Txtrucode, ErrorMsg(I))
    Case Nothing
    Exit Sub
  End Select
  Next I
End Sub
Private Sub TxtRubase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRubase.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtRuunit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRuunit.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtRuEDU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRuEDU.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtRufixt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRufixt.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtRuxtra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRuxtra.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtRupct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRuPct.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  myFrmListType_U = New FrmListType_U
  myFrmListType_U.MdiParent = Me.ParentForm
  myFrmListType_U.Wrkrutype = Txtrutype.Text
  myFrmListType_U.Show()
  Me.Hide()
End Sub
End Class







