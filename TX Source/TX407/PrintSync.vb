Imports System.IO
Imports System.Text
Module PrintSync

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXINVLM As TXINVLM.myData
Dim myTXINVLN As TXINVLN.myData
Dim myTXINVL8 As TXINVL8.myData
Dim myTXINV As TXINV.myData
Dim myTXVCUS As TXVCUS.myData
Dim myTXVEHL2 As TXVEHL2.myData

Dim mydsDMV As DataSet = New DataSet
Dim dsHold As DataSet = New DataSet
Dim mydsStatus As DataSet = New DataSet
Dim dsDT As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim mydsDMVTXINV As DataSet = New DataSet
Dim dr As Data.DataRow
Dim sw As StreamWriter

Dim WrkGLYearFrom As Integer
Dim WrkGLYearTo As Integer
Dim WrkSelType As String
Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
  Public Sub PrtSync()
  myTXINVQ = New TXINVQ.mydata(MyDBConnect)
  myTXINVLM = New TXINVLM.mydata(MyDBConnect)
  myTXINVLN = New TXINVLN.mydata(MyDBConnect)
  myTXINVL8 = New TXINVL8.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXVCUS = New TXVCUS.mydata(MyDBConnect)
  myTXVEHL2 = New TXVEHL2.mydata(MyDBConnect)

  With MyFrmTX407B
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
    BuildDsDT(dsDT)
  Else
    mydsDMV.Clear()
    dsDT.Clear()
  End If

  sw = New StreamWriter(MyFrmTX407B.LblFilePath.Text)
  BufferDT()
  GetPuton()
  GetTakeoff()
  sw.Close()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .WrkPost = WrkPost
    .wrkds = mydsDMV
    .WrkRpt = "Sync"
    .Show()
  End With

  End Sub
Public Sub BuildDsDT(ByRef Ds As DataSet)
  Dim myTable As New DataTable
  With myTable
    .TableName = "mytable"
    .Columns.Add("CustID", Type.GetType("System.Int32"))
    .Columns.Add("Name", Type.GetType("System.String"))
    .Columns.Add("DOB", Type.GetType("System.String"))
    .Columns.Add("VehID", Type.GetType("System.Int32"))
  End With
  Ds.Tables.Add(myTable)
End Sub
Friend Sub BufferDT()
  Dim WrkStream As FileStream = New FileStream(MyFrmTX407B.LblSyncPath.Text, FileMode.Open, FileAccess.Read)
  Dim sr As StreamReader = New StreamReader(WrkStream)
  Dim WrkFileSize As Integer
  Dim StrBuffer As String
  Dim Sarray As String()
  Dim I As Integer

  myFrmProgress = New FrmProgress
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  WrkFileSize = WrkStream.Length
  StrBuffer = sr.ReadLine

NextLine:
  strBuffer = sr.ReadLine
  If Trim(StrBuffer) = String.Empty Then
    GoTo CloseFile
  End If
  I = I + StrBuffer.Length
  SArray = Parse(StrBuffer, ",")
  dr = dsDT.Tables(0).NewRow
  dr.Item("custid") = MyUtils.CnvSng(Sarray(2))
  If Sarray(4) <> "" Then
    dr.Item("name") = Sarray(3) & " " & Sarray(4)
  Else
    dr.Item("name") = Sarray(3)
  End If
  dr.Item("dob") = Sarray(5)
  dr.Item("vehid") = MyUtils.CnvSng(Sarray(6))
  dsDT.Tables(0).Rows.Add(dr)

NextRec:
With myFrmProgress
  WrkPct = (I / WrkFileSize) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
GoTo NextLine

CloseFile:
sr.Close()
myFrmProgress.Close()

End Sub
Private Sub GetPuton()
Dim WrkQry As String
Dim WrkSort As String
Dim drSel() As DataRow
Dim WrkSelect As String
Dim ds4 As DataSet = New DataSet
Dim SaveCust As Integer
Dim Counter As Integer
Dim WrkSuscd As Boolean

WrkQry = "MVFLAG='Y'" & WrkAnd & "SS#>0" & WrkOr & "MVFLAG='P'" & WrkAnd & "SS#>0"
WrkSort = "SS#"
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveCust = 0
ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
  With myTXINVQ
    Counter = Counter + 1
    'Filter Suspense Codes
    WrkSuscd = False
    With MyFrmTX407B
      If .TxtReason1.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason1.Text) Then WrkSuscd = True
      End If
      If .TxtReason2.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason2.Text) Then WrkSuscd = True
      End If
      If .TxtReason3.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason3.Text) Then WrkSuscd = True
      End If
      If .TxtReason4.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason4.Text) Then WrkSuscd = True
      End If
      If .TxtReason5.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason5.Text) Then WrkSuscd = True
      End If
      If .TxtReason6.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason6.Text) Then WrkSuscd = True
      End If
      If .TxtReason7.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason7.Text) Then WrkSuscd = True
      End If
      If .TxtReason8.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason8.Text) Then WrkSuscd = True
      End If
      If .TxtReason9.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason9.Text) Then WrkSuscd = True
      End If
      If .TxtReason10.Text <> "" Then
        If myTXINVQ._SUSCD = MyUtils.Quo(.TxtReason10.Text) Then WrkSuscd = True
      End If
    End With
    If WrkSuscd Then
      GoTo NextRec
    End If
    If SaveCust <> ._SSNo Then
      WrkSelect = "custid=" & ._SSNo
      drSel = dsDT.Tables(0).Select(WrkSelect)
      If drSel.GetUpperBound(0) = -1 Then
        dr = mydsDMV.Tables(0).NewRow
        dr.Item("sel") = True
        dr.Item("pcust") = ._SSNo
        ds4 = myTXVEHL2.GetViewbyPcust(._SSNo, 99999999, 1)
        If ds4.Tables(0).Rows.Count > 0 Then
          dr.Item("vehid") = ds4.Tables(0).Rows(0).Item("vehid")
          With myTXVCUS
            .GetOneRecordP(myTXINVQ._SSNo)
            dr.Item("dmvname") = Trim(._NAME)
            dr.Item("dmvaddr") = Trim(._ADD1)
            dr.Item("dmvcity") = Trim(._CITY)
            dr.Item("dmvst") = Trim(._STATE)
            dr.Item("dmvzip") = Trim(._ZIPA)
          End With
          dr.Item("msg") = Trim("Put on")
          mydsDMV.Tables(0).Rows.Add(dr)
          sw.WriteLine(CreateDMV(._SSNo, ds4.Tables(0).Rows(0).Item("lease"), ds4.Tables(0).Rows(0).Item("vehid"), True))
        End If
      Else
        drSel(0).Delete()
      End If
    End If
    SaveCust = ._SSNo
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

myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Sub GetTakeoff()
  Dim ds4 As DataSet = New DataSet
  Dim WrkMVFlag As Boolean
  Dim I As Integer

  myFrmProgress = New FrmProgress
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  For I = 0 To dsDT.Tables(0).Rows.Count - 1
    With dsDT.Tables(0).Rows(I)
      WrkMVFlag = CheckMVFlag(.Item("custid"), True)
      If Not WrkMVFlag Then
        WrkMVFlag = CheckMVFlag(.Item("custid"), False)
      End If
      If Not WrkMVFlag Then
        dr = mydsDMV.Tables(0).NewRow
        dr.Item("sel") = True
        dr.Item("pcust") = .Item("custid")
        dr.Item("vehid") = .Item("vehid")
        dr.Item("dmvname") = .Item("name")
        dr.Item("dmvaddr") = ""
        dr.Item("dmvcity") = ""
        dr.Item("dmvst") = ""
        dr.Item("dmvzip") = ""
        dr.Item("msg") = Trim("Takeoff")
        mydsDMV.Tables(0).Rows.Add(dr)
        sw.WriteLine(CreateDMV(.Item("custid"), "N", .Item("vehid"), False))
      End If
    End With

NextRec:
    With myFrmProgress
      WrkPct = (I / 10) Mod 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .LblMsg.Text = "Records processed(2/2): " & I
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
  Next

myFrmProgress.Close()
End Sub

Private Function CreateDMV(ByVal WrkCustID As Integer, ByVal WrkLease As String, ByVal WrkVehId As Integer, ByVal WrkAdd As Boolean) As String
  Dim sb As StringBuilder
  Dim WrkStr As String
  Dim WrkCustFmt As String

  WrkCustFmt = Format(WrkCustID, "0000000000")
  sb = New StringBuilder
  sb.Append(Date.Today.Year)
  sb.Append(Format(Date.Today.Month, "00"))
  sb.Append(Format(Date.Today.Day, "00"))
  If WrkAdd Then
    sb.Append("A")
  Else
    sb.Append("D")
  End If
  sb.Append(WrkCustFmt)
  sb.Append(WrkLease)
  sb.Append(Format(WrkVehId, "000000000"))
  sb.Append(Format(myTOWN._TOWNBR, "000"))
  WrkStr = sb.ToString
  sb = Nothing
  Return WrkStr

End Function
Private Function CheckMVFlag(ByVal WrkCust As Integer, ByVal WrkPrimary As Boolean) As Boolean
  Dim ds2 As DataSet = New DataSet
  Dim I As Integer

  If WrkCust = 0 Then Return False

  If WrkPrimary Then
    ds2 = myTXINVLM.GetAllSSNo(WrkCust, 5000, False)
  Else
    ds2 = myTXINVLN.GetAllSS2(WrkCust, 5000, False)
  End If
  For I = 0 To ds2.Tables(0).Rows.Count - 1
    If ds2.Tables(0).Rows(I).Item("mvflag") = "Y" Or ds2.Tables(0).Rows(I).Item("mvflag") = "P" Then
      Return True
    End If
  Next
  ds2 = Nothing
  Return False
End Function
End Module







