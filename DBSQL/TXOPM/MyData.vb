Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXOPM"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _RECTYP = String.Empty
    _ADDR1 = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP = 0
    _ZIP4 = 0
    _PHONE = 0
    _PHONEX = 0
    _FAX = 0
    _EMAIL = String.Empty
    _CERT = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Wrkrectyp As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where rectyp = " & "'" & Wrkrectyp & "'"
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
  Public Function PosData(ByVal Wrkrectyp As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where rectyp >= " & "'" & Wrkrectyp & "'" & " Order by rectyp"
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
      _RECTYP = .Item("RECTYP")
      _ADDR1 = .Item("ADDR1")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP = .Item("ZIP")
      _ZIP4 = .Item("ZIP4")
      _PHONE = .Item("PHONE")
      _PHONEX = .Item("PHONEX")
      _FAX = .Item("FAX")
      _EMAIL = .Item("EMAIL")
      _CERT = .Item("CERT")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RECTYP") = _RECTYP
      .Item("ADDR1") = _ADDR1
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP") = _ZIP
      .Item("ZIP4") = _ZIP4
      .Item("PHONE") = _PHONE
      .Item("PHONEX") = _PHONEX
      .Item("FAX") = _FAX
      .Item("EMAIL") = _EMAIL
      .Item("CERT") = _CERT

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mRECTYP As String
  Public Property _RECTYP As String
    Get
      Return mRECTYP
    End Get
    Set(ByVal value As String)
      mRECTYP = value
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

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP As Integer
  Public Property _ZIP As Integer
    Get
      Return mZIP
    End Get
    Set(ByVal value As Integer)
      mZIP = value
    End Set
  End Property

  Dim mZIP4 As Integer
  Public Property _ZIP4 As Integer
    Get
      Return mZIP4
    End Get
    Set(ByVal value As Integer)
      mZIP4 = value
    End Set
  End Property

  Dim mPHONE As Long
  Public Property _PHONE As Long
    Get
      Return mPHONE
    End Get
    Set(ByVal value As Long)
      mPHONE = value
    End Set
  End Property

  Dim mPHONEX As Integer
  Public Property _PHONEX As Integer
    Get
      Return mPHONEX
    End Get
    Set(ByVal value As Integer)
      mPHONEX = value
    End Set
  End Property

  Dim mFAX As Long
  Public Property _FAX As Long
    Get
      Return mFAX
    End Get
    Set(ByVal value As Long)
      mFAX = value
    End Set
  End Property

  Dim mEMAIL As String
  Public Property _EMAIL As String
    Get
      Return mEMAIL
    End Get
    Set(ByVal value As String)
      mEMAIL = value
    End Set
  End Property

  Dim mCERT As String
  Public Property _CERT As String
    Get
      Return mCERT
    End Get
    Set(ByVal value As String)
      mCERT = value
    End Set
  End Property

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
#End Region
End Class


