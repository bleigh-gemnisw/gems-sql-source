Imports System.Text
Imports System.IO
Public Class FrmAvon
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTXSUPP As TXSUPP
  Dim MyTXVCLS As TXVCLS
  Dim MyTXVEH As TXVEH
  Dim MyTXVCUS As TXVCUS
  Dim WrkFile As String
  Dim WrkListNo As Integer
  Dim WrkCity As String
  Dim WrkState As String
  Const cAssPct As Decimal = 0.7
  Const cClassicVehicle As Integer = 500
  Const cMinValue As Integer = 200
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    WrkFile = ""
    LblMsg.Text = ""
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
  Private Sub InitFiles()
    MyTXSUPP = New TXSUPP(myDBConnect2.MyConn2)
    MyTXVCLS = New TXVCLS(myDBConnect2.MyConn2)
    MyTXVEH = New TXVEH(myDBConnect2.MyConn2)
    MyTXVCUS = New TXVCUS(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvAvonsupp.csv")
    ProgBar1.Visible = True
    WriteSU()
    '    WriteVEH_VCUS("MOTOR_CIVLS")
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
  End Sub
  Private Sub SplitCityST(ByVal WrkCityST As String)
    Dim Pos As Integer
    WrkCity = ""
    WrkState = ""
    WrkCityST = Replace(WrkCityST, "  ", " ")
    WrkCityST = Replace(WrkCityST, ",", " ")
    WrkCityST = Replace(WrkCityST, ".", "")
    WrkCityST = Replace(WrkCityST, " CONN", " CT")
    WrkCityST = Replace(WrkCityST, " TEXAS", " TX")
    WrkCityST = Replace(WrkCityST, " INDIANA,", " IN")
    Pos = InStrRev(WrkCityST, " ")
    If Len(WrkCityST) = Pos + 2 Then
      WrkCity = Mid(WrkCityST, 1, Pos - 1)
      WrkState = Mid(WrkCityST, Pos + 1, 2)
    Else
      WrkCity = WrkCityST
      WrkState = ""
    End If
  End Sub

  Private Sub WriteSU()
    Dim WrkStream As FileStream = New FileStream(LblFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim WrkOListNo As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim WrkCredit As Boolean
    Dim I As Integer

    MyTXSUPP = New TXSUPP(myDBConnect2.MyConn2)
    myDBConnect2.DeleteRecords2("TXSUPP")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    SplitCityST(Trim(RecArray(32)))
    With MyTXSUPP
      Counter = Counter + 1
      WrkListNo = CnvListNoAlpha(RecArray(0))
      WrkOListNo = CnvListNoAlpha(RecArray(85))
      .GetOneRecordP(WrkListNo)
      ._ADD1 = ConvertString("Add1", RecArray(31), 35)
      ._ADD2 = ConvertString("Add1", "", 35)
      If CnvSng(RecArray(77)) > 0 Then
        WrkCredit = True
      Else
        WrkCredit = False
      End If
      ._ASS = Trim(RecArray(75))
      If ._ASS = "Z" Then
        ._ASS = "N"
      End If
      ._BODY = RecArray(8)
      ._BTC = ""
      ._BTR = 0
      ._CAT = "1"
      ._CCCD1 = ""
      ._CCCD2 = ""
      ._CCCD3 = ""
      ._CCCD4 = ""
      ._CCCD5 = ""
      ._CCEX = 0
      ._CCGRS = 0
      ._CCNO = 0
      ._CCRS = ""
      ._CDATE = 0
      ._CEXA1 = 0
      ._CEXA2 = 0
      ._CEXA3 = 0
      ._CEXA4 = 0
      ._CEXA5 = 0
      ._CHDATE = 0
      ._CHTIME = 0
      ._CLASS = 0
      ._CYCLE = 0
      ._CYLAX = 0
      ._CITY = ConvertString("City", WrkCity, 25)
      ._DIST = 0
      ._DOB = ConvertDateAlpha(RecArray(23))
      ._EXAM1 = CnvSng(RecArray(43))
      ._EXAM2 = CnvSng(RecArray(45))
      ._EXAM3 = CnvSng(RecArray(47))
      ._EXAM4 = CnvSng(RecArray(49))
      ._EXAM5 = CnvSng(RecArray(51))
      ._EXCD1 = Trim(RecArray(42))
      ._EXCD2 = Trim(RecArray(44))
      ._EXCD3 = Trim(RecArray(46))
      ._EXCD4 = Trim(RecArray(48))
      ._EXCD5 = Trim(RecArray(50))
      ._GWT = CnvSng(RecArray(11))
      ._LEASE = Trim(RecArray(35))
      ._LETT = Mid(RecArray(17), 1, 1)
      ._LISTNO = WrkListNo
      ._LNVAL = CnvSng(RecArray(56))
      ._LWT = CnvSng(RecArray(10))
      ._MAKE = Mid(RecArray(3), 1, 5)
      ._MODEL = Mid(RecArray(5), 1, 8)
      ._MSRP = CnvSng(RecArray(57))
      ._NADA = ""
      ._NAME = ConvertString("Name", RecArray(17), 35)
      ._SNAME = ConvertString("Sname", RecArray(24), 35)
      If CnvSng(RecArray(77)) > 0 Then
        ._OASS = ._ASS
      Else
        ._OASS = ""
      End If
      ._OCLS = 0
      ._OCODE = 0
      ._OID = CnvSng(RecArray(73))
      ._OLIST = WrkOListNo
      ._OMAKE = Mid(RecArray(81), 1, 5)
      ._OMOD = Mid(RecArray(80), 1, 8)
      ._OPVAL = 0
      ._OREGNO = RecArray(79)
      ._ORIG = 0
      ._OVAL = CnvSng(RecArray(83))
      ._OVIN = ConvertString("OVIN", RecArray(82), 17)
      ._OYEAR = CnvSng(RecArray(77))
      ._PCCOD = 0
      ._PCLR = CnvColorAbbr(RecArray(12))
      ._PDST = 0
      ._PNET = CnvSng(RecArray(86))
      ._PREG = ""
      ._PRF = ""
      ._PVAL = 0
      ._RATE = 70
      ._RCODE = 0
      ._REGNO = RecArray(7)
      ._SCAP = 0
      ._SCLR = ""
      ._SEAT = 0
      ._SS2 = CnvSng(RecArray(72))
      ._SSNO = CnvSng(RecArray(71))
      ._STATE = WrkState
      ._TDATE = 0
      ._TIN = ""
      ._TRVAL = CnvSng(RecArray(55))
      ._TYPE = "S"
      ._VALUE = CnvSng(RecArray(16))
      ._VINNO = ConvertString("VIN", RecArray(6), 17)
      ._XDATE = 0
      ._YEAR = CnvSng(RecArray(4))
      ._ZIP4 = CnvSng(RecArray(34))
      ._ZIP5 = CnvSng(RecArray(33))
      ._RAD1 = ConvertString("Rad1", RecArray(66), 35)
      ._RAD2 = ConvertString("Rad2", "", 35)
      ._RCTY = ConvertString("Rcty", RecArray(67), 25)
      If Trim(RecArray(68)) <> "" Then
        ._RST = ConvertString("Rst", RecArray(68), 2)
      Else
        ._RST = "CT"
      End If
      Select Case Len(Trim(RecArray(69)))
        Case 4, 5
          ._RZ5 = CnvSng(RecArray(69))
          ._RZ4 = 0
        Case 8
          ._RZ5 = Mid(RecArray(69), 1, 4)
          ._RZ4 = Mid(RecArray(69), 5, 4)
        Case 9
          ._RZ5 = Mid(RecArray(69), 1, 5)
          ._RZ4 = Mid(RecArray(69), 6, 4)
      End Select
      ._LOCNO = ""
      ._LOC = ""
      ._DNBTR = 0
      ._DTBTR = 0
      .AddOneRecordP()
    End With

    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      '          .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteVEH_VCUS(ByVal WrkFromFile As String)
    'Dim ds As DataSet = New DataSet
    'Dim WrkVehID As Integer
    'Dim WrkPName As String
    'Dim WrkSName As String
    'Dim WrkLname As String
    'Dim WrkValue As Integer
    'Dim WrkTrVal As Integer
    'Dim WrkLnVal As Integer
    'Dim WrkClass As Integer
    'Dim WrkNewValue As Integer
    'Dim I As Integer
    'Dim J As Integer
    'Dim WrkPct As Decimal
    'Dim SavePct As Decimal
    'Dim Counter As Decimal

    'MyTXVEH = New TXVEH(myDBConnect2.MyConn2)
    'MyTXVCUS = New TXVCUS(myDBConnect2.MyConn2)
    'For I = 0 To ds.Tables(0).Rows.Count - 1
    '  Counter = Counter + 1
    '  WrkPName = ""
    '  If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
    '    WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName"))
    '  Else
    '    WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerLastName"))
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix"))
    '    End If
    '  End If

    '  WrkSName = ""
    '  If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerOrganizationName")) <> String.Empty Then
    '  Else
    '    WrkSName = Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerLastName"))
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix"))
    '    End If
    '  End If
    '  WrkClass = GetTXVCLSCode(ds.Tables(0).Rows(I).Item("PlateClassName"))

    '  'Calculate Assessment Values
    '  WrkValue = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedRetailValue")) * cAssPct
    '  WrkTrVal = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedTradeInValue")) * cAssPct
    '  WrkLnVal = CnvSng(ds.Tables(0).Rows(I).Item("SalesPriceAmount")) * cAssPct
    '  If cMinValue > WrkValue And WrkValue > 0 Then
    '    WrkNewValue = cMinValue
    '  Else
    '    WrkNewValue = WrkValue
    '  End If
    '  'Class 25 = Classic vehicle
    '  If WrkClass = 25 Then
    '    WrkNewValue = cClassicVehicle
    '  End If
    '  'Round down to nearest 10 dollars
    '  J = WrkNewValue Mod 10
    '  If J <> 0 Then
    '    WrkNewValue = WrkNewValue - J
    '  End If

    '  WrkFile = "TXVEH"
    '  With MyTXVEH
    '    WrkVehID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleID"))
    '    If WrkVehID > 0 Then
    '      .GetOneRecordP(WrkVehID)
    '      ._BODY = ConvertString("Body", ds.Tables(0).Rows(I).Item("BodyStyle"), 30)
    '      If Trim(ds.Tables(0).Rows(I).Item("FileCreationDate")) <> "" Then
    '        ._CHDATE = SetDBDate(ds.Tables(0).Rows(I).Item("FileCreationDate"))
    '      Else
    '        ._CHDATE = 0
    '      End If
    '      ._CLASS = WrkClass
    '      ._CLASSD = ds.Tables(0).Rows(I).Item("PlateClassName")
    '      If CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders")) < 10 Then
    '        ._CYLAX = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders"))
    '      Else
    '        ._CYLAX = 0
    '      End If
    '      ._DADD1 = ConvertString("DAdd1", ds.Tables(0).Rows(I).Item("DomiciledAddressLine1"), 35)
    '      ._DADD2 = ConvertString("DAdd2", ds.Tables(0).Rows(I).Item("DomiciledAddressLine2"), 35)
    '      ._DCITY = ConvertString("DCity", ds.Tables(0).Rows(I).Item("DomiciledAddressCity"), 25)
    '      ._DSTATE = ds.Tables(0).Rows(I).Item("DomiciledAddressStateCode")
    '      ._DZIPA = ds.Tables(0).Rows(I).Item("DomiciledAddressZip")
    '      ._ENDDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationEndDate"))
    '      ._GWT = CnvSng(ds.Tables(0).Rows(I).Item("GVWR"))
    '      WrkLname = String.Empty
    '      If ds.Tables(0).Rows(I).Item("LesseeOrganizationName") <> String.Empty Then
    '        ._LBUS = "Y"
    '        WrkLname = ds.Tables(0).Rows(I).Item("LesseeOrganizationName")
    '      Else
    '        ._LBUS = "N"
    '        WrkLname = ds.Tables(0).Rows(I).Item("LesseeLastName")
    '        If ds.Tables(0).Rows(I).Item("LesseeFirstName") <> String.Empty Then
    '          WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeFirstName")
    '        End If
    '        If ds.Tables(0).Rows(I).Item("LesseeMiddleName") <> String.Empty Then
    '          WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeMiddleName")
    '        End If
    '      End If
    '      If WrkLname <> String.Empty Then
    '        ._LEASE = "Y"
    '      Else
    '        ._LEASE = ""
    '        ._LBUS = ""
    '      End If
    '      ._LNAME = ConvertString("LName", WrkLname, 35)
    '      ._LCUST = CnvSng(ds.Tables(0).Rows(I).Item("LesseeVestedPartyID"))
    '      ._LADD1 = ConvertString("LAdd1", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine1"), 35)
    '      ._LADD2 = ConvertString("LAdd2", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine2"), 35)
    '      ._LCITY = ConvertString("LCity", ds.Tables(0).Rows(I).Item("LesseeResidencyCity"), 35)
    '      ._LSTATE = ds.Tables(0).Rows(I).Item("LesseeResidencyState")
    '      ._LZIPA = FormatZip(ds.Tables(0).Rows(I).Item("LesseeResidencyZip"))
    '      ._LNVAL = WrkLnVal
    '      ._LWT = CnvSng(ds.Tables(0).Rows(I).Item("UnladenWeight"))
    '      ._MSRP = CnvSng(ds.Tables(0).Rows(I).Item("MSRP"))
    '      ._NADA = ds.Tables(0).Rows(I).Item("NADAReturnCodes")
    '      ._ORIG = WrkValue
    '      ._PCUST = CnvSng(ds.Tables(0).Rows(I).Item("PrimaryOwnerCustomerID"))
    '      ._REGID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleRegistrationID"))
    '      ._REGNO = ds.Tables(0).Rows(I).Item("PlateNumber")
    '      If ds.Tables(0).Rows(I).Item("FineIndicator") Then
    '        ._RGLATE = "Y"
    '      Else
    '        ._RGLATE = ""
    '      End If
    '      ._SCUST = CnvSng(ds.Tables(0).Rows(I).Item("SecondaryOwnerCustomerID"))
    '      ._SEAT = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfSeats"))
    '      ._STRDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationStartDate"))
    '      ._TRVAL = WrkTrVal
    '      ._VINNO = ConvertString("VIN", ds.Tables(0).Rows(I).Item("VIN"), 17)
    '      ._VMAKE = ConvertString("Make", ds.Tables(0).Rows(I).Item("Make"), 15)
    '      ._VMODEL = ConvertString("Model", ds.Tables(0).Rows(I).Item("Model"), 15)
    '      ._VPCLR = ds.Tables(0).Rows(I).Item("PrimaryColor")
    '      ._VSCLR = ds.Tables(0).Rows(I).Item("SecondaryColor")
    '      ._YEAR = CnvSng(ds.Tables(0).Rows(I).Item("Year"))
    '      If .RecordNotFound Then
    '        ._VEHID = WrkVehID
    '        .AddOneRecordP()
    '      Else
    '        .UpdateOneRecordP()
    '      End If
    '    End If
    '  End With

    '  If MyTXVEH._PCUST > 0 Then
    '    WrkFile = "TXVCUS"
    '    With MyTXVCUS
    '      .GetOneRecordP(MyTXVEH._PCUST)
    '      ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine1"), 35)
    '      ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine2"), 35)
    '      ._CHDATE = MyTXVEH._CHDATE
    '      ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingCity"), 25)
    '      ._CONFID = ds.Tables(0).Rows(I).Item("PrimaryOwnerConfidential")
    '      If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB")) <> "" Then
    '        ._DOB = SetDBDate(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB"))
    '      Else
    '        ._DOB = 0
    '      End If
    '      If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
    '        ._BUS = "Y"
    '      Else
    '        ._BUS = "N"
    '      End If
    '      ._NAME = ConvertString("PName", WrkPName, 35)
    '      ._RADD1 = ConvertString("Radd1", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine1"), 35)
    '      ._RADD2 = ConvertString("Radd2", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine2"), 35)
    '      ._RCITY = ConvertString("Rcity", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyCity"), 35)
    '      ._RSTATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyState")
    '      ._RZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyZip"))
    '      ._SEX = Mid(ds.Tables(0).Rows(I).Item("PrimaryOwnerGender"), 1, 1)
    '      ._STATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingState")
    '      ._ZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingZip"))
    '      If .RecordNotFound Then
    '        ._CUSTID = MyTXVEH._PCUST
    '        .AddOneRecordP()
    '      Else
    '        .UpdateOneRecordP()
    '      End If
    '    End With
    '  End If

    '  WrkPct = (Counter / 10) Mod 100
    '  If SavePct <> WrkPct Then
    '    ProgBar1.Value = WrkPct
    '    LblMsg.Text = "Records processed: " & Counter
    '    '.Refresh()
    '    SavePct = WrkPct
    '    Application.DoEvents()
    '  End If
    'Next
    'ds = Nothing
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine(WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
    End If

    Return ReturnStr
  End Function
  Private Function ConvertDate(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDate(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateAlpha(ByVal DateIn As String) As Integer
    'IE: 31-Mar-1999

    Dim WrkMonth As Integer
    Dim ReturnDate As Integer
    Select Case Mid(DateIn, 4, 3).ToUpper
      Case "JAN"
        WrkMonth = 1
      Case "FEB"
        WrkMonth = 2
      Case "MAR"
        WrkMonth = 3
      Case "APR"
        WrkMonth = 4
      Case "MAY"
        WrkMonth = 5
      Case "JUN"
        WrkMonth = 6
      Case "JUL"
        WrkMonth = 7
      Case "AUG"
        WrkMonth = 8
      Case "SEP"
        WrkMonth = 9
      Case "OCT"
        WrkMonth = 10
      Case "NOV"
        WrkMonth = 11
      Case "DEC"
        WrkMonth = 12
      Case Else
    End Select
    If Trim(DateIn) <> "" Then
      If WrkMonth < 10 Then
        ReturnDate = Mid(DateIn, 8, 4) & "0" & WrkMonth & Mid(DateIn, 1, 2)
      Else
        ReturnDate = Mid(DateIn, 8, 4) & WrkMonth & Mid(DateIn, 1, 2)
      End If
    Else
        ReturnDate = 0
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDateMDY(DateIn)
    End If

    Return ReturnDate
  End Function
  Public Function CnvListNoAlpha(ByVal WrkStr As String) As Integer
    Dim WrkNum As Integer
    Dim WrkAsc As Integer

    If Trim(WrkStr) <> "" Then
      WrkAsc = Asc(Mid(WrkStr, 1, 1)) - 64
      WrkNum = WrkAsc & Mid(WrkStr, 2, 5)
    Else
      WrkNum = 0
    End If
    Return WrkNum

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
  Public Function GetTXVCLSCode(ByVal Desc As String) As Integer

    If Desc = "" Then
      Return 0
    End If

    MyTXVCLS.GetOneRecordP(Desc)
    If Not MyTXVCLS.RecordNotFound Then
      GetTXVCLSCode = MyTXVCLS._CLASS
    Else
      GetTXVCLSCode = 0
    End If
    Return GetTXVCLSCode

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

End Class