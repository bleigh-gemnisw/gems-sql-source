Imports System.Data
Imports System.Data.SqlClient
Public Class TXDCPP
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Dim MyFileName As String
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection, ByVal WrkFileName As String)
    Conn = WrkConn
    MyFileName = WrkFileName
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _YEAR = 0
    _OWNAME = String.Empty
    _SNAME = String.Empty
    _DBA = String.Empty
    _LOCNO = String.Empty
    _LOC = String.Empty
    _DNAME = String.Empty
    _DADDR = String.Empty
    _DADDR2 = String.Empty
    _DCITY = String.Empty
    _DSTATE = String.Empty
    _DZIP5 = 0
    _DZIP4 = 0
    _DPHONE = String.Empty
    _DFAX = String.Empty
    _DEMAIL = String.Empty
    _LNAME = String.Empty
    _LADDR = String.Empty
    _LADDR2 = String.Empty
    _LCITY = String.Empty
    _LSTATE = String.Empty
    _LZIP5 = 0
    _LZIP4 = 0
    _LPHONE = String.Empty
    _LFAX = String.Empty
    _LEMAIL = String.Empty
    _BUSDES = String.Empty
    _NOEMPS = 0
    _STRDT = 0
    _SQFEET = 0
    _OWN = String.Empty
    _OWNTYP = String.Empty
    _OWNOTH = String.Empty
    _BUSCAT = String.Empty
    _BUSOTH = String.Empty
    _BUSCD = String.Empty
    _PROPCT = String.Empty
    _OTHBUS = String.Empty
    _STATUS = String.Empty
    _PRTCOM = String.Empty
    _RECVDT = 0
    _FILSTS = String.Empty
    _ASECCD = String.Empty
    _ATITLE = String.Empty
    _ANAME = String.Empty
    _ADATE = 0
    _BTITLE = String.Empty
    _BNAME = String.Empty
    _BDATE = 0
    _BWIT = String.Empty
    _BWITDT = 0
    _BWITCD = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " And year >= " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, MyFileName)
    objCommand = Nothing
    Return ds
  End Function
  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, MyFileName)
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
      _PRTCOM = .Item("PRTCOM")
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

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("OWNAME") = _OWNAME
      .Item("SNAME") = _SNAME
      .Item("DBA") = _DBA
      .Item("LOC#") = _LOCNO
      .Item("LOC") = _LOC
      .Item("DNAME") = _DNAME
      .Item("DADDR") = _DADDR
      .Item("DADDR2") = _DADDR2
      .Item("DCITY") = _DCITY
      .Item("DSTATE") = _DSTATE
      .Item("DZIP5") = _DZIP5
      .Item("DZIP4") = _DZIP4
      .Item("DPHONE") = _DPHONE
      .Item("DFAX") = _DFAX
      .Item("DEMAIL") = _DEMAIL
      .Item("LNAME") = _LNAME
      .Item("LADDR") = _LADDR
      .Item("LADDR2") = _LADDR2
      .Item("LCITY") = _LCITY
      .Item("LSTATE") = _LSTATE
      .Item("LZIP5") = _LZIP5
      .Item("LZIP4") = _LZIP4
      .Item("LPHONE") = _LPHONE
      .Item("LFAX") = _LFAX
      .Item("LEMAIL") = _LEMAIL
      .Item("BUSDES") = _BUSDES
      .Item("NOEMPS") = _NOEMPS
      .Item("STRDT") = _STRDT
      .Item("SQFEET") = _SQFEET
      .Item("OWN") = _OWN
      .Item("OWNTYP") = _OWNTYP
      .Item("OWNOTH") = _OWNOTH
      .Item("BUSCAT") = _BUSCAT
      .Item("BUSOTH") = _BUSOTH
      .Item("BUSCD") = _BUSCD
      .Item("PROPCT") = _PROPCT
      .Item("OTHBUS") = _OTHBUS
      .Item("STATUS") = _STATUS
      .Item("PRTCOM") = _PRTCOM
      .Item("RECVDT") = _RECVDT
      .Item("FILSTS") = _FILSTS
      .Item("ASECCD") = _ASECCD
      .Item("ATITLE") = _ATITLE
      .Item("ANAME") = _ANAME
      .Item("ADATE") = _ADATE
      .Item("BTITLE") = _BTITLE
      .Item("BNAME") = _BNAME
      .Item("BDATE") = _BDATE
      .Item("BWIT") = _BWIT
      .Item("BWITDT") = _BWITDT
      .Item("BWITCD") = _BWITCD

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

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mOWNAME As String
  Public Property _OWNAME As String
    Get
      Return mOWNAME
    End Get
    Set(ByVal value As String)
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

  Dim mDBA As String
  Public Property _DBA As String
    Get
      Return mDBA
    End Get
    Set(ByVal value As String)
      mDBA = value
    End Set
  End Property

  Dim mLOCNO As String
  Public Property _LOCNO As String
    Get
      Return mLOCNO
    End Get
    Set(ByVal value As String)
      mLOCNO = value
    End Set
  End Property

  Dim mLOC As String
  Public Property _LOC As String
    Get
      Return mLOC
    End Get
    Set(ByVal value As String)
      mLOC = value
    End Set
  End Property

  Dim mDNAME As String
  Public Property _DNAME As String
    Get
      Return mDNAME
    End Get
    Set(ByVal value As String)
      mDNAME = value
    End Set
  End Property

  Dim mDADDR As String
  Public Property _DADDR As String
    Get
      Return mDADDR
    End Get
    Set(ByVal value As String)
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
  Public Property _DCITY As String
    Get
      Return mDCITY
    End Get
    Set(ByVal value As String)
      mDCITY = value
    End Set
  End Property

  Dim mDSTATE As String
  Public Property _DSTATE As String
    Get
      Return mDSTATE
    End Get
    Set(ByVal value As String)
      mDSTATE = value
    End Set
  End Property

  Dim mDZIP5 As Integer
  Public Property _DZIP5 As Integer
    Get
      Return mDZIP5
    End Get
    Set(ByVal value As Integer)
      mDZIP5 = value
    End Set
  End Property

  Dim mDZIP4 As Integer
  Public Property _DZIP4 As Integer
    Get
      Return mDZIP4
    End Get
    Set(ByVal value As Integer)
      mDZIP4 = value
    End Set
  End Property

  Dim mDPHONE As String
  Public Property _DPHONE As String
    Get
      Return mDPHONE
    End Get
    Set(ByVal value As String)
      mDPHONE = value
    End Set
  End Property

  Dim mDFAX As String
  Public Property _DFAX As String
    Get
      Return mDFAX
    End Get
    Set(ByVal value As String)
      mDFAX = value
    End Set
  End Property

  Dim mDEMAIL As String
  Public Property _DEMAIL As String
    Get
      Return mDEMAIL
    End Get
    Set(ByVal value As String)
      mDEMAIL = value
    End Set
  End Property

  Dim mLNAME As String
  Public Property _LNAME As String
    Get
      Return mLNAME
    End Get
    Set(ByVal value As String)
      mLNAME = value
    End Set
  End Property

  Dim mLADDR As String
  Public Property _LADDR As String
    Get
      Return mLADDR
    End Get
    Set(ByVal value As String)
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
  Public Property _LCITY As String
    Get
      Return mLCITY
    End Get
    Set(ByVal value As String)
      mLCITY = value
    End Set
  End Property

  Dim mLSTATE As String
  Public Property _LSTATE As String
    Get
      Return mLSTATE
    End Get
    Set(ByVal value As String)
      mLSTATE = value
    End Set
  End Property

  Dim mLZIP5 As Integer
  Public Property _LZIP5 As Integer
    Get
      Return mLZIP5
    End Get
    Set(ByVal value As Integer)
      mLZIP5 = value
    End Set
  End Property

  Dim mLZIP4 As Integer
  Public Property _LZIP4 As Integer
    Get
      Return mLZIP4
    End Get
    Set(ByVal value As Integer)
      mLZIP4 = value
    End Set
  End Property

  Dim mLPHONE As String
  Public Property _LPHONE As String
    Get
      Return mLPHONE
    End Get
    Set(ByVal value As String)
      mLPHONE = value
    End Set
  End Property

  Dim mLFAX As String
  Public Property _LFAX As String
    Get
      Return mLFAX
    End Get
    Set(ByVal value As String)
      mLFAX = value
    End Set
  End Property

  Dim mLEMAIL As String
  Public Property _LEMAIL As String
    Get
      Return mLEMAIL
    End Get
    Set(ByVal value As String)
      mLEMAIL = value
    End Set
  End Property

  Dim mBUSDES As String
  Public Property _BUSDES As String
    Get
      Return mBUSDES
    End Get
    Set(ByVal value As String)
      mBUSDES = value
    End Set
  End Property

  Dim mNOEMPS As Integer
  Public Property _NOEMPS As Integer
    Get
      Return mNOEMPS
    End Get
    Set(ByVal value As Integer)
      mNOEMPS = value
    End Set
  End Property

  Dim mSTRDT As Integer
  Public Property _STRDT As Integer
    Get
      Return mSTRDT
    End Get
    Set(ByVal value As Integer)
      mSTRDT = value
    End Set
  End Property

  Dim mSQFEET As Integer
  Public Property _SQFEET As Integer
    Get
      Return mSQFEET
    End Get
    Set(ByVal value As Integer)
      mSQFEET = value
    End Set
  End Property

  Dim mOWN As String
  Public Property _OWN As String
    Get
      Return mOWN
    End Get
    Set(ByVal value As String)
      mOWN = value
    End Set
  End Property

  Dim mOWNTYP As String
  Public Property _OWNTYP As String
    Get
      Return mOWNTYP
    End Get
    Set(ByVal value As String)
      mOWNTYP = value
    End Set
  End Property

  Dim mOWNOTH As String
  Public Property _OWNOTH As String
    Get
      Return mOWNOTH
    End Get
    Set(ByVal value As String)
      mOWNOTH = value
    End Set
  End Property

  Dim mBUSCAT As String
  Public Property _BUSCAT As String
    Get
      Return mBUSCAT
    End Get
    Set(ByVal value As String)
      mBUSCAT = value
    End Set
  End Property

  Dim mBUSOTH As String
  Public Property _BUSOTH As String
    Get
      Return mBUSOTH
    End Get
    Set(ByVal value As String)
      mBUSOTH = value
    End Set
  End Property

  Dim mBUSCD As String
  Public Property _BUSCD As String
    Get
      Return mBUSCD
    End Get
    Set(ByVal value As String)
      mBUSCD = value
    End Set
  End Property

  Dim mPROPCT As String
  Public Property _PROPCT As String
    Get
      Return mPROPCT
    End Get
    Set(ByVal value As String)
      mPROPCT = value
    End Set
  End Property

  Dim mOTHBUS As String
  Public Property _OTHBUS As String
    Get
      Return mOTHBUS
    End Get
    Set(ByVal value As String)
      mOTHBUS = value
    End Set
  End Property

  Dim mSTATUS As String
  Public Property _STATUS As String
    Get
      Return mSTATUS
    End Get
    Set(ByVal value As String)
      mSTATUS = value
    End Set
  End Property

  Dim mPRTCOM As String
  Public Property _PRTCOM As String
    Get
      Return mPRTCOM
    End Get
    Set(ByVal value As String)
      mPRTCOM = value
    End Set
  End Property

  Dim mRECVDT As Integer
  Public Property _RECVDT As Integer
    Get
      Return mRECVDT
    End Get
    Set(ByVal value As Integer)
      mRECVDT = value
    End Set
  End Property

  Dim mFILSTS As String
  Public Property _FILSTS As String
    Get
      Return mFILSTS
    End Get
    Set(ByVal value As String)
      mFILSTS = value
    End Set
  End Property

  Dim mASECCD As String
  Public Property _ASECCD As String
    Get
      Return mASECCD
    End Get
    Set(ByVal value As String)
      mASECCD = value
    End Set
  End Property

  Dim mATITLE As String
  Public Property _ATITLE As String
    Get
      Return mATITLE
    End Get
    Set(ByVal value As String)
      mATITLE = value
    End Set
  End Property

  Dim mANAME As String
  Public Property _ANAME As String
    Get
      Return mANAME
    End Get
    Set(ByVal value As String)
      mANAME = value
    End Set
  End Property

  Dim mADATE As Integer
  Public Property _ADATE As Integer
    Get
      Return mADATE
    End Get
    Set(ByVal value As Integer)
      mADATE = value
    End Set
  End Property

  Dim mBTITLE As String
  Public Property _BTITLE As String
    Get
      Return mBTITLE
    End Get
    Set(ByVal value As String)
      mBTITLE = value
    End Set
  End Property

  Dim mBNAME As String
  Public Property _BNAME As String
    Get
      Return mBNAME
    End Get
    Set(ByVal value As String)
      mBNAME = value
    End Set
  End Property

  Dim mBDATE As Integer
  Public Property _BDATE As Integer
    Get
      Return mBDATE
    End Get
    Set(ByVal value As Integer)
      mBDATE = value
    End Set
  End Property

  Dim mBWIT As String
  Public Property _BWIT As String
    Get
      Return mBWIT
    End Get
    Set(ByVal value As String)
      mBWIT = value
    End Set
  End Property

  Dim mBWITDT As Integer
  Public Property _BWITDT As Integer
    Get
      Return mBWITDT
    End Get
    Set(ByVal value As Integer)
      mBWITDT = value
    End Set
  End Property

  Dim mBWITCD As String
  Public Property _BWITCD As String
    Get
      Return mBWITCD
    End Get
    Set(ByVal value As String)
      mBWITCD = value
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


