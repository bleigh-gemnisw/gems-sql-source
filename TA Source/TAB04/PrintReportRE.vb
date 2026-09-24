Imports System.Text
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.myData
  Dim myTXREAL As TXReal.myData

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkExempt1 As String
  Dim WrkExempt2 As String
  Dim WrkExempt3 As String
  Dim WrkExempt4 As String
  Dim WrkExempt5 As String
  Dim WrkExempt6 As String
  Dim WrkExempt7 As String
  Public Sub PrtReportRE()

    myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
    myTXREAL = New TXReal.mydata(MyDBConnect)

    With MyFrmTAB04B
      WrkType = "R"
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkExempt1 = .TxtExempt1.Text
      WrkExempt2 = .TxtExempt2.Text
      WrkExempt3 = .TxtExempt3.Text
      WrkExempt4 = .TxtExempt4.Text
      WrkExempt5 = .TxtExempt5.Text
      WrkExempt6 = .TxtExempt6.Text
      WrkExempt7 = .TxtExempt7.Text
    End With

    GetDetail()

  End Sub
  Private Sub GetDetail()
    Dim WrkExcd(6) As String
    Dim WrkExam(6) As Integer
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Good As Boolean
    Dim Found As Boolean
    Dim Counter As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkSort = ""
    WrkQry = "CAT = '1'"
    If Not WrkDistAll Then
      WrkQry = "dist=" & WrkDist
    End If
    myTXREALCQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing Real Estate data..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXREALCQ.ReadQry()
    If Not myTXREALCQ.IsEOF Then
      With myTXREALCQ
        Counter = Counter + 1
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

        For J = 0 To 6
          If WrkExcd(J) = String.Empty Then Continue For
          Good = False
          If WrkExempt1 <> String.Empty And WrkExempt1 = WrkExcd(J) Then
            Found = CheckExcd(WrkExempt1)
            If Not Found Then Good = True
          End If
          If WrkExempt2 <> String.Empty And WrkExempt2 = WrkExcd(J) Then
            Found = CheckExcd(WrkExempt2)
            If Not Found Then Good = True
          End If
          If WrkExempt3 <> String.Empty And WrkExempt3 = WrkExcd(J) Then
            Found = CheckExcd(WrkExempt3)
            If Not Found Then Good = True
          End If
          If WrkExempt4 <> String.Empty And WrkExempt4 = WrkExcd(J) Then
            Found = CheckExcd(WrkExempt4)
            If Not Found Then Good = True
          End If
          If WrkExempt5 <> String.Empty And WrkExempt5 = WrkExcd(J) Then
            Found = CheckExcd(WrkExempt5)
            If Not Found Then Good = True
          End If
          If Not Good Then Continue For

          K = LookupExem(WrkExcd(J))
          If K = -1 Then Continue For
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNO
          dr.Item("name") = ._NAME
          dr.Item("type") = WrkType
          dr.Item("excd") = WrkExcd(J)
          If WrkExam(J) = 0 And ._CCNO = 0 Then
            dr.Item("exam") = WrkExFixedAmt(K)
          Else
            dr.Item("exam") = WrkExam(J)
          End If
          dr.Item("exdesc") = WrkExDesc(K)
          ds.Tables(0).Rows.Add(dr)
        Next
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
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    Application.DoEvents()
    myTXREALCQ.CloseFile()

  End Sub
  Private Function CheckExcd(WrkCode As String) As Boolean
    Dim WrkExcd(6) As String
    Dim WrkExam(6) As Integer
    Dim J As Integer
    Dim Found As Boolean

    Found = False
    myTXREAL.GetOneRecordP(myTXREALCQ._LISTNO)
    With myTXREAL
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
    End With

    For J = 0 To 6
      If WrkExcd(J) = String.Empty Then Continue For
      If WrkCode = WrkExcd(J) Then
        Found = True
        Exit For
      End If
    Next
    Return Found
  End Function
End Module






