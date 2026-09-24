Imports System.io
Imports System.Text
Module PrintCreateRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.MyData
  Dim myUTCUST As UTCUST.MyData
  Dim myTXINVLK As TXINVLK.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkAnd As String
  Dim WrkOr As String
  Dim CTaxType As String = "C"
  Public Sub PrtCreateRE()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)
    myTXINVLK = New TXINVLK.MyData(myDBConnect)

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
      .WrkOption = "Create"
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter = New StreamWriter(MyFrmUB302B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkList As Integer
    Dim SavePage As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = "LIST#"

    DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SavePage = ""
    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      With DsTXREAL.Tables(0).Rows(I)
        WrkList = .Item("list#")
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("ubname") = .Item("name")
        dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
        dr.Item("errmsg") = String.Empty
        ds.Tables(0).Rows.Add(dr)
        sw.WriteLine(BuildRecord(I))
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    sw.Close()
    myFrmProgress.Close()
    myTXREALQ.CloseFile()

  End Sub
  Private Function BuildRecord(ByVal I) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim CSeperator As String = "~"

    With DsTXREAL.Tables(0).Rows(I)
      sb = New StringBuilder
      'List # (5)
      WrkStr = Format(.Item("cuacct"), "00000")
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Name1 (35)
      WrkStr = MyUtils.JustifyLeft(.Item("name"), 35)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Name2 (35)
      WrkStr = MyUtils.JustifyLeft(.Item("sname"), 35)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Add1 (35)
      WrkStr = MyUtils.JustifyLeft(.Item("add1"), 35)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Add2 (35)
      WrkStr = MyUtils.JustifyLeft(.Item("add2"), 35)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'City (25)
      WrkStr = .Item("city")
      WrkStr = MyUtils.JustifyLeft(WrkStr, 25)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'State (2)
      WrkStr = .Item("state")
      WrkStr = MyUtils.JustifyLeft(WrkStr, 2)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Zip5/Zip4 (10)
      WrkStr = Format(.Item("zip5"), "00000")
      sb.Append(WrkStr)
      If .Item("zip4") > 0 Then
        WrkStr = " "
        sb.Append(WrkStr)
        WrkStr = Format(.Item("zip4"), "0000")
        sb.Append(WrkStr)
      Else
        WrkStr = MyUtils.JustifyLeft("", 5)
        sb.Append(WrkStr)
      End If
      sb.Append(CSeperator)
      'Vol (5)
      WrkStr = MyUtils.JustifyLeft(.Item("vol"), 5)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Page (5)
      WrkStr = MyUtils.JustifyLeft(.Item("pge"), 5)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Map (17)
      WrkStr = MyUtils.JustifyLeft(.Item("map"), 17)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Lot (1)
      WrkStr = " "
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: Strc (6)
      WrkStr = MyUtils.JustifyLeft("", 6)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Location # (7)
      WrkStr = MyUtils.JustifyRight(Trim(.Item("loc#")), 7)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: Apt (5)
      WrkStr = MyUtils.JustifyLeft("", 5)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Location (26)
      WrkStr = MyUtils.JustifyLeft(.Item("loc"), 26)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: Unit (5)
      WrkStr = MyUtils.JustifyLeft("", 5)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      myUTCUST.GetOneRecordP(.Item("list#"))
      If Not myUTCUST.RecordNotFound Then
        'Filler: App (5)
        WrkStr = Format(MyUtils.CnvSng(Right(Trim(myUTCUST._CUAPLNO), 5)), "00000")
        sb.Append(WrkStr)
        sb.Append(CSeperator)
        'Filler: Swap (5)
        WrkStr = Format(MyUtils.CnvSng(Right(Trim(myUTCUST._CUAPLNO), 5)), "00000")
        sb.Append(WrkStr)
        sb.Append(CSeperator)
      Else
        'Filler: App (5)
        WrkStr = "00000"
        sb.Append(WrkStr)
        sb.Append(CSeperator)
        'Filler: Swap (5)
        WrkStr = "00000"
        sb.Append(WrkStr)
        sb.Append(CSeperator)
      End If
      'Filler: F1 (1)
      WrkStr = MyUtils.JustifyLeft("", 1)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: F2 (1)
      WrkStr = MyUtils.JustifyLeft("", 1)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: Back Tax (4)
      WrkStr = MyUtils.JustifyRight("", 4)
      If CheckDelqListNo(.Item("list#"), CTaxType) Then
        WrkStr = MyUtils.JustifyRight("Y", 4)
      End If
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Filler: Delete Code (7)
      WrkStr = MyUtils.JustifyLeft("", 7)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Status (1)
      WrkStr = MyUtils.JustifyLeft("A", 1)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
      'Class (1)
      WrkStr = MyUtils.JustifyLeft("", 1)
      sb.Append(WrkStr)
      sb.Append(CSeperator)
    End With

    Return sb.ToString
  End Function
  Private Function CheckDelqListNo(ByVal WrkListNo As Integer, ByVal WrkType As String) As Boolean
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkType, 999)
    If ds2.Tables(0).Rows.Count = 0 Then Exit Function

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
        Return True
      End If
    Next

    Return False
  End Function
End Module






