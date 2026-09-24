Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Const cFileName As String = "VENDOR"
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
    _ACREC = .Item("ACREC")
    _VNDNR = .Item("VNDNR")
    _VENNM = .Item("VENNM")
    _VADD1 = .Item("VADD1")
    _VADD2 = .Item("VADD2")
    _VADD3 = .Item("VADD3")
    _VPHON = .Item("VPHON")
    _VDATE = .Item("VDATE")
    _VEYTD = .Item("VEYTD")
    _VADD4 = .Item("VADD4")
    _FIL01 = .Item("FIL01")
    _ORNAM = .Item("ORNAM")
    _ORAD1 = .Item("ORAD1")
    _ORAD2 = .Item("ORAD2")
    _ORAD3 = .Item("ORAD3")
    _ORAD4 = .Item("ORAD4")
    _PYNAM = .Item("PYNAM")
    _PYAD1 = .Item("PYAD1")
    _PYAD2 = .Item("PYAD2")
    _PYAD3 = .Item("PYAD3")
    _PYAD4 = .Item("PYAD4")
    _F1099 = .Item("F1099")
    _TAXID = .Item("TAXID")
    _FAXNO = .Item("FAXNO")
    _CONTN = .Item("CONTN")
    _VNCAT = .Item("VNCAT")
    _PHEXT = .Item("PHEXT")
    _PHALT = .Item("PHALT")
    _LADTE = .Item("LADTE")
    _MINCD = .Item("MINCD")
    _FEMCD = .Item("FEMCD")
    _ORDSP = .Item("ORDSP")
    _ORSHP = .Item("ORSHP")
    _FDNBD = .Item("FDNBD")
    _SFUDD = .Item("SFUDD")
    _DPNBD = .Item("DPNBD")
    _OBNBD = .Item("OBNBD")
    _FNPGD = .Item("FNPGD")
    _SUBFD = .Item("SUBFD")
    _FDNBS = .Item("FDNBS")
    _SFUNS = .Item("SFUNS")
    _DPNBS = .Item("DPNBS")
    _OBNBS = .Item("OBNBS")
    _FNPGS = .Item("FNPGS")
    _SUBFS = .Item("SUBFS")
    _VZIP = .Item("VZIP")
    _VZIPE = .Item("VZIPE")
    _OZIP = .Item("OZIP")
    _OZIPE = .Item("OZIPE")
    _PYZIP = .Item("PYZIP")
    _PYZIPE = .Item("PYZIPE")
    _MTDPR = .Item("MTDPR")
    _YTDPR = .Item("YTDPR")
    _FSCPR = .Item("FSCPR")
    _MTDPA = .Item("MTDPA")
    _YTDPA = .Item("YTDPA")
    _FSCPA = .Item("FSCPA")
    _DTLPD = .Item("DTLPD")
    _DUEDY = .Item("DUEDY")
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _OTIME = .Item("OTIME")
    _VSORT = .Item("VSORT")
      _FIL25 = .Item("FIL25")
      _VEMAIL = .Item("VEMAIL")
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
Dim mVNDNR As String
Public Property _VNDNR As String
    Get
        Return mVNDNR
    End Get
    Set(ByVal value As String)
        mVNDNR = value
    End Set
End Property
Dim mVENNM As String
Public Property _VENNM As String
    Get
        Return mVENNM
    End Get
    Set(ByVal value As String)
        mVENNM = value
    End Set
End Property
Dim mVADD1 As String
Public Property _VADD1 As String
    Get
        Return mVADD1
    End Get
    Set(ByVal value As String)
        mVADD1 = value
    End Set
End Property
Dim mVADD2 As String
Public Property _VADD2 As String
    Get
        Return mVADD2
    End Get
    Set(ByVal value As String)
        mVADD2 = value
    End Set
End Property
Dim mVADD3 As String
Public Property _VADD3 As String
    Get
        Return mVADD3
    End Get
    Set(ByVal value As String)
        mVADD3 = value
    End Set
End Property
Dim mVPHON As Long
Public Property _VPHON As Long
    Get
        Return mVPHON
    End Get
    Set(ByVal value As Long)
        mVPHON = value
    End Set
End Property
Dim mVDATE As Integer
Public Property _VDATE As Integer
    Get
        Return mVDATE
    End Get
    Set(ByVal value As Integer)
        mVDATE = value
    End Set
End Property
Dim mVEYTD As Decimal
Public Property _VEYTD As Decimal
    Get
        Return mVEYTD
    End Get
    Set(ByVal value As Decimal)
        mVEYTD = value
    End Set
End Property
Dim mVADD4 As String
Public Property _VADD4 As String
    Get
        Return mVADD4
    End Get
    Set(ByVal value As String)
        mVADD4 = value
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
Dim mORNAM As String
Public Property _ORNAM As String
    Get
        Return mORNAM
    End Get
    Set(ByVal value As String)
        mORNAM = value
    End Set
End Property
Dim mORAD1 As String
Public Property _ORAD1 As String
    Get
        Return mORAD1
    End Get
    Set(ByVal value As String)
        mORAD1 = value
    End Set
End Property
Dim mORAD2 As String
Public Property _ORAD2 As String
    Get
        Return mORAD2
    End Get
    Set(ByVal value As String)
        mORAD2 = value
    End Set
End Property
Dim mORAD3 As String
Public Property _ORAD3 As String
    Get
        Return mORAD3
    End Get
    Set(ByVal value As String)
        mORAD3 = value
    End Set
End Property
Dim mORAD4 As String
Public Property _ORAD4 As String
    Get
        Return mORAD4
    End Get
    Set(ByVal value As String)
        mORAD4 = value
    End Set
End Property
Dim mPYNAM As String
Public Property _PYNAM As String
    Get
        Return mPYNAM
    End Get
    Set(ByVal value As String)
        mPYNAM = value
    End Set
End Property
Dim mPYAD1 As String
Public Property _PYAD1 As String
    Get
        Return mPYAD1
    End Get
    Set(ByVal value As String)
        mPYAD1 = value
    End Set
End Property
Dim mPYAD2 As String
Public Property _PYAD2 As String
    Get
        Return mPYAD2
    End Get
    Set(ByVal value As String)
        mPYAD2 = value
    End Set
End Property
Dim mPYAD3 As String
Public Property _PYAD3 As String
    Get
        Return mPYAD3
    End Get
    Set(ByVal value As String)
        mPYAD3 = value
    End Set
End Property
Dim mPYAD4 As String
Public Property _PYAD4 As String
    Get
        Return mPYAD4
    End Get
    Set(ByVal value As String)
        mPYAD4 = value
    End Set
End Property
Dim mF1099 As String
Public Property _F1099 As String
    Get
        Return mF1099
    End Get
    Set(ByVal value As String)
        mF1099 = value
    End Set
End Property
Dim mTAXID As Integer
Public Property _TAXID As Integer
    Get
        Return mTAXID
    End Get
    Set(ByVal value As Integer)
        mTAXID = value
    End Set
End Property
Dim mFAXNO As Long
Public Property _FAXNO As Long
    Get
        Return mFAXNO
    End Get
    Set(ByVal value As Long)
        mFAXNO = value
    End Set
End Property
Dim mCONTN As String
Public Property _CONTN As String
    Get
        Return mCONTN
    End Get
    Set(ByVal value As String)
        mCONTN = value
    End Set
End Property
Dim mVNCAT As String
Public Property _VNCAT As String
    Get
        Return mVNCAT
    End Get
    Set(ByVal value As String)
        mVNCAT = value
    End Set
End Property
Dim mPHEXT As Integer
Public Property _PHEXT As Integer
    Get
        Return mPHEXT
    End Get
    Set(ByVal value As Integer)
        mPHEXT = value
    End Set
End Property
Dim mPHALT As Long
Public Property _PHALT As Long
    Get
        Return mPHALT
    End Get
    Set(ByVal value As Long)
        mPHALT = value
    End Set
End Property
Dim mLADTE As Integer
Public Property _LADTE As Integer
    Get
        Return mLADTE
    End Get
    Set(ByVal value As Integer)
        mLADTE = value
    End Set
End Property
Dim mMINCD As String
Public Property _MINCD As String
    Get
        Return mMINCD
    End Get
    Set(ByVal value As String)
        mMINCD = value
    End Set
End Property
Dim mFEMCD As String
Public Property _FEMCD As String
    Get
        Return mFEMCD
    End Get
    Set(ByVal value As String)
        mFEMCD = value
    End Set
End Property
Dim mORDSP As Decimal
Public Property _ORDSP As Decimal
    Get
        Return mORDSP
    End Get
    Set(ByVal value As Decimal)
        mORDSP = value
    End Set
End Property
Dim mORSHP As Decimal
Public Property _ORSHP As Decimal
    Get
        Return mORSHP
    End Get
    Set(ByVal value As Decimal)
        mORSHP = value
    End Set
End Property
Dim mFDNBD As Integer
Public Property _FDNBD As Integer
    Get
        Return mFDNBD
    End Get
    Set(ByVal value As Integer)
        mFDNBD = value
    End Set
End Property
Dim mSFUDD As Integer
Public Property _SFUDD As Integer
    Get
        Return mSFUDD
    End Get
    Set(ByVal value As Integer)
        mSFUDD = value
    End Set
End Property
Dim mDPNBD As Integer
Public Property _DPNBD As Integer
    Get
        Return mDPNBD
    End Get
    Set(ByVal value As Integer)
        mDPNBD = value
    End Set
End Property
Dim mOBNBD As Integer
Public Property _OBNBD As Integer
    Get
        Return mOBNBD
    End Get
    Set(ByVal value As Integer)
        mOBNBD = value
    End Set
End Property
Dim mFNPGD As Integer
Public Property _FNPGD As Integer
    Get
        Return mFNPGD
    End Get
    Set(ByVal value As Integer)
        mFNPGD = value
    End Set
End Property
Dim mSUBFD As Integer
Public Property _SUBFD As Integer
    Get
        Return mSUBFD
    End Get
    Set(ByVal value As Integer)
        mSUBFD = value
    End Set
End Property
Dim mFDNBS As Integer
Public Property _FDNBS As Integer
    Get
        Return mFDNBS
    End Get
    Set(ByVal value As Integer)
        mFDNBS = value
    End Set
End Property
Dim mSFUNS As Integer
Public Property _SFUNS As Integer
    Get
        Return mSFUNS
    End Get
    Set(ByVal value As Integer)
        mSFUNS = value
    End Set
End Property
Dim mDPNBS As Integer
Public Property _DPNBS As Integer
    Get
        Return mDPNBS
    End Get
    Set(ByVal value As Integer)
        mDPNBS = value
    End Set
End Property
Dim mOBNBS As Integer
Public Property _OBNBS As Integer
    Get
        Return mOBNBS
    End Get
    Set(ByVal value As Integer)
        mOBNBS = value
    End Set
End Property
Dim mFNPGS As Integer
Public Property _FNPGS As Integer
    Get
        Return mFNPGS
    End Get
    Set(ByVal value As Integer)
        mFNPGS = value
    End Set
End Property
Dim mSUBFS As Integer
Public Property _SUBFS As Integer
    Get
        Return mSUBFS
    End Get
    Set(ByVal value As Integer)
        mSUBFS = value
    End Set
End Property
Dim mVZIP As String
Public Property _VZIP As String
    Get
        Return mVZIP
    End Get
    Set(ByVal value As String)
        mVZIP = value
    End Set
End Property
Dim mVZIPE As String
Public Property _VZIPE As String
    Get
        Return mVZIPE
    End Get
    Set(ByVal value As String)
        mVZIPE = value
    End Set
End Property
Dim mOZIP As String
Public Property _OZIP As String
    Get
        Return mOZIP
    End Get
    Set(ByVal value As String)
        mOZIP = value
    End Set
End Property
Dim mOZIPE As String
Public Property _OZIPE As String
    Get
        Return mOZIPE
    End Get
    Set(ByVal value As String)
        mOZIPE = value
    End Set
End Property
Dim mPYZIP As String
Public Property _PYZIP As String
    Get
        Return mPYZIP
    End Get
    Set(ByVal value As String)
        mPYZIP = value
    End Set
End Property
Dim mPYZIPE As String
Public Property _PYZIPE As String
    Get
        Return mPYZIPE
    End Get
    Set(ByVal value As String)
        mPYZIPE = value
    End Set
End Property
Dim mMTDPR As Decimal
Public Property _MTDPR As Decimal
    Get
        Return mMTDPR
    End Get
    Set(ByVal value As Decimal)
        mMTDPR = value
    End Set
End Property
Dim mYTDPR As Decimal
Public Property _YTDPR As Decimal
    Get
        Return mYTDPR
    End Get
    Set(ByVal value As Decimal)
        mYTDPR = value
    End Set
End Property
Dim mFSCPR As Decimal
Public Property _FSCPR As Decimal
    Get
        Return mFSCPR
    End Get
    Set(ByVal value As Decimal)
        mFSCPR = value
    End Set
End Property
Dim mMTDPA As Decimal
Public Property _MTDPA As Decimal
    Get
        Return mMTDPA
    End Get
    Set(ByVal value As Decimal)
        mMTDPA = value
    End Set
End Property
Dim mYTDPA As Decimal
Public Property _YTDPA As Decimal
    Get
        Return mYTDPA
    End Get
    Set(ByVal value As Decimal)
        mYTDPA = value
    End Set
End Property
Dim mFSCPA As Decimal
Public Property _FSCPA As Decimal
    Get
        Return mFSCPA
    End Get
    Set(ByVal value As Decimal)
        mFSCPA = value
    End Set
End Property
Dim mDTLPD As Integer
Public Property _DTLPD As Integer
    Get
        Return mDTLPD
    End Get
    Set(ByVal value As Integer)
        mDTLPD = value
    End Set
End Property
Dim mDUEDY As Integer
Public Property _DUEDY As Integer
    Get
        Return mDUEDY
    End Get
    Set(ByVal value As Integer)
        mDUEDY = value
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
Dim mSFUND As Integer
Public Property _SFUND As Integer
    Get
        Return mSFUND
    End Get
    Set(ByVal value As Integer)
        mSFUND = value
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
Dim mOTIME As String
Public Property _OTIME As String
    Get
        Return mOTIME
    End Get
    Set(ByVal value As String)
        mOTIME = value
    End Set
End Property
Dim mVSORT As String
Public Property _VSORT As String
    Get
        Return mVSORT
    End Get
    Set(ByVal value As String)
        mVSORT = value
    End Set
End Property
Dim mFIL25 As String
  Public Property _FIL25 As String
    Get
      Return mFIL25
    End Get
    Set(ByVal value As String)
      mFIL25 = value
    End Set
  End Property
  Dim mVEMAIL As String
  Public Property _VEMAIL As String
    Get
      Return mVEMAIL
    End Get
    Set(ByVal value As String)
      mVEMAIL = value
    End Set
  End Property
#End Region


End Class

