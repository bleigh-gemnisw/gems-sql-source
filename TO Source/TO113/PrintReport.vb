Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXBTR As TXBTR.MyData
Dim myTXREAL As TXREAL.MyData
Dim myTXPPRP As TXPPRP.MyData
Dim myTXMVD As TXMVD.MyData
Dim myTXBTRC As TXBTRC.myData
Dim myTXREALC As TXREALC.myData
Dim myTXPPRPC As TXPPRPC.myData
Dim myTXMVDC As TXMVDC.myData
Dim DsTXBTR As DataSet = New DataSet
Dim dsRE As DataSet = New DataSet
Dim dsPP As DataSet = New DataSet
Dim dsMV As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkYear As Integer
Dim WrkFrozenFile As Boolean

	Public Sub PrtReport()

	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXREAL = New TXREAL.mydata(MyDBConnect)
	myTXPPRP = New TXPPRP.mydata(MyDBConnect)
	myTXMVD = New TXMVD.mydata(MyDBConnect)
  myTXBTRC = New TXBTRC.mydata(MyDBConnect)
  myTXREALC = New TXREALC.mydata(MyDBConnect)
  myTXPPRPC = New TXPPRPC.mydata(MyDBConnect)
  myTXMVDC = New TXMVDC.mydata(MyDBConnect)

	With MyFrmTO113B
		WrkYear = .TxtGLYear.Text
    WrkFrozenFile = .ChkFrozenFile.Checked
  End With

	If dsRE.Tables.Count = 0 Then
		BuildDS(dsRE, dsPP, dsMV)
	Else
		dsRE.Clear()
		dsPP.Clear()
		dsMV.Clear()
	End If

	GetDetail()

	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.wrkdsRE = dsRE
		.wrkdsPP = dsPP
		.wrkdsMV = dsMV
		.Show()
	End With
	End Sub
Private Sub GetDetail()
Dim I As Integer
Dim WrkType As String
Dim WrkName As String
Dim WrkGross As Integer
Dim WrkBTR As Decimal
Dim WrkTotBTR As Integer

If WrkFrozenFile Then
  DsTXBTR = myTXBTRC.PosData(0, "")
Else
  DsTXBTR = myTXBTR.PosData(0, "")
End If
If DsTXBTR.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXBTR.Tables(0).Rows.Count - 1)
  With DsTXBTR.Tables(0).Rows(I)
    WrkTotBTR = .Item("bass1") + .Item("bass2") + .Item("bass3") + .Item("bass4") + _
       .Item("bass5") + .Item("bass6") + .Item("bass7")
    WrkType = .Item("type")
    WrkName = String.Empty
    WrkGross = 0
    WrkBTR = 0
    Select Case WrkType
    Case "R"
      dr = dsRE.Tables(0).NewRow
      If WrkFrozenFile Then
        myTXREALC.GetOneRecordP(.Item("list#"))
        If Not myTXREALC.RecordNotFound Then
          With myTXREALC
            WrkName = Trim(._NAME)
            WrkGross = ._GROSS
            WrkBTR = ._BTR
          End With
        End If
      Else
        myTXREAL.GetOneRecordP(.Item("list#"))
        If Not myTXREAL.RecordNotFound Then
          With myTXREAL
            WrkName = Trim(._NAME)
            WrkGross = ._GROSS
            WrkBTR = ._BTR
          End With
        End If
      End If
    Case "P"
      dr = dsPP.Tables(0).NewRow
      If WrkFrozenFile Then
        myTXPPRPC.GetOneRecordP(.Item("list#"))
        If Not myTXPPRPC.RecordNotFound Then
          With myTXPPRPC
            WrkName = Trim(._NAME)
            WrkGross = ._GROSS
            WrkBTR = ._BTR
          End With
        End If
      Else
        myTXPPRP.GetOneRecordP(.Item("list#"))
        If Not myTXPPRP.RecordNotFound Then
          With myTXPPRP
            WrkName = Trim(._NAME)
            WrkGross = ._GROSS
            WrkBTR = ._BTR
          End With
        End If
      End If
    Case "M"
      dr = dsMV.Tables(0).NewRow
      If WrkFrozenFile Then
        myTXMVDC.GetOneRecordP(.Item("list#"))
        If Not myTXMVDC.RecordNotFound Then
          With myTXMVDC
            WrkName = Trim(._NAME)
            WrkGross = ._VALUE
            WrkBTR = ._BTR
          End With
        End If
      Else
        myTXMVD.GetOneRecordP(.Item("list#"))
        If Not myTXMVD.RecordNotFound Then
          With myTXMVD
            WrkName = Trim(._NAME)
            WrkGross = ._VALUE
            WrkBTR = ._BTR
          End With
        End If
      End If
    Case Else
      dr = dsRE.Tables(0).NewRow
      WrkName = "*** unknown tax type ***'"
      WrkGross = 0
      WrkBTR = 0
    End Select
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = WrkName
    dr.Item("gross") = WrkGross
    dr.Item("totbtr") = WrkTotBTR
    dr.Item("newgross") = WrkGross + WrkTotBTR
    dr.Item("errmsg") = ""
    If WrkBTR <> WrkTotBTR Then
      dr.Item("errmsg") = "*** Detail BTR = " & WrkBTR & " ***"
    End If
    Select Case WrkType
    Case "R"
      dsRE.Tables(0).Rows.Add(dr)
    Case "P"
      dsPP.Tables(0).Rows.Add(dr)
    Case "M"
      dsMV.Tables(0).Rows.Add(dr)
    End Select
    dr = Nothing
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXBTR.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
Application.DoEvents()

End Sub
End Module






