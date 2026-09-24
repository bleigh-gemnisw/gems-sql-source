Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXPHIA"

#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNo = 0
    _TXYEAR = 0   'LL new addition cloning from TXPHIN
    _CAPGRS = 0
    _CAPA1 = 0
    _CAPA2 = 0
    _CAPA3 = 0
    _CAPA4 = 0
    _CAPA5 = 0
    _CAPA6 = 0
    _CAPA7 = 0
    _CAPC1 = 0
    _CAPC2 = 0
    _CAPC3 = 0
    _CAPC4 = 0
    _CAPC5 = 0
    _CAPC6 = 0
    _CAPC7 = 0
    _ORIGRS = 0
    _FULGRS = 0
    _ADJGRS = 0
    _ADJA1 = 0
    _ADJA2 = 0
    _ADJA3 = 0
    _ADJA4 = 0
    _ADJA5 = 0
    _ADJA6 = 0
    _ADJA7 = 0
    _ADJC1 = 0
    _ADJC2 = 0
    _ADJC3 = 0
    _ADJC4 = 0
    _ADJC5 = 0
    _ADJC6 = 0
    _ADJC7 = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkplistno As Integer, ByVal Wrktxyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrkplistno & " and txyear = " & Wrktxyear
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function GetIsPosted(ByVal WrkYear As Integer) As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkResult As Integer

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where txyear = " & WrkYear
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      If ds.Tables(0).Rows.Count = 0 Then
        WrkResult = 0
      Else
        WrkResult = 1
      End If
      Return WrkResult
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub ArchiveQry(ByVal WrkYear As Integer)
    Dim Conn As SqlConnection = Nothing
    Dim objCommand As SqlCommand
    Dim rowsAffected As Integer
    Dim StrSQL As String
    Dim targetColumns As String = "[LIST#], TXYEAR, CAPGRS, CAPA1, CAPA2, CAPA3, CAPA4, CAPA5, CAPA6, CAPA7, " &
      "CAPC1, CAPC2, CAPC3, CAPC4, CAPC5, CAPC6, CAPC7, ORIGRS, FULGRS, ADJGRS, " &
      "ADJA1, ADJA2, ADJA3, ADJA4, ADJA5, ADJA6, ADJA7, ADJC1, ADJC2, ADJC3, ADJC4, ADJC5, ADJC6, ADJC7, AFTGRS, " &
      "AFTA1, AFTA2, AFTA3, AFTA4, AFTA5, AFTA6, AFTA7, AFTC1, AFTC2, AFTC3, AFTC4, AFTC5, AFTC6, AFTC7"
    ' 1. Define the INSERT INTO ... SELECT query
    ' We use a multi-line string or concatenation for readability
    StrSQL = "INSERT INTO TXPHIA (" & targetColumns & ") " &
             "Select " & targetColumns & " FROM TXPHIN WHERE TXYEAR = " & WrkYear
    Try
      Conn = MyDBConn.Open()
      objCommand = New SqlCommand(StrSQL, Conn)

      ' ExecuteNonQuery is the correct method for INSERT statements
      rowsAffected = objCommand.ExecuteNonQuery()

      Console.WriteLine(rowsAffected & " rows archived.")

    Catch ex As Exception
      ErrMsg = ex.Message
    Finally
      ' 4. Ensure the connection closes even if an error occurs
      If Conn IsNot Nothing AndAlso Conn.State = ConnectionState.Open Then
        Conn.Close()
      End If
    End Try
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _LISTNo = .Item("LIST#")
      _TXYEAR = .Item("TXYEAR")    'LL new addition cloning from TXPHIN
      _CAPGRS = .Item("CAPGRS")
      _CAPA1 = .Item("CAPA1")
      _CAPA2 = .Item("CAPA2")
      _CAPA3 = .Item("CAPA3")
      _CAPA4 = .Item("CAPA4")
      _CAPA5 = .Item("CAPA5")
      _CAPA6 = .Item("CAPA6")
      _CAPA7 = .Item("CAPA7")
      _CAPC1 = .Item("CAPC1")
      _CAPC2 = .Item("CAPC2")
      _CAPC3 = .Item("CAPC3")
      _CAPC4 = .Item("CAPC4")
      _CAPC5 = .Item("CAPC5")
      _CAPC6 = .Item("CAPC6")
      _CAPC7 = .Item("CAPC7")
      _ORIGRS = .Item("ORIGRS")
      _FULGRS = .Item("FULGRS")
      _ADJGRS = .Item("ADJGRS")
      _ADJA1 = .Item("ADJA1")
      _ADJA2 = .Item("ADJA2")
      _ADJA3 = .Item("ADJA3")
      _ADJA4 = .Item("ADJA4")
      _ADJA5 = .Item("ADJA5")
      _ADJA6 = .Item("ADJA6")
      _ADJA7 = .Item("ADJA7")
      _ADJC1 = .Item("ADJC1")
      _ADJC2 = .Item("ADJC2")
      _ADJC3 = .Item("ADJC3")
      _ADJC4 = .Item("ADJC4")
      _ADJC5 = .Item("ADJC5")
      _ADJC6 = .Item("ADJC6")
      _ADJC7 = .Item("ADJC7")
      _AFTGRS = .Item("AFTGRS")
      _AFTA1 = .Item("AFTA1")
      _AFTA2 = .Item("AFTA2")
      _AFTA3 = .Item("AFTA3")
      _AFTA4 = .Item("AFTA4")
      _AFTA5 = .Item("AFTA5")
      _AFTA6 = .Item("AFTA6")
      _AFTA7 = .Item("AFTA7")
      _AFTC1 = .Item("AFTC1")
      _AFTC2 = .Item("AFTC2")
      _AFTC3 = .Item("AFTC3")
      _AFTC4 = .Item("AFTC4")
      _AFTC5 = .Item("AFTC5")
      _AFTC6 = .Item("AFTC6")
      _AFTC7 = .Item("AFTC7")
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property

  Dim mCAPGRS As Long
  Public Property _CAPGRS As Long
    Get
      Return mCAPGRS
    End Get
    Set(ByVal value As Long)
      mCAPGRS = value
    End Set
  End Property

  Dim mCAPA1 As Long
  Public Property _CAPA1 As Long
    Get
      Return mCAPA1
    End Get
    Set(ByVal value As Long)
      mCAPA1 = value
    End Set
  End Property

  Dim mCAPA2 As Long
  Public Property _CAPA2 As Long
    Get
      Return mCAPA2
    End Get
    Set(ByVal value As Long)
      mCAPA2 = value
    End Set
  End Property

  Dim mCAPA3 As Long
  Public Property _CAPA3 As Long
    Get
      Return mCAPA3
    End Get
    Set(ByVal value As Long)
      mCAPA3 = value
    End Set
  End Property

  Dim mCAPA4 As Long
  Public Property _CAPA4 As Long
    Get
      Return mCAPA4
    End Get
    Set(ByVal value As Long)
      mCAPA4 = value
    End Set
  End Property

  Dim mCAPA5 As Long
  Public Property _CAPA5 As Long
    Get
      Return mCAPA5
    End Get
    Set(ByVal value As Long)
      mCAPA5 = value
    End Set
  End Property

  Dim mCAPA6 As Long
  Public Property _CAPA6 As Long
    Get
      Return mCAPA6
    End Get
    Set(ByVal value As Long)
      mCAPA6 = value
    End Set
  End Property

  Dim mCAPA7 As Long
  Public Property _CAPA7 As Long
    Get
      Return mCAPA7
    End Get
    Set(ByVal value As Long)
      mCAPA7 = value
    End Set
  End Property

  Dim mCAPC1 As Integer
  Public Property _CAPC1 As Integer
    Get
      Return mCAPC1
    End Get
    Set(ByVal value As Integer)
      mCAPC1 = value
    End Set
  End Property

  Dim mCAPC2 As Integer
  Public Property _CAPC2 As Integer
    Get
      Return mCAPC2
    End Get
    Set(ByVal value As Integer)
      mCAPC2 = value
    End Set
  End Property

  Dim mCAPC3 As Integer
  Public Property _CAPC3 As Integer
    Get
      Return mCAPC3
    End Get
    Set(ByVal value As Integer)
      mCAPC3 = value
    End Set
  End Property

  Dim mCAPC4 As Integer
  Public Property _CAPC4 As Integer
    Get
      Return mCAPC4
    End Get
    Set(ByVal value As Integer)
      mCAPC4 = value
    End Set
  End Property

  Dim mCAPC5 As Integer
  Public Property _CAPC5 As Integer
    Get
      Return mCAPC5
    End Get
    Set(ByVal value As Integer)
      mCAPC5 = value
    End Set
  End Property

  Dim mCAPC6 As Integer
  Public Property _CAPC6 As Integer
    Get
      Return mCAPC6
    End Get
    Set(ByVal value As Integer)
      mCAPC6 = value
    End Set
  End Property

  Dim mCAPC7 As Integer
  Public Property _CAPC7 As Integer
    Get
      Return mCAPC7
    End Get
    Set(ByVal value As Integer)
      mCAPC7 = value
    End Set
  End Property
  Dim mORIGRS As Long
  Public Property _ORIGRS As Long
    Get
      Return mORIGRS
    End Get
    Set(ByVal value As Long)
      mORIGRS = value
    End Set
  End Property

  Dim mFULGRS As Long
  Public Property _FULGRS As Long
    Get
      Return mFULGRS
    End Get
    Set(ByVal value As Long)
      mFULGRS = value
    End Set
  End Property

  Dim mADJGRS As Long
  Public Property _ADJGRS As Long
    Get
      Return mADJGRS
    End Get
    Set(ByVal value As Long)
      mADJGRS = value
    End Set
  End Property

  Dim mADJA1 As Long
  Public Property _ADJA1 As Long
    Get
      Return mADJA1
    End Get
    Set(ByVal value As Long)
      mADJA1 = value
    End Set
  End Property

  Dim mADJA2 As Long
  Public Property _ADJA2 As Long
    Get
      Return mADJA2
    End Get
    Set(ByVal value As Long)
      mADJA2 = value
    End Set
  End Property

  Dim mADJA3 As Long
  Public Property _ADJA3 As Long
    Get
      Return mADJA3
    End Get
    Set(ByVal value As Long)
      mADJA3 = value
    End Set
  End Property

  Dim mADJA4 As Long
  Public Property _ADJA4 As Long
    Get
      Return mADJA4
    End Get
    Set(ByVal value As Long)
      mADJA4 = value
    End Set
  End Property

  Dim mADJA5 As Long
  Public Property _ADJA5 As Long
    Get
      Return mADJA5
    End Get
    Set(ByVal value As Long)
      mADJA5 = value
    End Set
  End Property

  Dim mADJA6 As Long
  Public Property _ADJA6 As Long
    Get
      Return mADJA6
    End Get
    Set(ByVal value As Long)
      mADJA6 = value
    End Set
  End Property

  Dim mADJA7 As Long
  Public Property _ADJA7 As Long
    Get
      Return mADJA7
    End Get
    Set(ByVal value As Long)
      mADJA7 = value
    End Set
  End Property

  Dim mADJC1 As Integer
  Public Property _ADJC1 As Integer
    Get
      Return mADJC1
    End Get
    Set(ByVal value As Integer)
      mADJC1 = value
    End Set
  End Property

  Dim mADJC2 As Integer
  Public Property _ADJC2 As Integer
    Get
      Return mADJC2
    End Get
    Set(ByVal value As Integer)
      mADJC2 = value
    End Set
  End Property

  Dim mADJC3 As Integer
  Public Property _ADJC3 As Integer
    Get
      Return mADJC3
    End Get
    Set(ByVal value As Integer)
      mADJC3 = value
    End Set
  End Property

  Dim mADJC4 As Integer
  Public Property _ADJC4 As Integer
    Get
      Return mADJC4
    End Get
    Set(ByVal value As Integer)
      mADJC4 = value
    End Set
  End Property

  Dim mADJC5 As Integer
  Public Property _ADJC5 As Integer
    Get
      Return mADJC5
    End Get
    Set(ByVal value As Integer)
      mADJC5 = value
    End Set
  End Property

  Dim mADJC6 As Integer
  Public Property _ADJC6 As Integer
    Get
      Return mADJC6
    End Get
    Set(ByVal value As Integer)
      mADJC6 = value
    End Set
  End Property

  Dim mADJC7 As Integer
  Public Property _ADJC7 As Integer
    Get
      Return mADJC7
    End Get
    Set(ByVal value As Integer)
      mADJC7 = value
    End Set
  End Property
  Dim mAFTGRS As Long
  Public Property _AFTGRS As Long
    Get
      Return mAFTGRS
    End Get
    Set(value As Long)
      mAFTGRS = value
    End Set
  End Property

  Dim mAFTA1 As Long
  Public Property _AFTA1 As Long
    Get
      Return mAFTA1
    End Get
    Set(value As Long)
      mAFTA1 = value
    End Set
  End Property

  Dim mAFTA2 As Long
  Public Property _AFTA2 As Long
    Get
      Return mAFTA2
    End Get
    Set(value As Long)
      mAFTA2 = value
    End Set
  End Property

  Dim mAFTA3 As Long
  Public Property _AFTA3 As Long
    Get
      Return mAFTA3
    End Get
    Set(value As Long)
      mAFTA3 = value
    End Set
  End Property

  Dim mAFTA4 As Long
  Public Property _AFTA4 As Long
    Get
      Return mAFTA4
    End Get
    Set(value As Long)
      mAFTA4 = value
    End Set
  End Property

  Dim mAFTA5 As Long
  Public Property _AFTA5 As Long
    Get
      Return mAFTA5
    End Get
    Set(value As Long)
      mAFTA5 = value
    End Set
  End Property

  Dim mAFTA6 As Long
  Public Property _AFTA6 As Long
    Get
      Return mAFTA6
    End Get
    Set(value As Long)
      mAFTA6 = value
    End Set
  End Property

  Dim mAFTA7 As Long
  Public Property _AFTA7 As Long
    Get
      Return mAFTA7
    End Get
    Set(value As Long)
      mAFTA7 = value
    End Set
  End Property

  Dim mAFTC1 As Integer
  Public Property _AFTC1 As Integer
    Get
      Return mAFTC1
    End Get
    Set(value As Integer)
      mAFTC1 = value
    End Set
  End Property

  Dim mAFTC2 As Integer
  Public Property _AFTC2 As Integer
    Get
      Return mAFTC2
    End Get
    Set(value As Integer)
      mAFTC2 = value
    End Set
  End Property

  Dim mAFTC3 As Integer
  Public Property _AFTC3 As Integer
    Get
      Return mAFTC3
    End Get
    Set(value As Integer)
      mAFTC3 = value
    End Set
  End Property

  Dim mAFTC4 As Integer
  Public Property _AFTC4 As Integer
    Get
      Return mAFTC4
    End Get
    Set(value As Integer)
      mAFTC4 = value
    End Set
  End Property

  Dim mAFTC5 As Integer
  Public Property _AFTC5 As Integer
    Get
      Return mAFTC5
    End Get
    Set(value As Integer)
      mAFTC5 = value
    End Set
  End Property

  Dim mAFTC6 As Integer
  Public Property _AFTC6 As Integer
    Get
      Return mAFTC6
    End Get
    Set(value As Integer)
      mAFTC6 = value
    End Set
  End Property

  Dim mAFTC7 As Integer
  Public Property _AFTC7 As Integer
    Get
      Return mAFTC7
    End Get
    Set(value As Integer)
      mAFTC7 = value
    End Set
  End Property

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
  Dim mTXYEAR As Integer   'LL new addition cloning from TXPHIN
  Public Property _TXYEAR As Integer   'LL new addition cloning from TXPHIN
    Get
      Return mTXYEAR
    End Get
    Set(ByVal value As Integer)
      mTXYEAR = value
    End Set
  End Property
#End Region
End Class


