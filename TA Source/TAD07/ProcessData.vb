Imports System.Text
Module ProcessData

  Dim myDBUtils As DBUtils.Utils
  Dim ds As DataSet = New DataSet
  Public Sub ProcData()
    myDBUtils = New DBUtils.Utils(myDBConnect)
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Application.DoEvents()

    Application.DoEvents()
    myDBUtils.DeleteAllRecs("TXSUPPC")
    myDBUtils.CopyData("TXSUPP", "TXSUPPC")
    Application.DoEvents()

    MsgBox("File has been Frozen", MsgBoxStyle.Information, "Program Completed")
    MyFrmTAD07B.LblMsg.Text = "Done!"
  End Sub
End Module






