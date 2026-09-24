Imports System.Text
Module PrintReportPP

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXPPRPCQ As TXPPRPCQ.myData
Dim myTXBTR As TXBTR.myData
Dim myTXBTRC As TXBTRC.myData
Dim DsTXPPRP As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkBTR As Boolean
  Public Sub PrtReportPP()

  myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
  myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)
  myTXBTR = New TXBTR.mydata(MyDBConnect)
  myTXBTRC = New TXBTRC.mydata(MyDBConnect)

  With MyFrmTA235B
    WrkType = "P"
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

  GetDetail()

  End Sub
Private Sub ClearTotals()
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkTotBTR As Long
Dim WrkNumPP As Long
Dim WrkGrossPP As Long
Dim WrkTotExam As Long
Dim WrkExamPP As Long
Dim WrkNetPP As Long
Dim WrkNumPPx As Long
Dim WrkGrossPPx As Long
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Personal property data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If Not WrkFrozenFile Then
  DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  WrkTotBTR = 0
  With DsTXPPRP.Tables(0).Rows(I)
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

    WrkTotExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") + _
       .Item("exam5")
    If .Item("cat") = "5" Then
      WrkNumPP = WrkNumPP + 1
      WrkGrossPP = WrkGrossPP + .Item("gross") + WrkTotBTR
      WrkExamPP = WrkExamPP + WrkTotExam
      WrkNetPP = WrkNetPP + .Item("net") + WrkTotBTR
    Else
      WrkNumPPx = WrkNumPPx + 1
      WrkGrossPPx = WrkGrossPPx + .Item("gross") + WrkTotBTR
    End If
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

With ds.tables(0).rows(0)
  .Item("numpp") = WrkNumPP
  .Item("num") = .Item("num") + WrkNumPP
  .Item("grosspp") = WrkGrossPP
  .Item("gross") = .item("gross") + WrkGrossPP
  .Item("exampp") = WrkExamPP
  .Item("exam") = .item("exam") + WrkExamPP
  .Item("netpp") = WrkNetPP
  .Item("net") = .item("net") + WrkNetPP
  .Item("numPPx") = WrkNumPPx
  .Item("grossPPx") = WrkGrossPPx
End With

myFrmProgress.Close()
Application.DoEvents()
myTXPPRPQ.CloseFile()
myTXPPRPCQ.CloseFile()

End Sub

End Module






