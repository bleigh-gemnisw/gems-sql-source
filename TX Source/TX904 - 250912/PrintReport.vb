Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.MyData
Dim myTXINV As TXINV.MyData
Dim myCASHINT As CASHINT.MyData

Dim ds As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet

Dim dr As Data.DataRow
Dim WrkGLFromYear As Integer
Dim WrkGLToYear As Integer
Dim WrkSelType As String
Dim WrkStatus As String
Dim WrkOmitStatus As Boolean
Dim WrkSelResn As String
Dim WrkIntDate As Date
Dim WrkPostinv As Boolean
Dim WrkPrev As Boolean
Dim Wrksusdt As Boolean
Dim WrkDOB As Boolean
Dim WrkDOBModel As Boolean
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkFrom As Integer
Dim WrkTo As Integer
  Public Sub PrtReport()


  myTXINVQ = New TXINVQ.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myCASHINT = New CASHINT.mydata(MyDBConnect)

  With MyFrmTX904B
    WrkGLFromYear = MyUtils.CnvSng(.TxtGLFromYear.Text)
    WrkGLToYear = MyUtils.CnvSng(.TxtGLToYear.Text)
    WrkPrev = .ChkPrev.Checked
    WrkIntDate = .DtPckInt.Value
    WrkPostinv = .CHKPOSTINV.Checked
    Wrksusdt = .CHKSusdt.Checked
    WrkStatus = .TxtStatus.Text
    WrkOmitStatus = False
    If .ChkOmitStatus.Checked Then
      WrkOmitStatus = True
    End If
    WrkSelResn = .txtsresn.Text
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkDOB = .ChkDOB.Checked
    WrkDOBModel = .ChkDOBModel.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()

  End If

  GetDetail()

Done:
  MyCRViewer = New FrmCrViewer
  With MyCRViewer
    .wrkds = ds
    .Show()
  End With

  End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim sw As StreamWriter = New StreamWriter(MyFrmTX904B.LblFilePath.Text)
Dim WrkQry As String
Dim WrkSort As String

Dim WrkDue As Decimal
Dim WrkList As Integer
Dim WrkType As String
Dim WrkYear As Integer
Dim WrkTypes As String

Dim wrkinteger As Integer
Dim wrkstring As String
Dim Wrkdec As Decimal
Dim wrkfilter As String
Dim WrkInterestPaid As Decimal
Dim WrkInterest As Decimal
Dim WrkFee As Decimal
Dim WrkBond As Decimal
Dim WrkLien As Decimal
Dim WrkTax As Decimal
Dim Pos As Integer
Dim Good As Boolean
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

Counter = 0
WrkQry = "icode<>'I'" & WrkAnd & "bald > 0 "
'Filter Grand List Years
If WrkGLFromYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "year>=" & WrkGLFromYear & WrkAnd & "year<=" & WrkGLToYear
End If
WrkQry = WrkQry & WrkAnd & "suscd <> ' '"
MyTypes = MyFrmTX904B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If
    WrkSort = "YEAR, NAME, IMVREG"

myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
  With myTXINVQ
    Counter = Counter + 1
    If Not WrkPrev Then
      If Trim(._AGY) <> String.Empty Then GoTo NextRec ' already sent to agency
    End If
    If Trim(WrkSelResn) > "" Then  ' filter omitted suspense reason codes
      wrkfilter = InStr(1, WrkSelResn, Trim(._SUSCD), 1)
      If wrkfilter <> 0 And Trim(._SUSCD) > "" Then GoTo NextRec
    End If
    If Wrksusdt = True Then
     If ._SUSDT < WrkFrom Or ._SUSDT > WrkTo Then GoTo NextRec ' filter suspense date
    End If
    'Filter - Status Codes
    If Trim(WrkStatus) > "" Then
      If WrkOmitStatus Then
      'Omit
        Pos = 0
        If Trim(._STCD1) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD1), 1)
        End If
        If Pos = 0 And Trim(._STCD2) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD2), 1)
        End If
        If Pos = 0 And Trim(._STCD3) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD3), 1)
        End If
        If Pos = 0 And Trim(._STCD4) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD4), 1)
        End If
        If Pos = 0 And Trim(._STCD5) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD5), 1)
        End If
        If Pos > 0 Then GoTo NextRec
      Else
        'Select
        Good = False
        'Filter - Include Status Codes
        If WrkStatus = String.Empty Then
          Good = True
        End If
        If Not Good And Trim(._STCD1) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD2) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD3) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD4) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD5) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
            Good = True
          End If
        End If
        If Not Good Then GoTo NextRec
      End If
    End If
    WrkList = ._LISTNo
    WrkType = ._TYPE
    WrkYear = ._YEAR

    CalcInterest(WrkList, WrkType, WrkYear, WrkInterest, WrkInterestPaid, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue)

    If WrkDue > 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("year") = ._YEAR
      dr.Item("listno") = ._LISTNo
      dr.Item("type") = ._TYPE
      dr.Item("name") = ._NAME
      dr.Item("prin") = WrkTax
      dr.Item("int") = WrkInterest
      dr.Item("fee") = WrkFee
      dr.Item("lien") = WrkLien
      dr.Item("total") = WrkDue
      ds.Tables(0).Rows.Add(dr)

      'Write all fields to text file
      sb = New StringBuilder
      sb.Append(Format(._YEAR, "0000"))
      sb.Append(Mid(._TYPE, 1, 1))
      sb.Append(Format(._LISTNo, "000000"))
      sb.Append("00000000") 'prdue1
      wrkstring = MyUtils.JustifyLeft(._NAME, 35)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._SNAME, 35)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._ADD1, 35)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._CITY, 25)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._STATE, 2)
      sb.Append(wrkstring)
      wrkinteger = ._ZIP5
      sb.Append(Format(wrkinteger, "00000"))
      wrkinteger = ._ZIP4
      sb.Append(Format(wrkinteger, "0000"))
      wrkstring = MyUtils.JustifyLeft(._MAKE, 5)
      sb.Append(wrkstring)
      wrkinteger = ._MVYR
      sb.Append(Format(wrkinteger, "0000"))
      wrkstring = MyUtils.JustifyLeft(._IMVREG, 8)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(._IMVIDNo, 17)
      sb.Append(wrkstring)
      wrkstring = MyUtils.JustifyLeft(Trim(._LOCNo) & " " & ._LOC, 25)
      sb.Append(wrkstring)

      Wrkdec = WrkTax
      wrkinteger = Wrkdec * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      Wrkdec = WrkInterest
      wrkinteger = Wrkdec * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      Wrkdec = WrkLien
      wrkinteger = Wrkdec * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      Wrkdec = WrkFee + WrkBond
      wrkinteger = Wrkdec * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      Wrkdec = WrkDue
      wrkinteger = Wrkdec * 100
      sb.Append(Format(wrkinteger, "00000000000"))
      If WrkDOB Then
        sb.Append(Format(._DOB, "00000000"))
      End If
      If WrkDOBModel Then
        sb.Append(Format(._DOB, "00000000"))
        wrkstring = MyUtils.JustifyLeft(._MODEL, 8)
        sb.Append(wrkstring)
      End If

      sw.WriteLine(sb.ToString)
      If WrkPostinv = True Then
        myTXINV.GetOneRecordP(WrkList, WrkYear, WrkType)
        myTXINV._AGY = "C"
        myTXINV._ADATE = MyUtils.SetDBDateMDY(Date.Now.Date)
        myTXINV.UpdateOneRecordP()
      End If
    End If
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

sw.Close()
myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Prin", Type.GetType("System.Decimal"))
			.Columns.Add("Int", Type.GetType("System.Decimal"))
			.Columns.Add("Fee", Type.GetType("System.Decimal"))
			.Columns.Add("Lien", Type.GetType("System.Decimal"))
			.Columns.Add("Total", Type.GetType("System.Decimal"))
		End With
  Ds.Tables.Add(myTable)
End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
    ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub

End Module






