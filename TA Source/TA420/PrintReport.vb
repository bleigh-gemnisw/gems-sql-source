Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim found As Boolean
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXMVD As TXMVD.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dserr As DataSet = New DataSet
  Dim DsTXMVDQ As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow
  Dim drerr As Data.DataRow

  'Screen
  Dim WrkPrior As Boolean
  Dim WrkMin As Integer
  Dim WrkDecr As Boolean
  Dim WrkPctChg As Decimal
  Dim WrkSelClass As Integer
  Dim WrkPost As Boolean
  'Totals
  Dim WrkTCount As Integer
  Dim WrkTLstYrVal As Integer
  Dim WrkTNewVal As Integer
  'Buffered Fields
  Dim WrkClass(100000) As Integer
  Dim WrkYear(100000) As Integer
  Dim WrkMake(100000) As String
  Dim WrkModel(100000) As String
  Dim WrkValue(100000) As Integer

  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
      dserr = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      dserr.Clear()
      ClearTotals()
    End If

    WrkPrior = False
    If MyFrmTA420B.RbMV.Checked Or MyFrmTA420B.RbSU.Checked Then
      WrkPrior = True
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.wrkdserr = dserr
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("lstyrval", Type.GetType("System.Int32"))
      .Columns.Add("newval", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)


    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TLYVal", Type.GetType("System.Int32"))
      .Columns.Add("TNewVal", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTLstYrVal = 0
    WrkTNewVal = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkFromYear As Integer
    Dim WrkToYear As Integer
    Dim WrkListNo As Integer
    Dim WrkLstYrVal As Integer
    Dim WrkNewVal As Integer

    WrkSort = "MAKE, YEAR, MODEL, CLASS"
    With MyFrmTA420B
      WrkMin = MyUtils.CnvSng(.LblMinVal.Text)
      WrkDecr = .RbDecr.Checked
      WrkPctChg = MyUtils.CnvSng(.TxtPct.Text) / 100
      WrkSelClass = MyUtils.CnvSng(.TxtClass.Text)
      WrkFromYear = MyUtils.CnvSng(.TxtFromYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToYear.Text)
      WrkPost = .ChkUpdate.Checked
    End With

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "CAT = '1'" & WrkAnd & "VALUE=0"
    If WrkSelClass > 0 Then
      WrkQry = WrkQry & WrkAnd & "class=" & WrkSelClass
    Else
      WrkQry = WrkQry & WrkAnd & "class<>25"
    End If
    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkFromYear
    End If
    If WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkToYear
    End If

    If MyFrmTA420B.RbMV.Checked Or MyFrmTA420B.RbSU.Checked Then
      BufferPrevMVD()
    End If

    DsTXMVDQ = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXMVDQ.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXMVDQ.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXMVDQ.Tables(0).Rows(I)
        WrkLstYrVal = 0
        WrkNewVal = 0
        WrkListNo = .Item("list#")
        If WrkPrior Then
          K = LookupPrevMVD(.Item("class"), .Item("year"), Trim(.Item("make")), Trim(.Item("model")))
          If K >= 0 Then
            WrkLstYrVal = WrkValue(K)
            'If multiple values found then add to skipped list
            If WrkLstYrVal = -1 Then
              drerr = dserr.Tables(0).NewRow
              drerr.Item("listno") = .Item("list#")
              drerr.Item("Oname") = .Item("name")
              drerr.Item("class") = .Item("class")
              drerr.Item("year") = .Item("year")
              drerr.Item("make") = .Item("make")
              drerr.Item("model") = .Item("model")
              drerr.Item("idno") = .Item("vinno")
              drerr.Item("newval") = 0
              drerr.Item("lstyrval") = 0
              dserr.Tables(0).Rows.Add(drerr)
              GoTo NextRec
            End If
            If WrkPctChg > 0 Then
              If WrkDecr Then
                WrkNewVal = WrkValue(K) - (WrkValue(K) * WrkPctChg)
              Else
                WrkNewVal = WrkValue(K) + (WrkValue(K) * WrkPctChg)
              End If
            Else
              WrkNewVal = WrkValue(K)
            End If
            J = WrkNewVal Mod 10
            If J >= 5 Then
              WrkNewVal = WrkNewVal + (10 - J)
            Else
              WrkNewVal = WrkNewVal - J
            End If
          End If
        End If
        If WrkMin > 0 Then
          If WrkMin > WrkNewVal Then
            WrkNewVal = WrkMin
          End If
        End If

        If WrkPrior And WrkLstYrVal > 0 Or Not WrkPrior And WrkMin > 0 Then
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("Oname") = .Item("name")
          dr.Item("class") = .Item("class")
          dr.Item("year") = .Item("year")
          dr.Item("make") = .Item("make")
          dr.Item("model") = .Item("model")
          dr.Item("idno") = .Item("vinno")
          dr.Item("newval") = WrkNewVal
          dr.Item("lstyrval") = WrkLstYrVal
          WrkTCount = WrkTCount + 1
          WrkTLstYrVal = WrkTLstYrVal + WrkLstYrVal
          WrkTNewVal = WrkTNewVal + WrkNewVal
          ds.Tables(0).Rows.Add(dr)
        End If
      End With
      If WrkPrior Then
        If WrkLstYrVal > 0 And WrkPost Then
          UpdateTXMVD(WrkListNo, WrkNewVal)
        End If
      Else
        If WrkMin > 0 And WrkPost Then
          UpdateTXMVD(WrkListNo, WrkNewVal)
        End If
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXMVDQ.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    WriteTotals()

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
    myTXMVD.CloseFile()

  End Sub
  Private Sub WriteTotals()
    If WrkTCount = 0 Then Exit Sub

    dr2 = ds2.Tables(0).NewRow
    dr2.Item("tcount") = WrkTCount
    dr2.Item("tLYval") = WrkTLstYrVal
    dr2.Item("tNewVal") = WrkTNewVal
    ds2.Tables(0).Rows.Add(dr2)
  End Sub
  Friend Sub BufferPrevMVD()
    'Buffer MV file. Create one record per Class/Year/Make/Model 
    Dim myTXMVDCQ As TXMVDCQ.MyData
    Dim myTXSUPPQ As TXSUPPQ.MyData
    Dim dsMV As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim SaveClass As Integer
    Dim SaveYear As Integer
    Dim SaveMake As String
    Dim SaveModel As String
    Dim SaveValue As Integer
    Dim I As Integer
    Dim J As Integer

    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)

    Array.Clear(WrkClass, 0, 100000)
    Array.Clear(WrkYear, 0, 100000)
    Array.Clear(WrkMake, 0, 100000)
    Array.Clear(WrkModel, 0, 100000)
    Array.Clear(WrkValue, 0, 100000)

    SaveClass = 0
    SaveYear = 0
    SaveMake = String.Empty
    SaveModel = String.Empty
    SaveValue = 0

    WrkQry = "CAT='1'" & WrkAnd & "value>0"
    If WrkSelClass > 0 Then
      WrkQry = WrkQry & WrkAnd & "class=" & WrkSelClass
    End If
    WrkSort = "CLASS, YEAR, MAKE, MODEL, VALUE"
    If MyFrmTA420B.RbMV.Checked Then
      dsMV = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
    Else
      dsMV = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    End If
    For I = 0 To dsMV.Tables(0).Rows.Count - 1
      With dsMV.Tables(0).Rows(I)
        If SaveClass = .Item("class") And
       SaveYear = .Item("year") And
       SaveMake = Trim(.Item("make")) And
       SaveModel = Trim(.Item("model")) Then
          If SaveValue > 0 And SaveValue <> .Item("value") Then
            WrkValue(J - 1) = -1
          End If
        End If
        If SaveClass <> .Item("class") Or
       SaveYear <> .Item("year") Or
       SaveMake <> Trim(.Item("make")) Or
       SaveModel <> Trim(.Item("model")) Then
          If .Item("value") > 0 Then
            WrkClass(J) = .Item("class")
            WrkYear(J) = .Item("year")
            WrkMake(J) = Trim(.Item("make"))
            WrkModel(J) = Trim(.Item("model"))
            WrkValue(J) = .Item("value")
            J = J + 1
          End If

        End If
        SaveClass = .Item("class")
        SaveYear = .Item("year")
        SaveMake = Trim(.Item("make"))
        SaveModel = Trim(.Item("model"))
        SaveValue = .Item("value")
      End With
    Next

    myTXMVDCQ.CloseFile()
    myTXSUPPQ.CloseFile()
  End Sub
  Friend Function LookupPrevMVD(ByVal pClass As Integer, ByVal PYear As Integer,
  ByVal pMake As String, ByVal pModel As String) As Integer
    Dim I As Integer

    For I = 0 To WrkClass.GetUpperBound(0)
      If WrkClass(I) = 0 And Trim(WrkMake(I)) = String.Empty Then
        Return -1
      End If
      If pClass = WrkClass(I) And PYear = WrkYear(I) And
        Trim(pMake) = Trim(WrkMake(I)) And Trim(pModel) = Trim(WrkModel(I)) Then
        Return I
      End If
    Next

  End Function
  Private Sub UpdateTXMVD(ByVal WrkListNo As Integer, ByVal WrkValue As Integer)

    With myTXMVD
      .GetOneRecordP(WrkListNo)
      If .RecordNotFound Then Exit Sub
      ._VALUE = WrkValue
      .UpdateOneRecordP()
    End With
  End Sub
End Module






