Imports System.Text
Module PrintShared
Public myTXPROF As TXPROF.myData
Public myTXMRATE As TXMRATE.myData
Public WrkMryear(500) As Integer
Public WrkMrType(500) As String
Public WrkMrdist(500) As Integer
Public WrkMrrate(500) As Decimal
Public WrkMrfire(500) As Decimal
Public Sub InitFiles()
	myTXPROF = New TXPROF.mydata(MyDBConnect)
	myTXMRATE = New TXMRATE.mydata(MyDBConnect)
End Sub
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
			.Columns.Add("Fee", Type.GetType("System.Decimal"))
			.Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
End Sub
Public Sub BuildDSBill(ByRef dsBill As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
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
      .Columns.Add("MillRT", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("MVFee", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("DueDt1", Type.GetType("System.String"))
      .Columns.Add("DueDt2", Type.GetType("System.String"))
      .Columns.Add("PayRec", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("BondPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LastPayDt", Type.GetType("System.DateTime"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
			.Columns.Add("Fee", Type.GetType("System.Decimal"))
			.Columns.Add("UnpaidTax", Type.GetType("System.Decimal"))
      .Columns.Add("UnpaidBond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
  End With
  dsBill.Tables.Add(myTable)
End Sub
Public Sub GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String, _
  ByVal WrkDist As Integer)

  myTXPROF.GetOneRecordP(WrkType, WrkGLYear, WrkPhase, WrkDist)
  If myTXPROF.RecordNotFound Then
    MsgBox("Add year " & WrkGLYear, MsgBoxStyle.Critical, "Tax Profile missing")
    End
  End If

End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
End Sub
Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkGLYear As Integer) As String
  Dim WrkBarCode As String

  WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
  Return WrkBarCode
End Function
Public Sub BufferMillRate()
		 Dim I As Integer
		 Dim dsTXMRATE As DataSet = New DataSet

    dsTXMRATE = myTXMRATE.PosData(0, "", 0)
    For I = 0 To dsTXMRATE.Tables(0).Rows.Count - 1
			With dsTXMRATE.Tables(0).Rows(I)
				WrkMryear(I) = .Item("year")
        WrkMrType(I) = .Item("type")
        WrkMrdist(I) = .Item("dist")
				WrkMrrate(I) = .Item("mrrate")
				WrkMrfire(I) = .Item("mrfire")
			End With
		Next

End Sub
Public Function LookupMillRate(ByVal Year As Integer, ByVal Type As String, ByVal Dist As Integer) As Integer
     Dim I As Integer

     For I = 0 To WrkMryear.GetUpperBound(0)
       If WrkMryear(I) = 0 Then
         Exit For
       End If
       If Year = WrkMryear(I) And Type = WrkMrType(I) And Dist = WrkMrdist(I) Then
         Return I
       End If
     Next

     For I = 0 To WrkMryear.GetUpperBound(0)
       If WrkMryear(I) = 0 Then
         Return -1
       End If
       If Year = WrkMryear(I) And Dist = WrkMrdist(I) Then
         Return I
       End If
    Next
End Function
End Module






