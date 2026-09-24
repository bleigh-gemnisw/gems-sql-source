Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dsLbl As DataSet = New DataSet
  Dim drLbl As Data.DataRow

  'Screen fields
  Dim WrkUBType As String
  Dim WrkDist As Integer
  Dim WrkPhase As Integer
  Dim WrkDistto As Integer
  Dim WrkPhaseto As Integer
  Dim WrkListing As Boolean
  Dim WrkShowList As Boolean
  Dim WrkMailAddr As Boolean
  Dim WrkSortBy As String
  Dim WrkReport As Boolean
  Dim WrkAddress As Boolean

  'Common Work fields
  Dim wrkadist As Integer
  Dim wrkaphase As Integer
  Dim WrkListNo As Integer
  Dim WrkMaxLen As Integer
  Dim WrkMod As Integer
  Dim WrkHAdjust1 As Integer
  Dim WrkHAdjust2 As Integer
  Dim WrkHAdjust3 As Integer


  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)

    WrkMaxLen = 35
    With MyFrmUB207B
      WrkUBType = .TxtUBType.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistto = MyUtils.CnvSng(.txtdistto.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkPhaseto = MyUtils.CnvSng(.txtphaseto.Text)

      If WrkDist = 0 And WrkDistto = 0 Then
        WrkDistto = 999
        If WrkPhase = 0 And WrkPhaseto = 0 Then
          WrkPhaseto = 9
        End If
      End If
      WrkListing = .RbList.Checked
      WrkShowList = .ChkShowList.Checked
      WrkMailAddr = .ChkMailAddr.Checked
      If .RbSortList.Checked Then
        WrkSortBy = "Acct"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLoc.Checked Then
        WrkSortBy = "Location"
      End If
      If .Rb1Across.Checked Then WrkMod = 1
      If .Rb2Across.Checked Then WrkMod = 2
      If .Rb3Across.Checked Then WrkMod = 3
      WrkHAdjust1 = MyUtils.CnvSng(.TxtHAdjust1.Text)
      WrkHAdjust2 = MyUtils.CnvSng(.TxtHAdjust2.Text)
      WrkHAdjust3 = MyUtils.CnvSng(.TxtHAdjust3.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDSLbl()
    Else
      ds.Clear()
      dsLbl.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      If WrkListing Then
        .wrkds = ds
      Else
        .wrkds = dsLbl
      End If
      Select Case WrkSortBy
        Case "Acct"
          .Wrksort = "By Account"
        Case "Name"
          .Wrksort = "By Name"
        Case "Location"
          .Wrksort = "By Location"
      End Select
      .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString _
    + " To: " + WrkDistto.ToString + " / " + WrkPhaseto.ToString
      .Show()
    End With


  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("District", Type.GetType("System.Int32"))
      .Columns.Add("Phase", Type.GetType("System.Int32"))
      .Columns.Add("DistDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Friend Sub BuildDSLbl()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("line0", Type.GetType("System.String"))
      .Columns.Add("line1", Type.GetType("System.String"))
      .Columns.Add("line2", Type.GetType("System.String"))
      .Columns.Add("line3", Type.GetType("System.String"))
      .Columns.Add("line4", Type.GetType("System.String"))
      .Columns.Add("line5", Type.GetType("System.String"))
    End With
    dsLbl.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkLocation As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkNew As Boolean
    Dim WrkAnd As String
    Dim WrkCode As String
    Dim sb0 As StringBuilder
    Dim sb1 As StringBuilder
    Dim sb2 As StringBuilder
    Dim sb3 As StringBuilder
    Dim sb4 As StringBuilder
    Dim sb5 As StringBuilder
    Dim wrkdidesc As String
    Dim wrkdideschead As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If WrkDistto > WrkDist Then
      WrkQry = "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
    Else
      WrkQry = "cudst=" & WrkDist
    End If

    WrkSort = ""
    Select Case WrkSortBy
      Case "Acct"
        WrkSort = "CUDST, CUPHAS, CUACCT"
      Case "Name"
        WrkSort = "CUDST, CUPHAS, CUNAM1"
      Case "Location"
        WrkSort = "CUDST, CUPHAS, CULOC, CULOC#"
    End Select

    Counter = 0
    WrkNew = True
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
        WrkListNo = ._CUACCT
        WrkCode = GetRateCode(WrkUBType)
        If WrkCode = "" Then GoTo NextRec
        'filter phase..  cannot go phase to phase in call cases  as i can run dist 1 phase 3 to dist 4 phase 2
        wrkaphase = ._CUPHAS
        wrkadist = ._CUDST
        If WrkDist = WrkDistto Then
          If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo NextRec
        End If
        If WrkDist < WrkDistto Then
          If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo NextRec
          If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo NextRec
        End If
        ' end phase filter.

        If WrkMailAddr Then
          If Trim(._CUMAD1) <> "" Then
            AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2, ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
          Else
            AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
          End If
        Else
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
        End If
        WrkLocation = Trim(._CULOCNO) & " " & Trim(._CULOC)

        'Report
        If WrkListing Then
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = WrkListNo
          dr.Item("addr1") = AddrLine(0)
          dr.Item("addr2") = AddrLine(1)
          dr.Item("addr3") = AddrLine(2)
          dr.Item("addr4") = AddrLine(3)
          dr.Item("addr5") = AddrLine(4)
          dr.Item("location") = WrkLocation
          dr.Item("District") = wrkadist
          dr.Item("Phase") = wrkaphase
          wrkdidesc = GetUTDistDesc(wrkadist, wrkaphase)
          wrkdideschead = "District: " + wrkadist.ToString + " Phase: " + wrkaphase.ToString _
        + " " + wrkdidesc
          dr.Item("Distdesc") = wrkdideschead
          ds.Tables(0).Rows.Add(dr)
        End If

        'Labels
        If Not WrkListing Then
          Counter = Counter + 1
          If WrkNew Then
            sb0 = New StringBuilder
            sb1 = New StringBuilder
            sb2 = New StringBuilder
            sb3 = New StringBuilder
            sb4 = New StringBuilder
            sb5 = New StringBuilder
            'Adjust space before 1st column
            If WrkHAdjust1 > 0 Then
              sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
              sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
              sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
              sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
              sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
              sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust1))
            End If
          End If
          WrkNew = False
          sb0.Append(MyUtils.JustifyLeft(WrkListNo, WrkMaxLen))
          sb1.Append(MyUtils.JustifyLeft(AddrLine(0), WrkMaxLen))
          sb2.Append(MyUtils.JustifyLeft(AddrLine(1), WrkMaxLen))
          sb3.Append(MyUtils.JustifyLeft(AddrLine(2), WrkMaxLen))
          sb4.Append(MyUtils.JustifyLeft(AddrLine(3), WrkMaxLen))
          sb5.Append(MyUtils.JustifyLeft(AddrLine(4), WrkMaxLen))
          'Adjust space between 1st and 2nd columns
          If WrkMod > 1 And Counter Mod WrkMod = 1 And WrkHAdjust2 > 0 Then
            sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
            sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
            sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
            sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
            sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
            sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
          End If
          'Adjust space between 2nd and 3rd columns
          If WrkMod > 2 And Counter Mod WrkMod = 2 And WrkHAdjust3 > 0 Then
            sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
            sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
            sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
            sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
            sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
            sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
          End If
          If Counter Mod WrkMod = 0 Then
            drLbl = dsLbl.Tables(0).NewRow
            If WrkShowList Then
              drLbl.Item("line0") = sb0.ToString
            Else
              drLbl.Item("line0") = String.Empty
            End If
            drLbl.Item("line1") = sb1.ToString
            drLbl.Item("line2") = sb2.ToString
            drLbl.Item("line3") = sb3.ToString
            drLbl.Item("line4") = sb4.ToString
            drLbl.Item("line5") = sb5.ToString
            dsLbl.Tables(0).Rows.Add(drLbl)
            sb0 = Nothing
            sb1 = Nothing
            sb2 = Nothing
            sb3 = Nothing
            sb4 = Nothing
            sb5 = Nothing
            WrkNew = True
          End If
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

    'Write out any remaining data
    If Not WrkListing Then
      If Not WrkNew Then
        If sb1.ToString <> String.Empty Then
          drLbl = dsLbl.Tables(0).NewRow
          If WrkShowList Then
            drLbl.Item("line0") = sb0.ToString
          Else
            drLbl.Item("line0") = String.Empty
          End If
          drLbl.Item("line1") = sb1.ToString
          drLbl.Item("line2") = sb2.ToString
          drLbl.Item("line3") = sb3.ToString
          drLbl.Item("line4") = sb4.ToString
          drLbl.Item("line5") = sb5.ToString
          dsLbl.Tables(0).Rows.Add(drLbl)
        End If
      End If
    End If

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String

    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
End Module






