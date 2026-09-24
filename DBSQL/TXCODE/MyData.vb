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
  Public Sub ClearFields()
    _TCCODE = 0
    _TCTYPE = String.Empty
    _TCDESC = String.Empty
    _TCOPMC = 0
    _TCGRP = String.Empty
    _TCSGRP = String.Empty
    _MVINST = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrktccode As Integer, ByVal Wrktctype As String)
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
        ClearFields()
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
      _TCCODE = .Item("TCCODE")
      _TCTYPE = .Item("TCTYPE")
      _TCDESC = .Item("TCDESC")
      _TCOPMC = .Item("TCOPMC")
      _TCGRP = .Item("TCGRP")
      _TCSGRP = .Item("TCSGRP")
      _MVINST = .Item("MVINST")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("TCCODE") = _TCCODE
      .Item("TCTYPE") = _TCTYPE
      .Item("TCDESC") = _TCDESC
      .Item("TCOPMC") = _TCOPMC
      .Item("TCGRP") = _TCGRP
      .Item("TCSGRP") = _TCSGRP
      .Item("MVINST") = _MVINST
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mTCCODE As Integer
  Public Property _TCCODE As Integer
    Get
      Return mTCCODE
    End Get
    Set(ByVal value As Integer)
      mTCCODE = value
    End Set
  End Property

  Dim mTCTYPE As String
  Public Property _TCTYPE As String
    Get
      Return mTCTYPE
    End Get
    Set(ByVal value As String)
      mTCTYPE = value
    End Set
  End Property

  Dim mTCDESC As String
  Public Property _TCDESC As String
    Get
      Return mTCDESC
    End Get
    Set(ByVal value As String)
      mTCDESC = value
    End Set
  End Property

  Dim mTCOPMC As Integer
  Public Property _TCOPMC As Integer
    Get
      Return mTCOPMC
    End Get
    Set(ByVal value As Integer)
      mTCOPMC = value
    End Set
  End Property

  Dim mTCGRP As String
  Public Property _TCGRP As String
    Get
      Return mTCGRP
    End Get
    Set(ByVal value As String)
      mTCGRP = value
    End Set
  End Property

  Dim mTCSGRP As String
  Public Property _TCSGRP As String
    Get
      Return mTCSGRP
    End Get
    Set(ByVal value As String)
      mTCSGRP = value
    End Set
  End Property
  Dim mMVINST As String
  Public Property _MVINST As String
    Get
      Return mMVINST
    End Get
    Set(ByVal value As String)
      mMVINST = value
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


