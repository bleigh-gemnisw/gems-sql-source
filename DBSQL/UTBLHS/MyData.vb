Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTBLHS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_ACCT = 0
_YEAR = 0
_TYPE = string.empty
_DIST = 0
_PHASE = 0
_PERIOD = string.empty
_NAME1 = string.empty
_NAME2 = string.empty
_BLAMT = 0
_AMT1 = 0
_CODE1 = string.empty
_AMT2 = 0
_CODE2 = string.empty
_AMT3 = 0
_CODE3 = string.empty
_AMT4 = 0
_CODE4 = string.empty
_AMT5 = 0
_CODE5 = string.empty
_AMT6 = 0
_CODE6 = string.empty
_BILDT = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where acct=" & WrkList & " and year=" & WrkYear & _
  " and type='" & WrkType & "'"
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
Public Function PosData(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where acct=" & WrkList & " and year=" & WrkYear & _
  " and type>='" & WrkType & "'"
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
    _ACCT = .Item("ACCT")
    _YEAR = .Item("YEAR")
    _TYPE = .Item("TYPE")
    _DIST = .Item("DIST")
    _PHASE = .Item("PHASE")
    _PERIOD = .Item("PERIOD")
    _NAME1 = .Item("NAME1")
    _NAME2 = .Item("NAME2")
    _BLAMT = .Item("BLAMT")
    _AMT1 = .Item("AMT1")
    _CODE1 = .Item("CODE1")
    _AMT2 = .Item("AMT2")
    _CODE2 = .Item("CODE2")
    _AMT3 = .Item("AMT3")
    _CODE3 = .Item("CODE3")
    _AMT4 = .Item("AMT4")
    _CODE4 = .Item("CODE4")
    _AMT5 = .Item("AMT5")
    _CODE5 = .Item("CODE5")
    _AMT6 = .Item("AMT6")
    _CODE6 = .Item("CODE6")
    _BILDT = .Item("BILDT")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("ACCT") = _ACCT
    .Item("YEAR") = _YEAR
    .Item("TYPE") = _TYPE
    .Item("DIST") = _DIST
    .Item("PHASE") = _PHASE
    .Item("PERIOD") = _PERIOD
    .Item("NAME1") = _NAME1
    .Item("NAME2") = _NAME2
    .Item("BLAMT") = _BLAMT
    .Item("AMT1") = _AMT1
    .Item("CODE1") = _CODE1
    .Item("AMT2") = _AMT2
    .Item("CODE2") = _CODE2
    .Item("AMT3") = _AMT3
    .Item("CODE3") = _CODE3
    .Item("AMT4") = _AMT4
    .Item("CODE4") = _CODE4
    .Item("AMT5") = _AMT5
    .Item("CODE5") = _CODE5
    .Item("AMT6") = _AMT6
    .Item("CODE6") = _CODE6
    .Item("BILDT") = _BILDT
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
Dim mACCT As Integer
Public Property _ACCT As Integer
    Get
        Return mACCT
    End Get
    Set(ByVal value As Integer)
        mACCT = value
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
Dim mDIST As Integer
Public Property _DIST As Integer
    Get
        Return mDIST
    End Get
    Set(ByVal value As Integer)
        mDIST = value
    End Set
End Property
Dim mPHASE As Integer
Public Property _PHASE As Integer
    Get
        Return mPHASE
    End Get
    Set(ByVal value As Integer)
        mPHASE = value
    End Set
End Property
Dim mPERIOD As String
Public Property _PERIOD As String
    Get
        Return mPERIOD
    End Get
    Set(ByVal value As String)
        mPERIOD = value
    End Set
End Property
Dim mNAME1 As String
Public Property _NAME1 As String
    Get
        Return mNAME1
    End Get
    Set(ByVal value As String)
        mNAME1 = value
    End Set
End Property
Dim mNAME2 As String
Public Property _NAME2 As String
    Get
        Return mNAME2
    End Get
    Set(ByVal value As String)
        mNAME2 = value
    End Set
End Property
Dim mBLAMT As Decimal
Public Property _BLAMT As Decimal
    Get
        Return mBLAMT
    End Get
    Set(ByVal value As Decimal)
        mBLAMT = value
    End Set
End Property
Dim mAMT1 As Decimal
Public Property _AMT1 As Decimal
    Get
        Return mAMT1
    End Get
    Set(ByVal value As Decimal)
        mAMT1 = value
    End Set
End Property
Dim mCODE1 As String
Public Property _CODE1 As String
    Get
        Return mCODE1
    End Get
    Set(ByVal value As String)
        mCODE1 = value
    End Set
End Property
Dim mAMT2 As Decimal
Public Property _AMT2 As Decimal
    Get
        Return mAMT2
    End Get
    Set(ByVal value As Decimal)
        mAMT2 = value
    End Set
End Property
Dim mCODE2 As String
Public Property _CODE2 As String
    Get
        Return mCODE2
    End Get
    Set(ByVal value As String)
        mCODE2 = value
    End Set
End Property
Dim mAMT3 As Decimal
Public Property _AMT3 As Decimal
    Get
        Return mAMT3
    End Get
    Set(ByVal value As Decimal)
        mAMT3 = value
    End Set
End Property
Dim mCODE3 As String
Public Property _CODE3 As String
    Get
        Return mCODE3
    End Get
    Set(ByVal value As String)
        mCODE3 = value
    End Set
End Property
Dim mAMT4 As Decimal
Public Property _AMT4 As Decimal
    Get
        Return mAMT4
    End Get
    Set(ByVal value As Decimal)
        mAMT4 = value
    End Set
End Property
Dim mCODE4 As String
Public Property _CODE4 As String
    Get
        Return mCODE4
    End Get
    Set(ByVal value As String)
        mCODE4 = value
    End Set
End Property
Dim mAMT5 As Decimal
Public Property _AMT5 As Decimal
    Get
        Return mAMT5
    End Get
    Set(ByVal value As Decimal)
        mAMT5 = value
    End Set
End Property
Dim mCODE5 As String
Public Property _CODE5 As String
    Get
        Return mCODE5
    End Get
    Set(ByVal value As String)
        mCODE5 = value
    End Set
End Property
Dim mAMT6 As Decimal
Public Property _AMT6 As Decimal
    Get
        Return mAMT6
    End Get
    Set(ByVal value As Decimal)
        mAMT6 = value
    End Set
End Property
Dim mCODE6 As String
Public Property _CODE6 As String
    Get
        Return mCODE6
    End Get
    Set(ByVal value As String)
        mCODE6 = value
    End Set
End Property
Dim mBILDT As Integer
Public Property _BILDT As Integer
    Get
        Return mBILDT
    End Get
    Set(ByVal value As Integer)
        mBILDT = value
    End Set
End Property
#End Region
End Class

