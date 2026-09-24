Public Class FrmTAP02SUM
  Dim MyTXDMCD As TXDMCD.myData
  Dim MyTXDMDEP As TXDMDEP.myData
  Dim MyTXDMSUM As TXDMSUM.myData
  Dim ds As DataSet = New DataSet
	Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkName As String
  Private Sub FrmTAP02SUM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP02
      .TBarDecl.Enabled = False
      .TBarSum.Enabled = True
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarPrint.Enabled = False
    End With
End Sub
Private Sub FrmTAP02SUM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDMCD = New TXDMCD.mydata(MyDBConnect)
    MyTXDMDEP = New TXDMDEP.mydata(MyDBConnect)
    MyTXDMSUM = New TXDMSUM.mydata(MyDBConnect)

    With MyFrmTAP02
      .TBarDecl.Enabled = True
      .TBarSum.Enabled = False
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarPrint.Enabled = True
    End With

    LblListNo.Text = WrkListNo
		LblYear.Text = WrkYear
		LblName.Text = WrkName

    BuildDS(ds)
    BuildGrid()
    ShowGrid()

End Sub
  Private Sub FrmTAP02SUM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "TAP02SUM"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Qty", Type.GetType("System.Int32"))
      .Columns.Add("DeCost", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Int32"))
      .Columns.Add("DeNet", Type.GetType("System.Int32"))
      .Columns.Add("AsCost", Type.GetType("System.Int32"))
      .Columns.Add("AsNet", Type.GetType("System.Int32"))
			.Columns.Add("YearNo", Type.GetType("System.Int32"))
		End With
    ds.Tables.Add(myTable)
  End Sub
Sub BuildGrid()
    Dim ds2 As DataSet = New DataSet
		Dim ds3 As DataSet = New DataSet
		Dim myDr As Data.DataRow
		Dim WrkOrigCost As Integer
		Dim WrkDeprNet As Integer
    Dim WrkAssrNet As Integer
		Dim SaveYearNo As Integer
		Dim I As Integer
		Dim J As Integer

		WrkOrigCost = 0
    WrkDeprNet = 0
		WrkAssrNet = 0
		SaveYearNo = 0
    ds.Clear()

		ds2 = MyTXDMDEP.GetAllYear(WrkYear)
		For I = 0 To ds2.Tables(0).Rows.Count - 1
			MyTXDMSUM.GetOneRecordP(WrkListNo, WrkYear, I + 1)
			myDr = ds.Tables(0).NewRow
			myDr("Year") = WrkYear - I
			If MyTXDMSUM.RecordNotFound Then
				myDr("Qty") = 0
				myDr("DeCost") = 0
				myDr("DeNet") = 0
				myDr("AsCost") = 0
				myDr("AsNet") = 0
			Else
				With MyTXDMSUM
					myDr("Qty") = ._QTY
					myDr("DeCost") = ._DECOST
					myDr("DeNet") = ._DENET
					myDr("AsCost") = ._ASCOST
					myDr("AsNet") = ._ASNET
					WrkOrigCost = WrkOrigCost + ._DECOST
					WrkDeprNet = WrkDeprNet + ._DENET
					WrkAssrNet = WrkAssrNet + ._ASNET
				End With
			End If
			myDr("Pct") = ds2.Tables(0).Rows(I).Item("pct")
			myDr("YearNo") = ds2.Tables(0).Rows(I).Item("yearno")
			SaveYearNo = ds2.Tables(0).Rows(I).Item("yearno")
			ds.Tables(0).Rows.Add(myDr)
		Next

		'Add all previous years to bottom row
		ds3 = MyTXDMSUM.GetByList(WrkListNo, WrkYear)
		For J = 0 To ds3.Tables(0).Rows.Count - 1
			If ds3.Tables(0).Rows(J).Item("deyear") <= SaveYearNo Then
				Continue For
			End If
			ds.Tables(0).Rows(I - 1).Item("Qty") = ds.Tables(0).Rows(I - 1).Item("Qty") + ds3.Tables(0).Rows(J).Item("Qty")
			ds.Tables(0).Rows(I - 1).Item("DeCost") = ds.Tables(0).Rows(I - 1).Item("DeCost") + ds3.Tables(0).Rows(J).Item("DeCost")
			ds.Tables(0).Rows(I - 1).Item("DeNet") = ds.Tables(0).Rows(I - 1).Item("DeNet") + ds3.Tables(0).Rows(J).Item("DeNet")
			ds.Tables(0).Rows(I - 1).Item("AsCost") = ds.Tables(0).Rows(I - 1).Item("AsCost") + ds3.Tables(0).Rows(J).Item("AsCost")
			ds.Tables(0).Rows(I - 1).Item("AsNet") = ds.Tables(0).Rows(I - 1).Item("AsNet") + ds3.Tables(0).Rows(J).Item("AsNet")
			WrkOrigCost = WrkOrigCost + ds3.Tables(0).Rows(J).Item("DeCost")
			WrkDeprNet = WrkDeprNet + ds3.Tables(0).Rows(J).Item("DeNet")
			WrkAssrNet = WrkAssrNet + ds3.Tables(0).Rows(J).Item("AsNet")
		Next

		LblOrigCost.Text = WrkOrigCost
		LblDeprNet.Text = WrkDeprNet
    LblAssrNet.Text = WrkAssrNet
End Sub
    Public Sub ShowGrid()
     Windows.Forms.Cursor.Current = Cursors.WaitCursor

     With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Year"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Qty"
      .Splits(0).DisplayColumns(1).Width = 50
      .Columns(2).Caption = "Orig Cost"
      .Splits(0).DisplayColumns(2).Width = 70
      .Columns(3).Caption = "Pct"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Net Depr"
      .Splits(0).DisplayColumns(4).Width = 70
      .Columns(5).Caption = "Assr Cost"
      .Splits(0).DisplayColumns(5).Width = 70
      .Columns(6).Caption = "Assr Depr"
      .Splits(0).DisplayColumns(6).Width = 70
     End With
     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

Private Sub LblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblName.Click

End Sub
End Class





