Imports System.IO
Imports System.Data.SqlClient   'added 6/3/25
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myBCHHDR As BCHHDR.myData
  Dim myTCRBCH As TCRBCH.myData
  Dim myTXINV As TXINV.myData
  Dim MyCASHINT As CASHINT.MyData
  'MK 7/30/25 Begin
  'Dim myBulkImport As TXA04BulkImport.MyData
  'MK 7/30/25 End
  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim WrkOverride As Boolean
  Dim WrkReceiptDate As Date
  Dim WrkInterestDate As Date
  Dim WrkBatchNo As Integer
  Dim WrkYear4 As Boolean
  Dim WrkDist As Boolean
  Dim WrkOverBankcd As String
  Dim WrkOverCheckNo As String
  Dim WrkBankCd(500) As String
  Dim WrkBankName(500) As String
  Dim WrkCheckNo(500) As String
  Dim WrkComment As String
  Dim Conn As SqlConnection = myDBConnect.Open()  ' added 6-3/25
  Public Sub PrtReport()
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    MyCASHINT = New CASHINT.MyData(myDBConnect)
    'MK 7/30/25 Begin
    'myBulkImport = New TXA04BulkImport.MyData(myDBConnect)
    'MK 7/30/25 End

    With MyFrmTXA04B
      WrkReceiptDate = .DtPckReceipt.Value
      WrkInterestDate = .DtPckInterest.Value
      WrkDist = .ChkDist.Checked
      WrkYear4 = False
      If .ChkYear4.Checked Then
        WrkYear4 = True
      End If
      WrkOverride = .ChkOverride.Checked
      WrkOverBankcd = .TxtBankCd.Text
      WrkOverCheckNo = .TxtCheckNo.Text
      WrkComment = .TxtComment.Text
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If
    '    If myTOWN._TOWNBR = 4 Then 'Avon
    '   GetDetail()
    '  Else
    GetDetail_Bulk()     ' new method  6/6/25
    ' End If
    ' TestGetDetailBulk()
    'GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkBatchNo = WrkBatchNo
      .WrkReceiptDate = WrkReceiptDate
      .WrkInterestDate = WrkInterestDate
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("BankCd", Type.GetType("System.String"))
      .Columns.Add("BankName", Type.GetType("System.String"))
      .Columns.Add("CheckNo", Type.GetType("System.String"))
      .Columns.Add("Pamt", Type.GetType("System.Decimal"))
      .Columns.Add("Iamt", Type.GetType("System.Decimal"))
      .Columns.Add("PCamt", Type.GetType("System.Decimal"))
      .Columns.Add("Lamt", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub TestGetDetailBulk()
    Dim filePath As String = MyFrmTXA04B.LblFilePath.Text
    Dim tableName As String

    ' Pick the correct table based on the MyList7 global flag
    If MyList7 Then
      tableName = "bankpayimport_2digit_7"
    Else
      tableName = "bankpayimport_2digit_6"
    End If

    ' Run the upload using the new DLL logic
    'MK 7/30/25 Begin
    'myBulkImport.UploadBankFile(filePath, tableName, MyList7, WrkYear4)
    UploadBankFile(filePath, tableName, MyList7, WrkYear4)
    'MK 7/30/25 Begin

    MessageBox.Show("Bank pay file uploaded to SQL successfully!", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub
  Private Sub GetDetail_Bulk()
    Dim WrkFileSize As Integer
    Dim WrkLen As Integer
    Dim WrkTrnbr As Integer
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkPaid As Decimal
    Dim WrkInterest As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkFeeDue As Decimal
    Dim WrkFee(7) As Decimal
    Dim WrkFeecd(7) As String
    Dim WrkCAFee As Decimal
    Dim WrkCAProrated As Decimal
    Dim WrkOtherFee As Decimal
    Dim WrkBond As Decimal
    Dim WrkLien As Decimal
    Dim WrkTax As Decimal
    Dim WrkDue As Decimal
    Dim WrkBank As String
    Dim SaveBank As String = ""
    Dim SaveBankName As String = ""
    Dim SaveCheckNo As String = ""
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotFee As Decimal
    Dim TotLien As Decimal
    Dim J As Integer
    Dim I As Integer
    Dim K As Integer
    Dim strFilter As String
    Dim RowCounter As Integer = 0

    Const CBatchType As String = "PTC"
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Array.Clear(WrkBankCd, 0, 500)
    Array.Clear(WrkBankName, 0, 500)
    Array.Clear(WrkCheckNo, 0, 500)
    For J = 0 To (MyFrmTXA04B.DataGrdView.Rows.Count - 1)
      WrkBankCd(J) = Trim(myds.Tables(0).Rows(J).Item("bankcd"))
      WrkBankName(J) = Trim(myds.Tables(0).Rows(J).Item("bankname"))
      WrkCheckNo(J) = myds.Tables(0).Rows(J).Item("checkno")
    Next
    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)
    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)

    ' Perform the upload and get the joined TXINV/bankpay table
    'MK 7/30/25 Begin
    'Dim myBulk As New TXA04BulkImport.MyData(myDBConnect)
    'MK 7/30/25 End
    Dim tableName As String = If(MyList7, "bankpayimport_2digit_7", "bankpayimport_2digit_6")
    ' myBulk.UploadBankFile(MyFrmTXA04B.LblFilePath.Text, tableName, MyList7)
    'MK 7/30/25 Begin
    'myBulk.UploadBankFile(MyFrmTXA04B.LblFilePath.Text, tableName, MyList7, WrkYear4)
    UploadBankFile(MyFrmTXA04B.LblFilePath.Text, tableName, MyList7, WrkYear4)
    'Dim dtBulk As DataTable = myBulk.GetMatchedTXINV(MyList7)
    Dim dtBulk As DataTable = GetMatchedTXINV(MyList7)
    'MK 7/30/25 End

    WrkFileSize = dtBulk.Rows.Count
    For Each row As DataRow In dtBulk.Rows
      RowCounter += 1
      If I > 0 AndAlso I Mod 100 = 0 Then
        MessageBox.Show($"Processed {I} of {WrkFileSize} records...", "Progress Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
      WrkListNo = row("ListNo")
      WrkYear = row("Year")
      WrkType = row("Type")
      WrkPaid = row("PaidAmount")
      WrkBank = row("BankCd")
      WrkInterest = 0
      WrkLien = 0
      If WrkOverride Then
        WrkBank = WrkOverBankcd
        SaveBank = WrkOverBankcd
      End If
      WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
      myTCRBCH.GetOneRecordP(WrkBatchNo, WrkTrnbr)
      With myTCRBCH
        If SaveBank <> "" And SaveBank <> WrkBank Then
          dr = ds.Tables(0).NewRow
          dr.Item("count") = TotCount
          dr.Item("bankcd") = SaveBank
          dr.Item("bankname") = SaveBankName
          dr.Item("checkno") = SaveCheckNo
          dr.Item("pamt") = TotPaid
          dr.Item("iamt") = TotInt
          dr.Item("lamt") = TotLien
          dr.Item("total") = TotPaid + TotInt + TotLien
          ds.Tables(0).Rows.Add(dr)
          TotCount = 0
          TotPaid = 0
          TotInt = 0
          TotLien = 0
        End If

        SaveBank = WrkBank
        ._BCHNO = WrkBatchNo
        ._TRNBR = WrkTrnbr
        ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
        ._LISTNo = WrkListNo
        ._YEAR = WrkYear
        ._TYPE = WrkType
        ._NAME = row("NAME")
        If WrkDist Then ._DIST = row("DIST")

        ' Interest + Fee logic
        CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
                   WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)

        WrkFee(6) = 0 : WrkFeecd(6) = ""
        If WrkCAFee > 0 Then
          If WrkPaid < WrkDue Then
            WrkOtherFee = WrkFeeDue - WrkCAFee
            WrkCAProrated = MyUtils.Round(WrkPaid * 0.15, 2)
            WrkFee(6) = WrkCAProrated
            WrkFeecd(6) = "CA"
            WrkFeeDue = WrkOtherFee + WrkCAProrated
          Else
            WrkFee(6) = WrkCAFee
            WrkFeecd(6) = "CA"
          End If
        End If

        If WrkFeeDue >= WrkPaid Then
          WrkFeeDue = WrkPaid : WrkPaid = 0
        Else
          WrkPaid -= WrkFeeDue
        End If
        If WrkInterest >= WrkPaid Then
          WrkInterest = WrkPaid : WrkPaid = 0
        Else
          WrkPaid -= WrkInterest
        End If
        If WrkBond >= WrkPaid Then
          WrkBond = WrkPaid : WrkPaid = 0
        Else
          WrkPaid -= WrkBond
        End If
        If WrkPaid >= (WrkTax + WrkLien) And WrkLien > 0 Then
          WrkPaid -= WrkLien
        Else
          WrkLien = 0
        End If

        WrkFee(0) = row("FED1") : WrkFee(1) = row("FED2")
        WrkFee(2) = row("FED3") : WrkFee(3) = row("FED4")
        WrkFee(4) = row("FED5")
        WrkFeecd(0) = row("FEC1") : WrkFeecd(1) = row("FEC2")
        WrkFeecd(2) = row("FEC3") : WrkFeecd(3) = row("FEC4")
        WrkFeecd(4) = row("FEC5")
        WrkFee(5) = 0 : WrkFeecd(5) = ""

        For I = 0 To 4
          If WrkFee(I) > 0 And WrkFeeDue > 0 Then
            If WrkFeeDue < WrkFee(I) Then WrkFee(I) = WrkFeeDue
            WrkFeeDue -= WrkFee(I)
          Else
            WrkFee(I) = 0 : WrkFeecd(I) = ""
          End If
        Next

        ._PAMT = WrkPaid
        ._IAMT = WrkInterest
        ._PCAMT = WrkFee.Sum()
        ._PCAMT1 = WrkFee(0) : ._PCAMT2 = WrkFee(1)
        ._PCAMT3 = WrkFee(2) : ._PCAMT4 = WrkFee(3)
        ._PCAMT5 = WrkFee(4) : ._PCAMT6 = WrkFee(5)
        ._PCAMT7 = WrkFee(6)
        ._PENCD1 = WrkFeecd(0) : ._PENCD2 = WrkFeecd(1)
        ._PENCD3 = WrkFeecd(2) : ._PENCD4 = WrkFeecd(3)
        ._PENCD5 = WrkFeecd(4) : ._PENCD6 = WrkFeecd(5)
        ._PENCD7 = WrkFeecd(6)
        ._LAMT = WrkLien
        ._ADJ = ""
        ._BKCD = WrkBank
        K = LookupBankCd(WrkBank)
        If K >= 0 Then
          ._REF = WrkCheckNo(K)
          ._COMM = WrkBankName(K)
        Else
          ._REF = ""
          ._COMM = If(WrkBank <> "", Mid(GetTXBanksDesc(WrkBank), 1, 20), "")
        End If
        If WrkComment <> "" Then ._COMM = WrkComment
        If WrkOverride Then ._REF = WrkOverCheckNo

        SaveBankName = Trim(._COMM)
        SaveCheckNo = Trim(._REF)
        ._PMETH = "2"
        ._SRC = 4
        'myTCRBCH.AddOneRecordP()    '6/15/25  speed up pgm
        myTCRBCH.AddOneRecordFast()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End With

      TotCount += 1
      TotPaid += WrkPaid
      TotInt += WrkInterest
      TotFee += myTCRBCH._PCAMT
      TotLien += WrkLien

      If I > 0 AndAlso I Mod 100 = 0 Then
        MessageBox.Show($"Processed {I} of {WrkFileSize} records...", "Progress Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

      '-------------------  added 6/6/25 
      ' ---- Progress Bar Update ----
      If WrkFileSize > 0 Then
        Dim WrkPct As Integer = CInt((CDec(RowCounter) / CDec(WrkFileSize)) * 100)
        If WrkPct > 100 Then WrkPct = 100

        If SavePct <> WrkPct Then
          With myFrmProgress
            .ProgBar1.Value = WrkPct
            .Text = $"Creating Report...  Record {RowCounter} of {WrkFileSize}"
            .Refresh()
          End With
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End If
      'If RowCounter Mod 1000 = 0 Then
      '  MessageBox.Show($"Processed {RowCounter} of {WrkFileSize} records...", "Progress Debug", MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End If

      '-------------------------------------
    Next

    ' Final summary row
    dr = ds.Tables(0).NewRow
    dr.Item("count") = TotCount
    dr.Item("bankcd") = SaveBank
    dr.Item("bankname") = SaveBankName
    dr.Item("checkno") = SaveCheckNo
    dr.Item("pamt") = TotPaid
    dr.Item("iamt") = TotInt
    dr.Item("lamt") = TotLien
    dr.Item("pcamt") = TotFee
    dr.Item("total") = TotPaid + TotInt + TotLien + TotFee
    ds.Tables(0).Rows.Add(dr)

    ' Update header record
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "NET-TXA04"
      ._STATS = "S"
      ._SUBST = "K"
      ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    Else
      With myBCHHDR
        ._APPID = CBatchType
        ._BCHNO = 0
        ._LSBCH = WrkBatchNo
        .AddOneRecordP()
      End With
    End If

    myFrmProgress.Close()
    myTCRBCH.CloseFile()
  End Sub
  Public Function UploadBankFile(filePath As String, tableName As String, isList7 As Boolean, isYear4Digit As Boolean) As Boolean
    'MK 7/28/25 Begin
    Dim WrkLen As Integer
    'MK 7/28/25 End
    Try
      Dim dt As New DataTable
      dt.Columns.Add("LISTNO", GetType(Integer))
      dt.Columns.Add("YEAR", GetType(Integer))
      dt.Columns.Add("TYPE", GetType(String))
      dt.Columns.Add("PAIDAMOUNT", GetType(Decimal))
      dt.Columns.Add("BANKCD", GetType(String))

      Dim lines() As String = File.ReadAllLines(filePath)
      For Each line As String In lines
        If String.IsNullOrWhiteSpace(line) Then Continue For

        'MK 7/28/25 Begin
        'line = line.Trim()
        WrkLen = Len(line)
        'MK 7/28/25 End
        Dim listNoLen As Integer = If(isList7, 7, 6)
        Dim listNo As Integer = CInt(line.Substring(0, listNoLen).Trim())
        Dim year As Integer
        Dim taxType As String
        Dim paid As Decimal
        Dim bank As String

        If isYear4Digit Then
          year = CInt(line.Substring(listNoLen, 4).Trim())
          taxType = line.Substring(listNoLen + 4, 1).Trim()
          paid = Decimal.Parse(line.Substring(listNoLen + 5, 11).Trim()) / 100
          bank = line.Substring(listNoLen + 16, 2).Trim()
        Else
          year = 2000 + CInt(line.Substring(listNoLen, 2).Trim())
          taxType = line.Substring(listNoLen + 2, 1).Trim()
          'MK 7/28/25 Begin
          'paid = Decimal.Parse(line.Substring(listNoLen + 3, 11).Trim()) / 100
          If WrkLen >= listNoLen + 14 Then
            paid = Decimal.Parse(line.Substring(listNoLen + 3, 11).Trim()) / 100
          Else
            paid = Decimal.Parse(line.Substring(listNoLen + 3, 10).Trim()) / 100
          End If
          'bank = line.Substring(listNoLen + 14, 2).Trim()
          bank = ""
            If WrkLen >= listNoLen + 15 Then
              bank = line.Substring(listNoLen + 14, 2).Trim()
            End If
            If String.IsNullOrWhiteSpace(bank) Then
              'bank = line.Substring(listNoLen + 20, 2).Trim()
              If WrkLen >= listNoLen + 21 Then
                bank = line.Substring(listNoLen + 20, 2).Trim()
              End If
              'MK 7/28/25 Begin
            End If
          End If
          dt.Rows.Add(listNo, year, taxType, paid, bank)
      Next

      Dim delCmd As New SqlCommand("DELETE FROM " & tableName, Conn)
      delCmd.ExecuteNonQuery()

      Using bulkCopy As New SqlBulkCopy(Conn)
        bulkCopy.DestinationTableName = tableName
        bulkCopy.ColumnMappings.Add("LISTNO", "ListNo")
        bulkCopy.ColumnMappings.Add("YEAR", "Year")
        bulkCopy.ColumnMappings.Add("TYPE", "Type")
        bulkCopy.ColumnMappings.Add("PAIDAMOUNT", "PaidAmount")
        bulkCopy.ColumnMappings.Add("BANKCD", "BankCd")
        bulkCopy.WriteToServer(dt)
      End Using
      Return True
    Catch ex As Exception
      MsgBox("", MsgBoxStyle.Information, "Error in UploadBankFile: " & ex.Message)
    End Try
  End Function

  Public Function GetMatchedTXINV(useList7 As Boolean) As DataTable
    Dim dt As New DataTable
    Try
      Dim cmd As New SqlCommand("usp_GetBulkTXA04Records", Conn)
      cmd.CommandType = CommandType.StoredProcedure
      cmd.Parameters.AddWithValue("@UseList7", If(useList7, 1, 0))

      Dim da As New SqlDataAdapter(cmd)
      da.Fill(dt)
    Catch ex As Exception
      MsgBox("", MsgBoxStyle.Information, "Error in GetMatchedTXINV: " & ex.Message)
    End Try
    Return dt
  End Function


  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmTXA04B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkTrnbr As Integer
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkPaid As Decimal
    Dim WrkInterest As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkFeeDue As Decimal
    Dim WrkFee(7) As Decimal
    Dim WrkFeecd(7) As String
    Dim WrkCAFee As Decimal
    Dim WrkCAProrated As Decimal
    Dim WrkOtherFee As Decimal
    Dim WrkBond As Decimal
    Dim WrkLien As Decimal
    Dim WrkTax As Decimal
    Dim WrkDue As Decimal
    Dim WrkBank As String
    Dim SaveBank As String
    Dim SaveBankName As String
    Dim SaveCheckNo As String
    Dim TotCount As Integer
    Dim TotPaid As Decimal
    Dim TotInt As Decimal
    Dim TotFee As Decimal
    Dim TotLien As Decimal
    Dim WrkLen As Integer

    Const CBatchType As String = "PTC"
    SaveBank = String.Empty
    SaveBankName = String.Empty
    SaveCheckNo = String.Empty

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Array.Clear(WrkBankCd, 0, 500)
    Array.Clear(WrkBankName, 0, 500)
    Array.Clear(WrkCheckNo, 0, 500)

    For J = 0 To (MyFrmTXA04B.DataGrdView.Rows.Count - 1)
      WrkBankCd(J) = Trim(myds.Tables(0).Rows(J).Item("bankcd"))
      WrkBankName(J) = Trim(myds.Tables(0).Rows(J).Item("bankname"))
      WrkCheckNo(J) = myds.Tables(0).Rows(J).Item("checkno")
    Next

    WrkFileSize = WrkStream.Length
    WrkBatchNo = myBCHHDR.AutoGenKey(CBatchType)

    myBCHHDR.GetOneRecordP(CBatchType, WrkBatchNo)

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo WriteBatch
      Exit Sub
    End If

    If MyList7 Then
      WrkLen = 7
    Else
      WrkLen = 6
    End If
    I = I + strBuffer.Length
    If WrkYear4 Then
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 1, WrkLen))
      WrkYear = MyUtils.CnvSng(Mid(strBuffer, WrkLen + 1, 4))
      WrkType = Mid(strBuffer, WrkLen + 5, 1)
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, WrkLen + 6, 11)) / 100
      WrkBank = Mid(strBuffer, WrkLen + 17, 2)
    Else
      WrkListNo = MyUtils.CnvSng(Mid(strBuffer, 1, WrkLen))
      WrkYear = MyUtils.CnvSng("20" & Mid(strBuffer, WrkLen + 1, 2))
      WrkType = Mid(strBuffer, WrkLen + 3, 1)
      WrkPaid = MyUtils.CnvSng(Mid(strBuffer, WrkLen + 4, 11)) / 100
      WrkBank = Mid(strBuffer, WrkLen + 15, 2)
      If Trim(WrkBank) = "" Then
        WrkBank = Mid(strBuffer, WrkLen + 21, 2)
      End If
    End If
    If WrkOverride Then
      WrkBank = WrkOverBankcd
      SaveBank = WrkOverBankcd
    End If
    WrkInterest = 0
    WrkLien = 0

    WrkTrnbr = myTCRBCH.AutoGenKey(WrkBatchNo)
    myTCRBCH.GetOneRecordP(WrkBatchNo, WrkTrnbr)
    With myTCRBCH
      If SaveBank <> String.Empty And SaveBank <> WrkBank Then
        dr = ds.Tables(0).NewRow
        dr.Item("count") = TotCount
        dr.Item("bankcd") = SaveBank
        dr.Item("bankname") = SaveBankName
        dr.Item("checkno") = SaveCheckNo
        dr.Item("pamt") = TotPaid
        dr.Item("iamt") = TotInt
        dr.Item("lamt") = TotLien
        dr.Item("total") = TotPaid + TotInt + TotLien
        ds.Tables(0).Rows.Add(dr)
        TotCount = 0
        TotPaid = 0
        TotInt = 0
        TotLien = 0
      End If
      SaveBank = WrkBank
      ._BCHNO = WrkBatchNo
      ._TRNBR = WrkTrnbr
      ._RDTE = MyUtils.SetDBDate(WrkReceiptDate)
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ' ------------------------  6/3/25  changed to only get fields needed
      ' myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
      ' myTXINV.GetOneTXA04Rec(._LISTNo, ._YEAR, ._TYPE)
      myTXINV.GetOneTXA04Rec(._LISTNo, ._YEAR, ._TYPE, Conn)

      If Not myTXINV.RecordNotFound Then
        ._NAME = Trim(myTXINV._NAME)
        If WrkDist Then
          ._DIST = myTXINV._DIST
        End If
      Else
        ._NAME = String.Empty
      End If
      'CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkReceiptDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
      ' WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
      CalcInterest(WrkListNo, WrkType, WrkYear, MyUtils.SetDBDate(WrkInterestDate), WrkInterest, WrkInterestPaid, WrkFeeDue,
      WrkCAFee, WrkLien, WrkBond, WrkTax, WrkDue)
      WrkFee(6) = 0
      WrkFeecd(6) = ""
      If WrkCAFee > 0 Then
        'Partial Payment
        If WrkPaid < WrkDue Then
          WrkOtherFee = WrkFeeDue - WrkCAFee
          WrkCAProrated = MyUtils.Round(WrkPaid * 0.15, 2)
          WrkFee(6) = WrkCAProrated
          WrkFeecd(6) = "CA"
          WrkFeeDue = WrkOtherFee + WrkCAProrated
        Else
          WrkFee(6) = WrkCAFee
          WrkFeecd(6) = "CA"
        End If
      End If
      If WrkFeeDue >= WrkPaid Then
        WrkFeeDue = WrkPaid
        WrkPaid = 0
      Else
        WrkPaid = WrkPaid - WrkFeeDue
      End If
      If WrkInterest >= WrkPaid Then
        WrkInterest = WrkPaid
        WrkPaid = 0
      Else
        WrkPaid = WrkPaid - WrkInterest
      End If
      If WrkBond >= WrkPaid Then
        WrkBond = WrkPaid
        WrkPaid = 0
      Else
        WrkPaid = WrkPaid - WrkBond
      End If
      If WrkPaid >= (WrkTax + WrkLien) And WrkLien > 0 Then
        WrkPaid = WrkPaid - WrkLien
      Else
        WrkLien = 0
      End If
      'Determine What Fees to pay
      With myTXINV
        WrkFee(0) = ._FED1
        WrkFee(1) = ._FED2
        WrkFee(2) = ._FED3
        WrkFee(3) = ._FED4
        WrkFee(4) = ._FED5
        WrkFeecd(0) = ._FEC1
        WrkFeecd(1) = ._FEC2
        WrkFeecd(2) = ._FEC3
        WrkFeecd(3) = ._FEC4
        WrkFeecd(4) = ._FEC5
        WrkFee(5) = 0
        WrkFeecd(5) = ""
      End With
      For I = 0 To 4
        If WrkFee(I) > 0 And WrkFeeDue > 0 Then
          If WrkFeeDue < WrkFee(I) Then
            WrkFee(I) = WrkFeeDue
          End If
          WrkFeeDue = WrkFeeDue - WrkFee(I)
        Else
          WrkFee(I) = 0
          WrkFeecd(I) = ""
        End If
      Next
      ._PAMT = WrkPaid
      ._IAMT = WrkInterest
      ._PCAMT = WrkFee(0) + WrkFee(1) + WrkFee(2) + WrkFee(3) + WrkFee(4) + WrkFee(5) + WrkFee(6)
      ._PCAMT1 = WrkFee(0)
      ._PCAMT2 = WrkFee(1)
      ._PCAMT3 = WrkFee(2)
      ._PCAMT4 = WrkFee(3)
      ._PCAMT5 = WrkFee(4)
      ._PCAMT6 = WrkFee(5)
      ._PCAMT7 = WrkFee(6)
      ._PENCD1 = WrkFeecd(0)
      ._PENCD2 = WrkFeecd(1)
      ._PENCD3 = WrkFeecd(2)
      ._PENCD4 = WrkFeecd(3)
      ._PENCD5 = WrkFeecd(4)
      ._PENCD6 = WrkFeecd(5)
      ._PENCD7 = WrkFeecd(6)
      ._LAMT = WrkLien
      ._ADJ = String.Empty
      K = LookupBankCd(WrkBank)
      ._BKCD = WrkBank
      If K >= 0 Then
        ._REF = WrkCheckNo(K)
        ._COMM = WrkBankName(K)
      Else
        ._REF = String.Empty
        If WrkBank <> String.Empty Then
          ._COMM = Mid(GetTXBanksDesc(WrkBank), 1, 20)
        Else
          ._COMM = String.Empty
        End If
      End If
      If WrkComment <> String.Empty Then
        ._COMM = WrkComment
      End If
      If WrkOverride Then
        ._REF = WrkOverCheckNo
      End If
      SaveBankName = Trim(._COMM)
      SaveCheckNo = Trim(._REF)
      ._PMETH = "2"
      ._SRC = 4
      myTCRBCH.AddOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With
    TotCount = TotCount + 1
    TotPaid = TotPaid + WrkPaid
    TotInt = TotInt + WrkInterest
    TotFee = TotFee + myTCRBCH._PCAMT
    TotLien = TotLien + WrkLien

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

WriteBatch:
    With myBCHHDR
      ._APPID = CBatchType
      ._BCHNO = WrkBatchNo
      ._ORGUS = "NET-TXA04"
      ._STATS = "S"
      ._SUBST = "K"
      ._PSDT = MyUtils.SetDBDate(WrkReceiptDate)
      ._STRDT = MyUtils.SetDBDate(WrkInterestDate)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(CBatchType, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkBatchNo
        .UpdateOneRecordP()
      End With
    Else
      With myBCHHDR
        ._APPID = CBatchType
        ._BCHNO = 0
        ._LSBCH = WrkBatchNo
        .AddOneRecordP()
      End With
    End If

    dr = ds.Tables(0).NewRow
    dr.Item("count") = TotCount
    dr.Item("bankcd") = SaveBank
    dr.Item("bankname") = SaveBankName
    dr.Item("checkno") = SaveCheckNo
    dr.Item("pamt") = TotPaid
    dr.Item("iamt") = TotInt
    dr.Item("lamt") = TotLien
    dr.Item("pcamt") = TotFee
    dr.Item("total") = TotPaid + TotInt + TotLien + TotFee
    ds.Tables(0).Rows.Add(dr)
    sr.Close()
    'added 6/3/25 close of conn
    If Conn IsNot Nothing AndAlso Conn.State = ConnectionState.Open Then
      Conn.Close()
    End If
    myFrmProgress.Close()
    myTCRBCH.CloseFile()

  End Sub
  Private Function LookupBankCd(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkBankCd.GetUpperBound(0)
      If Trim(WrkBankCd(I)) = "" Then
        Return -1
      End If
      If Trim(Code) = Trim(WrkBankCd(I)) Then
        Return I
      End If
    Next

  End Function
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByVal InDate As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
  ByRef OutFee As Decimal, ByRef OutCAFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal,
  ByRef OutTax As Decimal, ByRef OutDue As Decimal)
    With MyCASHINT
      If InDate > 0 Then
        .In_IntDate = MyUtils.GetDBDate(InDate)
      Else
        .In_IntDate = WrkReceiptDate
      End If
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutCAFee = Format(.Out_CAFee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub
End Module






