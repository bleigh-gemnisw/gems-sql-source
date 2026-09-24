Public Class FrmUB112C
  Inherits System.Windows.Forms.Form
  Dim myUTMRESN As UTMRESN.myData
  Friend WrkMresn As String
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
Friend WithEvents TxtMresn As System.Windows.Forms.TextBox
Friend WithEvents TxtMrdesc As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMresn = New System.Windows.Forms.TextBox()
    Me.TxtMrdesc = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(24, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Code"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtMresn
    '
    Me.TxtMresn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMresn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMresn.Location = New System.Drawing.Point(72, 16)
    Me.TxtMresn.MaxLength = 3
    Me.TxtMresn.Name = "TxtMresn"
    Me.TxtMresn.Size = New System.Drawing.Size(34, 22)
    Me.TxtMresn.TabIndex = 0
    '
    'TxtMrdesc
    '
    Me.TxtMrdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMrdesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMrdesc.Location = New System.Drawing.Point(72, 48)
    Me.TxtMrdesc.MaxLength = 30
    Me.TxtMrdesc.Multiline = True
    Me.TxtMrdesc.Name = "TxtMrdesc"
    Me.TxtMrdesc.Size = New System.Drawing.Size(256, 24)
    Me.TxtMrdesc.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(0, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 24)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Description"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmUB112C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(354, 94)
    Me.Controls.Add(Me.TxtMrdesc)
    Me.Controls.Add(Me.TxtMresn)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmUB112C"
    Me.Text = "Maintain Reason Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmUB112C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myUTMRESN = New UTMRESN.mydata(MyDBConnect)
  MyFrmUB112.TBarNew.Enabled = False
  MyFrmUB112.TBarSave.Enabled = True
  If WrkMresn <> "" Then
    MyFrmUB112.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(TxtMresn)
  End If
  MyFrmUB112.TBarPrint.Enabled = False
  myUTMRESN.GetOneRecordP(WrkMresn)
  TxtMresn.Text = WrkMresn
  If myUTMRESN.RecordNotFound Then Exit Sub

  If s_chg = False And s_full = False Then    '#sec
    MyFrmUB112.TBarSave.Visible = False
  End If
  With myUTMRESN
    TxtMrdesc.Text = Trim(._MRDESC)
  End With
End Sub
Private Sub FrmUB112C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB112.SbpScreen.Text = "UB112C"
  MyUtils.CenterForm(Me.ParentForm, Me)
  With MyFrmUB112
    .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
  End With
End Sub
Private Sub FrmUB112C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmUB112.TBarNew.Enabled = True
  MyFrmUB112.TBarDelete.Enabled = False
  MyFrmUB112.TBarSave.Enabled = False
  MyFrmUB112.TBarPrint.Enabled = False
  MyFrmUB112.TBarSave.Visible = True   '#sec
  MyFrmUB112B.FormatGrid()
  MyFrmUB112B.Show()
End Sub
Public Sub DeleteData(ByRef WrkCancel As Boolean)
  Dim Answer As Integer
  WrkCancel = True
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If
  WrkCancel = False
  myUTMRESN.DeleteOneRecordP()
  Me.Close()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  myUTMRESN.GetOneRecordP(TxtMresn.Text)
  If WrkMresn = "" Then
    If Not myUTMRESN.RecordNotFound Then
      Me.ErrProv.SetError(TxtMresn, "Record already exists")
      Exit Sub
    End If
  End If
  If WrkMresn <> "" Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTMRESN.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    myUTMRESN._MRESN = TxtMresn.Text
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myUTMRESN.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myUTMRESN
    ._MRDESC = TxtMrdesc.Text
  End With
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtMresn.Text = String.Empty Then
      ErrorField(I) = "MRESN"
      ErrorMsg(I) = "Code is required"
      I = I + 1
    End If
    If TxtMrdesc.Text = String.Empty Then
      ErrorField(I) = "MRDESC"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtMresn, "")
  ErrProv.SetError(TxtMrdesc, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "MRESN"
      ErrProv.SetError(TxtMresn, ErrorMsg(I))
    Case "MRDESC"
      ErrProv.SetError(TxtMrdesc, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class







