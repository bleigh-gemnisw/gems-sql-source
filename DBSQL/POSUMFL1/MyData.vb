Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "POSUMF"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetAllPONo(ByVal WrkFscyr As Integer, ByVal WrkPonbr As Integer, _
 ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  RecordNotFound = False
  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where fscyr =" & WrkFscyr & " and ponbr=" & WrkPonbr _
    & " order by fscyr,ponbr"
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
Public Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FSCYR = .Item("FSCYR")
    _PONBR = .Item("PONBR")
    _ACCT = .Item("ACCT")
    _POAMT = .Item("POAMT")
    _POOPN = .Item("POOPN")
    _POPAD = .Item("POPAD")
    _POLIQ = .Item("POLIQ")
    _ODACT = .Item("ODACT")
  End With
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
Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property
Dim mPONBR As Integer
Public Property _PONBR As Integer
    Get
        Return mPONBR
    End Get
    Set(ByVal value As Integer)
        mPONBR = value
    End Set
End Property
  Dim mACCT As Decimal
  Public Property _ACCT As Decimal
    Get
      Return mACCT
    End Get
    Set(ByVal value As Decimal)
      mACCT = value
    End Set
  End Property
  Dim mPOAMT As Decimal
  Public Property _POAMT As Decimal
    Get
        Return mPOAMT
    End Get
    Set(ByVal value As Decimal)
        mPOAMT = value
    End Set
End Property
Dim mPOOPN As Decimal
Public Property _POOPN As Decimal
    Get
        Return mPOOPN
    End Get
    Set(ByVal value As Decimal)
        mPOOPN = value
    End Set
End Property
Dim mPOPAD As Decimal
Public Property _POPAD As Decimal
    Get
        Return mPOPAD
    End Get
    Set(ByVal value As Decimal)
        mPOPAD = value
    End Set
End Property
Dim mPOLIQ As String
Public Property _POLIQ As String
    Get
        Return mPOLIQ
    End Get
    Set(ByVal value As String)
        mPOLIQ = value
    End Set
End Property
Dim mODACT As Double
Public Property _ODACT As Double
    Get
        Return mODACT
    End Get
    Set(ByVal value As Double)
        mODACT = value
    End Set
End Property
#End Region
End Class

