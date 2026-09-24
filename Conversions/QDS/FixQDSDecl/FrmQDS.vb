Imports System.Text
Imports System.IO
Public Class FrmQDS
  Dim sw As StreamWriter
  Public myDBConnect As DBConnection
  Public myDBConnect2 As DBConnection
  Public myDBConnectGEMS As DBConnection
  Dim MyTOWN As TOWN
  Dim MyTAXCOM As TAXCOM
  Dim MyTXDCAFF As TXDCAFF
  Dim MyTXDCCD As TXDCCD
  Dim MyTXDCDEP As TXDCDEP
  Dim MyTXDCDTL As TXDCDTL
  Dim MyTXDCEXM As TXDCEXM
  Dim MyTXDCHOR As TXDCHOR
  Dim MyTXDCMV As TXDCMV
  Dim MyTXDCPP As TXDCPP
  Dim MyTXDCSUM As TXDCSUM
  Dim WrkListNo As Integer
  Dim WrkFile As String
  Dim ArrCode(25) As String
  Dim ArrLtr(25) As String
  Dim ArrDecode(25) As String
  Const cLastYear As Integer = 2021 'Oldest year to convert
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    sw = New StreamWriter(GetDataPath() & "FixQDSDecl.csv")
    ProgBar1.Visible = True
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    WriteDCPP()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub DoNotRun()
  End Sub

  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect = New DBConnection()
    myDBConnect.Open()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open()
    myDBConnectGEMS = New DBConnection()
    myDBConnectGEMS.Open2()
  End Sub
  Private Sub WriteDCPP()
    Dim WrkYear As Integer
    Dim WrkOldListNo As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXDCPP = New TXDCPP(myDBConnectGEMS.MyConn2, "TXDCPP")
    MyTXDCSUM = New TXDCSUM(myDBConnectGEMS.MyConn2, "TXDCSUM")
    MyTXDCEXM = New TXDCEXM(myDBConnectGEMS.MyConn2, "TXDCEXM")
    myDBConnect.OpenQry("qds162..taxmast as a left join persmaster as b on a.acct_8=b.unique_id and a.yr=b.record_year", " where yr=2022 And b.list_no Is Not null And a.bill_num<>b.list_no And len(a.acct_8)=7 order by bill_num desc")

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      WrkListNo = myDBConnect.objReader.Item("bill_num")
      WrkOldListNo = myDBConnect.objReader.Item("list_no")
      WrkYear = myDBConnect.objReader.Item("record_year")
      myDBConnectGEMS.UpdateRecords2("TXDCPP", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCSUM", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCDTL", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCEXM", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCAFF", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCHOR", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)
      myDBConnectGEMS.UpdateRecords2("TXDCMV", " set list#=" & WrkListNo & " where year=" & WrkYear & " and list#=" & WrkOldListNo)

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteDCAFF()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkYear As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXDCAFF = New TXDCAFF(myDBConnectGEMS.MyConn2, "TXDCAFF")
    myDBConnectGEMS.DeleteRecords2("TXDCAFF")
    myDBConnect.OpenQry("OUT_OF_BUSINESS", " where record_year>=" & cLastYear)
    WrkFile = "TXDCAFF"

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXDCAFF
        Counter = Counter + 1
        WrkYear = myDBConnect.objReader.Item("record_year")
        WrkQry = " where record_year=" & WrkYear & " And unique_id=" & myDBConnect.objReader.Item("unique_id")
        ds2 = myDBConnect2.RunQuery("PERSMASTER", WrkQry)
        WrkListNo = ds2.Tables(0).Rows(0).Item("list_no")
        .GetOneRecordP(WrkListNo, WrkYear)
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._ADDR = ""
        ._BUNAME = ""
        ._CITY = ""
        ._LOC = ""
        ._LOCNO = ""
        ._NAME = ""
        ._OWNAME = ""
        ._SIGNED = ""
        ._STATE = ""
        If Not IsDBNull(myDBConnect.objReader.Item("record_date")) Then
          ._TRANDT = ConvertDate(myDBConnect.objReader.Item("record_date"))
        Else
          ._TRANDT = 20000101
        End If
        ._TRANTY = "C"
        ._ZIP4 = 0
        ._ZIP5 = 0
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteDCDTL()
    Dim ds2 As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkCode As String
    Dim WrkLtr As String
    Dim WrkDeyear As Integer
    Dim WrkDecode As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim K As Integer

    MyTXDCDTL = New TXDCDTL(myDBConnectGEMS.MyConn2, "TXDCDTL")
    myDBConnectGEMS.DeleteRecords2("TXDCDTL")
    myDBConnect.OpenQry("TAXABLE_APPLIED", " where working_year>=" & cLastYear)
    WrkFile = "TXDCDTL"
    BufferDeprCodes(cLastYear)

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXDCDTL
        Counter = Counter + 1
        If CnvSng(myDBConnect.objReader.Item("amount_verify")) = 0 Then
          GoTo ReadNext
        End If
        WrkYear = myDBConnect.objReader.Item("working_year")
        WrkListNo = myDBConnect.objReader.Item("list_no")
        If Len(Trim(myDBConnect.objReader.Item("code"))) = 2 Then
          WrkCode = Trim(myDBConnect.objReader.Item("code"))
          WrkLtr = ""
        Else
          WrkCode = Mid(myDBConnect.objReader.Item("code"), 1, 2)
          WrkLtr = LCase(Mid(myDBConnect.objReader.Item("code"), 3, 1))
        End If
        WrkDeyear = myDBConnect.objReader.Item("yr_applied")
        WrkDecode = LookupDeprCode(WrkCode, WrkLtr)
        If WrkDecode = "" Then
          GoTo ReadNext
        End If
        Select Case WrkDecode 'Set Deyear to lowest year if under it
          Case "A", "C", "D", "E"
            If WrkYear - WrkDeyear > 7 Then
              WrkDeyear = WrkYear - 7
            End If
          Case "B"
            If WrkYear - WrkDeyear > 4 Then
              WrkDeyear = WrkYear - 4
            End If
          Case "G"
            If WrkYear - WrkDeyear > 5 Then
              WrkDeyear = WrkYear - 5
            End If
          Case "F"
            If WrkYear - WrkDeyear > 8 Then
              WrkDeyear = WrkYear - 8
            End If
        End Select
        .GetOneRecordP(WrkListNo, WrkYear, WrkCode, WrkLtr, WrkDeyear)
        If .RecordNotFound Then
          ._LISTNO = WrkListNo
          ._YEAR = WrkYear
          ._CODE = WrkCode
          ._LTR = WrkLtr
          ._DEYEAR = WrkDeyear
          ._DECOST = CnvSng(myDBConnect.objReader.Item("amount_verify"))
          .AddOneRecordP()
        Else
          ._DECOST = ._DECOST + CnvSng(myDBConnect.objReader.Item("amount_verify"))
          .UpdateOneRecordP()
        End If
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteDCHOR()
    Dim ds2 As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkSeq As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXDCHOR = New TXDCHOR(myDBConnectGEMS.MyConn2, "TXDCHOR")
    myDBConnectGEMS.DeleteRecords2("TXDCHOR")
    myDBConnect.OpenQry("HORSE_TABLE", "")
    WrkFile = "TXDCHOR"

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXDCHOR
        Counter = Counter + 1
        WrkListNo = myDBConnect.objReader.Item("list_no")
        WrkYear = myDBConnect.objReader.Item("yr_applied")
        WrkSeq = .AutoGenKey(WrkListNo, WrkYear)
        .GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._AGE = myDBConnect.objReader.Item("age")
        ._BREED = ConvertString("breed", myDBConnect.objReader.Item("breed"), 20)
        Select Case Trim(myDBConnect.objReader.Item("quality"))
          Case "P", "Pleasure"
            ._QUALCD = "P"
          Case Else
            ._QUALCD = ""
        End Select
        ._REG = ConvertString("reg", myDBConnect.objReader.Item("reg_no"), 10)
        ._SEQNO = WrkSeq
        Select Case Trim(myDBConnect.objReader.Item("sex"))
          Case "Mare"
            ._SEX = "F"
          Case "M"
            ._SEX = "M"
          Case Else
            ._SEX = ""
        End Select
        ._VALUE = myDBConnect.objReader.Item("net")
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub WriteDCMV()
    Dim ds2 As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkSeq As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXDCMV = New TXDCMV(myDBConnectGEMS.MyConn2, "TXDCMV")
    myDBConnectGEMS.DeleteRecords2("TXDCMV")
    myDBConnect.OpenQry("MOTOR_TABLE", "")
    WrkFile = "TXDCMV"

ReadNext:
    myDBConnect.ReadQry()
    If Not myDBConnect.IsEOF Then
      With MyTXDCMV
        Counter = Counter + 1
        WrkListNo = myDBConnect.objReader.Item("list_no")
        WrkYear = myDBConnect.objReader.Item("yr_applied")
        WrkSeq = .AutoGenKey(WrkListNo, WrkYear)
        .GetOneRecordP(WrkListNo, WrkYear, WrkSeq)
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeq
        ._MAKE = ConvertString("make", myDBConnect.objReader.Item("v_make"), 5)
        ._VYEAR = myDBConnect.objReader.Item("v_year")
        ._MODEL = ConvertString("model", myDBConnect.objReader.Item("v_model"), 8)
        ._VINNO = ConvertString("vin", myDBConnect.objReader.Item("v_vin"), 17)
        If myDBConnect.objReader.Item("v_length") <= 999 Then
          ._LENGTH = myDBConnect.objReader.Item("v_length")
        Else
          ._LENGTH = 0
          sw.WriteLine(WrkFile & "," & WrkListNo & "," & "Length,3" & myDBConnect.objReader.Item("v_length"))
        End If
        ._WEIGHT = myDBConnect.objReader.Item("v_weight")
        ._PURVL = myDBConnect.objReader.Item("v_puramt")
        ._PURDT = ConvertDate(myDBConnect.objReader.Item("v_purdate"))
        ._VALUE = myDBConnect.objReader.Item("v_value")
        .AddOneRecordP()
      End With

      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed: " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
        GoTo ReadNext
      End If
    End If
  End Sub
  Private Sub FixDCDTL()
    Dim ds2 As DataSet = New DataSet
    Dim WrkYear As Integer
    Dim WrkCode As Integer
    Dim WrkLtr As String
    Dim WrkDeyear As Integer
    Dim WrkDecode As String
    Dim WrkYearNo As Integer
    Dim WrkProrated As Integer
    Dim WrkValue As Integer
    Dim WrkTotValue As Integer
    Dim WrkDiff As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    MyTXDCDTL = New TXDCDTL(myDBConnectGEMS.MyConn2, "TXDCDTL")
    myDBConnectGEMS.OpenQry("TXDCDTL", " where year>=" & cLastYear)
    WrkFile = "TXDCDTL"
    BufferDeprCodes(cLastYear)

ReadNext:
    myDBConnectGEMS.ReadQry()
    If Not myDBConnectGEMS.IsEOF Then
      Counter = Counter + 1
      WrkYear = myDBConnect.objReader.Item("year")
      WrkListNo = myDBConnect.objReader.Item("list#")
      WrkCode = myDBConnect.objReader.Item("code")
      WrkLtr = Trim(myDBConnect.objReader.Item("ltr"))
      ds2 = MyTXDCDTL.GetByCode(WrkListNo, WrkYear, WrkCode)
      WrkTotValue = 0
      For I = 0 To ds2.Tables(0).Rows.Count - 1
        WrkYearNo = ds2.Tables(0).Rows(I).Item("year") - ds2.Tables(0).Rows(I).Item("deyear") + 1
        MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo)
        If MyTXDCDEP._PROPCT > 0 Then
          WrkProrated = Math.Round(ds2.Tables(0).Rows(I).Item("DECOST") * (MyTXDCDEP._PROPCT / 100), 0)
        Else
          WrkProrated = ds2.Tables(0).Rows(I).Item("DECOST")
        End If
        WrkValue = Math.Round(WrkProrated * (MyTXDCDEP._PCT / 100), 0)
        WrkTotValue = WrkTotValue + WrkValue
      Next
      MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
      WrkDiff = Math.Abs(WrkTotValue - MyTXDCSUM._VALUE)
      If WrkDiff > 1 Then
        WrkDecode = LookupDeprCode(WrkCode, WrkLtr)
        If WrkDecode = "" Then
          GoTo ReadNext
        End If
        Select Case WrkDecode 'Set Deyear to lowest year if under it
          Case "A", "C", "D", "E"
            If WrkYear - WrkDeyear > 7 Then
              WrkDeyear = WrkYear - 7
            End If
          Case "B"
            If WrkYear - WrkDeyear > 4 Then
              WrkDeyear = WrkYear - 4
            End If
          Case "G"
            If WrkYear - WrkDeyear > 5 Then
              WrkDeyear = WrkYear - 5
            End If
          Case "F"
            If WrkYear - WrkDeyear > 8 Then
              WrkDeyear = WrkYear - 8
            End If
        End Select
        myDBConnectGEMS.DeleteRecords2("TXDCDTL", " where year=" & WrkYear & " and list#=" & WrkListNo & " and code=" & WrkCode & " and ltr='" & WrkLtr & "'")
        With MyTXDCDTL
          .GetOneRecordP(WrkListNo, WrkYear, WrkCode, WrkLtr, WrkDeyear)
          If .RecordNotFound Then
            ._LISTNO = WrkListNo
            ._YEAR = WrkYear
            ._CODE = WrkCode
            ._LTR = WrkLtr
            ._DEYEAR = WrkDeyear
            ._DECOST = WrkTotValue
            .AddOneRecordP()
          End If
        End With

        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          ProgBar1.Value = WrkPct
          LblMsg.Text = "Records processed:  " & Counter
          '.Refresh()
          SavePct = WrkPct
          Application.DoEvents()
          GoTo ReadNext
        End If
      End If
    End If
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    WrkStr = Replace(WrkStr, "'", "")
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine(WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
    End If

    Return Trim(ReturnStr)
  End Function
  Private Function ConvertDate(ByVal DateIn As Date) As Integer

    Dim ReturnDate
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDate(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDateMDY(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function FormatZip(ByVal WrkZip As String) As String
    Dim Pos As Integer
    Dim WrkZipA As String

    If Trim(WrkZip) <> "" Then
      If Len(WrkZip) > 5 Then
        Pos = InStr(WrkZip, "-")
        If Pos = 0 Then
          WrkZipA = Mid(WrkZip, 1, 5) & "-" & Mid(WrkZip, 6, 4)
        Else
          WrkZipA = WrkZip
        End If
      Else
        WrkZipA = WrkZip
      End If
    Else
      WrkZipA = ""
    End If

    Return WrkZipA
  End Function
  Private Function CalcAddr(ByVal pAddress As String) As String

    Dim WrkAddress As String

    WrkAddress = pAddress
    WrkAddress = Replace(WrkAddress, "'", "")
    WrkAddress = Replace(WrkAddress, "/", "")
    WrkAddress = Replace(WrkAddress, "#", "")
    WrkAddress = Replace(WrkAddress, " AVENUE", " AVE")
    WrkAddress = Replace(WrkAddress, " AVENU", " AVE")
    WrkAddress = Replace(WrkAddress, " AV", " AVE")
    WrkAddress = Replace(WrkAddress, " AVEE", " AVE")
    WrkAddress = Replace(WrkAddress, " CIRCLE", " CIR")
    WrkAddress = Replace(WrkAddress, " COURT", " CT")
    WrkAddress = Replace(WrkAddress, " DRIVE", " DR")
    WrkAddress = Replace(WrkAddress, " HEIGHTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HGTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HT", " HTS")
    WrkAddress = Replace(WrkAddress, " HTSS", " HTS")
    WrkAddress = Replace(WrkAddress, " LANE", " LN")
    WrkAddress = Replace(WrkAddress, " LA", " LN")
    WrkAddress = Replace(WrkAddress, " PARKWAY", " PKY")
    WrkAddress = Replace(WrkAddress, " PLACE", " PL")
    WrkAddress = Replace(WrkAddress, " ROAD", " RD")
    WrkAddress = Replace(WrkAddress, " RIDGE", " RDG")
    WrkAddress = Replace(WrkAddress, " STREET", " ST")
    WrkAddress = Replace(WrkAddress, " TERRACE", " TER")
    WrkAddress = Replace(WrkAddress, " TERR", " TER")
    '    WrkAddress = Replace(WrkAddress, " ", "")
    WrkAddress = Replace(WrkAddress, ".", "")

    Return WrkAddress
  End Function
  Private Sub BufferDeprCodes(ByVal WrkYear As Integer)
    Dim dsFile As DataSet = New DataSet
    Dim I As Integer
    Dim J As Integer

    MyTXDCCD = New TXDCCD(myDBConnectGEMS.MyConn2, "TXDCCD")
    J = -1
    dsFile = MyTXDCCD.PosData(WrkYear, 0, "")
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        If .Item("year") > WrkYear Then
          Exit For
        End If
        If Trim(.Item("decode")) <> "" Then
          J = J + 1
          ArrCode(J) = Trim(.Item("code"))
          ArrLtr(J) = Trim(.Item("ltr"))
          ArrDecode(J) = Trim(.Item("decode"))
        End If
      End With
    Next
  End Sub
  Private Function LookupDeprCode(ByVal Code As String, ByVal Ltr As String) As String
    Dim I As Integer

    If Trim(Code) = "" Then Return True

    For I = 0 To ArrCode.GetUpperBound(0)
      If Trim(ArrCode(I)) = "" Then
        Return ""
      End If
      If Code = ArrCode(I) And Ltr = ArrLtr(I) Then
        Return ArrDecode(I)
      End If
    Next
    Return ""

  End Function
End Class