
Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTTYPE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetAllData() As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName
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
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"
#End Region


#Region "Properties: Fields"

Dim mTYTYPE as string 
Public Property _TYTYPE as string   
    Get
        Return mTYTYPE
    End Get
    set(byval value as string)
        mTYTYPE = value
    End Set
End Property

Dim mTYDESC as string 
Public Property _TYDESC as string   
    Get
        Return mTYDESC
    End Get
    set(byval value as string)
        mTYDESC = value
    End Set
End Property

Dim mTYTXTP as string 
Public Property _TYTXTP as string   
    Get
        Return mTYTXTP
    End Get
    set(byval value as string)
        mTYTXTP = value
    End Set
End Property

Dim mTYUTTP as string 
Public Property _TYUTTP as string   
    Get
        Return mTYUTTP
    End Get
    set(byval value as string)
        mTYUTTP = value
    End Set
End Property

Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class

