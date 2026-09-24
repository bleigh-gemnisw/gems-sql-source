Imports System.Text
Module ProcessData

  Dim myTXCNTL As TXCNTL.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim myDBUtils As DBUtils.Utils
  Dim ds As DataSet = New DataSet
  Public Sub ProcData()
    myDBUtils = New DBUtils.Utils(myDBConnect)
    myTXCNTL = New TXCNTL.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTAD03B.GrpFreeze.Visible = True

    UpdateTXCNTL()
    ProcRE()
    ProcPP()
    ProcMV()

    MyFrmTAD03B.LblMsg.Text = "Create Frozen BTR File"
    Application.DoEvents()
    MyFrmTAD03B.LblBTR.Visible = True
    myDBUtils.DeleteAllRecs("TXBTRC")
    myDBUtils.CopyData("TXBTR", "TXBTRC")
    myDBUtils.DeleteAllRecs("TXBTR")
    Windows.Forms.Cursor.Current = Cursors.Default
    MsgBox("Frozen File(s) have updated with BAA", MsgBoxStyle.Information, "Program Completed")
    MyFrmTAD03B.LblMsg.Text = "Done!"
    MyFrmTAD03B.GrpFreeze.Visible = False

  End Sub
  Private Sub UpdateTXCNTL()

    myTXCNTL.GetOneRecordP("")
    If myTXCNTL.RecordNotFound Then Exit Sub

    With myTXCNTL
      ._SFR = "N"
      ._SFP = "N"
      ._SFM = "N"
      .UpdateOneRecordP()
    End With

  End Sub
End Module






