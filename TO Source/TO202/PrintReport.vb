Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXM35HQ As TXM35HQ.MyData
  Dim myTXMRATE As TXMRATE.MyData
  Dim myTPAYMNT As TPAYMNT.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkClaimNo As Integer
  Dim WrkPrev As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  'File Fields
  Dim WrkTotCredit As Decimal
  Dim WrkTotCount As Integer

  Dim WrkTax As Decimal
  Dim WrkFrzTax As Decimal
  Dim WrkCreditMax As Decimal
  Dim WrkLesser As Decimal
  Dim WrkCredit As Decimal

  Public Sub PrtReport()

    myTXM35HQ = New TXM35HQ.MyData(myDBConnect)
    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)

    With MyFrmTO202B
      WrkGLYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkClaimNo = MyUtils.CnvSng(.TxtClaimNo.Text)
      WrkPrev = .RbPrev.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .Wrkds = ds
      .Show()
    End With

  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("year", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("credit", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmTO202B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkYear1 As Integer
    Dim wrkdate As Date
    Dim WrkMillRate As Decimal
    Dim WrkTotal As Decimal
    Dim WrkHeadCredit As Integer
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkYear1 = WrkGLYear - 1
    WrkQry = "year = " & WrkGLYear & WrkAnd & "ALLOW='Y'"
    If WrkPrev Then
      WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'"
    End If
    WrkSort = "ALNAME, AFNAME"

    Counter = 0
    WrkTotCredit = 0
    WrkTotCount = 0

    myTXM35HQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTXMRATE.GetOneRecordP(WrkGLYear, "R", 0)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear, "", 0)
    End If
    WrkMillRate = 0
    If Not myTXMRATE.RecordNotFound Then
      WrkMillRate = myTXMRATE._MRRATE * 1000
    End If

ReadNext:
    myTXM35HQ.ReadQry()
    If Not myTXM35HQ.IsEOF Then
      With myTXM35HQ
        myTXREALC.GetOneRecordP(._LISTNO)
        If Not myTXREALC.RecordNotFound Then
          If Trim(myTXREALC._FCCOD) = String.Empty Then GoTo NextRec
          If Trim(myTXREALC._FCYR) <> ._YEAR Then GoTo NextRec
        Else
          GoTo NextRec
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNO
        dr.Item("year") = ._YEAR
        sb = New StringBuilder
        sb.Append(Trim(._ALNAME))
        sb.Append(" ")
        sb.Append(Trim(._AFNAME))
        dr.Item("name") = sb.ToString
        sb = Nothing
        GetCredit()
        dr.Item("credit") = WrkCredit
        ds.Tables(0).Rows.Add(dr)
        WrkTotCount = WrkTotCount + 1
        WrkTotCredit = WrkTotCredit + WrkCredit
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

    'Write all fields to text file (Header)
    sb = New StringBuilder
    sb.Append("H  ")
    sb.Append(Format(myTOWN._TOWNBR, "0##"))
    sb.Append("  ")
    sb.Append(Format(WrkClaimNo, "00"))
    sb.Append("  001")
    sb.Append("  ")
    sb.Append(WrkGLYear)
    sb.Append("  ")
    sb.Append(Format(WrkTotCount, "0###"))
    sb.Append("  ")
    WrkHeadCredit = WrkTotCredit * 100
    sb.Append(Format(WrkHeadCredit, "0#######"))
    sw.WriteLine(sb.ToString)
    sb = Nothing

    myTXM35HQ.CloseFile()
    myTXM35HQ.OpenQry(WrkSort, WrkQry)

ReadNext2:
    myTXM35HQ.ReadQry()
    If Not myTXM35HQ.IsEOF Then
      With myTXM35HQ
        myTXREALC.GetOneRecordP(._LISTNO)
        If Not myTXREALC.RecordNotFound Then
          If Trim(myTXREALC._FCCOD) = String.Empty Then GoTo NextRec2
          If Trim(myTXREALC._FCYR) <> ._YEAR Then GoTo NextRec2
        End If
        'Write all fields to text file (Detail)
        sb = New StringBuilder
        sb.Append("D")
        sb.Append(Format(myTOWN._TOWNBR, "000"))
        sb.Append("001")
        sb.Append(._YEAR)
        sb.Append(MyUtils.JustifyLeft(._ALNAME, 20))
        sb.Append(MyUtils.JustifyLeft(._AFNAME, 10))
        sb.Append(MyUtils.JustifyLeft(._AINIT, 1))
        wrkdate = MyUtils.GetDBDate(._ADOB)
        sb.Append(Format(wrkdate.Month, "00"))
        sb.Append("/")
        sb.Append(Format(wrkdate.Day, "00"))
        sb.Append("/")
        sb.Append(wrkdate.Year)
        sb.Append(Format(._ASSN, "000000000"))
        sb.Append(MyUtils.JustifyLeft(._SLNAME, 20))
        sb.Append(MyUtils.JustifyLeft(._SFNAME, 10))
        sb.Append(MyUtils.JustifyLeft(._SINIT, 1))
        If ._SDOB > 0 Then
          wrkdate = MyUtils.GetDBDate(._SDOB)
          sb.Append(Format(wrkdate.Month, "00"))
          sb.Append("/")
          sb.Append(Format(wrkdate.Day, "00"))
          sb.Append("/")
          sb.Append(wrkdate.Year)
        Else
          sb.Append("00/00/0000")
        End If
        sb.Append(Format(._SSSN, "000000000"))
        sb.Append(MyUtils.JustifyLeft(._MADDR, 40))
        sb.Append(MyUtils.JustifyLeft(._MCITY, 16))
        sb.Append(MyUtils.JustifyLeft(._MSTATE, 2))
        sb.Append(Format(._MZIP, "00000"))
        sb.Append("0000")
        sb.Append(MyUtils.JustifyLeft(._PADDR, 40))
        sb.Append(MyUtils.JustifyLeft(._PCITY, 16))
        sb.Append(MyUtils.JustifyLeft(._PSTATE, 2))
        If ._PZIP > 0 Then
          sb.Append(Format(._PZIP, "00000"))
          sb.Append("0000")
        Else
          sb.Append("     ")
          sb.Append("    ")
        End If
        sb.Append(MyUtils.JustifyLeft(._OWNER, 30))
        If ._FILING = "C" Or ._FILING = "M" Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        If ._FILING = "U" Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        If ._FILING = "S" Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        If ._NRSHOM = "Y" Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        If ._DISAB = "Y" Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        If ._TAXRTN = "Y" Then
          sb.Append("X ")
        Else
          sb.Append(" X")
        End If
        sb.Append(Format(._INCOME, "0000000.00"))
        sb.Append(Format(._INT, "0000000.00"))
        sb.Append(Format(._SSRR, "0000000.00"))
        sb.Append(Format(._OTHER, "0000000.00"))
        'WrkTotal = CalcTotal(._INCOME, ._INT, ._SSRR, ._OTHER)
        'sb.Append(Format(WrkTotal, "00000.00"))
        sb.Append(Format(._PROPCT, "000"))
        sb.Append(Format(._GROSS, "0000000.00"))
        sb.Append(Format(._NET, "0000000.00"))
        sb.Append(Format(WrkMillRate, "00.0000"))
        GetCredit()
        sb.Append(Format(WrkTax, "0000000.00"))
        sb.Append(Format(WrkCredit, "0000.00"))
        sb.Append(Format(WrkTotal, "0000000.00"))
        sb.Append(Format(._PCT, "000"))
        sb.Append(Format(._MAX, "0000.00"))
        sb.Append(Format(._MIN, "0000.00"))
        If ._DTASSR > 0 Then
          sb.Append("X")
        Else
          sb.Append(" ")
        End If
        sb.Append(Format(._XBLIND, "00000.00"))
        sb.Append(Format(._XDISAB, "00000.00"))
        sb.Append(Format(._XVET, "00000.00"))
        sb.Append(Format(._XLOCAL, "00000.00"))
        sb.Append(Format(._XADDL, "00000.00"))
        If ._ALLOW = "Y" Then
          sb.Append("X ")
        Else
          sb.Append(" X")
        End If
        sb.Append(Format(._FRZTAX, "0000000.00"))
        sw.WriteLine(sb.ToString)
        sb = Nothing
      End With

NextRec2:
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
      GoTo ReadNext2
    End If

    sw.Close()
    myFrmProgress.Close()
    myTXM35HQ.CloseFile()

  End Sub
  Private Function CalcTotal(ByVal Income As Decimal, ByVal Interest As Decimal, ByVal SSRR As Decimal,
  ByVal Other As Decimal)
    Dim WrkTotal As Decimal

    WrkTotal = Income + Interest + SSRR + Other
    Return WrkTotal

  End Function
  Private Sub GetCredit()
    Dim WrkAmount As Decimal

    With myTXM35HQ
      If ._FRZTAX > 0 Then
        WrkFrzTax = ._FRZTAX
        WrkTax = ._TAX
        WrkAmount = ._FRZTAX
      Else
        WrkFrzTax = 0
        WrkTax = ._TAX
        WrkAmount = ._TAX
      End If
      With myTPAYMNT
        .In_Year = WrkGLYear
        .In_Type = "R"
        .In_Dst = 0
        .In_Phs = ""
        .In_TaxT = WrkAmount
        .CalcPaySplit()
        WrkAmount = .Out_TaxT
      End With
      WrkCreditMax = MyUtils.Round(WrkAmount * (._PCT / 100), 2)
      If WrkCreditMax > ._MAX Then
        WrkLesser = ._MAX
      Else
        WrkLesser = WrkCreditMax
      End If
      If WrkLesser < ._MIN Then
        WrkCredit = ._MIN
      Else
        WrkCredit = WrkLesser
      End If
    End With

    With myTPAYMNT
      .In_Year = WrkGLYear
      .In_Type = "R"
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkCredit
      .CalcPaySplit()
      WrkCredit = .Out_TaxT
    End With

  End Sub
End Module






