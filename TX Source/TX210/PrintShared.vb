Module PrintShared
Dim myTXCOEAL1 As TXCOEAL1.myData
Dim myUTCOEAL1 As UTCOEAL1.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim DsTXCOEA As DataSet = New DataSet
Dim DsUTCOEA As DataSet = New DataSet
'Global
Public WrkType As String
Public WrkPPCode(100) As Integer
Public WrkPPDesc(100) As String
Public Sub BuildDS(ByRef ds1 As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("frcd", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Letter", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Bkcd", Type.GetType("System.String"))
      .Columns.Add("frcddesc", Type.GetType("System.String"))
      .Columns.Add("Fryr", Type.GetType("System.Int32"))
      .Columns.Add("Gross", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("Suspense", Type.GetType("System.Boolean"))
      .Columns.Add("TaxDue", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2", Type.GetType("System.Decimal"))
      .Columns.Add("UnpaidTX", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LienPaid", Type.GetType("System.Decimal"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCETax", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx1", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx2", Type.GetType("System.Decimal"))
      .Columns.Add("UnpaidCC", Type.GetType("System.Decimal"))
      .Columns.Add("Pamt1", Type.GetType("System.Decimal"))
      .Columns.Add("PDate1", Type.GetType("System.DateTime"))
      .Columns.Add("Batch1", Type.GetType("System.Int32"))
      .Columns.Add("Pamt2", Type.GetType("System.Decimal"))
      .Columns.Add("PDate2", Type.GetType("System.DateTime"))
      .Columns.Add("Batch2", Type.GetType("System.Int32"))
      .Columns.Add("Pamt3", Type.GetType("System.Decimal"))
      .Columns.Add("PDate3", Type.GetType("System.DateTime"))
      .Columns.Add("Batch3", Type.GetType("System.Int32"))
      .Columns.Add("Pamt4", Type.GetType("System.Decimal"))
      .Columns.Add("PDate4", Type.GetType("System.DateTime"))
      .Columns.Add("Batch4", Type.GetType("System.Int32"))
      .Columns.Add("Pamt5", Type.GetType("System.Decimal"))
      .Columns.Add("PDate5", Type.GetType("System.DateTime"))
      .Columns.Add("Batch5", Type.GetType("System.Int32"))
      .Columns.Add("Pamt6", Type.GetType("System.Decimal"))
      .Columns.Add("PDate6", Type.GetType("System.DateTime"))
      .Columns.Add("Batch6", Type.GetType("System.Int32"))
      .Columns.Add("Pamt7", Type.GetType("System.Decimal"))
      .Columns.Add("PDate7", Type.GetType("System.DateTime"))
      .Columns.Add("Batch7", Type.GetType("System.Int32"))
      .Columns.Add("Pamt8", Type.GetType("System.Decimal"))
      .Columns.Add("PDate8", Type.GetType("System.DateTime"))
      .Columns.Add("Batch8", Type.GetType("System.Int32"))
      .Columns.Add("Pamt9", Type.GetType("System.Decimal"))
      .Columns.Add("PDate9", Type.GetType("System.DateTime"))
      .Columns.Add("Batch9", Type.GetType("System.Int32"))
      .Columns.Add("Pamt10", Type.GetType("System.Decimal"))
      .Columns.Add("PDate10", Type.GetType("System.DateTime"))
      .Columns.Add("Batch10", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
  Public Sub BuildDS2(ByRef ds2 As DataSet)
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("tgross", Type.GetType("System.Int64"))
      .Columns.Add("texempt", Type.GetType("System.Int64"))
      .Columns.Add("tnet", Type.GetType("System.Int64"))
      .Columns.Add("ttax", Type.GetType("System.Decimal"))
      .Columns.Add("ttax1", Type.GetType("System.Decimal"))
      .Columns.Add("ttax2", Type.GetType("System.Decimal"))
      .Columns.Add("taccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidaccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidbal", Type.GetType("System.Decimal"))
      .Columns.Add("tsusaccts", Type.GetType("System.Int32"))
      .Columns.Add("tsustax", Type.GetType("System.Decimal"))
      .Columns.Add("bccgross", Type.GetType("System.Int64"))
      .Columns.Add("bccexempt", Type.GetType("System.Int64"))
      .Columns.Add("bccnet", Type.GetType("System.Int64"))
      .Columns.Add("bcctax", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax1", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax2", Type.GetType("System.Decimal"))
      .Columns.Add("ccgross", Type.GetType("System.Int64"))
      .Columns.Add("ccexempt", Type.GetType("System.Int64"))
      .Columns.Add("ccnet", Type.GetType("System.Int64"))
      .Columns.Add("cctax", Type.GetType("System.Decimal"))
      .Columns.Add("cctax1", Type.GetType("System.Decimal"))
      .Columns.Add("cctax2", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Public Sub InitSharedFiles()
	myTXCOEAL1 = New TXCOEAL1.mydata(MyDBConnect)
	myUTCOEAL1 = New UTCOEAL1.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)
End Sub

Public Sub GetLastCC(ByVal WrkDist As Integer, ByVal WrkPhs As String, ByVal WrkListNo As Integer, _
  ByVal WrkYear As Integer, ByVal WrkPaid As Decimal, ByVal WrkTo As Integer, ByRef WrkOutCC As Boolean, _
  ByRef WrkOutCCNo As Integer, ByRef WrkOutCCETax As Decimal, ByRef WrkOutCCDate As Date, _
  ByRef WrkOutCCGrossChg As Integer, ByRef WrkOutCCExemptChg As Integer)

    Dim WrkDate As Date
    WrkOutCC = False
    WrkOutCCNo = 0
    WrkOutCCETax = 0
    WrkOutCCDate = WrkDate
    WrkOutCCGrossChg = 0
    WrkOutCCExemptChg = 0

    DsTXCOEA = myTXCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkTo)
    If DsTXCOEA.Tables(0).Rows.Count > 0 Then
      With DsTXCOEA.Tables(0).Rows(0)
        WrkOutCC = True
        WrkOutCCNo = .Item("ccno")
        WrkOutCCETax = .Item("cetax")
        WrkOutCCDate = MyUtils.GetDBDate(.Item("cdate"))
        WrkOutCCGrossChg = .Item("grchg")
        WrkOutCCExemptChg = .Item("exchg")
      End With
    End If

End Sub
Public Sub GetLastCC_UB(ByVal WrkDist As Integer, ByVal WrkPhs As String, ByVal WrkListNo As Integer, _
  ByVal WrkYear As Integer, ByVal WrkPaid As Decimal, ByVal WrkTo As Integer, ByRef WrkOutCC As Boolean, _
  ByRef WrkOutCCNo As Integer, ByRef WrkOutCCETax As Decimal, ByRef WrkOutCCDate As Date, _
  ByRef WrkOutCCGrossChg As Integer, ByRef WrkOutCCExemptChg As Integer)

    Dim WrkDate As Date
    WrkOutCC = False
    WrkOutCCNo = 0
    WrkOutCCETax = 0
    WrkOutCCDate = WrkDate
    WrkOutCCGrossChg = 0
    WrkOutCCExemptChg = 0

    DsUTCOEA = myUTCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkTo)
    If DsUTCOEA.Tables(0).Rows.Count > 0 Then
      With DsUTCOEA.Tables(0).Rows(0)
        WrkOutCC = True
        WrkOutCCNo = .Item("ccno")
        WrkOutCCETax = .Item("cetax")
        WrkOutCCDate = MyUtils.GetDBDate(.Item("cdate"))
        WrkOutCCGrossChg = 0
        WrkOutCCExemptChg = 0
      End With
    End If
End Sub
Public Sub PaySplit(ByVal WrkDist As Integer, ByVal WrkPhs As String, ByVal WrkListNo As Integer, ByVal WrkYear As Integer, _
    ByVal WrkTax As Decimal, ByRef Out_Tax1 As Decimal, ByRef Out_Tax2 As Decimal)

    If WrkTax = 0 Then
      Out_Tax1 = 0
      Out_Tax2 = 0
      Exit Sub
    End If

    With myTPaymnt
      .In_Dst = WrkDist
      .In_ListNo = WrkListNo
      .In_Phs = WrkPhs
      .In_Type = WrkType
      .In_Year = WrkYear
      .In_TaxT = WrkTax
      .CalcPaySplit()
      Out_Tax1 = .Out_Tax1
      Out_Tax2 = .Out_Tax2
    End With
End Sub
Public Sub BufferPPDesc(ByVal WrkType As String)
     Dim I As Integer

		 Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

		 myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkType)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkPPCode(I) = .Item("tccode")
        WrkPPDesc(I) = .Item("tcdesc")
      End With
    Next

End Sub
Public Function LookupPPDesc(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkDesc As String

     For I = 0 To WrkPPCode.GetUpperBound(0)
       If WrkPPCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkPPCode(I) Then
         WrkDesc = WrkPPDesc(I)
         Return WrkDesc
       End If
    Next

    Return ""
End Function
End Module






