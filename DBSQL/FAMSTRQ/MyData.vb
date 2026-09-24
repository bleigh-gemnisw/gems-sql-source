Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "FAMSTR"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal NumRecs As Long) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    RecordNotFound = False
    StrSQL = "Select " & WrkTop & " * from " & cFileName
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
    StrSQL = StrSQL & " order by " & WrkSort
  End If
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(ds, cFileName)

  If ds.Tables(0).Rows.Count = 0 Then
    RecordNotFound = True
  End If
  objCommand = Nothing
  Conn.Close()
  Return ds
End Function
Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand

  StrSQL = "Select * from " & cFileName
  If WrkQry <> String.Empty Then
    StrSQL = StrSQL & " where " & WrkQry
  End If
  If WrkSort <> String.Empty Then
    StrSQL = StrSQL & " order by " & WrkSort
  End If
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  objReader = objCommand.ExecuteReader()
End Sub
Public Sub ReadQry()
  Dim Good As Boolean

  IsEOF = False
  Good = objReader.Read
  If Good Then
    GetFields()
  Else
    IsEOF = True
    objReader.Close()
  End If
End Sub
  Public Sub OpenFile()
  End Sub
	Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields()
  With objReader
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

