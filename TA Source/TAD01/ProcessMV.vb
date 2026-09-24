Module ProcessMV
Dim myTXMVD As TXMVD.MyData

Const WrkType As String = "M"
  Public Sub ProcMV()
    '    Dim Counter As Integer

    myTXMVD = New TXMVD.mydata(MyDBConnect)

    'MyFrmProgress = New FrmProgress
    'MyFrmProgress.LblMsg.Text = "Motor Vehicle"
    'MyFrmProgress.Show()
    'MyFrmProgress.Refresh()
    'Application.DoEvents()

    'Counter = 0
    'MyFrmProgress.Close()
  End Sub
End Module






