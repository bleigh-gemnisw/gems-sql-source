Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "CKHIST"
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
      _EMPNO = .Item("EMPNO")
      _PORV = .Item("PORV")
      _EMNAME = .Item("EMNAME")
      _CKNUM = .Item("CKNUM")
      _CKDATE = .Item("CKDATE")
      _CKAMT = .Item("CKAMT")
      _CKCODE = .Item("CKCODE")
      _CHKDTE = .Item("CHKDTE")
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
  Dim mEMPNO As String
  Public Property _EMPNO As String
    Get
      Return mEMPNO
    End Get
    Set(ByVal value As String)
      mEMPNO = value
    End Set
  End Property

  Dim mPORV As String
  Public Property _PORV As String
    Get
      Return mPORV
    End Get
    Set(ByVal value As String)
      mPORV = value
    End Set
  End Property

  Dim mEMNAME As String
  Public Property _EMNAME As String
    Get
      Return mEMNAME
    End Get
    Set(ByVal value As String)
      mEMNAME = value
    End Set
  End Property

  Dim mCKNUM As Integer
  Public Property _CKNUM As Integer
    Get
      Return mCKNUM
    End Get
    Set(ByVal value As Integer)
      mCKNUM = value
    End Set
  End Property

  Dim mCKDATE As Integer
  Public Property _CKDATE As Integer
    Get
      Return mCKDATE
    End Get
    Set(ByVal value As Integer)
      mCKDATE = value
    End Set
  End Property
  Dim mCKAMT As Decimal
  Public Property _CKAMT As Decimal
    Get
      Return mCKAMT
    End Get
    Set(ByVal value As Decimal)
      mCKAMT = value
    End Set
  End Property

  Dim mCKCODE As String
  Public Property _CKCODE As String
    Get
      Return mCKCODE
    End Get
    Set(ByVal value As String)
      mCKCODE = value
    End Set
  End Property
  Dim mCHKDTE As Integer
  Public Property _CHKDTE As Integer
    Get
      Return mCHKDTE
    End Get
    Set(ByVal value As Integer)
      mCHKDTE = value
    End Set
  End Property
#End Region
End Class
