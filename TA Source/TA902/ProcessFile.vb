Imports System.Text
Imports System.io
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXDCPP As TXDCPP.myData
Dim myTXBUSTY As TXBUSTY.myData

Dim WrkCSV As Boolean
Dim WrkAll As Boolean
Dim WrkHeadings As Boolean
Dim WrkNoAssmnt As Boolean
Dim WrkTrans As Boolean
Dim WrkDistAll As Boolean
Dim WrkDist As Integer
Dim WrkPDist As Boolean
Dim WrkYear As Integer
  Public Sub ProcFile()
  myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
  myTXDCPP = New TXDCPP.mydata(MyDBConnect)
  myTXBUSTY = New TXBUSTY.mydata(MyDBConnect)

  With MyFrmTA902B
    WrkCSV = .RbCSV.Checked
    WrkAll = .ChkAll.Checked
    WrkHeadings = .ChkHeadings.Checked
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkPDist = .ChkPDist.Checked
    WrkNoAssmnt = .ChkNoAssmnt.Checked
    WrkYear = MyUtils.CnvSng(.TxtYear.Text)
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
sw = New StreamWriter(MyFrmTA902B.LblFilePath.Text)

myTXPPRPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkHeadings Then
  sw.WriteLine(HeadingsCSV(WrkAll))
End If

ReadNext:
  myTXPPRPQ.ReadQry()
  If Not myTXPPRPQ.IsEOF Then
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
  myTXPPRPQ.CloseFile()
  MsgBox(Format(Counter, "###,###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

End Sub
Private Function DownloadFixed() As String
	Dim sb As StringBuilder
	Dim WrkInteger As Integer

	With myTXPPRPQ
		If WrkNoAssmnt Then
			._ASS1 = 0
			._ASS2 = 0
			._ASS3 = 0
			._ASS4 = 0
			._ASS5 = 0
			._ASS6 = 0
			._ASS7 = 0
			._ASS8 = 0
			._ASS9 = 0
			._ASS10 = 0
			._EXAM1 = 0
			._EXAM2 = 0
			._EXAM3 = 0
			._EXAM4 = 0
			._EXAM5 = 0
			._NET = 0
			._GROSS = 0
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
		sb.Append(._LOCNO)
		sb.Append(._LOC)
		sb.Append(Format(._GROSS, "000000000"))
		sb.Append(Format(._NET, "000000000"))
		sb.Append(Format(._ASS1, "000000000"))
		sb.Append(Format(._ASS2, "000000000"))
		sb.Append(Format(._ASS3, "000000000"))
		sb.Append(Format(._ASS4, "000000000"))
		sb.Append(Format(._ASS5, "000000000"))
		sb.Append(Format(._ASS6, "000000000"))
		sb.Append(Format(._ASS7, "000000000"))
		sb.Append(Format(._ASS8, "000000000"))
		sb.Append(Format(._ASS9, "000000000"))
		sb.Append(Format(._ASS10, "000000000"))
		sb.Append(Format(._CODE1, "000"))
		sb.Append(Format(._CODE2, "000"))
		sb.Append(Format(._CODE3, "000"))
		sb.Append(Format(._CODE4, "000"))
		sb.Append(Format(._CODE5, "000"))
		sb.Append(Format(._CODE6, "000"))
		sb.Append(Format(._CODE7, "000"))
		sb.Append(Format(._CODE8, "000"))
		sb.Append(Format(._CODE9, "000"))
		sb.Append(Format(._CODEA, "000"))
		sb.Append(Format(._UNIT1, "000"))
		sb.Append(Format(._UNIT2, "000"))
		sb.Append(Format(._UNIT3, "000"))
		sb.Append(Format(._UNIT4, "000"))
		sb.Append(Format(._UNIT5, "000"))
		sb.Append(Format(._UNIT6, "000"))
		sb.Append(Format(._UNIT7, "000"))
		sb.Append(Format(._UNIT8, "000"))
		sb.Append(Format(._UNIT9, "000"))
		sb.Append(Format(._UNITA, "000"))
		If WrkPDist Then
			sb.Append(Format(._PDST, "000"))
		Else
			sb.Append(Format(._DIST, "000"))
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
		sb.Append(._BUSTY)
		WrkInteger = ._SQFT * 100
		sb.Append(Format(WrkInteger, "000000000"))
	End With
	Return sb.ToString
End Function
Private Function DownloadCSV() As String
	Dim sb As StringBuilder
	Dim WrkQuote As String
	Dim WrkComma As String

	WrkComma = ","
	WrkQuote = Chr(34)
	With myTXPPRPQ
		If WrkNoAssmnt Then
			._ASS1 = 0
			._ASS2 = 0
			._ASS3 = 0
			._ASS4 = 0
			._ASS5 = 0
			._ASS6 = 0
			._ASS7 = 0
			._ASS8 = 0
			._ASS9 = 0
			._ASS10 = 0
			._EXAM1 = 0
			._EXAM2 = 0
			._EXAM3 = 0
			._EXAM4 = 0
			._EXAM5 = 0
			._NET = 0
			._GROSS = 0
		End If
		sb = New StringBuilder
		sb.Append(WrkQuote)
		sb.Append(._CAT)
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
		sb.Append(Format(._ZIP5, "00000"))
		sb.Append(WrkComma)
		sb.Append(Format(._ZIP4, "0000"))
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._LOCNO))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(WrkQuote)
		sb.Append(Trim(._LOC))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._GROSS)
		sb.Append(WrkComma)
		sb.Append(._NET)
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
		sb.Append(._ASS8)
		sb.Append(WrkComma)
		sb.Append(._ASS9)
		sb.Append(WrkComma)
		sb.Append(._ASS10)
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
		sb.Append(._CODE7)
		sb.Append(WrkComma)
		sb.Append(._CODE8)
		sb.Append(WrkComma)
		sb.Append(._CODE9)
		sb.Append(WrkComma)
		sb.Append(._CODEA)
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
		sb.Append(._UNIT8)
		sb.Append(WrkComma)
		sb.Append(._UNIT9)
		sb.Append(WrkComma)
		sb.Append(._UNITA)
		sb.Append(WrkComma)
		If WrkPDist Then
			sb.Append(._PDST)
		Else
			sb.Append(._DIST)
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
		sb.Append(Trim(._BUSTY))
		sb.Append(WrkQuote)
		sb.Append(WrkComma)
		sb.Append(._SQFT)
		sb.Append(WrkComma)
		sb.Append(._ADYR)
    If WrkAll Then
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BTC))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._BTR)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BUS))
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
      sb.Append(._CASS8)
      sb.Append(WrkComma)
      sb.Append(._CASS9)
      sb.Append(WrkComma)
      sb.Append(._CASSA)
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
      sb.Append(WrkQuote)
      sb.Append(Trim(._RDATE))
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
      sb.Append(WrkQuote)
      sb.Append(Trim(._TYPE))
      sb.Append(WrkQuote)
    End If
    With myTXDCPP
      .GetOneRecordP(myTXPPRPQ._LISTNO, WrkYear)
      If Not .RecordNotFound Then
        sb.Append(WrkComma)
        sb.Append(WrkYear)
        sb.Append(WrkComma)
        Select Case Trim(._FILSTS)
        Case ""
          sb.Append("On Time")
        Case "E"
          sb.Append("Extension")
        Case "L"
          sb.Append("Late")
        Case "N"
          sb.Append("Non-Filer")
        End Select
        sb.Append(WrkComma)
        Select Case Trim(._STATUS)
        Case ""
          sb.Append("Active")
        Case "C"
          sb.Append("Increase")
        Case "P"
          sb.Append("Pending")
        Case "I"
          sb.Append("Inactive")
        End Select
      Else
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
      End If
    End With
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    myTXBUSTY.GetOneRecordP(._BUSTY)
    sb.Append(Trim(myTXBUSTY._BTDESC))
    sb.Append(WrkQuote)
    With myTXDCPP
      If Not .RecordNotFound Then
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(Trim(._DEMAIL))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(Trim(._DPHONE))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(Format(MyUtils.GetDBDate(._RECVDT), "M/d/yyyy"))
        sb.Append(WrkComma)
        If ._STRDT > 0 Then
          sb.Append(Format(MyUtils.GetDBDate(._STRDT), "M/d/yyyy"))
        Else
          sb.Append("")
        End If
        sb.Append(WrkComma)
        sb.Append(._SQFEET)
        sb.Append(WrkComma)
        sb.Append(._NOEMPS)
      Else
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
        sb.Append(WrkComma)
        sb.Append("")
      End If
    End With
  End With
  Return sb.ToString
End Function
End Module






