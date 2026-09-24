Public Class FrmFA003C
  Inherits System.Windows.Forms.Form
	Dim myFAASTYPE As FAASTYPE.myData
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtThreshold As System.Windows.Forms.TextBox
Friend WithEvents TxtYears As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtThreshold = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtYears = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
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
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 5
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(48, 22)
Me.TxtCode.TabIndex = 0
'
'TxtDesc
'
Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtDesc.Location = New System.Drawing.Point(124, 36)
Me.TxtDesc.MaxLength = 25
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(208, 22)
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
'TxtThreshold
'
Me.TxtThreshold.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtThreshold.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtThreshold.Location = New System.Drawing.Point(124, 60)
Me.TxtThreshold.MaxLength = 7
Me.TxtThreshold.Name = "TxtThreshold"
Me.TxtThreshold.Size = New System.Drawing.Size(64, 22)
Me.TxtThreshold.TabIndex = 5
Me.TxtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 60)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 16)
Me.Label2.TabIndex = 6
Me.Label2.Text = "Depr Threshold"
'
'TxtYears
'
Me.TxtYears.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtYears.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYears.Location = New System.Drawing.Point(124, 84)
Me.TxtYears.MaxLength = 3
Me.TxtYears.Name = "TxtYears"
Me.TxtYears.Size = New System.Drawing.Size(32, 22)
Me.TxtYears.TabIndex = 7
Me.TxtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 84)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(92, 16)
Me.Label4.TabIndex = 8
Me.Label4.Text = "Life Years"
'
'FrmFA003C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(340, 109)
Me.Controls.Add(Me.TxtYears)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtThreshold)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmFA003C"
Me.Text = "Maintain Asset Code"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmFA003C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myFAASTYPE = New FAASTYPE.MyData()
    myFAASTYPE.MyDBConn = myDBConnect
    MyFrmFA003.TBarNew.Enabled = False
    MyFrmFA003.TBarSave.Enabled = True
    If WrkCode <> "" Then
      MyFrmFA003.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
    End If
    MyFrmFA003.TBarPrint.Enabled = False
    myFAASTYPE.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myFAASTYPE.RecordNotFound Then Exit Sub
    If s_chg = False And s_full = False Then    '#sec
      MyFrmFA003.TBarSave.Visible = False
    End If
    With myFAASTYPE
      TxtDesc.Text = Trim(._ASDESC)
      TxtThreshold.Text = ._ASTHLD
      TxtYears.Text = ._ASEYR
    End With
  End Sub
  Private Sub FrmFA003C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmFA003.SbpScreen.Text = "FA003C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmFA003C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmFA003.TBarNew.Enabled = True
  MyFrmFA003.TBarDelete.Enabled = False
  MyFrmFA003.TBarSave.Enabled = False
  MyFrmFA003.TBarPrint.Enabled = False
  MyFrmFA003.TBarSave.Visible = True   '#sec
  MyFrmFA003B.FormatGrid()
  MyFrmFA003B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
	myFAASTYPE.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
	Dim ErrorField(25) As String
	Dim ErrorMsg(25) As String
	myFAASTYPE.GetOneRecordP(TxtCode.Text)
	If WrkCode = "" Then
		If Not myFAASTYPE.RecordNotFound Then
			Me.ErrProv.SetError(TxtCode, "Record already exists")
		Exit Sub
		End If
	End If
	If WrkCode <> "" Then
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myFAASTYPE.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	Else
		myFAASTYPE._ASCODE = TxtCode.Text
		MovetoFile()
		EditChecks(ErrorField, ErrorMsg)
		If IsNothing(ErrorMsg(0)) Then
			myFAASTYPE.AddOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If
	End If
	Me.Close()
End Sub
Private Sub MovetoFile()
	With myFAASTYPE
		._ASDESC = TxtDesc.Text
    ._ASTHLD = MyUtils.CnvSng(TxtThreshold.Text)
    ._ASEYR = MyUtils.CnvSng(TxtYears.Text)
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
Private Sub TxtThreshold_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtThreshold.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYears_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYears.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
