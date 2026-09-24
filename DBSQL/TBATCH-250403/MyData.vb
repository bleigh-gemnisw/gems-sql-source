Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TBATCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_KSTATS = string.empty
_KBTCHC = string.empty
_KBTCHNo = 0
_KBTCHT = string.empty
_KRMM = 0
_KRDD = 0
_KRYY = 0
_KIMM = 0
_KIDD = 0
_KIYY = 0
_KMMM = 0
_KMDD = 0
_KMYY = 0
_KPRINT = string.empty
_KVALID = string.empty
_KUCODE = 0
_KUSER = string.empty
_KBSTAT = string.empty
_KBCASH = 0
_KBEND = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkBatchCd As String, WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where kbtchc='" & WrkBatchCd & "' and kbtch#=" & WrkBchno
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
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
Public Function PosData(ByVal WrkBatchCd As String, WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & " where kbtchc='" & WrkBatchCd & _
  "' and kbtch#>=" & WrkBchno & "order by kbtch#"
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
Public Function PosData_MDY(ByVal WrkBatchCd As String, WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & " where kbtchc='" & WrkBatchCd & _
  "' and kbtch#>=" & WrkBchno & "order by kbtch#"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    ds2 = ReplaceDS(ds)
    ds = Nothing
    objCommand = Nothing
    Conn.Close()
    Return ds2
  Return ds
End Function
Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("kbtchc", Type.GetType("System.String"))
      .Columns.Add("kbtch#", Type.GetType("System.Int16"))
      .Columns.Add("kbtcht", Type.GetType("System.String"))
      .Columns.Add("krmdy", Type.GetType("System.String"))
      .Columns.Add("kimdy", Type.GetType("System.String"))
      .Columns.Add("kprint", Type.GetType("System.String"))
      .Columns.Add("kvalid", Type.GetType("System.String"))
      .Columns.Add("kuser", Type.GetType("System.String"))
      .Columns.Add("kucode", Type.GetType("System.Int16"))
      .Columns.Add("kbstat", Type.GetType("System.String"))
      .Columns.Add("kbend", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("kbtchc") = .Item("kbtchc")
      dr.Item("kbtch#") = .Item("kbtch#")
      dr.Item("kbtcht") = .Item("kbtcht")
      dr.Item("krmdy") = .Item("krmm") & "/" & .Item("krdd") & "/" & .Item("kryy")
      dr.Item("kimdy") = .Item("kimm") & "/" & .Item("kidd") & "/" & .Item("kiyy")
      dr.Item("kprint") = .Item("kprint")
      dr.Item("kvalid") = .Item("kvalid")
      dr.Item("kuser") = .Item("kuser")
      dr.Item("kucode") = .Item("kucode")
      dr.Item("kbstat") = .Item("kbstat")
      dr.Item("kbend") = .Item("kbend")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next

    Return ds2
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
  Public Sub DeleteBatch(ByVal WrkBatchCd As String, WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where kbtchc='" & WrkBatchCd & "' and kbtch#=" & WrkBchno
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
    _KSTATS = .Item("KSTATS")
    _KBTCHC = .Item("KBTCHC")
    _KBTCHNo = .Item("KBTCH#")
    _KBTCHT = .Item("KBTCHT")
    _KRMM = .Item("KRMM")
    _KRDD = .Item("KRDD")
    _KRYY = .Item("KRYY")
    _KIMM = .Item("KIMM")
    _KIDD = .Item("KIDD")
    _KIYY = .Item("KIYY")
    _KMMM = .Item("KMMM")
    _KMDD = .Item("KMDD")
    _KMYY = .Item("KMYY")
    _KPRINT = .Item("KPRINT")
    _KVALID = .Item("KVALID")
    _KUCODE = .Item("KUCODE")
    _KUSER = .Item("KUSER")
    _KBSTAT = .Item("KBSTAT")
    _KBCASH = .Item("KBCASH")
    _KBEND = .Item("KBEND")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("KSTATS") = _KSTATS
    .Item("KBTCHC") = _KBTCHC
    .Item("KBTCH#") = _KBTCHNo
    .Item("KBTCHT") = _KBTCHT
    .Item("KRMM") = _KRMM
    .Item("KRDD") = _KRDD
    .Item("KRYY") = _KRYY
    .Item("KIMM") = _KIMM
    .Item("KIDD") = _KIDD
    .Item("KIYY") = _KIYY
    .Item("KMMM") = _KMMM
    .Item("KMDD") = _KMDD
    .Item("KMYY") = _KMYY
    .Item("KPRINT") = _KPRINT
    .Item("KVALID") = _KVALID
    .Item("KUCODE") = _KUCODE
    .Item("KUSER") = _KUSER
    .Item("KBSTAT") = _KBSTAT
    .Item("KBCASH") = _KBCASH
    .Item("KBEND") = _KBEND
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
Dim mKSTATS As String
Public Property _KSTATS As String
    Get
        Return mKSTATS
    End Get
    Set(ByVal value As String)
        mKSTATS = value
    End Set
End Property

Dim mKBTCHC As String
Public Property _KBTCHC As String
    Get
        Return mKBTCHC
    End Get
    Set(ByVal value As String)
        mKBTCHC = value
    End Set
End Property

Dim mKBTCHNo As Integer
Public Property _KBTCHNo As Integer
    Get
        Return mKBTCHNo
    End Get
    Set(ByVal value As Integer)
        mKBTCHNo = value
    End Set
End Property

Dim mKBTCHT As String
Public Property _KBTCHT As String
    Get
        Return mKBTCHT
    End Get
    Set(ByVal value As String)
        mKBTCHT = value
    End Set
End Property

Dim mKRMM As Integer
Public Property _KRMM As Integer
    Get
        Return mKRMM
    End Get
    Set(ByVal value As Integer)
        mKRMM = value
    End Set
End Property

Dim mKRDD As Integer
Public Property _KRDD As Integer
    Get
        Return mKRDD
    End Get
    Set(ByVal value As Integer)
        mKRDD = value
    End Set
End Property

Dim mKRYY As Integer
Public Property _KRYY As Integer
    Get
        Return mKRYY
    End Get
    Set(ByVal value As Integer)
        mKRYY = value
    End Set
End Property

Dim mKIMM As Integer
Public Property _KIMM As Integer
    Get
        Return mKIMM
    End Get
    Set(ByVal value As Integer)
        mKIMM = value
    End Set
End Property

Dim mKIDD As Integer
Public Property _KIDD As Integer
    Get
        Return mKIDD
    End Get
    Set(ByVal value As Integer)
        mKIDD = value
    End Set
End Property

Dim mKIYY As Integer
Public Property _KIYY As Integer
    Get
        Return mKIYY
    End Get
    Set(ByVal value As Integer)
        mKIYY = value
    End Set
End Property

Dim mKMMM As Integer
Public Property _KMMM As Integer
    Get
        Return mKMMM
    End Get
    Set(ByVal value As Integer)
        mKMMM = value
    End Set
End Property

Dim mKMDD As Integer
Public Property _KMDD As Integer
    Get
        Return mKMDD
    End Get
    Set(ByVal value As Integer)
        mKMDD = value
    End Set
End Property

Dim mKMYY As Integer
Public Property _KMYY As Integer
    Get
        Return mKMYY
    End Get
    Set(ByVal value As Integer)
        mKMYY = value
    End Set
End Property

Dim mKPRINT As String
Public Property _KPRINT As String
    Get
        Return mKPRINT
    End Get
    Set(ByVal value As String)
        mKPRINT = value
    End Set
End Property

Dim mKVALID As String
Public Property _KVALID As String
    Get
        Return mKVALID
    End Get
    Set(ByVal value As String)
        mKVALID = value
    End Set
End Property

Dim mKUCODE As Integer
Public Property _KUCODE As Integer
    Get
        Return mKUCODE
    End Get
    Set(ByVal value As Integer)
        mKUCODE = value
    End Set
End Property

Dim mKUSER As String
Public Property _KUSER As String
    Get
        Return mKUSER
    End Get
    Set(ByVal value As String)
        mKUSER = value
    End Set
End Property

Dim mKBSTAT As String
Public Property _KBSTAT As String
    Get
        Return mKBSTAT
    End Get
    Set(ByVal value As String)
        mKBSTAT = value
    End Set
End Property

Dim mKBCASH As Decimal
Public Property _KBCASH As Decimal
    Get
        Return mKBCASH
    End Get
    Set(ByVal value As Decimal)
        mKBCASH = value
    End Set
End Property

Dim mKBEND As Decimal
Public Property _KBEND As Decimal
    Get
        Return mKBEND
    End Get
    Set(ByVal value As Decimal)
        mKBEND = value
    End Set
End Property
#End Region
End Class

