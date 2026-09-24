Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "TXDCPP"
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
      _YEAR = .Item("YEAR")
      _OWNAME = .Item("OWNAME")
      _SNAME = .Item("SNAME")
      _DBA = .Item("DBA")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _DNAME = .Item("DNAME")
      _DADDR = .Item("DADDR")
      _DADDR2 = .Item("DADDR2")
      _DCITY = .Item("DCITY")
      _DSTATE = .Item("DSTATE")
      _DZIP5 = .Item("DZIP5")
      _DZIP4 = .Item("DZIP4")
      _DPHONE = .Item("DPHONE")
      _DFAX = .Item("DFAX")
      _DEMAIL = .Item("DEMAIL")
      _LNAME = .Item("LNAME")
      _LADDR = .Item("LADDR")
      _LADDR2 = .Item("LADDR2")
      _LCITY = .Item("LCITY")
      _LSTATE = .Item("LSTATE")
      _LZIP5 = .Item("LZIP5")
      _LZIP4 = .Item("LZIP4")
      _LPHONE = .Item("LPHONE")
      _LFAX = .Item("LFAX")
      _LEMAIL = .Item("LEMAIL")
      _BUSDES = .Item("BUSDES")
      _NOEMPS = .Item("NOEMPS")
      _STRDT = .Item("STRDT")
      _SQFEET = .Item("SQFEET")
      _OWN = .Item("OWN")
      _OWNTYP = .Item("OWNTYP")
      _OWNOTH = .Item("OWNOTH")
      _BUSCAT = .Item("BUSCAT")
      _BUSOTH = .Item("BUSOTH")
      _BUSCD = .Item("BUSCD")
      _PROPCT = .Item("PROPCT")
      _OTHBUS = .Item("OTHBUS")
      _STATUS = .Item("STATUS")
      _RECVDT = .Item("RECVDT")
      _FILSTS = .Item("FILSTS")
      _ASECCD = .Item("ASECCD")
      _ATITLE = .Item("ATITLE")
      _ANAME = .Item("ANAME")
      _ADATE = .Item("ADATE")
      _BTITLE = .Item("BTITLE")
      _BNAME = .Item("BNAME")
      _BDATE = .Item("BDATE")
      _BWIT = .Item("BWIT")
      _BWITDT = .Item("BWITDT")
      _BWITCD = .Item("BWITCD")
      _IRSBUS = .Item("IRSBUS")
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

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mOWNAME as string 
Public Property _OWNAME as string   
    Get
        Return mOWNAME
    End Get
    set(byval value as string)
        mOWNAME = value
    End Set
End Property
  Dim mSNAME As String
  Public Property _SNAME As String
    Get
      Return mSNAME
    End Get
    Set(ByVal value As String)
      mSNAME = value
    End Set
  End Property

  Dim mDBA as string 
Public Property _DBA as string   
    Get
        Return mDBA
    End Get
    set(byval value as string)
        mDBA = value
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

Dim mDNAME as string 
Public Property _DNAME as string   
    Get
        Return mDNAME
    End Get
    set(byval value as string)
        mDNAME = value
    End Set
End Property

Dim mDADDR as string 
Public Property _DADDR as string   
    Get
        Return mDADDR
    End Get
    set(byval value as string)
        mDADDR = value
    End Set
End Property

  Dim mDADDR2 As String
  Public Property _DADDR2 As String
    Get
      Return mDADDR2
    End Get
    Set(ByVal value As String)
      mDADDR2 = value
    End Set
  End Property
  Dim mDCITY As String
  Public Property _DCITY as string   
    Get
        Return mDCITY
    End Get
    set(byval value as string)
        mDCITY = value
    End Set
End Property

Dim mDSTATE as string 
Public Property _DSTATE as string   
    Get
        Return mDSTATE
    End Get
    set(byval value as string)
        mDSTATE = value
    End Set
End Property

Dim mDZIP5  as integer 
Public Property _DZIP5  as integer   
    Get
        Return mDZIP5
    End Get
    set(byval value as integer)
        mDZIP5 = value
    End Set
End Property

Dim mDZIP4  as integer 
Public Property _DZIP4  as integer   
    Get
        Return mDZIP4
    End Get
    set(byval value as integer)
        mDZIP4 = value
    End Set
End Property

Dim mDPHONE as string 
Public Property _DPHONE as string   
    Get
        Return mDPHONE
    End Get
    set(byval value as string)
        mDPHONE = value
    End Set
End Property

Dim mDFAX as string 
Public Property _DFAX as string   
    Get
        Return mDFAX
    End Get
    set(byval value as string)
        mDFAX = value
    End Set
End Property

Dim mDEMAIL as string 
Public Property _DEMAIL as string   
    Get
        Return mDEMAIL
    End Get
    set(byval value as string)
        mDEMAIL = value
    End Set
End Property

Dim mLNAME as string 
Public Property _LNAME as string   
    Get
        Return mLNAME
    End Get
    set(byval value as string)
        mLNAME = value
    End Set
End Property

Dim mLADDR as string 
Public Property _LADDR as string   
    Get
        Return mLADDR
    End Get
    set(byval value as string)
        mLADDR = value
    End Set
End Property

  Dim mLADDR2 As String
  Public Property _LADDR2 As String
    Get
      Return mLADDR2
    End Get
    Set(ByVal value As String)
      mLADDR2 = value
    End Set
  End Property
  Dim mLCITY As String
  Public Property _LCITY as string   
    Get
        Return mLCITY
    End Get
    set(byval value as string)
        mLCITY = value
    End Set
End Property

Dim mLSTATE as string 
Public Property _LSTATE as string   
    Get
        Return mLSTATE
    End Get
    set(byval value as string)
        mLSTATE = value
    End Set
End Property

Dim mLZIP5  as integer 
Public Property _LZIP5  as integer   
    Get
        Return mLZIP5
    End Get
    set(byval value as integer)
        mLZIP5 = value
    End Set
End Property

Dim mLZIP4  as integer 
Public Property _LZIP4  as integer   
    Get
        Return mLZIP4
    End Get
    set(byval value as integer)
        mLZIP4 = value
    End Set
End Property

Dim mLPHONE as string 
Public Property _LPHONE as string   
    Get
        Return mLPHONE
    End Get
    set(byval value as string)
        mLPHONE = value
    End Set
End Property

Dim mLFAX as string 
Public Property _LFAX as string   
    Get
        Return mLFAX
    End Get
    set(byval value as string)
        mLFAX = value
    End Set
End Property

Dim mLEMAIL as string 
Public Property _LEMAIL as string   
    Get
        Return mLEMAIL
    End Get
    set(byval value as string)
        mLEMAIL = value
    End Set
End Property

Dim mBUSDES as string 
Public Property _BUSDES as string   
    Get
        Return mBUSDES
    End Get
    set(byval value as string)
        mBUSDES = value
    End Set
End Property

Dim mNOEMPS  as integer 
Public Property _NOEMPS  as integer   
    Get
        Return mNOEMPS
    End Get
    set(byval value as integer)
        mNOEMPS = value
    End Set
End Property

Dim mSTRDT  as integer 
Public Property _STRDT  as integer   
    Get
        Return mSTRDT
    End Get
    set(byval value as integer)
        mSTRDT = value
    End Set
End Property

Dim mSQFEET  as integer 
Public Property _SQFEET  as integer   
    Get
        Return mSQFEET
    End Get
    set(byval value as integer)
        mSQFEET = value
    End Set
End Property

Dim mOWN as string 
Public Property _OWN as string   
    Get
        Return mOWN
    End Get
    set(byval value as string)
        mOWN = value
    End Set
End Property

Dim mOWNTYP as string 
Public Property _OWNTYP as string   
    Get
        Return mOWNTYP
    End Get
    set(byval value as string)
        mOWNTYP = value
    End Set
End Property

Dim mOWNOTH as string 
Public Property _OWNOTH as string   
    Get
        Return mOWNOTH
    End Get
    set(byval value as string)
        mOWNOTH = value
    End Set
End Property

Dim mBUSCAT as string 
Public Property _BUSCAT as string   
    Get
        Return mBUSCAT
    End Get
    set(byval value as string)
        mBUSCAT = value
    End Set
End Property

Dim mBUSOTH as string 
Public Property _BUSOTH as string   
    Get
        Return mBUSOTH
    End Get
    set(byval value as string)
        mBUSOTH = value
    End Set
End Property

Dim mBUSCD as string 
Public Property _BUSCD as string   
    Get
        Return mBUSCD
    End Get
    set(byval value as string)
        mBUSCD = value
    End Set
End Property

Dim mPROPCT as string 
Public Property _PROPCT as string   
    Get
        Return mPROPCT
    End Get
    set(byval value as string)
        mPROPCT = value
    End Set
End Property

Dim mOTHBUS as string 
Public Property _OTHBUS as string   
    Get
        Return mOTHBUS
    End Get
    set(byval value as string)
        mOTHBUS = value
    End Set
End Property

Dim mSTATUS as string 
Public Property _STATUS as string   
    Get
        Return mSTATUS
    End Get
    set(byval value as string)
        mSTATUS = value
    End Set
End Property

Dim mRECVDT  as integer 
Public Property _RECVDT  as integer   
    Get
        Return mRECVDT
    End Get
    set(byval value as integer)
        mRECVDT = value
    End Set
End Property

Dim mFILSTS as string 
Public Property _FILSTS as string   
    Get
        Return mFILSTS
    End Get
    set(byval value as string)
        mFILSTS = value
    End Set
End Property

Dim mASECCD as string 
Public Property _ASECCD as string   
    Get
        Return mASECCD
    End Get
    set(byval value as string)
        mASECCD = value
    End Set
End Property

Dim mATITLE as string 
Public Property _ATITLE as string   
    Get
        Return mATITLE
    End Get
    set(byval value as string)
        mATITLE = value
    End Set
End Property

Dim mANAME as string 
Public Property _ANAME as string   
    Get
        Return mANAME
    End Get
    set(byval value as string)
        mANAME = value
    End Set
End Property

Dim mADATE  as integer 
Public Property _ADATE  as integer   
    Get
        Return mADATE
    End Get
    set(byval value as integer)
        mADATE = value
    End Set
End Property

Dim mBTITLE as string 
Public Property _BTITLE as string   
    Get
        Return mBTITLE
    End Get
    set(byval value as string)
        mBTITLE = value
    End Set
End Property

Dim mBNAME as string 
Public Property _BNAME as string   
    Get
        Return mBNAME
    End Get
    set(byval value as string)
        mBNAME = value
    End Set
End Property

Dim mBDATE  as integer 
Public Property _BDATE  as integer   
    Get
        Return mBDATE
    End Get
    set(byval value as integer)
        mBDATE = value
    End Set
End Property

Dim mBWIT as string 
Public Property _BWIT as string   
    Get
        Return mBWIT
    End Get
    set(byval value as string)
        mBWIT = value
    End Set
End Property

Dim mBWITDT  as integer 
Public Property _BWITDT  as integer   
    Get
        Return mBWITDT
    End Get
    set(byval value as integer)
        mBWITDT = value
    End Set
End Property

Dim mBWITCD as string 
Public Property _BWITCD as string   
    Get
        Return mBWITCD
    End Get
    set(byval value as string)
        mBWITCD = value
    End Set
End Property
  Dim mIRSBUS As Integer
  Public Property _IRSBUS As Integer
    Get
      Return mIRSBUS
    End Get
    Set(ByVal value As Integer)
      mIRSBUS = value
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


