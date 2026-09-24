Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim ConnRdr As SqlConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objreader As SqlDataReader
  Const cFileName As String = "UTCOEA"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region
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
      .Columns.Add("cetax", Type.GetType("System.Decimal"))
      .Columns.Add("cobond", Type.GetType("System.Decimal"))
      .Columns.Add("cnbond", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("ccno") = .Item("ccno")
        dr.Item("year") = .Item("year")
        dr.Item("list#") = .Item("list#")
        dr.Item("type") = .Item("type")
        dr.Item("name") = .Item("name")
        dr.Item("cdate") = .Item("cdate")
        dr.Item("wkdate") = GetDBDateInt(.Item("cdate"))
        dr.Item("rsncd") = .Item("rsncd")
        dr.Item("cetax") = .Item("cetax")
        dr.Item("cobond") = .Item("cobond")
        dr.Item("cnbond") = .Item("cnbond")
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

  '--------------------- 5/31/25   for bal sheet
  Public Sub SetRangeLite(ByVal ListNo As Integer, ByVal Year As Integer,
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
    StrSQL = "SELECT CDATE, CETAX from " & cFileName &
    " where list#=" & ListNo & " and type='" & Type & "' and year=" & Year &
    " and chdate" & WrkCompare & PDate &
    WrkOrder
    ConnRdr = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, ConnRdr)
    objreader = objCommand.ExecuteReader()
    objCommand = Nothing
  End Sub
  Public Sub ReadFileELite()
    Dim Good As Boolean

    Good = objreader.Read()
    If Good Then
      GetFieldsRdrLite()
    Else
      CloseRange()
    End If
  End Sub

  '--------------

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
      _RSNCD = .Item("RSNCD")
      _CDATE = .Item("CDATE")
      _CDESC = .Item("CDESC")
      _CETAX = .Item("CETAX")
      _CETAX1 = .Item("CETAX1")
      _CETAX2 = .Item("CETAX2")
      _CETAX3 = .Item("CETAX3")
      _CETAX4 = .Item("CETAX4")
      _COBOND = .Item("COBOND")
      _CNBOND = .Item("CNBOND")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
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
      _CDATE = .Item("CDATE")
      _CDESC = .Item("CDESC")
      _CETAX = .Item("CETAX")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
    End With
  End Sub
  '--------------------- 5/31/25   for bal sheet
  Public Sub GetFieldsRdrLite()
    With objreader
      _CDATE = .Item("CDATE")
      _CETAX = .Item("CETAX")
    End With
  End Sub

  '--------------------------
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
  Dim mCETAX As Decimal
  Public Property _CETAX As Decimal
    Get
        Return mCETAX
    End Get
    Set(ByVal value As Decimal)
        mCETAX = value
    End Set
End Property
  Dim mCETAX1 As Decimal
  Public Property _CETAX1 As Decimal
    Get
      Return mCETAX1
    End Get
    Set(ByVal value As Decimal)
      mCETAX1 = value
    End Set
  End Property

  Dim mCETAX2 As Decimal
  Public Property _CETAX2 As Decimal
    Get
      Return mCETAX2
    End Get
    Set(ByVal value As Decimal)
      mCETAX2 = value
    End Set
  End Property

  Dim mCETAX3 As Decimal
  Public Property _CETAX3 As Decimal
    Get
      Return mCETAX3
    End Get
    Set(ByVal value As Decimal)
      mCETAX3 = value
    End Set
  End Property

  Dim mCETAX4 As Decimal
  Public Property _CETAX4 As Decimal
    Get
      Return mCETAX4
    End Get
    Set(ByVal value As Decimal)
      mCETAX4 = value
    End Set
  End Property

  Dim mCOBOND As Decimal
  Public Property _COBOND As Decimal
    Get
      Return mCOBOND
    End Get
    Set(ByVal value As Decimal)
      mCOBOND = value
    End Set
  End Property

  Dim mCNBOND As Decimal
  Public Property _CNBOND As Decimal
    Get
      Return mCNBOND
    End Get
    Set(ByVal value As Decimal)
      mCNBOND = value
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
#End Region

End Class

