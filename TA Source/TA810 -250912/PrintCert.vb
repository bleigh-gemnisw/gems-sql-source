Module PrintCert
Dim ds As DataSet = New DataSet

Public Sub PrtCert(ByVal WrkType As String)

  BuildPrtDS()
  Select Case WrkType
  Case "R"
    AddRERecord()
  Case "P"
    AddPPRecord()
  Case "M"
    AddMVRecord()
  End Select
  MyFrmCrViewer = New FrmCrViewer
  MyFrmCrViewer.Wrkds = ds
  MyFrmCrViewer.WrkType = WrkType
  MyFrmCrViewer.ShowDialog()
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
      .Columns.Add("MVID", Type.GetType("System.String"))
      .Columns.Add("MVCls", Type.GetType("System.Int32"))
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
      .Columns.Add("MSRP", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

Private Sub AddRERecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8102R
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
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Sub AddPPRecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8103R
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
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
Private Sub AddMVRecord()
  Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmTA8104R
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetTXTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetTXCResnDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("mvid") = .TxtID.Text
      myDr("mvcls") = MyUtils.CnvSng(.TxtClass.Text)
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
      If MyUtils.CnvSng(.TxtOVMSRP.Text) > 0 Then
        myDr("msrp") = MyUtils.CnvSng(.TxtOVMSRP.Text)
      Else
        myDr("msrp") = MyUtils.CnvSng(.LblMSRP.Text)
      End If
      ds.Tables(0).Rows.Add(myDr)
    End With

End Sub
End Module






