Module ParseCSV

Function Parse(ByVal sText As String, ByVal sDelim As String) As Array

    ' Parses text buffer (sText), returning items
    ' separated by sDelim in sArray().

    Dim sArray As String()
    sArray = sText.Split(sDelim)

    Dim iStart As Integer
    Dim iFound As Integer
    Dim iFoundQuote As Integer
    Dim SaveStart As Integer
    Dim nElement As Integer
    Dim sFieldData As String
    Dim sFieldLen As Integer
    Const cQuote As Char = Chr(34)
    Const c As Char = Chr(39)

    ' Count number of delimiters so we
    ' know how large to dimension array
    ReDim sArray(0 To 0)
    iStart = 1
    SaveStart = 1
    nElement = -1

    Do
      iFound = InStr(iStart, sText, sDelim)
      If iFound > 0 Then
        If Mid(sText, SaveStart, 1) = cQuote Or Mid(sText, SaveStart, 1) = c Then
          If iFound > 1 Then
'            If Mid(sText, iFound - 1, 1) <> cQuote And Mid(sText, iFound - 1, 1) <> c And Mid(sText, iFound + 1, 1) <> cQuote Then
            If Mid(sText, iFound - 1, 1) <> cQuote And Mid(sText, iFound - 1, 1) <> c Then
              GoTo NextDelim
            End If
          End If
        End If
      End If
      nElement = nElement + 1
      If nElement > 0 Then
        ReDim Preserve sArray(0 To nElement)
      End If

      If iFound > 0 Then
        sFieldData = Trim$(Mid$(sText, SaveStart, iFound - SaveStart))
      Else
        sFieldData = Trim$(Mid$(sText, SaveStart, Len(sText) + 1 - SaveStart))
      End If
      If Left$(sFieldData, 1) = cQuote Then
        sFieldLen = Len(sFieldData)
        If sFieldLen > 1 Then
          sFieldData = Mid$(sFieldData, 2, sFieldLen - 2)
        Else
          GoTo NextDelim
        End If
      End If
      iFoundQuote = InStr(1, sFieldData, cQuote)
      If iFoundQuote Then
        sFieldData = Replace(sFieldData, cQuote, "")
      End If
      sArray(nElement) = sFieldData
      SaveStart = iFound + Len(sDelim)

NextDelim:
      iStart = iFound + Len(sDelim)
   Loop While iFound
   Return sArray
End Function
End Module






