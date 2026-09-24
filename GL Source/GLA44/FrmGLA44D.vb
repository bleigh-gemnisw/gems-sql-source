Public Class FrmGLA44D
  Dim myMUNMILD As MUNMILD.myData
  Dim ds As DataSet = New DataSet
  Friend WrkYear As Integer
  Private Sub FrmGLA44D_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myMUNMILD = New MUNMILD.MyData()
    myMUNMILD.MyDBConn = myDBConnect
    LoadForm()
  End Sub
Private Sub LoadForm()
  MyFrmGLA44.TBarNew.Enabled = False
  MyFrmGLA44.TBarSave.Enabled = True
  MyFrmGLA44.TBarDelete.Enabled = True
  MyFrmGLA44.TBarPrint.Enabled = False

  myMUNMILD.GetOneRecordP(WrkYear)
  If myMUNMILD.RecordNotFound Then
    MyFrmGLA44.TBarDelete.Enabled = False
    Exit Sub
  End If

  With myMUNMILD
    MyUtils.SetTxtReadOnly(TxtYear)
    TxtYear.Text = WrkYear
    TxtDspct.Text = ._DSPCT
  End With
End Sub
Private Sub FrmGLA44D_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmGLA44.SbpScreen.Text = "GLA44D"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub FrmGLA44D_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmGLA44.TBarNew.Enabled = True
  MyFrmGLA44.TBarDelete.Enabled = False
  MyFrmGLA44.TBarSave.Enabled = False
  MyFrmGLA44.TBarNew.Enabled = True
  MyFrmGLA44.TBarPrint.Enabled = False
  MyFrmGLA44B.FormatGridDS()
  MyFrmGLA44B.Show()
  'Memory Cleanup
  myMUNMILD = Nothing
  MyFrmGLA44D = Nothing
End Sub
Public Sub DeleteData()
  Dim Answer As Integer
  Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
  If Answer = vbNo Then
    Exit Sub
  End If

  myMUNMILD.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text))
  myMUNMILD.DeleteOneRecordP()
  Me.Close()
End Sub

Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  myMUNMILD.GetOneRecordP(MyUtils.CnvSng(TxtYear.Text))
  If WrkYear = 0 Then
    If Not myMUNMILD.RecordNotFound Then
      Me.ErrProv.SetError(TxtYear, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myMUNMILD.RecordNotFound Then
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myMUNMILD.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  Else
    MovetoFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      With myMUNMILD
        ._YEAR = TxtYear.Text
      End With
      myMUNMILD.AddOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
  End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMUNMILD
    ._DSPCT = MyUtils.CnvSng(TxtDspct.Text)
  End With
 End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If
  End Sub
 Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(TxtYear, String.Empty)
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "year"
      ErrProv.SetError(TxtYear, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
End Class