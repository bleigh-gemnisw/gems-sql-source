Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCSUMQ As TXDCSUMQ.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim MyTXDCPP As TXDCPP.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Dim WrkYear2 As Integer
  Dim WrkCode As Integer
  Public Sub PrtReport()

    myTXDCSUMQ = New TXDCSUMQ.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    MyTXDCPP = New TXDCPP.MyData(myDBConnect)

    With MyFrmTAP26B
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkYear2 = MyUtils.CnvSng(.TxtGLYear2.Text)
      WrkCode = MyUtils.CnvSng(.TxtCode.Text)
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
      .WrkCode = WrkCode
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
      .Columns.Add("Amount", Type.GetType("System.Int32"))
      .Columns.Add("Amount2", Type.GetType("System.Int32"))
      .Columns.Add("Diff", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkDiff As Integer
    Dim Counter As Integer

    WrkAnd = " and "
    WrkQry = "YEAR = " & WrkYear
    If WrkCode > 0 Then
      WrkQry = WrkQry & WrkAnd & "CODE = " & WrkCode
    End If
    myTXDCSUMQ.OpenQry("LIST#,CODE", WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCSUMQ.ReadQry()
    If Not myTXDCSUMQ.IsEOF Then
      With myTXDCSUMQ
        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("Listno") = ._LISTNO
        dr.Item("Code") = ._CODE
        MyTXDCPP.GetOneRecordP(._LISTNO, WrkYear)
        dr.Item("Name") = Trim(MyTXDCPP._OWNAME)
        dr.Item("DBA") = Trim(MyTXDCPP._DBA)
        dr.Item("Amount") = ._VALUE
      End With
      With myTXDCSUM
        .GetOneRecordP(myTXDCSUMQ._LISTNO, WrkYear2, myTXDCSUMQ._CODE)
        If Not .RecordNotFound Then
          dr.Item("Amount2") = ._VALUE
          WrkDiff = dr.Item("amount") - myTXDCSUM._VALUE
        Else
          dr.Item("Amount2") = 0
          WrkDiff = dr.Item("amount")
        End If
      End With
      dr.Item("Diff") = WrkDiff
      If dr.Item("amount") <> 0 Or dr.Item("amount2") <> 0 Then
        ds.Tables(0).Rows.Add(dr)
      End If

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