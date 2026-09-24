Module PrintReport
Public Sub PrtReport()
		Dim WrkLocal As Boolean

		With MyFrmTAB02B
			WrkLocal = False
			If .ChkLocal.Checked Then
				WrkLocal = True
			End If
		End With

		If ds.Tables.Count = 0 Then
			BuildDS()
		Else
			ds.Clear()
		End If

		BufferExem(WrkLocal)
		With MyFrmTAB02B
			If .ChkRE.Checked Then PrtReportRE()
			If .ChkPP.Checked Then PrtReportPP()
			If .ChkMV.Checked Then PrtReportMV()
			If .ChkSU.Checked Then PrtReportSU()
		End With

		MyCrViewer = New FrmCrViewer
		With MyCrViewer
			.Wrkds = ds
			.WrkMillRt = MrateMillrt * 1000
			.Show()
		End With
End Sub

End Module






