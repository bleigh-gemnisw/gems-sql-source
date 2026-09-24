Imports System.IO
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Module TasksToPerform

  Dim mysqlstring As String
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim WrkNoCustFound As Boolean
  Dim wrkmorethanonehit As Boolean
  Dim WrkalreadyMeter As Boolean
  Dim wrkreadingerror As Boolean
  Public Sub Task1()
    Dim WrkStream As FileStream = New FileStream(MyFrmGemniTaskB.LblFilePath1.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkXref As String
    Dim WrkAcct As Integer
    Dim WrkName As String
    Dim WrkLocation As String
    Dim SaveXref As String
    Dim wrklocno As String = ""
    Dim wrkloc As String = ""
    Dim WrkPath As String
    Dim WrkFileName As String
    Dim WrkTimestamp As String

    WrkPath = MyUtils.GetDataPath() & "Logs\"
    WrkFileName = "GEMNITASK-1 LOG"
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath &
      "-" & WrkFileName & "-" & WrkTimestamp & ".TXT")
    sw.WriteLine("Reading Issues")
    sw.WriteLine("")

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Reading file........"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SavePct = 0

    WrkFileSize = WrkStream.Length
    WrkXref = ""
    WrkName = ""
    WrkLocation = ""
    SaveXref = ""
    'Read the File
NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo Cleanup
    End If
    I = I + strBuffer.Length

    WrkAcct = 0
    WrkXref = ""
    WrkName = ""
    WrkLocation = ""
    wrkloc = ""
    wrklocno = ""

    WrkName = Trim(Mid(strBuffer, 109, 30)) & " " & Trim(Mid(strBuffer, 189, 30))
    WrkLocation = Mid(strBuffer, 29, 30)
    WrkXref = MyUtils.CnvSng(Mid(strBuffer, 1, 8))

    ' Call the procedure to split the location for only Location description
    If Trim(WrkLocation > "") Then
      SplitLocation(Trim(WrkLocation), wrklocno, wrkloc)
    End If
    If Trim(WrkName) = "" And Trim(wrkloc) = "" Then
      GoTo NextLine
    End If
    GetCust(WrkName, wrkloc, WrkXref)
    If WrkNoCustFound = True Then
      sw.WriteLine("Customer not found          : " & WrkName & " Location: " & wrkloc)
    End If
    If wrkmorethanonehit = True Then
      sw.WriteLine("More than 1 Customer Found  : " & WrkName & " Location: " & wrkloc)
    End If
    If WrkalreadyMeter = True Then
      sw.WriteLine("Customer already has a meter: " & WrkName & " Location: " & wrkloc)
    End If
    If wrkreadingerror = True Then
      sw.WriteLine("Reading Error               : " & WrkName & " Location: " & wrkloc)
    End If

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
    sw.Close()
    sr.Close()
    myFrmProgress.Close()
    MsgBox("Task Complete")
  End Sub
  Private Sub GetCust(ByVal Wrkname As String, ByVal wrkloc As String, ByVal wrkMeter As String)
    Dim WrkSort As String
    Dim WrkQry As String
    Dim counter As Integer
    Dim DsUTCUST As DataSet = New DataSet
    Dim myUTCUSTQ As UTCUSTQ.MyData
    Dim myUTCUST As UTCUST.MyData
    Dim myUTXREF As UTXREF.MyData
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTXREF = New UTXREF.MyData(myDBConnect)

    WrkSort = ""
    'WrkQry = "TRIM(CUNAM1) = '" & Wrkname.Trim().Replace("'", "''") & "' AND TRIM(CULOC) = '" & wrkloc.Trim().Replace("'", "''") & "'"
    WrkQry = "CUNAM1 = '" & Wrkname.Trim().Replace("'", "''") & "' AND CULOC = '" & wrkloc.Trim().Replace("'", "''") & "'"

    DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)
    If DsUTCUST.Tables(0).Rows.Count = 0 Then
      WrkNoCustFound = True
      Exit Sub
    End If
    'If DsUTCUST.Tables(0).Rows.Count > 1 Then
    '  wrkmorethanonehit = True
    '  Exit Sub
    'End If

    For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
      With DsUTCUST.Tables(0).Rows(I)
        WrkalreadyMeter = False
        wrkmorethanonehit = False
        WrkNoCustFound = False
        wrkreadingerror = False
        If myUTCUSTQ.RecordNotFound = True Then
          WrkNoCustFound = True
          Exit Sub
        End If
        counter = counter + 1

        'With myUTCUST
        '  .GetOneRecordP(DsUTCUST.Tables(0).Rows(I).Item("CUACCT"))
        '  If (._CUMETN > "" And Trim(._CUMETN) <> Trim(wrkMeter)) Then
        '    WrkalreadyMeter = True
        '  End If
        '  ._CUMETN = wrkMeter
        '  .UpdateOneRecordP()
        'End With
        With myUTXREF
          .GetOneRecordP(DsUTCUST.Tables(0).Rows(I).Item("CUACCT"), "", wrkMeter)
          If .RecordNotFound Then
            ._CXACCT = DsUTCUST.Tables(0).Rows(I).Item("CUACCT")
            ._CXCODE = ""
            ._CXREF = wrkMeter
            ._CXUSE = ""
            .AddOneRecordP()
          End If
        End With
      End With
    Next
  End Sub
  Private Sub SplitLocation(ByVal field As String, ByRef locNumber As String, ByRef loc As String)

    Dim parts As String() = field.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

    ' Check if the first part is a number
    If parts.Length > 0 AndAlso IsNumeric(parts(0)) Then
      locNumber = parts(0) ' The first part is the location number
      loc = Trim(String.Join(" ", parts.Skip(1))) ' The remaining parts form the location
    Else
      ' If no number is found, locNumber is empty and loc is the entire field
      locNumber = ""
      loc = Trim(field)
    End If
  End Sub
End Module
