Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPP As TXSupp.myData
  Dim myTXSUPPL6 As TXSUPPL6.myData
  Dim myTXMVDCL1 As TXMVDCL1.MyData
  Dim myTXMVDCL2 As TXMVDCL2.MyData
  Dim myTXVCLS As TXVCLS.MyData
  Dim myTXVCUS As TXVCUS.myData
  Dim myTXVCUS2 As TXVCUS.myData
  Dim myTXVEH As TXVEH.myData
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myDBUtils As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim dsinv As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkStartNo As Integer
  Dim WrkCount As Integer
  Dim WrkCountOid As Integer
  Dim WrkSkipped As Integer
  Dim WrkOutDated As Integer
  Dim WrkMinValue As Integer
  Dim WrkClear As Boolean
  Dim WrkSave As Boolean
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

    myTXSUPP = New TXSupp.mydata(MyDBConnect)
    myTXSUPPL6 = New TXSUPPL6.mydata(MyDBConnect)
    myTXMVDCL1 = New TXMVDCL1.mydata(MyDBConnect)
    myTXMVDCL2 = New TXMVDCL2.MyData(myDBConnect)
    myTXVCLS = New TXVCLS.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.mydata(MyDBConnect)
    myTXVCUS2 = New TXVCUS.mydata(MyDBConnect)
    myTXVEH = New TXVEH.mydata(MyDBConnect)
    myTXINVQ = New TXINVQ.mydata(MyDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    With MyFrmTA502B
      WrkStartNo = MyUtils.CnvSng(.TxtStartNo.Text)
      WrkMinValue = MyUtils.CnvSng(.TxtMinVal.Text)
      WrkClear = .ChkClear.Checked
      WrkSave = .RbSave.Checked
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

    If WrkSave Then
      If WrkClear Then
        ClearComments()
      End If
      BufferTXSupcd()
      GetDetailSave()
    Else
      GetDetailRestore()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .Wrkds3 = ds3
      .WrkCount = WrkCount
      .WrkSkipped = WrkSkipped
      .WrkOutDated = WrkOutDated
      .WrkMinValue = WrkMinValue
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
  Private Sub GetDetailSave()
    Dim dstemp As DataSet
    Dim DsTXMVD As DataSet = New DataSet
    Dim dsTXSUPP As DataSet = New DataSet
    Dim WrkStream As FileStream = New FileStream(MyFrmTA502B.LblFilePath.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim J As Integer
    Dim SArray As String()
    'Dim WrkStr As String()
    Dim WrkRecNo As Integer
    Dim WrkPName As String
    Dim WrkSName As String
    Dim WrkLname As String
    Dim WrkZip As String
    Dim WrkRegDate As Date
    Dim WrkYear As Integer
    Dim WrkAss As String
    Dim WrkClass As Integer
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
   "Install Suppl. MV File")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If
      If WrkSave Then
        If MyFrmTA502B.LblFileSave.Text = "" Then
          Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
        "Current file will not be saved")
          If Answer = MsgBoxResult.Cancel Then
            myFrmProgress.Close()
            Exit Sub
          End If
        Else
          dsTXSUPP = myTXSUPP.PosData(0)
          ExportFile(dsTXSUPP, MyFrmTA502B.LblFileSave.Text, True)
          dsTXSUPP.Clear()
          myTXSUPP.CloseFile()
        End If
      End If

      If WrkClear Then
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
    'Check for duplicate starting list# on append
    'If Not WrkClear And WrkRecNo = 1 Then
    '  myTXSUPP.GetOneRecordP(WrkStartNo + WrkRecNo)
    '  If Not myTXSUPP.RecordNotFound Then
    '    MsgBox("Starting number is already in the file", MsgBoxStyle.Exclamation, "Duplicate list number")
    '    sr.Close()
    '    myFrmProgress.Close()
    '    myTXSUPP.CloseFile()
    '    Exit Sub
    '  End If
    'End If

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
    WrkValue = MyUtils.CnvSng(SArray(14)) * CAssPct
    WrkTrVal = MyUtils.CnvSng(SArray(15)) * CAssPct
    WrkLnVal = MyUtils.CnvSng(SArray(18)) * CAssPct
    If WrkMinValue > WrkValue And WrkValue > 0 Then
      WrkNewValue = WrkMinValue
    Else
      WrkNewValue = WrkValue
    End If
    'Class 25 = Classic vehicle
    If WrkClass = 25 Then
      WrkNewValue = CClassicVehicle
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
  Private Sub GetDetailRestore()
    Dim dsTXSUPP As DataSet = New DataSet
    Dim WrkStream As FileStream = New FileStream(MyFrmTA502B.LblFileRestore.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim SArray As String()
    Dim I As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCount = 0

    myDBUtils.DeleteAllRecs("TXSUPP")
    'Skip 1st record (Field Names)
    strBuffer = sr.ReadLine

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    SArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length

    myTXSUPP.GetOneRecordP(SArray(30))
    WrkCount = WrkCount + 1
    With myTXSUPP
      ._CAT = SArray(0)
      ._MAKE = SArray(1)
      ._YEAR = SArray(2)
      ._MODEL = SArray(3)
      ._BODY = SArray(4)
      ._DIST = SArray(5)
      ._NAME = SArray(6)
      ._SNAME = SArray(7)
      ._ADD1 = SArray(8)
      ._ADD2 = SArray(9)
      ._CITY = SArray(10)
      ._STATE = SArray(11)
      ._ZIP5 = SArray(12)
      ._ZIP4 = SArray(13)
      ._XDATE = SArray(14)
      ._CLASS = SArray(15)
      ._REGNO = SArray(16)
      ._VINNO = SArray(17)
      ._CYLAX = SArray(18)
      ._PCLR = SArray(19)
      ._SCLR = SArray(20)
      ._SEAT = SArray(21)
      ._LWT = SArray(22)
      ._GWT = SArray(23)
      ._VALUE = SArray(24)
      ._ASS = SArray(25)
      ._CYCLE = SArray(26)
      ._RCODE = SArray(27)
      ._OCODE = SArray(28)
      ._RATE = SArray(29)
      ._LISTNO = SArray(30)
      ._PCCOD = SArray(31)
      ._PREG = SArray(32)
      ._SCAP = SArray(33)
      ._TDATE = SArray(34)
      ._EXCD1 = SArray(35)
      ._EXCD2 = SArray(36)
      ._EXCD3 = SArray(37)
      ._EXCD4 = SArray(38)
      ._EXCD5 = SArray(39)
      ._EXAM1 = SArray(40)
      ._EXAM2 = SArray(41)
      ._EXAM3 = SArray(42)
      ._EXAM4 = SArray(43)
      ._EXAM5 = SArray(44)
      ._CCNO = SArray(45)
      ._CCGRS = SArray(46)
      ._CCEX = SArray(47)
      ._CCRS = SArray(48)
      ._CDATE = SArray(49)
      ._CCCD1 = SArray(50)
      ._CCCD2 = SArray(51)
      ._CCCD3 = SArray(52)
      ._CCCD4 = SArray(53)
      ._CCCD5 = SArray(54)
      ._CEXA1 = SArray(55)
      ._CEXA2 = SArray(56)
      ._CEXA3 = SArray(57)
      ._CEXA4 = SArray(58)
      ._CEXA5 = SArray(59)
      ._OCLS = SArray(60)
      ._OMAKE = SArray(61)
      ._OYEAR = SArray(62)
      ._OMOD = SArray(63)
      ._OREGNO = SArray(64)
      ._OVIN = SArray(65)
      ._OASS = SArray(66)
      ._OVAL = SArray(67)
      ._OPVAL = SArray(68)
      ._PVAL = SArray(69)
      ._PNET = SArray(70)
      ._OLIST = SArray(71)
      ._BTR = SArray(72)
      ._DOB = SArray(73)
      ._SSNO = SArray(74)
      ._BTC = SArray(75)
      ._LEASE = SArray(76)
      ._ORIG = SArray(77)
      ._TRVAL = SArray(78)
      ._LNVAL = SArray(79)
      ._MSRP = SArray(80)
      ._NADA = SArray(81)
      ._PRF = SArray(82)
      ._CHDATE = SArray(83)
      ._CHTIME = SArray(84)
      ._LETT = SArray(85)
      ._TYPE = SArray(86)
      ._PDST = SArray(87)
      ._OID = SArray(88)
      ._SS2 = SArray(89)
      ._TIN = SArray(90)
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If

      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("name") = Trim(._NAME)
      dr.Item("class") = ._CLASS
      dr.Item("make") = Trim(._MAKE)
      dr.Item("year") = ._YEAR
      dr.Item("vinno") = Trim(._VINNO)
      dr.Item("model") = Trim(._MODEL)
      dr.Item("body") = Trim(._BODY)
      dr.Item("regno") = Trim(._REGNO)
      dr.Item("value") = ._VALUE
    End With
    ds.Tables(0).Rows.Add(dr)

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
    sr.Close()
    myFrmProgress.Close()
    myTXSUPP.CloseFile()

  End Sub
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.myData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)

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
    Dim myTXMVPCTL1 As TXMVPCTL1.myData

    myTXMVPCTL1 = New TXMVPCTL1.mydata(MyDBConnect)
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
End Module






