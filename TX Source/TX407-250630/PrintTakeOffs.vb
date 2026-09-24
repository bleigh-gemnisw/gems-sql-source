Imports System.Collections.Generic

Module PrintTakeOffs

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVLM As TXINVLM.MyData
  Dim myTXINVLN As TXINVLN.MyData
  Dim myTXVEHL1 As TXVEHL1.MyData
  Dim myTXVEHL2 As TXVEHL2.MyData
  Dim myTXVCUS As TXVCUS.MyData

  Public mydsDMV As DataSet = New DataSet
  Public mydsStatus As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkDays As Integer
  Dim WrkMethod As String
  Dim WrkAnd As String
  Dim WrkOr As String

  Dim SaveCust As Integer
  Public Sub PrtTakeOffs()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINVLM = New TXINVLM.MyData(myDBConnect)
    myTXINVLN = New TXINVLN.MyData(myDBConnect)
    myTXVEHL1 = New TXVEHL1.MyData(myDBConnect)
    myTXVEHL2 = New TXVEHL2.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)

    With MyFrmTX407B
    End With

    If mydsDMV.Tables.Count = 0 Then
      BuildDs(mydsDMV)
      BuildDs2(mydsStatus)
      InitCASHDUE()
    Else
      mydsDMV.Clear()
      mydsStatus.Clear()
    End If

    If MyAppSettings.DaysCheck <> MyUtils.CnvSng(MyFrmTX407B.TxtDaysCheck.Text) Or
     MyAppSettings.DaysECheck <> MyUtils.CnvSng(MyFrmTX407B.TxtDaysECheck.Text) Or
     MyAppSettings.DaysCredit <> MyUtils.CnvSng(MyFrmTX407B.TxtDaysCredit.Text) Then
      MyAppSettings.DaysCheck = MyUtils.CnvSng(MyFrmTX407B.TxtDaysCheck.Text)
      MyAppSettings.DaysECheck = MyUtils.CnvSng(MyFrmTX407B.TxtDaysECheck.Text)
      MyAppSettings.DaysCredit = MyUtils.CnvSng(MyFrmTX407B.TxtDaysCredit.Text)
      SaveAppSettings()
    End If
    GetDetail()

    MyFrmTX407C = New FrmTX407C
    MyFrmTX407C.MdiParent = MyFrmTX407
    MyFrmTX407C.Show()
    MyFrmTX407B.Hide()

  End Sub
  Private Sub GetDetail()
    Dim drSel() As DataRow
    Dim WrkSelect As String
    Dim WrkQry As String
    Dim WrkFields As String
    Dim WrkSort As String
    Dim WrkBalance As Boolean
    Dim WrkBalance2 As Boolean
    Dim Counter As Integer

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

    WrkQry = "mvflag='Y'" & WrkOr & "mvflag='P'"
    'WrkQry = "list#=727881 And type='M' and year=2023"
    WrkSort = "SS#, IMVREG, YEAR"
    WrkFields = "SS#, SS2, NEWPAY, LIST#, TYPE, YEAR, NAME, ADD1, CITY, DOB"
    myTXINVQ.OpenQry(WrkSort, WrkQry, WrkFields)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveCust = 0
    Counter = 0

ReadNext:
    myTXINVQ.ReadQry(WrkFields)
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        WrkDays = 0
        WrkMethod = ""
        If ._SS2 > 0 Then
          WrkSelect = "pcust=" & ._SS2
          drSel = mydsDMV.Tables(0).Select(WrkSelect)
          If drSel.GetUpperBound(0) = -1 Then
            WrkBalance2 = CheckBalance(._SS2, True)
            If Not WrkBalance2 Then
              WrkBalance2 = CheckBalance(._SS2, False)
            End If
            If Not WrkBalance2 Then
              BuildDmv(._SSNo, ._SS2)
            End If
          End If
        End If

        If SaveCust <> ._SSNo Then
          WrkBalance = CheckBalance(._SSNo, True)
          If Not WrkBalance Then
            WrkBalance = CheckBalance(._SSNo, False)
          End If
          If Not WrkBalance Then
            BuildDmv(._SSNo, ._SSNo)
          End If
        End If
        SaveCust = ._SSNo
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
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Function CheckBalance(ByVal WrkCust As Integer, ByVal WrkPrimary As Boolean) As Boolean
    Dim ds2 As DataSet = New DataSet
    Dim WrkDue As Decimal
    Dim WrkGracePeriod As Boolean
    Dim TempDays As Integer
    Dim TempMethod As String
    Dim I As Integer

    If WrkCust = 0 Then Return False
    TempDays = 0
    TempMethod = ""
    If WrkPrimary Then
      ds2 = myTXINVLM.GetAllSSNo(WrkCust, 5000, False)
    Else
      ds2 = myTXINVLN.GetAllSS2(WrkCust, 5000, False)
    End If
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      WrkDue = 0
      CalcDue(ds2.Tables(0).Rows(I).Item("list#"), ds2.Tables(0).Rows(I).Item("type"),
      ds2.Tables(0).Rows(I).Item("year"), 0, 0, 0, 0, WrkDue, WrkGracePeriod, TempDays, TempMethod)
      If WrkDue > 0 And Not WrkGracePeriod Then
        Return True
      End If
      If TempDays >= 0 Then
        If WrkMethod = "" Then
          WrkDays = TempDays
          WrkMethod = TempMethod
        End If
        If WrkDays > TempDays Then
          WrkDays = TempDays
          WrkMethod = TempMethod
        End If
      End If
    Next
    ds2 = Nothing

    Return False
  End Function
  Private Sub BuildDmv(ByVal WrkCust As Integer, ByVal WrkCust2 As Integer)
    Dim dstemp As DataSet = New DataSet
    Dim WrkVehid As Integer
    Dim WrkLease As String
    Dim I As Integer

    WrkLease = ""
    dstemp = myTXVEHL2.GetViewbyPcust(WrkCust, 99999999, 0)
    If dstemp.Tables(0).Rows.Count > 0 Then
      For I = 0 To dstemp.Tables(0).Rows.Count - 1
        If dstemp.Tables(0).Rows(I).Item("scust") = WrkCust2 Then
          WrkVehid = dstemp.Tables(0).Rows(I).Item("vehid")
          WrkLease = dstemp.Tables(0).Rows(I).Item("lease")
          Exit For
        End If
      Next
    End If
    If WrkVehid = 0 And dstemp.Tables(0).Rows.Count > 0 Then
      WrkVehid = dstemp.Tables(0).Rows(0).Item("vehid")
      WrkLease = dstemp.Tables(0).Rows(0).Item("lease")
    End If

    dr = mydsDMV.Tables(0).NewRow
    dr.Item("sel") = False
    If WrkVehid > 0 Then
      Select Case WrkMethod
        Case "1", "Cash"
          dr.Item("sel") = True
        Case "2", "Check"
          If WrkDays >= MyAppSettings.DaysCheck Then
            dr.Item("sel") = True
          End If
        Case "ECheck"
          If WrkDays >= MyAppSettings.DaysECheck Then
            dr.Item("sel") = True
          End If
        Case "3", "Credit"
          If WrkDays >= MyAppSettings.DaysCredit Then
            dr.Item("sel") = True
          End If
      End Select
    End If
    dr.Item("pcust") = WrkCust2
    dr.Item("vehid") = WrkVehid
    With myTXVCUS
      .GetOneRecordP(WrkCust2)
      dr.Item("dmvname") = Trim(._NAME)
      dr.Item("dmvaddr") = Trim(._ADD1)
      dr.Item("dmvcity") = Trim(._CITY)
      dr.Item("dmvst") = Trim(._STATE)
      dr.Item("dmvzip") = Trim(._ZIPA)
    End With
    With myTXINVQ
      If ._NEWPAY = 0 Then
        dr.Item("days") = WrkDays
        dr.Item("method") = WrkMethod
      Else
        dr.Item("days") = 0
        dr.Item("method") = "Unposted"
        dr.Item("sel") = False
      End If
      dr.Item("list") = ._LISTNo
      dr.Item("type") = ._TYPE
      dr.Item("year") = ._YEAR
      dr.Item("name") = Trim(._NAME)
      dr.Item("addr") = Trim(._ADD1)
      dr.Item("city") = Trim(._CITY)
      dr.Item("dob") = ._DOB
    End With
    If Trim(WrkLease) = "" Then
      WrkLease = "N"
    End If
    dr.Item("lease") = WrkLease
    If WrkVehid > 0 Then
      dr.Item("msg") = ""
    Else
      dr.Item("msg") = "No VehicleID"
    End If
    mydsDMV.Tables(0).Rows.Add(dr)
  End Sub
End Module






