Public Class FrmTAP01TWN2
  Dim MyTXDCTWN As TXDCTWN.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP01TWN2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01TWN.FormatGrid()
    MyFrmTAP01TWN.Show()
End Sub
Private Sub FrmTAP01TWN2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCTWN = New TXDCTWN.mydata(MyDBConnect)

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
    MyTXDCTWN.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCTWN.RecordNotFound Then Exit Sub

    With MyTXDCTWN
      TxtMonths.Text = Trim(._MONTHS)
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtCost.Text = ._COST
    End With

End Sub
  Private Sub FrmTAP01TWN2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01TWN2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCTWN.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCTWN.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCTWN.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCTWN.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCTWN.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCTWN.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCTWN
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._MONTHS = TxtMonths.Text
        ._LOCNO = TxtLocNo.Text
        ._LOC = TxtLoc.Text
        ._COST = MyUtils.CnvSng(TxtCost.Text)
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
Private Sub TxtCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCost.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





