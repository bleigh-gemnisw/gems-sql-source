Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXMVDQ As TXMVDQ.myData

Dim DsFile As DataSet = New DataSet

Dim WrkAnd As String
Dim WrkOr As String
Dim WrkTrailer As Boolean
'Buffered Fields
Dim WrkOYear(5000) As Integer
Dim WrkOMake(5000) As String
Dim WrkOModel(5000) As String
Dim WrkOValue(5000) As Integer

Public Sub PrtReport()
	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)

 With MyFrmTA940B
   WrkTrailer = .RbTrailer.Checked
 End With

	BufferPrevMVD()
	If MyFrmTA940B.RbMV.Checked Then
		GetDetailMV()
	Else
		GetDetailSU()
	End If

End Sub
Private Sub GetDetailMV()
Dim sb As StringBuilder
Dim sw As StreamWriter = New StreamWriter(MyFrmTA940B.LblFilePath.Text)
Dim WrkQry As String
Dim WrkSort As String
Dim WrkName As String
Dim Counter As Integer
Dim WrkLastYrVal As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

If WrkTrailer Then
  WrkQry = "CLASS = 10" & WrkOr & "CLASS = 11"
Else
  WrkQry = "CLASS = 2" & WrkOr & "CLASS = 3" & WrkOr & "CLASS = 4" & WrkOr & "CLASS = 7" & _
   WrkOr & "CLASS = 8" & WrkOr & "CLASS = 9" & WrkOr & "CLASS = 31" & WrkOr & "CLASS = 37" & _
   WrkOr & "CLASS = 40" & WrkOr & "CLASS = 70"
End If
WrkSort = ""

myTXMVDQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

sw.WriteLine(WriteHeader)
ReadNext:
  myTXMVDQ.ReadQry()
  If Not myTXMVDQ.IsEOF Then
   With myTXMVDQ
   Counter = Counter + 1
   sb = New StringBuilder
   sb.Append(Trim(._VINNO))
   sb.Append(",")
   sb.Append(Trim(._BODY))
   sb.Append(",")
   sb.Append(._CLASS)
   sb.Append(",")
   sb.Append(._LISTNo)
   sb.Append(",")
   sb.Append(Trim(._ADD1))
   sb.Append(",")
   sb.Append(Trim(._CITY))
   sb.Append(",")
   sb.Append(Trim(._STATE))
   sb.Append(",")
   sb.Append(Format(._ZIP5, "00000"))
   sb.Append(",")
   sb.Append(._LWT)
   sb.Append(",")
   sb.Append(._GWT)
   sb.Append(",")
   sb.Append(Trim(._MAKE))
   sb.Append(",")
   sb.Append(Trim(._MODEL))
   sb.Append(",")
   sb.Append(Trim(._REGNO))
      sb.Append(",")
      WrkName = Replace(Trim(._NAME), ",", " ")
      sb.Append(WrkName)
   sb.Append(",")
   sb.Append(._YEAR)
   sb.Append(",")
   sb.Append(._CYLAX)
   sb.Append(",")
   sb.Append(Counter)
   sb.Append(",")
   WrkLastYrVal = GetLastYrVal(._YEAR, Trim(._MAKE), Trim(._MODEL))
   sb.Append(WrkLastYrVal)
   sb.Append(",")
   sb.Append(._VALUE)
   sw.WriteLine(sb.ToString)
   sb = Nothing
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

sw.Close()
myFrmProgress.Close()
If MyFrmTA940B.RbMV.Checked Then
 myTXMVDQ.CloseFile()
Else
 myTXSUPPQ.CloseFile()
End If
End Sub
Private Sub GetDetailSU()
Dim sb As StringBuilder
Dim sw As StreamWriter = New StreamWriter(MyFrmTA940B.LblFilePath.Text)
Dim WrkQry As String
Dim WrkSort As String
Dim WrkName As String
Dim Counter As Integer
Dim WrkLastYrVal As Integer

If MyServer = "DB2" Then
 WrkAnd = " *and "
 WrkOr = " *or "
Else
 WrkAnd = " and "
 WrkOr = " or "
 End If

If WrkTrailer Then
  WrkQry = "CLASS = 10" & WrkOr & "CLASS = 11"
Else
  WrkQry = "CLASS = 2" & WrkOr & "CLASS = 3" & WrkOr & "CLASS = 4" & WrkOr & "CLASS = 7" & _
   WrkOr & "CLASS = 8" & WrkOr & "CLASS = 9" & WrkOr & "CLASS = 31" & WrkOr & "CLASS = 37" & _
   WrkOr & "CLASS = 40" & WrkOr & "CLASS = 70"
End If
WrkSort = ""

myTXSUPPQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

sw.WriteLine(WriteHeader)
ReadNext:
  myTXSUPPQ.ReadQry()
  If Not myTXSUPPQ.IsEOF Then
   With myTXSUPPQ
   Counter = Counter + 1
   sb = New StringBuilder
   sb.Append(Trim(._VINNO))
   sb.Append(",")
   sb.Append(Trim(._BODY))
   sb.Append(",")
   sb.Append(._CLASS)
   sb.Append(",")
   sb.Append(._LISTNo)
   sb.Append(",")
   sb.Append(Trim(._ADD1))
   sb.Append(",")
   sb.Append(Trim(._CITY))
   sb.Append(",")
   sb.Append(Trim(._STATE))
   sb.Append(",")
   sb.Append(Format(._ZIP5, "00000"))
   sb.Append(",")
   sb.Append(._LWT)
   sb.Append(",")
   sb.Append(._GWT)
   sb.Append(",")
   sb.Append(Trim(._MAKE))
   sb.Append(",")
   sb.Append(Trim(._MODEL))
   sb.Append(",")
   sb.Append(Trim(._REGNO))
   sb.Append(",")
      WrkName = Replace(Trim(._NAME), ",", " ")
      sb.Append(WrkName)
      sb.Append(",")
   sb.Append(._YEAR)
   sb.Append(",")
   sb.Append(._CYLAX)
   sb.Append(",")
   sb.Append(Counter)
   sb.Append(",")
   WrkLastYrVal = GetLastYrVal(._YEAR, Trim(._MAKE), Trim(._MODEL))
   sb.Append(WrkLastYrVal)
   sb.Append(",")
   sb.Append(._VALUE)
   sw.WriteLine(sb.ToString)
   sb = Nothing
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

sw.Close()
myFrmProgress.Close()
If MyFrmTA940B.RbMV.Checked Then
 myTXMVDQ.CloseFile()
Else
 myTXSUPPQ.CloseFile()
End If
End Sub
Public Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable
  With myTable
   .TableName = "mytable"
   .Columns.Add("ListNo", Type.GetType("System.Int32"))
   .Columns.Add("Year", Type.GetType("System.Int32"))
   .Columns.Add("Name", Type.GetType("System.String"))
   .Columns.Add("ImvReg", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
Friend Sub BufferPrevMVD()
  'Buffer MV file. Create one record per Year/Make/Model 
  Dim myTXMVDCQ As TXMVDCQ.myData
  Dim dsMV As DataSet = New DataSet
  Dim WrkSort As String
  Dim WrkQry As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim Counter As Integer
  Dim SaveYear As Integer
  Dim SaveMake As String
  Dim SaveModel As String
  Dim J As Integer

  myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)

  Array.Clear(WrkOYear, 0, 5000)
  Array.Clear(WrkOMake, 0, 5000)
  Array.Clear(WrkOModel, 0, 5000)
  Array.Clear(WrkOValue, 0, 5000)

  SaveYear = 0
  SaveMake = String.Empty
  SaveModel = String.Empty

  If myDBConnect.ServerAS400 Then
   WrkAnd = " *and "
   WrkOr = " *or "
  Else
   WrkAnd = " and "
   WrkOr = " or "
  End If

  WrkQry = "CLASS = 10" & WrkAnd & "VALUE > 0" & WrkOr & "CLASS = 11" & WrkAnd & "VALUE > 0"
  WrkSort = "YEAR, MAKE, MODEL"
  myTXMVDCQ.OpenQry(WrkSort, WrkQry)

  myFrmProgress = New FrmProgress
  myFrmProgress.Text = "Buffering Last year's values..."
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

ReadNext:
  myTXMVDCQ.ReadQry()
  If Not myTXMVDCQ.IsEOF Then
   With myTXMVDCQ
    Counter = Counter + 1
    If SaveYear <> ._YEAR Or _
     SaveMake <> Trim(._MAKE) Or _
     SaveModel <> Trim(._MODEL) Then
     If ._VALUE > 0 Then
      WrkOYear(J) = ._YEAR
      WrkOMake(J) = Trim(._MAKE)
      WrkOModel(J) = Trim(._MODEL)
      WrkOValue(J) = ._VALUE
      J = J + 1
     End If
    End If
    SaveYear = ._YEAR
    SaveMake = Trim(._MAKE)
    SaveModel = Trim(._MODEL)
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

 myFrmProgress.Close()
 myTXMVDCQ.CloseFile()
End Sub
Friend Function GetLastYrVal(ByVal PYear As Integer, ByVal pMake As String, ByVal pModel As String) As Integer
   Dim I As Integer
   Dim K As Integer
   Dim WrkLastYrVal As Integer

   For I = 0 To WrkOMake.GetUpperBound(0)
    If WrkOMake(I) = String.Empty Then
     Return 0
    End If
    If PYear = WrkOYear(I) And pMake = WrkOMake(I) And pModel = WrkOModel(I) Then
     WrkLastYrVal = WrkOValue(I)
     K = WrkLastYrVal Mod 10
     If K >= 5 Then
      WrkLastYrVal = WrkLastYrVal + (10 - K)
     Else
      WrkLastYrVal = WrkLastYrVal - K
     End If
     Return WrkLastYrVal
    End If
   Next

End Function
End Module






