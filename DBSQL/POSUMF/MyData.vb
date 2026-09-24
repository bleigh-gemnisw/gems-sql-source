Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "POSUMF"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub GetOneRecordP(ByVal Fscyr As Integer, ByVal Ponbr As Integer, ByVal Acct As Decimal)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where FSCYR=" & Fscyr & " and PONBR=" & Ponbr &
   " and ACCT=" & Format(Acct, "#####################")
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
  Public Function PosData(ByVal Fscyr As Integer, ByVal Ponbr As Integer, ByVal Acct As Decimal) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where " &
   " FSCYR=" & Fscyr & " and PONBR=" & Ponbr & " and ACCT>=" & Format(Acct, "#####################") &
   " or FSCYR=" & Fscyr & " and PONBR>" & Ponbr &
   " or FSCYR>" & Fscyr &
   " order by fscyr, ponbr, acct"
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
Public Sub InsertOneRecordP()
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  'Const caa As String = "','" 'Alpha Before/Alpha After
  Const can As String = "'," 'Alpha Before/Numeric After
  Const cna As String = ",'" 'Numeric Before/Alpha After
  Const cnn As String = "," 'Numeric Before/Numeric After

  StrSQL = "Insert into " & cFileName & "(FSCYR, PONBR, ACCT, POAMT,  POOPN, " & _
   "POPAD, POLIQ, ODACT)" & _
   " values(" & _FSCYR & cnn & _PONBR & cnn & _ACCT & cnn & _POAMT & cnn & _POOPN & cnn & _
   _POPAD & cna & _POLIQ & can & _ODACT & ")"
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    da = New SqlDataAdapter
    da.InsertCommand = objCommand
    da.InsertCommand.ExecuteNonQuery()
    objCommand = Nothing
    Conn.Close()
  Catch ex As Exception
    ErrMsg = ex.ToString()
  End Try
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
  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal wrkwhere As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim Result As Integer

   StrSQL = "Update " & cFileName & " " & Wrkset & " " & wrkwhere

  RecordNotFound = False
  IsEOF = False
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  Result = objCommand.ExecuteNonQuery()
  objCommand = Nothing
End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FSCYR = .Item("FSCYR")
    _PONBR = .Item("PONBR")
    _ACCT = .Item("ACCT")
    _POAMT = .Item("POAMT")
    _POOPN = .Item("POOPN")
    _POPAD = .Item("POPAD")
    _POLIQ = .Item("POLIQ")
    _ODACT = .Item("ODACT")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FSCYR") = _FSCYR
    .Item("PONBR") = _PONBR
    .Item("ACCT") = _ACCT
    .Item("POAMT") = _POAMT
    .Item("POOPN") = _POOPN
    .Item("POPAD") = _POPAD
    .Item("POLIQ") = _POLIQ
    .Item("ODACT") = _ODACT
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
Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property
Dim mPONBR As Integer
Public Property _PONBR As Integer
    Get
        Return mPONBR
    End Get
    Set(ByVal value As Integer)
        mPONBR = value
    End Set
End Property
  Dim mACCT As Decimal
  Public Property _ACCT As Decimal
    Get
      Return mACCT
    End Get
    Set(ByVal value As Decimal)
      mACCT = value
    End Set
  End Property
  Dim mPOAMT As Decimal
Public Property _POAMT As Decimal
    Get
        Return mPOAMT
    End Get
    Set(ByVal value As Decimal)
        mPOAMT = value
    End Set
End Property
Dim mPOOPN As Decimal
Public Property _POOPN As Decimal
    Get
        Return mPOOPN
    End Get
    Set(ByVal value As Decimal)
        mPOOPN = value
    End Set
End Property
Dim mPOPAD As Decimal
Public Property _POPAD As Decimal
    Get
        Return mPOPAD
    End Get
    Set(ByVal value As Decimal)
        mPOPAD = value
    End Set
End Property
Dim mPOLIQ As String
Public Property _POLIQ As String
    Get
        Return mPOLIQ
    End Get
    Set(ByVal value As String)
        mPOLIQ = value
    End Set
End Property
Dim mODACT As Double
Public Property _ODACT As Double
    Get
        Return mODACT
    End Get
    Set(ByVal value As Double)
        mODACT = value
    End Set
End Property
#End Region
End Class

