Imports System.Data
Imports System.Data.SqlClient
Public Class TXBANKS
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFileName As String = "TXBANKS"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _BKCODE = String.Empty
    _BKNAME = String.Empty
    _BKPRNT = String.Empty
    _BKADD1 = String.Empty
    _BKADD2 = String.Empty
    _BKADD3 = String.Empty
    _BKCTY = String.Empty
    _BKST = String.Empty
    _ZIP9 = 0

  End Sub
  Public Sub GetOneRecordP(ByVal WrkCode As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where bkcode='" & WrkCode & "'"
    Try
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
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("")
    Return ds
  End Function

  Public Function PosData(ByVal WrkCode As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where bkcode>='" & WrkCode & "' order by bkcode"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
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
      _BKCODE = .Item("BKCODE")
      _BKNAME = .Item("BKNAME")
      _BKPRNT = .Item("BKPRNT")
      _BKADD1 = .Item("BKADD1")
      _BKADD2 = .Item("BKADD2")
      _BKADD3 = .Item("BKADD3")
      _BKCTY = .Item("BKCTY")
      _BKST = .Item("BKST")
      _ZIP9 = .Item("ZIP9")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("BKCODE") = _BKCODE
      .Item("BKNAME") = _BKNAME
      .Item("BKPRNT") = _BKPRNT
      .Item("BKADD1") = _BKADD1
      .Item("BKADD2") = _BKADD2
      .Item("BKADD3") = _BKADD3
      .Item("BKCTY") = _BKCTY
      .Item("BKST") = _BKST
      .Item("ZIP9") = _ZIP9
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
  Dim mBKCODE As String
  Public Property _BKCODE As String
    Get
      Return mBKCODE
    End Get
    Set(ByVal value As String)
      mBKCODE = value
    End Set
  End Property

  Dim mBKNAME As String
  Public Property _BKNAME As String
    Get
      Return mBKNAME
    End Get
    Set(ByVal value As String)
      mBKNAME = value
    End Set
  End Property

  Dim mBKPRNT As String
  Public Property _BKPRNT As String
    Get
      Return mBKPRNT
    End Get
    Set(ByVal value As String)
      mBKPRNT = value
    End Set
  End Property

  Dim mBKADD1 As String
  Public Property _BKADD1 As String
    Get
      Return mBKADD1
    End Get
    Set(ByVal value As String)
      mBKADD1 = value
    End Set
  End Property

  Dim mBKADD2 As String
  Public Property _BKADD2 As String
    Get
      Return mBKADD2
    End Get
    Set(ByVal value As String)
      mBKADD2 = value
    End Set
  End Property

  Dim mBKADD3 As String
  Public Property _BKADD3 As String
    Get
      Return mBKADD3
    End Get
    Set(ByVal value As String)
      mBKADD3 = value
    End Set
  End Property

  Dim mBKCTY As String
  Public Property _BKCTY As String
    Get
      Return mBKCTY
    End Get
    Set(ByVal value As String)
      mBKCTY = value
    End Set
  End Property

  Dim mBKST As String
  Public Property _BKST As String
    Get
      Return mBKST
    End Get
    Set(ByVal value As String)
      mBKST = value
    End Set
  End Property

  Dim mZIP9 As Long
  Public Property _ZIP9 As Long
    Get
      Return mZIP9
    End Get
    Set(ByVal value As Long)
      mZIP9 = value
    End Set
  End Property

#End Region
End Class

