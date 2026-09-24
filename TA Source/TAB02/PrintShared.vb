Module PrintShared
Public ds As DataSet = New DataSet
Public dr As Data.DataRow
Dim myTXMRATE As TXMRATE.MyData
'Mill Rate
Public MrateMillrt As Double
'Exemption table
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Integer
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
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
		.Columns.Add("type", Type.GetType("System.String"))
		.Columns.Add("addr1", Type.GetType("System.String"))
		.Columns.Add("addr2", Type.GetType("System.String"))
		.Columns.Add("addr3", Type.GetType("System.String"))
		.Columns.Add("addr4", Type.GetType("System.String"))
		.Columns.Add("addr5", Type.GetType("System.String"))
		.Columns.Add("excd", Type.GetType("System.String"))
		.Columns.Add("exam", Type.GetType("System.Int32"))
		.Columns.Add("exdesc", Type.GetType("System.String"))
		.Columns.Add("revloss", Type.GetType("System.Decimal"))
	End With
	ds.Tables.Add(myTable)
End Sub
Friend Sub BufferExem(ByVal WrkLocal As Boolean)
		 Dim WrkOPM As String
		 Dim I As Integer
		 Dim J As Integer

		 Dim myTXEXEM As TXEXEM.myData
		 Dim dsTXEXEM As DataSet = New DataSet

		 Array.Clear(WrkExCode, 0, 201)
		 Array.Clear(WrkExDesc, 0, 201)
		 Array.Clear(WrkExFixedAmt, 0, 201)
		 Array.Clear(WrkExPerc, 0, 201)
		 Array.Clear(WrkExLetter, 0, 201)

     WrkOPM = MyFrmTAB02B.TxtOPM.Text
		 myTXEXEM = New TXEXEM.mydata(MyDBConnect)

		 dsTXEXEM = myTXEXEM.GetAllData
		 For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
			With dsTXEXEM.Tables(0).Rows(I)
				If Not WrkLocal And .Item("txscd") = String.Empty Then Continue For
				If WrkOPM <> String.Empty Then
					If WrkOPM <> .Item("txscd") Then
						Continue For
					End If
				End If
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






