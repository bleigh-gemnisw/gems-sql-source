Imports System.Text
Module PrintReportM59A

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXM59AQ As TXM59AQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXREAA As TXREAA.MyData
  Dim DsFile As DataSet = New DataSet

  Dim WrkListNo As Integer
  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFile As String
  Dim WrkPrintDist As Boolean

  Dim WrkExcd(6) As String
  Dim WrkExam(6) As Integer
  Public Sub PrtReportM59A()

    myTXM59AQ = New TXM59AQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXREAA = New TXREAA.MyData(myDBConnect)

    With MyFrmTO110B
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFile = .CboFile.SelectedItem.ToString
    End With

    GetDetail()

  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim WrkTypeDesc As String
    Dim AddrLine() As String
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkAddress As String
    Dim WrkCity As String
    Dim WrkState As String
    Dim WrkZip As String
    Dim WrkYear1 As Integer
    Dim WrkYear2 As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkCodeB As Boolean
    Dim Good As Boolean

    WrkAnd = " and "
    WrkOr = " or "

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing M59A data..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkSort = ""
    WrkQry = "txyear=" & WrkYear
    WrkYear1 = WrkYear - 1
    WrkYear2 = WrkYear - 2
    '    If Not WrkPrev Then
    '    WrkQry = "year = " & WrkYear & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE<>'S'"
    '   WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE='S'"
    '    Else
    WrkQry = "year = " & WrkYear & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE<>'S'"
    WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'"
    WrkQry = WrkQry & WrkOr & "year = " & WrkYear2 & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE='S'"
    '    End If
    DsFile = myTXM59AQ.GetQry(WrkSort, WrkQry, 0)
    If DsFile.Tables(0).Rows.Count = 0 Then
      myFrmProgress.Close()
      Exit Sub
    End If

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        Good = False
        WrkListNo = .Item("list#")
        WrkType = .Item("type")
        WrkTypeDesc = GetTXTypeDesc(WrkType)
        GetMillRate(WrkYear, WrkDist)
        sb = New StringBuilder
        sb.Append(Trim(.Item("ALNAME")))
        sb.Append(" ")
        sb.Append(Trim(.Item("AFNAME")))
        WrkName = sb.ToString
        sb = New StringBuilder
        sb.Append(Trim(.Item("SLNAME")))
        sb.Append(" ")
        sb.Append(Trim(.Item("SFNAME")))
        WrkName2 = sb.ToString
        If Trim(.Item("LOC")) = "" Then
          WrkAddress = Trim(.Item("MADDR"))
          WrkCity = Trim(.Item("MCITY"))
          WrkState = .Item("MSTATE")
          WrkZip = Format(.Item("MZIP"), "00000")
        Else
          WrkAddress = Trim(.Item("LOC#")) & " " & Trim(.Item("LOC"))
          WrkCity = Trim(.Item("CITY"))
          WrkState = Trim(.Item("STATE"))
          WrkZip = Format(.Item("ZIP"), "00000")
        End If
        AddrLine = MyUtils.SetAddrLine(WrkName & "*", WrkName2, WrkAddress, "", WrkCity, WrkState, WrkZip, 0)
      End With


      Select Case WrkFile
        Case "Regular"
          If WrkType = "R" Then
            With myTXREAL
              .GetOneRecordP(WrkListNo)
              If Not .RecordNotFound Then
                WrkExcd(0) = ._EXCD1
                WrkExcd(1) = ._EXCD2
                WrkExcd(2) = ._EXCD3
                WrkExcd(3) = ._EXCD4
                WrkExcd(4) = ._EXCD5
                WrkExcd(5) = ._EXCD6
                WrkExcd(6) = ._EXCD7
                WrkExam(0) = ._EXAM1
                WrkExam(1) = ._EXAM2
                WrkExam(2) = ._EXAM3
                WrkExam(3) = ._EXAM4
                WrkExam(4) = ._EXAM5
                WrkExam(5) = ._EXAM6
                WrkExam(6) = ._EXAM7
                If ._CCNO > 0 Then
                  WrkExcd(0) = ._CCCD1
                  WrkExcd(1) = ._CCCD2
                  WrkExcd(2) = ._CCCD3
                  WrkExcd(3) = ._CCCD4
                  WrkExcd(4) = ._CCCD5
                  WrkExcd(5) = ._CCCD6
                  WrkExcd(6) = ._CCCD7
                  WrkExam(0) = ._CEXA1
                  WrkExam(1) = ._CEXA2
                  WrkExam(2) = ._CEXA3
                  WrkExam(3) = ._CEXA4
                  WrkExam(4) = ._CEXA5
                  WrkExam(5) = ._CEXA6
                  WrkExam(6) = ._CEXA7
                End If
              End If
            End With
          End If
        Case "Frozen"
          If WrkType = "R" Then
            With myTXREALC
              .GetOneRecordP(WrkListNo)
              If Not .RecordNotFound Then
                WrkExcd(0) = ._EXCD1
                WrkExcd(1) = ._EXCD2
                WrkExcd(2) = ._EXCD3
                WrkExcd(3) = ._EXCD4
                WrkExcd(4) = ._EXCD5
                WrkExcd(5) = ._EXCD6
                WrkExcd(6) = ._EXCD7
                WrkExam(0) = ._EXAM1
                WrkExam(1) = ._EXAM2
                WrkExam(2) = ._EXAM3
                WrkExam(3) = ._EXAM4
                WrkExam(4) = ._EXAM5
                WrkExam(5) = ._EXAM6
                WrkExam(6) = ._EXAM7
                If ._CCNO > 0 Then
                  WrkExcd(0) = ._CCCD1
                  WrkExcd(1) = ._CCCD2
                  WrkExcd(2) = ._CCCD3
                  WrkExcd(3) = ._CCCD4
                  WrkExcd(4) = ._CCCD5
                  WrkExcd(5) = ._CCCD6
                  WrkExcd(6) = ._CCCD7
                  WrkExam(0) = ._CEXA1
                  WrkExam(1) = ._CEXA2
                  WrkExam(2) = ._CEXA3
                  WrkExam(3) = ._CEXA4
                  WrkExam(4) = ._CEXA5
                  WrkExam(5) = ._CEXA6
                  WrkExam(6) = ._CEXA7
                End If
              End If
            End With
          End If
        Case "Archive"
      End Select

      For J = 0 To WrkExcd.GetUpperBound(0)
          If Mid(WrkExcd(J), 1, 1) = "B" And WrkExam(J) > 0 _
       Or Mid(WrkExcd(J), 1, 1) = "C" And WrkExam(J) > 0 Then
            K = LookupExem(WrkExcd(J))
            If WrkExLetter(K) <> "B" And WrkExLetter(K) <> "C" Then Continue For
            Good = True
            WrkCodeB = False
            If WrkExLetter(K) = "B" Then
              WrkCodeB = True
            End If
            If WrkCodeB Then
              dr = dsCatB.Tables(0).NewRow
            Else
              dr = dsCatC.Tables(0).NewRow
            End If
          dr.Item("listno") = WrkListNo
          dr.Item("type") = WrkType
            dr.Item("typedesc") = WrkTypeDesc
          dr.Item("addr1") = AddrLine(0)
          dr.Item("addr2") = AddrLine(1)
            dr.Item("addr3") = AddrLine(2)
            dr.Item("addr4") = AddrLine(3)
            dr.Item("addr5") = AddrLine(4)
            dr.Item("excd") = WrkExcd(J)
            dr.Item("exam") = WrkExam(J)
            dr.Item("revloss") = MyUtils.Round(WrkExam(J) * CurMillrt, 2)
            If WrkCodeB Then
              dsCatB.Tables(0).Rows.Add(dr)
              MyCurAccts = MyCurAccts + 1
              MyCurAmt = MyCurAmt + WrkExam(J)
              MyCurRevLoss = MyCurRevLoss + dr.Item("revloss")
            Else
              dsCatC.Tables(0).Rows.Add(dr)
            End If
          'Missing
          If WrkCodeB And Not CheckTXM59A(WrkListNo, WrkType, WrkYear) Then
            dr = dsErr.Tables(0).NewRow
            dr.Item("listno") = WrkListNo
            dr.Item("type") = WrkType
            dr.Item("typedesc") = WrkTypeDesc
            dr.Item("addr1") = AddrLine(0)
            dr.Item("excd") = WrkExcd(J)
            dr.Item("exam") = WrkExam(J)
            dsErr.Tables(0).Rows.Add(dr)
          End If
        End If
        Next

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

    myFrmProgress.Close()
    Application.DoEvents()
    myTXM59AQ.CloseFile()
  End Sub

End Module
