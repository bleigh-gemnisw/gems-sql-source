Public Class FrmTAP10C
  Inherits System.Windows.Forms.Form
	Dim myTXCODE As txcode.MyData
	Dim myTXDCCD As TXDCCD.myData
  Dim ds As DataSet = New DataSet
  Friend Wrktxdccd As String
	Friend WrkYear As Integer
	Friend WrkTxType As String
  Friend WrktxLtr As String
  Friend WithEvents TxtAspct As System.Windows.Forms.TextBox
  Friend WithEvents TxtDecode As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtLtr As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtAscode As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.TxtCode = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtLtr = New System.Windows.Forms.TextBox
Me.TxtDesc = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.TxtAscode = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.TxtAspct = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtDecode = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
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
Me.TxtCode.Location = New System.Drawing.Point(124, 12)
Me.TxtCode.MaxLength = 3
Me.TxtCode.Name = "TxtCode"
Me.TxtCode.Size = New System.Drawing.Size(36, 20)
Me.TxtCode.TabIndex = 0
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 36)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(92, 24)
Me.Label2.TabIndex = 2
Me.Label2.Text = "Letter"
'
'TxtLtr
'
Me.TxtLtr.Location = New System.Drawing.Point(124, 36)
Me.TxtLtr.MaxLength = 1
Me.TxtLtr.Name = "TxtLtr"
Me.TxtLtr.Size = New System.Drawing.Size(20, 20)
Me.TxtLtr.TabIndex = 1
'
'TxtDesc
'
Me.TxtDesc.Location = New System.Drawing.Point(124, 60)
Me.TxtDesc.MaxLength = 50
Me.TxtDesc.Name = "TxtDesc"
Me.TxtDesc.Size = New System.Drawing.Size(288, 20)
Me.TxtDesc.TabIndex = 2
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(8, 60)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 24)
Me.Label3.TabIndex = 4
Me.Label3.Text = "Description"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 108)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(112, 24)
Me.Label4.TabIndex = 6
Me.Label4.Text = "Assessment Code"
'
'TxtAscode
'
Me.TxtAscode.Location = New System.Drawing.Point(124, 108)
Me.TxtAscode.MaxLength = 3
Me.TxtAscode.Name = "TxtAscode"
Me.TxtAscode.Size = New System.Drawing.Size(36, 20)
Me.TxtAscode.TabIndex = 5
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'TxtAspct
'
Me.TxtAspct.Location = New System.Drawing.Point(124, 132)
Me.TxtAspct.MaxLength = 3
Me.TxtAspct.Name = "TxtAspct"
Me.TxtAspct.Size = New System.Drawing.Size(36, 20)
Me.TxtAspct.TabIndex = 8
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 132)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(110, 24)
Me.Label5.TabIndex = 7
Me.Label5.Text = "Assessment Percent"
'
'TxtDecode
'
Me.TxtDecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDecode.Location = New System.Drawing.Point(124, 84)
Me.TxtDecode.MaxLength = 2
Me.TxtDecode.Name = "TxtDecode"
Me.TxtDecode.Size = New System.Drawing.Size(36, 20)
Me.TxtDecode.TabIndex = 3
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 84)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(110, 24)
Me.Label6.TabIndex = 10
Me.Label6.Text = "Depreciation Code"
'
'FrmTAP10C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(440, 169)
Me.Controls.Add(Me.TxtDecode)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtAspct)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.TxtAscode)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.TxtDesc)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.TxtLtr)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.TxtCode)
Me.Controls.Add(Me.Label1)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTAP10C"
Me.Text = "Maintain PP Declaration Property Codes"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

Private Sub FrmTAP10C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  WrkTxType = "P"
	myTXCODE = New TXCODE.mydata(MyDBConnect)
	myTXDCCD = New TXDCCD.mydata(MyDBConnect)

  MyFrmTAP10.TBarNew.Enabled = False
  MyFrmTAP10.TBarSave.Enabled = True
  If Wrktxdccd > 0 Then
    MyFrmTAP10.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtCode)
    MyUtils.SetTxtReadOnly(TxtLtr)
  End If

	myTXDCCD.GetOneRecordP(WrkYear, Wrktxdccd, WrktxLtr)
	If myTXDCCD.RecordNotFound Then Exit Sub
  TxtCode.Text = Wrktxdccd
  TxtLtr.Text = WrktxLtr

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTAP10.TBarSave.Visible = False
  End If
  With mytxdccd
    TxtDesc.Text = Trim(._DESC)
    TxtDecode.Text = Trim(._DECODE)
    TxtAscode.Text = ._ASCODE
    TxtAspct.Text = ._ASPCT

  End With
End Sub
Private Sub FrmTAP10C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAP10.SbpScreen.Text = "TAP10C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmTAP10C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTAP10.TBarNew.Enabled = True
  MyFrmTAP10.TBarDelete.Enabled = False
  MyFrmTAP10.TBarSave.Enabled = False
  MyFrmTAP10.TBarSave.Visible = True   '#sec
  MyFrmTAP10B.FormatGrid()
  MyFrmTAP10B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    mytxdccd.DeleteOneRecordP()

End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtAscode, "")
  WrkTxType = "P"
  myTXDCCD.GetOneRecordP(WrkYear, MyUtils.CnvSng(TxtCode.Text), TxtLtr.Text)
  If Wrktxdccd = "" Then
    If myTXDCCD.RecordNotFound = False Then
      Me.ErrProv.SetError(TxtCode, "Record already exists")
      Exit Sub
    End If
  End If

  If Not myTXDCCD.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCCD.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myTXDCCD.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()

   With myTXDCCD
    ._YEAR = WrkYear
    ._CODE = MyUtils.CnvSng(TxtCode.Text)
    ._LTR = TxtLtr.Text
    ._DESC = TxtDesc.Text
    ._DECODE = TxtDecode.Text
    ._ASCODE = MyUtils.CnvSng(TxtAscode.Text)
    ._ASPCT = MyUtils.CnvSng(TxtAspct.Text)
  End With

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtAscode, "")
  ErrProv.SetError(TxtCode, "")
  ErrProv.SetError(TxtDesc, "")

  For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
    Case "ascode"
      ErrProv.SetError(TxtAscode, ErrorMsg(I))
    Case "code"
      ErrProv.SetError(TxtCode, ErrorMsg(I))
    Case "desc"
      ErrProv.SetError(TxtDesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
  End Select
  Next I
End Sub
Private Sub TxtCode_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAscode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAscode.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtAspct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAspct.KeyPress
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

  myTXCODE.GetOneRecordP(MyUtils.CnvSng(TxtAscode.Text), WrkTxType)
  If myTXCODE.RecordNotFound Then
      ErrorField(I) = "ascode"
      ErrorMsg(I) = "Invalid Property Code"
      I = I + 1
  End If
  End Sub
End Class






