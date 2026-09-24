Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "UTRATEAS"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_RATYPE = string.empty
_RACODE = string.empty
_RADESC = string.empty
_RAPCT = 0
_RAMNTH = 0
_RANOYR = 0
_RAFOOT = 0
_RAPVAL = 0
_RAUNIT = 0
_RAACRE = 0
_RAYR1 = string.empty
_RAMORT = string.empty
_RABOND = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkratype As string, ByVal Wrkracode As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where ratype = " & "'" & Wrkratype & "'" & " and racode = " & "'" & Wrkracode & "'"
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

    StrSQL = "Select " & WrkTop & "* from " & cFileName & " where ratype='" & WrkType & "'"
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
  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("", "")
    Return ds
  End Function
  Public Function PosData(ByVal Wrkratype As String, ByVal Wrkracode As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where ratype = " & "'" & Wrkratype & "'" & " And racode >= " & "'" & Wrkracode & "'" & " Or ratype > " & "'" & Wrkratype & "'" & " Order by ratype, racode"
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
  _RATYPE   = .Item("RATYPE")
  _RACODE   = .Item("RACODE")
  _RADESC   = .Item("RADESC")
  _RAPCT    = .Item("RAPCT")
  _RAMNTH   = .Item("RAMNTH")
  _RANOYR   = .Item("RANOYR")
  _RAFOOT   = .Item("RAFOOT")
  _RAPVAL   = .Item("RAPVAL")
  _RAUNIT   = .Item("RAUNIT")
  _RAACRE   = .Item("RAACRE")
  _RAYR1    = .Item("RAYR1")
  _RAMORT   = .Item("RAMORT")
  _RABOND   = .Item("RABOND")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("RATYPE") =   _RATYPE  
.Item("RACODE") =   _RACODE  
.Item("RADESC") =   _RADESC  
.Item("RAPCT") =   _RAPCT   
.Item("RAMNTH") =   _RAMNTH  
.Item("RANOYR") =   _RANOYR  
.Item("RAFOOT") =   _RAFOOT  
.Item("RAPVAL") =   _RAPVAL  
.Item("RAUNIT") =   _RAUNIT  
.Item("RAACRE") =   _RAACRE  
.Item("RAYR1") =   _RAYR1   
.Item("RAMORT") =   _RAMORT  
.Item("RABOND") =   _RABOND  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mRATYPE as string 
Public Property _RATYPE as string   
    Get
        Return mRATYPE
    End Get
    set(byval value as string)
        mRATYPE = value
    End Set
End Property

Dim mRACODE as string 
Public Property _RACODE as string   
    Get
        Return mRACODE
    End Get
    set(byval value as string)
        mRACODE = value
    End Set
End Property

Dim mRADESC as string 
Public Property _RADESC as string   
    Get
        Return mRADESC
    End Get
    set(byval value as string)
        mRADESC = value
    End Set
End Property

  Dim mRAPCT As Decimal
  Public Property _RAPCT As Decimal
    Get
      Return mRAPCT
    End Get
    Set(ByVal value As Decimal)
      mRAPCT = value
    End Set
  End Property

  Dim mRAMNTH As Integer
  Public Property _RAMNTH As Integer
    Get
      Return mRAMNTH
    End Get
    Set(ByVal value As Integer)
      mRAMNTH = value
    End Set
  End Property

  Dim mRANOYR As Integer
  Public Property _RANOYR As Integer
    Get
      Return mRANOYR
    End Get
    Set(ByVal value As Integer)
      mRANOYR = value
    End Set
  End Property

  Dim mRAFOOT As Decimal
  Public Property _RAFOOT As Decimal
    Get
      Return mRAFOOT
    End Get
    Set(ByVal value As Decimal)
      mRAFOOT = value
    End Set
  End Property

  Dim mRAPVAL As Decimal
  Public Property _RAPVAL As Decimal
    Get
      Return mRAPVAL
    End Get
    Set(ByVal value As Decimal)
      mRAPVAL = value
    End Set
  End Property

  Dim mRAUNIT As Decimal
  Public Property _RAUNIT As Decimal
    Get
      Return mRAUNIT
    End Get
    Set(ByVal value As Decimal)
      mRAUNIT = value
    End Set
  End Property

  Dim mRAACRE As Decimal
  Public Property _RAACRE As Decimal
    Get
      Return mRAACRE
    End Get
    Set(ByVal value As Decimal)
      mRAACRE = value
    End Set
  End Property

  Dim mRAYR1 As String
  Public Property _RAYR1 As String
    Get
      Return mRAYR1
    End Get
    Set(ByVal value As String)
      mRAYR1 = value
    End Set
  End Property

  Dim mRAMORT As String
  Public Property _RAMORT As String
    Get
      Return mRAMORT
    End Get
    Set(ByVal value As String)
      mRAMORT = value
    End Set
  End Property

  Dim mRABOND As Decimal
  Public Property _RABOND As Decimal
    Get
      Return mRABOND
    End Get
    Set(ByVal value As Decimal)
      mRABOND = value
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


