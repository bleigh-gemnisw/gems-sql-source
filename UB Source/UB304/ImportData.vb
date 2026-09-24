Imports System.Text
Module ImportData

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUST As UTCUST.myData
Dim myTXREALQ As TXREALQ.myData
Dim myTXTRANS As TXTrans.myData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim wrklistno As Integer
Dim wrkcbname As Boolean
Dim wrkcbmap As Boolean
Dim wrkcbdist As Boolean
Dim wrkcbpdist As Boolean
Dim wrkcbloc As Boolean
Dim wrkcbvol As Boolean
Dim wrkcbtransfer As Boolean
Dim WrkAddMissing As Boolean
Dim WrkPost As Boolean
Dim WrkShowLines As Boolean
Dim WrkSortBy As String
Public Sub Impdata()
myUTCUST = New UTCUST.mydata(MyDBConnect)
myTXREALQ = New TXREALQ.mydata(MyDBConnect)
myTXTRANS = New TXTrans.mydata(MyDBConnect)

With MyFrmUB304B
  wrkcbtransfer = False
  If .ChkTransfer.Checked = True Then wrkcbtransfer = True
  wrkcbname = False
  If .ChkName.Checked = True Then wrkcbname = True
  wrkcbmap = False
  If .ChkMap.Checked = True Then wrkcbmap = True
  wrkcbdist = False
  If .ChkDist.Checked = True Then wrkcbdist = True
  wrkcbpdist = False
  If .ChkPDist.Checked = True Then wrkcbpdist = True
  wrkcbvol = False
  If .ChkVol.Checked = True Then wrkcbvol = True
  wrkcbloc = False
  If .ChkLoc.Checked = True Then wrkcbloc = True
  WrkAddMissing = False
  If .ChkAdd.Checked = True Then WrkAddMissing = True
  WrkPost = False
  If .ChkPost.Checked = True Then WrkPost = True
  WrkShowLines = False
  If .ChkShowLines.Checked Then WrkShowLines = True
  If .RbSortName.Checked Then WrkSortBy = "NAME"
  If .RbSortList.Checked Then WrkSortBy = "LIST#"
End With

If ds.Tables.Count = 0 Then
  BuildDs(ds, ds2)
  ds3 = ds.Clone
Else
  ds.Clear()
  ds2.Clear()
  ds3.Clear()
End If
GetDetail()

MyCrViewer = New FrmCrViewer
With MyCrViewer
  .Wrkds1 = ds
  .Wrkds2 = ds2
  .Wrkds3 = ds3
  .Show()
End With

End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
' this routine will retrieve the TXreal records and if selected and exists the transfer record.
' It will then update the UTCUST file using the associated subroutines.
' Only the fields selected will be updated on an update.   On an Add they all will be added

WrkSort = ""
WrkQry = ""
Counter = 0

myTXREALQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXREALQ.ReadQry()
  If Not myTXREALQ.IsEOF Then
  With myTXREALQ
    Counter = Counter + 1
    wrklistno = ._LISTNO
  End With

  If wrkcbtransfer = True Then
    myTXTRANS.GetOneRecordP(wrklistno)
  End If
  myUTCUST.GetOneRecordP(wrklistno)

  AddToReport()
  If WrkPost Then
    UpdateUTCUST()
  End If

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
myTXREALQ.CloseFile()

End Sub
Private Sub UpdateUTCUST()
 Dim WrkAdd As Boolean
 Dim wrkzip5 As Integer
 Dim wrkzip4 As Integer
 Dim wrkzipa As String

  With myUTCUST
    WrkAdd = False
    If myUTCUST.RecordNotFound Then
      If Not WrkAddMissing Then Exit Sub
      If myTXREALQ._SEWER = "Y" Then
        ._CUACCT = wrklistno
        WrkAdd = True
      Else
        Exit Sub
      End If
    Else
      If myTXREALQ._SEWER <> "Y" Then Exit Sub
    End If
    If Not wrkcbtransfer Or myTXTRANS.RecordNotFound Then
      If wrkcbname Or WrkAdd Then
        ._CUNAM1 = Trim(myTXREALQ._NAME)
        ._CUNAM2 = Trim(myTXREALQ._SNAME)
        ._CUADD1 = Trim(myTXREALQ._ADD1)
        ._CUADD2 = Trim(myTXREALQ._ADD2)
        ._CUCITY = Trim(myTXREALQ._CITY)
        ._CUST = Trim(myTXREALQ._STATE)
        wrkzip5 = myTXREALQ._ZIP5
        wrkzip4 = myTXREALQ._ZIP4
        wrkzipa = Format(wrkzip5, "00000")
        If wrkzip4 <> 0 Then
          wrkzipa = wrkzipa + "-" + Format(wrkzip4, "0000")
        End If
        ._CUZIP = wrkzipa
      End If
      If wrkcbmap Then
        ._CUMAP = Trim(myTXREALQ._MAP)
      End If
      If wrkcbvol Then
        ._CUVOLM = Trim(myTXREALQ._VOL)
        ._CUPAGE = Trim(myTXREALQ._PGE)
      End If
    Else  ' TRANSFER
      If wrkcbname Or WrkAdd Then
        ._CUNAM1 = myTXTRANS._NAME
        ._CUNAM2 = myTXTRANS._SNAME
        ._CUADD1 = myTXTRANS._ADD1
        ._CUADD2 = myTXTRANS._ADD2
        ._CUCITY = myTXTRANS._CITY
        ._CUST = myTXTRANS._STATE
        wrkzip5 = myTXTRANS._ZIP5
        wrkzip4 = myTXTRANS._ZIP4
        wrkzipa = Format(wrkzip5, "00000")
        If wrkzip4 <> 0 Then
          wrkzipa = wrkzipa + "-" + Format(wrkzip4, "0000")
        End If
        ._CUZIP = wrkzipa
      End If
      If wrkcbmap Then
        ._CUMAP = myTXTRANS._MAP
      End If
      If wrkcbvol Then
        ._CUVOLM = myTXTRANS._VOL
        ._CUPAGE = myTXTRANS._TPAGE
      End If
    End If

    ' dist & loc  not in transfer file
    If wrkcbdist Then
      ._CUDST = myTXREALQ._DIST
    End If
    If wrkcbpdist Then
      ._CUDST = myTXREALQ._PDST
    End If
    If wrkcbloc Or WrkAdd Then
      ._CULOC = Trim(myTXREALQ._LOC)
      ._CULOCNO = myTXREALQ._LOCNO
    End If
    If wrkcbname Or WrkAdd Then
      ._CUMAD1 = String.Empty
      ._CUMAD2 = String.Empty
      ._CUMCTY = String.Empty
      ._CUMST = String.Empty
      ._CUMZIP = String.Empty
    End If
  End With

  If myUTCUST.RecordNotFound Then
    myUTCUST.AddOneRecordP()
      If myUTCUST.ErrMsg <> "" Then
        WriteErrorLog(myUTCUST.ErrMsg)
        Exit Sub
      End If
    Else
      myUTCUST.UpdateOneRecordP()
      If myUTCUST.ErrMsg <> "" Then
        WriteErrorLog(myUTCUST.ErrMsg)
        Exit Sub
      End If
    End If
  End Sub
Public Sub BuildDs(ByRef Ds As DataSet, ByRef Ds2 As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("sortdata", Type.GetType("System.String"))
      .Columns.Add("sewer", Type.GetType("System.String"))
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("line1", Type.GetType("System.String"))
      .Columns.Add("line2", Type.GetType("System.String"))
      .Columns.Add("line3", Type.GetType("System.String"))
      .Columns.Add("line4", Type.GetType("System.String"))
      .Columns.Add("line5", Type.GetType("System.String"))
      .Columns.Add("locno", Type.GetType("System.String"))
      .Columns.Add("loc", Type.GetType("System.String"))
      .Columns.Add("dist", Type.GetType("System.Int32"))
      .Columns.Add("map", Type.GetType("System.String"))
      .Columns.Add("vol", Type.GetType("System.String"))
      .Columns.Add("page", Type.GetType("System.String"))
      .Columns.Add("nline1", Type.GetType("System.String"))
      .Columns.Add("nline2", Type.GetType("System.String"))
      .Columns.Add("nline3", Type.GetType("System.String"))
      .Columns.Add("nline4", Type.GetType("System.String"))
      .Columns.Add("nline5", Type.GetType("System.String"))
      .Columns.Add("nlocno", Type.GetType("System.String"))
      .Columns.Add("nloc", Type.GetType("System.String"))
      .Columns.Add("ndist", Type.GetType("System.Int32"))
      .Columns.Add("nmap", Type.GetType("System.String"))
      .Columns.Add("nvol", Type.GetType("System.String"))
      .Columns.Add("npage", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
    ds2 = Ds.Clone

End Sub
Public Sub AddToReport
  Dim AddrLine() As String
  Dim WrkAdd As Boolean

  WrkAdd = False
  If Not myUTCUST.RecordNotFound Then
    If myTXREALQ._SEWER = "Y" Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds3.Tables(0).NewRow
    End If
  Else
    If Not WrkAddMissing Then Exit Sub
    If myTXREALQ._SEWER = "Y" Then
      dr = ds2.Tables(0).NewRow
      WrkAdd = True
    End If
  End If
  Select Case WrkSortBy
  Case "LIST#"
    dr("sortdata") = Format(wrklistno, "000000")
  Case "NAME"
    If Not myUTCUST.RecordNotFound Then
      dr("sortdata") = myUTCUST._CUNAM1
    Else
      dr("sortdata") = myTXREALQ._NAME
    End If
  End Select
  dr("sewer") = Trim(myTXREALQ._SEWER)
  dr.Item("listno") = wrklistno
  If Not myUTCUST.RecordNotFound Then
    With myUTCUST
      AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, _
        ._CUCITY, ._CUST, 0, 0, ._CUZIP)
      dr.Item("line1") = Trim(AddrLine(0))
      If WrkShowLines Then
        dr.Item("line2") = Trim(AddrLine(1))
        dr.Item("line3") = Trim(AddrLine(2))
        dr.Item("line4") = Trim(AddrLine(3))
        dr.Item("line5") = Trim(AddrLine(4))
      End If
      If wrkcbmap Then
        dr.Item("map") = Trim(._CUMAP)
      End If
      If wrkcbvol Then
        dr.Item("vol") = Trim(._CUVOLM)
        dr.Item("page") = Trim(._CUPAGE)
      End If
      If wrkcbdist Then
        dr.Item("dist") = ._CUDST
      Else
        dr.Item("dist") = 0
      End If
      If wrkcbloc Or WrkAdd Then
        dr.Item("loc") = Trim(._CULOC)
        dr.Item("locno") = Trim(._CULOCNO)
      End If
    End With
  Else
    dr.Item("line1") = String.Empty
    dr.Item("line2") = String.Empty
    dr.Item("line3") = String.Empty
    dr.Item("line4") = String.Empty
    dr.Item("line5") = String.Empty
    dr.Item("map") = String.Empty
    dr.Item("vol") = String.Empty
    dr.Item("page") = String.Empty
    dr.Item("dist") = 0
    dr.Item("loc") = String.Empty
    dr.Item("locno") = String.Empty
  End If

  If Not wrkcbtransfer Or myTXTRANS.RecordNotFound Then
    With myTXREALQ
      If wrkcbname Or WrkAdd Then
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
          ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        dr.Item("nline1") = AddrLine(0)
        If WrkShowLines Then
          dr.Item("nline2") = AddrLine(1)
          dr.Item("nline3") = AddrLine(2)
          dr.Item("nline4") = AddrLine(3)
          dr.Item("nline5") = AddrLine(4)
        End If
      End If
      If wrkcbmap Then
        dr.Item("nmap") = ._MAP
      End If
      If wrkcbvol Then
        dr.Item("nvol") = ._VOL
        dr.Item("npage") = ._PGE
      End If
    End With
  Else  ' TRANSFER
    If wrkcbname Or WrkAdd Then
        AddrLine = MyUtils.SetAddrLine(myTXTRANS._NAME, myTXTRANS._SNAME, myTXTRANS._ADD1, myTXTRANS._ADD2, _
          myTXTRANS._CITY, myTXTRANS._STATE, myTXTRANS._ZIP5, myTXTRANS._ZIP4)
        dr.Item("nline1") = Trim(AddrLine(0))
        If WrkShowLines Then
          dr.Item("nline2") = Trim(AddrLine(1))
          dr.Item("nline3") = Trim(AddrLine(2))
          dr.Item("nline4") = Trim(AddrLine(3))
          dr.Item("nline5") = Trim(AddrLine(4))
       End If
    End If
    If wrkcbmap Then
      dr.Item("nmap") = Trim(myTXTRANS._MAP)
    End If
    If wrkcbvol Then
      dr.Item("nvol") = Trim(myTXTRANS._VOL)
      dr.Item("npage") = Trim(myTXTRANS._TPAGE)
    End If
  End If

  ' dist & loc  not in transfer file
  If wrkcbdist Then
    dr.Item("ndist") = myTXREALQ._DIST
  Else
    dr.Item("ndist") = 0
  End If
  If wrkcbloc Or WrkAdd Then
    dr.Item("nloc") = Trim(myTXREALQ._LOC)
    dr.Item("nlocno") = Trim(myTXREALQ._LOCNO)
  End If

    If Not myUTCUST.RecordNotFound Then
      If myTXREALQ._SEWER = "Y" Then
        ds.Tables(0).Rows.Add(dr)
      Else
        ds3.Tables(0).Rows.Add(dr)
      End If
    Else
      If myTXREALQ._SEWER = "Y" Then
        ds2.Tables(0).Rows.Add(dr)
      End If
    End If

  End Sub
End Module






