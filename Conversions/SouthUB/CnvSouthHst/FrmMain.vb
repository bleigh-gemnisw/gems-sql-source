Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Emit
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.VisualStyles
Public Class FrmMain
  Dim sw As StreamWriter
  Public myDBConnect As DBConnection 'Connection #1
  Public myDBConnect2 As DBConnection 'Connection #2
  Public myDBConnect3 As DBConnection 'Connection #3
  Public myDBConnect4 As DBConnection 'Connection #4
  Public myDBConnectGEMS As DBConnection 'GEMS Connection
  Public myDBConnectGEMS2 As DBConnection 'GEMS Connection 2
  Dim AcctXref As New Dictionary(Of String, List(Of Integer))()
  Dim MyTOWN As TOWN
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkFile As String
  Dim MyGLYear As Integer
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    Dim WrkTimeStamp As String
    WrkTimeStamp = Format(Date.Now, "MMddyyyy HHmmss")
    sw = New StreamWriter(GetDataPath() & "CnvSouthHst-" & WrkTimeStamp & ".csv")
    ProgBar1.Visible = True
    MyTOWN = New TOWN(myDBConnectGEMS.MyConn2)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    TxtErrorMsg.Text = TxtErrorMsg.Text & "TXHST" & vbCrLf
    NewHST() 'History file
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "Check Detail" & vbCrLf
    'CheckDetail() 'Check for missing UTCUST
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
    myDBConnect3 = New DBConnection()
    myDBConnect3.Open()
    myDBConnect4 = New DBConnection()
    myDBConnect4.Open()
    myDBConnectGEMS = New DBConnection()
    myDBConnectGEMS.Open2()
    myDBConnectGEMS2 = New DBConnection()
    myDBConnectGEMS2.Open2()
  End Sub
  Private Sub NewHST()
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkMunCid As Integer
    Dim SaveCid As Integer
    Dim WrkMunBillNo As Integer
    Dim SaveBillNo As Integer
    Dim WrkPrin As Decimal
    Dim WrkInt As Decimal
    Dim WrkTotPrin As Decimal
    Dim WrkTotInt As Decimal
    Dim WrkTotal As Decimal
    Dim WrkLastPaid As Integer
    Dim WrkMsg As String
    Dim I As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Integer
    Dim WrkRecID As Integer

    WrkRecID = 6594
    MyTXHST = New TXHST(myDBConnectGEMS.MyConn2)
    MyTXINV = New TXINV(myDBConnectGEMS.MyConn2)
    WrkFile = "TXHST"
    WrkType = "D"
    ds = myDBConnect.RunQuery("ar_history_detail", " where bd_last_activity>='2026-03-14' order by a_ar_customer_cid,a_bill_year,a_bill_number")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With MyTXHST
        Counter = Counter + 1
        WrkMunCid = ds.Tables(0).Rows(I).Item("a_ar_customer_cid")
        If SaveCid <> WrkMunCid Then
          ds2 = myDBConnectGEMS.RunQuery2("logut", " where cucnt#=" & WrkMunCid)
          If ds2.Tables(0).Rows.Count = 0 Then
            ds2 = myDBConnectGEMS.RunQuery2("utcust", " where cucnt#=" & WrkMunCid)
            If ds2.Tables(0).Rows.Count = 0 Then
              sw.WriteLine("No UT," & WrkMunCid)
              GoTo NextRec
            End If
          End If
          WrkListNo = ds2.Tables(0).Rows(0).Item("cuacct")
        End If
        SaveCid = WrkMunCid
        WrkYear = ds.Tables(0).Rows(I).Item("a_bill_year")
        WrkMunBillNo = ds.Tables(0).Rows(I).Item("a_bill_number")
        If WrkMunBillNo = SaveBillNo Then
          Continue For
        End If
        SaveBillNo = WrkMunBillNo
        ds3 = myDBConnect.RunQuery("ar_history_detail", "where a_ar_customer_cid=" & WrkMunCid & " And a_bill_number=" & WrkMunBillNo & " And a_bill_year=" & WrkYear &
           " And bd_paid_amount<>0 and bd_last_activity>='2026-03-14' order by bd_last_activity")
        WrkLastPaid = 0
        WrkTotPrin = 0
        WrkTotInt = 0
        WrkTotal = 0
        ' Dictionary to group and sum by date
        Dim dict As New Dictionary(Of Date, (IAMT As Decimal, PAMT As Decimal, Rows As List(Of DataRow)))()
        For Each row As DataRow In ds3.Tables(0).Rows
          Dim postDate As Date = row("bd_last_activity")
          WrkPrin = 0
          WrkInt = 0
          If row("bd_original_amount") <> 0 Then
            WrkPrin = row("bd_paid_amount")
            WrkLastPaid = ConvertDate(postDate)
          End If
          If CnvSng(row("a_charge_code")) = 0 Then
            Continue For
          End If
          If CnvSng(row("a_charge_code")) = 100000 Then 'Lien Payment
            WrkPrin = row("bd_paid_amount")
            WrkLastPaid = ConvertDate(postDate)
          End If
          If CnvSng(row("a_charge_code")) = 91000 Then 'Interest
            WrkInt = row("bd_paid_amount")
          End If
          ' Add to dictionary
          If dict.ContainsKey(postDate) Then
            dict(postDate) = (dict(postDate).IAMT + WrkInt, dict(postDate).PAMT + WrkPrin, dict(postDate).Rows)
            dict(postDate).Rows.Add(row)
          Else
            dict(postDate) = (WrkInt, WrkPrin, New List(Of DataRow)() From {row})
          End If
          WrkTotPrin = WrkTotPrin + WrkPrin
          WrkTotInt = WrkTotInt + WrkInt
          WrkTotal = WrkTotal + WrkPrin + WrkInt
        Next

        If WrkTotal = 0 Then
          GoTo NextRec
        End If

        WrkMsg = ""
        With MyTXINV
          .GetOneRecordP(WrkListNo, WrkYear, WrkType)
          If .RecordNotFound Then
            sw.WriteLine("Skip," & WrkListNo & "," & WrkYear & "," & WrkTotPrin & "," & WrkTotInt & "," & WrkLastPaid)
            GoTo NextRec
          End If
          ._INTPD = ._INTPD + WrkTotInt
          ._PAYREC = ._PAYREC + WrkTotPrin
          ._BALD = ._BALD - WrkTotPrin
          ._PRPRI = 0
          If WrkTotPrin > 0 Then
            ._TXIDT = WrkLastPaid
          End If
          ._PRF = "Miss3"
          .UpdateOneRecordP()
          sw.WriteLine(WrkMsg & "," & WrkListNo & "," & WrkYear & "," & WrkTotPrin & "," & WrkTotInt & "," & WrkLastPaid)
          If .ErrMsg <> String.Empty Then
            sw.WriteLine("Error" & "," & WrkListNo & "," & WrkYear & "," & WrkTotPrin & "," & WrkTotInt & "," & WrkLastPaid)
          End If
        End With

        ' Now insert one record per posting date with sums
        For Each kvp In dict
          Dim postDate As Date = kvp.Key
          Dim sumIAMT As Decimal = kvp.Value.IAMT
          Dim sumPAMT As Decimal = kvp.Value.PAMT
          Dim rows As List(Of DataRow) = kvp.Value.Rows

          ' Use the first row in the group for other fields like hh_batch, a_effective_date
          Dim firstRow As DataRow = rows(0)
          WrkRecID = WrkRecID + 1
          ' Initialize your record
          If sumPAMT >= 0 Then
            ._ADJCD = ""
          Else
            ._ADJCD = "A"
          End If
          ._BATCHA = ""
          ._BATCHN = 0
          ._BATCHS = 0
          ._CASH = 0
          ._CDATE = ConvertDate(firstRow("bd_last_activity"))
          ._CHDATE = ConvertDate(postDate)
          ._CHECK = 0
          ._CHTIME = 0
          ._CORC = ""
          ._CREDIT = 0
          ._DIST = ds2.Tables(0).Rows(0).Item("cudst")
          ._IAMT = sumIAMT
          ._INTOR = 0
          ._LAMT = 0
          ._LISTNO = WrkListNo
          ._PAMT = sumPAMT
          ._PCAMT = 0
          ._PDATE = ConvertDate(postDate)
          ._PENCD = ""
          ._RCODE = ""
          ._RECID = WrkRecID
          ._REF = ""
          ._SUSCD = ""
          ._THAJCD = ""
          ._THINPD = 0
          ._TYPE = WrkType
          ._YEAR = WrkYear
          ._PRF = "Miss3"
          .InsertOneRecordP()
        Next
      End With

NextRec:
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        ProgBar1.Value = WrkPct
        LblMsg.Text = "Records processed:  " & Counter
        '.Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    Next

    ds = Nothing
  End Sub
  Private Sub CheckDetail()
    '    Dim ds As DataSet = New DataSet
    '    Dim ds2 As DataSet = New DataSet
    '    Dim WrkMunCid As Integer
    '    Dim SaveCid As Integer
    '    Dim I As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Integer

    '    SaveCid = 0
    '    ds = myDBConnect.RunQuery("ar_history_detail", " where bd_last_activity>='2026-03-01' order by a_ar_customer_cid")
    '    For I = 0 To ds.Tables(0).Rows.Count - 1
    '      Counter = Counter + 1
    '      WrkMunCid = ds.Tables(0).Rows(I).Item("a_ar_customer_cid")
    '      If SaveCid <> WrkMunCid Then
    '        ds2 = myDBConnectGEMS.RunQuery2("utcust", "where cucnt#=" & WrkMunCid)
    '        If ds2.Tables(0).Rows.Count = 0 Then
    '          sw.WriteLine("No UTCUST," & WrkMunCid)
    '        End If
    '      End If
    '      SaveCid = WrkMunCid

    'NextRec:
    '      WrkPct = (Counter / 10) Mod 100
    '      If SavePct <> WrkPct Then
    '        ProgBar1.Value = WrkPct
    '        LblMsg.Text = "Records processed:  " & Counter
    '        '.Refresh()
    '        SavePct = WrkPct
    '        Application.DoEvents()
    '      End If
    '    Next

    '    ds = Nothing
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    WrkStr = Replace(WrkStr, "'", "")
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine("Truncate," & WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
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
  Private Function ConvertRate(WrkServiceCd As Integer, WrkRateCd As Integer) As (Meter As String, Code As String)

    Select Case WrkServiceCd
      Case 1000, 1500
        Select Case WrkRateCd
          Case 210
            Return ("RES", "RES")
          Case 211
            Return ("RE1", "RES")
          Case 212
            Return ("RE2", "RES")
          Case 213
            Return ("REA", "RES")
          Case 220, 240
            Return ("COM", "COM")
          Case 230
            Return ("IND", "IND")
          Case 290
            Return ("MUN", "COM")
        End Select
      Case 2000
        Select Case WrkRateCd
          Case 210
            Return ("WRE", "WEL")
          Case 211
            Return ("WE1", "WEL")
          Case 212
            Return ("WE2", "WEL")
          Case 220, 240
            Return ("WCO", "WEL")
          Case 230
            Return ("WIN", "WEL")
          Case 290
            Return ("WMU", "WEL")
        End Select
      Case 2500 : Return ("CHG", WrkRateCd.ToString())
      Case 3000 : Return ("PLN", "PLN")
      Case 4000 : Return ("MER", "MER")
      Case 5000 : Return ("GRO", "GRO")
      Case 9028, 9029, 9032, 9033
        Return ("", "")
      Case Else
        Return ("", "")
    End Select
    Return ("", "")
  End Function
  Private Function ConvertLoc(ByVal WrkLoc As String) As String
    WrkLoc = Replace(WrkLoc, "TERRACE", "TERR")
    WrkLoc = Replace(WrkLoc, "TER", "TERR")
    WrkLoc = Replace(WrkLoc, "TERRR", "TERR")
    WrkLoc = Replace(WrkLoc, "WDS", "WOODS")
    WrkLoc = Replace(WrkLoc, "MERIDEN WATERRBURY TPKE", "MERIDEN WATERBURY TPKE")
    WrkLoc = Replace(WrkLoc, "CENTERR", "CENTER")
    WrkLoc = Replace(WrkLoc, "PONDVIEW", "POND VIEW")
    WrkLoc = Replace(WrkLoc, "SOUTH FARM ", "SOUTH FARMS ")
    WrkLoc = Replace(WrkLoc, "WALKERS XING", "WALKERS CROSSING")
    Return WrkLoc
  End Function
  Private Function TrimAfterStreetSuffix(address As String) As String
    If String.IsNullOrWhiteSpace(address) Then Return address

    ' Common US street suffixes (add/remove as needed)
    Dim suffixes As String =
        "ALY|AV|AVE|BLVD|CIR|CT|DR|HWY|LN|PKWY|PL|PLZ|RD|SQ|ST|TER|TRL|WAY"

    ' Pattern:
    ' Start → any chars → space → suffix → optional period → stop
    Dim pattern As String =
        "\b(.+?\s(" & suffixes & ")\.?)\b"

    Dim match As Match = Regex.Match(address.ToUpper(), pattern)

    If match.Success Then
      Return match.Groups(1).Value.Trim()
    Else
      Return address.Trim() ' Return original if no suffix found
    End If
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
  Public Function FlipName(inputName As String) As String
    Dim name As String = inputName.Trim()

    '---- 1. Detect businesses (NO FLIP) ----
    Dim businessKeywords() As String = {
        "LLC", "INC", "CO", "CORP", "COMPANY", "LTD", "LLP"
    }

    For Each word In businessKeywords
      If name.ToUpper().Contains(" " & word) Then
        Return name   ' Business name → do not flip
      End If
    Next

    '---- 2. Detect couples: "John & Mary Smith" ----
    Dim normalized As String = name.Trim()

    ' Normalize delimiters
    normalized = normalized.Replace(" AND ", " & ")
    normalized = normalized.Replace(",", " & ")

    Dim suffixes() As String = {"JR", "SR", "II", "III", "IV"}

    ' Split owners
    Dim owners() As String = normalized.Split("&"c)
    Dim cleanedOwners As New List(Of String)
    For Each o In owners
      If o.Trim() <> "" Then cleanedOwners.Add(o.Trim())
    Next

    ' Extract last names
    Dim lastNames As New List(Of String)
    Dim firstNames As New List(Of String)

    Dim Owner As String
    For Each Owner In cleanedOwners
      Dim words() As String = Owner.Split(" "c)
      If words.Length = 0 Then Continue For

      ' Handle suffix
      Dim suffix As String = ""
      Dim lastNameIndex As Integer = words.Length - 1
      If suffixes.Contains(words(lastNameIndex).ToUpper()) AndAlso words.Length >= 2 Then
        suffix = " " & words(lastNameIndex)
        lastNameIndex -= 1
      End If

      Dim lastName As String = words(lastNameIndex)
      Dim firstName As String = String.Join(" ", words, 0, lastNameIndex)

      lastNames.Add(lastName & suffix)
      firstNames.Add(firstName)
    Next

    ' Check if all last names are the same
    Dim allSame As Boolean = lastNames.Distinct(StringComparer.OrdinalIgnoreCase).Count() = 1

    If allSame Then
      ' Combine first names
      Return lastNames(0) & ", " & String.Join(" & ", firstNames)
    Else
      ' Keep each owner separately
      Dim result As New List(Of String)
      For i As Integer = 0 To cleanedOwners.Count - 1
        result.Add(lastNames(i) & ", " & firstNames(i))
      Next
      Return String.Join(" & ", result)
    End If

    '---- 3. Standard names: single person ----
    Dim p() As String = name.Split(" "c)
    If p.Length < 2 Then Return name ' single word → no flip

    Dim ln As String = p(p.Length - 1)                    ' last name
    Dim fn As String = String.Join(" ", p, 0, p.Length - 1) ' first + middle

    Return ln & ", " & fn
  End Function
  Public Function JustifyRight(ByVal StrInput As String, ByVal MaxLength As Integer,
  Optional ByVal StrPadChar As String = " ") As String
    'Right justify a string and pad to left. If it's too big then chop it at max length.
    Dim InputLength As Integer
    Dim StrOutput As String
    InputLength = Len(StrInput)
    StrOutput = StrInput
    If InputLength > MaxLength Then 'Error
      Return Mid(StrInput, 1, MaxLength)
    End If

    Do Until InputLength = MaxLength
      StrOutput = StrPadChar & StrOutput
      InputLength = InputLength + 1
    Loop
    Return StrOutput
  End Function
End Class