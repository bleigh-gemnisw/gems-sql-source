Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "MRBCHD"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal WrkBchno As Integer, ByVal WrkCode As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " and code='" & WrkCode & "'"
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
  Public Function GetViewbyBatch(ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & " * from " & cFileName & " where bchno=" & WrkBchno & " order by code"
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
  Public Sub SetRange(ByVal WrkBchno As Integer)
    Dim objCommand As SqlCommand

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno & " order by bchno, code"
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
  Public Sub DeleteBatch(ByVal WrkBchno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName & " where bchno=" & WrkBchno
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
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _BCHNO = .Item("BCHNO")
      _CODE = .Item("CODE")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _TOTAL = .Item("TOTAL")
    End With
  End Sub
  Public Sub GetFieldsRdr()
    With objreader
      _BCHNO = .Item("BCHNO")
      _CODE = .Item("CODE")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _TOTAL = .Item("TOTAL")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("BCHNO") = _BCHNO
      .Item("CODE") = _CODE
      .Item("CASH") = _CASH
      .Item("CHECK") = _CHECK
      .Item("CREDIT") = _CREDIT
      .Item("TOTAL") = _TOTAL
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
  Dim mBCHNO As Integer
  Public Property _BCHNO As Integer
    Get
      Return mBCHNO
    End Get
    Set(ByVal value As Integer)
      mBCHNO = value
    End Set
  End Property
  Dim mCODE As String
  Public Property _CODE As String
    Get
      Return mCODE
    End Get
    Set(ByVal value As String)
      mCODE = value
    End Set
  End Property
  Dim mCASH As Decimal
  Public Property _CASH As Decimal
    Get
      Return mCASH
    End Get
    Set(ByVal value As Decimal)
      mCASH = value
    End Set
  End Property
  Dim mCHECK As Decimal
  Public Property _CHECK As Decimal
    Get
      Return mCHECK
    End Get
    Set(ByVal value As Decimal)
      mCHECK = value
    End Set
  End Property
  Dim mCREDIT As Decimal
  Public Property _CREDIT As Decimal
    Get
      Return mCREDIT
    End Get
    Set(ByVal value As Decimal)
      mCREDIT = value
    End Set
  End Property
  Dim mTOTAL As Decimal
  Public Property _TOTAL As Decimal
    Get
      Return mTOTAL
    End Get
    Set(ByVal value As Decimal)
      mTOTAL = value
    End Set
  End Property
#End Region
End Class

