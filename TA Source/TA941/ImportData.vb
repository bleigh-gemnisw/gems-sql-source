Imports System.Text
Imports System.IO
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkMV As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVD As TXMVD.MyData
  Dim myTXSUPP As TXSupp.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData

  Dim ds As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkSortBy As String
  Dim WrkRoundDown As Boolean
  Dim WrkSelMSRP As Boolean
  Dim WrkAssPct As Decimal
  Dim WrkSkipPriced As Boolean
  Dim WrkMinValue As Integer
  Dim WrkPost As Boolean
  Public Sub Impdata()
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXSUPP = New TXSupp.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)

    With MyFrmTA941C
      If .RbSortName.Checked Then WrkSortBy = "NAME"
      If .RbSortList.Checked Then WrkSortBy = "LIST#"
      WrkMV = .RbMV.Checked
      WrkRoundDown = .RbDown.Checked
      WrkPost = .ChkPost.Checked
      If .RbValuesMSRP.Checked Then
        WrkSelMSRP = True
      Else
        WrkSelMSRP = False
      End If
      If .RbValuesMSRP.Checked Or .RbValues100.Checked Then
        WrkAssPct = 0.7
      Else
        WrkAssPct = 1
      End If
      If .ChkSkip.Checked Then
        WrkSkipPriced = True
      Else
        WrkSkipPriced = False
      End If
      WrkMinValue = MyUtils.CnvSng(.TxtMinVal.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      BuildDsErr(dsErr)
    Else
      ds.Clear()
      dsErr.Clear()
    End If
    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsErr = dsErr
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTA941B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim J As Integer
    Dim cQuote As String = Chr(34)
    Dim StrBuffer As String
    Dim Sarray() As String
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkName As String
    Dim WrkVin As String
    Dim WrkMSRP As Integer
    Dim WrkValue As Integer
    Dim WrkNValue As Integer
    Dim WrkError As Boolean

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    StrBuffer = sr.ReadLine

NextLine:
    StrBuffer = sr.ReadLine
    If Trim(StrBuffer) = String.Empty Then
      GoTo Done
    End If
    StrBuffer = Replace(StrBuffer, cQuote, "")
    WrkError = False
    Sarray = Split(StrBuffer, ",")
    WrkListNo = MyUtils.CnvSng(Sarray(MyColListNo))
    WrkName = Sarray(MyColName)

    WrkValue = 0
    WrkYear = 0
    WrkVin = ""
    If WrkSelMSRP Then
      WrkMSRP = MyUtils.CnvSng(Sarray(MyColValue)) / 0.7
    Else
      WrkMSRP = 0
    End If
    If WrkMV Then
      myTXMVD.GetOneRecordP(WrkListNo)
      If Not myTXMVD.RecordNotFound Then
        WrkValue = myTXMVD._VALUE
        WrkYear = myTXMVD._YEAR
        WrkVin = Trim(myTXMVD._VINNO)
      Else
        WrkError = True
      End If
    Else
      myTXSUPP.GetOneRecordP(WrkListNo)
      If Not myTXSUPP.RecordNotFound Then
        WrkValue = myTXSUPP._VALUE
        WrkYear = myTXSUPP._YEAR
        WrkVin = Trim(myTXSUPP._VINNO)
      Else
        WrkError = True
      End If
    End If

    If WrkSelMSRP Then
      WrkNValue = CalcValue(WrkMSRP, WrkYear)
      J = WrkNValue Mod 10
      If J <> 0 Then
        If WrkRoundDown Then
          WrkNValue = WrkNValue - J
        Else
          If J < 5 Then
            WrkNValue = WrkNValue - J
          Else
            WrkNValue = WrkNValue + (10 - J)
          End If
        End If
      End If
    Else
      WrkNValue = MyUtils.Round(MyUtils.CnvSng(Sarray(MyColValue)) * WrkAssPct, 0)
      If WrkNValue = 0 Then GoTo NextRec
    J = WrkNValue Mod 10
      If J <> 0 Then
        If WrkRoundDown Then
          WrkNValue = WrkNValue - J
        Else
          If J < 5 Then
            WrkNValue = WrkNValue - J
          Else
            WrkNValue = WrkNValue + (10 - J)
          End If
        End If
      End If
    End If

    If WrkMinValue > WrkNValue And WrkNValue > 0 Then
      WrkNValue = WrkMinValue
    End If

    If WrkSkipPriced And WrkValue > 0 Then
      GoTo NextRec
    End If

    If WrkError Then
      dr = dsErr.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(WrkListNo, "000000")
        Case "NAME"
          dr("sortdata") = WrkName
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("name") = WrkName
      dr.Item("errmsg") = "** Invalid List # **"
      dsErr.Tables(0).Rows.Add(dr)
    Else
      dr = ds.Tables(0).NewRow
      Select Case WrkSortBy
        Case "LIST#"
          dr("sortdata") = Format(WrkListNo, "000000")
        Case "NAME"
          dr("sortdata") = WrkName
      End Select
      dr.Item("listno") = WrkListNo
      dr.Item("name") = WrkName
      dr.Item("msrp") = WrkMSRP
      dr.Item("value") = WrkValue
      dr.Item("nvalue") = WrkNValue
      ds.Tables(0).Rows.Add(dr)
    End If
    If WrkPost And Not WrkError Then
      If WrkMV Then
        With myTXMVD
          ._VALUE = WrkNValue
          .UpdateOneRecordP()
        End With
      Else
        With myTXSUPP
          ._VALUE = WrkNValue
          .UpdateOneRecordP()
        End With
      End If
      With myTXMSRP
        .GetOneRecordP(WrkVin)
        ._OVMSRP = WrkMSRP
        ._OVSOURCE = "V"
        If .RecordNotFound Then
          ._VINNO = Trim(WrkVin)
          ._COMPLETE = ""
          ._NONTAX = ""
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
    End If

    I = I + StrBuffer.Length

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    myFrmProgress.Close()
  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("value", Type.GetType("System.Int32"))
      .Columns.Add("nvalue", Type.GetType("System.Int32"))
    End With
    Ds.Tables.Add(myTable)

  End Sub
  Public Sub BuildDsErr(ByRef DsErr As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytableerr"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("errmsg", Type.GetType("System.String"))
    End With
    DsErr.Tables.Add(myTable)

  End Sub
  Public Sub EditChecks(ByVal WrkNassTot As Integer, ByVal WrkNExTot As Integer)

    'dr = dsErr.Tables(0).NewRow
    'With myTXPPRPQ
    ' Select Case WrkSortBy
    ' Case "LIST#"
    '  dr("sortdata") = Format(._LISTNO, "000000")
    ' Case "NAME"
    '  dr("sortdata") = Trim(._NAME)
    ' End Select
    ' dr.Item("listno") = ._LISTNO
    ' dr.Item("name") = Trim(._NAME)
    ' dr.Item("errmsg") = ""
    'End With
    'dsErr.Tables(0).Rows.Add(dr)
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
      WrkValue = WrkMSRP * WrkDepr * WrkAssPct
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
End Module






