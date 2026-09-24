Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "GLACCT"
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
  objCommand = Nothing
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
      _ACREC = .Item("ACREC")
      _FDNBR = .Item("FDNBR")
      _DPNBR = .Item("DPNBR")
      _OBNBR = .Item("OBNBR")
      _FNPGM = .Item("FNPGM")
      _SUBFN = .Item("SUBFN")
      _GLDSC = .Item("GLDSC")
      _GLTYP = .Item("GLTYP")
      _NONPR = .Item("NONPR")
      _FIL02 = .Item("FIL02")
      _CSHYN = .Item("CSHYN")
      _RLNBR = .Item("RLNBR")
      _FIL03 = .Item("FIL03")
      _SFUND = .Item("SFUND")
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
  Dim mACREC As String
  Public Property _ACREC As String
    Get
      Return mACREC
    End Get
    Set(ByVal value As String)
      mACREC = value
    End Set
  End Property
  Dim mFDNBR As Integer
  Public Property _FDNBR As Integer
    Get
      Return mFDNBR
    End Get
    Set(ByVal value As Integer)
      mFDNBR = value
    End Set
  End Property
  Dim mDPNBR As Integer
  Public Property _DPNBR As Integer
    Get
      Return mDPNBR
    End Get
    Set(ByVal value As Integer)
      mDPNBR = value
    End Set
  End Property
  Dim mOBNBR As Integer
  Public Property _OBNBR As Integer
    Get
      Return mOBNBR
    End Get
    Set(ByVal value As Integer)
      mOBNBR = value
    End Set
  End Property
  Dim mFNPGM As Integer
  Public Property _FNPGM As Integer
    Get
      Return mFNPGM
    End Get
    Set(ByVal value As Integer)
      mFNPGM = value
    End Set
  End Property
  Dim mSUBFN As Integer
  Public Property _SUBFN As Integer
    Get
      Return mSUBFN
    End Get
    Set(ByVal value As Integer)
      mSUBFN = value
    End Set
  End Property
  Dim mGLDSC As String
  Public Property _GLDSC As String
    Get
      Return mGLDSC
    End Get
    Set(ByVal value As String)
      mGLDSC = value
    End Set
  End Property
  Dim mGLTYP As String
  Public Property _GLTYP As String
    Get
      Return mGLTYP
    End Get
    Set(ByVal value As String)
      mGLTYP = value
    End Set
  End Property
  Dim mNONPR As String
  Public Property _NONPR As String
    Get
      Return mNONPR
    End Get
    Set(ByVal value As String)
      mNONPR = value
    End Set
  End Property
  Dim mFIL02 As String
  Public Property _FIL02 As String
    Get
      Return mFIL02
    End Get
    Set(ByVal value As String)
      mFIL02 = value
    End Set
  End Property
  Dim mCSHYN As String
  Public Property _CSHYN As String
    Get
      Return mCSHYN
    End Get
    Set(ByVal value As String)
      mCSHYN = value
    End Set
  End Property
  Dim mRLNBR As Integer
  Public Property _RLNBR As Integer
    Get
      Return mRLNBR
    End Get
    Set(ByVal value As Integer)
      mRLNBR = value
    End Set
  End Property
  Dim mFIL03 As String
  Public Property _FIL03 As String
    Get
      Return mFIL03
    End Get
    Set(ByVal value As String)
      mFIL03 = value
    End Set
  End Property
  Dim mSFUND As Integer
  Public Property _SFUND As Integer
    Get
      Return mSFUND
    End Get
    Set(ByVal value As Integer)
      mSFUND = value
    End Set
  End Property
#End Region

End Class

