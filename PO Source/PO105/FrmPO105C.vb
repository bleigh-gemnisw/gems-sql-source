Public Class FrmPO105C
  Inherits System.Windows.Forms.Form
  Dim myLOCSEC As LOCSEC.myData
  Dim myLOCATN As LOCATN.MyData
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WrkUsrprf As String
  Friend WrkLlocn As String
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
Friend WithEvents TxtLlocn As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtUsrprf = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtLlocn = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(29, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User"
    '
    'TxtUsrprf
    '
    Me.TxtUsrprf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUsrprf.Location = New System.Drawing.Point(66, 9)
    Me.TxtUsrprf.MaxLength = 10
    Me.TxtUsrprf.Name = "TxtUsrprf"
    Me.TxtUsrprf.Size = New System.Drawing.Size(80, 20)
    Me.TxtUsrprf.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtLlocn
    '
    Me.TxtLlocn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLlocn.Location = New System.Drawing.Point(66, 40)
    Me.TxtLlocn.MaxLength = 4
    Me.TxtLlocn.Name = "TxtLlocn"
    Me.TxtLlocn.Size = New System.Drawing.Size(43, 20)
    Me.TxtLlocn.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 43)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Location"
    '
    'FrmPO105C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(285, 86)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtLlocn)
    Me.Controls.Add(Me.TxtUsrprf)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO105C"
    Me.Text = "Maintain Location Security"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

  Private Sub FrmPO105C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myLOCSEC = New LOCSEC.myData()
  myLOCSEC.MyDBConn = myDBConnect
  myLOCATN = New LOCATN.MyData()
  myLOCATN.MyDBConn = myDBConnect
  MyFrmPO105.TBarNew.Enabled = False
  MyFrmPO105.TBarSave.Enabled = True
  MyFrmPO105.TBarPrint.Enabled = False
  If WrkLlocn <> "" Then
    MyFrmPO105.TBarSave.Enabled = False
    MyFrmPO105.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtUsrprf)
    MyUtils.SetTxtReadOnly(TxtLlocn)
  End If
  If WrkLlocn = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmPO105.TBarDelete.Enabled = False
    Exit Sub
  End If
  myLOCSEC.GetOneRecordP(WrkUsrprf, WrkLlocn)
  Txtusrprf.Text = WrkUsrprf
  TxtLlocn.Text = WrkLlocn

 If myLOCSEC.RecordNotFound Then
  MyFrmPO105.TBarNew.Enabled = False
  MyFrmPO105.TBarSave.Enabled = False
  MyFrmPO105.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtUsrprf, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmPO105.TBarSave.Visible = False
  End If

  With myLOCSEC
   TxtUsrprf.Text = Trim(._USRPRF)
  End With
End Sub
Private Sub FrmPO105C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPO105.SbpScreen.Text = "PO105C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmPO105C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmPO105.TBarNew.Enabled = True
  MyFrmPO105.TBarDelete.Enabled = False
  MyFrmPO105.TBarSave.Enabled = False
  MyFrmPO105.TBarPrint.Enabled = False
  MyFrmPO105B.FormatGrid()
  MyFrmPO105B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myLOCSEC.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myLOCSEC.GetOneRecordP(TxtUsrprf.Text, TxtLlocn.Text)
 If WrkLlocn = "" Then
   If Not myLOCSEC.RecordNotFound Then
     Me.ErrProv.SetError(TxtUsrprf, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkLlocn <> "" Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myLOCSEC.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myLOCSEC._USRPRF = TxtUsrprf.Text
   myLOCSEC._LLOCN = TxtLlocn.Text
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myLOCSEC.AddOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 With myLOCSEC
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
   ErrorField(I) = "usrprf"
   ErrorMsg(I) = "User is required"
   I = I + 1
  End If

  If TxtLlocn.Text = String.Empty Then
   ErrorField(I) = "llocn"
   ErrorMsg(I) = "Location is required"
   I = I + 1
  End If

 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.SetError(TxtUsrprf, "")
 ErrProv.SetError(TxtLlocn, "")

 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "usrprf"
    ErrProv.SetError(TxtUsrprf, ErrorMsg(I))
  Case "llocn"
    ErrProv.SetError(TxtLlocn, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
End Class
