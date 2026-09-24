Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXCODE"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_TCCODE  = 0
_TCTYPE = string.empty
_TCDESC = string.empty
_TCOPMC  = 0
_TCGRP = string.empty
_TCSGRP = string.empty

End Sub
  Public Sub GetOneRecordP(ByVal Wrktccode As integer, ByVal Wrktctype As string)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where tccode = " & Wrktccode & " and tctype = " & "'" & Wrktctype & "'"
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
  Public Function GetAllType(ByVal WrkType As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where tctype='" & WrkType & "'"
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
  Public Function PosData(ByVal Wrktccode As Integer, ByVal Wrktctype As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where tccode = " & Wrktccode & " And tctype >= " & "'" & Wrktctype & "'" & " Or tccode > " & Wrktccode & " Order by tccode, tctype"
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
  _TCCODE   = .Item("TCCODE")
  _TCTYPE   = .Item("TCTYPE")
  _TCDESC   = .Item("TCDESC")
  _TCOPMC   = .Item("TCOPMC")
  _TCGRP    = .Item("TCGRP")
  _TCSGRP   = .Item("TCSGRP")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("TCCODE") =   _TCCODE  
.Item("TCTYPE") =   _TCTYPE  
.Item("TCDESC") =   _TCDESC  
.Item("TCOPMC") =   _TCOPMC  
.Item("TCGRP") =   _TCGRP   
.Item("TCSGRP") =   _TCSGRP  

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mTCCODE  as integer 
Public Property _TCCODE  as integer   
    Get
        Return mTCCODE
    End Get
    set(byval value as integer)
        mTCCODE = value
    End Set
End Property

Dim mTCTYPE as string 
Public Property _TCTYPE as string   
    Get
        Return mTCTYPE
    End Get
    Set(ByVal value As String)
      mTCTYPE = value
    End Set
  End Property

Dim mTCDESC as string 
Public Property _TCDESC as string   
    Get
        Return mTCDESC
    End Get
    Set(ByVal value As String)
      mTCDESC = value
    End Set
  End Property

Dim mTCOPMC  as integer 
Public Property _TCOPMC  as integer   
    Get
        Return mTCOPMC
    End Get
    set(byval value as integer)
        mTCOPMC = value
    End Set
End Property

Dim mTCGRP as string 
Public Property _TCGRP as string   
    Get
        Return mTCGRP
    End Get
    Set(ByVal value As String)
      mTCGRP = value
    End Set
  End Property

Dim mTCSGRP as string 
Public Property _TCSGRP as string   
    Get
        Return mTCSGRP
    End Get
    Set(ByVal value As String)
      mTCSGRP = value
    End Set
  End Property

Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value As Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value As Boolean)
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
    Set(ByVal value As String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


