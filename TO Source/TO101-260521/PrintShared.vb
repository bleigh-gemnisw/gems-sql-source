Imports System.Text
Module PrintShared
Public dsTotMC As DataSet = New DataSet
Public dsTotEx As DataSet = New DataSet
Public dsTot As DataSet = New DataSet
'Exemption table
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Long
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
'Exemption totals
Public WrkTExCode(200) As String
Public WrkTExRECount(200) As Integer
Public WrkTExRE(200) As Long
Public WrkTExMVCount(200) As Integer
Public WrkTExMV(200) As Long
Public WrkTExPPCount(200) As Integer
Public WrkTExPP(200) As Long
Public WrkTExCount(200) As Integer
Public WrkTExam(200) As Long
'Summary Report Totals
Public WrkTotalRE As Long
Public WrkTotalMV As Long
Public WrkTotalPP As Long
Public WrkTotExPhaseIn As Long
Public WrkTotExRE As Long
Public WrkTotExMV As Long
Public WrkTotExPP As Long
'Summary Report - OPM Info
Public WrkAddress As String
Public WrkTownZip As String
Public WrkPhone As String
Public WrkFax As String
Public WrkEmail As String
Public WrkAssrName As String
Public WrkCertYes As String
Public WrkCertNo As String
Public WrkCert As String

Friend Sub BuildDS()
  Dim myTableTotMC As New DataTable
  Dim myTableTotEx As New DataTable
  Dim myTableTot As New DataTable

  With myTableTotMC
    .TableName = "mytabletmc"
    .Columns.Add("tmcgroup", Type.GetType("System.String"))
    .Columns.Add("tmccode", Type.GetType("System.String"))
    .Columns.Add("tmcdesc", Type.GetType("System.String"))
    .Columns.Add("tmccount", Type.GetType("System.Int32"))
    .Columns.Add("tmcgross", Type.GetType("System.Int64"))
  End With
  dsTotMC.Tables.Add(myTableTotMC)

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

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("totre", Type.GetType("System.Int64"))
      .Columns.Add("totmv", Type.GetType("System.Int64"))
      .Columns.Add("totpp", Type.GetType("System.Int64"))
      .Columns.Add("tot", Type.GetType("System.Int64"))
			.Columns.Add("totexphasein", Type.GetType("System.Int64"))
			.Columns.Add("totexre", Type.GetType("System.Int64"))
      .Columns.Add("totexmv", Type.GetType("System.Int64"))
      .Columns.Add("totexpp", Type.GetType("System.Int64"))
      .Columns.Add("totex", Type.GetType("System.Int64"))
      .Columns.Add("totgrand", Type.GetType("System.Int64"))
    End With
    dsTot.Tables.Add(myTableTot)
End Sub
Friend Sub BufferExem(ByVal WrkLocal As Boolean)
     Dim I As Integer
     Dim J As Integer

     Dim myTXEXEM As TXEXEM.myData
     Dim dsTXEXEM As DataSet = New DataSet

     Array.Clear(WrkExCode, 0, 201)
     Array.Clear(WrkExDesc, 0, 201)
     Array.Clear(WrkExFixedAmt, 0, 201)
     Array.Clear(WrkExPerc, 0, 201)
     Array.Clear(WrkExLetter, 0, 201)

     myTXEXEM = New TXEXEM.mydata(MyDBConnect)

     dsTXEXEM = myTXEXEM.GetAllData
     For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        If Not WrkLocal And Trim(.Item("txscd")) = String.Empty Then Continue For
        WrkExCode(J) = .Item("texem")
        WrkExDesc(J) = .Item("tdesc")
        WrkExFixedAmt(J) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(J) = 1
        Else
          WrkExPerc(J) = .Item("tperc")
        End If
        If WrkLocal And Trim(.Item("txscd")) = "" Then
          WrkExLetter(J) = Left(WrkExCode(J), 1)
        Else
          WrkExLetter(J) = .Item("txscd")
        End If
        J = J + 1
      End With
    Next

End Sub
  Friend Function LookupExem(ByVal Exem As String) As Integer
    Dim I As Integer
    Dim WrkIndex As Integer

    WrkIndex = -1
    For I = 0 To WrkExCode.GetUpperBound(0)
      If IsNothing(WrkExCode(I)) Then
        Exit For
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        WrkIndex = I
        Exit For
      End If
    Next
    Return WrkIndex
  End Function
  Public Sub ClearSharedTotals()
	WrkTotalRE = 0
	WrkTotalMV = 0
  WrkTotalPP = 0
	WrkTotExPhaseIn = 0
	WrkTotExRE = 0
  WrkTotExMV = 0
  WrkTotExPP = 0
  ReDim WrkTExCode(200)
  ReDim WrkTExCount(200)
  ReDim WrkTExam(200)
  ReDim WrkTExRECount(200)
  ReDim WrkTExRE(200)
  ReDim WrkTExMVCount(200)
  ReDim WrkTExMV(200)
  ReDim WrkTExPPCount(200)
  ReDim WrkTExPP(200)
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
Public Sub GetOPMAssr()
  Dim myTXOPM As TXOPM.myData
  Dim sb As StringBuilder = New StringBuilder

  myTXOPM = New TXOPM.mydata(MyDBConnect)
  WrkAddress = ""
  WrkTownZip = ""
  WrkPhone = ""
  WrkFax = ""
  WrkEmail = ""
  WrkAssrName = ""
  WrkCertYes = ""
  WrkCertNo = ""
  WrkCert = ""

  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  If myTXOPM._PHONE > 0 Then
    WrkPhone = Format(myTXOPM._PHONE, "(###)###-####")
    If myTXOPM._PHONEX > 0 Then
      WrkPhone = WrkPhone & " ext " & myTXOPM._PHONEX
    End If
  End If

	WrkAddress = Trim(myTXOPM._ADDR1)
  sb.Append(Trim(myTXOPM._CITY))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._STATE))
  sb.Append(" ")
  sb.Append(Format(myTXOPM._ZIP, "00000"))
  If myTXOPM._ZIP4 > 0 Then
    sb.Append("-")
    sb.Append(Format(myTXOPM._ZIP4, "0000"))
  End If
  WrkTownZip = sb.ToString
  sb = Nothing
  If myTXOPM._FAX > 0 Then
    WrkFax = Format(myTXOPM._FAX, "(###)###-####")
  End If
	WrkEmail = Trim(myTXOPM._EMAIL)
	WrkAssrName = Trim(myTOWN._ASSR)
  If Trim(myTXOPM._CERT) <> String.Empty Then
    WrkCertYes = "X"
		WrkCert = Trim(myTXOPM._CERT)
  Else
    WrkCertNo = "X"
  End If
End Sub
End Module






