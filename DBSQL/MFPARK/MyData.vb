Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "MFPARK"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _MFCATG = String.Empty
    _MFREGNo = String.Empty
    _MFNAM = String.Empty
    _MFSNAM = String.Empty
    _MFADD1 = String.Empty
    _MFADD2 = String.Empty
    _MFCITY = String.Empty
    _MFST = String.Empty
    _MFZIP5 = 0
    _MFZIP4 = 0
    _MFLOCNo = String.Empty
    _MFLOC = String.Empty
    _MFPERNo = 0
    _MFLISS = 0
    _MFYEAR = 0
    _MFCOMM = String.Empty
    _STAMPD = 0
    _STAMPT = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkYear As Integer, ByVal WrkCat As String, ByVal WrkName As String,
   ByVal WrkAdd1 As String, ByVal WrkStampd As Integer, ByVal WrkStampt As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where mfyear=" & WrkYear & " and mfcatg='" & WrkCat _
     & "' and mfnam='" & WrkName & "' and mfadd1 ='" & WrkAdd1 & "' and stampd=" & WrkStampd & " and stampt=" & WrkStampt
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
      _MFCATG = .Item("MFCATG")
      _MFREGNo = .Item("MFREG#")
      _MFNAM = .Item("MFNAM")
      _MFSNAM = .Item("MFSNAM")
      _MFADD1 = .Item("MFADD1")
      _MFADD2 = .Item("MFADD2")
      _MFCITY = .Item("MFCITY")
      _MFST = .Item("MFST")
      _MFZIP5 = .Item("MFZIP5")
      _MFZIP4 = .Item("MFZIP4")
      _MFLOCNo = .Item("MFLOC#")
      _MFLOC = .Item("MFLOC")
      _MFPERNo = .Item("MFPER#")
      _MFLISS = .Item("MFLISS")
      _MFYEAR = .Item("MFYEAR")
      _MFCOMM = .Item("MFCOMM")
      _STAMPD = .Item("STAMPD")
      _STAMPT = .Item("STAMPT")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("MFCATG") = _MFCATG
      .Item("MFREG#") = _MFREGNo
      .Item("MFNAM") = _MFNAM
      .Item("MFSNAM") = _MFSNAM
      .Item("MFADD1") = _MFADD1
      .Item("MFADD2") = _MFADD2
      .Item("MFCITY") = _MFCITY
      .Item("MFST") = _MFST
      .Item("MFZIP5") = _MFZIP5
      .Item("MFZIP4") = _MFZIP4
      .Item("MFLOC#") = _MFLOCNo
      .Item("MFLOC") = _MFLOC
      .Item("MFPER#") = _MFPERNo
      .Item("MFLISS") = _MFLISS
      .Item("MFYEAR") = _MFYEAR
      .Item("MFCOMM") = _MFCOMM
      .Item("STAMPD") = _STAMPD
      .Item("STAMPT") = _STAMPT
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
  Dim mMFCATG As String
  Public Property _MFCATG As String
    Get
      Return mMFCATG
    End Get
    Set(ByVal value As String)
      mMFCATG = value
    End Set
  End Property

  Dim mMFREGNo As String
  Public Property _MFREGNo As String
    Get
      Return mMFREGNo
    End Get
    Set(ByVal value As String)
      mMFREGNo = value
    End Set
  End Property

  Dim mMFNAM As String
  Public Property _MFNAM As String
    Get
      Return mMFNAM
    End Get
    Set(ByVal value As String)
      mMFNAM = value
    End Set
  End Property

  Dim mMFSNAM As String
  Public Property _MFSNAM As String
    Get
      Return mMFSNAM
    End Get
    Set(ByVal value As String)
      mMFSNAM = value
    End Set
  End Property

  Dim mMFADD1 As String
  Public Property _MFADD1 As String
    Get
      Return mMFADD1
    End Get
    Set(ByVal value As String)
      mMFADD1 = value
    End Set
  End Property

  Dim mMFADD2 As String
  Public Property _MFADD2 As String
    Get
      Return mMFADD2
    End Get
    Set(ByVal value As String)
      mMFADD2 = value
    End Set
  End Property

  Dim mMFCITY As String
  Public Property _MFCITY As String
    Get
      Return mMFCITY
    End Get
    Set(ByVal value As String)
      mMFCITY = value
    End Set
  End Property

  Dim mMFST As String
  Public Property _MFST As String
    Get
      Return mMFST
    End Get
    Set(ByVal value As String)
      mMFST = value
    End Set
  End Property

  Dim mMFZIP5 As Integer
  Public Property _MFZIP5 As Integer
    Get
      Return mMFZIP5
    End Get
    Set(ByVal value As Integer)
      mMFZIP5 = value
    End Set
  End Property

  Dim mMFZIP4 As Integer
  Public Property _MFZIP4 As Integer
    Get
      Return mMFZIP4
    End Get
    Set(ByVal value As Integer)
      mMFZIP4 = value
    End Set
  End Property

  Dim mMFLOCNo As String
  Public Property _MFLOCNo As String
    Get
      Return mMFLOCNo
    End Get
    Set(ByVal value As String)
      mMFLOCNo = value
    End Set
  End Property

  Dim mMFLOC As String
  Public Property _MFLOC As String
    Get
      Return mMFLOC
    End Get
    Set(ByVal value As String)
      mMFLOC = value
    End Set
  End Property

  Dim mMFPERNo As Integer
  Public Property _MFPERNo As Integer
    Get
      Return mMFPERNo
    End Get
    Set(ByVal value As Integer)
      mMFPERNo = value
    End Set
  End Property

  Dim mMFLISS As Integer
  Public Property _MFLISS As Integer
    Get
      Return mMFLISS
    End Get
    Set(ByVal value As Integer)
      mMFLISS = value
    End Set
  End Property

  Dim mMFYEAR As Integer
  Public Property _MFYEAR As Integer
    Get
      Return mMFYEAR
    End Get
    Set(ByVal value As Integer)
      mMFYEAR = value
    End Set
  End Property

  Dim mMFCOMM As String
  Public Property _MFCOMM As String
    Get
      Return mMFCOMM
    End Get
    Set(ByVal value As String)
      mMFCOMM = value
    End Set
  End Property

  Dim mSTAMPD As Integer
  Public Property _STAMPD As Integer
    Get
      Return mSTAMPD
    End Get
    Set(ByVal value As Integer)
      mSTAMPD = value
    End Set
  End Property

  Dim mSTAMPT As Integer
  Public Property _STAMPT As Integer
    Get
      Return mSTAMPT
    End Get
    Set(ByVal value As Integer)
      mSTAMPT = value
    End Set
  End Property
#End Region
End Class

