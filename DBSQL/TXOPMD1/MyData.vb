Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXOPMD1"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _TYPE = String.Empty
    _YEAR = 0
    _ALNAME = String.Empty
    _AFNAME = String.Empty
    _AINIT = String.Empty
    _ASSN = 0
    _MADDR = String.Empty
    _MCITY = String.Empty
    _MSTATE = String.Empty
    _MZIP = 0
    _PHONE = 0
    _DTSIGN = 0
    _PROOFE = String.Empty
    _PROOFT = String.Empty
    _PROOFA = String.Empty
    _DTASSR = 0

  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal WrkType As String, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type='" & WrkType & "' and year = " & Wrkyear
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal WrkType As String, ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and type='" & WrkType & "' and year = " & Wrkyear _
      & "or list# = " & Wrklistno & " and type>'" & WrkType & "'" _
      & "or list# > " & Wrklistno & " Order by list#,type,year"
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
      _LISTNO = .Item("LIST#")
      _TYPE = .Item("TYPE")
      _YEAR = .Item("YEAR")
      _ALNAME = .Item("ALNAME")
      _AFNAME = .Item("AFNAME")
      _AINIT = .Item("AINIT")
      _ASSN = .Item("ASSN")
      _MADDR = .Item("MADDR")
      _MCITY = .Item("MCITY")
      _MSTATE = .Item("MSTATE")
      _MZIP = .Item("MZIP")
      _PHONE = .Item("PHONE")
      _ADOB = .Item("ADOB")
      _DTSIGN = .Item("DTSIGN")
      _PROOFE = .Item("PROOFE")
      _PROOFT = .Item("PROOFT")
      _PROOFA = .Item("PROOFA")
      _DTASSR = .Item("DTASSR")

    End With
  End Sub

  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("TYPE") = _TYPE
      .Item("YEAR") = _YEAR
      .Item("ALNAME") = _ALNAME
      .Item("AFNAME") = _AFNAME
      .Item("AINIT") = _AINIT
      .Item("ASSN") = _ASSN

      .Item("MADDR") = _MADDR
      .Item("MCITY") = _MCITY
      .Item("MSTATE") = _MSTATE
      .Item("MZIP") = _MZIP
      .Item("PHONE") = _PHONE
      .Item("ADOB") = _ADOB
      .Item("DTSIGN") = _DTSIGN

      .Item("PROOFE") = _PROOFE
      .Item("PROOFT") = _PROOFT
      .Item("PROOFA") = _PROOFA
      .Item("DTASSR") = _DTASSR
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

  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
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

  Dim mALNAME As String
  Public Property _ALNAME As String
    Get
      Return mALNAME
    End Get
    Set(ByVal value As String)
      mALNAME = value
    End Set
  End Property

  Dim mAFNAME As String
  Public Property _AFNAME As String
    Get
      Return mAFNAME
    End Get
    Set(ByVal value As String)
      mAFNAME = value
    End Set
  End Property

  Dim mAINIT As String
  Public Property _AINIT As String
    Get
      Return mAINIT
    End Get
    Set(ByVal value As String)
      mAINIT = value
    End Set
  End Property

  Dim mASSN As Long
  Public Property _ASSN As Long
    Get
      Return mASSN
    End Get
    Set(ByVal value As Long)
      mASSN = value
    End Set
  End Property



  Dim mMADDR As String
  Public Property _MADDR As String
    Get
      Return mMADDR
    End Get
    Set(ByVal value As String)
      mMADDR = value
    End Set
  End Property

  Dim mMCITY As String
  Public Property _MCITY As String
    Get
      Return mMCITY
    End Get
    Set(ByVal value As String)
      mMCITY = value
    End Set
  End Property

  Dim mMSTATE As String
  Public Property _MSTATE As String
    Get
      Return mMSTATE
    End Get
    Set(ByVal value As String)
      mMSTATE = value
    End Set
  End Property

  Dim mMZIP As Integer
  Public Property _MZIP As Integer
    Get
      Return mMZIP
    End Get
    Set(ByVal value As Integer)
      mMZIP = value
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

  Dim mFILING As String


  Dim mDTSIGN As Integer
  Public Property _DTSIGN As Integer
    Get
      Return mDTSIGN
    End Get
    Set(ByVal value As Integer)
      mDTSIGN = value
    End Set
  End Property
  Dim mADOB As Integer
  Public Property _ADOB As Integer
    Get
      Return mADOB
    End Get
    Set(ByVal value As Integer)
      mADOB = value
    End Set
  End Property


  Dim mPROOFE As String
  Public Property _PROOFE As String
    Get
      Return mPROOFE
    End Get
    Set(ByVal value As String)
      mPROOFE = value
    End Set
  End Property
  Dim mPROOFT As String
  Public Property _PROOFT As String
    Get
      Return mPROOFT
    End Get
    Set(ByVal value As String)
      mPROOFT = value
    End Set
  End Property

  Dim mPROOFA As String
  Public Property _PROOFA As String
    Get
      Return mPROOFA
    End Get
    Set(ByVal value As String)
      mPROOFA = value
    End Set
  End Property

  Dim mDTASSR As Integer
  Public Property _DTASSR As Integer
    Get
      Return mDTASSR
    End Get
    Set(ByVal value As Integer)
      mDTASSR = value
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


