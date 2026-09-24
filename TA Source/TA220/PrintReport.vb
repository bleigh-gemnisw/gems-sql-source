Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXTRANSQ As TXTRANSQ.myData
Dim myTXTRANS As TXTrans.myData
Dim myTXREAL As TXReal.myData

Dim ds As DataSet = New DataSet
Dim DsTXTRANS As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXTRANSQ = New TXTRANSQ.mydata(MyDBConnect)
	myTXTRANS = New TXTrans.mydata(MyDBConnect)
	myTXREAL = New TXReal.mydata(MyDBConnect)

  With MyFrmTA220B
    If .ChkPost.Checked Then WrkPost = True
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("TAddr1", Type.GetType("System.String"))
      .Columns.Add("TAddr2", Type.GetType("System.String"))
      .Columns.Add("TAddr3", Type.GetType("System.String"))
      .Columns.Add("TAddr4", Type.GetType("System.String"))
      .Columns.Add("TAddr5", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("Vol", Type.GetType("System.String"))
      .Columns.Add("Pge", Type.GetType("System.String"))
      .Columns.Add("TVol", Type.GetType("System.String"))
      .Columns.Add("TPge", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
      .Columns.Add("PurchDate", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim TAddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "POSTED = ' '"

DsTXTRANS = myTXTRANSQ.GetQry(WrkSort, WrkQry, 0)
If DsTXTRANS.Tables(0).Rows.Count = 0 Then
  myTXTRANSQ.CloseFile()
  Exit Sub
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If DsTXTRANS.Tables(0).Rows.Count = 0 Then GoTo Done

For I = 0 To (DsTXTRANS.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  myTXREAL.GetOneRecordP(DsTXTRANS.Tables(0).Rows(I).Item("list#"))
  If myTXREAL.RecordNotFound Then
    GoTo NextRec
  End If
  dr = ds.Tables(0).NewRow
  With DsTXTRANS.Tables(0).Rows(I)
    TAddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("taddr1") = TAddrLine(0)
    dr.Item("taddr2") = TAddrLine(1)
    dr.Item("taddr3") = TAddrLine(2)
    dr.Item("taddr4") = TAddrLine(3)
    dr.Item("taddr5") = TAddrLine(4)
    dr.Item("tvol") = .Item("vol")
    dr.Item("tpge") = .Item("tpage")
    dr.Item("purchdate") = MyUtils.GetDBDate(.Item("tdate"))
  End With

 With myTXREAL
  dr.Item("listno") = ._LISTNO
  AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
   ._CITY, ._STATE, ._ZIP5, ._ZIP4)
  dr.Item("addr1") = AddrLine(0)
  dr.Item("addr2") = AddrLine(1)
  dr.Item("addr3") = AddrLine(2)
  dr.Item("addr4") = AddrLine(3)
  dr.Item("addr5") = AddrLine(4)
  dr.Item("loc") = Trim(._LOC)
  dr.Item("map") = Trim(._MAP)
  dr.Item("vol") = ""
  dr.Item("pge") = ""
  If Trim(._VOL) <> DsTXTRANS.Tables(0).Rows(I).Item("vol") Or _
    Trim(._PGE) <> DsTXTRANS.Tables(0).Rows(I).Item("tpage") Then
   dr.Item("vol") = Trim(._VOL)
   dr.Item("pge") = Trim(._PGE)
  End If
  ds.Tables(0).Rows.Add(dr)

  If Not WrkPost Then GoTo NextRec
  ._NAME = DsTXTRANS.Tables(0).Rows(I).Item("name")
  ._LETT = Mid(DsTXTRANS.Tables(0).Rows(I).Item("name"), 1, 1)
  ._SNAME = DsTXTRANS.Tables(0).Rows(I).Item("sname")
  ._ADD1 = DsTXTRANS.Tables(0).Rows(I).Item("add1")
  ._ADD2 = DsTXTRANS.Tables(0).Rows(I).Item("add2")
  ._CITY = DsTXTRANS.Tables(0).Rows(I).Item("city")
  ._STATE = DsTXTRANS.Tables(0).Rows(I).Item("state")
  ._ZIP5 = DsTXTRANS.Tables(0).Rows(I).Item("zip5")
  ._ZIP4 = DsTXTRANS.Tables(0).Rows(I).Item("zip4")
  ._MAP = DsTXTRANS.Tables(0).Rows(I).Item("map")
  ._VOL = DsTXTRANS.Tables(0).Rows(I).Item("vol")
  ._PGE = DsTXTRANS.Tables(0).Rows(I).Item("tpage")
  ._EXMPT = DsTXTRANS.Tables(0).Rows(I).Item("exmpt")
  ._PURDT = DsTXTRANS.Tables(0).Rows(I).Item("tdate")
  ._PURPR = DsTXTRANS.Tables(0).Rows(I).Item("price")
  If DsTXTRANS.Tables(0).Rows(0).Item("eldcd") = "Y" Then
   ._FCCOD = ""
   ._FCYR = 0
   ._CPERC = 0
   ._CMAX = 0
   ._CMIN = 0
   ._CIRAD = 0
   ._FTAX = 0
   ._FASS = 0
   ._TWNBN = 0
  End If
  If DsTXTRANS.Tables(0).Rows(0).Item("exmpt2") = "Y" Then
   ._NET = ._GROSS
   ._EXCD1 = ""
   ._EXCD2 = ""
   ._EXCD3 = ""
   ._EXCD4 = ""
   ._EXCD5 = ""
   ._EXCD6 = ""
   ._EXCD7 = ""
   ._EXAM1 = 0
   ._EXAM2 = 0
   ._EXAM3 = 0
   ._EXAM4 = 0
   ._EXAM5 = 0
   ._EXAM6 = 0
   ._EXAM7 = 0
  End If
  End With
		myTXREAL.UpdateOneRecordP()
    UpdateTXTRANS(DsTXTRANS.Tables(0).Rows(I).Item("list#"))
NextRec:
With myFrmProgress
  If DsTXTRANS.Tables(0).Rows.Count > 1 Then
    WrkPct = ((I + 1) / DsTXTRANS.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End If
End With
Next

Done:
myFrmProgress.Close()

End Sub
Private Sub UpdateTXTRANS(ByVal List As Integer)

	myTXTRANS.GetOneRecordP(List)
	If Not myTXTRANS.RecordNotFound Then
		With myTXTRANS
			._POSTED = "X"
			.UpdateOneRecordP()
		End With
	End If
End Sub
End Module






