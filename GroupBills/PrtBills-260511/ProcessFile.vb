Imports System.io
Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim myDBUtils As DBUtils
Dim myDBUtils2 As DBUtils
Dim dsBill As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim WrkFile As String
Dim WrkTownNo As String
Dim WrkSelGroupID As String
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkPostNet As String
Dim WrkPostID As Integer
Dim WrkGroupID As String
Dim WrkGroup12 As String
Dim WrkTotTax As Decimal
Dim WrkMaxRecs As Integer
Dim WrkSewer As Boolean
  Public Sub ProcBills()
    With MyFrmMainB
      If MyAppSettings.IsRPM Then
        WrkFile = .LblName.Text
      Else
        WrkFile = .LblName.Text & "2"
      End If
      WrkTownNo = .TxtTownNo.Text
      WrkSelGroupID = .TxtGroupID.Text
    End With

    If WrkFile = String.Empty Then
      Exit Sub
    End If

    WrkSewer = False
    If CnvSng(WrkTownNo) = 84 Then
      WrkSewer = True
    End If

    If dsBill.Tables.Count = 0 Then
      If MyFrmMainB.RbPrint.Checked Then
        BuildDSBill(dsBill, True, WrkSewer)
      Else
        BuildDSBill(dsBill, False, WrkSewer)
      End If
      BuildDSTot(dsTot)
    Else
      dsBill.Clear()
      dsTot.Clear()
    End If
    PrintBills()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkdsBill = dsBill
    .wrkdsTot = dsTot
    .WrkTotTax = WrkTotTax
    .Show()
  End With
End Sub
Private Sub SetNCOA(ByVal WrkFileNCOA As String)
Dim ds As DataSet = New DataSet
Dim WrkStream As FileStream = New FileStream(WrkFileNCOA, FileMode.Open, FileAccess.Read, FileShare.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim strBuffer As String
Dim sArray As String()
Dim WrkFileSize As Integer
Dim WrkQry As String
Dim I As Integer
Dim Counter As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myDBUtils = New DBUtils
Counter = 0
WrkFileSize = WrkStream.Length

'Skip Header record
strBuffer = sr.ReadLine

NextLine:
  strBuffer = sr.ReadLine
  If strBuffer Is Nothing Then
    GoTo Cleanup
  End If
  I = I + Len(strBuffer)
  Counter = Counter + 1
  sArray = Parse(strBuffer, ",")
  WrkQry = "POSTID=" & sArray(0)
  ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
  ds.Tables(0).Rows(0).Item("PostBarCode") = sArray(2)
  ds.Tables(0).Rows(0).Item("PostEndorse") = sArray(3)
  ds.Tables(0).Rows(0).Item("PostSort") = sArray(1)
  myDBUtils.UpdateOneRecordP(WrkFile, ds)

nextrecord:
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

CleanUp:
myFrmProgress.Close()

End Sub
Private Sub PrintBills()
Dim sw As StreamWriter = New StreamWriter(MyFrmMainB.LblFilePathNCOA.Text)
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim sArray As String()
Dim Counter As Integer
Dim WrkFileName As String
Dim WrkRecNo As Integer
Dim SaveGroup As Integer
Dim WrkCount As Integer
Dim WrkCountBank As Integer
Dim WrkStrPage As Integer
Dim WrkStr As String
Dim WrkPageNo As Integer
Dim I As Integer
Dim J As Integer
Dim WrkQry As String
Dim WrkZip As String

myDBUtils = New DBUtils
myDBUtils2 = New DBUtils

WrkQry = "PostID > 0"
If WrkSelGroupID <> "" Then
  WrkQry = WrkQry & " and GroupID = " & WrkSelGroupID
End If
If MyFrmMainB.RbPrint.Checked Then
  ds = myDBUtils.GetQry(WrkFile, "BKCD, GroupID DESC, postsort", WrkQry, 0)
Else
  ds = myDBUtils.GetQry(WrkFile, "BKCD, GroupID DESC, Group1, Group2", "PostID > 0", 0)
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()
WrkCount = 0
WrkCountBank = 0
WrkPageNo = 0
WrkStrPage = 1
WrkTotTax = 0
MyStateMillrt = ""
MyStateMoney = ""

WrkStr = BuildNCOAHdr()
sw.WriteLine(WrkStr)
If CnvSng(MyFrmMainB.TxtMaxRecs.Text) = 0 Then
  WrkMaxRecs = ds.Tables(0).Rows.Count - 1
Else
  WrkMaxRecs = CnvSng(MyFrmMainB.TxtMaxRecs.Text)
End If

  For I = 0 To WrkMaxRecs
    With ds.Tables(0).Rows(I)
      WrkQry = "GROUP1=" & Quo(.Item("group1")) & " and GROUP2=" & Quo(.Item("group2"))
      ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
      If ds2.Tables(0).Rows.Count > 1 Then
        For J = 0 To ds2.Tables(0).Rows.Count - 1
          With ds2.Tables(0).Rows(J)
            If .Item("postid") > 0 Then Continue For
            WrkFileName = ""
            Select Case .Item("type")
            Case "P"
              WrkFileName = MyFrmMainB.LblFilePathPP.Text
            Case "R"
              WrkFileName = MyFrmMainB.LblFilePathRE.Text
            Case "M"
              WrkFileName = MyFrmMainB.LblFilePathMV.Text
            Case "S"
              WrkFileName = MyFrmMainB.LblFilePathMS.Text
            End Select
            If WrkFileName = String.Empty Then GoTo NextRec
            WrkRecNo = .Item("recid")
            WrkPostNet = .Item("postbarcode")
            WrkPostID = 0
            WrkGroupID = .Item("groupid")
            WrkGroup12 = .Item("group1") & " " & .Item("group2")
            sArray = GetRecord(WrkFileName, WrkRecNo)
            Select Case .Item("type")
            Case "R"
              CrtREBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
            Case "P"
              CrtPPBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
            Case "M"
              CrtMVBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
            Case "S"
              CrtMSBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
            End Select
            WrkPageNo = WrkPageNo + 1
            UpdateFile(.Item("type"), .Item("recid"), WrkPageNo)
            WrkZip = .Item("zip")
            If .Item("zip4") <> "" Then
              WrkZip = WrkZip & "-" & .Item("zip4")
            End If
            If .Item("addr") <> sArray(6) Or .Item("addr2") <> sArray(7) Or .Item("town") <> sArray(8) _
             Or .Item("state") <> sArray(9) Or CnvSng(.Item("zip")) <> CnvSng(sArray(10)) _
             Or CnvSng(.Item("zip4")) <> CnvSng(sArray(11)) Then
               WrkStr = BuildNCOA(sArray, .Item("type"), .Item("name"), .Item("addr"), _
                .Item("addr2"), .Item("town"), .Item("state"), WrkZip)
              sw.WriteLine(WrkStr)
            End If
          End With
        Next
      End If

     'Write Header Bill Last
      If .Item("groupid") <> String.Empty Then
        If SaveGroup > 0 And SaveGroup <> .Item("groupid") Then
          WriteTot(WrkCount, SaveGroup, WrkStrPage)
          WrkStrPage = WrkStrPage + (WrkCount * SaveGroup)
          WrkCount = 0
        End If
        WrkCount = WrkCount + 1
        SaveGroup = .Item("groupid")
      Else
        WrkCountBank = WrkCountBank + 1
      End If
      WrkFileName = ""
      Select Case .Item("type")
      Case "R"
        WrkFileName = MyFrmMainB.LblFilePathRE.Text
      Case "P"
        WrkFileName = MyFrmMainB.LblFilePathPP.Text
      Case "M"
        WrkFileName = MyFrmMainB.LblFilePathMV.Text
      Case "S"
        WrkFileName = MyFrmMainB.LblFilePathMS.Text
      End Select
      If WrkFileName = String.Empty Then GoTo NextRec
      WrkRecNo = .Item("recid")
      WrkPostNet = .Item("postbarcode")
      WrkPostID = .Item("postid")
      WrkGroupID = .Item("groupid")
      WrkGroup12 = .Item("group1") & " " & .Item("group2")
      sArray = GetRecord(WrkFileName, WrkRecNo)
      Select Case .Item("type")
        Case "R"
          CrtREBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
        Case "P"
          CrtPPBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
        Case "M"
          CrtMVBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
        Case "S"
          CrtMSBill(sArray, .Item("addr"), .Item("addr2"), .Item("town"), .Item("state"), CnvSng(.Item("zip")), CnvSng(.Item("zip4")))
      End Select
      WrkPageNo = WrkPageNo + 1
      UpdateFile(.Item("type"), .Item("recid"), WrkPageNo)
      WrkZip = .Item("zip")
      If .Item("zip4") <> "" Then
        WrkZip = WrkZip & "-" & .Item("zip4")
      End If
      If .Item("addr") <> sArray(6) Or .Item("addr2") <> sArray(7) Or .Item("town") <> sArray(8) _
       Or .Item("state") <> sArray(9) Or CnvSng(.Item("zip")) <> CnvSng(sArray(10)) _
       Or CnvSng(.Item("zip4")) <> CnvSng(sArray(11)) Then
        sw.WriteLine(WrkStr)
      End If
    End With
    Counter = Counter + 1

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

End_of_file:
WriteTot(WrkCount, SaveGroup, WrkStrPage)
WriteTot(WrkCountBank, 999, 0)
sw.Close()

If MyFrmMainB.RbExport.Checked Then
  If MyFrmMainB.LblFilePathExport.Text <> "" Then
    WriteExport()
  End If
End If
MyStateMillrt = dsBill.Tables(0).Rows(0).Item("millrtbefore")
If MyStateMillrt = "" Then MyStateMillrt = "0"
MyStateMoney = dsBill.Tables(0).Rows(0).Item("taxbase")
If MyStateMoney = "" Then MyStateMoney = "0"
myFrmProgress.Close()
End Sub
Private Function GetRecord(ByVal WrkFileName As String, ByVal RecNo As Integer) As Array
Dim WrkStream As FileStream = New FileStream(WrkFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim strBuffer As String
Dim sArray As String()
Dim Counter As Integer

'Skip Header record
strBuffer = sr.ReadLine
Counter = 0

NextLine:
  strBuffer = sr.ReadLine
  If strBuffer Is Nothing Then
    Return sArray
  End If
  Counter = Counter + 1
  If Counter <> RecNo Then
    GoTo NextLine
  End If
  sArray = Parse(strBuffer, ",")

  Return sArray
End Function
Private Sub CrtREBill(ByVal sArray() As String, ByVal Addr As String, ByVal Addr2 As String, ByVal Town As String, _
  ByVal State As String, ByVal Zip As Integer, ByVal Zip4 As Integer)
  'Create Billing File
  Dim drBill As DataRow
  Dim AddrLine() As String
  drBill = dsBill.Tables(0).NewRow
  drBill.Item("BillType") = sArray(3)
  drBill.Item("BillDesc") = "REAL ESTATE BILL"
  drBill.Item("listno") = sArray(1)
  drBill.Item("year") = sArray(2)
  drBill.Item("acct") = Mid(sArray(2), 3, 2) & sArray(3) & sArray(1)
  AddrLine = SetAddrLine(sArray(4), sArray(5), Addr, Addr2, _
    Town, State, Zip, Zip4)
  If MyFrmMainB.RbPrint.Checked Then
    drBill.Item("addr1") = AddrLine(0)
    drBill.Item("addr2") = AddrLine(1)
    drBill.Item("addr3") = AddrLine(2)
    drBill.Item("addr4") = AddrLine(3)
    drBill.Item("addr5") = AddrLine(4)
  Else
    drBill.Item("name") = sArray(4)
    drBill.Item("sname") = sArray(5)
    drBill.Item("addr") = Addr
    drBill.Item("addr2") = Addr2
    drBill.Item("city") = Town
    drBill.Item("state") = State
    If Zip4 > 0 Then
      drBill.Item("zipa") = Format(Zip, "00000") & "-" & Format(Zip4, "0000")
    Else
      drBill.Item("zipa") = Format(Zip, "00000")
    End If
  End If
  drBill.Item("bank") = sArray(20)
  drBill.Item("gross") = sArray(15)
  drBill.Item("exemption") = sArray(16)
  drBill.Item("net") = sArray(17)
  drBill.Item("taxtot") = sArray(12)
  drBill.Item("tax1st") = sArray(13)
  drBill.Item("tax2nd") = sArray(14)
  drBill.Item("stbenefit") = sArray(30)
  drBill.Item("townbenefit") = sArray(43)
  drBill.Item("propdesc") = Trim(sArray(18)) & " " & sArray(19)
  drBill.Item("addldesc") = sArray(36)
  drBill.Item("addldesc2") = sArray(37)
  If sArray(0) = "BT" Then
    drBill.Item("backtax") = True
  Else
    drBill.Item("backtax") = False
  End If
  drBill.Item("barcode") = sArray(61)
  drBill.Item("groupid") = WrkGroupID
  drBill.Item("group12") = WrkGroup12
  drBill.Item("postnet") = WrkPostNet
  drBill.Item("postid") = WrkPostID
  drBill.Item("scanline") = sArray(44)
  drBill.Item("ccno") = sArray(34)
  drBill.Item("ccdesc") = sArray(33)
  If Trim(sArray(35)) <> "" Then
    drBill.Item("ccdate") = sArray(35)
  End If
  drBill.Item("millrt") = sArray(25)
  drBill.Item("taxbase") = sArray(38)
  drBill.Item("millrtbefore") = sArray(39)
  drBill.Item("maplot") = sArray(21)
  drBill.Item("lease") = ""
  If WrkSewer Then
    drBill.Item("sewertot") = sArray(45)
    drBill.Item("sewer1st") = sArray(46)
    drBill.Item("sewer2nd") = sArray(47)
    drBill.Item("combtot") = sArray(50)
    drBill.Item("comb1st") = sArray(51)
    drBill.Item("comb2nd") = sArray(52)
  End If
  drBill.Item("taxwouldbe") = sArray(28)
  dsBill.Tables(0).Rows.Add(drBill)
  WrkTotTax = WrkTotTax + CnvSng(sArray(12))
End Sub
Private Sub CrtPPBill(ByVal sArray() As String, ByVal Addr As String, ByVal Addr2 As String, ByVal Town As String, _
  ByVal State As String, ByVal Zip As Integer, ByVal Zip4 As Integer)
  'Create Billing File
  Dim drBill As DataRow
  Dim AddrLine() As String
  drBill = dsBill.Tables(0).NewRow
  drBill.Item("BillType") = sArray(3)
  drBill.Item("BillDesc") = "PERSONAL PROPERTY BILL"
  drBill.Item("listno") = sArray(1)
  drBill.Item("year") = sArray(2)
  drBill.Item("acct") = Mid(sArray(2), 3, 2) & sArray(3) & sArray(1)
  AddrLine = SetAddrLine(sArray(4), sArray(5), Addr, Addr2, _
    Town, State, Zip, Zip4)
  If MyFrmMainB.RbPrint.Checked Then
    drBill.Item("addr1") = AddrLine(0)
    drBill.Item("addr2") = AddrLine(1)
    drBill.Item("addr3") = AddrLine(2)
    drBill.Item("addr4") = AddrLine(3)
    drBill.Item("addr5") = AddrLine(4)
  Else
    drBill.Item("name") = sArray(4)
    drBill.Item("sname") = sArray(5)
    drBill.Item("addr") = Addr
    drBill.Item("addr2") = Addr2
    drBill.Item("city") = Town
    drBill.Item("state") = State
    If Zip4 > 0 Then
      drBill.Item("zipa") = Format(Zip, "00000") & "-" & Format(Zip4, "0000")
    Else
      drBill.Item("zipa") = Format(Zip, "00000")
    End If
  End If
  drBill.Item("gross") = sArray(15)
  drBill.Item("exemption") = sArray(16)
  drBill.Item("net") = sArray(17)
  drBill.Item("taxtot") = sArray(12)
  drBill.Item("tax1st") = sArray(13)
  drBill.Item("tax2nd") = sArray(14)
  drBill.Item("stbenefit") = 0
  drBill.Item("townbenefit") = 0
  drBill.Item("propdesc") = sArray(20)
  drBill.Item("addldesc") = Trim(sArray(18)) & " " & sArray(19)
  If sArray(0) = "BT" Then
    drBill.Item("backtax") = True
  Else
    drBill.Item("backtax") = False
  End If
  drBill.Item("barcode") = sArray(40)
  drBill.Item("groupid") = WrkGroupID
  drBill.Item("group12") = WrkGroup12
  drBill.Item("postnet") = WrkPostNet
  drBill.Item("postid") = WrkPostID
  drBill.Item("scanline") = sArray(31)
  drBill.Item("ccno") = sArray(26)
  drBill.Item("ccdesc") = sArray(25)
  If Trim(sArray(27)) <> "" Then
    drBill.Item("ccdate") = sArray(27)
  End If
  drBill.Item("millrt") = sArray(23)
  drBill.Item("taxbase") = sArray(28)
  drBill.Item("millrtbefore") = sArray(29)
  drBill.Item("maplot") = ""
  drBill.Item("lease") = ""
  If WrkSewer Then
    drBill.Item("sewertot") = 0
    drBill.Item("sewer1st") = 0
    drBill.Item("sewer2nd") = 0
    drBill.Item("combtot") = 0
    drBill.Item("comb1st") = 0
    drBill.Item("comb2nd") = 0
  End If
  drBill.Item("taxwouldbe") = 0
  dsBill.Tables(0).Rows.Add(drBill)
  WrkTotTax = WrkTotTax + CnvSng(sArray(12))
End Sub
Private Sub CrtMVBill(ByVal sArray() As String, ByVal Addr As String, ByVal Addr2 As String, ByVal Town As String, _
  ByVal State As String, ByVal Zip As Integer, ByVal Zip4 As Integer)
  'Create Billing File
  Dim drBill As DataRow
  Dim AddrLine() As String
  If sArray.GetUpperBound(0) < 39 Then
    MsgBox("MV List# " & sArray(1), MsgBoxStyle.Exclamation, "Data is not aligned")
    Exit Sub
  End If
  drBill = dsBill.Tables(0).NewRow
  drBill.Item("BillType") = sArray(3)
  drBill.Item("BillDesc") = "MOTOR VEHICLE BILL"
  drBill.Item("listno") = sArray(1)
  drBill.Item("year") = sArray(2)
  drBill.Item("acct") = Mid(sArray(2), 3, 2) & sArray(3) & sArray(1)
  AddrLine = SetAddrLine(sArray(4), sArray(5), Addr, Addr2, _
    Town, State, Zip, Zip4)
  If MyFrmMainB.RbPrint.Checked Then
    drBill.Item("addr1") = AddrLine(0)
    drBill.Item("addr2") = AddrLine(1)
    drBill.Item("addr3") = AddrLine(2)
    drBill.Item("addr4") = AddrLine(3)
    drBill.Item("addr5") = AddrLine(4)
  Else
    drBill.Item("name") = sArray(4)
    drBill.Item("sname") = sArray(5)
    drBill.Item("addr") = Addr
    drBill.Item("addr2") = Addr2
    drBill.Item("city") = Town
    drBill.Item("state") = State
    If Zip4 > 0 Then
      drBill.Item("zipa") = Format(Zip, "00000") & "-" & Format(Zip4, "0000")
    Else
      drBill.Item("zipa") = Format(Zip, "00000")
    End If
  End If
  drBill.Item("gross") = sArray(15)
  drBill.Item("exemption") = sArray(16)
  drBill.Item("net") = sArray(17)
  drBill.Item("taxtot") = sArray(12)
  drBill.Item("tax1st") = sArray(13)
  drBill.Item("tax2nd") = sArray(14)
  drBill.Item("stbenefit") = 0
  drBill.Item("townbenefit") = 0
  drBill.Item("propdesc") = sArray(21) & " " & sArray(20) & " " & _
    sArray(19) & " " & sArray(23) & "  " & sArray(18)
  If sArray(0) = "BT" Then
    drBill.Item("backtax") = True
  Else
    drBill.Item("backtax") = False
  End If
  drBill.Item("barcode") = sArray(39)
  drBill.Item("groupid") = WrkGroupID
  drBill.Item("group12") = WrkGroup12
  drBill.Item("postnet") = WrkPostNet
  drBill.Item("postid") = WrkPostID
  drBill.Item("scanline") = sArray(33)
  drBill.Item("ccno") = sArray(28)
  drBill.Item("ccdesc") = sArray(27)
  If Trim(sArray(29)) <> "" Then
    drBill.Item("ccdate") = sArray(29)
  End If
  drBill.Item("millrt") = sArray(25)
  drBill.Item("taxbase") = sArray(30)
  drBill.Item("millrtbefore") = sArray(31)
  drBill.Item("maplot") = ""
  drBill.Item("lease") = sArray(38)
  If WrkSewer Then
    drBill.Item("sewertot") = 0
    drBill.Item("sewer1st") = 0
    drBill.Item("sewer2nd") = 0
    drBill.Item("combtot") = 0
    drBill.Item("comb1st") = 0
    drBill.Item("comb2nd") = 0
  End If
  drBill.Item("lease") = sArray(38)
  drBill.Item("taxwouldbe") = 0
  dsBill.Tables(0).Rows.Add(drBill)
  WrkTotTax = WrkTotTax + CnvSng(sArray(12))
End Sub
Private Sub CrtMSBill(ByVal sArray() As String, ByVal Addr As String, ByVal Addr2 As String, ByVal Town As String, _
  ByVal State As String, ByVal Zip As Integer, ByVal Zip4 As Integer)
  'Create Billing File
  Dim drBill As DataRow
  Dim AddrLine() As String
  If sArray.GetUpperBound(0) < 39 Then
    MsgBox("MS List# " & sArray(1), MsgBoxStyle.Exclamation, "Data is not aligned")
    Exit Sub
  End If
  drBill = dsBill.Tables(0).NewRow
  drBill.Item("BillType") = sArray(3)
  drBill.Item("BillDesc") = "SUPPLEMENTAL MOTOR VEHICLE BILL"
  drBill.Item("listno") = sArray(1)
  drBill.Item("year") = sArray(2)
  drBill.Item("acct") = Mid(sArray(2), 3, 2) & sArray(3) & sArray(1)
  AddrLine = SetAddrLine(sArray(4), sArray(5), Addr, Addr2, _
    Town, State, Zip, Zip4)
  If MyFrmMainB.RbPrint.Checked Then
    drBill.Item("addr1") = AddrLine(0)
    drBill.Item("addr2") = AddrLine(1)
    drBill.Item("addr3") = AddrLine(2)
    drBill.Item("addr4") = AddrLine(3)
    drBill.Item("addr5") = AddrLine(4)
  Else
    drBill.Item("name") = sArray(4)
    drBill.Item("sname") = sArray(5)
    drBill.Item("addr") = Addr
    drBill.Item("addr2") = Addr2
    drBill.Item("city") = Town
    drBill.Item("state") = State
    If Zip4 > 0 Then
      drBill.Item("zipa") = Format(Zip, "00000") & "-" & Format(Zip4, "0000")
    Else
      drBill.Item("zipa") = Format(Zip, "00000")
    End If
  End If
  drBill.Item("prorate") = sArray(46)
  drBill.Item("credit") = sArray(52)
  drBill.Item("net") = sArray(17)
  drBill.Item("taxtot") = sArray(12)
  drBill.Item("tax1st") = sArray(13)
  drBill.Item("tax2nd") = sArray(14)
  drBill.Item("stbenefit") = 0
  drBill.Item("townbenefit") = 0
  drBill.Item("propdesc") = "SU:" & sArray(21) & " " & sArray(20) & " " & _
    sArray(19) & " " & sArray(23) & "  " & sArray(18)
  If sArray(37) <> "" Then
    drBill.Item("propdesc2") = "CR:" & sArray(34) & " " & sArray(35) & " " & _
      sArray(39) & " " & sArray(38) & "  " & sArray(37)
  Else
    drBill.Item("propdesc2") = ""
  End If
  drBill.Item("addldesc") = CnvSng(sArray(42)) & " " & sArray(43) & " " & sArray(44) & " " & sArray(45) & " " & CnvSng(sArray(46))
  If sArray(37) <> "" Then
    drBill.Item("addldesc2") = CnvSng(sArray(48)) & " " & sArray(49) & " " & sArray(50) & " " & sArray(51) & " " & CnvSng(sArray(52))
    drBill.Item("addldesc3") = CnvSng(sArray(54)) & " " & sArray(55) & " " & sArray(56) & " " & sArray(57) & " " & CnvSng(sArray(60))
  Else
    drBill.Item("addldesc2") = ""
    drBill.Item("addldesc3") = ""
  End If
  drBill.Item("addldesc4") = sArray(41)
  If sArray(0) = "BT" Then
    drBill.Item("backtax") = True
  Else
    drBill.Item("backtax") = False
  End If
  drBill.Item("barcode") = sArray(67)
  drBill.Item("groupid") = WrkGroupID
  drBill.Item("group12") = WrkGroup12
  drBill.Item("postnet") = WrkPostNet
  drBill.Item("postid") = WrkPostID
  drBill.Item("scanline") = sArray(61)
'  drBill.Item("ccno") = sArray(34)
'  drBill.Item("ccdesc") = sArray(33)
'  drBill.Item("ccdate") = sArray(35)
  drBill.Item("millrt") = sArray(25)
  drBill.Item("taxbase") = sArray(30)
  drBill.Item("millrtbefore") = sArray(31)
  drBill.Item("maplot") = ""
  drBill.Item("lease") = sArray(66)
  If WrkSewer Then
    drBill.Item("sewertot") = 0
    drBill.Item("sewer1st") = 0
    drBill.Item("sewer2nd") = 0
    drBill.Item("combtot") = 0
    drBill.Item("comb1st") = 0
    drBill.Item("comb2nd") = 0
  End If
  drBill.Item("taxwouldbe") = 0
  dsBill.Tables(0).Rows.Add(drBill)
  WrkTotTax = WrkTotTax + CnvSng(sArray(12))
End Sub
Private Sub WriteTot(ByVal WrkCount As Integer, ByVal WrkGroup As Integer, ByVal WrkStrPage As Integer)
  Dim drTot As DataRow
  drTot = dsTot.Tables(0).NewRow
  drTot.Item("Count") = WrkCount
  drTot.Item("Group") = WrkGroup
  If WrkGroup = 999 Then
    drTot.Item("Total") = WrkCount
  Else
    drTot.Item("Total") = WrkCount * WrkGroup
  End If
  drTot.Item("StrPage") = WrkStrPage
  dsTot.Tables(0).Rows.Add(drTot)
End Sub
Private Function BuildNCOAHdr() As String

   Dim sb As StringBuilder
   sb = New StringBuilder
   sb.Append("ListNo")
   sb.Append(",")
   sb.Append("Type")
   sb.Append(",")
   sb.Append("Name")
   sb.Append(",")
   sb.Append("NC Addr")
   sb.Append(",")
   sb.Append("NC Addr2")
   sb.Append(",")
   sb.Append("NC Town")
   sb.Append(",")
   sb.Append("NC State")
   sb.Append(",")
   sb.Append("NC Zip")
   sb.Append(",")
   sb.Append("Addr")
   sb.Append(",")
   sb.Append("Addr2")
   sb.Append(",")
   sb.Append("Town")
   sb.Append(",")
   sb.Append("State")
   sb.Append(",")
   sb.Append("Zip")
   sb.Append(",")
   sb.Append("Changed")
   Return sb.ToString
End Function
Private Function BuildNCOA(ByVal sArray() As String, ByVal Type As String, ByVal Name As String, _
  ByVal Addr As String, ByVal Addr2 As String, ByVal Town As String, ByVal State As String, _
  ByVal Zip As String) As String

   Dim sb As StringBuilder
   Dim sb2 As StringBuilder
   Dim WrkZip As String
   sb = New StringBuilder
   sb2 = New StringBuilder
   sb.Append(CnvSng(sArray(1)))
   sb.Append(",")
   sb.Append(Type)
   sb.Append(",")
   Name = Replace(Name, ",", "")
   sb.Append(Name)
   sb.Append(",")
   sb.Append(Addr)
   sb.Append(",")
   sb.Append(Addr2)
   sb.Append(",")
   sb.Append(Town)
   sb.Append(",")
   sb.Append(State)
   sb.Append(",")
   sb.Append(Zip)
   sb.Append(",")
   sb.Append(sArray(6))
   sb.Append(",")
   sb.Append(sArray(7))
   sb.Append(",")
   sb.Append(sArray(8))
   sb.Append(",")
   sb.Append(sArray(9))
   sb.Append(",")
   WrkZip = sArray(10)
   If CnvSng(sArray(11)) <> 0 Then
     WrkZip = WrkZip & "-" & sArray(11)
   End If
   sb.Append(WrkZip)
   sb.Append(",")
   If Addr <> sArray(6) Then
     sb.Append("A")
   End If
   If Addr2 <> sArray(7) Then
     sb.Append("2")
   End If
   If Town <> sArray(8) Then
     sb.Append("T")
   End If
   If State <> sArray(9) Then
     sb.Append("S")
   End If
   If Zip <> WrkZip Then
       sb.Append("Z")
   End If
   Return sb.ToString
End Function
Private Function BuildExportHdr() As String

    Dim sb As StringBuilder
    sb = New StringBuilder
    sb.Append("GroupID")
    sb.Append(",")
    sb.Append("Group No")
    sb.Append(",")
    sb.Append("PostID")
    sb.Append(",")
    sb.Append("Type")
    sb.Append(",")
    sb.Append("Bill Description")
    sb.Append(",")
    sb.Append("List No")
    sb.Append(",")
    sb.Append("Year")
    sb.Append(",")
    sb.Append("Account")
    sb.Append(",")
    If MyFrmMainB.RbPrint.Checked Then
      sb.Append("Address 1")
      sb.Append(",")
      sb.Append("Address 2")
      sb.Append(",")
      sb.Append("Address 3")
      sb.Append(",")
      sb.Append("Address 4")
      sb.Append(",")
      sb.Append("Address 5")
    Else
      sb.Append("Name")
      sb.Append(",")
      sb.Append("Second Name")
      sb.Append(",")
      sb.Append("Address")
      sb.Append(",")
      sb.Append("Address 2")
      sb.Append(",")
      sb.Append("City")
      sb.Append(",")
      sb.Append("State")
      sb.Append(",")
      sb.Append("Zip")
    End If
    sb.Append(",")
    sb.Append("Bank")
    sb.Append(",")
    sb.Append("Gross")
    sb.Append(",")
    sb.Append("Exemption")
    sb.Append(",")
    sb.Append("Net")
    sb.Append(",")
    sb.Append("Tax Total")
    sb.Append(",")
    sb.Append("Tax 1st")
    sb.Append(",")
    sb.Append("Tax 2nd")
    sb.Append(",")
    sb.Append("State Benefit")
    sb.Append(",")
    sb.Append("Town Benefit")
    sb.Append(",")
    sb.Append("CC No")
    sb.Append(",")
    sb.Append("CC Date")
    sb.Append(",")
    sb.Append("Property Description")
    sb.Append(",")
    sb.Append("Addl Description")
    sb.Append(",")
    sb.Append("Addl Description 2")
    sb.Append(",")
    sb.Append("Back Tax")
    sb.Append(",")
    sb.Append("Barcode")
    sb.Append(",")
    sb.Append("Scanline")
    sb.Append(",")
    sb.Append("Mill Rate")
    sb.Append(",")
    sb.Append("Tax Base")
    sb.Append(",")
    sb.Append("Mill Rate Before")
    sb.Append(",")
    sb.Append("Map/Lot")
    sb.Append(",")
    sb.Append("Lease")
    If WrkSewer Then
      sb.Append(",")
      sb.Append("Sewer Total")
      sb.Append(",")
      sb.Append("Sewer 1st")
      sb.Append(",")
      sb.Append("Sewer 2nd")
      sb.Append(",")
      sb.Append("Combined Total")
      sb.Append(",")
      sb.Append("Combined 1st")
      sb.Append(",")
      sb.Append("Combined 2nd")
    End If
    sb.Append(",")
    sb.Append("Tax Would Be")
    Return sb.ToString
End Function
Private Sub WriteExport()

   Dim sw As StreamWriter = New StreamWriter(MyFrmMainB.LblFilePathExport.Text)
   Dim sb As StringBuilder
   Const CQuote As String = Chr(34)
   Dim I As Integer
   Dim WrkGroupNo As Integer
   Dim SavePostID As Integer

   sb = New StringBuilder
   sw.WriteLine(BuildExportHdr)
   sb = Nothing
   WrkGroupNo = 1
   SavePostID = 0

  For I = 0 To dsBill.Tables(0).Rows.Count - 1
    With dsBill.Tables(0).Rows(I)
      sb = New StringBuilder
      sb.Append(.Item("groupid"))
      sb.Append(",")
      If SavePostID > 0 And SavePostID <> .Item("postid") Then
        WrkGroupNo = WrkGroupNo + 1
      End If
      SavePostID = .Item("postid")
      'If SaveGroup12 <> "" And SaveGroup12 <> UCase(.Item("group12")) Then
      '  WrkGroupNo = WrkGroupNo + 1
      'End If
      'SaveGroup12 = UCase(.Item("group12"))
      sb.Append(WrkGroupNo)
      sb.Append(",")
      sb.Append(.Item("postid"))
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("BillType"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("BillDesc"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(.Item("listno"))
      sb.Append(",")
      sb.Append(.Item("year"))
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("acct"))
      sb.Append(CQuote)
      sb.Append(",")
    If MyFrmMainB.RbPrint.Checked Then
      sb.Append(CQuote)
      sb.Append(.Item("addr1"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr2"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr3"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr4"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr5"))
      sb.Append(CQuote)
    Else
      sb.Append(CQuote)
      sb.Append(.Item("name"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("sname"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addr2"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("city"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("state"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("zipa"))
      sb.Append(CQuote)
    End If
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("bank"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(.Item("gross"))
      sb.Append(",")
      sb.Append(.Item("exemption"))
      sb.Append(",")
      sb.Append(.Item("net"))
      sb.Append(",")
      sb.Append(.Item("taxtot"))
      sb.Append(",")
      sb.Append(.Item("tax1st"))
      sb.Append(",")
      sb.Append(.Item("tax2nd"))
      sb.Append(",")
      sb.Append(CQuote)
      If .Item("stbenefit") > 0 Then
        sb.Append("State Benefit: " & .Item("stbenefit"))
      Else
        sb.Append("")
      End If
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      If .Item("townbenefit") > 0 Then
        sb.Append("Town Benefit: " & .Item("townbenefit"))
      Else
        sb.Append("")
      End If
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(.Item("ccno"))
      sb.Append(",")
      sb.Append(.Item("ccdate"))
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("propdesc"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addldesc"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("addldesc2"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      If .Item("backtax") Then
        sb.Append("BACK TAX")
      Else
        sb.Append("")
      End If
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(.Item("barcode"))
      sb.Append(",")
      sb.Append(.Item("scanline"))
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("millrt"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("taxbase"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("millrtbefore"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("maplot"))
      sb.Append(CQuote)
      sb.Append(",")
      sb.Append(CQuote)
      sb.Append(.Item("lease"))
      sb.Append(CQuote)
      If WrkSewer Then
        sb.Append(",")
        sb.Append(.Item("sewertot"))
        sb.Append(",")
        sb.Append(.Item("sewer1st"))
        sb.Append(",")
        sb.Append(.Item("sewer2nd"))
        sb.Append(",")
        sb.Append(.Item("combtot"))
        sb.Append(",")
        sb.Append(.Item("comb1st"))
        sb.Append(",")
        sb.Append(.Item("comb2nd"))
      End If
      sb.Append(",")
      sb.Append(.Item("taxwouldbe"))
      sw.WriteLine(sb.ToString)
      sb = Nothing
    End With
  Next
  sw.Flush()
  sw.Close()
End Sub
Private Sub UpdateFile(ByVal WrkType As String, ByVal WrkRecno As Integer, ByVal WrkPageNo As Integer)
  Dim ds2 As DataSet = New DataSet
  Dim WrkQry As String
  WrkQry = "TYPE=" & Quo(WrkType) & " And RECID=" & WrkRecno
  ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
  ds2.Tables(0).Rows(0).Item("pageno") = WrkPageNo
  myDBUtils.UpdateOneRecordP(WrkFile, ds2)
End Sub
End Module
