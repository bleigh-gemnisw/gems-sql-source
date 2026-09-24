Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXCOOQ As TXCOOQ.MyData
Dim myTXCOO As TXCOO.myData
Dim myTXREALC As TXREALC.myData
Dim myTXPROMS As TXPROMS.myData

Dim ds As DataSet = New DataSet
Dim DsTXCOO As DataSet = New DataSet
Dim dr As Data.DataRow
	Public Sub PrtReport()

	myTXCOOQ = New TXCOOQ.mydata(MyDBConnect)
	myTXCOO = New TXCOO.mydata(MyDBConnect)
	myTXREALC = New TXREALC.mydata(MyDBConnect)
	myTXPROMS = New TXPROMS.mydata(MyDBConnect)

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.wrkds = ds
	MyCrViewer.Show()

	End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("COType", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("ProrateAmt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkAmt As Double
Dim WrkProPct As Decimal

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "PFLAG = ' '"

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
        dr.Item("cotype") = .Item("pcd")
        dr.Item("listno") = .Item("list#")
        dr.Item("name") = .Item("conam")
        dr.Item("addr") = .Item("coadd1")
        dr.Item("city") = .Item("cocity")
        If .Item("pcd") = "E" Then
          WrkProPct = 1 - .Item("pct")
          WrkAmt = .Item("benamt") * WrkProPct
          dr.Item("prorateamt") = WrkAmt
        Else
          If .Item("benamt") = 0 Then
            dr.Item("prorateamt") = .Item("pinc")
          Else
            dr.Item("prorateamt") = .Item("benamt") - .Item("pinc")
          End If
        End If
        'Write TXPROMS
        myTXPROMS.GetOneRecordP(.Item("list#"))
        With myTXPROMS
          myTXREALC.GetOneRecordP(DsTXCOO.Tables(0).Rows(I).Item("rlist"))
          If myTXREALC.RecordNotFound Then
            myTXREALC.GetOneRecordP(DsTXCOO.Tables(0).Rows(I).Item("list#"))
          End If
          ._LISTNo = DsTXCOO.Tables(0).Rows(I).Item("list#")
          ._RLIST = DsTXCOO.Tables(0).Rows(I).Item("rlist")
          ._CAT = "1"
          ._NAME = DsTXCOO.Tables(0).Rows(I).Item("conam")
          If Trim(DsTXCOO.Tables(0).Rows(I).Item("conam")) = Trim(myTXREALC._NAME) Then
            ._SNAME = DsTXCOO.Tables(0).Rows(I).Item("conam2")
          Else
            If My2NDNO Then
              ._SNAME = Mid(DsTXCOO.Tables(0).Rows(I).Item("conam"), 1, 31) & " N/O"
            Else
              ._SNAME = "N/O " & Mid(DsTXCOO.Tables(0).Rows(I).Item("conam"), 1, 31)
            End If
          End If
          ._ADD1 = DsTXCOO.Tables(0).Rows(I).Item("coadd1")
          ._ADD2 = DsTXCOO.Tables(0).Rows(I).Item("coadd2")
          ._CITY = DsTXCOO.Tables(0).Rows(I).Item("cocity")
          ._STATE = DsTXCOO.Tables(0).Rows(I).Item("coste")
          ._ZIP5 = DsTXCOO.Tables(0).Rows(I).Item("cozip5")
          ._ZIP4 = DsTXCOO.Tables(0).Rows(I).Item("cozip4")
          ._COTYPE = DsTXCOO.Tables(0).Rows(I).Item("pcd")
          ._LETT = DsTXCOO.Tables(0).Rows(I).Item("lett")
          ._PRF = Mid(MyUserID, 1, 10)
          ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
          ._CHTIME = Format(DateTime.Now, "hhmmss")
          ._MAP = myTXREALC._MAP
          ._VOL = myTXREALC._VOL
          ._XPAGE = myTXREALC._PGE
          ._SURV = myTXREALC._SMAP
          ._LOCNo = myTXREALC._LOCNO
          ._LOC = myTXREALC._LOC
          If DsTXCOO.Tables(0).Rows(I).Item("pcd") = "E" Then
            WrkProPct = 1 - DsTXCOO.Tables(0).Rows(I).Item("pct")
            WrkAmt = DsTXCOO.Tables(0).Rows(I).Item("amt") * WrkProPct
            ._GROSS = WrkAmt
            ._TEX = 0
            ._NET = WrkAmt
          Else
            ._GROSS = dr.Item("prorateamt")
            ._TEX = 0
            ._NET = dr.Item("prorateamt")
          End If
        End With
        If myTXPROMS.RecordNotFound Then
          myTXPROMS.AddOneRecordP()
        Else
          myTXPROMS.UpdateOneRecordP()
        End If
        UpdateTxCOO(.Item("list#"), .Item("devlt"))
  End With
  ds.Tables(0).Rows.Add(dr)
NextRec:
With myFrmProgress
  If DsTXCOO.Tables(0).Rows.Count > 1 Then
    WrkPct = ((I + 1) / DsTXCOO.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End If
End With
Next

myFrmProgress.Close()
myTXCOOQ.CloseFile()
myTXCOO.CloseFile()
myTXREALC.CloseFile()
myTXPROMS.CloseFile()

End Sub
Private Sub UpdateTxCOO(ByVal List As Integer, ByVal DevLt As String)
	myTXCOO.GetOneRecordP(List, DevLt)
	If Not myTXCOO.RecordNotFound Then
		With myTXCOO
			._PFLAG = "P"
			.UpdateOneRecordP()
		End With
	End If
End Sub
End Module






