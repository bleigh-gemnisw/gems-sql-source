Module CnvType
  'Covert Tax Types: File name TAX_BILL_TYPES
  Public Function GetTaxType(ByVal TownNo As Integer, ByVal BillType As Integer) As String
    Dim WrkType As String

    WrkType = ""
    Select Case TownNo
      Case 162
        WrkType = GetTaxType162(BillType)
      Case Else
    End Select
    Return WrkType
  End Function
  Public Function GetTaxFamily(ByVal TownNo As Integer, ByVal BillType As Integer) As String
    Dim WrkFamily As String

    WrkFamily = ""
    Select Case TownNo
      Case 162
        WrkFamily = GetTaxFamily162(BillType)
      Case Else
    End Select
    Return WrkFamily
  End Function
  Private Function GetTaxType162(ByVal BillType As Integer) As String
    Dim WrkType As String
    WrkType = ""
    Select Case BillType
      Case 5
        WrkType = "A"
      Case 6
        WrkType = "U"
      Case 7
        WrkType = "C"
      Case 17
        WrkType = "D"
      Case 18
        WrkType = "W"
      Case Else
        WrkType = ""
    End Select
    Return WrkType
  End Function
  Private Function GetTaxFamily162(ByVal BillType As Integer) As String
    Dim WrkFamily As String
    WrkFamily = ""
    Select Case BillType
      Case 5
        WrkFamily = "A"
      Case 6
        WrkFamily = "U"
      Case 7
        WrkFamily = "U"
      Case 15
        WrkFamily = "A"
      Case 17
        WrkFamily = "U"
      Case 18
        WrkFamily = "U"
      Case Else
        WrkFamily = ""
    End Select
    Return WrkFamily
  End Function

End Module
