Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPERCNQ As APERCNQ.myData
  Dim myCKHISTQ As CKHISTQ.myData
  Dim myAPEBNK As APEBNK.myData
  Dim myVENDOR As VENDOR.myData
  Dim myPRMASTA As PRMASTA.myData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBank As String
  Dim WrkPrData As String
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPERCNQ = New APERCNQ.myData(myDBConnect.PgmDB)
    myCKHISTQ = New CKHISTQ.myData(myDBConnect.PgmDB)
    myAPEBNK = New APEBNK.myData(myDBConnect.PgmDB)
    myVENDOR = New VENDOR.myData(myDBConnect.PgmDB)
    myPRMASTA = New PRMASTA.myData(myDBConnect.PgmDB, MyPRPrefix)

    With MyFrmAP405B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBank = .TxtBank.Text
      WrkPrData = "*"
      If .RbDataRegular.Checked Then
        WrkPrData = "3"
      End If
      If .RbDataSupport.Checked Then
        WrkPrData = " "
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    With MyFrmAP405B
      If MyAP Then
        GetDetailAP()
      Else
        GetDetailPR()
      End If
    End With

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
      .Columns.Add("Void", Type.GetType("System.String"))
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("Date", Type.GetType("System.DateTime"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Name", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailAP()
    Dim sw As StreamWriter = New StreamWriter(MyFrmAP405B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAcct As String

    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    If MyFrmAP405B.TxtChkFrom.Text <> String.Empty Then
      WrkQry = "PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd & "PAYCK >=" & MyUtils.CnvSng(MyFrmAP405B.TxtChkFrom.Text) & WrkAnd & "PAYCK <=" & MyUtils.CnvSng(MyFrmAP405B.TxtChkTo.Text)
    Else
      WrkQry = "PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd & "PAYP8 >= " & WrkFrom & WrkAnd & "PAYP8 <=" & WrkTo
    End If

    WrkSort = "PAYCK"
    Counter = 0
    myAPERCNQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmAP405B.RbAPCSV.Checked Then
      sw.WriteLine(WriteAPCSVHdr)
    End If

ReadNext:
    myAPERCNQ.ReadQry()
    If Not myAPERCNQ.IsEOF Then
      Counter = Counter + 1
      myAPEBNK.GetOneRecordP(WrkBank)
      With myAPEBNK
        WrkAcct = Trim(._BNKAC)
      End With
      myVENDOR.GetOneRecordP(myAPERCNQ._VNDNR)
      If MyFrmAP405B.RbAP.Checked Then
        sw.WriteLine(WriteAPFile(WrkAcct))
      End If
      If MyFrmAP405B.RbAPTD.Checked Then
        sw.WriteLine(WriteAPTDFile(WrkAcct))
      End If
      If MyFrmAP405B.RbAPBOA.Checked Then
        sw.WriteLine(WriteAPBOAFile(WrkAcct))
      End If
      If MyFrmAP405B.RbAPBOAShort.Checked Then
        sw.WriteLine(WriteAPBOAShortFile(WrkAcct))
      End If
      If MyFrmAP405B.RbAPWebster.Checked Then
        sw.WriteLine(WriteAPWebster(WrkAcct))
      End If
      If MyFrmAP405B.RbAPCSV.Checked Then
        sw.WriteLine(WriteAPCSV(WrkAcct))
      End If

      'Create Report
      With myAPERCNQ
        dr = ds.Tables(0).NewRow
        If ._RCCDE = "P" Or ._RCCDE = "V" Then
          dr.Item("void") = "V"
        Else
          dr.Item("void") = String.Empty
        End If
        dr.Item("checkno") = ._PAYCK
        dr.Item("date") = MyUtils.GetDBDate(._PAYP8)
        dr.Item("amount") = ._PAYAM
        If Not myVENDOR.RecordNotFound Then
          dr.Item("name") = Trim(myVENDOR._VENNM)
        Else
          dr.Item("name") = Trim(._VNDNR)
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

    sw.Close()
    myFrmProgress.Close()
    myAPERCNQ.CloseFile()

  End Sub
  Private Function WriteAPFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer

    With myAPERCNQ
      sb.Append(MyUtils.JustifyRight(WrkAcct, 14, "0"))
      sb.Append(MyUtils.JustifyLeft("", 1))
      sb.Append(MyUtils.JustifyRight(._PAYCK, 10, "0"))
      sb.Append(MyUtils.JustifyLeft("", 1))
      WrkInteger = ._PAYAM * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 10, "0"))
      sb.Append(MyUtils.JustifyLeft("", 1))
      sb.Append(._PAYP8)
      sb.Append(MyUtils.JustifyLeft("", 1))
      sb.Append(._RCCDE)
    End With
    Return sb.ToString

  End Function
  Private Function WriteAPBOAFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myAPERCNQ
      sb.Append(MyUtils.JustifyRight(._PAYCK, 10, "0"))
      WrkInteger = ._PAYAM * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      WrkDate = MyUtils.GetDBDate(._PAYP8)
      sb.Append(Mid(WrkDate.Year, 3, 2))
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append("      ")
      sb.Append(MyUtils.JustifyRight(WrkAcct, 12, "0"))
      sb.Append("O")
      If myVENDOR.RecordNotFound Then
        sb.Append(._VNDNR)
      Else
        sb.Append(Trim(myVENDOR._VENNM))
      End If
    End With
    Return sb.ToString

  End Function
  Private Function WriteAPBOAShortFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myAPERCNQ
      sb.Append(MyUtils.JustifyRight(._PAYCK, 10, "0"))
      WrkInteger = ._PAYAM * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      WrkDate = MyUtils.GetDBDate(._PAYP8)
      sb.Append(Mid(WrkDate.Year, 3, 2))
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append("      ")
      sb.Append(MyUtils.JustifyRight(WrkAcct, 10, "0"))
      sb.Append("O")
    End With
    Return sb.ToString

  End Function
  Private Function WriteAPTDFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myAPERCNQ
      sb.Append("0004") 'Bank ID
      sb.Append("02") 'Checking Acct
      sb.Append(MyUtils.JustifyRight(WrkAcct, 16, "0"))
      sb.Append("60") 'Deposit
      sb.Append(MyUtils.JustifyRight(._PAYCK, 10, "0"))
      WrkInteger = ._PAYAM * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      If myVENDOR.RecordNotFound Then
        sb.Append(MyUtils.JustifyLeft(._VNDNR, 30))
      Else
        sb.Append(MyUtils.JustifyLeft(Trim(myVENDOR._VENNM), 30))
      End If
      WrkDate = MyUtils.GetDBDate(._PAYP8)
      sb.Append(WrkDate.Year)
      sb.Append(MyUtils.JustifyRight(WrkDate.DayOfYear, 3, "0"))
      If ._RCCDE <> "P" And ._RCCDE <> "V" Then
        sb.Append("10") 'Issue
      Else
        sb.Append("11") 'Void
      End If
    End With
    Return sb.ToString

  End Function
  Private Function WriteAPWebster(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    Dim WrkName As String
    Dim WrkFlipName As String
    Dim AddrLine() As String
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    sb = New StringBuilder
    With myAPERCNQ
      sb.Append(MyUtils.JustifyRight(WrkAcct, 10, "0"))
      sb.Append(MyUtils.JustifyRight(._PAYCK, 10, "0"))
      sb.Append(" ") 'Issue
      WrkInteger = ._PAYAM * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 12, "0"))
      WrkDate = MyUtils.GetDBDate(._PAYP8)
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append(Mid(WrkDate.Year, 3, 2))
    End With
    If myVENDOR.RecordNotFound Then
      sb.Append(MyUtils.JustifyLeft(myVENDOR._VNDNR, 50))
      sb.Append(MyUtils.JustifyLeft("", 50))
      sb.Append(MyUtils.JustifyLeft("", 50))
    Else
      With myVENDOR
        If Trim(._PYNAM) = "" Then
          WrkName = Trim(._VENNM)
          WrkFlipName = DoFlipName(Trim(._VENNM))
          AddrLine = SetVndrAddrLine(._VADD1, ._VADD2, ._VADD3,
         ._VADD4, ._VZIP, ._VZIPE)
        Else
          WrkName = Trim(._PYNAM)
          WrkFlipName = DoFlipName(Trim(._PYNAM))
          AddrLine = SetVndrAddrLine(._PYAD1, ._PYAD2, ._PYAD3,
        ._PYAD4, ._PYZIP, ._PYZIPE)
        End If
      End With
      sb.Append(MyUtils.JustifyLeft(WrkFlipName, 50))
      sb.Append(MyUtils.JustifyLeft(AddrLine(0), 50))
      sb.Append(MyUtils.JustifyLeft(AddrLine(1), 50))
    End If
    Return sb.ToString

  End Function
  Private Function WriteAPCSVHdr() As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append("Check No")
    sb.Append(",")
    sb.Append("Amount")
    sb.Append(",")
    sb.Append("Check Date")
    sb.Append(",")
    sb.Append("Vend No")
    sb.Append(",")
    sb.Append("Vendor Name")
    Return sb.ToString

  End Function
  Private Function WriteAPCSV(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    Dim WrkName As String
    Dim WrkFlipName As String

    sb = New StringBuilder
    With myAPERCNQ
      sb.Append(._PAYCK)
      sb.Append(",")
      sb.Append(._PAYAM)
      sb.Append(",")
      sb.Append(._PAYP8)
      sb.Append(",")
      sb.Append(._VNDNR)
      sb.Append(",")
    End With
    If myVENDOR.RecordNotFound Then
      sb.Append("")
    Else
      With myVENDOR
        If Trim(._PYNAM) = "" Then
          WrkName = Trim(._VENNM)
          WrkFlipName = DoFlipName(Trim(._VENNM))
        Else
          WrkName = Trim(._PYNAM)
          WrkFlipName = DoFlipName(Trim(._PYNAM))
        End If
      End With
      sb.Append(WrkFlipName)
    End If
    Return sb.ToString

  End Function
  Private Sub GetDetailPR()
    Dim sw As StreamWriter = New StreamWriter(MyFrmAP405B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAcct As String
    Dim WrkDate As Date
    Dim WrkByCheckNo As Boolean
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = String.Empty
    If MyFrmAP405B.TxtChkFrom.Text <> String.Empty Then
      WrkByCheckNo = True
      WrkQry = "CKNUM >=" & MyUtils.CnvSng(MyFrmAP405B.TxtChkFrom.Text) & WrkAnd & "CKNUM <=" & MyUtils.CnvSng(MyFrmAP405B.TxtChkTo.Text)
    Else
      WrkByCheckNo = False
    End If
    If WrkPrData <> "*" Then
      If WrkQry <> "" Then
        WrkQry = WrkQry & WrkAnd & "PORV = '" & WrkPrData & "'"
      Else
        WrkQry = "PORV = '" & WrkPrData & "'"
      End If
    End If
    WrkSort = "CKNUM"
    Counter = 0
    myCKHISTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmAP405B.RbPRCSV.Checked Then
      sw.WriteLine(WritePRCSVHdr)
    End If

ReadNext:
    myCKHISTQ.ReadQry()
    If Not myCKHISTQ.IsEOF Then
      Counter = Counter + 1
      With myCKHISTQ
        If Not WrkByCheckNo Then
          WrkDate = MyUtils.GetDBDateMDY(._CHKDTE)
          If WrkDate < MyFrmAP405B.DtPckFrom.Value Then
            GoTo NextRec
          End If
          If WrkDate > MyFrmAP405B.DtPckTo.Value Then
            GoTo NextRec
          End If
        End If
      End With
      myAPEBNK.GetOneRecordP(WrkBank)
      With myAPEBNK
        WrkAcct = Trim(._BNKAC)
      End With
      If MyFrmAP405B.RbPRTD.Checked Then
        sw.WriteLine(WritePRTDFile(WrkAcct))
      End If
      If MyFrmAP405B.RbPRBOA.Checked Then
        sw.WriteLine(WritePRBOAFile(WrkAcct))
      End If
      If MyFrmAP405B.RbPRBOAShort.Checked Then
        sw.WriteLine(WritePRBOAShortFile(WrkAcct))
      End If
      If MyFrmAP405B.RbPRWebster.Checked Then
        sw.WriteLine(WritePRWebster(WrkAcct))
      End If
      If MyFrmAP405B.RbPRCSV.Checked Then
        sw.WriteLine(WritePRCSV(WrkAcct))
      End If

      'Create Report
      With myCKHISTQ
        dr = ds.Tables(0).NewRow
        If ._PORV = "P" Or ._PORV = "V" Then
          dr.Item("void") = "V"
        Else
          dr.Item("void") = String.Empty
        End If
        dr.Item("checkno") = ._CKNUM
        dr.Item("date") = MyUtils.GetDBDateMDY(._CHKDTE)
        dr.Item("amount") = ._CKAMT
        dr.Item("name") = Trim(._EMNAME)
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

    sw.Close()
    myFrmProgress.Close()
    myCKHISTQ.CloseFile()

  End Sub
  Private Function WritePRTDFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myCKHISTQ
      sb.Append("0004") 'Bank ID
      sb.Append("02") 'Checking Acct
      sb.Append(MyUtils.JustifyRight(WrkAcct, 16, "0"))
      sb.Append("60") 'Deposit
      sb.Append(MyUtils.JustifyRight(._CKNUM, 10, "0"))
      WrkInteger = ._CKAMT * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      sb.Append(MyUtils.JustifyLeft(Trim(._EMNAME), 30))
      WrkDate = MyUtils.GetDBDateMDY(._CHKDTE)
      sb.Append(WrkDate.Year)
      sb.Append(MyUtils.JustifyRight(WrkDate.DayOfYear, 3, "0"))
      If ._PORV <> "P" And ._PORV <> "V" Then
        sb.Append("10") 'Issue
      Else
        sb.Append("11") 'Void
      End If
    End With
    Return sb.ToString

  End Function
  Private Function WritePRBOAFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myCKHISTQ
      sb.Append(MyUtils.JustifyRight(._CKNUM, 10, "0"))
      WrkInteger = ._CKAMT * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      WrkDate = MyUtils.GetDBDateMDY(._CHKDTE)
      sb.Append(Mid(WrkDate.Year, 3, 2))
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append("      ")
      sb.Append(MyUtils.JustifyRight(WrkAcct, 12, "0"))
      If ._PORV <> "P" And ._PORV <> "V" Then
        sb.Append("O") 'Issue
      Else
        sb.Append("V") 'Void
      End If
      sb.Append(Trim(._EMNAME))
    End With
    Return sb.ToString

  End Function
  Private Function WritePRBOAShortFile(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    sb = New StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date

    With myCKHISTQ
      sb.Append(MyUtils.JustifyRight(._CKNUM, 10, "0"))
      WrkInteger = ._CKAMT * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 11, "0"))
      WrkDate = MyUtils.GetDBDateMDY(._CHKDTE)
      sb.Append(Mid(WrkDate.Year, 3, 2))
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append("      ")
      sb.Append(MyUtils.JustifyRight(WrkAcct, 10, "0"))
      If ._PORV <> "P" And ._PORV <> "V" Then
        sb.Append("O") 'Issue
      Else
        sb.Append("V") 'Void
      End If
    End With
    Return sb.ToString

  End Function
  Private Function WritePRWebster(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    Dim WrkInteger As Integer
    Dim WrkDate As Date
    Dim AddrLine() As String
    Dim WrkFlipName As String
    Dim WrkAddr1 As String
    Dim WrkAddr2 As String

    sb = New StringBuilder
    With myCKHISTQ
      sb.Append(MyUtils.JustifyRight(WrkAcct, 10, "0"))
      sb.Append(MyUtils.JustifyRight(._CKNUM, 10, "0"))
      sb.Append(" ") 'Issue
      WrkInteger = ._CKAMT * 100
      sb.Append(MyUtils.JustifyRight(WrkInteger, 12, "0"))
      WrkDate = MyUtils.GetDBDateMDY(._CHKDTE)
      sb.Append(Format(WrkDate.Month, "00"))
      sb.Append(Format(WrkDate.Day, "00"))
      sb.Append(Mid(WrkDate.Year, 3, 2))
      WrkFlipName = DoFlipName(Trim(._EMNAME))
      sb.Append(MyUtils.JustifyLeft(WrkFlipName, 50))
      WrkAddr1 = String.Empty
      WrkAddr2 = String.Empty
      myPRMASTA.GetOneRecordP(._EMPNO)
      If Not myPRMASTA.RecordNotFound Then
        WrkAddr1 = myPRMASTA._EMADD1
        If Trim(myPRMASTA._EMADD2) <> String.Empty Then
          WrkAddr2 = myPRMASTA._EMADD2
        Else
          WrkAddr2 = Trim(myPRMASTA._EMADD3) & ", " & myPRMASTA._EMSTAT & " " & myPRMASTA._EMZPCD
        End If
      Else
        myVENDOR.GetOneRecordP(MyUtils.CnvSng(._EMPNO))
        With myVENDOR
          If Trim(._PYNAM) = "" Then
            AddrLine = SetVndrAddrLine(._VADD1, ._VADD2, ._VADD3,
         ._VADD4, ._VZIP, ._VZIPE)
          Else
            AddrLine = SetVndrAddrLine(._PYAD1, ._PYAD2, ._PYAD3,
        ._PYAD4, ._PYZIP, ._PYZIPE)
          End If
        End With
        WrkAddr1 = AddrLine(0)
        WrkAddr2 = AddrLine(1)
      End If
      sb.Append(MyUtils.JustifyLeft(WrkAddr1, 50))
      sb.Append(MyUtils.JustifyLeft(WrkAddr2, 50))
    End With
    Return sb.ToString

  End Function
  Private Function WritePRCSVHdr() As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append("Check No")
    sb.Append(",")
    sb.Append("Amount")
    sb.Append(",")
    sb.Append("Check Date")
    sb.Append(",")
    sb.Append("Emp No")
    sb.Append(",")
    sb.Append("Name")
    Return sb.ToString

  End Function
  Private Function WritePRCSV(ByVal WrkAcct As String) As String
    Dim sb As StringBuilder
    Dim WrkFlipName As String

    sb = New StringBuilder
    With myCKHISTQ
      sb.Append(._CKNUM)
      sb.Append(",")
      sb.Append(._CKAMT)
      sb.Append(",")
      sb.Append(._CHKDTE)
      sb.Append(",")
      sb.Append(._EMPNO)
      sb.Append(",")
      WrkFlipName = DoFlipName(Trim(._EMNAME))
      sb.Append(WrkFlipName)
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
