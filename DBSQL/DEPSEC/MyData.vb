Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "DEPSEC"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Usrprf As String, ByVal Fund As Integer, ByVal Sfund As Integer, Dept As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where USRPRF='" & Usrprf & "' and FUND=" & Fund & " and SFUND=" & Sfund &
    " and DEPT=" & Dept
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
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
  Public Function PosData(ByVal Usrprf As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where USRPRF>='" & Usrprf & "' order by usrprf, fund,sfund,dept"
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

#Region "Properties: Set Fields"
  Private Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _USRPRF = .Item("USRPRF")
      _FUND = .Item("FUND")
      _SFUND = .Item("SFUND")
      _DEPT = .Item("DEPT")
    End With
  End Sub
  Private Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("USRPRF") = _USRPRF
      .Item("FUND") = _FUND
      .Item("SFUND") = _SFUND
      .Item("DEPT") = _DEPT
    End With
  End Sub

#End Region

#Region "Properties: Fields"
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
  Dim mUSRPRF As String
  Public Property _USRPRF As String
    Get
      Return mUSRPRF
    End Get
    Set(ByVal value As String)
      mUSRPRF = value
    End Set
  End Property
  Dim mFUND As Integer
  Public Property _FUND As Integer
    Get
      Return mFUND
    End Get
    Set(ByVal value As Integer)
      mFUND = value
    End Set
  End Property
  Dim mSFUND As Integer
  Public Property _SFUND As Integer
    Get
      Return mSFUND
    End Get
    Set(ByVal value As Integer)
      mSFUND = value
    End Set
  End Property
  Dim mDEPT As Integer
  Public Property _DEPT As Integer
    Get
      Return mDEPT
    End Get
    Set(ByVal value As Integer)
      mDEPT = value
    End Set
  End Property
#End Region
End Class

