Public Class FrmTAP01HOR2
  Dim MyTXDCHOR As TXDCHOR.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer
  Dim cCode As Integer = 11
  Dim cLetter As String = String.Empty

Private Sub FrmTAP01HOR2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01HOR.FormatGrid()
    MyFrmTAP01HOR.Show()
End Sub
Private Sub FrmTAP01HOR2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCHOR = New TXDCHOR.mydata(MyDBConnect)

    With MyFrmTAP01
      .TbForms.Visible = False
      .TBarNew.Enabled = False
      If WrkSeqNo > 0 Then
        .TBarDelete.Enabled = True
      End If
      .TBarSave.Enabled = True
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    MyTXDCHOR.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCHOR.RecordNotFound Then Exit Sub

    With MyTXDCHOR
      TxtBreed.Text = Trim(._BREED)
      TxtReg.Text = Trim(._REG)
      TxtAge.Text = ._AGE
      Select Case Trim(._SEX)
      Case "F"
        RbSexFemale.Checked = True
      Case "M"
        RbSexMale.Checked = True
      Case Else
        RbSexUnknown.Checked = True
      End Select
      Select Case Trim(._QUALCD)
      Case "B"
        RbQualBreeding.Checked = True
      Case "S"
        RbQualShow.Checked = True
      Case "P"
        RbQualPleasure.Checked = True
      Case "R"
        RbQualRacing.Checked = True
      Case Else
        RbQualUnknown.Checked = True
      End Select
      TxtValue.Text = ._VALUE
    End With

End Sub
  Private Sub FrmTAP01HOR2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01HOR2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Dim WrkDiff As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCHOR.DeleteOneRecordP()
    WrkDiff = MyUtils.CnvSng(TxtValue.Text) * -1
    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
  End Sub
  Public Sub SaveData()
    Dim WrkDiff As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCHOR.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCHOR.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCHOR.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text) - MyTXDCHOR._VALUE
        MoveToFile()
        MyTXDCHOR.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text)
        MoveToFile()
        MyTXDCHOR.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCHOR
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._BREED = Trim(TxtBreed.Text)
        ._REG = Trim(TxtReg.Text)
        ._AGE = MyUtils.CnvSng(TxtAge.Text)
        If RbSexFemale.Checked Then ._SEX = "F"
        If RbSexMale.Checked Then ._SEX = "M"
        If RbSexUnknown.Checked Then ._SEX = ""
        If RbQualBreeding.Checked Then ._QUALCD = "B"
        If RbQualShow.Checked Then ._QUALCD = "S"
        If RbQualPleasure.Checked Then ._QUALCD = "P"
        If RbQualRacing.Checked Then ._QUALCD = "R"
        If RbQualUnknown.Checked Then ._QUALCD = ""
        ._VALUE = MyUtils.CnvSng(TxtValue.Text)
      End With
   End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub

Private Sub TxtAge_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAge.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





