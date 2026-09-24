Public Class FrmTAP03SUM2
  Dim MyTXDCSUM As TXDCSUM.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkCode As Integer
  Friend WrkDesc As String
  Friend WrkPct As Decimal

Private Sub FrmTAP03SUM2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP03
      .TbForms.Visible = True
      .TBarSave.Enabled = False
    End With
    MyFrmTAP03SUM.BuildGrid()
    MyFrmTAP03SUM.Show()
End Sub
Private Sub FrmTAP03SUM2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkValue As Integer

    MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)

    With MyFrmTAP03
      .TbForms.Visible = False
      .TBarSave.Enabled = True
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblCode.Text = WrkCode
    LblDesc.Text = WrkDesc

    MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
    If MyTXDCSUM.RecordNotFound Then
      If WrkCode = 25 Then
        WrkValue = MyUtils.Round(MyUtils.CnvSng(MyFrmTAP03SUM.LblAssrNet.Text) * 0.25, 0)
        TxtDeprValue.Text = WrkValue
        LblAssrNet.Text = WrkValue
      End If
      Exit Sub
    End If

    With MyTXDCSUM
      TxtDeprValue.Text = ._VALUE
      LblAssrNet.Text = ._NET
    End With

End Sub
  Private Sub FrmTAP03SUM2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP03.SbpScreen.Text = "TAP03SUM2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
    If Not MyTXDCSUM.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If MyUtils.CnvSng(TxtDeprValue.Text) = 0 Then
          MyTXDCSUM.DeleteOneRecordP()
        Else
          MoveToFile()
          MyTXDCSUM.UpdateOneRecordP()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCSUM.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      Dim WrkDiff As Integer

      With MyTXDCSUM
        WrkDiff = MyUtils.CnvSng(TxtDeprValue.Text) - ._VALUE
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._CODE = WrkCode
        ._VALUE = MyUtils.CnvSng(TxtDeprValue.Text)
        If MyDeclRound And WrkCode <> 25 Then
          ._NET = RoundNumber(MyUtils.CnvSng(LblAssrNet.Text), "Normal")
        Else
          ._NET = MyUtils.CnvSng(LblAssrNet.Text)
        End If
        If WrkDiff <> 0 Then
          ._STATUS = "K"
        End If
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
Private Sub TxtDeprValue_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDeprValue.KeyUp

  If WrkPct > 0 Then
    LblAssrNet.Text = MyUtils.Round(MyUtils.CnvSng(TxtDeprValue.Text) * (WrkPct / 100), 0)
  Else
    LblAssrNet.Text = MyUtils.CnvSng(TxtDeprValue.Text)
  End If
End Sub

Private Sub TxtDeprValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDeprValue.TextChanged

End Sub
End Class





