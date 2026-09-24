Imports System.Text
Module PrintReportSU

Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXMVPCT As TXMVPCT.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim DsTXSUPP As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkDetail As Boolean

Dim WrkExam(5) As Integer
'Buffered files
Dim WrkSupCode(25) As String
Dim WrkSupMonth(25) As String
Dim WrkSupPct(25) As Decimal

  Public Sub PrtReportSU()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXMVPCT = New TXMVPCT.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTO206B
    WrkType = "S"
    WrkGLYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkDetail = False
    If .ChkDetail.Checked Then
      WrkDetail = True
    End If
  End With

  BufferTXSupcd()
  GetDetail()
  End Sub
Private Sub GetDetail()
Dim WrkExcd(4) As String
Dim WrkGross As Integer
Dim WrkExempt As Integer
Dim WrkNet As Integer
Dim WrkOGross As Integer
Dim WrkProrate As Integer
Dim WrkProratePct As Decimal
Dim WrkCredit As Integer
Dim WrkCreditPct As Decimal
Dim WrkTaxTotal As Decimal
Dim WrkCC As Boolean
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

DsTXSUPP = myTXSUPPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
  With DsTXSUPP.Tables(0).Rows(I)
    WrkCC = False
    'If .Item("ccno") > 0 Then
    '  WrkCC = True
    'End If
    WrkGross = .Item("value") + .Item("btr")
    WrkExam(0) = .Item("exam1")
    WrkExam(1) = .Item("exam2")
    WrkExam(2) = .Item("exam3")
    WrkExam(3) = .Item("exam4")
    WrkExam(4) = .Item("exam5")
    WrkExempt = 0
    If WrkCC Then
      WrkGross = .Item("ccgrs")
      WrkExempt = .Item("ccex")
    Else
      WrkGross = .Item("value") + .Item("btr")
      WrkOGross = .Item("oval") + .Item("btr")
      For J = 0 To 4
        If WrkExcd(J) <> "" And WrkExam(J) = 0 Then
          K = LookupExem(WrkExcd(J))
          WrkExempt = WrkExempt + WrkExFixedAmt(K)
        Else
          WrkExempt = WrkExempt + WrkExam(J)
        End If
      Next
    End If
    WrkProratePct = CalcPct(.Item("ass"))
    WrkProrate = CalcAssmt(WrkGross, WrkProratePct)
    WrkCreditPct = CalcPct(.Item("oass"))
    WrkCredit = CalcAssmt(WrkOGross, WrkCreditPct)
    If WrkCredit > WrkProrate Then
      WrkCredit = WrkProrate
    End If
    WrkNet = WrkProrate - WrkCredit - WrkExempt
    If WrkNet < 0 Then WrkNet = 0
    WrkTaxTotal = WrkNet * myTXMRATE._MRRATE
    With myTPaymnt
      .In_ListNo = DsTXSUPP.Tables(0).Rows(I).Item("list#")
      .In_Type = WrkType
      .In_Year = WrkGLYear - 1
      .In_Dst = WrkDist
      .In_Phs = ""
      .In_TaxT = WrkTaxTotal
      .CalcPaySplit()
      WrkTaxTotal = .Out_TaxT
      WrkTotalSU = WrkTotalSU + .Out_TaxT
    End With

    If WrkDetail Then
      dr = dsDtl.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("Type") = WrkType
      dr.Item("name") = .Item("name")
      dr.Item("net") = WrkNet
      dr.Item("taxtot") = WrkTaxTotal
      dsDtl.Tables(0).Rows.Add(dr)
    End If
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myTXSUPPQ.CloseFile()

End Sub
Private Sub BufferTXSupcd()
     Dim I As Integer

		 Dim myTXSUPCD As TXSUPCD.myData
     Dim dsTXSupcd As DataSet = New DataSet

		 myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)

     dsTXSupcd = myTXSUPCD.GetAllData
     For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupMonth(I) = .Item("smon")
        WrkSupPct(I) = .Item("spct")
      End With
    Next

End Sub
Private Function LookupTxSupcd(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

End Function
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    WrkPct = WrkSupPct(K)
    Return WrkPct
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Decimal

    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function

End Module






