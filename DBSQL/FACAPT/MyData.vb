Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "FACAPT"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal RecNum As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName
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
Public Function PosData(ByVal Code As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where capt>='" & Code & "'"
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

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _CAPT = .Item("CAPT")
    _CAP01 = .Item("CAP01")
    _CAP02 = .Item("CAP02")
    _CAP03 = .Item("CAP03")
    _CAP04 = .Item("CAP04")
    _CAP05 = .Item("CAP05")
    _CAP06 = .Item("CAP06")
    _CAP07 = .Item("CAP07")
    _CAP08 = .Item("CAP08")
    _CAP09 = .Item("CAP09")
    _CAP10 = .Item("CAP10")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("CAPT") = _CAPT
    .Item("CAP01") = _CAP01
    .Item("CAP02") = _CAP02
    .Item("CAP03") = _CAP03
    .Item("CAP04") = _CAP04
    .Item("CAP05") = _CAP05
    .Item("CAP06") = _CAP06
    .Item("CAP07") = _CAP07
    .Item("CAP08") = _CAP08
    .Item("CAP09") = _CAP09
    .Item("CAP10") = _CAP10
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
Dim mCAPT As String
Public Property _CAPT As String
    Get
        Return mCAPT
    End Get
    Set(ByVal value As String)
        mCAPT = value
    End Set
End Property
Dim mCAP01 As String
Public Property _CAP01 As String
    Get
        Return mCAP01
    End Get
    Set(ByVal value As String)
        mCAP01 = value
    End Set
End Property
Dim mCAP02 As String
Public Property _CAP02 As String
    Get
        Return mCAP02
    End Get
    Set(ByVal value As String)
        mCAP02 = value
    End Set
End Property
Dim mCAP03 As String
Public Property _CAP03 As String
    Get
        Return mCAP03
    End Get
    Set(ByVal value As String)
        mCAP03 = value
    End Set
End Property
Dim mCAP04 As String
Public Property _CAP04 As String
    Get
        Return mCAP04
    End Get
    Set(ByVal value As String)
        mCAP04 = value
    End Set
End Property
Dim mCAP05 As String
Public Property _CAP05 As String
    Get
        Return mCAP05
    End Get
    Set(ByVal value As String)
        mCAP05 = value
    End Set
End Property
Dim mCAP06 As String
Public Property _CAP06 As String
    Get
        Return mCAP06
    End Get
    Set(ByVal value As String)
        mCAP06 = value
    End Set
End Property
Dim mCAP07 As String
Public Property _CAP07 As String
    Get
        Return mCAP07
    End Get
    Set(ByVal value As String)
        mCAP07 = value
    End Set
End Property
Dim mCAP08 As String
Public Property _CAP08 As String
    Get
        Return mCAP08
    End Get
    Set(ByVal value As String)
        mCAP08 = value
    End Set
End Property
Dim mCAP09 As String
Public Property _CAP09 As String
    Get
        Return mCAP09
    End Get
    Set(ByVal value As String)
        mCAP09 = value
    End Set
End Property
Dim mCAP10 As String
Public Property _CAP10 As String
    Get
        Return mCAP10
    End Get
    Set(ByVal value As String)
        mCAP10 = value
    End Set
End Property
#End Region

End Class

