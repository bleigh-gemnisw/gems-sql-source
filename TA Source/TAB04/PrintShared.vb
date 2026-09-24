Module PrintShared
  Public ds As DataSet = New DataSet
  Public dr As Data.DataRow
  'Exemption table
  Public WrkExCode(200) As String
  Public WrkExDesc(200) As String
  Public WrkExFixedAmt(200) As Integer
  Public WrkExPerc(200) As Double
  Public WrkExLetter(200) As String
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("excd", Type.GetType("System.String"))
      .Columns.Add("exam", Type.GetType("System.Int32"))
      .Columns.Add("exdesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Friend Sub BufferExem()
    Dim I As Integer
    Dim J As Integer

    Dim myTXEXEM As TXEXEM.myData
    Dim dsTXEXEM As DataSet = New DataSet

    Array.Clear(WrkExCode, 0, 201)
    Array.Clear(WrkExDesc, 0, 201)
    Array.Clear(WrkExFixedAmt, 0, 201)
    Array.Clear(WrkExPerc, 0, 201)
    Array.Clear(WrkExLetter, 0, 201)

    myTXEXEM = New TXEXEM.mydata(MyDBConnect)
    dsTXEXEM = myTXEXEM.GetAllData
    For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExCode(J) = .Item("texem")
        WrkExDesc(J) = .Item("tdesc")
        WrkExFixedAmt(J) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(J) = 1
        Else
          WrkExPerc(J) = .Item("tperc")
        End If
        WrkExLetter(J) = .Item("txscd")
        J = J + 1
      End With
    Next

  End Sub
  Friend Function LookupExem(ByVal Exem As String) As Integer
    Dim I As Integer

    For I = 0 To WrkExCode.GetUpperBound(0)
      If Trim(WrkExCode(I)) = "" Then
        Return -1
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

  End Function

End Module






