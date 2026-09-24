Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCSUMQ As TXDCSUMQ.MyData
  Dim myTXDCDTL As TXDCDTL.MyData
  Dim myTXDCDEP As TXDCDEP.MyData
  Dim MyTXDCPP As TXDCPP.MyData
  Dim myTXDCCD As TXDCCD.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Dim WrkNoDetail As Boolean
  Public Sub PrtReportSU()

    myTXDCSUMQ = New TXDCSUMQ.MyData(myDBConnect)
    myTXDCDTL = New TXDCDTL.MyData(myDBConnect)
    myTXDCDEP = New TXDCDEP.MyData(myDBConnect)
    MyTXDCPP = New TXDCPP.MyData(myDBConnect)
    myTXDCCD = New TXDCCD.MyData(myDBConnect)

    With MyFrmTAP22B
      WrkYear = .TxtGLYear.Text
      WrkNoDetail = .ChkNoDetail.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Show()
    End With

  End Sub
  Friend Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("DBA", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.Int16"))
      .Columns.Add("Summary", Type.GetType("System.Int32"))
      .Columns.Add("Detail", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkYearNo As Integer
    Dim WrkProrated As Integer
    Dim WrkValue As Integer
    Dim WrkTotValue As Integer
    Dim WrkDiff As Integer
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "YEAR = " & WrkYear
    myTXDCSUMQ.OpenQry("LIST#", WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCSUMQ.ReadQry()
    If Not myTXDCSUMQ.IsEOF Then
      With myTXDCSUMQ
        Counter = Counter + 1
        myTXDCCD.GetOneRecordP(WrkYear, ._CODE, "")
        If Trim(myTXDCCD._DECODE) = "" Then
          GoTo NextRec
        End If
        ds2 = myTXDCDTL.GetByCode(._LISTNO, WrkYear, ._CODE)
        WrkTotValue = 0
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          WrkYearNo = ds2.Tables(0).Rows(I).Item("year") - ds2.Tables(0).Rows(I).Item("deyear") + 1
          myTXDCDEP.GetOneRecordP(WrkYear, myTXDCCD._DECODE, WrkYearNo)
          If myTXDCDEP._PROPCT > 0 Then
            WrkProrated = MyUtils.Round(ds2.Tables(0).Rows(I).Item("DECOST") * (myTXDCDEP._PROPCT / 100), 0)
          Else
            WrkProrated = ds2.Tables(0).Rows(I).Item("DECOST")
          End If
          WrkValue = MyUtils.Round(WrkProrated * (myTXDCDEP._PCT / 100), 0)
          WrkTotValue = WrkTotValue + WrkValue
        Next
        If WrkNoDetail And WrkTotValue = 0 Then
          GoTo NextRec
        End If
        WrkDiff = Math.Abs(WrkTotValue - ._VALUE)
        If WrkDiff > 1 Then
          dr = ds.Tables(0).NewRow
          dr.Item("Listno") = ._LISTNO
          dr.Item("Code") = ._CODE
          MyTXDCPP.GetOneRecordP(._LISTNO, WrkYear)
          dr.Item("Name") = Trim(MyTXDCPP._OWNAME)
          dr.Item("DBA") = Trim(MyTXDCPP._DBA)
          dr.Item("Summary") = ._VALUE
          dr.Item("Detail") = WrkTotValue
          ds.Tables(0).Rows.Add(dr)
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

    myFrmProgress.Close()
    myTXDCSUMQ.CloseFile()

  End Sub
End Module






