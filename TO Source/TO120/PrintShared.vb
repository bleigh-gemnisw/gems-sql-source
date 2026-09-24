Imports System.Text
Module PrintShared
  Public dsTotEx As DataSet = New DataSet
  Public ds2 As DataSet = New DataSet
  Public ds3 As DataSet = New DataSet
  'Exemption table
  Public WrkExCode(200) As String
  Public WrkExDesc(200) As String
  Public WrkExFixedAmt(200) As Integer
  Public WrkExPerc(200) As Double
  Public WrkExLetter(200) As String
  'Exemption totals
  Public WrkTExCode(100) As String
  Public WrkTExRECount(100) As Integer
  Public WrkTExREAccts(100) As Integer
  Public WrkTExRE(100) As Integer
  Public WrkTExMVCount(100) As Integer
  Public WrkTExMVAccts(100) As Integer
  Public WrkTExMV(100) As Integer
  Public WrkTExPPCount(100) As Integer
  Public WrkTExPPAccts(100) As Integer
  Public WrkTExPP(100) As Integer
  Public WrkTExCount(100) As Integer
  Public WrkTExAccts(100) As Integer
  Public WrkTExam(100) As Integer

  Friend Sub BuildDS()
    Dim myTableTotEx As New DataTable

    With myTableTotEx
      .TableName = "mytableex"
      .Columns.Add("texcode", Type.GetType("System.String"))
      .Columns.Add("texdesc", Type.GetType("System.String"))
      .Columns.Add("texrecount", Type.GetType("System.Int32"))
      .Columns.Add("texre", Type.GetType("System.Int64"))
      .Columns.Add("texmvcount", Type.GetType("System.Int32"))
      .Columns.Add("texmv", Type.GetType("System.Int64"))
      .Columns.Add("texppcount", Type.GetType("System.Int32"))
      .Columns.Add("texpp", Type.GetType("System.Int64"))
      .Columns.Add("textotcount", Type.GetType("System.Int32"))
      .Columns.Add("textot", Type.GetType("System.Int64"))
    End With
    dsTotEx.Tables.Add(myTableTotEx)

  End Sub
  Friend Sub BuildDS2()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("code", Type.GetType("System.String"))
      .Columns.Add("exam", Type.GetType("System.Int32"))
      .Columns.Add("group", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)
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
        WrkExLetter(I) = .Item("txscd")
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
    ReDim WrkTExCode(100)
    ReDim WrkTExCount(100)
    ReDim WrkTExAccts(100)
    ReDim WrkTExam(100)
    ReDim WrkTExRECount(100)
    ReDim WrkTExREAccts(100)
    ReDim WrkTExRE(100)
    ReDim WrkTExMVCount(100)
    ReDim WrkTExMVAccts(100)
    ReDim WrkTExMV(100)
    ReDim WrkTExPPCount(100)
    ReDim WrkTExPPAccts(100)
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
  Public Sub WriteDVAHeader()

    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append(QuoDbl("First"))
    sb.Append(",")
    sb.Append(QuoDbl("Middle"))
    sb.Append(",")
    sb.Append(QuoDbl("Last"))
    sb.Append(",")
    sb.Append(QuoDbl("Suffix"))
    sb.Append(",")
    sb.Append(QuoDbl("Street"))
    sb.Append(",")
    sb.Append(QuoDbl("City"))
    sb.Append(",")
    sb.Append(QuoDbl("Zip"))
    sb.Append(",")
    sb.Append(QuoDbl("State"))
    sb.Append(",")
    sb.Append(QuoDbl("Code"))
    sb.Append(",")
    sb.Append(QuoDbl("Amount"))
    sw.WriteLine(sb.ToString)
  End Sub
  Public Sub WriteDVAFile(ByVal Name As String, ByVal Sname As String, ByVal Add1 As String,
  ByVal City As String, ByVal State As String, ByVal Zip As Integer, ByVal Code As String,
  ByVal Amount As Integer)

    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append(QuoDbl(Name))
    sb.Append(",")
    '  If Sname <> "" Then
    '    sb.Append(QuoDbl(Sname))
    '  End If
    sb.Append(",,,")
    sb.Append(QuoDbl(Add1))
    sb.Append(",")
    sb.Append(QuoDbl(City))
    sb.Append(",")
    sb.Append(QuoDbl(State))
    sb.Append(",")
    sb.Append(QuoDbl(Format(Zip, "00000")))
    sb.Append(",")
    sb.Append(QuoDbl(Code))
    sb.Append(",")
    sb.Append(Amount)
    sw.WriteLine(sb.ToString)
  End Sub
  Public Function QuoDbl(ByVal WrkString As String) As String
    'Put double quotes around strings for CSV file format
    Const CDblQuote As Char = Chr(34)
    QuoDbl = CDblQuote & WrkString & CDblQuote
  End Function
  Public Function FilterCodes(ByVal Code As String) As Boolean
    ' changed codes that are exempt... now  AIA   bid apa    6/24/25  per kim
    ' note this quick fix need to have better way in doing this.
    'If Code >= "AIA" And Code <= "AOA" Then
    'If Code = "APA" Or Code = "AIA" Or Code = "BID" Or Code = "CIB" Or Code = "BIE" _
    '  Or Code = "CJB" Or Code = "CFB" Or Code = "AJA" Or Code = "BLD" Then
    'Return True
    ' End If
    If {"APA", "AIA", "BID", "CIB", "BIE", "CJB", "CFB", "AJA", "BLD", "BJE"}.Contains(Code) Then
      Return True
    End If
    If Code > "AIA" And Code <= "AOA" Then
      Return False
    End If

    'If Code >= "BID" And Code <= "BND" Then
    If Code >= "BID" And Code <= "BND" Then
        Return False
      End If

      If Code >= "CIB" And Code <= "CNB" Then
      Return False
    End If

    Return True
  End Function
End Module






