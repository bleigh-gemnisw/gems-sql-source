Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim dsTXMVD As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkFromClass As Integer
  Dim WrkToClass As Integer
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkNADA As String

  Public Sub PrtReport(ByVal WrkClassDesc As String)
    Dim WrkFromClassDesc As String
    Dim WrkToClassDesc As String

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)

    With MyFrmTA430B
      WrkFromClass = MyUtils.CnvSng(.TxtFromClass.Text)
      WrkToClass = MyUtils.CnvSng(.TxtToClass.Text)
      WrkFromYear = MyUtils.CnvSng(.TxtFromYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToYear.Text)
      WrkNADA = .TxtNADA.Text
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()
    WrkFromClassDesc = GetTXCodeDesc(WrkFromClass, "M")
    WrkToClassDesc = GetTXCodeDesc(WrkToClass, "M")

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkFromClass = WrkFromClass
    MyCrViewer.WrkFromClassDesc = WrkFromClassDesc
    MyCrViewer.WrkToClass = WrkToClass
    MyCrViewer.WrkToClassDesc = WrkToClassDesc
    MyCrViewer.WrkFromYear = WrkFromYear
    MyCrViewer.WrkToYear = WrkToYear
    MyCrViewer.WrkNADA = WrkNADA
    MyCrViewer.Show()
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("value", Type.GetType("System.Int32"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("vinno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))
      .Columns.Add("regno", Type.GetType("System.String"))
      .Columns.Add("seat", Type.GetType("System.Int32"))
      .Columns.Add("pclr", Type.GetType("System.String"))
      .Columns.Add("nada", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim Pos As Integer
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "CAT <> '2' and NADA<>' '"
    If WrkFromClass > 0 Then
      WrkQry = WrkQry & WrkAnd & "class>=" & WrkFromClass
    End If
    If WrkToClass > 0 Then
      WrkQry = WrkQry & WrkAnd & "class<=" & WrkToClass
    End If
    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkFromYear
    End If
    If WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkToYear
    End If

    dsTXMVD = myTXMVDQ.GetQry("NAME", WrkQry, 0)
    If dsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsTXMVD.Tables(0).Rows.Count - 1)
      With dsTXMVD.Tables(0).Rows(I)
        If WrkNADA <> String.Empty Then
          Pos = InStr(.Item("nada"), WrkNADA, CompareMethod.Text)
          If Pos = 0 Then Continue For
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("value") = .Item("value")
        dr.Item("class") = .Item("class")
        dr.Item("make") = .Item("make")
        dr.Item("year") = .Item("year")
        dr.Item("vinno") = .Item("vinno")
        dr.Item("model") = .Item("model")
        dr.Item("body") = .Item("body")
        dr.Item("lwt") = .Item("lwt")
        dr.Item("gwt") = .Item("gwt")
        dr.Item("regno") = .Item("regno")
        dr.Item("seat") = .Item("seat")
        dr.Item("pclr") = .Item("pclr")
        dr.Item("nada") = .Item("nada")
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTXMVD.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()

  End Sub
End Module






