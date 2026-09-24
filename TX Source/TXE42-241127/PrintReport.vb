Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXHST As TXHSTL4.MyData
  Dim myTXINV As TXINV.MyData
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsTXHSTQ As DataSet = New DataSet
  Dim DsTXHST As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkType As String
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkFromGLYear As Integer
  Dim WrkToGLYear As Integer
  Dim WrkSortBy As String
  Dim WrkBlanket As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXHST = New TXHSTL4.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXE42B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      WrkBlanket = .RbBlanket.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If WrkBlanket Then
      GetDetail()
    Else
      GetDetail2()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("LienAmt", Type.GetType("System.Decimal"))
      .Columns.Add("LienDt", Type.GetType("System.String"))
      .Columns.Add("PaidDt", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    ds2 = New DataSet
    With myTable
      .TableName = "mytable2"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("MillRT", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("Tax3rd", Type.GetType("System.Decimal"))
      .Columns.Add("Tax4th", Type.GetType("System.Decimal"))
      .Columns.Add("OtherTot", Type.GetType("System.Decimal"))
      .Columns.Add("Other1st", Type.GetType("System.Decimal"))
      .Columns.Add("Other2nd", Type.GetType("System.Decimal"))
      .Columns.Add("BillTot", Type.GetType("System.Decimal"))
      .Columns.Add("Bill1st", Type.GetType("System.Decimal"))
      .Columns.Add("Bill2nd", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("DueDt1", Type.GetType("System.String"))
      .Columns.Add("DueDt2", Type.GetType("System.String"))
      .Columns.Add("DueDt3", Type.GetType("System.String"))
      .Columns.Add("DueDt4", Type.GetType("System.String"))
      .Columns.Add("PayRec", Type.GetType("System.Decimal"))
      .Columns.Add("BondPaid", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LastPayDt", Type.GetType("System.DateTime"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("UnPaidTax", Type.GetType("System.Decimal"))
      .Columns.Add("UnPaidBond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
      .Columns.Add("InterestDt", Type.GetType("System.DateTime"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDt", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim myBuffer_TXTYPE As Buffer_TXTYPE
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkTypeDesc As String
    Dim WrkFamily As String
    Dim WrkLienedAmt As Decimal
    Dim WrkLienedDate As String
    Dim WrkLienAmtPd As Decimal
    Dim WrkKey As String
    Dim SaveKey As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    myBuffer_TXTYPE = New Buffer_TXTYPE
    myBuffer_TXTYPE.BufferFile()

    WrkQry = "RCODE = ' '" & WrkAnd & "lamt > 0"
    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
    End If

    MyTypes = MyFrmTXE42B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    SaveKey = String.Empty
    WrkSort = "YEAR, TYPE, LIST#"
    DsTXHSTQ = myTXHSTQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXHSTQ.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXHSTQ.Tables(0).Rows.Count - 1)
      With DsTXHSTQ.Tables(0).Rows(I)
        WrkLienedAmt = 0
        WrkLienedDate = String.Empty
        WrkLienAmtPd = 0
        WrkKey = .Item("year") & "-" & .Item("type") & "-" & .Item("list#")
        If SaveKey = WrkKey Then GoTo NextRec
        DsTXHST = myTXHST.GetViewbyList(.Item("list#"), .Item("year"), .Item("type"), 0, 999999)
        For J = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
          With DsTXHST.Tables(0).Rows(J)
            If .Item("rcode") = "V" Then Continue For
            If .Item("rcode") = "I" Then
              If .Item("batcha") = "L" Then
                WrkLienedAmt = .Item("pamt")
                WrkLienedDate = Format(MyUtils.GetDBDate(.Item("pdate")), "Short Date")
              End If
              Continue For
            End If
            If .Item("pdate") > WrkTo Then Exit For
            If .Item("pdate") >= WrkFrom Then
              WrkLienAmtPd = WrkLienAmtPd + .Item("lamt")
            End If
          End With
        Next

        If WrkLienAmtPd = 0 Then GoTo NextRec
        'Skip record if there is still a lien balance
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            If Trim(._LIEN) = "L" Then GoTo NextRec
          End With
        End If

        SaveKey = .Item("year") & "-" & .Item("type") & "-" & .Item("list#")
        WrkType = .Item("type")
        With myBuffer_TXTYPE
          .In_Type = WrkType
          .LookupType()
          WrkTypeDesc = .Out_Desc
          WrkFamily = .Out_Family
        End With

        'Blanket
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("year") = .Item("year")
        dr.Item("type") = .Item("type")
        dr.Item("typedesc") = WrkTypeDesc
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
          ._CITY, ._STATE, ._ZIP5, ._ZIP4)
            dr.Item("addr1") = AddrLine(0)
            dr.Item("addr2") = AddrLine(1)
            Select Case WrkFamily
              Case "M", "S"
                dr.Item("propdesc") = Trim(._MAKE) & " " & Trim(._MVYR) & " " & Trim(._IMVREG)
                dr.Item("propdesc2") = Trim(._IMVIDNo)
              Case "R"
                dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
                dr.Item("propdesc2") = Trim(._MAP)
              Case "P"
                dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
                dr.Item("propdesc2") = ""
              Case Else
                dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
                dr.Item("propdesc2") = Trim(._MAP)
            End Select
          End With
        Else
          AddrLine(0) = "*** Invoice record not Found ***"
        End If
        dr.Item("lienamt") = WrkLienedAmt
        dr.Item("liendt") = WrkLienedDate
        dr.Item("paiddt") = Format(MyUtils.GetDBDate(.Item("pdate")), "Short Date")
        Select Case WrkSortBy
          Case "List"
            dr.Item("sortdata") = .Item("year") & .Item("type") & Format(.Item("list#"), "000000")
          Case "Name"
            dr.Item("sortdata") = AddrLine(0)
        End Select
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXHSTQ.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()

CloseFiles:
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub GetDetail2()
    Dim myBuffer_TXTYPE As Buffer_TXTYPE
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim J As Integer
    Dim WrkTypeDesc As String
    Dim WrkFamily As String
    Dim WrkLienedAmt As Decimal
    Dim WrkLienedDate As String
    Dim WrkLienAmtPd As Decimal
    Dim WrkKey As String
    Dim SaveKey As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    myBuffer_TXTYPE = New Buffer_TXTYPE
    myBuffer_TXTYPE.BufferFile()

    WrkQry = "RCODE = ' '" & WrkAnd & "lamt > 0"
    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
    End If

    MyTypes = MyFrmTXE42B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    SaveKey = String.Empty
    WrkSort = "YEAR, TYPE, LIST#"
    DsTXHSTQ = myTXHSTQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXHSTQ.Tables(0).Rows.Count = 0 Then GoTo CloseFiles

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXHSTQ.Tables(0).Rows.Count - 1)
      With DsTXHSTQ.Tables(0).Rows(I)
        WrkLienedAmt = 0
        WrkLienedDate = String.Empty
        WrkLienAmtPd = 0
        WrkKey = .Item("year") & "-" & .Item("type") & "-" & .Item("list#")
        If SaveKey = WrkKey Then GoTo NextRec
        DsTXHST = myTXHST.GetViewbyList(.Item("list#"), .Item("year"), .Item("type"), 0, 999999)
        For J = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
          With DsTXHST.Tables(0).Rows(J)
            If .Item("rcode") = "V" Then Continue For
            If .Item("rcode") = "I" Then
              If .Item("batcha") = "L" Then
                WrkLienedAmt = .Item("pamt")
                WrkLienedDate = Format(MyUtils.GetDBDate(.Item("pdate")), "Short Date")
              End If
              Continue For
            End If
            If .Item("pdate") > WrkTo Then Exit For
            If .Item("pdate") >= WrkFrom Then
              WrkLienAmtPd = WrkLienAmtPd + .Item("lamt")
            End If
          End With
        Next

        If WrkLienAmtPd = 0 Then GoTo NextRec
        'Skip record if there is still a lien balance
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            If Trim(._LIEN) = "L" Then GoTo NextRec
          End With
        End If

        SaveKey = .Item("year") & "-" & .Item("type") & "-" & .Item("list#")
        WrkType = .Item("type")
        With myBuffer_TXTYPE
          .In_Type = WrkType
          .LookupType()
          WrkTypeDesc = .Out_Desc
          WrkFamily = .Out_Family
        End With

        dr2 = ds2.Tables(0).NewRow
        dr2("sortdata") = .Item("list#") & " " & .Item("type") & " " & .Item("year")
        dr2("ListNo") = .Item("list#")
        dr2("BillType") = WrkTypeDesc
        dr2("Type") = WrkType
        dr2("Year") = .Item("year")
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            If WrkSortBy = "Name" Then
              dr2("sortdata") = ._NAME & " " & dr2("sortdata")
            End If
            AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
          ._CITY, ._STATE, ._ZIP5, ._ZIP4)
            dr2("Addr1") = AddrLine(0)
            dr2("Addr2") = AddrLine(1)
            dr2("Addr3") = AddrLine(2)
            dr2("Addr4") = AddrLine(3)
            dr2("Addr5") = AddrLine(4)
            WrkFamily = GetTXTypeFamily(WrkType)
            Select Case WrkFamily
              Case "M", "S"
                dr2("propdesc") = Trim(._MAKE) & " " & ._MVYR & " " & Trim(._IMVREG) &
            " " & Trim(._IMVIDNo)
              Case "R"
                dr2("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
                dr2("propdesc2") = Trim(._VOL) & "/" & Trim(._IPAGE)
              Case Else
                dr2("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
                dr2("propdesc2") = String.Empty
            End Select
          End With
        End If
        dr2("taxtot") = WrkLienedAmt
        dr2("total") = WrkLienAmtPd
        ds2.Tables(0).Rows.Add(dr2)
        DsTXHST.Clear()
        DsTXHST = Nothing
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXHSTQ.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()

CloseFiles:
    myTXHSTQ.CloseFile()

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

End Module






