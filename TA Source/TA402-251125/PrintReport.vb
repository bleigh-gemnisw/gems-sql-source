Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMVDL6 As TXMVDL6.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXCODE As TXCODE.MyData
  Dim myTXVCLS As TXVCLS.MyData
  Dim myTXVCUS As TXVCUS.MyData
  Dim myTXVCUS2 As TXVCUS.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXVEH As TXVEH.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myDBUtils As DBUtils.Utils
  Dim dsTXMVD As DataSet = New DataSet

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkStartNo As Integer
  Dim WrkCount As Integer
  Dim WrkCountOID As Integer
  Dim WrkOutdated As Integer
  Dim WrkSave As Boolean
  Dim WrkClear As Boolean
  Dim WrkOnlyDMVCust As Boolean
  Dim WrkUpValue As Boolean
  Public Sub PrtReport()
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMVDL6 = New TXMVDL6.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXCODE = New TXCODE.MyData(myDBConnect)
    myTXVCLS = New TXVCLS.MyData(myDBConnect)
    myTXVCUS = New TXVCUS.MyData(myDBConnect)
    myTXVCUS2 = New TXVCUS.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXVEH = New TXVEH.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    With MyFrmTA402B
      WrkStartNo = MyUtils.CnvSng(.TxtStartNo.Text)
      WrkClear = .ChkClear.Checked
      WrkSave = .RbSave.Checked
      WrkOnlyDMVCust = .ChkOnlyDMVCust.Checked
      WrkUpValue = .ChkUpValue.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If WrkSave Then
      If WrkClear Then
        ClearComments()
      End If
      GetDetailSave()
    Else
      GetDetailRestore()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Wrkds2 = ds2
      .WrkCount = WrkCount
      .WrkOutdated = WrkOutdated
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
    myTAXCOM.DeleteTypeYear("M", 0)
  End Sub
  Private Sub GetDetailSave()
    Dim ds4 As DataSet = New DataSet
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim J As Integer
    Dim SArray As String()
    Dim WrkRecNo As Integer
    Dim WrkIsOutdated As Boolean
    Dim WrkCat As String
    Dim WrkPName As String
    Dim WrkSName As String
    Dim WrkLname As String
    Dim WrkZip As String
    Dim WrkRegDate As Date
    Dim WrkVIN As String
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkDeyear As Integer
    Dim WrkDepr As Decimal
    Dim WrkValue As Integer
    Dim WrkTrVal As Integer
    Dim WrkLnVal As Integer
    Dim WrkBody As String
    Dim WrkYear As Integer
    Dim WrkClass As Integer
    Dim WrkNewValue As Integer
    Dim Answer As Integer
    Dim WrkMsg As String
    Dim WrkErrMsg As String
    Dim Pos As Integer

    Try
      WrkStream = New FileStream(MyFrmTA402B.LblFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.Read)
    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Critical, "Cannot process file")
      Exit Sub
    End Try
    sr = New StreamReader(WrkStream)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkRecNo = 0
    WrkOutdated = 0
    WrkCount = 0
    WrkCountOID = 0

    If WrkOnlyDMVCust Then
      Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
   "Refresh DMV Customer file ONLY (Do NOT install MV file)?")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If
    End If
    If WrkUpValue Then
      Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
   "Replace unpriced vehicle values ONLY (Do NOT install MV file)?")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If
    End If
    If Not WrkOnlyDMVCust And Not WrkUpValue Then
      Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
   "Install MV File")
      If Answer = MsgBoxResult.Cancel Then
        myFrmProgress.Close()
        Exit Sub
      End If
      If WrkSave Then
        If MyFrmTA402B.LblFileSave.Text = "" Then
          Answer = MsgBox("Click OK to continue or cancel to abort", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation,
        "Current file will not be saved")
          If Answer = MsgBoxResult.Cancel Then
            myFrmProgress.Close()
            Exit Sub
          End If
        Else
          dsTXMVD = myTXMVD.PosData(0)
          ExportFile(dsTXMVD, MyFrmTA402B.LblFileSave.Text, True)
          dsTXMVD.Clear()
          myTXMVD.CloseFile()
        End If
      End If

      If WrkClear Then
        myDBUtils.DeleteAllRecs("TXMVD")
      End If
    End If
    strBuffer = sr.ReadLine 'Skip Headers

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    WrkCount = WrkCount + 1
    WrkErrMsg = ""
    SArray = Parse(strBuffer, ",")
    WrkRecNo = WrkRecNo + 1
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
    WrkTrVal = MyUtils.CnvSng(SArray(15)) * MyBookPct
    WrkLnVal = MyUtils.CnvSng(SArray(18)) * MyBookPct
    If MyMinValue > WrkValue And WrkValue > 0 Then
      WrkNewValue = MyMinValue
    Else
      WrkNewValue = WrkValue
    End If
    WrkNewValue = MyUtils.Round10(WrkNewValue, "Normal")

    WrkIsOutdated = False
    If MyUtils.SetDBDate(SArray(31)) < MyUtils.CnvSng(Date.Now.Year & "1001") Then
      WrkIsOutdated = True
    End If

    If WrkUpValue Then
      ds4 = myTXMVDL6.GetViewbyRegNo(Trim(SArray(26)), 1, False)
      If ds4.Tables(0).Rows.Count > 0 Then
        myTXMVD.GetOneRecordP(ds4.Tables(0).Rows(0).Item("list#"))
        If Trim(ds4.Tables(0).Rows(0).Item("regno")) = Trim(SArray(26)) Then
          With myTXMVD
            If ._VALUE = 0 And WrkValue > 0 Then
              ._MSRP = WrkMSRP
              ._NADA = SArray(19)
              ._VALUE = WrkNewValue
              ._ORIG = WrkValue
              ._TRVAL = WrkTrVal
              ._LNVAL = WrkLnVal
              .UpdateOneRecordP()
              GoTo Report
            End If
          End With
        End If
      End If
      GoTo NextRec
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
          ._MSRP = WrkMSRP
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
      ds4 = myTXMVDL6.GetViewbyRegNo(myTXVEH._REGNO, 1, False)
      If ds4.Tables(0).Rows.Count > 0 Then
        myTXMVD.GetOneRecordP(ds4.Tables(0).Rows(0).Item("list#"))
        If Trim(ds4.Tables(0).Rows(0).Item("regno")) = Trim(myTXVEH._REGNO) Then
          myTXMVD._OID = myTXVEH._VEHID
          myTXMVD._SSNO = myTXVEH._PCUST
          myTXMVD._SS2 = myTXVEH._SCUST
          WrkCountOID = WrkCountOID + 1
        Else
          myTXMVD._OID = ""
          myTXMVD._SSNO = 0
          myTXMVD._SS2 = 0
        End If
        myTXMVD.UpdateOneRecordP()
      End If
      GoTo NextRec
    End If

    If WrkIsOutdated Then
      WrkOutdated = WrkOutdated + 1
      dr = ds2.Tables(0).NewRow
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
      dr.Item("errmsg") = SArray(30)
      ds2.Tables(0).Rows.Add(dr)
    End If

    With myTXMVD
      .GetOneRecordP(WrkStartNo + WrkRecNo)
      ._TYPE = "M"
      ._CAT = WrkCat
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
      '    WrkStr = GetTXMVPCTL1("M", WrkRegDate.Month)
      '    ._ASS = WrkStr(1)
      ._ASS = "Z"
      ._CYCLE = 0
      ._OCODE = 0
      ._RATE = MyBookPct * 100
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
      ._VALUE = WrkNewValue
      ._ORIG = WrkValue
      ._TRVAL = WrkTrVal
      ._LNVAL = WrkLnVal
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

Report:
    With myTXMVD
      dr = ds.Tables(0).NewRow
      If WrkUpValue Then
        dr.Item("listno") = ._LISTNO
      Else
        dr.Item("listno") = WrkStartNo + WrkRecNo
      End If
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
      WrkMsg = "Updated Records: " & WrkCountOID & " Added Records: " & (WrkCount - WrkCountOID)
      MsgBox(WrkMsg, MsgBoxStyle.Information, "DMV Customer files update")
    End If
    If WrkUpValue Then
      WrkMsg = "Completed"
      MsgBox(WrkMsg, MsgBoxStyle.Information, "Replace unpriced values")
    End If
    If Not WrkOnlyDMVCust And Not WrkUpValue Then
      MsgBox("MV Records: " & WrkCount, MsgBoxStyle.Information, "Motor Vehicle Install")
    End If
    sr.Close()
    myFrmProgress.Close()
    myTXMVD.CloseFile()

  End Sub
  Private Sub GetDetailRestore()
    Dim myTXMVD2 As TXMVD.MyData
    Dim WrkStream As FileStream = New FileStream(MyFrmTA402B.LblFileRestore.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim SArray As String()
    Dim I As Integer

    myTXMVD2 = New TXMVD.MyData(myDBConnect)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCount = 0

    myDBUtils.DeleteAllRecs("TXMVD")

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

    myTXMVD.GetOneRecordP(SArray(30))
    WrkCount = WrkCount + 1
    With myTXMVD
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
      ._PNET = SArray(69)
      ._OLIST = SArray(70)
      ._BTR = SArray(71)
      ._DOB = SArray(72)
      ._SSNO = SArray(73)
      ._BTC = SArray(74)
      ._LEASE = SArray(75)
      ._ORIG = SArray(76)
      ._TRVAL = SArray(77)
      ._LNVAL = SArray(78)
      ._MSRP = SArray(79)
      ._NADA = SArray(80)
      ._PRF = SArray(81)
      ._CHDATE = SArray(82)
      ._CHTIME = SArray(83)
      ._LETT = SArray(84)
      ._TYPE = SArray(85)
      ._DNBTR = SArray(86)
      ._DTBTR = SArray(87)
      ._PDST = SArray(88)
      ._OID = SArray(89)
      ._SS2 = SArray(90)
      ._TIN = SArray(91)
      ._RAD1 = SArray(92)
      ._RAD2 = SArray(93)
      ._RCTY = SArray(94)
      ._RST = SArray(95)
      ._RZ5 = SArray(96)
      ._RZ4 = SArray(97)
      ._LOCNO = SArray(98)
      ._LOC = SArray(99)
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
    myTXMVD.CloseFile()

  End Sub
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
      Return 0
    End If

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
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
End Module






