Imports System.Text
Module MassTransfer

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVFrom As TXINV.MyData
  Dim myTXINVTo As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen
  Dim WrkType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkPost As Boolean
  Dim WrkPostDate As Integer

  'Work Fields
  Dim WrkListNo As Integer
  Dim WrkFromTaxRcv As Decimal
  Dim WrkFromTaxDue As Decimal
  Dim WrkFromTaxBal As Decimal
  Dim WrkToTaxRcv As Decimal
  Dim WrkToTaxDue As Decimal
  Dim WrkToTaxBal As Decimal
  Dim WrkPayTax As Decimal
  Dim WrkPayInt As Decimal

  Public Sub MassXfer()
    Dim WrkTypeDesc As String

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINVFrom = New TXINV.MyData(myDBConnect)
    myTXINVTo = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTXA12B
      WrkType = .TxtType.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkPost = .ChkPost.Checked
      WrkPostDate = MyUtils.SetDBDate(.DtPckPost.Value)
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS(ds1)
    Else
      ds1.Clear()
    End If

    GetDetail()

Done:
    WrkTypeDesc = GetTXTypeDesc(WrkType)

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.WrkPostDate = MyFrmTXA12B.DtPckPost.Value
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub GetDetail()

    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkLastHistDate As Integer
    Dim OutInterest As Decimal
    Dim OutInterestPaid As Decimal
    Dim OutFee As Decimal
    Dim OutLien As Decimal
    Dim OutBond As Decimal
    Dim OutTax As Decimal
    Dim OutDue As Decimal
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "year=" & WrkFromYear & WrkAnd & "type=" & MyUtils.Quo(WrkType) & WrkAnd & "bald<0"
    WrkFlds = "NAME, LIST#"

    DsTXINV = myTXINVQ.GetQry(WrkFlds, WrkQry, 0)
    If DsTXINV.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXINV.Tables(0).Rows.Count - 1)
      With DsTXINV.Tables(0).Rows(I)
        WrkListNo = .Item("list#")
      End With

      myTXINVFrom.GetOneRecordP(WrkListNo, WrkFromYear, WrkType)
      WrkLastHistDate = GetLastHist(WrkListNo, WrkFromYear, WrkType, 99999999)
      If WrkLastHistDate > WrkPostDate Then
        GoTo NextRec
      End If

      With myTXINVFrom
        WrkFromTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkFromTaxDue = ._CCETAX
        Else
          WrkFromTaxDue = ._TAXT
        End If
        WrkFromTaxBal = WrkFromTaxDue - WrkFromTaxRcv
        'Filter no overpaid balances
        If WrkFromTaxBal >= 0 Then
          GoTo NextRec
        End If
        dr = ds1.Tables(0).NewRow
        dr.Item("fromlistno") = WrkListNo
        dr.Item("fromtype") = WrkType
        dr.Item("fromyear") = WrkFromYear
        dr.Item("FromName") = Trim(._NAME)
        dr.Item("FromBeforeBal") = ._BALD
        dr.Item("FromAfterBal") = 0
        dr.Item("FromTransferTax") = ._BALD
      End With

      myTXINVTo.GetOneRecordP(WrkListNo, WrkToYear, WrkType)
      If myTXINVTo.RecordNotFound Then GoTo NextRec

      WrkLastHistDate = GetLastHist(WrkListNo, WrkToYear, WrkType, 99999999)
      If WrkLastHistDate > WrkPostDate Then
        GoTo NextRec
      End If

      With myTXINVTo
        WrkToTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkToTaxDue = ._CCETAX
        Else
          WrkToTaxDue = ._TAXT
        End If
      End With
      WrkToTaxBal = WrkToTaxDue - WrkToTaxRcv
      'Filter no balances
      If WrkToTaxBal <= 0 Then
        GoTo NextRec
      End If

      CalcInterest(MyFrmTXA12B.DtPckPost.Value, WrkListNo, WrkType, WrkToYear,
    OutInterest, OutInterestPaid, OutFee, OutLien, OutBond, OutTax, OutDue)
      WrkPayTax = Math.Abs(WrkFromTaxBal)
      If WrkPayTax >= OutInterest Then
        WrkPayInt = OutInterest
        WrkPayTax = WrkPayTax - WrkPayInt
      Else
        WrkPayInt = WrkPayTax
        WrkPayTax = 0
      End If

      With myTXINVTo
        dr.Item("tolistno") = WrkListNo
        dr.Item("totype") = WrkType
        dr.Item("toyear") = WrkToYear
        dr.Item("ToName") = Trim(._NAME)
        dr.Item("ToBeforeBal") = ._BALD
        dr.Item("ToAfterBal") = ._BALD - WrkPayTax
        dr.Item("ToTransferTax") = WrkPayTax
        dr.Item("ToTransferInt") = WrkPayInt
      End With
      ds1.Tables(0).Rows.Add(dr)

      If WrkPost Then
        WriteFiles()
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXINV.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()

CloseFiles:
    myTXINVQ.CloseFile()
    myTXINVFrom.CloseFile()
    myTXINVTo.CloseFile()

    Reset()

  End Sub
  Private Sub WriteFiles()
    Dim WrkRecID As Integer

    myTXINVFrom.GetOneRecordP(WrkListNo, WrkFromYear, WrkType)
    With myTXINVFrom
      ._PAYREC = WrkFromTaxRcv - Math.Abs(WrkFromTaxBal)
      ._BALD = ._BALD + Math.Abs(WrkFromTaxBal)
      myTXINVFrom.UpdateOneRecordP()
    End With

    With myTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._LISTNO = WrkListNo
      ._YEAR = WrkFromYear
      ._TYPE = WrkType
      ._PAMT = WrkFromTaxBal
      ._PCAMT = 0
      ._COMM = "ADJUST TO " & WrkToYear
      ._REF = "Transfer"
      ._ADJCD = "A"
      ._PDATE = WrkPostDate
      ._CDATE = WrkPostDate
      ._PRF = "TXA12"
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      myTXHST.AddOneRecordP()
    End With

    myTXINVTo.GetOneRecordP(WrkListNo, WrkToYear, WrkType)
    With myTXINVTo
      ._PAYREC = ._PAYREC + WrkPayTax
      ._BALD = ._BALD - WrkPayTax
      myTXINVTo.UpdateOneRecordP()
    End With

    With myTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._LISTNO = WrkListNo
      ._YEAR = WrkToYear
      ._TYPE = WrkType
      ._PAMT = WrkPayTax
      ._IAMT = WrkPayInt
      ._PCAMT = 0
      ._COMM = "ADJUST FROM " & WrkFromYear
      ._REF = "Transfer"
      ._ADJCD = ""
      ._PDATE = WrkPostDate
      ._CDATE = WrkPostDate
      ._PRF = "TXA12"
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      myTXHST.AddOneRecordP()
    End With
  End Sub
End Module






