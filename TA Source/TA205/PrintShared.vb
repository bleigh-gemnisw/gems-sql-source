'Buffered files
Module PrintShared
  Public WrkAssrName As String
  Public WrkAssrPhone As String
  Public WrkCode(100) As Integer
  Public WrkDesc(100) As String
  Public WrkOPM(100) As Integer
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet, ByRef dsExempt As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("NMap", Type.GetType("System.String"))
      .Columns.Add("NAssDesc", Type.GetType("System.String"))
      .Columns.Add("NAssGross", Type.GetType("System.String"))
      .Columns.Add("NGross", Type.GetType("System.Int32"))
			.Columns.Add("NExam", Type.GetType("System.Int32"))
			.Columns.Add("OMap", Type.GetType("System.String"))
      .Columns.Add("OAssDesc", Type.GetType("System.String"))
      .Columns.Add("OAssGross", Type.GetType("System.String"))
      .Columns.Add("OGross", Type.GetType("System.Int32"))
			.Columns.Add("OExam", Type.GetType("System.Int32"))
			.Columns.Add("Location", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
    dsExempt = ds.Clone

  End Sub
Public Sub ClearCodes()
  Array.Clear(WrkCode, 0, 101)
  Array.Clear(WrkDesc, 0, 101)
  Array.Clear(WrkOPM, 0, 101)
End Sub

Public Sub BufferCodes(ByVal WrkType As String, ByVal WrkNewOPM As Boolean)
     Dim I As Integer

		 Dim myTXCODE As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

		 myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkType)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkCode(I) = .Item("tccode")
        WrkDesc(I) = .Item("tcdesc")
        If WrkNewOPM Then
          WrkOPM(I) = .Item("tcopmc")
        Else
          WrkOPM(I) = .Item("tccode")
        End If
      End With
    Next

End Sub
Public Function LookupOPMCode(ByVal Code As Integer) As Integer
     Dim I As Integer
     Dim WrkResult As Integer

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return 0
       End If
       If Code = WrkCode(I) Then
         WrkResult = WrkOPM(I)
         Return WrkResult
       End If
    Next

End Function
Public Function LookupOPMDesc(ByVal Code As Integer) As String
     'Returns Code & Description
     Dim I As Integer

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return Code
       End If
       If Code = WrkCode(I) Then
         Return WrkOPM(I) & " " & WrkDesc(I)
       End If
    Next

    Return Code
End Function
Public Function FmtNumber(ByVal NumIn As Integer) As String
  Dim WrkResult As String

  WrkResult = Trim(Format(NumIn, "###,###,###"))
  Return WrkResult
End Function
Public Sub GetTXCNTL()
	Dim myTXCNTL As TXCNTL.myData

	myTXCNTL = New TXCNTL.mydata(MyDBConnect)
  myTXCNTL.GetOneRecordP("")
	With myTXCNTL
    WrkAssrName = Trim(._ASRNAM)
    WrkAssrPhone = Trim(._ASRPHN)
	End With
End Sub
End Module






