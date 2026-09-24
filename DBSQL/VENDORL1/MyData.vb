Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "VENDOR"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewSort(ByVal Sort As String, ByVal ShowSusp As Boolean, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkAcrec As String

    WrkTop = String.Empty
    If NumRecs > 0 Then
      WrkTop = " TOP " & NumRecs
    End If
    If ShowSusp Then
      WrkAcrec = ""
    Else
      WrkAcrec = " and ACREC<>'S'"
    End If
    StrSQL = "Select " & WrkTop & "vndnr, vennm, vadd1, vadd2, vadd3, vadd4, vsort,acrec from " & cFileName &
     " where vsort>='" & Sort & "' " & WrkAcrec & " order by vsort,vennm"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds

  End Function
  Public Function GetViewbyNameScan(ByVal Sort As String, ByVal ShowSusp As Boolean, NumRecs As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkAcrec As String

    WrkTop = String.Empty
    If NumRecs > 0 Then
      WrkTop = " TOP " & NumRecs
    End If
    If ShowSusp Then
      WrkAcrec = ""
    Else
      WrkAcrec = " and ACREC<>'S'"
    End If


    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr, vennm, vadd1, vadd2, vadd3, vadd4, vsort,acrec from " & cFileName _
    & " where vsort  LIKE '%" & Sort & "%'  order by vsort,vennm"


    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region
#Region "Properties: Get/Put"
#End Region

#Region "Properties: Fields"
  Dim mRecordNotFound As Boolean
  Public Property RecordNotFound() As Boolean
    Set(ByVal value As Boolean)
      mRecordNotFound = value
    End Set
    Get
      Return mRecordNotFound
    End Get
  End Property
  Dim mIsEOF As Boolean
  Public Property IsEOF() As Boolean
    Set(ByVal value As Boolean)
      mIsEOF = value
    End Set
    Get
      Return mIsEOF
    End Get
  End Property
  Dim mErrMsg As String
  Public Property ErrMsg() As String
    Get
      Return mErrMsg
    End Get
    Set(ByVal value As String)
      mErrMsg = value
    End Set
  End Property
#End Region
End Class

