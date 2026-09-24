Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "TXM59A"
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
      _LISTNO = .Item("LIST#")
      _TYPE = .Item("TYPE")
      _YEAR = .Item("YEAR")
      _ALNAME = .Item("ALNAME")
      _AFNAME = .Item("AFNAME")
      _AINIT = .Item("AINIT")
      _ASSN = .Item("ASSN")
      _SLNAME = .Item("SLNAME")
      _SFNAME = .Item("SFNAME")
      _SINIT = .Item("SINIT")
      _SSSN = .Item("SSSN")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP = .Item("ZIP")
      _MADDR = .Item("MADDR")
      _MCITY = .Item("MCITY")
      _MSTATE = .Item("MSTATE")
      _MZIP = .Item("MZIP")
      _PHONE = .Item("PHONE")
      _FILING = .Item("FILING")
      _RATING = .Item("RATING")
      _DTSIGN = .Item("DTSIGN")
      _INCOME = .Item("INCOME")
      _INT = .Item("INT")
      _SSRR = .Item("SSRR")
      _OTHER = .Item("OTHER")
      _XVET = .Item("XVET")
      '//_DISINC   = .Item("DISINC")
      _XFULL = .Item("XFULL")
      _XADDL = .Item("XADDL")
      _XFULLO = .Item("XFULLO")
      _XLOCAL = .Item("XLOCAL")
      _ALLOW = .Item("ALLOW")
      _DISRSN = .Item("DISRSN")
      _DTASSR = .Item("DTASSR")

    End With
  End Sub

#End Region


#Region "Properties: Fields"

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

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mALNAME as string 
Public Property _ALNAME as string   
    Get
        Return mALNAME
    End Get
    set(byval value as string)
        mALNAME = value
    End Set
End Property

Dim mAFNAME as string 
Public Property _AFNAME as string   
    Get
        Return mAFNAME
    End Get
    set(byval value as string)
        mAFNAME = value
    End Set
End Property

Dim mAINIT as string 
Public Property _AINIT as string   
    Get
        Return mAINIT
    End Get
    set(byval value as string)
        mAINIT = value
    End Set
End Property

Dim mASSN  as long
Public Property _ASSN  as long  
    Get
        Return mASSN
    End Get
    set(byval value as long)
        mASSN = value
    End Set
End Property

Dim mSLNAME as string 
Public Property _SLNAME as string   
    Get
        Return mSLNAME
    End Get
    set(byval value as string)
        mSLNAME = value
    End Set
End Property

Dim mSFNAME as string 
Public Property _SFNAME as string   
    Get
        Return mSFNAME
    End Get
    set(byval value as string)
        mSFNAME = value
    End Set
End Property

Dim mSINIT as string 
Public Property _SINIT as string   
    Get
        Return mSINIT
    End Get
    set(byval value as string)
        mSINIT = value
    End Set
End Property

Dim mSSSN  as long
Public Property _SSSN  as long  
    Get
        Return mSSSN
    End Get
    set(byval value as long)
        mSSSN = value
    End Set
End Property

Dim mLOCNO as string 
Public Property _LOCNO as string   
    Get
        Return mLOCNO
    End Get
    set(byval value as string)
        mLOCNO = value
    End Set
End Property

Dim mLOC as string 
Public Property _LOC as string   
    Get
        Return mLOC
    End Get
    set(byval value as string)
        mLOC = value
    End Set
End Property

Dim mCITY as string 
Public Property _CITY as string   
    Get
        Return mCITY
    End Get
    set(byval value as string)
        mCITY = value
    End Set
End Property

Dim mSTATE as string 
Public Property _STATE as string   
    Get
        Return mSTATE
    End Get
    set(byval value as string)
        mSTATE = value
    End Set
End Property

Dim mZIP  as integer 
Public Property _ZIP  as integer   
    Get
        Return mZIP
    End Get
    set(byval value as integer)
        mZIP = value
    End Set
End Property

Dim mMADDR as string 
Public Property _MADDR as string   
    Get
        Return mMADDR
    End Get
    set(byval value as string)
        mMADDR = value
    End Set
End Property

Dim mMCITY as string 
Public Property _MCITY as string   
    Get
        Return mMCITY
    End Get
    set(byval value as string)
        mMCITY = value
    End Set
End Property

Dim mMSTATE as string 
Public Property _MSTATE as string   
    Get
        Return mMSTATE
    End Get
    set(byval value as string)
        mMSTATE = value
    End Set
End Property

Dim mMZIP  as integer 
Public Property _MZIP  as integer   
    Get
        Return mMZIP
    End Get
    set(byval value as integer)
        mMZIP = value
    End Set
End Property
  Dim mPHONE As Long
  Public Property _PHONE As Long
    Get
      Return mPHONE
    End Get
    Set(ByVal value As Long)
      mPHONE = value
    End Set
  End Property

  Dim mFILING as string 
Public Property _FILING as string   
    Get
        Return mFILING
    End Get
    set(byval value as string)
        mFILING = value
    End Set
End Property

Dim mRATING as string 
Public Property _RATING as string   
    Get
        Return mRATING
    End Get
    set(byval value as string)
        mRATING = value
    End Set
End Property

Dim mDTSIGN  as integer 
Public Property _DTSIGN  as integer   
    Get
        Return mDTSIGN
    End Get
    set(byval value as integer)
        mDTSIGN = value
    End Set
End Property

Dim mINCOME as decimal
Public Property _INCOME as decimal
    Get
        Return mINCOME
    End Get
    Set(ByVal value As Decimal)
      mINCOME = value
    End Set
  End Property

  Dim mINT As Decimal
  Public Property _INT As Decimal
    Get
      Return mINT
    End Get
    Set(ByVal value As Decimal)
      mINT = value
    End Set
  End Property

  Dim mSSRR As Decimal
  Public Property _SSRR As Decimal
    Get
      Return mSSRR
    End Get
    Set(ByVal value As Decimal)
      mSSRR = value
    End Set
  End Property

  Dim mOTHER As Decimal
  Public Property _OTHER As Decimal
    Get
      Return mOTHER
    End Get
    Set(ByVal value As Decimal)
      mOTHER = value
    End Set
  End Property

Dim mXVET  as integer 
Public Property _XVET  as integer   
    Get
        Return mXVET
    End Get
    set(byval value as integer)
        mXVET = value
    End Set
End Property

  '//Dim mDISINC as string 
  '//Public Property _DISINC as string   
  '//    Get
  '//        Return mDISINC
  '//    End Get
  '//    set(byval value as string)
  '//        mDISINC = value
  '//    End Set
  '//End Property

  Dim mXFULL  as integer 
Public Property _XFULL  as integer   
    Get
        Return mXFULL
    End Get
    Set(ByVal value As Integer)
      mXFULL = value
    End Set
  End Property

Dim mXADDL  as integer 
Public Property _XADDL  as integer   
    Get
        Return mXADDL
    End Get
    set(byval value as integer)
        mXADDL = value
    End Set
End Property

Dim mXFULLO  as integer 
Public Property _XFULLO  as integer   
    Get
        Return mXFULLO
    End Get
    set(byval value as integer)
        mXFULLO = value
    End Set
End Property

Dim mXLOCAL  as integer 
Public Property _XLOCAL  as integer   
    Get
        Return mXLOCAL
    End Get
    set(byval value as integer)
        mXLOCAL = value
    End Set
End Property

Dim mALLOW as string 
Public Property _ALLOW as string   
    Get
        Return mALLOW
    End Get
    set(byval value as string)
        mALLOW = value
    End Set
End Property

Dim mDISRSN as string 
Public Property _DISRSN as string   
    Get
        Return mDISRSN
    End Get
    set(byval value as string)
        mDISRSN = value
    End Set
End Property

Dim mDTASSR  as integer 
Public Property _DTASSR  as integer   
    Get
        Return mDTASSR
    End Get
    set(byval value as integer)
        mDTASSR = value
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


