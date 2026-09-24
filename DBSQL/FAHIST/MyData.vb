Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "FAHIST"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal TagNo As String, ByVal Dedt As Integer)
Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where fhtag='" & Trim(TagNo) & "' and fhdedt=" & Dedt
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
Public Function GetViewbyList(ByVal TagNo As String, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkTop As String

  RecordNotFound = False
  WrkTop = String.Empty
  If NumRecs > 0 Then
    WrkTop = " TOP " & NumRecs
  End If
  StrSQL = "Select * from " & cFileName & " where fhtag='" & Trim(TagNo) & "'"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(ds, cFileName)
  BuildDS(ds2)
  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("Tag") = .Item("fhtag")
      dr.Item("Fisc") = .Item("fhfisc")
      dr.Item("Wkdate") = Mid(.Item("fhdedt"), 5, 4) & Mid(.Item("fhdedt"), 1, 4)
      dr.Item("dedt") = .Item("fhdedt")
      dr.Item("devl") = .Item("fhdevl")
      dr.Item("Adj") = .Item("fhadj")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next
  objCommand = Nothing
  Conn.Close()
  Return ds2

End Function
Public Function GetViewDscList(ByVal TagNo As String, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As DataRow
  Dim WrkTop As String

  RecordNotFound = False
  WrkTop = String.Empty
  If NumRecs > 0 Then
    WrkTop = " TOP " & NumRecs
  End If
  StrSQL = "Select * from " & cFileName & " where fhtag='" & Trim(TagNo) & "' order by fhdedt desc"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(ds, cFileName)
  BuildDS(ds2)
  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("Tag") = .Item("fhtag")
      dr.Item("Fisc") = .Item("fhfisc")
      dr.Item("Wkdate") = Mid(.Item("fhdedt"), 5, 4) & Mid(.Item("fhdedt"), 1, 4)
      dr.Item("dedt") = .Item("fhdedt")
      dr.Item("devl") = .Item("fhdevl")
      dr.Item("Adj") = .Item("fhadj")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next
  objCommand = Nothing
  Conn.Close()
  Return ds2
End Function
Public Function PosData(ByVal TagNo As String, ByVal Dedt As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where fatag>='" & Trim(TagNo) & "' and fhdedt>=" & Dedt
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
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Tag", Type.GetType("System.String"))
      .Columns.Add("Fisc", Type.GetType("System.Int32"))
      .Columns.Add("Wkdate", Type.GetType("System.Int32"))
      .Columns.Add("dedt", Type.GetType("System.Int32"))
      .Columns.Add("devl", Type.GetType("System.Int32"))
      .Columns.Add("Adj", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
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

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FHTAG = .Item("FHTAG")
    _FHDEVL = .Item("FHDEVL")
    _FHDEDT = .Item("FHDEDT")
    _FHADJ = .Item("FHADJ")
    _FHFND = .Item("FHFND")
    _FHSFND = .Item("FHSFND")
    _FHDEPT = .Item("FHDEPT")
    _FHOBJ = .Item("FHOBJ")
    _FHFCN = .Item("FHFCN")
    _FHSFCN = .Item("FHSFCN")
    _FHFISC = .Item("FHFISC")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FHTAG") = _FHTAG
    .Item("FHDEVL") = _FHDEVL
    .Item("FHDEDT") = _FHDEDT
    .Item("FHADJ") = _FHADJ
    .Item("FHFND") = _FHFND
    .Item("FHSFND") = _FHSFND
    .Item("FHDEPT") = _FHDEPT
    .Item("FHOBJ") = _FHOBJ
    .Item("FHFCN") = _FHFCN
    .Item("FHSFCN") = _FHSFCN
    .Item("FHFISC") = _FHFISC
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
Dim mFHTAG As String
Public Property _FHTAG As String
    Get
        Return mFHTAG
    End Get
    Set(ByVal value As String)
        mFHTAG = value
    End Set
End Property
Dim mFHDEVL As Decimal
Public Property _FHDEVL As Decimal
    Get
        Return mFHDEVL
    End Get
    Set(ByVal value As Decimal)
        mFHDEVL = value
    End Set
End Property
Dim mFHDEDT As Integer
Public Property _FHDEDT As Integer
    Get
        Return mFHDEDT
    End Get
    Set(ByVal value As Integer)
        mFHDEDT = value
    End Set
End Property
Dim mFHADJ As String
Public Property _FHADJ As String
    Get
        Return mFHADJ
    End Get
    Set(ByVal value As String)
        mFHADJ = value
    End Set
End Property
Dim mFHFND As Integer
Public Property _FHFND As Integer
    Get
        Return mFHFND
    End Get
    Set(ByVal value As Integer)
        mFHFND = value
    End Set
End Property
Dim mFHSFND As Integer
Public Property _FHSFND As Integer
    Get
        Return mFHSFND
    End Get
    Set(ByVal value As Integer)
        mFHSFND = value
    End Set
End Property
Dim mFHDEPT As Integer
Public Property _FHDEPT As Integer
    Get
        Return mFHDEPT
    End Get
    Set(ByVal value As Integer)
        mFHDEPT = value
    End Set
End Property
Dim mFHOBJ As Integer
Public Property _FHOBJ As Integer
    Get
        Return mFHOBJ
    End Get
    Set(ByVal value As Integer)
        mFHOBJ = value
    End Set
End Property
Dim mFHFCN As Integer
Public Property _FHFCN As Integer
    Get
        Return mFHFCN
    End Get
    Set(ByVal value As Integer)
        mFHFCN = value
    End Set
End Property
Dim mFHSFCN As Integer
Public Property _FHSFCN As Integer
    Get
        Return mFHSFCN
    End Get
    Set(ByVal value As Integer)
        mFHSFCN = value
    End Set
End Property
Dim mFHFISC As Integer
Public Property _FHFISC As Integer
    Get
        Return mFHFISC
    End Get
    Set(ByVal value As Integer)
        mFHFISC = value
    End Set
End Property
#End Region

End Class

