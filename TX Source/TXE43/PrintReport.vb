Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData

  Dim ds As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  'Buffered Types
  Dim WrkTXCode(50) As String
  Dim WrkTXDesc(50) As String
  Dim WrkTXFamily(50) As String


  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferType()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkShowAddr As Boolean
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkSortBy As String
    Dim WrkTXType As String()
    Dim WrkDist As Integer
    Dim WrkDistAll As Boolean
    Dim WrkPhase As Integer
    Dim WrkGross(9) As Integer
    Dim WrkCode(9) As Integer
    Dim sb As StringBuilder
    Dim AddrLine(2) As String
    Dim Counter As Integer
    Dim WrkTGross As Integer
    Dim Good As Boolean
    Dim Pos As Integer
    Dim J As Integer

    WrkSortBy = ""
    With MyFrmTXE43B
      WrkType = .TxtTypes.Text
      WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
      MyTypes = .TxtTypes.Text
      If .RbName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbLocation.Checked Then
        WrkSortBy = "Location"
      End If
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If Trim(.TxtDist.Text) = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkShowAddr = .ChkAddress.Checked
    End With

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = ""
    Counter = 0
    Select Case WrkSortBy
      Case "Location"
        WrkSort = "LOC, LOC#, NAME"
      Case "Name"
        WrkSort = "NAME"
    End Select

    WrkQry = "icode<>'I'" & WrkAnd & "ICODE<>'D'"
    If WrkYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR = " & WrkYear
    End If
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "DIST=" & WrkDist
    End If
    If WrkPhase > 0 Then
      WrkQry = WrkQry & WrkAnd & "PHASE = " & WrkPhase
    End If
    MyTypes = MyFrmTXE43B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

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
        WrkCode(0) = ._IPPCD1
        WrkCode(1) = ._IPPCD2
        WrkCode(2) = ._IPPCD3
        WrkCode(3) = ._IPPCD4
        WrkCode(4) = ._IPPCD5
        WrkCode(5) = ._IPPCD6
        WrkCode(6) = ._IPPCD7
        WrkCode(7) = ._IPPCD8
        WrkCode(8) = ._IPPCD9
        WrkCode(9) = ._IPPCDA

        Good = False
        WrkTGross = 0
        For J = 0 To 9
          If WrkCode(J) = 0 Then Continue For
          Pos = InStr(MySelCodes, Format(WrkCode(J), " ###"))
          If Pos > 0 Then Good = True
          WrkTGross = WrkTGross + WrkGross(J)
        Next J

        If Not Good And Not MySelCodes = String.Empty Then
          GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("name") = Trim(._NAME)
        dr.Item("addr1") = Trim(._ADD1)
        If WrkShowAddr Then
          AddrLine = SetAddrShort(._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
          dr.Item("addr2") = AddrLine(0)
          dr.Item("addr3") = AddrLine(1)
        End If
        WrkTXType = LookupType(._TYPE)
        Select Case WrkTXType(1)
          Case "M", "S"
            sb = New StringBuilder
            sb.Append(MyUtils.JustifyLeft(._MAKE, 5))
            sb.Append(" ")
            sb.Append(MyUtils.JustifyLeft(._MODEL, 8))
            sb.Append(" ")
            sb.Append(._MVYR)
            sb.Append(" ")
            sb.Append(MyUtils.JustifyLeft(._IMVREG, 8))
            sb.Append(" ")
            sb.Append(._IMVIDNo)
            dr.Item("desc") = sb.ToString
            sb = Nothing
          Case Else
            dr.Item("desc") = MyUtils.JustifyRight(Trim(._LOCNo), 7) & " " & Trim(._LOC)
        End Select
        dr.Item("net") = ._NETASS
        dr.Item("balance") = ._BALD
      End With
      ds.Tables(0).Rows.Add(dr)

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
    myTXINVQ.CloseFile()

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
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkTXCode(I) = .Item("tycode")
        WrkTXDesc(I) = .Item("tydesc")
        WrkTXFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkTXCode.GetUpperBound(0)
      If WrkTXCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkTXCode(I) Then
        WrkResult(0) = WrkTXDesc(I)
        WrkResult(1) = WrkTXFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function
  Public Function SetAddrShort(ByVal Add2 As String, ByVal City As String, ByVal State As String,
   ByVal Zip5 As Integer, ByVal Zip4 As Integer) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    'City, State, Zip5 and Zip4 are combined into one line
    Dim AddrLine(2) As String
    Dim sb As StringBuilder
    Dim I As Integer

    If Trim(Add2) <> "" Then
      AddrLine(I) = Trim(Add2)
      I = I + 1
    End If
    sb = New StringBuilder
    sb.Append(Trim(City))
    sb.Append(", ")
    sb.Append(Trim(State))
    sb.Append(" ")
    sb.Append(Format(Zip5, "00000"))
    If Zip4 > 0 Then
      sb.Append("-")
      sb.Append(Format(Zip4, "0000"))
    End If
    AddrLine(I) = sb.ToString
    For I = 2 To 2
      If AddrLine(I) Is Nothing Then
        AddrLine(I) = ""
      End If
    Next
    Return AddrLine

  End Function

End Module






