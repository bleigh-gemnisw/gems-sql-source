Public Module Common2
  Public Const cMax As Integer = 50
  Public SelAcct(cMax) As String
Public Function ProcessSelItems() As String
  Dim WrkAcct As String
  Dim I As Integer
  WrkAcct = ""

  For I = 0 To SelAcct.GetUpperBound(0)
    If SelAcct(I) <> "" Then
      WrkAcct = SelAcct(I)
      SelAcct(I) = ""
      Exit For
    End If
  Next

  Return WrkAcct
End Function
Public Sub ClearSelAcct()
  Dim I As Integer
  For I = 0 To cMax
    SelAcct(I) = ""
  Next
End Sub
End Module






