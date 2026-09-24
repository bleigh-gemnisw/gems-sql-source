Module Common2
Public Function BuildYears(ByVal WrkYear As Integer, ByVal YearsDiff As Integer) As String
  Dim WrkStr As String

  WrkStr = (WrkYear + YearsDiff - 1) & "-" & (WrkYear + YearsDiff)
  Return WrkStr
End Function
End Module
