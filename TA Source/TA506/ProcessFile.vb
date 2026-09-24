Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkClass As Integer
Dim WrkMake As String
  Public Function BuildFile() As DataSet

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)

  With MyFrmTA506B
    WrkClass = MyUtils.CnvSng(.TxtFindClass.Text)
		WrkMake = .TxtFindMake.Text
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()
  Return ds

  End Function
Private Sub BuildDS()
    Dim myTable As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAnd As String
Dim WrkOr As String

Dim Counter As Integer
WrkSort = "MAKE, YEAR, MODEL, CLASS"

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "CAT = '1'" & WrkAnd & "ASS>'M'" & WrkAnd & "OVAL=0"
If WrkClass > 0 Then
  WrkQry = WrkQry & WrkAnd & "OCLS=" & WrkClass
End If
If WrkMake <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "OMAKE=" & MyUtils.Quo(WrkMake)
End If

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
			dr.Item("Oname") = Trim(._NAME)
			dr.Item("class") = ._OCLS
			dr.Item("year") = ._OYEAR
			dr.Item("make") = Trim(._OMAKE)
			dr.Item("model") = Trim(._OMOD)
			dr.Item("idno") = Trim(._OVIN)
			ds.Tables(0).Rows.Add(dr)
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

End Sub
End Module






