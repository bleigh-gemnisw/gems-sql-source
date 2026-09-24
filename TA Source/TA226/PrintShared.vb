Module PrintShared
Public ds As DataSet = New DataSet
Public dr As Data.DataRow
Dim myTXMRATE As TXMRATE.myData
'Mill Rate
Public MrateMillrt As Double
'Exemption table
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Integer
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkDist As Integer)
	myTXMRATE = New TXMRATE.mydata(MyDBConnect)
  myTXMRATE.GetOneRecordP(WrkGLYear, "R", WrkDist)
  If myTXMRATE.RecordNotFound Then
    myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
  End If
  If Not myTXMRATE.RecordNotFound Then
    With myTXMRATE
      MrateMillrt = ._MRRATE
    End With
  End If
	myTXMRATE.CloseFile()
End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int32"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
    .Columns.Add("addr4", Type.GetType("System.String"))
    .Columns.Add("addr5", Type.GetType("System.String"))
    .Columns.Add("excd1", Type.GetType("System.String"))
    .Columns.Add("exam1", Type.GetType("System.Int32"))
    .Columns.Add("revloss1", Type.GetType("System.Decimal"))
    .Columns.Add("excd2", Type.GetType("System.String"))
    .Columns.Add("exam2", Type.GetType("System.Int32"))
    .Columns.Add("revloss2", Type.GetType("System.Decimal"))
    .Columns.Add("excd3", Type.GetType("System.String"))
    .Columns.Add("exam3", Type.GetType("System.Int32"))
    .Columns.Add("revloss3", Type.GetType("System.Decimal"))
    .Columns.Add("excd4", Type.GetType("System.String"))
    .Columns.Add("exam4", Type.GetType("System.Int32"))
    .Columns.Add("revloss4", Type.GetType("System.Decimal"))
    .Columns.Add("excd5", Type.GetType("System.String"))
    .Columns.Add("exam5", Type.GetType("System.Int32"))
    .Columns.Add("revloss5", Type.GetType("System.Decimal"))
    .Columns.Add("excd6", Type.GetType("System.String"))
    .Columns.Add("exam6", Type.GetType("System.Int32"))
    .Columns.Add("revloss6", Type.GetType("System.Decimal"))
    .Columns.Add("excd7", Type.GetType("System.String"))
    .Columns.Add("exam7", Type.GetType("System.Int32"))
    .Columns.Add("revloss7", Type.GetType("System.Decimal"))
    .Columns.Add("texam", Type.GetType("System.Int32"))
    .Columns.Add("trevloss", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Friend Sub BufferExem()
     Dim I As Integer

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
        Return -1
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

End Function

End Module






