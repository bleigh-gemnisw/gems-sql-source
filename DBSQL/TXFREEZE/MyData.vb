Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXFREEZE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _TYPE = String.Empty
    _YEAR = 0
    _ALNAME = String.Empty
    _AFNAME = String.Empty
    _AINIT = String.Empty
    _ASSN = 0
    _SLNAME = String.Empty
    _SFNAME = String.Empty
    _SINIT = String.Empty
    _SSSN = 0
    _MADDR = String.Empty
    _MCITY = String.Empty
    _MSTATE = String.Empty
    _MZIP = 0
    _PADDR = String.Empty
    _PCITY = String.Empty
    _PSTATE = String.Empty
    _PZIP = 0
    _OWNER = String.Empty
    _FILING = String.Empty
    _NRSHOM = String.Empty
    _DISAB = String.Empty
    _TAXRTN = String.Empty
    _DTSIGN = 0
    _PHONE = 0
    _RELATE = String.Empty
    _INCOME = 0
    _INT = 0
    _SSRR = 0
    _DTRECV = 0
    _OTHER = 0
    _PROPCT = 0
    _PGROSS = 0
    _GROSS = 0
    _NET = 0
    _FRZTAX = 0
    _XBLIND = 0
    _XDISAB = 0
    _XVET = 0
    _XLOCAL = 0
    _XADDL = 0
    _ALLOW = String.Empty
    _DISRSN = String.Empty
    _DTASSR = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal WrkType As String, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type='" & WrkType & "' and year = " & Wrkyear
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal WrkType As String, ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type='" & WrkType & "' and year = " & Wrkyear _
      & "or list# = " & Wrklistno & " and type>'" & WrkType & "'" _
      & "or list# > " & Wrklistno & " Order by list#,type,year"
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
      _MADDR = .Item("MADDR")
      _MCITY = .Item("MCITY")
      _MSTATE = .Item("MSTATE")
      _MZIP = .Item("MZIP")
      _PADDR = .Item("PADDR")
      _PCITY = .Item("PCITY")
      _PSTATE = .Item("PSTATE")
      _PZIP = .Item("PZIP")
      _OWNER = .Item("OWNER")
      _FILING = .Item("FILING")
      _NRSHOM = .Item("NRSHOM")
      _DISAB = .Item("DISAB")
      _TAXRTN = .Item("TAXRTN")
      _DTSIGN = .Item("DTSIGN")
      _PHONE = .Item("PHONE")
      _RELATE = .Item("RELATE")
      _INCOME = .Item("INCOME")
      _INT = .Item("INT")
      _SSRR = .Item("SSRR")
      _OTHER = .Item("OTHER")
      _DTRECV = .Item("DTRECV")
      _PROPCT = .Item("PROPCT")
      _PGROSS = .Item("PGROSS")
      _GROSS = .Item("GROSS")
      _NET = .Item("NET")
      _FRZTAX = .Item("FRZTAX")
      _XBLIND = .Item("XBLIND")
      _XDISAB = .Item("XDISAB")
      _XVET = .Item("XVET")
      _XLOCAL = .Item("XLOCAL")
      _XADDL = .Item("XADDL")
      _ALLOW = .Item("ALLOW")
      _DISRSN = .Item("DISRSN")
      _DTASSR = .Item("DTASSR")
    End With
  End Sub

  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("TYPE") = _TYPE
      .Item("YEAR") = _YEAR
      .Item("ALNAME") = _ALNAME
      .Item("AFNAME") = _AFNAME
      .Item("AINIT") = _AINIT
      .Item("ASSN") = _ASSN
      .Item("SLNAME") = _SLNAME
      .Item("SFNAME") = _SFNAME
      .Item("SINIT") = _SINIT
      .Item("SSSN") = _SSSN
      .Item("MADDR") = _MADDR
      .Item("MCITY") = _MCITY
      .Item("MSTATE") = _MSTATE
      .Item("MZIP") = _MZIP
      .Item("PADDR") = _PADDR
      .Item("PCITY") = _PCITY
      .Item("PSTATE") = _PSTATE
      .Item("PZIP") = _PZIP
      .Item("OWNER") = _OWNER
      .Item("FILING") = _FILING
      .Item("NRSHOM") = _NRSHOM
      .Item("DISAB") = _DISAB
      .Item("TAXRTN") = _TAXRTN
      .Item("DTSIGN") = _DTSIGN
      .Item("PHONE") = _PHONE
      .Item("RELATE") = _RELATE
      .Item("INCOME") = _INCOME
      .Item("INT") = _INT
      .Item("SSRR") = _SSRR
      .Item("OTHER") = _OTHER
      .Item("DTRECV") = _DTRECV
      .Item("PROPCT") = _PROPCT
      .Item("PGROSS") = _PGROSS
      .Item("GROSS") = _GROSS
      .Item("NET") = _NET
      .Item("FRZTAX") = _FRZTAX
      .Item("XBLIND") = _XBLIND
      .Item("XDISAB") = _XDISAB
      .Item("XVET") = _XVET
      .Item("XLOCAL") = _XLOCAL
      .Item("XADDL") = _XADDL
      .Item("ALLOW") = _ALLOW
      .Item("DISRSN") = _DISRSN
      .Item("DTASSR") = _DTASSR
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
    End Set
  End Property

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mALNAME As String
  Public Property _ALNAME As String
    Get
      Return mALNAME
    End Get
    Set(ByVal value As String)
      mALNAME = value
    End Set
  End Property

  Dim mAFNAME As String
  Public Property _AFNAME As String
    Get
      Return mAFNAME
    End Get
    Set(ByVal value As String)
      mAFNAME = value
    End Set
  End Property

  Dim mAINIT As String
  Public Property _AINIT As String
    Get
      Return mAINIT
    End Get
    Set(ByVal value As String)
      mAINIT = value
    End Set
  End Property

  Dim mASSN As Long
  Public Property _ASSN As Long
    Get
      Return mASSN
    End Get
    Set(ByVal value As Long)
      mASSN = value
    End Set
  End Property

  Dim mSLNAME As String
  Public Property _SLNAME As String
    Get
      Return mSLNAME
    End Get
    Set(ByVal value As String)
      mSLNAME = value
    End Set
  End Property

  Dim mSFNAME As String
  Public Property _SFNAME As String
    Get
      Return mSFNAME
    End Get
    Set(ByVal value As String)
      mSFNAME = value
    End Set
  End Property

  Dim mSINIT As String
  Public Property _SINIT As String
    Get
      Return mSINIT
    End Get
    Set(ByVal value As String)
      mSINIT = value
    End Set
  End Property

  Dim mSSSN As Long
  Public Property _SSSN As Long
    Get
      Return mSSSN
    End Get
    Set(ByVal value As Long)
      mSSSN = value
    End Set
  End Property


  Dim mMADDR As String
  Public Property _MADDR As String
    Get
      Return mMADDR
    End Get
    Set(ByVal value As String)
      mMADDR = value
    End Set
  End Property

  Dim mMCITY As String
  Public Property _MCITY As String
    Get
      Return mMCITY
    End Get
    Set(ByVal value As String)
      mMCITY = value
    End Set
  End Property

  Dim mMSTATE As String
  Public Property _MSTATE As String
    Get
      Return mMSTATE
    End Get
    Set(ByVal value As String)
      mMSTATE = value
    End Set
  End Property

  Dim mMZIP As Integer
  Public Property _MZIP As Integer
    Get
      Return mMZIP
    End Get
    Set(ByVal value As Integer)
      mMZIP = value
    End Set
  End Property
  Dim mPADDR As String
  Public Property _PADDR As String
    Get
      Return mPADDR
    End Get
    Set(ByVal value As String)
      mPADDR = value
    End Set
  End Property

  Dim mPCITY As String
  Public Property _PCITY As String
    Get
      Return mPCITY
    End Get
    Set(ByVal value As String)
      mPCITY = value
    End Set
  End Property

  Dim mPSTATE As String
  Public Property _PSTATE As String
    Get
      Return mPSTATE
    End Get
    Set(ByVal value As String)
      mPSTATE = value
    End Set
  End Property

  Dim mPZIP As Integer
  Public Property _PZIP As Integer
    Get
      Return mPZIP
    End Get
    Set(ByVal value As Integer)
      mPZIP = value
    End Set
  End Property

  Dim mOWNER As String
  Public Property _OWNER As String
    Get
      Return mOWNER
    End Get
    Set(ByVal value As String)
      mOWNER = value
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
  Dim mFILING As String
  Public Property _FILING As String
    Get
      Return mFILING
    End Get
    Set(ByVal value As String)
      mFILING = value
    End Set
  End Property
  Dim mNRSHOM As String
  Public Property _NRSHOM As String
    Get
      Return mNRSHOM
    End Get
    Set(ByVal value As String)
      mNRSHOM = value
    End Set
  End Property

  Dim mDISAB As String
  Public Property _DISAB As String
    Get
      Return mDISAB
    End Get
    Set(ByVal value As String)
      mDISAB = value
    End Set
  End Property

  Dim mTAXRTN As String
  Public Property _TAXRTN As String
    Get
      Return mTAXRTN
    End Get
    Set(ByVal value As String)
      mTAXRTN = value
    End Set
  End Property
  Dim mDTSIGN As Integer
  Public Property _DTSIGN As Integer
    Get
      Return mDTSIGN
    End Get
    Set(ByVal value As Integer)
      mDTSIGN = value
    End Set
  End Property
  Dim mRELATE As String
  Public Property _RELATE As String
    Get
      Return mRELATE
    End Get
    Set(ByVal value As String)
      mRELATE = value
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
  Dim mDTRECV As Integer
  Public Property _DTRECV As Integer
    Get
      Return mDTRECV
    End Get
    Set(ByVal value As Integer)
      mDTRECV = value
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

  Dim mFRZTAX As Decimal
  Public Property _FRZTAX As Decimal
    Get
      Return mFRZTAX
    End Get
    Set(ByVal value As Decimal)
      mFRZTAX = value
    End Set
  End Property
  Dim mXBLIND As Integer
  Public Property _XBLIND As Integer
    Get
      Return mXBLIND
    End Get
    Set(ByVal value As Integer)
      mXBLIND = value
    End Set
  End Property

  Dim mXDISAB As Integer
  Public Property _XDISAB As Integer
    Get
      Return mXDISAB
    End Get
    Set(ByVal value As Integer)
      mXDISAB = value
    End Set
  End Property

  Dim mXVET As Integer
  Public Property _XVET As Integer
    Get
      Return mXVET
    End Get
    Set(ByVal value As Integer)
      mXVET = value
    End Set
  End Property

  Dim mXLOCAL As Integer
  Public Property _XLOCAL As Integer
    Get
      Return mXLOCAL
    End Get
    Set(ByVal value As Integer)
      mXLOCAL = value
    End Set
  End Property

  Dim mXADDL As Integer
  Public Property _XADDL As Integer
    Get
      Return mXADDL
    End Get
    Set(ByVal value As Integer)
      mXADDL = value
    End Set
  End Property

  Dim mALLOW As String
  Public Property _ALLOW As String
    Get
      Return mALLOW
    End Get
    Set(ByVal value As String)
      mALLOW = value
    End Set
  End Property

  Dim mDISRSN As String
  Public Property _DISRSN As String
    Get
      Return mDISRSN
    End Get
    Set(ByVal value As String)
      mDISRSN = value
    End Set
  End Property

  Dim mDTASSR As Integer
  Public Property _DTASSR As Integer
    Get
      Return mDTASSR
    End Get
    Set(ByVal value As Integer)
      mDTASSR = value
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
#End Region
End Class


