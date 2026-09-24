Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TBLCONTROL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _KEYFIELD = String.Empty
    _KEYVALUE = String.Empty
    _USERORSYSTEM = String.Empty
    _FIELD01 = String.Empty
    _FIELD02 = String.Empty
    _FIELD03 = String.Empty
    _FIELD04 = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkkey As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where KEYFIELD = '" & Wrkkey & "'"

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

  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("")
    Return ds
  End Function
  Public Function PosData(ByVal Wrkkey As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where KEYFIELD >= '" & Wrkkey & "' Order by KEYFIELD"
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
      _KEYFIELD = .Item("KEYFIELD")
      _KEYVALUE = .Item("KEYVALUE")
      _USERORSYSTEM = .Item("USERORSYSTEM")
      _FIELD01 = .Item("FIELD01")
      _FIELD02 = .Item("FIELD02")
      _FIELD03 = .Item("FIELD03")
      _FIELD04 = .Item("FIELD04")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("KEYFIELD") = _KEYFIELD
      .Item("KEYVALUE") = _KEYVALUE
      .Item("USERORSYSTEM") = _USERORSYSTEM
      .Item("FIELD01") = _FIELD01
      .Item("FIELD02") = _FIELD02
      .Item("FIELD03") = _FIELD03
      .Item("FIELD04") = _FIELD04
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mKEYFIELD As String
  Public Property _KEYFIELD As String
    Get
      Return mKEYFIELD
    End Get
    Set(ByVal value As String)
      mKEYFIELD = value
    End Set
  End Property

  Dim mKEYVALUE As String
  Public Property _KEYVALUE As String
    Get
      Return mKEYVALUE
    End Get
    Set(ByVal value As String)
      mKEYVALUE = value
    End Set
  End Property
  Dim mUSERORSYSTEM As String
  Public Property _USERORSYSTEM As String
    Get
      Return mUSERORSYSTEM
    End Get
    Set(ByVal value As String)
      mUSERORSYSTEM = value
    End Set
  End Property
  Dim m_FIELD01 As String
  Public Property _FIELD01 As String
    Get
      Return m_FIELD01
    End Get
    Set(ByVal value As String)
      m_FIELD01 = value
    End Set
  End Property
  Dim m_FIELD02 As String
  Public Property _FIELD02 As String
    Get
      Return m_FIELD02
    End Get
    Set(ByVal value As String)
      m_FIELD02 = value
    End Set
  End Property
  Dim m_FIELD03 As String
  Public Property _FIELD03 As Integer
    Get
      Return m_FIELD03
    End Get
    Set(ByVal value As Integer)
      m_FIELD03 = value
    End Set
  End Property
  Dim m_FIELD04 As String
  Public Property _FIELD04 As Decimal
    Get
      Return m_FIELD04
    End Get
    Set(ByVal value As Decimal)
      m_FIELD04 = value
    End Set
  End Property


  Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


