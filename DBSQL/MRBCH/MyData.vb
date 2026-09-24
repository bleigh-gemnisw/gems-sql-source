Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "MRBCH"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where bchno=" & WrkBchno 
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
Public Function PosData(ByVal WrkBchno As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where bchno>=" & WrkBchno & " order by bchno"
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
  Public Sub DeleteRange(ByVal WrkGroup As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where grpid='" & WrkGroup & "'"
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
      _BCHNO = .Item("BCHNO")
      _STATUS = .Item("STATUS")
      _DESCR = .Item("DESCR")
      _RECDT = .Item("RECDT")
      _STRDT = .Item("STRDT")
      _ENDDT = .Item("ENDDT")
      _PRF = .Item("PRF")
      _TCASH = .Item("TCASH")
      _TCHECK = .Item("TCHECK")
      _TCREDIT = .Item("TCREDIT")
      _TAMT = .Item("TAMT")
      _CODES = .Item("CODES")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("BCHNO") = _BCHNO
      .Item("STATUS") = _STATUS
      .Item("DESCR") = _DESCR
      .Item("RECDT") = _RECDT
      .Item("STRDT") = _STRDT
      .Item("ENDDT") = _ENDDT
      .Item("PRF") = _PRF
      .Item("TCASH") = _TCASH
      .Item("TCHECK") = _TCHECK
      .Item("TCREDIT") = _TCREDIT
      .Item("TAMT") = _TAMT
      .Item("CODES") = _CODES
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
Dim mSTATUS As String
Public Property _STATUS As String
    Get
        Return mSTATUS
    End Get
    Set(ByVal value As String)
        mSTATUS = value
    End Set
End Property
Dim mDESCR As String
Public Property _DESCR As String
    Get
        Return mDESCR
    End Get
    Set(ByVal value As String)
        mDESCR = value
    End Set
End Property
Dim mRECDT As Integer
Public Property _RECDT As Integer
    Get
        Return mRECDT
    End Get
    Set(ByVal value As Integer)
        mRECDT = value
    End Set
End Property
Dim mSTRDT As Integer
Public Property _STRDT As Integer
    Get
        Return mSTRDT
    End Get
    Set(ByVal value As Integer)
        mSTRDT = value
    End Set
End Property
Dim mENDDT As Integer
Public Property _ENDDT As Integer
    Get
        Return mENDDT
    End Get
    Set(ByVal value As Integer)
        mENDDT = value
    End Set
End Property
Dim mPRF As String
Public Property _PRF As String
    Get
        Return mPRF
    End Get
    Set(ByVal value As String)
        mPRF = value
    End Set
End Property
Dim mTCASH As Decimal
Public Property _TCASH As Decimal
    Get
        Return mTCASH
    End Get
    Set(ByVal value As Decimal)
        mTCASH = value
    End Set
End Property
Dim mTCHECK As Decimal
Public Property _TCHECK As Decimal
    Get
        Return mTCHECK
    End Get
    Set(ByVal value As Decimal)
        mTCHECK = value
    End Set
End Property
  Dim mTCREDIT As Decimal
  Public Property _TCREDIT As Decimal
    Get
      Return mTCREDIT
    End Get
    Set(ByVal value As Decimal)
      mTCREDIT = value
    End Set
  End Property
  Dim mTAMT As Decimal
  Public Property _TAMT As Decimal
    Get
        Return mTAMT
    End Get
    Set(ByVal value As Decimal)
        mTAMT = value
    End Set
End Property
  Dim mCODES As String
  Public Property _CODES As String
    Get
      Return mCODES
    End Get
    Set(ByVal value As String)
      mCODES = value
    End Set
  End Property
#End Region
End Class

