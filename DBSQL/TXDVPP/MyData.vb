Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXDVPP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _YEAR = 0
    _LOCNO = String.Empty
    _LOC = String.Empty
    _NAME = String.Empty
    _SNAME = String.Empty
    _ADDR = String.Empty
    _ADDR2 = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP5 = 0
    _ZIP4 = 0
    _PHONE = 0
    _FAX = 0
    _EMAIL = String.Empty
    _CAMPNM = String.Empty
    _CAMPNO = String.Empty
    _FROMDT = 0
    _TODT = 0
    _PROPYR = String.Empty
    _CTRAIL = String.Empty
    _TTRAIL = String.Empty
    _PMODEL = String.Empty
    _MHOME = String.Empty
    _FWHEEL = String.Empty
    _SLDON = String.Empty
    _SLDOUT = String.Empty
    _PCHASS = String.Empty
    _VYEAR = 0
    _MAKE = String.Empty
    _MODEL = String.Empty
    _MODELN = String.Empty
    _REG = String.Empty
    _REGNO = String.Empty
    _REGWH = String.Empty
    _ENGINE = String.Empty
    _CHASS = String.Empty
    _LENGTH = 0
    _WIDTH = 0
    _PURVL = 0
    _PURDT = 0
    _VALUE = 0
    _ONAME = String.Empty
    _ODATE = 0
    _ANAME = String.Empty
    _ADATE = 0
    _WNAME = String.Empty
    _WDATE = 0
    _MSRP = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year >= " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year"
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
      _YEAR = .Item("YEAR")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADDR = .Item("ADDR")
      _ADDR2 = .Item("ADDR2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _PHONE = .Item("PHONE")
      _FAX = .Item("FAX")
      _EMAIL = .Item("EMAIL")
      _CAMPNM = .Item("CAMPNM")
      _CAMPNO = .Item("CAMPNO")
      _FROMDT = .Item("FROMDT")
      _TODT = .Item("TODT")
      _PROPYR = .Item("PROPYR")
      _CTRAIL = .Item("CTRAIL")
      _TTRAIL = .Item("TTRAIL")
      _PMODEL = .Item("PMODEL")
      _MHOME = .Item("MHOME")
      _FWHEEL = .Item("FWHEEL")
      _SLDON = .Item("SLDON")
      _SLDOUT = .Item("SLDOUT")
      _PCHASS = .Item("PCHASS")
      _VYEAR = .Item("VYEAR")
      _MAKE = .Item("MAKE")
      _MODEL = .Item("MODEL")
      _MODELN = .Item("MODELN")
      _REG = .Item("REG")
      _REGNO = .Item("REGNO")
      _REGWH = .Item("REGWH")
      _ENGINE = .Item("ENGINE")
      _CHASS = .Item("CHASS")
      _LENGTH = .Item("LENGTH")
      _WIDTH = .Item("WIDTH")
      _PURVL = .Item("PURVL")
      _PURDT = .Item("PURDT")
      _VALUE = .Item("VALUE")
      _ONAME = .Item("ONAME")
      _ODATE = .Item("ODATE")
      _ANAME = .Item("ANAME")
      _ADATE = .Item("ADATE")
      _WNAME = .Item("WNAME")
      _WDATE = .Item("WDATE")
      _MSRP = .Item("MSRP")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("LOC#") = _LOCNO
      .Item("LOC") = _LOC
      .Item("NAME") = _NAME
      .Item("SNAME") = _SNAME
      .Item("ADDR") = _ADDR
      .Item("ADDR2") = _ADDR2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("PHONE") = _PHONE
      .Item("FAX") = _FAX
      .Item("EMAIL") = _EMAIL
      .Item("CAMPNM") = _CAMPNM
      .Item("CAMPNO") = _CAMPNO
      .Item("FROMDT") = _FROMDT
      .Item("TODT") = _TODT
      .Item("PROPYR") = _PROPYR
      .Item("CTRAIL") = _CTRAIL
      .Item("TTRAIL") = _TTRAIL
      .Item("PMODEL") = _PMODEL
      .Item("MHOME") = _MHOME
      .Item("FWHEEL") = _FWHEEL
      .Item("SLDON") = _SLDON
      .Item("SLDOUT") = _SLDOUT
      .Item("PCHASS") = _PCHASS
      .Item("VYEAR") = _VYEAR
      .Item("MAKE") = _MAKE
      .Item("MODEL") = _MODEL
      .Item("MODELN") = _MODELN
      .Item("REG") = _REG
      .Item("REGNO") = _REGNO
      .Item("REGWH") = _REGWH
      .Item("ENGINE") = _ENGINE
      .Item("CHASS") = _CHASS
      .Item("LENGTH") = _LENGTH
      .Item("WIDTH") = _WIDTH
      .Item("PURVL") = _PURVL
      .Item("PURDT") = _PURDT
      .Item("VALUE") = _VALUE
      .Item("ONAME") = _ONAME
      .Item("ODATE") = _ODATE
      .Item("ANAME") = _ANAME
      .Item("ADATE") = _ADATE
      .Item("WNAME") = _WNAME
      .Item("WDATE") = _WDATE
      .Item("MSRP") = _MSRP
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

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
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

  Dim mADDR As String
  Public Property _ADDR As String
    Get
      Return mADDR
    End Get
    Set(ByVal value As String)
      mADDR = value
    End Set
  End Property

  Dim mADDR2 As String
  Public Property _ADDR2 As String
    Get
      Return mADDR2
    End Get
    Set(ByVal value As String)
      mADDR2 = value
    End Set
  End Property

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP5 As Integer
  Public Property _ZIP5 As Integer
    Get
      Return mZIP5
    End Get
    Set(ByVal value As Integer)
      mZIP5 = value
    End Set
  End Property

  Dim mZIP4 As Integer
  Public Property _ZIP4 As Integer
    Get
      Return mZIP4
    End Get
    Set(ByVal value As Integer)
      mZIP4 = value
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
  Dim mFAX As Long
  Public Property _FAX As Long
    Get
      Return mFAX
    End Get
    Set(ByVal value As Long)
      mFAX = value
    End Set
  End Property

  Dim mEMAIL As String
  Public Property _EMAIL As String
    Get
      Return mEMAIL
    End Get
    Set(ByVal value As String)
      mEMAIL = value
    End Set
  End Property

  Dim mCAMPNM As String
  Public Property _CAMPNM As String
    Get
      Return mCAMPNM
    End Get
    Set(ByVal value As String)
      mCAMPNM = value
    End Set
  End Property

  Dim mCAMPNO As String
  Public Property _CAMPNO As String
    Get
      Return mCAMPNO
    End Get
    Set(ByVal value As String)
      mCAMPNO = value
    End Set
  End Property

  Dim mFROMDT As Integer
  Public Property _FROMDT As Integer
    Get
      Return mFROMDT
    End Get
    Set(ByVal value As Integer)
      mFROMDT = value
    End Set
  End Property

  Dim mTODT As Integer
  Public Property _TODT As Integer
    Get
      Return mTODT
    End Get
    Set(ByVal value As Integer)
      mTODT = value
    End Set
  End Property

  Dim mPROPYR As String
  Public Property _PROPYR As String
    Get
      Return mPROPYR
    End Get
    Set(ByVal value As String)
      mPROPYR = value
    End Set
  End Property

  Dim mCTRAIL As String
  Public Property _CTRAIL As String
    Get
      Return mCTRAIL
    End Get
    Set(ByVal value As String)
      mCTRAIL = value
    End Set
  End Property

  Dim mTTRAIL As String
  Public Property _TTRAIL As String
    Get
      Return mTTRAIL
    End Get
    Set(ByVal value As String)
      mTTRAIL = value
    End Set
  End Property

  Dim mPMODEL As String
  Public Property _PMODEL As String
    Get
      Return mPMODEL
    End Get
    Set(ByVal value As String)
      mPMODEL = value
    End Set
  End Property

  Dim mMHOME As String
  Public Property _MHOME As String
    Get
      Return mMHOME
    End Get
    Set(ByVal value As String)
      mMHOME = value
    End Set
  End Property

  Dim mFWHEEL As String
  Public Property _FWHEEL As String
    Get
      Return mFWHEEL
    End Get
    Set(ByVal value As String)
      mFWHEEL = value
    End Set
  End Property

  Dim mSLDON As String
  Public Property _SLDON As String
    Get
      Return mSLDON
    End Get
    Set(ByVal value As String)
      mSLDON = value
    End Set
  End Property

  Dim mSLDOUT As String
  Public Property _SLDOUT As String
    Get
      Return mSLDOUT
    End Get
    Set(ByVal value As String)
      mSLDOUT = value
    End Set
  End Property

  Dim mPCHASS As String
  Public Property _PCHASS As String
    Get
      Return mPCHASS
    End Get
    Set(ByVal value As String)
      mPCHASS = value
    End Set
  End Property

  Dim mVYEAR As Integer
  Public Property _VYEAR As Integer
    Get
      Return mVYEAR
    End Get
    Set(ByVal value As Integer)
      mVYEAR = value
    End Set
  End Property

  Dim mMAKE As String
  Public Property _MAKE As String
    Get
      Return mMAKE
    End Get
    Set(ByVal value As String)
      mMAKE = value
    End Set
  End Property

  Dim mMODEL As String
  Public Property _MODEL As String
    Get
      Return mMODEL
    End Get
    Set(ByVal value As String)
      mMODEL = value
    End Set
  End Property

  Dim mMODELN As String
  Public Property _MODELN As String
    Get
      Return mMODELN
    End Get
    Set(ByVal value As String)
      mMODELN = value
    End Set
  End Property

  Dim mREG As String
  Public Property _REG As String
    Get
      Return mREG
    End Get
    Set(ByVal value As String)
      mREG = value
    End Set
  End Property

  Dim mREGNO As String
  Public Property _REGNO As String
    Get
      Return mREGNO
    End Get
    Set(ByVal value As String)
      mREGNO = value
    End Set
  End Property

  Dim mREGWH As String
  Public Property _REGWH As String
    Get
      Return mREGWH
    End Get
    Set(ByVal value As String)
      mREGWH = value
    End Set
  End Property

  Dim mENGINE As String
  Public Property _ENGINE As String
    Get
      Return mENGINE
    End Get
    Set(ByVal value As String)
      mENGINE = value
    End Set
  End Property

  Dim mCHASS As String
  Public Property _CHASS As String
    Get
      Return mCHASS
    End Get
    Set(ByVal value As String)
      mCHASS = value
    End Set
  End Property

  Dim mLENGTH As Integer
  Public Property _LENGTH As Integer
    Get
      Return mLENGTH
    End Get
    Set(ByVal value As Integer)
      mLENGTH = value
    End Set
  End Property

  Dim mWIDTH As Integer
  Public Property _WIDTH As Integer
    Get
      Return mWIDTH
    End Get
    Set(ByVal value As Integer)
      mWIDTH = value
    End Set
  End Property

  Dim mPURVL As Long
  Public Property _PURVL As Long
    Get
      Return mPURVL
    End Get
    Set(ByVal value As Long)
      mPURVL = value
    End Set
  End Property

  Dim mPURDT As Integer
  Public Property _PURDT As Integer
    Get
      Return mPURDT
    End Get
    Set(ByVal value As Integer)
      mPURDT = value
    End Set
  End Property

  Dim mVALUE As Long
  Public Property _VALUE As Long
    Get
      Return mVALUE
    End Get
    Set(ByVal value As Long)
      mVALUE = value
    End Set
  End Property

  Dim mONAME As String
  Public Property _ONAME As String
    Get
      Return mONAME
    End Get
    Set(ByVal value As String)
      mONAME = value
    End Set
  End Property

  Dim mODATE As Integer
  Public Property _ODATE As Integer
    Get
      Return mODATE
    End Get
    Set(ByVal value As Integer)
      mODATE = value
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

  Dim mWNAME As String
  Public Property _WNAME As String
    Get
      Return mWNAME
    End Get
    Set(ByVal value As String)
      mWNAME = value
    End Set
  End Property

  Dim mWDATE As Integer
  Public Property _WDATE As Integer
    Get
      Return mWDATE
    End Get
    Set(ByVal value As Integer)
      mWDATE = value
    End Set
  End Property
  Dim mMSRP As Long
  Public Property _MSRP As Long
    Get
      Return mMSRP
    End Get
    Set(ByVal value As Long)
      mMSRP = value
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


