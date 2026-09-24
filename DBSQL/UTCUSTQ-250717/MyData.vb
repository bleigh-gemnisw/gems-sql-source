Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Const cFileName As String = "UTCUST"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
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
      _CUACCT = .Item("CUACCT")
      _CUNAM1 = .Item("CUNAM1")
      _CUNAM2 = .Item("CUNAM2")
      _CUADD1 = .Item("CUADD1")
      _CUADD2 = .Item("CUADD2")
      _CUCITY = .Item("CUCITY")
      _CUST = .Item("CUST")
      _CUZIP = .Item("CUZIP")
      _CUMAD1 = .Item("CUMAD1")
      _CUMAD2 = .Item("CUMAD2")
      _CUMCTY = .Item("CUMCTY")
      _CUMST = .Item("CUMST")
      _CUMZIP = .Item("CUMZIP")
      _CUTELNO = .Item("CUTEL#")
      _CUDST = .Item("CUDST")
      _CUPHAS = .Item("CUPHAS")
      _CUADDX = .Item("CUADDX")
      _CUTIE = .Item("CUTIE")
      _CUMAP = .Item("CUMAP")
      _CUVOLM = .Item("CUVOLM")
      _CUPAGE = .Item("CUPAGE")
      _CUZONE = .Item("CUZONE")
      _CUPCAT = .Item("CUPCAT")
      _CUXREF = .Item("CUXREF")
      _CUMSIZ = .Item("CUMSIZ")
      _CUUPMT = .Item("CUUPMT")
      _CUUNIT = .Item("CUUNIT")
      _CUEDU = .Item("CUEDU")
      _CUSFIX = .Item("CUSFIX")
      _CUXTRA = .Item("CUXTRA")
      _CUWFIX = .Item("CUWFIX")
      _CUSCHR = .Item("CUSCHR")
      _CUAPMT = .Item("CUAPMT")
      _CUAUNT = .Item("CUAUNT")
      _CUPVAL = .Item("CUPVAL")
      _CUFOOT = .Item("CUFOOT")
      _CUACRE = .Item("CUACRE")
      _CYC = .Item("CYC")
      _OID = .Item("OID")
      _CUSERN = .Item("CUSERN")
      _CUROUT = .Item("CUROUT")
      _CUMETN = .Item("CUMETN")
      _CUMETP = .Item("CUMETP")
      _CUREGN = .Item("CUREGN")
      _CULOCNO = .Item("CULOC#")
      _CULOC = .Item("CULOC")
      _CUCNTNO = .Item("CUCNT#")
      _CUAPLNO = .Item("CUAPL#")
      _CUFUND = .Item("CUFUND")
      _CUSECT = .Item("CUSECT")
      _CUSDES = .Item("CUSDES")
      _CULAT = .Item("CULAT")
      _CULONG = .Item("CULONG")
    End With
  End Sub
#End Region

#Region "Properties: Fields"

  Dim mCUACCT As Integer
  Public Property _CUACCT As Integer
    Get
      Return mCUACCT
    End Get
    Set(ByVal value As Integer)
      mCUACCT = value
    End Set
  End Property

  Dim mCUNAM1 As String
  Public Property _CUNAM1 As String
    Get
      Return mCUNAM1
    End Get
    Set(ByVal value As String)
      mCUNAM1 = value
    End Set
  End Property

  Dim mCUNAM2 As String
  Public Property _CUNAM2 As String
    Get
      Return mCUNAM2
    End Get
    Set(ByVal value As String)
      mCUNAM2 = value
    End Set
  End Property

  Dim mCUADD1 As String
  Public Property _CUADD1 As String
    Get
      Return mCUADD1
    End Get
    Set(ByVal value As String)
      mCUADD1 = value
    End Set
  End Property

  Dim mCUADD2 As String
  Public Property _CUADD2 As String
    Get
      Return mCUADD2
    End Get
    Set(ByVal value As String)
      mCUADD2 = value
    End Set
  End Property

  Dim mCUCITY As String
  Public Property _CUCITY As String
    Get
      Return mCUCITY
    End Get
    Set(ByVal value As String)
      mCUCITY = value
    End Set
  End Property

  Dim mCUST As String
  Public Property _CUST As String
    Get
      Return mCUST
    End Get
    Set(ByVal value As String)
      mCUST = value
    End Set
  End Property

  Dim mCUZIP As String
  Public Property _CUZIP As String
    Get
      Return mCUZIP
    End Get
    Set(ByVal value As String)
      mCUZIP = value
    End Set
  End Property

  Dim mCUMAD1 As String
  Public Property _CUMAD1 As String
    Get
      Return mCUMAD1
    End Get
    Set(ByVal value As String)
      mCUMAD1 = value
    End Set
  End Property

  Dim mCUMAD2 As String
  Public Property _CUMAD2 As String
    Get
      Return mCUMAD2
    End Get
    Set(ByVal value As String)
      mCUMAD2 = value
    End Set
  End Property

  Dim mCUMCTY As String
  Public Property _CUMCTY As String
    Get
      Return mCUMCTY
    End Get
    Set(ByVal value As String)
      mCUMCTY = value
    End Set
  End Property

  Dim mCUMST As String
  Public Property _CUMST As String
    Get
      Return mCUMST
    End Get
    Set(ByVal value As String)
      mCUMST = value
    End Set
  End Property

  Dim mCUMZIP As String
  Public Property _CUMZIP As String
    Get
      Return mCUMZIP
    End Get
    Set(ByVal value As String)
      mCUMZIP = value
    End Set
  End Property

  Dim mCUTELNO As String
  Public Property _CUTELNO As String
    Get
      Return mCUTELNO
    End Get
    Set(ByVal value As String)
      mCUTELNO = value
    End Set
  End Property

  Dim mCUDST As Integer
  Public Property _CUDST As Integer
    Get
      Return mCUDST
    End Get
    Set(ByVal value As Integer)
      mCUDST = value
    End Set
  End Property

  Dim mCUPHAS As Integer
  Public Property _CUPHAS As Integer
    Get
      Return mCUPHAS
    End Get
    Set(ByVal value As Integer)
      mCUPHAS = value
    End Set
  End Property

  Dim mCUADDX As String
  Public Property _CUADDX As String
    Get
      Return mCUADDX
    End Get
    Set(ByVal value As String)
      mCUADDX = value
    End Set
  End Property

  Dim mCUTIE As Integer
  Public Property _CUTIE As Integer
    Get
      Return mCUTIE
    End Get
    Set(ByVal value As Integer)
      mCUTIE = value
    End Set
  End Property

  Dim mCUMAP As String
  Public Property _CUMAP As String
    Get
      Return mCUMAP
    End Get
    Set(ByVal value As String)
      mCUMAP = value
    End Set
  End Property

  Dim mCUVOLM As String
  Public Property _CUVOLM As String
    Get
      Return mCUVOLM
    End Get
    Set(ByVal value As String)
      mCUVOLM = value
    End Set
  End Property

  Dim mCUPAGE As String
  Public Property _CUPAGE As String
    Get
      Return mCUPAGE
    End Get
    Set(ByVal value As String)
      mCUPAGE = value
    End Set
  End Property

  Dim mCUZONE As String
  Public Property _CUZONE As String
    Get
      Return mCUZONE
    End Get
    Set(ByVal value As String)
      mCUZONE = value
    End Set
  End Property

  Dim mCUPCAT As String
  Public Property _CUPCAT As String
    Get
      Return mCUPCAT
    End Get
    Set(ByVal value As String)
      mCUPCAT = value
    End Set
  End Property

  Dim mCUXREF As String
  Public Property _CUXREF As String
    Get
      Return mCUXREF
    End Get
    Set(ByVal value As String)
      mCUXREF = value
    End Set
  End Property

  Dim mCUMSIZ As String
  Public Property _CUMSIZ As String
    Get
      Return mCUMSIZ
    End Get
    Set(ByVal value As String)
      mCUMSIZ = value
    End Set
  End Property

  Dim mCUUPMT As String
  Public Property _CUUPMT As String
    Get
      Return mCUUPMT
    End Get
    Set(ByVal value As String)
      mCUUPMT = value
    End Set
  End Property

  Dim mCUUNIT As Decimal
  Public Property _CUUNIT As Decimal
    Get
      Return mCUUNIT
    End Get
    Set(ByVal value As Decimal)
      mCUUNIT = value
    End Set
  End Property

  Dim mCUEDU As Decimal
  Public Property _CUEDU As Decimal
    Get
      Return mCUEDU
    End Get
    Set(ByVal value As Decimal)
      mCUEDU = value
    End Set
  End Property

  Dim mCUSFIX As Integer
  Public Property _CUSFIX As Integer
    Get
      Return mCUSFIX
    End Get
    Set(ByVal value As Integer)
      mCUSFIX = value
    End Set
  End Property

  Dim mCUXTRA As Integer
  Public Property _CUXTRA As Integer
    Get
      Return mCUXTRA
    End Get
    Set(ByVal value As Integer)
      mCUXTRA = value
    End Set
  End Property

  Dim mCUWFIX As Integer
  Public Property _CUWFIX As Integer
    Get
      Return mCUWFIX
    End Get
    Set(ByVal value As Integer)
      mCUWFIX = value
    End Set
  End Property

  Dim mCUSCHR As Decimal
  Public Property _CUSCHR As Decimal
    Get
      Return mCUSCHR
    End Get
    Set(ByVal value As Decimal)
      mCUSCHR = value
    End Set
  End Property

  Dim mCUAPMT As String
  Public Property _CUAPMT As String
    Get
      Return mCUAPMT
    End Get
    Set(ByVal value As String)
      mCUAPMT = value
    End Set
  End Property

  Dim mCUAUNT As Decimal
  Public Property _CUAUNT As Decimal
    Get
      Return mCUAUNT
    End Get
    Set(ByVal value As Decimal)
      mCUAUNT = value
    End Set
  End Property

  Dim mCUPVAL As Long
  Public Property _CUPVAL As Long
    Get
      Return mCUPVAL
    End Get
    Set(ByVal value As Long)
      mCUPVAL = value
    End Set
  End Property

  Dim mCUFOOT As Decimal
  Public Property _CUFOOT As Decimal
    Get
      Return mCUFOOT
    End Get
    Set(ByVal value As Decimal)
      mCUFOOT = value
    End Set
  End Property

  Dim mCUACRE As Decimal
  Public Property _CUACRE As Decimal
    Get
      Return mCUACRE
    End Get
    Set(ByVal value As Decimal)
      mCUACRE = value
    End Set
  End Property

  Dim mCYC As String
  Public Property _CYC As String
    Get
      Return mCYC
    End Get
    Set(ByVal value As String)
      mCYC = value
    End Set
  End Property

  Dim mOID As String
  Public Property _OID As String
    Get
      Return mOID
    End Get
    Set(ByVal value As String)
      mOID = value
    End Set
  End Property

  Dim mCUSERN As String
  Public Property _CUSERN As String
    Get
      Return mCUSERN
    End Get
    Set(ByVal value As String)
      mCUSERN = value
    End Set
  End Property

  Dim mCUROUT As String
  Public Property _CUROUT As String
    Get
      Return mCUROUT
    End Get
    Set(ByVal value As String)
      mCUROUT = value
    End Set
  End Property

  Dim mCUMETN As String
  Public Property _CUMETN As String
    Get
      Return mCUMETN
    End Get
    Set(ByVal value As String)
      mCUMETN = value
    End Set
  End Property

  Dim mCUMETP As String
  Public Property _CUMETP As String
    Get
      Return mCUMETP
    End Get
    Set(ByVal value As String)
      mCUMETP = value
    End Set
  End Property

  Dim mCUREGN As String
  Public Property _CUREGN As String
    Get
      Return mCUREGN
    End Get
    Set(ByVal value As String)
      mCUREGN = value
    End Set
  End Property

  Dim mCULOCNO As String
  Public Property _CULOCNO As String
    Get
      Return mCULOCNO
    End Get
    Set(ByVal value As String)
      mCULOCNO = value
    End Set
  End Property

  Dim mCULOC As String
  Public Property _CULOC As String
    Get
      Return mCULOC
    End Get
    Set(ByVal value As String)
      mCULOC = value
    End Set
  End Property

  Dim mCUCNTNO As String
  Public Property _CUCNTNO As String
    Get
      Return mCUCNTNO
    End Get
    Set(ByVal value As String)
      mCUCNTNO = value
    End Set
  End Property

  Dim mCUAPLNO As String
  Public Property _CUAPLNO As String
    Get
      Return mCUAPLNO
    End Get
    Set(ByVal value As String)
      mCUAPLNO = value
    End Set
  End Property

  Dim mCUFUND As Integer
  Public Property _CUFUND As Integer
    Get
      Return mCUFUND
    End Get
    Set(ByVal value As Integer)
      mCUFUND = value
    End Set
  End Property

  Dim mCUSECT As String
  Public Property _CUSECT As String
    Get
      Return mCUSECT
    End Get
    Set(ByVal value As String)
      mCUSECT = value
    End Set
  End Property

  Dim mCUSDES As String
  Public Property _CUSDES As String
    Get
      Return mCUSDES
    End Get
    Set(ByVal value As String)
      mCUSDES = value
    End Set
  End Property
  Dim mCULAT As Decimal
  Public Property _CULAT As Decimal
    Get
      Return mCULAT
    End Get
    Set(ByVal value As Decimal)
      mCULAT = value
    End Set
  End Property
  Dim mCULONG As Decimal
  Public Property _CULONG As Decimal
    Get
      Return mCULONG
    End Get
    Set(ByVal value As Decimal)
      mCULONG = value
    End Set
  End Property

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
#End Region
End Class


