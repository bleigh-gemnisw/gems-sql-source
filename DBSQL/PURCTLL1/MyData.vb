Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "PURCTL"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetFscyr(ByVal WrkDate As Integer) As Integer
  Dim Fscyr As Integer
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where fscs8<=" & WrkDate & _
  " and fsce8>=" & WrkDate & " order by fscs8"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      Fscyr = 0
    Else
      Fscyr = ds.Tables(0).Rows(0).Item("fscyr")
    End If
    objCommand = Nothing
    ds.Clear()
    ds = Nothing
    Conn.Close()
  Catch ex As Exception
    ErrMsg = ex.ToString()
  End Try
  Return Fscyr
End Function
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
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
Dim mFSCSD As Integer
Public Property _FSCSD As Integer
    Get
        Return mFSCSD
    End Get
    Set(ByVal value As Integer)
        mFSCSD = value
    End Set
End Property

Dim mFSCED As Integer
Public Property _FSCED As Integer
    Get
        Return mFSCED
    End Get
    Set(ByVal value As Integer)
        mFSCED = value
    End Set
End Property

Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property

Dim mNXTPO As Integer
Public Property _NXTPO As Integer
    Get
        Return mNXTPO
    End Get
    Set(ByVal value As Integer)
        mNXTPO = value
    End Set
End Property

Dim mDYORD As Integer
Public Property _DYORD As Integer
    Get
        Return mDYORD
    End Get
    Set(ByVal value As Integer)
        mDYORD = value
    End Set
End Property

Dim mFSCS8 As Integer
Public Property _FSCS8 As Integer
    Get
        Return mFSCS8
    End Get
    Set(ByVal value As Integer)
        mFSCS8 = value
    End Set
End Property

Dim mFSCE8 As Integer
Public Property _FSCE8 As Integer
    Get
        Return mFSCE8
    End Get
    Set(ByVal value As Integer)
        mFSCE8 = value
    End Set
End Property

#End Region

End Class

