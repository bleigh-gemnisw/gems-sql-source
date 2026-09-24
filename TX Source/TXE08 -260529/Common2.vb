Module Common2
Public WrkTXCode(50) As String
Public WrkTXDesc(50) As String
Public WrkTXFamily(50) As String

Friend Sub BufferType()
     Dim I As Integer

     Dim myTXTYPE As TXTYPE.myData
     Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)
    dsTXType = myTXTYPE.PosData("")
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkTXCode(I) = .Item("tycode")
        WrkTXDesc(I) = .Item("tydesc")
        WrkTXFamily(I) = .Item("txfam")
      End With
    Next

End Sub
Friend Function LookupType(ByVal Type As String) As String()
     Dim I As Integer
     Dim WrkResult(1) As String

     WrkResult(0) = ""
     WrkResult(1) = ""

     For I = 0 To WrkTXCode.GetUpperBound(0)
       If WrkTXCode(I) = "" Then
         Return WrkResult
       End If
       If Type = WrkTXCode(I) Then
         WrkResult(0) = WrkTXDesc(I)
         WrkResult(1) = WrkTXFamily(I)
         Return WrkResult
       End If
    Next

    Return WrkResult
End Function
End Module
