Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "CKHIST"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _EMPNO = 0
    _PORV = String.Empty
    _EMNAME = String.Empty
    _CKNUM = 0
    _CKDATE = 0
    _CKAMT = 0
    _CKCODE = String.Empty
    _CHKDTE = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkCknum As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cknum = " & WrkCknum
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
      _EMPNO = .Item("EMPNO")
      _PORV = .Item("PORV")
      _EMNAME = .Item("EMNAME")
      _CKNUM = .Item("CKNUM")
      _CKDATE = .Item("CKDATE")
      _CKAMT = .Item("CKAMT")
      _CKCODE = .Item("CKCODE")
      _CHKDTE = .Item("CHKDTE")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("EMPNO") = _EMPNO
      .Item("PORV") = _PORV
      .Item("EMNAME") = _EMNAME
      .Item("CKNUM") = _CKNUM
      .Item("CKDATE") = _CKDATE
      .Item("CKAMT") = _CKAMT
      .Item("CKCODE") = _CKCODE
      .Item("CHKDTE") = _CHKDTE
    End With
  End Sub
#End Region


#Region "Properties: Fields"

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
    Set(ByVal value As String)
      mErrMsg = value
    End Set
  End Property
  Dim mEMPNO As String
  Public Property _EMPNO As String
    Get
      Return mEMPNO
    End Get
    Set(ByVal value As String)
      mEMPNO = value
    End Set
  End Property

  Dim mPORV As String
  Public Property _PORV As String
    Get
      Return mPORV
    End Get
    Set(ByVal value As String)
      mPORV = value
    End Set
  End Property

  Dim mEMNAME As String
  Public Property _EMNAME As String
    Get
      Return mEMNAME
    End Get
    Set(ByVal value As String)
      mEMNAME = value
    End Set
  End Property

  Dim mCKNUM As Integer
  Public Property _CKNUM As Integer
    Get
      Return mCKNUM
    End Get
    Set(ByVal value As Integer)
      mCKNUM = value
    End Set
  End Property

  Dim mCKDATE As Integer
  Public Property _CKDATE As Integer
    Get
      Return mCKDATE
    End Get
    Set(ByVal value As Integer)
      mCKDATE = value
    End Set
  End Property
  Dim mCKAMT As Decimal
  Public Property _CKAMT As Decimal
    Get
      Return mCKAMT
    End Get
    Set(ByVal value As Decimal)
      mCKAMT = value
    End Set
  End Property

  Dim mCKCODE As String
  Public Property _CKCODE As String
    Get
      Return mCKCODE
    End Get
    Set(ByVal value As String)
      mCKCODE = value
    End Set
  End Property
  Dim mCHKDTE As Integer
  Public Property _CHKDTE As Integer
    Get
      Return mCHKDTE
    End Get
    Set(ByVal value As Integer)
      mCHKDTE = value
    End Set
  End Property
#End Region
End Class


