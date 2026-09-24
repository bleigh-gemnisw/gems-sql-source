Imports System.Text
Module ProcessData

  Dim myDBUtils As DBUtils.Utils
  Dim ds As DataSet = New DataSet
  Public Sub ProcData()
    myDBUtils = New DBUtils.Utils(myDBConnect)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    MyFrmTAD01B.GrpFreeze.Visible = True
    Application.DoEvents()

    myDBUtils.DeleteAllRecs("TXREALC")
    myDBUtils.CopyData("TXREAL", "TXREALC")
    MyFrmTAD01B.LblRE.ForeColor = Color.Green
    MyFrmTAD01B.LblPP.Visible = True
    Application.DoEvents()
    myDBUtils.DeleteAllRecs("TXPPRPC")
    myDBUtils.CopyData("TXPPRP", "TXPPRPC")
    MyFrmTAD01B.LblPP.ForeColor = Color.Green
    MyFrmTAD01B.LblMV.Visible = True
    Application.DoEvents()
    myDBUtils.DeleteAllRecs("TXMVDC")
    myDBUtils.CopyData("TXMVD", "TXMVDC")
    MyFrmTAD01B.LblMV.ForeColor = Color.Green
    Application.DoEvents()

    ProcRE()
    ProcREFrozen()
    ProcPP()
    ProcMV()

    myDBUtils.DeleteAllRecs("TXCOO")
    myDBUtils.DeleteAllRecs("TXPROMS")
    MsgBox("File(s) have been Frozen", MsgBoxStyle.Information, "Program Completed")
    MyFrmTAD01B.LblMsg.Text = "Done!"
    MyFrmTAD01B.GrpFreeze.Visible = False

  End Sub
End Module






