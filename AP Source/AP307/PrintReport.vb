Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myAPEHSTQ As APEHSTQ.myData
Dim myAPEBNK As APEBNK.myData
Dim myVENDOR As VENDOR.myData
Dim myGLACCT As GLACCT.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkBank As String
Dim WrkPrData As String
Dim WrkAnd As String
Dim WrkOr As String

  Public Sub PrtReport()

  myAPEHSTQ = New APEHSTQ.MyData()
  myAPEHSTQ.MyDBConn = myDBConnect
  myAPEBNK = New APEBNK.MyData()
  myAPEBNK.MyDBConn = myDBConnect
  myVENDOR = New VENDOR.MyData()
  myVENDOR.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect

  With MyFrmAP307B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkBank = .TxtBank.Text
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
Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("FscYr", Type.GetType("System.Int32"))
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("Date", Type.GetType("System.DateTime"))
      .Columns.Add("Amount1", Type.GetType("System.Decimal"))
      .Columns.Add("Amount2", Type.GetType("System.Decimal"))
      .Columns.Add("PONbr", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("VendName", Type.GetType("System.String"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim sw As StreamWriter
Dim WrkQry As String
Dim WrkSort As String
Dim WrkName As String
Dim WrkAcct As String
Dim WrkAcctDesc As String
Dim SaveCheckNo As Integer
Dim SaveLstP8 As Integer
Dim SaveAmtGr As Decimal
Dim SaveFscyr As Integer
Dim SavePONbr As Integer
Dim SaveVndnr As String
Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "

WrkQry = "BNKCD = " & MyUtils.Quo(WrkBank) & WrkAnd & "AVOID<>'V'"
If MyFrmAP307B.TxtChkFrom.Text <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "CHKPD >=" & MyUtils.CnvSng(MyFrmAP307B.TxtChkFrom.Text) & _
   WrkAnd & "CHKPD <=" & MyUtils.CnvSng(MyFrmAP307B.TxtChkTo.Text)
Else
  WrkQry = WrkQry & WrkAnd & "LSTP8 >= " & WrkFrom & WrkAnd & "LSTP8 <=" & WrkTo
End If

WrkSort = "LSTP8, CHKPD"
SaveCheckNo = 0
SaveVndnr = ""
Counter = 0
WrkName = ""
myAPEHSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If MyFrmAP307B.LblFilePath.Text <> "" Then
  sw = New StreamWriter(MyFrmAP307B.LblFilePath.Text)
  sw.WriteLine(WriteHdr)
End If

ReadNext:
 myAPEHSTQ.ReadQry()
 If Not myAPEHSTQ.IsEOF Then
  Counter = Counter + 1
  myAPEBNK.GetOneRecordP(WrkBank)

  'Create Report
  With myAPEHSTQ
   WrkName = ""
   WrkAcct = ""
   WrkAcctDesc = ""
   If SaveCheckNo = 0 Then
     SaveCheckNo = ._CHKPD
   End If
   If SaveCheckNo <> ._CHKPD Then
    dr = ds.Tables(0).NewRow
    dr.Item("rptid") = "T"
    dr.Item("fscyr") = SaveFscyr
    dr.Item("checkno") = SaveCheckNo
    dr.Item("date") = Format(MyUtils.GetDBDate(SaveLstP8), "M/d/yyyy")
    dr.Item("amount2") = SaveAmtGr
    dr.Item("ponbr") = SavePONbr
    dr.Item("vendor") = SaveVndnr
    With myVENDOR
      .GetOneRecordP(SaveVndnr)
      If Trim(._PYNAM) = "" Then
        WrkName = Trim(._VENNM)
      Else
        WrkName = Trim(._PYNAM)
      End If
      WrkName = DoFlipName(WrkName)
    End With
    dr.Item("vendname") = WrkName
    dr.Item("acctno") = ""
    dr.Item("acctdesc") = ""
    ds.Tables(0).Rows.Add(dr)
     SaveAmtGr = 0
     SaveCheckNo = ._CHKPD
   End If
   If ._RECNO > 0 Then
     dr = ds.Tables(0).NewRow
     dr.Item("rptid") = "D"
     dr.Item("fscyr") = SaveFscyr
     dr.Item("checkno") = ._CHKPD
     dr.Item("date") = Format(MyUtils.GetDBDate(._LSTP8), "M/d/yyyy")
     dr.Item("amount1") = ._AMTGR
     dr.Item("ponbr") = SavePONbr
     dr.Item("vendor") = Trim(._VNDNR)
     dr.Item("vendname") = ""
     WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
     dr.Item("acctno") = WrkAcct
     WrkAcctDesc = (GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN))
     dr.Item("acctdesc") = WrkAcctDesc
     ds.Tables(0).Rows.Add(dr)
     If MyFrmAP307B.LblFilePath.Text <> "" Then
       sw.WriteLine(WriteCSV(SaveFscyr, SavePONbr, WrkName, WrkAcct, WrkAcctDesc))
     End If
  Else
     SaveAmtGr = SaveAmtGr + ._AMTGR
     SaveFscyr = ._FSCYR
     SavePONbr = ._PONBR
     SaveVndnr = Trim(._VNDNR)
     SaveLstP8 = ._LSTP8
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

  dr = ds.Tables(0).NewRow
  dr.Item("rptid") = "T"
  dr.Item("fscyr") = SaveFscyr
  dr.Item("checkno") = SaveCheckNo
  dr.Item("date") = Format(MyUtils.GetDBDate(SaveLstP8), "M/d/yyyy")
  dr.Item("amount2") = SaveAmtGr
  dr.Item("ponbr") = SavePONbr
  dr.Item("vendor") = SaveVndnr
  dr.Item("vendname") = WrkName
  dr.Item("acctno") = ""
  dr.Item("acctdesc") = ""
  ds.Tables(0).Rows.Add(dr)

  If MyFrmAP307B.LblFilePath.Text <> "" Then
    sw.Flush()
    sw.Close()
  End If
  myFrmProgress.Close()
  myAPEHSTQ.CloseFile()

End Sub
Private Function WriteHdr() As String
 Dim sb As StringBuilder

  sb = New StringBuilder
  sb.Append("Fiscal Yr")
  sb.Append(",")
  sb.Append("Check No")
  sb.Append(",")
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
  sb.Append(",")
  sb.Append("Account Description")
 Return sb.ToString

End Function
Private Function WriteCSV(ByVal SaveFscyr As Integer, ByVal SavePONbr As Integer, ByVal WrkName As String, _
 ByVal WrkAcct As String, ByVal WrkAcctDesc As String) As String
 Dim sb As StringBuilder

 sb = New StringBuilder
 With myAPEHSTQ
  sb.Append(SaveFscyr)
  sb.Append(",")
  sb.Append(._CHKPD)
  sb.Append(",")
  sb.Append(._AMTPD)
  sb.Append(",")
  sb.Append(Format(MyUtils.GetDBDate(._LSTP8), "M/d/yyyy"))
  sb.Append(",")
  sb.Append(SavePONbr)
  sb.Append(",")
  sb.Append(._VNDNR)
  sb.Append(",")
  sb.Append(WrkName)
  sb.Append(",")
  sb.Append(WrkAcct)
  sb.Append(",")
  sb.Append(WrkAcctDesc)
 End With
 Return sb.ToString

End Function
Public Function SetVndrAddrLine(ByVal Add1 As String, ByVal Add2 As String, _
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String, _
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
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Sfund As Integer, Dept As Integer, _
    ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer) As String
     myGLACCT.GetOneRecordP(Fund, Sfund, Dept, Obnbr, Fnpgm, Subfn)
     If Not myGLACCT.RecordNotFound Then
       GetAcctDesc = Trim(myGLACCT._GLDSC) ' & " " & Format(Dept, "0000") & "-" & Format(Obnbr, "000") & _
      '"-" & Format(Fnpgm, "0000") & "-" & Format(Subfn, "0000")
     Else
       GetAcctDesc = "*** Unknown ***"
     End If
     Return GetAcctDesc
  End Function
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
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
