Imports System.Text
Module ImportData

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXHST As TXHSTL1.myData

Dim ds As DataSet = New DataSet
'Buffered files
Dim WrkSupCode(25) As String
Dim WrkSupMonth(25) As String
Dim WrkSupPct(25) As Decimal
Public Sub Impdata()
Dim Good As Boolean

MyDBName = MyFrmFixB.TxtDBName.Text
Good = Connect()

If Not Good Then Exit Sub

myTXINVQ = New TXINVQ.myData(myDBConnect.pgmDB)
myTXHST = New TXHSTL1.myData(myDBConnect.pgmDB)

GetDetail()
MyFrmFix.Close()

End Sub
Public Function Connect() As Boolean
  Dim Good As Boolean

  myDBConnect = New DBConnect.DBConnection
  myDBConnect.pgmDB.DBName = MyDBName
  Good = myDBConnect.Connect()
  If Not Good Then
    MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
  End If

  MyAS400 = myDBConnect.ServerAS400
  Return Good
End Function
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer

WrkQry = "SUSDT=20140530"
WrkSort = ""
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ds = myTXINVQ.GetQry(WrkSort, WrkQry, 0)
For I = 0 To (ds.Tables(0).Rows.Count - 1)
  With ds.Tables(0).Rows(I)
    updatefile(I)
  End With

nextrecord:
With myFrmProgress
  WrkPct = ((I + 1) / ds.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()

End Sub
Private Sub updatefile(ByVal I As Integer)

  With myTXHST
    ._LISTNO = ds.Tables(0).Rows(I).Item("list#")
    ._TYPE = ds.Tables(0).Rows(I).Item("type")
    ._YEAR = ds.Tables(0).Rows(I).Item("year")
    ._BATCHA = "S"
    ._RCODE = "I"
    ._PCAMT = ds.Tables(0).Rows(I).Item("bald")
    ._PDATE = 20140530
    ._CDATE = 20140530
    ._CHDATE = 20140530
    ._PRF = "Add Susp"
    .AddOneRecordP()
  End With
End Sub
End Module
