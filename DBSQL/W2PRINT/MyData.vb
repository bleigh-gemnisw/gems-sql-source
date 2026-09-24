Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "W2PRINT"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
  End Sub
  Public Sub GetOneRecordP(ByVal WrkCntrl As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where wcntrl=" & WrkCntrl
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
  Public Function PosData(ByVal WrkCntrl As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where wcntrl >= " & WrkCntrl & " Order by wcntrl"
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
  Public Sub DeleteAllRecords()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
      _W2YEAR = .Item("W2YEAR")
      _WEMPNO = .Item("WEMPNO")
      _WSSN = .Item("WSSN")
      _WFEDID = .Item("WFEDID")
      _WERNAM = .Item("WERNAM")
      _WERAD1 = .Item("WERAD1")
      _WERAD2 = .Item("WERAD2")
      _WCNTRL = .Item("WCNTRL")
      _WEMFNM = .Item("WEMFNM")
      _WEMLNM = .Item("WEMLNM")
      _WEMSUF = .Item("WEMSUF")
      _WEMAD1 = .Item("WEMAD1")
      _WEMAD2 = .Item("WEMAD2")
      _WEMAD3 = .Item("WEMAD3")
      _WFITGR = .Item("WFITGR")
      _WFITTX = .Item("WFITTX")
      _WFICGR = .Item("WFICGR")
      _WFICTX = .Item("WFICTX")
      _WMEDGR = .Item("WMEDGR")
      _WMEDTX = .Item("WMEDTX")
      _WSSTIP = .Item("WSSTIP")
      _WALTIP = .Item("WALTIP")
      _WDEPC = .Item("WDEPC")
      _WNONQ = .Item("WNONQ")
      _WCD12A = .Item("WCD12A")
      _WCD12B = .Item("WCD12B")
      _WCD12C = .Item("WCD12C")
      _WCD12D = .Item("WCD12D")
      _WAM12A = .Item("WAM12A")
      _WAM12B = .Item("WAM12B")
      _WAM12C = .Item("WAM12C")
      _WAM12D = .Item("WAM12D")
      _WBX13A = .Item("WBX13A")
      _WBX13B = .Item("WBX13B")
      _WBX13C = .Item("WBX13C")
      _WCD14A = .Item("WCD14A")
      _WCD14B = .Item("WCD14B")
      _WCD14C = .Item("WCD14C")
      _WCD14D = .Item("WCD14D")
      _WAM14A = .Item("WAM14A")
      _WAM14B = .Item("WAM14B")
      _WAM14C = .Item("WAM14C")
      _WAM14D = .Item("WAM14D")
      _WSTATC = .Item("WSTATC")
      _WSTATNo = .Item("WSTAT#")
      _WSTGRS = .Item("WSTGRS")
      _WSTTAX = .Item("WSTTAX")
      _WLOGRS = .Item("WLOGRS")
      _WLOTAX = .Item("WLOTAX")
      _WLONAM = .Item("WLONAM")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("W2YEAR") = _W2YEAR
      .Item("WEMPNO") = _WEMPNO
      .Item("WSSN") = _WSSN
      .Item("WFEDID") = _WFEDID
      .Item("WERNAM") = _WERNAM
      .Item("WERAD1") = _WERAD1
      .Item("WERAD2") = _WERAD2
      .Item("WCNTRL") = _WCNTRL
      .Item("WEMFNM") = _WEMFNM
      .Item("WEMLNM") = _WEMLNM
      .Item("WEMSUF") = _WEMSUF
      .Item("WEMAD1") = _WEMAD1
      .Item("WEMAD2") = _WEMAD2
      .Item("WEMAD3") = _WEMAD3
      .Item("WFITGR") = _WFITGR
      .Item("WFITTX") = _WFITTX
      .Item("WFICGR") = _WFICGR
      .Item("WFICTX") = _WFICTX
      .Item("WMEDGR") = _WMEDGR
      .Item("WMEDTX") = _WMEDTX
      .Item("WSSTIP") = _WSSTIP
      .Item("WALTIP") = _WALTIP
      .Item("WDEPC") = _WDEPC
      .Item("WNONQ") = _WNONQ
      .Item("WCD12A") = _WCD12A
      .Item("WCD12B") = _WCD12B
      .Item("WCD12C") = _WCD12C
      .Item("WCD12D") = _WCD12D
      .Item("WAM12A") = _WAM12A
      .Item("WAM12B") = _WAM12B
      .Item("WAM12C") = _WAM12C
      .Item("WAM12D") = _WAM12D
      .Item("WBX13A") = _WBX13A
      .Item("WBX13B") = _WBX13B
      .Item("WBX13C") = _WBX13C
      .Item("WCD14A") = _WCD14A
      .Item("WCD14B") = _WCD14B
      .Item("WCD14C") = _WCD14C
      .Item("WCD14D") = _WCD14D
      .Item("WAM14A") = _WAM14A
      .Item("WAM14B") = _WAM14B
      .Item("WAM14C") = _WAM14C
      .Item("WAM14D") = _WAM14D
      .Item("WSTATC") = _WSTATC
      .Item("WSTAT#") = _WSTATNo
      .Item("WSTGRS") = _WSTGRS
      .Item("WSTTAX") = _WSTTAX
      .Item("WLOGRS") = _WLOGRS
      .Item("WLOTAX") = _WLOTAX
      .Item("WLONAM") = _WLONAM
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
  Dim mW2YEAR As Integer
  Public Property _W2YEAR As Integer
    Get
      Return mW2YEAR
    End Get
    Set(ByVal value As Integer)
      mW2YEAR = value
    End Set
  End Property

  Dim mWEMPNO As Integer
  Public Property _WEMPNO As Integer
    Get
      Return mWEMPNO
    End Get
    Set(ByVal value As Integer)
      mWEMPNO = value
    End Set
  End Property

  Dim mWSSN As String
  Public Property _WSSN As String
    Get
      Return mWSSN
    End Get
    Set(ByVal value As String)
      mWSSN = value
    End Set
  End Property

  Dim mWFEDID As String
  Public Property _WFEDID As String
    Get
      Return mWFEDID
    End Get
    Set(ByVal value As String)
      mWFEDID = value
    End Set
  End Property

  Dim mWERNAM As String
  Public Property _WERNAM As String
    Get
      Return mWERNAM
    End Get
    Set(ByVal value As String)
      mWERNAM = value
    End Set
  End Property

  Dim mWERAD1 As String
  Public Property _WERAD1 As String
    Get
      Return mWERAD1
    End Get
    Set(ByVal value As String)
      mWERAD1 = value
    End Set
  End Property

  Dim mWERAD2 As String
  Public Property _WERAD2 As String
    Get
      Return mWERAD2
    End Get
    Set(ByVal value As String)
      mWERAD2 = value
    End Set
  End Property

  Dim mWCNTRL As Long
  Public Property _WCNTRL As Long
    Get
      Return mWCNTRL
    End Get
    Set(ByVal value As Long)
      mWCNTRL = value
    End Set
  End Property

  Dim mWEMFNM As String
  Public Property _WEMFNM As String
    Get
      Return mWEMFNM
    End Get
    Set(ByVal value As String)
      mWEMFNM = value
    End Set
  End Property

  Dim mWEMLNM As String
  Public Property _WEMLNM As String
    Get
      Return mWEMLNM
    End Get
    Set(ByVal value As String)
      mWEMLNM = value
    End Set
  End Property

  Dim mWEMSUF As String
  Public Property _WEMSUF As String
    Get
      Return mWEMSUF
    End Get
    Set(ByVal value As String)
      mWEMSUF = value
    End Set
  End Property

  Dim mWEMAD1 As String
  Public Property _WEMAD1 As String
    Get
      Return mWEMAD1
    End Get
    Set(ByVal value As String)
      mWEMAD1 = value
    End Set
  End Property

  Dim mWEMAD2 As String
  Public Property _WEMAD2 As String
    Get
      Return mWEMAD2
    End Get
    Set(ByVal value As String)
      mWEMAD2 = value
    End Set
  End Property

  Dim mWEMAD3 As String
  Public Property _WEMAD3 As String
    Get
      Return mWEMAD3
    End Get
    Set(ByVal value As String)
      mWEMAD3 = value
    End Set
  End Property

  Dim mWFITGR As Decimal
  Public Property _WFITGR As Decimal
    Get
      Return mWFITGR
    End Get
    Set(ByVal value As Decimal)
      mWFITGR = value
    End Set
  End Property

  Dim mWFITTX As Decimal
  Public Property _WFITTX As Decimal
    Get
      Return mWFITTX
    End Get
    Set(ByVal value As Decimal)
      mWFITTX = value
    End Set
  End Property

  Dim mWFICGR As Decimal
  Public Property _WFICGR As Decimal
    Get
      Return mWFICGR
    End Get
    Set(ByVal value As Decimal)
      mWFICGR = value
    End Set
  End Property

  Dim mWFICTX As Decimal
  Public Property _WFICTX As Decimal
    Get
      Return mWFICTX
    End Get
    Set(ByVal value As Decimal)
      mWFICTX = value
    End Set
  End Property

  Dim mWMEDGR As Decimal
  Public Property _WMEDGR As Decimal
    Get
      Return mWMEDGR
    End Get
    Set(ByVal value As Decimal)
      mWMEDGR = value
    End Set
  End Property

  Dim mWMEDTX As Decimal
  Public Property _WMEDTX As Decimal
    Get
      Return mWMEDTX
    End Get
    Set(ByVal value As Decimal)
      mWMEDTX = value
    End Set
  End Property

  Dim mWSSTIP As Decimal
  Public Property _WSSTIP As Decimal
    Get
      Return mWSSTIP
    End Get
    Set(ByVal value As Decimal)
      mWSSTIP = value
    End Set
  End Property

  Dim mWALTIP As Decimal
  Public Property _WALTIP As Decimal
    Get
      Return mWALTIP
    End Get
    Set(ByVal value As Decimal)
      mWALTIP = value
    End Set
  End Property

  Dim mWDEPC As Decimal
  Public Property _WDEPC As Decimal
    Get
      Return mWDEPC
    End Get
    Set(ByVal value As Decimal)
      mWDEPC = value
    End Set
  End Property

  Dim mWNONQ As Decimal
  Public Property _WNONQ As Decimal
    Get
      Return mWNONQ
    End Get
    Set(ByVal value As Decimal)
      mWNONQ = value
    End Set
  End Property

  Dim mWCD12A As String
  Public Property _WCD12A As String
    Get
      Return mWCD12A
    End Get
    Set(ByVal value As String)
      mWCD12A = value
    End Set
  End Property

  Dim mWCD12B As String
  Public Property _WCD12B As String
    Get
      Return mWCD12B
    End Get
    Set(ByVal value As String)
      mWCD12B = value
    End Set
  End Property

  Dim mWCD12C As String
  Public Property _WCD12C As String
    Get
      Return mWCD12C
    End Get
    Set(ByVal value As String)
      mWCD12C = value
    End Set
  End Property

  Dim mWCD12D As String
  Public Property _WCD12D As String
    Get
      Return mWCD12D
    End Get
    Set(ByVal value As String)
      mWCD12D = value
    End Set
  End Property

  Dim mWAM12A As Decimal
  Public Property _WAM12A As Decimal
    Get
      Return mWAM12A
    End Get
    Set(ByVal value As Decimal)
      mWAM12A = value
    End Set
  End Property

  Dim mWAM12B As Decimal
  Public Property _WAM12B As Decimal
    Get
      Return mWAM12B
    End Get
    Set(ByVal value As Decimal)
      mWAM12B = value
    End Set
  End Property

  Dim mWAM12C As Decimal
  Public Property _WAM12C As Decimal
    Get
      Return mWAM12C
    End Get
    Set(ByVal value As Decimal)
      mWAM12C = value
    End Set
  End Property

  Dim mWAM12D As Decimal
  Public Property _WAM12D As Decimal
    Get
      Return mWAM12D
    End Get
    Set(ByVal value As Decimal)
      mWAM12D = value
    End Set
  End Property

  Dim mWBX13A As String
  Public Property _WBX13A As String
    Get
      Return mWBX13A
    End Get
    Set(ByVal value As String)
      mWBX13A = value
    End Set
  End Property

  Dim mWBX13B As String
  Public Property _WBX13B As String
    Get
      Return mWBX13B
    End Get
    Set(ByVal value As String)
      mWBX13B = value
    End Set
  End Property

  Dim mWBX13C As String
  Public Property _WBX13C As String
    Get
      Return mWBX13C
    End Get
    Set(ByVal value As String)
      mWBX13C = value
    End Set
  End Property

  Dim mWCD14A As String
  Public Property _WCD14A As String
    Get
      Return mWCD14A
    End Get
    Set(ByVal value As String)
      mWCD14A = value
    End Set
  End Property

  Dim mWCD14B As String
  Public Property _WCD14B As String
    Get
      Return mWCD14B
    End Get
    Set(ByVal value As String)
      mWCD14B = value
    End Set
  End Property

  Dim mWCD14C As String
  Public Property _WCD14C As String
    Get
      Return mWCD14C
    End Get
    Set(ByVal value As String)
      mWCD14C = value
    End Set
  End Property

  Dim mWCD14D As String
  Public Property _WCD14D As String
    Get
      Return mWCD14D
    End Get
    Set(ByVal value As String)
      mWCD14D = value
    End Set
  End Property

  Dim mWAM14A As Decimal
  Public Property _WAM14A As Decimal
    Get
      Return mWAM14A
    End Get
    Set(ByVal value As Decimal)
      mWAM14A = value
    End Set
  End Property

  Dim mWAM14B As Decimal
  Public Property _WAM14B As Decimal
    Get
      Return mWAM14B
    End Get
    Set(ByVal value As Decimal)
      mWAM14B = value
    End Set
  End Property

  Dim mWAM14C As Decimal
  Public Property _WAM14C As Decimal
    Get
      Return mWAM14C
    End Get
    Set(ByVal value As Decimal)
      mWAM14C = value
    End Set
  End Property

  Dim mWAM14D As Decimal
  Public Property _WAM14D As Decimal
    Get
      Return mWAM14D
    End Get
    Set(ByVal value As Decimal)
      mWAM14D = value
    End Set
  End Property

  Dim mWSTATC As String
  Public Property _WSTATC As String
    Get
      Return mWSTATC
    End Get
    Set(ByVal value As String)
      mWSTATC = value
    End Set
  End Property

  Dim mWSTATNo As String
  Public Property _WSTATNo As String
    Get
      Return mWSTATNo
    End Get
    Set(ByVal value As String)
      mWSTATNo = value
    End Set
  End Property

  Dim mWSTGRS As Decimal
  Public Property _WSTGRS As Decimal
    Get
      Return mWSTGRS
    End Get
    Set(ByVal value As Decimal)
      mWSTGRS = value
    End Set
  End Property

  Dim mWSTTAX As Decimal
  Public Property _WSTTAX As Decimal
    Get
      Return mWSTTAX
    End Get
    Set(ByVal value As Decimal)
      mWSTTAX = value
    End Set
  End Property

  Dim mWLOGRS As Decimal
  Public Property _WLOGRS As Decimal
    Get
      Return mWLOGRS
    End Get
    Set(ByVal value As Decimal)
      mWLOGRS = value
    End Set
  End Property

  Dim mWLOTAX As Decimal
  Public Property _WLOTAX As Decimal
    Get
      Return mWLOTAX
    End Get
    Set(ByVal value As Decimal)
      mWLOTAX = value
    End Set
  End Property

  Dim mWLONAM As String
  Public Property _WLONAM As String
    Get
      Return mWLONAM
    End Get
    Set(ByVal value As String)
      mWLONAM = value
    End Set
  End Property
#End Region
End Class

