Public Class FrmTAP01SUM
  Dim MyTXDCCD As TXDCCD.myData
  Dim MyTXDCEX As TXDCEX.myData
  Dim MyTXDCSUM As TXDCSUM.myData
  Dim MyTXDCEXM As TXDCEXM.myData
  Dim dsSUM As DataSet = New DataSet
  Dim dsEXM As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Private Sub FrmTAP01SUM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarDecl.Enabled = False
      .TBarSum.Enabled = True
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarPrint.Enabled = False
    End With
End Sub
Private Sub FrmTAP01SUM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCCD = New TXDCCD.mydata(MyDBConnect)
    MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
    MyTXDCEX = New TXDCEX.mydata(MyDBConnect)
    MyTXDCEXM = New TXDCEXM.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarDecl.Enabled = True
      .TBarSum.Enabled = False
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = True
			.TBarPrint.Enabled = True
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    BuildDSSUM(dsSUM)
    BuildDSEXM(dsEXM)

		BuildGridSUM(WrkYear)
    BuildGridEXM()
    CalcFinal()
    ShowGridSUM()
    ShowGridEXM()

End Sub
  Private Sub FrmTAP01SUM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01SUM"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub BuildDSSUM(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Code", Type.GetType("System.Int32"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Depr", Type.GetType("System.Int32"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSEXM(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("ExVal", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Sub BuildGridSUM(ByVal WrkYear As Integer)
		Dim ds2 As DataSet = New DataSet
		Dim myDr As Data.DataRow
		Dim WrkDeprValue As Integer
		Dim WrkAssrNet As Integer
		Dim WrkPenalty As Integer
		Dim I As Integer

		WrkDeprValue = 0
		WrkAssrNet = 0
		dsSUM.Clear()

		ds2 = MyTXDCCD.GetSummaryData(WrkYear)
		For I = 0 To ds2.Tables(0).Rows.Count - 1
			MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, ds2.Tables(0).Rows(I).Item("code"))
			With MyTXDCSUM
				myDr = dsSUM.Tables(0).NewRow
				myDr("Code") = ds2.Tables(0).Rows(I).Item("code")
				myDr("Desc") = ds2.Tables(0).Rows(I).Item("desc")
				If .RecordNotFound Then
					myDr("Depr") = 0
					myDr("Net") = 0
				Else
					myDr("Depr") = ._VALUE
					myDr("Net") = ._NET
					If ds2.Tables(0).Rows(I).Item("code") <> 25 Then
            WrkDeprValue = WrkDeprValue + ._VALUE
            If ._VALUE > 0 Then
              WrkAssrNet = WrkAssrNet + ._NET
            End If
          Else
            WrkPenalty = ._VALUE
          End If
        End If
				myDr("Pct") = ds2.Tables(0).Rows(I).Item("aspct")
				dsSUM.Tables(0).Rows.Add(myDr)
			End With
		Next

		LblSubDeprValue.Text = WrkDeprValue
		LblSubAssrNet.Text = WrkAssrNet
		LblPenalty.Text = WrkPenalty
End Sub
    Public Sub ShowGridSUM()
     Windows.Forms.Cursor.Current = Cursors.WaitCursor

     With C1DataGrdSum
      .DataSource = dsSUM.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Code"
      .Splits(0).DisplayColumns(0).Locked = True
      .Splits(0).DisplayColumns(0).Style.BackColor = cLightBlue
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Description"
      .Splits(0).DisplayColumns(1).Width = 200
      .Splits(0).DisplayColumns(1).Locked = True
      .Splits(0).DisplayColumns(1).Style.BackColor = cLightBlue
      .Columns(2).Caption = "Depr Value"
      .Splits(0).DisplayColumns(2).Width = 70
      .Columns(3).Caption = "Assr Net"
      .Splits(0).DisplayColumns(3).Locked = True
      .Splits(0).DisplayColumns(3).Style.BackColor = cLightBlue
      .Splits(0).DisplayColumns(3).Width = 70
      .Splits(0).DisplayColumns(4).Visible = False
     End With
     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
Sub BuildGridEXM()
    Dim ds2 As DataSet = New DataSet
    Dim myDr As Data.DataRow
    Dim WrkExam As Integer
    Dim I As Integer

    WrkExam = 0
    dsEXM.Clear()

    ds2 = MyTXDCEX.GetAllYear(WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      MyTXDCEXM.GetOneRecordP(WrkListNo, WrkYear, ds2.Tables(0).Rows(I).Item("code"))
      With MyTXDCEXM
        myDr = dsEXM.Tables(0).NewRow
        myDr("Code") = ds2.Tables(0).Rows(I).Item("code")
        myDr("Desc") = ds2.Tables(0).Rows(I).Item("desc")
        If .RecordNotFound Then
          myDr("Value") = 0
        Else
          myDr("Value") = ._VALUE
          WrkExam = WrkExam + ._VALUE
        End If
        myDr("ExVal") = ds2.Tables(0).Rows(I).Item("exval")
        dsEXM.Tables(0).Rows.Add(myDr)
      End With
    Next

    LblExam.Text = WrkExam
End Sub
    Public Sub ShowGridEXM()
     Windows.Forms.Cursor.Current = Cursors.WaitCursor

     With C1DataGrdExm
      .DataSource = dsEXM.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Code"
      .Splits(0).DisplayColumns(0).Width = 40
      .Splits(0).DisplayColumns(0).Locked = True
      .Splits(0).DisplayColumns(0).Style.BackColor = cLightBlue
      .Columns(1).Caption = "Description"
      .Splits(0).DisplayColumns(1).Width = 250
      .Splits(0).DisplayColumns(1).Locked = True
      .Splits(0).DisplayColumns(1).Style.BackColor = cLightBlue
      .Columns(2).Caption = "Exemption"
      .Splits(0).DisplayColumns(2).Width = 70
      .Splits(0).DisplayColumns(3).Visible = False
     End With
     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub
Public Sub CalcFinal()
  LblFinal.Text = MyUtils.CnvSng(LblSubAssrNet.Text) + MyUtils.CnvSng(LblPenalty.Text) - MyUtils.CnvSng(LblExam.Text)
  LblApplyPenalty.Text = RoundNumber(MyUtils.CnvSng(LblSubAssrNet.Text) * 0.25, 0)
End Sub
 Private Sub C1DataGrdSum_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles C1DataGrdSum.MouseClick
  CalcGridSummary()
  CalcFinal()
End Sub
Private Sub C1DataGrdSum_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DataGrdSum.AfterColEdit
  CalcGridSummary()
  CalcFinal()
End Sub
 Private Sub C1DataGrdExm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles C1DataGrdExm.MouseClick
  CalcGridExm()
  CalcFinal()
End Sub
Private Sub C1DataGrdExm_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles C1DataGrdExm.AfterColEdit
  CalcGridExm()
  CalcFinal()
End Sub
Private Sub CalcGridSummary()
  Dim WrkDeprValue As Long
  Dim WrkAssrNet As Long
  Dim WrkPenalty As Long
  Dim WrkTotDeprValue As Long
  Dim WrkTotAssrNet As Long
  Dim WrkTotPenalty As Long
  Dim WrkPct As Integer
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  WrkDeprValue = 0
  WrkAssrNet = 0
  WrkPenalty = 0
  For I = 0 To (C1DataGrdSum.Splits(0).Rows.Count - 1)
    WrkPct = MyUtils.CnvSng(C1DataGrdSum.Item(I, 4))
    If MyUtils.CnvSng(C1DataGrdSum.Item(I, 0)) = 25 Then
      If C1DataGrdSum.Item(I, 2) & "" = String.Empty Then
        WrkPenalty = 0
      Else
        WrkPenalty = MyUtils.CnvSng(C1DataGrdSum.Item(I, 2))
      End If
      WrkAssrNet = WrkPenalty
      WrkDeprValue = 0
    Else
      If C1DataGrdSum.Item(I, 2) & "" = String.Empty Then
        WrkDeprValue = 0
      Else
        WrkDeprValue = MyUtils.CnvSng(C1DataGrdSum.Item(I, 2))
      End If
      WrkAssrNet = MyUtils.Round(WrkDeprValue * (WrkPct / 100), 0)
      If MyDeclRound Then
        WrkAssrNet = RoundNumber(WrkAssrNet, "Normal")
      End If
      WrkTotAssrNet = WrkTotAssrNet + WrkAssrNet
    End If
    C1DataGrdSum.Item(I, 3) = WrkAssrNet
    WrkTotDeprValue = WrkTotDeprValue + WrkDeprValue
    WrkTotPenalty = WrkTotPenalty + WrkPenalty
  Next

  LblSubDeprValue.Text = WrkTotDeprValue
  LblSubAssrNet.Text = WrkTotAssrNet
  LblPenalty.Text = WrkTotPenalty
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Private Sub CalcGridExm()
  Dim WrkExam As Long
  Dim WrkTotExam As Long
  Dim I As Integer

  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  WrkTotExam = 0
  For I = 0 To (C1DataGrdExm.Splits(0).Rows.Count - 1)
    If C1DataGrdExm.Item(I, 2) & "" = String.Empty Then
      WrkExam = 0
    Else
      WrkExam = MyUtils.CnvSng(C1DataGrdExm.Item(I, 2))
    End If
    WrkTotExam = WrkTotExam + WrkExam
  Next

  LblExam.Text = WrkTotExam
  Windows.Forms.Cursor.Current = Cursors.Default
End Sub
Public Sub SaveData()
  SaveDataSum()
  SaveDataExm()
End Sub

Public Sub SaveDataSum()
    Dim WrkCode As Integer
    Dim WrkDeprValue As Long
    Dim WrkAssrNet As Long
    Dim I As Integer

    C1DataGrdSum.UpdateData()
    For I = 0 To (C1DataGrdSum.Splits(0).Rows.Count - 1)
      WrkCode = MyUtils.CnvSng(C1DataGrdSum.Item(I, 0))
      If C1DataGrdSum.Item(I, 2) & "" = String.Empty Then
        WrkDeprValue = 0
        WrkAssrNet = 0
      Else
        WrkDeprValue = MyUtils.CnvSng(C1DataGrdSum.Item(I, 2))
        WrkAssrNet = MyUtils.CnvSng(C1DataGrdSum.Item(I, 3))
      End If
      MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
      If Not MyTXDCSUM.RecordNotFound Then
        If WrkDeprValue = 0 Then
          MyTXDCSUM.DeleteOneRecordP()
        Else
          MoveToFileSum(WrkCode, WrkDeprValue, WrkAssrNet)
          MyTXDCSUM.UpdateOneRecordP()
        End If
      Else
        If WrkDeprValue > 0 Then
          MoveToFileSum(WrkCode, WrkDeprValue, WrkAssrNet)
          MyTXDCSUM.AddOneRecordP()
        End If
      End If
    Next
End Sub
 Private Sub MoveToFileSum(ByVal WrkCode As Integer, ByVal WrkDeprValue As Long, ByVal WrkAssrNet As Long)
   Dim WrkChanged As Boolean

    WrkChanged = False
    With MyTXDCSUM
      ._LISTNO = WrkListNo
      ._YEAR = WrkYear
      ._CODE = WrkCode
      If WrkDeprValue <> ._VALUE Then WrkChanged = True
      ._VALUE = WrkDeprValue
      ._NET = WrkAssrNet
      If WrkChanged Then
        ._STATUS = "K"
      End If
    End With
 End Sub
Public Sub SaveDataExm()
    Dim WrkCode As String
    Dim WrkExam As Long
    Dim I As Integer

    C1DataGrdExm.UpdateData()
    For I = 0 To (C1DataGrdExm.Splits(0).Rows.Count - 1)
      WrkCode = C1DataGrdExm.Item(I, 0)
      If C1DataGrdExm.Item(I, 2) & "" = String.Empty Then
        WrkExam = 0
      Else
        WrkExam = MyUtils.CnvSng(C1DataGrdExm.Item(I, 2))
      End If
      MyTXDCEXM.GetOneRecordP(WrkListNo, WrkYear, WrkCode)
      If Not MyTXDCEXM.RecordNotFound Then
        If WrkExam = 0 Then
          MyTXDCEXM.DeleteOneRecordP()
        Else
          MoveToFileExm(WrkCode, WrkExam)
          MyTXDCEXM.UpdateOneRecordP()
        End If
      Else
        If WrkExam > 0 Then
          MoveToFileExm(WrkCode, WrkExam)
          MyTXDCEXM.AddOneRecordP()
        End If
      End If
    Next
End Sub
 Private Sub MoveToFileExm(ByVal WrkCode As String, ByVal WrkExam As Long)
    With MyTXDCEXM
      ._LISTNO = WrkListNo
      ._YEAR = WrkYear
      ._CODE = WrkCode
      ._VALUE = WrkExam
      ._STATUS = "K"
    End With
 End Sub

Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles BtnApply.Click
  Dim I As Integer
  I = C1DataGrdSum.Splits(0).Rows.Count - 1
  C1DataGrdSum.Item(I, 2) = MyUtils.CnvSng(LblApplyPenalty.Text)
  C1DataGrdSum.UpdateData()
  CalcGridSummary()
  CalcFinal()
End Sub
End Class





