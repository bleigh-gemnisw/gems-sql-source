Imports System.Data
Imports System.Data.SqlClient
Public Class UTCUSTAS
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFileName As String = "UTCUSTAS"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CAACCT = 0
    _CATYPE = String.Empty
    _CAADJ = 0
    _CADEF = 0
    _CADEP = 0
    _CAAMT = 0
    _CAPNO = 0
    _CAOVR = 0
    _CALAT = 0
    _CAUNIF = 0

  End Sub
  Public Sub GetOneRecordP(ByVal Wrkcaacct As Integer, ByVal Wrkcatype As String)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where caacct = " & Wrkcaacct & " and catype = " & "'" & Wrkcatype & "'"
    Try
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
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function PosData(ByVal Wrkcaacct As Integer, ByVal Wrkcatype As String) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where caacct = " & Wrkcaacct & " And catype >= " & "'" & Wrkcatype & "'" & " Or caacct > " & Wrkcaacct & " Order by caacct, catype"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
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
  Public Sub DeleteListNo(ByVal wrklist As Integer)
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE caacct = " & wrklist

    RecordNotFound = False
    IsEOF = False
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
      _CAACCT = .Item("CAACCT")
      _CATYPE = .Item("CATYPE")
      _CAADJ = .Item("CAADJ")
      _CADEF = .Item("CADEF")
      _CADEP = .Item("CADEP")
      _CAAMT = .Item("CAAMT")
      _CAPNO = .Item("CAPNO")
      _CAOVR = .Item("CAOVR")
      _CALAT = .Item("CALAT")
      _CAUNIF = .Item("CAUNIF")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CAACCT") = _CAACCT
      .Item("CATYPE") = _CATYPE
      .Item("CAADJ") = _CAADJ
      .Item("CADEF") = _CADEF
      .Item("CADEP") = _CADEP
      .Item("CAAMT") = _CAAMT
      .Item("CAPNO") = _CAPNO
      .Item("CAOVR") = _CAOVR
      .Item("CALAT") = _CALAT
      .Item("CAUNIF") = _CAUNIF

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCAACCT As Integer
  Public Property _CAACCT As Integer
    Get
      Return mCAACCT
    End Get
    Set(ByVal value As Integer)
      mCAACCT = value
    End Set
  End Property

  Dim mCATYPE As String
  Public Property _CATYPE As String
    Get
      Return mCATYPE
    End Get
    Set(ByVal value As String)
      mCATYPE = value
    End Set
  End Property

  Dim mCAADJ As Decimal
  Public Property _CAADJ As Decimal
    Get
      Return mCAADJ
    End Get
    Set(ByVal value As Decimal)
      mCAADJ = value
    End Set
  End Property

  Dim mCADEF As Decimal
  Public Property _CADEF As Decimal
    Get
      Return mCADEF
    End Get
    Set(ByVal value As Decimal)
      mCADEF = value
    End Set
  End Property

  Dim mCADEP As Integer
  Public Property _CADEP As Integer
    Get
      Return mCADEP
    End Get
    Set(ByVal value As Integer)
      mCADEP = value
    End Set
  End Property

  Dim mCAAMT As Decimal
  Public Property _CAAMT As Decimal
    Get
      Return mCAAMT
    End Get
    Set(ByVal value As Decimal)
      mCAAMT = value
    End Set
  End Property

  Dim mCAPNO As Integer
  Public Property _CAPNO As Integer
    Get
      Return mCAPNO
    End Get
    Set(ByVal value As Integer)
      mCAPNO = value
    End Set
  End Property

  Dim mCAOVR As Decimal
  Public Property _CAOVR As Decimal
    Get
      Return mCAOVR
    End Get
    Set(ByVal value As Decimal)
      mCAOVR = value
    End Set
  End Property

  Dim mCALAT As Integer
  Public Property _CALAT As Integer
    Get
      Return mCALAT
    End Get
    Set(ByVal value As Integer)
      mCALAT = value
    End Set
  End Property

  Dim mCAUNIF As Integer
  Public Property _CAUNIF As Integer
    Get
      Return mCAUNIF
    End Get
    Set(ByVal value As Integer)
      mCAUNIF = value
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


