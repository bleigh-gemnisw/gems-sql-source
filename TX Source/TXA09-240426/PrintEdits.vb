Module PrintEdits
  Dim myTXBATCHL1 As TXBATCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim dsTXBATCH As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dsChk As DataSet = New DataSet
  Dim dsVoid As DataSet = New DataSet

  Sub PrtEdits(ByVal Post As Boolean)

    myTXBATCHL1 = New TXBATCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    dsTXBATCH = myTXBATCHL1.GetViewByBatch(MyBatch, MyBatchNo, 99999)
    BuildPrtDS()
    AddRecords()
    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.WrkdsChk = dsChk
    MyFrmCr_PrtEdits.WrkdsVoid = dsVoid
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.ShowDialog()
    ds.Tables.Remove("mytable")
    dsChk.Tables.Remove("mytable")
    dsVoid.Tables.Remove("mytable")
    'Memory Cleanup
    ds.Clear()
    dsChk.Clear()
    dsTXBATCH.Clear()
    Try
      dsVoid.Clear()
    Catch ex As Exception
    End Try
    myTXBATCHL1.CloseFile()
    myTXBATCHL1 = Nothing

  End Sub
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Seq", Type.GetType("System.Int32"))
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("PenCd", Type.GetType("System.String"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("BalDue", Type.GetType("System.Decimal"))
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("IntDt", Type.GetType("System.DateTime"))
      .Columns.Add("RecDt", Type.GetType("System.DateTime"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("CheckNo", Type.GetType("System.String"))
      .Columns.Add("CheckDate", Type.GetType("System.DateTime"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("Simt", Type.GetType("System.Decimal"))
      .Columns.Add("Tbl", Type.GetType("System.Decimal"))
      .Columns.Add("Arc", Type.GetType("System.Decimal"))
      .Columns.Add("Adjcd", Type.GetType("System.String"))
      .Columns.Add("Comment", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
    dsChk = ds.Clone
    dsVoid = ds.Clone
  End Sub

  Sub AddRecords()
    Dim myDr As Data.DataRow
    Dim myDr2 As Data.DataRow
    Dim WrkAdjTax As Decimal
    Dim WrkBald As Decimal
    Dim WrkInterestDate As Date
    Dim I As Integer

    For I = 0 To (dsTXBATCH.Tables(0).Rows.Count - 1)
      With dsTXBATCH.Tables(0).Rows(I)
        If .Item("jstat") = "V" Then
          myDr = dsVoid.Tables(0).NewRow
        Else
          myDr = ds.Tables(0).NewRow
        End If
        Select Case MyCheckSort
          Case "Check Number", String.Empty
            myDr("sortdata") = Format(MyUtils.CnvSng(.Item("refe")), "000000000")
          Case "Sequence"
            myDr("sortdata") = Format(.Item("jseqno"), "00000")
          Case "Name"
            myDr("sortdata") = .Item("name")
        End Select
        myDr("listno") = .Item("list#")
        myDr("type") = .Item("type")
        myDr("typedesc") = GetTXTypeDesc(.Item("type"))
        myDr("year") = .Item("year")
        myDr("seq") = .Item("jseqno")
        myDr("dist") = .Item("dist")
        myDr("amtdue") = .Item("pamt")
        myDr("principal") = .Item("pamt")
        myDr("interest") = .Item("iamt")
        myDr("liens") = .Item("lamt")
        myDr("fee") = .Item("tcamt")
        myDr("pencd") = .Item("cpencd")
        myDr("total") = .Item("pamt") + .Item("iamt") + .Item("lamt") + .Item("tcamt")
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
        WrkBald = 0
        With myTXINV
          If ._CCNO > 0 Then
            WrkAdjTax = ._CCETAX
          Else
            WrkAdjTax = ._TAXT
          End If
          WrkBald = WrkAdjTax - ._PAYREC - ._NEWPAY
        End With
        myDr("baldue") = WrkBald
        myDr("batch") = MyBatch
        myDr("batchno") = MyBatchNo
        WrkInterestDate = "#" & .Item("jim") & "/" & .Item("jid") & "/" & .Item("jiy") & "#"
        myDr("intdt") = WrkInterestDate
        myDr("recdt") = MyReceiptDate
        myDr("name") = .Item("name")
        myDr("cash") = .Item("cash")
        myDr("check") = .Item("check")
        myDr("credit") = .Item("credit")
        myDr("checkno") = .Item("refe")
        myDr("checkdate") = MyReceiptDate
        myDr("simt") = .Item("simt")
        myDr("tbl") = .Item("tbl")
        myDr("arc") = .Item("arc")
        myDr("adjcd") = .Item("adjcd")
        myDr("status") = .Item("jstat")
        myDr("comment") = .Item("comm")
        If .Item("jstat") = "V" Then
          dsVoid.Tables(0).Rows.Add(myDr)
        Else
          ds.Tables(0).Rows.Add(myDr)
        End If
        'Check reports
        If .Item("jstat") <> "V" And .Item("check") <> 0 Then
          myDr2 = dsChk.Tables(0).NewRow
          myDr("sortdata") = myDr("sortdata")
          myDr2("listno") = .Item("list#")
          myDr2("type") = .Item("type")
          myDr2("typedesc") = GetTXTypeDesc(.Item("type"))
          myDr2("year") = .Item("year")
          myDr2("seq") = .Item("jseqno")
          myDr2("batch") = MyBatch
          myDr2("batchno") = MyBatchNo
          myDr2("name") = .Item("name")
          myDr2("check") = .Item("check")
          myDr2("checkno") = .Item("refe")
          myDr2("checkdate") = MyReceiptDate
          dsChk.Tables(0).Rows.Add(myDr2)
        End If
      End With
    Next

  End Sub
End Module






