Imports System.Text
Module PrintShared
Dim myTXPROF As TXPROF.MyData
Dim myTXMRATE As TXMRATE.MyData
Dim DsTXPROF As DataSet = New DataSet
Dim DsTXMRATE As DataSet = New DataSet
'Mill Rate
Public MrateMillrt As Decimal
'Profile
Public ProfPrPerd As Integer
Public ProfWaiver As Double
Public ProfTxDt(3) As Date
Public ProfGrDt(3) As Date
'Exemptions (TXEXEM)
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As String
Public WrkExPerc(200) As String
Public Sub BuildDS(ByRef ds As DataSet)
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("Bank", Type.GetType("System.String"))
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
			.Columns.Add("Taxtot", Type.GetType("System.Decimal"))
			.Columns.Add("BackTax", Type.GetType("System.Boolean"))
	End With
	ds.Tables.Add(myTable)
End Sub
Public Function GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String, _
	ByVal WrkDist As Integer) As Boolean

myTXPROF = New TXPROF.mydata(MyDBConnect)
myTXPROF.GetOneRecordP(WrkType, WrkGLYear, WrkPhase, WrkDist)
If Not myTXPROF.RecordNotFound Then
	With myTXPROF
    ProfTxDt(0) = MyUtils.GetDBDateMDY(._PRDUE1)
    ProfTxDt(1) = MyUtils.GetDBDateMDY(._PRDUE2)
    ProfTxDt(2) = MyUtils.GetDBDateMDY(._PRDUE3)
    ProfTxDt(3) = MyUtils.GetDBDateMDY(._PRDUE4)
    ProfGrDt(0) = MyUtils.GetDBDateMDY(._PRGRD1)
    ProfGrDt(1) = MyUtils.GetDBDateMDY(._PRGRD2)
    ProfGrDt(2) = MyUtils.GetDBDateMDY(._PRGRD3)
    ProfGrDt(3) = MyUtils.GetDBDateMDY(._PRGRD4)
		ProfWaiver = ._PRWAV
	End With
Else
	MsgBox("Add year " & WrkGLYear, MsgBoxStyle.Critical, "Tax Profile missing")
	Return False
End If
myTXPROF.CloseFile()
Return True

End Function
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
Public Sub BufferExem()
		 Dim I As Integer

		 Dim myTXEXEM As TXEXEM.MyData
		 Dim dsTXEXEM As DataSet = New DataSet

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
			End With
		Next

End Sub
Public Function LookupExem(ByVal Exem As String) As Integer
     Dim I As Integer

     For I = 0 To WrkExCode.GetUpperBound(0)
       If WrkExCode(I) = "" Then
         Return 0
       End If
       If Exem = WrkExCode(I) Then
         Return I
       End If
    Next

End Function
End Module






