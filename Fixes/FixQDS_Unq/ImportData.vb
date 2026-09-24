Imports System.ComponentModel.Design
Imports System.IO
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.VisualStyles
Module ImportData
  Dim WrkGLYear As Integer
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINV As TXINV.MyData
  Dim myTXINV2 As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXCOEA As TXCOEA.MyData
  Dim sw As StreamWriter
  Dim WrkListNo As Integer
  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkUnqID As Integer
  Dim WrkCCNo As Integer
  Dim WrkCCTax As Decimal
  Dim WrkMsg As String

  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINV2 = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXCOEA = New TXCOEA.MyData(myDBConnect)
    GetFile()
    MyFrmFix.Close()

  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub GetFile()
    Dim WrkStream As FileStream = New FileStream(MyFrmFixB.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkUpdate As Boolean
    Dim sArray() As String
    Dim strBuffer As String
    Dim I As Integer
    Dim Counter As Integer

    With MyFrmFixB
      WrkUpdate = .ChkUpdate.Checked
    End With

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    strBuffer = sr.ReadLine 'Skip Heading
    If MyFrmFixB.LblFilePathLog.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePathLog.Text)
      sw.WriteLine(HeadingsCSV)
    End If

NextLine:
    Counter = Counter + 1
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo AllDone
    End If

    sArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length
    WrkUnqID = CnvSng(sArray(0))
    WrkType = GetTaxType162(sArray(2))
    WrkYear = CnvSng(sArray(1))
    WrkListNo = CnvSng(sArray(3))
    WrkCCTax = 0
    WrkMsg = ""
    With myTXINV
      .GetOneRecordP(WrkUnqID, WrkYear, WrkType)
      If .RecordNotFound Then
        If WrkUpdate Then
          .RunUpdateQuery("set List#=" & WrkUnqID & ",PRF='FixQDSUnq'", "Where list#=" & WrkListNo & " and Type='" & WrkType & "' and Year=" & WrkYear)
        End If
        WrkMsg = "Chg List"
        GoTo WriteLine
      Else
        If Trim(._PRF) = "FixQDSUnq" Then
          GoTo NextRec
        End If
        WrkCCNo = ._CCNO
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        '        If WrkCCNo = ._CCNO Then
        '        WrkMsg = "Same CC"
        '     End If
        'If WrkUpdate Then
        '  ._ICODE = "I"
        '  .UpdateOneRecordP()
        'End If
      End If
    End With

    With myTXINV2
      '.GetOneRecordP(WrkUnqID, WrkYear, WrkType)
      'WrkCCTax = myTXINV._TAXT + myTXINV._CCETAX
      '._CCNO = myTXINV._CCNO
      '._CDATE = myTXINV._CDATE
      '._CCETAX = WrkCCTax
      '._CCTX1 = myTXINV._TAX1 + myTXINV._CCTX1
      '._CCTX2 = myTXINV._TAX2 + myTXINV._CCTX2
      '._BALD = WrkCCTax - myTXINV2._PAYREC
      'If WrkUpdate Then
      '  If Not .RecordNotFound Then
      '    .UpdateOneRecordP()
      '  End If
      'End If
    End With

WriteLine:
    If MyFrmFixB.LblFilePathLog.Text <> "" Then
      sw.WriteLine(DownloadCSV)
    End If

    With myTXHST
      If WrkMsg = "Chg List" Then
        If WrkUpdate Then
          .RunUpdateQuery("set List#=" & WrkUnqID & ",PRF='FixQDSUnq'", "Where list#=" & WrkListNo & " and Type='" & WrkType & "' and Year=" & WrkYear)
        End If
      End If
    End With

    With myTXCOEA
      If WrkMsg = "Chg List" Then
        If WrkUpdate Then
          .RunUpdateQuery("set List#=" & WrkUnqID & ",PRF='FixQDSUnq'", "Where list#=" & WrkListNo & " and Type='" & WrkType & "' and Year=" & WrkYear)
        End If
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
    GoTo NextLine

AllDone:
    If MyFrmFixB.LblFilePathLog.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    sb = New StringBuilder
    sb.Append("Msg")
    sb.Append(CComma)
    sb.Append("ListNo")
    sb.Append(CComma)
    sb.Append("Type")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("CC No")
    sb.Append(CComma)
    sb.Append("CC Tax")
    sb.Append(CComma)
    sb.Append("Unq ID")
    sb.Append(CComma)
    sb.Append("CC Tax")
    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXINV
      sb = New StringBuilder
      sb.Append(WrkMsg)
      sb.Append(CComma)
      sb.Append(wrklistno)
      sb.Append(CComma)
      sb.Append(wrktype)
      sb.Append(CComma)
      sb.Append(wrkyear)
      sb.Append(CComma)
      sb.Append(Trim(._NAME))
      sb.Append(CComma)
      sb.Append(._CCNO)
      sb.Append(CComma)
      sb.Append(._CCETAX)
      sb.Append(CComma)
      sb.Append(WrkUnqID)
      sb.Append(CComma)
      sb.Append(WrkCCTax)
    End With
    Return sb.ToString
  End Function
  Private Function GetTaxType162(ByVal BillType As Integer) As String
    Dim WrkType As String
    WrkType = ""
    Select Case BillType
      Case 1
        WrkType = "R"
      Case 2
        WrkType = "P"
      Case 3
        WrkType = "M"
      Case 4
        WrkType = "S"
      Case 5
        WrkType = "A"
      Case 6
        WrkType = "U"
      Case 7
        WrkType = "C"
      Case 11
        WrkType = "X"
      Case 12
        WrkType = "Z"
      Case 13
        WrkType = "N"
      Case 14
        WrkType = "T"
      Case 15
        WrkType = ""
      Case 17
        WrkType = "D"
      Case 18
        WrkType = "W"
      Case 21
        WrkType = "Y"
    End Select
    Return WrkType
  End Function
End Module
