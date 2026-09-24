Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow
  Dim drTot As Data.DataRow

  'Screen
  Dim WrkSelClass As Integer
  Dim WrkRoundDown As Boolean
  Dim WrkInclDMV As Boolean
  Dim WrkInclPost As Boolean
  Dim WrkPost As Boolean

  'Control File
  Dim WrkBookPct As Decimal
  Dim WrkMinValue As Integer

  'Totals
  Dim WrkTCount As Integer
  Dim WrkTValue As Integer
  Public Sub PrtReport()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      dsTot.Clear()
      ClearTotals()
    End If
    GetTXMCTL()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.wrkdsTot = dsTot
    MyCrViewer.Show()

  End Sub
  Private Sub GetTXMCTL()
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMCTL.GetOneRecordP(1)
    If Not myTXMCTL.RecordNotFound Then
      With myTXMCTL
        WrkBookPct = ._VALPER
        WrkMinValue = ._VALMIN
      End With
    End If
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("source", Type.GetType("System.String"))
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("value", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytableTot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TValue", Type.GetType("System.Int32"))
    End With
    dstot.Tables.Add(myTableTot)
  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTValue = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim J As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkConfig As Integer
    Dim WrkSource As String
    Dim WrkMSRP As Integer
    Dim WrkValue As Integer
    Dim WrkComplete As String

    WrkSort = "MAKE, YEAR, MODEL, CLASS"
    With MyFrmTA432B
      WrkSelClass = MyUtils.CnvSng(.TxtClass.Text)
      WrkRoundDown = .RbDown.Checked
      WrkInclDMV = .ChkInclDMV.Checked
      WrkInclPost = .ChkInclPost.Checked
      WrkPost = .ChkUpdate.Checked
    End With

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "CAT = '1'"
    If Not WrkInclDMV Then
      WrkQry = WrkQry & WrkAnd & "MSRP=0"
    End If
    If WrkSelClass > 0 Then
      WrkQry = WrkQry & WrkAnd & "class=" & WrkSelClass
    Else
      WrkQry = WrkQry & WrkAnd & "class<>25"
    End If
    myTXMVDQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXMVDQ.ReadQry()
    If Not myTXMVDQ.IsEOF Then
      With myTXMVDQ
        Counter = Counter + 1
        WrkSource = ""
        WrkValue = 0
        myTXMSRP.GetOneRecordP(._VINNO)
        With myTXMSRP
          If Not .RecordNotFound Then
            If Not WrkInclPost Then
              If ._OVMSRP > 0 Then
                GoTo NextRec
              End If
            Else
              If ._OVSOURCE <> "P" Then
                GoTo NextRec
              End If
            End If
          End If
        End With

        WrkConfig = GetPriceDigestConfig(Trim(._VINNO), ._YEAR)
        If WrkConfig = 0 Then
          GoTo NextRec
        End If
        If WrkInclDMV And ._MSRP > 0 Then
          WrkMSRP = ._MSRP
          WrkSource = "DMV"
        Else
          WrkMSRP = GetPriceDigestMSRP(WrkConfig)
          WrkSource = "PD"
        End If
        WrkComplete = GetPriceDigestComplete(WrkConfig)
        If WrkMSRP > 0 Then
          If WrkInclDMV And WrkSource = "DMV" Then
            WrkValue = ._VALUE
          Else
            WrkValue = CalcValue(WrkMSRP, ._YEAR)
            J = WrkValue Mod 10
            If J <> 0 Then
              If WrkRoundDown Then
                WrkValue = WrkValue - J
              Else
                If J < 5 Then
                  WrkValue = WrkValue - J
                Else
                  WrkValue = WrkValue + (10 - J)
                End If
              End If
            End If
          End If
          If WrkMinValue > 0 Then
            If WrkMinValue > WrkValue Then
              WrkValue = WrkMinValue
            End If
          End If
        End If

        If WrkValue > 0 Or WrkComplete = "N" Then
          If WrkComplete = "Y" Then
            dr = ds.Tables(0).NewRow
          Else
            dr = ds2.Tables(0).NewRow
          End If
          dr.Item("listno") = ._LISTNo
          dr.Item("Oname") = Trim(._NAME)
          dr.Item("class") = ._CLASS
          dr.Item("year") = ._YEAR
          dr.Item("make") = Trim(._MAKE)
          dr.Item("model") = Trim(._MODEL)
          dr.Item("idno") = Trim(._VINNO)
          dr.Item("source") = WrkSource
          dr.Item("msrp") = WrkMSRP
          dr.Item("value") = WrkValue
          WrkTCount = WrkTCount + 1
          WrkTValue = WrkTValue + WrkValue
          If WrkComplete = "Y" Then
            ds.Tables(0).Rows.Add(dr)
          Else
            ds2.Tables(0).Rows.Add(dr)
          End If

          If WrkPost Then
            UpdateTXMVD(._LISTNo, WrkValue)
            With myTXMSRP
              .GetOneRecordP(Trim(myTXMVDQ._VINNO))
              If WrkSource = "PD" Then
                ._OVMSRP = WrkMSRP
              End If
              ._OVSOURCE = "P"
              ._COMPLETE = WrkComplete
              If .RecordNotFound Then
                ._VINNO = Trim(myTXMVDQ._VINNO)
                ._NONTAX = ""
                .AddOneRecordP()
              Else
                .UpdateOneRecordP()
              End If
            End With
          End If
        End If
      End With

NextRec:
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
      GoTo ReadNext
    End If

    WriteTotals()

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
    myTXMVD.CloseFile()

  End Sub
  Private Sub WriteTotals()
    If WrkTCount = 0 Then Exit Sub

    drTot = dsTot.Tables(0).NewRow
    drTot.Item("tcount") = WrkTCount
    drTot.Item("tvalue") = WrkTValue
    dsTot.Tables(0).Rows.Add(drTot)
  End Sub
  Private Sub UpdateTXMVD(ByVal WrkListNo As Integer, ByVal WrkValue As Integer)
    myTXMVD.GetOneRecordP(WrkListNo)
    If myTXMVD.RecordNotFound Then Exit Sub

    With myTXMVD
      ._VALUE = WrkValue
      .UpdateOneRecordP()
    End With
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkYear As Integer) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = 2024 - WrkYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkMSRP > 0 Then
      WrkValue = WrkMSRP * WrkDepr * WrkBookPct
    End If
    If WrkValue < WrkMinValue Then
      WrkValue = WrkMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Function GetPriceDigestConfig(ByVal WrkVIN As String, ByVal WrkYear As Integer) As Integer
    Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
    Dim WrkConfig As Integer
    WrkConfig = 0
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    With myPriceDigestVIN
      .GetApiVIN(WrkVIN)
      If .IsError Then
        Return 0
      End If
      If WrkYear - .modelYear > 1 Then 'If Vehicle year is more than 1 year different then it's an error
        Return 0
      End If
      WrkConfig = myPriceDigestVIN.configurationId
    End With
    Return WrkConfig
  End Function
  Private Function GetPriceDigestMSRP(ByVal WrkConfig As Integer) As Integer
    Dim myPriceDigestValue As PriceDigestAPI.ApiValue
    Dim WrkMSRP As Integer
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    With myPriceDigestValue
      .GetApiValue(WrkConfig)
      WrkMSRP = .MSRP
    End With
    Return WrkMSRP
  End Function
  Private Function GetPriceDigestComplete(ByVal WrkConfig As Integer) As String
    Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
    Dim WrkComplete As String
    WrkComplete = ""
    myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
    With myPriceDigestSpecs
      .GetApiSpecs(WrkConfig)
      WrkComplete = .Complete
    End With
    Return WrkComplete
  End Function
End Module
