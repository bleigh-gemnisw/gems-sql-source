Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "BCHHDR"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function AutoGenKey(ByVal WrkAppID As String) As Integer
  Dim NextKey As Integer
    GetOneRecordP(WrkAppID, 0)
    If RecordNotFound Then
      NextKey = 1
    Else
      NextKey = _LSBCH + 1
      If NextKey > 999 Then
        NextKey = 1
      End If
    End If

	CloseFile()
  Return NextKey
End Function
Public Sub GetOneRecordP(ByVal WrkAppID As String, ByVal WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where appid='" & WrkAppID & "' and bchno=" & WrkBchno

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
  Public Sub DeleteBatch(ByVal WrkBchno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

  RecordNotFound = False
  IsEOF = False
  StrSQL = "Delete from " & cFileName & " where bchno=" & WrkBchno
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
    _APPID = .Item("APPID")
    _BCHNO = .Item("BCHNO")
    _STATS = .Item("STATS")
    _SUBST = .Item("SUBST")
    _ORGUS = .Item("ORGUS")
    _LSTUS = .Item("LSTUS")
    _LSTDV = .Item("LSTDV")
    _STRDT = .Item("STRDT")
    _ENDDT = .Item("ENDDT")
    _NBRRC = .Item("NBRRC")
    _NBRER = .Item("NBRER")
    _HEADG = .Item("HEADG")
    _ENTPM = .Item("ENTPM")
    _EDTPM = .Item("EDTPM")
    _PSTPM = .Item("PSTPM")
    _LSBCH = .Item("LSBCH")
    _FREEA = .Item("FREEA")
    _PSDT = .Item("PSDT")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("APPID") = _APPID
    .Item("BCHNO") = _BCHNO
    .Item("STATS") = _STATS
    .Item("SUBST") = _SUBST
    .Item("ORGUS") = _ORGUS
    .Item("LSTUS") = _LSTUS
    .Item("LSTDV") = _LSTDV
    .Item("STRDT") = _STRDT
    .Item("ENDDT") = _ENDDT
    .Item("NBRRC") = _NBRRC
    .Item("NBRER") = _NBRER
    .Item("HEADG") = _HEADG
    .Item("ENTPM") = _ENTPM
    .Item("EDTPM") = _EDTPM
    .Item("PSTPM") = _PSTPM
    .Item("LSBCH") = _LSBCH
    .Item("FREEA") = _FREEA
    .Item("PSDT") = _PSDT
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
Dim mAPPID As String
Public Property _APPID As String
    Get
        Return mAPPID
    End Get
    Set(ByVal value As String)
        mAPPID = value
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
Dim mSTATS As String
Public Property _STATS As String
    Get
        Return mSTATS
    End Get
    Set(ByVal value As String)
        mSTATS = value
    End Set
End Property
Dim mSUBST As String
Public Property _SUBST As String
    Get
        Return mSUBST
    End Get
    Set(ByVal value As String)
        mSUBST = value
    End Set
End Property
Dim mORGUS As String
Public Property _ORGUS As String
    Get
        Return mORGUS
    End Get
    Set(ByVal value As String)
        mORGUS = value
    End Set
End Property
Dim mLSTUS As String
Public Property _LSTUS As String
    Get
        Return mLSTUS
    End Get
    Set(ByVal value As String)
        mLSTUS = value
    End Set
End Property
Dim mLSTDV As String
Public Property _LSTDV As String
    Get
        Return mLSTDV
    End Get
    Set(ByVal value As String)
        mLSTDV = value
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
Dim mNBRRC As Integer
Public Property _NBRRC As Integer
    Get
        Return mNBRRC
    End Get
    Set(ByVal value As Integer)
        mNBRRC = value
    End Set
End Property
Dim mNBRER As Integer
Public Property _NBRER As Integer
    Get
        Return mNBRER
    End Get
    Set(ByVal value As Integer)
        mNBRER = value
    End Set
End Property
Dim mHEADG As String
Public Property _HEADG As String
    Get
        Return mHEADG
    End Get
    Set(ByVal value As String)
        mHEADG = value
    End Set
End Property
Dim mENTPM As String
Public Property _ENTPM As String
    Get
        Return mENTPM
    End Get
    Set(ByVal value As String)
        mENTPM = value
    End Set
End Property
Dim mEDTPM As String
Public Property _EDTPM As String
    Get
        Return mEDTPM
    End Get
    Set(ByVal value As String)
        mEDTPM = value
    End Set
End Property
Dim mPSTPM As String
Public Property _PSTPM As String
    Get
        Return mPSTPM
    End Get
    Set(ByVal value As String)
        mPSTPM = value
    End Set
End Property
Dim mLSBCH As Integer
Public Property _LSBCH As Integer
    Get
        Return mLSBCH
    End Get
    Set(ByVal value As Integer)
        mLSBCH = value
    End Set
End Property
Dim mFREEA As String
Public Property _FREEA As String
    Get
        Return mFREEA
    End Get
    Set(ByVal value As String)
        mFREEA = value
    End Set
End Property
Dim mPSDT As Integer
Public Property _PSDT As Integer
    Get
        Return mPSDT
    End Get
    Set(ByVal value As Integer)
        mPSDT = value
    End Set
End Property

#End Region
End Class

