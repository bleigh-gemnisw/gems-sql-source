Module ProcessPP
Dim myTXPPRP As TXPPRP.myData

Const WrkType As String = "P"
  Public Sub ProcPP()
    '    Dim Counter As Integer

    myTXPPRP = New TXPPRP.mydata(MyDBConnect)

    'MyFrmProgress = New FrmProgress
    'MyFrmProgress.LblMsg.Text = "Personal Property"
    'MyFrmProgress.Show()
    'MyFrmProgress.Refresh()
    'Application.DoEvents()

    'Counter = 0
    'MyFrmProgress.Close()
  End Sub
End Module






