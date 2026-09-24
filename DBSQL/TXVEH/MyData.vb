Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXVEH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_REGID  = 0
_VEHID  = 0
_PCUST  = 0
_SCUST  = 0
_VMAKE = string.empty
_YEAR  = 0
_VMODEL = string.empty
_BODY = string.empty
_CLASS  = 0
_CLASSD = string.empty
_REGNO = string.empty
_VINNO = string.empty
_CYLAX  = 0
_VPCLR = string.empty
_VSCLR = string.empty
_SEAT  = 0
_LWT  = 0
_GWT  = 0
_ORIG  = 0
_TRVAL  = 0
_LNVAL  = 0
_MSRP  = 0
_NADA = string.empty
_STRDT  = 0
_ENDDT  = 0
_DADD1 = string.empty
_DADD2 = string.empty
_DCITY = string.empty
_DSTATE = string.empty
_DZIPA = string.empty
_LEASE = string.empty
_LCUST  = 0
_LNAME = string.empty
_LBUS = string.empty
_LADD1 = string.empty
_LADD2 = string.empty
_LCITY = string.empty
_LSTATE = string.empty
_LZIPA = string.empty
_RGLATE = string.empty
_CHDATE  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkvehid As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where vehid = " & Wrkvehid
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
  Public Function PosData(ByVal Wrkvehid As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where vehid >= " & Wrkvehid & " Order by vehid"
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

    StrSQL = "Select top 1 * from " & cFileName & " order by vehid desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("vehid") + 1
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
  _REGID    = .Item("REGID")
  _VEHID    = .Item("VEHID")
  _PCUST    = .Item("PCUST")
  _SCUST    = .Item("SCUST")
  _VMAKE    = .Item("VMAKE")
  _YEAR     = .Item("YEAR")
  _VMODEL   = .Item("VMODEL")
  _BODY     = .Item("BODY")
  _CLASS    = .Item("CLASS")
  _CLASSD   = .Item("CLASSD")
  _REGNO    = .Item("REGNO")
  _VINNO    = .Item("VINNO")
  _CYLAX    = .Item("CYLAX")
  _VPCLR    = .Item("VPCLR")
  _VSCLR    = .Item("VSCLR")
  _SEAT     = .Item("SEAT")
  _LWT      = .Item("LWT")
  _GWT      = .Item("GWT")
  _ORIG     = .Item("ORIG")
  _TRVAL    = .Item("TRVAL")
  _LNVAL    = .Item("LNVAL")
  _MSRP     = .Item("MSRP")
  _NADA     = .Item("NADA")
  _STRDT    = .Item("STRDT")
  _ENDDT    = .Item("ENDDT")
  _DADD1    = .Item("DADD1")
  _DADD2    = .Item("DADD2")
  _DCITY    = .Item("DCITY")
  _DSTATE   = .Item("DSTATE")
  _DZIPA    = .Item("DZIPA")
  _LEASE    = .Item("LEASE")
  _LCUST    = .Item("LCUST")
  _LNAME    = .Item("LNAME")
  _LBUS     = .Item("LBUS")
  _LADD1    = .Item("LADD1")
  _LADD2    = .Item("LADD2")
  _LCITY    = .Item("LCITY")
  _LSTATE   = .Item("LSTATE")
  _LZIPA    = .Item("LZIPA")
  _RGLATE   = .Item("RGLATE")
  _CHDATE   = .Item("CHDATE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("REGID") =   _REGID   
.Item("VEHID") =   _VEHID   
.Item("PCUST") =   _PCUST   
.Item("SCUST") =   _SCUST   
.Item("VMAKE") =   _VMAKE   
.Item("YEAR") =   _YEAR    
.Item("VMODEL") =   _VMODEL  
.Item("BODY") =   _BODY    
.Item("CLASS") =   _CLASS   
.Item("CLASSD") =   _CLASSD  
.Item("REGNO") =   _REGNO   
.Item("VINNO") =   _VINNO   
.Item("CYLAX") =   _CYLAX   
.Item("VPCLR") =   _VPCLR   
.Item("VSCLR") =   _VSCLR   
.Item("SEAT") =   _SEAT    
.Item("LWT") =   _LWT     
.Item("GWT") =   _GWT     
.Item("ORIG") =   _ORIG    
.Item("TRVAL") =   _TRVAL   
.Item("LNVAL") =   _LNVAL   
.Item("MSRP") =   _MSRP    
.Item("NADA") =   _NADA    
.Item("STRDT") =   _STRDT   
.Item("ENDDT") =   _ENDDT   
.Item("DADD1") =   _DADD1   
.Item("DADD2") =   _DADD2   
.Item("DCITY") =   _DCITY   
.Item("DSTATE") =   _DSTATE  
.Item("DZIPA") =   _DZIPA   
.Item("LEASE") =   _LEASE   
.Item("LCUST") =   _LCUST   
.Item("LNAME") =   _LNAME   
.Item("LBUS") =   _LBUS    
.Item("LADD1") =   _LADD1   
.Item("LADD2") =   _LADD2   
.Item("LCITY") =   _LCITY   
.Item("LSTATE") =   _LSTATE  
.Item("LZIPA") =   _LZIPA   
.Item("RGLATE") =   _RGLATE  
.Item("CHDATE") =   _CHDATE  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mREGID  as long
Public Property _REGID  as long  
    Get
        Return mREGID
    End Get
    set(byval value as long)
        mREGID = value
    End Set
End Property

Dim mVEHID  as long
Public Property _VEHID  as long  
    Get
        Return mVEHID
    End Get
    set(byval value as long)
        mVEHID = value
    End Set
End Property

Dim mPCUST  as long
Public Property _PCUST  as long  
    Get
        Return mPCUST
    End Get
    set(byval value as long)
        mPCUST = value
    End Set
End Property

Dim mSCUST  as long
Public Property _SCUST  as long  
    Get
        Return mSCUST
    End Get
    set(byval value as long)
        mSCUST = value
    End Set
End Property

Dim mVMAKE as string 
Public Property _VMAKE as string   
    Get
        Return mVMAKE
    End Get
    set(byval value as string)
        mVMAKE = value
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

Dim mVMODEL as string 
Public Property _VMODEL as string   
    Get
        Return mVMODEL
    End Get
    set(byval value as string)
        mVMODEL = value
    End Set
End Property

Dim mBODY as string 
Public Property _BODY as string   
    Get
        Return mBODY
    End Get
    set(byval value as string)
        mBODY = value
    End Set
End Property

Dim mCLASS  as integer 
Public Property _CLASS  as integer   
    Get
        Return mCLASS
    End Get
    set(byval value as integer)
        mCLASS = value
    End Set
End Property

Dim mCLASSD as string 
Public Property _CLASSD as string   
    Get
        Return mCLASSD
    End Get
    set(byval value as string)
        mCLASSD = value
    End Set
End Property

Dim mREGNO as string 
Public Property _REGNO as string   
    Get
        Return mREGNO
    End Get
    set(byval value as string)
        mREGNO = value
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

Dim mCYLAX  as integer 
Public Property _CYLAX  as integer   
    Get
        Return mCYLAX
    End Get
    set(byval value as integer)
        mCYLAX = value
    End Set
End Property

Dim mVPCLR as string 
Public Property _VPCLR as string   
    Get
        Return mVPCLR
    End Get
    set(byval value as string)
        mVPCLR = value
    End Set
End Property

Dim mVSCLR as string 
Public Property _VSCLR as string   
    Get
        Return mVSCLR
    End Get
    set(byval value as string)
        mVSCLR = value
    End Set
End Property

Dim mSEAT  as integer 
Public Property _SEAT  as integer   
    Get
        Return mSEAT
    End Get
    set(byval value as integer)
        mSEAT = value
    End Set
End Property

Dim mLWT  as integer 
Public Property _LWT  as integer   
    Get
        Return mLWT
    End Get
    set(byval value as integer)
        mLWT = value
    End Set
End Property

Dim mGWT  as integer 
Public Property _GWT  as integer   
    Get
        Return mGWT
    End Get
    set(byval value as integer)
        mGWT = value
    End Set
End Property

Dim mORIG  as integer 
Public Property _ORIG  as integer   
    Get
        Return mORIG
    End Get
    set(byval value as integer)
        mORIG = value
    End Set
End Property

Dim mTRVAL  as integer 
Public Property _TRVAL  as integer   
    Get
        Return mTRVAL
    End Get
    set(byval value as integer)
        mTRVAL = value
    End Set
End Property

Dim mLNVAL  as integer 
Public Property _LNVAL  as integer   
    Get
        Return mLNVAL
    End Get
    set(byval value as integer)
        mLNVAL = value
    End Set
End Property

Dim mMSRP  as integer 
Public Property _MSRP  as integer   
    Get
        Return mMSRP
    End Get
    set(byval value as integer)
        mMSRP = value
    End Set
End Property

Dim mNADA as string 
Public Property _NADA as string   
    Get
        Return mNADA
    End Get
    set(byval value as string)
        mNADA = value
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

Dim mENDDT  as integer 
Public Property _ENDDT  as integer   
    Get
        Return mENDDT
    End Get
    set(byval value as integer)
        mENDDT = value
    End Set
End Property

Dim mDADD1 as string 
Public Property _DADD1 as string   
    Get
        Return mDADD1
    End Get
    set(byval value as string)
        mDADD1 = value
    End Set
End Property

Dim mDADD2 as string 
Public Property _DADD2 as string   
    Get
        Return mDADD2
    End Get
    set(byval value as string)
        mDADD2 = value
    End Set
End Property

Dim mDCITY as string 
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

Dim mDZIPA as string 
Public Property _DZIPA as string   
    Get
        Return mDZIPA
    End Get
    set(byval value as string)
        mDZIPA = value
    End Set
End Property

Dim mLEASE as string 
Public Property _LEASE as string   
    Get
        Return mLEASE
    End Get
    set(byval value as string)
        mLEASE = value
    End Set
End Property

Dim mLCUST  as long
Public Property _LCUST  as long  
    Get
        Return mLCUST
    End Get
    set(byval value as long)
        mLCUST = value
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

Dim mLBUS as string 
Public Property _LBUS as string   
    Get
        Return mLBUS
    End Get
    set(byval value as string)
        mLBUS = value
    End Set
End Property

Dim mLADD1 as string 
Public Property _LADD1 as string   
    Get
        Return mLADD1
    End Get
    set(byval value as string)
        mLADD1 = value
    End Set
End Property

Dim mLADD2 as string 
Public Property _LADD2 as string   
    Get
        Return mLADD2
    End Get
    set(byval value as string)
        mLADD2 = value
    End Set
End Property

Dim mLCITY as string 
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

Dim mLZIPA as string 
Public Property _LZIPA as string   
    Get
        Return mLZIPA
    End Get
    set(byval value as string)
        mLZIPA = value
    End Set
End Property

Dim mRGLATE as string 
Public Property _RGLATE as string   
    Get
        Return mRGLATE
    End Get
    set(byval value as string)
        mRGLATE = value
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


