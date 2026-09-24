Module Main
Public MyFrmMain As FrmMain
Public ds As DataSet = New DataSet
Public DataPath As String
Public WrkAutomate As Boolean
Public WrkMsg As String
Sub Main()

		Dim TestCmd() As String

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		DataPath = GetDataPath()
		TestCmd = GetCommandLineArgs()
		WrkAutomate = False
		If Trim(TestCmd(0)) > "" Then
			If LCase(TestCmd(0)) = "/auto" Then
				WrkAutomate = True
				System.Threading.Thread.Sleep(2000)
				RunUpdate()
				LaunchEXE()
				End
			End If
		End If

	MyFrmMain = New FrmMain
	Application.Run(MyFrmMain)
End Sub
Public Sub LaunchEXE()
	Dim WrkEXE As String
	Dim WrkVal As Integer

	WrkEXE = DataPath & "A_CATALOG.EXE"

	Try
		WrkVal = Shell(WrkEXE, AppWinStyle.NormalFocus)
		If WrkVal = 0 Then
			MsgBox("Error running program " & WrkEXE & ". Please contact Hotline", MsgBoxStyle.Critical, "Program error")
		End If
	Catch
		MsgBox("Error running program " & WrkEXE & " .Please contact Hotline", MsgBoxStyle.Critical, "Program error")
	End Try
End Sub
'Copied from utils.vb

Public Function GetCommandLineArgs() As String()
	 ' Return values as string array
	 Dim separators As String = " "
	 Dim commands As String = Microsoft.VisualBasic.Command()
	 Dim args() As String = commands.Split(separators.ToCharArray)
	 Return args
End Function
Public Function GetDataPath() As String

		Dim WrkFileName As String
		Dim WrkPgmName As String

		WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
		Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

		With myFileVersionInfo
			WrkPgmName = .InternalName
	 End With

		'Remove program name from path
		WrkFileName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)

		Return WrkFileName
End Function
Public Function GetProgramName(Optional ByVal IncludeExtension As Boolean = True) As String
    Dim WrkFileName As String
    Dim WrkProgName As String

    WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
    Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

    With myFileVersionInfo
      WrkProgName = .InternalName
    End With

    'Optional - Remove .exe from prgram name
    If Not IncludeExtension Then
      WrkProgName = Replace(WrkProgName, ".exe", "", , , CompareMethod.Text)
    End If

    Return WrkProgName
End Function

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

    WrkPath = GetDataPath() & "Logs\"
    WrkProgName = GetProgramName()
    WrkProgName = Replace(WrkProgName, ".exe", "")
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath & _
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
    MsgBox("Program (" & ErrType & ") ended abnormally. Send " & _
      WrkProgName & " " & WrkTimestamp & ".Log file to RWA support", MsgBoxStyle.Critical)
    Application.Exit()
End Sub
End Module
