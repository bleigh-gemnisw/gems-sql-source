Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "APERCN"
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
    _PAYBN = .Item("PAYBN")
    _PAYCK = .Item("PAYCK")
    _PAYAM = .Item("PAYAM")
    _VNDNR = .Item("VNDNR")
    _RCCDE = .Item("RCCDE")
    _PAYCM = .Item("PAYCM")
    _MANUL = .Item("MANUL")
    _PENDC = .Item("PENDC")
    _BANKRP = .Item("BANKRP")
    _PAYP8 = .Item("PAYP8")
    _PAYC8 = .Item("PAYC8")
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
Dim mPAYBN As String
Public Property _PAYBN As String
    Get
        Return mPAYBN
    End Get
    Set(ByVal value As String)
        mPAYBN = value
    End Set
End Property
Dim mPAYCK As Integer
Public Property _PAYCK As Integer
    Get
        Return mPAYCK
    End Get
    Set(ByVal value As Integer)
        mPAYCK = value
    End Set
End Property
Dim mPAYAM As Decimal
Public Property _PAYAM As Decimal
    Get
        Return mPAYAM
    End Get
    Set(ByVal value As Decimal)
        mPAYAM = value
    End Set
End Property
Dim mVNDNR As String
Public Property _VNDNR As String
    Get
        Return mVNDNR
    End Get
    Set(ByVal value As String)
        mVNDNR = value
    End Set
End Property
Dim mRCCDE As String
Public Property _RCCDE As String
    Get
        Return mRCCDE
    End Get
    Set(ByVal value As String)
        mRCCDE = value
    End Set
End Property
Dim mPAYCM As Decimal
Public Property _PAYCM As Decimal
    Get
        Return mPAYCM
    End Get
    Set(ByVal value As Decimal)
        mPAYCM = value
    End Set
End Property
Dim mMANUL As String
Public Property _MANUL As String
    Get
        Return mMANUL
    End Get
    Set(ByVal value As String)
        mMANUL = value
    End Set
End Property
Dim mPENDC As String
Public Property _PENDC As String
    Get
        Return mPENDC
    End Get
    Set(ByVal value As String)
        mPENDC = value
    End Set
End Property
Dim mBANKRP As String
Public Property _BANKRP As String
    Get
        Return mBANKRP
    End Get
    Set(ByVal value As String)
        mBANKRP = value
    End Set
End Property
Dim mPAYP8 As Integer
Public Property _PAYP8 As Integer
    Get
        Return mPAYP8
    End Get
    Set(ByVal value As Integer)
        mPAYP8 = value
    End Set
End Property
Dim mPAYC8 As Integer
Public Property _PAYC8 As Integer
    Get
        Return mPAYC8
    End Get
    Set(ByVal value As Integer)
        mPAYC8 = value
    End Set
End Property
#End Region

End Class

