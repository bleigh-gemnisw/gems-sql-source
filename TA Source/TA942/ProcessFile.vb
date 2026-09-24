Imports System.Text
Imports System.io
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXDCPPQ As TXDCPPQ.myData
Dim myTXPPRP As TXPPRP.myData

Dim WrkHeadings As Boolean
Dim WrkYear As Integer
  Public Sub ProcFile()
  myTXDCPPQ = New TXDCPPQ.mydata(MyDBConnect)
  myTXPPRP = New TXPPRP.mydata(MyDBConnect)

  With MyFrmTA942B
    WrkHeadings = .ChkHeadings.Checked
    WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
  End With

 GetDetail()
End Sub
Private Sub GetDetail()
Dim sw As StreamWriter
Dim WrkQry As String
Dim WrkSort As String
Dim WrkData As String
Dim Counter As Integer

WrkQry = "Year =" & WrkYear
WrkSort = ""
Counter = 0
sw = New StreamWriter(MyFrmTA942B.LblFilePath.Text)

myTXDCPPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If WrkHeadings Then
  sw.WriteLine(HeadingsCSV)
End If

ReadNext:
  myTXDCPPQ.ReadQry()
  If Not myTXDCPPQ.IsEOF Then
    WrkData = DownloadCSV()
    If WrkData <> "" Then
      sw.WriteLine(WrkData)
      Counter = Counter + 1
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

  sw.Close()
  myFrmProgress.Close()
  myTXDCPPQ.CloseFile()
  MsgBox(Format(Counter, "###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

End Sub
Private Function DownloadCSV() As String
  Dim sb As StringBuilder
  Dim WrkQuote As String
  Dim WrkComma As String
  Dim AddrLine() As String

  WrkComma = ","
  WrkQuote = Chr(34)
  With myTXPPRP
    .GetOneRecordP(myTXDCPPQ._LISTNO)
    If .RecordNotFound Then Return ""
    AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
     ._CITY, ._STATE, ._ZIP5, ._ZIP4)
    sb = New StringBuilder
    sb.Append(._LISTNO)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(AddrLine(0))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(AddrLine(1))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(AddrLine(2))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(AddrLine(3))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(AddrLine(4))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If Trim(._LOCNO) <> "0" Then
      sb.Append(Trim(._LOCNO) & " " & Trim(._LOC))
    Else
      sb.Append(Trim(._LOC))
    End If
    sb.Append(WrkQuote)
  End With
  Return sb.ToString
End Function
Private Function HeadingsCSV() As String
	Dim sb As StringBuilder
	Dim WrkComma As String

	WrkComma = ","
	sb = New StringBuilder
  sb.Append("List No")
	sb.Append(WrkComma)
  sb.Append("Addr Line 1")
	sb.Append(WrkComma)
  sb.Append("Addr Line 2")
  sb.Append(WrkComma)
  sb.Append("Addr Line 3")
  sb.Append(WrkComma)
  sb.Append("Addr Line 4")
  sb.Append(WrkComma)
  sb.Append("Addr Line 5")
  sb.Append(WrkComma)
  sb.Append("Location")
  Return sb.ToString
End Function
End Module






