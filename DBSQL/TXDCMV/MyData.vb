Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCMV"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _YEAR = 0
    _SEQNO = 0
    _MAKE = String.Empty
    _VYEAR = 0
    _MODEL = String.Empty
    _VINNO = String.Empty
    _LENGTH = 0
    _WEIGHT = 0
    _PURVL = 0
    _PURDT = 0
    _VALUE = 0
    _MSRP = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seqno = " & Wrkseqno
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seqno >= " & Wrkseqno & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seqno"
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
  Public Function AutoGenKey(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " order by seqno desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("seqno") + 1
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
  Public Sub DeleteListNo(ByVal wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE list# = " & wrklistno & " And year = " & Wrkyear

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Function GetByList(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet


    RecordNotFound = False

    StrSQL = "Select  * FROM " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR = " & wrkyear & " order by list#"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetByYear(wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet


    RecordNotFound = False

    StrSQL = "Select  * FROM " & cFileName & " where YEAR = " & wrkyear & " order by list#,seqno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
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
      _YEAR = .Item("YEAR")
      _SEQNO = .Item("SEQNO")
      _VYEAR = .Item("VYEAR")
      _MAKE = .Item("MAKE")
      _MODEL = .Item("MODEL")
      _VINNO = .Item("VINNO")
      _LENGTH = .Item("LENGTH")
      _WEIGHT = .Item("WEIGHT")
      _PURVL = .Item("PURVL")
      _PURDT = .Item("PURDT")
      _VALUE = .Item("VALUE")
      _MSRP = .Item("MSRP")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("SEQNO") = _SEQNO
      .Item("VYEAR") = _VYEAR
      .Item("MAKE") = _MAKE
      .Item("MODEL") = _MODEL
      .Item("VINNO") = _VINNO
      .Item("LENGTH") = _LENGTH
      .Item("WEIGHT") = _WEIGHT
      .Item("PURVL") = _PURVL
      .Item("PURDT") = _PURDT
      .Item("VALUE") = _VALUE
      .Item("MSRP") = _MSRP
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
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

  Dim mSEQNO As Integer
  Public Property _SEQNO As Integer
    Get
      Return mSEQNO
    End Get
    Set(ByVal value As Integer)
      mSEQNO = value
    End Set
  End Property

  Dim mMAKE As String
  Public Property _MAKE As String
    Get
      Return mMAKE
    End Get
    Set(ByVal value As String)
      mMAKE = value
    End Set
  End Property

  Dim mVYEAR As Integer
  Public Property _VYEAR As Integer
    Get
      Return mVYEAR
    End Get
    Set(ByVal value As Integer)
      mVYEAR = value
    End Set
  End Property

  Dim mMODEL As String
  Public Property _MODEL As String
    Get
      Return mMODEL
    End Get
    Set(ByVal value As String)
      mMODEL = value
    End Set
  End Property

  Dim mVINNO As String
  Public Property _VINNO As String
    Get
      Return mVINNO
    End Get
    Set(ByVal value As String)
      mVINNO = value
    End Set
  End Property

  Dim mLENGTH As Integer
  Public Property _LENGTH As Integer
    Get
      Return mLENGTH
    End Get
    Set(ByVal value As Integer)
      mLENGTH = value
    End Set
  End Property

  Dim mWEIGHT As Integer
  Public Property _WEIGHT As Integer
    Get
      Return mWEIGHT
    End Get
    Set(ByVal value As Integer)
      mWEIGHT = value
    End Set
  End Property

  Dim mPURVL As Long
  Public Property _PURVL As Long
    Get
      Return mPURVL
    End Get
    Set(ByVal value As Long)
      mPURVL = value
    End Set
  End Property

  Dim mPURDT As Integer
  Public Property _PURDT As Integer
    Get
      Return mPURDT
    End Get
    Set(ByVal value As Integer)
      mPURDT = value
    End Set
  End Property

  Dim mVALUE As Long
  Public Property _VALUE As Long
    Get
      Return mVALUE
    End Get
    Set(ByVal value As Long)
      mVALUE = value
    End Set
  End Property
  Dim mMSRP As Long
  Public Property _MSRP As Long
    Get
      Return mMSRP
    End Get
    Set(ByVal value As Long)
      mMSRP = value
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


