Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "MFPRKH"
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
      _MFCATG = .Item("MFCATG")
      _MFNAM = .Item("MFNAM")
      _MFADD1 = .Item("MFADD1")
      _MFYEAR = .Item("MFYEAR")
      _MFPERNo = .Item("MFPER#")
      _MFLISS = .Item("MFLISS")
      _MFTDAT = .Item("MFTDAT")
      _MFTTIM = .Item("MFTTIM")
      _MFLFEE = .Item("MFLFEE")
      _MFCOMM = .Item("MFCOMM")
      _STAMPD = .Item("STAMPD")
      _STAMPT = .Item("STAMPT")
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
  Dim mMFCATG As String
  Public Property _MFCATG As String
    Get
      Return mMFCATG
    End Get
    Set(ByVal value As String)
      mMFCATG = value
    End Set
  End Property

  Dim mMFNAM As String
  Public Property _MFNAM As String
    Get
      Return mMFNAM
    End Get
    Set(ByVal value As String)
      mMFNAM = value
    End Set
  End Property

  Dim mMFADD1 As String
  Public Property _MFADD1 As String
    Get
      Return mMFADD1
    End Get
    Set(ByVal value As String)
      mMFADD1 = value
    End Set
  End Property

  Dim mMFYEAR As Integer
  Public Property _MFYEAR As Integer
    Get
      Return mMFYEAR
    End Get
    Set(ByVal value As Integer)
      mMFYEAR = value
    End Set
  End Property

  Dim mMFPERNo As Integer
  Public Property _MFPERNo As Integer
    Get
      Return mMFPERNo
    End Get
    Set(ByVal value As Integer)
      mMFPERNo = value
    End Set
  End Property

  Dim mMFLISS As Integer
  Public Property _MFLISS As Integer
    Get
      Return mMFLISS
    End Get
    Set(ByVal value As Integer)
      mMFLISS = value
    End Set
  End Property

  Dim mMFTDAT As Integer
  Public Property _MFTDAT As Integer
    Get
      Return mMFTDAT
    End Get
    Set(ByVal value As Integer)
      mMFTDAT = value
    End Set
  End Property

  Dim mMFTTIM As Integer
  Public Property _MFTTIM As Integer
    Get
      Return mMFTTIM
    End Get
    Set(ByVal value As Integer)
      mMFTTIM = value
    End Set
  End Property

  Dim mMFLFEE As Decimal
  Public Property _MFLFEE As Decimal
    Get
      Return mMFLFEE
    End Get
    Set(ByVal value As Decimal)
      mMFLFEE = value
    End Set
  End Property

  Dim mMFCOMM As String
  Public Property _MFCOMM As String
    Get
      Return mMFCOMM
    End Get
    Set(ByVal value As String)
      mMFCOMM = value
    End Set
  End Property

  Dim mSTAMPD As Integer
  Public Property _STAMPD As Integer
    Get
      Return mSTAMPD
    End Get
    Set(ByVal value As Integer)
      mSTAMPD = value
    End Set
  End Property

  Dim mSTAMPT As Integer
  Public Property _STAMPT As Integer
    Get
      Return mSTAMPT
    End Get
    Set(ByVal value As Integer)
      mSTAMPT = value
    End Set
  End Property
#End Region

End Class

