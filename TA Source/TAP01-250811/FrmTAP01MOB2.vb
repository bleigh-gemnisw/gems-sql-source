Public Class FrmTAP01MOB2
  Dim MyTXDCMOB As TXDCMOB.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer
  Dim cCode As Integer = 14
  Dim cLetter As String = String.Empty

Private Sub FrmTAP01MOB2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01MOB.FormatGrid()
    MyFrmTAP01MOB.Show()
End Sub
Private Sub FrmTAP01MOB2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCMOB = New TXDCMOB.mydata(MyDBConnect)

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
    MyTXDCMOB.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCMOB.RecordNotFound Then Exit Sub

    With MyTXDCMOB
      TxtVYear.Text = ._VYEAR
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtVIN.Text = Trim(._VINNO)
      TxtLength.Text = ._LENGTH
      TxtWidth.Text = ._WIDTH
      TxtBedrms.Text = ._BEDRMS
      TxtBaths.Text = ._BATHS
      TxtValue.Text = ._VALUE
    End With

End Sub
  Private Sub FrmTAP01MOB2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01MOB2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Dim WrkDiff As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCMOB.DeleteOneRecordP()
    WrkDiff = MyUtils.CnvSng(TxtValue.Text) * -1
    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
  End Sub
  Public Sub SaveData()
    Dim WrkDiff As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCMOB.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCMOB.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCMOB.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text) - MyTXDCMOB._VALUE
        MoveToFile()
        MyTXDCMOB.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text)
        MoveToFile()
        MyTXDCMOB.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCMOB
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._VYEAR = MyUtils.CnvSng(TxtVYear.Text)
        ._MAKE = TxtMake.Text
        ._MODEL = TxtModel.Text
        ._VINNO = TxtVIN.Text
        ._LENGTH = MyUtils.CnvSng(TxtLength.Text)
        ._WIDTH = MyUtils.CnvSng(TxtWidth.Text)
        ._BEDRMS = MyUtils.CnvSng(TxtBedrms.Text)
        ._BATHS = MyUtils.CnvSng(TxtBaths.Text)
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

Private Sub TxtLength_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLength.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtWidth.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtBedrms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBedrms.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtBaths_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaths.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





