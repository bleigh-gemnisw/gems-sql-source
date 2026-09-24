Imports System.Text
Imports System.io
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData

Dim WrkCSV As Boolean
Dim WrkAll As Boolean
Dim WrkHeadings As Boolean
Dim WrkPublic As Boolean
Dim WrkTrans As Boolean
Dim WrkDistAll As Boolean
Dim WrkDist As Integer
Dim WrkPDist As Boolean
	Public Sub ProcFile()
	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

	With MyFrmTA903B
		WrkCSV = .RbCSV.Checked
    WrkAll = .ChkAll.Checked
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

sw = New StreamWriter(MyFrmTA903B.LblFilePath.Text)

myTXMVDQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkHeadings Then
	sw.WriteLine(HeadingsCSV)
End If

ReadNext:
	myTXMVDQ.ReadQry()
	If Not myTXMVDQ.IsEOF Then
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
	myTXMVDQ.CloseFile()
	MsgBox(Format(Counter, "###,###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

End Sub
Private Function DownloadFixed() As String
	Dim sb As StringBuilder

	With myTXMVDQ
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
	With myTXMVDQ
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
		sb.Append(._ASS)
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
    sb.Append(WrkQuote)
    sb.Append(Trim(._RAD1))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._RAD2))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._RCTY))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Trim(._RST))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Format(._RZ5, "00000"))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Format(._RZ4, "0000"))
    sb.Append(WrkQuote)
    If WrkAll Then
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BTC))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._BTR)
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
      If ._CHDATE > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._CHDATE), "M/d/yyyy"))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(._CHTIME)
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
      sb.Append(WrkQuote)
      sb.Append(Trim(._LETT))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._OID))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._PRF))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._SSNo)
      sb.Append(WrkComma)
      sb.Append(._SS2)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._TIN))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._TYPE))
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
  sb.Append("RESIDENTIAL ADDRESS 1")
  sb.Append(WrkComma)
  sb.Append("RESIDENTIAL ADDRESS 2")
  sb.Append(WrkComma)
  sb.Append("RESIDENTIAL CITY")
  sb.Append(WrkComma)
  sb.Append("RESIDENTIAL STATE")
  sb.Append(WrkComma)
  sb.Append("RESIDENTIAL ZIP CODE")
  sb.Append(WrkComma)
  sb.Append("RESIDENTIAL ZIP 4")
  'Rest of fields in file
  If WrkAll Then
    sb.Append(WrkComma)
    sb.Append("BACK TAX")
    sb.Append(WrkComma)
    sb.Append("BTR")
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
    sb.Append("CHANGE DATE")
    sb.Append(WrkComma)
    sb.Append("CHANGE TIME")
    sb.Append(WrkComma)
    sb.Append("BTR DENIED?")
    sb.Append(WrkComma)
    sb.Append("BTR DATE")
    sb.Append(WrkComma)
    sb.Append("LETTER")
    sb.Append(WrkComma)
    sb.Append("VEHICLE ID")
    sb.Append(WrkComma)
    sb.Append("USERID")
    sb.Append(WrkComma)
    sb.Append("PRIMARY CUSTID")
    sb.Append(WrkComma)
    sb.Append("SECONDARY CUSTID")
    sb.Append(WrkComma)
    sb.Append("TIN")
    sb.Append(WrkComma)
    sb.Append("TAX TYPE")
  End If
  Return sb.ToString
End Function
End Module






