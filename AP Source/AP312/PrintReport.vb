Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEHSTQ As APEHSTQ.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFromFund As Integer
  Dim WrkToFund As Integer
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkAddr As Boolean
  Dim WrkVoid As Boolean
  Dim WrkSortby As String
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPEHSTQ = New APEHSTQ.MyData()
    myAPEHSTQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP312B
      If .RbSortNumber.Checked Then WrkSortby = "Number"
      If .RbSortSort.Checked Then WrkSortby = "Sort"
      WrkFromFund = MyUtils.CnvSng(.TxtFromFund.Text)
      WrkToFund = MyUtils.CnvSng(.TxtToFund.Text)
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkAddr = .ChkAddr.Checked
      WrkVoid = .ChkVoid.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
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
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("vndnr", Type.GetType("System.String"))
      .Columns.Add("amtpd", Type.GetType("System.Decimal"))
      .Columns.Add("vennm", Type.GetType("System.String"))
      .Columns.Add("vadd1", Type.GetType("System.String"))
      .Columns.Add("vadd2", Type.GetType("System.String"))
      .Columns.Add("vadd3", Type.GetType("System.String"))
      .Columns.Add("vadd4", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkGroup As String
    Dim Counter As Integer
    If myDBConnect.ServerName = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "PPDT8 >= " & WrkFrom & WrkAnd & "PPDT8 <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RECNO = 0"
    If Not WrkVoid Then
      WrkQry = WrkQry & WrkAnd & "AVOID<>'V'"
    End If
    If WrkFromFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFromFund
    End If
    If WrkToFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkToFund
    End If
    If Trim(MyFrmAP312B.TxtVndFrom.Text) <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "VNDNR >=" & MyUtils.Quo(MyFrmAP312B.TxtVndFrom.Text)
    End If
    If Trim(MyFrmAP312B.TxtVndTo.Text) <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "VNDNR <=" & MyUtils.Quo(MyFrmAP312B.TxtVndTo.Text)
    End If

    If WrkSortby = "Sort" Then
      WrkSort = "VSORT, VNDNR"
      WrkGroup = "VSORT, VNDNR"
    Else
      WrkSort = "VNDNR"
      WrkGroup = "VNDNR"
    End If
    Counter = 0
    myAPEHSTQ.SumPaidQry(WrkGroup, WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()


ReadNext:
    myAPEHSTQ.ReadQrySum()
    If Not myAPEHSTQ.IsEOF Then
      Counter = Counter + 1
      myVENDOR.GetOneRecordP(myAPEHSTQ._VNDNR)
      If WrkAddr Then
        AddrLine = SetVndrAddrLine(myVENDOR._VADD1, myVENDOR._VADD2, myVENDOR._VADD3, myVENDOR._VADD4,
       myVENDOR._VZIP, myVENDOR._VZIPE)
      End If
      'Create Report
      With myAPEHSTQ
        dr = ds.Tables(0).NewRow
        dr.Item("rptid") = "D"
        dr.Item("vndnr") = ._VNDNR
        dr.Item("amtpd") = ._SUMAMTPD
        dr.Item("vennm") = myVENDOR._VENNM
        If WrkAddr Then
          dr.Item("vadd1") = AddrLine(0)
          dr.Item("vadd2") = AddrLine(1)
          dr.Item("vadd3") = AddrLine(2)
          dr.Item("vadd4") = AddrLine(3)
        End If
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
    myAPEHSTQ.CloseFile()

  End Sub
  Public Function SetVndrAddrLine(ByVal Add1 As String, ByVal Add2 As String,
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String,
   ByVal Zip4 As String) As String()
    'Returns Address as string array. Blank lines are stripped out. 
    Dim AddrLine(3) As String
    Dim sb As StringBuilder
    Dim I As Integer

    Add1 = Trim(Add1)
    Add2 = Trim(Add2)
    Add3 = Trim(Add3)
    Add4 = Trim(Add4)
    Zip5 = Trim(Zip5)
    Zip4 = Trim(Zip4)

    AddrLine(I) = Add1
    If Add2 <> "" Then
      I = I + 1
      AddrLine(I) = Add2
    End If
    If Add3 <> "" Then
      I = I + 1
      AddrLine(I) = Add3
    End If
    If Add4 <> "" Then
      I = I + 1
      AddrLine(I) = Add4
    End If
    If Zip5 <> "" Then
      sb = New StringBuilder
      sb.Append(Zip5)
      If Zip4 <> "" Then
        sb.Append("-")
        sb.Append(Zip4)
      End If
      AddrLine(I) = AddrLine(I) & " " & sb.ToString
    End If
    For I = 2 To 3
      If AddrLine(I) Is Nothing Then
        AddrLine(I) = ""
      End If
    Next
    Return AddrLine

  End Function
End Module
