Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXLOCAL As TXLOCAL.MyData
  Dim myTXM35PM As TXM35PM.MyData
  Dim myTXM35H As TXM35H.MyData
  Dim myTXREAL As TXREAL.MyData
  Dim myTXREALC As TXREALC.MyData

  Dim ds As DataSet = New DataSet
  Dim dsFile As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkYear As Integer
  Dim WrkCode As String
  Dim WrkPrevYr As Boolean
  Dim WrkPost As Boolean

  Public Sub PrtReport()
    myTXLOCAL = New TXLOCAL.MyData(myDBConnect)
    myTXM35PM = New TXM35PM.MyData(myDBConnect)
    myTXM35H = New TXM35H.MyData(myDBConnect)
    myTXREAL = New TXREAL.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)

    With MyFrmTAP29B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkCode = Trim(.TxtCode.Text)
      WrkPrevYr = .ChkPrevYr.Checked
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
    Dim ds2 As DataSet = New DataSet
    Dim WrkName As String
    Dim I As Integer

    dsFile = myTXLOCAL.PosData(0, "", "")
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
      With dsFile.Tables(0).Rows(I)
        If Trim(.Item("bencde")) <> WrkCode Then
          GoTo NextRec
        End If
        If WrkPrevYr Then
          ds2 = myTXM35PM.GetbyListAll(.Item("List#"), WrkYear - 1)
          If ds2.Tables(0).Rows.Count > 0 Then
            GoTo NextRec
          End If
        End If
        WrkName = ""
        myTXM35H.GetOneRecordP(.Item("List#"), WrkYear - 1, 0)
        If Not myTXM35H.RecordNotFound Then
          WrkName = Trim(myTXM35H._ALNAME) & " " & Trim(myTXM35H._AFNAME)
        Else
          myTXM35H.GetOneRecordP(.Item("List#"), WrkYear - 2, 0)
          If Not myTXM35H.RecordNotFound Then
            WrkName = Trim(myTXM35H._ALNAME) & " " & Trim(myTXM35H._AFNAME)
          End If
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("List#")
        dr.Item("name") = WrkName
        dr.Item("benefit") = .Item("Benamt")
        ds.Tables(0).Rows.Add(dr)
        If WrkPost Then
          UpdateRE(.Item("List#"))
          myTXLOCAL.GetOneRecordP(.Item("List#"), .Item("type"), WrkCode)
          myTXLOCAL.DeleteOneRecordP()
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    If WrkPost Then
      MsgBox("Local Benefit Amounts have been removed", MsgBoxStyle.Information, "Update has finished")
      MyFrmTAP29B.ChkPost.Checked = False
    End If
  End Sub
  Private Sub UpdateRE(ByVal List As Integer)

    With myTXREAL
      .GetOneRecordP(List)
      If Not .RecordNotFound Then
        ._TWNBN = 0
        .UpdateOneRecordP()
      End If
    End With

    With myTXREALC
      .GetOneRecordP(List)
      If Not .RecordNotFound Then
        ._TWNBN = 0
        .UpdateOneRecordP()
      End If
    End With
  End Sub
End Module
