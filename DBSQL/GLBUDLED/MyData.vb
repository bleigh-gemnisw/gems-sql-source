Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLBUDLED"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal BFUND As Integer, ByVal BSFUND As Integer, ByVal BDEPT As Integer, _
 ByVal BOBJ As Integer, ByVal BFUNC As Integer, ByVal BSFUNC As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where BFUND=" & BFUND & " and BSFUND=" & BSFUND & _
   " and BDEPT=" & BDEPT & " and BOBJ=" & BOBJ & " and BFUNC=" & BFUNC & " and BSFUNC=" & BSFUNC
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
Public Function PosData(ByVal BFUND As Integer, ByVal BSFUND As Integer, ByVal BDEPT As Integer, _
 ByVal BOBJ As Integer, ByVal BFUNC As Integer, ByVal BSFUNC As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where BFUND=" & BFUND & " and BSFUND=" & BSFUND & " and BDEPT=" & BDEPT & " and BOBJ=" & BOBJ & _
  " and BFUNC=" & BFUNC & " and BSFUNC>=" & BSFUNC & _
  " or BFUND=" & BFUND & " and BSFUND=" & BSFUND & " and BDEPT=" & BDEPT & " and BOBJ=" & BOBJ & " and BFUNC>" & BFUNC & _
  " or BFUND=" & BFUND & " and BSFUND=" & BSFUND & " and BDEPT=" & BDEPT & " and BOBJ>" & BOBJ & _
  " or BFUND=" & BFUND & " and BSFUND=" & BSFUND & " and BDEPT>" & BDEPT & _
  " or BFUND=" & BFUND & " and BSFUND>" & BSFUND & _
  " or BFUND>" & BFUND & " order by BFUND,BSFUND,BDEPT,BOBJ,BFUNC,BSFUNC"
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
    _BFUND = .Item("BFUND")
    _BSFUND = .Item("BSFUND")
    _BDEPT = .Item("BDEPT")
    _BOBJ = .Item("BOBJ")
    _BFUNC = .Item("BFUNC")
    _BSFUNC = .Item("BSFUNC")
    _EFUT1 = .Item("EFUT1")
    _EFUT2 = .Item("EFUT2")
    _EFUT3 = .Item("EFUT3")
    _EFUT4 = .Item("EFUT4")
    _EFUT5 = .Item("EFUT5")
    _ESTAT = .Item("ESTAT")
    _ECARY = .Item("ECARY")
   End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("BFUND") = _BFUND
    .Item("BSFUND") = _BSFUND
    .Item("BDEPT") = _BDEPT
    .Item("BOBJ") = _BOBJ
    .Item("BFUNC") = _BFUNC
    .Item("BSFUNC") = _BSFUNC
    .Item("EFUT1") = _EFUT1
    .Item("EFUT2") = _EFUT2
    .Item("EFUT3") = _EFUT3
    .Item("EFUT4") = _EFUT4
    .Item("EFUT5") = _EFUT5
    .Item("ESTAT") = _ESTAT
    .Item("ECARY") = _ECARY
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
Dim mBFUND As Integer
Public Property _BFUND As Integer
    Get
        Return mBFUND
    End Get
    Set(ByVal value As Integer)
        mBFUND = value
    End Set
End Property
Dim mBSFUND As Integer
Public Property _BSFUND As Integer
    Get
        Return mBSFUND
    End Get
    Set(ByVal value As Integer)
        mBSFUND = value
    End Set
End Property
Dim mBDEPT As Integer
Public Property _BDEPT As Integer
    Get
        Return mBDEPT
    End Get
    Set(ByVal value As Integer)
        mBDEPT = value
    End Set
End Property
Dim mBOBJ As Integer
Public Property _BOBJ As Integer
    Get
        Return mBOBJ
    End Get
    Set(ByVal value As Integer)
        mBOBJ = value
    End Set
End Property
Dim mBFUNC As Integer
Public Property _BFUNC As Integer
    Get
        Return mBFUNC
    End Get
    Set(ByVal value As Integer)
        mBFUNC = value
    End Set
End Property
Dim mBSFUNC As Integer
Public Property _BSFUNC As Integer
    Get
        Return mBSFUNC
    End Get
    Set(ByVal value As Integer)
        mBSFUNC = value
    End Set
End Property
Dim mEFUT1 As Long
Public Property _EFUT1 As Long
    Get
        Return mEFUT1
    End Get
    Set(ByVal value As Long)
        mEFUT1 = value
    End Set
End Property
Dim mEFUT2 As Long
Public Property _EFUT2 As Long
    Get
        Return mEFUT2
    End Get
    Set(ByVal value As Long)
        mEFUT2 = value
    End Set
End Property
Dim mEFUT3 As Long
Public Property _EFUT3 As Long
    Get
        Return mEFUT3
    End Get
    Set(ByVal value As Long)
        mEFUT3 = value
    End Set
End Property
Dim mEFUT4 As Long
Public Property _EFUT4 As Long
    Get
        Return mEFUT4
    End Get
    Set(ByVal value As Long)
        mEFUT4 = value
    End Set
End Property
Dim mEFUT5 As Long
Public Property _EFUT5 As Long
    Get
        Return mEFUT5
    End Get
    Set(ByVal value As Long)
        mEFUT5 = value
    End Set
End Property
Dim mESTAT As String
Public Property _ESTAT As String
    Get
        Return mESTAT
    End Get
    Set(ByVal value As String)
        mESTAT = value
    End Set
End Property
Dim mECARY As Long
Public Property _ECARY As Long
    Get
        Return mECARY
    End Get
    Set(ByVal value As Long)
        mECARY = value
    End Set
End Property
#End Region

End Class

