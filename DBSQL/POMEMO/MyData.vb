Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "POMEMO"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function AutoGenKey(ByVal WrkFdnbr As Integer, ByVal WrkSfund As Integer) As Integer
  Dim NextKey As Integer
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where fdnbr=" & WrkFdnbr & _
   "and sfund=" & WrkSfund & " order by lne desc"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      NextKey = 1
    Else
      NextKey = ds.Tables(0).Rows(0).Item("lne") + 1
    End If
    objCommand = Nothing
    ds.Clear()
    ds = Nothing
    Conn.Close()
  Catch ex As Exception
    ErrMsg = ex.ToString()
  End Try
  Return NextKey
End Function
Public Sub GetOneRecordP(ByVal Fdnbr As Integer, ByVal Sfund As Integer, Lne As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund & _
   " and LNE=" & Lne
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
Public Function PosData(ByVal Fdnbr As Integer, ByVal Sfund As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select fdnbr,sfund,lne,text01 from " & cFileName & " where FDNBR>=" & Fdnbr & " order by fdnbr, sfund, lne"
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
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _LNE = .Item("LNE")
    _TEXT01 = .Item("TEXT01")
    _TEXT02 = .Item("TEXT02")
    _TEXT03 = .Item("TEXT03")
    _TEXT04 = .Item("TEXT04")
    _TEXT05 = .Item("TEXT05")
    _TEXT06 = .Item("TEXT06")
    _TEXT07 = .Item("TEXT07")
    _TEXT08 = .Item("TEXT08")
    _TEXT09 = .Item("TEXT09")
    _TEXT10 = .Item("TEXT10")
    _TEXT11 = .Item("TEXT11")
    _TEXT12 = .Item("TEXT12")
    _TEXT13 = .Item("TEXT13")
    _TEXT14 = .Item("TEXT14")
    _TEXT15 = .Item("TEXT15")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("LNE") = _LNE
    .Item("TEXT01") = _TEXT01
    .Item("TEXT02") = _TEXT02
    .Item("TEXT03") = _TEXT03
    .Item("TEXT04") = _TEXT04
    .Item("TEXT05") = _TEXT05
    .Item("TEXT06") = _TEXT06
    .Item("TEXT07") = _TEXT07
    .Item("TEXT08") = _TEXT08
    .Item("TEXT09") = _TEXT09
    .Item("TEXT10") = _TEXT10
    .Item("TEXT11") = _TEXT11
    .Item("TEXT12") = _TEXT12
    .Item("TEXT13") = _TEXT13
    .Item("TEXT14") = _TEXT14
    .Item("TEXT15") = _TEXT15
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
Dim mFDNBR As Integer
Public Property _FDNBR As Integer
    Get
        Return mFDNBR
    End Get
    Set(ByVal value As Integer)
        mFDNBR = value
    End Set
End Property
Dim mSFUND As Integer
Public Property _SFUND As Integer
    Get
        Return mSFUND
    End Get
    Set(ByVal value As Integer)
        mSFUND = value
    End Set
End Property
Dim mLNE As Integer
Public Property _LNE As Integer
    Get
        Return mLNE
    End Get
    Set(ByVal value As Integer)
        mLNE = value
    End Set
End Property
Dim mTEXT01 As String
Public Property _TEXT01 As String
    Get
        Return mTEXT01
    End Get
    Set(ByVal value As String)
        mTEXT01 = value
    End Set
End Property
Dim mTEXT02 As String
Public Property _TEXT02 As String
    Get
        Return mTEXT02
    End Get
    Set(ByVal value As String)
        mTEXT02 = value
    End Set
End Property
Dim mTEXT03 As String
Public Property _TEXT03 As String
    Get
        Return mTEXT03
    End Get
    Set(ByVal value As String)
        mTEXT03 = value
    End Set
End Property
Dim mTEXT04 As String
Public Property _TEXT04 As String
    Get
        Return mTEXT04
    End Get
    Set(ByVal value As String)
        mTEXT04 = value
    End Set
End Property
Dim mTEXT05 As String
Public Property _TEXT05 As String
    Get
        Return mTEXT05
    End Get
    Set(ByVal value As String)
        mTEXT05 = value
    End Set
End Property
Dim mTEXT06 As String
Public Property _TEXT06 As String
    Get
        Return mTEXT06
    End Get
    Set(ByVal value As String)
        mTEXT06 = value
    End Set
End Property
Dim mTEXT07 As String
Public Property _TEXT07 As String
    Get
        Return mTEXT07
    End Get
    Set(ByVal value As String)
        mTEXT07 = value
    End Set
End Property
Dim mTEXT08 As String
Public Property _TEXT08 As String
    Get
        Return mTEXT08
    End Get
    Set(ByVal value As String)
        mTEXT08 = value
    End Set
End Property
Dim mTEXT09 As String
Public Property _TEXT09 As String
    Get
        Return mTEXT09
    End Get
    Set(ByVal value As String)
        mTEXT09 = value
    End Set
End Property
Dim mTEXT10 As String
Public Property _TEXT10 As String
    Get
        Return mTEXT10
    End Get
    Set(ByVal value As String)
        mTEXT10 = value
    End Set
End Property
Dim mTEXT11 As String
Public Property _TEXT11 As String
    Get
        Return mTEXT11
    End Get
    Set(ByVal value As String)
        mTEXT11 = value
    End Set
End Property
Dim mTEXT12 As String
Public Property _TEXT12 As String
    Get
        Return mTEXT12
    End Get
    Set(ByVal value As String)
        mTEXT12 = value
    End Set
End Property
Dim mTEXT13 As String
Public Property _TEXT13 As String
    Get
        Return mTEXT13
    End Get
    Set(ByVal value As String)
        mTEXT13 = value
    End Set
End Property
Dim mTEXT14 As String
Public Property _TEXT14 As String
    Get
        Return mTEXT14
    End Get
    Set(ByVal value As String)
        mTEXT14 = value
    End Set
End Property
Dim mTEXT15 As String
Public Property _TEXT15 As String
    Get
        Return mTEXT15
    End Get
    Set(ByVal value As String)
        mTEXT15 = value
    End Set
End Property
#End Region
End Class

