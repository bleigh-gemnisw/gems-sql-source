Imports System.Data
Imports System.Data.SqlClient
Public Class TXDCDEP
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
    _DECODE = String.Empty
    _YEARNO = 0
    _PROPCT = 0
    _PCT = 0
    _PRIOR = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Wrkyear As Integer, ByVal Wrkdecode As String, ByVal Wrkyearno As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where year = " & Wrkyear & " and decode = '" & Wrkdecode & "' and yearno = " & Wrkyearno
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
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function PosData(ByVal Wrkyear As Integer, ByVal Wrkdecode As String, ByVal Wrkyearno As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where year = " & Wrkyear & " And yearno = " & Wrkyearno _
    & " And decode >= '" & Wrkdecode & "' Or year = " & Wrkyear & " And yearno > " & Wrkyearno & " Or year > " & Wrkyear & " Order by year, decode, yearno"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, MyFileName)
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
      _DECODE = .Item("DECODE")
      _YEARNO = .Item("YEARNO")
      _PROPCT = .Item("PROPCT")
      _PCT = .Item("PCT")
      _PRIOR = .Item("PRIOR")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("YEAR") = _YEAR
      .Item("DECODE") = _DECODE
      .Item("YEARNO") = _YEARNO
      .Item("PROPCT") = _PROPCT
      .Item("PCT") = _PCT
      .Item("PRIOR") = _PRIOR

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

  Dim mDECODE As String
  Public Property _DECODE As String
    Get
      Return mDECODE
    End Get
    Set(ByVal value As String)
      mDECODE = value
    End Set
  End Property

  Dim mYEARNO As Integer
  Public Property _YEARNO As Integer
    Get
      Return mYEARNO
    End Get
    Set(ByVal value As Integer)
      mYEARNO = value
    End Set
  End Property

  Dim mPROPCT As Integer
  Public Property _PROPCT As Integer
    Get
      Return mPROPCT
    End Get
    Set(ByVal value As Integer)
      mPROPCT = value
    End Set
  End Property

  Dim mPCT As Integer
  Public Property _PCT As Integer
    Get
      Return mPCT
    End Get
    Set(ByVal value As Integer)
      mPCT = value
    End Set
  End Property

  Dim mPRIOR As String
  Public Property _PRIOR As String
    Get
      Return mPRIOR
    End Get
    Set(ByVal value As String)
      mPRIOR = value
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


