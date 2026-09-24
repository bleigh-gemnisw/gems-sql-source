Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TXGL"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TXYR = 0
_TXTYP = string.empty
_TXCD = string.empty
_TXSUP = string.empty
_TXDIST = 0
_TXPHS = string.empty
_FDNRC = 0
_SFURC = 0
_DPNRC = 0
_OBNRC = 0
_FNPRC = 0
_SUBRC = 0
_FDNRD = 0
_SFURD = 0
_DPNRD = 0
_OBNRD = 0
_FNPRD = 0
_SUBRD = 0
_FDNLC = 0
_SFULC = 0
_DPNLC = 0
_OBNLC = 0
_FNPLC = 0
_SUBLC = 0
_FDNLD = 0
_SFULD = 0
_DPNLD = 0
_OBNLD = 0
_FNPLD = 0
_SUBLD = 0
_TXADD = string.empty

End Sub
Public Sub GetOneRecordP(ByVal Year As Integer, ByVal Type As String, ByVal Code As String, _
 ByVal Susp As String, ByVal Dist As Integer, ByVal Phase As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where TXYR=" & Year & " and TXTYP='" & Type & _
  "' and TXCD='" & Code & "' and TXSUP='" & Susp & "' and TXDIST=" & Dist & " and" & _
  " TXPHS='" & Phase & "'"
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
Public Function PosData(ByVal Year As Integer, ByVal Type As String, ByVal Code As String, _
 ByVal Susp As String, ByVal Dist As Integer, ByVal Phase As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where TXYR=" & Year & " and TXTYP='" & Type & _
  "' and TXCD='" & Code & "' and TXSUP='" & Susp & "' and TXDIST=" & Dist & " and" & " TXPHS>='" & Phase & "' or " & _
  "TXYR=" & Year & " and TXTYP='" & Type & "' and TXCD='" & Code & "' and TXSUP='" & Susp & "' and TXDIST>=" & Dist & " or " & _
  "TXYR=" & Year & " and TXTYP='" & Type & "' and TXCD='" & Code & "' and TXSUP>='" & Susp & "' or " & _
  "TXYR=" & Year & " and TXTYP='" & Type & "' and TXCD>='" & Code & "' or " & _
  "TXYR=" & Year & " and TXTYP>='" & Type & "' or " & _
  "TXYR>=" & Year & " order by txyr,txtyp,txcd,txsup,txdist,txphs"
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
  Public Sub SetRange(ByVal WrkYear As Integer)
  Dim objCommand As SqlCommand

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Select * from " & cFileName & " where txyr=" & WrkYear
  ConnRdr = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, ConnRdr)
  objreader = objCommand.ExecuteReader()
  objCommand = Nothing
End Sub
Public Sub ReadFileE()
  Dim Good As Boolean

  Good = objreader.Read()
  If Good Then
    GetFieldsRdr()
  Else
    CloseRange()
  End If
End Sub
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
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _TXYR = .Item("TXYR")
    _TXTYP = .Item("TXTYP")
    _TXCD = .Item("TXCD")
    _TXSUP = .Item("TXSUP")
    _TXDIST = .Item("TXDIST")
    _TXPHS = .Item("TXPHS")
    _FDNRC = .Item("FDNRC")
    _SFURC = .Item("SFURC")
    _DPNRC = .Item("DPNRC")
    _OBNRC = .Item("OBNRC")
    _FNPRC = .Item("FNPRC")
    _SUBRC = .Item("SUBRC")
    _FDNRD = .Item("FDNRD")
    _SFURD = .Item("SFURD")
    _DPNRD = .Item("DPNRD")
    _OBNRD = .Item("OBNRD")
    _FNPRD = .Item("FNPRD")
    _SUBRD = .Item("SUBRD")
    _FDNLC = .Item("FDNLC")
    _SFULC = .Item("SFULC")
    _DPNLC = .Item("DPNLC")
    _OBNLC = .Item("OBNLC")
    _FNPLC = .Item("FNPLC")
    _SUBLC = .Item("SUBLC")
    _FDNLD = .Item("FDNLD")
    _SFULD = .Item("SFULD")
    _DPNLD = .Item("DPNLD")
    _OBNLD = .Item("OBNLD")
    _FNPLD = .Item("FNPLD")
    _SUBLD = .Item("SUBLD")
    _TXADD = .Item("TXADD")
  End With
End Sub
Public Sub GetFieldsRdr()
  With objreader
    _TXYR = .Item("TXYR")
    _TXTYP = .Item("TXTYP")
    _TXCD = .Item("TXCD")
    _TXSUP = .Item("TXSUP")
    _TXDIST = .Item("TXDIST")
    _TXPHS = .Item("TXPHS")
    _FDNRC = .Item("FDNRC")
    _SFURC = .Item("SFURC")
    _DPNRC = .Item("DPNRC")
    _OBNRC = .Item("OBNRC")
    _FNPRC = .Item("FNPRC")
    _SUBRC = .Item("SUBRC")
    _FDNRD = .Item("FDNRD")
    _SFURD = .Item("SFURD")
    _DPNRD = .Item("DPNRD")
    _OBNRD = .Item("OBNRD")
    _FNPRD = .Item("FNPRD")
    _SUBRD = .Item("SUBRD")
    _FDNLC = .Item("FDNLC")
    _SFULC = .Item("SFULC")
    _DPNLC = .Item("DPNLC")
    _OBNLC = .Item("OBNLC")
    _FNPLC = .Item("FNPLC")
    _SUBLC = .Item("SUBLC")
    _FDNLD = .Item("FDNLD")
    _SFULD = .Item("SFULD")
    _DPNLD = .Item("DPNLD")
    _OBNLD = .Item("OBNLD")
    _FNPLD = .Item("FNPLD")
    _SUBLD = .Item("SUBLD")
    _TXADD = .Item("TXADD")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("TXYR") = _TXYR
    .Item("TXTYP") = _TXTYP
    .Item("TXCD") = _TXCD
    .Item("TXSUP") = _TXSUP
    .Item("TXDIST") = _TXDIST
    .Item("TXPHS") = _TXPHS
    .Item("FDNRC") = _FDNRC
    .Item("SFURC") = _SFURC
    .Item("DPNRC") = _DPNRC
    .Item("OBNRC") = _OBNRC
    .Item("FNPRC") = _FNPRC
    .Item("SUBRC") = _SUBRC
    .Item("FDNRD") = _FDNRD
    .Item("SFURD") = _SFURD
    .Item("DPNRD") = _DPNRD
    .Item("OBNRD") = _OBNRD
    .Item("FNPRD") = _FNPRD
    .Item("SUBRD") = _SUBRD
    .Item("FDNLC") = _FDNLC
    .Item("SFULC") = _SFULC
    .Item("DPNLC") = _DPNLC
    .Item("OBNLC") = _OBNLC
    .Item("FNPLC") = _FNPLC
    .Item("SUBLC") = _SUBLC
    .Item("FDNLD") = _FDNLD
    .Item("SFULD") = _SFULD
    .Item("DPNLD") = _DPNLD
    .Item("OBNLD") = _OBNLD
    .Item("FNPLD") = _FNPLD
    .Item("SUBLD") = _SUBLD
    .Item("TXADD") = _TXADD
  End With
End Sub

#End Region

#Region "Properties: Fields"
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
Dim mTXYR As Integer
Public Property _TXYR As Integer
    Get
        Return mTXYR
    End Get
    Set(ByVal value As Integer)
        mTXYR = value
    End Set
End Property
Dim mTXTYP As String
Public Property _TXTYP As String
    Get
        Return mTXTYP
    End Get
    Set(ByVal value As String)
        mTXTYP = value
    End Set
End Property
Dim mTXCD As String
Public Property _TXCD As String
    Get
        Return mTXCD
    End Get
    Set(ByVal value As String)
        mTXCD = value
    End Set
End Property
Dim mTXSUP As String
Public Property _TXSUP As String
    Get
        Return mTXSUP
    End Get
    Set(ByVal value As String)
        mTXSUP = value
    End Set
End Property
Dim mTXDIST As Integer
Public Property _TXDIST As Integer
    Get
        Return mTXDIST
    End Get
    Set(ByVal value As Integer)
        mTXDIST = value
    End Set
End Property
Dim mTXPHS As String
Public Property _TXPHS As String
    Get
        Return mTXPHS
    End Get
    Set(ByVal value As String)
        mTXPHS = value
    End Set
End Property
Dim mFDNRC As Integer
Public Property _FDNRC As Integer
    Get
        Return mFDNRC
    End Get
    Set(ByVal value As Integer)
        mFDNRC = value
    End Set
End Property
Dim mSFURC As Integer
Public Property _SFURC As Integer
    Get
        Return mSFURC
    End Get
    Set(ByVal value As Integer)
        mSFURC = value
    End Set
End Property
Dim mDPNRC As Integer
Public Property _DPNRC As Integer
    Get
        Return mDPNRC
    End Get
    Set(ByVal value As Integer)
        mDPNRC = value
    End Set
End Property
Dim mOBNRC As Integer
Public Property _OBNRC As Integer
    Get
        Return mOBNRC
    End Get
    Set(ByVal value As Integer)
        mOBNRC = value
    End Set
End Property
Dim mFNPRC As Integer
Public Property _FNPRC As Integer
    Get
        Return mFNPRC
    End Get
    Set(ByVal value As Integer)
        mFNPRC = value
    End Set
End Property
Dim mSUBRC As Integer
Public Property _SUBRC As Integer
    Get
        Return mSUBRC
    End Get
    Set(ByVal value As Integer)
        mSUBRC = value
    End Set
End Property
Dim mFDNRD As Integer
Public Property _FDNRD As Integer
    Get
        Return mFDNRD
    End Get
    Set(ByVal value As Integer)
        mFDNRD = value
    End Set
End Property
Dim mSFURD As Integer
Public Property _SFURD As Integer
    Get
        Return mSFURD
    End Get
    Set(ByVal value As Integer)
        mSFURD = value
    End Set
End Property
Dim mDPNRD As Integer
Public Property _DPNRD As Integer
    Get
        Return mDPNRD
    End Get
    Set(ByVal value As Integer)
        mDPNRD = value
    End Set
End Property
Dim mOBNRD As Integer
Public Property _OBNRD As Integer
    Get
        Return mOBNRD
    End Get
    Set(ByVal value As Integer)
        mOBNRD = value
    End Set
End Property
Dim mFNPRD As Integer
Public Property _FNPRD As Integer
    Get
        Return mFNPRD
    End Get
    Set(ByVal value As Integer)
        mFNPRD = value
    End Set
End Property
Dim mSUBRD As Integer
Public Property _SUBRD As Integer
    Get
        Return mSUBRD
    End Get
    Set(ByVal value As Integer)
        mSUBRD = value
    End Set
End Property
Dim mFDNLC As Integer
Public Property _FDNLC As Integer
    Get
        Return mFDNLC
    End Get
    Set(ByVal value As Integer)
        mFDNLC = value
    End Set
End Property
Dim mSFULC As Integer
Public Property _SFULC As Integer
    Get
        Return mSFULC
    End Get
    Set(ByVal value As Integer)
        mSFULC = value
    End Set
End Property
Dim mDPNLC As Integer
Public Property _DPNLC As Integer
    Get
        Return mDPNLC
    End Get
    Set(ByVal value As Integer)
        mDPNLC = value
    End Set
End Property
Dim mOBNLC As Integer
Public Property _OBNLC As Integer
    Get
        Return mOBNLC
    End Get
    Set(ByVal value As Integer)
        mOBNLC = value
    End Set
End Property
Dim mFNPLC As Integer
Public Property _FNPLC As Integer
    Get
        Return mFNPLC
    End Get
    Set(ByVal value As Integer)
        mFNPLC = value
    End Set
End Property
Dim mSUBLC As Integer
Public Property _SUBLC As Integer
    Get
        Return mSUBLC
    End Get
    Set(ByVal value As Integer)
        mSUBLC = value
    End Set
End Property
Dim mFDNLD As Integer
Public Property _FDNLD As Integer
    Get
        Return mFDNLD
    End Get
    Set(ByVal value As Integer)
        mFDNLD = value
    End Set
End Property
Dim mSFULD As Integer
Public Property _SFULD As Integer
    Get
        Return mSFULD
    End Get
    Set(ByVal value As Integer)
        mSFULD = value
    End Set
End Property
Dim mDPNLD As Integer
Public Property _DPNLD As Integer
    Get
        Return mDPNLD
    End Get
    Set(ByVal value As Integer)
        mDPNLD = value
    End Set
End Property
Dim mOBNLD As Integer
Public Property _OBNLD As Integer
    Get
        Return mOBNLD
    End Get
    Set(ByVal value As Integer)
        mOBNLD = value
    End Set
End Property
Dim mFNPLD As Integer
Public Property _FNPLD As Integer
    Get
        Return mFNPLD
    End Get
    Set(ByVal value As Integer)
        mFNPLD = value
    End Set
End Property
Dim mSUBLD As Integer
Public Property _SUBLD As Integer
    Get
        Return mSUBLD
    End Get
    Set(ByVal value As Integer)
        mSUBLD = value
    End Set
End Property
Dim mTXADD As String
Public Property _TXADD As String
    Get
        Return mTXADD
    End Get
    Set(ByVal value As String)
        mTXADD = value
    End Set
End Property
#End Region
End Class

