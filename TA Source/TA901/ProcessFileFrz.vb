Imports System.Text
Imports System.io
Module ProcessFileFrz

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.myData

Dim WrkCSV As Boolean
Dim WrkAll As Boolean
Dim WrkHeadings As Boolean
Dim WrkNoAssmnt As Boolean
Dim WrkDistAll As Boolean
Dim WrkDist As Integer
Dim WrkPDist As Boolean
	Public Sub ProcFileFrz()
	myTXREALCQ = New TXREALCQ.myData(myDBConnect)

	With MyFrmTA901B
		WrkCSV = .RbCSV.Checked
    WrkAll = .ChkAll.Checked
    WrkHeadings = .ChkHeadings.Checked
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkPDist = .ChkPDist.Checked
		WrkNoAssmnt = .ChkNoAssmnt.Checked
	End With

 GetDetail()
End Sub
Private Sub GetDetail()
Dim sw As StreamWriter
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer

WrkQry = ""
If Not WrkDistAll Then
  If WrkPDist Then
    WrkQry = "pdst=" & WrkDist
  Else
    WrkQry = "dist=" & WrkDist
  End If
End If
WrkSort = ""
Counter = 0
sw = New StreamWriter(MyFrmTA901B.LblFilePath.Text)

myTXREALCQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkHeadings Then
	sw.WriteLine(HeadingsCSV)
End If

ReadNext:
	myTXREALCQ.ReadQry()

	If Not myTXREALCQ.IsEOF Then
		If WrkCSV Then
			sw.WriteLine(DownloadCSV)
		Else
			sw.WriteLine(DownloadFixed)
		End If
		Counter = Counter + 1

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

	sw.Close()
	myFrmProgress.Close()
	myTXREALCQ.CloseFile()
	MsgBox(Format(Counter, "###,###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

End Sub
Private Function DownloadFixed() As String
	Dim sb As StringBuilder
	Dim WrkInteger As Integer

	With myTXREALCQ
		If WrkNoAssmnt Then
			._ASS1 = 0
			._ASS2 = 0
			._ASS3 = 0
			._ASS4 = 0
			._ASS5 = 0
			._ASS6 = 0
			._ASS7 = 0
			._EXAM1 = 0
			._EXAM2 = 0
			._EXAM3 = 0
			._EXAM4 = 0
			._EXAM5 = 0
			._EXAM6 = 0
			._EXAM7 = 0
			._CPERC = 0
			._CMIN = 0
			._NET = 0
			._FTAX = 0
			._GROSS = 0
			._PURPR = 0
		End If
		sb = New StringBuilder
    sb.Append(MyUtils.JustifyLeft(._CAT, 1))
		sb.Append(Format(._LISTNO, "000000"))
		sb.Append(._NAME)
		sb.Append(._SNAME)
		sb.Append(._ADD1)
		sb.Append(._ADD2)
		sb.Append(._CITY)
		sb.Append(._STATE)
		sb.Append(Format(._ZIP5, "00000"))
		sb.Append(Format(._ZIP4, "0000"))
		sb.Append(._LOC)
		sb.Append(._LOCNO)
		sb.Append(._VOL)
		sb.Append(._PGE)
		sb.Append(._MAP)
		sb.Append(._UNITNO)
		sb.Append(Format(._GROSS, "000000000"))
		sb.Append(Format(._ASS1, "000000000"))
		sb.Append(Format(._ASS2, "000000000"))
		sb.Append(Format(._ASS3, "000000000"))
		sb.Append(Format(._ASS4, "000000000"))
		sb.Append(Format(._ASS5, "000000000"))
		sb.Append(Format(._ASS6, "000000000"))
		sb.Append(Format(._ASS7, "000000000"))
		sb.Append(Format(._NET, "000000000"))
		If WrkPDist Then
			sb.Append(Format(._PDST, "000"))
		Else
			sb.Append(Format(._DIST, "000"))
		End If
		sb.Append("00")	'PYear
		sb.Append(Format(._CENTR, "0000000"))
		sb.Append(Format(._PURPR, "000000000"))
		sb.Append(Format(._CODE1, "000"))
		sb.Append(Format(._CODE2, "000"))
		sb.Append(Format(._CODE3, "000"))
		sb.Append(Format(._CODE4, "000"))
		sb.Append(Format(._CODE5, "000"))
		sb.Append(Format(._CODE6, "000"))
		sb.Append(Format(._PURDT, "00000000"))
		sb.Append(Format(._UNIT1, "000"))
		sb.Append(Format(._UNIT2, "000"))
		sb.Append(Format(._UNIT3, "000"))
		sb.Append(Format(._UNIT4, "000"))
		sb.Append(Format(._UNIT5, "000"))
		sb.Append(Format(._UNIT6, "000"))
		sb.Append(Format(._UNIT7, "000"))
		sb.Append(._FCCOD)
		sb.Append(Format(Val(Mid(._FCYR, 3, 2)), "00"))
		WrkInteger = ._CPERC * 100
		sb.Append(Format(WrkInteger, "000"))
		WrkInteger = ._FTAX * 100
		sb.Append(Format(WrkInteger, "0000000"))
		WrkInteger = ._CMIN * 100
		sb.Append(Format(WrkInteger, "00000"))
		sb.Append(Format(._EXCD1, "000"))
		sb.Append(Format(._EXCD2, "000"))
		sb.Append(Format(._EXCD3, "000"))
		sb.Append(Format(._EXCD4, "000"))
		sb.Append(Format(._EXCD5, "000"))
		sb.Append(Format(._EXCD6, "000"))
		sb.Append(Format(._EXCD7, "000"))
		sb.Append(Format(._EXAM1, "0000000"))
		sb.Append(Format(._EXAM2, "0000000"))
		sb.Append(Format(._EXAM3, "0000000"))
		sb.Append(Format(._EXAM4, "0000000"))
		sb.Append(Format(._EXAM5, "0000000"))
		sb.Append(Format(._EXAM6, "0000000"))
		sb.Append(Format(._EXAM7, "0000000"))
		sb.Append(._EXMPT)
    WrkInteger = ._ACRE1 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE2 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE3 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE4 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE5 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE6 * 100
    sb.Append(Format(WrkInteger, "0000000"))
    WrkInteger = ._ACRE7 * 100
    sb.Append(Format(WrkInteger, "0000000"))
 End With
	Return sb.ToString
End Function
Private Function DownloadCSV() As String
	Dim sb As StringBuilder
	Dim WrkComma As String
	Dim WrkQuote As String

	WrkComma = ","
	WrkQuote = Chr(34)

	With myTXREALCQ
		If WrkNoAssmnt Then
			._ASS1 = 0
			._ASS2 = 0
			._ASS3 = 0
			._ASS4 = 0
			._ASS5 = 0
			._ASS6 = 0
			._ASS7 = 0
			._EXAM1 = 0
			._EXAM2 = 0
			._EXAM3 = 0
			._EXAM4 = 0
			._EXAM5 = 0
			._EXAM6 = 0
			._EXAM7 = 0
			._CPERC = 0
			._CMIN = 0
			._NET = 0
			._FTAX = 0
			._GROSS = 0
			._PURPR = 0
		End If
		sb = New StringBuilder
		sb.Append(WrkQuote)
		sb.Append(Trim(._CAT))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._LISTNO)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._NAME))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._SNAME))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._ADD1))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._ADD2))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._CITY))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._STATE))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Format(._ZIP5, "00000"))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Format(._ZIP4, "0000"))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._LOC))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._LOCNO))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._VOL))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._PGE))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._MAP))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._UNITNO))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._GROSS)
		sb.Append(WrkComma)
		sb.Append(._ASS1)
		sb.Append(WrkComma)
		sb.Append(._ASS2)
		sb.Append(WrkComma)
		sb.Append(._ASS3)
		sb.Append(WrkComma)
		sb.Append(._ASS4)
		sb.Append(WrkComma)
		sb.Append(._ASS5)
		sb.Append(WrkComma)
		sb.Append(._ASS6)
		sb.Append(WrkComma)
		sb.Append(._ASS7)
		sb.Append(WrkComma)
		sb.Append(._NET)
		sb.Append(WrkComma)
		If WrkPDist Then
			sb.Append(._PDST)
		Else
			sb.Append(._DIST)
		End If
		sb.Append(WrkComma)
		sb.Append(0)	'PYear
		sb.Append(WrkComma)
		sb.Append(._CENTR)
		sb.Append(WrkComma)
		sb.Append(._PURPR)
		sb.Append(WrkComma)
		sb.Append(._CODE1)
		sb.Append(WrkComma)
		sb.Append(._CODE2)
		sb.Append(WrkComma)
		sb.Append(._CODE3)
		sb.Append(WrkComma)
		sb.Append(._CODE4)
		sb.Append(WrkComma)
		sb.Append(._CODE5)
		sb.Append(WrkComma)
		sb.Append(._CODE6)
		sb.Append(WrkComma)
		If ._PURDT > 0 Then
      sb.Append(Format(MyUtils.GetDBDate(._PURDT), "M/d/yyyy"))
		Else
			sb.Append(0)
		End If
		sb.Append(WrkComma)
		sb.Append(._UNIT1)
		sb.Append(WrkComma)
		sb.Append(._UNIT2)
		sb.Append(WrkComma)
		sb.Append(._UNIT3)
		sb.Append(WrkComma)
		sb.Append(._UNIT4)
		sb.Append(WrkComma)
		sb.Append(._UNIT5)
		sb.Append(WrkComma)
		sb.Append(._UNIT6)
		sb.Append(WrkComma)
		sb.Append(._UNIT7)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._FCCOD))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(Val(Mid(._FCYR, 3, 2)))
		sb.Append(WrkComma)
		sb.Append(._CPERC)
		sb.Append(WrkComma)
		sb.Append(._FTAX)
		sb.Append(WrkComma)
		sb.Append(._CMIN)
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD1))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD2))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD3))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD4))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD5))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD6))
		sb.Append(WrkComma)
		sb.Append(Trim(._EXCD7))
		sb.Append(WrkComma)
		sb.Append(._EXAM1)
		sb.Append(WrkComma)
		sb.Append(._EXAM2)
		sb.Append(WrkComma)
		sb.Append(._EXAM3)
		sb.Append(WrkComma)
		sb.Append(._EXAM4)
		sb.Append(WrkComma)
		sb.Append(._EXAM5)
		sb.Append(WrkComma)
		sb.Append(._EXAM6)
		sb.Append(WrkComma)
		sb.Append(._EXAM7)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._EXMPT))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._ACRE1)
		sb.Append(WrkComma)
		sb.Append(._ACRE2)
		sb.Append(WrkComma)
		sb.Append(._ACRE3)
		sb.Append(WrkComma)
		sb.Append(._ACRE4)
		sb.Append(WrkComma)
		sb.Append(._ACRE5)
		sb.Append(WrkComma)
		sb.Append(._ACRE6)
		sb.Append(WrkComma)
		sb.Append(._ACRE7)
      'Rest of fields in file
    If WrkAll Then
      sb.Append(WrkComma)
      sb.Append(._AACRE)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._ACCTN))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._AEDATE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._AEDATE), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      If ._AIDTE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._AIDTE), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BKCD))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BKSV))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BTC))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._BTR)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CARD))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._CASS1)
      sb.Append(WrkComma)
      sb.Append(._CASS2)
      sb.Append(WrkComma)
      sb.Append(._CASS3)
      sb.Append(WrkComma)
      sb.Append(._CASS4)
      sb.Append(WrkComma)
      sb.Append(._CASS5)
      sb.Append(WrkComma)
      sb.Append(._CASS6)
      sb.Append(WrkComma)
      sb.Append(._CASS7)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD1))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD3))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD4))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD5))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD6))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCCD7))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._CCEX)
      sb.Append(WrkComma)
      sb.Append(._CCGRS)
      sb.Append(WrkComma)
      sb.Append(._CCNO)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CCRS))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._CDATE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._CDATE), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(._CENBK)
      sb.Append(WrkComma)
      sb.Append(._CEXA1)
      sb.Append(WrkComma)
      sb.Append(._CEXA2)
      sb.Append(WrkComma)
      sb.Append(._CEXA3)
      sb.Append(WrkComma)
      sb.Append(._CEXA4)
      sb.Append(WrkComma)
      sb.Append(._CEXA5)
      sb.Append(WrkComma)
      sb.Append(._CEXA6)
      sb.Append(WrkComma)
      sb.Append(._CEXA7)
      sb.Append(WrkComma)
      If ._CHDATE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._CHDATE), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(._CHTIME)
      sb.Append(WrkComma)
      sb.Append(._CIRAD)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DNBTR))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._DTBTR > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._DTBTR), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(._FASS)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LETT))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._OID))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._PERC)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._PRF))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._RLST)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._SEWER))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._SMAP))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._SSNO)
      sb.Append(WrkComma)
      sb.Append(._SS2)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._TIN))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._TWNBN)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._TYPE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._VTYR)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._WMAIL))
      sb.Append(WrkQuote)
    End If
End With
	Return sb.ToString
End Function
Private Function HeadingsCSV() As String
	Dim sb As StringBuilder
	Dim WrkComma As String

	WrkComma = ","
	sb = New StringBuilder
	sb.Append("CATEGORY")
	sb.Append(WrkComma)
	sb.Append("LIST NO")
	sb.Append(WrkComma)
	sb.Append("NAME")
	sb.Append(WrkComma)
	sb.Append("SECOND NAME")
	sb.Append(WrkComma)
	sb.Append("ADDRESS 1")
	sb.Append(WrkComma)
	sb.Append("ADDRESS 2")
	sb.Append(WrkComma)
	sb.Append("CITY")
	sb.Append(WrkComma)
	sb.Append("STATE")
	sb.Append(WrkComma)
	sb.Append("ZIP CODE")
	sb.Append(WrkComma)
	sb.Append("ZIP 4")
	sb.Append(WrkComma)
	sb.Append("LOCATION NAME")
	sb.Append(WrkComma)
	sb.Append("LOCATION #")
	sb.Append(WrkComma)
	sb.Append("VOLUME")
	sb.Append(WrkComma)
	sb.Append("PAGE")
	sb.Append(WrkComma)
	sb.Append("MAP/LOT")
	sb.Append(WrkComma)
	sb.Append("UNIT NO")
	sb.Append(WrkComma)
	sb.Append("GROSS ASSESSMENT")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 1")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 2")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 3")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 4")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 5")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 6")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT 7")
	sb.Append(WrkComma)
	sb.Append("NET ASSESSMENT")
	sb.Append(WrkComma)
	sb.Append("DISTRICT")
	sb.Append(WrkComma)
	sb.Append("PYEAR (Not used)")
	sb.Append(WrkComma)
	sb.Append("CENSUS TRACT")
	sb.Append(WrkComma)
	sb.Append("PURCHASE PRICE")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 1")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 2")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 3")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 4")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 5")
	sb.Append(WrkComma)
	sb.Append("PROPERTY CODE 6")
	sb.Append(WrkComma)
	sb.Append("PURCHASE DATE")
	sb.Append(WrkComma)
	sb.Append("UNIT 1")
	sb.Append(WrkComma)
	sb.Append("UNIT 2")
	sb.Append(WrkComma)
	sb.Append("UNIT 3")
	sb.Append(WrkComma)
	sb.Append("UNIT 4")
	sb.Append(WrkComma)
	sb.Append("UNIT 5")
	sb.Append(WrkComma)
	sb.Append("UNIT 6")
	sb.Append(WrkComma)
	sb.Append("UNIT 7")
	sb.Append(WrkComma)
	sb.Append("ELDERLY CODE F/C")
	sb.Append(WrkComma)
	sb.Append("ELDERLY YEAR")
	sb.Append(WrkComma)
	sb.Append("CIRCUIT PERC")
	sb.Append(WrkComma)
	sb.Append("FROZEN TAX/BENEFIT")
	sb.Append(WrkComma)
	sb.Append("CIRCUIT MIN")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 1")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 2")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 3")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 4")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 5")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 6")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION CODE 7")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 1")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 2")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 3")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 4")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 5")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 6")
	sb.Append(WrkComma)
	sb.Append("EXEMPTION AMOUNT 7")
	sb.Append(WrkComma)
	sb.Append("EXEMPT CODE")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 1")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 2")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 3")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 4")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 5")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 6")
	sb.Append(WrkComma)
	sb.Append("ACREAGE 7")
  'Rest of fields in file
  If WrkAll Then
    sb.Append(WrkComma)
    sb.Append("ACRES CLASSIFICATION")
    sb.Append(WrkComma)
    sb.Append("ESCROW ACCOUNT")
    sb.Append(WrkComma)
    sb.Append("EXPIRATION DATE")
    sb.Append(WrkComma)
    sb.Append("ACQUIRED DATE")
    sb.Append(WrkComma)
    sb.Append("BANK CODE")
    sb.Append(WrkComma)
    sb.Append("BANK SERVICE")
    sb.Append(WrkComma)
    sb.Append("BACK TAX")
    sb.Append(WrkComma)
    sb.Append("BTR")
    sb.Append(WrkComma)
    sb.Append("PRINT PROPERTY CARD?")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 1")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 2")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 3")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 4")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 5")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 6")
    sb.Append(WrkComma)
    sb.Append("C/C ASSESSMENT 7")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 1")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 2")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 3")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 4")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 5")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 6")
    sb.Append(WrkComma)
    sb.Append("C/C CODE 7")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION")
    sb.Append(WrkComma)
    sb.Append("C/C GROSS")
    sb.Append(WrkComma)
    sb.Append("C/C NO")
    sb.Append(WrkComma)
    sb.Append("C/C REASON")
    sb.Append(WrkComma)
    sb.Append("C/C DATE")
    sb.Append(WrkComma)
    sb.Append("CENSUS BLOCK")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 1")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 2")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 3")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 4")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 5")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 6")
    sb.Append(WrkComma)
    sb.Append("C/C EXEMPTION AMOUNT 7")
    sb.Append(WrkComma)
    sb.Append("CHANGE DATE")
    sb.Append(WrkComma)
    sb.Append("CHANGE TIME")
    sb.Append(WrkComma)
    sb.Append("ELDERLY ADJUSTMENT")
    sb.Append(WrkComma)
    sb.Append("BTR DENIED?")
    sb.Append(WrkComma)
    sb.Append("BTR DATE")
    sb.Append(WrkComma)
    sb.Append("FROZEN ASSESSMENT")
    sb.Append(WrkComma)
    sb.Append("LETTER")
    sb.Append(WrkComma)
    sb.Append("VEHICLE ID")
    sb.Append(WrkComma)
    sb.Append("PERCENTAGE OWNERSHIP")
    sb.Append(WrkComma)
    sb.Append("USERID")
    sb.Append(WrkComma)
    sb.Append("REFERENCE LIST NO")
    sb.Append(WrkComma)
    sb.Append("SEWER?")
    sb.Append(WrkComma)
    sb.Append("SURVEY MAP")
    sb.Append(WrkComma)
    sb.Append("DMV PRIMARY CUSTID")
    sb.Append(WrkComma)
    sb.Append("DMV SECONDARY CUSTID")
    sb.Append(WrkComma)
    sb.Append("TIN")
    sb.Append(WrkComma)
    sb.Append("TOWN BENEFIT")
    sb.Append(WrkComma)
    sb.Append("TAX TYPE")
    sb.Append(WrkComma)
    sb.Append("VETRAN YEAR")
    sb.Append(WrkComma)
    sb.Append("MAIL WHERE")
  End If
  Return sb.ToString
End Function
End Module
