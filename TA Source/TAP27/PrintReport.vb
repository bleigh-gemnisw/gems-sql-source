Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim MyTXDCPPQ As TXDCPPQ.MyData
  Dim MyTXDCDTL As TXDCDTL.MyData
  Dim MyTXDCCD As TXDCCD.MyData
  Dim MyTXDCDEP As TXDCDEP.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Public Sub PrtReport()

    MyTXDCPPQ = New TXDCPPQ.MyData(myDBConnect)
    MyTXDCDTL = New TXDCDTL.MyData(myDBConnect)
    MyTXDCCD = New TXDCCD.MyData(myDBConnect)
    MyTXDCDEP = New TXDCDEP.MyData(myDBConnect)

    With MyFrmTAP27B
      WrkYear = .TxtGLYear.Text
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
      .Columns.Add("Ltr", Type.GetType("System.String"))
      .Columns.Add("DeYear", Type.GetType("System.Int16"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkYearNo As Integer
    Dim Counter As Integer

    WrkAnd = " *and "
    WrkQry = "YEAR = " & WrkYear
    MyTXDCPPQ.OpenQry("LIST#", WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    MyTXDCPPQ.ReadQry()
    If Not MyTXDCPPQ.IsEOF Then
      With MyTXDCPPQ
        Counter = Counter + 1
        ds2 = MyTXDCDTL.GetByList(._LISTNO, WrkYear)
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          MyTXDCCD.GetOneRecordP(WrkYear, ds2.Tables(0).Rows(I).Item("CODE"), ds2.Tables(0).Rows(I).Item("LTR"))
          WrkYearNo = WrkYear - ds2.Tables(0).Rows(I).Item("deyear") + 1
          MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo)
          If MyTXDCDEP.RecordNotFound Then Continue For
          dr = ds.Tables(0).NewRow
          dr("ListNo") = ._LISTNO
          dr("Name") = Trim(._OWNAME)
          dr("dba") = Trim(._DBA)
          dr("Code") = ds2.Tables(0).Rows(I).Item("Code")
          dr("Ltr") = ds2.Tables(0).Rows(I).Item("Ltr")
          dr("DeYear") = ds2.Tables(0).Rows(I).Item("deyear")
          If MyTXDCDEP._PRIOR = "Y" Then
            dr("Descr") = "Prior Yrs"
          Else
            dr("Descr") = ds2.Tables(0).Rows(I).Item("deyear")
          End If
          dr("Amount") = ds2.Tables(0).Rows(I).Item("DECOST")
          ds.Tables(0).Rows.Add(dr)
        Next
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
    MyTXDCPPQ.CloseFile()
  End Sub
End Module