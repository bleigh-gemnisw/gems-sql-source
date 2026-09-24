Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "TXCOEA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub
#End Region
  Public Function GetViewbyList(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName _
    & " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year &
    " order by chdate,chtime"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewDescList(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal pDate As Integer, pTime As Integer, ByVal NumRecs As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year & " and chdate=" & pDate & " and chtime<=" & pTime _
    & " or list#=" & ListNo & " and type='" & Type & "' and year=" & Year & " and chdate<" & pDate _
    & " order by chdate desc,chtime desc"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetDescList(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal pDate As Integer, pTime As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & "* from " & cFileName _
    & " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year & " and chdate=" & pDate & " and chtime<=" & pTime _
    & " or list#=" & ListNo & " and type='" & Type & "' and year=" & Year & " and chdate<" & pDate _
    & " order by chdate desc,chtime desc"
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
  Public Function GetLastbyDate(ByVal ListNo As Integer, ByVal Year As Integer,
 ByVal Type As String, ByVal PDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    If PDate = 0 Then PDate = 9999999
    StrSQL = "Select top 1 * from " & cFileName _
    & " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year & " and chdate<=" & PDate &
    " order by chdate desc,chtime desc"
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
  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("ccno", Type.GetType("System.Int32"))
      .Columns.Add("year", Type.GetType("System.Int16"))
      .Columns.Add("list#", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("cdate", Type.GetType("System.Int32"))
      .Columns.Add("wkdate", Type.GetType("System.Int32"))
      .Columns.Add("rsncd", Type.GetType("System.String"))
      .Columns.Add("cdesc", Type.GetType("System.String"))
      .Columns.Add("cnetas", Type.GetType("System.Int32"))
      .Columns.Add("cetax", Type.GetType("System.Decimal"))
      .Columns.Add("cgrs", Type.GetType("System.Decimal"))
      .Columns.Add("cexam", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item(0) = .Item("ccno")
        dr.Item(1) = .Item("year")
        dr.Item(2) = .Item("list#")
        dr.Item(3) = .Item("type")
        dr.Item(4) = .Item("name")
        dr.Item(5) = .Item("cdate")
        dr.Item(6) = GetDBDateInt(.Item("cdate"))
        dr.Item(7) = .Item("rsncd")
        dr.Item(8) = .Item("cdesc")
        dr.Item(9) = .Item("cnetas")
        dr.Item(10) = .Item("cetax")
        dr.Item(11) = .Item("cgrs")
        dr.Item(12) = .Item("ex1") + .Item("ex2") + .Item("ex3") + .Item("ex4") _
       + .Item("ex5") + .Item("ex6")
        ds2.Tables(0).Rows.Add(dr)
      End With
    Next

    Return ds2
  End Function
  Public Function GetDBDateInt(ByVal DateIn As Integer) As Integer
  Dim WrkDate As Integer
  Dim StrDate As String

  If DateIn > 0 Then
    StrDate = Trim$(Str(DateIn))
    Try
      WrkDate = Right$(StrDate, 4) & Left$(StrDate, 4)
    Catch
    End Try
  End If
  Return WrkDate
End Function
  Public Sub SetRange(ByVal ListNo As Integer, ByVal Year As Integer, _
 ByVal Type As String, ByVal PDate As Integer, ByVal PTime As Integer, ByVal Desc As Boolean)
  Dim objCommand As SqlCommand
  Dim WrkCompare As String
  Dim WrkOrder As String
  RecordNotFound = False
  IsEOF = False
  If Desc Then
      WrkCompare = "<="
      WrkOrder = " order by chdate desc, chtime desc"
  Else
      WrkCompare = ">="
      WrkOrder = " order by chdate, chtime"
  End If
  StrSQL = "Select * from " & cFileName & _
    " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year & _
    " and chdate" & WrkCompare & PDate & _
    WrkOrder
  ConnRdr = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, ConnRdr)
  objreader = objCommand.ExecuteReader()
  objCommand = Nothing
End Sub
  Public Sub ReadFileE()
    Dim Good As Boolean

    Good = objreader.Read()
    If Good Then
      GetFieldsRdr()
    Else
      CloseRange()
    End If
  End Sub
  Public Sub ReadFilePE()
    ReadFileE()
  End Sub

#Region "Methods: File Access Routines"
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
  Public Sub CloseRange()
    IsEOF = True
    objreader.Close()
    ConnRdr.Close()
  End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
      _CCNO = .Item("CCNO")
      _YEAR = .Item("YEAR")
      _LISTNo = .Item("LIST#")
    _TYPE = .Item("TYPE")
    _NAME = .Item("NAME")
    _DIST = .Item("DIST")
    _CTXOV = .Item("CTXOV")
    _CPCD1 = .Item("CPCD1")
    _CPCD2 = .Item("CPCD2")
    _CPCD3 = .Item("CPCD3")
    _CPCD4 = .Item("CPCD4")
    _CPCD5 = .Item("CPCD5")
    _CPCD6 = .Item("CPCD6")
    _CPCD7 = .Item("CPCD7")
    _CPCD8 = .Item("CPCD8")
    _CPCD9 = .Item("CPCD9")
    _CPCDA = .Item("CPCDA")
    _ASS1 = .Item("ASS1")
    _ASS2 = .Item("ASS2")
    _ASS3 = .Item("ASS3")
    _ASS4 = .Item("ASS4")
    _ASS5 = .Item("ASS5")
    _ASS6 = .Item("ASS6")
    _ASS7 = .Item("ASS7")
    _ASS8 = .Item("ASS8")
    _ASS9 = .Item("ASS9")
    _ASS10 = .Item("ASS10")
    _GRCHG = .Item("GRCHG")
    _EX1 = .Item("EX1")
    _EX2 = .Item("EX2")
    _EX3 = .Item("EX3")
    _EX4 = .Item("EX4")
    _EX5 = .Item("EX5")
    _EX6 = .Item("EX6")
    _EX7 = .Item("EX7")
    _EXCD1 = .Item("EXCD1")
    _EXCD2 = .Item("EXCD2")
    _EXCD3 = .Item("EXCD3")
    _EXCD4 = .Item("EXCD4")
    _EXCD5 = .Item("EXCD5")
    _EXCD6 = .Item("EXCD6")
    _EXCD7 = .Item("EXCD7")
    _RSNCD = .Item("RSNCD")
    _CDATE = .Item("CDATE")
    _CDESC = .Item("CDESC")
    _CGRS = .Item("CGRS")
    _EXCHG = .Item("EXCHG")
    _CETAX = .Item("CETAX")
    _C1MPCD = .Item("C1MPCD")
    _C1MSCD = .Item("C1MSCD")
    _C1CPCD = .Item("C1CPCD")
    _C1CSCD = .Item("C1CSCD")
    _C2MPCD = .Item("C2MPCD")
    _C2MSCD = .Item("C2MSCD")
    _C2CPCD = .Item("C2CPCD")
    _C2CSCD = .Item("C2CSCD")
    _SUSCD = .Item("SUSCD")
    _NEWMVC = .Item("NEWMVC")
    _AFTER = .Item("AFTER")
    _PRF = .Item("PRF")
    _CHDATE = .Item("CHDATE")
    _CHTIME = .Item("CHTIME")
    _IMVIDNo = .Item("IMVID#")
    _CNETAS = .Item("CNETAS")
  End With
End Sub
Public Sub GetFieldsRdr()
  With objreader
      _CCNO = .Item("CCNO")
      _YEAR = .Item("YEAR")
      _LISTNo = .Item("LIST#")
      _TYPE = .Item("TYPE")
      _NAME = .Item("NAME")
      _DIST = .Item("DIST")
      _CTXOV = .Item("CTXOV")
      _CPCD1 = .Item("CPCD1")
      _CPCD2 = .Item("CPCD2")
      _CPCD3 = .Item("CPCD3")
      _CPCD4 = .Item("CPCD4")
      _CPCD5 = .Item("CPCD5")
      _CPCD6 = .Item("CPCD6")
      _CPCD7 = .Item("CPCD7")
      _CPCD8 = .Item("CPCD8")
      _CPCD9 = .Item("CPCD9")
      _CPCDA = .Item("CPCDA")
      _ASS1 = .Item("ASS1")
      _ASS2 = .Item("ASS2")
      _ASS3 = .Item("ASS3")
      _ASS4 = .Item("ASS4")
      _ASS5 = .Item("ASS5")
      _ASS6 = .Item("ASS6")
      _ASS7 = .Item("ASS7")
      _ASS8 = .Item("ASS8")
      _ASS9 = .Item("ASS9")
      _ASS10 = .Item("ASS10")
      _GRCHG = .Item("GRCHG")
      _EX1 = .Item("EX1")
      _EX2 = .Item("EX2")
      _EX3 = .Item("EX3")
      _EX4 = .Item("EX4")
      _EX5 = .Item("EX5")
      _EX6 = .Item("EX6")
      _EX7 = .Item("EX7")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXCD6 = .Item("EXCD6")
      _EXCD7 = .Item("EXCD7")
      _RSNCD = .Item("RSNCD")
      _CDATE = .Item("CDATE")
      _CDESC = .Item("CDESC")
      _CGRS = .Item("CGRS")
      _EXCHG = .Item("EXCHG")
      _CETAX = .Item("CETAX")
      _C1MPCD = .Item("C1MPCD")
      _C1MSCD = .Item("C1MSCD")
      _C1CPCD = .Item("C1CPCD")
      _C1CSCD = .Item("C1CSCD")
      _C2MPCD = .Item("C2MPCD")
      _C2MSCD = .Item("C2MSCD")
      _C2CPCD = .Item("C2CPCD")
      _C2CSCD = .Item("C2CSCD")
      _SUSCD = .Item("SUSCD")
      _NEWMVC = .Item("NEWMVC")
      _AFTER = .Item("AFTER")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _IMVIDNo = .Item("IMVID#")
      _CNETAS = .Item("CNETAS")
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
Dim mCCNO As Integer
Public Property _CCNO As Integer
    Get
        Return mCCNO
    End Get
    Set(ByVal value As Integer)
        mCCNO = value
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
Dim mLISTNo As Integer
Public Property _LISTNo As Integer
    Get
        Return mLISTNo
    End Get
    Set(ByVal value As Integer)
        mLISTNo = value
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
Dim mCTXOV As String
Public Property _CTXOV As String
    Get
        Return mCTXOV
    End Get
    Set(ByVal value As String)
        mCTXOV = value
    End Set
End Property
Dim mCPCD1 As Integer
Public Property _CPCD1 As Integer
    Get
        Return mCPCD1
    End Get
    Set(ByVal value As Integer)
        mCPCD1 = value
    End Set
End Property
Dim mCPCD2 As Integer
Public Property _CPCD2 As Integer
    Get
        Return mCPCD2
    End Get
    Set(ByVal value As Integer)
        mCPCD2 = value
    End Set
End Property
Dim mCPCD3 As Integer
Public Property _CPCD3 As Integer
    Get
        Return mCPCD3
    End Get
    Set(ByVal value As Integer)
        mCPCD3 = value
    End Set
End Property
Dim mCPCD4 As Integer
Public Property _CPCD4 As Integer
    Get
        Return mCPCD4
    End Get
    Set(ByVal value As Integer)
        mCPCD4 = value
    End Set
End Property
Dim mCPCD5 As Integer
Public Property _CPCD5 As Integer
    Get
        Return mCPCD5
    End Get
    Set(ByVal value As Integer)
        mCPCD5 = value
    End Set
End Property
Dim mCPCD6 As Integer
Public Property _CPCD6 As Integer
    Get
        Return mCPCD6
    End Get
    Set(ByVal value As Integer)
        mCPCD6 = value
    End Set
End Property
Dim mCPCD7 As Integer
Public Property _CPCD7 As Integer
    Get
        Return mCPCD7
    End Get
    Set(ByVal value As Integer)
        mCPCD7 = value
    End Set
End Property
Dim mCPCD8 As Integer
Public Property _CPCD8 As Integer
    Get
        Return mCPCD8
    End Get
    Set(ByVal value As Integer)
        mCPCD8 = value
    End Set
End Property
Dim mCPCD9 As Integer
Public Property _CPCD9 As Integer
    Get
        Return mCPCD9
    End Get
    Set(ByVal value As Integer)
        mCPCD9 = value
    End Set
End Property
Dim mCPCDA As Integer
Public Property _CPCDA As Integer
    Get
        Return mCPCDA
    End Get
    Set(ByVal value As Integer)
        mCPCDA = value
    End Set
End Property
Dim mASS1 As Long
Public Property _ASS1 As Long
    Get
        Return mASS1
    End Get
    Set(ByVal value As Long)
        mASS1 = value
    End Set
End Property
Dim mASS2 As Long
Public Property _ASS2 As Long
    Get
        Return mASS2
    End Get
    Set(ByVal value As Long)
        mASS2 = value
    End Set
End Property
Dim mASS3 As Long
Public Property _ASS3 As Long
    Get
        Return mASS3
    End Get
    Set(ByVal value As Long)
        mASS3 = value
    End Set
End Property
Dim mASS4 As Long
Public Property _ASS4 As Long
    Get
        Return mASS4
    End Get
    Set(ByVal value As Long)
        mASS4 = value
    End Set
End Property
Dim mASS5 As Long
Public Property _ASS5 As Long
    Get
        Return mASS5
    End Get
    Set(ByVal value As Long)
        mASS5 = value
    End Set
End Property
Dim mASS6 As Long
Public Property _ASS6 As Long
    Get
        Return mASS6
    End Get
    Set(ByVal value As Long)
        mASS6 = value
    End Set
End Property
Dim mASS7 As Long
Public Property _ASS7 As Long
    Get
        Return mASS7
    End Get
    Set(ByVal value As Long)
        mASS7 = value
    End Set
End Property
Dim mASS8 As Long
Public Property _ASS8 As Long
    Get
        Return mASS8
    End Get
    Set(ByVal value As Long)
        mASS8 = value
    End Set
End Property
Dim mASS9 As Long
Public Property _ASS9 As Long
    Get
        Return mASS9
    End Get
    Set(ByVal value As Long)
        mASS9 = value
    End Set
End Property
Dim mASS10 As Long
Public Property _ASS10 As Long
    Get
        Return mASS10
    End Get
    Set(ByVal value As Long)
        mASS10 = value
    End Set
End Property
Dim mGRCHG As Long
Public Property _GRCHG As Long
    Get
        Return mGRCHG
    End Get
    Set(ByVal value As Long)
        mGRCHG = value
    End Set
End Property
Dim mEX1 As Integer
Public Property _EX1 As Integer
    Get
        Return mEX1
    End Get
    Set(ByVal value As Integer)
        mEX1 = value
    End Set
End Property
Dim mEX2 As Integer
Public Property _EX2 As Integer
    Get
        Return mEX2
    End Get
    Set(ByVal value As Integer)
        mEX2 = value
    End Set
End Property
Dim mEX3 As Integer
Public Property _EX3 As Integer
    Get
        Return mEX3
    End Get
    Set(ByVal value As Integer)
        mEX3 = value
    End Set
End Property
Dim mEX4 As Integer
Public Property _EX4 As Integer
    Get
        Return mEX4
    End Get
    Set(ByVal value As Integer)
        mEX4 = value
    End Set
End Property
Dim mEX5 As Integer
Public Property _EX5 As Integer
    Get
        Return mEX5
    End Get
    Set(ByVal value As Integer)
        mEX5 = value
    End Set
End Property
Dim mEX6 As Integer
Public Property _EX6 As Integer
    Get
        Return mEX6
    End Get
    Set(ByVal value As Integer)
        mEX6 = value
    End Set
End Property
Dim mEX7 As Integer
Public Property _EX7 As Integer
    Get
        Return mEX7
    End Get
    Set(ByVal value As Integer)
        mEX7 = value
    End Set
End Property
Dim mEXCD1 As String
Public Property _EXCD1 As String
    Get
        Return mEXCD1
    End Get
    Set(ByVal value As String)
        mEXCD1 = value
    End Set
End Property
Dim mEXCD2 As String
Public Property _EXCD2 As String
    Get
        Return mEXCD2
    End Get
    Set(ByVal value As String)
        mEXCD2 = value
    End Set
End Property
Dim mEXCD3 As String
Public Property _EXCD3 As String
    Get
        Return mEXCD3
    End Get
    Set(ByVal value As String)
        mEXCD3 = value
    End Set
End Property
Dim mEXCD4 As String
Public Property _EXCD4 As String
    Get
        Return mEXCD4
    End Get
    Set(ByVal value As String)
        mEXCD4 = value
    End Set
End Property
Dim mEXCD5 As String
Public Property _EXCD5 As String
    Get
        Return mEXCD5
    End Get
    Set(ByVal value As String)
        mEXCD5 = value
    End Set
End Property
Dim mEXCD6 As String
Public Property _EXCD6 As String
    Get
        Return mEXCD6
    End Get
    Set(ByVal value As String)
        mEXCD6 = value
    End Set
End Property
Dim mEXCD7 As String
Public Property _EXCD7 As String
    Get
        Return mEXCD7
    End Get
    Set(ByVal value As String)
        mEXCD7 = value
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
Dim mCETAX As Decimal
Public Property _CETAX As Decimal
    Get
        Return mCETAX
    End Get
    Set(ByVal value As Decimal)
        mCETAX = value
    End Set
End Property
Dim mC1MPCD As String
Public Property _C1MPCD As String
    Get
        Return mC1MPCD
    End Get
    Set(ByVal value As String)
        mC1MPCD = value
    End Set
End Property
Dim mC1MSCD As String
Public Property _C1MSCD As String
    Get
        Return mC1MSCD
    End Get
    Set(ByVal value As String)
        mC1MSCD = value
    End Set
End Property
Dim mC1CPCD As String
Public Property _C1CPCD As String
    Get
        Return mC1CPCD
    End Get
    Set(ByVal value As String)
        mC1CPCD = value
    End Set
End Property
Dim mC1CSCD As String
Public Property _C1CSCD As String
    Get
        Return mC1CSCD
    End Get
    Set(ByVal value As String)
        mC1CSCD = value
    End Set
End Property
Dim mC2MPCD As String
Public Property _C2MPCD As String
    Get
        Return mC2MPCD
    End Get
    Set(ByVal value As String)
        mC2MPCD = value
    End Set
End Property
Dim mC2MSCD As String
Public Property _C2MSCD As String
    Get
        Return mC2MSCD
    End Get
    Set(ByVal value As String)
        mC2MSCD = value
    End Set
End Property
Dim mC2CPCD As String
Public Property _C2CPCD As String
    Get
        Return mC2CPCD
    End Get
    Set(ByVal value As String)
        mC2CPCD = value
    End Set
End Property
Dim mC2CSCD As String
Public Property _C2CSCD As String
    Get
        Return mC2CSCD
    End Get
    Set(ByVal value As String)
        mC2CSCD = value
    End Set
End Property
Dim mSUSCD As String
Public Property _SUSCD As String
    Get
        Return mSUSCD
    End Get
    Set(ByVal value As String)
        mSUSCD = value
    End Set
End Property
Dim mNEWMVC As Long
Public Property _NEWMVC As Long
    Get
        Return mNEWMVC
    End Get
    Set(ByVal value As Long)
        mNEWMVC = value
    End Set
End Property
Dim mAFTER As String
Public Property _AFTER As String
    Get
        Return mAFTER
    End Get
    Set(ByVal value As String)
        mAFTER = value
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
Dim mIMVIDNo As String
Public Property _IMVIDNo As String
    Get
        Return mIMVIDNo
    End Get
    Set(ByVal value As String)
        mIMVIDNo = value
    End Set
End Property
Dim mCNETAS As Long
Public Property _CNETAS As Long
    Get
        Return mCNETAS
    End Get
    Set(ByVal value As Long)
        mCNETAS = value
    End Set
End Property
#End Region

End Class

