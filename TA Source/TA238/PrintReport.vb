Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREAL As TXREAL.myData

Dim ds As DataSet = New DataSet
Dim DsTXREAL As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen fields
Dim WrkPenCode As String
Dim WrkPenAmount As Integer
Dim WrkPenPct As Decimal
Dim WrkPost As Boolean
'File
Dim WrkAss(6) As Integer
Dim WrkCode(6) As Integer
Dim WrkUnit(6) As Integer

  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREAL = New TXREAL.mydata(MyDBConnect)

  With MyFrmTA238B
    WrkPenCode = .TxtPenCode.Text
    WrkPenAmount = MyUtils.CnvSng(.TxtPenAmount.Text)
    WrkPenPct = MyUtils.CnvSng(.TxtPenPct.Text) / 100
    If .ChkPost.Checked Then WrkPost = True
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.WrkPencode = WrkPenCode
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("PenAmount", Type.GetType("System.Decimal"))
      .Columns.Add("Error", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkNoPenNet As Integer
Dim WrkAmount As Integer

Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim J As Integer
Dim WrkAnd As String
Dim Good As Boolean

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "NAME"
WrkQry = ""
myTXREALQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXREALQ.ReadQry()
  If Not myTXREALQ.IsEOF Then
  With myTXREALQ
    Counter = Counter + 1
    WrkAss(0) = ._ASS1
    WrkAss(1) = ._ASS2
    WrkAss(2) = ._ASS3
    WrkAss(3) = ._ASS4
    WrkAss(4) = ._ASS5
    WrkAss(5) = ._ASS6
    WrkAss(6) = ._ASS7
    WrkCode(0) = ._CODE1
    WrkCode(1) = ._CODE2
    WrkCode(2) = ._CODE3
    WrkCode(3) = ._CODE4
    WrkCode(4) = ._CODE5
    WrkCode(5) = ._CODE6
    WrkCode(6) = ._CODE7
    WrkUnit(0) = ._UNIT1
    WrkUnit(1) = ._UNIT2
    WrkUnit(2) = ._UNIT3
    WrkUnit(3) = ._UNIT4
    WrkUnit(4) = ._UNIT5
    WrkUnit(5) = ._UNIT6
    WrkUnit(6) = ._UNIT7

    WrkNoPenNet = 0
    'Add Net without penalty amount
    For J = 0 To 6
      If WrkCode(J) <> WrkPenCode Then
        WrkNoPenNet = WrkNoPenNet + WrkAss(J)
      End If
    Next
    WrkNoPenNet = WrkNoPenNet - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
    If WrkPenAmount > 0 Then
      WrkAmount = WrkPenAmount
    Else
      WrkAmount = MyUtils.Round(WrkNoPenNet * WrkPenPct, 0)
    End If

    Good = False
    'Update penalty code bucket 
    For J = 0 To 6
      If WrkCode(J) = WrkPenCode Then
        WrkAss(J) = WrkAmount
        Good = True
        Exit For
      End If
    Next

    If Good Then
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNO
      dr.Item("name") = ._NAME
      dr.Item("proploc") = Trim(._LOCNO) & " " & ._LOC
      dr.Item("penamount") = WrkAmount
      dr.Item("error") = ""
      ds.Tables(0).Rows.Add(dr)

      If WrkPost Then
        UpdateTXREAL(._LISTNO)
      End If
    End If
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
myTXREALQ.CloseFile()
myTXREAL.CloseFile()

End Sub
Private Sub UpdateTXREAL(ByVal List As Integer)
	myTXREAL.GetOneRecordP(List)
	If Not myTXREAL.RecordNotFound Then
		With myTXREAL
		 ._ASS1 = WrkAss(0)
		 ._ASS2 = WrkAss(1)
		 ._ASS3 = WrkAss(2)
		 ._ASS4 = WrkAss(3)
		 ._ASS5 = WrkAss(4)
		 ._ASS6 = WrkAss(5)
		 ._ASS7 = WrkAss(6)
     ._GROSS = WrkAss(0) + WrkAss(1) + WrkAss(2) + WrkAss(3) + WrkAss(4) + WrkAss(5) + WrkAss(6)
     ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
     ._CODE1 = WrkCode(0)
		 ._CODE2 = WrkCode(1)
		 ._CODE3 = WrkCode(2)
		 ._CODE4 = WrkCode(3)
		 ._CODE5 = WrkCode(4)
		 ._CODE6 = WrkCode(5)
		 ._CODE7 = WrkCode(6)
     ._UNIT1 = WrkUnit(0)
		 ._UNIT2 = WrkUnit(1)
		 ._UNIT3 = WrkUnit(2)
		 ._UNIT4 = WrkUnit(3)
		 ._UNIT5 = WrkUnit(4)
		 ._UNIT6 = WrkUnit(5)
		 ._UNIT7 = WrkUnit(6)
    End With
		myTXREAL.UpdateOneRecordP()
	End If
End Sub
End Module






