Imports System.Text
Module SingleTransfer

  Dim myTXINVFrom As TXINV.MyData
  Dim myTXINVTo As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen
  Dim WrkFromListNo As Integer
  Dim WrkFromType As String
  Dim WrkFromYear As Integer
  Dim WrkToListNo As Integer
  Dim WrkToType As String
  Dim WrkToYear As Integer
  Dim WrkPostDate As Integer

  Public Sub SingleXfer()
    myTXINVFrom = New TXINV.MyData(myDBConnect)
    myTXINVTo = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)

    With MyFrmTXA12C
      WrkFromListNo = MyUtils.CnvSng(.TxtFromList.Text)
      WrkFromType = .TxtFromType.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromYear.Text)
      WrkToListNo = MyUtils.CnvSng(.TxtToList.Text)
      WrkToType = .TxtToType.Text
      WrkToYear = MyUtils.CnvSng(.TxtToYear.Text)
      WrkPostDate = MyUtils.SetDBDate(.DtPckPost.Value)
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS(ds1)
    Else
      ds1.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.WrkPostDate = MyFrmTXA12C.DtPckPost.Value
    MyCrViewer.WrkPost = True
    MyCrViewer.Show()

  End Sub
  Private Sub GetDetail()

    dr = ds1.Tables(0).NewRow
    dr.Item("fromlistno") = WrkFromListNo
    dr.Item("fromtype") = WrkFromType
    dr.Item("fromyear") = WrkFromYear
    dr.Item("FromName") = MyFrmTXA12C.LblFromName.Text
    dr.Item("FromBeforeBal") = MyUtils.CnvSng(MyFrmTXA12C.LblFromBeforeBal.Text)
    dr.Item("FromAfterBal") = MyUtils.CnvSng(MyFrmTXA12C.LblFromAfterBal.Text)
    dr.Item("FromTransferTax") = MyUtils.CnvSng(MyFrmTXA12C.TxtTransfer.Text) * -1
    dr.Item("tolistno") = WrkToListNo
    dr.Item("totype") = WrkToType
    dr.Item("toyear") = WrkToYear
    dr.Item("ToName") = MyFrmTXA12C.LblToName.Text
    dr.Item("ToBeforeBal") = MyUtils.CnvSng(MyFrmTXA12C.LblToBeforeBal.Text)
    dr.Item("ToAfterBal") = MyUtils.CnvSng(MyFrmTXA12C.LblToAfterBal.Text)
    dr.Item("ToTransferTax") = Math.Abs(MyUtils.CnvSng(MyFrmTXA12C.LblTransferTax.Text))
    dr.Item("ToTransferInt") = Math.Abs(MyUtils.CnvSng(MyFrmTXA12C.LblTransferInt.Text))
    dr.Item("ToTransferFee") = Math.Abs(MyUtils.CnvSng(MyFrmTXA12C.LblTransferFee.Text))
    ds1.Tables(0).Rows.Add(dr)
    WriteFiles()
  End Sub
  Private Sub WriteFiles()
    Dim WrkRecID As Integer
    Dim WrkFromTaxBal As Decimal
    Dim WrkTransferTax As Decimal
    Dim WrkTransferInt As Decimal
    Dim WrkTransferFee As Decimal
    Dim WrkFee(5) As Decimal
    Dim WrkFeeCd(5) As String
    Dim WrkFeeLeft(5) As Decimal
    Dim WrkFeeLeftCd(5) As String
    Dim WrkFirstTime As Boolean
    Dim I As Integer
    Dim J As Integer

    WrkFromTaxBal = MyUtils.CnvSng(MyFrmTXA12C.TxtTransfer.Text)
    WrkTransferTax = MyUtils.CnvSng(MyFrmTXA12C.LblTransferTax.Text)
    WrkTransferInt = MyUtils.CnvSng(MyFrmTXA12C.LblTransferInt.Text)
    WrkTransferFee = MyUtils.CnvSng(MyFrmTXA12C.LblTransferFee.Text)
    WrkFirstTime = True

    If WrkFromTaxBal > 0 Then
      myTXINVFrom.GetOneRecordP(WrkFromListNo, WrkFromYear, WrkFromType)
      With myTXINVFrom
        ._PAYREC = ._PAYREC - WrkFromTaxBal
        ._BALD = ._BALD + WrkFromTaxBal
        If WrkTransferTax > 0 Then
          ._TXIDT = WrkPostDate
        End If
        myTXINVFrom.UpdateOneRecordP()
      End With

      With myTXHST
        WrkRecID = .AutoGenKey()
        .GetOneRecordP(WrkRecID)
        ._RECID = WrkRecID
        If myTXINVFrom._ICODE = "S" Then
          ._RCODE = "S"
        Else
          ._RCODE = ""
        End If
        ._LISTNO = WrkFromListNo
        ._YEAR = WrkFromYear
        ._TYPE = WrkFromType
        ._PAMT = WrkFromTaxBal * -1
        ._PCAMT = 0
        ._COMM = "TO " & WrkToListNo & "-" & WrkToType & "-" & WrkToYear
        ._REF = "Transfer"
        ._ADJCD = "A"
        ._PDATE = WrkPostDate
        ._CDATE = WrkPostDate
        ._PRF = "TXA12"
        ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
        ._CHTIME = MyUtils.SetDBTime(Date.Now)
        myTXHST.AddOneRecordP()
      End With

      J = -1
      myTXINVTo.GetOneRecordP(WrkToListNo, WrkToYear, WrkToType)
      With myTXINVTo
        WrkFee(0) = ._FED1
        WrkFee(1) = ._FED2
        WrkFee(2) = ._FED3
        WrkFee(3) = ._FED4
        WrkFee(4) = ._FED5
        WrkFeeCd(0) = ._FEC1
        WrkFeeCd(1) = ._FEC2
        WrkFeeCd(2) = ._FEC3
        WrkFeeCd(3) = ._FEC4
        WrkFeeCd(4) = ._FEC5
        ._PAYREC = ._PAYREC + WrkTransferTax
        ._BALD = ._BALD - WrkTransferTax
        If WrkTransferTax > 0 Then
          ._TXIDT = WrkPostDate
        End If
        If WrkTransferInt > 0 Then
          ._INTPD = ._INTPD + WrkTransferInt
        End If
        If ._MVFLAG = "Y" And WrkTransferFee > 0 Then
          WrkFee(5) = MyMVFee
          WrkFeeCd(5) = "MV"
          WrkTransferFee = WrkTransferFee - WrkFee(5)
          ._MVFLAG = "P"
        End If
        For I = 0 To 4
          WrkFeeLeftCd(I) = 0
          If WrkFee(I) > 0 And WrkTransferFee > 0 Then
            If WrkTransferFee < WrkFee(I) Then
              J = J + 1
              WrkFeeLeft(J) = WrkFee(I) - WrkTransferFee
              WrkFeeLeftCd(J) = WrkFeeCd(I)
              WrkFee(I) = WrkTransferFee
            End If
            WrkTransferFee = WrkTransferFee - WrkFee(I)
          End If
        Next
        ._FED1 = WrkFeeLeft(0)
        ._FED2 = WrkFeeLeft(1)
        ._FED3 = WrkFeeLeft(2)
        ._FED4 = WrkFeeLeft(3)
        ._FED5 = WrkFeeLeft(4)
        ._FEC1 = WrkFeeLeftCd(0)
        ._FEC2 = WrkFeeLeftCd(1)
        ._FEC3 = WrkFeeLeftCd(2)
        ._FEC4 = WrkFeeLeftCd(3)
        ._FEC5 = WrkFeeLeftCd(4)
        myTXINVTo.UpdateOneRecordP()
      End With

      For I = 0 To 5
        If Not WrkFirstTime And WrkFee(I) = 0 Then Continue For
        With myTXHST
          WrkRecID = .AutoGenKey()
          .GetOneRecordP(WrkRecID)
          ._RECID = WrkRecID
          If myTXINVTo._ICODE = "S" Then
            ._RCODE = "S"
          Else
            ._RCODE = ""
          End If
          ._LISTNO = WrkToListNo
          ._YEAR = WrkToYear
          ._TYPE = WrkToType
          If WrkFirstTime Then
            ._PAMT = WrkTransferTax
            ._IAMT = WrkTransferInt
          Else
            ._PAMT = 0
            ._IAMT = 0
          End If
          ._PCAMT = WrkFee(I)
          ._PENCD = WrkFeeCd(I)
          ._COMM = "FROM " & WrkFromListNo & "-" & WrkFromType & "-" & WrkFromYear
          ._REF = "Transfer"
          ._ADJCD = ""
          ._PDATE = WrkPostDate
          ._CDATE = WrkPostDate
          ._PRF = "TXA12"
          ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
          ._CHTIME = MyUtils.SetDBTime(Date.Now)
          myTXHST.AddOneRecordP()
          WrkFirstTime = False
        End With
      Next
    End If
  End Sub
End Module






