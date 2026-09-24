Imports System.Text
Module PrintShared
Public myFrmProgress As FrmProgress
Public myTXMRATE As TXMRATE.myData
Public myTXPROF As TXPROF.myData
Public ds As DataSet = New DataSet
Public dsDtl As DataSet = New DataSet
'Summary Report Totals
Public WrkTotalRE As Decimal
Public WrkTotalMV As Decimal
Public WrkTotalPP As Decimal
Public WrkTotalSU As Decimal
Public WrkTotal As Decimal
Public WrkREDueDate1 As String
Public WrkREDueDate2 As String
Public WrkREDueDate3 As String
Public WrkREDueDate4 As String
Public WrkPPDueDate1 As String
Public WrkPPDueDate2 As String
Public WrkPPDueDate3 As String
Public WrkPPDueDate4 As String
Public WrkMVDueDate1 As String
Public WrkMVDueDate2 As String
Public WrkMVDueDate3 As String
Public WrkMVDueDate4 As String
'Summary Report - OPM Info
Public WrkAddress As String
Public WrkTownZip As String
Public WrkPhone As String
Public WrkEMail As String
'Exemptions (TXEXEM)
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As String
Public WrkExPerc(200) As String

Friend Sub BuildDS()
  Dim myTable As New DataTable
  Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("address", Type.GetType("System.String"))
      .Columns.Add("townzip", Type.GetType("System.String"))
      .Columns.Add("phone", Type.GetType("System.String"))
      .Columns.Add("email", Type.GetType("System.String"))
			.Columns.Add("muntown", Type.GetType("System.String"))
			.Columns.Add("munbur", Type.GetType("System.String"))
			.Columns.Add("muncity", Type.GetType("System.String"))
      .Columns.Add("distfire", Type.GetType("System.String"))
      .Columns.Add("distsewer", Type.GetType("System.String"))
      .Columns.Add("distlighting", Type.GetType("System.String"))
      .Columns.Add("distvillage", Type.GetType("System.String"))
      .Columns.Add("distbeach", Type.GetType("System.String"))
      .Columns.Add("distimprovement", Type.GetType("System.String"))
      .Columns.Add("distother", Type.GetType("System.String"))
      .Columns.Add("collapp", Type.GetType("System.String"))
			.Columns.Add("collelect", Type.GetType("System.String"))
			.Columns.Add("millrateday", Type.GetType("System.String"))
      .Columns.Add("millratemonth", Type.GetType("System.String"))
      .Columns.Add("millrate", Type.GetType("System.Decimal"))
      .Columns.Add("millratemv", Type.GetType("System.Decimal"))
      .Columns.Add("millrateauthority", Type.GetType("System.String"))
			.Columns.Add("creditcardyes", Type.GetType("System.String"))
			.Columns.Add("creditcardno", Type.GetType("System.String"))
			.Columns.Add("collected", Type.GetType("System.Decimal"))
			.Columns.Add("creditallyes", Type.GetType("System.String"))
      .Columns.Add("creditrestrict", Type.GetType("System.String"))
      .Columns.Add("creditallno", Type.GetType("System.String"))
      .Columns.Add("liensyes", Type.GetType("System.String"))
			.Columns.Add("liensno", Type.GetType("System.String"))
			.Columns.Add("totre", Type.GetType("System.Decimal"))
      .Columns.Add("totmv", Type.GetType("System.Decimal"))
      .Columns.Add("totpp", Type.GetType("System.Decimal"))
      .Columns.Add("tot", Type.GetType("System.Decimal"))
      .Columns.Add("totsu", Type.GetType("System.Decimal"))
      .Columns.Add("reduedate1", Type.GetType("System.String"))
      .Columns.Add("reduedate2", Type.GetType("System.String"))
      .Columns.Add("reduedate3", Type.GetType("System.String"))
      .Columns.Add("reduedate4", Type.GetType("System.String"))
      .Columns.Add("ppduedate1", Type.GetType("System.String"))
      .Columns.Add("ppduedate2", Type.GetType("System.String"))
      .Columns.Add("ppduedate3", Type.GetType("System.String"))
      .Columns.Add("ppduedate4", Type.GetType("System.String"))
      .Columns.Add("mvduedate1", Type.GetType("System.String"))
      .Columns.Add("mvduedate2", Type.GetType("System.String"))
      .Columns.Add("mvduedate3", Type.GetType("System.String"))
      .Columns.Add("mvduedate4", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
    End With
    dsDtl.Tables.Add(myTable2)
End Sub
Public Sub ClearSharedTotals()
  WrkTotalRE = 0
  WrkTotalMV = 0
  WrkTotalPP = 0
  WrkTotal = 0
  WrkTotalSU = 0
End Sub
Public Sub GetOPMColl()
  Dim myTXOPM As TXOPM.myData
  Dim sb As StringBuilder = New StringBuilder

  myTXOPM = New TXOPM.mydata(MyDBConnect)
  WrkAddress = ""
  WrkTownZip = ""
  WrkPhone = ""
  WrkEMail = ""

  myTXOPM.GetOneRecordP("C")
  If myTXOPM.RecordNotFound Then Exit Sub

  If myTXOPM._PHONE > 0 Then
    WrkPhone = Format(myTXOPM._PHONE, "(###)###-####")
    If myTXOPM._PHONEX > 0 Then
      WrkPhone = WrkPhone & " ext " & myTXOPM._PHONEX
    End If
  End If

  WrkAddress = myTXOPM._ADDR1
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
  'If myTXOPM._FAX > 0 Then
  '  WrkFax = Format(myTXOPM._FAX, "(###)###-####")
  'End If
  WrkEMail = myTXOPM._EMAIL
End Sub
Public Sub GetTXMRATE(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)
  myTXMRATE = New TXMRATE.mydata(MyDBConnect)

  myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
  If myTXMRATE.RecordNotFound Then
    myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
  End If
End Sub
Public Sub GetTXPROF(ByVal Type As String, ByVal Year As Integer, ByVal Phase As String, ByVal Dist As Integer)
  myTXPROF = New TXPROF.mydata(MyDBConnect)

  myTXPROF.GetOneRecordP(Type, Year, Phase, Dist)
End Sub
Public Sub BufferExem()
     Dim I As Integer

		 Dim myTXEXEM As TXEXEM.myData
     Dim dsTXEXEM As DataSet = New DataSet

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
      End With
    Next

End Sub
Public Function LookupExem(ByVal Exem As String) As Integer
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
End Module






