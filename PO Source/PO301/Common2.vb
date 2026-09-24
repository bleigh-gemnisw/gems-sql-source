Module Common2
Dim myLEDGERL1 As LEDGERL1.MyData
Dim myPOMBCDL1 As POMBCDL1.MyData
Public Function GetAcctBal(ByVal GlTyp As String, ByVal Fund As Integer, ByVal Sfund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, _
 ByVal Sfunc As Integer, ByVal DateFrom As Integer, ByVal DateTo As Integer) As Decimal
Dim ds2 As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim Tramt As Decimal
Dim Budget As Decimal
Dim Encumbered As Decimal
Dim LiqEnc As Decimal
Dim UnLiqEnc As Decimal
Dim Expenses As Decimal
Dim Unencumbered As Decimal
Dim Amount As Decimal

myLEDGERL1 = New LEDGERL1.MyData()
myLEDGERL1.MyDBConn = myDBConnect
myPOMBCDL1 = New POMBCDL1.MyData()
myPOMBCDL1.MyDBConn = myDBConnect

Amount = 0
ds2 = myLEDGERL1.GetAllAcct(Fund, Sfund, Dept, Obj, Func, Sfunc, DateFrom, DateTo)
For I = 0 To ds2.Tables(0).Rows.Count - 1
  With ds2.Tables(0).Rows(I)
    If .Item("amtyp") = "D" Then
      Tramt = .Item("tramt")
    Else
      Tramt = .Item("tramt") * -1
    End If
    Select Case .Item("trtyp")
    Case "B"
      Budget = Budget + Tramt
    Case "E"
      If .Item("amtyp") = "D" Then
        Encumbered = Encumbered + .Item("tramt")
      Else
        LiqEnc = LiqEnc + .Item("tramt")
      End If
    Case "X"
      Expenses = Expenses + Tramt
    End Select
   End With
Next

'Add up records in batch
ds3 = myPOMBCDL1.GetViewbyAcct(Fund, Sfund, Dept, Obj, Func, Sfunc)
For I = 0 To ds3.Tables(0).Rows.Count - 1
  With ds3.Tables(0).Rows(I)
    Amount = Amount + .Item("exval")
  End With
Next

Select Case GlTyp
Case "R" 'Revenue
  Unencumbered = Budget - Expenses - Amount
Case Else
  UnliqEnc = Encumbered - LiqEnc
  Unencumbered = Budget - UnliqEnc - Expenses - Amount
End Select

Return Unencumbered
End Function
End Module
