Public Class FrmGL114C
  Inherits System.Windows.Forms.Form
  Dim myFNDSEC As FNDSEC.myData
  Dim myGLFUND As GLFUND.myData
  Friend WrkUsrprf As String
  Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
  Friend WrkFdnbr As String
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
Friend WithEvents TxtUsrprf As System.Windows.Forms.TextBox
Friend WithEvents TxtFund As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtUsrprf = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.LnkFund = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(68, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User Name"
    '
    'TxtUsrprf
    '
    Me.TxtUsrprf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUsrprf.Location = New System.Drawing.Point(76, 8)
    Me.TxtUsrprf.MaxLength = 10
    Me.TxtUsrprf.Name = "TxtUsrprf"
    Me.TxtUsrprf.Size = New System.Drawing.Size(86, 20)
    Me.TxtUsrprf.TabIndex = 1
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Location = New System.Drawing.Point(208, 8)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 20)
    Me.TxtFund.TabIndex = 2
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Location = New System.Drawing.Point(171, 12)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 29
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'FrmGL114C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(252, 44)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtUsrprf)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL114C"
    Me.Text = "Maintain Fund Security"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmGL114C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myFNDSEC = New FNDSEC.MyData()
  myFNDSEC.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect
  MyFrmGL114.TBarNew.Enabled = False
  MyFrmGL114.TBarSave.Enabled = True
  MyFrmGL114.TBarPrint.Enabled = False
  If WrkUsrprf <> "" Then
    MyFrmGL114.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtUsrprf)
    MyUtils.SetTxtReadOnly(TxtFund)
    LnkFund.Enabled = False
  End If
  If WrkUsrprf = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmGL114.TBarDelete.Enabled = False
    Exit Sub
  End If
  myFNDSEC.GetOneRecordP(WrkUsrprf, WrkFdnbr)
  TxtUsrprf.Text = WrkUsrprf
  TxtFund.Text = WrkFdnbr

 If myFNDSEC.RecordNotFound Then
  MyFrmGL114.TBarNew.Enabled = False
  MyFrmGL114.TBarSave.Enabled = False
  MyFrmGL114.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtUsrprf, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmGL114.TBarSave.Visible = False
  End If
End Sub
Private Sub FrmGL114C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGL114.SbpScreen.Text = "GL114C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGL114C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGL114.TBarNew.Enabled = True
  MyFrmGL114.TBarDelete.Enabled = False
  MyFrmGL114.TBarSave.Enabled = False
  MyFrmGL114.TBarPrint.Enabled = False
  MyFrmGL114B.FormatGrid()
  MyFrmGL114B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myFNDSEC.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myFNDSEC.GetOneRecordP(TxtUsrprf.Text, MyUtils.CnvSng(TxtFund.Text))
 If WrkUsrprf = "" Then
   If Not myFNDSEC.RecordNotFound Then
     Me.ErrProv.SetError(TxtUsrprf, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkUsrprf <> "" Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myFNDSEC.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myFNDSEC._USRPRF = TxtUsrprf.Text
   myFNDSEC._FDNBR = MyUtils.CnvSng(TxtFund.Text)
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myFNDSEC.AddOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 With myFNDSEC
 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If TxtUsrprf.Text = String.Empty Then
   ErrorField(I) = "user"
   ErrorMsg(I) = "User is required"
   I = I + 1
  End If

  If MyUtils.CnvSng(TxtFund.Text) > 0 Then
   myGLFUND.GetOneRecordP(TxtFund.Text, 0)
   If myGLFUND.RecordNotFound Then
     ErrorField(I) = "fund"
     ErrorMsg(I) = "Fund is invalid"
     I = I + 1
   End If
  End If
 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.SetError(TxtUsrprf, "")
 ErrProv.SetError(TxtFund, "")
 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "user"
    ErrProv.SetError(TxtUsrprf, ErrorMsg(I))
  Case "fund"
    ErrProv.SetError(TxtFund, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub

Private Sub TxtFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LnkFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
  MyFrmListFund.Show()
 End Sub
End Class
