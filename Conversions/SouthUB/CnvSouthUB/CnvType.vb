Module CnvType
  'Covert Tax Types: File name TAX_BILL_TYPES
  Public Function GetTaxType(ByVal TownNo As Integer, ByVal BillType As Integer) As String
    Dim WrkType As String

    WrkType = ""
    Select Case TownNo
      Case 108
        WrkType = GetTaxType108(BillType)
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
      Case 108
        WrkFamily = GetTaxFamily108(BillType)
      Case 162
        WrkFamily = GetTaxFamily162(BillType)
      Case Else
    End Select
    Return WrkFamily
  End Function
  Private Function GetTaxType108(ByVal BillType As Integer) As String
    Dim WrkType As String
    WrkType = ""
    Select Case BillType
      Case 1
        WrkType = "R"
      Case 2
        WrkType = "P"
      Case 3
        WrkType = "M"
      Case 4
        WrkType = "S"
      Case 5
        WrkType = "A"
      Case 6
        WrkType = "U"
      Case 7
        WrkType = "U" 'Sewer Use
      Case 8
        WrkType = "G" 'Aircraft
      Case 9
        WrkType = "V" 'Sewer Use Spc
      Case 10
        WrkType = "F" 'Utilization Fee
      Case 41
        WrkType = "E"
    End Select
    Return WrkType
  End Function
  Private Function GetTaxType162(ByVal BillType As Integer) As String
    Dim WrkType As String
    WrkType = ""
    Select Case BillType
      Case 1
        WrkType = "R"
      Case 2
        WrkType = "P"
      Case 3
        WrkType = "M"
      Case 4
        WrkType = "S"
      Case 5
        WrkType = "A"
      Case 6
        WrkType = "U"
      Case 7
        WrkType = "C"
      Case 11
        WrkType = "X"
      Case 12
        WrkType = "Z"
      Case 13
        WrkType = "N"
      Case 14
        WrkType = "T"
      Case 15
        WrkType = ""
      Case 17
        WrkType = "D"
      Case 18
        WrkType = "W"
      Case 21
        WrkType = "Y"
    End Select
    Return WrkType
  End Function
  Private Function GetTaxFamily108(ByVal BillType As Integer) As String
    Dim WrkFamily As String
    WrkFamily = ""
    Select Case BillType
      Case 1
        WrkFamily = "R"
      Case 2
        WrkFamily = "P"
      Case 3
        WrkFamily = "M"
      Case 4
        WrkFamily = "S"
      Case 5
        WrkFamily = "A"
      Case 6
        WrkFamily = "U"
      Case 7
        WrkFamily = "U"
      Case 8
        WrkFamily = "U" 'Aircraft
      Case 9
        WrkFamily = "U" 'Sewer Use Spc
      Case 10
        WrkFamily = "U" 'Utilization Fee
      Case 41
        WrkFamily = "U"
    End Select
    Return WrkFamily
  End Function
  Private Function GetTaxFamily162(ByVal BillType As Integer) As String
    Dim WrkFamily As String
    WrkFamily = ""
    Select Case BillType
      Case 1
        WrkFamily = "R"
      Case 2
        WrkFamily = "P"
      Case 3
        WrkFamily = "M"
      Case 4
        WrkFamily = "S"
      Case 5
        WrkFamily = "A"
      Case 6
        WrkFamily = "U"
      Case 7
        WrkFamily = "U"
      Case 11
        WrkFamily = "R"
      Case 12
        WrkFamily = "P"
      Case 13
        WrkFamily = "M"
      Case 14
        WrkFamily = "S"
      Case 15
        WrkFamily = "A"
      Case 17
        WrkFamily = "U"
      Case 18
        WrkFamily = "U"
      Case 21
        WrkFamily = "R"
    End Select
    Return WrkFamily
  End Function

End Module
