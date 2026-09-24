Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "BDCNTL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _RECID = String.Empty
    _NAME = String.Empty
    _ADDR1 = String.Empty
    _ADDR2 = String.Empty
    _PHONE = String.Empty
    _FAX = String.Empty
    _LPERM = 0
    _NECYR = 0
    _IRCYR = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkRecid As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where recid='" & WrkRecid & "'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
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
  Public Function PosData(ByVal WrkRecid As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where recid>='" & WrkRecid & "'"
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
      _RECID = .Item("RECID")
      _NAME = .Item("NAME")
      _ADDR1 = .Item("ADDR1")
      _ADDR2 = .Item("ADDR2")
      _PHONE = .Item("PHONE")
      _FAX = .Item("FAX")
      _LPERM = .Item("LPERM")
      _NECYR = .Item("NECYR")
      _IRCYR = .Item("IRCYR")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECID") = _RECID
      .Item("NAME") = _NAME
      .Item("ADDR1") = _ADDR1
      .Item("ADDR2") = _ADDR2
      .Item("PHONE") = _PHONE
      .Item("FAX") = _FAX
      .Item("LPERM") = _LPERM
      .Item("NECYR") = _NECYR
      .Item("IRCYR") = _IRCYR
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
  Dim mRECID As String
  Public Property _RECID As String
    Get
      Return mRECID
    End Get
    Set(ByVal value As String)
      mRECID = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mADDR1 As String
  Public Property _ADDR1 As String
    Get
      Return mADDR1
    End Get
    Set(ByVal value As String)
      mADDR1 = value
    End Set
  End Property

  Dim mADDR2 As String
  Public Property _ADDR2 As String
    Get
      Return mADDR2
    End Get
    Set(ByVal value As String)
      mADDR2 = value
    End Set
  End Property

  Dim mPHONE As String
  Public Property _PHONE As String
    Get
      Return mPHONE
    End Get
    Set(ByVal value As String)
      mPHONE = value
    End Set
  End Property

  Dim mFAX As String
  Public Property _FAX As String
    Get
      Return mFAX
    End Get
    Set(ByVal value As String)
      mFAX = value
    End Set
  End Property

  Dim mLPERM As Integer
  Public Property _LPERM As Integer
    Get
      Return mLPERM
    End Get
    Set(ByVal value As Integer)
      mLPERM = value
    End Set
  End Property

  Dim mNECYR As Integer
  Public Property _NECYR As Integer
    Get
      Return mNECYR
    End Get
    Set(ByVal value As Integer)
      mNECYR = value
    End Set
  End Property

  Dim mIRCYR As Integer
  Public Property _IRCYR As Integer
    Get
      Return mIRCYR
    End Get
    Set(ByVal value As Integer)
      mIRCYR = value
    End Set
  End Property
#End Region
End Class

