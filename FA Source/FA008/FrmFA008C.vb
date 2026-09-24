Public Class FrmFA008C
  Inherits System.Windows.Forms.Form
	Dim myFADSPMT As FADSPMT.myData
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
Friend WithEvents TxtCode As System.Windows.Forms.TextBox
Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'TxtCode
'
Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtCode.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCode.Location = New System.Drawing.Point(81, 11)
Me.TxtCode.MaxLength = 5
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(48, 22)
Me.TxtCode.TabIndex = 0
'
'TxtDesc
'
Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDesc.Location = New System.Drawing.Point(81, 35)
Me.TxtDesc.MaxLength = 25
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(281, 22)
Me.TxtDesc.TabIndex = 1
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 40)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 16)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmFA008C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(378, 67)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmFA008C"
Me.Text = "Maintain Disposition Code"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmFA008C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFADSPMT = New FADSPMT.MyData()
    myFADSPMT.MyDBConn = myDBConnect
    MyFrmFA008.TBarNew.Enabled = False
    MyFrmFA008.TBarSave.Enabled = True
    If WrkCode <> "" Then
      MyFrmFA008.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
    End If
    MyFrmFA008.TBarPrint.Enabled = False
    myFADSPMT.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myFADSPMT.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmFA008.TBarSave.Visible = False
    End If
    With myFADSPMT
      TxtDesc.Text = Trim(._DSDESC)
    End With
  End Sub
  Private Sub FrmFA008C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmFA008.SbpScreen.Text = "FA008C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmFA008C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmFA008.TBarNew.Enabled = True
  MyFrmFA008.TBarDelete.Enabled = False
  MyFrmFA008.TBarSave.Enabled = False
  MyFrmFA008.TBarPrint.Enabled = False
  MyFrmFA008.TBarSave.Visible = True   '#sec
  MyFrmFA008B.FormatGrid()
  MyFrmFA008B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
	myFADSPMT.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String
	myFADSPMT.GetOneRecordP(TxtCode.Text)
	If WrkCode = "" Then
		If Not myFADSPMT.RecordNotFound Then
			Me.ErrProv.SetError(TxtCode, "Record already exists")
		Exit Sub
		End If
	End If
	If WrkCode <> "" Then
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myFADSPMT.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		myFADSPMT._DSCODE = TxtCode.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myFADSPMT.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	End If
	Me.Close()
End Sub
Private Sub MovetoFile()
	With myFADSPMT
		._DSDESC = TxtDesc.Text
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
