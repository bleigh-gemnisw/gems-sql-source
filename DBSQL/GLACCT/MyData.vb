Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLACCT"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Dpnbr As Integer, _
 ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund & _
   " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & " and FNPGM=" & Fnpgm & " and SUBFN=" & Subfn
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
Public Function GetViewbyAcct(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Dpnbr As Integer, _
 ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,gldsc,gltyp from " & cFileName & _
  " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & _
  " and FNPGM=" & Fnpgm & " and SUBFN>=" & Subfn & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & " and FNPGM>" & Fnpgm & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR>" & Obnbr & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR>" & Dpnbr & _
  " or FDNBR=" & Fdnbr & " and SFUND>" & Sfund & _
  " or FDNBR>" & Fdnbr & " order by fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn"
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
Public Function PosData(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Dpnbr As Integer, _
 ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If NumRecs > 0 Then
    WrkTop = "TOP " & NumRecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & _
  " and FNPGM=" & Fnpgm & " and SUBFN>=" & Subfn & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr & " and FNPGM>" & Fnpgm & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR>" & Obnbr & _
  " or FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR>" & Dpnbr & _
  " or FDNBR=" & Fdnbr & " and SFUND>" & Sfund & _
  " or FDNBR>" & Fdnbr & " order by fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn"
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
    _ACREC = .Item("ACREC")
    _FDNBR = .Item("FDNBR")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _GLDSC = .Item("GLDSC")
    _GLTYP = .Item("GLTYP")
    _NONPR = .Item("NONPR")
    _FIL02 = .Item("FIL02")
    _CSHYN = .Item("CSHYN")
    _RLNBR = .Item("RLNBR")
    _FIL03 = .Item("FIL03")
    _SFUND = .Item("SFUND")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("ACREC") = _ACREC
    .Item("FDNBR") = _FDNBR
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("SUBFN") = _SUBFN
    .Item("GLDSC") = _GLDSC
    .Item("GLTYP") = _GLTYP
    .Item("NONPR") = _NONPR
    .Item("FIL02") = _FIL02
    .Item("CSHYN") = _CSHYN
    .Item("RLNBR") = _RLNBR
    .Item("FIL03") = _FIL03
    .Item("SFUND") = _SFUND
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
Dim mACREC As String
Public Property _ACREC As String
    Get
        Return mACREC
    End Get
    Set(ByVal value As String)
        mACREC = value
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
Dim mDPNBR As Integer
Public Property _DPNBR As Integer
    Get
        Return mDPNBR
    End Get
    Set(ByVal value As Integer)
        mDPNBR = value
    End Set
End Property
Dim mOBNBR As Integer
Public Property _OBNBR As Integer
    Get
        Return mOBNBR
    End Get
    Set(ByVal value As Integer)
        mOBNBR = value
    End Set
End Property
Dim mFNPGM As Integer
Public Property _FNPGM As Integer
    Get
        Return mFNPGM
    End Get
    Set(ByVal value As Integer)
        mFNPGM = value
    End Set
End Property
Dim mSUBFN As Integer
Public Property _SUBFN As Integer
    Get
        Return mSUBFN
    End Get
    Set(ByVal value As Integer)
        mSUBFN = value
    End Set
End Property
Dim mGLDSC As String
Public Property _GLDSC As String
    Get
        Return mGLDSC
    End Get
    Set(ByVal value As String)
        mGLDSC = value
    End Set
End Property
Dim mGLTYP As String
Public Property _GLTYP As String
    Get
        Return mGLTYP
    End Get
    Set(ByVal value As String)
        mGLTYP = value
    End Set
End Property
Dim mNONPR As String
Public Property _NONPR As String
    Get
        Return mNONPR
    End Get
    Set(ByVal value As String)
        mNONPR = value
    End Set
End Property
Dim mFIL02 As String
Public Property _FIL02 As String
    Get
        Return mFIL02
    End Get
    Set(ByVal value As String)
        mFIL02 = value
    End Set
End Property
Dim mCSHYN As String
Public Property _CSHYN As String
    Get
        Return mCSHYN
    End Get
    Set(ByVal value As String)
        mCSHYN = value
    End Set
End Property
Dim mRLNBR As Integer
Public Property _RLNBR As Integer
    Get
        Return mRLNBR
    End Get
    Set(ByVal value As Integer)
        mRLNBR = value
    End Set
End Property
Dim mFIL03 As String
Public Property _FIL03 As String
    Get
        Return mFIL03
    End Get
    Set(ByVal value As String)
        mFIL03 = value
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
#End Region

End Class

