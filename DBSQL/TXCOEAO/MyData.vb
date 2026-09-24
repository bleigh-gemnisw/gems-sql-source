Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXCOEAO"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CCNO  = 0
_YEAR  = 0
_LISTNo  = 0
_TYPE = string.empty
_NAME = string.empty
_DIST  = 0
_CTXOV = string.empty
_CPCD1  = 0
_CPCD2  = 0
_CPCD3  = 0
_CPCD4  = 0
_CPCD5  = 0
_CPCD6  = 0
_CPCD7  = 0
_CPCD8  = 0
_CPCD9  = 0
_CPCDA  = 0
_ASS1  = 0
_ASS2  = 0
_ASS3  = 0
_ASS4  = 0
_ASS5  = 0
_ASS6  = 0
_ASS7  = 0
_ASS8  = 0
_ASS9  = 0
_ASS10  = 0
_GRCHG  = 0
_EX1  = 0
_EX2  = 0
_EX3  = 0
_EX4  = 0
_EX5  = 0
_EX6  = 0
_EX7  = 0
_EXCD1 = string.empty
_EXCD2 = string.empty
_EXCD3 = string.empty
_EXCD4 = string.empty
_EXCD5 = string.empty
_EXCD6 = string.empty
_EXCD7 = string.empty
_RSNCD = string.empty
_CDATE  = 0
_CDESC = string.empty
_CGRS  = 0
_EXCHG  = 0
_CETAX = 0
_C1MPCD = string.empty
_C1MSCD = string.empty
_C1CPCD = string.empty
_C1CSCD = string.empty
_C2MPCD = string.empty
_C2MSCD = string.empty
_C2CPCD = string.empty
_C2CSCD = string.empty
_SUSCD = string.empty
_NEWMVC  = 0
_AFTER = string.empty
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0
_IMVIDNo = string.empty
_CNETAS  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkccno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where ccno = " & Wrkccno
    Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
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
  Public Function PosData(ByVal Wrkccno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where ccno >= " & Wrkccno & " Order by ccno"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
  Public Function AutoGenKey() As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & cFileName & " order by ccno desc"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        NextKey = 1
      Else
        NextKey = ds.Tables(0).Rows(0).Item("ccno") + 1
      End If

      objCommand = Nothing
      ds.Clear()
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
    Return NextKey
  End Function

  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFileName)
    PutFields(ds)
    da.Update(ds, cFileName)
    ds = Nothing
  End Sub
  Public Sub OpenFile()
  End Sub
	Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
  _CCNO     = .Item("CCNO")
  _YEAR     = .Item("YEAR")
  _LISTNo   = .Item("LIST#")
  _TYPE     = .Item("TYPE")
  _NAME     = .Item("NAME")
  _DIST     = .Item("DIST")
  _CTXOV    = .Item("CTXOV")
  _CPCD1    = .Item("CPCD1")
  _CPCD2    = .Item("CPCD2")
  _CPCD3    = .Item("CPCD3")
  _CPCD4    = .Item("CPCD4")
  _CPCD5    = .Item("CPCD5")
  _CPCD6    = .Item("CPCD6")
  _CPCD7    = .Item("CPCD7")
  _CPCD8    = .Item("CPCD8")
  _CPCD9    = .Item("CPCD9")
  _CPCDA    = .Item("CPCDA")
  _ASS1     = .Item("ASS1")
  _ASS2     = .Item("ASS2")
  _ASS3     = .Item("ASS3")
  _ASS4     = .Item("ASS4")
  _ASS5     = .Item("ASS5")
  _ASS6     = .Item("ASS6")
  _ASS7     = .Item("ASS7")
  _ASS8     = .Item("ASS8")
  _ASS9     = .Item("ASS9")
  _ASS10    = .Item("ASS10")
  _GRCHG    = .Item("GRCHG")
  _EX1      = .Item("EX1")
  _EX2      = .Item("EX2")
  _EX3      = .Item("EX3")
  _EX4      = .Item("EX4")
  _EX5      = .Item("EX5")
  _EX6      = .Item("EX6")
  _EX7      = .Item("EX7")
  _EXCD1    = .Item("EXCD1")
  _EXCD2    = .Item("EXCD2")
  _EXCD3    = .Item("EXCD3")
  _EXCD4    = .Item("EXCD4")
  _EXCD5    = .Item("EXCD5")
  _EXCD6    = .Item("EXCD6")
  _EXCD7    = .Item("EXCD7")
  _RSNCD    = .Item("RSNCD")
  _CDATE    = .Item("CDATE")
  _CDESC    = .Item("CDESC")
  _CGRS     = .Item("CGRS")
  _EXCHG    = .Item("EXCHG")
  _CETAX    = .Item("CETAX")
  _C1MPCD   = .Item("C1MPCD")
  _C1MSCD   = .Item("C1MSCD")
  _C1CPCD   = .Item("C1CPCD")
  _C1CSCD   = .Item("C1CSCD")
  _C2MPCD   = .Item("C2MPCD")
  _C2MSCD   = .Item("C2MSCD")
  _C2CPCD   = .Item("C2CPCD")
  _C2CSCD   = .Item("C2CSCD")
  _SUSCD    = .Item("SUSCD")
  _NEWMVC   = .Item("NEWMVC")
  _AFTER    = .Item("AFTER")
  _PRF      = .Item("PRF")
  _CHDATE   = .Item("CHDATE")
  _CHTIME   = .Item("CHTIME")
  _IMVIDNo  = .Item("IMVID#")
  _CNETAS   = .Item("CNETAS")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CCNO") =   _CCNO    
.Item("YEAR") =   _YEAR    
.Item("LIST#") =   _LISTNo  
.Item("TYPE") =   _TYPE    
.Item("NAME") =   _NAME    
.Item("DIST") =   _DIST    
.Item("CTXOV") =   _CTXOV   
.Item("CPCD1") =   _CPCD1   
.Item("CPCD2") =   _CPCD2   
.Item("CPCD3") =   _CPCD3   
.Item("CPCD4") =   _CPCD4   
.Item("CPCD5") =   _CPCD5   
.Item("CPCD6") =   _CPCD6   
.Item("CPCD7") =   _CPCD7   
.Item("CPCD8") =   _CPCD8   
.Item("CPCD9") =   _CPCD9   
.Item("CPCDA") =   _CPCDA   
.Item("ASS1") =   _ASS1    
.Item("ASS2") =   _ASS2    
.Item("ASS3") =   _ASS3    
.Item("ASS4") =   _ASS4    
.Item("ASS5") =   _ASS5    
.Item("ASS6") =   _ASS6    
.Item("ASS7") =   _ASS7    
.Item("ASS8") =   _ASS8    
.Item("ASS9") =   _ASS9    
.Item("ASS10") =   _ASS10   
.Item("GRCHG") =   _GRCHG   
.Item("EX1") =   _EX1     
.Item("EX2") =   _EX2     
.Item("EX3") =   _EX3     
.Item("EX4") =   _EX4     
.Item("EX5") =   _EX5     
.Item("EX6") =   _EX6     
.Item("EX7") =   _EX7     
.Item("EXCD1") =   _EXCD1   
.Item("EXCD2") =   _EXCD2   
.Item("EXCD3") =   _EXCD3   
.Item("EXCD4") =   _EXCD4   
.Item("EXCD5") =   _EXCD5   
.Item("EXCD6") =   _EXCD6   
.Item("EXCD7") =   _EXCD7   
.Item("RSNCD") =   _RSNCD   
.Item("CDATE") =   _CDATE   
.Item("CDESC") =   _CDESC   
.Item("CGRS") =   _CGRS    
.Item("EXCHG") =   _EXCHG   
.Item("CETAX") =   _CETAX   
.Item("C1MPCD") =   _C1MPCD  
.Item("C1MSCD") =   _C1MSCD  
.Item("C1CPCD") =   _C1CPCD  
.Item("C1CSCD") =   _C1CSCD  
.Item("C2MPCD") =   _C2MPCD  
.Item("C2MSCD") =   _C2MSCD  
.Item("C2CPCD") =   _C2CPCD  
.Item("C2CSCD") =   _C2CSCD  
.Item("SUSCD") =   _SUSCD   
.Item("NEWMVC") =   _NEWMVC  
.Item("AFTER") =   _AFTER   
.Item("PRF") =   _PRF     
.Item("CHDATE") =   _CHDATE  
.Item("CHTIME") =   _CHTIME  
.Item("IMVID#") =   _IMVIDNo 
.Item("CNETAS") =   _CNETAS  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mCCNO  as integer 
Public Property _CCNO  as integer   
    Get
        Return mCCNO
    End Get
    set(byval value as integer)
        mCCNO = value
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

Dim mLISTNo  as integer 
Public Property _LISTNo  as integer   
    Get
        Return mLISTNo
    End Get
    set(byval value as integer)
        mLISTNo = value
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

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
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

Dim mCTXOV as string 
Public Property _CTXOV as string   
    Get
        Return mCTXOV
    End Get
    set(byval value as string)
        mCTXOV = value
    End Set
End Property

Dim mCPCD1  as integer 
Public Property _CPCD1  as integer   
    Get
        Return mCPCD1
    End Get
    set(byval value as integer)
        mCPCD1 = value
    End Set
End Property

Dim mCPCD2  as integer 
Public Property _CPCD2  as integer   
    Get
        Return mCPCD2
    End Get
    set(byval value as integer)
        mCPCD2 = value
    End Set
End Property

Dim mCPCD3  as integer 
Public Property _CPCD3  as integer   
    Get
        Return mCPCD3
    End Get
    set(byval value as integer)
        mCPCD3 = value
    End Set
End Property

Dim mCPCD4  as integer 
Public Property _CPCD4  as integer   
    Get
        Return mCPCD4
    End Get
    set(byval value as integer)
        mCPCD4 = value
    End Set
End Property

Dim mCPCD5  as integer 
Public Property _CPCD5  as integer   
    Get
        Return mCPCD5
    End Get
    set(byval value as integer)
        mCPCD5 = value
    End Set
End Property

Dim mCPCD6  as integer 
Public Property _CPCD6  as integer   
    Get
        Return mCPCD6
    End Get
    set(byval value as integer)
        mCPCD6 = value
    End Set
End Property

Dim mCPCD7  as integer 
Public Property _CPCD7  as integer   
    Get
        Return mCPCD7
    End Get
    set(byval value as integer)
        mCPCD7 = value
    End Set
End Property

Dim mCPCD8  as integer 
Public Property _CPCD8  as integer   
    Get
        Return mCPCD8
    End Get
    set(byval value as integer)
        mCPCD8 = value
    End Set
End Property

Dim mCPCD9  as integer 
Public Property _CPCD9  as integer   
    Get
        Return mCPCD9
    End Get
    set(byval value as integer)
        mCPCD9 = value
    End Set
End Property

Dim mCPCDA  as integer 
Public Property _CPCDA  as integer   
    Get
        Return mCPCDA
    End Get
    set(byval value as integer)
        mCPCDA = value
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

Dim mGRCHG  as long
Public Property _GRCHG  as long  
    Get
        Return mGRCHG
    End Get
    set(byval value as long)
        mGRCHG = value
    End Set
End Property

Dim mEX1  as integer 
Public Property _EX1  as integer   
    Get
        Return mEX1
    End Get
    set(byval value as integer)
        mEX1 = value
    End Set
End Property

Dim mEX2  as integer 
Public Property _EX2  as integer   
    Get
        Return mEX2
    End Get
    set(byval value as integer)
        mEX2 = value
    End Set
End Property

Dim mEX3  as integer 
Public Property _EX3  as integer   
    Get
        Return mEX3
    End Get
    set(byval value as integer)
        mEX3 = value
    End Set
End Property

Dim mEX4  as integer 
Public Property _EX4  as integer   
    Get
        Return mEX4
    End Get
    set(byval value as integer)
        mEX4 = value
    End Set
End Property

Dim mEX5  as integer 
Public Property _EX5  as integer   
    Get
        Return mEX5
    End Get
    set(byval value as integer)
        mEX5 = value
    End Set
End Property

Dim mEX6  as integer 
Public Property _EX6  as integer   
    Get
        Return mEX6
    End Get
    set(byval value as integer)
        mEX6 = value
    End Set
End Property

Dim mEX7  as integer 
Public Property _EX7  as integer   
    Get
        Return mEX7
    End Get
    set(byval value as integer)
        mEX7 = value
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

Dim mEXCD6 as string 
Public Property _EXCD6 as string   
    Get
        Return mEXCD6
    End Get
    set(byval value as string)
        mEXCD6 = value
    End Set
End Property

Dim mEXCD7 as string 
Public Property _EXCD7 as string   
    Get
        Return mEXCD7
    End Get
    set(byval value as string)
        mEXCD7 = value
    End Set
End Property

Dim mRSNCD as string 
Public Property _RSNCD as string   
    Get
        Return mRSNCD
    End Get
    set(byval value as string)
        mRSNCD = value
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

Dim mCDESC as string 
Public Property _CDESC as string   
    Get
        Return mCDESC
    End Get
    set(byval value as string)
        mCDESC = value
    End Set
End Property

Dim mCGRS  as long
Public Property _CGRS  as long  
    Get
        Return mCGRS
    End Get
    set(byval value as long)
        mCGRS = value
    End Set
End Property

Dim mEXCHG  as long
Public Property _EXCHG  as long  
    Get
        Return mEXCHG
    End Get
    set(byval value as long)
        mEXCHG = value
    End Set
End Property

  Dim mCETAX As Decimal
  Public Property _CETAX As Decimal
    Get
      Return mCETAX
    End Get
    Set(ByVal value As Decimal)
      mCETAX = value
    End Set
  End Property

Dim mC1MPCD as string 
Public Property _C1MPCD as string   
    Get
        Return mC1MPCD
    End Get
    set(byval value as string)
        mC1MPCD = value
    End Set
End Property

Dim mC1MSCD as string 
Public Property _C1MSCD as string   
    Get
        Return mC1MSCD
    End Get
    set(byval value as string)
        mC1MSCD = value
    End Set
End Property

Dim mC1CPCD as string 
Public Property _C1CPCD as string   
    Get
        Return mC1CPCD
    End Get
    set(byval value as string)
        mC1CPCD = value
    End Set
End Property

Dim mC1CSCD as string 
Public Property _C1CSCD as string   
    Get
        Return mC1CSCD
    End Get
    set(byval value as string)
        mC1CSCD = value
    End Set
End Property

Dim mC2MPCD as string 
Public Property _C2MPCD as string   
    Get
        Return mC2MPCD
    End Get
    set(byval value as string)
        mC2MPCD = value
    End Set
End Property

Dim mC2MSCD as string 
Public Property _C2MSCD as string   
    Get
        Return mC2MSCD
    End Get
    set(byval value as string)
        mC2MSCD = value
    End Set
End Property

Dim mC2CPCD as string 
Public Property _C2CPCD as string   
    Get
        Return mC2CPCD
    End Get
    set(byval value as string)
        mC2CPCD = value
    End Set
End Property

Dim mC2CSCD as string 
Public Property _C2CSCD as string   
    Get
        Return mC2CSCD
    End Get
    set(byval value as string)
        mC2CSCD = value
    End Set
End Property

Dim mSUSCD as string 
Public Property _SUSCD as string   
    Get
        Return mSUSCD
    End Get
    set(byval value as string)
        mSUSCD = value
    End Set
End Property

Dim mNEWMVC  as long
Public Property _NEWMVC  as long  
    Get
        Return mNEWMVC
    End Get
    set(byval value as long)
        mNEWMVC = value
    End Set
End Property

Dim mAFTER as string 
Public Property _AFTER as string   
    Get
        Return mAFTER
    End Get
    set(byval value as string)
        mAFTER = value
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

Dim mIMVIDNo as string 
Public Property _IMVIDNo as string   
    Get
        Return mIMVIDNo
    End Get
    set(byval value as string)
        mIMVIDNo = value
    End Set
End Property

Dim mCNETAS  as long
Public Property _CNETAS  as long  
    Get
        Return mCNETAS
    End Get
    set(byval value as long)
        mCNETAS = value
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


