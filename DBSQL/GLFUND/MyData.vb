Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLFUND"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fdnbr As Integer, ByVal Sfund As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FDNBR=" & Fdnbr & " and SFUND=" & Sfund
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
Public Function GetViewbyFund(ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal NumRecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  If NumRecs > 0 Then
    StrSQL = "Select fdnbr,sfund,fndsc,entfn,accfn,[group] from " & cFileName & " where FDNBR>=" & Fdnbr
  Else
    StrSQL = "Select top " & NumRecs & " fdnbr,sfund,fndsc,entfn,accfn,[group] from " & cFileName & " where FDNBR>=" & Fdnbr
  End If
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
Public Function PosData(ByVal Fdnbr As Integer, ByVal Sfund As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  StrSQL = "Select * from " & cFileName & " where FDNBR>=" & Fdnbr & " order by fdnbr"
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
    _FNDSC = .Item("FNDSC")
    _ENTFN = .Item("ENTFN")
    _ACCFN = .Item("ACCFN")
    _GROUP = .Item("GROUP")
    _DSFND = .Item("DSFND")
    _DSPCT = .Item("DSPCT")
    _FIL01 = .Item("FIL01")
    _SFUND = .Item("SFUND")
    _FSTDT = .Item("FSTDT")
    _FENDT = .Item("FENDT")
    _FDNBRA = .Item("FDNBRA")
    _SFUNDA = .Item("SFUNDA")
    _DPNBRA = .Item("DPNBRA")
    _OBNBRA = .Item("OBNBRA")
    _FNPGMA = .Item("FNPGMA")
    _SUBFNA = .Item("SUBFNA")
    _FDNBRC = .Item("FDNBRC")
    _SFUNDC = .Item("SFUNDC")
    _DPNBRC = .Item("DPNBRC")
    _OBNBRC = .Item("OBNBRC")
    _FNPGMC = .Item("FNPGMC")
    _SUBFNC = .Item("SUBFNC")
    _FDNBRE = .Item("FDNBRE")
    _SFUNDE = .Item("SFUNDE")
    _DPNBRE = .Item("DPNBRE")
    _OBNBRE = .Item("OBNBRE")
    _FNPGME = .Item("FNPGME")
    _SUBFNE = .Item("SUBFNE")
    _FDNBRF = .Item("FDNBRF")
    _SFUNDF = .Item("SFUNDF")
    _DPNBRF = .Item("DPNBRF")
    _OBNBRF = .Item("OBNBRF")
    _FNPGMF = .Item("FNPGMF")
    _SUBFNF = .Item("SUBFNF")
    _FDNBRR = .Item("FDNBRR")
    _SFUNDR = .Item("SFUNDR")
    _DPNBRR = .Item("DPNBRR")
    _OBNBRR = .Item("OBNBRR")
    _FNPGMR = .Item("FNPGMR")
    _SUBFNR = .Item("SUBFNR")
    _FDNBR1 = .Item("FDNBR1")
    _SFUND1 = .Item("SFUND1")
    _DPNBR1 = .Item("DPNBR1")
    _OBNBR1 = .Item("OBNBR1")
    _FNPGM1 = .Item("FNPGM1")
    _SUBFN1 = .Item("SUBFN1")
    _FDNBR2 = .Item("FDNBR2")
    _SFUND2 = .Item("SFUND2")
    _DPNBR2 = .Item("DPNBR2")
    _OBNBR2 = .Item("OBNBR2")
    _FNPGM2 = .Item("FNPGM2")
    _SUBFN2 = .Item("SUBFN2")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("ACREC") = _ACREC
    .Item("FDNBR") = _FDNBR
    .Item("FNDSC") = _FNDSC
    .Item("ENTFN") = _ENTFN
    .Item("ACCFN") = _ACCFN
    .Item("GROUP") = _GROUP
    .Item("DSFND") = _DSFND
    .Item("DSPCT") = _DSPCT
    .Item("FIL01") = _FIL01
    .Item("SFUND") = _SFUND
    .Item("FSTDT") = _FSTDT
    .Item("FENDT") = _FENDT
    .Item("FDNBRA") = _FDNBRA
    .Item("SFUNDA") = _SFUNDA
    .Item("DPNBRA") = _DPNBRA
    .Item("OBNBRA") = _OBNBRA
    .Item("FNPGMA") = _FNPGMA
    .Item("SUBFNA") = _SUBFNA
    .Item("FDNBRC") = _FDNBRC
    .Item("SFUNDC") = _SFUNDC
    .Item("DPNBRC") = _DPNBRC
    .Item("OBNBRC") = _OBNBRC
    .Item("FNPGMC") = _FNPGMC
    .Item("SUBFNC") = _SUBFNC
    .Item("FDNBRE") = _FDNBRE
    .Item("SFUNDE") = _SFUNDE
    .Item("DPNBRE") = _DPNBRE
    .Item("OBNBRE") = _OBNBRE
    .Item("FNPGME") = _FNPGME
    .Item("SUBFNE") = _SUBFNE
    .Item("FDNBRF") = _FDNBRF
    .Item("SFUNDF") = _SFUNDF
    .Item("DPNBRF") = _DPNBRF
    .Item("OBNBRF") = _OBNBRF
    .Item("FNPGMF") = _FNPGMF
    .Item("SUBFNF") = _SUBFNF
    .Item("FDNBRR") = _FDNBRR
    .Item("SFUNDR") = _SFUNDR
    .Item("DPNBRR") = _DPNBRR
    .Item("OBNBRR") = _OBNBRR
    .Item("FNPGMR") = _FNPGMR
    .Item("SUBFNR") = _SUBFNR
    .Item("FDNBR1") = _FDNBR1
    .Item("SFUND1") = _SFUND1
    .Item("DPNBR1") = _DPNBR1
    .Item("OBNBR1") = _OBNBR1
    .Item("FNPGM1") = _FNPGM1
    .Item("SUBFN1") = _SUBFN1
    .Item("FDNBR2") = _FDNBR2
    .Item("SFUND2") = _SFUND2
    .Item("DPNBR2") = _DPNBR2
    .Item("OBNBR2") = _OBNBR2
    .Item("FNPGM2") = _FNPGM2
    .Item("SUBFN2") = _SUBFN2
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
Dim mFNDSC As String
Public Property _FNDSC As String
    Get
        Return mFNDSC
    End Get
    Set(ByVal value As String)
        mFNDSC = value
    End Set
End Property
Dim mENTFN As String
Public Property _ENTFN As String
    Get
        Return mENTFN
    End Get
    Set(ByVal value As String)
        mENTFN = value
    End Set
End Property
Dim mACCFN As String
Public Property _ACCFN As String
    Get
        Return mACCFN
    End Get
    Set(ByVal value As String)
        mACCFN = value
    End Set
End Property
Dim mGROUP As Integer
Public Property _GROUP As Integer
    Get
        Return mGROUP
    End Get
    Set(ByVal value As Integer)
        mGROUP = value
    End Set
End Property
Dim mDSFND As Integer
Public Property _DSFND As Integer
    Get
        Return mDSFND
    End Get
    Set(ByVal value As Integer)
        mDSFND = value
    End Set
End Property
Dim mDSPCT As Decimal
Public Property _DSPCT As Decimal
    Get
        Return mDSPCT
    End Get
    Set(ByVal value As Decimal)
        mDSPCT = value
    End Set
End Property
Dim mFIL01 As String
Public Property _FIL01 As String
    Get
        Return mFIL01
    End Get
    Set(ByVal value As String)
        mFIL01 = value
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
Dim mFSTDT As Integer
Public Property _FSTDT As Integer
    Get
        Return mFSTDT
    End Get
    Set(ByVal value As Integer)
        mFSTDT = value
    End Set
End Property
Dim mFENDT As Integer
Public Property _FENDT As Integer
    Get
        Return mFENDT
    End Get
    Set(ByVal value As Integer)
        mFENDT = value
    End Set
End Property
Dim mFDNBRA As Integer
Public Property _FDNBRA As Integer
    Get
        Return mFDNBRA
    End Get
    Set(ByVal value As Integer)
        mFDNBRA = value
    End Set
End Property
Dim mSFUNDA As Integer
Public Property _SFUNDA As Integer
    Get
        Return mSFUNDA
    End Get
    Set(ByVal value As Integer)
        mSFUNDA = value
    End Set
End Property
Dim mDPNBRA As Integer
Public Property _DPNBRA As Integer
    Get
        Return mDPNBRA
    End Get
    Set(ByVal value As Integer)
        mDPNBRA = value
    End Set
End Property
Dim mOBNBRA As Integer
Public Property _OBNBRA As Integer
    Get
        Return mOBNBRA
    End Get
    Set(ByVal value As Integer)
        mOBNBRA = value
    End Set
End Property
Dim mFNPGMA As Integer
Public Property _FNPGMA As Integer
    Get
        Return mFNPGMA
    End Get
    Set(ByVal value As Integer)
        mFNPGMA = value
    End Set
End Property
Dim mSUBFNA As Integer
Public Property _SUBFNA As Integer
    Get
        Return mSUBFNA
    End Get
    Set(ByVal value As Integer)
        mSUBFNA = value
    End Set
End Property
Dim mFDNBRC As Integer
Public Property _FDNBRC As Integer
    Get
        Return mFDNBRC
    End Get
    Set(ByVal value As Integer)
        mFDNBRC = value
    End Set
End Property
Dim mSFUNDC As Integer
Public Property _SFUNDC As Integer
    Get
        Return mSFUNDC
    End Get
    Set(ByVal value As Integer)
        mSFUNDC = value
    End Set
End Property
Dim mDPNBRC As Integer
Public Property _DPNBRC As Integer
    Get
        Return mDPNBRC
    End Get
    Set(ByVal value As Integer)
        mDPNBRC = value
    End Set
End Property
Dim mOBNBRC As Integer
Public Property _OBNBRC As Integer
    Get
        Return mOBNBRC
    End Get
    Set(ByVal value As Integer)
        mOBNBRC = value
    End Set
End Property
Dim mFNPGMC As Integer
Public Property _FNPGMC As Integer
    Get
        Return mFNPGMC
    End Get
    Set(ByVal value As Integer)
        mFNPGMC = value
    End Set
End Property
Dim mSUBFNC As Integer
Public Property _SUBFNC As Integer
    Get
        Return mSUBFNC
    End Get
    Set(ByVal value As Integer)
        mSUBFNC = value
    End Set
End Property
Dim mFDNBRE As Integer
Public Property _FDNBRE As Integer
    Get
        Return mFDNBRE
    End Get
    Set(ByVal value As Integer)
        mFDNBRE = value
    End Set
End Property
Dim mSFUNDE As Integer
Public Property _SFUNDE As Integer
    Get
        Return mSFUNDE
    End Get
    Set(ByVal value As Integer)
        mSFUNDE = value
    End Set
End Property
Dim mDPNBRE As Integer
Public Property _DPNBRE As Integer
    Get
        Return mDPNBRE
    End Get
    Set(ByVal value As Integer)
        mDPNBRE = value
    End Set
End Property
Dim mOBNBRE As Integer
Public Property _OBNBRE As Integer
    Get
        Return mOBNBRE
    End Get
    Set(ByVal value As Integer)
        mOBNBRE = value
    End Set
End Property
Dim mFNPGME As Integer
Public Property _FNPGME As Integer
    Get
        Return mFNPGME
    End Get
    Set(ByVal value As Integer)
        mFNPGME = value
    End Set
End Property
Dim mSUBFNE As Integer
Public Property _SUBFNE As Integer
    Get
        Return mSUBFNE
    End Get
    Set(ByVal value As Integer)
        mSUBFNE = value
    End Set
End Property
Dim mFDNBRF As Integer
Public Property _FDNBRF As Integer
    Get
        Return mFDNBRF
    End Get
    Set(ByVal value As Integer)
        mFDNBRF = value
    End Set
End Property
Dim mSFUNDF As Integer
Public Property _SFUNDF As Integer
    Get
        Return mSFUNDF
    End Get
    Set(ByVal value As Integer)
        mSFUNDF = value
    End Set
End Property
Dim mDPNBRF As Integer
Public Property _DPNBRF As Integer
    Get
        Return mDPNBRF
    End Get
    Set(ByVal value As Integer)
        mDPNBRF = value
    End Set
End Property
Dim mOBNBRF As Integer
Public Property _OBNBRF As Integer
    Get
        Return mOBNBRF
    End Get
    Set(ByVal value As Integer)
        mOBNBRF = value
    End Set
End Property
Dim mFNPGMF As Integer
Public Property _FNPGMF As Integer
    Get
        Return mFNPGMF
    End Get
    Set(ByVal value As Integer)
        mFNPGMF = value
    End Set
End Property
Dim mSUBFNF As Integer
Public Property _SUBFNF As Integer
    Get
        Return mSUBFNF
    End Get
    Set(ByVal value As Integer)
        mSUBFNF = value
    End Set
End Property
Dim mFDNBRR As Integer
Public Property _FDNBRR As Integer
    Get
        Return mFDNBRR
    End Get
    Set(ByVal value As Integer)
        mFDNBRR = value
    End Set
End Property
Dim mSFUNDR As Integer
Public Property _SFUNDR As Integer
    Get
        Return mSFUNDR
    End Get
    Set(ByVal value As Integer)
        mSFUNDR = value
    End Set
End Property
Dim mDPNBRR As Integer
Public Property _DPNBRR As Integer
    Get
        Return mDPNBRR
    End Get
    Set(ByVal value As Integer)
        mDPNBRR = value
    End Set
End Property
Dim mOBNBRR As Integer
Public Property _OBNBRR As Integer
    Get
        Return mOBNBRR
    End Get
    Set(ByVal value As Integer)
        mOBNBRR = value
    End Set
End Property
Dim mFNPGMR As Integer
Public Property _FNPGMR As Integer
    Get
        Return mFNPGMR
    End Get
    Set(ByVal value As Integer)
        mFNPGMR = value
    End Set
End Property
Dim mSUBFNR As Integer
Public Property _SUBFNR As Integer
    Get
        Return mSUBFNR
    End Get
    Set(ByVal value As Integer)
        mSUBFNR = value
    End Set
End Property
Dim mFDNBR1 As Integer
Public Property _FDNBR1 As Integer
    Get
        Return mFDNBR1
    End Get
    Set(ByVal value As Integer)
        mFDNBR1 = value
    End Set
End Property
Dim mSFUND1 As Integer
Public Property _SFUND1 As Integer
    Get
        Return mSFUND1
    End Get
    Set(ByVal value As Integer)
        mSFUND1 = value
    End Set
End Property
Dim mDPNBR1 As Integer
Public Property _DPNBR1 As Integer
    Get
        Return mDPNBR1
    End Get
    Set(ByVal value As Integer)
        mDPNBR1 = value
    End Set
End Property
Dim mOBNBR1 As Integer
Public Property _OBNBR1 As Integer
    Get
        Return mOBNBR1
    End Get
    Set(ByVal value As Integer)
        mOBNBR1 = value
    End Set
End Property
Dim mFNPGM1 As Integer
Public Property _FNPGM1 As Integer
    Get
        Return mFNPGM1
    End Get
    Set(ByVal value As Integer)
        mFNPGM1 = value
    End Set
End Property
Dim mSUBFN1 As Integer
Public Property _SUBFN1 As Integer
    Get
        Return mSUBFN1
    End Get
    Set(ByVal value As Integer)
        mSUBFN1 = value
    End Set
End Property
Dim mFDNBR2 As Integer
Public Property _FDNBR2 As Integer
    Get
        Return mFDNBR2
    End Get
    Set(ByVal value As Integer)
        mFDNBR2 = value
    End Set
End Property
Dim mSFUND2 As Integer
Public Property _SFUND2 As Integer
    Get
        Return mSFUND2
    End Get
    Set(ByVal value As Integer)
        mSFUND2 = value
    End Set
End Property
Dim mDPNBR2 As Integer
Public Property _DPNBR2 As Integer
    Get
        Return mDPNBR2
    End Get
    Set(ByVal value As Integer)
        mDPNBR2 = value
    End Set
End Property
Dim mOBNBR2 As Integer
Public Property _OBNBR2 As Integer
    Get
        Return mOBNBR2
    End Get
    Set(ByVal value As Integer)
        mOBNBR2 = value
    End Set
End Property
Dim mFNPGM2 As Integer
Public Property _FNPGM2 As Integer
    Get
        Return mFNPGM2
    End Get
    Set(ByVal value As Integer)
        mFNPGM2 = value
    End Set
End Property
Dim mSUBFN2 As Integer
Public Property _SUBFN2 As Integer
    Get
        Return mSUBFN2
    End Get
    Set(ByVal value As Integer)
        mSUBFN2 = value
    End Set
End Property
#End Region
End Class

