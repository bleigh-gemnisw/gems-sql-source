Imports System.Data
Imports System.Data.SqlClient
Public Class TXPROF
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const MyFileName As String = "TXPROF"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub
#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Wrkprtype As String, ByVal Wrkpryear As Integer, ByVal Wrkphs As String, ByVal Wrkdist As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & MyFileName & " where prtype = " & "'" & Wrkprtype & "'" & " and pryear = " & Wrkpryear & " and phs = " & "'" & Wrkphs & "'" & " and dist = " & Wrkdist
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, MyFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
      Else
        GetFields(ds)
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Sub AddOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow

    da.InsertCommand = CmdBldr.GetInsertCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    dr = ds.Tables(0).NewRow
    ds.Tables(0).Rows.Add(dr)
    PutFields(ds)
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub DeleteOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet

    da.DeleteCommand = CmdBldr.GetDeleteCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    ds.Tables(0).Rows(0).Delete()
    da.Update(ds, MyFileName)
    ds = Nothing
  End Sub
  Public Sub UpdateOneRecordP()
    Dim CmdBldr As SqlCommandBuilder = New SqlCommandBuilder(da)
    Dim ds As DataSet = New DataSet
    da.UpdateCommand = CmdBldr.GetUpdateCommand
    CmdBldr.RefreshSchema()
    da.Fill(ds, MyFileName)
    PutFields(ds)
    da.Update(ds, MyFileName)
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
      _PRTYPE = .Item("PRTYPE")
      _PRYEAR = .Item("PRYEAR")
      _PRPERD = .Item("PRPERD")
      _PRDUE1 = .Item("PRDUE1")
      _PRDUE2 = .Item("PRDUE2")
      _PRDUE3 = .Item("PRDUE3")
      _PRDUE4 = .Item("PRDUE4")
      _PRINT = .Item("PRINT")
      _PRMINI = .Item("PRMINI")
      _PRPENI = .Item("PRPENI")
      _PRSBIL = .Item("PRSBIL")
      _PRWAV = .Item("PRWAV")
      _PRPAYC = .Item("PRPAYC")
      _PRLIEN = .Item("PRLIEN")
      _PRGRD1 = .Item("PRGRD1")
      _PRGRD2 = .Item("PRGRD2")
      _PRGRD3 = .Item("PRGRD3")
      _PRGRD4 = .Item("PRGRD4")
      _POSTED = .Item("POSTED")
      _PHS = .Item("PHS")
      _DIST = .Item("DIST")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("PRTYPE") = _PRTYPE
      .Item("PRYEAR") = _PRYEAR
      .Item("PRPERD") = _PRPERD
      .Item("PRDUE1") = _PRDUE1
      .Item("PRDUE2") = _PRDUE2
      .Item("PRDUE3") = _PRDUE3
      .Item("PRDUE4") = _PRDUE4
      .Item("PRINT") = _PRINT
      .Item("PRMINI") = _PRMINI
      .Item("PRPENI") = _PRPENI
      .Item("PRSBIL") = _PRSBIL
      .Item("PRWAV") = _PRWAV
      .Item("PRPAYC") = _PRPAYC
      .Item("PRLIEN") = _PRLIEN
      .Item("PRGRD1") = _PRGRD1
      .Item("PRGRD2") = _PRGRD2
      .Item("PRGRD3") = _PRGRD3
      .Item("PRGRD4") = _PRGRD4
      .Item("POSTED") = _POSTED
      .Item("PHS") = _PHS
      .Item("DIST") = _DIST

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mPRTYPE As String
  Public Property _PRTYPE As String
    Get
      Return mPRTYPE
    End Get
    Set(ByVal value As String)
      mPRTYPE = value
    End Set
  End Property

  Dim mPRYEAR As Integer
  Public Property _PRYEAR As Integer
    Get
      Return mPRYEAR
    End Get
    Set(ByVal value As Integer)
      mPRYEAR = value
    End Set
  End Property

  Dim mPRPERD As Integer
  Public Property _PRPERD As Integer
    Get
      Return mPRPERD
    End Get
    Set(ByVal value As Integer)
      mPRPERD = value
    End Set
  End Property

  Dim mPRDUE1 As Integer
  Public Property _PRDUE1 As Integer
    Get
      Return mPRDUE1
    End Get
    Set(ByVal value As Integer)
      mPRDUE1 = value
    End Set
  End Property

  Dim mPRDUE2 As Integer
  Public Property _PRDUE2 As Integer
    Get
      Return mPRDUE2
    End Get
    Set(ByVal value As Integer)
      mPRDUE2 = value
    End Set
  End Property

  Dim mPRDUE3 As Integer
  Public Property _PRDUE3 As Integer
    Get
      Return mPRDUE3
    End Get
    Set(ByVal value As Integer)
      mPRDUE3 = value
    End Set
  End Property

  Dim mPRDUE4 As Integer
  Public Property _PRDUE4 As Integer
    Get
      Return mPRDUE4
    End Get
    Set(ByVal value As Integer)
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

  Dim mPRGRD1 As Integer
  Public Property _PRGRD1 As Integer
    Get
      Return mPRGRD1
    End Get
    Set(ByVal value As Integer)
      mPRGRD1 = value
    End Set
  End Property

  Dim mPRGRD2 As Integer
  Public Property _PRGRD2 As Integer
    Get
      Return mPRGRD2
    End Get
    Set(ByVal value As Integer)
      mPRGRD2 = value
    End Set
  End Property

  Dim mPRGRD3 As Integer
  Public Property _PRGRD3 As Integer
    Get
      Return mPRGRD3
    End Get
    Set(ByVal value As Integer)
      mPRGRD3 = value
    End Set
  End Property

  Dim mPRGRD4 As Integer
  Public Property _PRGRD4 As Integer
    Get
      Return mPRGRD4
    End Get
    Set(ByVal value As Integer)
      mPRGRD4 = value
    End Set
  End Property

  Dim mPOSTED As String
  Public Property _POSTED As String
    Get
      Return mPOSTED
    End Get
    Set(ByVal value As String)
      mPOSTED = value
    End Set
  End Property

  Dim mPHS As String
  Public Property _PHS As String
    Get
      Return mPHS
    End Get
    Set(ByVal value As String)
      mPHS = value
    End Set
  End Property

  Dim mDIST As Integer
  Public Property _DIST As Integer
    Get
      Return mDIST
    End Get
    Set(ByVal value As Integer)
      mDIST = value
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
