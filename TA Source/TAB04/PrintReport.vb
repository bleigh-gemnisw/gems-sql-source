Module PrintReport
Public Sub PrtReport()
    With MyFrmTAB04B
    End With

    If ds.Tables.Count = 0 Then
			BuildDS()
		Else
			ds.Clear()
		End If

    BufferExem()
    With MyFrmTAB04B
      If .ChkRE.Checked Then PrtReportRE()
      '      If .ChkPP.Checked Then PrtReportPP()
    End With

    MyCrViewer = New FrmCrViewer
		With MyCrViewer
			.Wrkds = ds
      .Show()
    End With
End Sub

End Module






