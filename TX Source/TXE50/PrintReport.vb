Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData

  Dim dsinv As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkGLFromYear As Integer
  Dim WrkGLToYear As Integer
  Dim WrkSelStatus As String
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPost As Boolean
  Dim WrkDtAgency As Date
  Dim WrkAnd As String
  Dim WrkOr As String
  'Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    With MyFrmTXE50B
      WrkGLFromYear = MyUtils.CnvSng(.TxtGLFromYear.Text)
      WrkGLToYear = MyUtils.CnvSng(.TxtGLToYear.Text)
      WrkSelStatus = .TxtStatus.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPost = .ChkUpdate.Checked
      WrkDtAgency = .DtPckAgency.Value
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferType()
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .wrkds = ds
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim K As Integer
    Dim Pos As Integer
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'"
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If
    'Filter Grand List Years
    If WrkGLFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkGLFromYear
    End If
    If WrkGLToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkGLToYear
    End If
    MyTypes = MyFrmTXE50B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = WrkQry & WrkAnd & BuildSelectQryPC(WrkQry, MyTypes)
    End If
    WrkQry = WrkQry & WrkAnd & " AGY=' '"

    WrkSort = "YEAR, TYPE"

    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        If Trim(WrkSelStatus) > "" Then   ' filter status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD5), 1)
          End If
          If Pos = 0 Then GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        K = LookupType(._TYPE)
        dr.Item("typedesc") = WrkDesc(K)
        dr.Item("name") = Trim(._NAME)
        ds.Tables(0).Rows.Add(dr)
        dr = Nothing

        If WrkPost Then
          UpdateTXINV()
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
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
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
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return 0
      End If
      If Type = WrkCode(I) Then
        Return I
      End If
    Next

    Return 0
  End Function
  Private Sub UpdateTXINV()
    With myTXINV
      .GetOneRecordP(myTXINVQ._LISTNo, myTXINVQ._YEAR, myTXINVQ._TYPE)
      ._AGY = "Y"
      ._ADATE = MyUtils.SetDBDate(WrkDtAgency)
      .UpdateOneRecordP()
    End With
  End Sub
End Module
