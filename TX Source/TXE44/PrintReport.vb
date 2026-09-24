Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVLM As TXINVLM.MyData
  Dim myTXINVLN As TXINVLN.MyData
  Dim myTXINV As TXINV.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim ds2 As DataSet = New DataSet
  Dim dr2 As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkType As String
  Dim WrkFamily As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINVLM = New TXINVLM.MyData(myDBConnect)
    myTXINVLN = New TXINVLN.MyData(myDBConnect)

    With MyFrmTXE44B
      WrkType = .TxtType.Text
      WrkPost = .Chkupdatebacktax.Checked
    End With

    WrkFamily = GetTXTypeFamily(WrkType)
    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
    Else
      ds.Clear()
    End If

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
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim drSel() As DataRow
    Dim WrkQry As String
    Dim WrkQry2 As String
    Dim WrkSelect As String
    Dim WrkSort As String
    Dim WrkAcctID As String
    Dim SaveListNo As Integer
    Dim SaveCustID As Long
    Dim SaveCustID2 As Long
    Dim Counter As Integer
    Dim I As Integer
    Dim J As Integer

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

    If WrkPost Then
      MassClear()
    End If

    WrkQry2 = String.Empty
    SaveListNo = 0
    SaveCustID = 0
    Select Case WrkFamily
      Case "M", "S"
        WrkSort = "SS#, SS2, YEAR, TYPE"
        WrkQry = "BALD > 0" & WrkAnd & "SS# > 0"
      Case Else
        WrkSort = "LIST#, YEAR"
        WrkQry = "BALD > 0" & WrkAnd & "TYPE =" & MyUtils.Quo(WrkType)
    End Select

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
        If WrkFamily = "M" Or WrkFamily = "S" Then
          If SaveCustID <> ._SSNo Or SaveCustID2 <> ._SS2 Then
            If SaveCustID2 > 0 Then
              ds3 = myTXINVLN.GetAllSS2(SaveCustID2, 5000, False)
              For J = 0 To ds3.Tables(0).Rows.Count - 1
                If ds3.Tables(0).Rows(J).Item("wbal") > 0 Then
                  WrkAcctID = ds3.Tables(0).Rows(J).Item("year") & ds3.Tables(0).Rows(J).Item("type") & ds3.Tables(0).Rows(J).Item("list#")
                  WrkSelect = "acctid='" & WrkAcctID & "'"
                  drSel = ds2.Tables(0).Select(WrkSelect)
                  If drSel.GetUpperBound(0) = -1 Then
                    dr2 = ds2.Tables(0).NewRow
                    dr2.Item("acctid") = WrkAcctID
                    dr2.Item("year") = ds3.Tables(0).Rows(J).Item("year")
                    dr2.Item("type") = ds3.Tables(0).Rows(J).Item("type")
                    dr2.Item("listno") = ds3.Tables(0).Rows(J).Item("list#")
                    ds2.Tables(0).Rows.Add(dr2)
                  End If
                End If
              Next
            End If
            If SaveCustID > 0 Then
              UpdateTXINV_MV(ds2)
            End If
            ds2.Clear()
          End If
          SaveCustID = ._SSNo
          SaveCustID2 = ._SS2
        Else
          If SaveListNo <> ._LISTNo Then
            UpdateTXINV(ds2)
            ds2.Clear()
          End If
          SaveListNo = ._LISTNo
        End If
        'Filter - Omit Unposted Zero Balances 
        If (._BALD - ._NEWPAY) <= 0 Then
          GoTo NextRec
        End If

        dr2 = ds2.Tables(0).NewRow
        WrkAcctID = ._YEAR & ._TYPE & ._LISTNo
        dr2.Item("acctid") = WrkAcctID
        dr2.Item("year") = ._YEAR
        dr2.Item("type") = ._TYPE
        dr2.Item("listno") = ._LISTNo
        ds2.Tables(0).Rows.Add(dr2)
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

    If WrkFamily = "M" Or WrkFamily = "S" Then
      If SaveCustID2 > 0 Then
        ds3 = myTXINVLN.GetAllSS2(SaveCustID2, 5000, False)
        For I = 0 To ds3.Tables(0).Rows.Count - 1
          If ds3.Tables(0).Rows(I).Item("wbal") > 0 Then
            WrkAcctID = ds3.Tables(0).Rows(I).Item("year") & ds3.Tables(0).Rows(I).Item("type") & ds3.Tables(0).Rows(I).Item("list#")
            WrkSelect = "acctid='" & WrkAcctID & "'"
            drSel = ds2.Tables(0).Select(WrkSelect)
            If drSel.GetUpperBound(0) = -1 Then
              dr2 = ds2.Tables(0).NewRow
              dr2.Item("acctid") = WrkAcctID
              dr2.Item("year") = ds3.Tables(0).Rows(I).Item("year")
              dr2.Item("type") = ds3.Tables(0).Rows(I).Item("type")
              dr2.Item("listno") = ds3.Tables(0).Rows(I).Item("list#")
              ds2.Tables(0).Rows.Add(dr2)
            End If
          End If
        Next
      End If
      If SaveCustID > 0 Then
        UpdateTXINV_MV(ds2)
      End If
    Else
      UpdateTXINV(ds2)
    End If
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub

  Private Sub WriteDs()
    Dim drSel() As DataRow
    Dim WrkType As String
    Dim WrkAcctID As String
    Dim WrkSelect As String

    With myTXINV
      WrkAcctID = ._YEAR & ._TYPE & ._LISTNo
      WrkSelect = "acctid='" & WrkAcctID & "'"
      drSel = ds.Tables(0).Select(WrkSelect)
      If drSel.GetUpperBound(0) = -1 Then
        WrkType = Trim(._TYPE)
        dr = ds.Tables(0).NewRow
        If WrkFamily = "M" Or WrkFamily = "S" Then
          dr.Item("sortdata") = ._SSNo
        Else
          dr.Item("sortdata") = Format(._LISTNo, "000000") & ._YEAR
        End If
        dr.Item("acctid") = WrkAcctID
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("listno") = ._LISTNo
        If Trim(._SNAME) = "" Then
          dr.Item("name") = Trim(._NAME)
        Else
          dr.Item("name") = Trim(._NAME) & "/" & Trim(._SNAME)
        End If
        If WrkFamily = "M" Or WrkFamily = "S" Then
          If ._SS2 = 0 Then
            dr.Item("PropDesc") = ._SSNo
          Else
            dr.Item("PropDesc") = ._SSNo & " / " & ._SS2
          End If
        Else
          dr.Item("PropDesc") = Trim(._LOCNo) + " " + Trim(._LOC)
        End If
        dr.Item("balance") = ._BALD - ._NEWPAY
        ds.Tables(0).Rows.Add(dr)
      End If
    End With
  End Sub
  Private Sub UpdateTXINV(ByVal ds2 As DataSet)
    Dim I As Integer
    Dim FirstOne As Boolean

    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    FirstOne = True
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        myTXINV.GetOneRecordP(.Item("listno"), .Item("year"), .Item("type"))
      End With
      With myTXINV
        If FirstOne Then
          FirstOne = False
          Continue For
        End If
        If Trim(._ICODE) <> "" And Trim(._ICODE) <> "B" Then GoTo NextInv
        WriteDs()
        If WrkPost Then
          ._ICODE = "B"
          .UpdateOneRecordP()
        End If
      End With
NextInv:
    Next
  End Sub
  Private Sub UpdateTXINV_MV(ByVal ds2 As DataSet)
    Dim I As Integer
    Dim FirstYear As Integer
    Dim FirstType As String

    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    FirstYear = ds2.Tables(0).Rows(0).Item("year")
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("year") < FirstYear Then
        FirstYear = ds2.Tables(0).Rows(I).Item("year")
      End If
    Next

    FirstType = "Z"
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("year") = FirstYear And ds2.Tables(0).Rows(I).Item("type") < FirstType Then
        FirstType = ds2.Tables(0).Rows(I).Item("type")
      End If
    Next

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If FirstYear = .Item("year") And FirstType = .Item("type") Then
          Continue For
        End If
        myTXINV.GetOneRecordP(.Item("listno"), .Item("year"), .Item("type"))
      End With
      With myTXINV
        If Trim(._ICODE) <> "" And Trim(._ICODE) <> "B" Then GoTo NextInv
        WriteDs()
        If WrkPost Then
          ._ICODE = "B"
          .UpdateOneRecordP()
        End If
      End With
NextInv:
    Next
  End Sub
  Private Sub MassClear()
    Dim WrkSet As String
    Dim WrkWhere As String

    WrkSet = "set icode=''"
    If WrkFamily = "M" Or WrkFamily = "S" Then
      WrkWhere = "where SS#>0 and icode='B'"
    Else
      WrkWhere = "where type='" & WrkType & "' and icode='B'"
    End If
    myTXINV.RunUpdateQuery(WrkSet, WrkWhere)
  End Sub
End Module






