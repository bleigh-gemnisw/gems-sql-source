Imports System.Text
Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXM35HQ As TXM35HQ.MyData
  Dim myTXLOCAL As TXLOCAL.MyData
  Dim DsFile As DataSet = New DataSet
  Dim DsTXLOCAL As DataSet = New DataSet

  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkMaxLen As Integer
  Dim WrkMod As Integer
  Dim WrkType As String
  Dim WrkSelExemptcd As String
  Dim WrkSelExcd As String
  Dim WrkShowList As Boolean
  Dim WrkShowMap As Boolean
  Dim WrkSortby As String
  Dim WrkFromList As Integer
  Dim WrkToList As Integer
  Dim WrkVetYear As Integer
  Dim WrkAppYear As Integer
  Dim WrkLocal As String
  Dim WrkHAdjust1 As Integer
  Dim WrkHAdjust2 As Integer
  Dim WrkHAdjust3 As Integer
  Dim WrkCode(9) As Integer
  Dim WrkExcd(6) As String
  Dim WrkFrozenFile As Boolean

  Public Sub PrtReport()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXM35HQ = New TXM35HQ.MyData(myDBConnect)
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)

    With MyFrmTAB03B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkShowList = .ChkShowList.Checked
      WrkShowMap = .ChkMap.Checked
      If .RbSortName.Checked Then WrkSortby = "Name"
      If .RbSortZip.Checked Then WrkSortby = "Zip"
      WrkFromList = MyUtils.CnvSng(.TxtFromList.Text)
      WrkToList = MyUtils.CnvSng(.TxtToList.Text)
      WrkSelExemptcd = .TxtExemptCd.Text
      WrkSelExcd = .TxtExcd.Text
      WrkVetYear = MyUtils.CnvSng(.TxtVetYear.Text)
      WrkAppYear = MyUtils.CnvSng(.TxtAppYear.Text)
      WrkLocal = .TxtLocal.Text
      With MyFrmTAB03B
        Select Case .TabCtl1.SelectedTab.Name
          Case "TpRE"
            If .RbRE.Checked Then WrkType = "R"
            If .RbElderly.Checked Then WrkType = "E"
            If .RbLocal.Checked Then WrkType = "L"
          Case "TpPP"
            WrkType = "P"
          Case "TpMV"
            WrkType = "M"
          Case "TpSU"
            WrkType = "S"
          Case "TpM35H"
            WrkAppYear = MyUtils.CnvSng(.TxtM35HAppYear.Text)
            WrkType = "M35H"
        End Select
      End With

      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
      If .Rb1Across.Checked Then WrkMod = 1
      If .Rb2Across.Checked Then WrkMod = 2
      If .Rb3Across.Checked Then WrkMod = 3
      WrkMaxLen = MyUtils.CnvSng(.TxtMaxLen.Text)
      WrkHAdjust1 = MyUtils.CnvSng(.TxtHAdjust1.Text)
      WrkHAdjust2 = MyUtils.CnvSng(.TxtHAdjust2.Text)
      WrkHAdjust3 = MyUtils.CnvSng(.TxtHAdjust3.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    If WrkType <> "M35H" Then
      GetDetail()
    Else
      GetM35H()
    End If

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Show()
    End With
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkCat As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim sb0 As StringBuilder
    Dim sb1 As StringBuilder
    Dim sb2 As StringBuilder
    Dim sb3 As StringBuilder
    Dim sb4 As StringBuilder
    Dim sb5 As StringBuilder
    Dim WrkNew As Boolean
    Dim Good As Boolean
    Dim Pos As Integer
    Dim WrkLine As String
    Dim WrkBusty As String

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkQry = String.Empty
    WrkSort = String.Empty
    Select Case WrkSortby
      Case "Name"
        WrkSort = "NAME"
      Case "Zip"
        WrkSort = "ZIP5, ZIP4"
    End Select

    WrkCat = "1"
    If WrkType = "P" Then
      WrkCat = "5"
    End If
    If MyFrmTAB03B.RbCatExempt.Checked Then
      WrkCat = "3"
    End If

    Select Case WrkType
      Case "E"
        WrkQry = "CAT = " & MyUtils.Quo(WrkCat) & WrkAnd & "FCCOD<> ''"
        If WrkAppYear > 0 Then
          WrkQry = WrkQry & WrkAnd & "FCYR=" & WrkAppYear
        End If
        If WrkVetYear > 0 Then
          WrkQry = WrkQry & WrkAnd & "VTYR=" & WrkVetYear
        End If
      Case "L"
        ' WrkQry = "CAT = " & MyUtils.Quo(WrkCat) & WrkAnd & "TWNBN<>0"
        If WrkAppYear > 0 Then
          WrkQry = "FCYR=" & WrkAppYear
        End If
        If WrkVetYear > 0 Then
          WrkQry = "VTYR=" & WrkVetYear
        End If
      Case "P"
        WrkQry = "CAT = " & MyUtils.Quo(WrkCat)
      Case "R"
        WrkQry = "CAT = " & MyUtils.Quo(WrkCat)
        If WrkVetYear > 0 Then
          WrkQry = WrkQry & WrkAnd & "VTYR=" & WrkVetYear
        End If
      Case "M", "S"
        WrkQry = "CAT = " & MyUtils.Quo(WrkCat)
    End Select

    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    If WrkFromList > 0 Then
      WrkQry = WrkQry & WrkAnd & "list#>=" & WrkFromList & WrkAnd & "list#<=" & WrkToList
    End If

    Select Case WrkType
      Case "M"
        If Not WrkFrozenFile Then
          DsFile = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
        Else
          DsFile = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
        End If
      Case "P"
        If Not WrkFrozenFile Then
          DsFile = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
        Else
          DsFile = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
        End If
      Case "E", "L", "R"
        If Not WrkFrozenFile Then
          DsFile = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
        Else
          DsFile = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
        End If
      Case "S"
        DsFile = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
    End Select
    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub
    WrkNew = True

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = ""
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        If MySelCodes <> String.Empty Then
          Good = False
          If WrkType = "P" Then
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
            For J = 0 To 9
              If WrkCode(J) = 0 Then Continue For
              Pos = InStr(MySelCodes, Format(WrkCode(J), " ###"))
              If Pos > 0 Then Good = True
            Next J
          End If
          If WrkType = "R" Then
            WrkCode(0) = .Item("code1")
            WrkCode(1) = .Item("code2")
            WrkCode(2) = .Item("code3")
            WrkCode(3) = .Item("code4")
            WrkCode(4) = .Item("code5")
            WrkCode(5) = .Item("code6")
            WrkCode(6) = .Item("code7")
            For J = 0 To 6
              If WrkCode(J) = 0 Then Continue For
              Pos = InStr(MySelCodes, Format(WrkCode(J), " ###"))
              If Pos > 0 Then Good = True
            Next J
          End If
          If WrkType = "M" Or WrkType = "S" Then
            WrkCode(0) = .Item("class")
            Pos = InStr(MySelCodes, Format(WrkCode(0), "00"))
            If Pos > 0 Then Good = True
            If Pos = 0 Then
              GoTo NextRec
            End If
          End If
          If Not Good Then GoTo NextRec
        End If

        If MySelBusty <> String.Empty Then
          If WrkType = "P" Then
            WrkBusty = MyUtils.JustifyLeft(.Item("busty"), 4)
            Pos = InStr(MySelBusty, WrkBusty)
            If Pos = 0 Then
              GoTo NextRec
            End If
          End If
        End If

        If WrkSelExcd <> String.Empty Then
          Good = False
          If WrkType = "R" Then
            WrkExcd(0) = .Item("excd1")
            WrkExcd(1) = .Item("excd2")
            WrkExcd(2) = .Item("excd3")
            WrkExcd(3) = .Item("excd4")
            WrkExcd(4) = .Item("excd5")
            WrkExcd(5) = .Item("excd6")
            WrkExcd(6) = .Item("excd7")
            For J = 0 To 6
              If WrkExcd(J) = WrkSelExcd Then
                Good = True
                Exit For
              End If
            Next J
            If Not Good Then GoTo NextRec
          End If
          If WrkType <> "R" Then
            WrkExcd(0) = .Item("excd1")
            WrkExcd(1) = .Item("excd2")
            WrkExcd(2) = .Item("excd3")
            WrkExcd(3) = .Item("excd4")
            WrkExcd(4) = .Item("excd5")
            For J = 0 To 4
              If WrkExcd(J) = WrkSelExcd Then
                Good = True
                Exit For
              End If
            Next J
            If Not Good Then GoTo NextRec
          End If
        End If

        If WrkSelExemptcd <> String.Empty Then
          Good = False
          If WrkType = "R" Then
            If WrkSelExemptcd = .Item("exmpt") Then
              Good = True
            End If
          Else
            Good = True
          End If
          If Not Good Then GoTo NextRec
        End If

        If WrkType = "L" And WrkLocal <> String.Empty Then
          Good = False
          DsTXLOCAL = myTXLOCAL.GetViewbyList(.Item("list#"), "R", 999)
          For J = 0 To (DsTXLOCAL.Tables(0).Rows.Count - 1)
            If WrkLocal = DsTXLOCAL.Tables(0).Rows(J).Item("bencde") Then
              Good = True
              Exit For
            End If
          Next J
          If Not Good Then GoTo NextRec
        End If

        Counter = Counter + 1
        If WrkNew Then
          sb0 = New StringBuilder
          sb1 = New StringBuilder
          sb2 = New StringBuilder
          sb3 = New StringBuilder
          sb4 = New StringBuilder
          sb5 = New StringBuilder
          'Adjust space before 1st column
          If WrkHAdjust1 > 0 Then
            sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
          End If
        End If
        WrkNew = False
        WrkLine = ""
        If WrkShowList Then
          WrkLine = .Item("list#")
        End If
        Select Case WrkType
          Case "E", "L", "R"
            If WrkShowMap Then
              If WrkShowList Then
                WrkLine = WrkLine & "   "
              End If
              WrkLine = WrkLine & .Item("map")
            End If
          Case Else
        End Select
        sb0.Append(MyUtils.JustifyLeft(WrkLine, WrkMaxLen))
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        sb1.Append(MyUtils.JustifyLeft(AddrLine(0), WrkMaxLen))
        sb2.Append(MyUtils.JustifyLeft(AddrLine(1), WrkMaxLen))
        sb3.Append(MyUtils.JustifyLeft(AddrLine(2), WrkMaxLen))
        sb4.Append(MyUtils.JustifyLeft(AddrLine(3), WrkMaxLen))
        sb5.Append(MyUtils.JustifyLeft(AddrLine(4), WrkMaxLen))
        'Adjust space between 1st and 2nd columns
        If WrkMod > 1 And Counter Mod WrkMod = 1 And WrkHAdjust2 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
        End If
        'Adjust space between 2nd and 3rd columns
        If WrkMod > 2 And Counter Mod WrkMod = 2 And WrkHAdjust3 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
        End If
        If Counter Mod WrkMod = 0 Then
          dr = ds.Tables(0).NewRow
          If WrkShowList Or WrkShowMap Then
            dr.Item("line0") = sb0.ToString
          Else
            dr.Item("line0") = String.Empty
          End If
          dr.Item("line1") = sb1.ToString
          dr.Item("line2") = sb2.ToString
          dr.Item("line3") = sb3.ToString
          dr.Item("line4") = sb4.ToString
          dr.Item("line5") = sb5.ToString
          ds.Tables(0).Rows.Add(dr)
          sb0 = Nothing
          sb1 = Nothing
          sb2 = Nothing
          sb3 = Nothing
          sb4 = Nothing
          sb5 = Nothing
          WrkNew = True
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Write out any remaining data
    If Not WrkNew Then
      If sb1.ToString <> String.Empty Then
        dr = ds.Tables(0).NewRow
        If WrkShowList Then
          dr.Item("line0") = sb0.ToString
        Else
          dr.Item("line0") = String.Empty
        End If
        dr.Item("line1") = sb1.ToString
        dr.Item("line2") = sb2.ToString
        dr.Item("line3") = sb3.ToString
        dr.Item("line4") = sb4.ToString
        dr.Item("line5") = sb5.ToString
        ds.Tables(0).Rows.Add(dr)
      End If
    End If

    myFrmProgress.Close()
    Application.DoEvents()
    If Not WrkFrozenFile Then
      myTXPPRPQ.CloseFile()
      myTXREALQ.CloseFile()
      myTXMVDQ.CloseFile()
    Else
      myTXPPRPCQ.CloseFile()
      myTXREALCQ.CloseFile()
      myTXMVDCQ.CloseFile()
    End If
    myTXSUPPQ.CloseFile()
  End Sub
  Private Sub GetM35H()
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim sb0 As StringBuilder
    Dim sb1 As StringBuilder
    Dim sb2 As StringBuilder
    Dim sb3 As StringBuilder
    Dim sb4 As StringBuilder
    Dim sb5 As StringBuilder
    Dim WrkNew As Boolean
    Dim WrkLine As String

    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkQry = String.Empty
    WrkSort = String.Empty
    Select Case WrkSortby
      Case "Name"
        WrkSort = "ALNAME,AFNAME"
      Case "Zip"
        WrkSort = "PZIP"
    End Select

    WrkQry = "ALLOW='Y'" & WrkAnd & "year=" & MyUtils.Quo(WrkAppYear)
    If WrkFromList > 0 Then
      WrkQry = WrkQry & WrkAnd & "list#>=" & WrkFromList & WrkAnd & "list#<=" & WrkToList
    End If

    DsFile = myTXM35HQ.GetQry(WrkSort, WrkQry, 0)
    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub
    WrkNew = True

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = ""
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)

        Counter = Counter + 1
        If WrkNew Then
          sb0 = New StringBuilder
          sb1 = New StringBuilder
          sb2 = New StringBuilder
          sb3 = New StringBuilder
          sb4 = New StringBuilder
          sb5 = New StringBuilder
          'Adjust space before 1st column
          If WrkHAdjust1 > 0 Then
            sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
          End If
        End If
        WrkNew = False
        WrkLine = ""
          If WrkShowList Then
          WrkLine = .Item("list#")
        End If

        sb0.Append(MyUtils.JustifyLeft(WrkLine, WrkMaxLen))
        AddrLine = MyUtils.SetAddrLine(Trim(.Item("alname")) & " " & Trim(.Item("afname")),
          Trim(.Item("slname")) & " " & Trim(.Item("sfname")), .Item("maddr"), "", .Item("mcity"),
          .Item("mstate"), .Item("mzip"), 0)
        sb1.Append(MyUtils.JustifyLeft(AddrLine(0), WrkMaxLen))
        sb2.Append(MyUtils.JustifyLeft(AddrLine(1), WrkMaxLen))
        sb3.Append(MyUtils.JustifyLeft(AddrLine(2), WrkMaxLen))
        sb4.Append(MyUtils.JustifyLeft(AddrLine(3), WrkMaxLen))
        sb5.Append(MyUtils.JustifyLeft(AddrLine(4), WrkMaxLen))
        'Adjust space between 1st and 2nd columns
        If WrkMod > 1 And Counter Mod WrkMod = 1 And WrkHAdjust2 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
        End If
        'Adjust space between 2nd and 3rd columns
        If WrkMod > 2 And Counter Mod WrkMod = 2 And WrkHAdjust3 > 0 Then
          sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
        End If
        If Counter Mod WrkMod = 0 Then
          dr = ds.Tables(0).NewRow
          If WrkShowList Or WrkShowMap Then
            dr.Item("line0") = sb0.ToString
          Else
            dr.Item("line0") = String.Empty
          End If
          dr.Item("line1") = sb1.ToString
          dr.Item("line2") = sb2.ToString
          dr.Item("line3") = sb3.ToString
          dr.Item("line4") = sb4.ToString
          dr.Item("line5") = sb5.ToString
          ds.Tables(0).Rows.Add(dr)
          sb0 = Nothing
          sb1 = Nothing
          sb2 = Nothing
          sb3 = Nothing
          sb4 = Nothing
          sb5 = Nothing
          WrkNew = True
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Write out any remaining data
    If Not WrkNew Then
      If sb1.ToString <> String.Empty Then
        dr = ds.Tables(0).NewRow
        If WrkShowList Then
          dr.Item("line0") = sb0.ToString
        Else
          dr.Item("line0") = String.Empty
        End If
        dr.Item("line1") = sb1.ToString
        dr.Item("line2") = sb2.ToString
        dr.Item("line3") = sb3.ToString
        dr.Item("line4") = sb4.ToString
        dr.Item("line5") = sb5.ToString
        ds.Tables(0).Rows.Add(dr)
      End If
    End If

    myFrmProgress.Close()
    Application.DoEvents()
    myTXM35HQ.CloseFile()
  End Sub
End Module
