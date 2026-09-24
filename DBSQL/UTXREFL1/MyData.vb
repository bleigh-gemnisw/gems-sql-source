
Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTXREF"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetXRef(ByVal WrkXRef As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cxref='" & WrkXRef & "'"
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

Dim mCXACCT  as integer 
Public Property _CXACCT  as integer   
    Get
        Return mCXACCT
    End Get
    set(byval value as integer)
        mCXACCT = value
    End Set
End Property

Dim mCXCODE as string 
Public Property _CXCODE as string   
    Get
        Return mCXCODE
    End Get
    set(byval value as string)
        mCXCODE = value
    End Set
End Property

Dim mCXREF as string 
Public Property _CXREF as string   
    Get
        Return mCXREF
    End Get
    set(byval value as string)
        mCXREF = value
    End Set
End Property
  Dim mCXUSE As String
  Public Property _CXUSE As String
    Get
      Return mCXUSE
    End Get
    Set(ByVal value As String)
      mCXUSE = value
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

