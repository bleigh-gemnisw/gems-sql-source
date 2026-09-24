Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXCOOQ As TXCOOQ.myData
Dim myTXREALC As TXREALC.myData

Dim ds As DataSet = New DataSet
Dim DsTXCOO As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkSelect As String
Dim WrkSortBy As String
Dim WrkAddress As Boolean
  Public Sub PrtReport()
    myTXCOOQ = New TXCOOQ.mydata(MyDBConnect)
    myTXREALC = New TXREALC.mydata(MyDBConnect)

    With MyFrmTAE02B
      If .RbSelElderly.Checked Then
        WrkSelect = "E"
      End If
      If .RbSelNew.Checked Then
        WrkSelect = "N"
      End If
      If .RbSelTaxable.Checked Then
        WrkSelect = "T"
      End If
      If .RbSelVeterans.Checked Then
        WrkSelect = "V"
      End If
      If .RbSortOrig.Checked Then
        WrkSortBy = "Orig"
      End If
      If .RbSortNew.Checked Then
        WrkSortBy = "New"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      WrkAddress = .ChkAddress.Checked
    End With

    If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds = ds
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("COType", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("DevLot", Type.GetType("System.String"))
      .Columns.Add("MapLot", Type.GetType("System.String"))
      .Columns.Add("FullAmt", Type.GetType("System.Decimal"))
      .Columns.Add("CODate", Type.GetType("System.DateTime"))
      .Columns.Add("ProRateAmt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkAmt As Double

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkQry = ""
If WrkSelect <> "" Then 'CO Type
  WrkQry = "PCD=" & MyUtils.Quo(WrkSelect)
End If

WrkSort = ""
Select Case WrkSortBy
Case "Orig"
  WrkSort = "CONAM"
Case "New"
  WrkSort = "CONAM2"
Case "List"
  WrkSort = "LIST#"
End Select

DsTXCOO = myTXCOOQ.GetQry(WrkSort, WrkQry, 0)
If DsTXCOO.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

    For I = 0 To (DsTXCOO.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXCOO.Tables(0).Rows(I)
        dr = ds.Tables(0).NewRow
        Select Case WrkSortBy
          Case "Orig"
            dr.Item("sortdata") = .Item("conam")
          Case "New"
            dr.Item("sortdata") = .Item("conam2")
          Case "List"
            dr.Item("sortdata") = .Item("list#")
        End Select
        dr.Item("cotype") = .Item("pcd")
        dr.Item("listno") = .Item("list#")
        If WrkAddress Then
          AddrLine = MyUtils.SetAddrLine(.Item("conam"), .Item("conam2"), .Item("coadd1"),
          .Item("coadd2"), .Item("cocity"), .Item("coste"), .Item("cozip5"), .Item("cozip4"))
          dr.Item("addr1") = AddrLine(0)
          dr.Item("addr2") = AddrLine(1)
          dr.Item("addr3") = AddrLine(2)
          dr.Item("addr4") = AddrLine(3)
          dr.Item("addr5") = AddrLine(4)
        Else
          dr.Item("addr1") = .Item("conam")
          dr.Item("addr2") = .Item("conam2")
          dr.Item("addr3") = String.Empty
          dr.Item("addr4") = String.Empty
          dr.Item("addr5") = String.Empty
        End If
        dr.Item("devlot") = .Item("devlt")
        If .Item("rlist") > 0 Then
          myTXREALC.GetOneRecordP(.Item("rlist"))
        Else
          myTXREALC.GetOneRecordP(.Item("list#"))
        End If
        If Not myTXREALC.RecordNotFound Then
          With myTXREALC
            dr.Item("loc") = Trim(._LOCNO) & " " & Trim(._LOC)
            dr.Item("maplot") = Trim(._MAP)
          End With
        End If
        dr.Item("fullamt") = .Item("amt")
        dr.Item("codate") = MyUtils.GetDBDate(.Item("date"))
        If .Item("pcd") = "E" Then
          'MK 8/7/25 Begin
          'WrkAmt = .Item("benamt") - (.Item("benamt") * .Item("pct"))
          WrkAmt = .Item("amt") - (.Item("amt") * .Item("pct"))
          'MK 8/7/25 End
          dr.Item("prorateamt") = WrkAmt
        Else
          If .Item("benamt") = 0 Then
            dr.Item("prorateamt") = .Item("pinc")
          Else
            dr.Item("prorateamt") = .Item("benamt") - .Item("pinc")
          End If
        End If
      End With
      ds.Tables(0).Rows.Add(dr)

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / (DsTXCOO.Tables(0).Rows.Count)) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
myTXCOOQ.CloseFile()

End Sub
Private Sub CalcProrate()

End Sub

End Module






