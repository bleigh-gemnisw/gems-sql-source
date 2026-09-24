Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "GLBUDGET"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where FUND=" & Fund & " and SFUND=" & Sfund &
   " and DEPT=" & Dept & " and OBJ=" & Obj & " and FUNC=" & Func & " and SFUNC=" & Sfunc
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
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
  Public Function GetViewbyAcct(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "fund,sfund,dept,obj,func,sfunc,gltyp,descd from " & cFileName &
  " where FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ=" & Obj &
  " and FUNC=" & Func & " and SFUNC>=" & Sfunc &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ=" & Obj & " and FUNC>" & Func &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ>" & Obj &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT>" & Dept &
  " or FUND=" & Fund & " and SFUND>" & Sfund &
  " or FUND>" & Fund & " order by FUND,SFUND,DEPT,OBJ,FUNC,SFUNC"
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
  Public Function PosData(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Dept As Integer,
 ByVal Obj As Integer, ByVal Func As Integer, ByVal Sfunc As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName &
  " where FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ=" & Obj &
  " and FUNC=" & Func & " and SFUNC>=" & Sfunc &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ=" & Obj & " and FUNC>" & Func &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT=" & Dept & " and OBJ>" & Obj &
  " or FUND=" & Fund & " and SFUND=" & Sfund & " and DEPT>" & Dept &
  " or FUND=" & Fund & " and SFUND>" & Sfund &
  " or FUND>" & Fund & " order by FUND,SFUND,DEPT,OBJ,FUNC,SFUNC"
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
  Public Sub ClearBudgets()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Update " & cFileName & " set adoptd=0,bamt1=0,bamt2=0,bamt3=0,bamt4=0," &
   "bamt5=0,curr=0,exp=0,forcst=0,orig=0,prop=0"
    Conn = MyDBConn.Open
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
  Public Sub DeleteFund(ByVal WrkFund As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName & " where fund=" & WrkFund
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal wrkwhere As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Update " & cFileName & " " & Wrkset & " " & wrkwhere

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Set Fields"
  Private Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _FUND = .Item("FUND")
      _SFUND = .Item("SFUND")
      _DEPT = .Item("DEPT")
      _OBJ = .Item("OBJ")
      _FUNC = .Item("FUNC")
      _SFUNC = .Item("SFUNC")
      _DCODE = .Item("DCODE")
      _REV = .Item("REV")
      _GLTYP = .Item("GLTYP")
      _DESCD = .Item("DESCD")
      _ACT1 = .Item("ACT1")
      _ACT2 = .Item("ACT2")
      _ACT3 = .Item("ACT3")
      _ACT4 = .Item("ACT4")
      _ACT5 = .Item("ACT5")
      _ORIG = .Item("ORIG")
      _CURR = .Item("CURR")
      _PROP = .Item("PROP")
      _EXP = .Item("EXP")
      _ADOPTD = .Item("ADOPTD")
      _FORCST = .Item("FORCST")
      _BAMT1 = .Item("BAMT1")
      _BAMT2 = .Item("BAMT2")
      _BAMT3 = .Item("BAMT3")
      _BAMT4 = .Item("BAMT4")
      _BAMT5 = .Item("BAMT5")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("FUND") = _FUND
      .Item("SFUND") = _SFUND
      .Item("DEPT") = _DEPT
      .Item("OBJ") = _OBJ
      .Item("FUNC") = _FUNC
      .Item("SFUNC") = _SFUNC
      .Item("DCODE") = _DCODE
      .Item("REV") = _REV
      .Item("GLTYP") = _GLTYP
      .Item("DESCD") = _DESCD
      .Item("ACT1") = _ACT1
      .Item("ACT2") = _ACT2
      .Item("ACT3") = _ACT3
      .Item("ACT4") = _ACT4
      .Item("ACT5") = _ACT5
      .Item("ORIG") = _ORIG
      .Item("CURR") = _CURR
      .Item("PROP") = _PROP
      .Item("EXP") = _EXP
      .Item("ADOPTD") = _ADOPTD
      .Item("FORCST") = _FORCST
      .Item("BAMT1") = _BAMT1
      .Item("BAMT2") = _BAMT2
      .Item("BAMT3") = _BAMT3
      .Item("BAMT4") = _BAMT4
      .Item("BAMT5") = _BAMT5
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
  Dim mFUND As Integer
  Public Property _FUND As Integer
    Get
      Return mFUND
    End Get
    Set(ByVal value As Integer)
      mFUND = value
    End Set
  End Property
  Dim mSFUND As Integer
  Public Property _SFUND As Integer
    Get
      Return mSFUND
    End Get
    Set(ByVal value As Integer)
      mSFUND = value
    End Set
  End Property
  Dim mDEPT As Integer
  Public Property _DEPT As Integer
    Get
      Return mDEPT
    End Get
    Set(ByVal value As Integer)
      mDEPT = value
    End Set
  End Property
  Dim mOBJ As Integer
  Public Property _OBJ As Integer
    Get
      Return mOBJ
    End Get
    Set(ByVal value As Integer)
      mOBJ = value
    End Set
  End Property
  Dim mFUNC As Integer
  Public Property _FUNC As Integer
    Get
      Return mFUNC
    End Get
    Set(ByVal value As Integer)
      mFUNC = value
    End Set
  End Property
  Dim mSFUNC As Integer
  Public Property _SFUNC As Integer
    Get
      Return mSFUNC
    End Get
    Set(ByVal value As Integer)
      mSFUNC = value
    End Set
  End Property
  Dim mDCODE As String
  Public Property _DCODE As String
    Get
      Return mDCODE
    End Get
    Set(ByVal value As String)
      mDCODE = value
    End Set
  End Property
  Dim mREV As String
  Public Property _REV As String
    Get
      Return mREV
    End Get
    Set(ByVal value As String)
      mREV = value
    End Set
  End Property
  Dim mGLTYP As String
  Public Property _GLTYP As String
    Get
      Return mGLTYP
    End Get
    Set(ByVal value As String)
      mGLTYP = value
    End Set
  End Property
  Dim mDESCD As String
  Public Property _DESCD As String
    Get
      Return mDESCD
    End Get
    Set(ByVal value As String)
      mDESCD = value
    End Set
  End Property
  Dim mACT1 As Long
  Public Property _ACT1 As Long
    Get
      Return mACT1
    End Get
    Set(ByVal value As Long)
      mACT1 = value
    End Set
  End Property
  Dim mACT2 As Long
  Public Property _ACT2 As Long
    Get
      Return mACT2
    End Get
    Set(ByVal value As Long)
      mACT2 = value
    End Set
  End Property
  Dim mACT3 As Long
  Public Property _ACT3 As Long
    Get
      Return mACT3
    End Get
    Set(ByVal value As Long)
      mACT3 = value
    End Set
  End Property
  Dim mACT4 As Long
  Public Property _ACT4 As Long
    Get
      Return mACT4
    End Get
    Set(ByVal value As Long)
      mACT4 = value
    End Set
  End Property
  Dim mACT5 As Long
  Public Property _ACT5 As Long
    Get
      Return mACT5
    End Get
    Set(ByVal value As Long)
      mACT5 = value
    End Set
  End Property
  Dim mORIG As Long
  Public Property _ORIG As Long
    Get
      Return mORIG
    End Get
    Set(ByVal value As Long)
      mORIG = value
    End Set
  End Property
  Dim mCURR As Long
  Public Property _CURR As Long
    Get
      Return mCURR
    End Get
    Set(ByVal value As Long)
      mCURR = value
    End Set
  End Property
  Dim mPROP As Long
  Public Property _PROP As Long
    Get
      Return mPROP
    End Get
    Set(ByVal value As Long)
      mPROP = value
    End Set
  End Property
  Dim mEXP As Long
  Public Property _EXP As Long
    Get
      Return mEXP
    End Get
    Set(ByVal value As Long)
      mEXP = value
    End Set
  End Property
  Dim mADOPTD As Long
  Public Property _ADOPTD As Long
    Get
      Return mADOPTD
    End Get
    Set(ByVal value As Long)
      mADOPTD = value
    End Set
  End Property
  Dim mFORCST As Long
  Public Property _FORCST As Long
    Get
      Return mFORCST
    End Get
    Set(ByVal value As Long)
      mFORCST = value
    End Set
  End Property
  Dim mBAMT1 As Long
  Public Property _BAMT1 As Long
    Get
      Return mBAMT1
    End Get
    Set(ByVal value As Long)
      mBAMT1 = value
    End Set
  End Property
  Dim mBAMT2 As Long
  Public Property _BAMT2 As Long
    Get
      Return mBAMT2
    End Get
    Set(ByVal value As Long)
      mBAMT2 = value
    End Set
  End Property
  Dim mBAMT3 As Long
  Public Property _BAMT3 As Long
    Get
      Return mBAMT3
    End Get
    Set(ByVal value As Long)
      mBAMT3 = value
    End Set
  End Property
  Dim mBAMT4 As Long
  Public Property _BAMT4 As Long
    Get
      Return mBAMT4
    End Get
    Set(ByVal value As Long)
      mBAMT4 = value
    End Set
  End Property
  Dim mBAMT5 As Long
  Public Property _BAMT5 As Long
    Get
      Return mBAMT5
    End Get
    Set(ByVal value As Long)
      mBAMT5 = value
    End Set
  End Property
#End Region
End Class
