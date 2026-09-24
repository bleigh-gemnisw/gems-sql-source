Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXM35H"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_YEAR  = 0
_SEQ  = 0
_ALNAME = string.empty
_AFNAME = string.empty
_AINIT = string.empty
_ADOB  = 0
_ASSN  = 0
_SLNAME = string.empty
_SFNAME = string.empty
_SINIT = string.empty
_SDOB  = 0
_SSSN  = 0
_MADDR = string.empty
_MCITY = string.empty
_MSTATE = string.empty
_MZIP  = 0
_PADDR = string.empty
_PCITY = string.empty
_PSTATE = string.empty
_PZIP  = 0
_OWNER = string.empty
_FILING = string.empty
_NRSHOM = string.empty
_DISAB = string.empty
_TAXRTN = string.empty
_DTSIGN  = 0
_PHONE  = 0
_RELATE = string.empty
_DTRECV  = 0
_INCOME = 0
_INT = 0
_SSRR = 0
_OTHER = 0
_PROPCT = 0
_PGROSS = 0
_GROSS = 0
_NET = 0
_TAX = 0
_FRZTAX = 0
_PCT = 0
_MIN = 0
_MAX = 0
_XBLIND  = 0
_XDISAB  = 0
_XVET  = 0
_XLOCAL  = 0
_XADDL  = 0
_ALLOW = string.empty
_DISRSN = string.empty
_DTASSR  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrkyear As integer, ByVal Wrkseq As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seq = " & Wrkseq
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseq As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seq >= " & Wrkseq & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seq"
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
  Public Function GetbyList(ByVal wrklistno As Integer, ByVal wrkyear As Integer) As DataSet


    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False


    StrSQL = "Select  list#,year,seq,alname,afname,ainit,net,propct,pct,min,max,tax,frztax,allow from " & cFileName _
    & " where list# = " & wrklistno & " and year =" & wrkyear & " order by list#, year"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function

  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    Dim WrkCreditMax As Decimal
    Dim WrkLesser As Decimal
    Dim WrkCredit As Decimal

    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("seq", Type.GetType("System.Int32"))
      .Columns.Add("alname", Type.GetType("System.String"))
      .Columns.Add("afname", Type.GetType("System.String"))
      .Columns.Add("ainit", Type.GetType("System.String"))
      .Columns.Add("net", Type.GetType("System.Int32"))
      .Columns.Add("propct", Type.GetType("System.Decimal"))
      .Columns.Add("pct", Type.GetType("System.Decimal"))
      .Columns.Add("min", Type.GetType("System.Decimal"))
      .Columns.Add("max", Type.GetType("System.Decimal"))
      .Columns.Add("tax", Type.GetType("System.Decimal"))
      .Columns.Add("frztax", Type.GetType("System.Decimal"))
      .Columns.Add("credit", Type.GetType("System.Decimal"))
      .Columns.Add("allow", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)

        If .Item("tax") > 0 Then
          WrkCreditMax = .Item("tax") * (.Item("pct") / 100)
        Else
          WrkCreditMax = .Item("frztax") * (.Item("pct") / 100)
        End If
        If WrkCreditMax > .Item("max") Then
          WrkLesser = .Item("max")
        Else
          WrkLesser = WrkCreditMax
        End If
        If WrkLesser > .Item("min") Then
          WrkCredit = WrkLesser
        Else
          WrkCredit = .Item("min")
        End If


        dr = ds2.Tables(0).NewRow
        dr.Item("list#") = .Item("list#")
        dr.Item("year") = .Item("year")
        dr.Item("seq") = .Item("seq")
        dr.Item("alname") = .Item("alname")
        dr.Item("afname") = .Item("afname")
        dr.Item("ainit") = .Item("ainit")
        dr.Item("net") = .Item("net")
        dr.Item("propct") = .Item("propct")
        dr.Item("pct") = .Item("pct")
        dr.Item("min") = .Item("min")
        dr.Item("max") = .Item("max")
        dr.Item("tax") = .Item("tax")
        dr.Item("frztax") = .Item("frztax")
        dr.Item("credit") = WrkCredit
        dr.Item("allow") = .Item("allow")
        ds2.Tables(0).Rows.Add(dr)
      End With


    Next

    Return ds2
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
  _LISTNO    = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _SEQ      = .Item("SEQ")
  _ALNAME   = .Item("ALNAME")
  _AFNAME   = .Item("AFNAME")
  _AINIT    = .Item("AINIT")
  _ADOB     = .Item("ADOB")
  _ASSN     = .Item("ASSN")
  _SLNAME   = .Item("SLNAME")
  _SFNAME   = .Item("SFNAME")
  _SINIT    = .Item("SINIT")
  _SDOB     = .Item("SDOB")
  _SSSN     = .Item("SSSN")
  _MADDR    = .Item("MADDR")
  _MCITY    = .Item("MCITY")
  _MSTATE   = .Item("MSTATE")
  _MZIP     = .Item("MZIP")
  _PADDR    = .Item("PADDR")
  _PCITY    = .Item("PCITY")
  _PSTATE   = .Item("PSTATE")
  _PZIP     = .Item("PZIP")
  _OWNER    = .Item("OWNER")
  _FILING   = .Item("FILING")
  _NRSHOM   = .Item("NRSHOM")
  _DISAB    = .Item("DISAB")
  _TAXRTN   = .Item("TAXRTN")
  _DTSIGN   = .Item("DTSIGN")
  _PHONE    = .Item("PHONE")
  _RELATE   = .Item("RELATE")
  _DTRECV   = .Item("DTRECV")
  _INCOME   = .Item("INCOME")
  _INT      = .Item("INT")
  _SSRR     = .Item("SSRR")
  _OTHER    = .Item("OTHER")
  _PROPCT   = .Item("PROPCT")
  _PGROSS   = .Item("PGROSS")
  _GROSS    = .Item("GROSS")
  _NET      = .Item("NET")
  _TAX      = .Item("TAX")
  _FRZTAX   = .Item("FRZTAX")
  _PCT      = .Item("PCT")
  _MIN      = .Item("MIN")
  _MAX      = .Item("MAX")
  _XBLIND   = .Item("XBLIND")
  _XDISAB   = .Item("XDISAB")
  _XVET     = .Item("XVET")
  _XLOCAL   = .Item("XLOCAL")
  _XADDL    = .Item("XADDL")
  _ALLOW    = .Item("ALLOW")
  _DISRSN   = .Item("DISRSN")
  _DTASSR   = .Item("DTASSR")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO   
.Item("YEAR") =   _YEAR    
.Item("SEQ") =   _SEQ     
.Item("ALNAME") =   _ALNAME  
.Item("AFNAME") =   _AFNAME  
.Item("AINIT") =   _AINIT   
.Item("ADOB") =   _ADOB    
.Item("ASSN") =   _ASSN    
.Item("SLNAME") =   _SLNAME  
.Item("SFNAME") =   _SFNAME  
.Item("SINIT") =   _SINIT   
.Item("SDOB") =   _SDOB    
.Item("SSSN") =   _SSSN    
.Item("MADDR") =   _MADDR   
.Item("MCITY") =   _MCITY   
.Item("MSTATE") =   _MSTATE  
.Item("MZIP") =   _MZIP    
.Item("PADDR") =   _PADDR   
.Item("PCITY") =   _PCITY   
.Item("PSTATE") =   _PSTATE  
.Item("PZIP") =   _PZIP    
.Item("OWNER") =   _OWNER   
.Item("FILING") =   _FILING  
.Item("NRSHOM") =   _NRSHOM  
.Item("DISAB") =   _DISAB   
.Item("TAXRTN") =   _TAXRTN  
.Item("DTSIGN") =   _DTSIGN  
.Item("PHONE") =   _PHONE   
.Item("RELATE") =   _RELATE  
.Item("DTRECV") =   _DTRECV  
.Item("INCOME") =   _INCOME  
.Item("INT") =   _INT     
.Item("SSRR") =   _SSRR    
.Item("OTHER") =   _OTHER   
.Item("PROPCT") =   _PROPCT  
.Item("PGROSS") =   _PGROSS  
.Item("GROSS") =   _GROSS   
.Item("NET") =   _NET     
.Item("TAX") =   _TAX     
.Item("FRZTAX") =   _FRZTAX  
.Item("PCT") =   _PCT     
.Item("MIN") =   _MIN     
.Item("MAX") =   _MAX     
.Item("XBLIND") =   _XBLIND  
.Item("XDISAB") =   _XDISAB  
.Item("XVET") =   _XVET    
.Item("XLOCAL") =   _XLOCAL  
.Item("XADDL") =   _XADDL   
.Item("ALLOW") =   _ALLOW   
.Item("DISRSN") =   _DISRSN  
.Item("DTASSR") =   _DTASSR  

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

Dim mSEQ  as integer 
Public Property _SEQ  as integer   
    Get
        Return mSEQ
    End Get
    set(byval value as integer)
        mSEQ = value
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

Dim mADOB  as integer 
Public Property _ADOB  as integer   
    Get
        Return mADOB
    End Get
    set(byval value as integer)
        mADOB = value
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

Dim mSDOB  as integer 
Public Property _SDOB  as integer   
    Get
        Return mSDOB
    End Get
    set(byval value as integer)
        mSDOB = value
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

Dim mPADDR as string 
Public Property _PADDR as string   
    Get
        Return mPADDR
    End Get
    set(byval value as string)
        mPADDR = value
    End Set
End Property

Dim mPCITY as string 
Public Property _PCITY as string   
    Get
        Return mPCITY
    End Get
    set(byval value as string)
        mPCITY = value
    End Set
End Property

Dim mPSTATE as string 
Public Property _PSTATE as string   
    Get
        Return mPSTATE
    End Get
    set(byval value as string)
        mPSTATE = value
    End Set
End Property

Dim mPZIP  as integer 
Public Property _PZIP  as integer   
    Get
        Return mPZIP
    End Get
    set(byval value as integer)
        mPZIP = value
    End Set
End Property

Dim mOWNER as string 
Public Property _OWNER as string   
    Get
        Return mOWNER
    End Get
    set(byval value as string)
        mOWNER = value
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

Dim mNRSHOM as string 
Public Property _NRSHOM as string   
    Get
        Return mNRSHOM
    End Get
    set(byval value as string)
        mNRSHOM = value
    End Set
End Property

Dim mDISAB as string 
Public Property _DISAB as string   
    Get
        Return mDISAB
    End Get
    set(byval value as string)
        mDISAB = value
    End Set
End Property

Dim mTAXRTN as string 
Public Property _TAXRTN as string   
    Get
        Return mTAXRTN
    End Get
    set(byval value as string)
        mTAXRTN = value
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

  Dim mPHONE As Long
  Public Property _PHONE As Long
    Get
      Return mPHONE
    End Get
    Set(ByVal value As Long)
      mPHONE = value
    End Set
  End Property

  Dim mRELATE as string 
Public Property _RELATE as string   
    Get
        Return mRELATE
    End Get
    set(byval value as string)
        mRELATE = value
    End Set
End Property

Dim mDTRECV  as integer 
Public Property _DTRECV  as integer   
    Get
        Return mDTRECV
    End Get
    set(byval value as integer)
        mDTRECV = value
    End Set
End Property

  Dim mINCOME As Decimal
  Public Property _INCOME As Decimal
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

  Dim mPROPCT As Decimal
  Public Property _PROPCT As Decimal
    Get
      Return mPROPCT
    End Get
    Set(ByVal value As Decimal)
      mPROPCT = value
    End Set
  End Property

  Dim mPGROSS As Long
  Public Property _PGROSS As Long
    Get
      Return mPGROSS
    End Get
    Set(ByVal value As Long)
      mPGROSS = value
    End Set
  End Property

  Dim mGROSS As Long
  Public Property _GROSS As Long
    Get
      Return mGROSS
    End Get
    Set(ByVal value As Long)
      mGROSS = value
    End Set
  End Property

  Dim mNET As Long
  Public Property _NET As Long
    Get
      Return mNET
    End Get
    Set(ByVal value As Long)
      mNET = value
    End Set
  End Property

  Dim mTAX As Decimal
  Public Property _TAX As Decimal
    Get
      Return mTAX
    End Get
    Set(ByVal value As Decimal)
      mTAX = value
    End Set
  End Property

  Dim mFRZTAX As Decimal
  Public Property _FRZTAX As Decimal
    Get
      Return mFRZTAX
    End Get
    Set(ByVal value As Decimal)
      mFRZTAX = value
    End Set
  End Property

  Dim mPCT As Integer
  Public Property _PCT As Integer
    Get
      Return mPCT
    End Get
    Set(ByVal value As Integer)
      mPCT = value
    End Set
  End Property

  Dim mMIN As Decimal
  Public Property _MIN As Decimal
    Get
      Return mMIN
    End Get
    Set(ByVal value As Decimal)
      mMIN = value
    End Set
  End Property

  Dim mMAX As Decimal
  Public Property _MAX As Decimal
    Get
      Return mMAX
    End Get
    Set(ByVal value As Decimal)
      mMAX = value
    End Set
  End Property

Dim mXBLIND  as integer 
Public Property _XBLIND  as integer   
    Get
        Return mXBLIND
    End Get
    set(byval value as integer)
        mXBLIND = value
    End Set
End Property

Dim mXDISAB  as integer 
Public Property _XDISAB  as integer   
    Get
        Return mXDISAB
    End Get
    set(byval value as integer)
        mXDISAB = value
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

Dim mXLOCAL  as integer 
Public Property _XLOCAL  as integer   
    Get
        Return mXLOCAL
    End Get
    set(byval value as integer)
        mXLOCAL = value
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


