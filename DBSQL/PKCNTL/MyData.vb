Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "PKCNTL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _RECID = String.Empty
    _PAYTO = String.Empty
    _LINE1 = String.Empty
    _LINE2 = String.Empty
    _LINE3 = String.Empty
    _LINE4 = String.Empty
    _LINE5 = String.Empty
    _TITLE = String.Empty
    _SIGNED = String.Empty
    _TWNAME = String.Empty
    _DAYDBL = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal WrkRecID As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where RECID='" & WrkRecID & "'"
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
  Public Function PosData(ByVal WrkRecID As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where RECID>='" & WrkRecID & "' order by RECID"
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
      _PAYTO = .Item("PAYTO")
      _LINE1 = .Item("LINE1")
      _LINE2 = .Item("LINE2")
      _LINE3 = .Item("LINE3")
      _LINE4 = .Item("LINE4")
      _LINE5 = .Item("LINE5")
      _TITLE = .Item("TITLE")
      _SIGNED = .Item("SIGNED")
      _TWNAME = .Item("TWNAME")
      _DAYDBL = .Item("DAYDBL")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("PAYTO") = _PAYTO
      .Item("LINE1") = _LINE1
      .Item("LINE2") = _LINE2
      .Item("LINE3") = _LINE3
      .Item("LINE4") = _LINE4
      .Item("LINE5") = _LINE5
      .Item("TITLE") = _TITLE
      .Item("SIGNED") = _SIGNED
      .Item("TWNAME") = _TWNAME
      .Item("DAYDBL") = _DAYDBL
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
  Dim mRECID As String
  Public Property _RECID As String
    Get
      Return mRECID
    End Get
    Set(ByVal value As String)
      mRECID = value
    End Set
  End Property

  Dim mPAYTO As String
  Public Property _PAYTO As String
    Get
      Return mPAYTO
    End Get
    Set(ByVal value As String)
      mPAYTO = value
    End Set
  End Property

  Dim mLINE1 As String
  Public Property _LINE1 As String
    Get
      Return mLINE1
    End Get
    Set(ByVal value As String)
      mLINE1 = value
    End Set
  End Property

  Dim mLINE2 As String
  Public Property _LINE2 As String
    Get
      Return mLINE2
    End Get
    Set(ByVal value As String)
      mLINE2 = value
    End Set
  End Property

  Dim mLINE3 As String
  Public Property _LINE3 As String
    Get
      Return mLINE3
    End Get
    Set(ByVal value As String)
      mLINE3 = value
    End Set
  End Property

  Dim mLINE4 As String
  Public Property _LINE4 As String
    Get
      Return mLINE4
    End Get
    Set(ByVal value As String)
      mLINE4 = value
    End Set
  End Property

  Dim mLINE5 As String
  Public Property _LINE5 As String
    Get
      Return mLINE5
    End Get
    Set(ByVal value As String)
      mLINE5 = value
    End Set
  End Property

  Dim mTITLE As String
  Public Property _TITLE As String
    Get
      Return mTITLE
    End Get
    Set(ByVal value As String)
      mTITLE = value
    End Set
  End Property

  Dim mSIGNED As String
  Public Property _SIGNED As String
    Get
      Return mSIGNED
    End Get
    Set(ByVal value As String)
      mSIGNED = value
    End Set
  End Property

  Dim mTWNAME As String
  Public Property _TWNAME As String
    Get
      Return mTWNAME
    End Get
    Set(ByVal value As String)
      mTWNAME = value
    End Set
  End Property

  Dim mDAYDBL As Integer
  Public Property _DAYDBL As Integer
    Get
      Return mDAYDBL
    End Get
    Set(ByVal value As Integer)
      mDAYDBL = value
    End Set
  End Property
#End Region
End Class

