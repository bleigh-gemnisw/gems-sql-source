Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "FAMSTR"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function AutoGenKey() As Integer
    Dim NextKey As Integer
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select top 1 * from " & cFileName & " order by fatag desc"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count = 0 Then
        NextKey = 1
      Else
        NextKey = ds.Tables(0).Rows(0).Item("fatag") + 1
      End If
      objCommand = Nothing
      ds.Clear()
      ds = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
    Return NextKey
  End Function
  Public Sub GetOneRecordP(ByVal TagNo As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where fatag='" & Trim(TagNo) & "'"
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
Public Function PosData(ByVal TagNo As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where fatag>='" & Trim(TagNo) & "'"
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
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Tag", Type.GetType("System.String"))
      .Columns.Add("Fisc", Type.GetType("System.Int32"))
      .Columns.Add("Wkdate", Type.GetType("System.Int32"))
      .Columns.Add("dedt", Type.GetType("System.Int32"))
      .Columns.Add("devl", Type.GetType("System.Int32"))
      .Columns.Add("Adj", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
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

#Region "Properties: Set Fields"
Private Sub GetFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    _FASTAT = .Item("FASTAT")
    _FATAG = .Item("FATAG")
    _FADESC = .Item("FADESC")
    _FASERL = .Item("FASERL")
    _FAQTY = .Item("FAQTY")
    _FACLCD = .Item("FACLCD")
    _FABLCD = .Item("FABLCD")
    _FALOC = .Item("FALOC")
    _FAASCD = .Item("FAASCD")
    _FADECD = .Item("FADECD")
    _FAEQCD = .Item("FAEQCD")
    _FAEYR = .Item("FAEYR")
    _FAEDT = .Item("FAEDT")
    _FAFND = .Item("FAFND")
    _FASFND = .Item("FASFND")
    _FADPT = .Item("FADPT")
    _FAOBJ = .Item("FAOBJ")
    _FAFCN = .Item("FAFCN")
    _FASFCN = .Item("FASFCN")
    _FAFND2 = .Item("FAFND2")
    _FASFN2 = .Item("FASFN2")
    _FADPT2 = .Item("FADPT2")
    _FAOBJ2 = .Item("FAOBJ2")
    _FAFCN2 = .Item("FAFCN2")
    _FASFC2 = .Item("FASFC2")
    _FAAQCD = .Item("FAAQCD")
    _FAAQVL = .Item("FAAQVL")
    _FAAQDT = .Item("FAAQDT")
    _FADSCD = .Item("FADSCD")
    _FADSVL = .Item("FADSVL")
    _FADSDT = .Item("FADSDT")
    _FAINV = .Item("FAINV")
    _FAVEND = .Item("FAVEND")
    _FADEVL = .Item("FADEVL")
    _FADEDT = .Item("FADEDT")
    _FAGLGP = .Item("FAGLGP")
    _FANDEP = .Item("FANDEP")
    _FANREP = .Item("FANREP")
    _FAGOV = .Item("FAGOV")
    _FAU1CD = .Item("FAU1CD")
    _FAU2CD = .Item("FAU2CD")
    _FAU3CD = .Item("FAU3CD")
    _FAU4TX = .Item("FAU4TX")
    _FAU5TX = .Item("FAU5TX")
    _FASUBL = .Item("FASUBL")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FASTAT") = _FASTAT
    .Item("FATAG") = _FATAG
    .Item("FADESC") = _FADESC
    .Item("FASERL") = _FASERL
    .Item("FAQTY") = _FAQTY
    .Item("FACLCD") = _FACLCD
    .Item("FABLCD") = _FABLCD
    .Item("FALOC") = _FALOC
    .Item("FAASCD") = _FAASCD
    .Item("FADECD") = _FADECD
    .Item("FAEQCD") = _FAEQCD
    .Item("FAEYR") = _FAEYR
    .Item("FAEDT") = _FAEDT
    .Item("FAFND") = _FAFND
    .Item("FASFND") = _FASFND
    .Item("FADPT") = _FADPT
    .Item("FAOBJ") = _FAOBJ
    .Item("FAFCN") = _FAFCN
    .Item("FASFCN") = _FASFCN
    .Item("FAFND2") = _FAFND2
    .Item("FASFN2") = _FASFN2
    .Item("FADPT2") = _FADPT2
    .Item("FAOBJ2") = _FAOBJ2
    .Item("FAFCN2") = _FAFCN2
    .Item("FASFC2") = _FASFC2
    .Item("FAAQCD") = _FAAQCD
    .Item("FAAQVL") = _FAAQVL
    .Item("FAAQDT") = _FAAQDT
    .Item("FADSCD") = _FADSCD
    .Item("FADSVL") = _FADSVL
    .Item("FADSDT") = _FADSDT
    .Item("FAINV") = _FAINV
    .Item("FAVEND") = _FAVEND
    .Item("FADEVL") = _FADEVL
    .Item("FADEDT") = _FADEDT
    .Item("FAGLGP") = _FAGLGP
    .Item("FANDEP") = _FANDEP
    .Item("FANREP") = _FANREP
    .Item("FAGOV") = _FAGOV
    .Item("FAU1CD") = _FAU1CD
    .Item("FAU2CD") = _FAU2CD
    .Item("FAU3CD") = _FAU3CD
    .Item("FAU4TX") = _FAU4TX
    .Item("FAU5TX") = _FAU5TX
    .Item("FASUBL") = _FASUBL
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
Dim mFASTAT As String
Public Property _FASTAT As String
    Get
        Return mFASTAT
    End Get
    Set(ByVal value As String)
        mFASTAT = value
    End Set
End Property
Dim mFATAG As String
Public Property _FATAG As String
    Get
        Return mFATAG
    End Get
    Set(ByVal value As String)
        mFATAG = value
    End Set
End Property
Dim mFADESC As String
Public Property _FADESC As String
    Get
        Return mFADESC
    End Get
    Set(ByVal value As String)
        mFADESC = value
    End Set
End Property
Dim mFASERL As String
Public Property _FASERL As String
    Get
        Return mFASERL
    End Get
    Set(ByVal value As String)
        mFASERL = value
    End Set
End Property
Dim mFAQTY As Integer
Public Property _FAQTY As Integer
    Get
        Return mFAQTY
    End Get
    Set(ByVal value As Integer)
        mFAQTY = value
    End Set
End Property
Dim mFACLCD As String
Public Property _FACLCD As String
    Get
        Return mFACLCD
    End Get
    Set(ByVal value As String)
        mFACLCD = value
    End Set
End Property
Dim mFABLCD As String
Public Property _FABLCD As String
    Get
        Return mFABLCD
    End Get
    Set(ByVal value As String)
        mFABLCD = value
    End Set
End Property
Dim mFALOC As String
Public Property _FALOC As String
    Get
        Return mFALOC
    End Get
    Set(ByVal value As String)
        mFALOC = value
    End Set
End Property
Dim mFAASCD As String
Public Property _FAASCD As String
    Get
        Return mFAASCD
    End Get
    Set(ByVal value As String)
        mFAASCD = value
    End Set
End Property
Dim mFADECD As String
Public Property _FADECD As String
    Get
        Return mFADECD
    End Get
    Set(ByVal value As String)
        mFADECD = value
    End Set
End Property
Dim mFAEQCD As String
Public Property _FAEQCD As String
    Get
        Return mFAEQCD
    End Get
    Set(ByVal value As String)
        mFAEQCD = value
    End Set
End Property
Dim mFAEYR As Integer
Public Property _FAEYR As Integer
    Get
        Return mFAEYR
    End Get
    Set(ByVal value As Integer)
        mFAEYR = value
    End Set
End Property
Dim mFAEDT As Integer
Public Property _FAEDT As Integer
    Get
        Return mFAEDT
    End Get
    Set(ByVal value As Integer)
        mFAEDT = value
    End Set
End Property
Dim mFAFND As Integer
Public Property _FAFND As Integer
    Get
        Return mFAFND
    End Get
    Set(ByVal value As Integer)
        mFAFND = value
    End Set
End Property
Dim mFASFND As Integer
Public Property _FASFND As Integer
    Get
        Return mFASFND
    End Get
    Set(ByVal value As Integer)
        mFASFND = value
    End Set
End Property
Dim mFADPT As Integer
Public Property _FADPT As Integer
    Get
        Return mFADPT
    End Get
    Set(ByVal value As Integer)
        mFADPT = value
    End Set
End Property
Dim mFAOBJ As Integer
Public Property _FAOBJ As Integer
    Get
        Return mFAOBJ
    End Get
    Set(ByVal value As Integer)
        mFAOBJ = value
    End Set
End Property
Dim mFAFCN As Integer
Public Property _FAFCN As Integer
    Get
        Return mFAFCN
    End Get
    Set(ByVal value As Integer)
        mFAFCN = value
    End Set
End Property
Dim mFASFCN As Integer
Public Property _FASFCN As Integer
    Get
        Return mFASFCN
    End Get
    Set(ByVal value As Integer)
        mFASFCN = value
    End Set
End Property
Dim mFAFND2 As Integer
Public Property _FAFND2 As Integer
    Get
        Return mFAFND2
    End Get
    Set(ByVal value As Integer)
        mFAFND2 = value
    End Set
End Property
Dim mFASFN2 As Integer
Public Property _FASFN2 As Integer
    Get
        Return mFASFN2
    End Get
    Set(ByVal value As Integer)
        mFASFN2 = value
    End Set
End Property
Dim mFADPT2 As Integer
Public Property _FADPT2 As Integer
    Get
        Return mFADPT2
    End Get
    Set(ByVal value As Integer)
        mFADPT2 = value
    End Set
End Property
Dim mFAOBJ2 As Integer
Public Property _FAOBJ2 As Integer
    Get
        Return mFAOBJ2
    End Get
    Set(ByVal value As Integer)
        mFAOBJ2 = value
    End Set
End Property
Dim mFAFCN2 As Integer
Public Property _FAFCN2 As Integer
    Get
        Return mFAFCN2
    End Get
    Set(ByVal value As Integer)
        mFAFCN2 = value
    End Set
End Property
Dim mFASFC2 As Integer
Public Property _FASFC2 As Integer
    Get
        Return mFASFC2
    End Get
    Set(ByVal value As Integer)
        mFASFC2 = value
    End Set
End Property
Dim mFAAQCD As String
Public Property _FAAQCD As String
    Get
        Return mFAAQCD
    End Get
    Set(ByVal value As String)
        mFAAQCD = value
    End Set
End Property
Dim mFAAQVL As Decimal
Public Property _FAAQVL As Decimal
    Get
        Return mFAAQVL
    End Get
    Set(ByVal value As Decimal)
        mFAAQVL = value
    End Set
End Property
Dim mFAAQDT As Integer
Public Property _FAAQDT As Integer
    Get
        Return mFAAQDT
    End Get
    Set(ByVal value As Integer)
        mFAAQDT = value
    End Set
End Property
Dim mFADSCD As String
Public Property _FADSCD As String
    Get
        Return mFADSCD
    End Get
    Set(ByVal value As String)
        mFADSCD = value
    End Set
End Property
Dim mFADSVL As Decimal
Public Property _FADSVL As Decimal
    Get
        Return mFADSVL
    End Get
    Set(ByVal value As Decimal)
        mFADSVL = value
    End Set
End Property
Dim mFADSDT As Integer
Public Property _FADSDT As Integer
    Get
        Return mFADSDT
    End Get
    Set(ByVal value As Integer)
        mFADSDT = value
    End Set
End Property
Dim mFAINV As String
Public Property _FAINV As String
    Get
        Return mFAINV
    End Get
    Set(ByVal value As String)
        mFAINV = value
    End Set
End Property
Dim mFAVEND As String
Public Property _FAVEND As String
    Get
        Return mFAVEND
    End Get
    Set(ByVal value As String)
        mFAVEND = value
    End Set
End Property
Dim mFADEVL As Decimal
Public Property _FADEVL As Decimal
    Get
        Return mFADEVL
    End Get
    Set(ByVal value As Decimal)
        mFADEVL = value
    End Set
End Property
Dim mFADEDT As Integer
Public Property _FADEDT As Integer
    Get
        Return mFADEDT
    End Get
    Set(ByVal value As Integer)
        mFADEDT = value
    End Set
End Property
Dim mFAGLGP As String
Public Property _FAGLGP As String
    Get
        Return mFAGLGP
    End Get
    Set(ByVal value As String)
        mFAGLGP = value
    End Set
End Property
Dim mFANDEP As String
Public Property _FANDEP As String
    Get
        Return mFANDEP
    End Get
    Set(ByVal value As String)
        mFANDEP = value
    End Set
End Property
Dim mFANREP As String
Public Property _FANREP As String
    Get
        Return mFANREP
    End Get
    Set(ByVal value As String)
        mFANREP = value
    End Set
End Property
Dim mFAGOV As String
Public Property _FAGOV As String
    Get
        Return mFAGOV
    End Get
    Set(ByVal value As String)
        mFAGOV = value
    End Set
End Property
Dim mFAU1CD As String
Public Property _FAU1CD As String
    Get
        Return mFAU1CD
    End Get
    Set(ByVal value As String)
        mFAU1CD = value
    End Set
End Property
Dim mFAU2CD As String
Public Property _FAU2CD As String
    Get
        Return mFAU2CD
    End Get
    Set(ByVal value As String)
        mFAU2CD = value
    End Set
End Property
Dim mFAU3CD As String
Public Property _FAU3CD As String
    Get
        Return mFAU3CD
    End Get
    Set(ByVal value As String)
        mFAU3CD = value
    End Set
End Property
Dim mFAU4TX As String
Public Property _FAU4TX As String
    Get
        Return mFAU4TX
    End Get
    Set(ByVal value As String)
        mFAU4TX = value
    End Set
End Property
Dim mFAU5TX As String
Public Property _FAU5TX As String
    Get
        Return mFAU5TX
    End Get
    Set(ByVal value As String)
        mFAU5TX = value
    End Set
End Property
Dim mFASUBL As String
Public Property _FASUBL As String
    Get
        Return mFASUBL
    End Get
    Set(ByVal value As String)
        mFASUBL = value
    End Set
End Property
#End Region

End Class

