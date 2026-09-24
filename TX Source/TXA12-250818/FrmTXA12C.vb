Public Class FrmTXA12C
Dim myTXINV As TXINV.myData

Private Sub FrmTXA12C_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  MyFrmTXA12.TBarMassTransfer.Enabled = True
  MyFrmTXA12.TBarSingleTransfer.Enabled = True
  MyFrmTXA12B.Show()
End Sub
Private Sub TxtFromList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromList.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToList.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTXA12C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXA12.SbpScreen.Text = "TXA12C"
End Sub
Private Sub TxtFromYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtToYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub FrmTXA12C_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  myTXINV = New TXINV.mydata(MyDBConnect)
  DtPckPost.Value = Date.Today
  MyUtils.SetTxtReadOnly(TxtTransfer)
  BtnTransfer.Enabled = False
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtFromYear, "")
    ErrProv.SetError(TxtToYear, "")
    ErrProv.SetError(TxtTransfer, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "from"
        ErrProv.SetError(TxtFromYear, ErrorMsg(I))
      Case "to"
        ErrProv.SetError(TxtToYear, ErrorMsg(I))
      Case "transfer"
        ErrProv.SetError(TxtTransfer, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim dstxinv As DataSet = New DataSet
    Dim WrkFamily As String
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtFromList.Text), MyUtils.CnvSng(TxtFromYear.Text), TxtFromType.Text)
    If myTXINV.RecordNotFound Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "Invalid From Account"
      I = I + 1
    End If

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtToList.Text), MyUtils.CnvSng(TxtToYear.Text), TxtToType.Text)
    If myTXINV.RecordNotFound Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid To Account"
      I = I + 1
    End If

    WrkFamily = GetTXTypeFamily(TxtFromType.Text)
    If WrkFamily = "A" Then
      ErrorField(I) = "from"
      ErrorMsg(I) = "UB Assessment Tax Types are not valid for this option"
      I = I + 1
    End If
    WrkFamily = GetTXTypeFamily(TxtToType.Text)
    If WrkFamily = "A" Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "UB Assessment Tax Types are not valid for this option"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtTransfer.Text) = 0 Then
      ErrorField(I) = "transfer"
      ErrorMsg(I) = "Transfer Amount cannot be 0"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtTransfer.Text) > Math.Abs(MyUtils.CnvSng(LblFromBeforeBal.Text)) Then
      ErrorField(I) = "transfer"
      ErrorMsg(I) = "Transfer Amount cannot be more than credit amount"
      I = I + 1
    End If
  End Sub
Public Sub Transfer()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    If ErrProv.GetError(TxtFromYear) <> "" Then
      MsgBox("Correct error and retry", MsgBoxStyle.Exclamation, "Transfer cancelled")
      Exit Sub
    End If
    If ErrProv.GetError(TxtToYear) <> "" Then
      MsgBox("Correct error and retry", MsgBoxStyle.Exclamation, "Transfer cancelled")
      Exit Sub
    End If

    EditChecks(ErrorField, ErrorMsg)
    ShowError(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    SingleXfer()

    'Reset screen to defaults after posting
    Reset()
    Windows.Forms.Cursor.Current = Cursors.Default

End Sub

Private Sub TxtFromYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFromYear.LostFocus
    Dim WrkFamily As String
    Dim WrkTaxDue As Decimal
    Dim WrkTaxRcv As Decimal
    Dim WrkTaxBal As Decimal
    Dim WrkLastHistDate As Integer
    Dim WrkError As Boolean

    WrkError = False
    ErrProv.SetError(TxtFromYear, "")

    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtFromList.Text), MyUtils.CnvSng(TxtFromYear.Text), TxtFromType.Text)
    If myTXINV.RecordNotFound Then
      ErrProv.SetError(TxtFromYear, "Invalid Account")
      LblFromTax.Text = ""
      LblFromName.Text = ""
      LblFromDesc.Text = ""
      LblFromBeforeBal.Text = ""
      LblFromAfterBal.Text = ""
      LblFromHist.Text = ""
      WrkError = True
    Else
      With myTXINV
        If ._BALD >= 0 Then
          ErrProv.SetError(TxtFromYear, "Account does not have credit balance")
          WrkError = True
        End If
        WrkTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkTaxDue = ._CCETAX
        Else
          WrkTaxDue = ._TAXT
        End If
        WrkTaxBal = WrkTaxDue - WrkTaxRcv
        LblFromName.Text = Trim(._NAME)
        WrkFamily = GetTXTypeFamily(TxtFromType.Text)
        Select Case WrkFamily
        Case "M", "S"
          LblFromDesc.Text = Trim(myTXINV._MAKE) & " " & Trim(myTXINV._MVYR) & " " & myTXINV._IMVREG
        Case Else
          LblFromDesc.Text = Trim(myTXINV._LOCNo) & " " & myTXINV._LOC
        End Select
        LblFromTax.Text = WrkTaxDue
        LblFromBeforeBal.Text = Format(WrkTaxBal, "fixed")
        If Not WrkError Then
          LblFromAfterBal.Text = Format(0, "fixed")
          TxtTransfer.Text = Format(Math.Abs(WrkTaxBal), "fixed")
        End If
      End With
    End If

    If WrkError Then
      MyUtils.SetTxtReadOnly(TxtTransfer)
      TxtTransfer.Text = ""
    Else
      TxtTransfer.ReadOnly = False
      TxtTransfer.BackColor = Color.White
    End If

    WrkLastHistDate = GetLastHist(MyUtils.CnvSng(TxtFromList.Text), MyUtils.CnvSng(TxtFromYear.Text), TxtFromType.Text, 99999999)
    If WrkLastHistDate > 0 Then
      LblFromHist.Text = "Last activity was on " & MyUtils.GetDBDate(WrkLastHistDate)
    Else
      LblFromHist.Text = String.Empty
    End If
    LblFromHist.ForeColor = Color.Black
    If MyUtils.GetDBDate(WrkLastHistDate) > DtPckPost.Value Or WrkError Then
      LblFromHist.ForeColor = Color.Red
    End If
End Sub
Private Sub TxtToYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtToYear.LostFocus
    Dim WrkFamily As String
    Dim WrkTaxDue As Decimal
    Dim WrkTaxRcv As Decimal
    Dim WrkTaxBal As Decimal
    Dim WrkLastHistDate As Integer
    Dim WrkError As Boolean

    WrkError = False
    ErrProv.SetError(TxtToYear, "")
    myTXINV.GetOneRecordP(MyUtils.CnvSng(TxtToList.Text), MyUtils.CnvSng(TxtToYear.Text), TxtToType.Text)
    If myTXINV.RecordNotFound Then
      ErrProv.SetError(TxtToYear, "Invalid Account")
      LblToBeforeBal.Text = ""
      LblToAfterBal.Text = ""
      LblToTax.Text = ""
      LblToName.Text = ""
      LblToDesc.Text = ""
      LblToHist.Text = ""
      LblTransferTax.Text = ""
      LblTransferInt.Text = ""
      LblTransferTot.Text = ""
      WrkError = True
    Else
      With myTXINV
        If ._BALD <= 0 Then
          ErrProv.SetError(TxtToYear, "Account does not have a balance")
          WrkError = True
        End If
        WrkTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkTaxDue = ._CCETAX
        Else
          WrkTaxDue = ._TAXT
        End If
        WrkTaxBal = WrkTaxDue - WrkTaxRcv
        LblToName.Text = Trim(._NAME)
        WrkFamily = GetTXTypeFamily(TxtToType.Text)
        Select Case WrkFamily
        Case "M", "S"
          LblToDesc.Text = Trim(myTXINV._MAKE) & " " & Trim(myTXINV._MVYR) & " " & myTXINV._IMVREG
        Case Else
          LblToDesc.Text = Trim(myTXINV._LOCNo) & " " & myTXINV._LOC
        End Select
        LblToTax.Text = WrkTaxDue
        LblToBeforeBal.Text = Format(WrkTaxBal, "fixed")
      End With
    End If

    WrkLastHistDate = GetLastHist(MyUtils.CnvSng(TxtToList.Text), MyUtils.CnvSng(TxtToYear.Text), TxtToType.Text, 99999999)
    If WrkLastHistDate > 0 Then
      LblToHist.Text = "Last activity was on " & MyUtils.GetDBDate(WrkLastHistDate)
    Else
      LblToHist.Text = String.Empty
    End If
    LblToHist.ForeColor = Color.Black
    If MyUtils.GetDBDate(WrkLastHistDate) > DtPckPost.Value Or WrkError Then
      LblToHist.ForeColor = Color.Red
    End If

    CheckInt()
    If LblFromHist.ForeColor = Color.Black And LblToHist.ForeColor = Color.Black Then
      BtnTransfer.Enabled = True
      BtnTransfer.Focus()
    End If
End Sub
Private Sub BtnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransfer.Click
  Transfer()
End Sub
Private Sub Reset()
  ErrProv.Clear()
  TxtFromList.Text = ""
  TxtFromType.Text = ""
  TxtFromYear.Text = ""
  TxtToList.Text = ""
  TxtToType.Text = ""
  TxtToYear.Text = ""
  LblFromTax.Text = ""
  LblFromName.Text = ""
  LblFromDesc.Text = ""
  LblFromBeforeBal.Text = ""
  LblFromAfterBal.Text = ""
  LblFromHist.Text = ""
  LblToBeforeBal.Text = ""
  LblToAfterBal.Text = ""
  LblToTax.Text = ""
  LblToName.Text = ""
  LblToDesc.Text = ""
  LblToHist.Text = ""
  LblTransferTax.Text = ""
  LblTransferInt.Text = ""
  LblTransferFee.Text = ""
  LblTransferTot.Text = ""
  MyUtils.SetTxtReadOnly(TxtTransfer)
  TxtTransfer.Text = ""
  BtnTransfer.Enabled = False
End Sub
Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
  Reset()
End Sub
Private Sub TxtFromType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromType.KeyPress
  'Move to next field after anything has been typed since it's only 1 char allowed
  Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
End Sub
Private Sub TxtToType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToType.KeyPress
  'Move to next field after anything has been typed since it's only 1 char allowed
  Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
End Sub
Private Sub CheckInt()
  Dim WrkPaid As Decimal
  Dim WrkTransferTot As Decimal
  Dim OutInterest As Decimal
  Dim OutInterestPaid As Decimal
  Dim OutFee As Decimal
  Dim OutLien As Decimal
  Dim OutBond As Decimal
  Dim OutTax As Decimal
  Dim OutDue As Decimal
  Dim WrkTransferInterest As Decimal
  Dim WrkTransferFee As Decimal
  Dim WrkTransferTax As Decimal

  WrkPaid = MyUtils.CnvSng(TxtTransfer.Text)
  WrkTransferInterest = 0
  WrkTransferFee = 0
  WrkTransferTax = MyUtils.CnvSng(TxtTransfer.Text)
  WrkTransferTot = 0
  CalcInterest(DtPckPost.Value, MyUtils.CnvSng(TxtToList.Text), TxtToType.Text, MyUtils.CnvSng(TxtToYear.Text), _
    OutInterest, OutInterestPaid, OutFee, OutLien, OutBond, OutTax, OutDue)
    If OutInterest >= WrkPaid Then
      OutInterest = WrkPaid
      WrkPaid = 0
    Else
     WrkPaid = WrkPaid - OutInterest
    End If
    If OutFee >= WrkPaid Then
     OutFee = WrkPaid
     WrkPaid = 0
    Else
     WrkPaid = WrkPaid - OutFee
    End If
    If OutBond >= WrkPaid Then
     OutBond = WrkPaid
     WrkPaid = 0
    Else
     WrkPaid = WrkPaid - OutBond
    End If
    If WrkPaid >= (OutTax + OutLien) And OutLien > 0 Then
     WrkPaid = WrkPaid - OutLien
    Else
     OutLien = 0
    End If
    LblTransferInt.Text = Format(OutInterest, "fixed")
    LblTransferFee.Text = Format(OutFee, "fixed")
    LblTransferTax.Text = Format(WrkPaid, "fixed")

 WrkTransferTot = WrkPaid + OutInterest + OutFee
 LblTransferTot.Text = Format(WrkTransferTot, "fixed")
 LblToAfterBal.Text = Format(MyUtils.CnvSng(LblToBeforeBal.Text) - WrkPaid, "fixed")
End Sub
Private Sub DtPckPost_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckPost.ValueChanged
    Dim WrkLastHistDate As Integer

    WrkLastHistDate = GetLastHist(MyUtils.CnvSng(TxtFromList.Text), MyUtils.CnvSng(TxtFromYear.Text), TxtFromType.Text, 99999999)
    LblFromHist.ForeColor = Color.Black
    If MyUtils.GetDBDate(WrkLastHistDate) > DtPckPost.Value Then
      LblFromHist.ForeColor = Color.Red
    End If
    WrkLastHistDate = GetLastHist(MyUtils.CnvSng(TxtToList.Text), MyUtils.CnvSng(TxtToYear.Text), TxtToType.Text, 99999999)
    LblToHist.ForeColor = Color.Black
    If MyUtils.GetDBDate(WrkLastHistDate) > DtPckPost.Value Then
      LblToHist.ForeColor = Color.Red
    End If

    BtnTransfer.Enabled = False
    If LblFromHist.ForeColor = Color.Black And LblToHist.ForeColor = Color.Black Then
      If LblTransferTot.Text <> String.Empty Then
        BtnTransfer.Enabled = True
      End If
    End If
End Sub
Private Sub TxtTransfer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTransfer.KeyPress
 e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtTransfer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTransfer.TextChanged
 CalcTransfer()
 If BtnTransfer.Enabled Then
  CheckInt()
 End If
End Sub
Private Sub CalcTransfer()
 Dim WrkFromAfterBal As Decimal

 WrkFromAfterBal = MyUtils.CnvSng(LblFromBeforeBal.Text) + MyUtils.CnvSng(TxtTransfer.Text)
 LblFromAfterBal.Text = Format(WrkFromAfterBal, "fixed")
End Sub
Private Sub LnkFee_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFee.LinkClicked
  Dim WrkMVFee As Decimal

  WrkMVFee = 0
  If myTXINV._MVFLAG = "Y" Then
    WrkMVFee = MyMVFee
  End If

  MyFrmTXA12Fees = New FrmTXA12Fees
  With MyFrmTXA12Fees
   .WrkListNo = MyUtils.CnvSng(TxtToList.Text)
   .WrkYear = MyUtils.CnvSng(TxtToYear.Text)
   .WrkType = TxtToType.Text
   .WrkCode1 = Trim(myTXINV._FEC1)
   .WrkCode2 = Trim(myTXINV._FEC2)
   .WrkCode3 = Trim(myTXINV._FEC3)
   .WrkCode4 = Trim(myTXINV._FEC4)
   .WrkCode5 = Trim(myTXINV._FEC5)
   .WrkAmt1 = Trim(myTXINV._FED1)
   .WrkAmt2 = Trim(myTXINV._FED2)
   .WrkAmt3 = Trim(myTXINV._FED3)
   .WrkAmt4 = Trim(myTXINV._FED4)
   .WrkAmt5 = Trim(myTXINV._FED5)
   .WrkMVFee = WrkMVFee
   .MdiParent = Me.ParentForm
   .Show()
  End With
  Me.Hide()
End Sub
End Class






