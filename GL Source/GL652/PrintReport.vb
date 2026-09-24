Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myGLBUDGETQ As GLBUDGETQ.myData
Dim myGLBUDLED As GLBUDLED.myData
Dim myBUDNAR As BUDNAR.myData
Dim myDEPNARL As DEPNARL.myData

Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsBUDNAR As DataSet = New DataSet
Dim DsDEPNARL As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drTot As Data.DataRow
'Totals
Dim WrkActual3Yr As Integer
Dim WrkActual2Yr As Integer
Dim WrkActual1Yr As Integer
Dim WrkOrig As Integer
Dim WrkAmended As Integer
Dim WrkExpended As Integer
Dim WrkDept As Integer
Dim WrkMayor As Integer
Dim WrkTownCon As Integer
Dim WrkNextCarry As Integer
Dim WrkPlan1Yr As Integer
Dim WrkPlan2Yr As Integer
Dim WrkPlan3Yr As Integer
Dim WrkPlan4Yr As Integer
Dim WrkPlan5Yr As Integer

Dim SaveDept As Integer
  Public Sub PrtReport()

  myGLBUDGETQ = New GLBUDGETQ.MyData()
  myGLBUDGETQ.MyDBConn = myDBConnect
  myGLBUDLED = New GLBUDLED.myData()
  myGLBUDLED.MyDBConn = myDBConnect
  myBUDNAR = New BUDNAR.myData()
  myBUDNAR.MyDBConn = myDBConnect
  myDEPNARL = New DEPNARL.MyData()
  myDEPNARL.MyDBConn = myDBConnect

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    dsTot.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkdstot = dsTot
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("GroupDesc", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("Actual3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("PrevCarry", Type.GetType("System.Decimal"))
      .Columns.Add("Orig", Type.GetType("System.Decimal"))
      .Columns.Add("Amended", Type.GetType("System.Decimal"))
      .Columns.Add("Expended", Type.GetType("System.Decimal"))
      .Columns.Add("ExpendedDiff", Type.GetType("System.Decimal"))
      .Columns.Add("ExpendedPct", Type.GetType("System.Decimal"))
      .Columns.Add("NextCarry", Type.GetType("System.Decimal"))
      .Columns.Add("Dept", Type.GetType("System.Decimal"))
      .Columns.Add("DeptDiff", Type.GetType("System.Decimal"))
      .Columns.Add("DeptPct", Type.GetType("System.Decimal"))
      .Columns.Add("Mayor", Type.GetType("System.Decimal"))
      .Columns.Add("MayorDiff", Type.GetType("System.Decimal"))
      .Columns.Add("MayorPct", Type.GetType("System.Decimal"))
      .Columns.Add("TownCon", Type.GetType("System.Decimal"))
      .Columns.Add("Plan1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan4Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan5Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Notes", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("DeptNo", Type.GetType("System.Int32"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("Actual3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("PrevCarry", Type.GetType("System.Decimal"))
      .Columns.Add("Orig", Type.GetType("System.Decimal"))
      .Columns.Add("Amended", Type.GetType("System.Decimal"))
      .Columns.Add("Expended", Type.GetType("System.Decimal"))
      .Columns.Add("ExpendedDiff", Type.GetType("System.Decimal"))
      .Columns.Add("ExpendedPct", Type.GetType("System.Decimal"))
      .Columns.Add("NextCarry", Type.GetType("System.Decimal"))
      .Columns.Add("Dept", Type.GetType("System.Decimal"))
      .Columns.Add("DeptDiff", Type.GetType("System.Decimal"))
      .Columns.Add("DeptPct", Type.GetType("System.Decimal"))
      .Columns.Add("Mayor", Type.GetType("System.Decimal"))
      .Columns.Add("MayorDiff", Type.GetType("System.Decimal"))
      .Columns.Add("MayorPct", Type.GetType("System.Decimal"))
      .Columns.Add("TownCon", Type.GetType("System.Decimal"))
      .Columns.Add("Plan1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan4Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Plan5Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Notes", Type.GetType("System.String"))
    End With
    dstot.Tables.Add(myTableTot)
  End Sub
Private Sub ClearTotals()
  WrkActual3Yr = 0
  WrkActual2Yr = 0
  WrkActual1Yr = 0
  WrkOrig = 0
  WrkAmended = 0
  WrkExpended = 0
  WrkDept = 0
  WrkMayor = 0
  WrkTownCon = 0
  WrkNextCarry = 0
  WrkPlan1Yr = 0
  WrkPlan2Yr = 0
  WrkPlan3Yr = 0
  WrkPlan4Yr = 0
  WrkPlan5Yr = 0
End Sub

  Private Sub GetDetail()
    Dim WrkSelFund As Integer
    Dim WrkSelDept As Integer
    Dim WrkAcct As String
    Dim sb As StringBuilder
    Dim WrkOmitNoAct As Boolean
    Dim WrkNum As Decimal
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim J As Integer
    Dim WrkAnd As String

    With MyFrmGL652B
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelDept = MyUtils.CnvSng(.TxtDept.Text)
      WrkOmitNoAct = .ChkOmit.Checked
    End With

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = "DEPT"
    WrkQry = "FUND=" & WrkSelFund & WrkAnd & "GLTYP='X'"
    If WrkSelDept > 0 Then
      WrkQry = WrkQry & WrkAnd & "DEPT=" & WrkSelDept
    End If
    myGLBUDGETQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myGLBUDGETQ.ReadQry()
    If Not myGLBUDGETQ.IsEOF Then
      With myGLBUDGETQ
        Counter = Counter + 1
        WrkAcct = BuildDept(._FUND, ._SFUND, ._DEPT)
        If SaveDept > 0 And SaveDept <> ._DEPT Then
          WriteTotals(._FUND)
          ClearTotals()
        End If
        SaveDept = ._DEPT
        If WrkOmitNoAct Then
          If ._ACT1 = 0 And ._ACT2 = 0 And ._ORIG = 0 And ._EXP = 0 _
           And ._CURR = 0 And ._BAMT1 = 0 And ._BAMT2 = 0 And ._BAMT3 = 0 And ._ADOPTD = 0 Then
            GoTo NextRec
          End If
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("group") = WrkAcct
        dr.Item("groupdesc") = GetGLACCTDesc(._FUND, 0, ._DEPT, 0, 0, 0)
        WrkAcct = BuildAcct(._OBJ, ._FUNC, ._SFUNC)
        dr.Item("acct") = WrkAcct
        dr.Item("descr") = GetGLACCTDesc(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
        dr.Item("actual3yr") = ._ACT3
        dr.Item("actual2yr") = ._ACT2
        dr.Item("actual1yr") = ._ACT1
        dr.Item("orig") = ._ORIG
        dr.Item("amended") = ._CURR
        dr.Item("expended") = ._EXP
        If ._ORIG > 0 Then
          WrkNum = ._EXP / ._ORIG
          dr.Item("expendedpct") = WrkNum * 100
        Else
          dr.Item("expendedpct") = 0
        End If
        dr.Item("dept") = ._BAMT1
        WrkNum = ._BAMT1 - ._ORIG
        dr.Item("deptdiff") = WrkNum
        If ._ORIG > 0 Then
          WrkNum = (WrkNum / ._ORIG) * 100
          dr.Item("deptpct") = WrkNum
        Else
          dr.Item("deptpct") = 0
        End If
        dr.Item("mayor") = ._BAMT2
        WrkNum = ._BAMT2 - ._ORIG
        dr.Item("mayordiff") = WrkNum
        If ._ORIG > 0 Then
          WrkNum = (WrkNum / ._ORIG) * 100
          dr.Item("mayorpct") = WrkNum
        Else
          dr.Item("mayorpct") = 0
        End If
        dr.Item("towncon") = ._BAMT3

        'Expanded file
        myGLBUDLED.GetOneRecordP(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
        If Not myGLBUDLED.RecordNotFound Then
          With myGLBUDLED
            dr.Item("status") = GetStatus(._ESTAT)
            dr.Item("prevcarry") = 0
            dr.Item("nextcarry") = ._ECARY
            dr.Item("plan1yr") = ._EFUT1
            dr.Item("plan2yr") = ._EFUT2
            dr.Item("plan3yr") = ._EFUT3
            dr.Item("plan4yr") = ._EFUT4
            dr.Item("plan5yr") = ._EFUT5
            WrkNextCarry = WrkNextCarry + ._ECARY
            WrkPlan1Yr = WrkPlan1Yr + ._EFUT1
            WrkPlan2Yr = WrkPlan2Yr + ._EFUT2
            WrkPlan3Yr = WrkPlan3Yr + ._EFUT3
            WrkPlan4Yr = WrkPlan4Yr + ._EFUT4
            WrkPlan5Yr = WrkPlan5Yr + ._EFUT5
          End With
        End If

        sb = New StringBuilder("")
        'Account Narrative File
        DsBUDNAR = myBUDNAR.GetViewbyAcct(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC, 999)
        If DsBUDNAR.Tables(0).Rows.Count > 0 Then
          For J = 0 To DsBUDNAR.Tables(0).Rows.Count - 1
            With DsBUDNAR.Tables(0).Rows(J)
              sb.Append(.Item("nar1"))
              sb.Append(" ")
            End With
          Next
        End If
        dr.Item("notes") = sb.ToString
        ds.Tables(0).Rows.Add(dr)
        'Summary Totals
        WrkActual3Yr = WrkActual3Yr + ._ACT3
        WrkActual2Yr = WrkActual2Yr + ._ACT2
        WrkActual1Yr = WrkActual1Yr + ._ACT1
        WrkOrig = WrkOrig + ._ORIG
        WrkAmended = WrkAmended + ._CURR
        WrkExpended = WrkExpended + ._EXP
        WrkDept = WrkDept + ._BAMT1
        WrkMayor = WrkMayor + ._BAMT2
        WrkTownCon = WrkTownCon + ._BAMT3
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

    WriteTotals(WrkSelFund)
    myFrmProgress.Close()
    myGLBUDGETQ.CloseFile()

  End Sub
  Private Function BuildDept(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer) As String
  Dim sb As StringBuilder = New StringBuilder

  sb.Append(Format(Fund, "000"))
  sb.Append("-")
  sb.Append(Format(SFund, "000"))
  sb.Append("-")
  sb.Append(Format(Dept, "0000"))
  Return sb.ToString
End Function
Private Function BuildAcct(ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
  Dim sb As StringBuilder = New StringBuilder

  sb.Append(Format(Obj, "000"))
  sb.Append("-")
  sb.Append(Format(Func, "0000"))
  sb.Append("-")
  sb.Append(Format(SFunc, "0000"))
  Return sb.ToString
End Function
Private Function GetStatus(ByVal Code As String) As String
  Dim WrkDesc As String

  WrkDesc = ""
  Select Case Code
  Case "C"
    WrkDesc = "Contractual"
  Case "D"
    WrkDesc = "Desirable but not Essential"
  Case "EB"
    WrkDesc = "Essential to Basic"
  Case "EI"
    WrkDesc = "Essential to Improved"
  Case "M"
    WrkDesc = "Mandated"
  End Select

  Return WrkDesc
End Function
Private Sub WriteTotals(ByVal Fund As Integer)
  Dim sb As StringBuilder
  Dim WrkNum As Decimal
  Dim J As Integer

  drTot = dsTot.Tables(0).NewRow
  drTot.Item("deptno") = SaveDept
  drTot.Item("descr") = GetGLACCTDesc(Fund, 0, SaveDept, 0, 0, 0)
  drTot.Item("actual3yr") = WrkActual3Yr
  drTot.Item("actual2yr") = WrkActual2Yr
  drTot.Item("actual1yr") = WrkActual1Yr
  drTot.Item("orig") = WrkOrig
  drTot.Item("amended") = WrkAmended
  drTot.Item("expended") = WrkExpended
  If WrkOrig > 0 Then
    WrkNum = WrkExpended / WrkOrig
    drTot.Item("expendedpct") = WrkNum * 100
  Else
    drTot.Item("expendedpct") = 0
  End If
  drTot.Item("dept") = WrkDept
  WrkNum = WrkDept - WrkOrig
  drTot.Item("deptdiff") = WrkNum
  If WrkOrig > 0 Then
    WrkNum = (WrkNum / WrkOrig) * 100
    drTot.Item("deptpct") = WrkNum
  Else
    drTot.Item("deptpct") = 0
  End If
  drTot.Item("mayor") = WrkMayor
  WrkNum = WrkMayor - WrkOrig
  drTot.Item("mayordiff") = WrkNum
  If WrkOrig > 0 Then
    WrkNum = (WrkNum / WrkOrig) * 100
    drTot.Item("mayorpct") = WrkNum
  Else
    drTot.Item("mayorpct") = 0
  End If
  drTot.Item("towncon") = WrkTownCon
  drTot.Item("nextcarry") = WrkNextCarry
  drTot.Item("plan1yr") = WrkPlan1Yr
  drTot.Item("plan2yr") = WrkPlan2Yr
  drTot.Item("plan3yr") = WrkPlan3Yr
  drTot.Item("plan4yr") = WrkPlan4Yr
  drTot.Item("plan5yr") = WrkPlan5Yr

  sb = New StringBuilder("")
  'Department Narrative File
  DsDEPNARL = myDEPNARL.GetViewbyDept(SaveDept, 999)
  If DsDEPNARL.Tables(0).Rows.Count > 0 Then
    For J = 0 To DsDEPNARL.Tables(0).Rows.Count - 1
      With DsDEPNARL.Tables(0).Rows(J)
          sb.Append(.Item("narr"))
          sb.Append(" ")
      End With
    Next
  End If
  drTot.Item("notes") = sb.ToString
  dsTot.Tables(0).Rows.Add(drTot)

End Sub
	Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer, _
		ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer, _
		ByVal PSubFunc As Integer) As String
		 Dim myGLACCT As GLACCT.myData

     myGLACCT = New GLACCT.MyData()
     myGLACCT.MyDBConn = myDBConnect
     If PFund = 0 Then
       Return ""
     End If

		 myGLACCT.GetOneRecordP(PFund, PSubFund, PDept, PObject, PFunction, PSubFunc)
		 If Not myGLACCT.RecordNotFound Then
			 GetGLACCTDesc = Trim(myGLACCT._GLDSC)
		 Else
			 GetGLACCTDesc = "*** Unknown ***"
		 End If
		 Return GetGLACCTDesc

	End Function
End Module
