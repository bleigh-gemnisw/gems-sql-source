Module CnvType
  Public Function GetTaxType(ByVal BillType As String) As String
    Dim WrkType As String
    WrkType = ""
    Select Case BillType
      Case "A"
        WrkType = "X"
      Case Else
        WrkType = BillType
    End Select
    Return WrkType
  End Function
  Public Function GetTaxFamily(ByVal BillType As String) As String
    Dim WrkFamily As String
    WrkFamily = ""
    Select Case BillType
      Case "A"
        WrkFamily = "R"
      Case Else
        WrkFamily = BillType
    End Select
    Return WrkFamily
  End Function
End Module
