Module ProcessRE
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Public Sub ProcRE()
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREAL.ClearBanks()
  End Sub
  Public Sub ProcREFrozen()
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXREALC.ClearBanks()
  End Sub
End Module






