Imports System.io
Imports System.Text
Module PrintCustID

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXINVLC As TXINVLC.myData
Dim myTXINV As TXINV.myData
Dim myTXVCUS As TXVCUS.myData
Dim myTXVEHL1 As TXVEHL1.myData
Dim myTXVBUS As TXVBUS.myData

Dim mydsDMV As DataSet = New DataSet
Dim dsHold As DataSet = New DataSet
Dim mydsStatus As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim mydsDMVTXINV As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkGLYearFrom As Integer
Dim WrkGLYearTo As Integer
Dim WrkSelType As String
Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtCustID()
  myTXINVQ = New TXINVQ.mydata(MyDBConnect)
  myTXINVLC = New TXINVLC.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXVCUS = New TXVCUS.mydata(MyDBConnect)
  myTXVEHL1 = New TXVEHL1.mydata(MyDBConnect)
  myTXVBUS = New TXVBUS.mydata(MyDBConnect)

  With MyFrmTX407B
    WrkGLYearFrom = MyUtils.CnvSng(.TxtCustYearFrom.Text)
    WrkGLYearTo = MyUtils.CnvSng(.TxtCustYearTo.Text)
    If .RbCustMV.Checked Then
      WrkSelType = "M"
    End If
    If .RbCustSU.Checked Then
      WrkSelType = "S"
    End If
    If .RbCustBoth.Checked Then
      WrkSelType = ""
    End If
    WrkPost = .ChkPost.Checked
  End With

  If MyServer = "DB2" Then
    WrkAnd = " *and "
    WrkOr = " *or "
  Else
    WrkAnd = " and "
    WrkOr = " or "
  End If
  If MyServer = "SQL" Then
    MyBlocking = False
  Else
    MyBlocking = True
  End If

  If mydsDMV.Tables.Count = 0 Then
    BuildDs(mydsDMV)
    BuildDsHold(dsHold)
    BuildDs2(mydsStatus)
    InitCASHINT()
    'InitCASHDUE()
  Else
    mydsDMV.Clear()
    dsHold.Clear()
    mydsStatus.Clear()
  End If
  GetDetail()
  GetMissing()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .WrkPost = WrkPost
    .wrkds3 = mydsStatus
    .WrkRpt = "CustID"
    .Show()
  End With

  End Sub
Private Sub GetDetail()
Dim drSel() As DataRow
Dim WrkQry As String
Dim WrkSort As String
Dim WrkList As Integer
Dim WrkType As String
Dim WrkYear As Integer
Dim SaveReg As String
Dim SavePCust As Integer
Dim SaveSCust As Integer
Dim SaveDOB As Integer
Dim SaveQry As String
Dim WrkSelect As String
Dim Good As Boolean
Dim GoodDOB As Boolean
Dim Counter As Integer
Dim I As Integer

WrkQry = "ss#=0"
'Filter Year
If WrkGLYearFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "year>=" & WrkGLYearFrom
End If
If WrkGLYearTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "year<=" & WrkGLYearTo
End If
'Filter Suspense Codes
With MyFrmTX407B
  If .TxtReason1.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason1.Text)
  End If
  If .TxtReason2.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason2.Text)
  End If
  If .TxtReason3.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason3.Text)
  End If
  If .TxtReason4.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason4.Text)
  End If
  If .TxtReason5.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason5.Text)
  End If
  If .TxtReason6.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason6.Text)
  End If
  If .TxtReason7.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason7.Text)
  End If
  If .TxtReason8.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason8.Text)
  End If
  If .TxtReason9.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason9.Text)
  End If
  If .TxtReason10.Text <> "" Then
    WrkQry = WrkQry & WrkAnd & "suscd<>" & MyUtils.Quo(.TxtReason10.Text)
  End If
End With
SaveQry = WrkQry
'Filter Tax Types
If WrkSelType <> "" Then
  WrkQry = SaveQry & WrkAnd & "type=" & MyUtils.Quo(WrkSelType)
Else
  WrkQry = SaveQry & WrkAnd & "type='M'" & WrkOr & SaveQry & WrkAnd & "type='S'"
End If

WrkSort = "IMVREG, SS# desc"
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveReg = ""
SavePCust = 0
SaveSCust = 0
SaveDOB = 0
Counter = 0
Good = False

ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
  With myTXINVQ
    Counter = Counter + 1
    If SaveReg <> Trim(._IMVREG) Then
      If WrkPost And Good Then FlagPutons(SaveReg, SavePCust, SaveSCust, SaveDOB)
      SaveReg = Trim(._IMVREG)
      Good = False
    End If
    WrkList = ._LISTNo
    WrkType = ._TYPE
    WrkYear = ._YEAR
    If Good Then GoTo NextRec

    SavePCust = 0
    SaveSCust = 0
    Good = True
    GoodDOB = False
    ds3 = myTXVEHL1.GetViewRegNo(Trim(._IMVREG), 100)
    If ds3.Tables(0).Rows.Count > 0 Then
      For I = 0 To ds3.Tables(0).Rows.Count - 1
        myTXVCUS.GetOneRecordP(ds3.Tables(0).Rows(I).Item("pcust"))
        If Not myTXVCUS.RecordNotFound Then
          If ._DOB = 0 Then
            If Mid(myTXVCUS._NAME, 1, 5) = Mid(._NAME, 1, 5) Then
              GoodDOB = True
              Exit For
            End If
          Else
            If myTXVCUS._DOB = ._DOB Then
              GoodDOB = True
              Exit For
            End If
          End If
        End If
      Next
    End If
    If GoodDOB Then
      SavePCust = ds3.Tables(0).Rows(I).Item("pcust")
      SaveSCust = ds3.Tables(0).Rows(I).Item("scust")
      WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, SavePCust)
      WrkSelect = "pcust=" & Str(ds3.Tables(0).Rows(I).Item("pcust"))
      drSel = mydsDMV.Tables(0).Select(WrkSelect)
      If drSel.GetUpperBound(0) = -1 Then
        dr = mydsDMV.Tables(0).NewRow
        dr.Item("sel") = True
        dr.Item("pcust") = ds3.Tables(0).Rows(I).Item("pcust")
        dr.Item("vehid") = ds3.Tables(0).Rows(I).Item("vehid")
        With myTXVCUS
          dr.Item("dmvname") = Trim(._NAME)
          dr.Item("dmvaddr") = Trim(._ADD1)
          dr.Item("dmvcity") = Trim(._CITY)
          dr.Item("dmvst") = Trim(._STATE)
          dr.Item("dmvzip") = Trim(._ZIPA)
        End With
        dr.Item("list") = WrkList
        dr.Item("type") = WrkType
        dr.Item("year") = WrkYear
        dr.Item("name") = Trim(._NAME)
        dr.Item("addr") = Trim(._ADD1)
        dr.Item("city") = Trim(._CITY)
        dr.Item("dob") = ._DOB
        mydsDMV.Tables(0).Rows.Add(dr)
      End If

      If ds3.Tables(0).Rows(I).Item("scust") > 0 Then
        WrkSelect = "pcust=" & Str(ds3.Tables(0).Rows(I).Item("scust"))
        drSel = mydsDMV.Tables(0).Select(WrkSelect)
        If drSel.GetUpperBound(0) = -1 Then
          dr = mydsDMV.Tables(0).NewRow
          dr.Item("sel") = True
          dr.Item("pcust") = ds3.Tables(0).Rows(I).Item("scust")
          dr.Item("vehid") = ds3.Tables(0).Rows(I).Item("vehid")
          With myTXVCUS
            .GetOneRecordP(ds3.Tables(0).Rows(I).Item("scust"))
            dr.Item("dmvname") = Trim(._NAME)
            dr.Item("dmvaddr") = Trim(._ADD1)
            dr.Item("dmvcity") = Trim(._CITY)
            dr.Item("dmvst") = Trim(._STATE)
            dr.Item("dmvzip") = Trim(._ZIPA)
          End With
          dr.Item("list") = WrkList
          dr.Item("type") = WrkType
          dr.Item("year") = WrkYear
          dr.Item("name") = Trim(._NAME)
          dr.Item("addr") = Trim(._ADD1)
          dr.Item("city") = Trim(._CITY)
          dr.Item("dob") = ._DOB
          mydsDMV.Tables(0).Rows.Add(dr)
        End If
      End If
    Else
      WriteHold(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, ._CITY, ._DOB, "")
    End If
  End With

NextRec:
  With myFrmProgress
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .LblMsg.Text = "Records processed(1/2): " & Counter
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo ReadNext
  End With
End If

If WrkPost Then FlagPutons(SaveReg, SavePCust, SaveSCust, SaveDOB)
myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Sub GetMissing()
Dim drSel() As DataRow
Dim SaveReg As String
Dim SavePCust As Integer
Dim SaveSCust As Integer
Dim SaveDOB As Integer
Dim WrkName As String
Dim WrkAddr As String
Dim WrkCity As String
Dim WrkSelect As String
Dim Good As Boolean
Dim Counter As Integer
Dim I As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveReg = ""
SavePCust = 0
SaveSCust = 0
SaveDOB = 0
Counter = 0
Good = False

For I = 0 To dsHold.Tables(0).Rows.Count - 1
  With dsHold.Tables(0).Rows(I)
    Counter = Counter + 1
    WrkName = Replace(.Item("name"), "'", "")
    WrkAddr = Replace(.Item("addr"), "'", "")
    WrkCity = Replace(.Item("city"), "'", "")
    If .Item("dob") > 0 Then
      WrkSelect = "addr='" & WrkAddr & "' and city='" & WrkCity & "' and dob=" & .Item("dob")
    Else
      WrkSelect = "addr='" & WrkAddr & "' and city='" & WrkCity & "' and name='" & WrkName & "'"
    End If
    SaveDOB = .Item("dob")
    drSel = mydsDMV.Tables(0).Select(WrkSelect)
    If drSel.GetUpperBound(0) > -1 Then
      WriteStatus(.Item("regno"), .Item("list"), .Item("type"), .Item("year"), .Item("name"), _
        .Item("addr"), drSel(0).Item("pcust"))
      If WrkPost Then FlagPutons(.Item("regno"), drSel(0).Item("pcust"), 0, 0)
    End If
  End With

NextRec:
  With myFrmProgress
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .LblMsg.Text = "Records processed(2/2): " & Counter
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End With
Next

If WrkPost Then FlagPutons(SaveReg, SavePCust, SaveSCust, SaveDOB)
myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Sub FlagPutons(ByVal RegNo As String, ByVal PCust As Integer, ByVal SCust As Integer, ByVal DOB As Integer)
  Dim ds2 As DataSet = New DataSet
  Dim I As Integer

  ds2 = myTXINVLC.GetAllRegno(RegNo, 999, MyBlocking)
  For I = 0 To ds2.Tables(0).Rows.Count - 1
    With ds2.Tables(0).Rows(I)
      myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
    End With
    With myTXINV
      If ._SSNo > 0 Then Continue For
      If ._TYPE <> "M" And ._TYPE <> "S" Then Continue For
      If DOB > 0 Then
        If DOB <> ._DOB Then Continue For
      End If
      ._SSNo = PCust
      ._SS2 = SCust
      If ._MVFLAG = "M" Then
        ._MVFLAG = "Y"
      End If
      .UpdateOneRecordP()
    End With
  Next
End Sub
Private Sub WriteStatus(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkYear As Integer, ByVal WrkName As String, ByVal WrkAddr As String, ByVal WrkMsg As String)
      dr = mydsStatus.Tables(0).NewRow
      dr.Item("regno") = WrkRegno
      dr.Item("list") = WrkList
      dr.Item("type") = WrkType
      dr.Item("year") = WrkYear
      dr.Item("name") = Trim(WrkName)
      dr.Item("addr") = Trim(WrkAddr)
      dr.Item("msg") = WrkMsg
      mydsStatus.Tables(0).Rows.Add(dr)
End Sub
Private Sub WriteHold(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkYear As Integer, ByVal WrkName As String, ByVal WrkAddr As String, ByVal WrkCity As String, _
  ByVal WrkDOB As Integer, ByVal WrkMsg As String)
      dr = dsHold.Tables(0).NewRow
      dr.Item("regno") = WrkRegno
      dr.Item("list") = WrkList
      dr.Item("type") = WrkType
      dr.Item("year") = WrkYear
      dr.Item("name") = Trim(WrkName)
      dr.Item("addr") = Trim(WrkAddr)
      dr.Item("city") = Trim(WrkCity)
      dr.Item("dob") = WrkDOB
      dr.Item("msg") = WrkMsg
      dsHold.Tables(0).Rows.Add(dr)
End Sub
Private Sub WriteStatus(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkYear As Integer, ByVal WrkName As String, ByVal WrkAddr As String, ByVal WrkCity As String, _
  ByVal WrkDOB As Integer, ByVal WrkMsg As String)
      dr = mydsStatus.Tables(0).NewRow
      dr.Item("regno") = WrkRegno
      dr.Item("list") = WrkList
      dr.Item("type") = WrkType
      dr.Item("year") = WrkYear
      dr.Item("name") = Trim(WrkName)
      dr.Item("addr") = Trim(WrkAddr)
      dr.Item("city") = Trim(WrkCity)
      dr.Item("dob") = WrkDOB
      dr.Item("msg") = WrkMsg
      mydsStatus.Tables(0).Rows.Add(dr)
End Sub
End Module






