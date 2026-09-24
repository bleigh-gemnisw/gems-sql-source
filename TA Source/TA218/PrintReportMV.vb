Module PrintReportMV
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim DsTXMVD As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkCodeFrom As Integer
  Dim WrkCodeTo As Integer
  Dim WrkShowAddr As Boolean
  Dim WrkSortBy As String
  Dim WrkFrozenFile As Boolean
  Public Sub PrtReportMV()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)

    With MyFrmTA218B
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortSName.Checked Then
        WrkSortBy = "SName"
      End If
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkShowAddr = .ChkAddress.Checked
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkType = "M"
      .WrkDist = WrkDist
      .WrkPrintDist = WrkPrintDist
      .Show()
    End With
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkGross As Integer
    Dim WrkClass As Integer
    Dim Pos As Integer
    Dim Good As Boolean

    If myDBConnect.ServerAS400 Then
      WrkOr = " *or "
      WrkAnd = " *and "
    Else
      WrkOr = " or "
      WrkAnd = " and "
    End If

    WrkSort = ""
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "CAT, NAME"
      Case "SName"
        WrkSort = "CAT, SNAME, NAME"
    End Select

    WrkQry = "CAT <> '2'"
    If Not WrkDistAll Then
      If Not WrkPrintDist Then
        WrkQry = WrkQry & " and dist=" & WrkDist
      Else
        WrkQry = WrkQry & " and pdst=" & WrkDist
      End If
    End If

    If Not WrkFrozenFile Then
      DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXMVD = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXMVD.Tables(0).Rows.Count = 0 Then
      If Not WrkFrozenFile Then
        myTXMVDQ.CloseFile()
      Else
        myTXMVDCQ.CloseFile()
      End If
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
      With DsTXMVD.Tables(0).Rows(I)
        WrkGross = .Item("value")
        WrkClass = .Item("class")
        Good = False
        Pos = InStr(MySelCodes, Format(WrkClass, " 00"))
        If Pos > 0 Then Good = True

        If Not Good And Not MySelCodes = String.Empty Then
          GoTo NextRec
        End If

        dr = ds.Tables(0).NewRow
        If .Item("cat") = "3" Then
          dr.Item("exempt") = True
        Else
          dr.Item("exempt") = False
        End If
        dr.Item("listno") = .Item("list#")
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        If WrkShowAddr Then
          dr.Item("addr2") = AddrLine(1)
          dr.Item("addr3") = AddrLine(2)
          dr.Item("addr4") = AddrLine(3)
          dr.Item("addr5") = AddrLine(4)
        Else
          If WrkSortBy = "SName" Then
            dr.Item("addr2") = .Item("sname")
          End If
        End If
        dr.Item("proploc") = .Item("make") & " " & .Item("year") & " " & .Item("regno")
        dr.Item("gross") = WrkGross
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    Application.DoEvents()
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()

  End Sub
End Module






