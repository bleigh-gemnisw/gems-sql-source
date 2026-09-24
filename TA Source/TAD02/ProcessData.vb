Imports System.Text
Module ProcessData

Dim myTXCNTL As TXCNTL.myData
Public Sub ProcData()
myTXCNTL = New TXCNTL.mydata(MyDBConnect)

myTXCNTL.GetOneRecordP("")
If myTXCNTL.RecordNotFound Then Exit Sub

With MyFrmTAD02B
	If .RbRE.Checked Or .RbAll.Checked Then
		myTXCNTL._SFR = "Y"
	End If
	If .RbPP.Checked Or .RbAll.Checked Then
		myTXCNTL._SFP = "Y"
	End If
	If .RbMV.Checked Or .RbAll.Checked Then
		myTXCNTL._SFM = "Y"
	End If
	myTXCNTL.UpdateOneRecordP()
End With

MsgBox("File(s) have been Soft Frozen", MsgBoxStyle.Information, "Program Completed")
MyFrmTAD02.Close()

End Sub
End Module






