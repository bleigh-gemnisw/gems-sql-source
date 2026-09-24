Imports System.Text
Module PrintReportMV

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim DsTXMVD As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFrozenFile As Boolean
  Dim WrkBTR As Boolean

  Public Sub PrtReportMV()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)

    With MyFrmTA235B
      WrkType = "M"
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
    End With

    ClearTotals()
    GetDetail()
  End Sub
  Private Sub ClearTotals()
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkTotBTR As Long
    Dim WrkNumMV As Long
    Dim WrkGrossMV As Long
    Dim WrkTotExam As Long
    Dim WrkExamMV As Long
    Dim WrkNetMV As Long
    Dim WrkNumMVx As Long
    Dim WrkGrossMVx As Long
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = ""
    WrkQry = "CAT <> '2'"
    If Not WrkDistAll Then
      WrkQry = WrkQry & " and dist=" & WrkDist
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing Motor Vehicle data..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If Not WrkFrozenFile Then
      DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXMVD = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
      With DsTXMVD.Tables(0).Rows(I)
        WrkTotBTR = 0
        If WrkBTR And .Item("btr") <> 0 Then
          If Not WrkFrozenFile Then
            myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTR.RecordNotFound Then
              With myTXBTR
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
              End With
            End If
          Else
            myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTRC.RecordNotFound Then
              With myTXBTRC
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
              End With
            End If
          End If
        End If

        WrkTotExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") +
       .Item("exam5")
        If .Item("cat") = "1" Then
          WrkNumMV = WrkNumMV + 1
          WrkGrossMV = WrkGrossMV + .Item("value") + WrkTotBTR
          WrkExamMV = WrkExamMV + WrkTotExam
          WrkNetMV = WrkNetMV + .Item("value") + WrkTotBTR - WrkTotExam
        Else
          WrkNumMVx = WrkNumMVx + 1
          WrkGrossMVx = WrkGrossMVx + .Item("value") + WrkTotBTR
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    With ds.Tables(0).Rows(0)
      .Item("numMV") = WrkNumMV
      .Item("num") = .Item("num") + WrkNumMV
      .Item("grossMV") = WrkGrossMV
      .Item("gross") = .Item("gross") + WrkGrossMV
      .Item("examMV") = WrkExamMV
      .Item("exam") = .Item("exam") + WrkExamMV
      .Item("netMV") = WrkNetMV
      .Item("net") = .Item("net") + WrkNetMV
      .Item("numMVx") = WrkNumMVx
      .Item("grossMVx") = WrkGrossMVx
    End With

    myFrmProgress.Close()
    Application.DoEvents()
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()

  End Sub
End Module






