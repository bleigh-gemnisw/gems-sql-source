Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "BDCON"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function AutoGenKey() As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & cFileName & " order by recid desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("recid") + 1
      End If
      If NextKey > 9999999 Then
        NextKey = 1
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
  Public Sub ClearFields()
    _RECID = 0
    _CONAME = String.Empty
    _COADD1 = String.Empty
    _COCITY = String.Empty
    _COST = String.Empty
    _COZIP = String.Empty
    _COPHON = String.Empty
    _COLIC1 = String.Empty
    _COLIC2 = String.Empty
    _COLIC3 = String.Empty
    _COLIC4 = String.Empty
    _COLIC5 = String.Empty
    _PRF = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal WrkRecid As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where recid=" & WrkRecid
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
  Public Function PosData(ByVal WrkRecid As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where recid>=" & WrkRecid
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
      _RECID = .Item("RECID")
      _CONAME = .Item("CONAME")
      _COADD1 = .Item("COADD1")
      _COCITY = .Item("COCITY")
      _COST = .Item("COST")
      _COZIP = .Item("COZIP")
      _COPHON = .Item("COPHON")
      _COLIC1 = .Item("COLIC1")
      _COLIC2 = .Item("COLIC2")
      _COLIC3 = .Item("COLIC3")
      _COLIC4 = .Item("COLIC4")
      _COLIC5 = .Item("COLIC5")
      _PRF = .Item("PRF")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("CONAME") = _CONAME
      .Item("COADD1") = _COADD1
      .Item("COCITY") = _COCITY
      .Item("COST") = _COST
      .Item("COZIP") = _COZIP
      .Item("COPHON") = _COPHON
      .Item("COLIC1") = _COLIC1
      .Item("COLIC2") = _COLIC2
      .Item("COLIC3") = _COLIC3
      .Item("COLIC4") = _COLIC4
      .Item("COLIC5") = _COLIC5
      .Item("PRF") = _PRF
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
  Dim mRECID As Integer
  Public Property _RECID As Integer
    Get
      Return mRECID
    End Get
    Set(ByVal value As Integer)
      mRECID = value
    End Set
  End Property

  Dim mCONAME As String
  Public Property _CONAME As String
    Get
      Return mCONAME
    End Get
    Set(ByVal value As String)
      mCONAME = value
    End Set
  End Property

  Dim mCOADD1 As String
  Public Property _COADD1 As String
    Get
      Return mCOADD1
    End Get
    Set(ByVal value As String)
      mCOADD1 = value
    End Set
  End Property

  Dim mCOCITY As String
  Public Property _COCITY As String
    Get
      Return mCOCITY
    End Get
    Set(ByVal value As String)
      mCOCITY = value
    End Set
  End Property

  Dim mCOST As String
  Public Property _COST As String
    Get
      Return mCOST
    End Get
    Set(ByVal value As String)
      mCOST = value
    End Set
  End Property

  Dim mCOZIP As Integer
  Public Property _COZIP As Integer
    Get
      Return mCOZIP
    End Get
    Set(ByVal value As Integer)
      mCOZIP = value
    End Set
  End Property

  Dim mCOPHON As String
  Public Property _COPHON As String
    Get
      Return mCOPHON
    End Get
    Set(ByVal value As String)
      mCOPHON = value
    End Set
  End Property

  Dim mCOLIC1 As String
  Public Property _COLIC1 As String
    Get
      Return mCOLIC1
    End Get
    Set(ByVal value As String)
      mCOLIC1 = value
    End Set
  End Property

  Dim mCOLIC2 As String
  Public Property _COLIC2 As String
    Get
      Return mCOLIC2
    End Get
    Set(ByVal value As String)
      mCOLIC2 = value
    End Set
  End Property

  Dim mCOLIC3 As String
  Public Property _COLIC3 As String
    Get
      Return mCOLIC3
    End Get
    Set(ByVal value As String)
      mCOLIC3 = value
    End Set
  End Property

  Dim mCOLIC4 As String
  Public Property _COLIC4 As String
    Get
      Return mCOLIC4
    End Get
    Set(ByVal value As String)
      mCOLIC4 = value
    End Set
  End Property

  Dim mCOLIC5 As String
  Public Property _COLIC5 As String
    Get
      Return mCOLIC5
    End Get
    Set(ByVal value As String)
      mCOLIC5 = value
    End Set
  End Property

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property
#End Region
End Class

