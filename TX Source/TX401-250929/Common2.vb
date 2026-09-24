Public Module Common2
  Public Const cMax As Integer = 100
  Public SelListNo(cMax) As Integer

Public Function ProcessSelItems() As Integer
  Dim WrkListNo As Integer
  Dim I As Integer
  WrkListNo = 0

  For I = 0 To SelListNo.GetUpperBound(0)
    If SelListNo(I) > 0 Then
      WrkListNo = SelListNo(I)
      SelListNo(I) = 0
      Exit For
    End If
  Next

  Return WrkListNo
End Function
End Module






