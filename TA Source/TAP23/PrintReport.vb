Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXDCPP As TXDCPP.MyData
  Dim myTXDCSUM As TXDCSUM.MyData
  Dim myTXDMPP As TXDMPP.MyData
  Dim myTXINV As TXINV.MyData
  Dim DsFile As DataSet = New DataSet

  Dim WrkGLYear As Integer
  Dim WrkOid As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()
    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXDCPP = New TXDCPP.MyData(myDBConnect)
    myTXDCSUM = New TXDCSUM.MyData(myDBConnect)
    myTXDMPP = New TXDMPP.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTAP23B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkOID = .ChkOID.Checked
    End With

    GetDetail()
    MsgBox("File created", MsgBoxStyle.Information, "Completed")

  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmTAP23B.LblFilePath.Text)
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkDname As String
    Dim WrkDaddr As String
    Dim WrkDaddr2 As String
    Dim WrkDcity As String
    Dim WrkDstate As String
    Dim WrkDzip5 As Integer
    Dim WrkDzip4 As Integer
    Dim WrkDemail As String
    Dim WrkStatus As String
    Dim WrkFilsts As String
    Dim WrkZip As String
    Dim WrkForm As String
    Dim WrkBackTax As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = "NAME"
    myTXPPRPQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    sw.WriteLine(WriteHeader)
ReadNext:
    myTXPPRPQ.ReadQry()
    If Not myTXPPRPQ.IsEOF Then
      With myTXPPRPQ
        Counter = Counter + 1
        If WrkOid And Trim(._OID) = "" Then
          GoTo NextRec
        End If
        sb = New StringBuilder
        sb.Append(._LISTNO)
        sb.Append(CComma)
        sb.Append(WrkGLYear + 1)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(Trim(._NAME))
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(Trim(._SNAME))
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        If Trim(._LOCNO) <> "0" Then
          sb.Append(Trim(._LOCNO))
        Else
          sb.Append("")
        End If
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(Trim(._LOC))
        sb.Append(CQuote)
        sb.Append(CComma)
      End With
      WrkForm = "Short"
      With myTXDCPP
        .GetOneRecordP(myTXPPRPQ._LISTNO, WrkGLYear)
        If Not .RecordNotFound Then
          WrkDname = Trim(._DNAME)
          WrkDaddr = Trim(._DADDR)
          WrkDaddr2 = Trim(._DADDR2)
          WrkDcity = Trim(._DCITY)
          WrkDstate = Trim(._DSTATE)
          WrkDzip5 = ._DZIP5
          WrkDzip4 = ._DZIP4
          WrkDemail = Trim(._DEMAIL)
          WrkStatus = Trim(._STATUS)
          WrkFilsts = Trim(._FILSTS)
        Else
          WrkDname = Trim(myTXPPRPQ._NAME)
          WrkDaddr = Trim(myTXPPRPQ._ADD1)
          WrkDaddr2 = Trim(myTXPPRPQ._ADD2)
          WrkDcity = Trim(myTXPPRPQ._CITY)
          WrkDstate = Trim(myTXPPRPQ._STATE)
          WrkDzip5 = myTXPPRPQ._ZIP5
          WrkDzip4 = myTXPPRPQ._ZIP4
          WrkDemail = ""
          WrkStatus = ""
          WrkFilsts = ""
        End If
      End With
      With myTXDMPP
        .GetOneRecordP(myTXPPRPQ._LISTNO, WrkGLYear)
        If Not .RecordNotFound Then
          WrkForm = "Long"
        End If
      End With
      'Check for codes that are on long Form
      If WrkForm = "Short" Then
        WrkForm = myTXDCSUM.GetFormType(myTXPPRPQ._LISTNO, WrkGLYear)
      End If
      sb.Append(CQuote)
      sb.Append(WrkDname)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkDaddr)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkDaddr2)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkDcity)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkDstate)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      If WrkDzip5 > 0 Then
        If WrkDzip4 > 0 Then
          WrkZip = Format(WrkDzip5, "00000") & "-" & Format(WrkDzip4, "0000")
        Else
          WrkZip = Format(WrkDzip5, "00000")
        End If
      Else
        WrkZip = ""
      End If
      sb.Append(WrkZip)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkDemail)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkForm)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(myTXPPRPQ._BUSTY))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(BuildBarCode(myTXPPRPQ._LISTNO))
      WrkBackTax = ""
      With myTXINV
        .GetOneRecordP(myTXPPRPQ._LISTNO, WrkGLYear, "P")
        If Not .RecordNotFound Then
          If ._ICODE = "B" Then
            WrkBackTax = "BT"
          End If
        End If
      End With
      sb.Append(CComma)
      sb.Append(WrkBackTax)
      sb.Append(CComma)
      sb.Append(WrkStatus)
      sb.Append(CComma)
      sb.Append(WrkFilsts)
      sb.Append(CComma)
      sb.Append(Trim(myTXPPRPQ._OID))
      sw.WriteLine(sb.ToString)
      sb = Nothing

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
  End Sub
End Module
