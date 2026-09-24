Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "AP1099P"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal WrkYear As String, ByVal WrkAcct As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where ayear=" & WrkYear & " and aracct='" & WrkAcct & "'"
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

   StrSQL = "Delete from " & cFileName

  RecordNotFound = False
  IsEOF = False
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
    _AYEAR = .Item("AYEAR")
    _AFEDID = .Item("AFEDID")
    _APNAME = .Item("APNAME")
    _APADR1 = .Item("APADR1")
    _APADR2 = .Item("APADR2")
    _APADR3 = .Item("APADR3")
    _APPHON = .Item("APPHON")
    _ATAXID = .Item("ATAXID")
    _ARNAME = .Item("ARNAME")
    _ARADR1 = .Item("ARADR1")
    _ARADR2 = .Item("ARADR2")
    _ARADR3 = .Item("ARADR3")
    _ARADR4 = .Item("ARADR4")
    _ARACCT = .Item("ARACCT")
    _AMISAM = .Item("AMISAM")
    _ASTCDE = .Item("ASTCDE")
    _ASTEID = .Item("ASTEID")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("AYEAR") = _AYEAR
    .Item("AFEDID") = _AFEDID
    .Item("APNAME") = _APNAME
    .Item("APADR1") = _APADR1
    .Item("APADR2") = _APADR2
    .Item("APADR3") = _APADR3
    .Item("APPHON") = _APPHON
    .Item("ATAXID") = _ATAXID
    .Item("ARNAME") = _ARNAME
    .Item("ARADR1") = _ARADR1
    .Item("ARADR2") = _ARADR2
    .Item("ARADR3") = _ARADR3
    .Item("ARADR4") = _ARADR4
    .Item("ARACCT") = _ARACCT
    .Item("AMISAM") = _AMISAM
    .Item("ASTCDE") = _ASTCDE
    .Item("ASTEID") = _ASTEID
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
Dim mAYEAR As Integer
Public Property _AYEAR As Integer
    Get
        Return mAYEAR
    End Get
    Set(ByVal value As Integer)
        mAYEAR = value
    End Set
End Property
Dim mAFEDID As String
Public Property _AFEDID As String
    Get
        Return mAFEDID
    End Get
    Set(ByVal value As String)
        mAFEDID = value
    End Set
End Property
Dim mAPNAME As String
Public Property _APNAME As String
    Get
        Return mAPNAME
    End Get
    Set(ByVal value As String)
        mAPNAME = value
    End Set
End Property
Dim mAPADR1 As String
Public Property _APADR1 As String
    Get
        Return mAPADR1
    End Get
    Set(ByVal value As String)
        mAPADR1 = value
    End Set
End Property
Dim mAPADR2 As String
Public Property _APADR2 As String
    Get
        Return mAPADR2
    End Get
    Set(ByVal value As String)
        mAPADR2 = value
    End Set
End Property
Dim mAPADR3 As String
Public Property _APADR3 As String
    Get
        Return mAPADR3
    End Get
    Set(ByVal value As String)
        mAPADR3 = value
    End Set
End Property
Dim mAPPHON As String
Public Property _APPHON As String
    Get
        Return mAPPHON
    End Get
    Set(ByVal value As String)
        mAPPHON = value
    End Set
End Property
Dim mATAXID As String
Public Property _ATAXID As String
    Get
        Return mATAXID
    End Get
    Set(ByVal value As String)
        mATAXID = value
    End Set
End Property
Dim mARNAME As String
Public Property _ARNAME As String
    Get
        Return mARNAME
    End Get
    Set(ByVal value As String)
        mARNAME = value
    End Set
End Property
Dim mARADR1 As String
Public Property _ARADR1 As String
    Get
        Return mARADR1
    End Get
    Set(ByVal value As String)
        mARADR1 = value
    End Set
End Property
Dim mARADR2 As String
Public Property _ARADR2 As String
    Get
        Return mARADR2
    End Get
    Set(ByVal value As String)
        mARADR2 = value
    End Set
End Property
Dim mARADR3 As String
Public Property _ARADR3 As String
    Get
        Return mARADR3
    End Get
    Set(ByVal value As String)
        mARADR3 = value
    End Set
End Property
Dim mARADR4 As String
Public Property _ARADR4 As String
    Get
        Return mARADR4
    End Get
    Set(ByVal value As String)
        mARADR4 = value
    End Set
End Property
Dim mARACCT As String
Public Property _ARACCT As String
    Get
        Return mARACCT
    End Get
    Set(ByVal value As String)
        mARACCT = value
    End Set
End Property
Dim mAMISAM As Decimal
Public Property _AMISAM As Decimal
    Get
        Return mAMISAM
    End Get
    Set(ByVal value As Decimal)
        mAMISAM = value
    End Set
End Property
Dim mASTCDE As String
Public Property _ASTCDE As String
    Get
        Return mASTCDE
    End Get
    Set(ByVal value As String)
        mASTCDE = value
    End Set
End Property
Dim mASTEID As String
Public Property _ASTEID As String
    Get
        Return mASTEID
    End Get
    Set(ByVal value As String)
        mASTEID = value
    End Set
End Property
#End Region
End Class

