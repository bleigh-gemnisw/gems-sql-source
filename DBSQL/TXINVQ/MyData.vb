Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader
  Dim ds2 As DataSet = New DataSet
  Dim dt As DataTable
  Private currentIndex As Integer = -1
  Const cFileName As String = "TXINV"

  '--- Added for optimized combo TXINV + TXHST preload   txe08
  Private ComboDS As DataSet
  Private ComboIndex As Integer = -1


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
    objCommand.CommandTimeout = 300

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
    objCommand.CommandTimeout = 300
    'MK 8/14/25 Begin
    'objReader = objCommand.ExecuteReader()
    objReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
    'MK 8/14/25 End
  End Sub
  'MK 7/28/25 Begin
  'Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal WrkFields As String)
  Public Sub OpenQry(ByVal WrkSort As String, ByVal WrkQry As String, ByVal WrkFields As String, ByVal WrkLock As Boolean)
    'MK 7/28/25 End
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    'MK 7/28/25 Begin
    'StrSQL = "Select " & WrkFields & " from " & cFileName
    If WrkLock Then
      StrSQL = "Select " & WrkFields & " from " & cFileName
    Else
      StrSQL = "Select " & WrkFields & " from " & cFileName & " with (NOLOCK)"
    End If
    'MK 7/28/25 End
    If WrkQry <> String.Empty Then
      StrSQL = StrSQL & " where " & WrkQry
    End If
    If WrkSort <> String.Empty Then
      StrSQL = StrSQL & " order by " & WrkSort
    End If
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.CommandTimeout = 300
    'MK 8/14/25 Begin
    'objReader = objCommand.ExecuteReader()
    objReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection)
    'MK 8/14/25 End
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
  Public Sub ReadQry(ByVal WrkFields As String)
    Dim Good As Boolean
    Dim Pos As Integer

    IsEOF = False
    Good = objReader.Read
    If Good Then
      Pos = InStr(WrkFields, "SS#")
      If Pos = 0 Then
        GetView()
      Else
        GetView(1)
      End If
    Else
      IsEOF = True
      objReader.Close()
    End If
  End Sub
  '------------------  6/1/25 added forbal sheet txe08
  Public Sub OpenComboQry(WrkFromYear As Integer, WrkToYear As Integer, WrkDist As Integer, WrkPhase As Integer, WrkTypes As String)
    ComboIndex = -1
    ComboDS = New DataSet()

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand("usp_GetTXINVWithTXHST", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@WrkFromYear", WrkFromYear)
        cmd.Parameters.AddWithValue("@WrkToYear", WrkToYear)
        cmd.Parameters.AddWithValue("@WrkDist", If(WrkDist = 0, DBNull.Value, WrkDist))
        cmd.Parameters.AddWithValue("@WrkPhase", If(WrkPhase = 0, DBNull.Value, WrkPhase))
        cmd.Parameters.AddWithValue("@WrkTypes", WrkTypes)

        Using da As New SqlDataAdapter(cmd)
          da.Fill(ComboDS)
        End Using
      End Using
    End Using
  End Sub
  Public Sub ReadComboQry()
    ComboIndex += 1
    If ComboIndex >= ComboDS.Tables(0).Rows.Count Then
      IsEOF = True
    Else
      IsEOF = False
      Dim dr As DataRow = ComboDS.Tables(0).Rows(ComboIndex)

      _LISTNo = If(IsDBNull(dr("List#")), 0, dr("List#"))
      _YEAR = If(IsDBNull(dr("YEAR")), 0, dr("YEAR"))
      _TYPE = If(IsDBNull(dr("TYPE")), "", dr("TYPE").ToString())
      _NAME = If(IsDBNull(dr("NAME")), "", dr("NAME").ToString())
      _DIST = If(IsDBNull(dr("DIST")), 0, dr("DIST"))
      _PHASE = If(IsDBNull(dr("PHASE")), 0, dr("PHASE"))
      _ICODE = If(IsDBNull(dr("ICODE")), "", dr("ICODE").ToString())
      _TAXT = If(IsDBNull(dr("TAXT")), 0D, dr("TAXT"))
      _PDAT = If(IsDBNull(dr("PDAT")), 0D, Convert.ToDecimal(dr("PDAT")))
      _CCNO = If(IsDBNull(dr("CCNO")), 0, dr("CCNO"))
      _CDATE = If(IsDBNull(dr("CDATE")), 0D, Convert.ToDecimal(dr("CDATE")))
      _CCETAX = If(IsDBNull(dr("CCETAX")), 0D, dr("CCETAX"))
      _SUSCD = If(IsDBNull(dr("SUSCD")), "", dr("SUSCD").ToString())
      _SUSDT = If(IsDBNull(dr("SUSDT")), 0D, Convert.ToDecimal(dr("SUSDT")))
    End If
  End Sub

  Public Function GetTXHSTRowsForCurrentRecord() As DataRow()
    Dim filter As String = $"[List#] = {_LISTNo} AND YEAR = {_YEAR} AND TYPE = '{_TYPE}'"
    Return ComboDS.Tables(1).Select(filter)
  End Function
  '-------------------- end add 6/1/25
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields()
    With objReader
      _ICODE = .Item("ICODE")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _DIST = .Item("DIST")
      _TAXT = .Item("TAXT")
      _TAX1 = .Item("TAX1")
      _TAX2 = .Item("TAX2")
      _PAYREC = .Item("PAYREC")
      _NEWPAY = .Item("NEWPAY")
      _GROSS = .Item("GROSS")
      _TOTEXP = .Item("TOTEXP")
      _NETASS = .Item("NETASS")
      _LOCNo = .Item("LOC#")
      _LOC = .Item("LOC")
      _LIEN = .Item("LIEN")
      _SUSCD = .Item("SUSCD")
      _SUSDT = .Item("SUSDT")
      _CCNO = .Item("CCNO")
      _CCETAX = .Item("CCETAX")
      _CCTX1 = .Item("CCTX1")
      _CCTX2 = .Item("CCTX2")
      _CGRS = .Item("CGRS")
      _CCEXP = .Item("CCEXP")
      _CDATE = .Item("CDATE")
      _CCRSN = .Item("CCRSN")
      _VOL = .Item("VOL")
      _IPAGE = .Item("IPAGE")
      _MAP = .Item("MAP")
      _BKSR = .Item("BKSR")
      _BKCD = .Item("BKCD")
      _FRCD = .Item("FRCD")
      _FRYR = .Item("FRYR")
      _PCD = .Item("PCD")
      _PHASE = .Item("PHASE")
      _IPPCD1 = .Item("IPPCD1")
      _IPPCD2 = .Item("IPPCD2")
      _IPPCD3 = .Item("IPPCD3")
      _IPPCD4 = .Item("IPPCD4")
      _IPPCD5 = .Item("IPPCD5")
      _IPPCD6 = .Item("IPPCD6")
      _IPPCD7 = .Item("IPPCD7")
      _IPPCD8 = .Item("IPPCD8")
      _IPPCD9 = .Item("IPPCD9")
      _IPPCDA = .Item("IPPCDA")
      _MAKE = .Item("MAKE")
      _MVYR = .Item("MVYR")
      _MODEL = .Item("MODEL")
      _BODY = .Item("BODY")
      _CLASS = .Item("CLASS")
      _IMVIDNo = .Item("IMVID#")
      _IMVREG = .Item("IMVREG")
      _ILEASE = .Item("ILEASE")
      _ICVGRS = .Item("ICVGRS")
      _ICVACD = .Item("ICVACD")
      _ICVREG = .Item("ICVREG")
      _ICVMKE = .Item("ICVMKE")
      _ICVYR = .Item("ICVYR")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _AGY = .Item("AGY")
      _ADATE = .Item("ADATE")
      _LETT = .Item("LETT")
      _INTPD = .Item("INTPD")
      _LNPD = .Item("LNPD")
      _RPD = .Item("RPD")
      _TXIDT = .Item("TXIDT")
      _PRPRI = .Item("PRPRI")
      _PRINT = .Item("PRINT")
      _PRLIN = .Item("PRLIN")
      _TX3RD = .Item("TX3RD")
      _TX4TH = .Item("TX4TH")
      _TXINT = .Item("TXINT")
      _PDAT = .Item("PDAT")
      _MVFLAG = .Item("MVFLAG")
      _CEODC = .Item("CEODC")
      _BOND = .Item("BOND")
      _BONDP = .Item("BONDP")
      _BONT = .Item("BONT")
      _STCD1 = .Item("STCD1")
      _STCD2 = .Item("STCD2")
      _STCD3 = .Item("STCD3")
      _STCD4 = .Item("STCD4")
      _STCD5 = .Item("STCD5")
      _DOB = .Item("DOB")
      _PINPD = .Item("PINPD")
      _BALD = .Item("BALD")
      _CCTX3 = .Item("CCTX3")
      _CCTX4 = .Item("CCTX4")
      _OAS1 = .Item("OAS1")
      _OAS2 = .Item("OAS2")
      _OAS3 = .Item("OAS3")
      _OAS4 = .Item("OAS4")
      _OAS5 = .Item("OAS5")
      _OAS6 = .Item("OAS6")
      _OAS7 = .Item("OAS7")
      _OAS8 = .Item("OAS8")
      _OAS9 = .Item("OAS9")
      _OAS10 = .Item("OAS10")
      _CASS1 = .Item("CASS1")
      _CASS2 = .Item("CASS2")
      _CASS3 = .Item("CASS3")
      _CASS4 = .Item("CASS4")
      _CASS5 = .Item("CASS5")
      _CASS6 = .Item("CASS6")
      _CASS7 = .Item("CASS7")
      _CASS8 = .Item("CASS8")
      _CASS9 = .Item("CASS9")
      _CASS10 = .Item("CASS10")
      _UNIT1 = .Item("UNIT1")
      _UNIT2 = .Item("UNIT2")
      _UNIT3 = .Item("UNIT3")
      _UNIT4 = .Item("UNIT4")
      _UNIT5 = .Item("UNIT5")
      _UNIT6 = .Item("UNIT6")
      _UNIT7 = .Item("UNIT7")
      _UNIT8 = .Item("UNIT8")
      _UNIT9 = .Item("UNIT9")
      _UNITA = .Item("UNITA")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXCD6 = .Item("EXCD6")
      _EXCD7 = .Item("EXCD7")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _EXAM6 = .Item("EXAM6")
      _EXAM7 = .Item("EXAM7")
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CCCD6 = .Item("CCCD6")
      _CCCD7 = .Item("CCCD7")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _CEXA6 = .Item("CEXA6")
      _CEXA7 = .Item("CEXA7")
      _CPERC = .Item("CPERC")
      _CMAX = .Item("CMAX")
      _CMIN = .Item("CMIN")
      _CIRAD = .Item("CIRAD")
      _FTAX = .Item("FTAX")
      _FASS = .Item("FASS")
      _TWNBN = .Item("TWNBN")
      _ASS = .Item("ASS")
      _CMVDC = .Item("CMVDC")
      _CCM = .Item("CCM")
      _RLST = .Item("RLST")
      _PDST = .Item("PDST")
      _ICVIDNo = .Item("ICVID#")
      _ICVMOD = .Item("ICVMOD")
      _ICVCLS = .Item("ICVCLS")
      _OID = .Item("OID")
      _SSNo = .Item("SS#")
      _SS2 = .Item("SS2")
      _TIN = .Item("TIN")
      _FEC1 = .Item("FEC1")
      _FEC2 = .Item("FEC2")
      _FEC3 = .Item("FEC3")
      _FEC4 = .Item("FEC4")
      _FEC5 = .Item("FEC5")
      _FED1 = .Item("FED1")
      _FED2 = .Item("FED2")
      _FED3 = .Item("FED3")
      _FED4 = .Item("FED4")
      _FED5 = .Item("FED5")
      _ABAT = .Item("ABAT")
      _ACD = .Item("ACD")
      _DECD = .Item("DECD")
      _INTY = .Item("INTY")
      _INPCT = .Item("INPCT")
      _ACCTN = .Item("ACCTN")
      _ETC1 = .Item("ETC1")
      _ETC2 = .Item("ETC2")
      _ETC3 = .Item("ETC3")
      _ETC4 = .Item("ETC4")
      _ETC5 = .Item("ETC5")
      _ETC6 = .Item("ETC6")
      _ETC7 = .Item("ETC7")
      _ETC8 = .Item("ETC8")
      _ETC9 = .Item("ETC9")
      _ETCA = .Item("ETCA")
      _XDATE = .Item("XDATE")
      _DEFERT = .Item("DEFERT")
      _DEFER1 = .Item("DEFER1")
      _DEFER2 = .Item("DEFER2")
      _DEFER3 = .Item("DEFER3")
      _DEFER4 = .Item("DEFER4")
      _CCINT30 = .Item("CCINT30")
    End With
  End Sub
  Public Sub GetFieldsDr(ByVal Dr As DataRow)
    With Dr
      _ICODE = .Item("ICODE")
      _LISTNo = .Item("LIST#")
      _YEAR = .Item("YEAR")
      _TYPE = .Item("TYPE")
      _NAME = .Item("NAME")
      _SNAME = .Item("SNAME")
      _ADD1 = .Item("ADD1")
      _ADD2 = .Item("ADD2")
      _CITY = .Item("CITY")
      _STATE = .Item("STATE")
      _ZIP5 = .Item("ZIP5")
      _ZIP4 = .Item("ZIP4")
      _DIST = .Item("DIST")
      _TAXT = .Item("TAXT")
      _TAX1 = .Item("TAX1")
      _TAX2 = .Item("TAX2")
      _PAYREC = .Item("PAYREC")
      _NEWPAY = .Item("NEWPAY")
      _GROSS = .Item("GROSS")
      _TOTEXP = .Item("TOTEXP")
      _NETASS = .Item("NETASS")
      _LOCNo = .Item("LOC#")
      _LOC = .Item("LOC")
      _LIEN = .Item("LIEN")
      _SUSCD = .Item("SUSCD")
      _SUSDT = .Item("SUSDT")
      _CCNO = .Item("CCNO")
      _CCETAX = .Item("CCETAX")
      _CCTX1 = .Item("CCTX1")
      _CCTX2 = .Item("CCTX2")
      _CGRS = .Item("CGRS")
      _CCEXP = .Item("CCEXP")
      _CDATE = .Item("CDATE")
      _CCRSN = .Item("CCRSN")
      _VOL = .Item("VOL")
      _IPAGE = .Item("IPAGE")
      _MAP = .Item("MAP")
      _BKSR = .Item("BKSR")
      _BKCD = .Item("BKCD")
      _FRCD = .Item("FRCD")
      _FRYR = .Item("FRYR")
      _PCD = .Item("PCD")
      _PHASE = .Item("PHASE")
      _IPPCD1 = .Item("IPPCD1")
      _IPPCD2 = .Item("IPPCD2")
      _IPPCD3 = .Item("IPPCD3")
      _IPPCD4 = .Item("IPPCD4")
      _IPPCD5 = .Item("IPPCD5")
      _IPPCD6 = .Item("IPPCD6")
      _IPPCD7 = .Item("IPPCD7")
      _IPPCD8 = .Item("IPPCD8")
      _IPPCD9 = .Item("IPPCD9")
      _IPPCDA = .Item("IPPCDA")
      _MAKE = .Item("MAKE")
      _MVYR = .Item("MVYR")
      _MODEL = .Item("MODEL")
      _BODY = .Item("BODY")
      _CLASS = .Item("CLASS")
      _IMVIDNo = .Item("IMVID#")
      _IMVREG = .Item("IMVREG")
      _ILEASE = .Item("ILEASE")
      _ICVGRS = .Item("ICVGRS")
      _ICVACD = .Item("ICVACD")
      _ICVREG = .Item("ICVREG")
      _ICVMKE = .Item("ICVMKE")
      _ICVYR = .Item("ICVYR")
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _AGY = .Item("AGY")
      _ADATE = .Item("ADATE")
      _LETT = .Item("LETT")
      _INTPD = .Item("INTPD")
      _LNPD = .Item("LNPD")
      _RPD = .Item("RPD")
      _TXIDT = .Item("TXIDT")
      _PRPRI = .Item("PRPRI")
      _PRINT = .Item("PRINT")
      _PRLIN = .Item("PRLIN")
      _TX3RD = .Item("TX3RD")
      _TX4TH = .Item("TX4TH")
      _TXINT = .Item("TXINT")
      _PDAT = .Item("PDAT")
      _MVFLAG = .Item("MVFLAG")
      _CEODC = .Item("CEODC")
      _BOND = .Item("BOND")
      _BONDP = .Item("BONDP")
      _BONT = .Item("BONT")
      _STCD1 = .Item("STCD1")
      _STCD2 = .Item("STCD2")
      _STCD3 = .Item("STCD3")
      _STCD4 = .Item("STCD4")
      _STCD5 = .Item("STCD5")
      _DOB = .Item("DOB")
      _PINPD = .Item("PINPD")
      _BALD = .Item("BALD")
      _CCTX3 = .Item("CCTX3")
      _CCTX4 = .Item("CCTX4")
      _OAS1 = .Item("OAS1")
      _OAS2 = .Item("OAS2")
      _OAS3 = .Item("OAS3")
      _OAS4 = .Item("OAS4")
      _OAS5 = .Item("OAS5")
      _OAS6 = .Item("OAS6")
      _OAS7 = .Item("OAS7")
      _OAS8 = .Item("OAS8")
      _OAS9 = .Item("OAS9")
      _OAS10 = .Item("OAS10")
      _CASS1 = .Item("CASS1")
      _CASS2 = .Item("CASS2")
      _CASS3 = .Item("CASS3")
      _CASS4 = .Item("CASS4")
      _CASS5 = .Item("CASS5")
      _CASS6 = .Item("CASS6")
      _CASS7 = .Item("CASS7")
      _CASS8 = .Item("CASS8")
      _CASS9 = .Item("CASS9")
      _CASS10 = .Item("CASS10")
      _UNIT1 = .Item("UNIT1")
      _UNIT2 = .Item("UNIT2")
      _UNIT3 = .Item("UNIT3")
      _UNIT4 = .Item("UNIT4")
      _UNIT5 = .Item("UNIT5")
      _UNIT6 = .Item("UNIT6")
      _UNIT7 = .Item("UNIT7")
      _UNIT8 = .Item("UNIT8")
      _UNIT9 = .Item("UNIT9")
      _UNITA = .Item("UNITA")
      _EXCD1 = .Item("EXCD1")
      _EXCD2 = .Item("EXCD2")
      _EXCD3 = .Item("EXCD3")
      _EXCD4 = .Item("EXCD4")
      _EXCD5 = .Item("EXCD5")
      _EXCD6 = .Item("EXCD6")
      _EXCD7 = .Item("EXCD7")
      _EXAM1 = .Item("EXAM1")
      _EXAM2 = .Item("EXAM2")
      _EXAM3 = .Item("EXAM3")
      _EXAM4 = .Item("EXAM4")
      _EXAM5 = .Item("EXAM5")
      _EXAM6 = .Item("EXAM6")
      _EXAM7 = .Item("EXAM7")
      _CCCD1 = .Item("CCCD1")
      _CCCD2 = .Item("CCCD2")
      _CCCD3 = .Item("CCCD3")
      _CCCD4 = .Item("CCCD4")
      _CCCD5 = .Item("CCCD5")
      _CCCD6 = .Item("CCCD6")
      _CCCD7 = .Item("CCCD7")
      _CEXA1 = .Item("CEXA1")
      _CEXA2 = .Item("CEXA2")
      _CEXA3 = .Item("CEXA3")
      _CEXA4 = .Item("CEXA4")
      _CEXA5 = .Item("CEXA5")
      _CEXA6 = .Item("CEXA6")
      _CEXA7 = .Item("CEXA7")
      _CPERC = .Item("CPERC")
      _CMAX = .Item("CMAX")
      _CMIN = .Item("CMIN")
      _CIRAD = .Item("CIRAD")
      _FTAX = .Item("FTAX")
      _FASS = .Item("FASS")
      _TWNBN = .Item("TWNBN")
      _ASS = .Item("ASS")
      _CMVDC = .Item("CMVDC")
      _CCM = .Item("CCM")
      _RLST = .Item("RLST")
      _PDST = .Item("PDST")
      _ICVIDNo = .Item("ICVID#")
      _ICVMOD = .Item("ICVMOD")
      _ICVCLS = .Item("ICVCLS")
      _OID = .Item("OID")
      _SSNo = .Item("SS#")
      _SS2 = .Item("SS2")
      _TIN = .Item("TIN")
      _FEC1 = .Item("FEC1")
      _FEC2 = .Item("FEC2")
      _FEC3 = .Item("FEC3")
      _FEC4 = .Item("FEC4")
      _FEC5 = .Item("FEC5")
      _FED1 = .Item("FED1")
      _FED2 = .Item("FED2")
      _FED3 = .Item("FED3")
      _FED4 = .Item("FED4")
      _FED5 = .Item("FED5")
      _ABAT = .Item("ABAT")
      _ACD = .Item("ACD")
      _DECD = .Item("DECD")
      _INTY = .Item("INTY")
      _INPCT = .Item("INPCT")
      _ACCTN = .Item("ACCTN")
      _ETC1 = .Item("ETC1")
      _ETC2 = .Item("ETC2")
      _ETC3 = .Item("ETC3")
      _ETC4 = .Item("ETC4")
      _ETC5 = .Item("ETC5")
      _ETC6 = .Item("ETC6")
      _ETC7 = .Item("ETC7")
      _ETC8 = .Item("ETC8")
      _ETC9 = .Item("ETC9")
      _ETCA = .Item("ETCA")
      _XDATE = .Item("XDATE")
      _DEFERT = .Item("DEFERT")
      _DEFER1 = .Item("DEFER1")
      _DEFER2 = .Item("DEFER2")
      _DEFER3 = .Item("DEFER3")
      _DEFER4 = .Item("DEFER4")
      _CCINT30 = .Item("CCINT30")
    End With
  End Sub
  Public Sub GetView(Optional ByVal WrkFormat As Integer = 0)
    Select Case WrkFormat
      Case 1
        With objReader
          _LISTNo = .Item("LIST#")
          _YEAR = .Item("YEAR")
          _TYPE = .Item("TYPE")
          _NAME = .Item("NAME")
          _ADD1 = .Item("ADD1")
          _CITY = .Item("CITY")
          _SSNo = .Item("SS#")
          _SS2 = .Item("ss2")
          _NEWPAY = .Item("NEWPAY")
          _DOB = .Item("DOB")
        End With
      Case Else
        With objReader
          _ICODE = .Item("ICODE")
          _LISTNo = .Item("LIST#")
          _YEAR = .Item("YEAR")
          _TYPE = .Item("TYPE")
          _NAME = .Item("NAME")
          _DIST = .Item("DIST")
          _PHASE = .Item("PHASE")
          _TAXT = .Item("TAXT")
          _CCNO = .Item("CCNO")
          _CDATE = .Item("CDATE")
          _CCETAX = .Item("CCETAX")
          _SUSCD = .Item("SUSCD")
          _SUSDT = .Item("SUSDT")
        End With
    End Select
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
  Dim mICODE As String
  Public Property _ICODE As String
    Get
      Return mICODE
    End Get
    Set(ByVal value As String)
      mICODE = value
    End Set
  End Property
  Dim mLISTNo As Integer
  Public Property _LISTNo As Integer
    Get
      Return mLISTNo
    End Get
    Set(ByVal value As Integer)
      mLISTNo = value
    End Set
  End Property
  Dim mYEAR As Integer
  Public Property _YEAR As Integer
    Get
      Return mYEAR
    End Get
    Set(ByVal value As Integer)
      mYEAR = value
    End Set
  End Property
  Dim mTYPE As String
  Public Property _TYPE As String
    Get
      Return mTYPE
    End Get
    Set(ByVal value As String)
      mTYPE = value
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

  Dim mSNAME As String
  Public Property _SNAME As String
    Get
      Return mSNAME
    End Get
    Set(ByVal value As String)
      mSNAME = value
    End Set
  End Property

  Dim mADD1 As String
  Public Property _ADD1 As String
    Get
      Return mADD1
    End Get
    Set(ByVal value As String)
      mADD1 = value
    End Set
  End Property

  Dim mADD2 As String
  Public Property _ADD2 As String
    Get
      Return mADD2
    End Get
    Set(ByVal value As String)
      mADD2 = value
    End Set
  End Property

  Dim mCITY As String
  Public Property _CITY As String
    Get
      Return mCITY
    End Get
    Set(ByVal value As String)
      mCITY = value
    End Set
  End Property

  Dim mSTATE As String
  Public Property _STATE As String
    Get
      Return mSTATE
    End Get
    Set(ByVal value As String)
      mSTATE = value
    End Set
  End Property

  Dim mZIP5 As Integer
  Public Property _ZIP5 As Integer
    Get
      Return mZIP5
    End Get
    Set(ByVal value As Integer)
      mZIP5 = value
    End Set
  End Property

  Dim mZIP4 As Integer
  Public Property _ZIP4 As Integer
    Get
      Return mZIP4
    End Get
    Set(ByVal value As Integer)
      mZIP4 = value
    End Set
  End Property

  Dim mDIST As Integer
  Public Property _DIST As Integer
    Get
      Return mDIST
    End Get
    Set(ByVal value As Integer)
      mDIST = value
    End Set
  End Property
  Dim mTAXT As Decimal
  Public Property _TAXT As Decimal
    Get
      Return mTAXT
    End Get
    Set(ByVal value As Decimal)
      mTAXT = value
    End Set
  End Property
  Dim mTAX1 As Decimal
  Public Property _TAX1 As Decimal
    Get
      Return mTAX1
    End Get
    Set(ByVal value As Decimal)
      mTAX1 = value
    End Set
  End Property

  Dim mTAX2 As Decimal
  Public Property _TAX2 As Decimal
    Get
      Return mTAX2
    End Get
    Set(ByVal value As Decimal)
      mTAX2 = value
    End Set
  End Property

  Dim mPAYREC As Decimal
  Public Property _PAYREC As Decimal
    Get
      Return mPAYREC
    End Get
    Set(ByVal value As Decimal)
      mPAYREC = value
    End Set
  End Property

  Dim mNEWPAY As Decimal
  Public Property _NEWPAY As Decimal
    Get
      Return mNEWPAY
    End Get
    Set(ByVal value As Decimal)
      mNEWPAY = value
    End Set
  End Property
  Dim mGROSS As Long
  Public Property _GROSS As Long
    Get
      Return mGROSS
    End Get
    Set(ByVal value As Long)
      mGROSS = value
    End Set
  End Property

  Dim mTOTEXP As Long
  Public Property _TOTEXP As Long
    Get
      Return mTOTEXP
    End Get
    Set(ByVal value As Long)
      mTOTEXP = value
    End Set
  End Property

  Dim mNETASS As Long
  Public Property _NETASS As Long
    Get
      Return mNETASS
    End Get
    Set(ByVal value As Long)
      mNETASS = value
    End Set
  End Property
  Dim mLOCNo As String
  Public Property _LOCNo As String
    Get
      Return mLOCNo
    End Get
    Set(ByVal value As String)
      mLOCNo = value
    End Set
  End Property

  Dim mLOC As String
  Public Property _LOC As String
    Get
      Return mLOC
    End Get
    Set(ByVal value As String)
      mLOC = value
    End Set
  End Property

  Dim mLIEN As String
  Public Property _LIEN As String
    Get
      Return mLIEN
    End Get
    Set(ByVal value As String)
      mLIEN = value
    End Set
  End Property

  Dim mSUSCD As String
  Public Property _SUSCD As String
    Get
      Return mSUSCD
    End Get
    Set(ByVal value As String)
      mSUSCD = value
    End Set
  End Property

  Dim mSUSDT As Integer
  Public Property _SUSDT As Integer
    Get
      Return mSUSDT
    End Get
    Set(ByVal value As Integer)
      mSUSDT = value
    End Set
  End Property

  Dim mCCNO As Integer
  Public Property _CCNO As Integer
    Get
      Return mCCNO
    End Get
    Set(ByVal value As Integer)
      mCCNO = value
    End Set
  End Property

  Dim mCCETAX As Decimal
  Public Property _CCETAX As Decimal
    Get
      Return mCCETAX
    End Get
    Set(ByVal value As Decimal)
      mCCETAX = value
    End Set
  End Property

  Dim mCCTX1 As Decimal
  Public Property _CCTX1 As Decimal
    Get
      Return mCCTX1
    End Get
    Set(ByVal value As Decimal)
      mCCTX1 = value
    End Set
  End Property

  Dim mCCTX2 As Decimal
  Public Property _CCTX2 As Decimal
    Get
      Return mCCTX2
    End Get
    Set(ByVal value As Decimal)
      mCCTX2 = value
    End Set
  End Property

  Dim mCGRS As Long
  Public Property _CGRS As Long
    Get
      Return mCGRS
    End Get
    Set(ByVal value As Long)
      mCGRS = value
    End Set
  End Property

  Dim mCCEXP As Long
  Public Property _CCEXP As Long
    Get
      Return mCCEXP
    End Get
    Set(ByVal value As Long)
      mCCEXP = value
    End Set
  End Property

  Dim mCDATE As Integer
  Public Property _CDATE As Integer
    Get
      Return mCDATE
    End Get
    Set(ByVal value As Integer)
      mCDATE = value
    End Set
  End Property

  Dim mCCRSN As String
  Public Property _CCRSN As String
    Get
      Return mCCRSN
    End Get
    Set(ByVal value As String)
      mCCRSN = value
    End Set
  End Property

  Dim mVOL As String
  Public Property _VOL As String
    Get
      Return mVOL
    End Get
    Set(ByVal value As String)
      mVOL = value
    End Set
  End Property

  Dim mIPAGE As String
  Public Property _IPAGE As String
    Get
      Return mIPAGE
    End Get
    Set(ByVal value As String)
      mIPAGE = value
    End Set
  End Property

  Dim mMAP As String
  Public Property _MAP As String
    Get
      Return mMAP
    End Get
    Set(ByVal value As String)
      mMAP = value
    End Set
  End Property

  Dim mBKSR As String
  Public Property _BKSR As String
    Get
      Return mBKSR
    End Get
    Set(ByVal value As String)
      mBKSR = value
    End Set
  End Property

  Dim mBKCD As String
  Public Property _BKCD As String
    Get
      Return mBKCD
    End Get
    Set(ByVal value As String)
      mBKCD = value
    End Set
  End Property

  Dim mFRCD As String
  Public Property _FRCD As String
    Get
      Return mFRCD
    End Get
    Set(ByVal value As String)
      mFRCD = value
    End Set
  End Property

  Dim mFRYR As Integer
  Public Property _FRYR As Integer
    Get
      Return mFRYR
    End Get
    Set(ByVal value As Integer)
      mFRYR = value
    End Set
  End Property

  Dim mPCD As String
  Public Property _PCD As String
    Get
      Return mPCD
    End Get
    Set(ByVal value As String)
      mPCD = value
    End Set
  End Property

  Dim mPHASE As Integer
  Public Property _PHASE As Integer
    Get
      Return mPHASE
    End Get
    Set(ByVal value As Integer)
      mPHASE = value
    End Set
  End Property

  Dim mIPPCD1 As Integer
  Public Property _IPPCD1 As Integer
    Get
      Return mIPPCD1
    End Get
    Set(ByVal value As Integer)
      mIPPCD1 = value
    End Set
  End Property

  Dim mIPPCD2 As Integer
  Public Property _IPPCD2 As Integer
    Get
      Return mIPPCD2
    End Get
    Set(ByVal value As Integer)
      mIPPCD2 = value
    End Set
  End Property

  Dim mIPPCD3 As Integer
  Public Property _IPPCD3 As Integer
    Get
      Return mIPPCD3
    End Get
    Set(ByVal value As Integer)
      mIPPCD3 = value
    End Set
  End Property

  Dim mIPPCD4 As Integer
  Public Property _IPPCD4 As Integer
    Get
      Return mIPPCD4
    End Get
    Set(ByVal value As Integer)
      mIPPCD4 = value
    End Set
  End Property

  Dim mIPPCD5 As Integer
  Public Property _IPPCD5 As Integer
    Get
      Return mIPPCD5
    End Get
    Set(ByVal value As Integer)
      mIPPCD5 = value
    End Set
  End Property

  Dim mIPPCD6 As Integer
  Public Property _IPPCD6 As Integer
    Get
      Return mIPPCD6
    End Get
    Set(ByVal value As Integer)
      mIPPCD6 = value
    End Set
  End Property

  Dim mIPPCD7 As Integer
  Public Property _IPPCD7 As Integer
    Get
      Return mIPPCD7
    End Get
    Set(ByVal value As Integer)
      mIPPCD7 = value
    End Set
  End Property

  Dim mIPPCD8 As Integer
  Public Property _IPPCD8 As Integer
    Get
      Return mIPPCD8
    End Get
    Set(ByVal value As Integer)
      mIPPCD8 = value
    End Set
  End Property

  Dim mIPPCD9 As Integer
  Public Property _IPPCD9 As Integer
    Get
      Return mIPPCD9
    End Get
    Set(ByVal value As Integer)
      mIPPCD9 = value
    End Set
  End Property

  Dim mIPPCDA As Integer
  Public Property _IPPCDA As Integer
    Get
      Return mIPPCDA
    End Get
    Set(ByVal value As Integer)
      mIPPCDA = value
    End Set
  End Property

  Dim mMAKE As String
  Public Property _MAKE As String
    Get
      Return mMAKE
    End Get
    Set(ByVal value As String)
      mMAKE = value
    End Set
  End Property

  Dim mMVYR As Integer
  Public Property _MVYR As Integer
    Get
      Return mMVYR
    End Get
    Set(ByVal value As Integer)
      mMVYR = value
    End Set
  End Property

  Dim mMODEL As String
  Public Property _MODEL As String
    Get
      Return mMODEL
    End Get
    Set(ByVal value As String)
      mMODEL = value
    End Set
  End Property

  Dim mBODY As String
  Public Property _BODY As String
    Get
      Return mBODY
    End Get
    Set(ByVal value As String)
      mBODY = value
    End Set
  End Property

  Dim mCLASS As Integer
  Public Property _CLASS As Integer
    Get
      Return mCLASS
    End Get
    Set(ByVal value As Integer)
      mCLASS = value
    End Set
  End Property

  Dim mIMVIDNo As String
  Public Property _IMVIDNo As String
    Get
      Return mIMVIDNo
    End Get
    Set(ByVal value As String)
      mIMVIDNo = value
    End Set
  End Property

  Dim mIMVREG As String
  Public Property _IMVREG As String
    Get
      Return mIMVREG
    End Get
    Set(ByVal value As String)
      mIMVREG = value
    End Set
  End Property

  Dim mILEASE As String
  Public Property _ILEASE As String
    Get
      Return mILEASE
    End Get
    Set(ByVal value As String)
      mILEASE = value
    End Set
  End Property

  Dim mICVGRS As Long
  Public Property _ICVGRS As Long
    Get
      Return mICVGRS
    End Get
    Set(ByVal value As Long)
      mICVGRS = value
    End Set
  End Property

  Dim mICVACD As String
  Public Property _ICVACD As String
    Get
      Return mICVACD
    End Get
    Set(ByVal value As String)
      mICVACD = value
    End Set
  End Property

  Dim mICVREG As String
  Public Property _ICVREG As String
    Get
      Return mICVREG
    End Get
    Set(ByVal value As String)
      mICVREG = value
    End Set
  End Property

  Dim mICVMKE As String
  Public Property _ICVMKE As String
    Get
      Return mICVMKE
    End Get
    Set(ByVal value As String)
      mICVMKE = value
    End Set
  End Property

  Dim mICVYR As Integer
  Public Property _ICVYR As Integer
    Get
      Return mICVYR
    End Get
    Set(ByVal value As Integer)
      mICVYR = value
    End Set
  End Property

  Dim mPRF As String
  Public Property _PRF As String
    Get
      Return mPRF
    End Get
    Set(ByVal value As String)
      mPRF = value
    End Set
  End Property

  Dim mCHDATE As Integer
  Public Property _CHDATE As Integer
    Get
      Return mCHDATE
    End Get
    Set(ByVal value As Integer)
      mCHDATE = value
    End Set
  End Property

  Dim mCHTIME As Integer
  Public Property _CHTIME As Integer
    Get
      Return mCHTIME
    End Get
    Set(ByVal value As Integer)
      mCHTIME = value
    End Set
  End Property

  Dim mAGY As String
  Public Property _AGY As String
    Get
      Return mAGY
    End Get
    Set(ByVal value As String)
      mAGY = value
    End Set
  End Property

  Dim mADATE As Integer
  Public Property _ADATE As Integer
    Get
      Return mADATE
    End Get
    Set(ByVal value As Integer)
      mADATE = value
    End Set
  End Property

  Dim mLETT As String
  Public Property _LETT As String
    Get
      Return mLETT
    End Get
    Set(ByVal value As String)
      mLETT = value
    End Set
  End Property

  Dim mINTPD As Decimal
  Public Property _INTPD As Decimal
    Get
      Return mINTPD
    End Get
    Set(ByVal value As Decimal)
      mINTPD = value
    End Set
  End Property

  Dim mLNPD As Decimal
  Public Property _LNPD As Decimal
    Get
      Return mLNPD
    End Get
    Set(ByVal value As Decimal)
      mLNPD = value
    End Set
  End Property

  Dim mRPD As Decimal
  Public Property _RPD As Decimal
    Get
      Return mRPD
    End Get
    Set(ByVal value As Decimal)
      mRPD = value
    End Set
  End Property

  Dim mTXIDT As Integer
  Public Property _TXIDT As Integer
    Get
      Return mTXIDT
    End Get
    Set(ByVal value As Integer)
      mTXIDT = value
    End Set
  End Property

  Dim mPRPRI As Decimal
  Public Property _PRPRI As Decimal
    Get
      Return mPRPRI
    End Get
    Set(ByVal value As Decimal)
      mPRPRI = value
    End Set
  End Property

  Dim mPRINT As Decimal
  Public Property _PRINT As Decimal
    Get
      Return mPRINT
    End Get
    Set(ByVal value As Decimal)
      mPRINT = value
    End Set
  End Property

  Dim mPRLIN As Decimal
  Public Property _PRLIN As Decimal
    Get
      Return mPRLIN
    End Get
    Set(ByVal value As Decimal)
      mPRLIN = value
    End Set
  End Property

  Dim mTX3RD As Decimal
  Public Property _TX3RD As Decimal
    Get
      Return mTX3RD
    End Get
    Set(ByVal value As Decimal)
      mTX3RD = value
    End Set
  End Property

  Dim mTX4TH As Decimal
  Public Property _TX4TH As Decimal
    Get
      Return mTX4TH
    End Get
    Set(ByVal value As Decimal)
      mTX4TH = value
    End Set
  End Property

  Dim mTXINT As Decimal
  Public Property _TXINT As Decimal
    Get
      Return mTXINT
    End Get
    Set(ByVal value As Decimal)
      mTXINT = value
    End Set
  End Property

  Dim mPDAT As Integer
  Public Property _PDAT As Integer
    Get
      Return mPDAT
    End Get
    Set(ByVal value As Integer)
      mPDAT = value
    End Set
  End Property

  Dim mMVFLAG As String
  Public Property _MVFLAG As String
    Get
      Return mMVFLAG
    End Get
    Set(ByVal value As String)
      mMVFLAG = value
    End Set
  End Property

  Dim mCEODC As String
  Public Property _CEODC As String
    Get
      Return mCEODC
    End Get
    Set(ByVal value As String)
      mCEODC = value
    End Set
  End Property

  Dim mBOND As Decimal
  Public Property _BOND As Decimal
    Get
      Return mBOND
    End Get
    Set(ByVal value As Decimal)
      mBOND = value
    End Set
  End Property

  Dim mBONDP As Decimal
  Public Property _BONDP As Decimal
    Get
      Return mBONDP
    End Get
    Set(ByVal value As Decimal)
      mBONDP = value
    End Set
  End Property

  Dim mBONT As Decimal
  Public Property _BONT As Decimal
    Get
      Return mBONT
    End Get
    Set(ByVal value As Decimal)
      mBONT = value
    End Set
  End Property

  Dim mSTCD1 As String
  Public Property _STCD1 As String
    Get
      Return mSTCD1
    End Get
    Set(ByVal value As String)
      mSTCD1 = value
    End Set
  End Property

  Dim mSTCD2 As String
  Public Property _STCD2 As String
    Get
      Return mSTCD2
    End Get
    Set(ByVal value As String)
      mSTCD2 = value
    End Set
  End Property

  Dim mSTCD3 As String
  Public Property _STCD3 As String
    Get
      Return mSTCD3
    End Get
    Set(ByVal value As String)
      mSTCD3 = value
    End Set
  End Property

  Dim mSTCD4 As String
  Public Property _STCD4 As String
    Get
      Return mSTCD4
    End Get
    Set(ByVal value As String)
      mSTCD4 = value
    End Set
  End Property

  Dim mSTCD5 As String
  Public Property _STCD5 As String
    Get
      Return mSTCD5
    End Get
    Set(ByVal value As String)
      mSTCD5 = value
    End Set
  End Property

  Dim mDOB As Integer
  Public Property _DOB As Integer
    Get
      Return mDOB
    End Get
    Set(ByVal value As Integer)
      mDOB = value
    End Set
  End Property

  Dim mPINPD As String
  Public Property _PINPD As String
    Get
      Return mPINPD
    End Get
    Set(ByVal value As String)
      mPINPD = value
    End Set
  End Property

  Dim mBALD As Decimal
  Public Property _BALD As Decimal
    Get
      Return mBALD
    End Get
    Set(ByVal value As Decimal)
      mBALD = value
    End Set
  End Property

  Dim mCCTX3 As Decimal
  Public Property _CCTX3 As Decimal
    Get
      Return mCCTX3
    End Get
    Set(ByVal value As Decimal)
      mCCTX3 = value
    End Set
  End Property

  Dim mCCTX4 As Decimal
  Public Property _CCTX4 As Decimal
    Get
      Return mCCTX4
    End Get
    Set(ByVal value As Decimal)
      mCCTX4 = value
    End Set
  End Property

  Dim mOAS1 As Long
  Public Property _OAS1 As Long
    Get
      Return mOAS1
    End Get
    Set(ByVal value As Long)
      mOAS1 = value
    End Set
  End Property

  Dim mOAS2 As Long
  Public Property _OAS2 As Long
    Get
      Return mOAS2
    End Get
    Set(ByVal value As Long)
      mOAS2 = value
    End Set
  End Property

  Dim mOAS3 As Long
  Public Property _OAS3 As Long
    Get
      Return mOAS3
    End Get
    Set(ByVal value As Long)
      mOAS3 = value
    End Set
  End Property

  Dim mOAS4 As Long
  Public Property _OAS4 As Long
    Get
      Return mOAS4
    End Get
    Set(ByVal value As Long)
      mOAS4 = value
    End Set
  End Property

  Dim mOAS5 As Long
  Public Property _OAS5 As Long
    Get
      Return mOAS5
    End Get
    Set(ByVal value As Long)
      mOAS5 = value
    End Set
  End Property

  Dim mOAS6 As Long
  Public Property _OAS6 As Long
    Get
      Return mOAS6
    End Get
    Set(ByVal value As Long)
      mOAS6 = value
    End Set
  End Property

  Dim mOAS7 As Long
  Public Property _OAS7 As Long
    Get
      Return mOAS7
    End Get
    Set(ByVal value As Long)
      mOAS7 = value
    End Set
  End Property

  Dim mOAS8 As Long
  Public Property _OAS8 As Long
    Get
      Return mOAS8
    End Get
    Set(ByVal value As Long)
      mOAS8 = value
    End Set
  End Property

  Dim mOAS9 As Long
  Public Property _OAS9 As Long
    Get
      Return mOAS9
    End Get
    Set(ByVal value As Long)
      mOAS9 = value
    End Set
  End Property

  Dim mOAS10 As Long
  Public Property _OAS10 As Long
    Get
      Return mOAS10
    End Get
    Set(ByVal value As Long)
      mOAS10 = value
    End Set
  End Property

  Dim mCASS1 As Long
  Public Property _CASS1 As Long
    Get
      Return mCASS1
    End Get
    Set(ByVal value As Long)
      mCASS1 = value
    End Set
  End Property

  Dim mCASS2 As Long
  Public Property _CASS2 As Long
    Get
      Return mCASS2
    End Get
    Set(ByVal value As Long)
      mCASS2 = value
    End Set
  End Property

  Dim mCASS3 As Long
  Public Property _CASS3 As Long
    Get
      Return mCASS3
    End Get
    Set(ByVal value As Long)
      mCASS3 = value
    End Set
  End Property

  Dim mCASS4 As Long
  Public Property _CASS4 As Long
    Get
      Return mCASS4
    End Get
    Set(ByVal value As Long)
      mCASS4 = value
    End Set
  End Property

  Dim mCASS5 As Long
  Public Property _CASS5 As Long
    Get
      Return mCASS5
    End Get
    Set(ByVal value As Long)
      mCASS5 = value
    End Set
  End Property

  Dim mCASS6 As Long
  Public Property _CASS6 As Long
    Get
      Return mCASS6
    End Get
    Set(ByVal value As Long)
      mCASS6 = value
    End Set
  End Property

  Dim mCASS7 As Long
  Public Property _CASS7 As Long
    Get
      Return mCASS7
    End Get
    Set(ByVal value As Long)
      mCASS7 = value
    End Set
  End Property

  Dim mCASS8 As Long
  Public Property _CASS8 As Long
    Get
      Return mCASS8
    End Get
    Set(ByVal value As Long)
      mCASS8 = value
    End Set
  End Property

  Dim mCASS9 As Long
  Public Property _CASS9 As Long
    Get
      Return mCASS9
    End Get
    Set(ByVal value As Long)
      mCASS9 = value
    End Set
  End Property

  Dim mCASS10 As Long
  Public Property _CASS10 As Long
    Get
      Return mCASS10
    End Get
    Set(ByVal value As Long)
      mCASS10 = value
    End Set
  End Property

  Dim mUNIT1 As Integer
  Public Property _UNIT1 As Integer
    Get
      Return mUNIT1
    End Get
    Set(ByVal value As Integer)
      mUNIT1 = value
    End Set
  End Property

  Dim mUNIT2 As Integer
  Public Property _UNIT2 As Integer
    Get
      Return mUNIT2
    End Get
    Set(ByVal value As Integer)
      mUNIT2 = value
    End Set
  End Property

  Dim mUNIT3 As Integer
  Public Property _UNIT3 As Integer
    Get
      Return mUNIT3
    End Get
    Set(ByVal value As Integer)
      mUNIT3 = value
    End Set
  End Property

  Dim mUNIT4 As Integer
  Public Property _UNIT4 As Integer
    Get
      Return mUNIT4
    End Get
    Set(ByVal value As Integer)
      mUNIT4 = value
    End Set
  End Property

  Dim mUNIT5 As Integer
  Public Property _UNIT5 As Integer
    Get
      Return mUNIT5
    End Get
    Set(ByVal value As Integer)
      mUNIT5 = value
    End Set
  End Property

  Dim mUNIT6 As Integer
  Public Property _UNIT6 As Integer
    Get
      Return mUNIT6
    End Get
    Set(ByVal value As Integer)
      mUNIT6 = value
    End Set
  End Property

  Dim mUNIT7 As Integer
  Public Property _UNIT7 As Integer
    Get
      Return mUNIT7
    End Get
    Set(ByVal value As Integer)
      mUNIT7 = value
    End Set
  End Property

  Dim mUNIT8 As Integer
  Public Property _UNIT8 As Integer
    Get
      Return mUNIT8
    End Get
    Set(ByVal value As Integer)
      mUNIT8 = value
    End Set
  End Property

  Dim mUNIT9 As Integer
  Public Property _UNIT9 As Integer
    Get
      Return mUNIT9
    End Get
    Set(ByVal value As Integer)
      mUNIT9 = value
    End Set
  End Property

  Dim mUNITA As Integer
  Public Property _UNITA As Integer
    Get
      Return mUNITA
    End Get
    Set(ByVal value As Integer)
      mUNITA = value
    End Set
  End Property

  Dim mEXCD1 As String
  Public Property _EXCD1 As String
    Get
      Return mEXCD1
    End Get
    Set(ByVal value As String)
      mEXCD1 = value
    End Set
  End Property

  Dim mEXCD2 As String
  Public Property _EXCD2 As String
    Get
      Return mEXCD2
    End Get
    Set(ByVal value As String)
      mEXCD2 = value
    End Set
  End Property

  Dim mEXCD3 As String
  Public Property _EXCD3 As String
    Get
      Return mEXCD3
    End Get
    Set(ByVal value As String)
      mEXCD3 = value
    End Set
  End Property

  Dim mEXCD4 As String
  Public Property _EXCD4 As String
    Get
      Return mEXCD4
    End Get
    Set(ByVal value As String)
      mEXCD4 = value
    End Set
  End Property

  Dim mEXCD5 As String
  Public Property _EXCD5 As String
    Get
      Return mEXCD5
    End Get
    Set(ByVal value As String)
      mEXCD5 = value
    End Set
  End Property

  Dim mEXCD6 As String
  Public Property _EXCD6 As String
    Get
      Return mEXCD6
    End Get
    Set(ByVal value As String)
      mEXCD6 = value
    End Set
  End Property

  Dim mEXCD7 As String
  Public Property _EXCD7 As String
    Get
      Return mEXCD7
    End Get
    Set(ByVal value As String)
      mEXCD7 = value
    End Set
  End Property

  Dim mEXAM1 As Integer
  Public Property _EXAM1 As Integer
    Get
      Return mEXAM1
    End Get
    Set(ByVal value As Integer)
      mEXAM1 = value
    End Set
  End Property

  Dim mEXAM2 As Integer
  Public Property _EXAM2 As Integer
    Get
      Return mEXAM2
    End Get
    Set(ByVal value As Integer)
      mEXAM2 = value
    End Set
  End Property

  Dim mEXAM3 As Integer
  Public Property _EXAM3 As Integer
    Get
      Return mEXAM3
    End Get
    Set(ByVal value As Integer)
      mEXAM3 = value
    End Set
  End Property

  Dim mEXAM4 As Integer
  Public Property _EXAM4 As Integer
    Get
      Return mEXAM4
    End Get
    Set(ByVal value As Integer)
      mEXAM4 = value
    End Set
  End Property

  Dim mEXAM5 As Integer
  Public Property _EXAM5 As Integer
    Get
      Return mEXAM5
    End Get
    Set(ByVal value As Integer)
      mEXAM5 = value
    End Set
  End Property

  Dim mEXAM6 As Integer
  Public Property _EXAM6 As Integer
    Get
      Return mEXAM6
    End Get
    Set(ByVal value As Integer)
      mEXAM6 = value
    End Set
  End Property

  Dim mEXAM7 As Integer
  Public Property _EXAM7 As Integer
    Get
      Return mEXAM7
    End Get
    Set(ByVal value As Integer)
      mEXAM7 = value
    End Set
  End Property

  Dim mCCCD1 As String
  Public Property _CCCD1 As String
    Get
      Return mCCCD1
    End Get
    Set(ByVal value As String)
      mCCCD1 = value
    End Set
  End Property

  Dim mCCCD2 As String
  Public Property _CCCD2 As String
    Get
      Return mCCCD2
    End Get
    Set(ByVal value As String)
      mCCCD2 = value
    End Set
  End Property

  Dim mCCCD3 As String
  Public Property _CCCD3 As String
    Get
      Return mCCCD3
    End Get
    Set(ByVal value As String)
      mCCCD3 = value
    End Set
  End Property

  Dim mCCCD4 As String
  Public Property _CCCD4 As String
    Get
      Return mCCCD4
    End Get
    Set(ByVal value As String)
      mCCCD4 = value
    End Set
  End Property

  Dim mCCCD5 As String
  Public Property _CCCD5 As String
    Get
      Return mCCCD5
    End Get
    Set(ByVal value As String)
      mCCCD5 = value
    End Set
  End Property

  Dim mCCCD6 As String
  Public Property _CCCD6 As String
    Get
      Return mCCCD6
    End Get
    Set(ByVal value As String)
      mCCCD6 = value
    End Set
  End Property

  Dim mCCCD7 As String
  Public Property _CCCD7 As String
    Get
      Return mCCCD7
    End Get
    Set(ByVal value As String)
      mCCCD7 = value
    End Set
  End Property

  Dim mCEXA1 As Integer
  Public Property _CEXA1 As Integer
    Get
      Return mCEXA1
    End Get
    Set(ByVal value As Integer)
      mCEXA1 = value
    End Set
  End Property

  Dim mCEXA2 As Integer
  Public Property _CEXA2 As Integer
    Get
      Return mCEXA2
    End Get
    Set(ByVal value As Integer)
      mCEXA2 = value
    End Set
  End Property

  Dim mCEXA3 As Integer
  Public Property _CEXA3 As Integer
    Get
      Return mCEXA3
    End Get
    Set(ByVal value As Integer)
      mCEXA3 = value
    End Set
  End Property

  Dim mCEXA4 As Integer
  Public Property _CEXA4 As Integer
    Get
      Return mCEXA4
    End Get
    Set(ByVal value As Integer)
      mCEXA4 = value
    End Set
  End Property

  Dim mCEXA5 As Integer
  Public Property _CEXA5 As Integer
    Get
      Return mCEXA5
    End Get
    Set(ByVal value As Integer)
      mCEXA5 = value
    End Set
  End Property

  Dim mCEXA6 As Integer
  Public Property _CEXA6 As Integer
    Get
      Return mCEXA6
    End Get
    Set(ByVal value As Integer)
      mCEXA6 = value
    End Set
  End Property
  Dim mCEXA7 As Integer
  Public Property _CEXA7 As Integer
    Get
      Return mCEXA7
    End Get
    Set(ByVal value As Integer)
      mCEXA7 = value
    End Set
  End Property

  Dim mCPERC As Decimal
  Public Property _CPERC As Decimal
    Get
      Return mCPERC
    End Get
    Set(ByVal value As Decimal)
      mCPERC = value
    End Set
  End Property

  Dim mCMAX As Integer
  Public Property _CMAX As Integer
    Get
      Return mCMAX
    End Get
    Set(ByVal value As Integer)
      mCMAX = value
    End Set
  End Property

  Dim mCMIN As Integer
  Public Property _CMIN As Integer
    Get
      Return mCMIN
    End Get
    Set(ByVal value As Integer)
      mCMIN = value
    End Set
  End Property

  Dim mCIRAD As Decimal
  Public Property _CIRAD As Decimal
    Get
      Return mCIRAD
    End Get
    Set(ByVal value As Decimal)
      mCIRAD = value
    End Set
  End Property

  Dim mFTAX As Decimal
  Public Property _FTAX As Decimal
    Get
      Return mFTAX
    End Get
    Set(ByVal value As Decimal)
      mFTAX = value
    End Set
  End Property

  Dim mFASS As Decimal
  Public Property _FASS As Decimal
    Get
      Return mFASS
    End Get
    Set(ByVal value As Decimal)
      mFASS = value
    End Set
  End Property

  Dim mTWNBN As Decimal
  Public Property _TWNBN As Decimal
    Get
      Return mTWNBN
    End Get
    Set(ByVal value As Decimal)
      mTWNBN = value
    End Set
  End Property

  Dim mASS As String
  Public Property _ASS As String
    Get
      Return mASS
    End Get
    Set(ByVal value As String)

      mASS = value
    End Set
  End Property

  Dim mCMVDC As String
  Public Property _CMVDC As String
    Get
      Return mCMVDC
    End Get
    Set(ByVal value As String)

      mCMVDC = value
    End Set
  End Property

  Dim mCCM As String
  Public Property _CCM As String
    Get
      Return mCCM
    End Get
    Set(ByVal value As String)

      mCCM = value
    End Set
  End Property

  Dim mRLST As Integer
  Public Property _RLST As Integer
    Get
      Return mRLST
    End Get
    Set(ByVal value As Integer)

      mRLST = value
    End Set
  End Property

  Dim mPDST As Integer
  Public Property _PDST As Integer
    Get
      Return mPDST
    End Get
    Set(ByVal value As Integer)
      mPDST = value
    End Set
  End Property

  Dim mICVIDno As String
  Public Property _ICVIDNo As String
    Get
      Return mICVIDno
    End Get
    Set(ByVal value As String)
      mICVIDno = value
    End Set
  End Property

  Dim mICVMOD As String
  Public Property _ICVMOD As String
    Get
      Return mICVMOD
    End Get
    Set(ByVal value As String)
      mICVMOD = value
    End Set
  End Property

  Dim mICVCLS As Integer
  Public Property _ICVCLS As Integer
    Get
      Return mICVCLS
    End Get
    Set(ByVal value As Integer)
      mICVCLS = value
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

  Dim mSSNO As Long
  Public Property _SSNo As Long
    Get
      Return mSSNO
    End Get
    Set(ByVal value As Long)
      mSSNO = value
    End Set
  End Property

  Dim mSS2 As Long
  Public Property _SS2 As Long
    Get
      Return mSS2
    End Get
    Set(ByVal value As Long)
      mSS2 = value
    End Set
  End Property

  Dim mTIN As String
  Public Property _TIN As String
    Get
      Return mTIN
    End Get
    Set(ByVal value As String)
      mTIN = value
    End Set
  End Property

  Dim mFEC1 As String
  Public Property _FEC1 As String
    Get
      Return mFEC1
    End Get
    Set(ByVal value As String)
      mFEC1 = value
    End Set
  End Property

  Dim mFEC2 As String
  Public Property _FEC2 As String
    Get
      Return mFEC2
    End Get
    Set(ByVal value As String)
      mFEC2 = value
    End Set
  End Property

  Dim mFEC3 As String
  Public Property _FEC3 As String
    Get
      Return mFEC3
    End Get
    Set(ByVal value As String)
      mFEC3 = value
    End Set
  End Property

  Dim mFEC4 As String
  Public Property _FEC4 As String
    Get
      Return mFEC4
    End Get
    Set(ByVal value As String)
      mFEC4 = value
    End Set
  End Property

  Dim mFEC5 As String
  Public Property _FEC5 As String
    Get
      Return mFEC5
    End Get
    Set(ByVal value As String)
      mFEC5 = value
    End Set
  End Property

  Dim mFED1 As Decimal
  Public Property _FED1 As Decimal
    Get
      Return mFED1
    End Get
    Set(ByVal value As Decimal)
      mFED1 = value
    End Set
  End Property

  Dim mFED2 As Decimal
  Public Property _FED2 As Decimal
    Get
      Return mFED2
    End Get
    Set(ByVal value As Decimal)
      mFED2 = value
    End Set
  End Property

  Dim mFED3 As Decimal
  Public Property _FED3 As Decimal
    Get
      Return mFED3
    End Get
    Set(ByVal value As Decimal)
      mFED3 = value
    End Set
  End Property

  Dim mFED4 As Decimal
  Public Property _FED4 As Decimal
    Get
      Return mFED4
    End Get
    Set(ByVal value As Decimal)
      mFED4 = value
    End Set
  End Property

  Dim mFED5 As Decimal
  Public Property _FED5 As Decimal
    Get
      Return mFED5
    End Get
    Set(ByVal value As Decimal)
      mFED5 = value
    End Set
  End Property

  Dim mABAT As Decimal
  Public Property _ABAT As Decimal
    Get
      Return mABAT
    End Get
    Set(ByVal value As Decimal)
      mABAT = value
    End Set
  End Property

  Dim mACD As String
  Public Property _ACD As String
    Get
      Return mACD
    End Get
    Set(ByVal value As String)
      mACD = value
    End Set
  End Property

  Dim mDECD As String
  Public Property _DECD As String
    Get
      Return mDECD
    End Get
    Set(ByVal value As String)
      mDECD = value
    End Set
  End Property

  Dim mINTY As String
  Public Property _INTY As String
    Get
      Return mINTY
    End Get
    Set(ByVal value As String)
      mINTY = value
    End Set
  End Property

  Dim mINPCT As Decimal
  Public Property _INPCT As Decimal
    Get
      Return mINPCT
    End Get
    Set(ByVal value As Decimal)
      mINPCT = value
    End Set
  End Property

  Dim mACCTN As String
  Public Property _ACCTN As String
    Get
      Return mACCTN
    End Get
    Set(ByVal value As String)
      mACCTN = value
    End Set
  End Property

  Dim mETC1 As String
  Public Property _ETC1 As String
    Get
      Return mETC1
    End Get
    Set(ByVal value As String)
      mETC1 = value
    End Set
  End Property

  Dim mETC2 As String
  Public Property _ETC2 As String
    Get
      Return mETC2
    End Get
    Set(ByVal value As String)
      mETC2 = value
    End Set
  End Property

  Dim mETC3 As String
  Public Property _ETC3 As String
    Get
      Return mETC3
    End Get
    Set(ByVal value As String)
      mETC3 = value
    End Set
  End Property

  Dim mETC4 As String
  Public Property _ETC4 As String
    Get
      Return mETC4
    End Get
    Set(ByVal value As String)
      mETC4 = value
    End Set
  End Property

  Dim mETC5 As String
  Public Property _ETC5 As String
    Get
      Return mETC5
    End Get
    Set(ByVal value As String)
      mETC5 = value
    End Set
  End Property

  Dim mETC6 As String
  Public Property _ETC6 As String
    Get
      Return mETC6
    End Get
    Set(ByVal value As String)
      mETC6 = value
    End Set
  End Property

  Dim mETC7 As String
  Public Property _ETC7 As String
    Get
      Return mETC7
    End Get
    Set(ByVal value As String)
      mETC7 = value
    End Set
  End Property

  Dim mETC8 As String
  Public Property _ETC8 As String
    Get
      Return mETC8
    End Get
    Set(ByVal value As String)
      mETC8 = value
    End Set
  End Property

  Dim mETC9 As String
  Public Property _ETC9 As String
    Get
      Return mETC9
    End Get
    Set(ByVal value As String)
      mETC9 = value
    End Set
  End Property

  Dim mETCA As String
  Public Property _ETCA As String
    Get
      Return mETCA
    End Get
    Set(ByVal value As String)
      mETCA = value
    End Set
  End Property

  Dim mXDATE As Integer
  Public Property _XDATE As Integer
    Get
      Return mXDATE
    End Get
    Set(ByVal value As Integer)
      mXDATE = value
    End Set
  End Property
#End Region
  Dim mDEFERT As Decimal
  Public Property _DEFERT As Decimal
    Get
      Return mDEFERT
    End Get
    Set(ByVal value As Decimal)
      mDEFERT = value
    End Set
  End Property
  Dim mDEFER1 As Decimal
  Public Property _DEFER1 As Decimal
    Get
      Return mDEFER1
    End Get
    Set(ByVal value As Decimal)
      mDEFER1 = value
    End Set
  End Property
  Dim mDEFER2 As Decimal
  Public Property _DEFER2 As Decimal
    Get
      Return mDEFER2
    End Get
    Set(ByVal value As Decimal)
      mDEFER2 = value
    End Set
  End Property
  Dim mDEFER3 As Decimal
  Public Property _DEFER3 As Decimal
    Get
      Return mDEFER3
    End Get
    Set(ByVal value As Decimal)
      mDEFER3 = value
    End Set
  End Property
  Dim mDEFER4 As Decimal
  Public Property _DEFER4 As Decimal
    Get
      Return mDEFER4
    End Get
    Set(ByVal value As Decimal)
      mDEFER4 = value
    End Set
  End Property
  Dim mCCINT30 As Decimal
  Public Property _CCINT30 As Decimal
    Get
      Return mCCINT30
    End Get
    Set(ByVal value As Decimal)
      mCCINT30 = value
    End Set
  End Property
End Class

