Imports System.ComponentModel
Imports System.Text
Imports System.Drawing.Imaging

Module Utils
  Private Const mciFudge As Integer = 4                   'fudge factor for 'ScaleWidth/
  Public VbKeyEnter As Char = Microsoft.VisualBasic.ChrW(13)
  Dim WrkPrtFileName As String 'needed for PrtScreen 
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
    MsgBox("Program (" & ErrType & ") ended abnormally", MsgBoxStyle.Critical)
    Application.Exit()
End Sub
#End Region
  Public Sub CenterForm(ByVal mdi As Form, ByVal frm As Form)
    ' Use 'old' method to center in MDI work area
    Dim l As Integer, t As Integer, w As Integer, h As Integer

    With frm
      If .WindowState = vbNormal Then
        w = GetMDIScaleWidth(mdi)
        h = GetMDIScaleHeight(mdi)
        If w > 0 And h > 0 Then
          l = (w - .Width) \ 2
          t = (h - .Height) \ 2
          If l < 0 Then                       'can't have caption off the screen
            l = 0
          End If
          If t < 0 Then
            t = 0
          End If
          If .Width > w Then
            .Width = w
            l = 0
          End If
          If .Height > h Then
            .Height = h
            t = 0
          End If
          .SetBounds(l, t, .Width, .Height)   'move to centered location
        End If
      End If
    End With
  End Sub

#Region "Get MDI ScaleHeight & ScaleWidth"

  Private Function GetMDIScaleHeight(ByVal mdi As Form) As Integer
    ' Consider docked controls in the mdi and if docked then reduce the size
    Dim ctl As Control
    Dim h As Integer = mdi.ClientSize.Height

    For Each ctl In mdi.Controls
      With ctl
        If .GetContainerControl() Is mdi Then   'docked to the mdi form
          If .Dock = DockStyle.Top Or .Dock = DockStyle.Bottom Then
            h = h - .Size.Height
          End If
        End If
      End With
    Next
    GetMDIScaleHeight = h - mciFudge
  End Function

  Private Function GetMDIScaleWidth(ByVal mdi As Form) As Integer
    ' Consider docked controls in the mdi and if docked then reduce the size
    Dim ctl As Control
    Dim w As Integer = mdi.ClientSize.Width

    For Each ctl In mdi.Controls
      With ctl
        If .GetContainerControl() Is mdi Then   'docked to the mdi form
          If .Dock = DockStyle.Left Or .Dock = DockStyle.Right Then
            w = w - .Size.Width
          End If
        End If
      End With
    Next
    GetMDIScaleWidth = w - mciFudge
  End Function

#End Region

Public Function CheckFileExists(ByVal FileName As String) As Boolean

  Dim Results As String

  CheckFileExists = False
  Results = Dir(FileName)

  If Results <> "" Then
    CheckFileExists = True
  End If

  Return CheckFileExists

End Function

Public Function CnvSng(ByVal WrkNum As String) As Double
'Convert string to double
Dim WrkDbl As Double

If WrkNum = "" Then
  WrkDbl = 0
  Return WrkDbl
End If

If Not IsNumeric(WrkNum) Then
  WrkDbl = 0
  Return WrkDbl
End If

WrkDbl = CDbl(WrkNum)
Return WrkDbl
End Function

Public Function GetCommandLineArgs() As String()
   ' Return values as string array
   Dim separators As String = " "
   Dim commands As String = Microsoft.VisualBasic.Command()
   Dim args() As String = commands.Split(separators.ToCharArray)
   Return args
End Function

#Region "Get Program Name, Data Path, Helpfile, Report Path"
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
#End Region


  Public Sub SetTxtReadOnly(ByRef WrkCtl As TextBox)
    'Make textbox be readonly
    WrkCtl.ReadOnly = True
    WrkCtl.TabStop = False
    WrkCtl.BackColor = Color.Aqua
  End Sub

#Region "Justify Right/Left"
Public Function JustifyRight(ByVal StrInput As String, ByVal MaxLength As Integer) As String
 'Right justify a string and pad with spaces to left
 Dim InputLength As Integer
 Dim StrOutput As String
 InputLength = Len(StrInput)
 StrOutput = StrInput
 If InputLength > MaxLength Then 'Error
   Return ""
 End If

 Do Until InputLength = MaxLength
   StrOutput = " " & StrOutput
   InputLength = InputLength + 1
 Loop
 Return StrOutput
End Function
Public Function JustifyLeft(ByVal StrInput As String, ByVal MaxLength As Integer) As String
 'Pad a string with space to the right
 Dim InputLength As Integer
 Dim StrOutput As String
 InputLength = Len(StrInput)
 StrOutput = StrInput
 If InputLength > MaxLength Then 'Error
   Return ""
 End If

 Do Until InputLength = MaxLength
   StrOutput = StrOutput & " "
   InputLength = InputLength + 1
 Loop
 Return StrOutput
End Function
#End Region

Public Function FilterNumbers(ByVal KeyChar As Char, ByVal AllowDec As Boolean, _
  ByVal AllowNegative As Boolean) As Boolean
  'Only numbers allowed 
  'Usage (Keypress event):  e.Handled = FilterNumbers(e.KeyChar, False, False)

    If KeyChar = vbBack Then
      Return False
      Exit Function
    End If

    If AllowDec Then
      If Convert.ToString(KeyChar) = "." Then
        Return False
        Exit Function
      End If
    End If

    If AllowNegative Then
      If Convert.ToString(KeyChar) = "-" Then
        Return False
        Exit Function
      End If
    End If

    Return IIf(IsNumeric(KeyChar), False, True) 'check if numeric is returned
End Function

Public Sub ShowFocus(ByVal tb As TextBox)
  'Highlights text 
  'Usage (GotFocus event):  ShowFocus(Me.ActiveControl)
  tb.SelectionStart = 0
  tb.SelectionLength = tb.Text.Length

End Sub

End Module
