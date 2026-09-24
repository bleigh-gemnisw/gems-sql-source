Imports Microsoft.Win32
Public Class FrmMain
  Dim WrkDirName As String
  Dim cNET As String = "1-NDP48-x86-x64-AllOS-ENU.exe"
  Dim cCR13_32 As String = "2b-CRRuntime_32bit_13_0_32.msi"
  Dim cCR13_64 As String = "2a-CRRuntime_64bit_13_0_32.msi"
  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CheckVersions()
  End Sub
  Private Sub CheckVersions()
    '    Dim WrkAssemblies() As System.Reflection.AssemblyName
    Dim WrkFileName As String
    Dim WrkPgmName As String
    Dim WrkFileVersionInfo As FileVersionInfo
    Dim OSVersion As String
    Dim ProgFiles As String
    Dim NetFramework As String
    Dim HasCR13 As Boolean
    Dim Fail As Boolean
    Const cCrystal32File As String = "\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win32_x86\crqe.dll"
    Const cCrystal64File As String = "\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64\crqe.dll"
    Const cCrystalVer As String = "13.0.30.3805"
    Const cCrystalVer2 As String = "13.0.32.4286"

    WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
    Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)
    With myFileVersionInfo
      WrkPgmName = .InternalName
    End With
    'Remove program name from path
    WrkDirName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)
    WrkDirName = WrkDirName & "Install\"

    OSVersion = My.Computer.Info.OSFullName
    If IntPtr.Size = 8 Then
      LblOS.Text = "OS: " & OSVersion & " 64 bit"
      ProgFiles = "C:\Program Files (x86)"
    Else
      LblOS.Text = "OS: " & OSVersion & " 32 bit"
      ProgFiles = "C:\Program Files"
    End If
    BtnNET.Visible = False
    NetFramework = Get45or451FromRegistry()
    If Mid(NetFramework, 10, 3) = "4.8" Then
      LblFramework.Text = ".Net Framework " & NetFramework
      LblFramework.ForeColor = Color.Green
    Else
      LblFramework.Text = ".Net Framework " & NetFramework
      LblFramework.ForeColor = Color.Red
      BtnNET.Visible = True
      Fail = True
    End If

    LblCR13.Text = ""
    If IntPtr.Size = 8 Then
      HasCR13 = CheckFileExists(ProgFiles & cCrystal64File)
      LblCR13.Text = LblCR13.Text & " (64 bit)"
      WrkFileVersionInfo = FileVersionInfo.GetVersionInfo(ProgFiles & cCrystal64File)
    Else
      HasCR13 = CheckFileExists(ProgFiles & cCrystal32File)
      LblCR13.Text = LblCR13.Text & " (32 bit)"
      WrkFileVersionInfo = FileVersionInfo.GetVersionInfo(ProgFiles & cCrystal32File)
    End If
    With WrkFileVersionInfo
      LblCR13.Text = LblCR13.Text & " " & .FileVersion
    End With
    If HasCR13 And WrkFileVersionInfo.FileVersion = cCrystalVer Or HasCR13 And WrkFileVersionInfo.FileVersion = cCrystalVer2 Then
      LblCR13.ForeColor = Color.Green
      BtnCR13.Visible = False
    Else
      LblCR13.ForeColor = Color.Red
      BtnCR13.Visible = True
      Fail = True
    End If
    If Not Fail Then
      LblResult.ForeColor = Color.Green
      LblResult.Text = "Result: Pass"
    Else
      LblResult.ForeColor = Color.Red
      LblResult.Text = "Result: Fail"
    End If
  End Sub
  Private Function Get45or451FromRegistry() As String
    Try
      Using ndpKey As RegistryKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").
        OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\")
        If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
          Return "Version: " & CheckFor45DotVersion(CInt(ndpKey.GetValue("Release")))
        Else
          Return ""
        End If
      End Using
    Catch
    End Try
    Return ""
  End Function
  ' Checking the version using >= will enable forward compatibility,  
  ' however you should always compile your code on newer versions of 
  ' the framework to ensure your app works the same. 
  Private Shared Function CheckFor45DotVersion(ByVal releaseKey As Integer) As String
    If releaseKey >= 533320 Then
      Return "4.8.1 or later"
    End If
    If releaseKey >= 528040 Then
      Return "4.8 or later"
    End If
    If releaseKey >= 461808 Then
      Return "4.7.2 or later"
    End If
    If releaseKey >= 461308 Then
      Return "4.7.1 or later"
    End If
    If releaseKey >= 460798 Then
      Return "4.7 or later"
    End If
    If releaseKey >= 394802 Then
      Return "4.6.2 or later"
    End If
    If releaseKey >= 394254 Then
      Return "4.6.1 or later"
    End If
    If releaseKey >= 393295 Then
      Return "4.6 or later"
    End If
    If releaseKey >= 393273 Then
      Return "4.6 RC or later"
    End If
    If releaseKey >= 379893 Then
      Return "4.5.2 or later"
    End If
    If releaseKey >= 378675 Then
      Return "4.5.1 or later"
    End If
    If releaseKey >= 378389 Then
      Return "4.5 or later"
    End If
    ' This line should never execute. A non-null release key should mean 
    ' that 4.5 or later is installed. 
    Return "No 4.5 or later version detected"
  End Function
  Public Function CheckFileExists(ByVal FileName As String) As Boolean

    Dim Results As String

    CheckFileExists = False
    Results = ""
    Try
      Results = Dir(FileName)
    Catch
    End Try

    If Results <> "" Then
      CheckFileExists = True
    End If

    Return CheckFileExists

  End Function
  Private Sub BtnNET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNET.Click
    LaunchEXE("NET")
  End Sub
  Private Sub BtnCR13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCR13.Click
    If IntPtr.Size = 8 Then
      LaunchEXE("CR13-64")
    Else
      LaunchEXE("CR13-32")
    End If
  End Sub
  Public Sub LaunchEXE(ByVal WrkName As String)
    Dim WrkEXE As String

    Select Case WrkName
      Case "CR13-32"
        WrkEXE = WrkDirName & cCR13_32
      Case "CR13-64"
        WrkEXE = WrkDirName & cCR13_64
      Case Else
        WrkEXE = ""
    End Select
    If WrkEXE = "" Then Exit Sub

    Try
      System.Diagnostics.Process.Start(WrkEXE)
    Catch
      MsgBox("Error running program " & WrkEXE & vbCrLf & "Please contact Hotline", MsgBoxStyle.Critical, "Program error")
    End Try
  End Sub

  Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
    CheckVersions()
  End Sub
End Class
