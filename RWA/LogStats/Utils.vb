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
    MsgBox("Program (" & ErrType & ") ended abnormally. Send " & "-" & _
      WrkProgName & " " & WrkTimestamp & ".Log file to RWA support", MsgBoxStyle.Critical)
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

Public Function SetAddrLine(ByVal Name As String, ByVal Sname As String, ByVal Add1 As String, _
   ByVal Add2 As String, ByVal City As String, ByVal State As String, _
   ByVal Zip5 As Integer, ByVal Zip4 As Integer, _
   Optional ByVal ZipAlpha As String = "") As String()
   'Returns Address as string array. Blank lines are stripped out. 
   'City, State, Zip5 and Zip4 are combined into one line
   Dim AddrLine(4) As String
   Dim sb As StringBuilder
   Dim I As Integer

   AddrLine(I) = Name
   I = I + 1
   If Sname <> "" Then
     AddrLine(I) = Sname
      I = I + 1
   End If
   AddrLine(I) = Add1
   I = I + 1
   If Add2 <> "" Then
     AddrLine(I) = Add2
      I = I + 1
   End If
   sb = New StringBuilder
   sb.Append(City)
   sb.Append(", ")
   sb.Append(State)
   sb.Append(" ")
   If ZipAlpha = "" Then
     sb.Append(Format(Zip5, "00000"))
     If Zip4 > 0 Then
       sb.Append("-")
       sb.Append(Format(Zip4, "0000"))
     End If
   Else
     sb.Append(ZipAlpha)
   End If
   AddrLine(I) = sb.ToString
   For I = 3 To 4
     If AddrLine(I) Is Nothing Then
       AddrLine(I) = ""
     End If
   Next
   Return AddrLine

End Function
  Public Sub SetTxtReadOnly(ByRef WrkCtl As TextBox)
    'Make textbox be readonly
    WrkCtl.ReadOnly = True
    WrkCtl.TabStop = False
    WrkCtl.BackColor = Color.Aqua
  End Sub

#Region "Get/Set DB Dates"
Public Function GetDBDate(ByVal DateIn As Integer) As Date
  Dim WrkDate As Date
  Dim StrDate As String

  If DateIn > 0 Then
    StrDate = Trim$(Str(DateIn))
    Try
      WrkDate = Mid$(StrDate, 5, 2) & "/" & Right$(StrDate, 2) & "/" & Left$(StrDate, 4)
    Catch
    End Try
  End If
  Return WrkDate
End Function
Public Function GetDBDateMDY(ByVal DateIn As Integer) As Date
  Dim WrkDate As Date
  Dim StrDate As String
  Dim WrkLen As Integer

  StrDate = Trim$(Str(DateIn))
  WrkLen = Len(StrDate)
  If WrkLen = 8 Then
    WrkDate = Left$(StrDate, 2) & "/" & Mid$(StrDate, 3, 2) & "/" & Right$(StrDate, 4)
  End If
  If WrkLen = 7 Then
    WrkDate = Left$(StrDate, 1) & "/" & Mid$(StrDate, 2, 2) & "/" & Right$(StrDate, 4)
  End If
  Return WrkDate
End Function
Public Function SetDBDate(ByVal DateIn As Date) As Integer
  Dim WrkDate As Integer
  Dim StrDate As String

  StrDate = Year(DateIn) & Format(Month(DateIn), "00") & _
    Format(DatePart(DateInterval.Day, DateIn), "00")
  WrkDate = CnvSng(StrDate)
  Return WrkDate
End Function
Public Function SetDBDateMDY(ByVal DateIn As Date) As Integer
  Dim WrkDate As Integer
  Dim StrDate As String

  StrDate = Format(Month(DateIn), "00") & _
    Format(DatePart(DateInterval.Day, DateIn), "00") & Year(DateIn)
  WrkDate = CnvSng(StrDate)
  Return WrkDate
End Function
Public Function SetDBTime(ByVal DateIn As Date) As Integer
  Dim WrkTime As Integer
  Dim StrTime As String

  StrTime = Hour(DateIn) & Format(Minute(DateIn), "00") & _
    Format(Second(DateIn), "00")
  WrkTime = CnvSng(StrTime)
  Return WrkTime
End Function
#End Region

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
Public Function FmtCurrency(ByVal WrkAmount As Decimal) As String
  'Format number as currency: 1234.56 = $1,234.56
  Dim WrkStr As String
  WrkStr = FormatCurrency(WrkAmount, 2, TriState.False, TriState.False)
  Return WrkStr
End Function
Public Function StripTime(ByVal DateIn As Date) As Date
 'Strip off time from imcoming date/time 
  StripTime = DateIn.ToShortDateString
End Function
Public Sub KeyEnter_isTab(ByVal WrkFrm As Form, ByRef e As KeyPressEventArgs)
  'Makes Enter/Return Key act like Tab Key
  'Usage (KeyPress event): KeyEnter_isTab(Me, e)
  If Asc(e.KeyChar) = Keys.Return Then
    WrkFrm.SelectNextControl(WrkFrm.ActiveControl, True, True, True, True)
    e.Handled = True
  End If
End Sub
Public Function Quo(ByVal WrkString As String) As String
  'Put quotes around strings for Query Select
  Quo = "'" & WrkString & "'"
End Function
Public Function QuoDate(ByVal WrkString As Date) As String
  'Changes date to a string
  QuoDate = "#" & WrkString & "#"
End Function
Public Function Round(ByVal Number As Decimal, ByVal Decimals As Integer) As Double
'Round numbers normally. Note that Math.round uses banker's rounding.
Dim WrkNo As Double
Dim WrkInt As Long
Select Case Decimals
Case 0
  WrkNo = Math.Floor(Number + 0.5)
Case 1
  WrkNo = Number * 10
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 10
Case 2
  WrkNo = Number * 100
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 100
Case 3
  WrkNo = Number * 1000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 1000
Case 4
  WrkNo = Number * 10000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 10000
End Select

Return WrkNo
End Function
Public Sub ShowFocus(ByVal tb As TextBox)
  'Highlights text 
  'Usage (GotFocus event):  ShowFocus(Me.ActiveControl)
  tb.SelectionStart = 0
  tb.SelectionLength = tb.Text.Length

End Sub

#Region "PrtScreen (Screen Capture)"
<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
Private Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Boolean

End Function
Public Sub PrtScreen(ByVal FormName As Form)
  'Code only needed in MDI, otherwise put in each form
  'Usage (KeyDown event):   
  ' If Not e.Alt Then Exit Sub
  ' If e.KeyCode = Keys.F12 Then
  '   PrtScreen(Me.ActiveForm)
  ' End If
  Dim g1 As Graphics = FormName.CreateGraphics()
  Dim MyImage As Bitmap
  MyImage = New Bitmap(FormName.Width, FormName.Height, g1)
  Dim g2 As Graphics = Graphics.FromImage(MyImage)
  Dim dc1 As IntPtr = g1.GetHdc()
  Dim dc2 As IntPtr = g2.GetHdc()
  Dim WrkDataPath As String
  Dim WrkTimestamp As String

  BitBlt(dc2, 0, 0, FormName.Width, FormName.Height, dc1, -4, -30, 13369376)
  g1.ReleaseHdc(dc1)
  g2.ReleaseHdc(dc2)
  WrkDataPath = GetDataPath() & "Logs\"
  WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
  WrkPrtFileName = WrkDataPath & "PrtScrn " & WrkTimestamp & ".jpg"
  MyImage.Save(WrkPrtFileName, ImageFormat.Jpeg)

  Dim pd As New System.Drawing.Printing.PrintDocument
  AddHandler pd.PrintPage, AddressOf PrtPage
  If GetRegKey("PrtScreen", True) <> "" Then
    pd.PrinterSettings.PrinterName = GetRegKey("PrtScreen", True)
    If GetRegKey("PrtScreenOrient", True) = "L" Then
      pd.DefaultPageSettings.Landscape = True
    Else
      pd.DefaultPageSettings.Landscape = True
    End If
  End If
  pd.Print()
End Sub
Private Sub PrtPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
 ev.Graphics.DrawImage(Image.FromFile(WrkPrtFileName), _
 ev.Graphics.VisibleClipBounds)

' Indicate that this is the last page to print.
 ev.HasMorePages = False
End Sub
#End Region

#Region "Registry Set/Get Keys"
Public Function GetRegKey(ByVal KeyElement As String, ByVal IsGlobal As Boolean) As String

Dim Key As Microsoft.Win32.RegistryKey
Dim KeyName As String
Dim WrkKey As String

Dim WrkFileName As String
Dim WrkPgmName As String

If IsGlobal Then
  KeyName = "SOFTWARE\\R Walsh Associates\\"
Else
  WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
    WrkPgmName = .InternalName
  End With

  'Remove exe from program name
  WrkPgmName = Replace(WrkPgmName, ".exe", "").ToUpper

  KeyName = "SOFTWARE\\R Walsh Associates\\" & WrkPgmName & "\\"
End If

Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyName)
If Key Is Nothing Then
  Key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyName)
  Key.SetValue(KeyElement, "")
End If

WrkKey = Key.GetValue(KeyElement, "")
Key.Close()
Return WrkKey

End Function
Public Sub SetRegKey(ByVal KeyElement As String, ByVal IsGlobal As Boolean, ByVal Value As String)

Dim Key As Microsoft.Win32.RegistryKey
Dim KeyName As String

Dim WrkFileName As String
Dim WrkPgmName As String

If IsGlobal Then
  KeyName = "SOFTWARE\\R Walsh Associates\\"
Else
  WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
    WrkPgmName = .InternalName
  End With

  'Remove exe from program name
  WrkPgmName = Replace(WrkPgmName, ".exe", "").ToUpper

  KeyName = "SOFTWARE\\R Walsh Associates\\" & WrkPgmName & "\\"
End If

Key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyName, True)
Key.SetValue(KeyElement, Value)
Key.Close()

End Sub
#End Region

End Module
