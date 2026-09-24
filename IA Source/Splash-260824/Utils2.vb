Imports System.ComponentModel
Imports System.Text
Imports System.Drawing.Imaging
Imports system.Drawing.Printing
Module Utils2
Public Function CheckFileExists(ByVal FileName As String) As Boolean

  Dim Results As String

  CheckFileExists = False
  Results = Dir(FileName)

  If Results <> "" Then
    CheckFileExists = True
  End If

  Return CheckFileExists

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
Public Function GetComputerName() As String
    Dim WrkComputerName As String
    WrkComputerName = System.Environment.MachineName
    Return WrkComputerName
End Function

End Module
