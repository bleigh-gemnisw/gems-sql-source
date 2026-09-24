Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myUTCUST As UTCUST.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkGLYear As Integer
  Dim WrkType As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSortBy As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)

    With MyFrmTXE49B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkType = .TxtType.Text
      WrkPost = .Chkupdatebacktax.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("ZipA", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim dr As DataRow
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkFamily As String
    Dim WrkZipA As String
    Dim Counter As Integer
    Dim WrkSname As String
    Dim I As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If

    WrkFamily = GetTXTypeFamily(WrkType)
    'Milford use Real Estate for type U
    If myTOWN._TOWNBR = 84 Then
      If WrkType = "U" Then
        WrkFamily = "R"
      End If
    End If
    WrkSort = "LIST#, YEAR"
    WrkQry = "icode<>'I'" & WrkAnd & "TYPE=" & MyUtils.Quo(WrkType) & WrkAnd & "YEAR=" & WrkGLYear
    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        Counter = Counter + 1
        Select Case WrkFamily
          Case "R"
            myTXREAL.GetOneRecordP(._LISTNo)
            If myTXREAL.RecordNotFound Then GoTo NextRec
            If Trim(myTXREAL._NAME) = Trim(._NAME) And Trim(myTXREAL._SNAME) = Trim(._SNAME) _
            And Trim(myTXREAL._ADD1) = Trim(._ADD1) And Trim(myTXREAL._ADD2) = Trim(._ADD2) _
            And Trim(myTXREAL._CITY) = Trim(._CITY) And Trim(myTXREAL._STATE) = Trim(._STATE) _
            And Trim(myTXREAL._ZIP5) = Trim(._ZIP5) And Trim(myTXREAL._ZIP4) = Trim(._ZIP4) Then
              GoTo NextRec
            End If
            If Trim(myTXREAL._NAME) = Trim(._NAME) Then
              WrkSname = myTXREAL._SNAME
            Else
              If My2NDNO Then
                WrkSname = Mid(myTXREAL._NAME, 1, 31) & " N/O"
              Else
                WrkSname = "N/O " & Mid(myTXREAL._NAME, 1, 31)
              End If
            End If
            If Trim(._SNAME) = Trim(WrkSname) _
            And Trim(myTXREAL._ADD1) = Trim(._ADD1) And Trim(myTXREAL._ADD2) = Trim(._ADD2) _
            And Trim(myTXREAL._CITY) = Trim(._CITY) And Trim(myTXREAL._STATE) = Trim(._STATE) _
            And Trim(myTXREAL._ZIP5) = Trim(._ZIP5) And Trim(myTXREAL._ZIP4) = Trim(._ZIP4) Then
              GoTo NextRec
            End If
            WrkZipA = Format(myTXREAL._ZIP5, "00000")
            If ._ZIP4 > 0 Then
              WrkZipA = WrkZipA + "-" + Format(myTXREAL._ZIP4, "0000")
            End If
            WriteDs(WrkSname, myTXREAL._ADD1, myTXREAL._ADD2, myTXREAL._CITY, WrkZipA)
            If WrkPost Then
              myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
              myTXINV._SNAME = WrkSname
              myTXINV._ADD1 = myTXREAL._ADD1
              myTXINV._ADD2 = myTXREAL._ADD2
              myTXINV._CITY = myTXREAL._CITY
              myTXINV._STATE = myTXREAL._STATE
              myTXINV._ZIP5 = myTXREAL._ZIP5
              myTXINV._ZIP4 = myTXREAL._ZIP4
              myTXINV.UpdateOneRecordP()
            End If
          Case "A", "U"
            myUTCUST.GetOneRecordP(._LISTNo)
            If myUTCUST.RecordNotFound Then GoTo NextRec
            WrkZipA = Format(._ZIP5, "00000")
            If ._ZIP4 > 0 Then
              WrkZipA = WrkZipA + "-" + Format(._ZIP4, "0000")
            End If
            If Trim(myUTCUST._CUNAM1) = Trim(._NAME) _
            And Trim(myUTCUST._CUADD1) = Trim(._ADD1) And Trim(myUTCUST._CUADD2) = Trim(._ADD2) _
            And Trim(myUTCUST._CUCITY) = Trim(._CITY) And Trim(myUTCUST._CUST) = Trim(._STATE) _
            And Trim(myUTCUST._CUZIP) = WrkZipA Then
              GoTo NextRec
            End If
            If Trim(myUTCUST._CUNAM1) = Trim(myTXINVQ._NAME) Then
              WrkSname = myUTCUST._CUNAM2
            Else
              If My2NDNO Then
                WrkSname = Mid(myUTCUST._CUNAM1, 1, 31) & " N/O"
              Else
                WrkSname = "N/O " & Mid(myUTCUST._CUNAM1, 1, 31)
              End If
            End If
            If Trim(._SNAME) = Trim(WrkSname) _
            And Trim(myUTCUST._CUADD1) = Trim(._ADD1) And Trim(myUTCUST._CUADD2) = Trim(._ADD2) _
            And Trim(myUTCUST._CUCITY) = Trim(._CITY) And Trim(myUTCUST._CUST) = Trim(._STATE) _
            And Trim(myUTCUST._CUZIP) = WrkZipA Then
              GoTo NextRec
            End If
            WriteDs(WrkSname, myUTCUST._CUADD1, myUTCUST._CUADD2, myUTCUST._CUCITY, myUTCUST._CUZIP)
            If WrkPost Then
              myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
              myTXINV._SNAME = WrkSname
              myTXINV._ADD1 = myUTCUST._CUADD1
              myTXINV._ADD2 = myUTCUST._CUADD2
              myTXINV._CITY = myUTCUST._CUCITY
              myTXINV._STATE = myUTCUST._CUST
              myTXINV._ZIP5 = MyUtils.CnvSng(Mid(myUTCUST._CUZIP, 1, 5))
              If Len(Trim(myUTCUST._CUZIP)) > 5 Then
                myTXINV._ZIP4 = Mid(myUTCUST._CUZIP, 7, 4)
              Else
                myTXINV._ZIP4 = 0
              End If
              myTXINV.UpdateOneRecordP()
            End If
          Case Else
        End Select
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
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub WriteDs(ByVal WrkSname As String, WrkAdd1 As String, WrkAdd2 As String, WrkCity As String,
 WrkZipA As String)

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = myTXINVQ._LISTNo
    dr.Item("Name") = Trim(myTXINVQ._NAME)
    dr.Item("Sname") = WrkSname
    dr.Item("Addr1") = Trim(WrkAdd1)
    dr.Item("Addr2") = Trim(WrkAdd2)
    dr.Item("City") = Trim(WrkCity)
    dr.Item("ZipA") = Trim(WrkZipA)
    ds.Tables(0).Rows.Add(dr)
  End Sub
End Module






