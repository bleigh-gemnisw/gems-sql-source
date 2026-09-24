Imports System.Data
Imports System.Data.SqlClient
Public Class TXINVDTL
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFilename As String = "TXINVDTL"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region
#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNo = 0
    _YEAR = 0
    _TYPE = String.Empty
    _PERD = 0
    _CODE = String.Empty
    _AMOUNT = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrktype As String, ByVal WrkPeriod As Integer, ByVal WrkCode As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    ErrMsg = ""
    StrSQL = "Select * from " & cFilename & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and type = " & "'" & Wrktype & "'" &
      " and perd = " & WrkPeriod & " and code = " & "'" & WrkCode & "'"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFilename)
      If ds.Tables(0).Rows.Count = 0 Then
        ClearFields()
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
    da.Fill(ds, cFilename)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    PutFields(ds)
    da.Update(ds, cFilename)
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
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _PERD = .Item("PERD")
      _CODE = .Item("CODE")
      _AMOUNT = .Item("AMOUNT")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNo
      .Item("YEAR") = _YEAR
      .Item("TYPE") = _TYPE
      .Item("PERD") = _PERD
      .Item("CODE") = _CODE
      .Item("AMOUNT") = _AMOUNT
    End With
  End Sub
#End Region

#Region "Properties: Fields"

  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
    End Set
  End Property
  Dim mPERD As Integer
  Public Property _PERD As Integer
    Get
      Return mPERD
    End Get
    Set(ByVal value As Integer)
      mPERD = value
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
  Dim mAMOUNT As Decimal
  Public Property _AMOUNT As Decimal
    Get
      Return mAMOUNT
    End Get
    Set(ByVal value As Decimal)
      mAMOUNT = value
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

