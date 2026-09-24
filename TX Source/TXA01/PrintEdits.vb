Module PrintEdits
  Dim myTCRBCHL1 As TCRBCHL1.MyData
  Dim myTXINV As TXINV.myData
  Dim myTXMRATE As TXMRATE.myData
  Dim ds As DataSet = New DataSet
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim Errors As Boolean
  Dim WrkDistBreakout As Boolean
  'General
  Dim SaveYear As Integer
  Dim SaveDist As Integer
  'Buffer Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String


  Public Function PrtEdits(ByVal BatchNo As Integer, ByVal BatchTypeDesc As String,
  ByVal ReceiptDate As Date, ByVal InterestDate As Date, ByVal Post As Boolean) As Boolean

    myTCRBCHL1 = New TCRBCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.mydata(MyDBConnect)
    myTXMRATE = New TXMRATE.mydata(MyDBConnect)

    Errors = False
    myTCRBCHL1.SetRange(BatchNo)
    If ds.Tables.Count = 0 Then
      BuildPrtDS()
      BufferType()
    Else
      ds.Clear()
    End If
    AddRecords(BatchNo, ReceiptDate, InterestDate, Post)
    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.WrkBatchTypeDesc = BatchTypeDesc
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkErrors = Errors
    MyFrmCr_PrtEdits.WrkDistBreakout = WrkDistBreakout
    MyFrmCr_PrtEdits.WrkReceiptDate = ReceiptDate
    MyFrmCr_PrtEdits.WrkInterestDate = InterestDate
    MyFrmCr_PrtEdits.ShowDialog()
    'Memory Cleanup
    myTCRBCHL1 = Nothing
    Return Errors

  End Function
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("Seq", Type.GetType("System.Int32"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("fees", Type.GetType("System.Decimal"))
      .Columns.Add("fee1", Type.GetType("System.Decimal"))
      .Columns.Add("fee2", Type.GetType("System.Decimal"))
      .Columns.Add("fee3", Type.GetType("System.Decimal"))
      .Columns.Add("fee4", Type.GetType("System.Decimal"))
      .Columns.Add("fee5", Type.GetType("System.Decimal"))
      .Columns.Add("fee6", Type.GetType("System.Decimal"))
      .Columns.Add("fee7", Type.GetType("System.Decimal"))
      .Columns.Add("Pencd1", Type.GetType("System.String"))
      .Columns.Add("Pencd2", Type.GetType("System.String"))
      .Columns.Add("Pencd3", Type.GetType("System.String"))
      .Columns.Add("Pencd4", Type.GetType("System.String"))
      .Columns.Add("Pencd5", Type.GetType("System.String"))
      .Columns.Add("Pencd6", Type.GetType("System.String"))
      .Columns.Add("Pencd7", Type.GetType("System.String"))
      .Columns.Add("Adj", Type.GetType("System.String"))
      .Columns.Add("FirePrin", Type.GetType("System.Decimal"))
      .Columns.Add("FireInt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Bald", Type.GetType("System.Decimal"))
      .Columns.Add("Batch", Type.GetType("System.String"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("RecDt", Type.GetType("System.DateTime"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Msg1", Type.GetType("System.String"))
      .Columns.Add("Msg2", Type.GetType("System.String"))
      .Columns.Add("Msg3", Type.GetType("System.String"))
      .Columns.Add("Msg4", Type.GetType("System.String"))
      .Columns.Add("Msg5", Type.GetType("System.String"))
      .Columns.Add("Error", Type.GetType("System.Boolean"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Sub AddRecords(ByVal BatchNo As Integer, ByVal ReceiptDate As Date, ByVal InterestDate As Date, ByVal Post As Boolean)
    Dim WrkTXType As String()
    Dim Counter As Integer
    Dim WrkFirePrin As Decimal
    Dim WrkFireInt As Decimal
    Dim WrkFirePct As Decimal
    Dim WrkDistPct As Decimal
    Dim WrkInterest As Decimal
    Dim WrkBald As Decimal
    Dim myDr As Data.DataRow

    myFrmProgress = New FrmProgress
    If Post Then
      myFrmProgress.Text = "Creating Posting Reports"
    Else
      myFrmProgress.Text = "Creating Edit Reports"
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveYear = 0
    SaveDist = 0
    WrkDistBreakout = False

    Do While Not myTCRBCHL1.IsEOF
      myTCRBCHL1.ReadFileE()
      With myTCRBCHL1
        If .IsEOF Then Exit Do
        Counter = Counter + 1
        If SaveDist <> ._DIST Or SaveYear <> ._YEAR Then
          WrkFirePct = 0
          WrkDistPct = 1
          myTXMRATE.GetOneRecordP(._YEAR, ._TYPE, ._DIST)
          If Not myTXMRATE.RecordNotFound Then
            With myTXMRATE
              If ._MRFIRE > 0 Then
                WrkFirePct = (._MRFIRE / ._MRRATE)
                WrkFirePct = MyUtils.Round(WrkFirePct, 6)
                WrkDistPct = 1 - WrkFirePct
                WrkDistBreakout = True
              End If
            End With
          End If
        End If
        SaveYear = ._YEAR
        SaveDist = ._DIST

        myDr = ds.Tables(0).NewRow
        myDr("listno") = ._LISTNo
        myDr("type") = ._TYPE
        WrkTXType = LookupType(._TYPE)
        myDr("typedesc") = WrkTXType(0)
        myDr("year") = ._YEAR
        myDr("seq") = ._TRNBR
        myDr("dist") = ._DIST
        If ._TYPE = "U" Or WrkDistPct = 1 Then
          myDr("principal") = ._PAMT
          myDr("interest") = ._IAMT
          myDr("liens") = ._LAMT
          WrkFirePrin = 0
          WrkFireInt = 0
        Else
          myDr("principal") = MyUtils.Round(._PAMT * WrkDistPct, 2)
          myDr("interest") = MyUtils.Round(._IAMT * WrkDistPct, 2)
          myDr("liens") = ._LAMT
          WrkFirePrin = MyUtils.Round(._PAMT * WrkFirePct, 2)
          WrkFireInt = MyUtils.Round(._IAMT * WrkFirePct, 2)
        End If
        myDr("fees") = ._PCAMT
        myDr("fee1") = ._PCAMT1
        myDr("fee2") = ._PCAMT2
        myDr("fee3") = ._PCAMT3
        myDr("fee4") = ._PCAMT4
        myDr("fee5") = ._PCAMT5
        myDr("fee6") = ._PCAMT6
        myDr("fee7") = ._PCAMT7
        myDr("pencd1") = Trim(._PENCD1)
        myDr("pencd2") = Trim(._PENCD2)
        myDr("pencd3") = Trim(._PENCD3)
        myDr("pencd4") = Trim(._PENCD4)
        myDr("pencd5") = Trim(._PENCD5)
        myDr("pencd6") = Trim(._PENCD6)
        myDr("pencd7") = Trim(._PENCD7)
        myDr("adj") = Trim(._ADJ)
        myDr("fireprin") = WrkFirePrin
        myDr("fireint") = WrkFireInt
        myDr("total") = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
        myDr("batch") = MyBatch
        myDr("batchno") = BatchNo
        myDr("recdt") = MyUtils.GetDBDate(._RDTE)
        myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
        myDr("msg1") = ""
        myDr("msg2") = ""
        myDr("msg3") = ""
        myDr("error") = False
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            WrkBald = ._BALD - myTCRBCHL1._PAMT - ._NEWPAY
            myDr("bald") = WrkBald
            myDr("name") = ._NAME
            If ._ICODE = "B" Then
              myDr("msg1") = "Back Tax Due"
            End If
          End With
          If ._PAMT > myTXINV._BALD Then
            myDr("msg2") = "Overpaid Account"
          End If
          CalcInterest(._LISTNo, ._TYPE, ._YEAR, MyUtils.SetDBDate(InterestDate), WrkInterest, 0, 0,
      0, 0, 0, 0, 0)
          If ._IAMT <> WrkInterest And ._PAMT > 0 Then
            myDr("msg2") = "Interest variance"
          End If
          '    If ._PCAMT1 > WrkFee + WrkBond Then
          '      myDr("msg2") = "*** Overpaid Fee ***"
          '      myDr("error") = True
          '      Errors = True
          '    End If
          If myDr("total") = 0 Then
            myDr("msg1") = "Skipped - Zero Amounts"
          End If
          If MyUtils.GetDBDate(._RDTE) <> ReceiptDate Then
            myDr("msg3") = "Receipt Date is " & MyUtils.GetDBDate(._RDTE)
          End If
          If CheckForDup(BatchNo, ._LISTNo, ._TYPE, ._YEAR) Then
            myDr("msg4") = "Multiple transactions for account"
          End If
          If myTXINV._ICODE = "S" Then
            myDr("msg5") = "Suspense Account"
          End If
        Else
          myDr("name") = "*** Record not found ***"
          myDr("error") = True
          Errors = True
        End If
        ds.Tables(0).Rows.Add(myDr)

        With myFrmProgress
          WrkPct = (Counter / 10) Mod 100
          If SavePct <> WrkPct Then
            .ProgBar1.Value = WrkPct
            .LblMsg.Text = "Records processed: " & Counter
            .Refresh()
            SavePct = WrkPct
            Application.DoEvents()
          End If
        End With
      End With
    Loop

    myFrmProgress.Close()
    Application.DoEvents()

  End Sub
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.myData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.mydata(MyDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkCode(I) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function
  Private Function CheckForDup(ByVal BatchNo As Integer, ByVal List As Integer,
  ByVal Type As String, ByVal Year As Integer) As Boolean

    Dim ds2 As DataSet = New DataSet
    Dim WrkDup As Boolean


    WrkDup = False
    ds2 = myTCRBCHL1.GetViewbyList(BatchNo, List, Year, Type, 2)
    If ds2.Tables(0).Rows.Count > 1 Then
      WrkDup = True
    End If

    Return WrkDup
  End Function
End Module






