Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.myData
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXBTR As TXBTR.myData
Dim myTXBTRC As TXBTRC.myData
Dim myTXPHIN As TXPHIN.myData
Dim DsTXREAL As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkBTR As Boolean
Dim WrkPrintDist As Boolean
  Public Sub PrtReportRE()

  myTXREALQ = New TXREALQ.mydata(MyDBConnect)
  myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
  myTXBTR = New TXBTR.mydata(MyDBConnect)
  myTXBTRC = New TXBTRC.mydata(MyDBConnect)
  myTXPHIN = New TXPHIN.mydata(MyDBConnect)

  With MyFrmTA235B
    WrkType = "R"
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
Dim WrkFullGross As Long
Dim WrkNumRE As Long
Dim WrkNumREFrz As Long
Dim WrkNumRESt As Long
Dim WrkNumREx As Long
Dim WrkGrossRE As Long
Dim WrkGrossREFrz As Long
Dim WrkGrossRESt As Long
Dim WrkGrossREx As Long
Dim WrkTotExam As Long
Dim WrkExamRE As Long
Dim WrkExamREFrz As Long
Dim WrkExamRESt As Long
Dim WrkNetRE As Long
Dim WrkNetREFrz As Long
Dim WrkNetRESt As Long
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
If Not WrkFrozenFile Then
  DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Real Estate data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
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

    'PhaseIn
    If MyPhaseIn Then
          myTXPHIN.GetOneRecordP(.Item("list#"), WrkYear)
          With myTXPHIN
        If Not .RecordNotFound Then
          WrkFullGross = ._FULGRS
        End If
      End With
      'myTXREALC.GetOneRecordP(.Item("list#"))
      'With myTXREALC
      '	If Not .RecordNotFound Then
      '		WrkTotExPhaseIn = WrkTotExPhaseIn + (WrkFullGross - ._GROSS)
      '	End If
      'End With
    End If
    WrkTotExam = .Item("exam1") + .Item("exam2") + .Item("exam3") + .Item("exam4") + _
       .Item("exam5") + .Item("exam6") + .Item("exam7")
    If .Item("cat") = "1" Then
      Select Case .Item("fccod")
      Case "C"
        WrkNumRESt = WrkNumRESt + 1
        WrkGrossRESt = WrkGrossRESt + .Item("gross") + WrkTotBTR
        WrkExamRESt = WrkExamRESt + WrkTotExam
        WrkNetRESt = WrkNetRESt + .Item("net") + WrkTotBTR
      Case "F"
        WrkNumREFrz = WrkNumREFrz + 1
        WrkGrossREFrz = WrkGrossREFrz + .Item("gross") + WrkTotBTR
        WrkExamREFrz = WrkExamREFrz + WrkTotExam
        WrkNetREFrz = WrkNetREFrz + .Item("net") + WrkTotBTR
      Case Else
        WrkNumRE = WrkNumRE + 1
        WrkGrossRE = WrkGrossRE + .Item("gross") + WrkTotBTR
        WrkExamRE = WrkExamRE + WrkTotExam
        WrkNetRE = WrkNetRE + .Item("net") + WrkTotBTR
      End Select
    Else
      WrkNumREx = WrkNumREx + 1
      WrkGrossREx = WrkGrossREx + .Item("gross") + WrkTotBTR
    End If
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

dr = ds.Tables(0).NewRow
dr.Item("numre") = WrkNumRE
dr.Item("numrefrz") = WrkNumREFrz
dr.Item("numrest") = WrkNumRESt
dr.Item("numretot") = WrkNumRE + WrkNumREFrz + WrkNumRESt
dr.Item("numrex") = WrkNumREx
dr.Item("num") = WrkNumRE + WrkNumREFrz + WrkNumRESt
dr.Item("grossre") = WrkGrossRE
dr.Item("grossrefrz") = WrkGrossREFrz
dr.Item("grossrest") = WrkGrossRESt
dr.Item("grossretot") = WrkGrossRE + WrkGrossREFrz + WrkGrossRESt
dr.Item("grossrex") = WrkGrossREx
dr.Item("gross") = WrkGrossRE + WrkGrossREFrz + WrkGrossRESt
dr.Item("examre") = WrkExamRE
dr.Item("examrefrz") = WrkExamREFrz
dr.Item("examrest") = WrkExamRESt
dr.Item("examretot") = WrkExamRE + WrkExamREFrz + WrkExamRESt
dr.Item("exam") = WrkExamRE + WrkExamREFrz + WrkExamRESt
dr.Item("netre") = WrkNetRE
dr.Item("netrefrz") = WrkNetREFrz
dr.Item("netrest") = WrkNetRESt
dr.Item("netretot") = WrkNetRE + WrkNetREFrz + WrkNetRESt
dr.Item("net") = WrkNetRE + WrkNetREFrz + WrkNetRESt
ds.Tables(0).Rows.Add(dr)

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
End Module






