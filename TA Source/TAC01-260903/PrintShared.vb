Module PrintShared
  Public WrkCode(100) As Integer
  Public WrkDesc(100) As String
  Public WrkExemptCode(200) As String
  Public WrkExemptDesc(200) As String
	Public WrkTMCCode(100) As String
	Public WrkTMCCount(100) As Integer
	Public WrkTMCGross(100) As Long

Public Sub BuildDs(ByRef Ds As DataSet)
		Dim myTable As New DataTable

		With myTable
			.TableName = "mytable"
			.Columns.Add("sortdata", Type.GetType("System.String"))
			.Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("cat", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("locno", Type.GetType("System.String"))
      .Columns.Add("loc", Type.GetType("System.String"))
			.Columns.Add("map", Type.GetType("System.String"))
			.Columns.Add("gross", Type.GetType("System.Int32"))
			.Columns.Add("net", Type.GetType("System.Int32"))
			.Columns.Add("exam", Type.GetType("System.Int32"))
      .Columns.Add("ccat", Type.GetType("System.String"))
      .Columns.Add("cname", Type.GetType("System.String"))
      .Columns.Add("csname", Type.GetType("System.String"))
      .Columns.Add("co", Type.GetType("System.String"))
      .Columns.Add("clocno", Type.GetType("System.String"))
      .Columns.Add("cloc", Type.GetType("System.String"))
			.Columns.Add("cadd1", Type.GetType("System.String"))
			.Columns.Add("cadd2", Type.GetType("System.String"))
			.Columns.Add("cmap", Type.GetType("System.String"))
			.Columns.Add("cgross", Type.GetType("System.Int32"))
			.Columns.Add("cnet", Type.GetType("System.Int32"))
			.Columns.Add("cexam", Type.GetType("System.Int32"))
		End With
		Ds.Tables.Add(myTable)

End Sub
Public Sub BuildDs2(ByRef Ds2 As DataSet)
		Dim myTable2 As New DataTable

		With myTable2
			.TableName = "mytable2"
			.Columns.Add("sortdata", Type.GetType("System.String"))
			.Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("ccat", Type.GetType("System.String"))
      .Columns.Add("cname", Type.GetType("System.String"))
      .Columns.Add("csname", Type.GetType("System.String"))
      .Columns.Add("co", Type.GetType("System.String"))
      .Columns.Add("clocno", Type.GetType("System.String"))
      .Columns.Add("cloc", Type.GetType("System.String"))
			.Columns.Add("cadd1", Type.GetType("System.String"))
			.Columns.Add("cadd2", Type.GetType("System.String"))
			.Columns.Add("cmap", Type.GetType("System.String"))
			.Columns.Add("cgross", Type.GetType("System.Int32"))
			.Columns.Add("cnet", Type.GetType("System.Int32"))
			.Columns.Add("cexam", Type.GetType("System.Int32"))
		End With
		ds2.Tables.Add(myTable2)
End Sub
Public Sub BuildDs3(ByRef Ds3 As DataSet)
		Dim myTable3 As New DataTable

		With myTable3
			.TableName = "mytable3"
			.Columns.Add("sortdata", Type.GetType("System.String"))
			.Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("cat", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
			.Columns.Add("locno", Type.GetType("System.String"))
			.Columns.Add("loc", Type.GetType("System.String"))
			.Columns.Add("map", Type.GetType("System.String"))
      .Columns.Add("cgross", Type.GetType("System.Int32"))
      .Columns.Add("gross", Type.GetType("System.Int32"))
			.Columns.Add("net", Type.GetType("System.Int32"))
			.Columns.Add("exam", Type.GetType("System.Int32"))
		End With
		Ds3.Tables.Add(myTable3)
End Sub
	Public Sub BuildDSTotMC(ByRef dsTotMC As DataSet)
		Dim myTableMC As New DataTable

		With myTableMC
			.TableName = "mytablemc"
			.Columns.Add("tmccode", Type.GetType("System.String"))
			.Columns.Add("tmcdesc", Type.GetType("System.String"))
			.Columns.Add("tmccount", Type.GetType("System.Int32"))
			.Columns.Add("tmcgross", Type.GetType("System.Int64"))
		End With
		dsTotMC.Tables.Add(myTableMC)
 End Sub
Public Sub BuildDsErr(ByRef DsErr As DataSet)
		Dim myTableErr As New DataTable

		With myTableErr
			.TableName = "mytableerr"
			.Columns.Add("sortdata", Type.GetType("System.String"))
			.Columns.Add("listno", Type.GetType("System.Int32"))
			.Columns.Add("name", Type.GetType("System.String"))
			.Columns.Add("locno", Type.GetType("System.String"))
			.Columns.Add("loc", Type.GetType("System.String"))
			.Columns.Add("errmsg", Type.GetType("System.String"))
		End With
		DsErr.Tables.Add(myTableErr)
End Sub
Public Sub BufferCodes(ByVal WrkType As String)
		 Dim I As Integer

		 Dim myTXCode As TXCode.myData
		 Dim dsTXCode As DataSet = New DataSet

		 myTXCode = New TXCode.mydata(MyDBConnect)

		 dsTXCode = myTXCode.GetAllType(WrkType)
		 For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
			With dsTXCode.Tables(0).Rows(I)
				WrkCode(I) = .Item("tccode")
				WrkDesc(I) = .Item("tcdesc")
			End With
		Next

End Sub
Public Function LookupOPMCode(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkResult As String

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkCode(I) Then
         WrkResult = WrkDesc(I)
         Return WrkResult
       End If
    Next

    Return ""
End Function
Public Sub BufferExemptCodes()
     Dim I As Integer

		 Dim myTXEXEM As TXEXEM.myData
     Dim dsTXEXEM As DataSet = New DataSet

		 myTXEXEM = New TXEXEM.mydata(MyDBConnect)

     dsTXEXEM = myTXEXEM.GetAllData
     For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExemptCode(I) = .Item("texem")
        WrkExemptDesc(I) = .Item("tdesc")
      End With
    Next

End Sub
Public Function LookupExemptCode(ByVal Code As String) As String
     Dim I As Integer
     Dim WrkResult As String

     For I = 0 To WrkExemptCode.GetUpperBound(0)
      If Trim(WrkExemptCode(I)) = "" Then
        Return ""
      End If
      If Trim(Code) = Trim(WrkExemptCode(I)) Then
        WrkResult = WrkExemptDesc(I)
        Return WrkResult
      End If
    Next

    Return ""
End Function
	Public Function CheckDate(ByVal WrkDate As Date) As Boolean
		Dim Good As Boolean

		Good = False
		'MK 8/18/25 Begin
		'If #1/1/2500# > WrkDate And WrkDate > #1/1/1800# Then
		If #1/1/2500# > WrkDate And WrkDate > #1/1/1600# Then
				'MK 8/18/25 End
				Good = True
			End If

			Return Good
	End Function
	Public Function LookupWrkTMCCode(ByVal Code As Integer) As Integer
		 Dim I As Integer

		 For I = 0 To WrkTMCCode.GetUpperBound(0)
			 If WrkTMCCode(I) = "" Then
				 Return I
			 End If
			 If Code = WrkTMCCode(I) Then
				 Return I
			 End If
		Next

End Function
End Module






