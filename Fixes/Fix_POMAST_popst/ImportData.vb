Imports System.Text
Imports System.Text.RegularExpressions
Module ImportData

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myPOMASTQ As POMASTQ.MyData
Dim myPOMAST As POMAST.MyData
Public Sub Impdata()

MyDBName = MyFrmFixB.TxtDBName.Text
myDBConnect = New SQLConnect.DBConnection(MyDBName)
myDBConnect.Open()
myDBConnect2 = New SQLConnect.DBConnection(MyDBName)
myDBConnect2.Open()

myPOMASTQ = New POMASTQ.MyData()
myPOMASTQ.MyDBConn = myDBConnect
myPOMAST = New POMAST.MyData()
myPOMAST.MyDBConn = myDBConnect2

GetDetail()
End Sub

  'Private Sub BuildDS()
  '  Dim myTable As New DataTable
  '  With myTable
  '    .TableName = "mytable"
  '    .Columns.Add("Batch", Type.GetType("System.Int32"))
  '  End With
  '  ds.Tables.Add(myTable)

  'End Sub
Private Sub GetDetail()

Dim ds As DataSet = New DataSet
Dim WrkAnd As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
WrkAnd = " and "

With MyFrmFixB
End With

WrkQry = "POPST=0 and RENTD>0"
WrkSort = ""
myPOMASTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myPOMASTQ.ReadQry()
  If Not myPOMASTQ.IsEOF Then
  With myPOMASTQ
    Counter = Counter + 1
    myPOMAST.GetOneRecordP(._FSCYR, ._PONBR, ._POSUF, ._POSEQ, ._RSQDG)
    myPOMAST._POPST = Mid(._RENTD, 5, 4) & Mid(._RENTD, 1, 4)
    myPOMAST.UpdateOneRecordP()
  End With

NextRec:
    With myFrmProgress
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .LblMsg.Text = "Records processed: " & Counter
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo ReadNext
 End If

myFrmProgress.Close()
End Sub
End Module
