Public Class FrmTAP12C
  Inherits System.Windows.Forms.Form
  Dim myTXDCEX As TXDCEX.myData
	Dim ds As DataSet = New DataSet
	Friend WrkYear As Integer
  Friend WrkCode As String
  Dim WrkTxType As String
  Friend WithEvents TxtExval As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label

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
  Friend WithEvents TxtCode As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtExval = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
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
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(36, 20)
Me.TxtCode.TabIndex = 0
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(124, 36)
Me.TxtDesc.MaxLength = 50
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(288, 20)
Me.TxtDesc.TabIndex = 2
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
'TxtExval
'
Me.TxtExval.Location = New System.Drawing.Point(124, 60)
Me.TxtExval.MaxLength = 3
Me.TxtExval.Name = "TxtExval"
Me.TxtExval.Size = New System.Drawing.Size(36, 20)
Me.TxtExval.TabIndex = 8
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 60)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(110, 24)
Me.Label5.TabIndex = 7
Me.Label5.Text = "Default Value"
'
'FrmTAP12C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(440, 89)
Me.Controls.Add(Me.TxtExval)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP12C"
Me.Text = "Maintain PP Declaration Exemption"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTAP12C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	WrkTxType = "P"
	myTXDCEX = New TXDCEX.mydata(MyDBConnect)

	MyFrmTAP12.TBarNew.Enabled = False
	MyFrmTAP12.TBarSave.Enabled = True
	If WrkCode <> String.Empty Then
		MyFrmTAP12.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
	End If

	myTXDCEX.GetOneRecordP(WrkYear, WrkCode)
	If myTXDCEX.RecordNotFound Then Exit Sub
	TxtCode.Text = WrkCode

	If s_chg = False And s_full = False Then		'#sec
		MyFrmTAP12.TBarSave.Visible = False
	End If
	With myTXDCEX
		TxtDesc.Text = Trim(._DESC)
		TxtExval.Text = ._EXVAL
	End With
End Sub
Private Sub FrmTAP12C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	MyFrmTAP12.SbpScreen.Text = "TAP12C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP12C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
	MyFrmTAP12.TBarNew.Enabled = True
	MyFrmTAP12.TBarDelete.Enabled = False
	MyFrmTAP12.TBarSave.Enabled = False
	MyFrmTAP12.TBarSave.Visible = True	 '#sec
	MyFrmTAP12B.FormatGrid()
	MyFrmTAP12B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myTXDCEX.DeleteOneRecordP()

End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  ErrProv.SetError(TxtCode, "")
  WrkTxType = "P"
	myTXDCEX.GetOneRecordP(WrkYear, TxtCode.Text)
  If WrkCode = "" Then
    If myTXDCEX.RecordNotFound = False Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myTXDCEX.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCEX.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCEX.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myTXDCEX
		._YEAR = WrkYear
		._CODE = TxtCode.Text
    ._DESC = TxtDesc.Text
    ._EXVAL = MyUtils.CnvSng(TxtExval.Text)
  End With

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
Private Sub TxtExval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExval.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
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
      ErrorMsg(I) = "Invalid Code"
      I = I + 1
  End If

  If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Invalid Description"
      I = I + 1
  End If

  End Sub
End Class






