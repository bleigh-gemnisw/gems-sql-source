Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports System.Threading
Public Class UTCUSTMT
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim Conn As SqlConnection
  Const cFileName As String = "UTCUSTMT"
#Region "Constructors"

  Public Sub New(ByVal WrkConn As SqlConnection)
    Conn = WrkConn
  End Sub

#End Region


#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CMACCT = 0
    _CMTYPE = String.Empty
    _CMDATE = 0
    _CMREAD = 0
    _CMUSE = 0
    _CMRESN = String.Empty

  End Sub
  Public Sub GetOneRecordP(ByVal Wrkcmacct As Integer, ByVal Wrkcmtype As String, ByVal Wrkcmdate As Integer)
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cmacct = " & Wrkcmacct & " and cmtype = " & "'" & Wrkcmtype & "'" & " and cmdate = " & Wrkcmdate
    Try
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
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Function GetAllListNo(ByVal WrkListNo As Integer, ByVal WrkRateType As String, ByVal WrkStrDate As Integer, ByVal WrkEndDate As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    If WrkEndDate = 0 Then
      WrkEndDate = 99999999
    End If
    StrSQL = "Select * from " & cFileName & " where cmacct=" & WrkListNo & " and cmtype='" & WrkRateType &
     "' and cmdate>=" & WrkStrDate & " and cmdate <= " & WrkEndDate & " order by cmdate desc"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Return ds
  End Function

  Public Function GetLastbyDate(ByVal wrklistno As Integer, ByVal wrktype As String, ByVal wrkdate As Integer) As DataSet

    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False
    StrSQL = "Select TOP 1 * from " & cFileName _
    & " where cmacct = " & wrklistno & " And cmtype = '" & wrktype & "' and cmdate<=" & wrkdate & " order by cmdate desc"
    Try
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function PosData(ByVal Wrkcmacct As Integer, ByVal Wrkcmtype As String, ByVal Wrkcmdate As Integer) As DataSet
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cmacct = " & Wrkcmacct & " And cmtype = " & "'" & Wrkcmtype & "'" & " And cmdate >= " & Wrkcmdate & " Or cmacct = " & Wrkcmacct & " And cmtype > " & "'" & Wrkcmtype & "'" & " Or cmacct > " & Wrkcmacct & " Order by cmacct, cmtype, cmdate"
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
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
  Public Sub DeleteListNo(ByVal wrklist As Integer)
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE cmacct = " & wrklist

    RecordNotFound = False
    IsEOF = False
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub InsertOneRecordP()

    ErrMsg = String.Empty

    Dim StrSQL As String = "INSERT INTO UTCUSTMT " &
    "(CMACCT, CMTYPE, CMDATE, CMREAD, CMUSE, CMRESN) " &
    "VALUES (@Acct, @Type,@ReadDate, @Reading, @Usage, @Reason)"

    Using cmd As New SqlCommand(StrSQL, Conn)
      cmd.Parameters.AddWithValue("@Acct", _CMACCT)
      cmd.Parameters.AddWithValue("@Type", _CMTYPE)
      cmd.Parameters.AddWithValue("@ReadDate", _CMDATE)
      cmd.Parameters.AddWithValue("@Reading", _CMREAD)
      cmd.Parameters.AddWithValue("@Usage", _CMUSE)
      cmd.Parameters.AddWithValue("@Reason", _CMRESN)
      cmd.ExecuteNonQuery()
    End Using
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
      _CMACCT = .Item("CMACCT")
      _CMTYPE = .Item("CMTYPE")
      _CMDATE = .Item("CMDATE")
      _CMREAD = .Item("CMREAD")
      _CMUSE = .Item("CMUSE")
      _CMRESN = .Item("CMRESN")

    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CMACCT") = _CMACCT
      .Item("CMTYPE") = _CMTYPE
      .Item("CMDATE") = _CMDATE
      .Item("CMREAD") = _CMREAD
      .Item("CMUSE") = _CMUSE
      .Item("CMRESN") = _CMRESN

    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mCMACCT As Integer
  Public Property _CMACCT As Integer
    Get
      Return mCMACCT
    End Get
    Set(ByVal value As Integer)
      mCMACCT = value
    End Set
  End Property

  Dim mCMTYPE As String
  Public Property _CMTYPE As String
    Get
      Return mCMTYPE
    End Get
    Set(ByVal value As String)
      mCMTYPE = value
    End Set
  End Property

  Dim mCMDATE As Integer
  Public Property _CMDATE As Integer
    Get
      Return mCMDATE
    End Get
    Set(ByVal value As Integer)
      mCMDATE = value
    End Set
  End Property

  Dim mCMREAD As Long
  Public Property _CMREAD As Long
    Get
      Return mCMREAD
    End Get
    Set(ByVal value As Long)
      mCMREAD = value
    End Set
  End Property

  Dim mCMUSE As Long
  Public Property _CMUSE As Long
    Get
      Return mCMUSE
    End Get
    Set(ByVal value As Long)
      mCMUSE = value
    End Set
  End Property

  Dim mCMRESN As String
  Public Property _CMRESN As String
    Get
      Return mCMRESN
    End Get
    Set(ByVal value As String)
      mCMRESN = value
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


