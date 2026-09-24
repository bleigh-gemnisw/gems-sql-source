Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.myData
  Dim myTXINVQ As TXINVQ.myData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkCurrYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  'Buffered Fields
  Dim WrkList(100000) As Integer
  Dim WrkVIN(100000) As String
  Dim WrkCustID(100000) As Long
  Public Sub PrtReport()

    myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
    myTXINVQ = New TXINVQ.mydata(MyDBConnect)

    With MyFrmTA525B
      WrkCurrYear = MyUtils.CnvSng(.TxtCurrYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferMVYear()
    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("select", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("olist", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    If myDBConnect.ServerName = "DB2" Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "LIST#"
    WrkQry = "ASS<>'A'"
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    myTXSUPPQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXSUPPQ.ReadQry()
    If Not myTXSUPPQ.IsEOF Then
      With myTXSUPPQ
        Counter = Counter + 1
        K = LookupMVYear(Trim(._VINNO), ._SSNo)
        If K >= 0 Then
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNo
          dr.Item("name") = Trim(._NAME)
          dr.Item("vinno") = Trim(._VINNO)
          dr.Item("olist") = WrkList(K)
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
    Application.DoEvents()
    myTXSUPPQ.CloseFile()

  End Sub
  Friend Sub BufferMVYear()
    'Buffer Current MV year 
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim J As Integer

    Array.Clear(WrkList, 0, 100000)
    Array.Clear(WrkVIN, 0, 100000)
    Array.Clear(WrkCustID, 0, 100000)

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "YEAR=" & WrkCurrYear & WrkAnd & "TYPE='M'"
    WrkSort = ""
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If Trim(._IMVIDNo) <> "" Then
          WrkList(J) = ._LISTNo
          WrkVIN(J) = Trim(._IMVIDNo)
          WrkCustID(J) = ._SSNo
          J = J + 1
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
    Application.DoEvents()
    myTXINVQ.CloseFile()
  End Sub
  Friend Function LookupMVYear(ByVal pVIN As String, ByVal pCustID As Long) As Integer
    Dim I As Integer
    For I = 0 To WrkVIN.GetUpperBound(0)
      If Trim(WrkVIN(I)) = "" Then
        Return -1
      End If
      If Trim(pVIN) = Trim(WrkVIN(I)) And pCustID = WrkCustID(I) Then
        Return I
      End If
    Next
    Return -1
  End Function
End Module





