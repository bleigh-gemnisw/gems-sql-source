Public Class FrmPO104C
  Inherits System.Windows.Forms.Form
  Dim myPOMEMO As POMEMO.myData
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WrkFdnbr As Integer
  Friend WrkSfund As Integer
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtFdnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtLne As System.Windows.Forms.TextBox
  Friend WithEvents TxtMemo As System.Windows.Forms.TextBox
  Friend WrkLne As Integer
  Const CFieldLen As Integer = 70

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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFdnbr = New System.Windows.Forms.TextBox()
    Me.TxtLne = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMemo = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(121, 9)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 36
    Me.Label3.Text = "Sub Fund"
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Location = New System.Drawing.Point(178, 6)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfund.TabIndex = 34
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(31, 13)
    Me.Label2.TabIndex = 35
    Me.Label2.Text = "Fund"
    '
    'TxtFdnbr
    '
    Me.TxtFdnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFdnbr.Location = New System.Drawing.Point(69, 6)
    Me.TxtFdnbr.MaxLength = 3
    Me.TxtFdnbr.Name = "TxtFdnbr"
    Me.TxtFdnbr.Size = New System.Drawing.Size(32, 20)
    Me.TxtFdnbr.TabIndex = 33
    '
    'TxtLne
    '
    Me.TxtLne.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLne.Location = New System.Drawing.Point(273, 6)
    Me.TxtLne.MaxLength = 3
    Me.TxtLne.Name = "TxtLne"
    Me.TxtLne.Size = New System.Drawing.Size(32, 20)
    Me.TxtLne.TabIndex = 37
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(240, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(27, 13)
    Me.Label1.TabIndex = 38
    Me.Label1.Text = "Line"
    '
    'TxtMemo
    '
    Me.TxtMemo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMemo.Location = New System.Drawing.Point(12, 42)
    Me.TxtMemo.MaxLength = 1050
    Me.TxtMemo.Multiline = True
    Me.TxtMemo.Name = "TxtMemo"
    Me.TxtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtMemo.Size = New System.Drawing.Size(599, 274)
    Me.TxtMemo.TabIndex = 291
    '
    'FrmPO104C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(623, 328)
    Me.Controls.Add(Me.TxtMemo)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtLne)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFdnbr)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO104C"
    Me.Text = "Maintain PO Memo"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmPO104C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myPOMEMO = New POMEMO.myData()
  myPOMEMO.MyDBConn = myDBConnect
  MyFrmPO104.TBarNew.Enabled = False
  MyFrmPO104.TBarSave.Enabled = True
  MyFrmPO104.TBarPrint.Enabled = False
  MyUtils.SetTxtReadOnly(TxtLne)
  If WrkFdnbr > 0 Then
    MyFrmPO104.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtFdnbr)
    MyUtils.SetTxtReadOnly(TxtSfund)
  End If
  If WrkFdnbr = 0 Then
    Me.Text = "Add " & Me.Text
    MyFrmPO104.TBarDelete.Enabled = False
    Exit Sub
  End If
  myPOMEMO.GetOneRecordP(WrkFdnbr, WrkSfund, WrkLne)
  TxtFdnbr.Text = WrkFdnbr
  TxtSfund.Text = WrkSfund
  TxtLne.Text = WrkLne

 If myPOMEMO.RecordNotFound Then
  MyFrmPO104.TBarNew.Enabled = False
  MyFrmPO104.TBarSave.Enabled = False
  MyFrmPO104.TBarDelete.Enabled = False
  Me.ErrProv.SetError(TxtFdnbr, "Record not found")
  Exit Sub
 End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmPO104.TBarSave.Visible = False
  End If

  With myPOMEMO
    TxtMemo.Text = ._TEXT01 & ._TEXT02 & ._TEXT03 & ._TEXT04 & ._TEXT05 & _
    ._TEXT06 & ._TEXT07 & ._TEXT08 & ._TEXT09 & ._TEXT10 & _
    ._TEXT11 & ._TEXT12 & ._TEXT13 & ._TEXT14 & ._TEXT15
  End With
End Sub
Private Sub FrmPO104C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPO104.SbpScreen.Text = "PO104C"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmPO104C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmPO104.TBarNew.Enabled = True
  MyFrmPO104.TBarDelete.Enabled = False
  MyFrmPO104.TBarSave.Enabled = False
  MyFrmPO104.TBarPrint.Enabled = False
  MyFrmPO104B.FormatGrid()
  MyFrmPO104B.Show()
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
 myPOMEMO.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 If WrkFdnbr = 0 Then
   WrkLne = myPOMEMO.AutoGenKey(WrkFdnbr, WrkSfund)
 End If
 myPOMEMO.GetOneRecordP(MyUtils.CnvSng(TxtFdnbr.Text), MyUtils.CnvSng(TxtSfund.Text), _
  WrkLne)
 If WrkFdnbr = 0 Then
   If Not myPOMEMO.RecordNotFound Then
     Me.ErrProv.SetError(TxtFdnbr, "Record already exists")
     Exit Sub
   End If
 End If
 If WrkFdnbr > 0 Then
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myPOMEMO.UpdateOneRecordP()
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 Else
   myPOMEMO._FDNBR = TxtFdnbr.Text
   myPOMEMO._SFUND = TxtSfund.Text
   myPOMEMO._LNE = WrkLne
   MovetoFile()
   EditChecks(ErrorField, ErrorMsg)
   If IsNothing(ErrorMsg(0)) Then
     myPOMEMO.AddOneRecordP()
     MsgBox("Memo added as line " & WrkLne, MsgBoxStyle.Information, "Completed")
   Else
     ShowError(ErrorField, ErrorMsg)
     Exit Sub
   End If
 End If
 Me.Close()
End Sub
Private Sub MovetoFile()
 Dim WrkPos As Integer

 With myPOMEMO
   WrkPos = 1
   ._TEXT01 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT02 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT03 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT04 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT05 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT06 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT07 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT08 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT09 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT10 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT11 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT12 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT13 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT14 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
   WrkPos = WrkPos + CFieldLen
   ._TEXT15 = Mid(TxtMemo.Text, WrkPos, CFieldLen)
 End With

End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next

  If MyUtils.CnvSng(TxtFdnbr.Text) = 0 Then
   ErrorField(I) = "Fdnbr"
   ErrorMsg(I) = "Fund is required"
   I = I + 1
  End If

  If Len(Trim(TxtMemo.Text)) > CFieldLen * 15 Then
   ErrorField(I) = "memo"
   ErrorMsg(I) = "Memo is " & Len(TxtMemo.Text) & " characters...Maximum is " & CFieldLen * 15
   I = I + 1
  End If
 End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
 Dim I As Integer
 ErrProv.Clear()

 For I = 0 To ErrorField.GetUpperBound(0)
  Select Case ErrorField(I)
  Case "Fdnbr"
    ErrProv.SetError(TxtFdnbr, ErrorMsg(I))
  Case "Sfund"
    ErrProv.SetError(TxtSfund, ErrorMsg(I))
  Case "memo"
    ErrProv.SetError(TxtMemo, ErrorMsg(I))
  Case Nothing
    Exit Sub
  End Select
 Next I
End Sub
End Class
