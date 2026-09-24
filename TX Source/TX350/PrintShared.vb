Imports System.Text
Module PrintShared
Dim myTXPROF As TXPROF.myData
Dim myTXMRATE As TXMRATE.myData
Public myTXFMBILL As TXFMBILL.myData
'Mill Rate
Public MrateMillrt As Decimal
'Profile
Public ProfPrPerd As Integer
Public ProfWaiver As Decimal
Public ProfTxDt(3) As Date
Public ProfGrDt(3) As Date
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Group", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
End Sub
Public Sub BuildDSBill(ByRef dsBill As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
      .Columns.Add("PostNet", Type.GetType("System.String"))
      .Columns.Add("ScanLine", Type.GetType("System.String"))
  End With
  dsBill.Tables.Add(myTable)
End Sub
Public Sub BuildDSTot(ByRef dsTot As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytabletot"
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTable)
End Sub
Public Sub GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String, _
  ByVal WrkDist As Integer)

myTXPROF = New TXPROF.mydata(MyDBConnect)
myTXPROF.GetOneRecordP(WrkType, WrkGLYear, WrkPhase, WrkDist)
If Not myTXPROF.RecordNotFound Then
	With myTXPROF
    ProfTxDt(0) = MyUtils.GetDBDateMDY(._PRDUE1)
    ProfTxDt(1) = MyUtils.GetDBDateMDY(._PRDUE2)
    ProfTxDt(2) = MyUtils.GetDBDateMDY(._PRDUE3)
    ProfTxDt(3) = MyUtils.GetDBDateMDY(._PRDUE4)
    ProfGrDt(0) = MyUtils.GetDBDateMDY(._PRGRD1)
    ProfGrDt(1) = MyUtils.GetDBDateMDY(._PRGRD2)
    ProfGrDt(2) = MyUtils.GetDBDateMDY(._PRGRD3)
    ProfGrDt(3) = MyUtils.GetDBDateMDY(._PRGRD4)
		ProfWaiver = ._PRWAV
	End With
Else
	MsgBox("Add year " & WrkGLYear, MsgBoxStyle.Critical, "Tax Profile missing")
	End
End If
myTXPROF.CloseFile()

End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)

  myTXMRATE = New TXMRATE.mydata(MyDBConnect)
  myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
  If myTXMRATE.RecordNotFound Then
    myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
  End If
  If Not myTXMRATE.RecordNotFound Then
    With myTXMRATE
      MrateMillrt = ._MRRATE
    End With
  End If
End Sub
Public Sub GetTXFMBILL(ByVal WrkType As String)
  myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)

  myTXFMBILL.GetOneRecordP(WrkType)
End Sub
Public Function BuildScanLine(ByVal WrkList As Integer, ByVal WrkGLYear As Integer, _
 ByVal WrkType As String, ByVal WrkTaxTotal As Decimal, ByVal WrkTax1st As Decimal, _
 ByVal WrkBackTax As String) As String

    Dim sb As StringBuilder
    Dim WrkChk As String
    Dim WrkChkDigit1 As Integer
    Dim WrkChkDigit2 As Integer
    Dim WrkChkDigit3 As Integer
    Dim WrkChkDigit4 As Integer
    Dim WrkChkDigit5 As Integer
    Dim HoldString As String

    sb = New StringBuilder
    'Check Digit #1 = Town/Year/BT
		WrkChk = Format(myTOWN._TOWNBR, "000")
    WrkChk = WrkChk & Trim(Str(WrkGLYear))
    If WrkBackTax = "BT" Then
      WrkChk = WrkChk + "1"
    Else
      WrkChk = WrkChk + "0"
    End If
    WrkChkDigit1 = CalcModulus(WrkChk)
    HoldString = WrkChk + Trim(Str(WrkChkDigit1))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit1)

    'Check Digit #2 = Type#/List#
    If myTOWN._TOWNBR = 162 Then
      WrkChk = GetTypeNoAmerica(WrkType) & Format(WrkList, "000000")
    Else
      WrkChk = GetTypeNo(WrkType) & Format(WrkList, "000000")
    End If
    WrkChkDigit2 = CalcModulus(WrkChk)
    HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit2))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit2)

    'Check Digit#3 = Tax Total
    WrkChk = Format(WrkTaxTotal * 100, "000000000")
    WrkChkDigit3 = CalcModulus(WrkChk)
    HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit3))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit3)

    'Check Digit#4 = Tax1st 
    WrkChk = Format(WrkTax1st * 100, "000000000")
    WrkChkDigit4 = CalcModulus(WrkChk)
    HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit4))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit4)

    'Check Digit#5 = Everything 
    WrkChkDigit5 = CalcModulus(HoldString)
    sb.Append(WrkChkDigit5)
    Return sb.ToString
End Function
Public Function BuildScanLineWebster(ByVal WrkList As Integer, ByVal WrkGLYear As Integer, _
 ByVal WrkType As String, ByVal WrkTaxTotal As Decimal, ByVal WrkTax1st As Decimal, _
 ByVal WrkTax2nd As Decimal, ByVal WrkBackTax As String) As String

    Dim sb As StringBuilder
    Dim WrkChk As String
    Dim WrkChkDigit1 As Integer
    Dim WrkChkDigit2 As Integer
    Dim WrkChkDigit3 As Integer
    Dim WrkChkDigit4 As Integer
    Dim HoldString As String

    sb = New StringBuilder
    'Check Digit #1 = Town/Year/BT/Type/List #
		WrkChk = Format(myTOWN._TOWNBR, "000")
    WrkChk = WrkChk & Mid(WrkGLYear, 3, 2)
    If WrkBackTax = "BT" Then
      WrkChk = WrkChk + "1"
    Else
      WrkChk = WrkChk + "0"
    End If
		If myTOWN._TOWNBR = 99 Then
			WrkChk = WrkChk & GetTypeNoWebster(WrkType) & Format(WrkList, "000000")
		Else
			WrkChk = WrkChk & GetTypeNoWebster(WrkType) & Format(WrkList, "0000000")
		End If
		WrkChkDigit1 = CalcModulus(WrkChk)
		HoldString = WrkChk + Trim(Str(WrkChkDigit1))
		sb.Append(WrkChk)
		sb.Append(WrkChkDigit1)

		'Check Digit = Tax1st/Tax2nd
		WrkChk = Format(WrkTax1st * 100, "00000000")
		WrkChk = WrkChk & Format(WrkTax2nd * 100, "00000000")
		WrkChk = WrkChk & Format(0, "00000000")
		WrkChk = WrkChk & Format(0, "00000000")
		WrkChkDigit2 = CalcModulus(WrkChk)
		HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit2))
		sb.Append(WrkChk)
		sb.Append(WrkChkDigit2)

		'Check Digit#3 = Tax Total
		WrkChk = Format(WrkTaxTotal * 100, "0000000000")
		WrkChkDigit3 = CalcModulus(WrkChk)
		HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit3))
		sb.Append(WrkChk)
		sb.Append(WrkChkDigit3)

		'Check Digit#4 = Everything 
		WrkChkDigit4 = CalcModulus(HoldString)
		sb.Append(WrkChkDigit4)
		Return sb.ToString
End Function
Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkGLYear As Integer) As String
  Dim WrkBarCode As String

  WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
  Return WrkBarCode
End Function
Public Function BuildPostNet(ByVal Zip5 As Integer, ByVal Zip4 As Integer, _
   Optional ByVal ZipAlpha As String = "") As String
   'Build POSTNET bar code (USPS Bar Code font)  
   Dim WrkBarCode As String
   Dim sb As StringBuilder
   Dim WrkChkDigit As Integer

   sb = New StringBuilder
   If ZipAlpha = "" Then
     sb.Append(Format(Zip5, "00000"))
     If Zip4 > 0 Then
       sb.Append(Format(Zip4, "0000"))
     End If
   Else
     ZipAlpha = Replace(ZipAlpha, "-", "")
     sb.Append(ZipAlpha)
   End If

  WrkChkDigit = CalcModPostNet(sb.ToString)
  sb.Append(WrkChkDigit)
  WrkBarCode = "(" & sb.ToString & ")"
  Return WrkBarCode
End Function
Public Function CalcModulus(ByVal sNumber As String) As Integer

  Select Case Trim(myTXFMBILL._MOD10)
  Case "E"
    CalcModulus = CalcModulus10(sNumber, False)
  Case "O"
    CalcModulus = CalcModulus10(sNumber)
  Case "7"
    CalcModulus = CalcModulus10_7(sNumber)
  End Select
End Function
Public Function CalcModulus10(ByVal sNumber As String, _
  Optional ByVal DoubleOdd As Boolean = True) As Integer
  'Modulus 10 Check Digit
  'DoubleOdd: true=double odd digits / false=double even digits
  Dim tmpTotal As Integer
  Dim i As Integer, f As Byte, tmpStr As String
  Dim j As Integer

  If DoubleOdd Then
    j = 1
  Else
    j = 0
  End If

  For i = 1 To Len(sNumber)
    f = f + 1
    If (f Mod 2) = j Then
      tmpStr = CInt(Mid$(sNumber, i, 1)) * 2
      If Len(tmpStr) > 1 Then
        tmpTotal = tmpTotal + CInt(Mid$(tmpStr, 1, 1)) + CInt(Mid$(tmpStr, 2, 1))
      Else
        tmpTotal = tmpTotal + CInt(tmpStr)
      End If
      tmpStr = ""
    Else
      tmpTotal = tmpTotal + CInt(Mid$(sNumber, i, 1))
    End If
  Next i
  If Right$(CStr(tmpTotal), 1) = "0" Then
    tmpTotal = 0
  Else
    tmpTotal = ((tmpTotal + 10) - CInt(Right$(CStr(tmpTotal), _
  1))) - tmpTotal
  End If
  CalcModulus10 = tmpTotal
End Function
Public Function CalcModulus10_7(ByVal sNumber As String) As Integer

  Dim I As Integer
  Dim CheckDigit As Integer ' check digit variable

  ' set up variable
  CheckDigit = 0

  ' build check sum subtotal
  For I = 1 To Len(sNumber)
    Select Case (I Mod 3)
    Case 1
      CheckDigit = CheckDigit + (Val(Mid(sNumber, I, 1)) * 7)
    Case 2
      CheckDigit = CheckDigit + (Val(Mid(sNumber, I, 1)) * 3)
    Case 0
      CheckDigit = CheckDigit + (Val(Mid(sNumber, I, 1)) * 1)
    End Select
  Next I

  CheckDigit = CheckDigit Mod 10
  If CheckDigit > 0 Then
    CheckDigit = 10 - CheckDigit
  End If
  Return CheckDigit

End Function
Public Function CalcModPostNet(ByVal sNumber As String) As Integer

  Dim I As Integer
  Dim CheckDigit As Integer ' check digit variable

  ' set up variable
  CheckDigit = 0

  ' build check sum subtotal
  For I = 1 To Len(sNumber)
    CheckDigit = CheckDigit + Val(Mid(sNumber, I, 1))
  Next I

  CheckDigit = CheckDigit Mod 10
  If CheckDigit > 0 Then
    CheckDigit = 10 - CheckDigit
  End If
  Return CheckDigit

End Function
Public Function GetTypeNo(ByVal Type As String) As Integer
   '1 FOR SUPPLEMENT MOTOR VEHICLE
   '2 FOR MOTOR VEHICLE  
   '3 FOR PERSONAL PROPERTY 
   '4 FOR REAL ESTATE       
  Select Case Type
  Case "P"
    Return 3
  Case "M"
    Return 2
  Case "R"
    Return 4
  Case "S"
    Return 1
  End Select
End Function
Public Function GetTypeNoAmerica(ByVal Type As String) As Integer
   '1 FOR REAL ESTATE       
   '2 FOR PERSONAL PROPERTY 
   '3 FOR MOTOR VEHICLE  
   '4 FOR SUPPLEMENT MOTOR VEHICLE
  Select Case Type
  Case "P"
    Return 2
  Case "M"
    Return 3
  Case "R"
    Return 1
  Case "S"
    Return 4
  End Select
End Function
Public Function GetTypeNoWebster(ByVal Type As String) As Integer
   '1 FOR REAL ESTATE       
   '2 FOR PERSONAL PROPERTY 
   '3 FOR MOTOR VEHICLE  
   '4 FOR SUPPLEMENT MOTOR VEHICLE
  Select Case Type
  Case "P"
    Return 2
  Case "M"
    Return 3
  Case "R"
    Return 1
  Case "S"
    Return 4
  End Select
End Function
End Module






