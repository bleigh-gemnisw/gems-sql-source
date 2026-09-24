Imports System.Data
Imports System.Data.SqlClient
Public Class TXVCUS
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const MyFileName As String = "TXVCUS"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub
#End Region
#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Wrkcustid As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where custid = " & Wrkcustid
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
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
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
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
      _CUSTID = .Item("CUSTID")
      _NAME = .Item("NAME")
      _BUS = .Item("BUS")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIPA = .Item("ZIPA")
      _DOB = .Item("DOB")
      _SEX = .Item("SEX")
      _RADD1 = .Item("RADD1")
      _RADD2 = .Item("RADD2")
      _RCITY = .Item("RCITY")
      _RSTATE = .Item("RSTATE")
      _RZIPA = .Item("RZIPA")
      _CONFID = .Item("CONFID")
      _CHDATE = .Item("CHDATE")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CUSTID") = _CUSTID
      .Item("NAME") = _NAME
      .Item("BUS") = _BUS
      .Item("ADD1") = _ADD1
      .Item("ADD2") = _ADD2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIPA") = _ZIPA
      .Item("DOB") = _DOB
      .Item("SEX") = _SEX
      .Item("RADD1") = _RADD1
      .Item("RADD2") = _RADD2
      .Item("RCITY") = _RCITY
      .Item("RSTATE") = _RSTATE
      .Item("RZIPA") = _RZIPA
      .Item("CONFID") = _CONFID
      .Item("CHDATE") = _CHDATE

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCUSTID As Long
  Public Property _CUSTID As Long
    Get
      Return mCUSTID
    End Get
    Set(ByVal value As Long)
      mCUSTID = value
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

  Dim mBUS As String
  Public Property _BUS As String
    Get
      Return mBUS
    End Get
    Set(ByVal value As String)
      mBUS = value
    End Set
  End Property

  Dim mADD1 As String
  Public Property _ADD1 As String
    Get
      Return mADD1
    End Get
    Set(ByVal value As String)
      mADD1 = value
    End Set
  End Property

  Dim mADD2 As String
  Public Property _ADD2 As String
    Get
      Return mADD2
    End Get
    Set(ByVal value As String)
      mADD2 = value
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

  Dim mZIPA As String
  Public Property _ZIPA As String
    Get
      Return mZIPA
    End Get
    Set(ByVal value As String)
      mZIPA = value
    End Set
  End Property

  Dim mDOB As Integer
  Public Property _DOB As Integer
    Get
      Return mDOB
    End Get
    Set(ByVal value As Integer)
      mDOB = value
    End Set
  End Property

  Dim mSEX As String
  Public Property _SEX As String
    Get
      Return mSEX
    End Get
    Set(ByVal value As String)
      mSEX = value
    End Set
  End Property

  Dim mRADD1 As String
  Public Property _RADD1 As String
    Get
      Return mRADD1
    End Get
    Set(ByVal value As String)
      mRADD1 = value
    End Set
  End Property

  Dim mRADD2 As String
  Public Property _RADD2 As String
    Get
      Return mRADD2
    End Get
    Set(ByVal value As String)
      mRADD2 = value
    End Set
  End Property

  Dim mRCITY As String
  Public Property _RCITY As String
    Get
      Return mRCITY
    End Get
    Set(ByVal value As String)
      mRCITY = value
    End Set
  End Property

  Dim mRSTATE As String
  Public Property _RSTATE As String
    Get
      Return mRSTATE
    End Get
    Set(ByVal value As String)
      mRSTATE = value
    End Set
  End Property

  Dim mRZIPA As String
  Public Property _RZIPA As String
    Get
      Return mRZIPA
    End Get
    Set(ByVal value As String)
      mRZIPA = value
    End Set
  End Property

  Dim mCONFID As String
  Public Property _CONFID As String
    Get
      Return mCONFID
    End Get
    Set(ByVal value As String)
      mCONFID = value
    End Set
  End Property

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
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
