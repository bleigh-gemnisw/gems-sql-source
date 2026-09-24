Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTBREAK"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_BTYPE = string.empty
_BDESC1 = string.empty
_BPCT1 = 0
_BDESC2 = string.empty
_BPCT2 = 0
_BDESC3 = string.empty
_BPCT3 = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkbtype As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where btype = " & "'" & Wrkbtype & "'"
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
  Public Function PosData(ByVal Wrkbtype As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where btype >= " & "'" & Wrkbtype & "'" & " Order by btype"
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
  _BTYPE    = .Item("BTYPE")
  _BDESC1   = .Item("BDESC1")
  _BPCT1    = .Item("BPCT1")
  _BDESC2   = .Item("BDESC2")
  _BPCT2    = .Item("BPCT2")
  _BDESC3   = .Item("BDESC3")
  _BPCT3    = .Item("BPCT3")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("BTYPE") =   _BTYPE   
.Item("BDESC1") =   _BDESC1  
.Item("BPCT1") =   _BPCT1   
.Item("BDESC2") =   _BDESC2  
.Item("BPCT2") =   _BPCT2   
.Item("BDESC3") =   _BDESC3  
.Item("BPCT3") =   _BPCT3   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mBTYPE as string 
Public Property _BTYPE as string   
    Get
        Return mBTYPE
    End Get
    set(byval value as string)
        mBTYPE = value
    End Set
End Property

Dim mBDESC1 as string 
Public Property _BDESC1 as string   
    Get
        Return mBDESC1
    End Get
    set(byval value as string)
        mBDESC1 = value
    End Set
End Property

  Dim mBPCT1 As Decimal
  Public Property _BPCT1 As Decimal
    Get
      Return mBPCT1
    End Get
    Set(ByVal value As Decimal)
      mBPCT1 = value
    End Set
  End Property

  Dim mBDESC2 As String
  Public Property _BDESC2 As String
    Get
      Return mBDESC2
    End Get
    Set(ByVal value As String)
      mBDESC2 = value
    End Set
  End Property

  Dim mBPCT2 As Decimal
  Public Property _BPCT2 As Decimal
    Get
      Return mBPCT2
    End Get
    Set(ByVal value As Decimal)
      mBPCT2 = value
    End Set
  End Property

  Dim mBDESC3 As String
  Public Property _BDESC3 As String
    Get
      Return mBDESC3
    End Get
    Set(ByVal value As String)
      mBDESC3 = value
    End Set
  End Property

  Dim mBPCT3 As Decimal
  Public Property _BPCT3 As Decimal
    Get
      Return mBPCT3
    End Get
    Set(ByVal value As Decimal)
      mBPCT3 = value
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


