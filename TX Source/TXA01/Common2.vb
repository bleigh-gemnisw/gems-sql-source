Module Common2
Public myCASHINT As CASHINT.MyData
Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String, _
  ByVal InYear As Integer, ByVal InDate As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal, _
  ByRef OutFee As Decimal, ByRef OutCAFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, _
  ByRef OutTax As Decimal, ByRef OutDue As Decimal)
  If myCASHINT Is Nothing Then
    myCASHINT = New CASHINT.mydata(MyDBConnect)
  End If
  With myCASHINT
   .In_IntDate = MyUtils.GetDBDate(InDate)
   .In_ListNo = InListNo
   .In_Type = InType
   .In_Year = InYear
   .CalcInterest()
   OutInterest = Format(.Out_Int(), "standard")
   OutInterestPaid = Format(.Out_IntPaid(), "standard")
   OutLien = Format(.Out_Lien(), "standard")
   OutFee = Format(.Out_Fee(), "standard")
   OutCAFee = Format(.Out_CAFee(), "standard")
   OutBond = Format(.Out_Bond(), "standard")
   OutTax = Format(.Out_Prin(), "standard")
   OutDue = Format(.Out_Tot(), "standard")
  End With
End Sub

End Module






