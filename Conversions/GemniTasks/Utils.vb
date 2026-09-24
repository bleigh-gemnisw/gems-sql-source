Module Util
#Region "GlobalErrors"
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
    Dim WrkPath As String
    Dim WrkProgName As String
    Dim WrkTimestamp As String

    WrkPath = MyUtils.GetDataPath() & "Logs\"
    WrkProgName = MyUtils.GetProgramName()
    WrkProgName = Replace(WrkProgName, ".exe", "")
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath & MyUserID &
      "-" & WrkProgName & "-" & WrkTimestamp & ".Log")
    sw.WriteLine(WrkProgName & " (" & ErrType & ")")
    sw.WriteLine("")
    sw.WriteLine(ex.Message)
    sw.WriteLine("")
    If Not IsNothing(ex.InnerException) Then
      sw.WriteLine(ex.InnerException.Message)
      sw.WriteLine("")
    End If
    sw.WriteLine(ex.StackTrace)
    sw.Close()
    MsgBox("Program (" & ErrType & ") ended abnormally. Send " & MyUserID & "-" &
      WrkProgName & " " & WrkTimestamp & ".Log file to RWA support", MsgBoxStyle.Critical)
    Application.Exit()
  End Sub
#End Region
  Public Sub WriteErrorLog(ByVal ErrMsg As String)
    Dim WrkPath As String
    Dim WrkProgName As String
    Dim WrkTimestamp As String

    WrkPath = MyUtils.GetDataPath() & "Logs\"
    WrkProgName = MyUtils.GetProgramName()
    WrkProgName = Replace(WrkProgName, ".exe", "")
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath & MyUserID &
      "-" & WrkProgName & "-" & WrkTimestamp & ".Log")
    sw.WriteLine(WrkProgName)
    sw.WriteLine("")
    sw.WriteLine(ErrMsg)
    sw.Close()
    MsgBox("File write error. Send " & MyUserID & "-" &
      WrkProgName & " " & WrkTimestamp & ".Log file to RWA support", MsgBoxStyle.Critical)
    Application.Exit()
  End Sub
  Public Function GetCommandLineArgs() As String()
    ' Return values as string array
    Dim separators As String = " "
    Dim commands As String = Microsoft.VisualBasic.Command()
    Dim args() As String = commands.Split(separators.ToCharArray)
    Return args
  End Function
End Module






