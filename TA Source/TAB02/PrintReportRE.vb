Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREALCQ As TXREALCQ.MyData
Dim DsTXREAL As DataSet = New DataSet

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkCategory As String
Dim WrkSubdivision As String
Dim WrkIncomeLevel As String
Dim WrkFrozenFile As Boolean
Dim WrkPrintDist As Boolean
Dim WrkExempt1 As String
Dim WrkExempt2 As String
Dim WrkExempt3 As String
Dim WrkExempt4 As String
Dim WrkExempt5 As String
Dim WrkCategory1 As String
Dim WrkCategory2 As String
Dim WrkCategory3 As String
Dim WrkCategory4 As String

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
  Public Sub PrtReportRE()

  myTXREALQ = New TXREALQ.mydata(MyDBConnect)
  myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTAB02B
    WrkType = "R"
    WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkCategory = .TxtCategory.Text
    WrkSubdivision = .TxtSubdivision.Text
    WrkIncomeLevel = .TxtIncomeLevel.Text
    WrkExempt1 = .TxtExempt1.Text
    WrkExempt2 = .TxtExempt2.Text
    WrkExempt3 = .TxtExempt3.Text
    WrkExempt4 = .TxtExempt4.Text
    WrkExempt5 = .TxtExempt5.Text
    WrkCategory1 = .TxtCategory1.Text
    WrkCategory2 = .TxtCategory2.Text
    WrkCategory3 = .TxtCategory3.Text
    WrkCategory4 = .TxtCategory4.Text
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
  End With

  GetDetail()

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim Good As Boolean
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "CAT = '1'"
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If
If Not WrkFrozenFile Then
  DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Real Estate data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

GetMillRate(WrkYear, "R", WrkDist)

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
    WrkExcd(0) = .Item("excd1")
    WrkExcd(1) = .Item("excd2")
    WrkExcd(2) = .Item("excd3")
    WrkExcd(3) = .Item("excd4")
    WrkExcd(4) = .Item("excd5")
    WrkExcd(5) = .Item("excd6")
    WrkExcd(6) = .Item("excd7")
    WrkExam(0) = .Item("exam1")
    WrkExam(1) = .Item("exam2")
    WrkExam(2) = .Item("exam3")
    WrkExam(3) = .Item("exam4")
    WrkExam(4) = .Item("exam5")
    WrkExam(5) = .Item("exam6")
    WrkExam(6) = .Item("exam7")
    If .Item("ccno") > 0 Then
      WrkExcd(0) = .Item("cccd1")
      WrkExcd(1) = .Item("cccd2")
      WrkExcd(2) = .Item("cccd3")
      WrkExcd(3) = .Item("cccd4")
      WrkExcd(4) = .Item("cccd5")
      WrkExcd(5) = .Item("cccd6")
      WrkExcd(6) = .Item("cccd7")
      WrkExam(0) = .Item("cexa1")
      WrkExam(1) = .Item("cexa2")
      WrkExam(2) = .Item("cexa3")
      WrkExam(3) = .Item("cexa4")
      WrkExam(4) = .Item("cexa5")
      WrkExam(5) = .Item("cexa6")
      WrkExam(6) = .Item("cexa7")
    End If

    For J = 0 To 6
      If WrkExcd(J) = String.Empty Then Continue For
      If WrkCategory <> String.Empty Then
        If WrkCategory <> Mid(WrkExcd(J), 1, 1) Then
          Continue For
        End If
      End If
      If WrkSubdivision <> String.Empty Then
        If WrkSubdivision <> Mid(WrkExcd(J), 2, 1) Then
          Continue For
        End If
      End If
      If WrkIncomeLevel <> String.Empty Then
        If WrkIncomeLevel <> Mid(WrkExcd(J), 3, 1) Then
          Continue For
        End If
      End If

      Good = False
      If WrkCategory1 <> String.Empty Then
        If WrkCategory1 = Mid(WrkExcd(J), 1, 1) Or WrkCategory2 = Mid(WrkExcd(J), 1, 1) Or _
         WrkCategory3 = Mid(WrkExcd(J), 1, 1) Or WrkCategory4 = Mid(WrkExcd(J), 1, 1) Then
          Good = True
        End If
      Else
        If WrkExempt1 <> String.Empty Then
          If WrkExempt1 = WrkExcd(J) Then Good = True
        Else
          Good = True
        End If
        If WrkExempt2 <> String.Empty Then
          If WrkExempt2 = WrkExcd(J) Then Good = True
        End If
        If WrkExempt3 <> String.Empty Then
          If WrkExempt3 = WrkExcd(J) Then Good = True
        End If
        If WrkExempt4 <> String.Empty Then
          If WrkExempt4 = WrkExcd(J) Then Good = True
        End If
        If WrkExempt5 <> String.Empty Then
          If WrkExempt5 = WrkExcd(J) Then Good = True
        End If
      End If
      If Not Good Then Continue For
      K = LookupExem(WrkExcd(J))
      If K = -1 Then Continue For
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("type") = WrkType
      AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("excd") = WrkExcd(J)
      If WrkExam(J) = 0 And .Item("ccno") = 0 Then
        dr.Item("exam") = WrkExFixedAmt(K)
      Else
        dr.Item("exam") = WrkExam(J)
      End If
      dr.Item("exdesc") = WrkExDesc(K)
      dr.Item("revloss") = MyUtils.Round(WrkExam(J) * MrateMillrt, 2)
      ds.Tables(0).Rows.Add(dr)
    Next
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
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
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
'Private Sub FindExemptions(ByRef WrkCode As String, ByRef WrkCodeExam As Integer)
'  Dim I As Integer

'  WrkCode = ""
'  WrkCodeExam = 0

'  For I = 0 To WrkExcd.GetUpperBound(0)
'    If Mid(WrkExcd(I), 1, 1) = "E" Then
'      WrkCode = WrkExcd(I)
'      WrkCodeExam = WrkExam(I)
'      Exit For
'    End If
'  Next

'End Sub
End Module






