Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXSUPP As TXSupp.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen fields
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXSUPP = New TXSupp.mydata(MyDBConnect)

  With MyFrmTA504B
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
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim WrkAnd As String
Dim WrkOr As String

If myDBConnect.ServerName = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

WrkSort = "NAME"
WrkQry = "ASS='K'" & WrkOr & "Ass='L'"

	myTXSUPPQ.OpenQry(WrkSort, WrkQry)
	myFrmProgress = New FrmProgress
	myFrmProgress.Show()
	myFrmProgress.Refresh()
	Application.DoEvents()

ReadNext:
	myTXSUPPQ.ReadQry()
	If Not myTXSUPPQ.IsEOF Then
	With myTXSUPPQ
		Counter = Counter + 1
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("name") = Trim(._NAME)
    dr.Item("code") = ._ASS
    ds.Tables(0).Rows.Add(dr)

    If WrkPost Then
      UpdateTXSUPP(._LISTNo, "A")
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
myTXSUPPQ.CloseFile()
myTXSUPP.CloseFile()

End Sub
Private Sub UpdateTXSUPP(ByVal List As Integer, ByVal Code As String)

	myTXSUPP.GetOneRecordP(List)
	If Not myTXSUPP.RecordNotFound Then
		With myTXSUPP
			._ASS = Code
			.UpdateOneRecordP()
		End With
	End If
End Sub
End Module






