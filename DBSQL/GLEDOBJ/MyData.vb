Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "GLEDOBJ"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal Fiscyr As Integer, ByVal Fdnbr As Integer, ByVal Sfund As Integer, _
 ByVal Dpnbr As Integer, ByVal Obnbr As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where FSCYR=" & Fiscyr & " and FDNBR=" & Fdnbr & _
   " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR=" & Obnbr
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
Public Function PosData(ByVal Fiscyr As Integer, ByVal Fdnbr As Integer, ByVal Sfund As Integer, _
 ByVal Dpnbr As Integer, ByVal Obnbr As Integer, ByVal Numrecs As Integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  Dim WrkTop As String
  WrkTop = String.Empty

  If Numrecs > 0 Then
    WrkTop = "TOP " & Numrecs & " "
  End If
  StrSQL = "Select " & WrkTop & "* from " & cFileName & _
  " where FSCYR=" & Fiscyr & " and FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR=" & Dpnbr & " and OBNBR>=" & Obnbr & _
  " or FSCYR=" & Fiscyr & " and FDNBR=" & Fdnbr & " and SFUND=" & Sfund & " and DPNBR>" & Dpnbr & _
  " or FSCYR=" & Fiscyr & " and FDNBR=" & Fdnbr & " and SFUND>" & Sfund & _
  " or FSCYR=" & Fiscyr & " and FDNBR>" & Fdnbr & " order by fscyr,fdnbr,sfund,dpnbr,obnbr"
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
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _X01 = .Item("X01")
    _X02 = .Item("X02")
    _X03 = .Item("X03")
    _X04 = .Item("X04")
    _X05 = .Item("X05")
    _X06 = .Item("X06")
    _X07 = .Item("X07")
    _X08 = .Item("X08")
    _X09 = .Item("X09")
    _X10 = .Item("X10")
    _X11 = .Item("X11")
    _X12 = .Item("X12")
    _B01 = .Item("B01")
    _B02 = .Item("B02")
    _B03 = .Item("B03")
    _B04 = .Item("B04")
    _B05 = .Item("B05")
    _B06 = .Item("B06")
    _B07 = .Item("B07")
    _B08 = .Item("B08")
    _B09 = .Item("B09")
    _B10 = .Item("B10")
    _B11 = .Item("B11")
    _B12 = .Item("B12")
    _U01 = .Item("U01")
    _U02 = .Item("U02")
    _U03 = .Item("U03")
    _U04 = .Item("U04")
    _U05 = .Item("U05")
    _U06 = .Item("U06")
    _U07 = .Item("U07")
    _U08 = .Item("U08")
    _U09 = .Item("U09")
    _U10 = .Item("U10")
    _U11 = .Item("U11")
    _U12 = .Item("U12")
    _E01 = .Item("E01")
    _E02 = .Item("E02")
    _E03 = .Item("E03")
    _E04 = .Item("E04")
    _E05 = .Item("E05")
    _E06 = .Item("E06")
    _E07 = .Item("E07")
    _E08 = .Item("E08")
    _E09 = .Item("E09")
    _E10 = .Item("E10")
    _E11 = .Item("E11")
    _E12 = .Item("E12")
    _R01 = .Item("R01")
    _R02 = .Item("R02")
    _R03 = .Item("R03")
    _R04 = .Item("R04")
    _R05 = .Item("R05")
    _R06 = .Item("R06")
    _R07 = .Item("R07")
    _R08 = .Item("R08")
    _R09 = .Item("R09")
    _R10 = .Item("R10")
    _R11 = .Item("R11")
    _R12 = .Item("R12")
    _P01 = .Item("P01")
    _P02 = .Item("P02")
    _P03 = .Item("P03")
    _P04 = .Item("P04")
    _P05 = .Item("P05")
    _P06 = .Item("P06")
    _P07 = .Item("P07")
    _P08 = .Item("P08")
    _P09 = .Item("P09")
    _P10 = .Item("P10")
    _P11 = .Item("P11")
    _P12 = .Item("P12")
    _J01 = .Item("J01")
    _J02 = .Item("J02")
    _J03 = .Item("J03")
    _J04 = .Item("J04")
    _J05 = .Item("J05")
    _J06 = .Item("J06")
    _J07 = .Item("J07")
    _J08 = .Item("J08")
    _J09 = .Item("J09")
    _J10 = .Item("J10")
    _J11 = .Item("J11")
    _J12 = .Item("J12")
    _FSCYR = .Item("FSCYR")
  End With
End Sub
Private Sub PutFields(ByVal ds As DataSet)
  With ds.Tables(0).Rows(0)
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("SUBFN") = _SUBFN
    .Item("X01") = _X01
    .Item("X02") = _X02
    .Item("X03") = _X03
    .Item("X04") = _X04
    .Item("X05") = _X05
    .Item("X06") = _X06
    .Item("X07") = _X07
    .Item("X08") = _X08
    .Item("X09") = _X09
    .Item("X10") = _X10
    .Item("X11") = _X11
    .Item("X12") = _X12
    .Item("B01") = _B01
    .Item("B02") = _B02
    .Item("B03") = _B03
    .Item("B04") = _B04
    .Item("B05") = _B05
    .Item("B06") = _B06
    .Item("B07") = _B07
    .Item("B08") = _B08
    .Item("B09") = _B09
    .Item("B10") = _B10
    .Item("B11") = _B11
    .Item("B12") = _B12
    .Item("U01") = _U01
    .Item("U02") = _U02
    .Item("U03") = _U03
    .Item("U04") = _U04
    .Item("U05") = _U05
    .Item("U06") = _U06
    .Item("U07") = _U07
    .Item("U08") = _U08
    .Item("U09") = _U09
    .Item("U10") = _U10
    .Item("U11") = _U11
    .Item("U12") = _U12
    .Item("E01") = _E01
    .Item("E02") = _E02
    .Item("E03") = _E03
    .Item("E04") = _E04
    .Item("E05") = _E05
    .Item("E06") = _E06
    .Item("E07") = _E07
    .Item("E08") = _E08
    .Item("E09") = _E09
    .Item("E10") = _E10
    .Item("E11") = _E11
    .Item("E12") = _E12
    .Item("R01") = _R01
    .Item("R02") = _R02
    .Item("R03") = _R03
    .Item("R04") = _R04
    .Item("R05") = _R05
    .Item("R06") = _R06
    .Item("R07") = _R07
    .Item("R08") = _R08
    .Item("R09") = _R09
    .Item("R10") = _R10
    .Item("R11") = _R11
    .Item("R12") = _R12
    .Item("P01") = _P01
    .Item("P02") = _P02
    .Item("P03") = _P03
    .Item("P04") = _P04
    .Item("P05") = _P05
    .Item("P06") = _P06
    .Item("P07") = _P07
    .Item("P08") = _P08
    .Item("P09") = _P09
    .Item("P10") = _P10
    .Item("P11") = _P11
    .Item("P12") = _P12
    .Item("J01") = _J01
    .Item("J02") = _J02
    .Item("J03") = _J03
    .Item("J04") = _J04
    .Item("J05") = _J05
    .Item("J06") = _J06
    .Item("J07") = _J07
    .Item("J08") = _J08
    .Item("J09") = _J09
    .Item("J10") = _J10
    .Item("J11") = _J11
    .Item("J12") = _J12
    .Item("FSCYR") = _FSCYR
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
Dim mX01 As Decimal
Public Property _X01 As Decimal
    Get
        Return mX01
    End Get
    Set(ByVal value As Decimal)
        mX01 = value
    End Set
End Property

Dim mX02 As Decimal
Public Property _X02 As Decimal
    Get
        Return mX02
    End Get
    Set(ByVal value As Decimal)
        mX02 = value
    End Set
End Property

Dim mX03 As Decimal
Public Property _X03 As Decimal
    Get
        Return mX03
    End Get
    Set(ByVal value As Decimal)
        mX03 = value
    End Set
End Property

Dim mX04 As Decimal
Public Property _X04 As Decimal
    Get
        Return mX04
    End Get
    Set(ByVal value As Decimal)
        mX04 = value
    End Set
End Property

Dim mX05 As Decimal
Public Property _X05 As Decimal
    Get
        Return mX05
    End Get
    Set(ByVal value As Decimal)
        mX05 = value
    End Set
End Property

Dim mX06 As Decimal
Public Property _X06 As Decimal
    Get
        Return mX06
    End Get
    Set(ByVal value As Decimal)
        mX06 = value
    End Set
End Property

Dim mX07 As Decimal
Public Property _X07 As Decimal
    Get
        Return mX07
    End Get
    Set(ByVal value As Decimal)
        mX07 = value
    End Set
End Property

Dim mX08 As Decimal
Public Property _X08 As Decimal
    Get
        Return mX08
    End Get
    Set(ByVal value As Decimal)
        mX08 = value
    End Set
End Property

Dim mX09 As Decimal
Public Property _X09 As Decimal
    Get
        Return mX09
    End Get
    Set(ByVal value As Decimal)
        mX09 = value
    End Set
End Property

Dim mX10 As Decimal
Public Property _X10 As Decimal
    Get
        Return mX10
    End Get
    Set(ByVal value As Decimal)
        mX10 = value
    End Set
End Property

Dim mX11 As Decimal
Public Property _X11 As Decimal
    Get
        Return mX11
    End Get
    Set(ByVal value As Decimal)
        mX11 = value
    End Set
End Property

Dim mX12 As Decimal
Public Property _X12 As Decimal
    Get
        Return mX12
    End Get
    Set(ByVal value As Decimal)
        mX12 = value
    End Set
End Property

Dim mB01 As Decimal
Public Property _B01 As Decimal
    Get
        Return mB01
    End Get
    Set(ByVal value As Decimal)
        mB01 = value
    End Set
End Property

Dim mB02 As Decimal
Public Property _B02 As Decimal
    Get
        Return mB02
    End Get
    Set(ByVal value As Decimal)
        mB02 = value
    End Set
End Property

Dim mB03 As Decimal
Public Property _B03 As Decimal
    Get
        Return mB03
    End Get
    Set(ByVal value As Decimal)
        mB03 = value
    End Set
End Property

Dim mB04 As Decimal
Public Property _B04 As Decimal
    Get
        Return mB04
    End Get
    Set(ByVal value As Decimal)
        mB04 = value
    End Set
End Property

Dim mB05 As Decimal
Public Property _B05 As Decimal
    Get
        Return mB05
    End Get
    Set(ByVal value As Decimal)
        mB05 = value
    End Set
End Property

Dim mB06 As Decimal
Public Property _B06 As Decimal
    Get
        Return mB06
    End Get
    Set(ByVal value As Decimal)
        mB06 = value
    End Set
End Property

Dim mB07 As Decimal
Public Property _B07 As Decimal
    Get
        Return mB07
    End Get
    Set(ByVal value As Decimal)
        mB07 = value
    End Set
End Property

Dim mB08 As Decimal
Public Property _B08 As Decimal
    Get
        Return mB08
    End Get
    Set(ByVal value As Decimal)
        mB08 = value
    End Set
End Property

Dim mB09 As Decimal
Public Property _B09 As Decimal
    Get
        Return mB09
    End Get
    Set(ByVal value As Decimal)
        mB09 = value
    End Set
End Property

Dim mB10 As Decimal
Public Property _B10 As Decimal
    Get
        Return mB10
    End Get
    Set(ByVal value As Decimal)
        mB10 = value
    End Set
End Property

Dim mB11 As Decimal
Public Property _B11 As Decimal
    Get
        Return mB11
    End Get
    Set(ByVal value As Decimal)
        mB11 = value
    End Set
End Property

Dim mB12 As Decimal
Public Property _B12 As Decimal
    Get
        Return mB12
    End Get
    Set(ByVal value As Decimal)
        mB12 = value
    End Set
End Property

Dim mU01 As Decimal
Public Property _U01 As Decimal
    Get
        Return mU01
    End Get
    Set(ByVal value As Decimal)
        mU01 = value
    End Set
End Property

Dim mU02 As Decimal
Public Property _U02 As Decimal
    Get
        Return mU02
    End Get
    Set(ByVal value As Decimal)
        mU02 = value
    End Set
End Property

Dim mU03 As Decimal
Public Property _U03 As Decimal
    Get
        Return mU03
    End Get
    Set(ByVal value As Decimal)
        mU03 = value
    End Set
End Property

Dim mU04 As Decimal
Public Property _U04 As Decimal
    Get
        Return mU04
    End Get
    Set(ByVal value As Decimal)
        mU04 = value
    End Set
End Property

Dim mU05 As Decimal
Public Property _U05 As Decimal
    Get
        Return mU05
    End Get
    Set(ByVal value As Decimal)
        mU05 = value
    End Set
End Property

Dim mU06 As Decimal
Public Property _U06 As Decimal
    Get
        Return mU06
    End Get
    Set(ByVal value As Decimal)
        mU06 = value
    End Set
End Property

Dim mU07 As Decimal
Public Property _U07 As Decimal
    Get
        Return mU07
    End Get
    Set(ByVal value As Decimal)
        mU07 = value
    End Set
End Property

Dim mU08 As Decimal
Public Property _U08 As Decimal
    Get
        Return mU08
    End Get
    Set(ByVal value As Decimal)
        mU08 = value
    End Set
End Property

Dim mU09 As Decimal
Public Property _U09 As Decimal
    Get
        Return mU09
    End Get
    Set(ByVal value As Decimal)
        mU09 = value
    End Set
End Property

Dim mU10 As Decimal
Public Property _U10 As Decimal
    Get
        Return mU10
    End Get
    Set(ByVal value As Decimal)
        mU10 = value
    End Set
End Property

Dim mU11 As Decimal
Public Property _U11 As Decimal
    Get
        Return mU11
    End Get
    Set(ByVal value As Decimal)
        mU11 = value
    End Set
End Property

Dim mU12 As Decimal
Public Property _U12 As Decimal
    Get
        Return mU12
    End Get
    Set(ByVal value As Decimal)
        mU12 = value
    End Set
End Property

Dim mE01 As Decimal
Public Property _E01 As Decimal
    Get
        Return mE01
    End Get
    Set(ByVal value As Decimal)
        mE01 = value
    End Set
End Property

Dim mE02 As Decimal
Public Property _E02 As Decimal
    Get
        Return mE02
    End Get
    Set(ByVal value As Decimal)
        mE02 = value
    End Set
End Property

Dim mE03 As Decimal
Public Property _E03 As Decimal
    Get
        Return mE03
    End Get
    Set(ByVal value As Decimal)
        mE03 = value
    End Set
End Property

Dim mE04 As Decimal
Public Property _E04 As Decimal
    Get
        Return mE04
    End Get
    Set(ByVal value As Decimal)
        mE04 = value
    End Set
End Property

Dim mE05 As Decimal
Public Property _E05 As Decimal
    Get
        Return mE05
    End Get
    Set(ByVal value As Decimal)
        mE05 = value
    End Set
End Property

Dim mE06 As Decimal
Public Property _E06 As Decimal
    Get
        Return mE06
    End Get
    Set(ByVal value As Decimal)
        mE06 = value
    End Set
End Property

Dim mE07 As Decimal
Public Property _E07 As Decimal
    Get
        Return mE07
    End Get
    Set(ByVal value As Decimal)
        mE07 = value
    End Set
End Property

Dim mE08 As Decimal
Public Property _E08 As Decimal
    Get
        Return mE08
    End Get
    Set(ByVal value As Decimal)
        mE08 = value
    End Set
End Property

Dim mE09 As Decimal
Public Property _E09 As Decimal
    Get
        Return mE09
    End Get
    Set(ByVal value As Decimal)
        mE09 = value
    End Set
End Property

Dim mE10 As Decimal
Public Property _E10 As Decimal
    Get
        Return mE10
    End Get
    Set(ByVal value As Decimal)
        mE10 = value
    End Set
End Property

Dim mE11 As Decimal
Public Property _E11 As Decimal
    Get
        Return mE11
    End Get
    Set(ByVal value As Decimal)
        mE11 = value
    End Set
End Property

Dim mE12 As Decimal
Public Property _E12 As Decimal
    Get
        Return mE12
    End Get
    Set(ByVal value As Decimal)
        mE12 = value
    End Set
End Property

Dim mR01 As Decimal
Public Property _R01 As Decimal
    Get
        Return mR01
    End Get
    Set(ByVal value As Decimal)
        mR01 = value
    End Set
End Property

Dim mR02 As Decimal
Public Property _R02 As Decimal
    Get
        Return mR02
    End Get
    Set(ByVal value As Decimal)
        mR02 = value
    End Set
End Property

Dim mR03 As Decimal
Public Property _R03 As Decimal
    Get
        Return mR03
    End Get
    Set(ByVal value As Decimal)
        mR03 = value
    End Set
End Property

Dim mR04 As Decimal
Public Property _R04 As Decimal
    Get
        Return mR04
    End Get
    Set(ByVal value As Decimal)
        mR04 = value
    End Set
End Property

Dim mR05 As Decimal
Public Property _R05 As Decimal
    Get
        Return mR05
    End Get
    Set(ByVal value As Decimal)
        mR05 = value
    End Set
End Property

Dim mR06 As Decimal
Public Property _R06 As Decimal
    Get
        Return mR06
    End Get
    Set(ByVal value As Decimal)
        mR06 = value
    End Set
End Property

Dim mR07 As Decimal
Public Property _R07 As Decimal
    Get
        Return mR07
    End Get
    Set(ByVal value As Decimal)
        mR07 = value
    End Set
End Property

Dim mR08 As Decimal
Public Property _R08 As Decimal
    Get
        Return mR08
    End Get
    Set(ByVal value As Decimal)
        mR08 = value
    End Set
End Property

Dim mR09 As Decimal
Public Property _R09 As Decimal
    Get
        Return mR09
    End Get
    Set(ByVal value As Decimal)
        mR09 = value
    End Set
End Property

Dim mR10 As Decimal
Public Property _R10 As Decimal
    Get
        Return mR10
    End Get
    Set(ByVal value As Decimal)
        mR10 = value
    End Set
End Property

Dim mR11 As Decimal
Public Property _R11 As Decimal
    Get
        Return mR11
    End Get
    Set(ByVal value As Decimal)
        mR11 = value
    End Set
End Property

Dim mR12 As Decimal
Public Property _R12 As Decimal
    Get
        Return mR12
    End Get
    Set(ByVal value As Decimal)
        mR12 = value
    End Set
End Property

Dim mP01 As Decimal
Public Property _P01 As Decimal
    Get
        Return mP01
    End Get
    Set(ByVal value As Decimal)
        mP01 = value
    End Set
End Property

Dim mP02 As Decimal
Public Property _P02 As Decimal
    Get
        Return mP02
    End Get
    Set(ByVal value As Decimal)
        mP02 = value
    End Set
End Property

Dim mP03 As Decimal
Public Property _P03 As Decimal
    Get
        Return mP03
    End Get
    Set(ByVal value As Decimal)
        mP03 = value
    End Set
End Property

Dim mP04 As Decimal
Public Property _P04 As Decimal
    Get
        Return mP04
    End Get
    Set(ByVal value As Decimal)
        mP04 = value
    End Set
End Property

Dim mP05 As Decimal
Public Property _P05 As Decimal
    Get
        Return mP05
    End Get
    Set(ByVal value As Decimal)
        mP05 = value
    End Set
End Property

Dim mP06 As Decimal
Public Property _P06 As Decimal
    Get
        Return mP06
    End Get
    Set(ByVal value As Decimal)
        mP06 = value
    End Set
End Property

Dim mP07 As Decimal
Public Property _P07 As Decimal
    Get
        Return mP07
    End Get
    Set(ByVal value As Decimal)
        mP07 = value
    End Set
End Property

Dim mP08 As Decimal
Public Property _P08 As Decimal
    Get
        Return mP08
    End Get
    Set(ByVal value As Decimal)
        mP08 = value
    End Set
End Property

Dim mP09 As Decimal
Public Property _P09 As Decimal
    Get
        Return mP09
    End Get
    Set(ByVal value As Decimal)
        mP09 = value
    End Set
End Property

Dim mP10 As Decimal
Public Property _P10 As Decimal
    Get
        Return mP10
    End Get
    Set(ByVal value As Decimal)
        mP10 = value
    End Set
End Property

Dim mP11 As Decimal
Public Property _P11 As Decimal
    Get
        Return mP11
    End Get
    Set(ByVal value As Decimal)
        mP11 = value
    End Set
End Property

Dim mP12 As Decimal
Public Property _P12 As Decimal
    Get
        Return mP12
    End Get
    Set(ByVal value As Decimal)
        mP12 = value
    End Set
End Property

Dim mJ01 As Decimal
Public Property _J01 As Decimal
    Get
        Return mJ01
    End Get
    Set(ByVal value As Decimal)
        mJ01 = value
    End Set
End Property

Dim mJ02 As Decimal
Public Property _J02 As Decimal
    Get
        Return mJ02
    End Get
    Set(ByVal value As Decimal)
        mJ02 = value
    End Set
End Property

Dim mJ03 As Decimal
Public Property _J03 As Decimal
    Get
        Return mJ03
    End Get
    Set(ByVal value As Decimal)
        mJ03 = value
    End Set
End Property

Dim mJ04 As Decimal
Public Property _J04 As Decimal
    Get
        Return mJ04
    End Get
    Set(ByVal value As Decimal)
        mJ04 = value
    End Set
End Property

Dim mJ05 As Decimal
Public Property _J05 As Decimal
    Get
        Return mJ05
    End Get
    Set(ByVal value As Decimal)
        mJ05 = value
    End Set
End Property

Dim mJ06 As Decimal
Public Property _J06 As Decimal
    Get
        Return mJ06
    End Get
    Set(ByVal value As Decimal)
        mJ06 = value
    End Set
End Property

Dim mJ07 As Decimal
Public Property _J07 As Decimal
    Get
        Return mJ07
    End Get
    Set(ByVal value As Decimal)
        mJ07 = value
    End Set
End Property

Dim mJ08 As Decimal
Public Property _J08 As Decimal
    Get
        Return mJ08
    End Get
    Set(ByVal value As Decimal)
        mJ08 = value
    End Set
End Property

Dim mJ09 As Decimal
Public Property _J09 As Decimal
    Get
        Return mJ09
    End Get
    Set(ByVal value As Decimal)
        mJ09 = value
    End Set
End Property

Dim mJ10 As Decimal
Public Property _J10 As Decimal
    Get
        Return mJ10
    End Get
    Set(ByVal value As Decimal)
        mJ10 = value
    End Set
End Property

Dim mJ11 As Decimal
Public Property _J11 As Decimal
    Get
        Return mJ11
    End Get
    Set(ByVal value As Decimal)
        mJ11 = value
    End Set
End Property

Dim mJ12 As Decimal
Public Property _J12 As Decimal
    Get
        Return mJ12
    End Get
    Set(ByVal value As Decimal)
        mJ12 = value
    End Set
End Property
Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property
#End Region

End Class

