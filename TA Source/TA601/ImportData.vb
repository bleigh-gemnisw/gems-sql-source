Imports System.Text
Imports System.IO
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim myTXREALC As TXREALC.MyData
  Dim myTXHOIN As TXHOIN.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkPost As Boolean
  Public Sub Impdata()
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXHOIN = New TXHOIN.MyData(myDBConnect)

    With MyFrmTA601B
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
      .Wrkds = ds
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTA601B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim cQuote As String = Chr(34)
    Dim StrBuffer As String
    Dim Sarray() As String
    Dim WrkListNo As Integer
    Dim SaveListNo As Integer
    Dim WrkTax As Decimal
    Dim WrkCredit As Decimal
    Dim SaveCredit As Decimal
    Dim WrkTwnBen As Decimal
    Dim SaveTwnBen As Decimal
    Dim WrkMarried As Boolean
    Dim WrkPct As Integer
    Dim SavePct As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveListNo = 0
    SaveCredit = 0
    SaveTwnBen = 0
    WrkFileSize = WrkStream.Length
    StrBuffer = sr.ReadLine 'Skip Header Line

NextLine:
    StrBuffer = sr.ReadLine
    If Trim(StrBuffer) = String.Empty Then
      GoTo Done
    End If
    StrBuffer = Replace(StrBuffer, cQuote, "")
    Sarray = Split(StrBuffer, ",")
    WrkListNo = MyUtils.CnvSng(Sarray(0))
    If WrkListNo = 0 Then
      GoTo NextLine
    End If
    myTXREALC.GetOneRecordP(WrkListNo)
    With myTXREALC
      dr = ds.Tables(0).NewRow
      WrkTax = MyUtils.CnvSng(Sarray(60))
      WrkCredit = MyUtils.CnvSng(Sarray(69))
      WrkTwnBen = MyUtils.CnvSng(Sarray(71))
      dr.Item("listno") = WrkListNo
      dr.Item("name") = Trim(._NAME)
      dr.Item("tax") = WrkTax
      If Trim(Sarray(74)) <> "" Then 'Approved
        dr.Item("credit") = Math.Round(WrkCredit, 0)
        dr.Item("local") = Math.Round(WrkTwnBen, 0)
        dr.Item("adjtax") = WrkTax - WrkCredit - WrkTwnBen
        'dr.Item("credit") = 0
        'dr.Item("local") = WrkTwnBen
        'dr.Item("adjtax") = WrkTax - WrkTwnBen
        If SaveListNo = WrkListNo Then
          dr.Item("split") = "Y"
        Else
          dr.Item("split") = ""
        End If
        ds.Tables(0).Rows.Add(dr)
      End If
      If WrkPost Then
        If Not myTXREALC.RecordNotFound Then
          WrkMarried = False
          If Trim(Sarray(26)) <> "" Then
            WrkMarried = True
          End If
          ._FCCOD = "C"
          ._FCYR = MyUtils.CnvSng(Sarray(4))
          ._CPERC = CalcTablePct(WrkListNo, WrkMarried, MyUtils.CnvSng(Sarray(37)))
          ._CMAX = MyUtils.CnvSng(Sarray(67))
          ._CMIN = MyUtils.CnvSng(Sarray(68))
          If SaveListNo = WrkListNo Then
            SaveCredit = SaveCredit + WrkCredit
            SaveTwnBen = SaveTwnBen + WrkTwnBen
            ._FTAX = SaveCredit
            ._TWNBN = SaveTwnBen
          Else
            ._FTAX = WrkCredit
            ._TWNBN = WrkTwnBen
          End If
          .UpdateOneRecordP()
        End If
      End If
      SaveListNo = ._LISTNO
      SaveCredit = WrkCredit
      SaveTwnBen = WrkTwnBen
    End With

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
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("tax", Type.GetType("System.Decimal"))
      .Columns.Add("credit", Type.GetType("System.Decimal"))
      .Columns.Add("local", Type.GetType("System.Int32"))
      .Columns.Add("adjtax", Type.GetType("System.Decimal"))
      .Columns.Add("split", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)

  End Sub
  Private Function CalcTablePct(ByVal WrkYear As Integer, ByVal WrkMarried As Boolean, ByVal WrkIncome As Integer) As Decimal
    Dim WrkPct As Decimal
    Dim I As Integer

    For I = 1 To 5
      With myTXHOIN
        .GetOneRecordP(WrkYear, I)
        If .RecordNotFound Then
          Return 0
        End If
        If ._LIMIT >= MyUtils.CnvSng(WrkIncome) Then
          If WrkMarried Then
            WrkPct = MyUtils.Round(._MPERC * 100, 0)
          Else
            WrkPct = MyUtils.Round(._UPERC * 100, 0)
          End If
        End If
      End With
    Next
    Return WrkPct
  End Function
End Module






