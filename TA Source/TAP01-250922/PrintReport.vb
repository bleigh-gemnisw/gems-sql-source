Imports System.text
Module PrintReport

Dim MyTXDCDTL As TXDCDTL.myData
Dim MyTXDCCD As TXDCCD.myData
Dim MyTXDCDEP As TXDCDEP.myData
Dim MyTXDCSUM As TXDCSUM.myData
Dim MyTXDCEXM As TXDCEXM.myData
Dim MyTXDCEX As TXDCEX.myData
Dim MyTXDCCOM As TXDCCOM.myData
Dim Ds As DataSet = New DataSet
Public Sub PrtReport()
  Dim MyCRViewer As FrmCrViewer

  MyTXDCDTL = New TXDCDTL.mydata(MyDBConnect)
  MyTXDCCD = New TXDCCD.mydata(MyDBConnect)
  MyTXDCDEP = New TXDCDEP.mydata(MyDBConnect)
	MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
	MyTXDCEXM = New TXDCEXM.mydata(MyDBConnect)
	MyTXDCEX = New TXDCEX.mydata(MyDBConnect)
  MyTXDCCOM = New TXDCCOM.mydata(MyDBConnect)
  If Ds.Tables.Count = 0 Then
    BuildDS()
  Else
    Ds.Clear()
  End If

  GetDetail()

Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkds = Ds
  MyCRViewer.ShowDialog()

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Filsts", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("OwName", Type.GetType("System.String"))
      .Columns.Add("DBA", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("RptID", Type.GetType("System.String"))
			.Columns.Add("Code", Type.GetType("System.Int16"))
      .Columns.Add("Ltr", Type.GetType("System.String"))
			.Columns.Add("DeYear", Type.GetType("System.String"))
			.Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Cost", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Decimal"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("Comment", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
		Dim ds3 As DataSet = New DataSet
		Dim ds4 As DataSet = New DataSet
		Dim dr As Data.DataRow
    Dim WrkYear As Integer
    Dim WrkYearNo As Integer
    Dim WrkValue As Integer
    Dim WrkProrated As Integer
    Dim WrkFilsts As String
    Dim WrkStatus As String
    Dim WrkComment As String
    Dim I As Integer

		'Depreciation Code Details
    WrkYear = MyUtils.CnvSng(MyFrmTAP01C.LblYear.Text)
    WrkFilsts = ""
    WrkStatus = ""
    If MyFrmTAP01C.RbFileOntime.Checked Then WrkFilsts = "On Time"
    If MyFrmTAP01C.RbFileExt.Checked Then WrkFilsts = "Extension"
    If MyFrmTAP01C.RbFileLate.Checked Then WrkFilsts = "Late"
    If MyFrmTAP01C.RbFileNon.Checked Then WrkFilsts = "Non-Filer"
    If MyFrmTAP01C.RbStatActive.Checked Then WrkStatus = "Active"
    If MyFrmTAP01C.RbStatIncr.Checked Then WrkStatus = "Increase"
    If MyFrmTAP01C.RbStatPend.Checked Then WrkStatus = "Pending"
    If MyFrmTAP01C.RbStatInact.Checked Then WrkStatus = "Inactive"
    WrkComment = ""
    ds2 = MyTXDCDTL.GetByList(MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text), WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      MyTXDCCD.GetOneRecordP(WrkYear, ds2.Tables(0).Rows(I).Item("CODE"), ds2.Tables(0).Rows(I).Item("LTR"))
      WrkYearNo = WrkYear - ds2.Tables(0).Rows(I).Item("deyear") + 1
      MyTXDCDEP.GetOneRecordP(WrkYear, MyTXDCCD._DECODE, WrkYearNo)
      If MyTXDCDEP.RecordNotFound Then Continue For
      dr = Ds.Tables(0).NewRow
      dr("Filsts") = WrkFilsts
      dr("Status") = WrkStatus
      dr("ListNo") = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
      dr("Year") = WrkYear
      dr("OwName") = MyFrmTAP01C.TxtOwname.Text
      dr("dba") = MyFrmTAP01C.TxtDBA.Text
      dr("loc") = Trim(MyFrmTAP01C.TxtLocNo.Text) & " " & MyFrmTAP01C.TxtLoc.Text
      dr("RptID") = "A"
      dr("Code") = ds2.Tables(0).Rows(I).Item("Code")
      dr("Ltr") = ds2.Tables(0).Rows(I).Item("Ltr")
      dr("DeYear") = ds2.Tables(0).Rows(I).Item("deyear")
      If MyTXDCDEP._PRIOR = "Y" Then
        dr("Descr") = "Prior Yrs"
      Else
        dr("Descr") = "10-1-" & Mid(ds2.Tables(0).Rows(I).Item("deyear"), 3, 2)
      End If
      dr("Cost") = ds2.Tables(0).Rows(I).Item("DECOST")
       If MyTXDCDEP._PROPCT > 0 Then
         WrkProrated = MyUtils.Round(ds2.Tables(0).Rows(I).Item("decost") * (MyTXDCDEP._PROPCT / 100), 0)
       Else
         WrkProrated = ds2.Tables(0).Rows(I).Item("decost")
       End If
      dr("Pct") = MyTXDCDEP._PCT
      WrkValue = MyUtils.Round(WrkProrated * (MyTXDCDEP._PCT / 100), 0)
      dr("Value") = WrkValue
      Ds.Tables(0).Rows.Add(dr)
    Next
    ds2.Clear()

    'Summary headings
    dr = Ds.Tables(0).NewRow
    dr("RptID") = "B"
    dr("Filsts") = WrkFilsts
    dr("Status") = WrkStatus
    dr("ListNo") = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
    dr("Year") = WrkYear
    dr("OwName") = MyFrmTAP01C.TxtOwname.Text
    dr("dba") = MyFrmTAP01C.TxtDBA.Text
    dr("loc") = Trim(MyFrmTAP01C.TxtLocNo.Text) & " " & MyFrmTAP01C.TxtLoc.Text
    Ds.Tables(0).Rows.Add(dr)

    'Summary 
    ds3 = MyTXDCSUM.GetByList(MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text), WrkYear)
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      If ds3.Tables(0).Rows(I).Item("value") = 0 Then Continue For
      MyTXDCCD.GetOneRecordP(WrkYear, ds3.Tables(0).Rows(I).Item("CODE"), String.Empty)
      dr = Ds.Tables(0).NewRow
      dr("Filsts") = WrkFilsts
      dr("Status") = WrkStatus
      dr("ListNo") = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
      dr("Year") = WrkYear
      dr("OwName") = MyFrmTAP01C.TxtOwname.Text
      dr("dba") = MyFrmTAP01C.TxtDBA.Text
      dr("loc") = MyFrmTAP01C.TxtLAddr.Text
      dr("RptID") = "C"
      dr("Code") = ds3.Tables(0).Rows(I).Item("Code")
      dr("Ltr") = String.Empty
      dr("DeYear") = 0
      dr("Descr") = Trim(MyTXDCCD._DESC)
      dr("Cost") = ds3.Tables(0).Rows(I).Item("value")
      dr("Pct") = 0
      dr("Value") = ds3.Tables(0).Rows(I).Item("net")
      Ds.Tables(0).Rows.Add(dr)
    Next

    'Exemption Heading 
    dr = Ds.Tables(0).NewRow
    dr("RptID") = "D"
    Ds.Tables(0).Rows.Add(dr)

    'Exemption detail 
    ds4 = MyTXDCEXM.GetByList(MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text), WrkYear)
    For I = 0 To ds4.Tables(0).Rows.Count - 1
      MyTXDCEX.GetOneRecordP(WrkYear, ds4.Tables(0).Rows(I).Item("CODE"))
      dr = Ds.Tables(0).NewRow
      dr("Filsts") = WrkFilsts
      dr("Status") = WrkStatus
      dr("ListNo") = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
      dr("Year") = WrkYear
      dr("OwName") = MyFrmTAP01C.TxtOwname.Text
      dr("dba") = MyFrmTAP01C.TxtDBA.Text
      dr("loc") = Trim(MyFrmTAP01C.TxtLocNo.Text) & " " & MyFrmTAP01C.TxtLoc.Text
      dr("RptID") = "E"
      dr("Code") = 0
      dr("Ltr") = ds4.Tables(0).Rows(I).Item("Code")
      dr("DeYear") = 0
      dr("Descr") = Trim(MyTXDCEX._DESC)
      dr("Cost") = 0
      dr("Pct") = 0
      dr("Value") = ds4.Tables(0).Rows(I).Item("value")
      Ds.Tables(0).Rows.Add(dr)
    Next

    'Comments 
    If MyFrmTAP01C.ChkPrtcom.Checked Then
      WrkComment = GetComment()
    End If
    dr = Ds.Tables(0).NewRow
    dr("Filsts") = WrkFilsts
    dr("Status") = WrkStatus
    dr("ListNo") = MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text)
    dr("Year") = WrkYear
    dr("OwName") = MyFrmTAP01C.TxtOwname.Text
    dr("dba") = MyFrmTAP01C.TxtDBA.Text
    dr("loc") = Trim(MyFrmTAP01C.TxtLocNo.Text) & " " & MyFrmTAP01C.TxtLoc.Text
    dr("RptID") = "F"
    dr("Comment") = WrkComment
    Ds.Tables(0).Rows.Add(dr)
End Sub
Public Function GetComment()
  Dim ds As DataSet
  Dim I As Integer
  Dim WrkStr As String

  ds = MyTXDCCOM.Getcomments(MyUtils.CnvSng(MyFrmTAP01C.TxtListNo.Text), MyUtils.CnvSng(MyFrmTAP01C.LblYear.Text))
  WrkStr = ""
  For I = 0 To ds.Tables(0).Rows.Count - 1
    If Len(ds.Tables(0).Rows(I).Item("cmnt")) = 49 Then
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt") & " "
    Else
      WrkStr = WrkStr + ds.Tables(0).Rows(I).Item("cmnt")
    End If
  Next
  GetComment = Trim(WrkStr)
End Function

End Module






