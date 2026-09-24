Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myPOMASTQ As POMASTQ.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData
  Dim myGLACCT As GLACCT.MyData

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkFundFrom As Integer
  Dim WrkFundTo As Integer
  Dim WrkVndnr As String
  Dim WrkLlocn As String
  Dim WrkDetail As Boolean
  Dim WrkAmount As Decimal
  Dim WrkStatus As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Public Sub PrtReport()

    myPOMASTQ = New POMASTQ.MyData()
    myPOMASTQ.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect

    With MyFrmPO320B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
      WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
      WrkVndnr = .TxtVndnr.Text
      WrkLlocn = .TxtLlocn.Text
      WrkDetail = .ChkDetail.Checked
      WrkAmount = MyUtils.CnvSng(.TxtAmount.Text)
      WrkStatus = ""
      If .RbStatusOpen.Checked Then WrkStatus = "O"
      If .RbStatusClosed.Checked Then WrkStatus = "C"
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("RptSort", Type.GetType("System.String"))
      .Columns.Add("Prtgrp", Type.GetType("System.String"))
      .Columns.Add("Fscyr", Type.GetType("System.Int32"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Amtnt", Type.GetType("System.Decimal"))
      .Columns.Add("Vennm", Type.GetType("System.String"))
      .Columns.Add("Popen", Type.GetType("System.Decimal"))
      .Columns.Add("PODate", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("AcctAmtnt", Type.GetType("System.Decimal"))
      .Columns.Add("AcctOpen", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dssumf As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkRptSort As String
    Dim WrkFdnbr As Integer
    Dim WrkSfund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim WrkOpen As Decimal
    Dim Counter As Integer
    Dim I As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "RENTD >= " & WrkFrom & WrkAnd & "RENTD <=" & WrkTo & WrkAnd & "poseq=0"
    If WrkAmount > 0 Then
      WrkQry = WrkQry & WrkAnd & "AMTNT >= " & WrkAmount
    End If
    If WrkVndnr <> "" Then
      WrkQry = WrkQry & WrkAnd & "VNDNR= '" & WrkVndnr & "'"
    End If
    If WrkLlocn <> "" Then
      WrkQry = WrkQry & WrkAnd & "LLOCN= '" & WrkLlocn & "'"
    End If
    Select Case WrkStatus
      Case "O"
        WrkQry = WrkQry & WrkAnd & "CMPCD IN ('O','')"
      Case "C"
        WrkQry = WrkQry & WrkAnd & "CMPCD = 'C'"
      Case Else
    End Select
    WrkSort = ""
    If MyFrmPO320B.RbSortDate.Checked Then
      WrkSort = "RENTD, VENNM, PONBR"
    End If
    If MyFrmPO320B.RbSortVName.Checked Then
      WrkSort = "VENNM, PONBR"
    End If
    If MyFrmPO320B.RbSortPO.Checked Then
      WrkSort = "FSCYR, PONBR"
    End If
    myPOMASTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myPOMASTQ.ReadQry()
    If Not myPOMASTQ.IsEOF Then
      With myPOMASTQ
        Counter = Counter + 1
        WrkOpen = 0
        WrkRptSort = ""
        If MyFrmPO320B.RbSortDate.Checked Then
          WrkRptSort = ._RENTD & Trim(._VENNM) & Format(._PONBR, "0000000")
        End If
        If MyFrmPO320B.RbSortVName.Checked Then
          WrkRptSort = Trim(._VENNM) & Format(._PONBR, "0000000")
        End If
        If MyFrmPO320B.RbSortPO.Checked Then
          WrkRptSort = ._FSCYR & Format(._PONBR, "0000000")
        End If
        If WrkDetail Or WrkFundFrom > 0 Or WrkFundTo > 0 Then
          dssumf = myPOSUMFL1.GetAllPONo(._FSCYR, ._PONBR, 0)
          For I = 0 To dssumf.Tables(0).Rows.Count - 1
            With dssumf.Tables(0).Rows(I)
              BreakAcct(.Item("acct"), WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
            End With
            If WrkFundFrom > 0 Then
              If WrkFdnbr < WrkFundFrom Then
                Continue For
              End If
            End If
            If WrkFundTo > 0 Then
              If WrkFdnbr > WrkFundTo Then
                Continue For
              End If
            End If
            If WrkStatus = "O" And dssumf.Tables(0).Rows(I).Item("poopn") = 0 Then Continue For
            dr = ds.Tables(0).NewRow
            dr.Item("rptsort") = WrkRptSort & "B"
            dr.Item("prtgrp") = "B"
            dr.Item("fscyr") = ._FSCYR
            dr.Item("ponbr") = ._PONBR
            dr.Item("acctamtnt") = dssumf.Tables(0).Rows(I).Item("poamt")
            dr.Item("vennm") = Trim(._VENNM)
            dr.Item("acctopen") = dssumf.Tables(0).Rows(I).Item("poopn")
            WrkOpen = WrkOpen + dssumf.Tables(0).Rows(I).Item("poopn")
            If ._RENTD > 0 Then
              dr.Item("podate") = Format(MyUtils.GetDBDate(._RENTD), "M/d/yyyy")
            End If
            With dssumf.Tables(0).Rows(I)
              BreakAcct(.Item("acct"), WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
              dr.Item("acct") = BuildAcct(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
              dr.Item("acctdesc") = GetAcctDesc(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
            End With
            ds.Tables(0).Rows.Add(dr)
          Next
        End If
        If WrkStatus = "O" And WrkOpen = 0 Then GoTo NextRec
        dr = ds.Tables(0).NewRow
        dr.Item("rptsort") = WrkRptSort & "A"
        dr.Item("prtgrp") = "A"
        dr.Item("fscyr") = ._FSCYR
        dr.Item("ponbr") = ._PONBR
        dr.Item("amtnt") = ._AMTNT
        dr.Item("vennm") = Trim(._VENNM)
        dr.Item("popen") = WrkOpen
        If ._RENTD > 0 Then
          dr.Item("podate") = Format(MyUtils.GetDBDate(._RENTD), "M/d/yyyy")
        End If
        dr.Item("acct") = ""
        dr.Item("acctdesc") = ""
        ds.Tables(0).Rows.Add(dr)
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

    myFrmProgress.Close()
    myPOMASTQ.CloseFile()

  End Sub
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund > 0 Then
      sb.Append(Format(Fund, "000"))
      sb.Append("-")
      sb.Append(Format(SFund, "000"))
      sb.Append("-")
      sb.Append(Format(Dept, "0000"))
      sb.Append("-")
      sb.Append(Format(Obj, "000"))
      sb.Append("-")
      sb.Append(Format(Func, "0000"))
      sb.Append("-")
      sb.Append(Format(SFunc, "0000"))
    Else
      sb.Append(String.Empty)
    End If
    Return sb.ToString
  End Function
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder
    Dim WrkLen As Integer
    Dim WrkStr As Integer

    Select Case Len(In_Acct)
      Case 19
        WrkLen = 1
      Case 20
        WrkLen = 2
      Case 21
        WrkLen = 3
    End Select
    Out_Fund = Mid(In_Acct, 1, WrkLen)
    WrkStr = 1 + WrkLen
    Out_SFund = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Dept = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Obj = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Func = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Subfn = Mid(In_Acct, WrkStr, 4)
  End Sub
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Sfund As Integer, Dept As Integer,
    ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer) As String
    myGLACCT.GetOneRecordP(Fund, Sfund, Dept, Obnbr, Fnpgm, Subfn)
    If Not myGLACCT.RecordNotFound Then
      GetAcctDesc = Trim(myGLACCT._GLDSC) & "  " & Fund & "-" &
       Format(Sfund, "000") & "-" & Format(Dept, "0000") & "-" & Format(Obnbr, "000") &
      "-" & Format(Fnpgm, "0000") & "-" & Format(Subfn, "0000")
    Else
      GetAcctDesc = "*** Unknown ***"
    End If
    Return GetAcctDesc
  End Function
End Module
