Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Module RecalcBen

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXLOCAL As TXLOCAL.MyData
  Public Sub Recalc()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)

    GetDetail()

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkGLYear As Integer
    Dim WrkBenefit As Decimal
    Dim I As Integer
    Dim Counter As Integer
    Dim Answer As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Answer = MsgBox("Local Benefits totals will be recalculated for BOTH Real Estate " &
  "(Current & Frozen) files. Please note that Screen options will be ignored." & vbCrLf & vbCrLf & "OK to continue?", MsgBoxStyle.OkCancel, "Recalc Local Benefits")
    If Answer = MsgBoxResult.Cancel Then Exit Sub

    With MyFrmTA236B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    End With

    Counter = 0
    WrkSort = "LIST#"
    WrkQry = "TWNBN > 0"

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
        WrkBenefit = 0
        ds = myTXLOCAL.GetViewbyList(._LISTNO, WrkGLYear, "R", 100)
        ds2 = myTXLOCAL.GetViewbyList(._LISTNO, WrkGLYear - 1, "R", 100)
        ds.Merge(ds2)
        For I = 0 To ds.Tables(0).Rows.Count - 1
          WrkBenefit = WrkBenefit + ds.Tables(0).Rows(I).Item("benamt")
        Next
        UpdateRE(._LISTNO, WrkBenefit)
        ds2.Clear()
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

    MsgBox("Local Benefits", MsgBoxStyle.Information, "Recalc has finished")
    MyFrmTA236B.ChkPost.Checked = False
  End Sub
  Private Sub UpdateRE(ByVal List As Integer, ByVal WrkBenefit As Decimal)

 With myTXREAL
  .GetOneRecordP(List)
  If Not .RecordNotFound Then
   ._TWNBN = WrkBenefit
   .UpdateOneRecordP()
  End If
 End With

 With myTXREALC
  .GetOneRecordP(List)
  If Not .RecordNotFound Then
    ._TWNBN = WrkBenefit
    .UpdateOneRecordP()
  End If
 End With
End Sub
End Module






