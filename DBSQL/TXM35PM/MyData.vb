Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXM35PM"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _LISTNO = 0
    _YEAR = 0
    _SEQ = 0
    _LOCPM = String.Empty
    _TRF = 0
    _BENAMT = 0
    _DEFER = String.Empty
    _DEFPCT = 0
    _ALLOW = String.Empty
    _DISRSN = String.Empty
    _DTASSR = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseq As Integer, ByVal Wrklocpm As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and seq = " & Wrkseq & " and locpm = " & "'" & Wrklocpm & "'"
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrkseq As Integer, ByVal Wrklocpm As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And seq = " & Wrkseq & " And locpm >= " & "'" & Wrklocpm & "'" & " Or list# = " & Wrklistno & " And year = " & Wrkyear & " And seq > " & Wrkseq & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, seq, locpm"
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
  Public Function GetbyList(ByVal Wrklistno As Integer, wrkyear As Integer, wrkseq As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select  list#,year,seq,locpm,trf,benamt,defer,defpct,allow,disrsn,dtassr From " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR =" & wrkyear & " AND seq = " & wrkseq & " order by list#,year,seq"
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
  Public Function GetbyListAll(ByVal Wrklistno As Integer, wrkyear As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select  list#,year,seq,locpm,benamt,allow,disrsn,dtassr From " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR =" & wrkyear & " order by list#,year,seq"
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
      _LISTNO = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _SEQ = .Item("SEQ")
      _LOCPM = .Item("LOCPM")
      _TRF = .Item("TRF")
      _BENAMT = .Item("BENAMT")
      _DEFER = .Item("DEFER")
      _DEFPCT = .Item("DEFPCT")
      _ALLOW = .Item("ALLOW")
      _DISRSN = .Item("DISRSN")
      _DTASSR = .Item("DTASSR")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("LIST#") = _LISTNO
      .Item("YEAR") = _YEAR
      .Item("SEQ") = _SEQ
      .Item("LOCPM") = _LOCPM
      .Item("TRF") = _TRF
      .Item("BENAMT") = _BENAMT
      .Item("DEFER") = _DEFER
      .Item("DEFPCT") = _DEFPCT
      .Item("ALLOW") = _ALLOW
      .Item("DISRSN") = _DISRSN
      .Item("DTASSR") = _DTASSR
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mLISTNO As Integer
  Public Property _LISTNO As Integer
    Get
      Return mLISTNO
    End Get
    Set(ByVal value As Integer)
      mLISTNO = value
    End Set
  End Property

  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property
  Dim mSEQ As Integer
  Public Property _SEQ As Integer
    Get
      Return mSEQ
    End Get
    Set(ByVal value As Integer)
      mSEQ = value
    End Set
  End Property
  Dim mLOCPM As String
  Public Property _LOCPM As String
    Get
      Return mLOCPM
    End Get
    Set(ByVal value As String)
      mLOCPM = value
    End Set
  End Property
  Dim mTRF As Decimal
  Public Property _TRF As Decimal
    Get
      Return mTRF
    End Get
    Set(ByVal value As Decimal)
      mTRF = value
    End Set
  End Property
  Dim mBENAMT As Decimal
  Public Property _BENAMT As Decimal
    Get
      Return mBENAMT
    End Get
    Set(ByVal value As Decimal)
      mBENAMT = value
    End Set
  End Property
  Dim mDEFER As String
  Public Property _DEFER As String
    Get
      Return mDEFER
    End Get
    Set(ByVal value As String)
      mDEFER = value
    End Set
  End Property
  Dim mDEFPCT As Decimal
  Public Property _DEFPCT As Decimal
    Get
      Return mDEFPCT
    End Get
    Set(ByVal value As Decimal)
      mDEFPCT = value
    End Set
  End Property
  Dim mALLOW As String
  Public Property _ALLOW As String
    Get
      Return mALLOW
    End Get
    Set(ByVal value As String)
      mALLOW = value
    End Set
  End Property
  Dim mDISRSN As String
  Public Property _DISRSN As String
    Get
      Return mDISRSN
    End Get
    Set(ByVal value As String)
      mDISRSN = value
    End Set
  End Property

  Dim mDTASSR As Integer
  Public Property _DTASSR As Integer
    Get
      Return mDTASSR
    End Get
    Set(ByVal value As Integer)
      mDTASSR = value
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


