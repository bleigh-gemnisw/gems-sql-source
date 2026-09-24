Imports System.Runtime.CompilerServices

Module Common2
  'MK 7/31/25 Change from 25 to 100
  Public SelListNo(100) As Integer
  Public SelYear(100) As Integer
  Public SelType(100) As String
  Public SelProcessed(100) As Boolean
  'MK 7/31/25 End
  Public Sub CalcInterest(ByVal WrkListno As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkDate As Date,
  ByRef OutPrin As Decimal, ByRef OutInterest As Decimal, ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutDue As Decimal,
  Optional ByRef OutCAFee As Decimal = 0, Optional ByRef OutIntPaid As Decimal = 0, Optional ByRef OutFeePaid As Decimal = 0, Optional ByRef OutDebug As String = "")

    Dim MyCashInt As CASHINT.MyData
    MyCashInt = New CASHINT.MyData(myDBConnect)
    With MyCashInt
      .In_IntDate = WrkDate
      .In_ListNo = WrkListno
      .In_Type = WrkType
      .In_Year = WrkYear
      .CalcInterest()
      OutPrin = .Out_Prin()
      OutInterest = .Out_Int()
      OutFee = .Out_Fee()
      OutLien = .Out_Lien()
      OutBond = .Out_Bond()
      OutDue = .Out_Tot()
      OutCAFee = .Out_CAFee()
      OutIntPaid = .Out_IntPaid()
      OutFeePaid = .Out_FeePaid()
      OutDebug = .Out_Debug
    End With
    MyCashInt.CloseFiles()
    MyCashInt = Nothing
  End Sub
  Public Sub CalcInterest_219SW(ByVal WrkListno As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkDate As Date,
  ByRef OutPrin As Decimal, ByRef OutInterest As Decimal, ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutDue As Decimal,
  Optional ByRef OutCAFee As Decimal = 0, Optional ByRef OutIntPaid As Decimal = 0, Optional ByRef OutFeePaid As Decimal = 0, Optional ByRef OutDebug As String = "")

    Dim ds As DataSet = New DataSet
    Dim MyCashInt As CASHINT.MyData
    Dim MyTXBATCHL1 As TXBATCHL1.MyData
    Dim WrkType2 As String
    Dim WrkInterest As Decimal
    Dim WrkOrigInterest As Decimal
    Dim WrkIntPaidInstall As Decimal
    Dim WrkIntPaidInstall2 As Decimal
    Dim WrkBchIntPaid2 As Decimal
    Dim WrkDiff As Decimal
    'MK 7/16/25 Begin
    Dim WrkNoType2 As Boolean
    'MK 7/16/25 End
    Dim I As Integer

    If WrkType = "S" Then
      WrkType2 = "W"
    Else
      WrkType2 = "S"
    End If
    'MK 7/16/25 Begin
    WrkNoType2 = False
    'MK 7/16/25 End
    WrkIntPaidInstall2 = False

    MyCashInt = New CASHINT.MyData(myDBConnect)
    MyTXBATCHL1 = New TXBATCHL1.MyData(myDBConnect)
    With MyCashInt
      .In_IntDate = WrkDate
      .In_ListNo = WrkListno
      .In_Type = WrkType
      .In_Year = WrkYear
      .CalcInterest()
      OutPrin = .Out_Prin()
      WrkInterest = .Out_Int()
      WrkOrigInterest = .Out_IntOrig()
      OutLien = .Out_Lien()
      OutFee = .Out_Fee
      OutBond = .Out_Bond()
      OutCAFee = .Out_CAFee()
      OutDebug = .Out_Debug
      WrkIntPaidInstall = .Out_IntPaidInstall()
      OutFeePaid = .Out_FeePaid()
    End With

    If WrkOrigInterest > 0 And WrkInterest <> WrkOrigInterest Then
      MyCashInt = New CASHINT.MyData(myDBConnect)
      With MyCashInt
        .In_IntDate = WrkDate
        .In_ListNo = WrkListno
        .In_Type = WrkType2
        .In_Year = WrkYear
        .CalcInterest()
        WrkIntPaidInstall2 = .Out_IntPaidInstall
        'Only split min interest if interest paid is under min interest
        If WrkIntPaidInstall + WrkIntPaidInstall2 = 0 Then
          If .Out_IntOrig > 0 And .Out_ProfMinInt > WrkOrigInterest + .Out_IntOrig Then
            WrkDiff = .Out_ProfMinInt * (WrkOrigInterest / (WrkOrigInterest + .Out_IntOrig))
            WrkOrigInterest = WrkDiff
          End If
        End If
        'Check for Interest Paid in History
        If .Out_IntPaidInstall > 0 And .Out_ProfMinInt > WrkOrigInterest + .Out_IntPaidInstall Then
          WrkDiff = .Out_ProfMinInt * (WrkOrigInterest / (WrkOrigInterest + .Out_IntPaidInstall))
          WrkOrigInterest = WrkDiff
        End If
        'Check for Interest Paid in a batch
        WrkBchIntPaid2 = 0
        If .Out_Int = 0 Then
          ds = MyTXBATCHL1.GetViewbyList(WrkListno, WrkYear, WrkType2, 0)
          For I = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(I).Item("jstat") <> "V" And ds.Tables(0).Rows(I).Item("iamt") > 0 Then
              WrkBchIntPaid2 = ds.Tables(0).Rows(I).Item("iamt")
            End If
          Next
          If WrkBchIntPaid2 > 0 And .Out_ProfMinInt > WrkOrigInterest + WrkBchIntPaid2 Then
            WrkDiff = .Out_ProfMinInt - WrkBchIntPaid2
            WrkOrigInterest = WrkDiff
          End If
        End If

        'MK 7/16/25 Begin
        'MK 7/23/25 Begin
        'If .Out_Tot = 0 Then
        If (.Out_Adj1 + .Out_Adj2 + .Out_Adj3 + .Out_Adj4) = 0 Then
          'MK 7/23/25 End
          WrkNoType2 = True
        End If
        'MK 7/16/25 End
      End With
    End If
    OutInterest = WrkOrigInterest
    OutIntPaid = WrkIntPaidInstall
    'MK 7/16/25 Begin
    If WrkNoType2 Then
      OutInterest = WrkInterest
    End If
    'MK 7/16/25 End
    OutDue = OutPrin + OutInterest + OutLien + OutFee
    MyCashInt.CloseFiles()
    MyCashInt = Nothing
  End Sub
End Module







