Module PrintShared
Public myUTFMBILL As UTFMBILL.myData
Public myTXFMBILL As TXFMBILL.myData
Public Sub GetUTFMBILL(ByVal WrkType As String)
	myUTFMBILL = New UTFMBILL.mydata(MyDBConnect)

	myUTFMBILL.GetOneRecordP(WrkType)
End Sub
Public Sub GetTXFMBILL(ByVal WrkType As String)
	myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)

	myTXFMBILL.GetOneRecordP(WrkType)
End Sub
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
	Dim CheckDigit As Integer	' check digit variable

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
End Module






