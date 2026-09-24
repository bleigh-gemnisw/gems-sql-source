Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLHEAD"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fdnbr As Integer, ByVal Sfund As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund
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
Public Function PosData(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Numrecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where FDNBR=" & Fdnbr & " and SFUND>" & Sfund & _
  " or FDNBR>" & Fdnbr & " order by fdnbr,sfund"
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
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _BUDC1 = .Item("BUDC1")
    _BUDC2 = .Item("BUDC2")
    _BUDC3 = .Item("BUDC3")
    _BUDC4 = .Item("BUDC4")
    _BUDA1 = .Item("BUDA1")
    _BUDA2 = .Item("BUDA2")
    _BUDA3 = .Item("BUDA3")
    _BUDA4 = .Item("BUDA4")
    _BUDB1 = .Item("BUDB1")
    _BUDB2 = .Item("BUDB2")
    _BUDB3 = .Item("BUDB3")
    _BUDB4 = .Item("BUDB4")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("BUDC1") = _BUDC1
    .Item("BUDC2") = _BUDC2
    .Item("BUDC3") = _BUDC3
    .Item("BUDC4") = _BUDC4
    .Item("BUDA1") = _BUDA1
    .Item("BUDA2") = _BUDA2
    .Item("BUDA3") = _BUDA3
    .Item("BUDA4") = _BUDA4
    .Item("BUDB1") = _BUDB1
    .Item("BUDB2") = _BUDB2
    .Item("BUDB3") = _BUDB3
    .Item("BUDB4") = _BUDB4
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
Dim mFDNBR As Integer
Public Property _FDNBR As Integer
    Get
        Return mFDNBR
    End Get
    Set(ByVal value As Integer)
        mFDNBR = value
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
Dim mBUDC1 As String
Public Property _BUDC1 As String
    Get
        Return mBUDC1
    End Get
    Set(ByVal value As String)
        mBUDC1 = value
    End Set
End Property
Dim mBUDC2 As String
Public Property _BUDC2 As String
    Get
        Return mBUDC2
    End Get
    Set(ByVal value As String)
        mBUDC2 = value
    End Set
End Property
Dim mBUDC3 As String
Public Property _BUDC3 As String
    Get
        Return mBUDC3
    End Get
    Set(ByVal value As String)
        mBUDC3 = value
    End Set
End Property
Dim mBUDC4 As String
Public Property _BUDC4 As String
    Get
        Return mBUDC4
    End Get
    Set(ByVal value As String)
        mBUDC4 = value
    End Set
End Property
Dim mBUDA1 As String
Public Property _BUDA1 As String
    Get
        Return mBUDA1
    End Get
    Set(ByVal value As String)
        mBUDA1 = value
    End Set
End Property
Dim mBUDA2 As String
Public Property _BUDA2 As String
    Get
        Return mBUDA2
    End Get
    Set(ByVal value As String)
        mBUDA2 = value
    End Set
End Property
Dim mBUDA3 As String
Public Property _BUDA3 As String
    Get
        Return mBUDA3
    End Get
    Set(ByVal value As String)
        mBUDA3 = value
    End Set
End Property
Dim mBUDA4 As String
Public Property _BUDA4 As String
    Get
        Return mBUDA4
    End Get
    Set(ByVal value As String)
        mBUDA4 = value
    End Set
End Property
Dim mBUDB1 As String
Public Property _BUDB1 As String
    Get
        Return mBUDB1
    End Get
    Set(ByVal value As String)
        mBUDB1 = value
    End Set
End Property
Dim mBUDB2 As String
Public Property _BUDB2 As String
    Get
        Return mBUDB2
    End Get
    Set(ByVal value As String)
        mBUDB2 = value
    End Set
End Property
Dim mBUDB3 As String
Public Property _BUDB3 As String
    Get
        Return mBUDB3
    End Get
    Set(ByVal value As String)
        mBUDB3 = value
    End Set
End Property
Dim mBUDB4 As String
Public Property _BUDB4 As String
    Get
        Return mBUDB4
    End Get
    Set(ByVal value As String)
        mBUDB4 = value
    End Set
End Property
#End Region

End Class

