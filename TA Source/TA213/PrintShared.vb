Module PrintShared
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Integer
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
Friend Sub BuildDS(ByRef dsTot As DataSet)
  Dim myTableTot As New DataTable

  With myTableTot
    .TableName = "mytabletot"
    .Columns.Add("totletter", Type.GetType("System.String"))
    .Columns.Add("totcount", Type.GetType("System.Int64"))
    .Columns.Add("totgross", Type.GetType("System.Int64"))
    .Columns.Add("totprorate", Type.GetType("System.Int64"))
    .Columns.Add("totcreditgross", Type.GetType("System.Int64"))
    .Columns.Add("totcredit", Type.GetType("System.Int64"))
    .Columns.Add("totexam", Type.GetType("System.Int64"))
    .Columns.Add("totnet", Type.GetType("System.Int64"))
  End With
  dsTot.Tables.Add(myTableTot)

End Sub
Friend Sub BufferExem()
     Dim I As Integer

		 Dim myTXEXEM As TXEXEM.MyData
		 Dim dsTXEXEM As DataSet = New DataSet

		 Array.Clear(WrkExCode, 0, 200)
		 Array.Clear(WrkExDesc, 0, 200)
		 Array.Clear(WrkExFixedAmt, 0, 200)
		 Array.Clear(WrkExPerc, 0, 200)
		 Array.Clear(WrkExLetter, 0, 200)

		 myTXEXEM = New TXEXEM.mydata(MyDBConnect)

     dsTXEXEM = myTXEXEM.GetAllData
     For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExCode(I) = .Item("texem")
        WrkExDesc(I) = .Item("tdesc")
        WrkExFixedAmt(I) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(I) = 1
        Else
          WrkExPerc(I) = .Item("tperc")
        End If
        WrkExLetter(I) = .Item("txscd")
      End With
    Next

End Sub
Friend Function LookupExem(ByVal Exem As String) As Integer
     Dim I As Integer

     For I = 0 To WrkExCode.GetUpperBound(0)
      If Trim(WrkExCode(I)) = "" Then
        Return 0
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

End Function

End Module






