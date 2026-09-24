Imports System.Data
Imports System.Data.SqlClient
Public Class TOWN
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFilename As String = "TOWN"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal RecNum As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFilename
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFilename)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
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
  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, cFilename)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, cFilename)
    PutFields(ds)
    da.Update(ds, cFilename)
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
      _TOWN = .Item("TOWN")
      _ADDR1 = .Item("ADDR1")
      _ADDR2 = .Item("ADDR2")
      _CITY = .Item("CITY")
      _ZIP = .Item("ZIP")
      _ASSR = .Item("ASSR")
      _PHONE = .Item("PHONE")
      _COLCTR = .Item("COLCTR")
      _CLERK = .Item("CLERK")
      _COUNTY = .Item("COUNTY")
      _CEREC = .Item("CEREC")
      _RECCOD = .Item("RECCOD")
      _TOWNBR = .Item("TOWNBR")
    End With
  End Sub

  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TOWN") = _TOWN
      .Item("ADDR1") = _ADDR1
      .Item("ADDR2") = _ADDR2
      .Item("CITY") = _CITY
      .Item("ZIP") = _ZIP
      .Item("ASSR") = _ASSR
      .Item("PHONE") = _PHONE
      .Item("COLCTR") = _COLCTR
      .Item("CLERK") = _CLERK
      .Item("COUNTY") = _COUNTY
      .Item("CEREC") = _CEREC
      .Item("RECCOD") = _RECCOD
      .Item("TOWNBR") = _TOWNBR
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
  Dim mTOWN As String
  Public Property _TOWN() As String
    Get
      Return mTOWN
    End Get
    Set(ByVal value As String)
      mTOWN = value
    End Set
  End Property
  Dim mADDR1 As String
  Public Property _ADDR1() As String
    Get
      Return mADDR1
    End Get
    Set(ByVal value As String)
      mADDR1 = value
    End Set
  End Property
  Dim mADDR2 As String
  Public Property _ADDR2() As String
    Get
      Return mADDR2
    End Get
    Set(ByVal value As String)
      mADDR2 = value
    End Set
  End Property
  Dim mCITY As String
  Public Property _CITY() As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property
  Dim mZIP As String
  Public Property _ZIP() As String
    Get
      Return mZIP
    End Get
    Set(ByVal value As String)
      mZIP = value
    End Set
  End Property
  Dim mASSR As String
  Public Property _ASSR() As String
    Get
      Return mASSR
    End Get
    Set(ByVal value As String)
      mASSR = value
    End Set
  End Property
  Dim mPHONE As String
  Public Property _PHONE() As String
    Get
      Return mPHONE
    End Get
    Set(ByVal value As String)
      mPHONE = value
    End Set
  End Property
  Dim mCOLCTR As String
  Public Property _COLCTR() As String
    Get
      Return mCOLCTR
    End Get
    Set(ByVal value As String)
      mCOLCTR = value
    End Set
  End Property
  Dim mCLERK As String
  Public Property _CLERK() As String
    Get
      Return mCLERK
    End Get
    Set(ByVal value As String)
      mCLERK = value
    End Set
  End Property
  Dim mCOUNTY As String
  Public Property _COUNTY() As String
    Get
      Return mCOUNTY
    End Get
    Set(ByVal value As String)
      mCOUNTY = value
    End Set
  End Property
  Dim mCEREC As String
  Public Property _CEREC() As String
    Get
      Return mCEREC
    End Get
    Set(ByVal value As String)
      mCEREC = value
    End Set
  End Property
  Dim mRECCOD As String
  Public Property _RECCOD() As String
    Get
      Return mRECCOD
    End Get
    Set(ByVal value As String)
      mRECCOD = value
    End Set
  End Property
  Dim mTOWNBR As Integer
  Public Property _TOWNBR() As Integer
    Get
      Return mTOWNBR
    End Get
    Set(ByVal value As Integer)
      mTOWNBR = value
    End Set
  End Property
#End Region
End Class
