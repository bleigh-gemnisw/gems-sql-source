Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCASS"
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
_CODE  = 0
_LTR = string.empty
_DESC = string.empty
_ACQDT  = 0
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
  Public Function GetByList(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select *  FROM " & cFileName _
    & " where list# = " & Wrklistno & " AND YEAR = " & wrkyear & " order by list#"
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

  Public Sub DeleteListNo(ByVal wrklist As Integer, wrkyear As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE list# = " & wrklist & " AND  year = " & wrkyear

    RecordNotFound = False
    IsEOF = False
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
  _LISTNO    = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _SEQNO    = .Item("SEQNO")
  _CODE     = .Item("CODE")
  _LTR      = .Item("LTR")
  _DESC     = .Item("DESC")
  _ACQDT    = .Item("ACQDT")
  _ACQCST   = .Item("ACQCST")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO   
.Item("YEAR") =   _YEAR    
.Item("SEQNO") =   _SEQNO   
.Item("CODE") =   _CODE    
.Item("LTR") =   _LTR     
.Item("DESC") =   _DESC    
.Item("ACQDT") =   _ACQDT   
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

Dim mCODE  as integer 
Public Property _CODE  as integer   
    Get
        Return mCODE
    End Get
    set(byval value as integer)
        mCODE = value
    End Set
End Property

Dim mLTR as string 
Public Property _LTR as string   
    Get
        Return mLTR
    End Get
    set(byval value as string)
        mLTR = value
    End Set
End Property

Dim mDESC as string 
Public Property _DESC as string   
    Get
        Return mDESC
    End Get
    set(byval value as string)
        mDESC = value
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


