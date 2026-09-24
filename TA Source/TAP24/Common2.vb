Module Common2

Public Function GetFilingDesc(WrkCode As String) As String
Dim WrkDesc As String

Select Case WrkCode
Case ""
  WrkDesc = "On Time"
Case "E"
  WrkDesc = "Extension"
Case "L"
  WrkDesc = "Late"
Case "N"
  WrkDesc = "Non-Filer"
Case Else
  WrkDesc = WrkCode
End Select

Return WrkDesc
End Function
Public Function GetStatusDesc(WrkCode As String) As String
Dim WrkDesc As String

Select Case WrkCode
Case ""
  WrkDesc = "Active"
Case "C"
  WrkDesc = "Increase"
Case "I"
  WrkDesc = "Inactive"
Case "P"
  WrkDesc = "Pending"
Case Else
  WrkDesc = WrkCode
End Select

Return WrkDesc
End Function

End Module






