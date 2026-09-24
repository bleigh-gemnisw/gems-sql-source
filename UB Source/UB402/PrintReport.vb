Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myTXINVOld As TXINV.MyData
  Dim myTXINVNew As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkPost As Boolean
  Dim WrkPostDate As Integer
  Dim WrkListNo As Integer
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String
  'Work Fields
  Dim WrkOldTaxRcv As Decimal
  Dim WrkOldTaxDue As Decimal
  Dim WrkOldTaxBal As Decimal
  Dim WrkOldBondRcv As Decimal
  Dim WrkOldBondDue As Decimal
  Dim WrkOldBondBal As Decimal
  Dim WrkNewTaxRcv As Decimal
  Dim WrkNewTaxDue As Decimal
  Dim WrkNewTaxBal As Decimal
  Dim WrkNewBondRcv As Decimal
  Dim WrkNewBondDue As Decimal
  Dim WrkNewBondBal As Decimal
  Dim WrkPayTax As Decimal
  Dim WrkPayBond As Decimal

  Public Sub PrtReport()
    Dim WrkTypeDesc As String

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myTXINVOld = New TXINV.MyData(myDBConnect)
    myTXINVNew = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)

    With MyFrmUB402B
      WrkType = .TxtType.Text
      WrkYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkPost = .ChkPost.Checked
      WrkPostDate = MyUtils.SetDBDate(.DtPckPost.Value)
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
    End If

    GetDetail()

Done:
    WrkTypeDesc = GetUTTypeDescL2(WrkType)

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.WrkTypeDesc = WrkTypeDesc
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("OldTaxDue", Type.GetType("System.Decimal"))
      .Columns.Add("OldTaxRcv", Type.GetType("System.Decimal"))
      .Columns.Add("NewTaxDue", Type.GetType("System.Decimal"))
      .Columns.Add("NewTaxRcv", Type.GetType("System.Decimal"))
      .Columns.Add("NewBondDue", Type.GetType("System.Decimal"))
      .Columns.Add("NewBondRcv", Type.GetType("System.Decimal"))
      .Columns.Add("AfterTaxRcv", Type.GetType("System.Decimal"))
      .Columns.Add("AfterBondRcv", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()

    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "icode<>'I'" & WrkAnd & "year=" & WrkYear & WrkAnd & "type=" & MyUtils.Quo(WrkType) & WrkAnd & "bald<0"
    WrkFlds = "NAME, LIST#"

    DsTXINV = myTXINVQ.GetQry(WrkFlds, WrkQry, 0)
    If DsTXINV.Tables(0).Rows.Count = 0 Then GoTo CloseFiles
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkUBType = GetUTTypeUBType(WrkType)

    For I = 0 To (DsTXINV.Tables(0).Rows.Count - 1)
      With DsTXINV.Tables(0).Rows(I)
        WrkListNo = .Item("list#")
        WrkCode = GetRateCode(WrkUBType)
        If WrkCode = "" Then GoTo NextRec

        dr = ds1.Tables(0).NewRow
        dr.Item("listno") = WrkListNo
        dr.Item("name") = .Item("name")
      End With

      myTXINVOld.GetOneRecordP(WrkListNo, WrkYear, WrkType)
      If myTXINVOld.RecordNotFound Then GoTo NextRec

      With myTXINVOld
        WrkOldTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkOldTaxDue = ._CCETAX
        Else
          WrkOldTaxDue = ._TAXT
        End If
        WrkOldTaxBal = WrkOldTaxDue - WrkOldTaxRcv
        WrkOldBondRcv = ._BONDP + ._BONT
        WrkOldBondDue = ._BOND
        WrkOldBondBal = WrkOldBondDue - WrkOldBondRcv
        'Filter no overpaid balances
        If WrkOldTaxBal >= 0 And WrkOldBondBal >= 0 Then
          GoTo NextRec
        End If
      End With

      dr.Item("oldtaxdue") = WrkOldTaxDue
      dr.Item("oldtaxrcv") = WrkOldTaxRcv
      myTXINVNew.GetOneRecordP(WrkListNo, WrkYear + 1, WrkType)
      If myTXINVNew.RecordNotFound Then GoTo NextRec

      With myTXINVNew
        WrkNewTaxRcv = ._PAYREC + ._NEWPAY
        If ._CCNO > 0 Then
          WrkNewTaxDue = ._CCETAX
        Else
          WrkNewTaxDue = ._TAXT
        End If
        WrkNewTaxBal = WrkNewTaxDue - WrkNewTaxRcv
        WrkNewBondRcv = ._BONDP + ._BONT
        WrkNewBondDue = ._BOND
        WrkNewBondBal = WrkNewBondDue - WrkNewBondRcv
      End With
      dr.Item("newtaxdue") = WrkNewTaxDue
      dr.Item("newtaxrcv") = WrkNewTaxRcv
      dr.Item("newbonddue") = WrkNewBondDue
      dr.Item("newbondrcv") = WrkNewBondRcv

      'REDUCE PAYMENT BY OUTSTANDING BOND DUE FIRST, THEN TAX
      WrkPayTax = Math.Abs(WrkOldTaxBal)
      WrkPayBond = 0
      If WrkNewBondBal > 0 Then
        WrkPayBond = WrkNewBondRcv + WrkPayTax
        If WrkPayBond > WrkNewBondBal Then
          WrkPayBond = WrkNewBondBal
          WrkPayTax = WrkPayTax - WrkNewBondBal
        Else
          WrkPayTax = 0
        End If
      End If
      dr.Item("aftertaxrcv") = WrkNewTaxRcv + WrkPayTax
      dr.Item("afterbondrcv") = WrkNewBondRcv + WrkPayBond

      If WrkPost Then
        WriteFiles(I)
      End If
      ds1.Tables(0).Rows.Add(dr)

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
    myTXINVOld.CloseFile()
    myTXINVNew.CloseFile()

  End Sub
  Private Sub WriteFiles(ByVal I As Integer)
    Dim WrkRecID As Integer

    If WrkOldTaxBal < 0 Then
      With myTXINVOld
        ._PAYREC = WrkOldTaxRcv - Math.Abs(WrkOldTaxBal)
        ._BALD = ._BALD + Math.Abs(WrkOldTaxBal)
        .UpdateOneRecordP()
      End With

      With myTXHST
        WrkRecID = .AutoGenKey
        .GetOneRecordP(WrkRecID)
        ._RECID = WrkRecID
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._TYPE = WrkType
        ._PAMT = Math.Abs(WrkOldTaxBal) * -1
        ._PCAMT = 0
        ._COMM = "ADJUST TO " & WrkYear + 1
        ._ADJCD = "A"
        ._PDATE = WrkPostDate
        ._CDATE = WrkPostDate
        ._PRF = "UB402"
        ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
        ._CHTIME = MyUtils.SetDBTime(Date.Now)
        .AddOneRecordP()
      End With

      With myTXINVNew
        ._PAYREC = ._PAYREC + WrkPayTax
        ._BALD = ._BALD - WrkPayTax
        ._BONDP = ._BONDP + WrkPayBond
        .UpdateOneRecordP()
      End With

      With myTXHST
        WrkRecID = .AutoGenKey
        .GetOneRecordP(WrkRecID)
        ._RECID = WrkRecID
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear + 1
        ._TYPE = WrkType
        ._PAMT = WrkPayTax
        ._PCAMT = WrkPayBond
        ._COMM = "ADJUST FROM " & WrkYear
        ._ADJCD = ""
        ._PDATE = WrkPostDate
        ._CDATE = WrkPostDate
        ._PRF = "UB402"
        ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
        ._CHTIME = MyUtils.SetDBTime(Date.Now)
        .AddOneRecordP()
      End With
    End If
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function

End Module






