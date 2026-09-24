Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "PRCHK"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _CPCKNO = 0
    _CPCKDT = 0
    _CPEMP = 0
    _PAYTYP = ""
    _NAME = ""
    _ADDR1 = ""
    _ADDR2 = ""
    _ADDR3 = ""
    _CPFND = 0
    _CPDEPT = 0
    _YTDDED = 0
    _YTDGRS = 0
    _CURDED = 0
    _GROSS = 0
    _NETPAY = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkChkno As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where cpckno=" & WrkChkno
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
  Public Function PosData(ByVal WrkChkno As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where cpckno >= " & WrkChkno & " Order by cpckno"
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
  Public Sub DeleteAllRecords()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    RecordNotFound = False
    IsEOF = False
    StrSQL = "Delete from " & cFileName
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
      _CPCKNO = .Item("CPCKNO")
      _CPCKDT = .Item("CPCKDT")
      _CPEMP = .Item("CPEMP")
      _PAYTYP = .Item("PAYTYP")
      _NAME = .Item("NAME")
      _ADDR1 = .Item("ADDR1")
      _ADDR2 = .Item("ADDR2")
      _ADDR3 = .Item("ADDR3")
      _CPFND = .Item("CPFND")
      _CPDEPT = .Item("CPDEPT")
      _YTDDED = .Item("YTDDED")
      _YTDGRS = .Item("YTDGRS")
      _CURDED = .Item("CURDED")
      _GROSS = .Item("GROSS")
      _NETPAY = .Item("NETPAY")
    End With
  End Sub
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("CPCKNO") = _CPCKNO
      .Item("CPCKDT") = _CPCKDT
      .Item("CPEMP") = _CPEMP
      .Item("PAYTYP") = _PAYTYP
      .Item("NAME") = _NAME
      .Item("ADDR1") = _ADDR1
      .Item("ADDR2") = _ADDR2
      .Item("ADDR3") = _ADDR3
      .Item("CPFND") = _CPFND
      .Item("CPDEPT") = _CPDEPT
      .Item("YTDDED") = _YTDDED
      .Item("YTDGRS") = _YTDGRS
      .Item("CURDED") = _CURDED
      .Item("GROSS") = _GROSS
      .Item("NETPAY") = _NETPAY
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
  Dim mCPCKNO As Integer
  Public Property _CPCKNO As Integer
    Get
      Return mCPCKNO
    End Get
    Set(ByVal value As Integer)
      mCPCKNO = value
    End Set
  End Property

  Dim mCPCKDT As Integer
  Public Property _CPCKDT As Integer
    Get
      Return mCPCKDT
    End Get
    Set(ByVal value As Integer)
      mCPCKDT = value
    End Set
  End Property

  Dim mCPEMP As Integer
  Public Property _CPEMP As Integer
    Get
      Return mCPEMP
    End Get
    Set(ByVal value As Integer)
      mCPEMP = value
    End Set
  End Property

  Dim mPAYTYP As String
  Public Property _PAYTYP As String
    Get
      Return mPAYTYP
    End Get
    Set(ByVal value As String)
      mPAYTYP = value
    End Set
  End Property

  Dim mNAME As String
  Public Property _NAME As String
    Get
      Return mNAME
    End Get
    Set(ByVal value As String)
      mNAME = value
    End Set
  End Property

  Dim mADDR1 As String
  Public Property _ADDR1 As String
    Get
      Return mADDR1
    End Get
    Set(ByVal value As String)
      mADDR1 = value
    End Set
  End Property

  Dim mADDR2 As String
  Public Property _ADDR2 As String
    Get
      Return mADDR2
    End Get
    Set(ByVal value As String)
      mADDR2 = value
    End Set
  End Property

  Dim mADDR3 As String
  Public Property _ADDR3 As String
    Get
      Return mADDR3
    End Get
    Set(ByVal value As String)
      mADDR3 = value
    End Set
  End Property

  Dim mCPFND As Integer
  Public Property _CPFND As Integer
    Get
      Return mCPFND
    End Get
    Set(ByVal value As Integer)
      mCPFND = value
    End Set
  End Property

  Dim mCPDEPT As Integer
  Public Property _CPDEPT As Integer
    Get
      Return mCPDEPT
    End Get
    Set(ByVal value As Integer)
      mCPDEPT = value
    End Set
  End Property

  Dim mYTDDED As Decimal
  Public Property _YTDDED As Decimal
    Get
      Return mYTDDED
    End Get
    Set(ByVal value As Decimal)
      mYTDDED = value
    End Set
  End Property

  Dim mYTDGRS As Decimal
  Public Property _YTDGRS As Decimal
    Get
      Return mYTDGRS
    End Get
    Set(ByVal value As Decimal)
      mYTDGRS = value
    End Set
  End Property

  Dim mCURDED As Decimal
  Public Property _CURDED As Decimal
    Get
      Return mCURDED
    End Get
    Set(ByVal value As Decimal)
      mCURDED = value
    End Set
  End Property

  Dim mGROSS As Decimal
  Public Property _GROSS As Decimal
    Get
      Return mGROSS
    End Get
    Set(ByVal value As Decimal)
      mGROSS = value
    End Set
  End Property

  Dim mNETPAY As Decimal
  Public Property _NETPAY As Decimal
    Get
      Return mNETPAY
    End Get
    Set(ByVal value As Decimal)
      mNETPAY = value
    End Set
  End Property
#End Region
End Class

