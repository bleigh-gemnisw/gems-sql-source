Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXM35HQ As TXM35HQ.myData
Dim myTXM35PM As TXM35PM.myData
Dim myTXLOCIN As TXLOCIN.myData
Dim myTPAYMNT As TPAYMNT.MyData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkGLYear As Integer

  Public Sub PrtReport()

  myTXM35HQ = New TXM35HQ.mydata(MyDBConnect)
  myTXM35PM = New TXM35PM.mydata(MyDBConnect)
  myTXLOCIN = New TXLOCIN.mydata(MyDBConnect)
  myTPAYMNT = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTA237B
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .Wrkds = ds
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
    .Columns.Add("code", Type.GetType("System.String"))
    .Columns.Add("localcredit", Type.GetType("System.Decimal"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim ds2 As DataSet = New DataSet
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim Counter As Integer

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

Counter = 0
WrkSort = "ALNAME, AFNAME"
WrkQry = "ALLOW='Y'"

myTXM35HQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXM35HQ.ReadQry()
  If Not myTXM35HQ.IsEOF Then
    With myTXM35HQ
      Counter = Counter + 1
      ds2 = myTXM35PM.GetbyList(._LISTNO, WrkGLYear, ._SEQ)
      If ds2.Tables(0).Rows.Count > 0 Then
        For I = 0 To ds2.Tables(0).Rows.Count - 1
          If Trim(ds2.Tables(0).Rows(I).Item("locpm")) <> "" Then
            dr = ds.Tables(0).NewRow
            dr.Item("listno") = ._LISTNO
            dr.Item("name") = Trim(._AFNAME) & " " & Trim(._ALNAME)
            dr.Item("sname") = Trim(._SFNAME) & " " & Trim(._SLNAME)
            dr.Item("proploc") = Trim(._PADDR)
            dr.Item("code") = ds2.Tables(0).Rows(I).Item("locpm")
            If MyLocEld = "032" Then
              dr.Item("localcredit") = GetLocCredit(ds2.Tables(0).Rows(I).Item("locpm"))
            End If
            If MyLocEld = "084" Then
              myTXLOCIN.GetOneRecordP(WrkGLYear, ds2.Tables(0).Rows(I).Item("locpm"))
              dr.Item("localcredit") = myTXLOCIN._AMOUNT
            End If
            ds.Tables(0).Rows.Add(dr)
          End If
        Next
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
Application.DoEvents()
myTXM35HQ.CloseFile()

End Sub
Private Function GetLocCredit(WrkCode As String) As Decimal
  Dim WrkCreditMax As Decimal
  Dim WrkLesser As Decimal
  Dim WrkCredit As Decimal

 WrkCredit = 0
 With myTXM35HQ
  If ._FRZTAX > 0 Then
   WrkCreditMax = MyUtils.Round(._FRZTAX * (._PCT / 100), 2)
  Else
   WrkCreditMax = MyUtils.Round(._TAX * (._PCT / 100), 2)
  End If
  With myTPAYMNT
    .In_Year = WrkGLYear
    .In_Type = "R"
    .In_Dst = 0
    .In_Phs = ""
    .In_TaxT = WrkCreditMax
    .CalcPaySplit()
    WrkCreditMax = .Out_TaxT
  End With
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

 Select Case WrkCode
 Case "212"
 Case "250"
   WrkCredit = WrkCredit * 0.5
 End Select

 Return WrkCredit
End Function
End Module






