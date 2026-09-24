Imports System.Data
Imports System.Data.SqlClient

Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "UTDEDDIFF"

#Region "Constructors"
  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub
#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _DDACCT = 0
    _DDMETER = String.Empty
    _DDDATE = 0
    _DDREAD = 0
    _DDDIFF = 0
    _DDRESN = String.Empty
  End Sub

  Public Sub GetOneRecordP(ByVal Wrkddacct As Integer, ByVal Wrkddmeter As String, ByVal Wrkdddate As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    ErrMsg = String.Empty
    StrSQL = "Select * from " & cFileName &
      " where ddacct=" & Wrkddacct &
      " and ddmeter='" & Trim(Wrkddmeter) & "'" &
      " and dddate=" & Wrkdddate
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
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

  Public Function GetAllListNo(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String,
                               ByVal WrkStrDate As Integer, ByVal WrkEndDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    If WrkEndDate = 0 Then WrkEndDate = 99999999
    StrSQL = "Select * from " & cFileName &
      " where ddacct=" & WrkListNo &
      " and ddmeter='" & Trim(WrkMeterNo) & "'" &
      " and dddate>=" & WrkStrDate & " and dddate<=" & WrkEndDate &
      " order by dddate desc"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function


  Public Function GetLatestAll() As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select d.* from " & cFileName & " d " & _
      "inner join (select ddacct, ddmeter, max(dddate) as maxdate from " & cFileName & _
      " group by ddacct, ddmeter) x on d.ddacct=x.ddacct and d.ddmeter=x.ddmeter and d.dddate=x.maxdate " & _
      "order by d.ddacct, d.ddmeter"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function

  Public Function GetAllListNoAscending(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName &
      " where ddacct=" & WrkListNo &
      " and ddmeter='" & Trim(WrkMeterNo) & "' order by dddate"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    Return ds
  End Function

  Public Function GetLastbyDate(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String,
                                ByVal WrkDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    ErrMsg = String.Empty
    StrSQL = "Select TOP 1 * from " & cFileName &
      " where ddacct=" & WrkListNo &
      " and ddmeter='" & Trim(WrkMeterNo) & "'" &
      " and dddate<=" & WrkDate & " order by dddate desc"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
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

  Public Function GetNextbyDate(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String,
                                ByVal WrkDate As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    ErrMsg = String.Empty
    StrSQL = "Select TOP 1 * from " & cFileName &
      " where ddacct=" & WrkListNo &
      " and ddmeter='" & Trim(WrkMeterNo) & "'" &
      " and dddate>" & WrkDate & " order by dddate"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
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

  Public Sub DeleteOneRecordP(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String, ByVal WrkDate As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Delete from " & cFileName &
      " where ddacct=" & WrkListNo &
      " and ddmeter='" & Trim(WrkMeterNo) & "'" &
      " and dddate=" & WrkDate
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.ExecuteNonQuery()
    Conn.Close()
    objCommand = Nothing
  End Sub

  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal Wrkwhere As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Update " & cFileName & " " & Wrkset & " " & Wrkwhere
    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.CommandTimeout = 120
    objCommand.ExecuteNonQuery()
    Conn.Close()
    objCommand = Nothing
  End Sub

  Public Sub RecalcAllDifferences(ByVal WrkListNo As Integer, ByVal WrkMeterNo As String)
    Dim ds As DataSet = GetAllListNoAscending(WrkListNo, WrkMeterNo)
    Dim PrevReading As Long = 0
    Dim FirstRecord As Boolean = True
    Dim MeterSQL As String = Trim(WrkMeterNo)

    If ds Is Nothing OrElse ds.Tables.Count = 0 Then Exit Sub

    For Each Row As DataRow In ds.Tables(0).Rows
      Dim ThisReading As Long = CLng(Row("DDREAD"))
      Dim ThisDiff As Long = 0

      If Not FirstRecord Then
        ThisDiff = ThisReading - PrevReading
        If ThisDiff < 0 Then ThisDiff = 0
      End If

      RunUpdateQuery("set dddiff=" & ThisDiff,
                     "where ddacct=" & WrkListNo &
                     " and ddmeter='" & MeterSQL & "'" &
                     " and dddate=" & CInt(Row("DDDATE")))

      PrevReading = ThisReading
      FirstRecord = False
    Next
  End Sub

  Public Sub OpenFile()
  End Sub

  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _DDACCT = .Item("DDACCT")
      _DDMETER = Trim(.Item("DDMETER"))
      _DDDATE = .Item("DDDATE")
      _DDREAD = .Item("DDREAD")
      _DDDIFF = .Item("DDDIFF")
      _DDRESN = .Item("DDRESN")
    End With
  End Sub

  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("DDACCT") = _DDACCT
      .Item("DDMETER") = _DDMETER
      .Item("DDDATE") = _DDDATE
      .Item("DDREAD") = _DDREAD
      .Item("DDDIFF") = _DDDIFF
      .Item("DDRESN") = _DDRESN
    End With
  End Sub
#End Region

#Region "Properties: Fields"
  Dim mDDACCT As Integer
  Public Property _DDACCT As Integer
    Get
      Return mDDACCT
    End Get
    Set(ByVal value As Integer)
      mDDACCT = value
    End Set
  End Property

  Dim mDDMETER As String
  Public Property _DDMETER As String
    Get
      Return mDDMETER
    End Get
    Set(ByVal value As String)
      mDDMETER = value
    End Set
  End Property

  Dim mDDDATE As Integer
  Public Property _DDDATE As Integer
    Get
      Return mDDDATE
    End Get
    Set(ByVal value As Integer)
      mDDDATE = value
    End Set
  End Property

  Dim mDDREAD As Long
  Public Property _DDREAD As Long
    Get
      Return mDDREAD
    End Get
    Set(ByVal value As Long)
      mDDREAD = value
    End Set
  End Property

  Dim mDDDIFF As Long
  Public Property _DDDIFF As Long
    Get
      Return mDDDIFF
    End Get
    Set(ByVal value As Long)
      mDDDIFF = value
    End Set
  End Property

  Dim mDDRESN As String
  Public Property _DDRESN As String
    Get
      Return mDDRESN
    End Get
    Set(ByVal value As String)
      mDDRESN = value
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
