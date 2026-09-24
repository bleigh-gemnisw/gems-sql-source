Public Class FrmTS002C
  Inherits System.Windows.Forms.Form
  Dim myMFTTYPE As MFTTYPE.MyData
  Dim ds As DataSet = New DataSet
  Friend wrkmfttyp As String
  Friend wrkmfpdes As String
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
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Txtmfttyp As System.Windows.Forms.TextBox
Friend WithEvents Txtmftypd As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Txtmfttyp = New System.Windows.Forms.TextBox
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label2 = New System.Windows.Forms.Label
Me.Txtmftypd = New System.Windows.Forms.TextBox
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(11, 64)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(76, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Code"
'
'Txtmfttyp
'
Me.Txtmfttyp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmfttyp.Location = New System.Drawing.Point(79, 60)
Me.Txtmfttyp.MaxLength = 2
Me.Txtmfttyp.Name = "Txtmfttyp"
Me.Txtmfttyp.Size = New System.Drawing.Size(28, 20)
Me.Txtmfttyp.TabIndex = 0
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(127, 62)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(69, 16)
Me.Label2.TabIndex = 28
Me.Label2.Text = "Description"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Txtmftypd
'
Me.Txtmftypd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.Txtmftypd.Location = New System.Drawing.Point(202, 60)
Me.Txtmftypd.MaxLength = 25
Me.Txtmftypd.Name = "Txtmftypd"
Me.Txtmftypd.Size = New System.Drawing.Size(373, 20)
Me.Txtmftypd.TabIndex = 2
'
'FrmTS002C
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(598, 169)
Me.Controls.Add(Me.Txtmftypd)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Txtmfttyp)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTS002C"
Me.Text = "Maintain Transfer Station Type"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region
Private Sub FrmTS002C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  myMFTTYPE = New MFTTYPE.mydata(MyDBConnect)
  MyFrmTS002.TBarNew.Enabled = False
  MyFrmTS002.TBarSave.Enabled = True
  MyFrmTS002.TBarPrint.Enabled = False
  If wrkmfttyp <> "" Then
    MyFrmTS002.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtmfttyp)
  End If
  If wrkmfttyp = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmTS002.TBarDelete.Enabled = False
    Exit Sub
    End If
  myMFTTYPE.GetOneRecordP(wrkmfttyp)
  If myMFTTYPE.RecordNotFound Then Exit Sub
  Txtmfttyp.Text = wrkmfttyp

  If s_chg = False And s_full = False Then    '#sec
    MyFrmTS002.TBarSave.Visible = False
  End If

  With myMFTTYPE
    Txtmftypd.Text = Trim(._MFTYPD)
  End With
End Sub
Private Sub FrmTS002C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTS002.SbpScreen.Text = "TS002C"
  MyUtils.CenterForm(Me.ParentForm, Me)

End Sub
Private Sub FrmTS002C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmTS002.TBarNew.Enabled = True
  MyFrmTS002.TBarDelete.Enabled = False
  MyFrmTS002.TBarSave.Enabled = False
  MyFrmTS002.TBarPrint.Enabled = False
  MyFrmTS002B.FormatGrid()
  MyFrmTS002B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
  myMFTTYPE.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
 myMFTTYPE.GetOneRecordP(Txtmfttyp.Text)
  If wrkmfttyp = "" Then
    If myMFTTYPE.RecordNotFound = False Then
      Me.ErrProv.SetError(Txtmfttyp, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myMFTTYPE.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFTTYPE.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFTTYPE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMFTTYPE
    ._MFTTYP = Trim(Txtmfttyp.Text)
    ._MFTYPD = Trim(Txtmftypd.Text)

  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtmfttyp, "")
  ErrProv.SetError(Txtmftypd, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "mfpcod"
      ErrProv.SetError(Txtmfttyp, ErrorMsg(I))
    Case "mfpdes"
      ErrProv.SetError(Txtmftypd, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  If Txtmfttyp.Text = Trim("") Then
      ErrorField(I) = "myttyp"
      ErrorMsg(I) = "Code Required"
      I = I + 1
  End If

  If Txtmftypd.Text = Trim("") Then
      ErrorField(I) = "mypdes"
      ErrorMsg(I) = "Description required"
      I = I + 1
  End If

End Sub
End Class






