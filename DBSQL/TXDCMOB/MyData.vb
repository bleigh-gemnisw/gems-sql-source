Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCMOB"
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
_MAKE = string.empty
_VYEAR  = 0
_MODEL = string.empty
_VINNO = string.empty
_LENGTH  = 0
_WIDTH  = 0
_BEDRMS  = 0
_BATHS  = 0
_VALUE  = 0

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


    RecordNotFound = False

    StrSQL = "Select  * FROM " & cFileName _
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
  _MAKE     = .Item("MAKE")
  _VYEAR    = .Item("VYEAR")
  _MODEL    = .Item("MODEL")
  _VINNO    = .Item("VINNO")
  _LENGTH   = .Item("LENGTH")
  _WIDTH    = .Item("WIDTH")
  _BEDRMS   = .Item("BEDRMS")
  _BATHS    = .Item("BATHS")
  _VALUE    = .Item("VALUE")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("SEQNO") =   _SEQNO   
.Item("MAKE") =   _MAKE    
.Item("VYEAR") =   _VYEAR   
.Item("MODEL") =   _MODEL   
.Item("VINNO") =   _VINNO   
.Item("LENGTH") =   _LENGTH  
.Item("WIDTH") =   _WIDTH   
.Item("BEDRMS") =   _BEDRMS  
.Item("BATHS") =   _BATHS   
.Item("VALUE") =   _VALUE   

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

Dim mMAKE as string 
Public Property _MAKE as string   
    Get
        Return mMAKE
    End Get
    set(byval value as string)
        mMAKE = value
    End Set
End Property

Dim mVYEAR  as integer 
Public Property _VYEAR  as integer   
    Get
        Return mVYEAR
    End Get
    set(byval value as integer)
        mVYEAR = value
    End Set
End Property

Dim mMODEL as string 
Public Property _MODEL as string   
    Get
        Return mMODEL
    End Get
    set(byval value as string)
        mMODEL = value
    End Set
End Property

Dim mVINNO as string 
Public Property _VINNO as string   
    Get
        Return mVINNO
    End Get
    set(byval value as string)
        mVINNO = value
    End Set
End Property

Dim mLENGTH  as integer 
Public Property _LENGTH  as integer   
    Get
        Return mLENGTH
    End Get
    set(byval value as integer)
        mLENGTH = value
    End Set
End Property

Dim mWIDTH  as integer 
Public Property _WIDTH  as integer   
    Get
        Return mWIDTH
    End Get
    set(byval value as integer)
        mWIDTH = value
    End Set
End Property

Dim mBEDRMS  as integer 
Public Property _BEDRMS  as integer   
    Get
        Return mBEDRMS
    End Get
    set(byval value as integer)
        mBEDRMS = value
    End Set
End Property

Dim mBATHS  as integer 
Public Property _BATHS  as integer   
    Get
        Return mBATHS
    End Get
    set(byval value as integer)
        mBATHS = value
    End Set
End Property

Dim mVALUE  as long
Public Property _VALUE  as long  
    Get
        Return mVALUE
    End Get
    set(byval value as long)
        mVALUE = value
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


