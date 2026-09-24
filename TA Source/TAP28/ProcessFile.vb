Imports System.Text
Imports System.IO
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCPPQ As TXDCPPQ.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim myTXDCCD As TXDCCD.MyData
  Dim myTXDCEX As TXDCEX.MyData
  Dim myTXDCEXM As TXDCEXM.MyData

  Dim WrkNoExempt As Boolean
  Dim WrkYear As Integer
  Dim WrkMaxCodes As Integer
  Dim WrkMaxExCodes As Integer
  Dim WrkExCode(100) As String
  Public Sub ProcFile()
    myTXDCPPQ = New TXDCPPQ.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    myTXDCCD = New TXDCCD.MyData(myDBConnect)
    myTXDCEX = New TXDCEX.MyData(myDBConnect)
    myTXDCEXM = New TXDCEXM.MyData(myDBConnect)

    With MyFrmTAP28B
      WrkNoExempt = .ChkNoExempt.Checked
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkQry = "YEAR=" & WrkYear
    WrkSort = ""
    Counter = 0
    sw = New StreamWriter(MyFrmTAP28B.LblFilePath.Text)

    myTXDCPPQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    sw.WriteLine(HeadingsCSV)

ReadNext:
    myTXDCPPQ.ReadQry()
    If Not myTXDCPPQ.IsEOF Then
      sw.WriteLine(DownloadCSV)
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
    myTXDCPPQ.CloseFile()
    MsgBox(Format(Counter, "###,###,##0") & " Records Exported", MsgBoxStyle.Information, "Export Completed")

  End Sub
  Public Function HeadingsCSV() As String
    Dim ds2 As DataSet = New DataSet
    Dim sb As StringBuilder
    Dim WrkQuote As String
    Dim WrkComma As String
    Dim I As Integer

    WrkComma = ","
    WrkQuote = Chr(34)
    sb = New StringBuilder
    sb.Append("List No")
    sb.Append(WrkComma)
    sb.Append("Year")
    sb.Append(WrkComma)
    sb.Append("Owner's Name")
    sb.Append(WrkComma)
    sb.Append("Second Name")
    sb.Append(WrkComma)
    sb.Append("DBA")
    sb.Append(WrkComma)
    sb.Append("Location No")
    sb.Append(WrkComma)
    sb.Append("Location")
    sb.Append(WrkComma)
    sb.Append("Direct questions To Name")
    sb.Append(WrkComma)
    sb.Append("Direct To Address")
    sb.Append(WrkComma)
    sb.Append("Direct To Address 2")
    sb.Append(WrkComma)
    sb.Append("Direct To City")
    sb.Append(WrkComma)
    sb.Append("Direct To State")
    sb.Append(WrkComma)
    sb.Append("Direct To Zip5")
    sb.Append(WrkComma)
    sb.Append("Direct To Zip4")
    sb.Append(WrkComma)
    sb.Append("Direct To Phone")
    sb.Append(WrkComma)
    sb.Append("Direct To Fax")
    sb.Append(WrkComma)
    sb.Append("Direct To Email")
    sb.Append(WrkComma)
    sb.Append("Location Name")
    sb.Append(WrkComma)
    sb.Append("Location Address")
    sb.Append(WrkComma)
    sb.Append("Location Address 2")
    sb.Append(WrkComma)
    sb.Append("Location City")
    sb.Append(WrkComma)
    sb.Append("Location State")
    sb.Append(WrkComma)
    sb.Append("Location Zip5")
    sb.Append(WrkComma)
    sb.Append("Location Zip4")
    sb.Append(WrkComma)
    sb.Append("Location Phone")
    sb.Append(WrkComma)
    sb.Append("Location Fax")
    sb.Append(WrkComma)
    sb.Append("Location Email")
    sb.Append(WrkComma)
    sb.Append("Business Description")
    sb.Append(WrkComma)
    sb.Append("No Of Employees")
    sb.Append(WrkComma)
    sb.Append("Business Start Date")
    sb.Append(WrkComma)
    sb.Append("Square Feet")
    sb.Append(WrkComma)
    sb.Append("Own/Lease")
    sb.Append(WrkComma)
    sb.Append("Type of Ownership")
    sb.Append(WrkComma)
    sb.Append("Other")
    sb.Append(WrkComma)
    sb.Append("Type of Business")
    sb.Append(WrkComma)
    sb.Append("Other")
    sb.Append(WrkComma)
    sb.Append("Business Code")
    sb.Append(WrkComma)
    sb.Append("Filing Status")
    sb.Append(WrkComma)
    sb.Append("Status")
    sb.Append(WrkComma)
    sb.Append("Date Received")
    ds2 = myTXDCCD.GetAllYear(WrkYear)
    WrkMaxCodes = -1
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If Trim(ds2.Tables(0).Rows(I).Item("Ltr")) = "" Then
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        WrkMaxCodes = WrkMaxCodes + 1
        sb.Append(ds2.Tables(0).Rows(I).Item("Code") & " " & ds2.Tables(0).Rows(I).Item("desc"))
        sb.Append(WrkQuote)
      End If
    Next
    If WrkMaxCodes = -1 Then WrkMaxCodes = 0
    sb.Append(WrkComma)
    sb.Append("Assr Net")
    If Not WrkNoExempt Then
      ds2 = myTXDCEX.GetAllYear(WrkYear)
      WrkMaxExCodes = -1
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        sb.Append(WrkComma)
        WrkMaxExCodes = WrkMaxExCodes + 1
        WrkExCode(I) = ds2.Tables(0).Rows(I).Item("Code")
        sb.Append(ds2.Tables(0).Rows(I).Item("Code"))
      Next
      If WrkMaxExCodes = -1 Then WrkMaxExCodes = 0
      sb.Append(WrkComma)
      sb.Append("Total Exemptions")
    End If
    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim ds2 As DataSet = New DataSet
    Dim sb As StringBuilder
    Dim WrkQuote As String
    Dim WrkComma As String
    Dim WrkCode(WrkMaxCodes) As String
    Dim WrkCodeAmt(WrkMaxCodes) As Integer
    ReDim Preserve WrkExCode(WrkMaxExCodes)
    Dim WrkExCodeAmt(WrkMaxExCodes) As Integer
    Dim WrkTotAmt As Integer
    Dim I As Integer
    Dim J As Integer

    WrkComma = ","
    WrkQuote = Chr(34)
    With myTXDCPPQ
      sb = New StringBuilder
      sb.Append(._LISTNO)
      sb.Append(WrkComma)
      sb.Append(WrkYear)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._OWNAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._SNAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DBA))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(._LOCNO)
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LOC))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DNAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DADDR))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DADDR2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DCITY))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DSTATE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._DZIP5 > 0 Then
        sb.Append(Format(._DZIP5, "00000"))
      End If
      sb.Append(WrkComma)
      If ._DZIP4 > 0 Then
        sb.Append(Format(._DZIP4, "00000"))
      End If
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DPHONE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DFAX))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._DEMAIL))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LNAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LADDR))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LADDR2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LCITY))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LSTATE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._LZIP5 > 0 Then
        sb.Append(Format(._LZIP5, "00000"))
      End If
      sb.Append(WrkComma)
      If ._LZIP4 > 0 Then
        sb.Append(Format(._LZIP4, "00000"))
      End If
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LPHONE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LFAX))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._LEMAIL))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BUSDES))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._NOEMPS)
      sb.Append(WrkComma)
      If ._STRDT > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(._STRDT), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(WrkComma)
      sb.Append(._SQFEET)
      sb.Append(WrkComma)
      If ._OWN = "Y" Then
        sb.Append("Own")
      Else
        sb.Append("Lease")
      End If
      sb.Append(WrkComma)
      Select Case Trim(._OWNTYP)
        Case "C"
          sb.Append("Corporation")
        Case "W"
          sb.Append("Partnership")
        Case "L"
          sb.Append("LLC")
        Case "S"
          sb.Append("Sole Proprietor")
        Case Else
          sb.Append("Other")
      End Select
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._OWNOTH))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      Select Case Trim(._BUSCAT)
        Case "M"
          sb.Append("Manufacturer")
        Case "W"
          sb.Append("Wholesale")
        Case "S"
          sb.Append("Service")
        Case "P"
          sb.Append("Profession")
        Case "R"
          sb.Append("Retail/Mercantile")
        Case "T"
          sb.Append("Tradesman")
        Case "L"
          sb.Append("Lessor")
        Case Else
          sb.Append("Other")
      End Select
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BUSOTH))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._BUSCD))
      sb.Append(WrkQuote)
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
      sb.Append(WrkComma)
      sb.Append(Format(MyUtils.GetDBDate(._RECVDT), "M/d/yyyy"))

      'Summary 
      Array.Clear(WrkCode, 0, WrkMaxCodes)
      Array.Clear(WrkCodeAmt, 0, WrkMaxCodes)
      WrkTotAmt = 0
      ds2 = myTXDCSUM.GetByList(._LISTNO, WrkYear)
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        If ds2.Tables(0).Rows(I).Item("value") = 0 Then Continue For
        J = ds2.Tables(0).Rows(I).Item("CODE")
        If J < 15 Then
          J = J - 9 'Codes 9-14 subtract 9 for index 0-5
        Else
          J = J - 10 'Codes 16-25 subtract 10 for index 6-15
        End If
        WrkCode(J) = ds2.Tables(0).Rows(I).Item("Code")
        WrkCodeAmt(J) = WrkCodeAmt(J) + ds2.Tables(0).Rows(I).Item("net")
      Next
      For J = 0 To WrkMaxCodes
        sb.Append(WrkComma)
        sb.Append(WrkCodeAmt(J))
        WrkTotAmt = WrkTotAmt + WrkCodeAmt(J)
      Next
      sb.Append(WrkComma)
      sb.Append(WrkTotAmt)

      'Exemptions
      If Not WrkNoExempt Then
        Array.Clear(WrkExCodeAmt, 0, WrkMaxExCodes)
        WrkTotAmt = 0
        ds2 = myTXDCEXM.GetByList(._LISTNO, WrkYear)
        For J = 0 To WrkMaxExCodes
          For I = 0 To ds2.Tables(0).Rows.Count - 1
            If WrkExCode(J) = ds2.Tables(0).Rows(I).Item("Code") Then
              WrkExCodeAmt(J) = ds2.Tables(0).Rows(I).Item("value")
            End If
          Next
        Next
        For J = 0 To WrkMaxExCodes
          sb.Append(WrkComma)
          sb.Append(WrkExCodeAmt(J))
          WrkTotAmt = WrkTotAmt + WrkExCodeAmt(J)
        Next
        sb.Append(WrkComma)
        sb.Append(WrkTotAmt)
      End If
    End With
    Return sb.ToString
  End Function
End Module
