Module PrintShared
Public Function BuildSort(ByVal Sortby As String) As String

  BuildSort = ""
  Select Case Sortby
  Case "Asset Type"
        BuildSort = "FAASCD"
      Case "Classification"
        BuildSort = "FACLCD"
      Case "Equipment Condition"
        BuildSort = "FAEQCD"
      Case "Department"
        BuildSort = "FADECD"
      Case "Location"
        BuildSort = "FABLCD"
      Case "Vendor"
        BuildSort = "FAVEND"
      Case "GLGrouping"
        BuildSort = "FAGLGP"
      Case "User1"
        BuildSort = "FAU1CD"
      Case "User2"
        BuildSort = "FAU2CD"
      Case "User3"
        BuildSort = "FAU3CD"
      Case "User4"
        BuildSort = "FAU4TX"
      Case "User5"
        BuildSort = "FAU5TX"
    End Select

End Function
End Module
