Imports System.Text
Module PrintShared

  Public Function WriteHeader() As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    'Write Headers
    sb = New StringBuilder
    sb.Append("LIST_NO")
    sb.Append(",")
    sb.Append("YEAR")
    sb.Append(",")
    sb.Append("OWNER_NAME")
    sb.Append(",")
    sb.Append("DBA")
    sb.Append(",")
    sb.Append("LOCATION_NO")
    sb.Append(",")
    sb.Append("LOCATION")
    sb.Append(",")
    sb.Append("DNAME")
    sb.Append(",")
    sb.Append("DADDR")
    sb.Append(",")
    sb.Append("DADDR2")
    sb.Append(",")
    sb.Append("DCITY")
    sb.Append(",")
    sb.Append("DSTATE")
    sb.Append(",")
    sb.Append("DZIP")
    sb.Append(",")
    sb.Append("DEMAIL")
    sb.Append(",")
    sb.Append("FORM")
    sb.Append(",")
    sb.Append("BUS_TYPE")
    sb.Append(",")
    sb.Append("BAR_CODE")
    sb.Append(",")
    sb.Append("BACK_TAX")
    sb.Append(",")
    sb.Append("STATUS")
    sb.Append(",")
    sb.Append("FILING STATUS")
    sb.Append(",")
    sb.Append("OID")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Public Function BuildBarCode(ByVal WrkList As Integer) As String
    Dim WrkBarCode As String

    WrkBarCode = "*" & Format(WrkList, "000000") & "*"
    Return WrkBarCode
  End Function
End Module






