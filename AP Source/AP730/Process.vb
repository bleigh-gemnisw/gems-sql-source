Imports System.io
Imports System.Text
Module Process
  Dim myFrmProgress As FrmProgress
  Dim WrkTotal As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAP1099PQ As AP1099PQ.MyData
  Dim myAP1099PL1 As AP1099PL1.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myAPCTRL As APCTRL.MyData
  'Global
  Dim Counter As Integer
  Dim WrkRecCount As Integer
  Dim WrkResubmit As Boolean
  Dim WrkNEC As Boolean
  Dim WrkError As Boolean
  Public Sub CreateIrstax()

    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmAP730B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkTotMisc As Decimal
    Dim WrkIsNec As Boolean

    WrkQry = String.Empty
    WrkSort = String.Empty
    Counter = 0
    WrkTotMisc = 0
    WrkError = False

    With MyFrmAP730B
      WrkResubmit = .ChkResubmit.Checked
      WrkNEC = .RbNEC.Checked
    End With

    myAP1099PQ = New AP1099PQ.MyData()
    myAP1099PQ.MyDBConn = myDBConnect
    myAP1099PL1 = New AP1099PL1.MyData()
    myAP1099PL1.MyDBConn = myDBConnect
    myAPCTRL = New APCTRL.MyData(myDBConnect)
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    myAPCTRL.GetOneRecordP(1)
    myAP1099PQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    'sw.WriteLine(BuildRuler) 'Used for file testing only
    WrkRecCount = myAP1099PL1.GetRecordCount

ReadNext:
    myAP1099PQ.ReadQry()
    If Not myAP1099PQ.IsEOF Then
      With myAP1099PQ
        If Counter = 0 Then
          Counter = Counter + 1
          sw.WriteLine(BuildCodeT)
          Counter = Counter + 1
          sw.WriteLine(BuildCodeA)
        End If
        sb = New StringBuilder
        myVENDOR.GetOneRecordP(Trim(._ARACCT))
        If Not myVENDOR.RecordNotFound Then
          If myVENDOR._FEMCD = "Y" Or myVENDOR._MINCD = "Y" Then 'Misc
            WrkIsNec = False
          Else
            WrkIsNec = True
          End If
        End If
        If (WrkNEC And WrkIsNec) Or (Not WrkNEC And Not WrkIsNec) Then 'If NEC checked then NEC records otherwise Misc records
          Counter = Counter + 1
          sw.WriteLine(BuildCodeB)
        End If
        WrkTotMisc = WrkTotMisc + ._AMISAM
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

    Counter = Counter + 1
    sw.WriteLine(BuildCodeC(WrkTotMisc))
    Counter = Counter + 1
    sw.WriteLine(BuildCodeF)
    sw.Close()
    myFrmProgress.Close()
    myAP1099PQ.CloseFile()
    If WrkError Then
      MsgBox("Invalid Vendor Address. Search file for *** Error", MsgBoxStyle.Exclamation, "Correct data and rerun")
    Else
      MsgBox(Counter & " records created", MsgBoxStyle.Information, "Processing completed")
    End If
  End Sub
  Private Function BuildRuler() As String
    'Data positions ruler for testing
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim I As Integer

    With myAP1099PQ
      sb = New StringBuilder
      For I = 0 To 74
        sb.Append("1234567890")
      Next
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
  Private Function BuildCodeT() As String
    'Transmitter
    Dim sb As StringBuilder
    Dim WrkStr As String

    With myAP1099PQ
      sb = New StringBuilder
      sb.Append("T") 'Code (1)
      sb.Append(._AYEAR) 'Year (2-5)
      sb.Append(" ") 'Prior Year Indicator (6)
      sb.Append(Replace(._AFEDID, "-", "")) 'Federal ID (7-15)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._TCC, 5)) 'Transmitter Code (16-20)
      sb.Append(Space(7))
      sb.Append(" ") 'Test File Indicator (28)
      sb.Append(" ") 'Foreign Entry Indicator (29)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FNAME, 40)) 'Transmitter Name (30-69)
      sb.Append(MyUtils.JustifyLeft("", 40)) '(70-109)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FNAME, 40)) 'Company Name (110-149)
      sb.Append(MyUtils.JustifyLeft("", 40)) '(150-189) 
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FADD1, 40)) 'Company Mailing Address (190-229)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FCITY, 40)) 'Company Mailing City ('230-269)
      sb.Append(myAPCTRL._FSTATE) 'Company Mailing State (270-271)
      sb.Append(Format(myAPCTRL._FZIP, "000000000")) 'Company Mailing Zip (272-280)
      sb.Append(Space(15))
      sb.Append(Format(WrkRecCount, "00000000")) 'Number of Payees (296-303)
      sb.Append(MyUtils.JustifyLeft("", 40)) 'Contact Name (304-343)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._CTEL, 15)) 'Contact Phone (344-358)
      sb.Append(MyUtils.JustifyLeft("", 50)) 'Contact Email (359-408)
      sb.Append(Space(91))
      sb.Append(Format(Counter, "00000000")) 'Record Number in file (500-507)
      sb.Append(Space(9))
      sb.Append("V") 'VENDOR INDICATOR V=PURCHASED FROM VENDOR  I=IN HOUSE (518) 
      sb.Append(MyUtils.JustifyLeft("GEMNISW LLC", 40)) 'Vendor Name (519-558)
      sb.Append(MyUtils.JustifyLeft("5 SALMON RUN", 40)) 'Vendor Address (559-598)
      sb.Append(MyUtils.JustifyLeft("EAST HAMPTON", 40)) 'Vendor City (599-638)
      sb.Append(MyUtils.JustifyLeft("CT", 2)) 'Vendor State (639-640)
      sb.Append(MyUtils.JustifyLeft("06424", 9)) 'Vendor Zip (641-649)
      sb.Append(MyUtils.JustifyLeft("KIM DESIMONE", 40)) 'Vendor Contact (650-689)
      sb.Append(MyUtils.JustifyLeft("860 655-3864", 15)) 'Vendor Contact Phone (690-704)
      sb.Append(Space(35))
      sb.Append(" ") 'VENDOR FOREIGN = 1 (740)
      sb.Append(Space(10))
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
  Private Function BuildCodeA() As String
    'Payer
    Dim sb As StringBuilder
    Dim WrkStr As String

    With myAP1099PQ
      sb = New StringBuilder
      sb.Append("A") 'Code (1)
      sb.Append(._AYEAR) 'Year (2-5)
      sb.Append(" ") 'COMBINED FEDERAL/STATE = 1 (6)
      sb.Append(Space(5))
      ._AFEDID = Replace(._AFEDID, "-", "")
      sb.Append(Format(MyUtils.CnvSng(._AFEDID), "000000000")) 'TRANSMITTER TAX PAYOR INDICATOR (12-20)
      sb.Append(Left(myAPCTRL._PCNAM, 4)) 'PAYER NAME CONTROL (21-24)
      sb.Append(myAPCTRL._LSTFIL) 'LAST FILING INDICATOR = 1 (25)
      If WrkNEC Then
        sb.Append("NE") 'TYPE OF RETURN/1099-NEC = NE (26-27)
        sb.Append("1") 'AMOUNT CODE/NON EMPLOYEE COMP = 1 (28-43) 
      Else
        sb.Append("A ") 'TYPE OF RETURN/1099-MISC = A (26-27)
        'sb.Append("1") 'AMOUNT CODE/RENTS = 1 (28-43) 
        sb.Append("3") 'AMOUNT CODE/OTHER INCOME = 3 (28-43) 
      End If
      sb.Append(" ") 'FOREIGN ENTITY INDICATOR = 1 (29)
      sb.Append(Space(23))
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FNAME, 40)) 'FIRST PAYER NAME (53-92)
      sb.Append(MyUtils.JustifyLeft("", 40)) 'SECOND PAYER NAME (93-132)
      sb.Append("0") 'TRANSFER AGENT INDICATOR = 0 (133)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FADD1, 40)) 'PAYER SHIPPING ADDRESS (134-173)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FCITY, 40)) 'PAYER CITY (174-213) 
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._FSTATE, 2)) 'PAYER STATE (214-215)
      sb.Append(Format(myAPCTRL._FZIP, "000000000")) 'PAYER ZIP ('216-224)
      sb.Append(MyUtils.JustifyLeft(myAPCTRL._PTEL, 15)) 'PAYER PHONE AND EXTENSION (225-239)
      sb.Append(Space(260))
      sb.Append(Format(Counter, "00000000")) 'RECORD SEQUENCE IN THE FILE (500-507)
      sb.Append(Space(243))
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
  Private Function BuildCodeB() As String
    'Payee
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkAddr As String
    Dim WrkCity As String
    Dim WrkState As String
    Dim WrkZip As Integer
    Dim Pos As Integer
    Dim Pos2 As Integer

    With myAP1099PQ
      sb = New StringBuilder
      sb.Append("B") 'Code (1)
      sb.Append(._AYEAR) 'Year (2-5)
      If WrkResubmit Then
        sb.Append("G") 'RESUBMIT
      Else
        sb.Append(" ") 'CORRECTED RETURN INDICATOR (6)
      End If
      sb.Append(Space(4)) 'PAYEE NAME CONTROL/FIRST 4 CHAR OF LAST OR BLANKS (7-10)
      sb.Append("2") 'TYPE OF TAX IDENTIFICATION # 1=EIN 2=SSN,ITIN,ATIN (11)
      WrkStr = Replace(Trim(._ATAXID), "-", "")
      sb.Append(MyUtils.JustifyLeft(WrkStr, 9)) 'TAX IDENTIFICATION NUMBER  (12-20)
      sb.Append(MyUtils.JustifyLeft(._ARACCT, 20)) 'PAYERS ACCT NUMBER (21-40)
      sb.Append(Space(4)) 'PAYER'S OFFICE CODE (41-44)
      sb.Append(Space(10))
      sb.Append(Format(._AMISAM * 100, "000000000000")) 'PAYMENT AMOUNT 1 (55-66) 
      '   sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 1 (55-66) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 2 (67-78) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 3 (79-90) 
      '   sb.Append(Format(._AMISAM * 100, "000000000000")) 'PAYMENT AMOUNT 3 (79-90) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 4 (91-102) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 5 (103-114) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 6 (115-126) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 7 (127-138) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 8 (139-150) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT 9 (151-162) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT A (163-174) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT B (175-186) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT C (187-198) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT D (199-210) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT E (211-222) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT F (223-234) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT G (235-246) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT H (247-258) 
      sb.Append(Format(0, "000000000000")) 'PAYMENT AMOUNT J (259-270) 
      sb.Append(Space(16))
      sb.Append(" ") 'FOREIGN COUNTRY INDICATOR = 1 (287)
      sb.Append(MyUtils.JustifyLeft(._ARNAME, 40)) 'FIRST PAYEE NAME (288-327)
      sb.Append(Space(40))
      sb.Append(MyUtils.JustifyLeft(._ARADR1, 40)) 'PAYEE ADDRESS (368-407)
      sb.Append(Space(40))
      WrkCity = ""
      WrkState = ""
      WrkZip = 0
      WrkAddr = ""
      If Trim(._ARADR2) <> "" Then
        WrkAddr = Trim(._ARADR2)
      End If
      If Trim(._ARADR3) <> "" Then
        WrkAddr = Trim(._ARADR3)
      End If
      If Trim(._ARADR4) <> "" Then
        WrkAddr = Trim(._ARADR4)
      End If
      WrkAddr = Replace(WrkAddr, ", ", ",")
      Pos = InStr(WrkAddr, ",")
      If Pos > 0 Then
        WrkCity = Left(WrkAddr, Pos - 1)
        WrkState = Mid(WrkAddr, Pos + 1, 2)
        Pos2 = InStr(Pos + 2, WrkAddr, " ")
        WrkZip = MyUtils.CnvSng(Mid(WrkAddr, Pos2 + 1, 5))
      Else
        Pos2 = InStrRev(WrkAddr, " ")
        WrkZip = MyUtils.CnvSng(Mid(WrkAddr, Pos2 + 1, 5))
        Pos = InStrRev(WrkAddr, " ", Pos2 - 1)
        If Pos > 0 Then
          WrkCity = Left(WrkAddr, Pos - 1)
          WrkState = Mid(WrkAddr, Pos + 1, 2)
        Else
          WrkCity = "*** Error ***"
          WrkState = "**"
          WrkError = True
        End If
      End If
      sb.Append(MyUtils.JustifyLeft(WrkCity, 40)) 'PAYEE CITY (448-487)  
      sb.Append(MyUtils.JustifyLeft(WrkState, 2)) 'PAYEE STATE (488-489)
      sb.Append(Format(WrkZip, "00000")) 'PAYEE ZIP (490-498)
      sb.Append(Space(4)) 'Zip 4
      sb.Append(Space(1))
      sb.Append(Format(Counter, "00000000")) 'RECORD SEQUENCE IN THE FILE (500-507)
      sb.Append(Space(155))
      sb.Append(Space(60)) 'NEC: Blanks (663-722)
      '   sb.Append(MyUtils.JustifyLeft(._ASTEID, 60)) 'MISC: SPECIAL DATA FOR FILERS PURPOSE (663-722)
      sb.Append(Format(0, "000000000000")) 'STATE TAX = 0 (723-734)
      sb.Append(Format(0, "000000000000")) 'LOCAL TAX = 0 (735-746)
      sb.Append(Space(2)) 'COMBINED FEDERAL/STATE CODE (747-748)
      sb.Append(Space(2))
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
  Private Function BuildCodeC(ByVal WrkTotMisc As Decimal) As String
    'End of Payer
    Dim sb As StringBuilder
    Dim WrkStr As String

    With myAP1099PQ
      sb = New StringBuilder
      sb.Append("C") 'Code (1)
      sb.Append(Format(WrkRecCount, "00000000")) 'NUMBER OF PAYEES (2-9)
      sb.Append(Space(6))
      sb.Append(Format(WrkTotMisc * 100, "000000000000000000")) 'PAYMENT AMOUNT 1 (16-33) 
      '   sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 1 (16-33) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 2 (34-51) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 3 (52-69) 
      '   sb.Append(Format(WrkTotMisc * 100, "000000000000000000")) 'PAYMENT AMOUNT 3 (52-69) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 4 (70-87) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 5 (88-105) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 6 (106-123) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 7 (124-141) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 8 (142-159) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT 9 (151-177) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT A (178-195) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT B (196-213) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT C (214-231) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT D (232-249) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT E (250-267) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT F (268-285) 
      sb.Append(Format(0, "000000000000000000")) 'PAYMENT AMOUNT G (286-303) 
      sb.Append(Space(196))
      sb.Append(Format(Counter, "00000000")) 'RECORD SEQUENCE IN THE FILE (500-507)
      sb.Append(Space(243))
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
  Private Function BuildCodeF() As String
    'End of Transmission
    Dim sb As StringBuilder
    Dim WrkStr As String

    With myAP1099PQ
      sb = New StringBuilder
      sb.Append("F") 'Code (1)
      sb.Append(Format(1, "00000000")) 'NUMBER OF PAYERS (2-9)
      sb.Append(StrDup(21, "0")) '21 ZEROES (10-30)
      sb.Append(Space(19))
      sb.Append(Format(WrkRecCount, "00000000")) 'NUMBER OF PAYEES (50-57)
      sb.Append(Space(442))
      sb.Append(Format(Counter, "00000000")) 'RECORD SEQUENCE IN THE FILE (500-507)
      sb.Append(Space(243))
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With

  End Function
End Module
