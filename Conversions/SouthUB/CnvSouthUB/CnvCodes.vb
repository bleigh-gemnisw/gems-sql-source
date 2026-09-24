Module CnvCodes
  'Convert Sewer Codes (WT_ID)
  Public Function GetSewerCode(ByVal WrkType As String, ByVal Code As String) As String
    Dim WrkCode As String
    Select Case Trim(Code)
      Case "CMS", "DMS"
        WrkCode = "M"
      Case "FIX", "FW"
        WrkCode = "1"
      Case "GPM"
        If WrkType = "U" Then
          WrkCode = "2"
        Else
          WrkCode = "*" 'Keep meter code and change meter size
        End If
      Case "NCF"
        WrkCode = "N" 'Keep meter code and change meter size
      Case Else
        WrkCode = ""
    End Select
    Return WrkCode
  End Function
End Module
