Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTCUST As UTCUST.MyData
  Dim myTXREALQ As TXREALQ.MyData

  Dim ds As DataSet = New DataSet
  Dim WrkYear As Integer
  Dim WrkRegCode As String
  Dim WrkSoldCode As String
  Dim WrkRegSize As String
  Dim WrkSoldSize As String
  Dim WrkPost As Boolean
  Public Sub Impdata()
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myTXREALQ = New TXREALQ.MyData(myDBConnect)

    With MyFrmUB431B
      WrkYear = .TxtYear.Text
      WrkRegCode = .TxtRegCode.Text
      WrkSoldCode = .TxtSoldCode.Text
      WrkRegSize = .TxtRegSize.Text
      WrkSoldSize = .TxtSoldSize.Text
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If
    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds1 = ds
      .Show()
    End With
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkSort = ""
    WrkQry = "PURDT >=" & WrkYear & "0101 and PURDT<=" & WrkYear & "1231"
    Counter = 0

    myTXREALQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    myUTCUSTRT.ChangeCode(WrkSoldCode, WrkRegCode)
    myUTCUST.ChangeMeterSize(WrkSoldSize, WrkRegSize)

ReadNext:
    myTXREALQ.ReadQry()
    If Not myTXREALQ.IsEOF Then
      With myTXREALQ
        Counter = Counter + 1
        myUTCUSTRT.GetOneRecordP(._LISTNO, "U")
        myUTCUST.GetOneRecordP(._LISTNO)
        If myUTCUSTRT._CRCODE = WrkRegCode Then
          AddToReport()
          If WrkPost Then
            UpdateUTCUSTRT()
            myUTCUST.GetOneRecordP(._LISTNO)
            myUTCUST._CUMSIZ = WrkSoldSize
            myUTCUST.UpdateOneRecordP()
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

    myFrmProgress.Close()
    myTXREALQ.CloseFile()

  End Sub
  Private Sub UpdateUTCUSTRT()
    With myUTCUSTRT
      ._CRCODE = WrkSoldCode
      .UpdateOneRecordP()
    End With
  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("dtsold", Type.GetType("System.DateTime"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Public Sub AddToReport()
    Dim dr As DataRow
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = myTXREALQ._LISTNO
    dr.Item("name") = myUTCUST._CUNAM1
    dr.Item("dtsold") = MyUtils.GetDBDate(myTXREALQ._PURDT)
    ds.Tables(0).Rows.Add(dr)
  End Sub
End Module






