Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim ds As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim DsTXHST As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim DsUTCUSTAS As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkAnd As String
  Dim WrkOr As String
  'Screen fields
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkUBType As String
  Dim WrkOmit As Boolean
  Dim WrkLocNo As String
  Dim WrkLoc As String
  Dim WrkListNo As Integer
  'UB413
  Dim WrkCode As String
  Dim WrkPrevPaid As Decimal
  Dim WrkPaid As Decimal
  Dim WrkInt As Decimal
  Dim WrkLien As Decimal
  Dim WrkBond As Decimal
  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkAssmntLeft As Decimal
  'Totals
  Dim WrkTOrigBal As Decimal
  Dim WrkTPaid As Decimal
  Dim WrkTUnbilled As Decimal
  Dim WrkTCurrBal As Decimal
  Dim WrkTEndBal As Decimal
  Dim WrkTInt As Decimal
  Dim WrkTLien As Decimal
  Dim WrkTBond As Decimal
  Public Sub PrtReport()

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
      dsErr = ds.Clone
      BuildDSTot()
    Else
      ds.Clear()
      dsErr.Clear()
      dsTot.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdsErr = dsErr
    MyCrViewer.wrkdsTot = dsTot
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("OrigBal", Type.GetType("System.Decimal"))
      .Columns.Add("Payments", Type.GetType("System.Decimal"))
      .Columns.Add("CurrBal", Type.GetType("System.Decimal"))
      .Columns.Add("Unbilled", Type.GetType("System.Decimal"))
      .Columns.Add("EndBal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub BuildDSTot()
    Dim myTableTot As New DataTable
    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TOrigBal", Type.GetType("System.Decimal"))
      .Columns.Add("TPayments", Type.GetType("System.Decimal"))
      .Columns.Add("TCurrBal", Type.GetType("System.Decimal"))
      .Columns.Add("TUnbilled", Type.GetType("System.Decimal"))
      .Columns.Add("TPrinBal", Type.GetType("System.Decimal"))
      .Columns.Add("TEndBal", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TLien", Type.GetType("System.Decimal"))
      .Columns.Add("TBond", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkUnbilled As Decimal
    Dim WrkCurrBal As Decimal
    Dim WrkEndBal As Decimal
    Dim WrkPaidYear As Decimal
    Dim WrkFamily As String
    Dim WrkName As String
    Dim WrkLocation As String
    Dim WrkActive As Boolean
    Dim Good As Boolean

    ClearTotals()
    WrkDistAll = False

    With MyFrmUB413B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkUBType = .TxtUBType.Text
      WrkOmit = .ChkOmit.Checked
      WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
      WrkLocNo = MyUtils.JustifyRight(.TxtLocNo.Text, 7)
      WrkLoc = .TxtLoc.Text
    End With

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkFamily = GetUTTYPEFamily(WrkUBType)
    ClearTotals()

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

    If WrkListNo > 0 Then
      If WrkQry = "" Then
        WrkQry = "cuacct=" & WrkListNo
      Else
        WrkQry = WrkQry & WrkAnd & "cuacct=" & WrkListNo
      End If
    End If

    If WrkLoc <> String.Empty Then
      If WrkQry = "" Then
        WrkQry = "culoc=" & MyUtils.Quo(WrkLoc)
      Else
        WrkQry = WrkQry & WrkAnd & "culoc=" & MyUtils.Quo(WrkLoc)
      End If
      If Trim(WrkLocNo) <> String.Empty Then
        WrkQry = WrkQry & WrkAnd & "culoc#=" & MyUtils.Quo(WrkLocNo)
      End If
    End If

    WrkSort = "CUNAM1"
    DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)
    If DsUTCUST.Tables(0).Rows.Count = 0 Then
      myUTCUSTQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

    For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsUTCUST.Tables(0).Rows(I)
        WrkListNo = .Item("cuacct")
        WrkName = .Item("cunam1")
        WrkLocation = .Item("culoc#") & " " & .Item("culoc")
        WrkCode = GetRateCode(WrkUBType)
        If WrkCode = "" Then GoTo NextRec

        CalcAssmnt(I)
        WrkPaid = 0
        WrkInt = 0
        WrkLien = 0
        WrkBond = 0
        WrkUnbilled = 0
        WrkCurrBal = 0
        WrkActive = False

        DsTXINV = myTXINV.GetAllListNoType(WrkListNo, WrkUBType)
        For K = 0 To (DsTXINV.Tables(0).Rows.Count - 1)
          With DsTXINV.Tables(0).Rows(K)
            If .Item("icode") = "I" Then Continue For
            WrkActive = True
            WrkCurrBal = WrkCurrBal + .Item("bald")
            DsTXHST = myTXHSTL4.GetViewbyList(WrkListNo, .Item("year"), .Item("type"), 0, 9999)
            WrkPaidYear = 0
            For J = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
              With DsTXHST.Tables(0).Rows(J)
                If .Item("rcode") = "V" Then Continue For
                If .Item("rcode") = "I" Then Continue For

                WrkPaid = WrkPaid + .Item("pamt")
                WrkPaidYear = WrkPaidYear + .Item("pamt")
                WrkInt = WrkInt + .Item("iamt")
                WrkLien = WrkLien + .Item("lamt")
                WrkBond = WrkBond + .Item("pcamt")
              End With
            Next
            'If no payments for a year then use payments received instead
            If WrkPaidYear = 0 And .Item("payrec") > 0 Then
              WrkPaid = WrkPaid + .Item("payrec")
            End If
          End With
        Next

        If WrkOmit And Not WrkActive And K >= 0 Then 'Omit Inactive accounts
          GoTo NextRec
        End If

        WrkUnbilled = WrkAssmntLeft
        WrkEndBal = WrkOrigAssmnt - WrkPaid
        Good = False
        If WrkOrigAssmnt > 0 Then
          Good = True
          dr = ds.Tables(0).NewRow
          dr.Item("list") = WrkListNo
          dr.Item("type") = WrkUBType
          dr.Item("name") = WrkName
          dr.Item("location") = WrkLocation
          dr.Item("origbal") = WrkOrigAssmnt
          dr.Item("payments") = WrkPaid
          dr.Item("currbal") = WrkCurrBal
          dr.Item("unbilled") = WrkUnbilled
          dr.Item("endbal") = WrkEndBal
          dr.Item("interest") = WrkInt
          dr.Item("lien") = WrkLien
          dr.Item("bond") = WrkBond
          ds.Tables(0).Rows.Add(dr)
        End If
      End With

      'Check for Error
      If WrkOrigAssmnt - WrkPaid - WrkEndBal <> 0 Then
        dr = dsErr.Tables(0).NewRow
        dr.Item("list") = WrkListNo
        dr.Item("type") = WrkUBType
        dr.Item("name") = WrkName
        dr.Item("location") = WrkLocation
        dr.Item("origbal") = WrkOrigAssmnt
        dr.Item("payments") = WrkPaid
        dr.Item("currbal") = WrkCurrBal
        dr.Item("unbilled") = WrkUnbilled
        dr.Item("endbal") = WrkEndBal
        dr.Item("interest") = WrkInt
        dr.Item("lien") = WrkLien
        dr.Item("bond") = WrkBond
        dsErr.Tables(0).Rows.Add(dr)
      End If

      'Add to totals
      If Good Then
        WrkTOrigBal = WrkTOrigBal + WrkOrigAssmnt
        WrkTPaid = WrkTPaid + WrkPaid
        WrkTCurrBal = WrkTCurrBal + WrkCurrBal
        WrkTUnbilled = WrkTUnbilled + WrkUnbilled
        WrkTEndBal = WrkTEndBal + WrkEndBal
        WrkTInt = WrkTInt + WrkInt
        WrkTLien = WrkTLien + WrkLien
        WrkTBond = WrkTBond + WrkBond
      End If

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    WriteTotals()

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()

  End Sub
  Private Sub WriteTotals()
    dr = dsTot.Tables(0).NewRow
    dr.Item("type") = WrkUBType
    dr.Item("torigbal") = WrkTOrigBal
    dr.Item("tpayments") = WrkTPaid
    dr.Item("tcurrbal") = WrkTCurrBal
    dr.Item("tunbilled") = WrkTUnbilled
    dr.Item("tprinbal") = WrkTUnbilled + WrkTCurrBal
    dr.Item("tendbal") = WrkTEndBal
    dr.Item("tinterest") = WrkTInt
    dr.Item("tlien") = WrkTLien
    dr.Item("tbond") = WrkTBond
    dsTot.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub ClearTotals()
    WrkTOrigBal = 0
    WrkTPaid = 0
    WrkTCurrBal = 0
    WrkTUnbilled = 0
    WrkTEndBal = 0
    WrkTInt = 0
    WrkTLien = 0
    WrkTBond = 0
  End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)
    Dim MyUBCalcBill As UBCalcBill.BillAssessment

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
      .In_PropVal = DsUTCUST.Tables(0).Rows(I).Item("cupval")
      .In_Footage = DsUTCUST.Tables(0).Rows(I).Item("cufoot")
      .In_Acreage = DsUTCUST.Tables(0).Rows(I).Item("cuacre")
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.Round(.Out_OrigBill, 2)
      WrkAssmntLeft = MyUtils.Round(.Out_AmtLeft, 2)
    End With
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






