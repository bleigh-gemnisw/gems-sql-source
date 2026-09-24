Imports System.Text
Module PrintShared
Dim myTXPROF As TXPROF.myData
Dim myTXMRATE As TXMRATE.myData
'Mill Rate
Public MrateMillrt As Double
'Profile
Public ProfPrPerd As Integer
Public ProfWaiver As Double
Public ProfTxDt(3) As Date
Public ProfGrDt(3) As Date
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
			.Columns.Add("Balance", Type.GetType("System.Decimal"))
		End With
    ds.Tables.Add(myTable)
End Sub
Public Sub BuildDSBill(ByRef dsBill As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCDesc", Type.GetType("System.String"))
  End With
  dsBill.Tables.Add(myTable)
End Sub
Public Sub GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String, _
  ByVal WrkDist As Integer)

myTXPROF = New TXPROF.mydata(MyDBConnect)
myTXPROF.GetOneRecordP(WrkType, WrkGLYear, WrkPhase, WrkDist)
If Not myTXPROF.RecordNotFound Then
	With myTXPROF
		ProfPrPerd = ._PRPERD
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
	End
End If
myTXPROF.CloseFile()

End Sub
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
End Sub
Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkGLYear As Integer) As String
  Dim WrkBarCode As String

  WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
  Return WrkBarCode
End Function
End Module






