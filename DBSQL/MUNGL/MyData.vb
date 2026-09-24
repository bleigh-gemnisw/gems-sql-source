Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "MUNGL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal ID As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where id='" & ID & "'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
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
  Public Function PosData(ByVal ID As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where id>='" & ID & "' order by id"
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

#Region "Properties: Set Fields"

Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
      _ID = .Item("ID")
      _CTAXC = .Item("CTAXC")
      _CTAXD = .Item("CTAXD")
      _CSUC = .Item("CSUC")
      _CSUD = .Item("CSUD")
      _PTAXC = .Item("PTAXC")
      _PTAXD = .Item("PTAXD")
      _STAXC = .Item("STAXC")
      _STAXD = .Item("STAXD")
      _CINTC = .Item("CINTC")
      _CINTD = .Item("CINTD")
      _PINTC = .Item("PINTC")
      _PINTD = .Item("PINTD")
      _SINTC = .Item("SINTC")
      _SINTD = .Item("SINTD")
      _PENC = .Item("PENC")
      _PEND = .Item("PEND")
      _PENCBC = .Item("PENCBC")
      _PENCBD = .Item("PENCBD")
      _FTAXC = .Item("FTAXC")
      _FTAXD = .Item("FTAXD")
      _ATAXC = .Item("ATAXC")
      _ATAXD = .Item("ATAXD")
      _ASWRC = .Item("ASWRC")
      _ASWRD = .Item("ASWRD")
      _CSWRC = .Item("CSWRC")
      _CSWRD = .Item("CSWRD")
      _CSWRIC = .Item("CSWRIC")
      _CSWRID = .Item("CSWRID")
      _PSWRC = .Item("PSWRC")
      _PSWRD = .Item("PSWRD")
      _PSWRIC = .Item("PSWRIC")
      _PSWRID = .Item("PSWRID")
    End With
  End Sub

Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("ID") = _ID
      .Item("CTAXC") = _CTAXC
      .Item("CTAXD") = _CTAXD
      .Item("CSUC") = _CSUC
      .Item("CSUD") = _CSUD
      .Item("PTAXC") = _PTAXC
      .Item("PTAXD") = _PTAXD
      .Item("STAXC") = _STAXC
      .Item("STAXD") = _STAXD
      .Item("CINTC") = _CINTC
      .Item("CINTD") = _CINTD
      .Item("PINTC") = _PINTC
      .Item("PINTD") = _PINTD
      .Item("SINTC") = _SINTC
      .Item("SINTD") = _SINTD
      .Item("PENC") = _PENC
      .Item("PEND") = _PEND
      .Item("PENCBC") = _PENCBC
      .Item("PENCBD") = _PENCBD
      .Item("FTAXC") = _FTAXC
      .Item("FTAXD") = _FTAXD
      .Item("ATAXC") = _ATAXC
      .Item("ATAXD") = _ATAXD
      .Item("ASWRC") = _ASWRC
      .Item("ASWRD") = _ASWRD
      .Item("CSWRC") = _CSWRC
      .Item("CSWRD") = _CSWRD
      .Item("CSWRIC") = _CSWRIC
      .Item("CSWRID") = _CSWRID
      .Item("PSWRC") = _PSWRC
      .Item("PSWRD") = _PSWRD
      .Item("PSWRIC") = _PSWRIC
      .Item("PSWRID") = _PSWRID
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
Public Property IsEOF As Boolean
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
  Dim mID As String
  Public Property _ID As String
    Get
      Return mID
    End Get
    Set(ByVal value As String)
      mID = value
    End Set
  End Property

  Dim mCTAXC As String
  Public Property _CTAXC As String
    Get
      Return mCTAXC
    End Get
    Set(ByVal value As String)
      mCTAXC = value
    End Set
  End Property

  Dim mCTAXD As String
  Public Property _CTAXD As String
    Get
      Return mCTAXD
    End Get
    Set(ByVal value As String)
      mCTAXD = value
    End Set
  End Property

  Dim mCSUC As String
  Public Property _CSUC As String
    Get
      Return mCSUC
    End Get
    Set(ByVal value As String)
      mCSUC = value
    End Set
  End Property

  Dim mCSUD As String
  Public Property _CSUD As String
    Get
      Return mCSUD
    End Get
    Set(ByVal value As String)
      mCSUD = value
    End Set
  End Property

  Dim mPTAXC As String
  Public Property _PTAXC As String
    Get
      Return mPTAXC
    End Get
    Set(ByVal value As String)
      mPTAXC = value
    End Set
  End Property

  Dim mPTAXD As String
  Public Property _PTAXD As String
    Get
      Return mPTAXD
    End Get
    Set(ByVal value As String)
      mPTAXD = value
    End Set
  End Property

  Dim mSTAXC As String
  Public Property _STAXC As String
    Get
      Return mSTAXC
    End Get
    Set(ByVal value As String)
      mSTAXC = value
    End Set
  End Property

  Dim mSTAXD As String
  Public Property _STAXD As String
    Get
      Return mSTAXD
    End Get
    Set(ByVal value As String)
      mSTAXD = value
    End Set
  End Property

  Dim mCINTC As String
  Public Property _CINTC As String
    Get
      Return mCINTC
    End Get
    Set(ByVal value As String)
      mCINTC = value
    End Set
  End Property

  Dim mCINTD As String
  Public Property _CINTD As String
    Get
      Return mCINTD
    End Get
    Set(ByVal value As String)
      mCINTD = value
    End Set
  End Property

  Dim mPINTC As String
  Public Property _PINTC As String
    Get
      Return mPINTC
    End Get
    Set(ByVal value As String)
      mPINTC = value
    End Set
  End Property

  Dim mPINTD As String
  Public Property _PINTD As String
    Get
      Return mPINTD
    End Get
    Set(ByVal value As String)
      mPINTD = value
    End Set
  End Property

  Dim mSINTC As String
  Public Property _SINTC As String
    Get
      Return mSINTC
    End Get
    Set(ByVal value As String)
      mSINTC = value
    End Set
  End Property

  Dim mSINTD As String
  Public Property _SINTD As String
    Get
      Return mSINTD
    End Get
    Set(ByVal value As String)
      mSINTD = value
    End Set
  End Property

  Dim mPENC As String
  Public Property _PENC As String
    Get
      Return mPENC
    End Get
    Set(ByVal value As String)
      mPENC = value
    End Set
  End Property

  Dim mPEND As String
  Public Property _PEND As String
    Get
      Return mPEND
    End Get
    Set(ByVal value As String)
      mPEND = value
    End Set
  End Property

  Dim mPENCBC As String
  Public Property _PENCBC As String
    Get
      Return mPENCBC
    End Get
    Set(ByVal value As String)
      mPENCBC = value
    End Set
  End Property

  Dim mPENCBD As String
  Public Property _PENCBD As String
    Get
      Return mPENCBD
    End Get
    Set(ByVal value As String)
      mPENCBD = value
    End Set
  End Property

  Dim mFTAXC As String
  Public Property _FTAXC As String
    Get
      Return mFTAXC
    End Get
    Set(ByVal value As String)
      mFTAXC = value
    End Set
  End Property

  Dim mFTAXD As String
  Public Property _FTAXD As String
    Get
      Return mFTAXD
    End Get
    Set(ByVal value As String)
      mFTAXD = value
    End Set
  End Property

  Dim mATAXC As String
  Public Property _ATAXC As String
    Get
      Return mATAXC
    End Get
    Set(ByVal value As String)
      mATAXC = value
    End Set
  End Property

  Dim mATAXD As String
  Public Property _ATAXD As String
    Get
      Return mATAXD
    End Get
    Set(ByVal value As String)
      mATAXD = value
    End Set
  End Property

  Dim mASWRC As String
  Public Property _ASWRC As String
    Get
      Return mASWRC
    End Get
    Set(ByVal value As String)
      mASWRC = value
    End Set
  End Property

  Dim mASWRD As String
  Public Property _ASWRD As String
    Get
      Return mASWRD
    End Get
    Set(ByVal value As String)
      mASWRD = value
    End Set
  End Property

  Dim mCSWRC As String
  Public Property _CSWRC As String
    Get
      Return mCSWRC
    End Get
    Set(ByVal value As String)
      mCSWRC = value
    End Set
  End Property

  Dim mCSWRD As String
  Public Property _CSWRD As String
    Get
      Return mCSWRD
    End Get
    Set(ByVal value As String)
      mCSWRD = value
    End Set
  End Property

  Dim mCSWRIC As String
  Public Property _CSWRIC As String
    Get
      Return mCSWRIC
    End Get
    Set(ByVal value As String)
      mCSWRIC = value
    End Set
  End Property

  Dim mCSWRID As String
  Public Property _CSWRID As String
    Get
      Return mCSWRID
    End Get
    Set(ByVal value As String)
      mCSWRID = value
    End Set
  End Property

  Dim mPSWRC As String
  Public Property _PSWRC As String
    Get
      Return mPSWRC
    End Get
    Set(ByVal value As String)
      mPSWRC = value
    End Set
  End Property

  Dim mPSWRD As String
  Public Property _PSWRD As String
    Get
      Return mPSWRD
    End Get
    Set(ByVal value As String)
      mPSWRD = value
    End Set
  End Property

  Dim mPSWRIC As String
  Public Property _PSWRIC As String
    Get
      Return mPSWRIC
    End Get
    Set(ByVal value As String)
      mPSWRIC = value
    End Set
  End Property

  Dim mPSWRID As String
  Public Property _PSWRID As String
    Get
      Return mPSWRID
    End Get
    Set(ByVal value As String)
      mPSWRID = value
    End Set
  End Property
#End Region
End Class

