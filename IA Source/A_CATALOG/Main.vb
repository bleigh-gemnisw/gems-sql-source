Imports System.IO

'Parameters:
' /auto = automatic mode
' /debug = debug log to rebexlog.txt
Module Main
  Public MyFrmMain As FrmMain
  Public ds As DataSet = New DataSet
  Public MyApps As String
  Public MyTownNo As String
  Public DataPath As String
  Public MyCustom As String
  Public MyFTPDir As String
  Public MyAutomate As Boolean
  Public MyDebug As Boolean
  Public WrkCompareOnly As Boolean
  Sub Main()
    Dim TestCmd() As String

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    DataPath = GetDataPath()
    TestCmd = GetCommandLineArgs()
    MyAutomate = False
    If Trim(TestCmd(0)) > "" Then
      If UCase(TestCmd(0)) = "/AUTO" Then
        MyAutomate = True
      End If
      If UCase(TestCmd(0)) = "/DEBUG" Then
        MyDebug = True
      End If
    End If

    ReadIni()
    If MyAutomate Then
      AutomaticUpdate()
      End
    End If

    MyFrmMain = New FrmMain
    Application.Run(MyFrmMain)
  End Sub
  Private Sub ReadIni()
    'Sample ini file. Do NOT include text in () or this line.
    'APPS=TA;IA;TO;TX (Installed Applications)  
    'TOWN = 99 (Town Number)
    'CUSTOM=B (Optional, if 2nd set of custom reports is needed) 
    'FTP=GEMSBETA (optional, alternative FTP directory name)

    Dim sr As StreamReader
    Dim WrkDatapath As String
    Dim WrkLine As String

    WrkDatapath = GetDataPath()
    sr = New StreamReader(WrkDatapath & "A_CATALOG.INI")
    WrkLine = sr.ReadLine()
    MyApps = Mid(WrkLine, 6, 50)
    WrkLine = sr.ReadLine()
    MyTownNo = Mid(WrkLine, 6, 3)
    MyCustom = ""
    MyFTPDir = "GEMS_NET"
    Do While Not sr.EndOfStream
      WrkLine = sr.ReadLine()
      If Left(WrkLine, 6) = "CUSTOM" Then
        MyCustom = Mid(WrkLine, 8, 1)
      End If
      If Left(WrkLine, 3) = "FTP" Then
        MyFTPDir = Trim(Mid(WrkLine, 5, 10))
      End If
    Loop
    sr.Close()
  End Sub
  Public Sub LaunchEXE()
    Dim WrkEXE As String
    Dim WrkVal As Integer

    WrkEXE = DataPath & "A_CATALOGUP.EXE /auto"

    Try
      WrkVal = Shell(WrkEXE, AppWinStyle.NormalNoFocus)
      If WrkVal = 0 Then
        MsgBox("Error running program " & WrkEXE & ". Please contact Hotline", MsgBoxStyle.Critical, "Program error")
      End If
    Catch
      MsgBox("Error running program " & WrkEXE & ". Please contact Hotline", MsgBoxStyle.Critical, "Program error")
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
  'Copied from utils.vb
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
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath &
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
    MsgBox("Program (" & ErrType & ") ended abnormally. Send " &
      WrkProgName & " " & WrkTimestamp & ".Log file to RWA support", MsgBoxStyle.Critical)
    Application.Exit()
  End Sub
End Module
