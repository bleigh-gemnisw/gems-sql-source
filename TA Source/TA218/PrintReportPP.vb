Module PrintReportPP
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.myData
  Dim myTXPPRPCQ As TXPPRPCQ.myData
  Dim DsTXPPRP As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkGrossCode As Boolean
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkCodeFrom As Integer
  Dim WrkCodeTo As Integer
  Dim WrkShowAddr As Boolean
  Dim WrkSortBy As String
  Dim WrkFrozenFile As Boolean

  Dim WrkGross(9) As Integer
  Dim WrkCode(9) As Integer
  Dim WrkUnit(9) As Integer

  Public Sub PrtReportPP()

    myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)

    With MyFrmTA218B
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortSName.Checked Then
        WrkSortBy = "SName"
      End If
      If .RbSortLoc.Checked Then
        WrkSortBy = "Location"
      End If
      WrkGrossCode = False
      If .RbGrossCode.Checked Then
        WrkGrossCode = True
      End If
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkShowAddr = .ChkAddress.Checked
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkType = "P"
      .WrkDist = WrkDist
      .WrkPrintDist = WrkPrintDist
      .Show()
    End With
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkTGross As Integer
    Dim WrkTUnits As Integer
    Dim Pos As Integer
    Dim Good As Boolean

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = ""
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "CAT, NAME"
      Case "SName"
        WrkSort = "CAT, SNAME, NAME"
      Case "Location"
        WrkSort = "CAT, LOC, LOC#"
    End Select

    WrkQry = ""
    If Not WrkDistAll Then
      If Not WrkPrintDist Then
        WrkQry = "dist=" & WrkDist
      Else
        WrkQry = "pdst=" & WrkDist
      End If
    End If

    If Not WrkFrozenFile Then
      DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXPPRP.Tables(0).Rows.Count = 0 Then
      If Not WrkFrozenFile Then
        myTXPPRPQ.CloseFile()
      Else
        myTXPPRPCQ.CloseFile()
      End If
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
      With DsTXPPRP.Tables(0).Rows(I)
        WrkGross(0) = .Item("ass1")
        WrkGross(1) = .Item("ass2")
        WrkGross(2) = .Item("ass3")
        WrkGross(3) = .Item("ass4")
        WrkGross(4) = .Item("ass5")
        WrkGross(5) = .Item("ass6")
        WrkGross(6) = .Item("ass7")
        WrkGross(7) = .Item("ass8")
        WrkGross(8) = .Item("ass9")
        WrkGross(9) = .Item("ass10")
        WrkCode(0) = .Item("code1")
        WrkCode(1) = .Item("code2")
        WrkCode(2) = .Item("code3")
        WrkCode(3) = .Item("code4")
        WrkCode(4) = .Item("code5")
        WrkCode(5) = .Item("code6")
        WrkCode(6) = .Item("code7")
        WrkCode(7) = .Item("code8")
        WrkCode(8) = .Item("code9")
        WrkCode(9) = .Item("codea")
        WrkUnit(0) = .Item("unit1")
        WrkUnit(1) = .Item("unit2")
        WrkUnit(2) = .Item("unit3")
        WrkUnit(3) = .Item("unit4")
        WrkUnit(4) = .Item("unit5")
        WrkUnit(5) = .Item("unit6")
        WrkUnit(6) = .Item("unit7")
        WrkUnit(7) = .Item("unit8")
        WrkUnit(8) = .Item("unit9")
        WrkUnit(9) = .Item("unita")

        Good = False
        WrkTGross = 0
        WrkTUnits = 0
        For J = 0 To 9
          If WrkCode(J) = 0 Then Continue For
          Pos = InStr(MySelCodes, Format(WrkCode(J), " ###"))
          If Pos > 0 Then
            Good = True
          Else
            If WrkGrossCode Then Continue For
          End If
          WrkTGross = WrkTGross + WrkGross(J)
          WrkTUnits = WrkTUnits + WrkUnit(J)
        Next J

        If Not Good And Not MySelCodes = String.Empty Then
          GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        If .Item("cat") = "3" Then
          dr.Item("exempt") = True
        Else
          dr.Item("exempt") = False
        End If
        dr.Item("listno") = .Item("list#")
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        If WrkShowAddr Then
          dr.Item("addr2") = AddrLine(1)
          dr.Item("addr3") = AddrLine(2)
          dr.Item("addr4") = AddrLine(3)
          dr.Item("addr5") = AddrLine(4)
        Else
          If WrkSortBy = "SName" Then
            dr.Item("addr2") = .Item("sname")
          End If
        End If
        dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
        dr.Item("units") = WrkTUnits
        dr.Item("gross") = WrkTGross
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    Application.DoEvents()
    myTXPPRPQ.CloseFile()
    myTXPPRPCQ.CloseFile()

  End Sub
End Module






