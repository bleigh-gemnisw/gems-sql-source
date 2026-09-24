Imports System.io
Imports System.Text
Module PrintPutons

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVLM As TXINVLM.MyData
  Dim myTXINVLN As TXINVLN.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVEH As TXVEH.MyData
  Dim myTXVEHL2 As TXVEHL2.MyData
  Dim myTXVBUS As TXVBUS.MyData

  Dim mydsDMV As DataSet = New DataSet
  Dim dsMissing As DataSet = New DataSet
  Dim mydsStatus As DataSet = New DataSet
  Dim mydsDMVTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drinv As Data.DataRow

  Dim WrkGLYearFrom As Integer
  Dim WrkGLYearTo As Integer
  Dim WrkSelType As String
  Dim WrkPost As Boolean
  Dim WrkMass As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtPutons()
    Dim WrkAnswer As Integer

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINVLM = New TXINVLM.MyData(myDBConnect)
    myTXINVLN = New TXINVLN.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXVEHL2 = New TXVEHL2.MyData(myDBConnect)
    myTXVBUS = New TXVBUS.MyData(myDBConnect)

    With MyFrmTX407B
      WrkGLYearFrom = MyUtils.CnvSng(.TxtGLYearFrom.Text)
      WrkGLYearTo = MyUtils.CnvSng(.TxtGLYearTo.Text)
      If .RbMV.Checked Then
        WrkSelType = "M"
      End If
      If .RbSU.Checked Then
        WrkSelType = "S"
      End If
      If .RbBoth.Checked Then
        WrkSelType = ""
      End If
      WrkPost = .ChkPost.Checked
      WrkMass = .ChkMass.Checked
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

    If WrkMass And WrkPost Then
      If WrkGLYearFrom > 0 Or WrkGLYearTo > 0 Then
        WrkAnswer = MsgBox("This will CLEAR MV flags for ALL Grand List Years", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "WARNING: Mass Putons with a Year Range")
        If WrkAnswer = MsgBoxResult.Cancel Then Exit Sub
      End If
      MassFlagClear()
    End If

    If mydsDMV.Tables.Count = 0 Then
      BuildDs(mydsDMV)
      BuildDs2(dsMissing)
      mydsStatus = dsMissing.Clone
      InitCASHINT()
      'InitCASHDUE()
    Else
      mydsDMV.Clear()
      dsMissing.Clear()
      mydsStatus.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkPost = WrkPost
      .wrkds = mydsDMV
      .wrkds2 = dsMissing
      .wrkds3 = mydsStatus
      .WrkRpt = "Puton"
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter = New StreamWriter(MyFrmTX407B.LblFilePath.Text)
    Dim sw2 As StreamWriter = New StreamWriter(MyFrmTX407B.LblMissPath.Text)
    Dim dsveh As DataSet = New DataSet
    Dim dsinv As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim drSel() As DataRow
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkDue As Decimal
    Dim WrkList As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkVehID As Long
    Dim Good As Boolean
    Dim WrkFlagged As Boolean
    Dim SaveQry As String
    Dim WrkSelect As String
    Dim WrkGracePeriod As Boolean
    Dim Counter As Integer
    Dim I As Integer

    If WrkMass Then
      WrkQry = "bald > 0" & WrkAnd & "icode<>'I'" '& WrkAnd & "ilease=''"
    Else
      WrkQry = "bald > 0" & WrkAnd & "icode<>'I'" & WrkAnd & "mvflag<>'Y'" & WrkAnd & "mvflag<>'P'" _
   & WrkAnd & "mvflag<>'M'" '& WrkAnd & "ilease=''"
    End If

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

    WrkSort = "SS#"
    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      drinv = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(drinv)
        WrkList = ._LISTNo
        WrkType = ._TYPE
        WrkYear = ._YEAR
        CalcInterest(WrkList, WrkType, WrkYear, 0, 0, 0, 0, 0, 0, WrkDue, WrkGracePeriod, 0, "")
        'CalcDue(WrkList, WrkType, WrkYear, WrkDue)
        If WrkDue <= 0 Or WrkGracePeriod Then GoTo NextRec

        Good = False
        If ._SSNo > 0 And MyUtils.CnvSng(._OID) > 0 Then
          WrkFlagged = CheckDMVFLag(._SSNo, True)
          myTXVEH.GetOneRecordP(MyUtils.CnvSng(._OID))
          WrkVehID = MyUtils.CnvSng(._OID)
          If Not myTXVEH.RecordNotFound Then
            Good = True
            If Not WrkFlagged Then
              WrkSelect = "pcust=" & ._SSNo
              drSel = mydsDMV.Tables(0).Select(WrkSelect)
              If drSel.GetUpperBound(0) = -1 Then
                WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "DMV Put On")
                dr = mydsDMV.Tables(0).NewRow
                dr.Item("sel") = True
                dr.Item("pcust") = ._SSNo
                dr.Item("vehid") = myTXVEH._VEHID
                With myTXVCUS
                  .GetOneRecordP(myTXVEH._PCUST)
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
                sw.WriteLine(CreateDMV(._SSNo, myTXVEH._LEASE, WrkVehID))
              End If
            Else
              WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "Set Put On")
            End If

            If myTXVEH._SCUST > 0 Then
              Good = True
              WrkFlagged = CheckDMVFLag(._SS2, True)
              If Not WrkFlagged Then
                WrkSelect = "pcust=" & ._SS2
                drSel = mydsDMV.Tables(0).Select(WrkSelect)
                If drSel.GetUpperBound(0) = -1 Then
                  WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "DMV Put On2")
                  dr = mydsDMV.Tables(0).NewRow
                  dr.Item("sel") = True
                  dr.Item("pcust") = ._SS2
                  dr.Item("vehid") = WrkVehID
                  With myTXVCUS
                    .GetOneRecordP(myTXINVQ._SS2)
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
                  sw.WriteLine(CreateDMV(._SS2, myTXVEH._LEASE, myTXVEH._VEHID))
                End If
              Else
                WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "Set Put On2")
              End If
            End If
          End If
          If WrkPost And Good Then FlagPutons(._LISTNo, ._TYPE, ._YEAR, WrkVehID)
        End If

        If Not Good And ._SSNo > 0 Then
          WrkFlagged = CheckDMVFLag(._SSNo, True)
          ds3 = myTXVEHL2.GetViewbyPcust(._SSNo, 99999999, 100)
          If ds3.Tables(0).Rows.Count > 0 Then
            WrkVehID = ds3.Tables(0).Rows(0).Item("vehid")
            Good = True
            If Not WrkFlagged Then
              WrkSelect = "pcust=" & ._SSNo
              drSel = mydsDMV.Tables(0).Select(WrkSelect)
              If drSel.GetUpperBound(0) = -1 Then
                WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "DMV Put On")
                dr = mydsDMV.Tables(0).NewRow
                dr.Item("sel") = True
                dr.Item("pcust") = ._SSNo
                dr.Item("vehid") = WrkVehID
                With myTXVCUS
                  .GetOneRecordP(myTXINVQ._SSNo)
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
                sw.WriteLine(CreateDMV(._SSNo, ds3.Tables(0).Rows(0).Item("lease"), WrkVehID))
              End If
            Else
              WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "Set Put On")
            End If

            If ds3.Tables(0).Rows(0).Item("scust") > 0 Then
              Good = True
              WrkFlagged = CheckDMVFLag(._SS2, True)
              If Not WrkFlagged Then
                WrkSelect = "pcust=" & ._SS2
                drSel = mydsDMV.Tables(0).Select(WrkSelect)
                If drSel.GetUpperBound(0) = -1 Then
                  WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "DMV Put On2")
                  dr = mydsDMV.Tables(0).NewRow
                  dr.Item("sel") = True
                  dr.Item("pcust") = ._SS2
                  dr.Item("vehid") = WrkVehID
                  With myTXVCUS
                    .GetOneRecordP(myTXINVQ._SS2)
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
                  sw.WriteLine(CreateDMV(._SS2, ds3.Tables(0).Rows(0).Item("lease"), WrkVehID))
                End If
              Else
                WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "Set Put On2")
              End If
            End If
          Else
            WriteStatus(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, "Missing Vehicle")
          End If
        End If
        If Not Good Then
          WriteMissing(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, ._ADD1, ._CITY, ._DOB, "")
        End If
        If WrkPost And Good Then FlagPutons(._LISTNo, ._TYPE, ._YEAR, WrkVehID)
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
    Next

    sw.Close()
    sw2.Close()
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub FlagPutons(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkVehID As Long)
    Dim ds2 As DataSet = New DataSet

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    With myTXINV
      If MyUtils.CnvSng(._OID) <> WrkVehID Then
        ._OID = WrkVehID
      End If
      If ._SSNo > 0 Then
        ._MVFLAG = "Y"
      Else
        ._MVFLAG = "M"
      End If
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub MassFlagClear()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer

    WrkQry = "mvflag='Y'" & WrkOr & "mvflag='P'" & WrkOr & "mvflag='M'"
    WrkSort = ""
    ds2 = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
        myTXINV._MVFLAG = ""
        myTXINV.UpdateOneRecordP()
        Application.DoEvents()
      End With

      With myFrmProgress
        WrkPct = (I / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed(Clear): " & I
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()
  End Sub
  Private Function ChkCompany(ByVal WrkName As String) As Boolean

    Dim ds3 As DataSet = New DataSet
    Dim I As Integer
    Dim Pos As Integer
    Dim WrkStr As String
    Dim WrkStrLen As Integer

    ds3 = myTXVBUS.PosData("")
    WrkName = Trim(WrkName)

ReadNext:
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      With ds3.Tables(0).Rows(I)
        WrkStr = " " & .Item("word")
        WrkStrLen = Len(WrkStr)
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            Return True
            Exit For
          End If
        End If

        WrkStr = " " & .Item("word") & " "
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          Return True
          Exit For
        End If

        WrkStr = " " & .Item("word") & "-"
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        If Pos > 0 Then
          Return True
          Exit For
        End If

        WrkStr = "-" & .Item("word")
        Pos = InStr(WrkName, WrkStr, CompareMethod.Text)
        WrkStrLen = Len(WrkStr)
        If Pos > 0 Then
          If Pos + WrkStrLen = Len(WrkName) + 1 Then
            Return True
            Exit For
          End If
        End If

        WrkStr = .Item("word")
        If UCase(WrkStr) = WrkName Then
          Return True
          Exit For
        End If
      End With
    Next

    Return False

  End Function
  Private Function CheckDMVFLag(ByVal WrkCust As Integer, ByVal WrkPrimary As Boolean) As Boolean
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim Found As Boolean

    Found = False
    If WrkCust = 0 Then Return False
    If WrkPrimary Then
      ds2 = myTXINVLM.GetAllSSNo(WrkCust, 5000, False)
    Else
      ds2 = myTXINVLN.GetAllSS2(WrkCust, 5000, False)
    End If
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("mvflag") = "Y" Then
        Found = True
      End If
    Next
    ds2 = Nothing

    Return Found
  End Function
  Private Sub WriteStatus(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String,
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
  Private Sub WriteMissing(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String,
  ByVal WrkYear As Integer, ByVal WrkName As String, ByVal WrkAddr As String, ByVal WrkCity As String,
  ByVal WrkDOB As Integer, ByVal WrkMsg As String)
    dr = dsMissing.Tables(0).NewRow
    dr.Item("regno") = WrkRegno
    dr.Item("list") = WrkList
    dr.Item("type") = WrkType
    dr.Item("year") = WrkYear
    dr.Item("name") = Trim(WrkName)
    dr.Item("addr") = Trim(WrkAddr)
    dr.Item("city") = Trim(WrkCity)
    dr.Item("dob") = WrkDOB
    dr.Item("msg") = WrkMsg
    dsMissing.Tables(0).Rows.Add(dr)
  End Sub
  Private Function CreateDMV(ByVal WrkCustID As Integer, ByVal WrkLease As String, ByVal WrkVehId As Integer) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkCustFmt As String

    WrkCustFmt = Format(WrkCustID, "0000000000")
    sb = New StringBuilder
    sb.Append(Date.Today.Year)
    sb.Append(Format(Date.Today.Month, "00"))
    sb.Append(Format(Date.Today.Day, "00"))
    sb.Append("A") 'Add
    sb.Append(WrkCustFmt)
    sb.Append(WrkLease)
    sb.Append(Format(WrkVehId, "000000000"))
    sb.Append(Format(myTOWN._TOWNBR, "000"))
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr

  End Function
  Private Function CreateMissing(ByVal WrkList As Integer, ByVal WrkType As String,
  ByVal WrkYear As Integer) As String
    Dim sb As StringBuilder
    Dim WrkFirstName As String
    Dim WrkLastName As String
    Dim Pos As Integer
    Dim Pos2 As Integer
    Dim WrkStr As String

    With myTXINV
      .GetOneRecordP(WrkList, WrkYear, WrkType)
      WrkLastName = ""
      WrkFirstName = ""
      If ChkCompany(._NAME) Then
        WrkLastName = ._NAME
      Else
        Pos = InStr(._NAME, " ")
        WrkLastName = Mid(._NAME, 1, Pos - 1)
        Pos2 = InStr(Pos + 1, ._NAME, " ")
        If Pos2 > 0 Then
          WrkFirstName = Mid(._NAME, Pos + 1)
        Else
          WrkFirstName = Mid(._NAME, Pos + 1, Pos2 - Pos)
        End If
      End If
      sb = New StringBuilder
      sb.Append(MyUtils.JustifyLeft(WrkLastName, 80))
      sb.Append(MyUtils.JustifyLeft(WrkFirstName, 80))
      If myTXINVQ._DOB > 0 Then
        sb.Append(myTXINVQ._DOB)
      Else
        sb.Append(Space(8))
      End If
      sb.Append(MyUtils.JustifyLeft(._IMVREG, 9))
      sb.Append(MyUtils.JustifyLeft(._ADD1, 50))
      sb.Append(MyUtils.JustifyLeft(._ADD2, 50))
      sb.Append(MyUtils.JustifyLeft(._CITY, 20))
      sb.Append(._STATE)
      If myTXINVQ._ZIP5 > 0 Then
        sb.Append(Format(._ZIP5, "00000"))
      Else
        sb.Append(Space(5))
      End If
      If myTXINVQ._ZIP4 > 0 Then
        sb.Append(Format(._ZIP4, "0000"))
      Else
        sb.Append(Space(4))
      End If
    End With
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr

  End Function
End Module






