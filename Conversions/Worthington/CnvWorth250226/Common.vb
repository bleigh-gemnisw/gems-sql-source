Module Common
  Public MyAppSettings As AppSettings
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkFileExists As Boolean

    WrkXMLPath = GetDataPath() & "Settings\CnvWorth.xml"
    WrkFileExists = CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      Try
        MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
      End Try
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Sub SaveAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkXMLPath As String

    WrkXMLPath = GetDataPath() & "Settings\CnvWorth.xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
  End Sub
  Public Function CheckFileExists(ByVal FileName As String) As Boolean

    Dim Results As String

    CheckFileExists = False
    Results = Dir(FileName)

    If Results <> "" Then
      CheckFileExists = True
    End If

    Return CheckFileExists

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
  Public Function JustifyRight(ByVal StrInput As String, ByVal MaxLength As Integer,
  Optional ByVal StrPadChar As String = " ") As String
    'Right justify a string and pad to left. If it's too big then chop it at max length.
    Dim InputLength As Integer
    Dim StrOutput As String

    StrInput = Trim(StrInput)
    If Left(StrInput, 5) = "00000" Then
      StrInput = Replace(StrInput, "00000", "", 1, 1)
    End If
    If Left(StrInput, 4) = "0000" Then
      StrInput = Replace(StrInput, "0000", "", 1, 1)
    End If
    If Left(StrInput, 3) = "000" Then
      StrInput = Replace(StrInput, "000", "", 1, 1)
    End If
    If Left(StrInput, 2) = "00" Then
      StrInput = Replace(StrInput, "00", "", 1, 1)
    End If
    If Left(StrInput, 1) = "0" Then
      StrInput = Replace(StrInput, "0", "", 1, 1)
    End If

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
  Public Function SetDBDate(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Year(DateIn) & Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00")
    WrkDate = CnvSng(StrDate)
    Return WrkDate
  End Function
  Public Function SetDBDateMDY(ByVal DateIn As Date) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    StrDate = Format(Month(DateIn), "00") &
    Format(DatePart(DateInterval.Day, DateIn), "00") & Year(DateIn)
    WrkDate = CnvSng(StrDate)
    Return WrkDate
  End Function
  Public Function SetDBTime(ByVal DateIn As Date) As Integer
    Dim WrkTime As Integer
    Dim StrTime As String

    StrTime = Hour(DateIn) & Format(Minute(DateIn), "00") &
    Format(Second(DateIn), "00")
    WrkTime = CnvSng(StrTime)
    Return WrkTime
  End Function
End Module
