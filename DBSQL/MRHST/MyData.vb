Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "MRHST"
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
  Public Sub InsertOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    'Const caa As String = "','" 'Alpha Before/Alpha After
    Const can As String = "'," 'Alpha Before/Numeric After
    Const cna As String = ",'" 'Numeric Before/Alpha After
    Const cnn As String = "," 'Numeric Before/Numeric After

    StrSQL = "Insert into " & cFileName & "(STATUS,BCHNO,DESCR,RECDT," &
      "STRDT,ENDDT,CODE,CASH,CHECK,CREDIT,TOTAL,PRF,CHDATE,CHTIME)" &
      " values('" & _STATUS & can & _BCHNO & cna & _DESCR & can & _RECDT & cnn & _STRDT & cnn &
      _ENDDT & cna & _CODE & can & _CASH & cnn & _CHECK & cnn & _CREDIT & cnn & _TOTAL & cna & _PRF & can &
      _CHDATE & cnn & _CHTIME & ")"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
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
      _STATUS = .Item("STATUS")
      _BCHNO = .Item("BCHNO")
      _DESCR = .Item("DESCR")
      _RECDT = .Item("RECDT")
      _STRDT = .Item("STRDT")
      _ENDDT = .Item("ENDDT")
      _CODE = .Item("CODE")
      _CASH = .Item("CASH")
      _CHECK = .Item("CHECK")
      _CREDIT = .Item("CREDIT")
      _TOTAL = .Item("TOTAL")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("STATUS") = _STATUS
      .Item("BCHNO") = _BCHNO
      .Item("DESCR") = _DESCR
      .Item("RECDT") = _RECDT
      .Item("STRDT") = _STRDT
      .Item("ENDDT") = _ENDDT
      .Item("CODE") = _CODE
      .Item("CASH") = _CASH
      .Item("CHECK") = _CHECK
      .Item("CREDIT") = _CREDIT
      .Item("TOTAL") = _TOTAL
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME
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
Dim mSTATUS As String
Public Property _STATUS As String
    Get
        Return mSTATUS
    End Get
    Set(ByVal value As String)
        mSTATUS = value
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
Dim mPRF As String
Public Property _PRF As String
    Get
        Return mPRF
    End Get
    Set(ByVal value As String)
        mPRF = value
    End Set
End Property
Dim mCHDATE As Integer
Public Property _CHDATE As Integer
    Get
        Return mCHDATE
    End Get
    Set(ByVal value As Integer)
        mCHDATE = value
    End Set
End Property
Dim mCHTIME As Integer
Public Property _CHTIME As Integer
    Get
        Return mCHTIME
    End Get
    Set(ByVal value As Integer)
        mCHTIME = value
    End Set
End Property
#End Region
End Class

