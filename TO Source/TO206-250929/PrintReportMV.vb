Imports System.Text
Module PrintReportMV

Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXMVDCQ As TXMVDCQ.myData
Dim myTXCOEB As TXCOEB.myData
Dim myTXMVPCT As TXMVPCT.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim DsTXMVD As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkDetail As Boolean

Dim WrkExam(5) As Integer

  Public Sub PrtReportMV()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
	myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)
	myTXCOEB = New TXCOEB.mydata(MyDBConnect)
	myTXMVPCT = New TXMVPCT.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTO206B
    WrkType = "M"
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
Dim WrkGross As Integer
Dim WrkExempt As Integer
Dim WrkMVCred As Decimal
Dim WrkNet As Integer
Dim WrkTaxTotal As Decimal
Dim WrkCC As Boolean
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
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
  DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXMVD = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  With DsTXMVD.Tables(0).Rows(I)
    WrkCC = False
    If .Item("ccno") > 0 Then
      WrkCC = True
    End If
    WrkGross = .Item("value") + .Item("btr")
    WrkExam(0) = .Item("exam1")
    WrkExam(1) = .Item("exam2")
    WrkExam(2) = .Item("exam3")
    WrkExam(3) = .Item("exam4")
    WrkExam(4) = .Item("exam5")
    WrkExempt = WrkExam(0) + WrkExam(1) + WrkExam(2) + WrkExam(3) + WrkExam(4)
    WrkNet = WrkGross - WrkExempt
    If WrkNet < 0 Then WrkNet = 0
    WrkExempt = 0
    If WrkCC Then
      WrkGross = .Item("ccgrs")
      WrkExempt = .Item("ccex")
      WrkMVCred = CalcMvCred(.Item("ccno"))
      WrkNet = WrkGross - WrkExempt - WrkMVCred
    End If
    WrkTaxTotal = WrkNet * myTXMRATE._MRRATE
    With myTPaymnt
      .In_ListNo = DsTXMVD.Tables(0).Rows(I).Item("list#")
      .In_Type = WrkType
      .In_Year = WrkGLYear
      .In_Dst = WrkDist
      .In_Phs = ""
      .In_TaxT = WrkTaxTotal
      .CalcPaySplit()
      WrkTaxTotal = .Out_TaxT
      WrkTotalMV = WrkTotalMV + .Out_TaxT
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
  WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myTXMVDQ.CloseFile()
myTXMVDCQ.CloseFile()

End Sub
Private Function CalcMvCred(ByVal CCNo As Integer) As Integer
	Dim WrkCCGross As Decimal
  Dim WrkCode As String
  Dim WrkAmount As Decimal

	myTXCOEB.GetOneRecordP(CCNo)
	If myTXCOEB.RecordNotFound Then Return 0

	With myTXCOEB
		WrkCCGross = ._CGRS
		WrkCode = ._CT2MC1
	End With

	myTXMVPCT.GetOneRecordP("M", WrkCode)
	If myTXMVPCT.RecordNotFound Then Return 0

	With myTXMVPCT
    WrkAmount = MyUtils.Round(WrkCCGross * ._PCT, 0)
	End With

  Return WrkAmount
End Function
End Module






