Imports System.io
Imports System.Text
Module ProcessFile

  Dim myTXTRANSQ As TXTRANSQ.MyData
  Dim myDBUTILS As DBUtils.Utils

  Dim DsTXTRANS As DataSet = New DataSet

  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub ProcFile()
    myTXTRANSQ = New TXTRANSQ.MyData(myDBConnect)
    myDBUTILS = New DBUtils.Utils(myDBConnect)

    GetDetail()

    myDBUTILS.DeleteAllRecs("TXTRANS")
    MsgBox("Transfer file has been cleared", MsgBoxStyle.Information, "Processing completed")
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String

    WrkQry = ""
    WrkSort = ""

    DsTXTRANS = myTXTRANSQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXTRANS.Tables(0).Rows.Count = 0 Then Exit Sub

    ExportFile(DsTXTRANS, MyFrmTA221B.LblFile.Text, True)

    myTXTRANSQ.CloseFile()

  End Sub
End Module






