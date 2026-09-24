Imports System.io
Imports System.Text
Module PrintReceiveUB

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer

Dim myUTCUST As UTCUST.myData
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
Dim WrkAcct As Integer
Dim WrkName As String
Dim WrkSName As String
Dim WrkTaxTotal As Decimal
Dim WrkTax1st As Decimal
Dim WrkTax2nd As Decimal
Dim WrkTax3rd As Decimal
Dim WrkTax4th As Decimal
  Public Sub PrtReceiveUB()
  myUTCUST = New UTCUST.mydata(MyDBConnect)
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
    Dim I As Integer
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

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If

    WrkMsg = String.Empty
    '  If Mid(strBuffer, 94, 32) <> "~" Then
    WrkAcct = MyUtils.CnvSng(Mid(strBuffer, 267, 5))
    WrkName = Mid(strBuffer, 95, 35)
    WrkTaxTotal = MyUtils.CnvSng(Mid(strBuffer, 79, 15))
    '  Else
    '    WrkAcct = MyUtils.CnvSng(Mid(strBuffer, 252, 5))
    '    WrkName = Mid(strBuffer, 94, 35)
    '    WrkTaxTotal = MyUtils.CnvSng(Mid(strBuffer, 76, 15))
    '  End If
    myUTCUST.GetOneRecordP(WrkAcct)
    myTXINV.GetOneRecordP(WrkAcct, WrkYear, CTaxType)
    If Mid(WrkName, 1, 5) <> Mid(myUTCUST._CUNAM1, 1, 5) Then
      WrkMsg = "Names are different"
    End If
    If myUTCUST.RecordNotFound Then
      WrkMsg = "*** Account not found ***"
    End If
    If Not myTXINV.RecordNotFound Then
      WrkMsg = "*** Record already posted ***"
    End If
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
    dr.Item("ubname") = Trim(myUTCUST._CUNAM1)
    dr.Item("location") = Trim(myUTCUST._CULOCNO) & " " & myUTCUST._CULOC
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

  If WrkTaxTotal = 0 Then Exit Sub

  With myTXINV
    ._ICODE = ""
    ._LISTNo = WrkAcct
    ._YEAR = WrkYear
    ._TYPE = CTaxType
    ._NAME = myUTCUST._CUNAM1
    ._SNAME = myUTCUST._CUNAM2
    ._ADD1 = myUTCUST._CUADD1
    ._ADD2 = myUTCUST._CUADD2
    ._CITY = myUTCUST._CUCITY
    ._STATE = myUTCUST._CUST
    ._ZIP5 = MyUtils.CnvSng(Mid(myUTCUST._CUZIP, 1, 5))
    If Len(Trim(myUTCUST._CUZIP)) > 5 Then
      ._ZIP4 = MyUtils.CnvSng(Mid(myUTCUST._CUZIP, 7, 4))
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
    ._LOCNo = myUTCUST._CULOCNO
    ._LOC = myUTCUST._CULOC
    ._MAP = myUTCUST._CUMAP
    ._VOL = myUTCUST._CUVOLM
    ._IPAGE = myUTCUST._CUPAGE
    ._LETT = Mid(myUTCUST._CUNAM1, 1, 1)
    .AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
  End Sub
End Module






