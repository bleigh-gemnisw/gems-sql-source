Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXCOEB"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CCNO  = 0
_CYEAR  = 0
_LISTNo  = 0
_CTYPE = string.empty
_NAME = string.empty
_DIST  = 0
_CT2MC1 = string.empty
_CT2MC2 = string.empty
_CT2MC3 = string.empty
_CT2MC4 = string.empty
_RSNCD = string.empty
_CGRSCH  = 0
_CDATE  = 0
_CDESC = string.empty
_CGRS  = 0
_EXCHG  = 0
_CATG = string.empty
_EXEMP = string.empty
_NTPCD1  = 0
_NTPCD2  = 0
_NTPCD3  = 0
_NTPCD4  = 0
_NTPCD5  = 0
_NTPCD6  = 0
_NTPCD7  = 0
_NTPCD8  = 0
_NTPCD9  = 0
_NTPCDA  = 0
_NTASS1  = 0
_NTASS2  = 0
_NTASS3  = 0
_NTASS4  = 0
_NTASS5  = 0
_NTASS6  = 0
_NTASS7  = 0
_NTASS8  = 0
_NTASS9  = 0
_NTASSA  = 0
_NTEX1  = 0
_NTEX2  = 0
_NTEX3  = 0
_NTEX4  = 0
_NTEX5  = 0
_NTEX6  = 0
_NTEX7  = 0
_NTECD1 = string.empty
_NTECD2 = string.empty
_NTECD3 = string.empty
_NTECD4 = string.empty
_NTECD5 = string.empty
_NTECD6 = string.empty
_NTECD7 = string.empty
_NTNET  = 0
_VINNO = string.empty
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0

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
  _CYEAR    = .Item("CYEAR")
  _LISTNo   = .Item("LIST#")
  _CTYPE    = .Item("CTYPE")
  _NAME     = .Item("NAME")
  _DIST     = .Item("DIST")
  _CT2MC1   = .Item("CT2MC1")
  _CT2MC2   = .Item("CT2MC2")
  _CT2MC3   = .Item("CT2MC3")
  _CT2MC4   = .Item("CT2MC4")
  _RSNCD    = .Item("RSNCD")
  _CGRSCH   = .Item("CGRSCH")
  _CDATE    = .Item("CDATE")
  _CDESC    = .Item("CDESC")
  _CGRS     = .Item("CGRS")
  _EXCHG    = .Item("EXCHG")
  _CATG     = .Item("CATG")
  _EXEMP    = .Item("EXEMP")
  _NTPCD1   = .Item("NTPCD1")
  _NTPCD2   = .Item("NTPCD2")
  _NTPCD3   = .Item("NTPCD3")
  _NTPCD4   = .Item("NTPCD4")
  _NTPCD5   = .Item("NTPCD5")
  _NTPCD6   = .Item("NTPCD6")
  _NTPCD7   = .Item("NTPCD7")
  _NTPCD8   = .Item("NTPCD8")
  _NTPCD9   = .Item("NTPCD9")
  _NTPCDA   = .Item("NTPCDA")
  _NTASS1   = .Item("NTASS1")
  _NTASS2   = .Item("NTASS2")
  _NTASS3   = .Item("NTASS3")
  _NTASS4   = .Item("NTASS4")
  _NTASS5   = .Item("NTASS5")
  _NTASS6   = .Item("NTASS6")
  _NTASS7   = .Item("NTASS7")
  _NTASS8   = .Item("NTASS8")
  _NTASS9   = .Item("NTASS9")
  _NTASSA   = .Item("NTASSA")
  _NTEX1    = .Item("NTEX1")
  _NTEX2    = .Item("NTEX2")
  _NTEX3    = .Item("NTEX3")
  _NTEX4    = .Item("NTEX4")
  _NTEX5    = .Item("NTEX5")
  _NTEX6    = .Item("NTEX6")
  _NTEX7    = .Item("NTEX7")
  _NTECD1   = .Item("NTECD1")
  _NTECD2   = .Item("NTECD2")
  _NTECD3   = .Item("NTECD3")
  _NTECD4   = .Item("NTECD4")
  _NTECD5   = .Item("NTECD5")
  _NTECD6   = .Item("NTECD6")
  _NTECD7   = .Item("NTECD7")
  _NTNET    = .Item("NTNET")
  _VINNO    = .Item("VINNO")
  _PRF      = .Item("PRF")
  _CHDATE   = .Item("CHDATE")
  _CHTIME   = .Item("CHTIME")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CCNO") =   _CCNO    
.Item("CYEAR") =   _CYEAR   
.Item("LIST#") =   _LISTNo  
.Item("CTYPE") =   _CTYPE   
.Item("NAME") =   _NAME    
.Item("DIST") =   _DIST    
.Item("CT2MC1") =   _CT2MC1  
.Item("CT2MC2") =   _CT2MC2  
.Item("CT2MC3") =   _CT2MC3  
.Item("CT2MC4") =   _CT2MC4  
.Item("RSNCD") =   _RSNCD   
.Item("CGRSCH") =   _CGRSCH  
.Item("CDATE") =   _CDATE   
.Item("CDESC") =   _CDESC   
.Item("CGRS") =   _CGRS    
.Item("EXCHG") =   _EXCHG   
.Item("CATG") =   _CATG    
.Item("EXEMP") =   _EXEMP   
.Item("NTPCD1") =   _NTPCD1  
.Item("NTPCD2") =   _NTPCD2  
.Item("NTPCD3") =   _NTPCD3  
.Item("NTPCD4") =   _NTPCD4  
.Item("NTPCD5") =   _NTPCD5  
.Item("NTPCD6") =   _NTPCD6  
.Item("NTPCD7") =   _NTPCD7  
.Item("NTPCD8") =   _NTPCD8  
.Item("NTPCD9") =   _NTPCD9  
.Item("NTPCDA") =   _NTPCDA  
.Item("NTASS1") =   _NTASS1  
.Item("NTASS2") =   _NTASS2  
.Item("NTASS3") =   _NTASS3  
.Item("NTASS4") =   _NTASS4  
.Item("NTASS5") =   _NTASS5  
.Item("NTASS6") =   _NTASS6  
.Item("NTASS7") =   _NTASS7  
.Item("NTASS8") =   _NTASS8  
.Item("NTASS9") =   _NTASS9  
.Item("NTASSA") =   _NTASSA  
.Item("NTEX1") =   _NTEX1   
.Item("NTEX2") =   _NTEX2   
.Item("NTEX3") =   _NTEX3   
.Item("NTEX4") =   _NTEX4   
.Item("NTEX5") =   _NTEX5   
.Item("NTEX6") =   _NTEX6   
.Item("NTEX7") =   _NTEX7   
.Item("NTECD1") =   _NTECD1  
.Item("NTECD2") =   _NTECD2  
.Item("NTECD3") =   _NTECD3  
.Item("NTECD4") =   _NTECD4  
.Item("NTECD5") =   _NTECD5  
.Item("NTECD6") =   _NTECD6  
.Item("NTECD7") =   _NTECD7  
.Item("NTNET") =   _NTNET   
.Item("VINNO") =   _VINNO   
.Item("PRF") =   _PRF     
.Item("CHDATE") =   _CHDATE  
.Item("CHTIME") =   _CHTIME  

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

Dim mCYEAR  as integer 
Public Property _CYEAR  as integer   
    Get
        Return mCYEAR
    End Get
    set(byval value as integer)
        mCYEAR = value
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

Dim mCTYPE as string 
Public Property _CTYPE as string   
    Get
        Return mCTYPE
    End Get
    set(byval value as string)
        mCTYPE = value
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

Dim mCT2MC1 as string 
Public Property _CT2MC1 as string   
    Get
        Return mCT2MC1
    End Get
    set(byval value as string)
        mCT2MC1 = value
    End Set
End Property

Dim mCT2MC2 as string 
Public Property _CT2MC2 as string   
    Get
        Return mCT2MC2
    End Get
    set(byval value as string)
        mCT2MC2 = value
    End Set
End Property

Dim mCT2MC3 as string 
Public Property _CT2MC3 as string   
    Get
        Return mCT2MC3
    End Get
    set(byval value as string)
        mCT2MC3 = value
    End Set
End Property

Dim mCT2MC4 as string 
Public Property _CT2MC4 as string   
    Get
        Return mCT2MC4
    End Get
    set(byval value as string)
        mCT2MC4 = value
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

Dim mCGRSCH  as long
Public Property _CGRSCH  as long  
    Get
        Return mCGRSCH
    End Get
    set(byval value as long)
        mCGRSCH = value
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

Dim mCATG as string 
Public Property _CATG as string   
    Get
        Return mCATG
    End Get
    set(byval value as string)
        mCATG = value
    End Set
End Property

Dim mEXEMP as string 
Public Property _EXEMP as string   
    Get
        Return mEXEMP
    End Get
    set(byval value as string)
        mEXEMP = value
    End Set
End Property

Dim mNTPCD1  as integer 
Public Property _NTPCD1  as integer   
    Get
        Return mNTPCD1
    End Get
    set(byval value as integer)
        mNTPCD1 = value
    End Set
End Property

Dim mNTPCD2  as integer 
Public Property _NTPCD2  as integer   
    Get
        Return mNTPCD2
    End Get
    set(byval value as integer)
        mNTPCD2 = value
    End Set
End Property

Dim mNTPCD3  as integer 
Public Property _NTPCD3  as integer   
    Get
        Return mNTPCD3
    End Get
    set(byval value as integer)
        mNTPCD3 = value
    End Set
End Property

Dim mNTPCD4  as integer 
Public Property _NTPCD4  as integer   
    Get
        Return mNTPCD4
    End Get
    set(byval value as integer)
        mNTPCD4 = value
    End Set
End Property

Dim mNTPCD5  as integer 
Public Property _NTPCD5  as integer   
    Get
        Return mNTPCD5
    End Get
    set(byval value as integer)
        mNTPCD5 = value
    End Set
End Property

Dim mNTPCD6  as integer 
Public Property _NTPCD6  as integer   
    Get
        Return mNTPCD6
    End Get
    set(byval value as integer)
        mNTPCD6 = value
    End Set
End Property

Dim mNTPCD7  as integer 
Public Property _NTPCD7  as integer   
    Get
        Return mNTPCD7
    End Get
    set(byval value as integer)
        mNTPCD7 = value
    End Set
End Property

Dim mNTPCD8  as integer 
Public Property _NTPCD8  as integer   
    Get
        Return mNTPCD8
    End Get
    set(byval value as integer)
        mNTPCD8 = value
    End Set
End Property

Dim mNTPCD9  as integer 
Public Property _NTPCD9  as integer   
    Get
        Return mNTPCD9
    End Get
    set(byval value as integer)
        mNTPCD9 = value
    End Set
End Property

Dim mNTPCDA  as integer 
Public Property _NTPCDA  as integer   
    Get
        Return mNTPCDA
    End Get
    set(byval value as integer)
        mNTPCDA = value
    End Set
End Property

Dim mNTASS1  as long
Public Property _NTASS1  as long  
    Get
        Return mNTASS1
    End Get
    set(byval value as long)
        mNTASS1 = value
    End Set
End Property

Dim mNTASS2  as long
Public Property _NTASS2  as long  
    Get
        Return mNTASS2
    End Get
    set(byval value as long)
        mNTASS2 = value
    End Set
End Property

Dim mNTASS3  as long
Public Property _NTASS3  as long  
    Get
        Return mNTASS3
    End Get
    set(byval value as long)
        mNTASS3 = value
    End Set
End Property

Dim mNTASS4  as long
Public Property _NTASS4  as long  
    Get
        Return mNTASS4
    End Get
    set(byval value as long)
        mNTASS4 = value
    End Set
End Property

Dim mNTASS5  as long
Public Property _NTASS5  as long  
    Get
        Return mNTASS5
    End Get
    set(byval value as long)
        mNTASS5 = value
    End Set
End Property

Dim mNTASS6  as long
Public Property _NTASS6  as long  
    Get
        Return mNTASS6
    End Get
    set(byval value as long)
        mNTASS6 = value
    End Set
End Property

Dim mNTASS7  as long
Public Property _NTASS7  as long  
    Get
        Return mNTASS7
    End Get
    set(byval value as long)
        mNTASS7 = value
    End Set
End Property

Dim mNTASS8  as long
Public Property _NTASS8  as long  
    Get
        Return mNTASS8
    End Get
    set(byval value as long)
        mNTASS8 = value
    End Set
End Property

Dim mNTASS9  as long
Public Property _NTASS9  as long  
    Get
        Return mNTASS9
    End Get
    set(byval value as long)
        mNTASS9 = value
    End Set
End Property

Dim mNTASSA  as long
Public Property _NTASSA  as long  
    Get
        Return mNTASSA
    End Get
    set(byval value as long)
        mNTASSA = value
    End Set
End Property

Dim mNTEX1  as long
Public Property _NTEX1  as long  
    Get
        Return mNTEX1
    End Get
    set(byval value as long)
        mNTEX1 = value
    End Set
End Property

Dim mNTEX2  as long
Public Property _NTEX2  as long  
    Get
        Return mNTEX2
    End Get
    set(byval value as long)
        mNTEX2 = value
    End Set
End Property

Dim mNTEX3  as long
Public Property _NTEX3  as long  
    Get
        Return mNTEX3
    End Get
    set(byval value as long)
        mNTEX3 = value
    End Set
End Property

Dim mNTEX4  as long
Public Property _NTEX4  as long  
    Get
        Return mNTEX4
    End Get
    set(byval value as long)
        mNTEX4 = value
    End Set
End Property

Dim mNTEX5  as long
Public Property _NTEX5  as long  
    Get
        Return mNTEX5
    End Get
    set(byval value as long)
        mNTEX5 = value
    End Set
End Property

Dim mNTEX6  as long
Public Property _NTEX6  as long  
    Get
        Return mNTEX6
    End Get
    set(byval value as long)
        mNTEX6 = value
    End Set
End Property

Dim mNTEX7  as long
Public Property _NTEX7  as long  
    Get
        Return mNTEX7
    End Get
    set(byval value as long)
        mNTEX7 = value
    End Set
End Property

Dim mNTECD1 as string 
Public Property _NTECD1 as string   
    Get
        Return mNTECD1
    End Get
    set(byval value as string)
        mNTECD1 = value
    End Set
End Property

Dim mNTECD2 as string 
Public Property _NTECD2 as string   
    Get
        Return mNTECD2
    End Get
    set(byval value as string)
        mNTECD2 = value
    End Set
End Property

Dim mNTECD3 as string 
Public Property _NTECD3 as string   
    Get
        Return mNTECD3
    End Get
    set(byval value as string)
        mNTECD3 = value
    End Set
End Property

Dim mNTECD4 as string 
Public Property _NTECD4 as string   
    Get
        Return mNTECD4
    End Get
    set(byval value as string)
        mNTECD4 = value
    End Set
End Property

Dim mNTECD5 as string 
Public Property _NTECD5 as string   
    Get
        Return mNTECD5
    End Get
    set(byval value as string)
        mNTECD5 = value
    End Set
End Property

Dim mNTECD6 as string 
Public Property _NTECD6 as string   
    Get
        Return mNTECD6
    End Get
    set(byval value as string)
        mNTECD6 = value
    End Set
End Property

Dim mNTECD7 as string 
Public Property _NTECD7 as string   
    Get
        Return mNTECD7
    End Get
    set(byval value as string)
        mNTECD7 = value
    End Set
End Property

Dim mNTNET  as long
Public Property _NTNET  as long  
    Get
        Return mNTNET
    End Get
    set(byval value as long)
        mNTNET = value
    End Set
End Property

Dim mVINNO as string 
Public Property _VINNO as string   
    Get
        Return mVINNO
    End Get
    set(byval value as string)
        mVINNO = value
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


