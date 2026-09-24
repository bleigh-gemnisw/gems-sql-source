Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTMETER"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_MTTYPE = string.empty
_MTSIZE = string.empty
_MTDESC = string.empty
_MTMIN = 0
_MTMINC = string.empty
_MTEDU = 0
_MTBLCD = string.empty
_MTMULT = 0
_MTPCT = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkmttype As string, ByVal Wrkmtsize As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where mttype = " & "'" & Wrkmttype & "'" & " and mtsize = " & "'" & Wrkmtsize & "'"
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
    ds = PosData("", "")
    Return ds
  End Function
  Public Function GetAllType(ByVal WrkType As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where mttype='" & WrkType & "'"
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

  Public Function PosData(ByVal Wrkmttype As String, ByVal Wrkmtsize As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where mttype = " & "'" & Wrkmttype & "'" & " And mtsize >= " & "'" & Wrkmtsize & "'" & " Or mttype > " & "'" & Wrkmttype & "'" & " Order by mttype, mtsize"
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
  _MTTYPE   = .Item("MTTYPE")
  _MTSIZE   = .Item("MTSIZE")
  _MTDESC   = .Item("MTDESC")
  _MTMIN    = .Item("MTMIN")
  _MTMINC   = .Item("MTMINC")
  _MTEDU    = .Item("MTEDU")
  _MTBLCD   = .Item("MTBLCD")
  _MTMULT   = .Item("MTMULT")
  _MTPCT    = .Item("MTPCT")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("MTTYPE") =   _MTTYPE  
.Item("MTSIZE") =   _MTSIZE  
.Item("MTDESC") =   _MTDESC  
.Item("MTMIN") =   _MTMIN   
.Item("MTMINC") =   _MTMINC  
.Item("MTEDU") =   _MTEDU   
.Item("MTBLCD") =   _MTBLCD  
.Item("MTMULT") =   _MTMULT  
.Item("MTPCT") =   _MTPCT   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mMTTYPE as string 
Public Property _MTTYPE as string   
    Get
        Return mMTTYPE
    End Get
    set(byval value as string)
        mMTTYPE = value
    End Set
End Property

Dim mMTSIZE as string 
Public Property _MTSIZE as string   
    Get
        Return mMTSIZE
    End Get
    set(byval value as string)
        mMTSIZE = value
    End Set
End Property

Dim mMTDESC as string 
Public Property _MTDESC as string   
    Get
        Return mMTDESC
    End Get
    set(byval value as string)
        mMTDESC = value
    End Set
End Property

  Dim mMTMIN As Decimal
  Public Property _MTMIN As Decimal
    Get
      Return mMTMIN
    End Get
    Set(ByVal value As Decimal)
      mMTMIN = value
    End Set
  End Property

  Dim mMTMINC As String
  Public Property _MTMINC As String
    Get
      Return mMTMINC
    End Get
    Set(ByVal value As String)
      mMTMINC = value
    End Set
  End Property

  Dim mMTEDU As Decimal
  Public Property _MTEDU As Decimal
    Get
      Return mMTEDU
    End Get
    Set(ByVal value As Decimal)
      mMTEDU = value
    End Set
  End Property

  Dim mMTBLCD As String
  Public Property _MTBLCD As String
    Get
      Return mMTBLCD
    End Get
    Set(ByVal value As String)
      mMTBLCD = value
    End Set
  End Property

  Dim mMTMULT As Integer
  Public Property _MTMULT As Integer
    Get
      Return mMTMULT
    End Get
    Set(ByVal value As Integer)
      mMTMULT = value
    End Set
  End Property

  Dim mMTPCT As Decimal
  Public Property _MTPCT As Decimal
    Get
      Return mMTPCT
    End Get
    Set(ByVal value As Decimal)
      mMTPCT = value
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


