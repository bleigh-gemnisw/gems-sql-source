Public Class FrmGL506C
  Inherits System.Windows.Forms.Form
  Dim myDEPSEC As DEPSEC.MyData
  Dim myGLFUND As GLFUND.MyData
  Friend WithEvents LnkFund As System.Windows.Forms.LinkLabel
  Friend WrkUsrprf As String
  Friend WrkFund As Integer
  Friend WrkSfund As Integer
  Friend WithEvents TxtDept As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents TxtSfund As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents Label4 As Label
  Friend WrkDept As Integer
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
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User Name"
    '
    'TxtUsrprf
    '
    Me.TxtUsrprf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUsrprf.Location = New System.Drawing.Point(80, 5)
    Me.TxtUsrprf.MaxLength = 10
    Me.TxtUsrprf.Name = "TxtUsrprf"
    Me.TxtUsrprf.Size = New System.Drawing.Size(86, 20)
    Me.TxtUsrprf.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Location = New System.Drawing.Point(80, 31)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 20)
    Me.TxtFund.TabIndex = 2
    '
    'LnkFund
    '
    Me.LnkFund.AutoSize = True
    Me.LnkFund.Location = New System.Drawing.Point(43, 35)
    Me.LnkFund.Name = "LnkFund"
    Me.LnkFund.Size = New System.Drawing.Size(31, 13)
    Me.LnkFund.TabIndex = 1
    Me.LnkFund.TabStop = True
    Me.LnkFund.Text = "Fund" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Location = New System.Drawing.Point(80, 57)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfund.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 61)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Sub Fund"
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Location = New System.Drawing.Point(80, 83)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 20)
    Me.TxtDept.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 87)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(62, 13)
    Me.Label3.TabIndex = 32
    Me.Label3.Text = "Department"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(131, 87)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(94, 13)
    Me.Label4.TabIndex = 33
    Me.Label4.Text = "(Zero for all Depts)"
    '
    'FrmGL506C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(252, 118)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtDept)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkFund)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtUsrprf)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL506C"
    Me.Text = "Maintain Department Security"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL506C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myDEPSEC = New DEPSEC.MyData()
    myDEPSEC.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    MyFrmGL506.TBarNew.Enabled = False
    MyFrmGL506.TBarSave.Enabled = True
    MyFrmGL506.TBarPrint.Enabled = False
    If WrkUsrprf <> "" Then
      MyFrmGL506.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtUsrprf)
      MyUtils.SetTxtReadOnly(TxtFund)
      MyUtils.SetTxtReadOnly(TxtSFund)
      MyUtils.SetTxtReadOnly(TxtDept)
      LnkFund.Enabled = False
    End If
    If WrkUsrprf = "" Then
      Me.Text = "Add " & Me.Text
      MyFrmGL506.TBarDelete.Enabled = False
      Exit Sub
    End If
    myDEPSEC.GetOneRecordP(WrkUsrprf, WrkFund, WrkSfund, WrkDept)
    TxtUsrprf.Text = WrkUsrprf
    TxtFund.Text = WrkFund
    TxtSfund.Text = WrkSfund
    TxtDept.Text = WrkDept

    If myDEPSEC.RecordNotFound Then
      MyFrmGL506.TBarNew.Enabled = False
      MyFrmGL506.TBarSave.Enabled = False
      MyFrmGL506.TBarDelete.Enabled = False
      Me.ErrProv.SetError(TxtUsrprf, "Record not found")
      Exit Sub
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmGL506.TBarSave.Visible = False
    End If
  End Sub
  Private Sub FrmGL506C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL506.SbpScreen.Text = "GL506C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmGL506C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL506.TBarNew.Enabled = True
    MyFrmGL506.TBarDelete.Enabled = False
    MyFrmGL506.TBarSave.Enabled = False
    MyFrmGL506.TBarPrint.Enabled = False
    MyFrmGL506B.FormatGrid()
    MyFrmGL506B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    myDEPSEC.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myDEPSEC.GetOneRecordP(TxtUsrprf.Text, MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text), MyUtils.CnvSng(TxtDept.Text))
    If WrkUsrprf = "" Then
      If Not myDEPSEC.RecordNotFound Then
        Me.ErrProv.SetError(TxtUsrprf, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkUsrprf <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myDEPSEC.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myDEPSEC._USRPRF = TxtUsrprf.Text
      myDEPSEC._FUND = MyUtils.CnvSng(TxtFund.Text)
      myDEPSEC._SFUND = MyUtils.CnvSng(TxtSfund.Text)
      myDEPSEC._DEPT = MyUtils.CnvSng(TxtDept.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myDEPSEC.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myDEPSEC
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
  Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFund.LinkClicked
    MyFrmListFund = New FrmListFund
    MyFrmListFund.MdiParent = Me.ParentForm
    MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
    MyFrmListFund.Show()
  End Sub
End Class
