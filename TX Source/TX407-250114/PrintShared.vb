Imports System.Text
Module PrintShared
Public myCASHINT As CASHINT.MyData
'Public myCASHDUE As CASHDUE.MyData
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Sel", Type.GetType("System.Boolean"))
      .Columns.Add("Days", Type.GetType("System.Int32"))
      .Columns.Add("Method", Type.GetType("System.String"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("PCust", Type.GetType("System.Int32"))
      .Columns.Add("VehID", Type.GetType("System.Int32"))
      .Columns.Add("DMVName", Type.GetType("System.String"))
      .Columns.Add("DMVAddr", Type.GetType("System.String"))
      .Columns.Add("DMVCity", Type.GetType("System.String"))
      .Columns.Add("DMVSt", Type.GetType("System.String"))
      .Columns.Add("DMVZip", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("DOB", Type.GetType("System.Int32"))
      .Columns.Add("Lease", Type.GetType("System.String"))
      .Columns.Add("Msg", Type.GetType("System.String"))
  End With
  Ds.Tables.Add(myTable)
End Sub
Public Sub BuildDs2(ByRef Ds2 As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("DOB", Type.GetType("System.Int32"))
      .Columns.Add("Msg", Type.GetType("System.String"))
  End With
  Ds2.Tables.Add(myTable)
End Sub
Public Sub BuildDsHold(ByRef DsHold As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("DOB", Type.GetType("System.Int32"))
      .Columns.Add("Msg", Type.GetType("System.String"))
  End With
  DsHold.Tables.Add(myTable)
End Sub
Public Sub InitCASHINT()
  myCASHINT = New CASHINT.mydata(MyDBConnect)
End Sub
'Public Sub InitCASHDUE()
'  myCASHDUE = New CASHDUE.mydata(MyDBConnect)
'End Sub
Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String, _
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal, _
    ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal, _
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean, ByRef OutDays As Integer, _
    ByRef OutMethod As String)
    With myCASHINT
      .In_IntDate = Date.Today
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
      OutDays = DateDiff(DateInterval.Day, .Out_IntDate, Today.Date)
      OutMethod = .Out_Method
    End With
End Sub
Public Sub CalcDue(ByVal InListNo As Integer, ByVal InType As String, _
    ByVal InYear As Integer, ByRef OutDue As Decimal)
    'With myCASHdue
    '  .In_DueDate = Date.Today
    '  .In_ListNo = InListNo
    '  .In_Type = InType
    '  .In_Year = InYear
    '  .CalcDue()
    '  OutDue = Format(.Out_Prin(), "standard")
    'End With
End Sub
End Module






