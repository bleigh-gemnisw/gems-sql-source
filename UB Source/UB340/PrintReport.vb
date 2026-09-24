Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUST As UTCUSTQ.myData
Dim dsUTCUST As DataSet = New DataSet

Dim ds As DataSet = New DataSet
Dim dr As DataRow
  Public Sub PrtReport()
  myUTCUST = New UTCUSTQ.mydata(MyDBConnect)
  With MyFrmUB340B
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .Show()
  End With

  End Sub
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("CitySt", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("SerialNo", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
  End With
  Ds.Tables.Add(myTable)
End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmUB340B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim strBuffer As String
    Dim sArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim J As Integer
    Dim WrkRecNo As Integer
    Dim Good As Boolean
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkSelect As String
    Dim WrkSerial As String
    Dim WrkCodes As String
    Dim drUTCUST() As DataRow

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkRecNo = 0
    WrkSort = ""
    WrkQry = ""
    strBuffer = sr.ReadLine 'Skip 1st record

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If
    Good = False
    I = I + strBuffer.Length
    sArray = Parse(strBuffer, ",")
    'Code 80 or 81 - Write Report & Letter
    WrkCodes = sArray(7)
    If WrkCodes = "" Then GoTo NextRec
    WrkSerial = ""

    For J = 1 To Len(WrkCodes) Step 2
      WrkSerial = sArray(6)
      If WrkSerial <> "" Then
        If Mid(WrkCodes, J, 2) = "80" Or Mid(WrkCodes, J, 2) = "81" Then
          dsUTCUST = myUTCUST.GetQry(WrkSort, WrkQry, 0)
          WrkSelect = "CUSERN=" & MyUtils.Quo(WrkSerial)
          If WrkSelect = String.Empty Then
            WrkSelect = "CUMETN=" & MyUtils.Quo(WrkSerial)
          End If
          drUTCUST = dsUTCUST.Tables(0).Select(WrkSelect)
          If Not Good And drUTCUST.GetUpperBound(0) >= 0 Then
            With drUTCUST(0)
              Good = True
              dr = ds.Tables(0).NewRow
              dr.Item("listno") = .Item("cuacct")
              dr.Item("name") = .Item("cunam1")
              If .Item("cumad1") = String.Empty Then
                dr.Item("addr") = .Item("cuadd1")
                dr.Item("cityst") = .Item("cucity") & "," & .Item("cust") & " " & .Item("cuzip")
              Else
                dr.Item("addr") = .Item("cumad1")
                dr.Item("cityst") = .Item("cumcty") & "," & .Item("cumst") & " " & .Item("cumzip")
              End If
              dr.Item("proploc") = Trim(.Item("culoc#")) & " " & .Item("culoc")
              dr.Item("serialno") = WrkSerial
              dr.Item("errmsg") = String.Empty
              ds.Tables(0).Rows.Add(dr)
            End With
          End If
        End If
      End If
    Next
    If Not Good Then
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = 0
      dr.Item("name") = String.Empty
      dr.Item("proploc") = sArray(2)
      dr.Item("serialno") = WrkSerial
      dr.Item("errmsg") = "No Match on Serial #"
      ds.Tables(0).Rows.Add(dr)
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

End_of_file:
    sr.Close()
    myFrmProgress.Close()
    myUTCUST.CloseFile()

  End Sub
End Module






