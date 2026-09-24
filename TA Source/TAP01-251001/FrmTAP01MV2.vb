Public Class FrmTAP01MV2
  Dim MyTXDCMV As TXDCMV.MyData
  Dim MyTXMSRPDEP As TXMSRPDEP.MyData
  Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
  Dim myPriceDigestValue As PriceDigestAPI.ApiValue
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer
  Dim cCode As Integer = 9
  Dim cLetter As String = String.Empty

  Private Sub FrmTAP01MV2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01MV.FormatGrid()
    MyFrmTAP01MV.Show()
  End Sub
  Private Sub FrmTAP01MV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCMV = New TXDCMV.MyData(myDBConnect)
    MyTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)

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
    LblNoData.Visible = False
    MyTXDCMV.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCMV.RecordNotFound Then Exit Sub

    With MyTXDCMV
      TxtVYear.Text = ._VYEAR
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtVIN.Text = Trim(._VINNO)
      TxtLength.Text = ._LENGTH
      TxtWeight.Text = ._WEIGHT
      TxtPurvl.Text = ._PURVL
      If ._PURDT > 0 Then
        DtPckPurDt.Value = MyUtils.GetDBDate(._PURDT)
        DtPckPurDt.Checked = True
      End If
      TxtValue.Text = ._VALUE
      If ._MSRP > 0 Then
        TxtMSRP.Text = ._MSRP
      End If
    End With

  End Sub
  Private Sub FrmTAP01MV2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01MV2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Dim WrkDiff As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCMV.DeleteOneRecordP()
    WrkDiff = MyUtils.CnvSng(TxtValue.Text) * -1
    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
  End Sub
  Public Sub SaveData()
    Dim WrkDiff As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCMV.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCMV.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCMV.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text) - MyTXDCMV._VALUE
        MoveToFile()
        MyTXDCMV.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiff = MyUtils.CnvSng(TxtValue.Text)
        MoveToFile()
        MyTXDCMV.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    WriteTXDCSUM(WrkListNo, WrkYear, cCode, cLetter, WrkDiff)
    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXDCMV
      ._LISTNO = WrkListNo
      ._YEAR = WrkYear
      ._SEQNO = WrkSeqNo
      ._VYEAR = MyUtils.CnvSng(TxtVYear.Text)
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._VINNO = TxtVIN.Text
      ._LENGTH = MyUtils.CnvSng(TxtLength.Text)
      ._WEIGHT = MyUtils.CnvSng(TxtWeight.Text)
      ._PURVL = MyUtils.CnvSng(TxtPurvl.Text)
      If DtPckPurDt.Checked Then
        ._PURDT = MyUtils.SetDBDate(DtPckPurDt.Value)
      Else
        ._PURDT = 0
      End If
      ._VALUE = MyUtils.CnvSng(TxtValue.Text)
      ._MSRP = MyUtils.CnvSng(TxtMSRP.Text)
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
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case ""
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub TxtMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    'MK 9/29/25 Begin
    'Dim WrkYear As Integer
    Dim WrkVehYear As Integer
    'MK 9/29/25 Begin
    WrkMSRP = MyUtils.CnvSng(TxtMSRP.Text)
    WrkOvMSRP = 0
    'MK 9/29/25 Begin
    'WrkYear = MyUtils.CnvSng(TxtVYear.Text)
    WrkVehYear = MyUtils.CnvSng(TxtVYear.Text)
    'TxtValue.Text = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear)
    TxtValue.Text = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear, WrkVehYear)
    'MK 9/29/25 Begin
  End Sub
  'MK 9/29/25 Begin
  'Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer) As Integer
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer,
    ByVal WrkVehYear As Integer) As Integer
    'MK 9/29/25 Begin
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    'MK 8/11/25 Begin
    'WrkDeYear = 2024 - WrkYear + 1
    'If WrkDeYear < 1 Then
    '  WrkDeYear = 1
    'End If
    WrkDeYear = WrkYear - WrkVehYear + 1
    'MK 8/11/25 End
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr
    Else
      WrkValue = WrkMSRP * WrkDepr
    End If
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = MyTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Sub BtnPriceDigest_Click(sender As Object, e As EventArgs) Handles BtnPriceDigest.Click
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    With myPriceDigestVIN
      .GetApiVIN(TxtVIN.Text)
      If MyUtils.CnvSng(TxtVYear.Text) <> .modelYear Then 'If Vehicle year don't match it's an error
        .IsError = True
      End If
      If .IsError Then
        TxtMSRP.Text = ""
        LblNoData.Visible = True
        Exit Sub
      End If
    End With
    LblNoData.Visible = False
    With myPriceDigestValue
      .GetApiValue(myPriceDigestVIN.configurationId)
      TxtMSRP.Text = .MSRP
    End With
    TxtMSRP.Focus()
  End Sub
End Class





