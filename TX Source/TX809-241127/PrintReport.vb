Imports System.io
Imports System.Text
Module PrintReport
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.myData
  Dim myTXSUPCD As TXSUPCD.myData
  Dim ds As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkGLYear As Integer
  Dim WrkSelType As String
  Dim WrkShowList As Boolean
  Dim WrkBalDue As Boolean
  Dim WrkPaid As Boolean
  Dim WrkPaidCount As Integer
  Dim WrkSortBy As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.mydata(MyDBConnect)
    myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkPaidCount = WrkPaidCount
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmTX809B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkTypes As String
    Dim Counter As Integer
    Dim WrkAmtDue As Decimal
    Dim WrkLease As String
    Dim WrkMonth As String

    WrkPaidCount = 0
    With MyFrmTX809B
      WrkGLYear = .TxtGlYear.Text
      If .RbAll.Checked Then Mypayment = "All"
      If .rb1.Checked Then Mypayment = "1"
      If .rb2.Checked Then Mypayment = "2"
      If .rb3.Checked Then Mypayment = "3"
      If .rb4.Checked Then Mypayment = "4"
      WrkLease = Trim(.TxtLease.Text)
      WrkBalDue = .ChkBalDue.Checked
      WrkPaid = .ChkPaid.Checked
      WrkSortBy = ""
      If .RbSortType.Checked Then
        WrkSortBy = "Type"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
    End With

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "icode<>'I'" & WrkAnd & "YEAR = " & WrkGLYear
    If WrkLease > "" Then
      WrkQry = WrkQry & WrkAnd & " ILEASE = " & MyUtils.Quo(WrkLease)
    Else
      WrkQry = WrkQry & WrkAnd & " ILEASE > ''"
    End If
    MyTypes = MyFrmTX809B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    Counter = 0
    WrkSort = ""
    Select Case WrkSortBy
      Case "Type"
        WrkSort = "TYPE, NAME, LIST#"
      Case "Name"
        WrkSort = "NAME, LIST#, TYPE"
    End Select

    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    sb = New StringBuilder
    sb.Append("List No")
    sb.Append(",")
    sb.Append("Year")
    sb.Append(",")
    sb.Append("Type")
    sb.Append(",")
    sb.Append("Name")
    sb.Append(",")
    sb.Append("Reg No")
    sb.Append(",")
    sb.Append("VIN")
    sb.Append(",")
    sb.Append("Make")
    sb.Append(",")
    sb.Append("Model")
    sb.Append(",")
    sb.Append("MV Year")
    sb.Append(",")
    sb.Append("Amt Due")
    sb.Append(",")
    sb.Append("Net Assmnt")
    sb.Append(",")
    sb.Append("Assmnt Month")
    sw.WriteLine(sb.ToString)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If ._CCNO = 0 Then
          Select Case Mypayment
            Case "All"
              WrkAmtDue = ._TAXT
            Case "1"
              WrkAmtDue = ._TAX1
            Case "2"
              WrkAmtDue = ._TAX2
            Case "3"
              WrkAmtDue = ._TX3RD
            Case "4"
              WrkAmtDue = ._TX4TH
          End Select
        Else
          Select Case Mypayment
            Case "All"
              WrkAmtDue = ._CCETAX
            Case "1"
              WrkAmtDue = ._CCTX1
            Case "2"
              WrkAmtDue = ._CCTX2
            Case "3"
              WrkAmtDue = ._CCTX3
            Case "4"
              WrkAmtDue = ._CCTX4
          End Select
        End If
        If Trim(._ASS) <> "" Then
          myTXSUPCD.GetOneRecordP(._ASS)
          WrkMonth = myTXSUPCD._SMON
        Else
          WrkMonth = ""
        End If
        WrkAmtDue = WrkAmtDue - ._NEWPAY - ._PAYREC
        If WrkAmtDue < 0 Then WrkAmtDue = 0
        If WrkAmtDue > 0 Or WrkPaid Then
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNo
          dr.Item("type") = ._TYPE
          dr.Item("year") = ._YEAR
          dr.Item("name") = Trim(._NAME)
          dr.Item("regno") = Trim(._IMVREG)
          dr.Item("vin") = Trim(._IMVIDNo)
          dr.Item("amtdue") = WrkAmtDue
          dr.Item("net") = ._NETASS
          dr.Item("assmonth") = WrkMonth
          ds.Tables(0).Rows.Add(dr)
        End If
        If WrkAmtDue <= 0 Then
          WrkPaidCount = WrkPaidCount + 1
        End If

        If WrkAmtDue > 0 Or WrkPaid Then
          sb = New StringBuilder
          sb.Append(._LISTNo)
          sb.Append(",")
          sb.Append(._YEAR)
          sb.Append(",")
          sb.Append(._TYPE)
          sb.Append(",")
          sb.Append(Replace(Trim(._NAME), ",", ""))
          sb.Append(",")
          sb.Append(Trim(._IMVREG))
          sb.Append(",")
          sb.Append(Trim(._IMVIDNo))
          sb.Append(",")
          sb.Append(Trim(._MAKE))
          sb.Append(",")
          sb.Append(Trim(._MODEL))
          sb.Append(",")
          sb.Append(._MVYR)
          sb.Append(",")
          sb.Append(Format(WrkAmtDue, "fixed"))
          sb.Append(",")
          sb.Append(._NETASS)
          sb.Append(",")
          sb.Append(WrkMonth)
          sw.WriteLine(sb.ToString)
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
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("VIN", Type.GetType("System.String"))
      .Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("AssMonth", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module






