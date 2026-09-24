Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myFAMSTRQ As FAMSTRQ.MyData
  Dim ds1 As DataSet = New DataSet
  Dim DsFAMSTR As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkAcqFrom As Integer
  Dim WrkAcqTo As Integer
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
  Dim WrkExpirationDate As Date

  'Buffered files
  Dim WrkAcqCode(100) As String
  Dim WrkAcqDesc(100) As String

  Public Sub PrtReport()
    Dim WrkSortby As String
    myFAMSTRQ = New FAMSTRQ.MyData()
    myFAMSTRQ.MyDBConn = myDBConnect

    With MyFrmFA102B
      WrkAcqFrom = 0
      WrkAcqTo = 0
      If .DtPckAcqFrom.Checked Then
        WrkAcqFrom = MyUtils.SetDBDate(.DtPckAcqFrom.Value)
      End If
      If .DtPckAcqTo.Checked Then
        WrkAcqTo = MyUtils.SetDBDate(.DtPckAcqTo.Value)
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
      WrkExpirationDate = MyUtils.StripTime(.DtPckExpiration.Value)

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
    End If

    BufferAcqDesc()
    GetDetail()

Done:

    WrkSortby = " by " & WrkPSort
    If WrkSSort <> "" Then
      WrkSortby = WrkSortby & ", " & WrkSSort
    End If
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.WrkExpirationDate = Format(WrkExpirationDate, "short date")
    MyCrViewer.WrkSortby = WrkSortby
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("Tag", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Serial", Type.GetType("System.String"))
      .Columns.Add("AcqVal", Type.GetType("System.Int32"))
      .Columns.Add("AcqDesc", Type.GetType("System.String"))
      .Columns.Add("AcqDate", Type.GetType("System.String"))
      .Columns.Add("LifeDate", Type.GetType("System.String"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkSortby As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim SaveGroup As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "FASTAT='A'" & WrkAnd & "FADSCD=' '" & WrkAnd & "FAEYR>0"
    WrkSortby = ""
    If WrkAsTypeFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD >= " & MyUtils.Quo(WrkAsTypeFrom)
    End If
    If WrkAsTypeTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD <= " & MyUtils.Quo(WrkAsTypeTo)
    End If
    If WrkAcqFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQDT >= " & WrkAcqFrom
    End If
    If WrkAcqTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQDT <= " & WrkAcqTo
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
    If MyFrmFA102B.RbFundBusiness.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV<>'Y'"
    End If
    If MyFrmFA102B.RbFundGovernment.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV='Y'"
    End If
    If MyFrmFA102B.RbDeprYes.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP<>'Y'"
    End If
    If MyFrmFA102B.RbDeprNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP='Y'"
    End If
    If MyFrmFA102B.RbAssetsReport.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP<>'Y'"
    End If
    If MyFrmFA102B.RbAssetsNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP='Y'"
    End If

    If WrkSSort <> "" Then
      WrkSortby = BuildSort(WrkPSort) & "," & BuildSort(WrkSSort) & ",FADESC"
    Else
      WrkSortby = BuildSort(WrkPSort) & ",FADESC"
    End If

    DsFAMSTR = myFAMSTRQ.GetQry(WrkSortby, WrkQry, 0)
    If DsFAMSTR.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveGroup = ""

    For I = 0 To (DsFAMSTR.Tables(0).Rows.Count - 1)
      With DsFAMSTR.Tables(0).Rows(I)
        dr = ds1.Tables(0).NewRow
        'Filter Life Expectancy dates beyond Expiration date
        If .Item("faedt") > 0 Then
          If MyUtils.GetDBDate(.Item("faedt")) > WrkExpirationDate Then
            GoTo NextRec
          End If
        End If

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
        dr.Item("tag") = .Item("fatag")
        dr.Item("serial") = .Item("faserl")
        dr.Item("desc") = .Item("fadesc")
        dr.Item("acqval") = .Item("faaqvl")
        dr.Item("acqdesc") = LookupAcqDesc(.Item("faaqcd"))
        dr.Item("acqdate") = Format(MyUtils.GetDBDate(.Item("faaqdt")), "M/d/yyyy")
        If .Item("faedt") > 0 Then
          dr.Item("lifedate") = Format(MyUtils.GetDBDate(.Item("faedt")), "M/d/yyyy")
        End If
      End With
      ds1.Tables(0).Rows.Add(dr)
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

    myFrmProgress.Close()
    myFAMSTRQ.CloseFile()

  End Sub
  Private Sub BufferAcqDesc()
    Dim I As Integer

    Dim myFAAQUMT As FAAQUMT.MyData
    Dim dsFAAQUMT As DataSet = New DataSet

    myFAAQUMT = New FAAQUMT.MyData()
    myFAAQUMT.MyDBConn = myDBConnect

    dsFAAQUMT = myFAAQUMT.PosData("")
    For I = 0 To dsFAAQUMT.Tables(0).Rows.Count - 1
      With dsFAAQUMT.Tables(0).Rows(I)
        WrkAcqCode(I) = .Item("aqcode")
        WrkAcqDesc(I) = .Item("aqdesc")
      End With
    Next

  End Sub
  Private Function LookupAcqDesc(ByVal Code As String) As String
    Dim I As Integer
    Dim WrkDesc As String

    For I = 0 To WrkAcqCode.GetUpperBound(0)
      If WrkAcqCode(I) Is Nothing Then
        Return ""
      End If
      If Code = WrkAcqCode(I) Then
        WrkDesc = WrkAcqDesc(I)
        Return WrkDesc
      End If
    Next

    Return ""
  End Function
End Module
