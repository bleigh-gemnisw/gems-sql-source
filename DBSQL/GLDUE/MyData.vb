Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLDUE"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fund As Integer, ByVal Sfund As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fund & " and SFUND=" & Sfund
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
Public Function PosData(ByVal Fund As Integer, ByVal Sfund As Integer, ByVal Numrecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If Numrecs > 0 Then
    WrkTop = "TOP " & Numrecs & " "
  End If
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fund & " and SFUND>=" & Sfund & _
   " or FDNBR>" & Fund & " order by fund, sfund"
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
    _FDNBR5 = .Item("FDNBR5")
    _SFUND5 = .Item("SFUND5")
    _DPNBR5 = .Item("DPNBR5")
    _OBNBR5 = .Item("OBNBR5")
    _FNPGM5 = .Item("FNPGM5")
    _SUBFN5 = .Item("SUBFN5")
    _FDNBR6 = .Item("FDNBR6")
    _SFUND6 = .Item("SFUND6")
    _DPNBR6 = .Item("DPNBR6")
    _OBNBR6 = .Item("OBNBR6")
    _FNPGM6 = .Item("FNPGM6")
    _SUBFN6 = .Item("SUBFN6")
    _FDNBR7 = .Item("FDNBR7")
    _SFUND7 = .Item("SFUND7")
    _DPNBR7 = .Item("DPNBR7")
    _OBNBR7 = .Item("OBNBR7")
    _FNPGM7 = .Item("FNPGM7")
    _SUBFN7 = .Item("SUBFN7")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("FDNBR5") = _FDNBR5
    .Item("SFUND5") = _SFUND5
    .Item("DPNBR5") = _DPNBR5
    .Item("OBNBR5") = _OBNBR5
    .Item("FNPGM5") = _FNPGM5
    .Item("SUBFN5") = _SUBFN5
    .Item("FDNBR6") = _FDNBR6
    .Item("SFUND6") = _SFUND6
    .Item("DPNBR6") = _DPNBR6
    .Item("OBNBR6") = _OBNBR6
    .Item("FNPGM6") = _FNPGM6
    .Item("SUBFN6") = _SUBFN6
    .Item("FDNBR7") = _FDNBR7
    .Item("SFUND7") = _SFUND7
    .Item("DPNBR7") = _DPNBR7
    .Item("OBNBR7") = _OBNBR7
    .Item("FNPGM7") = _FNPGM7
    .Item("SUBFN7") = _SUBFN7
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
Dim mFDNBR5 As Integer
Public Property _FDNBR5 As Integer
    Get
        Return mFDNBR5
    End Get
    Set(ByVal value As Integer)
        mFDNBR5 = value
    End Set
End Property
Dim mSFUND5 As Integer
Public Property _SFUND5 As Integer
    Get
        Return mSFUND5
    End Get
    Set(ByVal value As Integer)
        mSFUND5 = value
    End Set
End Property
Dim mDPNBR5 As Integer
Public Property _DPNBR5 As Integer
    Get
        Return mDPNBR5
    End Get
    Set(ByVal value As Integer)
        mDPNBR5 = value
    End Set
End Property
Dim mOBNBR5 As Integer
Public Property _OBNBR5 As Integer
    Get
        Return mOBNBR5
    End Get
    Set(ByVal value As Integer)
        mOBNBR5 = value
    End Set
End Property
Dim mFNPGM5 As Integer
Public Property _FNPGM5 As Integer
    Get
        Return mFNPGM5
    End Get
    Set(ByVal value As Integer)
        mFNPGM5 = value
    End Set
End Property
Dim mSUBFN5 As Integer
Public Property _SUBFN5 As Integer
    Get
        Return mSUBFN5
    End Get
    Set(ByVal value As Integer)
        mSUBFN5 = value
    End Set
End Property
Dim mFDNBR6 As Integer
Public Property _FDNBR6 As Integer
    Get
        Return mFDNBR6
    End Get
    Set(ByVal value As Integer)
        mFDNBR6 = value
    End Set
End Property
Dim mSFUND6 As Integer
Public Property _SFUND6 As Integer
    Get
        Return mSFUND6
    End Get
    Set(ByVal value As Integer)
        mSFUND6 = value
    End Set
End Property
Dim mDPNBR6 As Integer
Public Property _DPNBR6 As Integer
    Get
        Return mDPNBR6
    End Get
    Set(ByVal value As Integer)
        mDPNBR6 = value
    End Set
End Property
Dim mOBNBR6 As Integer
Public Property _OBNBR6 As Integer
    Get
        Return mOBNBR6
    End Get
    Set(ByVal value As Integer)
        mOBNBR6 = value
    End Set
End Property
Dim mFNPGM6 As Integer
Public Property _FNPGM6 As Integer
    Get
        Return mFNPGM6
    End Get
    Set(ByVal value As Integer)
        mFNPGM6 = value
    End Set
End Property
Dim mSUBFN6 As Integer
Public Property _SUBFN6 As Integer
    Get
        Return mSUBFN6
    End Get
    Set(ByVal value As Integer)
        mSUBFN6 = value
    End Set
End Property
Dim mFDNBR7 As Integer
Public Property _FDNBR7 As Integer
    Get
        Return mFDNBR7
    End Get
    Set(ByVal value As Integer)
        mFDNBR7 = value
    End Set
End Property
Dim mSFUND7 As Integer
Public Property _SFUND7 As Integer
    Get
        Return mSFUND7
    End Get
    Set(ByVal value As Integer)
        mSFUND7 = value
    End Set
End Property
Dim mDPNBR7 As Integer
Public Property _DPNBR7 As Integer
    Get
        Return mDPNBR7
    End Get
    Set(ByVal value As Integer)
        mDPNBR7 = value
    End Set
End Property
Dim mOBNBR7 As Integer
Public Property _OBNBR7 As Integer
    Get
        Return mOBNBR7
    End Get
    Set(ByVal value As Integer)
        mOBNBR7 = value
    End Set
End Property
Dim mFNPGM7 As Integer
Public Property _FNPGM7 As Integer
    Get
        Return mFNPGM7
    End Get
    Set(ByVal value As Integer)
        mFNPGM7 = value
    End Set
End Property
Dim mSUBFN7 As Integer
Public Property _SUBFN7 As Integer
    Get
        Return mSUBFN7
    End Get
    Set(ByVal value As Integer)
        mSUBFN7 = value
    End Set
End Property
#End Region

End Class

