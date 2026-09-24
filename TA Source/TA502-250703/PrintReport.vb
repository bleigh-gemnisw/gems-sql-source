Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPP As TXSupp.MyData
  Dim myTXSUPPL4 As TXSUPPL4.MyData
  Dim myTXSUPPL6 As TXSUPPL6.MyData
  Dim myTXMVDCL1 As TXMVDCL1.MyData
  Dim myTXMVDCL2 As TXMVDCL2.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXCODE As TXCODE.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXVCLS As TXVCLS.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVCUS2 As TXVCUS.MyData
  Dim myTXVEH As TXVEH.MyData
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myDBUtils As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim dssuppl4 As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkStartNo As Integer
  Dim WrkCount As Integer
  Dim WrkCountOid As Integer
  Dim WrkSkipped As Integer
  Dim WrkOutDated As Integer
  Dim WrkInstall As Boolean
  Dim WrkOnlyDMVCust As Boolean
  Const CAssPct As Decimal = 0.7
  Const CClassicVehicle As Integer = 500
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupMonth(25) As String
  Dim WrkSupPct(25) As Decimal
  Public Sub PrtReport()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkYear As Integer

    myTXSUPP = New TXSupp.MyData(myDBConnect)
    myTXSUPPL4 = New TXSUPPL4.MyData(myDBConnect)
    myTXSUPPL6 = New TXSUPPL6.MyData(myDBConnect)
    myTXMVDCL1 = New TXMVDCL1.MyData(myDBConnect)
    myTXMVDCL2 = New TXMVDCL2.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXCODE = New TXCODE.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXVCLS = New TXVCLS.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVCUS2 = New TXVCUS.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    With MyFrmTA502B
      If WrkInstall Then
        WrkStartNo = myTXSUPP.AutoGenKey
      Else
        WrkStartNo = MyUtils.CnvSng(.TxtStartNo.Text)
      End If
      WrkInstall = .RbInstall.Checked
      WrkOnlyDMVCust = .ChkOnlyDMVCust.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      ds2 = ds.Clone
      ds3 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
    End If

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If
    WrkYear = Date.Now.Year - 1
    WrkSort = "IMVID#"
    WrkQry = "YEAR = " & WrkYear & WrkAnd & "TYPE = 'M'" & WrkAnd & "CCNO > 0"
    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
    BufferTXSupcd()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .Wrkds3 = ds3
      .WrkCount = WrkCount
      .WrkSkipped = WrkSkipped
      .WrkOutDated = WrkOutDated
      .WrkMinValue = MyMinValue
      .Show()
    End With
  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.Int32"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("Body", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("Errmsg", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub ClearComments()
    myTAXCOM.DeleteTypeYear("S", 0)
  End Sub
  Private Sub GetDetail()
    Dim dstemp As DataSet
    Dim DsTXMVD As DataSet = New DataSet
    Dim dsTXSUPP As DataSet = New DataSet
    Dim WrkStream As FileStream = New FileStream(MyFrmTA502B.LblFilePath.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim SArray As String()
    Dim WrkRecNo As Integer
    Dim WrkCat As String
    Dim WrkPName As String
    Dim WrkSName As String
    Dim WrkLname As String
    Dim WrkZip As String
    Dim WrkRegDate As Date
    Dim WrkYear As Integer
    Dim WrkAss As String
    Dim WrkClass As Integer
    Dim WrkVIN As String
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkDeyear As Integer
    Dim WrkDepr As Decimal
    Dim WrkValue As Integer
    Dim WrkTrVal As Integer
    Dim WrkLnVal As Integer
    Dim WrkBody As String
    Dim WrkNewValue As Integer
    Dim WrkProrate As Integer
    Dim WrkProratePct As Decimal
    Dim WrkCredit As Integer
    Dim WrkCreditPct As Decimal
    Dim WrkGLDate As Integer
    Dim WrkIsOutdated As Boolean
    Dim WrkStr As String()
    Dim Answer As Integer
    Dim WrkErrMsg As String
    Dim Pos As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkRecNo = 0
    WrkSkipped = 0
    WrkOutDated = 0
    WrkCount = 0
    WrkCountOid = 0

    If WrkOnlyDMVCust Then
      Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
   "Refresh DMV Customer file ONLY (Do NOT install Suppl. MV file")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If
    Else
      Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
   "Process Suppl. MV File")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If

      If WrkInstall Then
        myDBUtils.DeleteAllRecs("TXSUPP")
      End If
    End If
    strBuffer = sr.ReadLine 'Skip Headers
    WrkGLDate = (Date.Now.Year - 1) & "1002"

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    WrkErrMsg = ""
    SArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length

    WrkYear = SArray(6)
    If WrkYear < 100 Then
      If WrkYear >= 80 Then
        WrkYear = WrkYear + 1900
      Else
        WrkYear = WrkYear + 2000
      End If
    End If
    WrkPName = ""
    If SArray(34) <> String.Empty Then
      WrkPName = SArray(34)
    Else
      WrkPName = SArray(37)
      If SArray(35) <> String.Empty Then
        WrkPName = WrkPName & " " & SArray(35)
      End If
      If SArray(36) <> String.Empty Then
        WrkPName = WrkPName & " " & SArray(36)
      End If
      If SArray(38) <> String.Empty Then
        WrkPName = WrkPName & " " & SArray(38)
      End If
    End If
    'Check For Duplicate VIN
    With myTXSUPPL4
      dssuppl4 = .GetViewbyVIN(Trim(SArray(3)), 1, False)
      If dssuppl4.Tables(0).Rows.Count > 0 Then
        If Trim(SArray(3)) = Trim(dssuppl4.Tables(0).Rows(0).Item("vinno")) Then
          WrkSkipped = WrkSkipped + 1
          dr = ds2.Tables(0).NewRow
          dr.Item("listno") = 0
          dr.Item("name") = WrkPName
          dr.Item("class") = 0
          dr.Item("make") = SArray(4)
          dr.Item("year") = WrkYear
          dr.Item("vinno") = SArray(3)
          dr.Item("model") = SArray(5)
          dr.Item("body") = SArray(7)
          dr.Item("regno") = SArray(26)
          dr.Item("value") = 0
          dr.Item("errmsg") = "DUP VIN"
          ds2.Tables(0).Rows.Add(dr)
          GoTo NextRec
        End If
      End If
    End With

    WrkSName = ""
    If SArray(53) <> String.Empty Then
      WrkSName = SArray(53)
    Else
      WrkSName = SArray(56)
      If SArray(54) <> String.Empty Then
        WrkSName = WrkSName & " " & SArray(54)
      End If
      If SArray(55) <> String.Empty Then
        WrkSName = WrkSName & " " & SArray(55)
      End If
      If SArray(57) <> String.Empty Then
        WrkSName = WrkSName & " " & SArray(57)
      End If
    End If

    WrkClass = GetTXVCLSCode(SArray(27))
    'Calculate Assessment Values
    WrkValue = 0
    WrkOvMSRP = 0
    WrkVIN = Mid(SArray(3), 1, 17)
    myTXMSRP.GetOneRecordP(WrkVIN)
    With myTXVEH
      .GetOneRecordP(SArray(2))
      If Not .RecordNotFound Then
        If ._MSRP > 0 Then
          WrkMSRP = ._MSRP
        Else
          WrkMSRP = MyUtils.CnvSng(SArray(17))
        End If
        If Not myTXMSRP.RecordNotFound Then
          WrkOvMSRP = myTXMSRP._OVMSRP
        End If
      Else
        WrkMSRP = MyUtils.CnvSng(SArray(17))
        WrkOvMSRP = 0
      End If
    End With
    WrkCat = "1"
    With myTXCODE
      .GetOneRecordP(WrkClass, "M")
      Select Case Trim(._MVINST)
        Case = "N" 'Non Taxable
          WrkCat = "2"
        Case = "Z" 'Zero MSRP
          WrkMSRP = 0
        Case Else
      End Select
    End With
    With myTXMSRP
      If Not .RecordNotFound Then
        If ._NONTAX = "Y" Then
          WrkCat = "2"
        End If
      End If
    End With

    WrkDeyear = 2024 - WrkYear + 1
    If WrkDeyear < 1 Then
      WrkDeyear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeyear)
    If Trim(myTXCODE._MVINST) = "M" Then 'Min Value
      WrkValue = MyMinValue
    Else
      If WrkOvMSRP > 0 Then
        WrkValue = WrkOvMSRP * WrkDepr * MyBookPct
      Else
        If WrkMSRP > 0 Then
          WrkValue = WrkMSRP * WrkDepr * MyBookPct
        End If
      End If
    End If
    WrkTrVal = MyUtils.CnvSng(SArray(15)) * CAssPct
    WrkLnVal = MyUtils.CnvSng(SArray(18)) * CAssPct
    If MyMinValue > WrkValue And WrkValue > 0 Then
      WrkNewValue = MyMinValue
    Else
      WrkNewValue = WrkValue
    End If
    WrkNewValue = MyUtils.Round10(WrkNewValue, "Normal")

    WrkIsOutdated = False
    If MyUtils.SetDBDate(SArray(31)) <= MyUtils.CnvSng(Date.Now.Year - 1 & "1001") Then
      WrkSkipped = WrkSkipped + 1
      dr = ds2.Tables(0).NewRow
      dr.Item("listno") = 0
      dr.Item("name") = WrkPName
      dr.Item("class") = WrkClass
      dr.Item("make") = SArray(4)
      dr.Item("year") = WrkYear
      dr.Item("vinno") = SArray(3)
      dr.Item("model") = SArray(5)
      dr.Item("body") = SArray(7)
      dr.Item("regno") = SArray(26)
      dr.Item("value") = WrkValue
      dr.Item("errmsg") = SArray(31)
      ds2.Tables(0).Rows.Add(dr)
      GoTo NextRec
    End If
    If MyUtils.SetDBDate(SArray(31)) > MyUtils.CnvSng(Date.Now.Year & "0731") And
   MyUtils.SetDBDate(SArray(31)) < MyUtils.CnvSng(Date.Now.Year & "1002") Then
      WrkIsOutdated = True
    End If

    If MyUtils.CnvSng(SArray(2)) > 0 Then
      With myTXVEH
        .GetOneRecordP(SArray(2))
        ._BODY = Mid(SArray(7), 1, 30)
        ._CHDATE = MyUtils.SetDBDate(SArray(0))
        ._CLASS = WrkClass
        ._CLASSD = SArray(27)
        If MyUtils.CnvSng(SArray(12)) < 10 Then
          ._CYLAX = MyUtils.CnvSng(SArray(12))
        Else
          ._CYLAX = 0
        End If
        ._DADD1 = Mid(SArray(20), 1, 35)
        ._DADD2 = Mid(SArray(21), 1, 35)
        ._DCITY = Mid(SArray(22), 1, 25)
        ._DSTATE = SArray(23)
        ._DZIPA = FormatZip(SArray(24))
        ._ENDDT = MyUtils.SetDBDate(SArray(31))
        ._GWT = MyUtils.CnvSng(SArray(11))
        WrkLname = String.Empty
        If SArray(67) <> String.Empty Then
          ._LBUS = "Y"
          WrkLname = SArray(67)
        Else
          ._LBUS = "N"
          WrkLname = SArray(70)
          If SArray(68) <> String.Empty Then
            WrkLname = WrkLname & " " & SArray(68)
          End If
          If SArray(69) <> String.Empty Then
            WrkLname = WrkLname & " " & SArray(69)
          End If
        End If
        If WrkLname <> String.Empty Then
          ._LEASE = "Y"
        Else
          ._LEASE = ""
          ._LBUS = ""
        End If
        ._LNAME = Mid(WrkLname, 1, 35)
        ._LCUST = MyUtils.CnvSng(SArray(65))
        ._LADD1 = Mid(SArray(71), 1, 35)
        ._LADD2 = Mid(SArray(72), 1, 35)
        ._LCITY = Mid(SArray(73), 1, 25)
        ._LSTATE = SArray(74)
        ._LZIPA = FormatZip(SArray(75))
        ._LNVAL = WrkLnVal
        ._LWT = MyUtils.CnvSng(SArray(10))
        ._MSRP = MyUtils.CnvSng(SArray(17))
        ._NADA = SArray(19)
        ._ORIG = WrkValue
        ._PCUST = MyUtils.CnvSng(SArray(32))
        ._REGID = SArray(1)
        ._REGNO = Mid(SArray(26), 1, 8)
        If SArray(77) Then
          ._RGLATE = "Y"
        Else
          ._RGLATE = ""
        End If
        ._SCUST = MyUtils.CnvSng(SArray(51))
        ._SEAT = MyUtils.CnvSng(SArray(13))
        ._STRDT = MyUtils.SetDBDate(SArray(30))
        ._TRVAL = WrkTrVal
        ._VINNO = Mid(SArray(3), 1, 17)
        ._VMAKE = Mid(SArray(4), 1, 15)
        ._VMODEL = Mid(SArray(5), 1, 15)
        ._VPCLR = Mid(SArray(8), 1, 10)
        ._VSCLR = Mid(SArray(9), 1, 10)
        ._YEAR = WrkYear
        If .RecordNotFound Then
          ._VEHID = SArray(2)
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        Else
          .UpdateOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End If
      End With

      With myTXVCUS
        .GetOneRecordP(myTXVEH._PCUST)
        ._ADD1 = Mid(SArray(41), 1, 35)
        ._ADD2 = Mid(SArray(42), 1, 35)
        ._CHDATE = myTXVEH._CHDATE
        ._CITY = SArray(43)
        ._CONFID = SArray(40)
        If SArray(33) <> "" Then
          ._DOB = MyUtils.SetDBDate(SArray(33))
        Else
          ._DOB = 0
        End If
        If SArray(34) <> String.Empty Then
          ._BUS = "Y"
        Else
          ._BUS = "N"
        End If
        ._NAME = Mid(WrkPName, 1, 35)
        ._RADD1 = Mid(SArray(46), 1, 35)
        ._RADD2 = Mid(SArray(47), 1, 35)
        ._RCITY = Mid(SArray(48), 1, 25)
        ._RSTATE = SArray(49)
        ._RZIPA = FormatZip(SArray(50))
        ._SEX = Mid(SArray(39), 1, 1)
        ._STATE = SArray(44)
        ._ZIPA = FormatZip(SArray(45))
        If .RecordNotFound Then
          ._CUSTID = myTXVEH._PCUST
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        Else
          .UpdateOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End If
      End With

      If myTXVEH._SCUST > 0 Then
        With myTXVCUS2
          .GetOneRecordP(myTXVEH._SCUST)
          ._ADD1 = Mid(SArray(60), 1, 35)
          ._ADD2 = Mid(SArray(61), 1, 35)
          ._CHDATE = myTXVEH._CHDATE
          ._CITY = SArray(62)
          ._CONFID = SArray(59)
          If SArray(52) <> "" Then
            ._DOB = MyUtils.SetDBDate(SArray(52))
          Else
            ._DOB = 0
          End If
          If SArray(53) <> String.Empty Then
            ._BUS = "Y"
          Else
            ._BUS = "N"
          End If
          ._NAME = Mid(WrkSName, 1, 35)
          ._RADD1 = ""
          ._RADD2 = ""
          ._RCITY = ""
          ._RSTATE = ""
          ._RZIPA = ""
          ._SEX = Mid(SArray(58), 1, 1)
          ._STATE = SArray(63)
          ._ZIPA = FormatZip(SArray(64))
          If .RecordNotFound Then
            ._CUSTID = myTXVEH._SCUST
            .AddOneRecordP()
            If .ErrMsg <> "" Then
              WriteErrorLog(.ErrMsg)
              Exit Sub
            End If
          Else
            .UpdateOneRecordP()
            If .ErrMsg <> "" Then
              WriteErrorLog(.ErrMsg)
              Exit Sub
            End If
          End If
        End With
      End If
    End If

    If WrkOnlyDMVCust Then
      dstemp = myTXSUPPL6.GetViewbyRegNo(myTXVEH._REGNO, 1, False)
      If dstemp.Tables(0).Rows.Count > 0 Then
        myTXSUPP.GetOneRecordP(dstemp.Tables(0).Rows(0).Item("list#"))
        If Trim(dstemp.Tables(0).Rows(0).Item("regno")) = Trim(myTXVEH._REGNO) Then
          myTXSUPP._OID = myTXVEH._VEHID
          myTXSUPP._SSNO = myTXVEH._PCUST
          myTXSUPP._SS2 = myTXVEH._SCUST
          WrkCountOid = WrkCountOid + 1
        Else
          myTXSUPP._OID = ""
          myTXSUPP._SSNO = 0
          myTXSUPP._SS2 = 0
        End If
        myTXSUPP.UpdateOneRecordP()
      End If
      GoTo NextRec
    End If

    With myTXMVDCL1
      .GetOneRecordP(SArray(3))
      If Not .RecordNotFound Then
        If ._SSNO = myTXVEH._PCUST Then
          WrkSkipped = WrkSkipped + 1
          dr = ds2.Tables(0).NewRow
          dr.Item("listno") = 0
          dr.Item("name") = WrkPName
          dr.Item("class") = WrkClass
          dr.Item("make") = SArray(4)
          dr.Item("year") = WrkYear
          dr.Item("vinno") = SArray(3)
          dr.Item("model") = SArray(5)
          dr.Item("body") = SArray(7)
          dr.Item("regno") = SArray(26)
          dr.Item("value") = WrkValue
          dr.Item("errmsg") = "DUP VIN"
          ds2.Tables(0).Rows.Add(dr)
          GoTo NextRec
        End If
      End If

      If FindVINInv(SArray(3), myTXVEH._PCUST) Then
        WrkSkipped = WrkSkipped + 1
        dr = ds2.Tables(0).NewRow
        dr.Item("listno") = 0
        dr.Item("name") = WrkPName
        dr.Item("class") = WrkClass
        dr.Item("make") = SArray(4)
        dr.Item("year") = WrkYear
        dr.Item("vinno") = SArray(3)
        dr.Item("model") = SArray(5)
        dr.Item("body") = SArray(7)
        dr.Item("regno") = SArray(26)
        dr.Item("value") = WrkValue
        dr.Item("errmsg") = "CC ADD"
        ds2.Tables(0).Rows.Add(dr)
        GoTo NextRec
      End If
    End With

    WrkCount = WrkCount + 1
    WrkRecNo = WrkRecNo + 1

    If WrkIsOutdated Then
      WrkOutDated = WrkOutDated + 1
      dr = ds3.Tables(0).NewRow
      dr.Item("listno") = WrkStartNo + WrkRecNo
      dr.Item("name") = WrkPName
      dr.Item("class") = WrkClass
      dr.Item("make") = SArray(4)
      dr.Item("year") = WrkYear
      dr.Item("vinno") = SArray(3)
      dr.Item("model") = SArray(5)
      dr.Item("body") = SArray(7)
      dr.Item("regno") = SArray(26)
      dr.Item("value") = WrkValue
      dr.Item("errmsg") = SArray(31)
      ds3.Tables(0).Rows.Add(dr)
    End If

    With myTXSUPP
      .GetOneRecordP(WrkStartNo + WrkRecNo)
      ._TYPE = "S"
      ._CAT = "1"
      ._LISTNO = WrkStartNo + WrkRecNo
      ._YEAR = WrkYear
      ._MAKE = UCase(Mid(SArray(4), 1, 5))
      ._MODEL = UCase(Mid(SArray(5), 1, 8))
      WrkBody = SArray(7)
      WrkBody = Replace(WrkBody, " ", "")
      WrkBody = Replace(WrkBody, "/", "")
      ._BODY = Mid(WrkBody, 1, 6)
      ._DIST = 0
      ._NAME = Mid(WrkPName, 1, 35)
      ._SNAME = Mid(WrkSName, 1, 35)
      ._ADD1 = Mid(SArray(41), 1, 35)
      ._ADD2 = Mid(SArray(42), 1, 35)
      ._CITY = Mid(SArray(43), 1, 25)
      ._STATE = SArray(44)
      ._ZIP5 = 0
      ._ZIP4 = 0
      WrkZip = Replace(SArray(45), "-", "")
      If IsNumeric(WrkZip) Then
        If Trim(SArray(45)) <> "" Then
          ._ZIP5 = Mid(WrkZip, 1, 5)
          If Len(WrkZip) > 5 Then
            ._ZIP4 = Mid(WrkZip, 6, 4)
          End If
        End If
      Else
        WrkErrMsg = "*Zip*"
      End If
      ._LETT = Mid(._NAME, 1, 1)
      ._XDATE = MyUtils.SetDBDate(SArray(31))
      ._CLASS = WrkClass
      ._REGNO = SArray(26)
      ._VINNO = Mid(SArray(3), 1, 17)
      If MyUtils.CnvSng(SArray(12)) < 10 Then
        ._CYLAX = MyUtils.CnvSng(SArray(12))
      Else
        ._CYLAX = 0
      End If
      ._PCLR = CnvColorAbbr(SArray(8))
      ._SCLR = CnvColorAbbr(SArray(9))
      ._SEAT = MyUtils.CnvSng(SArray(13))
      ._LWT = MyUtils.CnvSng(SArray(10))
      ._GWT = MyUtils.CnvSng(SArray(11))
      WrkRegDate = SArray(30)
      If WrkIsOutdated Then
        ._ASS = "A"
      Else
        WrkStr = GetTXMVPCTL1("M", WrkRegDate.Month)
        ._ASS = WrkStr(1)
      End If
      WrkAss = ._ASS
      ._CYCLE = 0
      ._OCODE = 0
      ._RATE = CAssPct * 100
      ._PCCOD = 0
      ._PREG = ""
      ._SCAP = 0
      ._TDATE = 0
      If SArray(33) <> "" Then
        ._DOB = MyUtils.SetDBDate(SArray(33))
      Else
        ._DOB = 0
      End If
      ._MSRP = MyUtils.CnvSng(SArray(17))
      ._NADA = SArray(19)
      ._RAD1 = Mid(SArray(20), 1, 35)
      ._RAD2 = Mid(SArray(21), 1, 35)
      ._RCTY = Mid(SArray(22), 1, 25)
      ._RST = SArray(23)
      ._RZ5 = 0
      ._RZ4 = 0
      WrkZip = Replace(SArray(24), "-", "")
      If IsNumeric(WrkZip) Then
        If Trim(SArray(24)) <> "" Then
          ._RZ5 = Mid(WrkZip, 1, 5)
          If Len(WrkZip) > 5 Then
            ._RZ4 = Mid(WrkZip, 6, 4)
          End If
        End If
      End If
      Pos = InStr(._RAD1, " ", CompareMethod.Text)
      If Trim(._RAD1) <> "" Then
        If Pos > 0 Then
          ._LOC = Mid(._RAD1, Pos + 1, 25)
          ._LOCNO = MyUtils.JustifyRight(Mid(._RAD1, 1, Pos - 1), 7)
        End If
      Else
        Pos = InStr(._ADD1, " ", CompareMethod.Text)
        If Pos > 0 Then
          ._LOC = Mid(._ADD1, Pos + 1, 25)
          ._LOCNO = MyUtils.JustifyRight(Mid(._ADD1, 1, Pos - 1), 7)
        End If
      End If
      ._OID = MyUtils.CnvSng(SArray(2))
      ._SSNO = MyUtils.CnvSng(SArray(32))
      ._SS2 = MyUtils.CnvSng(SArray(51))
      Select Case ._CLASS
        Case 1, 2, 3, 4, 12
          ._VALUE = WrkNewValue
          ._ORIG = WrkValue
        Case Else
          ._VALUE = 0
          ._ORIG = 0
      End Select
      ._TRVAL = WrkTrVal
      ._LNVAL = WrkLnVal
      WrkProratePct = CalcPct(WrkAss)
      WrkProrate = CalcAssmt(WrkNewValue, WrkProratePct)
      ._PVAL = WrkProrate

      WrkCredit = 0
      myTXMVDCL2.GetOneRecordP(GetTXVCLSCode(SArray(27)), SArray(26))
      If Not myTXMVDCL2.RecordNotFound Then
        If myTXMVDCL2._SSNO = myTXSUPP._SSNO Then
          WrkStr = GetTXMVPCTL1("S", WrkRegDate.Month)
          ._ASS = WrkStr(1)
          WrkAss = ._ASS
          WrkCreditPct = CalcPct(WrkAss)
          WrkCredit = CalcAssmt(myTXMVDCL2._VALUE, WrkCreditPct)
          If WrkCredit > WrkProrate Then
            WrkCredit = WrkProrate
          End If
          ._OYEAR = myTXMVDCL2._YEAR
          ._OMAKE = myTXMVDCL2._MAKE
          ._OMOD = myTXMVDCL2._MODEL
          ._OCLS = myTXMVDCL2._CLASS
          ._OREGNO = myTXMVDCL2._REGNO
          ._OVIN = myTXMVDCL2._VINNO
          ._OASS = WrkAss
          ._OVAL = myTXMVDCL2._VALUE
          ._OPVAL = WrkCredit
          ._OLIST = myTXMVDCL2._LISTNO
        End If
      End If
      ._PNET = WrkProrate - WrkCredit
      myTXSUPP.AddOneRecordP()
      If myTXSUPP.ErrMsg <> "" Then
        WriteErrorLog(myTXSUPP.ErrMsg)
        Exit Sub
      End If

      dr = ds.Tables(0).NewRow
      dr.Item("listno") = WrkStartNo + WrkRecNo
      dr.Item("name") = ._NAME
      dr.Item("class") = ._CLASS
      dr.Item("make") = ._MAKE
      dr.Item("year") = ._YEAR
      dr.Item("vinno") = ._VINNO
      dr.Item("model") = ._MODEL
      If WrkErrMsg = "" Then
        dr.Item("body") = ._BODY
      Else
        dr.Item("body") = WrkErrMsg
      End If
      dr.Item("regno") = ._REGNO
      dr.Item("value") = ._VALUE
      ds.Tables(0).Rows.Add(dr)
    End With

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With

    GoTo NextLine

End_of_file:
    If WrkOnlyDMVCust Then
      MsgBox("Updated Records: " & WrkCountOid & vbCrLf &
    "Records with same VIN (skipped): " & WrkSkipped & vbCrLf &
    "Total Records: " & WrkCount, MsgBoxStyle.Information, "DMV Customer files update")
    Else
      MsgBox("Records with same VIN (skipped): " & WrkSkipped & vbCrLf &
    "Supplemental Records: " & WrkCount, MsgBoxStyle.Information, "Supplemental Install")
    End If
    sr.Close()
    myFrmProgress.Close()
    myTXSUPP.CloseFile()
  End Sub
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.MyData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)

    dsTXSupcd = myTXSUPCD.GetAllData
    For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupMonth(I) = .Item("smon")
        WrkSupPct(I) = .Item("spct")
      End With
    Next

  End Sub
  Private Function LookupTxSupcd(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

  End Function
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    WrkPct = WrkSupPct(K)
    Return WrkPct
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Decimal

    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function
  Private Function CnvColorAbbr(ByVal WrkColor As String) As String

    Dim WrkAbbr As String

    WrkAbbr = ""
    Select Case Trim(WrkColor)
      Case "Beige"
        WrkAbbr = "BGE"
      Case "Black"
        WrkAbbr = "BLK"
      Case "Blue"
        WrkAbbr = "BLU"
      Case "Brown"
        WrkAbbr = "BRN"
      Case "Gold"
        WrkAbbr = "GLD"
      Case "Gray"
        WrkAbbr = "GRY"
      Case "Green"
        WrkAbbr = "GRN"
      Case "Orange"
        WrkAbbr = "ORN"
      Case "Purple"
        WrkAbbr = "PUR"
      Case "Red"
        WrkAbbr = "RED"
      Case "Tan"
        WrkAbbr = "TAN"
      Case "Unk"
        WrkAbbr = ""
      Case "White"
        WrkAbbr = "WHT"
      Case "Yellow"
        WrkAbbr = "YEL"
      Case Else
        WrkAbbr = UCase(Mid(WrkColor, 1, 3))
    End Select

    Return WrkAbbr
  End Function
  Private Function FormatZip(ByVal WrkZip As String) As String
    Dim Pos As Integer
    Dim WrkZipA As String

    If Trim(WrkZip) <> "" Then
      If Len(WrkZip) > 5 Then
        Pos = InStr(WrkZip, "-")
        If Pos = 0 Then
          WrkZipA = Mid(WrkZip, 1, 5) & "-" & Mid(WrkZip, 6, 4)
        Else
          WrkZipA = WrkZip
        End If
      Else
        WrkZipA = WrkZip
      End If
    Else
      WrkZipA = ""
    End If

    Return WrkZipA
  End Function
  Public Function GetTXVCLSCode(ByVal Desc As String) As Integer

    If Desc = "" Then
      Return ""
    End If

    '   Desc = Replace(Desc, " -", "")

    myTXVCLS.GetOneRecordP(Desc)
    If Not myTXVCLS.RecordNotFound Then
      GetTXVCLSCode = myTXVCLS._CLASS
    Else
      GetTXVCLSCode = 0
    End If
    Return GetTXVCLSCode

  End Function
  Public Function GetTXMVPCTL1(ByVal Type As String, ByVal Month As Integer) As String()
    Dim Wrkstr(1) As String
    Dim myTXMVPCTL1 As TXMVPCTL1.MyData

    myTXMVPCTL1 = New TXMVPCTL1.MyData(myDBConnect)
    If IsNothing(Month) Then
      Return Wrkstr
    End If

    myTXMVPCTL1.GetOneRecordP(Type, Month)
    If Not myTXMVPCTL1.RecordNotFound Then
      With myTXMVPCTL1
        Wrkstr(0) = Format(myTXMVPCTL1._PCT, ".###")
        Wrkstr(1) = Trim(myTXMVPCTL1._CODE)
      End With
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
  Private Function FindVINInv(WrkVin As String, WrkCustID As Integer)
    Dim I As Integer

    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      If dsinv.Tables(0).Rows(I).Item("imvid#") = WrkVin And dsinv.Tables(0).Rows(I).Item("ss#") = WrkCustID Then
        Return True
      End If
      If dsinv.Tables(0).Rows(I).Item("imvid#") > WrkVin Then
        Exit For
      End If
    Next

    Return False
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
End Module






