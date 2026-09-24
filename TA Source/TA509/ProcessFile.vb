Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXMVDC As TXMVDCL1.myData

Dim ds As DataSet = New DataSet
Dim DsTXSUPPQ As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkClass As Integer
Dim WrkMake As String
	Public Function BuildFile(ByVal Process As Boolean) As DataSet

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXMVDC = New TXMVDCL1.mydata(MyDBConnect)

	With MyFrmTA509B
    WrkClass = MyUtils.CnvSng(.TxtFindClass.Text)
		WrkMake = .TxtFindMake.Text
	End With

	If Not Process Then
		BuildDS(ds)
	Else
		ds.Clear()
		GetDetail()
	End If

	Return ds

	End Function
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAnd As String
Dim WrkOr As String
Dim Counter As Integer

WrkSort = "CLASS, MAKE, YEAR, VINNO, MODEL"

If myDBConnect.ServerAS400 Then
	WrkAnd = " *and "
	WrkOr = " *or "
Else
	WrkAnd = " and "
	WrkOr = " or "
End If

WrkQry = "CAT = '1'" & WrkAnd & "VALUE=0"
If WrkClass > 0 Then
	WrkQry = WrkQry & WrkAnd & "CLASS=" & WrkClass
End If
If WrkMake <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "MAKE=" & MyUtils.Quo(WrkMake)
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
			 dr.Item("class") = ._CLASS
			 dr.Item("year") = ._YEAR
			 dr.Item("make") = Trim(._MAKE)
			 dr.Item("model") = Trim(._MODEL)
			 dr.Item("body") = Trim(._BODY)
			 dr.Item("idno") = Trim(._VINNO)
			 dr.Item("nada") = Trim(._NADA)
				'MK 7/21/25 Begin
				'dr.Item("loanval") = ._LNVAL
				'dr.Item("tradeval") = ._TRVAL
				'MK 7/21/25 End
				dr.Item("msrp") = ._MSRP
				dr.Item("lastyrval") = 0
				myTXMVDC.GetOneRecordP(Trim(._VINNO))
				If Not myTXMVDC.RecordNotFound Then
					With myTXMVDC
						If ._CCNO > 0 Then
							dr.Item("lastyrval") = ._CCGRS
						Else
							dr.Item("lastyrval") = ._VALUE
						End If
					End With
				End If
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






