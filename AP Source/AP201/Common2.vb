Module Common2
Dim myLEDGERL1 As LEDGERL1.MyData
Public Function GetAcctBal(ByVal Fund As Integer, ByVal Sfund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, _
 ByVal Sfunc As Integer, DateFrom As Integer, DateTo As Integer) As Decimal
Dim ds2 As DataSet = New DataSet
Dim WrkTramt As Decimal
Dim WrkMult As Integer

myLEDGERL1 = New LEDGERL1.MyData()
myLEDGERL1.MyDBConn = myDBConnect

WrkTramt = 0
'Beginning balance
ds2 = myLEDGERL1.GetAllAcct(Fund, Sfund, Dept, Obj, Func, Sfunc, 0, DateFrom - 1)
For I = 0 To ds2.Tables(0).Rows.Count - 1
  With ds2.Tables(0).Rows(I)
    Select Case .Item("gltyp")
    Case "A", "L", "Q"
      If .Item("amtyp") = "D" Then
        WrkTramt = WrkTramt + .Item("tramt")
      Else
        WrkTramt = WrkTramt - .Item("tramt")
      End If
    Case Else
    End Select
  End With
Next

ds2 = myLEDGERL1.GetAllAcct(Fund, Sfund, Dept, Obj, Func, Sfunc, DateFrom, DateTo)
For I = 0 To ds2.Tables(0).Rows.Count - 1
  With ds2.Tables(0).Rows(I)
    Select Case .Item("gltyp")
    Case "A", "L", "Q"
      If .Item("amtyp") = "D" Then
        WrkTramt = WrkTramt + .Item("tramt")
      Else
        WrkTramt = WrkTramt - .Item("tramt")
      End If
    Case "R"
      WrkMult = 1
      WrkTramt = .Item("tramt") * WrkMult
    Case "X"
      If .Item("amtyp") = "D" Then
        WrkTramt = WrkTramt + .Item("tramt")
      Else
        WrkTramt = WrkTramt - .Item("tramt")
      End If
    End Select
  End With
Next

Return WrkTramt
End Function
Public Sub CalcFyDates(ByVal WrkDate As Date, ByRef WrkFrom As Integer, ByRef WrkTo As Integer)
  If WrkDate.Month >= 7 Then
    WrkFrom = WrkDate.Year & "0701"
    WrkTo = WrkDate.Year + 1 & "0630"
  Else
    WrkFrom = WrkDate.Year - 1 & "0701"
    WrkTo = WrkDate.Year & "0630"
  End If
End Sub
End Module
