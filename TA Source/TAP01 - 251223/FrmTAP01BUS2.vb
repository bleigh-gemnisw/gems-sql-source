Public Class FrmTAP01BUS2
  Dim MyTXDCBUS As TXDCBUS.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP01BUS2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01BUS.FormatGrid()
    MyFrmTAP01BUS.Show()
End Sub
Private Sub FrmTAP01BUS2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCBUS = New TXDCBUS.mydata(MyDBConnect)

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
    MyTXDCBUS.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCBUS.RecordNotFound Then Exit Sub

    With MyTXDCBUS
      TxtName.Text = Trim(._BNAME)
      TxtAddr.Text = Trim(._BADDR)
      TxtCity.Text = Trim(._BCITY)
      TxtState.Text = Trim(._BSTATE)
      If ._BZIP5 > 0 Then
        TxtZip5.Text = Format(._BZIP5, "00000")
      End If
      If ._BZIP4 > 0 Then
        TxtZip4.Text = Format(._BZIP4, "0000")
      End If
    End With

End Sub
  Private Sub FrmTAP01BUS2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01BUS2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCBUS.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCBUS.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCBUS.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCBUS.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCBUS.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCBUS.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCBUS
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._BNAME = TxtName.Text
        ._BADDR = TxtAddr.Text
        ._BCITY = TxtCity.Text
        ._BSTATE = TxtState.Text
        ._BZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._BZIP4 = MyUtils.CnvSng(TxtZip4.Text)
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
Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





