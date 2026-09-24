Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "MUNJE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region


#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Acct As String, ByVal Proj As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where acct='" & Acct & "' and proj='" & Proj & "'"
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
  Public Function PosData(ByVal Acct As String, ByVal Proj As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where acct='" & Acct & "' and proj>='" & Proj & "'" _
    & " or acct>'" & Acct & "' order by acct,proj"
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
      _ACCT = .Item("ACCT")
      _PROJ = .Item("PROJ")
      _FACCT = .Item("FACCT")
      _COMM = .Item("COMM")
      _REF2 = .Item("REF2")
      _REF3 = .Item("REF3")
      _DC = .Item("DC")
      _AMT = .Item("AMT")
      _ENCDC = .Item("ENCDC")
      _ENCAMT = .Item("ENCAMT")
      _ALLOC = .Item("ALLOC")
      _TRANS = .Item("TRANS")
      _PROJTY = .Item("PROJTY")
      _PROJST = .Item("PROJST")
    End With
  End Sub

Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("ACCT") = _ACCT
      .Item("PROJ") = _PROJ
      .Item("FACCT") = _FACCT
      .Item("COMM") = _COMM
      .Item("REF2") = _REF2
      .Item("REF3") = _REF3
      .Item("DC") = _DC
      .Item("AMT") = _AMT
      .Item("ENCDC") = _ENCDC
      .Item("ENCAMT") = _ENCAMT
      .Item("ALLOC") = _ALLOC
      .Item("TRANS") = _TRANS
      .Item("PROJTY") = _PROJTY
      .Item("PROJST") = _PROJST
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
Public Property IsEOF As Boolean
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
  Dim mACCT As String
  Public Property _ACCT As String
    Get
      Return mACCT
    End Get
    Set(ByVal value As String)
      mACCT = value
    End Set
  End Property

  Dim mPROJ As String
  Public Property _PROJ As String
    Get
      Return mPROJ
    End Get
    Set(ByVal value As String)
      mPROJ = value
    End Set
  End Property

  Dim mFACCT As String
  Public Property _FACCT As String
    Get
      Return mFACCT
    End Get
    Set(ByVal value As String)
      mFACCT = value
    End Set
  End Property

  Dim mCOMM As String
  Public Property _COMM As String
    Get
      Return mCOMM
    End Get
    Set(ByVal value As String)
      mCOMM = value
    End Set
  End Property

  Dim mREF2 As String
  Public Property _REF2 As String
    Get
      Return mREF2
    End Get
    Set(ByVal value As String)
      mREF2 = value
    End Set
  End Property

  Dim mREF3 As String
  Public Property _REF3 As String
    Get
      Return mREF3
    End Get
    Set(ByVal value As String)
      mREF3 = value
    End Set
  End Property

  Dim mDC As String
  Public Property _DC As String
    Get
      Return mDC
    End Get
    Set(ByVal value As String)
      mDC = value
    End Set
  End Property

  Dim mAMT As Long
  Public Property _AMT As Long
    Get
      Return mAMT
    End Get
    Set(ByVal value As Long)
      mAMT = value
    End Set
  End Property

  Dim mENCDC As String
  Public Property _ENCDC As String
    Get
      Return mENCDC
    End Get
    Set(ByVal value As String)
      mENCDC = value
    End Set
  End Property

  Dim mENCAMT As Long
  Public Property _ENCAMT As Long
    Get
      Return mENCAMT
    End Get
    Set(ByVal value As Long)
      mENCAMT = value
    End Set
  End Property

  Dim mALLOC As String
  Public Property _ALLOC As String
    Get
      Return mALLOC
    End Get
    Set(ByVal value As String)
      mALLOC = value
    End Set
  End Property

  Dim mTRANS As String
  Public Property _TRANS As String
    Get
      Return mTRANS
    End Get
    Set(ByVal value As String)
      mTRANS = value
    End Set
  End Property

  Dim mPROJTY As String
  Public Property _PROJTY As String
    Get
      Return mPROJTY
    End Get
    Set(ByVal value As String)
      mPROJTY = value
    End Set
  End Property

  Dim mPROJST As String
  Public Property _PROJST As String
    Get
      Return mPROJST
    End Get
    Set(ByVal value As String)
      mPROJST = value
    End Set
  End Property
#End Region
End Class

