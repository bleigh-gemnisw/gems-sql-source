Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "PRSUPD"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CPCKNO = 0
    _SEQNO = 0
    _EHOURS = 0
    _EDESC = ""
    _EAMT = 0
    _EYTD = 0
    _DDESC = ""
    _DAMT = 0
    _DYTD = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkChkno As Integer, ByVal WrkSeqno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cpckno=" & WrkChkno & " and seqno=" & WrkSeqno
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
  Public Function GetbyCheckNo(ByVal WrkChkno As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cpckno=" & WrkChkno & " order by cpckno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function PosData(ByVal WrkChkno As Integer, ByVal WrkSeqno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cpckno >= " & WrkChkno & " Order by cpckno"
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
      _CPCKNO = .Item("CPCKNO")
      _CPCKNO = .Item("CPCKNO")
      _SEQNO = .Item("SEQNO")
      _EHOURS = .Item("EHOURS")
      _EDESC = .Item("EDESC")
      _EAMT = .Item("EAMT")
      _EYTD = .Item("EYTD")
      _DDESC = .Item("DDESC")
      _DAMT = .Item("DAMT")
      _DYTD = .Item("DYTD")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CPCKNO") = _CPCKNO
      .Item("SEQNO") = _SEQNO
      .Item("EHOURS") = _EHOURS
      .Item("EDESC") = _EDESC
      .Item("EAMT") = _EAMT
      .Item("EYTD") = _EYTD
      .Item("DDESC") = _DDESC
      .Item("DAMT") = _DAMT
      .Item("DYTD") = _DYTD
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
  Dim mCPCKNO As Integer
  Public Property _CPCKNO As Integer
    Get
      Return mCPCKNO
    End Get
    Set(ByVal value As Integer)
      mCPCKNO = value
    End Set
  End Property

  Dim mSEQNO As Integer
  Public Property _SEQNO As Integer
    Get
      Return mSEQNO
    End Get
    Set(ByVal value As Integer)
      mSEQNO = value
    End Set
  End Property

  Dim mEHOURS As Decimal
  Public Property _EHOURS As Decimal
    Get
      Return mEHOURS
    End Get
    Set(ByVal value As Decimal)
      mEHOURS = value
    End Set
  End Property

  Dim mEDESC As String
  Public Property _EDESC As String
    Get
      Return mEDESC
    End Get
    Set(ByVal value As String)
      mEDESC = value
    End Set
  End Property

  Dim mEAMT As Decimal
  Public Property _EAMT As Decimal
    Get
      Return mEAMT
    End Get
    Set(ByVal value As Decimal)
      mEAMT = value
    End Set
  End Property

  Dim mEYTD As Decimal
  Public Property _EYTD As Decimal
    Get
      Return mEYTD
    End Get
    Set(ByVal value As Decimal)
      mEYTD = value
    End Set
  End Property

  Dim mDDESC As String
  Public Property _DDESC As String
    Get
      Return mDDESC
    End Get
    Set(ByVal value As String)
      mDDESC = value
    End Set
  End Property

  Dim mDAMT As Decimal
  Public Property _DAMT As Decimal
    Get
      Return mDAMT
    End Get
    Set(ByVal value As Decimal)
      mDAMT = value
    End Set
  End Property

  Dim mDYTD As Decimal
  Public Property _DYTD As Decimal
    Get
      Return mDYTD
    End Get
    Set(ByVal value As Decimal)
      mDYTD = value
    End Set
  End Property
#End Region
End Class

