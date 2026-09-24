Imports System.ComponentModel
Imports System.Text
'Imports System.Drawing.Imaging
'Imports System.Drawing.Printing
Public Class Util
  Private Const mciFudge As Integer = 4                   'fudge factor for 'ScaleWidth/
  Public VbKeyEnter As Char = Microsoft.VisualBasic.ChrW(13)
  Dim MyImage As System.Drawing.Bitmap 'needed for PrtScreen
  Public Sub CenterForm(ByVal mdi As Windows.Forms.Form, ByVal frm As Windows.Forms.Form)
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

  Private Function GetMDIScaleHeight(ByVal mdi As Windows.Forms.Form) As Integer
    ' Consider docked controls in the mdi and if docked then reduce the size
    Dim ctl As Windows.Forms.Control
    Dim h As Integer = mdi.ClientSize.Height

    For Each ctl In mdi.Controls
      With ctl
        If .GetContainerControl() Is mdi Then   'docked to the mdi form
          If .Dock = Windows.Forms.DockStyle.Top Or .Dock = Windows.Forms.DockStyle.Bottom Then
            h = h - .Size.Height
          End If
        End If
      End With
    Next
    GetMDIScaleHeight = h - mciFudge
  End Function

  Private Function GetMDIScaleWidth(ByVal mdi As Windows.Forms.Form) As Integer
    ' Consider docked controls in the mdi and if docked then reduce the size
    Dim ctl As Windows.Forms.Control
    Dim w As Integer = mdi.ClientSize.Width

    For Each ctl In mdi.Controls
      With ctl
        If .GetContainerControl() Is mdi Then   'docked to the mdi form
          If .Dock = Windows.Forms.DockStyle.Left Or .Dock = Windows.Forms.DockStyle.Right Then
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
Public Function CheckPrinterExists(ByVal PrinterName As String) As Boolean
  Dim pd As New Drawing.Printing.PrintDocument()
  Dim Good As Boolean

  Good = False
  pd.PrinterSettings.PrinterName = PrinterName

  If pd.PrinterSettings.IsValid Then
    Good = True
  End If
  Return Good
End Function

Public Function CnvSng(ByVal WrkNum As String) As Decimal
'Convert string to decimal
Dim WrkDbl As Decimal

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
#Region "Get Program Name, Data Path, Computer Name, Helpfile, Report Path"
Public Function GetProgramName(Optional ByVal IncludeExtension As Boolean = True) As String
    Dim WrkFileName As String
    Dim WrkProgName As String

    WrkFileName = System.Reflection.Assembly.GetCallingAssembly.Location
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

    WrkFileName = System.Reflection.Assembly.GetCallingAssembly.Location
    Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

    With myFileVersionInfo
      WrkPgmName = .InternalName
   End With

    'Remove program name from path
    WrkFileName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)

    Return WrkFileName
End Function
Public Function GetComputerName() As String
    Dim WrkComputerName As String
    WrkComputerName = System.Environment.MachineName
    Return WrkComputerName
End Function
Public Function GetHelpFile(ByVal HelpID As String) As String
    'Usage (with HelpProvider control):
    '  HelpProvider1.HelpNamespace = GetHelpFile("UB101")
    'Optional keywords:
    '  HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
    '  HelpProvider1.SetHelpKeyword(Me, "UB101")
 Dim WrkFileName As String
 Dim WrkFilePath As String
 Dim WrkExists As Boolean

 WrkFilePath = GetDataPath()
 WrkFileName = WrkFilePath & "gemshelp\" & GetProgramName(False) & ".chm"
 WrkExists = CheckFileExists(WrkFileName)
 If Not WrkExists Then
   WrkFileName = WrkFilePath & "gemshelp\Construction.chm"
 End If

 'Remove extra slashes if network path 
 WrkFileName = Replace(WrkFileName, "\\\\", "\\")
 Return WrkFileName
End Function
Public Function GetReportPath(ByVal RptName As String, ByVal TownNbr As Integer, _
  Optional ByVal CustomDir As String = "") As String
  'Use custom report from town subdir if found otherwise use standard report
  Dim WrkFileName As String
  Dim WrkDefaultName As String
  Dim WrkPgmName As String
  Dim WrkTownNbr As String
  Dim WrkExists As Boolean

  WrkFileName = System.Reflection.Assembly.GetCallingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
   WrkPgmName = .InternalName
  End With

  'Remove program name from path
  WrkFileName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)

  WrkTownNbr = Format(TownNbr, "000")
  'Add town number to path
  WrkFileName = WrkFileName & WrkTownNbr & "\"

  CustomDir = Trim(CustomDir)
  'Check for custom report (\<townnbr>\reports) 
  WrkDefaultName = WrkFileName & "reports\"
  If CustomDir = String.Empty Then
   WrkFileName = WrkFileName & "reports\"
  Else
   WrkFileName = WrkFileName & "reports" & CustomDir & "\"
  End If
  WrkExists = CheckFileExists(WrkFileName & RptName)

  'No Custom report found so use generic report
  If Not WrkExists Then
   WrkFileName = Replace(WrkDefaultName, WrkTownNbr & "\", "")
  End If

  'Need double slashes for crystal reports path 
  WrkFileName = Replace(WrkFileName, "\", "\\")

  'Remove extra slashes if network path 
  WrkFileName = Replace(WrkFileName, "\\\\", "\\")

  'Add report name to path
  WrkFileName = WrkFileName & RptName

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

   AddrLine(I) = Trim(Name)
   I = I + 1
   If Trim(Sname) <> "" Then
     AddrLine(I) = Trim(Sname)
      I = I + 1
   End If
   AddrLine(I) = Trim(Add1)
   I = I + 1
   If Trim(Add2) <> "" Then
     AddrLine(I) = Trim(Add2)
      I = I + 1
   End If
   sb = New StringBuilder
   sb.Append(Trim(City))
   sb.Append(", ")
   sb.Append(Trim(State))
   sb.Append(" ")
   If ZipAlpha = "" Then
     sb.Append(Format(Zip5, "00000"))
     If Zip4 > 0 Then
       sb.Append("-")
       sb.Append(Format(Zip4, "0000"))
     End If
   Else
     sb.Append(Trim(ZipAlpha))
   End If
   AddrLine(I) = sb.ToString
   For I = 3 To 4
     If AddrLine(I) Is Nothing Then
       AddrLine(I) = ""
     End If
   Next
   Return AddrLine

End Function
  Public Sub SetTxtReadOnly(ByRef WrkCtl As Windows.Forms.TextBox)
    'Make textbox be readonly
    WrkCtl.ReadOnly = True
    WrkCtl.TabStop = False
    WrkCtl.BackColor = Drawing.Color.Aqua
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
Public Function GetDBDate6(ByVal DateIn As Integer) As Date
  Dim WrkDate As Date
  Dim StrDate As String

  If DateIn > 0 Then
    StrDate = Trim$(Str(DateIn))
    Try
      WrkDate = Mid$(StrDate, 3, 2) & "/" & Right$(StrDate, 2) & "/" & Left$(StrDate, 2)
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
    Try
      WrkDate = Left$(StrDate, 2) & "/" & Mid$(StrDate, 3, 2) & "/" & Right$(StrDate, 4)
    Catch ex As Exception
      Return #1/1/1800#
    End Try
  End If
  If WrkLen = 7 Then
    Try
      WrkDate = Left$(StrDate, 1) & "/" & Mid$(StrDate, 2, 2) & "/" & Right$(StrDate, 4)
    Catch ex As Exception
      Return #1/1/1800#
    End Try
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
Public Function JustifyRight(ByVal StrInput As String, ByVal MaxLength As Integer, _
  Optional ByVal StrPadChar As String = " ") As String
 'Right justify a string and pad to left. If it's too big then chop it at max length.
 Dim InputLength As Integer
 Dim StrOutput As String
 InputLength = Len(StrInput)
 StrOutput = StrInput
 If InputLength > MaxLength Then 'Error
   Return Mid(StrInput, 1, MaxLength)
 End If

 Do Until InputLength = MaxLength
   StrOutput = StrPadChar & StrOutput
   InputLength = InputLength + 1
 Loop
 Return StrOutput
End Function
Public Function JustifyLeft(ByVal StrInput As String, ByVal MaxLength As Integer, _
  Optional ByVal StrPadChar As String = " ") As String
 'Left justify a string abd pad to right.  If it's too big then chop it at max length.
 Dim InputLength As Integer
 Dim StrOutput As String
 InputLength = Len(StrInput)
 StrOutput = StrInput
 If InputLength > MaxLength Then 'Error
   Return Mid(StrInput, 1, MaxLength)
 End If

 Do Until InputLength = MaxLength
   StrOutput = StrOutput & StrPadChar
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
Public Sub KeyEnter_isTab(ByVal WrkFrm As Windows.Forms.Form, ByRef e As Windows.Forms.KeyPressEventArgs)
  'Makes Enter/Return Key act like Tab Key
  'Usage (KeyPress event): KeyEnter_isTab(Me, e)
  If Asc(e.KeyChar) = Windows.Forms.Keys.Return Then
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
Public Function Round(ByVal Number As Decimal, ByVal Decimals As Integer) As Decimal
'Round numbers normally. Note that Math.round uses banker's rounding.
Dim WrkNo As Decimal
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
Case 5
  WrkNo = Number * 100000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 100000
Case 6
  WrkNo = Number * 1000000
  WrkInt = Math.Floor(WrkNo + 0.5)
  WrkNo = WrkInt / 1000000
End Select

Return WrkNo
End Function
  Public Function Round10(ByVal WrkNumber As Integer, ByVal RoundMethod As String) As Integer
    'Round to 10's. Down=Round down, Normal=1-4 Round down and 5-9 Round up  
    Dim RoundDown As Boolean
    Dim J As Integer

    Select Case RoundMethod
      Case "Down"
        RoundDown = True
      Case "Normal"
        RoundDown = False
      Case Else
        Return WrkNumber
    End Select

    J = WrkNumber Mod 10
    If J <> 0 Then
      If RoundDown Then
        WrkNumber = WrkNumber - J
      Else
        If J < 5 Then
          WrkNumber = WrkNumber - J
        Else
          WrkNumber = WrkNumber + (10 - J)
        End If
      End If
    End If

    Return WrkNumber
  End Function
  Public Sub ShowFocus(ByVal tb As Windows.Forms.TextBox)
    'Highlights text 
    'Usage (GotFocus event):  ShowFocus(Me.ActiveControl)
    tb.SelectionStart = 0
    tb.SelectionLength = tb.Text.Length

  End Sub

#Region "PrtScreen (Screen Capture)"
  Public Sub PrtScreen(ByVal FormName As Windows.Forms.Form, Optional ByVal AskBW As Boolean = False)
  'Code only needed in MDI, otherwise put in each form
  'Usage (KeyDown event):   
  ' If Not e.Alt Then Exit Sub
  ' If e.KeyCode = Keys.F12 Then
  '   PrtScreen(Me.ActiveForm)
  ' End If
  Dim g1 As Drawing.Graphics = FormName.CreateGraphics()
  MyImage = New Drawing.Bitmap(FormName.Width, FormName.Height, g1)
  Dim g2 As Drawing.Graphics = Drawing.Graphics.FromImage(MyImage)
  Dim dc1 As IntPtr = g1.GetHdc()
  Dim dc2 As IntPtr = g2.GetHdc()
  Dim WrkDataPath As String
'  Dim WrkTimestamp As String

'  added code to compute and capture the form title(bar And borders)
  Dim widthDiff As Integer = _
     (FormName.Width - FormName.ClientRectangle.Width)
  Dim heightDiff As Integer = _
     (FormName.Height - FormName.ClientRectangle.Height)
  Dim borderSize As Integer = widthDiff \ 2
  Dim heightTitleBar As Integer = heightDiff - borderSize
  BitBlt(dc2, 0, 0, _
     FormName.ClientRectangle.Width + widthDiff, _
     FormName.ClientRectangle.Height + heightDiff, dc1, _
     0 - borderSize, 0 - heightTitleBar, 13369376)
  g1.ReleaseHdc(dc1)
  g2.ReleaseHdc(dc2)
  WrkDataPath = GetDataPath() & "Logs\"

  Dim pd As New System.Drawing.Printing.PrintDocument
  AddHandler pd.PrintPage, AddressOf PrtPage
  Dim MySplash As Splash.FrmSplash

  MySplash = New Splash.FrmSplash
  With MySplash
    .GetAppSettings()
    If .MyAppSettings.PrtscrnBW Then
        pd.DefaultPageSettings.Color = False
      End If
    If .MyAppSettings.Printer <> "" Then
      pd.PrinterSettings.PrinterName = .MyAppSettings.Printer
      If .MyAppSettings.PrintOrient = "L" Then
        pd.DefaultPageSettings.Landscape = True
      Else
        pd.DefaultPageSettings.Landscape = False
      End If
    End If
  End With
  pd.Print()
End Sub
Private Sub PrtPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
 ev.Graphics.DrawImage(MyImage, ev.Graphics.VisibleClipBounds)
' ev.Graphics.DrawImage(Image.FromFile(WrkPrtFileName), _
' ev.Graphics.VisibleClipBounds)

' Indicate that this is the last page to print.
 ev.HasMorePages = False
End Sub

#End Region
End Class
