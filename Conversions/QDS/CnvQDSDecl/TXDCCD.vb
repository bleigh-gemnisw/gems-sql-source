Imports System.Data
Imports System.Data.SqlClient
Public Class TXDCCD
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
    _YEAR = 0
    _CODE = 0
    _LTR = String.Empty
    _DESC = String.Empty
    _DECODE = String.Empty
    _ASCODE = 0
    _ASPCT = 0

  End Sub
  Public Sub GetOneRecordP(ByVal Wrkyear As Integer, ByVal Wrkcode As Integer, ByVal Wrkltr As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where year = " & Wrkyear & " and code = " & Wrkcode & " and ltr = " & "'" & Wrkltr & "'"
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
  Public Function PosData(ByVal Wrkyear As Integer, ByVal Wrkcode As Integer, ByVal Wrkltr As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where year = " & Wrkyear & " And code = " & Wrkcode & " And ltr >= " & "'" & Wrkltr & "'" & " Or year = " & Wrkyear & " And code > " & Wrkcode & " Or year > " & Wrkyear & " Order by year, code, ltr"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, MyFileName)
    objCommand = Nothing
    Return ds
  End Function

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
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _YEAR = .Item("YEAR")
      _CODE = .Item("CODE")
      _LTR = .Item("LTR")
      _DESC = .Item("DESC")
      _DECODE = .Item("DECODE")
      _ASCODE = .Item("ASCODE")
      _ASPCT = .Item("ASPCT")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("YEAR") = _YEAR
      .Item("CODE") = _CODE
      .Item("LTR") = _LTR
      .Item("DESC") = _DESC
      .Item("DECODE") = _DECODE
      .Item("ASCODE") = _ASCODE
      .Item("ASPCT") = _ASPCT

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property

  Dim mCODE As Integer
  Public Property _CODE As Integer
    Get
      Return mCODE
    End Get
    Set(ByVal value As Integer)
      mCODE = value
    End Set
  End Property

  Dim mLTR As String
  Public Property _LTR As String
    Get
      Return mLTR
    End Get
    Set(ByVal value As String)
      mLTR = value
    End Set
  End Property

  Dim mDESC As String
  Public Property _DESC As String
    Get
      Return mDESC
    End Get
    Set(ByVal value As String)
      mDESC = value
    End Set
  End Property

  Dim mDECODE As String
  Public Property _DECODE As String
    Get
      Return mDECODE
    End Get
    Set(ByVal value As String)
      mDECODE = value
    End Set
  End Property

  Dim mASCODE As Integer
  Public Property _ASCODE As Integer
    Get
      Return mASCODE
    End Get
    Set(ByVal value As Integer)
      mASCODE = value
    End Set
  End Property

  Dim mASPCT As Integer
  Public Property _ASPCT As Integer
    Get
      Return mASPCT
    End Get
    Set(ByVal value As Integer)
      mASPCT = value
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


