Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "POSUMF"
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
Public Sub SumPaidQry(ByVal WrkGroup As String, ByVal WrkSort As String, ByVal WrkQry As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand

  StrSQL = "Select vndnr, sum(amtpd) as amtpd from " & cFileName
  If WrkQry <> String.Empty Then
    StrSQL = StrSQL & " where " & WrkQry
  End If
  If WrkGroup <> String.Empty Then
    StrSQL = StrSQL & " Group by " & WrkGroup
  End If
  If WrkSort <> String.Empty Then
    StrSQL = StrSQL & " Order by " & WrkSort
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
Dim mODACT As ULong
Public Property _ODACT As ULong
    Get
        Return mODACT
    End Get
    Set(ByVal value As ULong)
        mODACT = value
    End Set
End Property
#End Region

End Class

