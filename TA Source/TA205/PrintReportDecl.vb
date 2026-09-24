Imports System.Text
Module PrintReportDecl

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXDCPPQ As TXDCPPQ.myData
Dim myTXPPRP As TXPPRP.myData
Dim myTXPPRPC As TXPPRPC.myData
Dim myTXINV As TXINV.myData

Dim ds As DataSet = New DataSet
Dim dsExempt As DataSet = New DataSet
Dim DsTXDCPP As DataSet = New DataSet
Dim dr As Data.DataRow
Const WrkType As String = "P"
'Screen
Dim WrkGLYear As Integer
Dim WrkIncrease As Boolean
Dim WrkExemptions As Boolean
Dim WrkNewOPM As Boolean
Dim WrkNoDetail As Boolean
'Report Fields
Dim RptCode(9) As String
Dim RptGross(9) As Integer

  Public Sub PrtReportDecl()

  myTXDCPPQ = New TXDCPPQ.mydata(MyDBConnect)
  myTXPPRP = New TXPPRP.mydata(MyDBConnect)
  myTXPPRPC = New TXPPRPC.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)

  With MyFrmTA205B
    WrkGLYear = .TxtGLYear.Text
    WrkIncrease = .RbIncrease.Checked
    WrkNewOPM = False
    If .ChkNewOPM.Checked Then
      WrkNewOPM = True
    End If
    WrkNoDetail = False
    If .ChkNoDetail.Checked Then
      WrkNoDetail = True
    End If
    WrkExemptions = False
    If .ChkExemptions.Checked Then
      WrkExemptions = True
    End If
  End With

  If ds.Tables.Count = 0 Then
    BuildDS(ds, dsExempt)
  Else
    ds.Clear()
    dsExempt.Clear()
    ClearCodes()
  End If

  BufferCodes(WrkType, WrkNewOPM)
  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkdsExempt = dsExempt
  MyCrViewer.WrkType = WrkType
  MyCrViewer.WrkAssrName = WrkAssrName
  MyCrViewer.WrkAssrPhone = WrkAssrPhone
  MyCrViewer.Show()

  End Sub
Private Sub GetDetail()
Dim AddrLine As String()
Dim WrkAssCode(9) As Integer
Dim WrkGross(9) As Integer
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String
Dim WrkOPMGroup As Integer
Dim WrkOGross As Integer
Dim WrkOExam As Integer
Dim WrkOMap As String
Dim WrkOAssDesc As String
Dim WrkOAssGross As String
Dim WrkNAssDesc As String
Dim WrkNAssGross As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkSort = "OWNAME, LIST#"
WrkQry = "STATUS ='C'" & WrkAnd & "YEAR=" & WrkGLYear

myTXDCPPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXDCPPQ.ReadQry()
  If Not myTXDCPPQ.IsEOF Then
    With myTXDCPPQ
    Counter = Counter + 1
    myTXINV.GetOneRecordP(._LISTNO, WrkGLYear, "P")
    If myTXINV.RecordNotFound Then
      myTXPPRPC.GetOneRecordP(._LISTNO)
    End If
    WrkOGross = 0
    WrkOExam = 0
    WrkOMap = ""
    WrkOAssDesc = ""
    WrkOAssGross = ""
    WrkNAssDesc = ""
    WrkNAssGross = ""
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        If ._CCNO = 0 Then
          WrkAssCode(0) = ._IPPCD1
          WrkAssCode(1) = ._IPPCD2
          WrkAssCode(2) = ._IPPCD3
          WrkAssCode(3) = ._IPPCD4
          WrkAssCode(4) = ._IPPCD5
          WrkAssCode(5) = ._IPPCD6
          WrkAssCode(6) = ._IPPCD7
          WrkAssCode(7) = ._IPPCD8
          WrkAssCode(8) = ._IPPCD9
          WrkAssCode(9) = ._IPPCDA
          WrkGross(0) = ._OAS1
          WrkGross(1) = ._OAS2
          WrkGross(2) = ._OAS3
          WrkGross(3) = ._OAS4
          WrkGross(4) = ._OAS5
          WrkGross(5) = ._OAS6
          WrkGross(6) = ._OAS7
          WrkGross(7) = ._OAS8
          WrkGross(8) = ._OAS9
          WrkGross(9) = ._OAS10
          WrkOGross = ._GROSS
          WrkOExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
        Else
          WrkAssCode(0) = MyUtils.CnvSng(._CCCD1)
          WrkAssCode(1) = MyUtils.CnvSng(._CCCD2)
          WrkAssCode(2) = MyUtils.CnvSng(._CCCD3)
          WrkAssCode(3) = MyUtils.CnvSng(._CCCD4)
          WrkAssCode(4) = MyUtils.CnvSng(._CCCD5)
          WrkAssCode(5) = MyUtils.CnvSng(._CCCD6)
          WrkAssCode(6) = MyUtils.CnvSng(._CCCD7)
          WrkAssCode(7) = ._IPPCD8
          WrkAssCode(8) = ._IPPCD9
          WrkAssCode(9) = ._IPPCDA
          WrkGross(0) = ._CASS1
          WrkGross(1) = ._CASS2
          WrkGross(2) = ._CASS3
          WrkGross(3) = ._CASS4
          WrkGross(4) = ._CASS5
          WrkGross(5) = ._CASS6
          WrkGross(6) = ._CASS7
          WrkGross(7) = ._CASS8
          WrkGross(8) = ._CASS9
          WrkGross(9) = ._CASS10
          WrkOGross = ._CGRS
          WrkOExam = ._CCEXP
        End If
        WrkOMap = Trim(._MAP)
      End With
    Else
      With myTXPPRPC
        If ._CCNO = 0 Then
          WrkAssCode(0) = ._CODE1
          WrkAssCode(1) = ._CODE2
          WrkAssCode(2) = ._CODE3
          WrkAssCode(3) = ._CODE4
          WrkAssCode(4) = ._CODE5
          WrkAssCode(5) = ._CODE6
          WrkAssCode(6) = ._CODE7
          WrkAssCode(7) = ._CODE8
          WrkAssCode(8) = ._CODE9
          WrkAssCode(9) = ._CODEA
          WrkGross(0) = ._ASS1
          WrkGross(1) = ._ASS2
          WrkGross(2) = ._ASS3
          WrkGross(3) = ._ASS4
          WrkGross(4) = ._ASS5
          WrkGross(5) = ._ASS6
          WrkGross(6) = ._ASS7
          WrkGross(7) = ._ASS8
          WrkGross(8) = ._ASS9
          WrkGross(9) = ._ASS10
          WrkOGross = ._GROSS
          WrkOExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
        Else
          WrkAssCode(0) = MyUtils.CnvSng(._CCCD1)
          WrkAssCode(1) = MyUtils.CnvSng(._CCCD2)
          WrkAssCode(2) = MyUtils.CnvSng(._CCCD3)
          WrkAssCode(3) = MyUtils.CnvSng(._CCCD4)
          WrkAssCode(4) = MyUtils.CnvSng(._CCCD5)
          WrkAssCode(5) = ._CODE6
          WrkAssCode(6) = ._CODE7
          WrkAssCode(7) = ._CODE8
          WrkAssCode(8) = ._CODE9
          WrkAssCode(9) = ._CODEA
          WrkGross(0) = ._CASS1
          WrkGross(1) = ._CASS2
          WrkGross(2) = ._CASS3
          WrkGross(3) = ._CASS4
          WrkGross(4) = ._CASS5
          WrkGross(5) = ._CASS6
          WrkGross(6) = ._CASS7
          WrkGross(7) = ._CASS8
          WrkGross(8) = ._CASS9
          WrkGross(9) = ._CASSA
          WrkOGross = ._CCGRS
          WrkOExam = ._CCEX
        End If
      End With
    End If

    If WrkOGross > 0 Then
      'Combine Gross into OPM groups
      Array.Clear(RptCode, 0, 10)
      Array.Clear(RptGross, 0, 10)
      For J = 0 To 9
        If WrkAssCode(J) > 0 Then
          WrkOPMGroup = LookupOPMCode(WrkAssCode(J))
          K = LookupRptCode(WrkOPMGroup)
          RptCode(K) = WrkOPMGroup
          RptGross(K) = RptGross(K) + WrkGross(J)
        End If
      Next J

      For J = 0 To 9
        If RptCode(J) <> "" Then
          If WrkOAssGross = "" Then
            WrkOAssGross = FmtNumber(RptGross(J))
            WrkOAssDesc = LookupOPMDesc(RptCode(J))
          Else
            WrkOAssGross = WrkOAssGross & vbCrLf & FmtNumber(RptGross(J))
            WrkOAssDesc = WrkOAssDesc & vbCrLf & LookupOPMDesc(RptCode(J))
          End If
       End If
      Next
    End If

    dr = ds.Tables(0).NewRow
    With myTXPPRP
      dr.Item("listno") = ._LISTNO
      AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      WrkAssCode(0) = ._CODE1
      WrkAssCode(1) = ._CODE2
      WrkAssCode(2) = ._CODE3
      WrkAssCode(3) = ._CODE4
      WrkAssCode(4) = ._CODE5
      WrkAssCode(5) = ._CODE6
      WrkAssCode(6) = ._CODE7
      WrkAssCode(7) = ._CODE8
      WrkAssCode(8) = ._CODE9
      WrkAssCode(9) = ._CODEA
      WrkGross(0) = ._ASS1
      WrkGross(1) = ._ASS2
      WrkGross(2) = ._ASS3
      WrkGross(3) = ._ASS4
      WrkGross(4) = ._ASS5
      WrkGross(5) = ._ASS6
      WrkGross(6) = ._ASS7
      WrkGross(7) = ._ASS8
      WrkGross(8) = ._ASS9
      WrkGross(9) = ._ASS10
      dr.Item("ngross") = ._GROSS
      dr.Item("nexam") = ._GROSS - ._NET
      dr.Item("nmap") = ""
    End With

    'Combine Gross into OPM groups
    Array.Clear(RptCode, 0, 10)
    Array.Clear(RptGross, 0, 10)
    For J = 0 To 9
      If WrkAssCode(J) > 0 Then
        WrkOPMGroup = LookupOPMCode(WrkAssCode(J))
        K = LookupRptCode(WrkOPMGroup)
        RptCode(K) = WrkOPMGroup
        RptGross(K) = RptGross(K) + WrkGross(J)
      End If
    Next J

    For J = 0 To 9
      If RptCode(J) > 0 Then
        If WrkNAssGross = "" Then
          WrkNAssGross = FmtNumber(RptGross(J))
          WrkNAssDesc = LookupOPMDesc(RptCode(J))
        Else
          WrkNAssGross = WrkNAssGross & vbCrLf & FmtNumber(RptGross(J))
          WrkNAssDesc = WrkNAssDesc & vbCrLf & LookupOPMDesc(RptCode(J))
        End If
     End If
    Next

    If WrkNoDetail Then
      dr.Item("nassdesc") = String.Empty
      dr.Item("nassgross") = String.Empty
      dr.Item("oassdesc") = String.Empty
      dr.Item("oassgross") = String.Empty
    Else
      dr.Item("nassdesc") = WrkNAssDesc
      dr.Item("nassgross") = WrkNAssGross
      dr.Item("oassdesc") = WrkOAssDesc
      dr.Item("oassgross") = WrkOAssGross
    End If
    dr.Item("ogross") = WrkOGross
    dr.Item("oexam") = WrkOExam
    dr.Item("omap") = WrkOMap
    dr.Item("location") = Trim(myTXPPRP._LOCNO) & " " & Trim(myTXPPRP._LOC)
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
myTXDCPPQ.CloseFile()

End Sub
Private Function LookupRptCode(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To RptCode.GetUpperBound(0)
       If RptCode(I) & "" = "" Then
         Return I
       End If
       If Code = RptCode(I) Then
         Return I
       End If
    Next

End Function
End Module






