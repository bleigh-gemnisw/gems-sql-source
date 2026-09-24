Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "MRHST"
#Region "Constructors"

  Public Sub New()
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
      _STATUS = .Item("STATUS")
      _BCHNO = .Item("BCHNO")
      _DESCR = .Item("DESCR")
      _RECDT = .Item("RECDT")
      _STRDT = .Item("STRDT")
      _ENDDT = .Item("ENDDT")
      _CODE = .Item("CODE")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _TOTAL = .Item("TOTAL")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
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
Dim mSTATUS As String
Public Property _STATUS As String
    Get
        Return mSTATUS
    End Get
    Set(ByVal value As String)
        mSTATUS = value
    End Set
End Property
Dim mBCHNO As Integer
Public Property _BCHNO As Integer
    Get
        Return mBCHNO
    End Get
    Set(ByVal value As Integer)
        mBCHNO = value
    End Set
End Property
Dim mDESCR As String
Public Property _DESCR As String
    Get
        Return mDESCR
    End Get
    Set(ByVal value As String)
        mDESCR = value
    End Set
End Property
Dim mRECDT As Integer
Public Property _RECDT As Integer
    Get
        Return mRECDT
    End Get
    Set(ByVal value As Integer)
        mRECDT = value
    End Set
End Property
Dim mSTRDT As Integer
Public Property _STRDT As Integer
    Get
        Return mSTRDT
    End Get
    Set(ByVal value As Integer)
        mSTRDT = value
    End Set
End Property
Dim mENDDT As Integer
Public Property _ENDDT As Integer
    Get
        Return mENDDT
    End Get
    Set(ByVal value As Integer)
        mENDDT = value
    End Set
End Property
Dim mCODE As String
Public Property _CODE As String
    Get
        Return mCODE
    End Get
    Set(ByVal value As String)
        mCODE = value
    End Set
End Property
Dim mCASH As Decimal
Public Property _CASH As Decimal
    Get
        Return mCASH
    End Get
    Set(ByVal value As Decimal)
        mCASH = value
    End Set
End Property
Dim mCHECK As Decimal
Public Property _CHECK As Decimal
    Get
        Return mCHECK
    End Get
    Set(ByVal value As Decimal)
        mCHECK = value
    End Set
End Property
  Dim mCREDIT As Decimal
  Public Property _CREDIT As Decimal
    Get
      Return mCREDIT
    End Get
    Set(ByVal value As Decimal)
      mCREDIT = value
    End Set
  End Property
  Dim mTOTAL As Decimal
  Public Property _TOTAL As Decimal
    Get
        Return mTOTAL
    End Get
    Set(ByVal value As Decimal)
        mTOTAL = value
    End Set
End Property
Dim mPRF As String
Public Property _PRF As String
    Get
        Return mPRF
    End Get
    Set(ByVal value As String)
        mPRF = value
    End Set
End Property
Dim mCHDATE As Integer
Public Property _CHDATE As Integer
    Get
        Return mCHDATE
    End Get
    Set(ByVal value As Integer)
        mCHDATE = value
    End Set
End Property
Dim mCHTIME As Integer
Public Property _CHTIME As Integer
    Get
        Return mCHTIME
    End Get
    Set(ByVal value As Integer)
        mCHTIME = value
    End Set
End Property
#End Region

End Class

