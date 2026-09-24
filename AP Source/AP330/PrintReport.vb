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

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkPrData As String
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPEHSTQ = New APEHSTQ.MyData()
    myAPEHSTQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP330B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
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
      .Columns.Add("Date", Type.GetType("System.DateTime"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkName As String
    Dim WrkAcct As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "LSTP8 >= " & WrkFrom & WrkAnd & "LSTP8 <=" & WrkTo & WrkAnd & "AVOID<>'V'"
    WrkSort = "LSTP8, CHKPD"
    Counter = 0
    If MyFrmAP330B.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmAP330B.LblFilePath.Text)
      sw.WriteLine(WriteHdr)
    End If
    myAPEHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myAPEHSTQ.ReadQry()
    If Not myAPEHSTQ.IsEOF Then
      Counter = Counter + 1
      myVENDOR.GetOneRecordP(myAPEHSTQ._VNDNR)

      'Create Report
      With myAPEHSTQ
        WrkName = ""
        WrkAcct = ""
        If ._RECNO > 0 Then
          dr = ds.Tables(0).NewRow
          dr.Item("date") = Format(MyUtils.GetDBDate(._LSTP8), "M/d/yyyy")
          dr.Item("invno") = ._INVNO
          dr.Item("descr") = Trim(._DSCTX)
          dr.Item("amount") = ._AMTGR
          dr.Item("vendor") = Trim(._VNDNR)
          'With myVENDOR
          '  If Trim(._PYNAM) = "" Then
          '    WrkName = Trim(._VENNM)
          '  Else
          '    WrkName = Trim(._PYNAM)
          '  End If
          '  WrkName = DoFlipName(WrkName)
          'End With
          'dr.Item("vendname") = WrkName
          WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("acctno") = WrkAcct
          ds.Tables(0).Rows.Add(dr)
          If MyFrmAP330B.LblFilePath.Text <> "" Then
            sw.WriteLine(WriteCSV(WrkName, WrkAcct))
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

    If MyFrmAP330B.LblFilePath.Text <> "" Then
      sw.Close()
    End If
    myFrmProgress.Close()
    myAPEHSTQ.CloseFile()

  End Sub
  Private Function WriteHdr() As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append("Amount")
    sb.Append(",")
    sb.Append("Check Date")
    sb.Append(",")
    sb.Append("PO Nbr")
    sb.Append(",")
    sb.Append("Vend No")
    sb.Append(",")
    sb.Append("Vendor Name")
    sb.Append(",")
    sb.Append("Account Number")
    Return sb.ToString

  End Function
  Private Function WriteCSV(ByVal WrkName As String, ByVal WrkAcct As String) As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    With myAPEHSTQ
      sb.Append(._AMTPD)
      sb.Append(",")
      sb.Append(Format(MyUtils.GetDBDate(._LSTP8), "M/d/yyyy"))
      sb.Append(",")
      sb.Append(._PONBR)
      sb.Append(",")
      sb.Append(._VNDNR)
      sb.Append(",")
      sb.Append(WrkName)
      sb.Append(",")
      sb.Append(WrkAcct)
    End With
    Return sb.ToString

  End Function
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
  Private Function DoFlipName(ByVal Name As String) As String
    Dim WrkName As String
    Dim Pos As Integer

    WrkName = ""
    Pos = InStr(Name, ",", CompareMethod.Text)
    If Pos > 0 Then
      WrkName = Trim(Mid(Name, Pos + 1, 40)) & " " & Mid(Name, 1, Pos - 1)
    Else
      WrkName = Name
    End If

    Return WrkName
  End Function

End Module
