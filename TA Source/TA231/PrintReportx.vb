Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXREAL As TXREAL.myData
Dim myTXREALC As TXREALC.myData
Dim myTXM35H As TXM35H.myData
Dim myTXLOCFRZ As TXLOCFRZ.myData
Dim myTXMRATE As TXMRATE.myData
Dim myTPAYMNT As TPAYMNT.MyData

'Adjusted Gross Ommited Codes 
Dim cExcludeCode1 As Integer
Dim cExcludeCode2 As Integer
Dim cExcludeCode3 As Integer
Dim cExcludeCode4 As Integer

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkEldYear As Integer
Dim WrkPost As Boolean

 Public Sub PrtReport()

 myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
 myTXREAL = New TXReal.mydata(MyDBConnect)
 myTXREALC = New TXREALC.mydata(MyDBConnect)
 myTXM35H = New TXM35H.mydata(MyDBConnect)
 myTXLOCFRZ = New TXLOCFRZ.mydata(MyDBConnect)
 myTXMRATE = New TXMRATE.mydata(MyDBConnect)
 myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)

 With MyFrmTA231B
    WrkEldYear = MyUtils.CnvSng(.TxtEldYear.Text)
    WrkPost = .ChkPost.Checked
 End With

 myTXMRATE.GetOneRecordP(WrkEldYear, "R", 0)
 If myTXMRATE.RecordNotFound Then
   myTXMRATE.GetOneRecordP(WrkEldYear, "", 0)
 End If
 If myTXMRATE.RecordNotFound Then
  MsgBox("Mill rate not found", MsgBoxStyle.Critical, "Process has been cancelled")
  Exit Sub
 End If

 If ds.Tables.Count = 0 Then
  BuildDS(ds)
 Else
  ds.Clear()
 End If

 cExcludeCode1 = GetTXCDAGCode(1)
 cExcludeCode2 = GetTXCDAGCode(2)
 cExcludeCode3 = GetTXCDAGCode(3)
 cExcludeCode4 = GetTXCDAGCode(4)
 If cExcludeCode1 = 0 Then cExcludeCode1 = 12
 If cExcludeCode2 = 0 Then cExcludeCode2 = 61
 If cExcludeCode3 = 0 Then cExcludeCode3 = 62
 If cExcludeCode4 = 0 Then cExcludeCode4 = 63
 GetDetail()

 MyCrViewer = New FrmCrViewer
 MyCrViewer.wrkds = ds
 MyCrViewer.WrkPost = WrkPost
 MyCrViewer.Show()

 End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAssCode(6) As Integer
Dim WrkGross(6) As Integer
Dim WrkTotGross As Integer
Dim WrkExcludeGross As Integer
Dim WrkExam As Integer
Dim WrkNet As Integer
Dim WrkAnd As String
Dim WrkTax As Decimal
Dim WrkBenefit As Decimal
Dim Counter As Integer
Dim J As Integer

If myDBConnect.ServerAS400 Then
 WrkAnd = " *and "
Else
 WrkAnd = " and "
 End If

Counter = 0
WrkSort = "LIST#"
WrkQry = "FCCOD = 'C'" & WrkAnd & "FCYR = " & WrkEldYear

myTXREALCQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myTXREALCQ.ReadQry()
 If Not myTXREALCQ.IsEOF Then
 With myTXREALCQ
    Counter = Counter + 1
    ds2 = myTXM35H.GetbyList(._LISTNO, ._FCYR)
    If ds2.Tables(0).Rows.Count > 0 Then
      GoTo ReadNext
    End If
    myTXLOCFRZ.GetOneRecordP(._LISTNO)
    If Not myTXLOCFRZ.RecordNotFound Then
      WrkTax = myTXLOCFRZ._FRZTAX
    Else
     WrkAssCode(0) = ._CODE1
     WrkAssCode(1) = ._CODE2
     WrkAssCode(2) = ._CODE3
     WrkAssCode(3) = ._CODE4
     WrkAssCode(4) = ._CODE5
     WrkAssCode(5) = ._CODE6
     WrkAssCode(6) = ._CODE7
     If ._CCNO > 0 Then
      WrkGross(0) = ._CASS1
      WrkGross(1) = ._CASS2
      WrkGross(2) = ._CASS3
      WrkGross(3) = ._CASS4
      WrkGross(4) = ._CASS5
      WrkGross(5) = ._CASS6
      WrkGross(6) = ._CASS7
      WrkExam = ._CEXA1 + ._CEXA2 + ._CEXA3 + ._CEXA4 + ._CEXA5 + ._CEXA6 + ._CEXA7
     Else
      WrkGross(0) = ._ASS1
      WrkGross(1) = ._ASS2
      WrkGross(2) = ._ASS3
      WrkGross(3) = ._ASS4
      WrkGross(4) = ._ASS5
      WrkGross(5) = ._ASS6
      WrkGross(6) = ._ASS7
      WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
     End If

     WrkTotGross = 0
     WrkExcludeGross = 0
     For J = 0 To 6
      WrkTotGross = WrkTotGross + WrkGross(J)
      If WrkAssCode(J) = cExcludeCode1 Or WrkAssCode(J) = cExcludeCode2 _
       Or WrkAssCode(J) = cExcludeCode3 Or WrkAssCode(J) = cExcludeCode4 Then
       WrkExcludeGross = WrkExcludeGross + WrkGross(J)
      End If
     Next J
     WrkNet = WrkTotGross - WrkExcludeGross - WrkExam
     WrkTax = CalcTax(._DIST, WrkNet)
    End If
    WrkBenefit = CalcBenefit(WrkTax, ._DIST, ._CPERC, ._CMIN, ._CMAX)
    If WrkPost Then
     UpdateRE(._LISTNO, WrkBenefit)
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNO
    dr.Item("name") = Trim(._NAME)
    dr.Item("benefit") = WrkBenefit
    ds.Tables(0).Rows.Add(dr)
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
  End With
  GoTo ReadNext
 End If

myFrmProgress.Close()
myTXREALCQ.CloseFile()

If WrkPost Then
 MsgBox("Benefit Amounts have been recalculated", MsgBoxStyle.Information, "Update has finished")
 MyFrmTA231B.ChkPost.Checked = False
End If
End Sub
Private Sub UpdateRE(ByVal List As Integer, ByVal WrkBenefit As Decimal)

 With myTXREAL
  .GetOneRecordP(List)
  If Not .RecordNotFound Then
   ._FTAX = WrkBenefit
   .UpdateOneRecordP()
  End If
 End With

 With myTXREALC
  .GetOneRecordP(List)
  ._FTAX = WrkBenefit
  .UpdateOneRecordP()
 End With
End Sub
Private Function CalcTax(ByVal WrkDist As Integer, ByVal WrkNet As Integer) As Decimal

 Dim WrkTax As Decimal

 WrkTax = MyUtils.Round(WrkNet * myTXMRATE._MRRATE, 2)
 With myTPAYMNT
  .In_Year = WrkEldYear
  .In_Type = "R"
  .In_Dst = WrkDist
  .In_Phs = ""
  .In_TaxT = WrkTax
  .CalcPaySplit()
  WrkTax = .Out_TaxT
 End With

 Return WrkTax

End Function
Private Function CalcBenefit(ByVal WrkTax As Decimal, ByVal WrkDist As Integer, ByVal WrkPct As Decimal, _
 ByVal WrkMin As Decimal, ByVal WrkMax As Decimal) As Decimal
 Dim WrkCreditMax As Decimal
 Dim WrkLesser As Decimal
 Dim WrkCredit As Decimal

 WrkCreditMax = WrkTax * WrkPct
 If WrkCreditMax > WrkMax Then
  WrkLesser = WrkMax
 Else
  WrkLesser = WrkCreditMax
 End If
 If WrkLesser > WrkMin Then
  WrkCredit = WrkLesser
 Else
  WrkCredit = WrkMin
 End If
 With myTPAYMNT
  .In_Year = WrkEldYear
  .In_Type = "R"
  .In_Dst = WrkDist
  .In_Phs = ""
  .In_TaxT = WrkCredit
  .CalcPaySplit()
  WrkCredit = .Out_TaxT
 End With
 Return WrkCredit

End Function
End Module






