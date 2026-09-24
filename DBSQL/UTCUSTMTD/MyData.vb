Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "UTCUSTMTD"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CMACCT = 0
    _CMXREF = String.Empty
    _CMTYPE = String.Empty
    _CMDATE = 0
    _CMREAD = 0
    _CMUSE = 0
    _CMRESN = String.Empty
    _CMDESC1 = String.Empty
    _CMDESC2 = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkcmacct As Integer, ByVal Wrkcmxref As String, ByVal Wrkcmtype As String,
   ByVal Wrkcmdate As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cmacct = " & Wrkcmacct & " and cmxref = '" & Wrkcmxref &
     "' and cmtype = '" & Wrkcmtype & "' and cmdate = " & Wrkcmdate
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
  Public Function GetAllListNo(ByVal WrkListNo As Integer, ByVal WrkXref As String, ByVal WrkRateType As String,
   ByVal WrkStrDate As Integer, ByVal WrkEndDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    If WrkEndDate = 0 Then
      WrkEndDate = 99999999
    End If
    StrSQL = "Select * from " & cFileName & " where cmacct=" & WrkListNo & " and cmxref>='" & WrkXref &
     "' and cmtype='" & WrkRateType & "' and cmdate>=" & WrkStrDate & " and cmdate <= " & WrkEndDate &
     " order by cmxref,cmdate desc"
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

  Public Function GetLastbyDate(ByVal wrklistno As Integer, ByVal wrktype As String, ByVal wrkdate As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    RecordNotFound = False
    StrSQL = "Select TOP 1 * from " & cFileName _
    & " where cmacct = " & wrklistno & " And cmtype = '" & wrktype & "' and cmdate<=" & wrkdate & " order by cmxref,cmdate desc"
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
  Public Function GetAcctSumDate(ByVal WrkListNo As Integer, ByVal WrkRateType As String,
   ByVal WrkDate As Integer) As Decimal
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkAmount As Decimal

    RecordNotFound = False
    StrSQL = "Select sum(cmuse) As wrksum from " & cFileName & " where cmacct=" & WrkListNo &
    " and cmtype='" & WrkRateType & "' and cmdate=" & WrkDate
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      WrkAmount = ds.Tables(0).Rows(0).Item(0)
      objCommand = Nothing
      ds = Nothing
      Conn.Close()
      Return WrkAmount
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function PosData(ByVal Wrkcmacct As Integer, ByVal Wrkcmtype As String, ByVal Wrkcmdate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cmacct = " & Wrkcmacct & " And cmtype = " & "'" & Wrkcmtype & "'" & " And cmdate >= " & Wrkcmdate & " Or cmacct = " & Wrkcmacct & " And cmtype > " & "'" & Wrkcmtype & "'" & " Or cmacct > " & Wrkcmacct & " Order by cmacct, cmtype, cmdate"
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
  Public Sub DeleteListNo(ByVal wrklist As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE cmacct = " & wrklist

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
  End Sub
  Public Sub DeleteListNoDate(ByVal wrklist As Integer, ByVal Wrkcmdate As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE cmacct = " & wrklist & " And cmdate = " & Wrkcmdate

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
      _CMXREF = .Item("CMXREF")
      _CMTYPE = .Item("CMTYPE")
      _CMDATE = .Item("CMDATE")
      _CMREAD = .Item("CMREAD")
      _CMUSE = .Item("CMUSE")
      _CMRESN = .Item("CMRESN")
      _CMDESC1 = .Item("CMDESC1")
      _CMDESC2 = .Item("CMDESC2")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CMACCT") = _CMACCT
      .Item("CMXREF") = _CMXREF
      .Item("CMTYPE") = _CMTYPE
      .Item("CMDATE") = _CMDATE
      .Item("CMREAD") = _CMREAD
      .Item("CMUSE") = _CMUSE
      .Item("CMRESN") = _CMRESN
      .Item("CMDESC1") = _CMDESC1
      .Item("CMDESC2") = _CMDESC2
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
  Dim mCMXREF As String
  Public Property _CMXREF As String
    Get
      Return mCMXREF
    End Get
    Set(ByVal value As String)
      mCMXREF = value
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
  Dim mCMDESC1 As String
  Public Property _CMDESC1 As String
    Get
      Return mCMDESC1
    End Get
    Set(ByVal value As String)
      mCMDESC1 = value
    End Set
  End Property
  Dim mCMDESC2 As String
  Public Property _CMDESC2 As String
    Get
      Return mCMDESC2
    End Get
    Set(ByVal value As String)
      mCMDESC2 = value
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


