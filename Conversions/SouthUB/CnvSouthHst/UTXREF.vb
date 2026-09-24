Imports System.Data
Imports System.Data.SqlClient
Public Class UTXREF
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFileName As String = "UTXREF"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CXACCT = 0
    _CXCODE = String.Empty
    _CXREF = String.Empty
    _CXUSE = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkcxacct As Integer, ByVal Wrkcxcode As String, ByVal Wrkcxref As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cxacct = " & Wrkcxacct & " and cxcode = " & "'" & Wrkcxcode & "'" & " and cxref = " & "'" & Wrkcxref & "'"
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
      ds.Clear()
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function GetAllAcct(ByVal WrkListNo As Integer, ByVal WrkCode As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cxacct=" & WrkListNo & " and cxcode='" & WrkCode & "'"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function
  Public Function PosData(ByVal Wrkcxacct As Integer, ByVal Wrkcxcode As String, ByVal Wrkcxref As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cxacct = " & Wrkcxacct & " And cxcode = " & "'" & Wrkcxcode & "'" & " And cxref >= " & "'" & Wrkcxref & "'" & " Or cxacct = " & Wrkcxacct & " And cxcode > " & "'" & Wrkcxcode & "'" & " Or cxacct > " & Wrkcxacct & " Order by cxacct, cxcode, cxref"
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
  Public Sub DeleteAcct(ByVal WrkListNo As Integer, ByVal WrkCode As String)
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " where cxacct=" & WrkListNo & " and cxcode='" & WrkCode & "'"

    RecordNotFound = False
    IsEOF = False
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
      _CXACCT = .Item("CXACCT")
      _CXCODE = .Item("CXCODE")
      _CXREF = .Item("CXREF")
      _CXUSE = .Item("CXUSE")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CXACCT") = _CXACCT
      .Item("CXCODE") = _CXCODE
      .Item("CXREF") = _CXREF
      .Item("CXUSE") = _CXUSE
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCXACCT As Integer
  Public Property _CXACCT As Integer
    Get
      Return mCXACCT
    End Get
    Set(ByVal value As Integer)
      mCXACCT = value
    End Set
  End Property

  Dim mCXCODE As String
  Public Property _CXCODE As String
    Get
      Return mCXCODE
    End Get
    Set(ByVal value As String)
      mCXCODE = value
    End Set
  End Property

  Dim mCXREF As String
  Public Property _CXREF As String
    Get
      Return mCXREF
    End Get
    Set(ByVal value As String)
      mCXREF = value
    End Set
  End Property
  Dim mCXUSE As String
  Public Property _CXUSE As String
    Get
      Return mCXUSE
    End Get
    Set(ByVal value As String)
      mCXUSE = value
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


