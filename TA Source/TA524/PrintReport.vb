Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXSUPP As TXSupp.MyData
  Dim myTXINVQ As TXINVQ.MyData
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkPrevYear As Integer
  Dim WrkCurrYear As Integer
  Dim WrkUpdate As Boolean
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  'Buffered Fields
  Dim WrkPrevList(100000) As Integer
  Dim WrkPrevVIN(100000) As String
  Dim WrkPrevName(100000) As String
  Dim WrkPrevCustID(100000) As String
  Dim WrkCurrList(100000) As Integer
  Dim WrkCurrVIN(100000) As String
  Public Sub PrtReport()

    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    myTXSUPP = New TXSupp.MyData(myDBConnect)
    myTXINVQ = New TXINVQ.MyData(myDBConnect)

    With MyFrmTA524B
      WrkPrevYear = MyUtils.CnvSng(.TxtPrevYear.Text)
      WrkCurrYear = MyUtils.CnvSng(.TxtCurrYear.Text)
      WrkUpdate = .ChkUpdate.Checked
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    BufferPrevMVYear()
    BufferCurrMVYear()
    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .Show()
    End With
  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("olist", Type.GetType("System.Int64"))
      .Columns.Add("oname", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim K As Integer
    Dim L As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkMatch As Boolean

    If myDBConnect.ServerName = "DB2" Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "NAME"
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
        K = LookupPrevMVYear(Trim(._VINNO))
        If K >= 0 Then
          L = LookupCurrMVYear(Trim(._VINNO))
          If L = -1 Then
            'If Mid(._NAME, 1, 3) = Mid(WrkPrevName(K), 1, 3) Then
            '  WrkMatch = True
            'Else
            '  WrkMatch = False
            'End If
            If ._SSNo = WrkPrevCustID(K) Then
              WrkMatch = True
              dr = ds.Tables(0).NewRow
            Else
              WrkMatch = False
              dr = ds2.Tables(0).NewRow
            End If
            dr.Item("listno") = ._LISTNo
            dr.Item("name") = Trim(._NAME)
            dr.Item("vinno") = Trim(._VINNO)
            dr.Item("olist") = WrkPrevList(K)
            dr.Item("oname") = WrkPrevName(K)
            If WrkMatch Then
              ds.Tables(0).Rows.Add(dr)
            Else
              ds2.Tables(0).Rows.Add(dr)
            End If
            If WrkUpdate And WrkMatch Then
              With myTXSUPP
                .GetOneRecordP(myTXSUPPQ._LISTNo)
                ._ASS = "A"
                ._OASS = ""
                ._OCLS = 0
                ._OID = ""
                ._OLIST = 0
                ._OMAKE = ""
                ._OMOD = ""
                ._OPVAL = 0
                ._OREGNO = ""
                ._OVAL = 0
                ._OVIN = ""
                ._OYEAR = 0
                ._PCCOD = 0
                ._PNET = ._VALUE
                ._PREG = ""
                ._PVAL = 0
                .UpdateOneRecordP()
              End With
            End If
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
    Application.DoEvents()
    myTXSUPPQ.CloseFile()

  End Sub
  Friend Sub BufferPrevMVYear()
    'Buffer Previous MV year 
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim J As Integer

    Array.Clear(WrkPrevList, 0, 100000)
    Array.Clear(WrkPrevVIN, 0, 100000)
    Array.Clear(WrkPrevName, 0, 100000)

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "YEAR=" & WrkPrevYear & WrkAnd & "TYPE='M'"
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
          WrkPrevList(J) = ._LISTNo
          WrkPrevVIN(J) = Trim(._IMVIDNo)
          WrkPrevName(J) = Trim(._NAME)
          WrkPrevCustID(J) = ._SSNo
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
  Friend Sub BufferCurrMVYear()
    'Buffer Current MV year 
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim J As Integer

    Array.Clear(WrkCurrList, 0, 100000)
    Array.Clear(WrkCurrVIN, 0, 100000)

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
          WrkCurrList(J) = ._LISTNo
          WrkCurrVIN(J) = Trim(._IMVIDNo)
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
  Friend Function LookupPrevMVYear(ByVal pVIN As String) As Integer
    Dim I As Integer
    For I = 0 To WrkPrevVIN.GetUpperBound(0)
      If Trim(WrkPrevVIN(I)) = "" Then
        Return -1
      End If
      If Trim(pVIN) = Trim(WrkPrevVIN(I)) Then
        Return I
      End If
    Next
    Return -1
  End Function
  Friend Function LookupCurrMVYear(ByVal pVIN As String) As Integer
    Dim I As Integer
    For I = 0 To WrkCurrVIN.GetUpperBound(0)
      If Trim(WrkCurrVIN(I)) = "" Then
        Return -1
      End If
      If Trim(pVIN) = Trim(WrkCurrVIN(I)) Then
        Return I
      End If
    Next
    Return -1
  End Function
End Module





