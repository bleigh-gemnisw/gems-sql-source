Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "APERCN"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal WrkPaybn As String, ByVal WrkPayck As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where paybn='" & WrkPaybn & _
   "' and payck = " & WrkPayck
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
    _PAYBN = .Item("PAYBN")
    _PAYCK = .Item("PAYCK")
    _PAYAM = .Item("PAYAM")
    _VNDNR = .Item("VNDNR")
    _RCCDE = .Item("RCCDE")
    _PAYCM = .Item("PAYCM")
    _MANUL = .Item("MANUL")
    _PENDC = .Item("PENDC")
    _BANKRP = .Item("BANKRP")
    _PAYP8 = .Item("PAYP8")
    _PAYC8 = .Item("PAYC8")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("PAYBN") = _PAYBN
    .Item("PAYCK") = _PAYCK
    .Item("PAYAM") = _PAYAM
    .Item("VNDNR") = _VNDNR
    .Item("RCCDE") = _RCCDE
    .Item("PAYCM") = _PAYCM
    .Item("MANUL") = _MANUL
    .Item("PENDC") = _PENDC
    .Item("BANKRP") = _BANKRP
    .Item("PAYP8") = _PAYP8
    .Item("PAYC8") = _PAYC8
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
Dim mPAYBN As String
Public Property _PAYBN As String
    Get
        Return mPAYBN
    End Get
    Set(ByVal value As String)
        mPAYBN = value
    End Set
End Property
Dim mPAYCK As Integer
Public Property _PAYCK As Integer
    Get
        Return mPAYCK
    End Get
    Set(ByVal value As Integer)
        mPAYCK = value
    End Set
End Property
Dim mPAYAM As Decimal
Public Property _PAYAM As Decimal
    Get
        Return mPAYAM
    End Get
    Set(ByVal value As Decimal)
        mPAYAM = value
    End Set
End Property
Dim mVNDNR As String
Public Property _VNDNR As String
    Get
        Return mVNDNR
    End Get
    Set(ByVal value As String)
        mVNDNR = value
    End Set
End Property
Dim mRCCDE As String
Public Property _RCCDE As String
    Get
        Return mRCCDE
    End Get
    Set(ByVal value As String)
        mRCCDE = value
    End Set
End Property
Dim mPAYCM As Decimal
Public Property _PAYCM As Decimal
    Get
        Return mPAYCM
    End Get
    Set(ByVal value As Decimal)
        mPAYCM = value
    End Set
End Property
Dim mMANUL As String
Public Property _MANUL As String
    Get
        Return mMANUL
    End Get
    Set(ByVal value As String)
        mMANUL = value
    End Set
End Property
Dim mPENDC As String
Public Property _PENDC As String
    Get
        Return mPENDC
    End Get
    Set(ByVal value As String)
        mPENDC = value
    End Set
End Property
Dim mBANKRP As String
Public Property _BANKRP As String
    Get
        Return mBANKRP
    End Get
    Set(ByVal value As String)
        mBANKRP = value
    End Set
End Property
Dim mPAYP8 As Integer
Public Property _PAYP8 As Integer
    Get
        Return mPAYP8
    End Get
    Set(ByVal value As Integer)
        mPAYP8 = value
    End Set
End Property
Dim mPAYC8 As Integer
Public Property _PAYC8 As Integer
    Get
        Return mPAYC8
    End Get
    Set(ByVal value As Integer)
        mPAYC8 = value
    End Set
End Property
#End Region
End Class

