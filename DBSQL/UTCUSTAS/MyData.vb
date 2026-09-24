Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTCUSTAS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_CAACCT  = 0
_CATYPE = string.empty
_CAADJ = 0
_CADEF = 0
_CADEP = 0
_CAAMT = 0
_CAPNO = 0
_CAOVR = 0
_CALAT  = 0
_CAUNIF  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkcaacct As integer, ByVal Wrkcatype As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where caacct = " & Wrkcaacct & " and catype = " & "'" & Wrkcatype & "'"
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
Public Function PosData(ByVal Wrkcaacct As integer, ByVal Wrkcatype As string) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where caacct = " & Wrkcaacct & " And catype >= " & "'" & Wrkcatype & "'" & " Or caacct > " & Wrkcaacct & " Order by caacct, catype"
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
  Public Sub DeleteListNo(ByVal wrklist As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE caacct = " & wrklist

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
  _CAACCT   = .Item("CAACCT")
  _CATYPE   = .Item("CATYPE")
  _CAADJ    = .Item("CAADJ")
  _CADEF    = .Item("CADEF")
  _CADEP    = .Item("CADEP")
  _CAAMT    = .Item("CAAMT")
  _CAPNO    = .Item("CAPNO")
  _CAOVR    = .Item("CAOVR")
  _CALAT    = .Item("CALAT")
  _CAUNIF   = .Item("CAUNIF")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("CAACCT") =   _CAACCT  
.Item("CATYPE") =   _CATYPE  
.Item("CAADJ") =   _CAADJ   
.Item("CADEF") =   _CADEF   
.Item("CADEP") =   _CADEP   
.Item("CAAMT") =   _CAAMT   
.Item("CAPNO") =   _CAPNO   
.Item("CAOVR") =   _CAOVR   
.Item("CALAT") =   _CALAT   
.Item("CAUNIF") =   _CAUNIF  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mCAACCT  as integer 
Public Property _CAACCT  as integer   
    Get
        Return mCAACCT
    End Get
    set(byval value as integer)
        mCAACCT = value
    End Set
End Property

Dim mCATYPE as string 
Public Property _CATYPE as string   
    Get
        Return mCATYPE
    End Get
    set(byval value as string)
        mCATYPE = value
    End Set
End Property

  Dim mCAADJ As Decimal
  Public Property _CAADJ As Decimal
    Get
      Return mCAADJ
    End Get
    Set(ByVal value As Decimal)
      mCAADJ = value
    End Set
  End Property

  Dim mCADEF As Decimal
  Public Property _CADEF As Decimal
    Get
      Return mCADEF
    End Get
    Set(ByVal value As Decimal)
      mCADEF = value
    End Set
  End Property

  Dim mCADEP As Integer
  Public Property _CADEP As Integer
    Get
      Return mCADEP
    End Get
    Set(ByVal value As Integer)
      mCADEP = value
    End Set
  End Property

  Dim mCAAMT As Decimal
  Public Property _CAAMT As Decimal
    Get
      Return mCAAMT
    End Get
    Set(ByVal value As Decimal)
      mCAAMT = value
    End Set
  End Property

  Dim mCAPNO As Integer
  Public Property _CAPNO As Integer
    Get
      Return mCAPNO
    End Get
    Set(ByVal value As Integer)
      mCAPNO = value
    End Set
  End Property

  Dim mCAOVR As Decimal
  Public Property _CAOVR As Decimal
    Get
      Return mCAOVR
    End Get
    Set(ByVal value As Decimal)
      mCAOVR = value
    End Set
  End Property

Dim mCALAT  as integer 
Public Property _CALAT  as integer   
    Get
        Return mCALAT
    End Get
    set(byval value as integer)
        mCALAT = value
    End Set
End Property

Dim mCAUNIF  as integer 
Public Property _CAUNIF  as integer   
    Get
        Return mCAUNIF
    End Get
    set(byval value as integer)
        mCAUNIF = value
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


