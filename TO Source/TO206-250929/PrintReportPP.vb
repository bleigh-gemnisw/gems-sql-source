Imports System.Text
Module PrintReportPP

Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXPPRPCQ As TXPPRPCQ.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim DsTXPPRP As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkDetail As Boolean
Dim WrkBTR As Boolean
  Public Sub PrtReportPP()

	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
	myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTO206B
    WrkType = "P"
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
WrkQry = "CAT = '5'"
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If

If Not WrkFrozenFile Then
  DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  With DsTXPPRP.Tables(0).Rows(I)
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
      WrkNet = WrkGross - WrkExempt
    End If
    WrkTaxTotal = WrkNet * myTXMRATE._MRRATE
    With myTPaymnt
      .In_ListNo = DsTXPPRP.Tables(0).Rows(I).Item("list#")
      .In_Type = WrkType
      .In_Year = WrkGLYear
      .In_Dst = WrkDist
      .In_Phs = ""
      .In_TaxT = WrkTaxTotal
      .CalcPaySplit()
      WrkTaxTotal = .Out_TaxT
      WrkTotalPP = WrkTotalPP + .Out_TaxT
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
  WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myTXPPRPQ.CloseFile()
myTXPPRPCQ.CloseFile()

End Sub
End Module






