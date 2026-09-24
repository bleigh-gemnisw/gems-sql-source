Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXLEASE As TXLEASE.MyData

  Dim ds As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkGLYear As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSortBy As String
  Dim WrkCode(250) As String
  Dim WrkName(250) As String
  Dim WrkAddr1(250) As String
  Dim WrkCity(250) As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXLEASE = New TXLEASE.MyData(myDBConnect)

    With MyFrmTXE54B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkPost = .Chkupdatebacktax.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    BufferLease()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("Lease", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkLease As String
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

    WrkSort = "NAME, LIST#, YEAR"
    WrkQry = "icode<>'I'" & WrkAnd & "YEAR = " & WrkGLYear
    MyTypes = MyFrmTXE54B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

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
        WrkLease = LookupLease(Trim(._NAME), Trim(._ADD1), Trim(._CITY))
        If WrkLease <> "" And Trim(._ILEASE) <> WrkLease Then
          WriteDs(WrkLease)
          If WrkPost Then
            myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
            myTXINV._ILEASE = WrkLease
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
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub WriteDs(ByVal WrkLease As String)

    With myTXINVQ
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("name") = Trim(._NAME)
      dr.Item("add1") = Trim(._ADD1)
      dr.Item("city") = Trim(._CITY)
      dr.Item("Lease") = WrkLease
    End With
    ds.Tables(0).Rows.Add(dr)
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
  Private Sub BufferLease()
    Dim I As Integer
    Dim ds2 As DataSet = New DataSet

    ds2 = myTXLEASE.PosData("")
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkCode(I) = .Item("code")
        WrkName(I) = UCase(.Item("name"))
        WrkAddr1(I) = UCase(.Item("addr1"))
        WrkCity(I) = UCase(.Item("city"))
      End With
    Next

  End Sub
  Private Function LookupLease(ByVal Name As String, ByVal Addr1 As String, ByVal City As String) As String
    Dim I As Integer

    For I = 0 To WrkName.GetUpperBound(0)
      If Trim(WrkName(I)) & "" = "" Then
        Return ""
      End If
      If Trim(Name) = Trim(WrkName(I)) Then
        Return WrkCode(I)
      End If
    Next
    Return ""
  End Function
End Module
