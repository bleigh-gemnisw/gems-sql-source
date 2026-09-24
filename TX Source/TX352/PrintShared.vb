Module PrintShared
Dim myTXPROF As TXPROF.myData
Dim myTXMRATE As TXMRATE.myData
'Mill Rate
Public MrateMillrt As Decimal
'Profile
Public ProfPrPerd As Integer
Public ProfWaiver As Decimal
Public ProfTxDt(3) As Date
Public ProfGrDt(3) As Date
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Integer
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
Friend Sub BufferExem()
     Dim I As Integer

		 Dim myTXEXEM As TXEXEM.MyData
     Dim dsTXEXEM As DataSet = New DataSet

     Array.Clear(WrkExCode, 0, 200)
     Array.Clear(WrkExDesc, 0, 200)
     Array.Clear(WrkExFixedAmt, 0, 200)
     Array.Clear(WrkExPerc, 0, 200)
     Array.Clear(WrkExLetter, 0, 200)

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
        If Trim(.Item("txscd")) = "" Then
          WrkExLetter(I) = "*"
        Else
          WrkExLetter(I) = .Item("txscd")
        End If
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
  Public Sub BuildDSTot(ByRef dsTot As DataSet)
    Dim myTableTot As New DataTable

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("totdesc", Type.GetType("System.String"))
      .Columns.Add("totcount", Type.GetType("System.Int32"))
      .Columns.Add("totamount", Type.GetType("System.Int64"))
    End With
    dsTot.Tables.Add(myTableTot)

 End Sub
  Public Sub BuildDSTotEx(ByRef dsTotEx As DataSet)
    Dim myTableEx As New DataTable

    With myTableEx
      .TableName = "mytableex"
      .Columns.Add("texformat", Type.GetType("System.String"))
      .Columns.Add("texcode", Type.GetType("System.String"))
      .Columns.Add("texdesc", Type.GetType("System.String"))
      .Columns.Add("texcount", Type.GetType("System.Int32"))
      .Columns.Add("tex", Type.GetType("System.Int64"))
      .Columns.Add("texfrzcount", Type.GetType("System.Int32"))
      .Columns.Add("texfrz", Type.GetType("System.Int64"))
      .Columns.Add("texheartcount", Type.GetType("System.Int32"))
      .Columns.Add("texheart", Type.GetType("System.Int64"))
      .Columns.Add("textotcount", Type.GetType("System.Int32"))
      .Columns.Add("textot", Type.GetType("System.Int64"))
    End With
    dsTotEx.Tables.Add(myTableEx)

 End Sub
  Public Sub BuildDSTotMC(ByRef dsTotMC As DataSet)
    Dim myTableMC As New DataTable

    With myTableMC
      .TableName = "mytablemc"
      .Columns.Add("tmcformat", Type.GetType("System.String"))
      .Columns.Add("tmccode", Type.GetType("System.String"))
      .Columns.Add("tmcdesc", Type.GetType("System.String"))
      .Columns.Add("tmccount", Type.GetType("System.Int32"))
      .Columns.Add("tmcgross", Type.GetType("System.Int64"))
      .Columns.Add("tmcexempt", Type.GetType("System.Int64"))
      .Columns.Add("tmcnet", Type.GetType("System.Int64"))
      .Columns.Add("tmcfrzcount", Type.GetType("System.Int32"))
      .Columns.Add("tmcfrzgross", Type.GetType("System.Int64"))
      .Columns.Add("tmcfrzexempt", Type.GetType("System.Int64"))
      .Columns.Add("tmcfrznet", Type.GetType("System.Int64"))
      .Columns.Add("tmcheartcount", Type.GetType("System.Int32"))
      .Columns.Add("tmcheartgross", Type.GetType("System.Int64"))
      .Columns.Add("tmcheartexempt", Type.GetType("System.Int64"))
      .Columns.Add("tmcheartnet", Type.GetType("System.Int64"))
      .Columns.Add("tmctotcount", Type.GetType("System.Int32"))
      .Columns.Add("tmctotgross", Type.GetType("System.Int64"))
      .Columns.Add("tmctotexempt", Type.GetType("System.Int64"))
      .Columns.Add("tmctotnet", Type.GetType("System.Int64"))
    End With
    dsTotMC.Tables.Add(myTableMC)
 End Sub
Public Sub BuildDSErr(ByRef dserr As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int32"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("Errmsg", Type.GetType("System.String"))
    End With
    dserr.Tables.Add(myTable)
End Sub
Public Sub GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String, _
  ByVal WrkDist As Integer)

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

  myTXMRATE.CloseFile()
End Sub

End Module






