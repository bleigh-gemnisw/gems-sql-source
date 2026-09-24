Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALQ.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXLOCAL As TXLOCAL.MyData
  Dim myTXLOCCD As TXLOCCD.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkCode As String
  Dim WrkGLYear As Integer
  Dim WrkOldBenefit As Decimal
  Dim WrkNewBenefit As Decimal
  Dim WrkPost As Boolean

  Public Sub PrtReport()

    myTXREALCQ = New TXREALQ.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)
    myTXLOCCD = New TXLOCCD.MyData(myDBConnect)

    With MyFrmTA236B
      WrkCode = .TxtCode.Text
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkOldBenefit = MyUtils.CnvSng(.TxtOldBen.Text)
      WrkNewBenefit = MyUtils.CnvSng(.TxtNewBen.Text)
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkAdjBenefit As Decimal
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkSort = "LIST#"
    WrkQry = "TWNBN > 0"

    myTXREALCQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXREALCQ.ReadQry()
    If Not myTXREALCQ.IsEOF Then
      With myTXREALCQ
        Counter = Counter + 1
        myTXLOCAL.GetOneRecordP(._LISTNO, WrkGLYear, "R", WrkCode)
        If myTXLOCAL.RecordNotFound Then GoTo NextRec
        If WrkOldBenefit > 0 Then
          If myTXLOCAL._BENAMT <> WrkOldBenefit Then GoTo ReadNext
        End If
        WrkAdjBenefit = WrkNewBenefit - WrkOldBenefit
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNO
        dr.Item("name") = Trim(._NAME)
        dr.Item("oldben") = myTXLOCAL._BENAMT
        dr.Item("newben") = WrkNewBenefit
        ds.Tables(0).Rows.Add(dr)
        If WrkPost Then
          UpdateRE(._LISTNO, WrkNewBenefit)
          If Not myTXLOCAL.RecordNotFound Then
            With myTXLOCAL
              If WrkNewBenefit > 0 Then
                ._BENAMT = WrkNewBenefit
                .UpdateOneRecordP()
              Else
                .DeleteOneRecordP()
              End If
            End With
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
    myTXREALCQ.CloseFile()

    If WrkPost Then
      If WrkNewBenefit > 0 Then
        MsgBox("Local Benefit has been changed", MsgBoxStyle.Information, "Update has finished")
      Else
        MsgBox("Local Benefit has been removed", MsgBoxStyle.Information, "Update has finished")
      End If
      MyFrmTA236B.ChkPost.Checked = False
    End If
  End Sub
  Private Sub UpdateRE(ByVal List As Integer, ByVal WrkNewBenefit As Decimal)

    With myTXREAL
      .GetOneRecordP(List)
      If Not .RecordNotFound Then
        ._TWNBN = WrkNewBenefit
        .UpdateOneRecordP()
      End If
    End With

    With myTXREALC
      .GetOneRecordP(List)
      ._TWNBN = WrkNewBenefit
      .UpdateOneRecordP()
    End With
  End Sub
End Module






