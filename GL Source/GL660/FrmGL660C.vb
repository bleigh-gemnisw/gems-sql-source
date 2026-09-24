Public Class FrmGL660C
  Inherits System.Windows.Forms.Form
	Dim myGLDEPGRP As GLDEPGRP.myData
	Friend WrkCode As Integer
  Friend WithEvents ChkExcTot As System.Windows.Forms.CheckBox
  Friend WrkDesc As String
  Friend WrkExcTot As String


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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.ChkExcTot = New System.Windows.Forms.CheckBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(12, 12)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(45, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Location = New System.Drawing.Point(83, 8)
Me.TxtCode.MaxLength = 2
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(24, 20)
Me.TxtCode.TabIndex = 1
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(12, 35)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(68, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(83, 34)
Me.TxtDesc.MaxLength = 30
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(344, 20)
Me.TxtDesc.TabIndex = 2
'
'ChkExcTot
'
Me.ChkExcTot.AutoSize = True
Me.ChkExcTot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.ChkExcTot.Location = New System.Drawing.Point(12, 63)
Me.ChkExcTot.Name = "ChkExcTot"
Me.ChkExcTot.Size = New System.Drawing.Size(152, 17)
Me.ChkExcTot.TabIndex = 29
Me.ChkExcTot.Text = "Exclude from Fund Totals?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
Me.ChkExcTot.UseVisualStyleBackColor = True
'
'FrmGL660C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(445, 92)
Me.Controls.Add(Me.ChkExcTot)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmGL660C"
Me.Text = "Maintain Department Group Code"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL660C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myGLDEPGRP = New GLDEPGRP.MyData()
  myGLDEPGRP.MyDBConn = myDBConnect
  MyFrmGL660.TBarNew.Enabled = False
  MyFrmGL660.TBarSave.Enabled = True
  MyFrmGL660.TBarPrint.Enabled = False
  If WrkCode = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmGL660.TBarDelete.Enabled = False
    Exit Sub
  End If

  MyFrmGL660.TBarDelete.Enabled = True
  MyUtils.SetTxtReadOnly(TxtCode)
	myGLDEPGRP.GetOneRecordP(WrkCode)
  TxtCode.Text = WrkCode
  TxtDesc.Text = Trim(WrkDesc)
  If WrkExcTot = "Y" Then
    ChkExcTot.Checked = True
  Else
    ChkExcTot.Checked = False
  End If

	If myGLDEPGRP.RecordNotFound Then
			MyFrmGL660.TBarNew.Enabled = False
			MyFrmGL660.TBarSave.Enabled = False
			MyFrmGL660.TBarDelete.Enabled = False
			Me.ErrProv.SetError(TxtCode, "Record not found")
			Exit Sub
		End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmGL660.TBarSave.Visible = False
  End If
End Sub
Private Sub FrmGL660C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL660.SbpScreen.Text = "GL660C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGL660C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL660.TBarNew.Enabled = True
  MyFrmGL660.TBarDelete.Enabled = False
  MyFrmGL660.TBarSave.Enabled = False
  MyFrmGL660.TBarPrint.Enabled = False
  MyFrmGL660B.FormatGrid()
  MyFrmGL660B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

	myGLDEPGRP.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
	Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myGLDEPGRP.GetOneRecordP(MyUtils.CnvSng(TxtCode.Text))
  If WrkCode = 0 Then
		If Not myGLDEPGRP.RecordNotFound Then
			Me.ErrProv.SetError(TxtCode, "Record already exists")
			Exit Sub
		End If
  End If
  If WrkCode <> 0 Then
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
			myGLDEPGRP.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
    End If
    Else
    myGLDEPGRP._CODE = MyUtils.CnvSng(TxtCode.Text)
    MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myGLDEPGRP.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
	With myGLDEPGRP
		._DESC = TxtDesc.Text
		If ChkExcTot.Checked Then
			._EXCTOT = "Y"
		Else
			._EXCTOT = ""
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
