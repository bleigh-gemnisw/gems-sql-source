Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "BDENDRS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _TYPE = String.Empty
    _EL1 = String.Empty
    _EL2 = String.Empty
    _EL3 = String.Empty
    _EL4 = String.Empty
    _EL5 = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrktype As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where type = " & "'" & Wrktype & "'"
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
  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("")
    Return ds
  End Function
  Public Function PosData(ByVal Wrktype As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where type >= " & "'" & Wrktype & "'" & " Order by type"
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
      _TYPE = .Item("TYPE")
      _EL1 = .Item("EL1")
      _EL2 = .Item("EL2")
      _EL3 = .Item("EL3")
      _EL4 = .Item("EL4")
      _EL5 = .Item("EL5")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TYPE") = _TYPE
      .Item("EL1") = _EL1
      .Item("EL2") = _EL2
      .Item("EL3") = _EL3
      .Item("EL4") = _EL4
      .Item("EL5") = _EL5
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property

  Dim mEL1 As String
  Public Property _EL1 As String
    Get
      Return mEL1
    End Get
    Set(ByVal value As String)
      mEL1 = value
    End Set
  End Property

  Dim mEL2 As String
  Public Property _EL2 As String
    Get
      Return mEL2
    End Get
    Set(ByVal value As String)
      mEL2 = value
    End Set
  End Property

  Dim mEL3 As String
  Public Property _EL3 As String
    Get
      Return mEL3
    End Get
    Set(ByVal value As String)
      mEL3 = value
    End Set
  End Property

  Dim mEL4 As String
  Public Property _EL4 As String
    Get
      Return mEL4
    End Get
    Set(ByVal value As String)
      mEL4 = value
    End Set
  End Property

  Dim mEL5 As String
  Public Property _EL5 As String
    Get
      Return mEL5
    End Get
    Set(ByVal value As String)
      mEL5 = value
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


