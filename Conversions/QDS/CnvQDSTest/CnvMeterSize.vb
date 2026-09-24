
Module CnvMeterSize
  'Convert Meter Size 2 Chars to 1 char 
  Public Function GetMeterSize(ByVal WrkSize As String, ByVal WrkMult As Integer) As String
    Dim WrkCode As String

    Select Case Trim(WrkSize)
      Case "S1"
        If WrkMult = 1 Then
          WrkCode = Trim(Mid(WrkSize, 2, 1))
        Else
          WrkCode = "H"
        End If
      Case "S2", "S3"
        WrkCode = Trim(Mid(WrkSize, 2, 1))
      Case "S4"
        If WrkMult = 10 Then
          WrkCode = Trim(Mid(WrkSize, 2, 1))
        Else
          WrkCode = "I"
        End If
      Case "S5", "W5"
        If WrkMult = 10 Then
          WrkCode = Trim(Mid(WrkSize, 2, 1))
        Else
          WrkCode = "J"
        End If
      Case "S6"
        If WrkMult = 10 Then
          WrkCode = Trim(Mid(WrkSize, 2, 1))
        Else
          WrkCode = "K"
        End If
      Case "S6"
        If WrkMult = 10 Then
          WrkCode = Trim(Mid(WrkSize, 2, 1))
        Else
          WrkCode = "L"
        End If
      Case Else
        WrkCode = Trim(Mid(WrkSize, 2, 1))
    End Select
    Return WrkCode
  End Function
End Module
