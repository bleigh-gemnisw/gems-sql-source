Module PrintReport

Dim Ds As DataSet = New DataSet
Dim WrkRptID As String
Public Sub PrtReport()
    Dim MyCRViewer As FrmCrViewer
    If Ds.Tables.Count = 0 Then
      BuildDS()
    Else
      Ds.Clear()
    End If

    GetDetail()

    With MyFrmTAE01C
      If .RbTaxable.Checked Then
        WrkRptID = "T"
      End If
      If .RbNew.Checked Then
        WrkRptID = "N"
      End If
      If .RbEld.Checked Then
        WrkRptID = "E"
      End If
      If .RbVet.Checked Then
        WrkRptID = "V"
      End If
    End With


Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkds = Ds
  MyCRViewer.WrkRptID = WrkRptID
  MyCRViewer.ShowDialog()

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("PRDate", Type.GetType("System.String"))
      .Columns.Add("PRNo", Type.GetType("System.Int32"))
      .Columns.Add("MapLot", Type.GetType("System.String"))
      .Columns.Add("GranteeAddr1", Type.GetType("System.String"))
      .Columns.Add("GranteeAddr2", Type.GetType("System.String"))
      .Columns.Add("GranteeAddr3", Type.GetType("System.String"))
      .Columns.Add("GranteeAddr4", Type.GetType("System.String"))
      .Columns.Add("GranteeAddr5", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("AmtIncr", Type.GetType("System.Decimal"))
      .Columns.Add("AmtProrate", Type.GetType("System.Decimal"))
			.Columns.Add("AmtGross", Type.GetType("System.Decimal"))
			.Columns.Add("NewGross", Type.GetType("System.Decimal"))
      .Columns.Add("Days", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Decimal"))
      .Columns.Add("EffDate", Type.GetType("System.String"))
      .Columns.Add("E_RevLoss", Type.GetType("System.Decimal"))
      .Columns.Add("E_PctBefore", Type.GetType("System.Decimal"))
      .Columns.Add("E_PctAfter", Type.GetType("System.Decimal"))
      .Columns.Add("E_Pct", Type.GetType("System.Decimal"))
      .Columns.Add("E_Grantor", Type.GetType("System.Decimal"))
      .Columns.Add("E_AddlTax", Type.GetType("System.Decimal"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Assr", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim myTXREALC As TXREALC.MyData
    Dim dr As Data.DataRow
    Dim AddrLine() As String
    Dim WrkYear As Integer

    myTXREALC = New TXREALC.MyData(myDBConnect)

    With MyFrmTAE01C
      WrkYear = Year(.DtPckProrate.Value)
      If Month(.DtPckProrate.Value) < 10 Then
        WrkYear = WrkYear - 1
      End If
      dr = Ds.Tables(0).NewRow
      dr.Item("listno") = MyUtils.CnvSng(.TxtReListNo.Text)
      dr.Item("year") = WrkYear
      dr.Item("type") = "X"
      dr.Item("prdate") = Format(.DtPckProrate.Value.Date, "Short Date")
      dr.Item("prno") = MyUtils.CnvSng(.TxtListNo.Text)
      dr.Item("maplot") = .LblMap.Text
      dr.Item("location") = .LblLoc.Text
      '  If Trim(.LblREName.Text) = Trim(.TxtName.Text) And Trim(.LblRESname.Text) = Trim(.TxtSname.Text) Then
      If Trim(.TxtSname.Text) = String.Empty Then
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, String.Empty, .TxtAdd1.Text, .TxtAdd2.Text,
      .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text), MyUtils.CnvSng(.TxtZip4.Text))
      Else
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, .TxtAdd2.Text,
      .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text), MyUtils.CnvSng(.TxtZip4.Text))
      End If
      dr.Item("granteeaddr1") = AddrLine(0)
      dr.Item("granteeaddr2") = AddrLine(1)
      dr.Item("granteeaddr3") = AddrLine(2)
      dr.Item("granteeaddr4") = AddrLine(3)
      dr.Item("granteeaddr5") = AddrLine(4)
      dr.Item("amtincr") = MyUtils.CnvSng(.LblIncr.Text)
      dr.Item("newgross") = MyUtils.CnvSng(.LblIncr.Text)
      dr.Item("effdate") = Format(.DtPckProrate.Value, "Short Date")
      dr.Item("amtprorate") = MyUtils.CnvSng(.LblProrate.Text)
      dr.Item("days") = MyUtils.CnvSng(.LblDays.Text)
      dr.Item("pct") = MyUtils.CnvSng(.LblPct.Text) * 100
      If .RbEld.Checked Then
        dr.Item("e_revloss") = MyUtils.CnvSng(.LblProrate.Text)
        dr.Item("e_pctbefore") = MyUtils.CnvSng(.TxtBeforePct.Text)
        dr.Item("e_pctafter") = MyUtils.CnvSng(.TxtAfterPct.Text)
        dr.Item("e_pct") = MyUtils.CnvSng(.LblPct.Text)
        dr.Item("e_grantor") = MyUtils.CnvSng(.LblGrantor.Text)
        dr.Item("e_addltax") = MyUtils.CnvSng(.LblAddlTax.Text)
      End If
      AddrLine = MyUtils.SetAddrLine(.LblREName.Text, .LblRESname.Text, .LblREAdd1.Text, .LblREAdd2.Text,
    .LblRECity.Text, .LblREState.Text, MyUtils.CnvSng(.LblReZip5.Text), MyUtils.CnvSng(.LblREZip4.Text))
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("assr") = Trim(myTOWN._ASSR)

      myTXREALC.GetOneRecordP(MyUtils.CnvSng(.TxtReListNo.Text))
      If Not myTXREALC.RecordNotFound Then
        With myTXREALC
          If ._CCNO > 0 Then
            dr.Item("amtgross") = ._CCGRS
          Else
            dr.Item("amtgross") = ._GROSS + ._BTR
          End If
        End With
      Else
        dr.Item("amtgross") = 0
      End If
      dr.Item("newgross") = dr.Item("amtgross") + MyUtils.CnvSng(.LblIncr.Text)
      Ds.Tables(0).Rows.Add(dr)
    End With
  End Sub

End Module






