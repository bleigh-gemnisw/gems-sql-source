Imports System.text
Module PrintShared
Public ds As DataSet = New DataSet
Public dr As Data.DataRow
Dim myTXMRATE As TXMRATE.myData
Dim myTXOPM As TXOPM.myData
'Mill Rates
Public CurMillrt As Decimal
Public MVMillrt As Decimal
Public PrvMillrt As Decimal
Public MVMillrtUsed As Boolean
'Exemption table
Public WrkExCode(200) As String
Public WrkExDesc(200) As String
Public WrkExFixedAmt(200) As Integer
Public WrkExPerc(200) As Double
Public WrkExLetter(200) As String
'Global
Public WrkTown As String
Public WrkAssrPhone As String
Public WrkAssrEmail As String
Public WrkCollPhone As String
Public WrkCollEmail As String
Public WrkCurREAccts As Integer
Public WrkCurREExAmt As Decimal
Public WrkCurRERevLoss As Decimal
Public WrkCurMVAccts As Integer
Public WrkCurMVExAmt As Decimal
Public WrkCurMVRevLoss As Decimal
Public WrkPrvAccts As Integer
Public WrkPrvExAmt As Decimal
Public WrkPrvRevLoss As Decimal

Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkDist As Integer)
myTXMRATE = New TXMRATE.mydata(MyDBConnect)

myTXMRATE.GetOneRecordP(WrkGLYear, "R", WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    CurMillrt = ._MRRATE
  End With
End If

myTXMRATE.GetOneRecordP(WrkGLYear, "M", WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    MVMillrt = ._MRRATE
  End With
End If

myTXMRATE.GetOneRecordP(WrkGLYear - 1, "R", WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear - 1, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    PrvMillrt = ._MRRATE
  End With
End If
myTXMRATE.CloseFile()
End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int32"))
    .Columns.Add("type", Type.GetType("System.String"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
    .Columns.Add("addr4", Type.GetType("System.String"))
    .Columns.Add("addr5", Type.GetType("System.String"))
    .Columns.Add("excd", Type.GetType("System.String"))
    .Columns.Add("exam", Type.GetType("System.Int32"))
    .Columns.Add("revloss", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Friend Sub BufferExem()
     Dim I As Integer

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
        WrkExCode(I) = .Item("texem")
        WrkExDesc(I) = .Item("tdesc")
        WrkExFixedAmt(I) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(I) = 1
        Else
          WrkExPerc(I) = .Item("tperc")
        End If
        WrkExLetter(I) = Trim(.Item("txscd"))
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
Public Sub GetOPMAssr()

  myTXOPM = New TXOPM.mydata(MyDBConnect)
  WrkAssrPhone = ""
  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkAssrPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkAssrPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If
    WrkAssrEmail = Trim(myTXOPM._EMAIL)
End Sub
Public Sub GetOPMColl()

  Dim sb As StringBuilder = New StringBuilder

  myTXOPM = New TXOPM.mydata(MyDBConnect)
  WrkTown = ""
  WrkCollPhone = ""
  myTXOPM.GetOneRecordP("C")
  If myTXOPM.RecordNotFound Then Exit Sub

  sb.Append(Trim(myTOWN._TOWN))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._ADDR1))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._CITY))
  sb.Append(",")
  sb.Append(Trim(myTXOPM._STATE))
  sb.Append(" ")
  sb.Append(Format(myTXOPM._ZIP, "00000"))
  If myTXOPM._ZIP4 > 0 Then
    sb.Append("-")
    sb.Append(Format(myTXOPM._ZIP4, "0000"))
  End If
  WrkTown = sb.ToString
  sb = Nothing

  WrkCollPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkCollPhone = WrkCollPhone & " ext " & myTXOPM._PHONEX
  End If
    WrkCollEmail = Trim(myTXOPM._EMAIL)
End Sub
End Module






