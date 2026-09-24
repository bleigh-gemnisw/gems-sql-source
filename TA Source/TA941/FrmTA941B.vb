Imports System.Text
Imports System.IO
Public Class FrmTA941B

Private Sub FrmTA941B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmTA941.SbpScreen.Text = "TA941B"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmTA941B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  LblListNo.Text = ""
  LblName.Text = ""
  LblValue.Text = ""
  MyFrmTA941.TBarProcess.Enabled = False
  BtnContinue.Enabled = False
End Sub
Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .Filter = "CSV|*.csv"
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If
  End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblFilePath, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub

Private Sub BtnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheck.Click
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    CheckFormat()
End Sub
Private Sub CheckFormat()
Dim WrkStream As FileStream = New FileStream(MyFrmTA941B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim cQuote As String = Chr(34)
Dim StrBuffer As String
Dim Hdrarray() As String
Dim Sarray() As String
Dim I As Integer
Dim WrkError As Boolean

StrBuffer = sr.ReadLine
Hdrarray = Split(StrBuffer, ",")
If UBound(Hdrarray) = 0 Then
  MsgBox("Invalid File Format", MsgBoxStyle.Exclamation, "File must be CSV format")
  GoTo Done
End If

MyColListNo = -1
MyColName = -1
MyColValue = -1
For I = 0 To Hdrarray.GetUpperBound(0)
  Select Case UCase(Hdrarray(I))
  Case "LIST_NO", "LISTNO"
    MyColListNo = I
  Case "TAXPAYER"
    MyColName = I
  Case "VALUE"
    MyColValue = I
  End Select
Next

Done:
  WrkError = False
  StrBuffer = sr.ReadLine
  StrBuffer = Replace(StrBuffer, cQuote, "")
  Sarray = Split(StrBuffer, ",")
  If MyColListNo >= 0 Then
    LblListNo.Text = Sarray(MyColListNo)
  Else
    LblListNo.Text = "*** Column LISTNO or LIST_NO is missing***"
    WrkError = True
  End If
  If MyColName >= 0 Then
    LblName.Text = Sarray(MyColName)
  Else
    LblName.Text = "*** Column TAXPAYER is missing***"
    WrkError = True
  End If
  If MyColValue >= 0 Then
    LblValue.Text = Sarray(MyColValue)
  Else
    LblValue.Text = "*** Column VALUE is missing***"
    WrkError = True
  End If
  If WrkError Then
    Exit Sub
  End If

  BtnContinue.Enabled = True
End Sub

Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
  MyFrmTA941.TBarProcess.Enabled = True
  MyFrmTA941C = New FrmTA941C
  MyFrmTA941C.MdiParent = MyFrmTA941B.MdiParent
  MyFrmTA941C.Show()
  Me.Hide()
End Sub
End Class





