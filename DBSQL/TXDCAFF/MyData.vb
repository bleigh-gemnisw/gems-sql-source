Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXDCAFF"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_LISTNO  = 0
_YEAR  = 0
_OWNAME = string.empty
_BUNAME = string.empty
_LOCNO = string.empty
_LOC = string.empty
_TRANDT  = 0
_TRANTY = string.empty
_NAME = string.empty
_ADDR = string.empty
_CITY = string.empty
_STATE = string.empty
_ZIP5  = 0
_ZIP4  = 0
_SIGNED = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As integer, ByVal Wrkyear As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear
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
Public Function PosData(ByVal Wrklistno As integer, ByVal Wrkyear As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year >= " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year"
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
  _LISTNO   = .Item("LIST#")
  _YEAR     = .Item("YEAR")
  _OWNAME   = .Item("OWNAME")
  _BUNAME   = .Item("BUNAME")
  _LOCNO    = .Item("LOC#")
  _LOC      = .Item("LOC")
  _TRANDT   = .Item("TRANDT")
  _TRANTY   = .Item("TRANTY")
  _NAME     = .Item("NAME")
  _ADDR     = .Item("ADDR")
  _CITY     = .Item("CITY")
  _STATE    = .Item("STATE")
  _ZIP5     = .Item("ZIP5")
  _ZIP4     = .Item("ZIP4")
  _SIGNED   = .Item("SIGNED")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("LIST#") =   _LISTNO  
.Item("YEAR") =   _YEAR    
.Item("OWNAME") =   _OWNAME  
.Item("BUNAME") =   _BUNAME  
.Item("LOC#") =   _LOCNO   
.Item("LOC") =   _LOC     
.Item("TRANDT") =   _TRANDT  
.Item("TRANTY") =   _TRANTY  
.Item("NAME") =   _NAME    
.Item("ADDR") =   _ADDR    
.Item("CITY") =   _CITY    
.Item("STATE") =   _STATE   
.Item("ZIP5") =   _ZIP5    
.Item("ZIP4") =   _ZIP4    
.Item("SIGNED") =   _SIGNED  

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

Dim mOWNAME as string 
Public Property _OWNAME as string   
    Get
        Return mOWNAME
    End Get
    set(byval value as string)
        mOWNAME = value
    End Set
End Property

Dim mBUNAME as string 
Public Property _BUNAME as string   
    Get
        Return mBUNAME
    End Get
    set(byval value as string)
        mBUNAME = value
    End Set
End Property

Dim mLOCNO as string 
Public Property _LOCNO as string   
    Get
        Return mLOCNO
    End Get
    set(byval value as string)
        mLOCNO = value
    End Set
End Property

Dim mLOC as string 
Public Property _LOC as string   
    Get
        Return mLOC
    End Get
    set(byval value as string)
        mLOC = value
    End Set
End Property

Dim mTRANDT  as integer 
Public Property _TRANDT  as integer   
    Get
        Return mTRANDT
    End Get
    set(byval value as integer)
        mTRANDT = value
    End Set
End Property

Dim mTRANTY as string 
Public Property _TRANTY as string   
    Get
        Return mTRANTY
    End Get
    set(byval value as string)
        mTRANTY = value
    End Set
End Property

Dim mNAME as string 
Public Property _NAME as string   
    Get
        Return mNAME
    End Get
    set(byval value as string)
        mNAME = value
    End Set
End Property

Dim mADDR as string 
Public Property _ADDR as string   
    Get
        Return mADDR
    End Get
    set(byval value as string)
        mADDR = value
    End Set
End Property

Dim mCITY as string 
Public Property _CITY as string   
    Get
        Return mCITY
    End Get
    set(byval value as string)
        mCITY = value
    End Set
End Property

Dim mSTATE as string 
Public Property _STATE as string   
    Get
        Return mSTATE
    End Get
    set(byval value as string)
        mSTATE = value
    End Set
End Property

Dim mZIP5  as integer 
Public Property _ZIP5  as integer   
    Get
        Return mZIP5
    End Get
    set(byval value as integer)
        mZIP5 = value
    End Set
End Property

Dim mZIP4  as integer 
Public Property _ZIP4  as integer   
    Get
        Return mZIP4
    End Get
    set(byval value as integer)
        mZIP4 = value
    End Set
End Property

Dim mSIGNED as string 
Public Property _SIGNED as string   
    Get
        Return mSIGNED
    End Get
    set(byval value as string)
        mSIGNED = value
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


