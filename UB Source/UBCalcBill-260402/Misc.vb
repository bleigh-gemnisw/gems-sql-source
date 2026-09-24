Module Misc
Friend Function Round(ByVal Number As Decimal, ByVal Decimals As Integer) As Decimal
'Round numbers normally. Note that Math.round uses banker's rounding.
Dim WrkNo As Decimal
Dim WrkInt As Long
Select Case Decimals
Case 0
  WrkNo = Math.Floor(Number + 0.5)
Case 1
  WrkNo = Number * 10
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 10
Case 2
  WrkNo = Number * 100
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 100
Case 3
  WrkNo = Number * 1000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 1000
Case 4
  WrkNo = Number * 10000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 10000
End Select

Return WrkNo
End Function

End Module
