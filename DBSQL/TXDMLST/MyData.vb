Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDMLST"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_YEAR  = 0
_SEQNO  = 0
_PRDESC = string.empty
_PRMOD = string.empty
_QTY  = 0
_ACQDT  = 0
_INSDT  = 0
_GLYEAR  = 0
_LEASE = string.empty
_IRSCLS  = 0
_PURCH  = 0
_TRANS  = 0
_ACQCST  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrkyear As integer, ByVal Wrkseqno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seqno = " & Wrkseqno
    Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseqno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seqno >= " & Wrkseqno & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seqno"
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
  Public Function AutoGenKey(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer) As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False

    StrSQL = "Select top 1 * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " order by seqno desc"
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
        NextKey = ds.Tables(0).Rows(0).Item("seqno") + 1
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
  Public Sub DeleteListNo(ByVal wrklistno As Integer, ByVal Wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE list# = " & wrklistno & " And year = " & Wrkyear

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Function GetByList(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False

    StrSQL = "Select * From " & cFileName _
    & " where list# = " & Wrklistno & "AND YEAR = " & wrkyear & " order by list#"
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
  _LISTNO   = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _SEQNO    = .Item("SEQNO")
  _PRDESC   = .Item("PRDESC")
  _PRMOD    = .Item("PRMOD")
  _QTY      = .Item("QTY")
  _ACQDT    = .Item("ACQDT")
  _INSDT    = .Item("INSDT")
  _GLYEAR   = .Item("GLYEAR")
  _LEASE    = .Item("LEASE")
  _IRSCLS   = .Item("IRSCLS")
  _PURCH    = .Item("PURCH")
  _TRANS    = .Item("TRANS")
  _ACQCST   = .Item("ACQCST")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("SEQNO") =   _SEQNO   
.Item("PRDESC") =   _PRDESC  
.Item("PRMOD") =   _PRMOD   
.Item("QTY") =   _QTY     
.Item("ACQDT") =   _ACQDT   
.Item("INSDT") =   _INSDT   
.Item("GLYEAR") =   _GLYEAR  
.Item("LEASE") =   _LEASE   
.Item("IRSCLS") =   _IRSCLS  
.Item("PURCH") =   _PURCH   
.Item("TRANS") =   _TRANS   
.Item("ACQCST") =   _ACQCST  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mLISTNO  as integer 
Public Property _LISTNO  as integer   
    Get
        Return mLISTNO
    End Get
    set(byval value as integer)
        mLISTNO = value
    End Set
End Property

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
    End Set
End Property

Dim mSEQNO  as integer 
Public Property _SEQNO  as integer   
    Get
        Return mSEQNO
    End Get
    set(byval value as integer)
        mSEQNO = value
    End Set
End Property

Dim mPRDESC as string 
Public Property _PRDESC as string   
    Get
        Return mPRDESC
    End Get
    set(byval value as string)
        mPRDESC = value
    End Set
End Property

Dim mPRMOD as string 
Public Property _PRMOD as string   
    Get
        Return mPRMOD
    End Get
    set(byval value as string)
        mPRMOD = value
    End Set
End Property

Dim mQTY  as integer 
Public Property _QTY  as integer   
    Get
        Return mQTY
    End Get
    set(byval value as integer)
        mQTY = value
    End Set
End Property

Dim mACQDT  as integer 
Public Property _ACQDT  as integer   
    Get
        Return mACQDT
    End Get
    set(byval value as integer)
        mACQDT = value
    End Set
End Property

Dim mINSDT  as integer 
Public Property _INSDT  as integer   
    Get
        Return mINSDT
    End Get
    set(byval value as integer)
        mINSDT = value
    End Set
End Property

Dim mGLYEAR  as integer 
Public Property _GLYEAR  as integer   
    Get
        Return mGLYEAR
    End Get
    set(byval value as integer)
        mGLYEAR = value
    End Set
End Property

Dim mLEASE as string 
Public Property _LEASE as string   
    Get
        Return mLEASE
    End Get
    set(byval value as string)
        mLEASE = value
    End Set
End Property

Dim mIRSCLS  as integer 
Public Property _IRSCLS  as integer   
    Get
        Return mIRSCLS
    End Get
    set(byval value as integer)
        mIRSCLS = value
    End Set
End Property

Dim mPURCH  as long
Public Property _PURCH  as long  
    Get
        Return mPURCH
    End Get
    set(byval value as long)
        mPURCH = value
    End Set
End Property

Dim mTRANS  as long
Public Property _TRANS  as long  
    Get
        Return mTRANS
    End Get
    set(byval value as long)
        mTRANS = value
    End Set
End Property

Dim mACQCST  as long
Public Property _ACQCST  as long  
    Get
        Return mACQCST
    End Get
    set(byval value as long)
        mACQCST = value
    End Set
End Property

Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


