Imports System.Text
Imports System.IO
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim ds1 As DataSet = New DataSet
Dim dr As Data.DataRow

'General
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkNo As Integer
Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkMail As Boolean
Dim WrkStatus As String
Dim WrkOmitStatus As Boolean

Dim WrkGrpCount As Integer
Dim WrkGrpTax As Decimal
Dim WrkGrpPaid As Decimal
Dim WrkGroupBalance As Decimal

Public Sub PrtReport()
  myTXINVQ = New TXINVQ.mydata(MyDBConnect)

  With MyFrmTXE52B
    WrkNo = .TxtNo.Text
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkStatus = .TxtStatus.Text
    WrkOmitStatus = False
    If .ChkOmitStatus.Checked Then
      WrkOmitStatus = True
    End If
    WrkMail = .RbMail.Checked
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
  Else
    ds1.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.Decimal"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("TaxDue", Type.GetType("System.Decimal"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
Private Sub ClearGrpTotals()
  WrkGrpCount = 0
  WrkGrpTax = 0
  WrkGrpPaid = 0
  WrkGroupBalance = 0
End Sub
Private Sub GetDetail()
Dim sw As StreamWriter
Dim WrkSort As String
Dim WrkQry As String
Dim WrkListNo As Integer
Dim WrkYear As Integer
Dim WrkType As String
Dim WrkAddr As String
Dim Counter As Integer
Dim SaveYear As Integer
Dim SaveType As String
Dim SaveName As String
Dim SaveAdd1 As String
Dim SaveCity As String
Dim SaveState As String

Dim WrkTax As Decimal
Dim WrkPaid As Decimal
Dim WrkBalance As Decimal
Dim WrkTypes As String
Dim Pos As Integer
Dim Good As Boolean

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "icode<>'I'" & WrkAnd & "Icode<>'D'" & WrkAnd & "payrec > 0"

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If

MyTypes = MyFrmTXE52B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    If MyFrmTXE52B.LblFilePath.Text <> String.Empty Then
  sw = New StreamWriter(MyFrmTXE52B.LblFilePath.Text)
  sw.WriteLine(HeadingsCSV)
End If

If WrkMail Then
  WrkSort = "NAME, ADD1, TYPE, YEAR"
Else
  WrkSort = "NAME, LOC, LOC#, TYPE, YEAR"
End If
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

Counter = 0
SaveType = ""
SaveName = ""
SaveAdd1 = ""
SaveCity = ""
SaveState = ""
ClearGrpTotals()

ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
  With myTXINVQ
    Counter = Counter + 1
    If WrkMail Then
      WrkAddr = Trim(._ADD1)
    Else
      WrkAddr = Trim(._LOC) & " " & Trim(._LOCNo)
    End If
    If SaveName <> "" And SaveName <> ._NAME Or _
      SaveAdd1 <> "" And SaveAdd1 <> WrkAddr Then
      WriteTotals(SaveName, SaveAdd1, SaveCity, SaveState)
      ClearGrpTotals()
    End If

    'Filter - Status Codes
    If Trim(WrkStatus) > "" Then
      If WrkOmitStatus Then
      'Omit
        Pos = 0
        If Trim(._STCD1) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD1), 1)
        End If
        If Pos = 0 And Trim(._STCD2) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD2), 1)
        End If
        If Pos = 0 And Trim(._STCD3) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD3), 1)
        End If
        If Pos = 0 And Trim(._STCD4) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD4), 1)
        End If
        If Pos = 0 And Trim(._STCD5) <> "" Then
          Pos = InStr(1, WrkStatus, Trim(._STCD5), 1)
        End If
        If Pos > 0 Then GoTo NextRec
      Else
        'Select
        Good = False
        'Filter - Include Status Codes
        If WrkStatus = String.Empty Then
          Good = True
        End If
        If Not Good And Trim(._STCD1) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD2) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD3) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD4) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
            Good = True
          End If
        End If
        If Not Good And Trim(._STCD5) <> String.Empty Then
          If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
            Good = True
          End If
        End If
        If Not Good Then GoTo NextRec
      End If
    End If

    WrkListNo = ._LISTNo
    WrkYear = ._YEAR
    WrkType = ._TYPE
    If ._CCNO > 0 Then
      WrkTax = ._CCETAX
    Else
      WrkTax = ._TAXT
    End If
    WrkPaid = ._PAYREC
    WrkBalance = ._BALD
    SaveYear = ._YEAR
    SaveType = ._TYPE
    SaveName = ._NAME
    If WrkMail Then
      SaveAdd1 = Trim(._ADD1)
    Else
      SaveAdd1 = Trim(._LOC) & " " & Trim(._LOCNo)
    End If
    SaveCity = ._CITY
    SaveState = ._STATE

    WrkGrpCount = WrkGrpCount + 1
    WrkGrpTax = WrkGrpTax + WrkTax
    WrkGrpPaid = WrkGrpPaid + WrkPaid
    WrkGroupBalance = WrkGroupBalance + WrkBalance

    If MyFrmTXE52B.LblFilePath.Text <> String.Empty Then
      sw.WriteLine(DetailCSV(WrkListNo, SaveYear, SaveType, SaveName, SaveAdd1, WrkTax, WrkPaid, _
       WrkBalance))
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
    GoTo ReadNext
  End If

WriteTotals(SaveName, SaveAdd1, SaveCity, SaveState)
If MyFrmTXE52B.LblFilePath.Text <> String.Empty Then
  sw.WriteLine(DetailCSV(WrkListNo, SaveYear, SaveType, SaveName, SaveAdd1, WrkTax, WrkPaid, _
   WrkBalance))
  sw.Close()
End If

myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveName As String, ByVal SaveAdd1 As String, _
 ByVal SaveCity As String, ByVal SaveState As String)
  If WrkGrpCount = 0 Then Exit Sub

  dr = ds1.Tables(0).NewRow
  dr.Item("sortdata") = WrkGrpPaid
  dr.Item("name") = SaveName
  dr.Item("addr1") = SaveAdd1
  dr.Item("city") = SaveCity
  dr.Item("state") = SaveState
  dr.Item("taxdue") = WrkGrpTax
  dr.Item("paid") = WrkGrpPaid
  dr.Item("balance") = WrkGroupBalance
  ds1.Tables(0).Rows.Add(dr)
End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("LIST NO")
    sb.Append(CComma)
    sb.Append("YEAR")
    sb.Append(CComma)
    sb.Append("TYPE")
    sb.Append(CComma)
    sb.Append("NAME")
    sb.Append(CComma)
    If WrkMail Then
      sb.Append("ADDRESS")
    Else
      sb.Append("PROPERTY LOCATION")
    End If
    sb.Append(CComma)
    sb.Append("TAX DUE")
    sb.Append(CComma)
    sb.Append("TAX PAID")
    sb.Append(CComma)
    sb.Append("BALANCE")
    Return sb.ToString
  End Function
  Private Function DetailCSV(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String, _
  ByVal Name As String, ByVal Add1 As String, ByVal TaxDue As Decimal, ByVal Paid As Decimal, _
  ByVal Balance As Decimal) As String
  Dim sb As StringBuilder
  Dim CComma As String = ","

  sb = New StringBuilder
  sb.Append(ListNo)
  sb.Append(CComma)
  sb.Append(Year)
  sb.Append(CComma)
  sb.Append(Type)
  sb.Append(CComma)
  sb.Append(Name)
  sb.Append(CComma)
  sb.Append(Add1)
  sb.Append(CComma)
  sb.Append(TaxDue)
  sb.Append(CComma)
  sb.Append(Paid)
  sb.Append(CComma)
  sb.Append(Balance)
  Return sb.ToString

End Function
End Module






