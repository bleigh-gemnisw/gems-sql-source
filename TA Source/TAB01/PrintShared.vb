Module PrintShared
  Public ds As DataSet = New DataSet
  Public dsEld As DataSet = New DataSet
  Public dsLtr As DataSet = New DataSet
  'Exemption table
  Public WrkExCode(200) As String
  Public WrkExDesc(200) As String
  Public WrkExFixedAmt(200) As Integer
  Public WrkExPerc(200) As Decimal
  Public WrkExLetter(200) As String
  'Exemption Code totals
  Public WrkTExCode(200) As String
  Public WrkTExRE(200) As Integer
  Public WrkTExMV(200) As Integer
  Public WrkTExPP(200) As Integer
  Public WrkTExam(200) As Integer
  'Exemption Letter totals
  Public WrkLtrEx(200) As String
  Public WrkLtrDesc(200) As String
  Public WrkLtrExRE(200) As Integer
  Public WrkLtrExMV(200) As Integer
  Public WrkLtrExPP(200) As Integer
  'Summary Report Totals
  Public WrkTotalRE As Long
  Public WrkTotalMV As Long
  Public WrkTotalPP As Long
  Public WrkTotalREGross As Long
  Public WrkTotalMVGross As Long
  Public WrkTotalPPGross As Long
  Public WrkTotalRENet As Long
  Public WrkTotalMVNet As Long
  Public WrkTotalPPNet As Long
  Public WrkTotalREEx As Long
  Public WrkTotalMVEx As Long
  Public WrkTotalPPEx As Long
  Public WrkREExempt As Long
  Public WrkPPExempt As Long
  Public WrkMVExempt As Long
  Friend Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableEld As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("group", Type.GetType("System.String"))
      .Columns.Add("ltr", Type.GetType("System.String"))
      .Columns.Add("code", Type.GetType("System.String"))
      .Columns.Add("desc", Type.GetType("System.String"))
      .Columns.Add("re", Type.GetType("System.Int64"))
      .Columns.Add("mv", Type.GetType("System.Int64"))
      .Columns.Add("pp", Type.GetType("System.Int64"))
      .Columns.Add("tot", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)

    With myTableEld
      .TableName = "mytableeld"
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("code", Type.GetType("System.String"))
      .Columns.Add("count", Type.GetType("System.Int32"))
      .Columns.Add("gross", Type.GetType("System.Int64"))
      .Columns.Add("netass", Type.GetType("System.Int64"))
      .Columns.Add("tax", Type.GetType("System.Decimal"))
      .Columns.Add("statecredit", Type.GetType("System.Decimal"))
      .Columns.Add("localcredit", Type.GetType("System.Decimal"))
      .Columns.Add("adjtax", Type.GetType("System.Decimal"))
    End With
    dsEld.Tables.Add(myTableEld)
    dsLtr = ds.Clone
  End Sub
  Friend Sub BufferExem()
    Dim I As Integer

    Dim myTXEXEM As TXEXEM.MyData
    Dim dsTXEXEM As DataSet = New DataSet

    Array.Clear(WrkExCode, 0, 201)
    Array.Clear(WrkExDesc, 0, 201)
    Array.Clear(WrkExFixedAmt, 0, 201)
    Array.Clear(WrkExPerc, 0, 201)
    Array.Clear(WrkExLetter, 0, 201)

    myTXEXEM = New TXEXEM.MyData(myDBConnect)

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
        Return 0
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

  End Function
  Public Sub ClearSharedTotals()
    WrkTotalRE = 0
    WrkTotalMV = 0
    WrkTotalPP = 0
    WrkTotalREGross = 0
    WrkTotalMVGross = 0
    WrkTotalPPGross = 0
    WrkTotalRENet = 0
    WrkTotalMVNet = 0
    WrkTotalPPNet = 0
    WrkTotalREEx = 0
    WrkTotalMVEx = 0
    WrkTotalPPEx = 0
    WrkREExempt = 0
    WrkPPExempt = 0
    WrkMVExempt = 0
    ReDim WrkTExCode(100)
    ReDim WrkTExam(100)
    ReDim WrkTExRE(100)
    ReDim WrkTExMV(100)
    ReDim WrkTExPP(100)
  End Sub
  Public Function LookupWrkTExCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkTExCode.GetUpperBound(0)
      If Trim(WrkTExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkTExCode(I)) Then
        Return I
      End If
    Next
  End Function
  Public Function LookupWrkLtrEx(ByVal Letter As String) As Integer
    Dim I As Integer

    For I = 0 To WrkLtrEx.GetUpperBound(0)
      If Trim(WrkLtrEx(I)) = "" Then
        Return I
      End If
      If Trim(Letter) = Trim(WrkLtrEx(I)) Then
        Return I
      End If
    Next
  End Function
End Module






