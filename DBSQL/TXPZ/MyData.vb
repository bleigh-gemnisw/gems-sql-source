Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXPZ"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAT = string.empty
_LISTNo  = 0
_CARDNO = string.empty
_NONCON = string.empty
_ZONING = string.empty
_GRSACR  = 0
_BLDACR  = 0
_AERMAP = string.empty
_BEDRMS  = 0
_PERM1  = 0
_PERM2  = 0
_PERM3  = 0
_PERM4  = 0
_PERM5  = 0
_PERDT1  = 0
_PERDT2  = 0
_PERDT3  = 0
_PERDT4  = 0
_PERDT5  = 0
_PERCT1  = 0
_PERCT2  = 0
_PERCT3  = 0
_PERCT4  = 0
_PERCT5  = 0
_PCY1 = string.empty
_PCY2 = string.empty
_PCY3 = string.empty
_PCY4 = string.empty
_PCY5 = string.empty
_SEWPHS = string.empty
_LTSZ = string.empty
_BATH  = 0
_SEP = string.empty
_PRF = string.empty
_CHDATE  = 0
_CHTIME  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno
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
Public Function PosData(ByVal Wrklistno As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# >= " & Wrklistno & " Order by list#"
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
      _CAT = .Item("CAT")
      _LISTNo = .Item("LIST#")
      _CARDNO = .Item("CARDNO")
      _NONCON = .Item("NONCON")
      _ZONING = .Item("ZONING")
      _GRSACR = .Item("GRSACR")
      _BLDACR = .Item("BLDACR")
      _AERMAP = .Item("AERMAP")
      _BEDRMS = .Item("BEDRMS")
      _PERM1 = .Item("PERM1")
      _PERM2 = .Item("PERM2")
      _PERM3 = .Item("PERM3")
      _PERM4 = .Item("PERM4")
      _PERM5 = .Item("PERM5")
      _PERDT1 = .Item("PERDT1")
      _PERDT2 = .Item("PERDT2")
      _PERDT3 = .Item("PERDT3")
      _PERDT4 = .Item("PERDT4")
      _PERDT5 = .Item("PERDT5")
      _PERCT1 = .Item("PERCT1")
      _PERCT2 = .Item("PERCT2")
      _PERCT3 = .Item("PERCT3")
      _PERCT4 = .Item("PERCT4")
      _PERCT5 = .Item("PERCT5")
      _PCY1 = .Item("PCY1")
      _PCY2 = .Item("PCY2")
      _PCY3 = .Item("PCY3")
      _PCY4 = .Item("PCY4")
      _PCY5 = .Item("PCY5")
      _SEWPHS = .Item("SEWPHS")
      _LTSZ = .Item("LTSZ")
      _BATH = .Item("BATH")
      _SEP = .Item("SEP")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CAT") = _CAT
      .Item("LIST#") = _LISTNo
      .Item("CARDNO") = _CARDNO
      .Item("NONCON") = _NONCON
      .Item("ZONING") = _ZONING
      .Item("GRSACR") = _GRSACR
      .Item("BLDACR") = _BLDACR
      .Item("AERMAP") = _AERMAP
      .Item("BEDRMS") = _BEDRMS
      .Item("PERM1") = _PERM1
      .Item("PERM2") = _PERM2
      .Item("PERM3") = _PERM3
      .Item("PERM4") = _PERM4
      .Item("PERM5") = _PERM5
      .Item("PERDT1") = _PERDT1
      .Item("PERDT2") = _PERDT2
      .Item("PERDT3") = _PERDT3
      .Item("PERDT4") = _PERDT4
      .Item("PERDT5") = _PERDT5
      .Item("PERCT1") = _PERCT1
      .Item("PERCT2") = _PERCT2
      .Item("PERCT3") = _PERCT3
      .Item("PERCT4") = _PERCT4
      .Item("PERCT5") = _PERCT5
      .Item("PCY1") = _PCY1
      .Item("PCY2") = _PCY2
      .Item("PCY3") = _PCY3
      .Item("PCY4") = _PCY4
      .Item("PCY5") = _PCY5
      .Item("SEWPHS") = _SEWPHS
      .Item("LTSZ") = _LTSZ
      .Item("BATH") = _BATH
      .Item("SEP") = _SEP
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME
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

Dim mLISTNo  as integer 
Public Property _LISTNo  as integer   
    Get
        Return mLISTNo
    End Get
    set(byval value as integer)
        mLISTNo = value
    End Set
End Property

Dim mCARDNO as string 
Public Property _CARDNO as string   
    Get
        Return mCARDNO
    End Get
    set(byval value as string)
        mCARDNO = value
    End Set
End Property

Dim mNONCON as string 
Public Property _NONCON as string   
    Get
        Return mNONCON
    End Get
    set(byval value as string)
        mNONCON = value
    End Set
End Property

Dim mZONING as string 
Public Property _ZONING as string   
    Get
        Return mZONING
    End Get
    set(byval value as string)
        mZONING = value
    End Set
End Property

Dim mGRSACR  as integer 
Public Property _GRSACR  as integer   
    Get
        Return mGRSACR
    End Get
    set(byval value as integer)
        mGRSACR = value
    End Set
End Property

Dim mBLDACR  as integer 
Public Property _BLDACR  as integer   
    Get
        Return mBLDACR
    End Get
    set(byval value as integer)
        mBLDACR = value
    End Set
End Property

Dim mAERMAP as string 
Public Property _AERMAP as string   
    Get
        Return mAERMAP
    End Get
    set(byval value as string)
        mAERMAP = value
    End Set
End Property

Dim mBEDRMS  as integer 
Public Property _BEDRMS  as integer   
    Get
        Return mBEDRMS
    End Get
    set(byval value as integer)
        mBEDRMS = value
    End Set
End Property

Dim mPERM1  as integer 
Public Property _PERM1  as integer   
    Get
        Return mPERM1
    End Get
    set(byval value as integer)
        mPERM1 = value
    End Set
End Property

Dim mPERM2  as integer 
Public Property _PERM2  as integer   
    Get
        Return mPERM2
    End Get
    set(byval value as integer)
        mPERM2 = value
    End Set
End Property

Dim mPERM3  as integer 
Public Property _PERM3  as integer   
    Get
        Return mPERM3
    End Get
    set(byval value as integer)
        mPERM3 = value
    End Set
End Property

Dim mPERM4  as integer 
Public Property _PERM4  as integer   
    Get
        Return mPERM4
    End Get
    set(byval value as integer)
        mPERM4 = value
    End Set
End Property

Dim mPERM5  as integer 
Public Property _PERM5  as integer   
    Get
        Return mPERM5
    End Get
    set(byval value as integer)
        mPERM5 = value
    End Set
End Property

Dim mPERDT1  as integer 
Public Property _PERDT1  as integer   
    Get
        Return mPERDT1
    End Get
    set(byval value as integer)
        mPERDT1 = value
    End Set
End Property

Dim mPERDT2  as integer 
Public Property _PERDT2  as integer   
    Get
        Return mPERDT2
    End Get
    set(byval value as integer)
        mPERDT2 = value
    End Set
End Property

Dim mPERDT3  as integer 
Public Property _PERDT3  as integer   
    Get
        Return mPERDT3
    End Get
    set(byval value as integer)
        mPERDT3 = value
    End Set
End Property

Dim mPERDT4  as integer 
Public Property _PERDT4  as integer   
    Get
        Return mPERDT4
    End Get
    set(byval value as integer)
        mPERDT4 = value
    End Set
End Property

Dim mPERDT5  as integer 
Public Property _PERDT5  as integer   
    Get
        Return mPERDT5
    End Get
    set(byval value as integer)
        mPERDT5 = value
    End Set
End Property

Dim mPERCT1  as long
Public Property _PERCT1  as long  
    Get
        Return mPERCT1
    End Get
    set(byval value as long)
        mPERCT1 = value
    End Set
End Property

Dim mPERCT2  as long
Public Property _PERCT2  as long  
    Get
        Return mPERCT2
    End Get
    set(byval value as long)
        mPERCT2 = value
    End Set
End Property

Dim mPERCT3  as long
Public Property _PERCT3  as long  
    Get
        Return mPERCT3
    End Get
    set(byval value as long)
        mPERCT3 = value
    End Set
End Property

Dim mPERCT4  as long
Public Property _PERCT4  as long  
    Get
        Return mPERCT4
    End Get
    set(byval value as long)
        mPERCT4 = value
    End Set
End Property

Dim mPERCT5  as long
Public Property _PERCT5  as long  
    Get
        Return mPERCT5
    End Get
    set(byval value as long)
        mPERCT5 = value
    End Set
End Property

Dim mPCY1 as string 
Public Property _PCY1 as string   
    Get
        Return mPCY1
    End Get
    set(byval value as string)
        mPCY1 = value
    End Set
End Property

Dim mPCY2 as string 
Public Property _PCY2 as string   
    Get
        Return mPCY2
    End Get
    set(byval value as string)
        mPCY2 = value
    End Set
End Property

Dim mPCY3 as string 
Public Property _PCY3 as string   
    Get
        Return mPCY3
    End Get
    set(byval value as string)
        mPCY3 = value
    End Set
End Property

Dim mPCY4 as string 
Public Property _PCY4 as string   
    Get
        Return mPCY4
    End Get
    set(byval value as string)
        mPCY4 = value
    End Set
End Property

Dim mPCY5 as string 
Public Property _PCY5 as string   
    Get
        Return mPCY5
    End Get
    set(byval value as string)
        mPCY5 = value
    End Set
End Property

Dim mSEWPHS as string 
Public Property _SEWPHS as string   
    Get
        Return mSEWPHS
    End Get
    set(byval value as string)
        mSEWPHS = value
    End Set
End Property

Dim mLTSZ as string 
Public Property _LTSZ as string   
    Get
        Return mLTSZ
    End Get
    set(byval value as string)
        mLTSZ = value
    End Set
End Property

Dim mBATH  as integer 
Public Property _BATH  as integer   
    Get
        Return mBATH
    End Get
    set(byval value as integer)
        mBATH = value
    End Set
End Property

Dim mSEP as string 
Public Property _SEP as string   
    Get
        Return mSEP
    End Get
    set(byval value as string)
        mSEP = value
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


