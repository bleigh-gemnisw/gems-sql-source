Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCCD"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_YEAR  = 0
_CODE  = 0
_LTR = string.empty
_DESC = string.empty
_DECODE = string.empty
_ASCODE  = 0
_ASPCT  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkyear As integer, ByVal Wrkcode As integer, ByVal Wrkltr As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " and code = " & Wrkcode & " and ltr = " & "'" & Wrkltr & "'"
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
  Public Function PosData(ByVal Wrkyear As Integer, ByVal Wrkcode As Integer, ByVal Wrkltr As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " And code = " & Wrkcode & " And ltr >= " & "'" & Wrkltr & "'" & " Or year = " & Wrkyear & " And code > " & Wrkcode & " Or year > " & Wrkyear & " Order by year, code, ltr"
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
  Public Function GetAllYear(ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear
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
  Public Function GetDeprData(ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " AND DECODE <>'  '"
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
  Public Function GetSummaryData(ByVal Wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where year = " & Wrkyear & " AND LTR = '  '"
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
  _YEAR     = .Item("YEAR")
  _CODE     = .Item("CODE")
  _LTR      = .Item("LTR")
  _DESC     = .Item("DESC")
  _DECODE   = .Item("DECODE")
  _ASCODE   = .Item("ASCODE")
  _ASPCT    = .Item("ASPCT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("YEAR") =   _YEAR    
.Item("CODE") =   _CODE    
.Item("LTR") =   _LTR     
.Item("DESC") =   _DESC    
.Item("DECODE") =   _DECODE  
.Item("ASCODE") =   _ASCODE  
.Item("ASPCT") =   _ASPCT   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mYEAR  as integer 
Public Property _YEAR  as integer   
    Get
        Return mYEAR
    End Get
    set(byval value as integer)
        mYEAR = value
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

Dim mDECODE as string 
Public Property _DECODE as string   
    Get
        Return mDECODE
    End Get
    set(byval value as string)
        mDECODE = value
    End Set
End Property

Dim mASCODE  as integer 
Public Property _ASCODE  as integer   
    Get
        Return mASCODE
    End Get
    set(byval value as integer)
        mASCODE = value
    End Set
End Property

Dim mASPCT  as integer 
Public Property _ASPCT  as integer   
    Get
        Return mASPCT
    End Get
    set(byval value as integer)
        mASPCT = value
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


