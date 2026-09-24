Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXCOEB"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CCNO = 0
    _CYEAR = 0
    _LISTNo = 0
    _CTYPE = String.Empty
    _NAME = String.Empty
    _DIST = 0
    _CT2MC1 = String.Empty
    _CT2MC2 = String.Empty
    _CT2MC3 = String.Empty
    _CT2MC4 = String.Empty
    _RSNCD = String.Empty
    _CGRSCH = 0
    _CDATE = 0
    _CDESC = String.Empty
    _CGRS = 0
    _EXCHG = 0
    _CATG = String.Empty
    _EXEMP = String.Empty
    _NTPCD1 = 0
    _NTPCD2 = 0
    _NTPCD3 = 0
    _NTPCD4 = 0
    _NTPCD5 = 0
    _NTPCD6 = 0
    _NTPCD7 = 0
    _NTPCD8 = 0
    _NTPCD9 = 0
    _NTPCDA = 0
    _NTASS1 = 0
    _NTASS2 = 0
    _NTASS3 = 0
    _NTASS4 = 0
    _NTASS5 = 0
    _NTASS6 = 0
    _NTASS7 = 0
    _NTASS8 = 0
    _NTASS9 = 0
    _NTASSA = 0
    _NTEX1 = 0
    _NTEX2 = 0
    _NTEX3 = 0
    _NTEX4 = 0
    _NTEX5 = 0
    _NTEX6 = 0
    _NTEX7 = 0
    _NTECD1 = String.Empty
    _NTECD2 = String.Empty
    _NTECD3 = String.Empty
    _NTECD4 = String.Empty
    _NTECD5 = String.Empty
    _NTECD6 = String.Empty
    _NTECD7 = String.Empty
    _NTNET = 0
    _VINNO = String.Empty
    _PRF = String.Empty
    _CHDATE = 0
    _CHTIME = 0
    _NEWMVC = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkccno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where ccno = " & Wrkccno
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
  Public Function PosData(ByVal Wrkccno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where ccno >= " & Wrkccno & " Order by ccno"
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
  Public Function AutoGenKey() As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & cFileName & " order by ccno desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("ccno") + 1
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
      _CCNO = .Item("CCNO")
      _CYEAR = .Item("CYEAR")
      _LISTNo = .Item("LIST#")
      _CTYPE = .Item("CTYPE")
      _NAME = .Item("NAME")
      _DIST = .Item("DIST")
      _CT2MC1 = .Item("CT2MC1")
      _CT2MC2 = .Item("CT2MC2")
      _CT2MC3 = .Item("CT2MC3")
      _CT2MC4 = .Item("CT2MC4")
      _RSNCD = .Item("RSNCD")
      _CGRSCH = .Item("CGRSCH")
      _CDATE = .Item("CDATE")
      _CDESC = .Item("CDESC")
      _CGRS = .Item("CGRS")
      _EXCHG = .Item("EXCHG")
      _CATG = .Item("CATG")
      _EXEMP = .Item("EXEMP")
      _NTPCD1 = .Item("NTPCD1")
      _NTPCD2 = .Item("NTPCD2")
      _NTPCD3 = .Item("NTPCD3")
      _NTPCD4 = .Item("NTPCD4")
      _NTPCD5 = .Item("NTPCD5")
      _NTPCD6 = .Item("NTPCD6")
      _NTPCD7 = .Item("NTPCD7")
      _NTPCD8 = .Item("NTPCD8")
      _NTPCD9 = .Item("NTPCD9")
      _NTPCDA = .Item("NTPCDA")
      _NTASS1 = .Item("NTASS1")
      _NTASS2 = .Item("NTASS2")
      _NTASS3 = .Item("NTASS3")
      _NTASS4 = .Item("NTASS4")
      _NTASS5 = .Item("NTASS5")
      _NTASS6 = .Item("NTASS6")
      _NTASS7 = .Item("NTASS7")
      _NTASS8 = .Item("NTASS8")
      _NTASS9 = .Item("NTASS9")
      _NTASSA = .Item("NTASSA")
      _NTEX1 = .Item("NTEX1")
      _NTEX2 = .Item("NTEX2")
      _NTEX3 = .Item("NTEX3")
      _NTEX4 = .Item("NTEX4")
      _NTEX5 = .Item("NTEX5")
      _NTEX6 = .Item("NTEX6")
      _NTEX7 = .Item("NTEX7")
      _NTECD1 = .Item("NTECD1")
      _NTECD2 = .Item("NTECD2")
      _NTECD3 = .Item("NTECD3")
      _NTECD4 = .Item("NTECD4")
      _NTECD5 = .Item("NTECD5")
      _NTECD6 = .Item("NTECD6")
      _NTECD7 = .Item("NTECD7")
      _NTNET = .Item("NTNET")
      _VINNO = .Item("VINNO")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _NEWMVC = .Item("NEWMVC")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CCNO") = _CCNO
      .Item("CYEAR") = _CYEAR
      .Item("LIST#") = _LISTNo
      .Item("CTYPE") = _CTYPE
      .Item("NAME") = _NAME
      .Item("DIST") = _DIST
      .Item("CT2MC1") = _CT2MC1
      .Item("CT2MC2") = _CT2MC2
      .Item("CT2MC3") = _CT2MC3
      .Item("CT2MC4") = _CT2MC4
      .Item("RSNCD") = _RSNCD
      .Item("CGRSCH") = _CGRSCH
      .Item("CDATE") = _CDATE
      .Item("CDESC") = _CDESC
      .Item("CGRS") = _CGRS
      .Item("EXCHG") = _EXCHG
      .Item("CATG") = _CATG
      .Item("EXEMP") = _EXEMP
      .Item("NTPCD1") = _NTPCD1
      .Item("NTPCD2") = _NTPCD2
      .Item("NTPCD3") = _NTPCD3
      .Item("NTPCD4") = _NTPCD4
      .Item("NTPCD5") = _NTPCD5
      .Item("NTPCD6") = _NTPCD6
      .Item("NTPCD7") = _NTPCD7
      .Item("NTPCD8") = _NTPCD8
      .Item("NTPCD9") = _NTPCD9
      .Item("NTPCDA") = _NTPCDA
      .Item("NTASS1") = _NTASS1
      .Item("NTASS2") = _NTASS2
      .Item("NTASS3") = _NTASS3
      .Item("NTASS4") = _NTASS4
      .Item("NTASS5") = _NTASS5
      .Item("NTASS6") = _NTASS6
      .Item("NTASS7") = _NTASS7
      .Item("NTASS8") = _NTASS8
      .Item("NTASS9") = _NTASS9
      .Item("NTASSA") = _NTASSA
      .Item("NTEX1") = _NTEX1
      .Item("NTEX2") = _NTEX2
      .Item("NTEX3") = _NTEX3
      .Item("NTEX4") = _NTEX4
      .Item("NTEX5") = _NTEX5
      .Item("NTEX6") = _NTEX6
      .Item("NTEX7") = _NTEX7
      .Item("NTECD1") = _NTECD1
      .Item("NTECD2") = _NTECD2
      .Item("NTECD3") = _NTECD3
      .Item("NTECD4") = _NTECD4
      .Item("NTECD5") = _NTECD5
      .Item("NTECD6") = _NTECD6
      .Item("NTECD7") = _NTECD7
      .Item("NTNET") = _NTNET
      .Item("VINNO") = _VINNO
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME
      .Item("NEWMVC") = _NEWMVC
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCCNO As Integer
  Public Property _CCNO As Integer
    Get
      Return mCCNO
    End Get
    Set(ByVal value As Integer)
      mCCNO = value
    End Set
  End Property

  Dim mCYEAR As Integer
  Public Property _CYEAR As Integer
    Get
      Return mCYEAR
    End Get
    Set(ByVal value As Integer)
      mCYEAR = value
    End Set
  End Property

  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property

  Dim mCTYPE As String
  Public Property _CTYPE As String
    Get
      Return mCTYPE
    End Get
    Set(ByVal value As String)
      mCTYPE = value
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

  Dim mDIST As Integer
  Public Property _DIST As Integer
    Get
      Return mDIST
    End Get
    Set(ByVal value As Integer)
      mDIST = value
    End Set
  End Property

  Dim mCT2MC1 As String
  Public Property _CT2MC1 As String
    Get
      Return mCT2MC1
    End Get
    Set(ByVal value As String)
      mCT2MC1 = value
    End Set
  End Property

  Dim mCT2MC2 As String
  Public Property _CT2MC2 As String
    Get
      Return mCT2MC2
    End Get
    Set(ByVal value As String)
      mCT2MC2 = value
    End Set
  End Property

  Dim mCT2MC3 As String
  Public Property _CT2MC3 As String
    Get
      Return mCT2MC3
    End Get
    Set(ByVal value As String)
      mCT2MC3 = value
    End Set
  End Property

  Dim mCT2MC4 As String
  Public Property _CT2MC4 As String
    Get
      Return mCT2MC4
    End Get
    Set(ByVal value As String)
      mCT2MC4 = value
    End Set
  End Property

  Dim mRSNCD As String
  Public Property _RSNCD As String
    Get
      Return mRSNCD
    End Get
    Set(ByVal value As String)
      mRSNCD = value
    End Set
  End Property

  Dim mCGRSCH As Long
  Public Property _CGRSCH As Long
    Get
      Return mCGRSCH
    End Get
    Set(ByVal value As Long)
      mCGRSCH = value
    End Set
  End Property

  Dim mCDATE As Integer
  Public Property _CDATE As Integer
    Get
      Return mCDATE
    End Get
    Set(ByVal value As Integer)
      mCDATE = value
    End Set
  End Property

  Dim mCDESC As String
  Public Property _CDESC As String
    Get
      Return mCDESC
    End Get
    Set(ByVal value As String)
      mCDESC = value
    End Set
  End Property

  Dim mCGRS As Long
  Public Property _CGRS As Long
    Get
      Return mCGRS
    End Get
    Set(ByVal value As Long)
      mCGRS = value
    End Set
  End Property

  Dim mEXCHG As Long
  Public Property _EXCHG As Long
    Get
      Return mEXCHG
    End Get
    Set(ByVal value As Long)
      mEXCHG = value
    End Set
  End Property

  Dim mCATG As String
  Public Property _CATG As String
    Get
      Return mCATG
    End Get
    Set(ByVal value As String)
      mCATG = value
    End Set
  End Property

  Dim mEXEMP As String
  Public Property _EXEMP As String
    Get
      Return mEXEMP
    End Get
    Set(ByVal value As String)
      mEXEMP = value
    End Set
  End Property

  Dim mNTPCD1 As Integer
  Public Property _NTPCD1 As Integer
    Get
      Return mNTPCD1
    End Get
    Set(ByVal value As Integer)
      mNTPCD1 = value
    End Set
  End Property

  Dim mNTPCD2 As Integer
  Public Property _NTPCD2 As Integer
    Get
      Return mNTPCD2
    End Get
    Set(ByVal value As Integer)
      mNTPCD2 = value
    End Set
  End Property

  Dim mNTPCD3 As Integer
  Public Property _NTPCD3 As Integer
    Get
      Return mNTPCD3
    End Get
    Set(ByVal value As Integer)
      mNTPCD3 = value
    End Set
  End Property

  Dim mNTPCD4 As Integer
  Public Property _NTPCD4 As Integer
    Get
      Return mNTPCD4
    End Get
    Set(ByVal value As Integer)
      mNTPCD4 = value
    End Set
  End Property

  Dim mNTPCD5 As Integer
  Public Property _NTPCD5 As Integer
    Get
      Return mNTPCD5
    End Get
    Set(ByVal value As Integer)
      mNTPCD5 = value
    End Set
  End Property

  Dim mNTPCD6 As Integer
  Public Property _NTPCD6 As Integer
    Get
      Return mNTPCD6
    End Get
    Set(ByVal value As Integer)
      mNTPCD6 = value
    End Set
  End Property

  Dim mNTPCD7 As Integer
  Public Property _NTPCD7 As Integer
    Get
      Return mNTPCD7
    End Get
    Set(ByVal value As Integer)
      mNTPCD7 = value
    End Set
  End Property

  Dim mNTPCD8 As Integer
  Public Property _NTPCD8 As Integer
    Get
      Return mNTPCD8
    End Get
    Set(ByVal value As Integer)
      mNTPCD8 = value
    End Set
  End Property

  Dim mNTPCD9 As Integer
  Public Property _NTPCD9 As Integer
    Get
      Return mNTPCD9
    End Get
    Set(ByVal value As Integer)
      mNTPCD9 = value
    End Set
  End Property

  Dim mNTPCDA As Integer
  Public Property _NTPCDA As Integer
    Get
      Return mNTPCDA
    End Get
    Set(ByVal value As Integer)
      mNTPCDA = value
    End Set
  End Property

  Dim mNTASS1 As Long
  Public Property _NTASS1 As Long
    Get
      Return mNTASS1
    End Get
    Set(ByVal value As Long)
      mNTASS1 = value
    End Set
  End Property

  Dim mNTASS2 As Long
  Public Property _NTASS2 As Long
    Get
      Return mNTASS2
    End Get
    Set(ByVal value As Long)
      mNTASS2 = value
    End Set
  End Property

  Dim mNTASS3 As Long
  Public Property _NTASS3 As Long
    Get
      Return mNTASS3
    End Get
    Set(ByVal value As Long)
      mNTASS3 = value
    End Set
  End Property

  Dim mNTASS4 As Long
  Public Property _NTASS4 As Long
    Get
      Return mNTASS4
    End Get
    Set(ByVal value As Long)
      mNTASS4 = value
    End Set
  End Property

  Dim mNTASS5 As Long
  Public Property _NTASS5 As Long
    Get
      Return mNTASS5
    End Get
    Set(ByVal value As Long)
      mNTASS5 = value
    End Set
  End Property

  Dim mNTASS6 As Long
  Public Property _NTASS6 As Long
    Get
      Return mNTASS6
    End Get
    Set(ByVal value As Long)
      mNTASS6 = value
    End Set
  End Property

  Dim mNTASS7 As Long
  Public Property _NTASS7 As Long
    Get
      Return mNTASS7
    End Get
    Set(ByVal value As Long)
      mNTASS7 = value
    End Set
  End Property

  Dim mNTASS8 As Long
  Public Property _NTASS8 As Long
    Get
      Return mNTASS8
    End Get
    Set(ByVal value As Long)
      mNTASS8 = value
    End Set
  End Property

  Dim mNTASS9 As Long
  Public Property _NTASS9 As Long
    Get
      Return mNTASS9
    End Get
    Set(ByVal value As Long)
      mNTASS9 = value
    End Set
  End Property

  Dim mNTASSA As Long
  Public Property _NTASSA As Long
    Get
      Return mNTASSA
    End Get
    Set(ByVal value As Long)
      mNTASSA = value
    End Set
  End Property

  Dim mNTEX1 As Long
  Public Property _NTEX1 As Long
    Get
      Return mNTEX1
    End Get
    Set(ByVal value As Long)
      mNTEX1 = value
    End Set
  End Property

  Dim mNTEX2 As Long
  Public Property _NTEX2 As Long
    Get
      Return mNTEX2
    End Get
    Set(ByVal value As Long)
      mNTEX2 = value
    End Set
  End Property

  Dim mNTEX3 As Long
  Public Property _NTEX3 As Long
    Get
      Return mNTEX3
    End Get
    Set(ByVal value As Long)
      mNTEX3 = value
    End Set
  End Property

  Dim mNTEX4 As Long
  Public Property _NTEX4 As Long
    Get
      Return mNTEX4
    End Get
    Set(ByVal value As Long)
      mNTEX4 = value
    End Set
  End Property

  Dim mNTEX5 As Long
  Public Property _NTEX5 As Long
    Get
      Return mNTEX5
    End Get
    Set(ByVal value As Long)
      mNTEX5 = value
    End Set
  End Property

  Dim mNTEX6 As Long
  Public Property _NTEX6 As Long
    Get
      Return mNTEX6
    End Get
    Set(ByVal value As Long)
      mNTEX6 = value
    End Set
  End Property

  Dim mNTEX7 As Long
  Public Property _NTEX7 As Long
    Get
      Return mNTEX7
    End Get
    Set(ByVal value As Long)
      mNTEX7 = value
    End Set
  End Property

  Dim mNTECD1 As String
  Public Property _NTECD1 As String
    Get
      Return mNTECD1
    End Get
    Set(ByVal value As String)
      mNTECD1 = value
    End Set
  End Property

  Dim mNTECD2 As String
  Public Property _NTECD2 As String
    Get
      Return mNTECD2
    End Get
    Set(ByVal value As String)
      mNTECD2 = value
    End Set
  End Property

  Dim mNTECD3 As String
  Public Property _NTECD3 As String
    Get
      Return mNTECD3
    End Get
    Set(ByVal value As String)
      mNTECD3 = value
    End Set
  End Property

  Dim mNTECD4 As String
  Public Property _NTECD4 As String
    Get
      Return mNTECD4
    End Get
    Set(ByVal value As String)
      mNTECD4 = value
    End Set
  End Property

  Dim mNTECD5 As String
  Public Property _NTECD5 As String
    Get
      Return mNTECD5
    End Get
    Set(ByVal value As String)
      mNTECD5 = value
    End Set
  End Property

  Dim mNTECD6 As String
  Public Property _NTECD6 As String
    Get
      Return mNTECD6
    End Get
    Set(ByVal value As String)
      mNTECD6 = value
    End Set
  End Property

  Dim mNTECD7 As String
  Public Property _NTECD7 As String
    Get
      Return mNTECD7
    End Get
    Set(ByVal value As String)
      mNTECD7 = value
    End Set
  End Property

  Dim mNTNET As Long
  Public Property _NTNET As Long
    Get
      Return mNTNET
    End Get
    Set(ByVal value As Long)
      mNTNET = value
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

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
    End Set
  End Property

  Dim mCHTIME As Integer
  Public Property _CHTIME As Integer
    Get
      Return mCHTIME
    End Get
    Set(ByVal value As Integer)
      mCHTIME = value
    End Set
  End Property
  Dim mNEWMVC As Integer
  Public Property _NEWMVC As Integer
    Get
      Return mNEWMVC
    End Get
    Set(ByVal value As Integer)
      mNEWMVC = value
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


