Imports System.Text
Imports System.IO
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkFile As String
  Dim WrkUBType As String
  Dim WrkRpt As String
  Dim sw As StreamWriter
  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)

    With MyFrmUB235B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkUBType = .TxtUBType.Text
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmUB235B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .ds = ds
      .WrkUBType = WrkUBType
      .Show()
    End With
  End Sub
  Public Sub GetDetail()
    Dim WrkUBCode As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = "CUACCT"
    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = "cudst=" & WrkDist
    End If
    If WrkPhase > 0 Then
      If WrkQry = String.Empty Then
        WrkQry = "cuphas = " & WrkPhase
      Else
        WrkQry = WrkQry & WrkAnd & "cuphas = " & WrkPhase
      End If
    End If

    If WrkFile <> String.Empty Then
      sw.WriteLine(BuildHeadings())
    End If

    myUTCUSTQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        Counter = Counter + 1
        If WrkUBType <> "" Then
          WrkUBCode = GetRateCode(._CUACCT, WrkUBType)
          If Trim(WrkUBCode) = "" Then GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._CUACCT
        dr.Item("name") = Trim(._CUNAM1)
        dr.Item("locno") = MyUtils.JustifyRight(Trim(._CULOCNO), 7)
        dr.Item("loc") = Trim(._CULOC)
        If Trim(._CUSERN) <> "" Then
          dr.Item("serial") = Trim(._CUSERN)
        Else
          dr.Item("serial") = Trim(._CUMETN)
        End If
        dr.Item("route") = Trim(._CUROUT)
        ds.Tables(0).Rows.Add(dr)
        If WrkFile <> String.Empty Then
          sw.WriteLine(BuildNormal)
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

    If WrkFile <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    Application.DoEvents()
    myUTCUSTQ.CloseFile()

  End Sub
  Friend Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int64"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("locno", Type.GetType("System.String"))
      .Columns.Add("loc", Type.GetType("System.String"))
      .Columns.Add("serial", Type.GetType("System.String"))
      .Columns.Add("route", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Function GetRateCode(ByVal WrkListno As Integer, ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListno, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
  Public Function BuildHeadings()
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    sb.Append("List No")
    sb.Append(",")
    sb.Append("Name")
    sb.Append(",")
    sb.Append("Loc No")
    sb.Append(",")
    sb.Append("Loc")
    sb.Append(",")
    sb.Append("Serial No")
    sb.Append(",")
    sb.Append("Route")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildNormal() As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    WrkStr = ""
    sb = New StringBuilder
    sb.Append(dr.Item("listno"))
    sb.Append(",")
    sb.Append(dr.Item("name"))
    sb.Append(",")
    sb.Append(dr.Item("locno"))
    sb.Append(",")
    sb.Append(dr.Item("loc"))
    sb.Append(",")
    sb.Append(dr.Item("serial"))
    sb.Append(",")
    sb.Append(dr.Item("route"))
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
End Module






