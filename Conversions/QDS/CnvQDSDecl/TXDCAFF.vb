Imports System.Data
Imports System.Data.SqlClient
Public Class TXDCAFF
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
    _OWNAME = String.Empty
    _BUNAME = String.Empty
    _LOCNO = String.Empty
    _LOC = String.Empty
    _TRANDT = 0
    _TRANTY = String.Empty
    _NAME = String.Empty
    _ADDR = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP5 = 0
    _ZIP4 = 0
    _SIGNED = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & MyFileName & " where list# = " & Wrklistno & " And year >= " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year"
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
      _LISTNO = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _OWNAME = .Item("OWNAME")
      _BUNAME = .Item("BUNAME")
      _LOCNO = .Item("LOC#")
      _LOC = .Item("LOC")
      _TRANDT = .Item("TRANDT")
      _TRANTY = .Item("TRANTY")
      _NAME = .Item("NAME")
      _ADDR = .Item("ADDR")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _SIGNED = .Item("SIGNED")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("OWNAME") = _OWNAME
      .Item("BUNAME") = _BUNAME
      .Item("LOC#") = _LOCNO
      .Item("LOC") = _LOC
      .Item("TRANDT") = _TRANDT
      .Item("TRANTY") = _TRANTY
      .Item("NAME") = _NAME
      .Item("ADDR") = _ADDR
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("SIGNED") = _SIGNED

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

  Dim mOWNAME As String
  Public Property _OWNAME As String
    Get
      Return mOWNAME
    End Get
    Set(ByVal value As String)
      mOWNAME = value
    End Set
  End Property

  Dim mBUNAME As String
  Public Property _BUNAME As String
    Get
      Return mBUNAME
    End Get
    Set(ByVal value As String)
      mBUNAME = value
    End Set
  End Property

  Dim mLOCNO As String
  Public Property _LOCNO As String
    Get
      Return mLOCNO
    End Get
    Set(ByVal value As String)
      mLOCNO = value
    End Set
  End Property

  Dim mLOC As String
  Public Property _LOC As String
    Get
      Return mLOC
    End Get
    Set(ByVal value As String)
      mLOC = value
    End Set
  End Property

  Dim mTRANDT As Integer
  Public Property _TRANDT As Integer
    Get
      Return mTRANDT
    End Get
    Set(ByVal value As Integer)
      mTRANDT = value
    End Set
  End Property

  Dim mTRANTY As String
  Public Property _TRANTY As String
    Get
      Return mTRANTY
    End Get
    Set(ByVal value As String)
      mTRANTY = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mADDR As String
  Public Property _ADDR As String
    Get
      Return mADDR
    End Get
    Set(ByVal value As String)
      mADDR = value
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

  Dim mZIP5 As Integer
  Public Property _ZIP5 As Integer
    Get
      Return mZIP5
    End Get
    Set(ByVal value As Integer)
      mZIP5 = value
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

  Dim mSIGNED As String
  Public Property _SIGNED As String
    Get
      Return mSIGNED
    End Get
    Set(ByVal value As String)
      mSIGNED = value
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


