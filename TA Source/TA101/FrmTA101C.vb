Public Class FrmTA101C
  Inherits System.Windows.Forms.Form
  Dim myTXXPROP As TXXPROP.MyData
  Friend Wrkprexem As String
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
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
    Me.TxtCode.MaxLength = 4
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(40, 20)
    Me.TxtCode.TabIndex = 0
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(124, 36)
    Me.TxtDesc.MaxLength = 60
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(412, 20)
    Me.TxtDesc.TabIndex = 1
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
    'FrmTA101C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(632, 70)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTA101C"
    Me.Text = "Maintain Exempt Real Property Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA101C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXXPROP = New TXXPROP.MyData(myDBConnect)
    MyFrmTA101.TBarNew.Enabled = False
    MyFrmTA101.TBarSave.Enabled = True
    If Wrkprexem <> "" Then
      MyFrmTA101.TBarDelete.Enabled = True
      MyUtils.SetTxtReadOnly(TxtCode)
    End If
    MyFrmTA101.TBarPrint.Enabled = False
    myTXXPROP.GetOneRecordP(Wrkprexem)
    TxtCode.Text = Wrkprexem
    If myTXXPROP.RecordNotFound Then Exit Sub

    If s_chg = False And s_full = False Then    '#sec
      MyFrmTA101.TBarSave.Visible = False
    End If
    With myTXXPROP
      TxtDesc.Text = Trim(._TXDESC)
    End With
  End Sub
  Private Sub FrmTA101C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA101.SbpScreen.Text = "TA101C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmTA101C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA101.TBarNew.Enabled = True
    MyFrmTA101.TBarDelete.Enabled = False
    MyFrmTA101.TBarSave.Enabled = False
    MyFrmTA101.TBarPrint.Enabled = False
    MyFrmTA101.TBarSave.Visible = True   '#sec
    MyFrmTA101B.FormatGrid()
    MyFrmTA101B.Show()
  End Sub
  Public Sub DeleteData(ByRef WrkCancel As Boolean)
    Dim Answer As Integer
    WrkCancel = True
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    WrkCancel = False
    myTXXPROP.DeleteOneRecordP()
    Me.Close()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myTXXPROP.GetOneRecordP(TxtCode.Text)
    If Wrkprexem = "" Then
      If Not myTXXPROP.RecordNotFound Then
        Me.ErrProv.SetError(TxtCode, "Record already exists")
        Exit Sub
      End If
    End If
    If Wrkprexem <> "" Then
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXXPROP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myTXXPROP._PREXEM = TxtCode.Text
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myTXXPROP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
    Me.Close()
  End Sub
  Private Sub MovetoFile()
    With myTXXPROP
      ._TXDESC = TxtDesc.Text
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
      ErrorField(I) = "prexem"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "txdesc"
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
        Case "prexem"
          ErrProv.SetError(TxtCode, ErrorMsg(I))
        Case "txdesc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
End Class
