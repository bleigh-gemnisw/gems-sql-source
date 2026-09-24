Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
  Dim myTPAYMNT As TPAYMNT.MyData
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPrintDist As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkCC As Boolean
Dim WrkBTR As Boolean

'Mill Rate
Public MrateMillrt As Double

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer

'Elderly Totals
Dim WrkEldCount As Integer
Dim WrkEldGross As Integer
Dim WrkEldNet As Integer
Dim WrkEldTax As Decimal
Dim WrkEldStateCR As Decimal
Dim WrkEldLocalCR As Decimal
Dim WrkEldAdjTax As Decimal

  Public Sub PrtReportRE()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
    myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)

    With MyFrmTAB01B
    WrkType = "R"
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkPrintDist = False
    If .ChkPrtDist.Checked Then
      WrkPrintDist = True
    End If
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
    WrkCC = False
    If .ChkCC.Checked Then
      WrkCC = True
    End If
    WrkBTR = False
    If .ChkBAA.Checked Then
      WrkBTR = True
    End If
  End With

  GetMillRate(WrkGLYear, "R", WrkDist)
  GetDetail()

  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkTotBTR As Decimal
Dim WrkEx As Integer
Dim WrkGross As Integer
Dim WrkNet As Integer
    Dim WrkTax As Decimal
    Dim WrkAdjTax As Decimal
    Dim WrkBenefit As Decimal
    Dim WrkLocal As Decimal
Dim SaveFCCode As String
Dim SaveFCYear As Integer
Dim WrkFirstTime As Boolean
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "FCCOD, FCYR"
WrkQry = ""
If Not WrkDistAll Then
  If Not WrkPrintDist Then
    WrkQry = "dist=" & WrkDist
  Else
    WrkQry = "pdst=" & WrkDist
  End If
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

SaveFCCode = ""
SaveFCYear = 0
ClearElderlyTotals()
WrkFirstTime = True
    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      With DsTXREAL.Tables(0).Rows(I)
        If Not WrkFirstTime Then
          If SaveFCCode <> .Item("fccod") Or
           SaveFCYear <> .Item("fcyr") Then
            WriteElderlyTotals(SaveFCCode, SaveFCYear)
            ClearElderlyTotals()
          End If
        End If
        WrkFirstTime = False
        SaveFCCode = .Item("fccod")
        SaveFCYear = .Item("fcyr")
        If .Item("cat") = "1" Then
          WrkTotBTR = 0
          If WrkBTR Then
            WrkTotBTR = .Item("btr")
          End If
          WrkTotalRE = WrkTotalRE + 1
          If WrkCC And .Item("ccno") > 0 Then
            WrkGross = .Item("ccgrs")
            WrkNet = .Item("ccgrs") - .Item("ccex")
          Else
            WrkGross = .Item("gross") + WrkTotBTR
            WrkNet = .Item("net") + WrkTotBTR
          End If
          WrkTotalREGross = WrkTotalREGross + WrkGross
          WrkTotalRENet = WrkTotalRENet + WrkNet
          If WrkCC And .Item("ccno") > 0 Then
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
          Else
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
          End If
          WrkTax = MyUtils.Round(WrkNet * MrateMillrt, 2)
          With myTPAYMNT
            .In_Year = WrkGLYear
            .In_Type = "R"
            .In_Dst = WrkDist
            .In_Phs = ""
            .In_TaxT = WrkTax
            .CalcPaySplit()
            WrkTax = .Out_TaxT
          End With
          If Trim(.Item("Fccod")) <> "" Then
            If Trim(.Item("fccod")) = "C" Then
              WrkBenefit = .Item("ftax")
            Else
              WrkBenefit = WrkTax - .Item("ftax")
            End If
            WrkLocal = .Item("twnbn")
            WrkAdjTax = WrkTax - WrkBenefit - WrkLocal
            With myTPAYMNT
              .In_Year = WrkGLYear
              .In_Type = "R"
              .In_Dst = WrkDist
              .In_Phs = ""
              .In_TaxT = WrkAdjTax
              .CalcPaySplit()
              WrkAdjTax = .Out_TaxT
            End With
            WrkEldCount = WrkEldCount + 1
            WrkEldGross = WrkEldGross + WrkGross
            WrkEldNet = WrkEldNet + WrkNet
            WrkEldTax = WrkEldTax + WrkTax
            WrkEldStateCR = WrkEldStateCR + WrkBenefit
            WrkEldLocalCR = WrkEldLocalCR + WrkLocal
            WrkEldAdjTax = WrkEldAdjTax + WrkAdjTax
          Else
            WrkLocal = .Item("twnbn")
            WrkEldLocalCR = WrkEldLocalCR + WrkLocal
          End If

          'Add to Exemption groups
          For J = 0 To 6
            WrkEx = 0
            If Trim(WrkExcd(J)) <> "" Then
              K = LookupExem(WrkExcd(J))
              If WrkExam(J) = 0 And DsTXREAL.Tables(0).Rows(I).Item("ccno") = 0 Then
                WrkEx = WrkExFixedAmt(K)
              Else
                WrkEx = WrkExam(J)
              End If
              K = LookupWrkTExCode(WrkExcd(J))
              WrkTExCode(K) = WrkExcd(J)
              WrkTExRE(K) = WrkTExRE(K) + WrkEx
            End If
          Next
        Else
          WrkREExempt = WrkREExempt + .Item("gross")
        End If
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

    If WrkEldCount > 0 Then
  WriteElderlyTotals(SaveFCCode, SaveFCYear)
End If

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
Private Sub WriteElderlyTotals(ByVal FCCode As String, ByVal FCYear As String)
  dr = dsEld.Tables(0).NewRow
	Select Case FCCode
	Case "C"
    dr.Item("code") = "Elderly (State)"
	Case "F"
		dr.Item("code") = "Frozen"
	Case Else
    dr.Item("code") = "Local"
	End Select
	dr.Item("year") = FCYear
	dr.Item("count") = WrkEldCount
	dr.Item("gross") = WrkEldGross
	dr.Item("netass") = WrkEldNet
	dr.Item("tax") = WrkEldTax
	dr.Item("statecredit") = WrkEldStateCR
	dr.Item("localcredit") = WrkEldLocalCR
	dr.Item("adjtax") = WrkEldAdjTax
	dsEld.Tables(0).Rows.Add(dr)
End Sub
Private Sub ClearElderlyTotals()
  WrkEldCount = 0
  WrkEldGross = 0
  WrkEldNet = 0
  WrkEldTax = 0
  WrkEldStateCR = 0
  WrkEldLocalCR = 0
  WrkEldAdjTax = 0
End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)
Dim myTXMRATE As TXMRATE.myData

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    MrateMillrt = ._MRRATE
  End With
End If
myTXMRATE.CloseFile()
End Sub
End Module






