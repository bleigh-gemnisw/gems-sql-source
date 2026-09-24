Imports System.Text
Module PrintShared
  Dim myTXPROF As TXPROF.MyData
  Dim myTXMRATE As TXMRATE.MyData
  'Mill Rate
  Public MrateMillrt As Decimal
  'Profile
  Public ProfPrPerd As Integer
  Public ProfWaiver As Decimal
  Public ProfTxDt(3) As Date
  Public ProfGrDt(3) As Date
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Letter", Type.GetType("System.String"))
      .Columns.Add("Frcd", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("RefListNo", Type.GetType("System.Int32"))
      .Columns.Add("OldOwner", Type.GetType("System.String"))
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("FrcdDesc", Type.GetType("System.String"))
      .Columns.Add("Fryr", Type.GetType("System.Int32"))
      .Columns.Add("STBenefit", Type.GetType("System.Decimal"))
      .Columns.Add("FrzLoss", Type.GetType("System.Decimal"))
      .Columns.Add("TownBenefit", Type.GetType("System.Decimal"))
      .Columns.Add("ProrateDesc", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.String"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCETax", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx1", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx2", Type.GetType("System.Decimal"))
      .Columns.Add("CCGross", Type.GetType("System.Decimal"))
      .Columns.Add("CCExemption", Type.GetType("System.Decimal"))
      .Columns.Add("CCNet", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Prorate", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("BTR", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDSTot(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("tgross", Type.GetType("System.Int64"))
      .Columns.Add("texempt", Type.GetType("System.Int64"))
      .Columns.Add("tprorate", Type.GetType("System.Int64"))
      .Columns.Add("tcredit", Type.GetType("System.Int32"))
      .Columns.Add("tnet", Type.GetType("System.Int64"))
      .Columns.Add("tfull", Type.GetType("System.Int64"))
      .Columns.Add("tpartial", Type.GetType("System.Int64"))
      .Columns.Add("tfullcredit", Type.GetType("System.Int64"))
      .Columns.Add("tproratecredit", Type.GetType("System.Int64"))
      .Columns.Add("tbtr", Type.GetType("System.Int64"))
      .Columns.Add("tnetnonelderly", Type.GetType("System.Int64"))
      .Columns.Add("tnetfrozen", Type.GetType("System.Int32"))
      .Columns.Add("tnetheart", Type.GetType("System.Int32"))
      .Columns.Add("ttax", Type.GetType("System.Decimal"))
      .Columns.Add("ttax1", Type.GetType("System.Decimal"))
      .Columns.Add("ttax2", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxmill", Type.GetType("System.Decimal"))
      .Columns.Add("tvariance", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxnonelderly", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxfrozen", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxheart", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxstbenefit", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxtownbenefit", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxfrzloss", Type.GetType("System.Decimal"))
      .Columns.Add("ttax10mlloss", Type.GetType("System.Decimal"))
      .Columns.Add("twaiveredaccts", Type.GetType("System.Int32"))
      .Columns.Add("twaivered", Type.GetType("System.Decimal"))
      .Columns.Add("trounding", Type.GetType("System.Decimal"))
      .Columns.Add("ttaxvariance", Type.GetType("System.Decimal"))
      .Columns.Add("taccts", Type.GetType("System.Int32"))
      .Columns.Add("tbills", Type.GetType("System.Int32"))
      .Columns.Add("bccgross", Type.GetType("System.Int64"))
      .Columns.Add("bccexempt", Type.GetType("System.Int64"))
      .Columns.Add("bccnet", Type.GetType("System.Int64"))
      .Columns.Add("bcctax", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax1", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax2", Type.GetType("System.Decimal"))
      .Columns.Add("ccgross", Type.GetType("System.Int64"))
      .Columns.Add("ccexempt", Type.GetType("System.Int64"))
      .Columns.Add("ccnet", Type.GetType("System.Int64"))
      .Columns.Add("cccredit", Type.GetType("System.Int64"))
      .Columns.Add("cctax", Type.GetType("System.Decimal"))
      .Columns.Add("cctax1", Type.GetType("System.Decimal"))
      .Columns.Add("cctax2", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDSTotEx(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable3"
      .Columns.Add("tcode", Type.GetType("System.String"))
      .Columns.Add("tdesc", Type.GetType("System.String"))
      .Columns.Add("tcount", Type.GetType("System.Int32"))
      .Columns.Add("texempt", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub GetTaxProfile(ByVal WrkType As String, ByVal WrkGLYear As Integer, ByVal WrkPhase As String,
  ByVal WrkDist As Integer)

    myTXPROF = New TXPROF.MyData(myDBConnect)
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

    myTXMRATE = New TXMRATE.MyData(myDBConnect)
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






