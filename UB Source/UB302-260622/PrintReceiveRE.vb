Imports System.io
Imports System.Text
Module PrintReceiveRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer

Dim myTXREAL As TXReal.myData
Dim myTXINV As TXINV.myData
Dim myTXPROF As TXPROF.myData
Dim myTPaymnt As TPAYMNT.MyData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkYear As Integer
Dim WrkPost As Boolean
Dim WrkAnd As String
Dim WrkOr As String
'Shared Fields
Dim CTaxType As String = "C"
'Dim CFileLen As Integer = 255
Dim WrkAcct As Integer
Dim WrkName As String
Dim WrkSName As String
Dim WrkTaxTotal As Decimal
Dim WrkTax1st As Decimal
Dim WrkTax2nd As Decimal
Dim WrkTax3rd As Decimal
Dim WrkTax4th As Decimal
  Public Sub PrtReceiveRE()
  myTXREAL = New TXReal.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXPROF = New TXPROF.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmUB302B
    WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    WrkPost = .ChkPost.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
    ds2 = ds.Clone
  Else
    ds.Clear()
    ds2.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkds2 = ds2
    .WrkPost = WrkPost
    .Show()
  End With

  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB302B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim sArray As String()
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkMsg As String

    myTXPROF.GetOneRecordP(CTaxType, WrkYear, "", 0)
    If myTXPROF.RecordNotFound Then
      MsgBox("Type: " & CTaxType & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If

    sArray = Parse(strBuffer, "~")
    Counter = Counter + 1
    WrkMsg = String.Empty
    WrkAcct = MyUtils.CnvSng(sArray(13))
    WrkName = sArray(7)
    WrkTaxTotal = MyUtils.CnvSng(sArray(6))
    myTXREAL.GetOneRecordP(WrkAcct)
    myTXINV.GetOneRecordP(WrkAcct, WrkYear, CTaxType)
    If Mid(WrkName, 1, 5) <> Mid(myTXREAL._NAME, 1, 5) Then
      WrkMsg = "Names are different"
    End If
    If myTXREAL.RecordNotFound Then
      WrkMsg = "*** Account not found ***"
    End If
    'If Len(strBuffer) <> CFileLen Then
    '  WrkMsg = "*** Bad record length ***"
    '  WrkName = "* Record #" & Counter & " *"
    'End If
    If Mid(WrkMsg, 1, 3) <> "***" Then
      dr = ds.Tables(0).NewRow
    Else
      dr = ds2.Tables(0).NewRow
    End If

    I = I + strBuffer.Length
    With myTPaymnt
      .In_ListNo = WrkAcct
      .In_Type = CTaxType
      .In_Year = WrkYear
      .In_Dst = 0
      .In_Phs = String.Empty
      .In_TaxT = WrkTaxTotal
      .CalcPaySplit()
      WrkTaxTotal = .Out_TaxT
      WrkTax1st = .Out_Tax1
      WrkTax2nd = .Out_Tax2
      WrkTax3rd = .Out_Tax3
      WrkTax4th = .Out_Tax4
    End With

    dr.Item("listno") = WrkAcct
    dr.Item("ubname") = Trim(myTXREAL._NAME)
    dr.Item("location") = Trim(myTXREAL._LOCNO) & " " & myTXREAL._LOC
    dr.Item("name") = Trim(WrkName)
    dr.Item("taxtotal") = WrkTaxTotal
    dr.Item("errmsg") = WrkMsg
    If Mid(WrkMsg, 1, 3) <> "***" Then
      ds.Tables(0).Rows.Add(dr)
    Else
      ds2.Tables(0).Rows.Add(dr)
    End If
    dr = Nothing

    If Mid(WrkMsg, 1, 3) <> "***" And WrkPost Then
      WriteInvoice()
    End If

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Cleanup:
    sr.Close()
    myFrmProgress.Close()

  End Sub
  Private Sub WriteInvoice()

  With myTXINV
    ._ICODE = ""
    ._LISTNo = WrkAcct
    ._YEAR = WrkYear
    ._TYPE = CTaxType
    ._NAME = myTXREAL._NAME
    ._SNAME = myTXREAL._SNAME
    ._ADD1 = myTXREAL._ADD1
    ._ADD2 = myTXREAL._ADD2
    ._CITY = myTXREAL._CITY
    ._STATE = myTXREAL._STATE
    ._ZIP5 = myTXREAL._ZIP5
    If myTXREAL._ZIP4 > 0 Then
      ._ZIP4 = myTXREAL._ZIP4
    Else
      ._ZIP4 = 0
    End If
    ._DIST = 0
    ._TAXT = WrkTaxTotal
    ._TAX1 = WrkTax1st
    ._TAX2 = WrkTax2nd
    ._TX3RD = WrkTax3rd
    ._TX4TH = WrkTax4th
    ._BALD = WrkTaxTotal
    ._LOCNo = myTXREAL._LOCNO
    ._LOC = myTXREAL._LOC
    ._MAP = myTXREAL._MAP
    ._VOL = myTXREAL._VOL
    ._IPAGE = myTXREAL._PGE
    ._LETT = Mid(myTXREAL._NAME, 1, 1)
    .AddOneRecordP()
  End With
End Sub
End Module






