Module PrintCert
Dim ds As DataSet = New DataSet

Public Sub PrtCert(ByVal WrkType As String)
  Dim WrkTypeFamily As String

  WrkTypeFamily = GetTXTypeFamily(WrkType)
  BuildPrtDS()
  Select Case WrkTypeFamily
  Case "R"
    AddRERecord()
  Case "P"
    AddPPRecord()
  Case "M"
    AddMVRecord()
  Case "S"
    AddSURecord()
  End Select

  MyfrmCrViewer = New FrmCrViewer
  MyfrmCrViewer.Wrkds = ds
  MyfrmCrViewer.WrkType = WrkType
  MyfrmCrViewer.ShowDialog()
  ds.Tables.Remove("mytable")

End Sub
  Private Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Cdate", Type.GetType("System.DateTime"))
      .Columns.Add("Cdesc", Type.GetType("System.String"))
      .Columns.Add("Locno", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("Rsncd", Type.GetType("System.String"))
      .Columns.Add("RsnDesc", Type.GetType("System.String"))
      .Columns.Add("Map", Type.GetType("System.String"))
      .Columns.Add("MVClass", Type.GetType("System.Int32"))
      .Columns.Add("MVID", Type.GetType("System.String"))
      .Columns.Add("MVReg", Type.GetType("System.String"))
      .Columns.Add("MVYear", Type.GetType("System.String"))
      .Columns.Add("MVMake", Type.GetType("System.String"))
      .Columns.Add("MVModel", Type.GetType("System.String"))
      .Columns.Add("SSNo", Type.GetType("System.Int32"))
      .Columns.Add("SS2", Type.GetType("System.Int32"))
      .Columns.Add("Oid", Type.GetType("System.String"))
      .Columns.Add("Ogross", Type.GetType("System.Int32"))
      .Columns.Add("Ngross", Type.GetType("System.Int32"))
      .Columns.Add("Cgross", Type.GetType("System.Int32"))
      .Columns.Add("Oexam", Type.GetType("System.Int32"))
      .Columns.Add("Nexam", Type.GetType("System.Int32"))
      .Columns.Add("Cexam", Type.GetType("System.Int32"))
      .Columns.Add("OProrate", Type.GetType("System.Int32"))
      .Columns.Add("NProrate", Type.GetType("System.Int32"))
      .Columns.Add("CProrate", Type.GetType("System.Int32"))
      .Columns.Add("Onet", Type.GetType("System.Int32"))
      .Columns.Add("Nnet", Type.GetType("System.Int32"))
      .Columns.Add("Cnet", Type.GetType("System.Int32"))
      .Columns.Add("Oamt", Type.GetType("System.Decimal"))
      .Columns.Add("Namt", Type.GetType("System.Decimal"))
      .Columns.Add("Camt", Type.GetType("System.Decimal"))
      .Columns.Add("OCred", Type.GetType("System.Decimal"))
      .Columns.Add("NCred", Type.GetType("System.Decimal"))
      .Columns.Add("CCred", Type.GetType("System.Decimal"))
      .Columns.Add("ODue", Type.GetType("System.Decimal"))
      .Columns.Add("NDue", Type.GetType("System.Decimal"))
      .Columns.Add("CDue", Type.GetType("System.Decimal"))
      .Columns.Add("SaleMonth", Type.GetType("System.String"))
      .Columns.Add("MSRP", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub AddRERecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8112R
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetTXTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("locno") = .TxtLocNo.Text
      myDr("loc") = .TxtLoc.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetTXCResnDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("map") = .TxtMap.Text
      myDr("ogross") = MyUtils.CnvSng(.LblOrigGross.Text)
      myDr("ngross") = MyUtils.CnvSng(.LblNewGross.Text)
      myDr("cgross") = MyUtils.CnvSng(.LblChgGross.Text)
      myDr("oexam") = MyUtils.CnvSng(.LblOrigExam.Text)
      myDr("nexam") = MyUtils.CnvSng(.LblNewExam.Text)
      myDr("cexam") = MyUtils.CnvSng(.LblChgExam.Text)
      myDr("OProrate") = 0
      myDr("NProrate") = 0
      myDr("CProrate") = 0
      myDr("onet") = MyUtils.CnvSng(.LblOrigNet.Text)
      myDr("nnet") = MyUtils.CnvSng(.LblNewNet.Text)
      myDr("cnet") = MyUtils.CnvSng(.LblChgNet.Text)
      myDr("oamt") = MyUtils.CnvSng(.LblOrigAmt.Text)
      myDr("namt") = MyUtils.CnvSng(.LblNewAmt.Text)
      myDr("camt") = MyUtils.CnvSng(.LblChgAmt.Text)
      myDr("ocred") = MyUtils.CnvSng(.LblOrigCred.Text)
      myDr("ncred") = MyUtils.CnvSng(.LblNewCred.Text)
      myDr("ccred") = MyUtils.CnvSng(.LblChgCred.Text)
      myDr("odue") = MyUtils.CnvSng(.LblOrigDue.Text)
      myDr("ndue") = MyUtils.CnvSng(.LblNewDue.Text)
      myDr("cdue") = MyUtils.CnvSng(.LblChgDue.Text)
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Sub AddPPRecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8113R
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetTXTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("locno") = .TxtLocNo.Text
      myDr("loc") = .TxtLoc.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetTXCResnDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("ogross") = MyUtils.CnvSng(.LblOrigGross.Text)
      myDr("ngross") = MyUtils.CnvSng(.LblNewGross.Text)
      myDr("cgross") = MyUtils.CnvSng(.LblChgGross.Text)
      myDr("oexam") = MyUtils.CnvSng(.LblOrigExam.Text)
      myDr("nexam") = MyUtils.CnvSng(.LblNewExam.Text)
      myDr("cexam") = MyUtils.CnvSng(.LblChgExam.Text)
      myDr("OProrate") = 0
      myDr("NProrate") = 0
      myDr("CProrate") = 0
      myDr("onet") = MyUtils.CnvSng(.LblOrigNet.Text)
      myDr("nnet") = MyUtils.CnvSng(.LblNewNet.Text)
      myDr("cnet") = MyUtils.CnvSng(.LblChgNet.Text)
      myDr("oamt") = MyUtils.CnvSng(.LblOrigAmt.Text)
      myDr("namt") = MyUtils.CnvSng(.LblNewAmt.Text)
      myDr("camt") = MyUtils.CnvSng(.LblChgAmt.Text)
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Sub AddMVRecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8114R
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetTXTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetTXCResnDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("mvclass") = MyUtils.CnvSng(.TxtClass.Text)
      myDr("mvid") = .TxtID.Text
      myDr("mvreg") = .TxtReg.Text
      myDr("mvyear") = .TxtMVYear.Text
      myDr("mvmake") = .TxtMake.Text
      myDr("mvmodel") = .TxtModel.Text
      myDr("ssno") = MyUtils.CnvSng(.TxtSSNo.Text)
      myDr("ss2") = MyUtils.CnvSng(.TxtSS2.Text)
      myDr("oid") = .TxtOid.Text
      myDr("ogross") = MyUtils.CnvSng(.LblOrigGross.Text)
      myDr("ngross") = MyUtils.CnvSng(.LblNewGross.Text)
      myDr("cgross") = MyUtils.CnvSng(.LblChgGross.Text)
      myDr("oexam") = MyUtils.CnvSng(.LblOrigExam.Text)
      myDr("nexam") = MyUtils.CnvSng(.LblNewExam.Text)
      myDr("cexam") = MyUtils.CnvSng(.LblChgExam.Text)
      myDr("OProrate") = MyUtils.CnvSng(.LblOrigProrate.Text)
      myDr("NProrate") = MyUtils.CnvSng(.LblNewProrate.Text)
      myDr("CProrate") = MyUtils.CnvSng(.LblChgProrate.Text)
      myDr("onet") = MyUtils.CnvSng(.LblOrigNet.Text)
      myDr("nnet") = MyUtils.CnvSng(.LblNewNet.Text)
      myDr("cnet") = MyUtils.CnvSng(.LblChgNet.Text)
      myDr("oamt") = MyUtils.CnvSng(.LblOrigAmt.Text)
      myDr("namt") = MyUtils.CnvSng(.LblNewAmt.Text)
      myDr("camt") = MyUtils.CnvSng(.LblChgAmt.Text)
      If MyUtils.CnvSng(.TxtOVMSRP.Text) > 0 Then
        myDr("msrp") = MyUtils.CnvSng(.TxtOVMSRP.Text)
      Else
        myDr("msrp") = MyUtils.CnvSng(.LblMSRP.Text)
      End If
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Sub AddSURecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8115R
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetTXTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetTXCResnDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("mvclass") = MyUtils.CnvSng(.TxtClass.Text)
      myDr("mvid") = .TxtID.Text
      myDr("mvreg") = .TxtReg.Text
      myDr("mvyear") = .TxtMVYear.Text
      myDr("mvmake") = .TxtMake.Text
      myDr("mvmodel") = .TxtModel.Text
      myDr("ssno") = MyUtils.CnvSng(.TxtSSNo.Text)
      myDr("ss2") = MyUtils.CnvSng(.TxtSS2.Text)
      myDr("oid") = .TxtOid.Text
      myDr("ogross") = MyUtils.CnvSng(.LblOrigGross.Text)
      myDr("ngross") = MyUtils.CnvSng(.LblNewGross.Text)
      myDr("cgross") = MyUtils.CnvSng(.LblChgGross.Text)
      myDr("oexam") = MyUtils.CnvSng(.LblOrigExam.Text)
      myDr("nexam") = MyUtils.CnvSng(.LblNewExam.Text)
      myDr("cexam") = MyUtils.CnvSng(.LblChgExam.Text)
      myDr("OProrate") = MyUtils.CnvSng(.LblOrigProrate.Text)
      myDr("NProrate") = MyUtils.CnvSng(.LblNewProrate.Text)
      myDr("CProrate") = MyUtils.CnvSng(.LblChgProrate.Text)
      myDr("onet") = MyUtils.CnvSng(.LblOrigNet.Text)
      myDr("nnet") = MyUtils.CnvSng(.LblNewNet.Text)
      myDr("cnet") = MyUtils.CnvSng(.LblChgNet.Text)
      myDr("oamt") = MyUtils.CnvSng(.LblOrigAmt.Text)
      myDr("namt") = MyUtils.CnvSng(.LblNewAmt.Text)
      myDr("camt") = MyUtils.CnvSng(.LblChgAmt.Text)
      myDr("salemonth") = GetMonthName(MyUtils.CnvSng(.TxtSaleMonth.Text))
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Function GetMonthName(ByVal Month As Integer) As String

  Select Case Month
  Case 1
    GetMonthName = "January"
  Case 2
    GetMonthName = "February"
  Case 3
    GetMonthName = "March"
  Case 4
    GetMonthName = "April"
  Case 5
    GetMonthName = "May"
  Case 6
    GetMonthName = "June"
  Case 7
    GetMonthName = "July"
  Case 8
    GetMonthName = "August"
  Case 9
    GetMonthName = "September"
  Case 10
    GetMonthName = "October"
  Case 11
    GetMonthName = "November"
  Case 12
    GetMonthName = "December"
  Case Else
    GetMonthName = ""
  End Select

  Return GetMonthName
End Function
End Module






