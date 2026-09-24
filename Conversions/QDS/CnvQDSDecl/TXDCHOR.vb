Imports System.Data
Imports System.Data.SqlClient
Public Class TXDCHOR
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Dim MyFileName As String
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection, ByVal WrkFileName As String)
    Conn = WrkConn
    MyFileName = WrkFileName
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _YEAR = 0
    _SEQNO = 0
    _BREED = String.Empty
    _REG = String.Empty
    _AGE = 0
    _SEX = String.Empty
    _QUALCD = String.Empty
    _VALUE = 0

  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seqno = " & Wrkseqno
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seqno >= " & Wrkseqno & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seqno"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, MyFileName)
    objCommand = Nothing
    Return ds
  End Function
  Public Function AutoGenKey(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As Integer
    Dim NextKey As Integer
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & MyFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " order by seqno desc"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        NextKey = 1
      Else
        NextKey = ds.Tables(0).Rows(0).Item("seqno") + 1
      End If

      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
    Return NextKey
  End Function
  Public Function GetByList(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select  * FROM " & MyFileName _
    & " where list# =" & Wrklistno & " AND YEAR = " & wrkyear & " order by list#"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      objCommand = Nothing
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Sub DeleteListNo(ByVal wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & MyFileName & " WHERE list# = " & wrklistno & " And year = " & Wrkyear

    RecordNotFound = False
    IsEOF = False
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    PutFields(ds)
    da.Update(ds, MyFileName)
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
      _BREED = .Item("BREED")
      _REG = .Item("REG")
      _AGE = .Item("AGE")
      _SEX = .Item("SEX")
      _QUALCD = .Item("QUALCD")
      _VALUE = .Item("VALUE")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("SEQNO") = _SEQNO
      .Item("BREED") = _BREED
      .Item("REG") = _REG
      .Item("AGE") = _AGE
      .Item("SEX") = _SEX
      .Item("QUALCD") = _QUALCD
      .Item("VALUE") = _VALUE

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

  Dim mBREED As String
  Public Property _BREED As String
    Get
      Return mBREED
    End Get
    Set(ByVal value As String)
      mBREED = value
    End Set
  End Property

  Dim mREG As String
  Public Property _REG As String
    Get
      Return mREG
    End Get
    Set(ByVal value As String)
      mREG = value
    End Set
  End Property

  Dim mAGE As Integer
  Public Property _AGE As Integer
    Get
      Return mAGE
    End Get
    Set(ByVal value As Integer)
      mAGE = value
    End Set
  End Property

  Dim mSEX As String
  Public Property _SEX As String
    Get
      Return mSEX
    End Get
    Set(ByVal value As String)
      mSEX = value
    End Set
  End Property

  Dim mQUALCD As String
  Public Property _QUALCD As String
    Get
      Return mQUALCD
    End Get
    Set(ByVal value As String)
      mQUALCD = value
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


