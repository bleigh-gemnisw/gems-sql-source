Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myFAMSTRQ As FAMSTRQ.MyData
  Dim myFAHIST As FAHIST.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsFAMSTR As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkHistFrom As Integer
  Dim WrkHistTo As Integer
  Dim WrkHistType As String
  Dim WrkAsTypeFrom As String
  Dim WrkAsTypeTo As String
  Dim WrkBldgFrom As String
  Dim WrkBldgTo As String
  Dim WrkClassFrom As String
  Dim WrkClassTo As String
  Dim WrkDeptFrom As String
  Dim WrkDeptTo As String
  Dim WrkEqupFrom As String
  Dim WrkEqupTo As String
  Dim WrkUser1From As String
  Dim WrkUser1To As String
  Dim WrkUser2From As String
  Dim WrkUser2To As String
  Dim WrkUser3From As String
  Dim WrkUser3To As String
  Dim WrkAssetValFrom As Integer
  Dim WrkAssetValTo As Integer
  Dim WrkPSort As String
  Dim WrkSSort As String

  Dim WrkTValue As Integer

  Public Sub PrtReport()
    Dim WrkSortby As String
    myFAMSTRQ = New FAMSTRQ.MyData()
    myFAMSTRQ.MyDBConn = myDBConnect
    myFAHIST = New FAHIST.MyData()
    myFAHIST.MyDBConn = myDBConnect

    With MyFrmFA104B
      WrkHistFrom = 0
      WrkHistTo = 0
      If .RbHistAdjust.Checked Then WrkHistType = "Adjust"
      If .RbHistDepr.Checked Then WrkHistType = "Depr"
      If .RbHistBoth.Checked Then WrkHistType = ""
      If .DtPckHistFrom.Checked Then
        WrkHistFrom = MyUtils.SetDBDate(.DtPckHistFrom.Value)
      End If
      If .DtPckHistTo.Checked Then
        WrkHistTo = MyUtils.SetDBDate(.DtPckHistTo.Value)
      End If
      WrkAsTypeFrom = .TxtAsTypeFrom.Text
      WrkAsTypeTo = .TxtAsTypeTo.Text
      WrkBldgFrom = .TxtBldgFrom.Text
      WrkBldgTo = .TxtBldgTo.Text
      WrkClassFrom = .TxtClassFrom.Text
      WrkClassTo = .TxtClassTo.Text
      WrkDeptFrom = .TxtDeptFrom.Text
      WrkDeptTo = .TxtDeptTo.Text
      WrkEqupFrom = .TxtEqupFrom.Text
      WrkEqupTo = .TxtEqupTo.Text
      WrkUser1From = .TxtUser1From.Text
      WrkUser1To = .TxtUser1To.Text
      WrkUser2From = .TxtUser2From.Text
      WrkUser2To = .TxtUser2To.Text
      WrkUser3From = .TxtUser3From.Text
      WrkUser3To = .TxtUser3To.Text
      WrkAssetValFrom = MyUtils.CnvSng(.TxtAssetValFrom.Text)
      WrkAssetValTo = MyUtils.CnvSng(.TxtAssetValTo.Text)

      WrkPSort = ""
      If .RbPAssetType.Checked Then
        WrkPSort = "Asset Type"
      End If
      If .RbPClassification.Checked Then
        WrkPSort = "Classification"
      End If
      If .RbPCondition.Checked Then
        WrkPSort = "Equipment Condition"
      End If
      If .RbPDepartment.Checked Then
        WrkPSort = "Department"
      End If
      If .RbPLocation.Checked Then
        WrkPSort = "Location"
      End If
      If .RbPVendor.Checked Then
        WrkPSort = "Vendor"
      End If
      If .RbPGLGrouping.Checked Then
        WrkPSort = "GLGrouping"
      End If
      If .RbPUser1.Checked Then
        WrkPSort = "User1"
      End If
      If .RbPUser2.Checked Then
        WrkPSort = "User2"
      End If
      If .RbPUser3.Checked Then
        WrkPSort = "User3"
      End If
      If .RbPUser4.Checked Then
        WrkPSort = "User4"
      End If
      If .RbPUser5.Checked Then
        WrkPSort = "User5"
      End If

      WrkSSort = ""
      If .RbSAssetType.Checked Then
        WrkSSort = "Asset Type"
      End If
      If .RbSClassification.Checked Then
        WrkSSort = "Classification"
      End If
      If .RbSCondition.Checked Then
        WrkSSort = "Equipment Condition"
      End If
      If .RbSDepartment.Checked Then
        WrkSSort = "Department"
      End If
      If .RbSLocation.Checked Then
        WrkSSort = "Location"
      End If
      If .RbSVendor.Checked Then
        WrkSSort = "Vendor"
      End If
      If .RbSGLGrouping.Checked Then
        WrkSSort = "GLGrouping"
      End If
      If .RbSUser1.Checked Then
        WrkSSort = "User1"
      End If
      If .RbSUser2.Checked Then
        WrkSSort = "User2"
      End If
      If .RbSUser3.Checked Then
        WrkSSort = "User3"
      End If
      If .RbSUser4.Checked Then
        WrkSSort = "User4"
      End If
      If .RbSUser5.Checked Then
        WrkSSort = "User5"
      End If
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:

    WrkSortby = " by " & WrkPSort
    If WrkSSort <> "" Then
      WrkSortby = WrkSortby & ", " & WrkSSort
    End If
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.Wrkds2 = ds2
    MyCrViewer.WrkSortby = WrkSortby
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("Tag", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Serial", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("TValue", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub ClearTotals()
    WrkTValue = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSortby As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim SaveGroup As String
    Dim WrkValue As Integer
    Dim Good As Boolean

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "FASTAT='A'"
    WrkSortby = ""
    Good = False
    If WrkAsTypeFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD >= " & MyUtils.Quo(WrkAsTypeFrom)
    End If
    If WrkAsTypeTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD <= " & MyUtils.Quo(WrkAsTypeTo)
    End If
    If WrkBldgFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FABLCD >= " & MyUtils.Quo(WrkBldgFrom)
    End If
    If WrkBldgTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FABLCD <= " & MyUtils.Quo(WrkBldgTo)
    End If
    If WrkClassFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FACLCD >= " & MyUtils.Quo(WrkClassFrom)
    End If
    If WrkClassTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FACLCD <= " & MyUtils.Quo(WrkClassTo)
    End If
    If WrkDeptFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FADECD >= " & MyUtils.Quo(WrkDeptFrom)
    End If
    If WrkDeptTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FADECD <= " & MyUtils.Quo(WrkDeptTo)
    End If
    If WrkEqupFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAEQCD >= " & MyUtils.Quo(WrkEqupFrom)
    End If
    If WrkEqupTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAEQCD <= " & MyUtils.Quo(WrkEqupTo)
    End If
    If WrkUser1From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU1CD >= " & MyUtils.Quo(WrkUser1From)
    End If
    If WrkUser1To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU1CD <= " & MyUtils.Quo(WrkUser1To)
    End If
    If WrkUser2From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU2CD >= " & MyUtils.Quo(WrkUser1From)
    End If
    If WrkUser2To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU2CD <= " & MyUtils.Quo(WrkUser1To)
    End If
    If WrkUser3From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU3CD >= " & MyUtils.Quo(WrkUser2From)
    End If
    If WrkUser3To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU3CD <= " & MyUtils.Quo(WrkUser3To)
    End If
    If WrkAssetValFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQVL >= " & WrkAssetValFrom
    End If
    If WrkAssetValTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQVL <= " & WrkAssetValTo
    End If
    If MyFrmFA104B.RbFundBusiness.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV<>'Y'"
    End If
    If MyFrmFA104B.RbFundGovernment.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV='Y'"
    End If

    If WrkSSort <> "" Then
      WrkSortby = BuildSort(WrkPSort) & "," & BuildSort(WrkSSort) & ",FADESC"
    Else
      WrkSortby = BuildSort(WrkPSort) & ",FADESC"
    End If

    DsFAMSTR = myFAMSTRQ.GetQry(WrkSortby, WrkQry, 0)
    If DsFAMSTR.Tables(0).Rows.Count = 0 Then
      myFAMSTRQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveGroup = ""

    For I = 0 To (DsFAMSTR.Tables(0).Rows.Count - 1)
      With DsFAMSTR.Tables(0).Rows(I)
        dr = ds1.Tables(0).NewRow
        Select Case WrkPSort
          Case "Asset Type"
            dr.Item("groupid") = .Item("faascd") & "-" & GetFAASTypeDesc(.Item("faascd"))
          Case "Classification"
            dr.Item("groupid") = .Item("faclcd") & "-" & GetFAClassDesc(.Item("faclcd"))
          Case "Equipment Condition"
            dr.Item("groupid") = .Item("faeqcd") & "-" & GetFAEqupDesc(.Item("faeqcd"))
          Case "Department"
            dr.Item("groupid") = .Item("fadecd") & "-" & GetFADeptDesc(.Item("fadecd"))
          Case "Location"
            dr.Item("groupid") = .Item("fablcd") & "-" & GetFABldgDesc(.Item("fablcd"))
          Case "GL Grouping"
            dr.Item("groupid") = .Item("faglgp")
          Case "Vendor"
            dr.Item("groupid") = .Item("favend")
          Case "User1"
            dr.Item("groupid") = .Item("fau1cd") & "-" & GetFAUser1Desc(.Item("fau1cd"))
          Case "User2"
            dr.Item("groupid") = .Item("fau2cd") & "-" & GetFAUser2Desc(.Item("fau2cd"))
          Case "User3"
            dr.Item("groupid") = .Item("fau3cd") & "-" & GetFAUser3Desc(.Item("fau3cd"))
          Case "User4"
            dr.Item("groupid") = .Item("fau4tx")
          Case "User5"
            dr.Item("groupid") = .Item("fau5tx")
        End Select
        If SaveGroup <> "" And SaveGroup <> dr.Item("groupid") And Good Then
          WriteTotals(SaveGroup)
          ClearTotals()
          Good = False
        End If
        SaveGroup = dr.Item("groupid")
        dr.Item("tag") = .Item("fatag")
        dr.Item("serial") = .Item("faserl")
        dr.Item("desc") = .Item("fadesc")
        WrkValue = GetHistory(.Item("fatag"))
        dr.Item("value") = WrkValue
        WrkTValue = WrkTValue + WrkValue
      End With
      If WrkValue <> 0 Then
        Good = True
        ds1.Tables(0).Rows.Add(dr)
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / (DsFAMSTR.Tables(0).Rows.Count)) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    WriteTotals(SaveGroup)
    myFrmProgress.Close()
    myFAMSTRQ.CloseFile()

  End Sub
  Private Sub WriteTotals(ByVal SaveGroup As String)
    dr2 = ds2.Tables(0).NewRow
    dr2.Item("groupid") = SaveGroup
    dr2.Item("tvalue") = WrkTValue
    ds2.Tables(0).Rows.Add(dr2)
  End Sub
  Private Function GetHistory(ByVal WrkTag As String) As Integer
    Dim dshist As DataSet = New DataSet
    Dim WrkValue As Integer
    Dim J As Integer

    dshist = myFAHIST.GetViewbyList(WrkTag, 999)
    For J = 0 To dshist.Tables(0).Rows.Count - 1
      If WrkHistFrom > 0 And dshist.Tables(0).Rows(J).Item("dedt") < WrkHistFrom Then
        Continue For
      End If
      If WrkHistTo > 0 And dshist.Tables(0).Rows(J).Item("dedt") > WrkHistTo Then
        Continue For
      End If
      Select Case WrkHistType
        Case "Adjust"
          If dshist.Tables(0).Rows(J).Item("adj") = "Y" Then
            WrkValue = WrkValue + dshist.Tables(0).Rows(J).Item("devl")
          End If
        Case "Depr"
          If Trim(dshist.Tables(0).Rows(J).Item("adj")) = "" Then
            WrkValue = WrkValue + dshist.Tables(0).Rows(J).Item("devl")
          End If
        Case Else
          WrkValue = WrkValue + dshist.Tables(0).Rows(J).Item("devl")
      End Select
    Next

    Return WrkValue
  End Function
End Module
