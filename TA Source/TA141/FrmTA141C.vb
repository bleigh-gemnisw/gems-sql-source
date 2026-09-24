Public Class FrmTA141C
  Inherits System.Windows.Forms.Form
  Dim myTXMSRPCD As TXMSRPCD.MyData
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
  Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(116, 12)
    Me.TxtCode.MaxLength = 1
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(23, 20)
    Me.TxtCode.TabIndex = 0
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(116, 36)
    Me.TxtDescr.MaxLength = 30
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(348, 20)
    Me.TxtDescr.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 36)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Description"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmTA141C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(478, 62)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA141C"
    Me.Text = "Maintain MSRP Source Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA141C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMSRPCD = New TXMSRPCD.MyData(myDBConnect)
    MyFrmTA141.TBarNew.Enabled = False
    MyFrmTA141.TBarSave.Enabled = True
    If WrkCode <> "" Then
      MyFrmTA141.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
    End If
    MyFrmTA141.TBarPrint.Enabled = False
    myTXMSRPCD.GetOneRecordP(WrkCode)
    TxtCode.Text = WrkCode
    If myTXMSRPCD.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA141.TBarSave.Visible = False
    End If
    With myTXMSRPCD
      TxtDescr.Text = Trim(._DESCR)
    End With
  End Sub
  Private Sub FrmTA141C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA141.SbpScreen.Text = "TA141C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmTA141C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA141.TBarNew.Enabled = True
    MyFrmTA141.TBarDelete.Enabled = False
    MyFrmTA141.TBarSave.Enabled = False
    MyFrmTA141.TBarPrint.Enabled = False
    MyFrmTA141.TBarSave.Visible = True
    MyFrmTA141B.FormatGrid()
    MyFrmTA141B.Show()
  End Sub
  Public Sub DeleteData(ByRef wrkcancel As Boolean)
    Dim Answer As Integer
    wrkcancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    wrkcancel = False
    myTXMSRPCD.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXMSRPCD.GetOneRecordP(TxtCode.Text)
    If WrkCode = "" Then
      If Not myTXMSRPCD.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkCode <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXMSRPCD.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXMSRPCD._SOURCE = TxtCode.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXMSRPCD.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXMSRPCD
      ._DESCR = TxtDescr.Text
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
			ErrorField(I) = "btcode"
			ErrorMsg(I) = "Code is required"
			I = I + 1
		End If

		If TxtDescr.Text = String.Empty Then
			ErrorField(I) = "btdesc"
			ErrorMsg(I) = "Description is required"
			I = I + 1
		End If

	End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
	Dim I As Integer
	ErrProv.SetError(TxtCode, "")
	ErrProv.SetError(TxtDescr, "")
	For I = 0 To ErrorField.GetUpperBound(0)
	Select Case ErrorField(I)
	Case "btcode"
		ErrProv.SetError(TxtCode, ErrorMsg(I))
	Case "btdesc"
		ErrProv.SetError(TxtDescr, ErrorMsg(I))
	Case ""
		Exit Sub
	End Select
	Next I
End Sub
End Class







