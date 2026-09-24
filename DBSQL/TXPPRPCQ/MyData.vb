Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "TXPPRPC"
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
      _CAT = .Item("CAT")
      _LISTNO = .Item("LIST#")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _DIST = .Item("DIST")
      _GROSS = .Item("GROSS")
      _NET = .Item("NET")
      _ASS1 = .Item("ASS1")
      _ASS2 = .Item("ASS2")
      _ASS3 = .Item("ASS3")
      _ASS4 = .Item("ASS4")
      _ASS5 = .Item("ASS5")
      _ASS6 = .Item("ASS6")
      _ASS7 = .Item("ASS7")
      _ASS8 = .Item("ASS8")
      _ASS9 = .Item("ASS9")
      _ASS10 = .Item("ASS10")
      _CODE1 = .Item("CODE1")
      _CODE2 = .Item("CODE2")
      _CODE3 = .Item("CODE3")
      _CODE4 = .Item("CODE4")
      _CODE5 = .Item("CODE5")
      _CODE6 = .Item("CODE6")
      _CODE7 = .Item("CODE7")
      _CODE8 = .Item("CODE8")
      _CODE9 = .Item("CODE9")
      _CODEA = .Item("CODEA")
      _UNIT1 = .Item("UNIT1")
      _UNIT2 = .Item("UNIT2")
      _UNIT3 = .Item("UNIT3")
      _UNIT4 = .Item("UNIT4")
      _UNIT5 = .Item("UNIT5")
      _UNIT6 = .Item("UNIT6")
      _UNIT7 = .Item("UNIT7")
      _UNIT8 = .Item("UNIT8")
      _UNIT9 = .Item("UNIT9")
      _UNITA = .Item("UNITA")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _CCNO = .Item("CCNO")
      _CCGRS = .Item("CCGRS")
      _CCEX = .Item("CCEX")
      _CCRS = .Item("CCRS")
      _CDATE = .Item("CDATE")
      _CASS1 = .Item("CASS1")
      _CASS2 = .Item("CASS2")
      _CASS3 = .Item("CASS3")
      _CASS4 = .Item("CASS4")
      _CASS5 = .Item("CASS5")
      _CASS6 = .Item("CASS6")
      _CASS7 = .Item("CASS7")
      _CASS8 = .Item("CASS8")
      _CASS9 = .Item("CASS9")
      _CASSA = .Item("CASSA")
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _BTR = .Item("BTR")
      _BTC = .Item("BTC")
      _SSNO = .Item("SS#")
      _BUSTY = .Item("BUSTY")
      _SQFT = .Item("SQFT")
      _BUS = .Item("BUS")
      _RDATE = .Item("RDATE")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _LETT = .Item("LETT")
      _TYPE = .Item("TYPE")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
      _ADYR = .Item("ADYR")
      _PDST = .Item("PDST")
      _OID = .Item("OID")
      _SS2 = .Item("SS2")
      _TIN = .Item("TIN")

    End With
  End Sub

#End Region


#Region "Properties: Fields"

  Dim mCAT as string 
Public Property _CAT as string   
    Get
        Return mCAT
    End Get
    set(byval value as string)
        mCAT = value
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

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
    End Set
End Property

Dim mSNAME as string 
Public Property _SNAME as string   
    Get
        Return mSNAME
    End Get
    set(byval value as string)
        mSNAME = value
    End Set
End Property

Dim mADD1 as string 
Public Property _ADD1 as string   
    Get
        Return mADD1
    End Get
    set(byval value as string)
        mADD1 = value
    End Set
End Property

Dim mADD2 as string 
Public Property _ADD2 as string   
    Get
        Return mADD2
    End Get
    set(byval value as string)
        mADD2 = value
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

Dim mZIP5  as integer 
Public Property _ZIP5  as integer   
    Get
        Return mZIP5
    End Get
    set(byval value as integer)
        mZIP5 = value
    End Set
End Property

Dim mZIP4  as integer 
Public Property _ZIP4  as integer   
    Get
        Return mZIP4
    End Get
    set(byval value as integer)
        mZIP4 = value
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

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
    End Set
End Property

Dim mGROSS  as long
Public Property _GROSS  as long  
    Get
        Return mGROSS
    End Get
    set(byval value as long)
        mGROSS = value
    End Set
End Property

Dim mNET  as long
Public Property _NET  as long  
    Get
        Return mNET
    End Get
    set(byval value as long)
        mNET = value
    End Set
End Property

Dim mASS1  as long
Public Property _ASS1  as long  
    Get
        Return mASS1
    End Get
    set(byval value as long)
        mASS1 = value
    End Set
End Property

Dim mASS2  as long
Public Property _ASS2  as long  
    Get
        Return mASS2
    End Get
    set(byval value as long)
        mASS2 = value
    End Set
End Property

Dim mASS3  as long
Public Property _ASS3  as long  
    Get
        Return mASS3
    End Get
    set(byval value as long)
        mASS3 = value
    End Set
End Property

Dim mASS4  as long
Public Property _ASS4  as long  
    Get
        Return mASS4
    End Get
    set(byval value as long)
        mASS4 = value
    End Set
End Property

Dim mASS5  as long
Public Property _ASS5  as long  
    Get
        Return mASS5
    End Get
    set(byval value as long)
        mASS5 = value
    End Set
End Property

Dim mASS6  as long
Public Property _ASS6  as long  
    Get
        Return mASS6
    End Get
    set(byval value as long)
        mASS6 = value
    End Set
End Property

Dim mASS7  as long
Public Property _ASS7  as long  
    Get
        Return mASS7
    End Get
    set(byval value as long)
        mASS7 = value
    End Set
End Property

Dim mASS8  as long
Public Property _ASS8  as long  
    Get
        Return mASS8
    End Get
    set(byval value as long)
        mASS8 = value
    End Set
End Property

Dim mASS9  as long
Public Property _ASS9  as long  
    Get
        Return mASS9
    End Get
    set(byval value as long)
        mASS9 = value
    End Set
End Property

Dim mASS10  as long
Public Property _ASS10  as long  
    Get
        Return mASS10
    End Get
    set(byval value as long)
        mASS10 = value
    End Set
End Property

Dim mCODE1  as integer 
Public Property _CODE1  as integer   
    Get
        Return mCODE1
    End Get
    set(byval value as integer)
        mCODE1 = value
    End Set
End Property

Dim mCODE2  as integer 
Public Property _CODE2  as integer   
    Get
        Return mCODE2
    End Get
    set(byval value as integer)
        mCODE2 = value
    End Set
End Property

Dim mCODE3  as integer 
Public Property _CODE3  as integer   
    Get
        Return mCODE3
    End Get
    set(byval value as integer)
        mCODE3 = value
    End Set
End Property

Dim mCODE4  as integer 
Public Property _CODE4  as integer   
    Get
        Return mCODE4
    End Get
    set(byval value as integer)
        mCODE4 = value
    End Set
End Property

Dim mCODE5  as integer 
Public Property _CODE5  as integer   
    Get
        Return mCODE5
    End Get
    set(byval value as integer)
        mCODE5 = value
    End Set
End Property

Dim mCODE6  as integer 
Public Property _CODE6  as integer   
    Get
        Return mCODE6
    End Get
    set(byval value as integer)
        mCODE6 = value
    End Set
End Property

Dim mCODE7  as integer 
Public Property _CODE7  as integer   
    Get
        Return mCODE7
    End Get
    set(byval value as integer)
        mCODE7 = value
    End Set
End Property

Dim mCODE8  as integer 
Public Property _CODE8  as integer   
    Get
        Return mCODE8
    End Get
    set(byval value as integer)
        mCODE8 = value
    End Set
End Property

Dim mCODE9  as integer 
Public Property _CODE9  as integer   
    Get
        Return mCODE9
    End Get
    set(byval value as integer)
        mCODE9 = value
    End Set
End Property

Dim mCODEA  as integer 
Public Property _CODEA  as integer   
    Get
        Return mCODEA
    End Get
    set(byval value as integer)
        mCODEA = value
    End Set
End Property

Dim mUNIT1  as integer 
Public Property _UNIT1  as integer   
    Get
        Return mUNIT1
    End Get
    set(byval value as integer)
        mUNIT1 = value
    End Set
End Property

Dim mUNIT2  as integer 
Public Property _UNIT2  as integer   
    Get
        Return mUNIT2
    End Get
    set(byval value as integer)
        mUNIT2 = value
    End Set
End Property

Dim mUNIT3  as integer 
Public Property _UNIT3  as integer   
    Get
        Return mUNIT3
    End Get
    set(byval value as integer)
        mUNIT3 = value
    End Set
End Property

Dim mUNIT4  as integer 
Public Property _UNIT4  as integer   
    Get
        Return mUNIT4
    End Get
    set(byval value as integer)
        mUNIT4 = value
    End Set
End Property

Dim mUNIT5  as integer 
Public Property _UNIT5  as integer   
    Get
        Return mUNIT5
    End Get
    set(byval value as integer)
        mUNIT5 = value
    End Set
End Property

Dim mUNIT6  as integer 
Public Property _UNIT6  as integer   
    Get
        Return mUNIT6
    End Get
    set(byval value as integer)
        mUNIT6 = value
    End Set
End Property

Dim mUNIT7  as integer 
Public Property _UNIT7  as integer   
    Get
        Return mUNIT7
    End Get
    set(byval value as integer)
        mUNIT7 = value
    End Set
End Property

Dim mUNIT8  as integer 
Public Property _UNIT8  as integer   
    Get
        Return mUNIT8
    End Get
    set(byval value as integer)
        mUNIT8 = value
    End Set
End Property

Dim mUNIT9  as integer 
Public Property _UNIT9  as integer   
    Get
        Return mUNIT9
    End Get
    set(byval value as integer)
        mUNIT9 = value
    End Set
End Property

Dim mUNITA  as integer 
Public Property _UNITA  as integer   
    Get
        Return mUNITA
    End Get
    set(byval value as integer)
        mUNITA = value
    End Set
End Property

Dim mEXCD1 as string 
Public Property _EXCD1 as string   
    Get
        Return mEXCD1
    End Get
    set(byval value as string)
        mEXCD1 = value
    End Set
End Property

Dim mEXCD2 as string 
Public Property _EXCD2 as string   
    Get
        Return mEXCD2
    End Get
    set(byval value as string)
        mEXCD2 = value
    End Set
End Property

Dim mEXCD3 as string 
Public Property _EXCD3 as string   
    Get
        Return mEXCD3
    End Get
    set(byval value as string)
        mEXCD3 = value
    End Set
End Property

Dim mEXCD4 as string 
Public Property _EXCD4 as string   
    Get
        Return mEXCD4
    End Get
    set(byval value as string)
        mEXCD4 = value
    End Set
End Property

Dim mEXCD5 as string 
Public Property _EXCD5 as string   
    Get
        Return mEXCD5
    End Get
    set(byval value as string)
        mEXCD5 = value
    End Set
End Property

Dim mEXAM1  as integer 
Public Property _EXAM1  as integer   
    Get
        Return mEXAM1
    End Get
    set(byval value as integer)
        mEXAM1 = value
    End Set
End Property

Dim mEXAM2  as integer 
Public Property _EXAM2  as integer   
    Get
        Return mEXAM2
    End Get
    set(byval value as integer)
        mEXAM2 = value
    End Set
End Property

Dim mEXAM3  as integer 
Public Property _EXAM3  as integer   
    Get
        Return mEXAM3
    End Get
    set(byval value as integer)
        mEXAM3 = value
    End Set
End Property

Dim mEXAM4  as integer 
Public Property _EXAM4  as integer   
    Get
        Return mEXAM4
    End Get
    set(byval value as integer)
        mEXAM4 = value
    End Set
End Property

Dim mEXAM5  as integer 
Public Property _EXAM5  as integer   
    Get
        Return mEXAM5
    End Get
    set(byval value as integer)
        mEXAM5 = value
    End Set
End Property

Dim mCCNO  as integer 
Public Property _CCNO  as integer   
    Get
        Return mCCNO
    End Get
    set(byval value as integer)
        mCCNO = value
    End Set
End Property

Dim mCCGRS  as long
Public Property _CCGRS  as long  
    Get
        Return mCCGRS
    End Get
    set(byval value as long)
        mCCGRS = value
    End Set
End Property

Dim mCCEX  as long
Public Property _CCEX  as long  
    Get
        Return mCCEX
    End Get
    set(byval value as long)
        mCCEX = value
    End Set
End Property

Dim mCCRS as string 
Public Property _CCRS as string   
    Get
        Return mCCRS
    End Get
    set(byval value as string)
        mCCRS = value
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

Dim mCASS1  as long
Public Property _CASS1  as long  
    Get
        Return mCASS1
    End Get
    set(byval value as long)
        mCASS1 = value
    End Set
End Property

Dim mCASS2  as long
Public Property _CASS2  as long  
    Get
        Return mCASS2
    End Get
    set(byval value as long)
        mCASS2 = value
    End Set
End Property

Dim mCASS3  as long
Public Property _CASS3  as long  
    Get
        Return mCASS3
    End Get
    set(byval value as long)
        mCASS3 = value
    End Set
End Property

Dim mCASS4  as long
Public Property _CASS4  as long  
    Get
        Return mCASS4
    End Get
    set(byval value as long)
        mCASS4 = value
    End Set
End Property

Dim mCASS5  as long
Public Property _CASS5  as long  
    Get
        Return mCASS5
    End Get
    set(byval value as long)
        mCASS5 = value
    End Set
End Property

Dim mCASS6  as long
Public Property _CASS6  as long  
    Get
        Return mCASS6
    End Get
    set(byval value as long)
        mCASS6 = value
    End Set
End Property

Dim mCASS7  as long
Public Property _CASS7  as long  
    Get
        Return mCASS7
    End Get
    set(byval value as long)
        mCASS7 = value
    End Set
End Property

Dim mCASS8  as long
Public Property _CASS8  as long  
    Get
        Return mCASS8
    End Get
    set(byval value as long)
        mCASS8 = value
    End Set
End Property

Dim mCASS9  as long
Public Property _CASS9  as long  
    Get
        Return mCASS9
    End Get
    set(byval value as long)
        mCASS9 = value
    End Set
End Property

Dim mCASSA  as long
Public Property _CASSA  as long  
    Get
        Return mCASSA
    End Get
    set(byval value as long)
        mCASSA = value
    End Set
End Property

Dim mCCCD1 as string 
Public Property _CCCD1 as string   
    Get
        Return mCCCD1
    End Get
    set(byval value as string)
        mCCCD1 = value
    End Set
End Property

Dim mCCCD2 as string 
Public Property _CCCD2 as string   
    Get
        Return mCCCD2
    End Get
    set(byval value as string)
        mCCCD2 = value
    End Set
End Property

Dim mCCCD3 as string 
Public Property _CCCD3 as string   
    Get
        Return mCCCD3
    End Get
    set(byval value as string)
        mCCCD3 = value
    End Set
End Property

Dim mCCCD4 as string 
Public Property _CCCD4 as string   
    Get
        Return mCCCD4
    End Get
    set(byval value as string)
        mCCCD4 = value
    End Set
End Property

Dim mCCCD5 as string 
Public Property _CCCD5 as string   
    Get
        Return mCCCD5
    End Get
    set(byval value as string)
        mCCCD5 = value
    End Set
End Property

Dim mCEXA1  as integer 
Public Property _CEXA1  as integer   
    Get
        Return mCEXA1
    End Get
    set(byval value as integer)
        mCEXA1 = value
    End Set
End Property

Dim mCEXA2  as integer 
Public Property _CEXA2  as integer   
    Get
        Return mCEXA2
    End Get
    set(byval value as integer)
        mCEXA2 = value
    End Set
End Property

Dim mCEXA3  as integer 
Public Property _CEXA3  as integer   
    Get
        Return mCEXA3
    End Get
    set(byval value as integer)
        mCEXA3 = value
    End Set
End Property

Dim mCEXA4  as integer 
Public Property _CEXA4  as integer   
    Get
        Return mCEXA4
    End Get
    set(byval value as integer)
        mCEXA4 = value
    End Set
End Property

Dim mCEXA5  as integer 
Public Property _CEXA5  as integer   
    Get
        Return mCEXA5
    End Get
    set(byval value as integer)
        mCEXA5 = value
    End Set
End Property

Dim mBTR  as long
Public Property _BTR  as long  
    Get
        Return mBTR
    End Get
    set(byval value as long)
        mBTR = value
    End Set
End Property

Dim mBTC as string 
Public Property _BTC as string   
    Get
        Return mBTC
    End Get
    set(byval value as string)
        mBTC = value
    End Set
End Property

Dim mSSNO  as long
Public Property _SSNO  as long  
    Get
        Return mSSNO
    End Get
    set(byval value as long)
        mSSNO = value
    End Set
End Property

Dim mBUSTY as string 
Public Property _BUSTY as string   
    Get
        Return mBUSTY
    End Get
    set(byval value as string)
        mBUSTY = value
    End Set
End Property

Dim mSQFT as decimal
Public Property _SQFT as decimal
    Get
        Return mSQFT
    End Get
    Set(ByVal value As Decimal)
      mSQFT = value
    End Set
  End Property

Dim mBUS as string 
Public Property _BUS as string   
    Get
        Return mBUS
    End Get
    set(byval value as string)
        mBUS = value
    End Set
End Property

Dim mRDATE as string 
Public Property _RDATE as string   
    Get
        Return mRDATE
    End Get
    set(byval value as string)
        mRDATE = value
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

Dim mLETT as string 
Public Property _LETT as string   
    Get
        Return mLETT
    End Get
    set(byval value as string)
        mLETT = value
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

Dim mDNBTR as string 
Public Property _DNBTR as string   
    Get
        Return mDNBTR
    End Get
    set(byval value as string)
        mDNBTR = value
    End Set
End Property

Dim mDTBTR  as integer 
Public Property _DTBTR  as integer   
    Get
        Return mDTBTR
    End Get
    set(byval value as integer)
        mDTBTR = value
    End Set
End Property

Dim mADYR  as integer 
Public Property _ADYR  as integer   
    Get
        Return mADYR
    End Get
    set(byval value as integer)
        mADYR = value
    End Set
End Property

Dim mPDST  as integer 
Public Property _PDST  as integer   
    Get
        Return mPDST
    End Get
    set(byval value as integer)
        mPDST = value
    End Set
End Property

Dim mOID as string 
Public Property _OID as string   
    Get
        Return mOID
    End Get
    set(byval value as string)
        mOID = value
    End Set
End Property

Dim mSS2  as long
Public Property _SS2  as long  
    Get
        Return mSS2
    End Get
    set(byval value as long)
        mSS2 = value
    End Set
End Property

Dim mTIN as string 
Public Property _TIN as string   
    Get
        Return mTIN
    End Get
    set(byval value as string)
        mTIN = value
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


