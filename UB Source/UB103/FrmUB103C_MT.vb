Public Class FrmUB103C_MT
  Inherits System.Windows.Forms.Form
	Dim myUTRATEMT As UTRATEMT.myData
	Friend Wrkrmtype As String
  Dim checked As Boolean
  Friend Wrkrmcode As String
  Friend Wrkrmtier As Integer

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
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Txtrmtype As System.Windows.Forms.TextBox
Friend WithEvents txtRmdesc As System.Windows.Forms.TextBox
Friend WithEvents Txtrmcode As System.Windows.Forms.TextBox
Friend WithEvents TxtRmtier As System.Windows.Forms.TextBox
Friend WithEvents TxtRmrate As System.Windows.Forms.TextBox
Friend WithEvents LnkType As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Txtrmtype = New System.Windows.Forms.TextBox
Me.txtRmdesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtrmcode = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.TxtRmtier = New System.Windows.Forms.TextBox
Me.TxtRmrate = New System.Windows.Forms.TextBox
Me.LnkType = New System.Windows.Forms.LinkLabel
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Txtrmtype
'
Me.Txtrmtype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtrmtype.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Txtrmtype.Location = New System.Drawing.Point(72, 16)
Me.Txtrmtype.MaxLength = 2
Me.Txtrmtype.Name = "Txtrmtype"
Me.Txtrmtype.Size = New System.Drawing.Size(24, 22)
Me.Txtrmtype.TabIndex = 0
'
'txtRmdesc
'
Me.txtRmdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.txtRmdesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtRmdesc.Location = New System.Drawing.Point(72, 56)
Me.txtRmdesc.MaxLength = 25
Me.txtRmdesc.Name = "txtRmdesc"
Me.txtRmdesc.Size = New System.Drawing.Size(200, 22)
Me.txtRmdesc.TabIndex = 3
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(0, 56)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(68, 24)
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
'Txtrmcode
'
Me.Txtrmcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtrmcode.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Txtrmcode.Location = New System.Drawing.Point(168, 16)
Me.Txtrmcode.MaxLength = 3
Me.Txtrmcode.Name = "Txtrmcode"
Me.Txtrmcode.Size = New System.Drawing.Size(32, 21)
Me.Txtrmcode.TabIndex = 1
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(224, 20)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(40, 16)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Tier"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(16, 84)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(48, 16)
Me.Label6.TabIndex = 8
Me.Label6.Text = "Rate"
Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'TxtRmtier
'
Me.TxtRmtier.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRmtier.Location = New System.Drawing.Point(268, 16)
Me.TxtRmtier.MaxLength = 8
Me.TxtRmtier.Name = "TxtRmtier"
Me.TxtRmtier.Size = New System.Drawing.Size(74, 22)
Me.TxtRmtier.TabIndex = 2
Me.TxtRmtier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'TxtRmrate
'
Me.TxtRmrate.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtRmrate.Location = New System.Drawing.Point(72, 80)
Me.TxtRmrate.MaxLength = 13
Me.TxtRmrate.Name = "TxtRmrate"
Me.TxtRmrate.Size = New System.Drawing.Size(119, 22)
Me.TxtRmrate.TabIndex = 4
Me.TxtRmrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'LnkType
'
Me.LnkType.Location = New System.Drawing.Point(24, 16)
Me.LnkType.Name = "LnkType"
Me.LnkType.Size = New System.Drawing.Size(40, 23)
Me.LnkType.TabIndex = 9
Me.LnkType.TabStop = True
Me.LnkType.Text = "Type"
Me.LnkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'
'FrmUB103C_MT
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(357, 113)
Me.Controls.Add(Me.LnkType)
Me.Controls.Add(Me.TxtRmrate)
Me.Controls.Add(Me.TxtRmtier)
Me.Controls.Add(Me.Txtrmcode)
Me.Controls.Add(Me.txtRmdesc)
Me.Controls.Add(Me.Txtrmtype)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label3)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmUB103C_MT"
Me.Text = "Maintain Meter Rate Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB103C_MT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	myUTRATEMT = New UTRATEMT.mydata(MyDBConnect)
  MyFrmUB103.TBarNew.Enabled = False
  MyFrmUB103.TBarSave.Enabled = True
  If Wrkrmtype <> "" Then
    MyFrmUB103.TBarDelete.Enabled = True
    LnkType.Enabled = False
    MyUtils.SetTxtReadOnly(Txtrmtype)
    MyUtils.SetTxtReadOnly(Txtrmcode)
    MyUtils.SetTxtReadOnly(TxtRmtier)
  End If
  MyFrmUB103.TBarPrint.Enabled = False
	myUTRATEMT.GetOneRecordp(Wrkrmtype, Wrkrmcode, Wrkrmtier)
  Txtrmtype.Text = Wrkrmtype
		If myUTRATEMT.RecordNotFound Then Exit Sub
      If s_chg = False And s_full = False Then    '#sec
        MyFrmUB103.TBarSave.Visible = False
      End If
		With myUTRATEMT
			Txtrmcode.Text = ._rmcode
			TxtRmtier.Text = ._rmtier
			txtRmdesc.Text = Trim(._rmdesc)
			TxtRmrate.Text = ._rmrate
		End With
End Sub
Private Sub FrmUB103C_MT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB103.SbpScreen.Text = "UB103C_MT"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB103
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB103C_MT_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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
	myUTRATEMT.DeleteOneRecordp()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myUTRATEMT.GetOneRecordP(Txtrmtype.Text, Txtrmcode.Text, MyUtils.CnvSng(TxtRmtier.Text))
  If Wrkrmtype = "" Then
    If Not myUTRATEMT.RecordNotFound Then
      Me.ErrProv.SetError(Txtrmtype, "Record already exists")
      Exit Sub
    End If
  End If
  If Wrkrmtype <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEMT.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
    Exit Sub
    End If
  Else
    myUTRATEMT._RMTYPE = Txtrmtype.Text
    myUTRATEMT._RMCODE = Txtrmcode.Text
    myUTRATEMT._RMTIER = MyUtils.CnvSng(TxtRmtier.Text)
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTRATEMT.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTRATEMT
    ._RMDESC = txtRmdesc.Text
    ._RMRATE = MyUtils.CnvSng(TxtRmrate.Text)
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

		myUTTYPE.GetOneRecordP(Txtrmtype.Text)
		If myUTTYPE.RecordNotFound Then
			ErrorField(I) = "rmtype"
			ErrorMsg(I) = "Invalid Utility Type"
			I = I + 1
		End If

		If Txtrmcode.Text = String.Empty Then
			ErrorField(I) = "rmcode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If
	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(Txtrmtype, "")
	ErrProv.SetError(Txtrmcode, "")
	For I = 0 To ErrorField.GetUpperBound(0)
	Select Case ErrorField(I)
		Case "rmtype"
			ErrProv.SetError(Txtrmtype, ErrorMsg(I))
		Case "rmcode"
			ErrProv.SetError(Txtrmcode, ErrorMsg(I))
		Case Nothing
			Exit Sub
	End Select
	Next I
End Sub

Private Sub TxtRmtier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRmtier.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtRmrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRmrate.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub LnkType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkType.LinkClicked
  myFrmListType_M = New FrmListType_M
  myFrmListType_M.MdiParent = Me.ParentForm
  myFrmListType_M.Wrkrmtype = Txtrmtype.Text
  myFrmListType_M.Show()
  Me.Hide()
End Sub
End Class







