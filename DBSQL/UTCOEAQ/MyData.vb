Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "UTCOEA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal NumRecs As Long) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)

    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
    End If
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
  Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Select * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objReader = objCommand.ExecuteReader()
  End Sub
  Public Sub ReadQry()
    Dim Good As Boolean

    IsEOF = False
    Good = objReader.Read
    If Good Then
      GetFields()
    Else
      IsEOF = True
      objReader.Close()
    End If
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields()
    With objReader
      _CCNO = .Item("CCNO")
      _YEAR = .Item("YEAR")
      _LISTNO = .Item("LIST#")
      _TYPE = .Item("TYPE")
      _NAME = .Item("NAME")
      _DIST = .Item("DIST")
      _RSNCD = .Item("RSNCD")
      _CDATE = .Item("CDATE")
      _CDESC = .Item("CDESC")
      _CETAX = .Item("CETAX")
      _CETAX1 = .Item("CETAX1")
      _CETAX2 = .Item("CETAX2")
      _CETAX3 = .Item("CETAX3")
      _CETAX4 = .Item("CETAX4")
      _COBOND = .Item("COBOND")
      _CNBOND = .Item("CNBOND")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
    End With
  End Sub
#End Region

#Region "Properties: Fields"

  Dim mCCNO  as integer 
Public Property _CCNO  as integer   
    Get
        Return mCCNO
    End Get
    set(byval value as integer)
        mCCNO = value
    End Set
End Property

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mLISTNO  as integer 
Public Property _LISTNO  as integer   
    Get
        Return mLISTNO
    End Get
    set(byval value as integer)
        mLISTNO = value
    End Set
End Property

Dim mTYPE as string 
Public Property _TYPE as string   
    Get
        Return mTYPE
    End Get
    set(byval value as string)
        mTYPE = value
    End Set
End Property

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
    End Set
End Property

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
    End Set
End Property

Dim mRSNCD as string 
Public Property _RSNCD as string   
    Get
        Return mRSNCD
    End Get
    set(byval value as string)
        mRSNCD = value
    End Set
End Property

Dim mCDATE  as integer 
Public Property _CDATE  as integer   
    Get
        Return mCDATE
    End Get
    set(byval value as integer)
        mCDATE = value
    End Set
End Property

Dim mCDESC as string 
Public Property _CDESC as string   
    Get
        Return mCDESC
    End Get
    set(byval value as string)
        mCDESC = value
    End Set
End Property

  Dim mCETAX As Decimal
  Public Property _CETAX As Decimal
    Get
      Return mCETAX
    End Get
    Set(ByVal value As Decimal)
      mCETAX = value
    End Set
  End Property

  Dim mCETAX1 As Decimal
  Public Property _CETAX1 As Decimal
    Get
      Return mCETAX1
    End Get
    Set(ByVal value As Decimal)
      mCETAX1 = value
    End Set
  End Property

  Dim mCETAX2 As Decimal
  Public Property _CETAX2 As Decimal
    Get
      Return mCETAX2
    End Get
    Set(ByVal value As Decimal)
      mCETAX2 = value
    End Set
  End Property

  Dim mCETAX3 As Decimal
  Public Property _CETAX3 As Decimal
    Get
      Return mCETAX3
    End Get
    Set(ByVal value As Decimal)
      mCETAX3 = value
    End Set
  End Property

  Dim mCETAX4 As Decimal
  Public Property _CETAX4 As Decimal
    Get
      Return mCETAX4
    End Get
    Set(ByVal value As Decimal)
      mCETAX4 = value
    End Set
  End Property

  Dim mCOBOND As Decimal
  Public Property _COBOND As Decimal
    Get
      Return mCOBOND
    End Get
    Set(ByVal value As Decimal)
      mCOBOND = value
    End Set
  End Property

  Dim mCNBOND As Decimal
  Public Property _CNBOND As Decimal
    Get
      Return mCNBOND
    End Get
    Set(ByVal value As Decimal)
      mCNBOND = value
    End Set
  End Property

Dim mPRF as string 
Public Property _PRF as string   
    Get
        Return mPRF
    End Get
    set(byval value as string)
        mPRF = value
    End Set
End Property

Dim mCHDATE  as integer 
Public Property _CHDATE  as integer   
    Get
        Return mCHDATE
    End Get
    set(byval value as integer)
        mCHDATE = value
    End Set
End Property

Dim mCHTIME  as integer 
Public Property _CHTIME  as integer   
    Get
        Return mCHTIME
    End Get
    set(byval value as integer)
        mCHTIME = value
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


