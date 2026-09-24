Module Numbers2Words

Public Function CurrencyToText(ByVal dblAmount As Decimal, _
	ByVal intLength As Integer) As String

' Comments : Converts a number to spelled out text with padding/length
' options.
' Parameters: dblAmount - Pound/Punt or even "Euro" amount to convert
' intLength - Length of string to create (pads with trailing
' asterisks to fill to length). If text exceeds the given
' length, the numeric representation is given. If the
' intLength parameter is set to 0, the full string is
' returned without padding.
' Returns : String representation of the amount

Dim strText As String
Dim strCurrFormat As String
Dim intLowDigit As Integer
Dim strPence As String
Dim intGroup As Integer
Dim intDigit1 As Integer
Dim intDigit2 As Integer
Dim intDigit3 As Integer
Dim strSubText As String
Dim intGroupCounter As Integer
Dim intCounter As Integer

' Create the arrays
Dim astrOnes(0 To 19) As String
Dim astrTens(0 To 9) As String
Dim astrGroup(0 To 3) As String

' Fill the arrays.
astrOnes(1) = "ONE"
astrOnes(2) = "TWO"
astrOnes(3) = "THREE"
astrOnes(4) = "FOUR"
astrOnes(5) = "FIVE"
astrOnes(6) = "SIX"
astrOnes(7) = "SEVEN"
astrOnes(8) = "EIGHT"
astrOnes(9) = "NINE"
astrOnes(10) = "TEN"
astrOnes(11) = "ELEVEN"
astrOnes(12) = "TWELVE"
astrOnes(13) = "THIRTEEN"
astrOnes(14) = "FOURTEEN"
astrOnes(15) = "FIFTEEN"
astrOnes(16) = "SIXTEEN"
astrOnes(17) = "SEVENTEEN"
astrOnes(18) = "EIGHTTEEN"
astrOnes(19) = "NINETEEN"
astrTens(1) = "TEN"
astrTens(2) = "TWENTY"
astrTens(3) = "THIRTY"
astrTens(4) = "FORTY"
astrTens(5) = "FIFTY"
astrTens(6) = "SIXTY"
astrTens(7) = "SEVENTY"
astrTens(8) = "EIGHTY"
astrTens(9) = "NINETY"
astrGroup(1) = "THOUSAND"
astrGroup(2) = "MILLION"
astrGroup(3) = "BILLION"

' Prepare the temp variable
strText = ""

' Ensure amount is greater than zero
If dblAmount > 0 Then

' Format the string
strCurrFormat = Format$(dblAmount, "#,###.00")

' Get the lower digit part
intLowDigit = InStr(strCurrFormat, ".") - 1

' Get the cents
strPence = Mid$(strCurrFormat, intLowDigit + 2, 2)

intGroup = 0

' Loop through lower digit part
While intLowDigit > 0
intDigit3 = CInt(Mid$(strCurrFormat, intLowDigit, 1))
If intLowDigit > 1 Then
	intDigit2 = CInt(Mid$(strCurrFormat, intLowDigit - 1, 1))
Else
	intDigit2 = 0
End If

If intLowDigit > 2 Then
	intDigit1 = CInt(Mid$(strCurrFormat, intLowDigit - 2, 1))
Else
	intDigit1 = 0
End If

strSubText = ""

' Get the hundreds
If intDigit1 > 0 Then
	strSubText = astrOnes(intDigit1) & " HUNDRED "
End If

If intDigit2 > 0 Then
	' Get the ones
	If intDigit2 = 1 Then
		strSubText = strSubText & astrOnes(intDigit3 + 10) & " "
	Else
		strSubText = strSubText & astrTens(intDigit2)
		If intDigit3 > 0 Then
			strSubText = strSubText & "-" & astrOnes(intDigit3)
		End If
		strSubText = strSubText & " "
	End If
Else

If intDigit3 > 0 Then
	strSubText = strSubText & astrOnes(intDigit3) & " "
End If
End If

' Get the grouping
If strSubText <> "" And intGroupCounter <> 0 Then
	strSubText = strSubText & astrGroup(intGroupCounter) & " "
End If

' Concatenate the temp vars
strText = strSubText & strText

' Move back through the number
intLowDigit = intLowDigit - 4

' Increment the counter
intGroupCounter = intGroupCounter + 1

End While

' Finalize the text
strText = strText + "& " + strPence + "/100"

' Replace the place holder with "NO" cents string
If Left$(strText, 1) = "&" Then
	strText = "NO " + strText
End If

' Cleanup and pad
If intLength > 0 Then

	If Len(strText) > intLength Then
		strText = strCurrFormat
	Else
		For intCounter = 1 To (intLength - Len(strText))
			strText = strText + "*"
		Next intCounter
	End If
End If
End If

' Return the result
CurrencyToText = strText
End Function
End Module
