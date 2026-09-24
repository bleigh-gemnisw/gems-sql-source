Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXBAA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO = 0
_TYPE = string.empty
_YEAR = 0
_DNBTR = string.empty
_DTBTR = 0
_ASS1 = 0
_ASS2 = 0
_ASS3 = 0
_ASS4 = 0
_ASS5 = 0
_ASS6 = 0
_ASS7 = 0
_ASS8 = 0
_ASS9 = 0
_ASS10 = 0
_CODE1 = 0
_CODE2 = 0
_CODE3 = 0
_CODE4 = 0
_CODE5 = 0
_CODE6 = 0
_CODE7 = 0
_CODE8 = 0
_CODE9 = 0
_CODEA = 0
_BASS1 = 0
_BASS2 = 0
_BASS3 = 0
_BASS4 = 0
_BASS5 = 0
_BASS6 = 0
_BASS7 = 0
_BASS8 = 0
_BASS9 = 0
_BASSA = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkList As Integer, ByVal WrkType As String, ByVal WrkYear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list#=" & WrkList & " and type='" & WrkType & "' and year =" & WrkYear
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
  Public Function PosData(ByVal WrkList As Integer, ByVal WrkType As String, ByVal WrkYear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list#=" & WrkList & " and type='" & WrkType & "' and year >=" & WrkYear &
     " or list#=" & WrkList & " and type>'" & WrkType & " or list#>" & WrkList &
     " order by list#, type, year"
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
      _LISTNO = .Item("LIST#")
      _TYPE = .Item("TYPE")
      _YEAR = .Item("YEAR")
      _DNBTR = .Item("DNBTR")
      _DTBTR = .Item("DTBTR")
      _ASS1 = .Item("ASS1")
      _ASS2 = .Item("ASS2")
      _ASS3 = .Item("ASS3")
      _ASS4 = .Item("ASS4")
      _ASS5 = .Item("ASS5")
      _ASS6 = .Item("ASS6")
      _ASS7 = .Item("ASS7")
      _ASS8 = .Item("ASS8")
      _ASS9 = .Item("ASS9")
      _ASS10 = .Item("ASS10")
      _CODE1 = .Item("CODE1")
      _CODE2 = .Item("CODE2")
      _CODE3 = .Item("CODE3")
      _CODE4 = .Item("CODE4")
      _CODE5 = .Item("CODE5")
      _CODE6 = .Item("CODE6")
      _CODE7 = .Item("CODE7")
      _CODE8 = .Item("CODE8")
      _CODE9 = .Item("CODE9")
      _CODEA = .Item("CODEA")
      _BASS1 = .Item("BASS1")
      _BASS2 = .Item("BASS2")
      _BASS3 = .Item("BASS3")
      _BASS4 = .Item("BASS4")
      _BASS5 = .Item("BASS5")
      _BASS6 = .Item("BASS6")
      _BASS7 = .Item("BASS7")
      _BASS8 = .Item("BASS8")
      _BASS9 = .Item("BASS9")
      _BASSA = .Item("BASSA")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("TYPE") = _TYPE
      .Item("YEAR") = _YEAR
      .Item("DNBTR") = _DNBTR
      .Item("DTBTR") = _DTBTR
      .Item("ASS1") = _ASS1
      .Item("ASS2") = _ASS2
      .Item("ASS3") = _ASS3
      .Item("ASS4") = _ASS4
      .Item("ASS5") = _ASS5
      .Item("ASS6") = _ASS6
      .Item("ASS7") = _ASS7
      .Item("ASS8") = _ASS8
      .Item("ASS9") = _ASS9
      .Item("ASS10") = _ASS10
      .Item("CODE1") = _CODE1
      .Item("CODE2") = _CODE2
      .Item("CODE3") = _CODE3
      .Item("CODE4") = _CODE4
      .Item("CODE5") = _CODE5
      .Item("CODE6") = _CODE6
      .Item("CODE7") = _CODE7
      .Item("CODE8") = _CODE8
      .Item("CODE9") = _CODE9
      .Item("CODEA") = _CODEA
      .Item("BASS1") = _BASS1
      .Item("BASS2") = _BASS2
      .Item("BASS3") = _BASS3
      .Item("BASS4") = _BASS4
      .Item("BASS5") = _BASS5
      .Item("BASS6") = _BASS6
      .Item("BASS7") = _BASS7
      .Item("BASS8") = _BASS8
      .Item("BASS9") = _BASS9
      .Item("BASSA") = _BASSA
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
  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
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

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mDNBTR As String
  Public Property _DNBTR As String
    Get
      Return mDNBTR
    End Get
    Set(ByVal value As String)
      mDNBTR = value
    End Set
  End Property

  Dim mDTBTR As Integer
  Public Property _DTBTR As Integer
    Get
      Return mDTBTR
    End Get
    Set(ByVal value As Integer)
      mDTBTR = value
    End Set
  End Property

  Dim mASS1 As Long
  Public Property _ASS1 As Long
    Get
      Return mASS1
    End Get
    Set(ByVal value As Long)
      mASS1 = value
    End Set
  End Property

  Dim mASS2 As Long
  Public Property _ASS2 As Long
    Get
      Return mASS2
    End Get
    Set(ByVal value As Long)
      mASS2 = value
    End Set
  End Property

  Dim mASS3 As Long
  Public Property _ASS3 As Long
    Get
      Return mASS3
    End Get
    Set(ByVal value As Long)
      mASS3 = value
    End Set
  End Property

  Dim mASS4 As Long
  Public Property _ASS4 As Long
    Get
      Return mASS4
    End Get
    Set(ByVal value As Long)
      mASS4 = value
    End Set
  End Property

  Dim mASS5 As Long
  Public Property _ASS5 As Long
    Get
      Return mASS5
    End Get
    Set(ByVal value As Long)
      mASS5 = value
    End Set
  End Property

  Dim mASS6 As Long
  Public Property _ASS6 As Long
    Get
      Return mASS6
    End Get
    Set(ByVal value As Long)
      mASS6 = value
    End Set
  End Property

  Dim mASS7 As Long
  Public Property _ASS7 As Long
    Get
      Return mASS7
    End Get
    Set(ByVal value As Long)
      mASS7 = value
    End Set
  End Property

  Dim mASS8 As Long
  Public Property _ASS8 As Long
    Get
      Return mASS8
    End Get
    Set(ByVal value As Long)
      mASS8 = value
    End Set
  End Property

  Dim mASS9 As Long
  Public Property _ASS9 As Long
    Get
      Return mASS9
    End Get
    Set(ByVal value As Long)
      mASS9 = value
    End Set
  End Property

  Dim mASS10 As Long
  Public Property _ASS10 As Long
    Get
      Return mASS10
    End Get
    Set(ByVal value As Long)
      mASS10 = value
    End Set
  End Property

  Dim mCODE1 As Integer
  Public Property _CODE1 As Integer
    Get
      Return mCODE1
    End Get
    Set(ByVal value As Integer)
      mCODE1 = value
    End Set
  End Property

  Dim mCODE2 As Integer
  Public Property _CODE2 As Integer
    Get
      Return mCODE2
    End Get
    Set(ByVal value As Integer)
      mCODE2 = value
    End Set
  End Property

  Dim mCODE3 As Integer
  Public Property _CODE3 As Integer
    Get
      Return mCODE3
    End Get
    Set(ByVal value As Integer)
      mCODE3 = value
    End Set
  End Property

  Dim mCODE4 As Integer
  Public Property _CODE4 As Integer
    Get
      Return mCODE4
    End Get
    Set(ByVal value As Integer)
      mCODE4 = value
    End Set
  End Property

  Dim mCODE5 As Integer
  Public Property _CODE5 As Integer
    Get
      Return mCODE5
    End Get
    Set(ByVal value As Integer)
      mCODE5 = value
    End Set
  End Property

  Dim mCODE6 As Integer
  Public Property _CODE6 As Integer
    Get
      Return mCODE6
    End Get
    Set(ByVal value As Integer)
      mCODE6 = value
    End Set
  End Property

  Dim mCODE7 As Integer
  Public Property _CODE7 As Integer
    Get
      Return mCODE7
    End Get
    Set(ByVal value As Integer)
      mCODE7 = value
    End Set
  End Property

  Dim mCODE8 As Integer
  Public Property _CODE8 As Integer
    Get
      Return mCODE8
    End Get
    Set(ByVal value As Integer)
      mCODE8 = value
    End Set
  End Property

  Dim mCODE9 As Integer
  Public Property _CODE9 As Integer
    Get
      Return mCODE9
    End Get
    Set(ByVal value As Integer)
      mCODE9 = value
    End Set
  End Property

  Dim mCODEA As Integer
  Public Property _CODEA As Integer
    Get
      Return mCODEA
    End Get
    Set(ByVal value As Integer)
      mCODEA = value
    End Set
  End Property

  Dim mBASS1 As Long
  Public Property _BASS1 As Long
    Get
      Return mBASS1
    End Get
    Set(ByVal value As Long)
      mBASS1 = value
    End Set
  End Property

  Dim mBASS2 As Long
  Public Property _BASS2 As Long
    Get
      Return mBASS2
    End Get
    Set(ByVal value As Long)
      mBASS2 = value
    End Set
  End Property

  Dim mBASS3 As Long
  Public Property _BASS3 As Long
    Get
      Return mBASS3
    End Get
    Set(ByVal value As Long)
      mBASS3 = value
    End Set
  End Property

  Dim mBASS4 As Long
  Public Property _BASS4 As Long
    Get
      Return mBASS4
    End Get
    Set(ByVal value As Long)
      mBASS4 = value
    End Set
  End Property

  Dim mBASS5 As Long
  Public Property _BASS5 As Long
    Get
      Return mBASS5
    End Get
    Set(ByVal value As Long)
      mBASS5 = value
    End Set
  End Property

  Dim mBASS6 As Long
  Public Property _BASS6 As Long
    Get
      Return mBASS6
    End Get
    Set(ByVal value As Long)
      mBASS6 = value
    End Set
  End Property

  Dim mBASS7 As Long
  Public Property _BASS7 As Long
    Get
      Return mBASS7
    End Get
    Set(ByVal value As Long)
      mBASS7 = value
    End Set
  End Property

  Dim mBASS8 As Long
  Public Property _BASS8 As Long
    Get
      Return mBASS8
    End Get
    Set(ByVal value As Long)
      mBASS8 = value
    End Set
  End Property

  Dim mBASS9 As Long
  Public Property _BASS9 As Long
    Get
      Return mBASS9
    End Get
    Set(ByVal value As Long)
      mBASS9 = value
    End Set
  End Property

  Dim mBASSA As Long
  Public Property _BASSA As Long
    Get
      Return mBASSA
    End Get
    Set(ByVal value As Long)
      mBASSA = value
    End Set
  End Property
#End Region
End Class

