Imports System.Text
Module PrintShared

Public Function WriteHeader() As String
	Dim sb As StringBuilder
	Dim WrkStr As String
  'VIN, BODY, CLASS, LIST_NO, STREET, CITY, STATE, ZIP, LIGHT_WEIGHT, GROSS_WEIGHT, 
  'MAKE, MODEL, REGISTRATION, TAXPAYER, YEAR,AXLES,UNIQUE_ID, OLD_VALUE, VALUE.

  'vinno, body, class, list#, addr1, city, state, zip5, lwt, gwt,
  'make, model, regno, name, Year, cylax, WrkSeqNo, WrkLastYear , value
	'Write Headers
	sb = New StringBuilder
	sb.Append("VIN")
	sb.Append(",")
	sb.Append("BODY")
	sb.Append(",")
	sb.Append("CLASS")
	sb.Append(",")
	sb.Append("LIST_NO")
	sb.Append(",")
  sb.Append("STREET")
  sb.Append(",")
  sb.Append("CITY")
  sb.Append(",")
  sb.Append("STATE")
  sb.Append(",")
  sb.Append("ZIP")
  sb.Append(",")
  sb.Append("LIGHT_WEIGHT")
	sb.Append(",")
	sb.Append("GROSS_WEIGHT")
	sb.Append(",")
	sb.Append("MAKE")
	sb.Append(",")
	sb.Append("MODEL")
	sb.Append(",")
	sb.Append("REGISTRATION")
	sb.Append(",")
	sb.Append("TAXPAYER")
	sb.Append(",")
	sb.Append("YEAR")
	sb.Append(",")
	sb.Append("AXLES")
	sb.Append(",")
	sb.Append("UNIQUE_ID")
	sb.Append(",")
	sb.Append("OLD_VALUE")
	sb.Append(",")
	sb.Append("VALUE")
	WrkStr = sb.ToString
	sb = Nothing
	Return WrkStr
End Function
End Module






