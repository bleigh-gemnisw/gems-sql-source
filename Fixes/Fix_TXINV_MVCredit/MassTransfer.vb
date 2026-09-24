Imports System.IO
Imports System.Text
Module MassTransfer

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVFrom As TXINV.MyData
  Dim myTXINVTo As TXINV.MyData
  Dim myTXINVLC As TXINVLC.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen
  Dim WrkFromType As String
  Dim WrkToType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkPost As Boolean
  Dim WrkPostDate As Integer

  'Work Fields
  Dim WrkFromListNo As Integer
  Dim WrkToListNo As Integer
  Dim WrkFromTaxRcv As Decimal
  Dim WrkFromTaxDue As Decimal
  Dim WrkFromTaxBal As Decimal
  Dim WrkToTaxRcv As Decimal
  Dim WrkToTaxDue As Decimal
  Dim WrkToTaxBal As Decimal
  Dim WrkPayTax As Decimal
  Dim WrkPayInt As Decimal

  Public Sub MassXfer()
    myTXINVFrom = New TXINV.MyData(myDBConnect)
    myTXINVTo = New TXINV.MyData(myDBConnect)
    myTXINVLC = New TXINVLC.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmFixB
      WrkFromType = .TxtFromType.Text
      WrkToType = .TxtToType.Text
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
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.WrkPostDate = MyFrmFixB.DtPckPost.Value
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmFixB.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim SArray As String()
    Dim WrkFileSize As Integer
    Dim WrkLastHistDate As Integer
    Dim WrkRegno As String
    Dim OutInterest As Decimal
    Dim OutInterestPaid As Decimal
    Dim OutFee As Decimal
    Dim OutLien As Decimal
    Dim OutBond As Decimal
    Dim OutTax As Decimal
    Dim OutDue As Decimal
    Dim I As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo CloseFiles
    End If

    I = I + strBuffer.Length
    SArray = Parse(strBuffer, ",")
    WrkRegno = SArray(16)
    DsTXINV = myTXINVLC.GetViewbyRegNo(WrkRegno, "YEAR=" & WrkFromYear & " and TYPE='" & WrkFromType & "'", 1, False)
    If DsTXINV.Tables(0).Rows.Count > 0 Then
      WrkFromListNo = DsTXINV.Tables(0).Rows(0).Item("list#")
    Else
      WrkFromListNo = 0
      dr = ds1.Tables(0).NewRow
      dr.Item("fromlistno") = WrkFromListNo
      dr.Item("fromtype") = WrkFromType
      dr.Item("fromyear") = WrkFromYear
      dr.Item("FromName") = WrkRegno
      dr.Item("FromBeforeBal") = 0
      dr.Item("FromAfterBal") = 0
      dr.Item("FromTransferTax") = 0
      dr.Item("tolistno") = 0
      dr.Item("totype") = ""
      dr.Item("toyear") = 0
      dr.Item("ToName") = "** list no not found"
      dr.Item("ToBeforeBal") = 0
      dr.Item("ToAfterBal") = 0
      dr.Item("ToTransferTax") = 0
      dr.Item("ToTransferInt") = 0
      ds1.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If

    myTXINVFrom.GetOneRecordP(WrkFromListNo, WrkFromYear, WrkFromType)
    WrkLastHistDate = GetLastHist(WrkFromListNo, WrkFromYear, WrkFromType, 99999999)

    With myTXINVFrom
      WrkFromTaxRcv = ._PAYREC + ._NEWPAY
      If ._CCNO > 0 Then
        WrkFromTaxDue = ._CCETAX
      Else
        WrkFromTaxDue = ._TAXT
      End If
      WrkFromTaxBal = WrkFromTaxDue - WrkFromTaxRcv
      dr = ds1.Tables(0).NewRow
      dr.Item("fromlistno") = WrkFromListNo
      dr.Item("fromtype") = WrkFromType
      dr.Item("fromyear") = WrkFromYear
      dr.Item("FromName") = Trim(._NAME)
      dr.Item("FromBeforeBal") = ._BALD
      dr.Item("FromAfterBal") = 0
      dr.Item("FromTransferTax") = ._BALD
      If WrkLastHistDate > WrkPostDate Then
        dr.Item("tolistno") = 0
        dr.Item("totype") = ""
        dr.Item("toyear") = 0
        dr.Item("ToName") = "** History after date"
        dr.Item("ToBeforeBal") = ._BALD
        dr.Item("ToAfterBal") = 0
        dr.Item("ToTransferTax") = 0
        dr.Item("ToTransferInt") = 0
        ds1.Tables(0).Rows.Add(dr)
        GoTo NextRec
      End If
      'Filter no overpaid balances
      If WrkFromTaxBal >= 0 Then
        dr.Item("tolistno") = 0
        dr.Item("totype") = ""
        dr.Item("toyear") = 0
        dr.Item("ToName") = "** No Credit Balance"
        dr.Item("ToBeforeBal") = ._BALD
        dr.Item("ToAfterBal") = 0
        dr.Item("ToTransferTax") = 0
        dr.Item("ToTransferInt") = 0
        ds1.Tables(0).Rows.Add(dr)
        GoTo NextRec
      End If
    End With

    DsTXINV = myTXINVLC.GetViewbyRegNo(WrkRegno, "YEAR=" & WrkToYear & " and TYPE='" & WrkToType & "'", 1, False)
    If DsTXINV.Tables(0).Rows.Count = 0 Then
      dr.Item("tolistno") = 0
      dr.Item("totype") = ""
      dr.Item("toyear") = 0
      dr.Item("ToName") = WrkRegno & " ** No Match"
      dr.Item("ToBeforeBal") = 0
      dr.Item("ToAfterBal") = 0
      dr.Item("ToTransferTax") = 0
      dr.Item("ToTransferInt") = 0
      ds1.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If

    WrkToListNo = DsTXINV.Tables(0).Rows(0).Item("list#")
    myTXINVTo.GetOneRecordP(WrkToListNo, WrkToYear, WrkToType)
    If myTXINVTo.RecordNotFound Then GoTo NextRec

    WrkLastHistDate = GetLastHist(WrkToListNo, WrkToYear, WrkToType, 99999999)
    If WrkLastHistDate > WrkPostDate Then
      dr.Item("tolistno") = 0
      dr.Item("totype") = ""
      dr.Item("toyear") = 0
      dr.Item("ToName") = "** History after date"
      dr.Item("ToBeforeBal") = 0
      dr.Item("ToAfterBal") = 0
      dr.Item("ToTransferTax") = 0
      dr.Item("ToTransferInt") = 0
      ds1.Tables(0).Rows.Add(dr)
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
      dr.Item("tolistno") = WrkToListNo
      dr.Item("totype") = WrkToType
      dr.Item("toyear") = WrkToYear
      dr.Item("ToName") = "** No Tax Due"
      dr.Item("ToBeforeBal") = 0
      dr.Item("ToAfterBal") = 0
      dr.Item("ToTransferTax") = 0
      dr.Item("ToTransferInt") = 0
      ds1.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If

    CalcInterest(MyFrmFixB.DtPckPost.Value, WrkToListNo, WrkToType, WrkToYear,
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
      dr.Item("tolistno") = WrkToListNo
      dr.Item("totype") = WrkToType
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
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine


CloseFiles:
    myFrmProgress.Close()
    myTXINVFrom.CloseFile()
    myTXINVTo.CloseFile()
  End Sub
  Private Sub WriteFiles()
    Dim WrkRecID As Integer

    myTXINVFrom.GetOneRecordP(WrkFromListNo, WrkFromYear, WrkFromType)
    With myTXINVFrom
      ._PAYREC = WrkFromTaxRcv - Math.Abs(WrkFromTaxBal)
      ._BALD = ._BALD + Math.Abs(WrkFromTaxBal)
      myTXINVFrom.UpdateOneRecordP()
    End With

    With myTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._LISTNO = WrkFromListNo
      ._YEAR = WrkFromYear
      ._TYPE = WrkFromType
      ._PAMT = WrkFromTaxBal
      ._PCAMT = 0
      ._COMM = "ADJUST TO " & WrkToYear
      ._REF = "Transfer"
      ._ADJCD = "A"
      ._PDATE = WrkPostDate
      ._CDATE = WrkPostDate
      ._PRF = "Fix"
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      myTXHST.AddOneRecordP()
    End With

    myTXINVTo.GetOneRecordP(WrkToListNo, WrkToYear, WrkToType)
    With myTXINVTo
      ._PAYREC = ._PAYREC + WrkPayTax
      ._BALD = ._BALD - WrkPayTax
      myTXINVTo.UpdateOneRecordP()
    End With

    With myTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._LISTNO = WrkToListNo
      ._YEAR = WrkToYear
      ._TYPE = WrkToType
      ._PAMT = WrkPayTax
      ._IAMT = WrkPayInt
      ._PCAMT = 0
      ._COMM = "ADJUST FROM " & WrkFromYear
      ._REF = "Transfer"
      ._ADJCD = ""
      ._PDATE = WrkPostDate
      ._CDATE = WrkPostDate
      ._PRF = "Fix"
      ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      myTXHST.AddOneRecordP()
    End With
  End Sub
End Module






