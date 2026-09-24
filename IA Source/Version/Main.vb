Module Main
  Public MyFrmMain As FrmMain
  Public MyFrmErrMsg As FrmErrMsg
  Public WrkErrMsg As String
Sub Main()

WrkErrMsg = ""
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmMain = New FrmMain
  Application.Run(MyFrmMain)
End Sub
  Public Sub GlobalThreadHandler(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)
    'Traps application unhandled thread errors, writes a log file and ends program
    'Usage (Sub Main): AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
    Dim ex As Exception = CType(t.Exception, Exception)

    GlobalErrorLog(ex, "Thread")
  End Sub
  Public Sub GlobalUnhandler(ByVal sender As Object, ByVal t As System.UnhandledExceptionEventArgs)
    'Traps AppDomain/CLR unhandled errors, writes a log file and ends program
    'Usage (Sub Main): AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    Dim ex As Exception = CType(t.ExceptionObject, Exception)

    GlobalErrorLog(ex, "AppDomain")
  End Sub
Private Sub GlobalErrorLog(ByVal ex As Exception, ByVal ErrType As String)
    Dim sb As System.Text.StringBuilder

    sb = New System.Text.StringBuilder
    sb.AppendLine(ex.Message)
    sb.AppendLine("")
    If Not IsNothing(ex.InnerException) Then
      sb.AppendLine(ex.InnerException.Message)
      sb.AppendLine("")
    End If
    sb.AppendLine(ex.StackTrace)
    WrkErrMsg = sb.ToString
    MyFrmErrMsg = New FrmErrMsg
    MyFrmErrMsg.ShowDialog()
End Sub
End Module
