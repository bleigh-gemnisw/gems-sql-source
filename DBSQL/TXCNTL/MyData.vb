
Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXCNTL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_RECID = string.empty
_COFC  = 0
_STACD = string.empty
_SFR = string.empty
_SFM = string.empty
_SFP = string.empty
_ASRNAM = string.empty
_ASRTTL = string.empty
_ASRPHN = string.empty
_ASRFAX = string.empty
_ASRGL  = 0

End Sub
  Public Sub GetOneRecordP(ByVal WrkRecID As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where recid='" & WrkRecID & "'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
 ClearFields 
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
  Public Function PosData(ByVal WrkRecID As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where recid>='" & WrkRecID & "'"
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
#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _COFC = .Item("COFC")
      _STACD = .Item("STACD")
      _SFR = .Item("SFR")
      _SFM = .Item("SFM")
      _SFP = .Item("SFP")
      _ASRNAM = .Item("ASRNAM")
      _ASRTTL = .Item("ASRTTL")
      _ASRPHN = .Item("ASRPHN")
      _ASRFAX = .Item("ASRFAX")
      _ASRGL = .Item("ASRGL")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("COFC") = _COFC
      .Item("STACD") = _STACD
      .Item("SFR") = _SFR
      .Item("SFM") = _SFM
      .Item("SFP") = _SFP
      .Item("ASRNAM") = _ASRNAM
      .Item("ASRTTL") = _ASRTTL
      .Item("ASRPHN") = _ASRPHN
      .Item("ASRFAX") = _ASRFAX
      .Item("ASRGL") = _ASRGL
    End With
  End Sub
#End Region

#Region "Properties: Fields"
  Dim mRECID As String
  Public Property _RECID as string   
    Get
        Return mRECID
    End Get
    set(byval value as string)
        mRECID = value
    End Set
End Property

Dim mCOFC  as integer 
Public Property _COFC  as integer   
    Get
        Return mCOFC
    End Get
    set(byval value as integer)
        mCOFC = value
    End Set
End Property

Dim mSTACD as string 
Public Property _STACD as string   
    Get
        Return mSTACD
    End Get
    set(byval value as string)
        mSTACD = value
    End Set
End Property

Dim mSFR as string 
Public Property _SFR as string   
    Get
        Return mSFR
    End Get
    set(byval value as string)
        mSFR = value
    End Set
End Property

Dim mSFM as string 
Public Property _SFM as string   
    Get
        Return mSFM
    End Get
    set(byval value as string)
        mSFM = value
    End Set
End Property

Dim mSFP as string 
Public Property _SFP as string   
    Get
        Return mSFP
    End Get
    set(byval value as string)
        mSFP = value
    End Set
End Property

Dim mASRNAM as string 
Public Property _ASRNAM as string   
    Get
        Return mASRNAM
    End Get
    set(byval value as string)
        mASRNAM = value
    End Set
End Property

Dim mASRTTL as string 
Public Property _ASRTTL as string   
    Get
        Return mASRTTL
    End Get
    set(byval value as string)
        mASRTTL = value
    End Set
End Property

Dim mASRPHN as string 
Public Property _ASRPHN as string   
    Get
        Return mASRPHN
    End Get
    set(byval value as string)
        mASRPHN = value
    End Set
End Property

Dim mASRFAX as string 
Public Property _ASRFAX as string   
    Get
        Return mASRFAX
    End Get
    set(byval value as string)
        mASRFAX = value
    End Set
End Property

Dim mASRGL  as integer 
Public Property _ASRGL  as integer   
    Get
        Return mASRGL
    End Get
    set(byval value as integer)
        mASRGL = value
    End Set
End Property
Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class

