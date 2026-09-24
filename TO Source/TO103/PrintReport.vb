Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXM35HQ As TXM35HQ.myData
Dim myTXOPM As TXOPM.myData
Dim myTXMRATE As TXMRATE.myData
Dim myTPAYMNT As TPAYMNT.MyData
Dim myTXREALC As TXREALC.myData
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dsErr As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkAppYear As Integer
Dim WrkPrev As Boolean
Dim WrkPrintDist As Boolean

Dim WrkTax As Decimal
Dim WrkFrzTax As Decimal
Dim WrkCreditMax As Decimal
Dim WrkLesser As Decimal
Dim WrkCredit As Decimal
Dim WrkAnd As String
Dim WrkOr As String

'Global
Public MrateMillrt As Decimal
Public WrkTown As String
Public WrkAssrPhone As String
Public WrkCollPhone As String
Public WrkAcctsApp As Integer
Public WrkAcctsRen As Integer
Public WrkReimbApp As Decimal
Public WrkReimbRen As Decimal


  Public Sub PrtReport()

  myTXM35HQ = New TXM35HQ.mydata(MyDBConnect)
  myTXOPM = New TXOPM.mydata(MyDBConnect)
  myTXMRATE = New TXMRATE.mydata(MyDBConnect)
	myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)
  myTXREALC = New TXREALC.mydata(MyDBConnect)

  With MyFrmTO103B
    WrkGLYear = .TxtGLYear.Text
    WrkAppYear = MyUtils.CnvSng(.TxtAppYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkPrev = .RbPrev.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    ds2.Clear()
    dsErr.Clear()
  End If

  GetMillRate(WrkGLYear, "R", WrkDist)
  GetOPMAssr()
  GetOPMColl()
  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .Wrkds = ds
    .Wrkds2 = ds2
    .WrkdsErr = dsErr
    .Show()
  End With

  End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("sname", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("year", Type.GetType("System.Int64"))
    .Columns.Add("code", Type.GetType("System.String"))
    .Columns.Add("netass", Type.GetType("System.Int64"))
    .Columns.Add("tax", Type.GetType("System.Decimal"))
    .Columns.Add("adjtax", Type.GetType("System.Decimal"))
    .Columns.Add("taxcredit", Type.GetType("System.Decimal"))
    .Columns.Add("msg", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
  ds2 = ds.Clone
  dsErr = ds.Clone
End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkYear1 As Integer
Dim WrkMillRate As Decimal
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

WrkYear1 = WrkGLYear - 1
WrkQry = "year = " & WrkGLYear & WrkAnd & "ALLOW='Y'"
If WrkPrev Then
  WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'"
End If
WrkSort = "ALNAME, AFNAME"

Counter = 0
WrkAcctsApp = 0
WrkAcctsRen = 0
WrkReimbApp = 0
WrkReimbRen = 0
myTXM35HQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myTXMRATE.GetOneRecordP(WrkGLYear, "R", 0)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", 0)
End If
WrkMillRate = 0
If Not myTXMRATE.RecordNotFound Then
  WrkMillRate = myTXMRATE._MRRATE * 1000
End If

ReadNext:
  myTXM35HQ.ReadQry()
  If Not myTXM35HQ.IsEOF Then
  With myTXM35HQ
    myTXREALC.GetOneRecordP(._LISTNO)
    If Not myTXREALC.RecordNotFound Then
      If Trim(myTXREALC._FCCOD) = String.Empty Then GoTo NextRec
      If Trim(myTXREALC._FCYR) <> ._YEAR Then GoTo NextRec
    Else
      GoTo NextRec
    End If
    GetCredit()
    If ._YEAR <> WrkAppYear Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If
    dr.Item("listno") = ._LISTNO
    dr.Item("name") = Trim(._ALNAME) & " " & Trim(._AFNAME)
    If ._PROPCT <> 100 Then
      dr.Item("name") = dr.Item("name") & " (" & Format(._PROPCT / 100, "##%") & ")"
    End If
    dr.Item("sname") = Trim(._SLNAME) & " " & Trim(._SFNAME)
    dr.Item("proploc") = Trim(myTXREALC._LOCNO) & " " & Trim(myTXREALC._LOC)
    dr.Item("year") = ._YEAR
    'Check for Even or Odd year
    If ._YEAR Mod 2 = 0 Then
      dr.Item("code") = "E"
    Else
      dr.Item("code") = "O"
    End If
    If ._FRZTAX > 0 Then
      WrkTax = ._FRZTAX
    Else
      WrkTax = ._TAX
    End If
    With myTPAYMNT
      .In_Year = WrkGLYear
      .In_Type = "R"
      .In_Dst = WrkDist
      .In_Phs = ""
      .In_TaxT = WrkTax
      .CalcPaySplit()
      WrkTax = .Out_TaxT
    End With
    dr.Item("netass") = ._NET
    dr.Item("tax") = WrkTax
    dr.Item("adjtax") = WrkTax - WrkCredit
    dr.Item("taxcredit") = WrkCredit
    If ._YEAR <> WrkAppYear Then
      ds.Tables(0).Rows.Add(dr)
      WrkAcctsRen = WrkAcctsRen + 1
      WrkReimbRen = WrkReimbRen + WrkCredit
    Else
      ds2.Tables(0).Rows.Add(dr)
      WrkAcctsApp = WrkAcctsApp + 1
      WrkReimbApp = WrkReimbApp + WrkCredit
    End If
    If WrkTax = 0 Then
      dr = dsErr.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("name") = Trim(._ALNAME) & " " & Trim(._AFNAME)
      If ._PROPCT <> 100 Then
        dr.Item("name") = dr.Item("name") & " (" & Format(._PROPCT / 100, "##%") & ")"
      End If
      dr.Item("sname") = Trim(._SLNAME) & " " & Trim(._SFNAME)
      dr.Item("proploc") = Trim(myTXREALC._LOCNO) & " " & Trim(myTXREALC._LOC)
      dr.Item("year") = ._YEAR
      dr.Item("taxcredit") = WrkCredit
      dr.Item("msg") = "Tax is Zero"
      dsErr.Tables(0).Rows.Add(dr)
    End If
  End With

NextRec:
    With myFrmProgress
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .LblMsg.Text = "Records processed: " & Counter
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo ReadNext
  End If

myFrmProgress.Close()
myTXM35HQ.CloseFile()

End Sub
Private Sub GetCredit()
 Dim WrkAmount As Decimal

 With myTXM35HQ
  If ._FRZTAX > 0 Then
    WrkFrzTax = ._FRZTAX
    WrkTax = ._TAX
    WrkAmount = ._FRZTAX
  Else
    WrkFrzTax = 0
    WrkTax = ._TAX
    WrkAmount = ._TAX
  End If
  With myTPAYMNT
    .In_Year = WrkGLYear
    .In_Type = "R"
    .In_Dst = 0
    .In_Phs = ""
    .In_TaxT = WrkAmount
    .CalcPaySplit()
    WrkAmount = .Out_TaxT
  End With
  WrkCreditMax = MyUtils.Round(WrkAmount * (._PCT / 100), 2)
  If WrkCreditMax > ._MAX Then
   WrkLesser = ._MAX
  Else
   WrkLesser = WrkCreditMax
  End If
  If WrkLesser < ._MIN Then
   WrkCredit = ._MIN
  Else
   WrkCredit = WrkLesser
  End If
 End With

 With myTPAYMNT
  .In_Year = WrkGLYear
  .In_Type = "R"
  .In_Dst = 0
  .In_Phs = ""
  .In_TaxT = WrkCredit
  .CalcPaySplit()
  WrkCredit = .Out_TaxT
 End With

End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)
Dim myTXMRATE As TXMRATE.myData

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
Public Sub GetOPMAssr()

  Dim sb As StringBuilder = New StringBuilder

  WrkAssrPhone = ""
  WrkTown = ""
  myTXOPM.GetOneRecordP("A")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkAssrPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkAssrPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If

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

End Sub
Public Sub GetOPMColl()

  Dim sb As StringBuilder = New StringBuilder

  WrkCollPhone = ""
  myTXOPM.GetOneRecordP("C")
  If myTXOPM.RecordNotFound Then Exit Sub

  WrkCollPhone = Format(myTXOPM._PHONE, "###-###-####")
  If myTXOPM._PHONEX > 0 Then
    WrkCollPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
  End If
End Sub
End Module






