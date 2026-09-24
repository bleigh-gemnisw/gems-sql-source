Imports System.Text
Imports System.io
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData

Dim WrkCSV As Boolean
Dim WrkHeadings As Boolean
Dim WrkPublic As Boolean
Dim WrkTrans As Boolean
Dim WrkDistAll As Boolean
Dim WrkDist As Integer
Dim WrkPDist As Boolean
  Public Sub ProcFile()
  myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)

  With MyFrmTA904B
		WrkCSV = .RbCSV.Checked
		WrkHeadings = .ChkHeadings.Checked
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkPDist = .ChkPDist.Checked
		WrkPublic = .ChkPublic.Checked
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
sw = New StreamWriter(MyFrmTA904B.LblFilePath.Text)

myTXSUPPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkHeadings Then
	sw.WriteLine(HeadingsCSV)
End If

ReadNext:
  myTXSUPPQ.ReadQry()
  If Not myTXSUPPQ.IsEOF Then
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
  myTXSUPPQ.CloseFile()
  MsgBox(Format(Counter, "###,###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

End Sub
Private Function DownloadFixed() As String
	Dim sb As StringBuilder

	With myTXSUPPQ
		sb = New StringBuilder
    sb.Append(MyUtils.JustifyLeft(._CAT, 1))
		sb.Append(._MAKE)
		sb.Append(Format(._YEAR, "0000"))
		sb.Append(._MODEL)
		sb.Append(._BODY)
		sb.Append(Format(myTOWN._TOWNBR, "000"))
		sb.Append(._NAME)
		sb.Append(._SNAME)
		sb.Append(._ADD1)
		sb.Append(._ADD2)
		sb.Append(._CITY)
		sb.Append(._STATE)
		sb.Append(Format(._ZIP5, "00000"))
		sb.Append(Format(._ZIP4, "0000"))
		sb.Append(Format(._CLASS, "00"))
		If WrkPublic Then
			sb.Append(._REGNO)
		Else
      sb.Append(MyUtils.JustifyLeft("", 8))
		End If
		sb.Append(._VINNO)
		sb.Append(Format(._CYLAX, "0"))
		sb.Append(._PCLR)
		sb.Append(._SCLR)
		sb.Append(Format(._SEAT, "00"))
		sb.Append(Format(._LWT, "000000"))
		sb.Append(Format(._GWT, "000000"))
		sb.Append(._ASS)
		sb.Append(Format(._CYCLE, "0"))
		sb.Append("0") 'RCODE
		sb.Append("0") 'OCODE
		sb.Append("000") 'RATE
		sb.Append(Format(._LISTNo, "000000"))
		sb.Append(Format(._PCCOD, "00"))
		If WrkPublic Then
			sb.Append(._PREG)
		Else
      sb.Append(MyUtils.JustifyLeft("", 8))
		End If
		sb.Append(Format(._SCAP, "00"))
		sb.Append(Format(._VALUE, "000000000"))
		sb.Append(Format(._PVAL, "000000000"))
		If WrkPublic Then
			sb.Append(Format(._DOB, "00000000"))
		Else
			sb.Append("00000000")
		End If
		sb.Append(Format(._EXCD1, "000"))
		sb.Append(Format(._EXCD2, "000"))
		sb.Append(Format(._EXCD3, "000"))
		sb.Append(Format(._EXCD4, "000"))
		sb.Append(Format(._EXCD5, "000"))
		sb.Append(Format(._EXAM1, "0000000"))
		sb.Append(Format(._EXAM2, "0000000"))
		sb.Append(Format(._EXAM3, "0000000"))
		sb.Append(Format(._EXAM4, "0000000"))
		sb.Append(Format(._EXAM5, "0000000"))
	End With
	Return sb.ToString

End Function
Private Function DownloadCSV() As String
	Dim sb As StringBuilder
	Dim WrkComma As String
	Dim WrkQuote As String

	WrkComma = ","
	WrkQuote = Chr(34)
	With myTXSUPPQ
		sb = New StringBuilder
		sb.Append(WrkQuote)
		sb.Append(Trim(._CAT))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._MAKE))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._YEAR)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._MODEL))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._BODY))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(myTOWN._TOWNBR)
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
		sb.Append(._CLASS)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		If WrkPublic Then
			sb.Append(Trim(._REGNO))
		End If
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._VINNO))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._CYLAX)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._PCLR))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._SCLR))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._SEAT)
		sb.Append(WrkComma)
		sb.Append(._LWT)
		sb.Append(WrkComma)
		sb.Append(._GWT)
		sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(._ASS)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
		sb.Append(._CYCLE)
		sb.Append(WrkComma)
		sb.Append(0) 'RCODE
		sb.Append(WrkComma)
		sb.Append(0) 'OCODE
		sb.Append(WrkComma)
		sb.Append(0) 'RATE
		sb.Append(WrkComma)
		sb.Append(._LISTNo)
		sb.Append(WrkComma)
		sb.Append(._PCCOD)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		If WrkPublic Then
			sb.Append(Trim(._PREG))
		End If
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._SCAP)
		sb.Append(WrkComma)
		sb.Append(._VALUE)
		sb.Append(WrkComma)
		sb.Append(._PVAL)
		sb.Append(WrkComma)
		If WrkPublic Then
			If ._DOB > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._DOB), "M/d/yyyy"))
			Else
				sb.Append(0)
			End If
		Else
			sb.Append(0)
		End If
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
    sb.Append(._OLIST)
    sb.Append(WrkComma)
    sb.Append(._OCLS)
    sb.Append(WrkComma)
    sb.Append(._OYEAR)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._OMAKE))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._OMOD))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If WrkPublic Then
     sb.Append(Trim(._OREGNo))
    End If
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._OVIN))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(._OASS)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(._OVAL)
    sb.Append(WrkComma)
    sb.Append(._OPVAL)
    sb.Append(WrkComma)
    sb.Append(._PNET)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(._LEASE)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(._DIST)
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
	sb.Append("MAKE")
	sb.Append(WrkComma)
	sb.Append("YEAR")
	sb.Append(WrkComma)
	sb.Append("MODEL")
	sb.Append(WrkComma)
	sb.Append("BODY")
	sb.Append(WrkComma)
	sb.Append("TOWN NO")
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
	sb.Append("CLASS")
	sb.Append(WrkComma)
	sb.Append("REG NO")
	sb.Append(WrkComma)
	sb.Append("VIN NO")
	sb.Append(WrkComma)
	sb.Append("CYLINDER AXLE")
	sb.Append(WrkComma)
	sb.Append("PRIMARY COLOR")
	sb.Append(WrkComma)
	sb.Append("SECONDARY COLOR")
	sb.Append(WrkComma)
	sb.Append("SEATING CAPACITY")
	sb.Append(WrkComma)
	sb.Append("LIGHT WEIGHT")
	sb.Append(WrkComma)
	sb.Append("GROSS WEIGHT")
	sb.Append(WrkComma)
	sb.Append("ASSESSMENT CODE")
	sb.Append(WrkComma)
	sb.Append("CYCLE CODE")
	sb.Append(WrkComma)
	sb.Append("ROUNDING CODE")
	sb.Append(WrkComma)
	sb.Append("OUTPUT CODE")
	sb.Append(WrkComma)
	sb.Append("PERC OF ASSESS")
	sb.Append(WrkComma)
	sb.Append("LIST NO")
	sb.Append(WrkComma)
	sb.Append("PREVIOUS CLASS")
	sb.Append(WrkComma)
	sb.Append("PREVIOUS REGNO")
	sb.Append(WrkComma)
	sb.Append("STANDING CAPACITY")
	sb.Append(WrkComma)
	sb.Append("VALUE")
	sb.Append(WrkComma)
	sb.Append("PREVIOUS VALUE")
	sb.Append(WrkComma)
	sb.Append("DOB")
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
  sb.Append("CR LIST NO")
  sb.Append(WrkComma)
  sb.Append("CR CLASS")
  sb.Append(WrkComma)
  sb.Append("CR YEAR")
  sb.Append(WrkComma)
  sb.Append("CR MAKE")
  sb.Append(WrkComma)
  sb.Append("CR MODEL")
  sb.Append(WrkComma)
  sb.Append("CR REG NO")
  sb.Append(WrkComma)
  sb.Append("CR VIN NO")
  sb.Append(WrkComma)
  sb.Append("CR ASSESSMENT CODE")
  sb.Append(WrkComma)
  sb.Append("CR VALUE")
  sb.Append(WrkComma)
  sb.Append("CR PRORATED VALUE")
  sb.Append(WrkComma)
  sb.Append("PRORATED NET")
  sb.Append(WrkComma)
  sb.Append("LEASE CODE")
  sb.Append(WrkComma)
  sb.Append("DISTRICT")
  Return sb.ToString
End Function
End Module






