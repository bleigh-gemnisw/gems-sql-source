Imports System.Text
Module PrintReportRE

Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim DsTXREAL As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkDetail As Boolean
Dim WrkBTR As Boolean
Dim WrkPrintDist As Boolean

  Public Sub PrtReportRE()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTO206B
    WrkType = "R"
    WrkGLYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
    WrkDetail = False
    If .ChkDetail.Checked Then
      WrkDetail = True
    End If
  End With

  GetDetail()

  End Sub
Private Sub GetDetail()
Dim WrkCode(6) As Integer
Dim WrkAss(6) As Integer
Dim WrkCCAss(6) As Integer
Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
Dim WrkGross As Integer
Dim WrkGross10ML As Integer
Dim WrkExempt As Integer
Dim WrkNet As Integer
Dim WrkCC As Boolean
Dim WrkCCGross As Integer
Dim WrkCCExempt As Integer
Dim WrkCCNet As Integer
Dim WrkCCTax As Decimal
Dim WrkFrozenCode As String
Dim WrkSTBenefit As Decimal
Dim WrkTownBenefit As Decimal
Dim WrkTaxAmount As Decimal
Dim WrkTax As Decimal
Dim WrkSort As String
Dim WrkQry As String
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

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
    WrkCode(0) = .Item("code1")
    WrkCode(1) = .Item("code2")
    WrkCode(2) = .Item("code3")
    WrkCode(3) = .Item("code4")
    WrkCode(4) = .Item("code5")
    WrkCode(5) = .Item("code6")
    WrkCode(6) = .Item("code7")
    WrkAss(0) = .Item("ass1")
    WrkAss(1) = .Item("ass2")
    WrkAss(2) = .Item("ass3")
    WrkAss(3) = .Item("ass4")
    WrkAss(4) = .Item("ass5")
    WrkAss(5) = .Item("ass6")
    WrkAss(6) = .Item("ass7")
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
    WrkCCAss(0) = .Item("cass1")
    WrkCCAss(1) = .Item("cass2")
    WrkCCAss(2) = .Item("cass3")
    WrkCCAss(3) = .Item("cass4")
    WrkCCAss(4) = .Item("cass5")
    WrkCCAss(5) = .Item("cass6")
    WrkCCAss(6) = .Item("cass7")
    WrkExempt = 0
    WrkGross10ML = 0
    WrkCC = False
    If .Item("ccno") > 0 Then
      WrkCC = True
    End If
    WrkGross = .Item("gross") + .Item("btr")
    WrkNet = .Item("net") + .Item("btr")
    If WrkNet < 0 Then WrkNet = 0
    WrkExempt = 0
    If WrkCC Then
      WrkGross = .Item("ccgrs")
      WrkExempt = .Item("ccex")
    Else
      WrkGross = .Item("gross") + .Item("btr")
      For J = 0 To 6
        If WrkCode(J) = 71 Then
          If Not WrkCC Then
            WrkGross10ML = WrkGross10ML + WrkAss(J)
          Else
            WrkGross10ML = WrkGross10ML + WrkCCAss(J)
          End If
        End If
        If WrkExcd(J) <> "" And WrkExam(J) = 0 Then
          K = LookupExem(WrkExcd(J))
          WrkExempt = WrkExempt + WrkExFixedAmt(K)
        Else
          WrkExempt = WrkExempt + WrkExam(J)
        End If
      Next
    End If
    WrkNet = WrkGross - WrkExempt
    If WrkNet < 0 Then WrkNet = 0
		If WrkCC Then
			WrkCCGross = .Item("ccgrs")
			WrkCCExempt = .Item("ccex")
			WrkCCNet = WrkCCGross - WrkCCExempt
			If WrkCCNet < 0 Then WrkCCNet = 0
			WrkCCTax = WrkCCNet * myTXMRATE._MRRATE
		End If
		WrkTaxAmount = (WrkNet - WrkGross10ML) * myTXMRATE._MRRATE
    WrkTaxAmount = WrkTaxAmount + (WrkGross10ML * 0.01)
    WrkSTBenefit = 0
    WrkTownBenefit = .Item("twnbn")
    WrkFrozenCode = .Item("fccod")
    Select Case WrkFrozenCode
    Case "F" 'Frozen
      WrkTax = MyUtils.Round(.Item("ftax"), 2) - WrkTownBenefit
      WrkSTBenefit = MyUtils.Round(WrkTaxAmount - WrkTax - WrkTownBenefit, 2)
    Case "C" 'Heart/Circuit Breaker
			WrkSTBenefit = .Item("ftax")
			If WrkCC Then
				WrkTax = WrkCCTax - WrkSTBenefit - WrkTownBenefit
			Else
				WrkTax = WrkTaxAmount - WrkSTBenefit - WrkTownBenefit
			End If
		Case Else	'Normal
			WrkTax = WrkTaxAmount - WrkTownBenefit
		End Select
    With myTPaymnt
      .In_ListNo = DsTXREAL.Tables(0).Rows(I).Item("list#")
      .In_Type = WrkType
      .In_Year = WrkGLYear
      .In_Dst = WrkDist
      .In_Phs = ""
			.In_TaxT = WrkTax
      .CalcPaySplit()
			WrkTax = .Out_TaxT
      WrkTotalRE = WrkTotalRE + .Out_TaxT
    End With

    If WrkDetail Then
      dr = dsDtl.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("Type") = WrkType
      dr.Item("name") = .Item("name")
      dr.Item("net") = WrkNet
			dr.Item("taxtot") = WrkTax
      dsDtl.Tables(0).Rows.Add(dr)
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

myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
End Module






