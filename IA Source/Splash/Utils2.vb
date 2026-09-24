Imports System.ComponentModel
Imports System.Text
Imports System.Drawing.Imaging
Imports system.Drawing.Printing
Module Utils2
  Public Function CheckFileExists(ByVal FileName As String) As Boolean
    If String.IsNullOrWhiteSpace(FileName) Then
      Return False
    End If

    Return IO.File.Exists(FileName)
  End Function
  Public Function GetDataPath() As String

    Dim WrkFileName As String =
        System.Reflection.Assembly.GetExecutingAssembly().Location

    Dim DataPath As String =
        IO.Path.GetDirectoryName(WrkFileName)

    Return DataPath.TrimEnd(IO.Path.DirectorySeparatorChar,
                            IO.Path.AltDirectorySeparatorChar) &
           IO.Path.DirectorySeparatorChar
  End Function
  Public Function GetComputerName() As String
    Dim WrkComputerName As String
    WrkComputerName = System.Environment.MachineName
    Return WrkComputerName
  End Function
End Module
