Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "UTMUSER"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _USER1 = String.Empty
    _USER2 = String.Empty
    _USER3 = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal WrkRecno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & cFileName
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
  Public Sub AddOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Const caa As String = "','" 'Alpha Before/Alpha After
    'Const can As String = "'," 'Alpha Before/Numeric After
    'Const cna As String = ",'" 'Numeric Before/Alpha After
    'Const cnn As String = "," 'Numeric Before/Numeric After

    StrSQL = "Insert into " & cFileName & "(USER1,USER2,USER3)" &
   " values('" & _USER1 & caa & _USER2 & caa & _USER3 & "')"
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
  Public Sub DeleteOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Update " & cFileName & " set USER1='" & _USER1 & "',USER2='" & _USER2 & "',USER3='" & _USER3 & "'"

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _USER1 = .Item("USER1")
      _USER2 = .Item("USER2")
      _USER3 = .Item("USER3")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("USER1") = _USER1
      .Item("USER2") = _USER2
      .Item("USER3") = _USER3
    End With
  End Sub
#End Region

#Region "Properties: Fields"
  Dim mUSER1 As String
  Public Property _USER1 As String
    Get
      Return mUSER1
    End Get
    Set(ByVal value As String)
      mUSER1 = value
    End Set
  End Property
  Dim mUSER2 As String
  Public Property _USER2 As String
    Get
      Return mUSER2
    End Get
    Set(ByVal value As String)
      mUSER2 = value
    End Set
  End Property
  Dim mUSER3 As String
  Public Property _USER3 As String
    Get
      Return mUSER3
    End Get
    Set(ByVal value As String)
      mUSER3 = value
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



