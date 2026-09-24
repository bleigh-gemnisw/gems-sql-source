Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXEXEM"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TEXEM = string.empty
_FILL6 = string.empty
_TFIXAM  = 0
_TPERC  = 0
_TASS  = 0
_FILL62 = string.empty
_TDESC = string.empty
_TXSCD = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrktexem As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where texem = " & "'" & Wrktexem & "'"
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
  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("")
    Return ds
  End Function
  Public Function PosData(ByVal Wrktexem As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where texem >= " & "'" & Wrktexem & "'" & " Order by texem"
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
  _TEXEM    = .Item("TEXEM")
  _FILL6    = .Item("FILL6")
  _TFIXAM   = .Item("TFIXAM")
  _TPERC    = .Item("TPERC")
  _TASS     = .Item("TASS")
  _FILL62   = .Item("FILL62")
  _TDESC    = .Item("TDESC")
  _TXSCD    = .Item("TXSCD")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("TEXEM") =   _TEXEM   
.Item("FILL6") =   _FILL6   
.Item("TFIXAM") =   _TFIXAM  
.Item("TPERC") =   _TPERC   
.Item("TASS") =   _TASS    
.Item("FILL62") =   _FILL62  
.Item("TDESC") =   _TDESC   
.Item("TXSCD") =   _TXSCD   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mTEXEM as string 
Public Property _TEXEM as string   
    Get
        Return mTEXEM
    End Get
    set(byval value as string)
        mTEXEM = value
    End Set
End Property

Dim mFILL6 as string 
Public Property _FILL6 as string   
    Get
        Return mFILL6
    End Get
    set(byval value as string)
        mFILL6 = value
    End Set
End Property

Dim mTFIXAM  as long
Public Property _TFIXAM  as long  
    Get
        Return mTFIXAM
    End Get
    set(byval value as long)
        mTFIXAM = value
    End Set
End Property

Dim mTPERC  as integer 
Public Property _TPERC  as integer   
    Get
        Return mTPERC
    End Get
    set(byval value as integer)
        mTPERC = value
    End Set
End Property

Dim mTASS  as long
Public Property _TASS  as long  
    Get
        Return mTASS
    End Get
    set(byval value as long)
        mTASS = value
    End Set
End Property

Dim mFILL62 as string 
Public Property _FILL62 as string   
    Get
        Return mFILL62
    End Get
    set(byval value as string)
        mFILL62 = value
    End Set
End Property
  Dim mTDESC As String
  Public Property _TDESC As String
    Get
      Return mTDESC
    End Get
    Set(ByVal value As String)
      mTDESC = value
    End Set
  End Property

Dim mTXSCD as string 
Public Property _TXSCD as string   
    Get
        Return mTXSCD
    End Get
    set(byval value as string)
        mTXSCD = value
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


