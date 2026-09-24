Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXPROF"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_PRTYPE = string.empty
_PRYEAR  = 0
_PRPERD  = 0
_PRDUE1  = 0
_PRDUE2  = 0
_PRDUE3  = 0
_PRDUE4  = 0
_PRINT = 0
_PRMINI = 0
_PRPENI = 0
_PRSBIL = 0
_PRWAV = 0
_PRPAYC = string.empty
_PRLIEN = 0
_PRGRD1  = 0
_PRGRD2  = 0
_PRGRD3  = 0
_PRGRD4  = 0
_POSTED = string.empty
_PHS = string.empty
_DIST  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkprtype As string, ByVal Wrkpryear As integer, ByVal Wrkphs As string, ByVal Wrkdist As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where prtype = " & "'" & Wrkprtype & "'" & " and pryear = " & Wrkpryear & " and phs = " & "'" & Wrkphs & "'" & " and dist = " & Wrkdist
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
  Public Function PosData(ByVal Wrkprtype As String, ByVal Wrkpryear As Integer, ByVal Wrkphs As String, ByVal Wrkdist As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where prtype = " & "'" & Wrkprtype & "'" & " And pryear = " & Wrkpryear & " And phs = " & "'" & Wrkphs & "'" & " And dist >= " & Wrkdist & " Or prtype = " & "'" & Wrkprtype & "'" & " And pryear = " & Wrkpryear & " And phs > " & "'" & Wrkphs & "'" & " Or prtype = " & "'" & Wrkprtype & "'" & " And pryear > " & Wrkpryear & " Or prtype > " & "'" & Wrkprtype & "'" & " Order by prtype, pryear, phs, dist"
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
  Public Function GetbyTypeYear(wrktype As String, ByVal WrkYear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select  * FROM " & cFileName _
    & " where pryear =" & WrkYear & " AND prtype = '" & wrktype & "' order by prtype,pryear"
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
  _PRTYPE   = .Item("PRTYPE")
  _PRYEAR   = .Item("PRYEAR")
  _PRPERD   = .Item("PRPERD")
  _PRDUE1   = .Item("PRDUE1")
  _PRDUE2   = .Item("PRDUE2")
  _PRDUE3   = .Item("PRDUE3")
  _PRDUE4   = .Item("PRDUE4")
  _PRINT    = .Item("PRINT")
  _PRMINI   = .Item("PRMINI")
  _PRPENI   = .Item("PRPENI")
  _PRSBIL   = .Item("PRSBIL")
  _PRWAV    = .Item("PRWAV")
  _PRPAYC   = .Item("PRPAYC")
  _PRLIEN   = .Item("PRLIEN")
  _PRGRD1   = .Item("PRGRD1")
  _PRGRD2   = .Item("PRGRD2")
  _PRGRD3   = .Item("PRGRD3")
  _PRGRD4   = .Item("PRGRD4")
  _POSTED   = .Item("POSTED")
  _PHS      = .Item("PHS")
  _DIST     = .Item("DIST")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("PRTYPE") =   _PRTYPE  
.Item("PRYEAR") =   _PRYEAR  
.Item("PRPERD") =   _PRPERD  
.Item("PRDUE1") =   _PRDUE1  
.Item("PRDUE2") =   _PRDUE2  
.Item("PRDUE3") =   _PRDUE3  
.Item("PRDUE4") =   _PRDUE4  
.Item("PRINT") =   _PRINT   
.Item("PRMINI") =   _PRMINI  
.Item("PRPENI") =   _PRPENI  
.Item("PRSBIL") =   _PRSBIL  
.Item("PRWAV") =   _PRWAV   
.Item("PRPAYC") =   _PRPAYC  
.Item("PRLIEN") =   _PRLIEN  
.Item("PRGRD1") =   _PRGRD1  
.Item("PRGRD2") =   _PRGRD2  
.Item("PRGRD3") =   _PRGRD3  
.Item("PRGRD4") =   _PRGRD4  
.Item("POSTED") =   _POSTED  
.Item("PHS") =   _PHS     
.Item("DIST") =   _DIST    

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mPRTYPE as string 
Public Property _PRTYPE as string   
    Get
        Return mPRTYPE
    End Get
    set(byval value as string)
        mPRTYPE = value
    End Set
End Property

Dim mPRYEAR  as integer 
Public Property _PRYEAR  as integer   
    Get
        Return mPRYEAR
    End Get
    set(byval value as integer)
        mPRYEAR = value
    End Set
End Property

Dim mPRPERD  as integer 
Public Property _PRPERD  as integer   
    Get
        Return mPRPERD
    End Get
    set(byval value as integer)
        mPRPERD = value
    End Set
End Property

Dim mPRDUE1  as integer 
Public Property _PRDUE1  as integer   
    Get
        Return mPRDUE1
    End Get
    set(byval value as integer)
        mPRDUE1 = value
    End Set
End Property

Dim mPRDUE2  as integer 
Public Property _PRDUE2  as integer   
    Get
        Return mPRDUE2
    End Get
    set(byval value as integer)
        mPRDUE2 = value
    End Set
End Property

Dim mPRDUE3  as integer 
Public Property _PRDUE3  as integer   
    Get
        Return mPRDUE3
    End Get
    set(byval value as integer)
        mPRDUE3 = value
    End Set
End Property

Dim mPRDUE4  as integer 
Public Property _PRDUE4  as integer   
    Get
        Return mPRDUE4
    End Get
    set(byval value as integer)
        mPRDUE4 = value
    End Set
End Property

  Dim mPRINT As Decimal
  Public Property _PRINT As Decimal
    Get
      Return mPRINT
    End Get
    Set(ByVal value As Decimal)
      mPRINT = value
    End Set
  End Property

  Dim mPRMINI As Decimal
  Public Property _PRMINI As Decimal
    Get
      Return mPRMINI
    End Get
    Set(ByVal value As Decimal)
      mPRMINI = value
    End Set
  End Property

  Dim mPRPENI As Decimal
  Public Property _PRPENI As Decimal
    Get
      Return mPRPENI
    End Get
    Set(ByVal value As Decimal)
      mPRPENI = value
    End Set
  End Property

  Dim mPRSBIL As Decimal
  Public Property _PRSBIL As Decimal
    Get
      Return mPRSBIL
    End Get
    Set(ByVal value As Decimal)
      mPRSBIL = value
    End Set
  End Property

  Dim mPRWAV As Decimal
  Public Property _PRWAV As Decimal
    Get
      Return mPRWAV
    End Get
    Set(ByVal value As Decimal)
      mPRWAV = value
    End Set
  End Property

  Dim mPRPAYC As String
  Public Property _PRPAYC As String
    Get
      Return mPRPAYC
    End Get
    Set(ByVal value As String)
      mPRPAYC = value
    End Set
  End Property

  Dim mPRLIEN As Decimal
  Public Property _PRLIEN As Decimal
    Get
      Return mPRLIEN
    End Get
    Set(ByVal value As Decimal)
      mPRLIEN = value
    End Set
  End Property

Dim mPRGRD1  as integer 
Public Property _PRGRD1  as integer   
    Get
        Return mPRGRD1
    End Get
    set(byval value as integer)
        mPRGRD1 = value
    End Set
End Property

Dim mPRGRD2  as integer 
Public Property _PRGRD2  as integer   
    Get
        Return mPRGRD2
    End Get
    set(byval value as integer)
        mPRGRD2 = value
    End Set
End Property

Dim mPRGRD3  as integer 
Public Property _PRGRD3  as integer   
    Get
        Return mPRGRD3
    End Get
    set(byval value as integer)
        mPRGRD3 = value
    End Set
End Property

Dim mPRGRD4  as integer 
Public Property _PRGRD4  as integer   
    Get
        Return mPRGRD4
    End Get
    set(byval value as integer)
        mPRGRD4 = value
    End Set
End Property

Dim mPOSTED as string 
Public Property _POSTED as string   
    Get
        Return mPOSTED
    End Get
    set(byval value as string)
        mPOSTED = value
    End Set
End Property

Dim mPHS as string 
Public Property _PHS as string   
    Get
        Return mPHS
    End Get
    set(byval value as string)
        mPHS = value
    End Set
End Property

Dim mDIST  as integer 
Public Property _DIST  as integer   
    Get
        Return mDIST
    End Get
    set(byval value as integer)
        mDIST = value
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


