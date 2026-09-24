Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "TXINV"
  Const CTimeOut As Integer = 120
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _ICODE = String.Empty
    _LISTNo = 0
    _YEAR = 0
    _TYPE = String.Empty
    _NAME = String.Empty
    _SNAME = String.Empty
    _ADD1 = String.Empty
    _ADD2 = String.Empty
    _CITY = String.Empty
    _STATE = String.Empty
    _ZIP5 = 0
    _ZIP4 = 0
    _DIST = 0
    _PDST = 0
    _TAXT = 0
    _TAX1 = 0
    _TAX2 = 0
    _TX3RD = 0
    _TX4TH = 0
    _PAYREC = 0
    _NEWPAY = 0
    _BALD = 0
    _GROSS = 0
    _TOTEXP = 0
    _NETASS = 0
    _LOCNo = String.Empty
    _LOC = String.Empty
    _LIEN = String.Empty
    _SUSCD = String.Empty
    _SUSDT = 0
    _CCNO = 0
    _CCETAX = 0
    _CCTX1 = 0
    _CCTX2 = 0
    _CCTX3 = 0
    _CCTX4 = 0
    _CGRS = 0
    _CCEXP = 0
    _CDATE = 0
    _CCRSN = String.Empty
    _VOL = String.Empty
    _IPAGE = String.Empty
    _MAP = String.Empty
    _BKSR = String.Empty
    _BKCD = String.Empty
    _FRCD = String.Empty
    _FRYR = 0
    _PCD = String.Empty
    _PHASE = 0
    _IPPCD1 = 0
    _IPPCD2 = 0
    _IPPCD3 = 0
    _IPPCD4 = 0
    _IPPCD5 = 0
    _IPPCD6 = 0
    _IPPCD7 = 0
    _IPPCD8 = 0
    _IPPCD9 = 0
    _IPPCDA = 0
    _MAKE = String.Empty
    _MVYR = 0
    _MODEL = String.Empty
    _BODY = String.Empty
    _CLASS = 0
    _IMVIDNo = String.Empty
    _IMVREG = String.Empty
    _ILEASE = String.Empty
    _DOB = 0
    _ICVGRS = 0
    _ICVACD = String.Empty
    _ICVREG = String.Empty
    _ICVMKE = String.Empty
    _ICVYR = 0
    _ICVIDNo = String.Empty
    _ICVMOD = String.Empty
    _ICVCLS = 0
    _AGY = String.Empty
    _ADATE = 0
    _LETT = String.Empty
    _INTPD = 0
    _LNPD = 0
    _RPD = 0
    _TXIDT = 0
    _PRPRI = 0
    _PRINT = 0
    _PRLIN = 0
    _TXINT = 0
    _PDAT = 0
    _MVFLAG = String.Empty
    _CEODC = String.Empty
    _BOND = 0
    _BONDP = 0
    _BONT = 0
    _STCD1 = String.Empty
    _STCD2 = String.Empty
    _STCD3 = String.Empty
    _STCD4 = String.Empty
    _STCD5 = String.Empty
    _PINPD = String.Empty
    _OAS1 = 0
    _OAS2 = 0
    _OAS3 = 0
    _OAS4 = 0
    _OAS5 = 0
    _OAS6 = 0
    _OAS7 = 0
    _OAS8 = 0
    _OAS9 = 0
    _OAS10 = 0
    _CASS1 = 0
    _CASS2 = 0
    _CASS3 = 0
    _CASS4 = 0
    _CASS5 = 0
    _CASS6 = 0
    _CASS7 = 0
    _CASS8 = 0
    _CASS9 = 0
    _CASS10 = 0
    _UNIT1 = 0
    _UNIT2 = 0
    _UNIT3 = 0
    _UNIT4 = 0
    _UNIT5 = 0
    _UNIT6 = 0
    _UNIT7 = 0
    _UNIT8 = 0
    _UNIT9 = 0
    _UNITA = 0
    _EXCD1 = String.Empty
    _EXCD2 = String.Empty
    _EXCD3 = String.Empty
    _EXCD4 = String.Empty
    _EXCD5 = String.Empty
    _EXCD6 = String.Empty
    _EXCD7 = String.Empty
    _EXAM1 = 0
    _EXAM2 = 0
    _EXAM3 = 0
    _EXAM4 = 0
    _EXAM5 = 0
    _EXAM6 = 0
    _EXAM7 = 0
    _CCCD1 = String.Empty
    _CCCD2 = String.Empty
    _CCCD3 = String.Empty
    _CCCD4 = String.Empty
    _CCCD5 = String.Empty
    _CCCD6 = String.Empty
    _CCCD7 = String.Empty
    _CEXA1 = 0
    _CEXA2 = 0
    _CEXA3 = 0
    _CEXA4 = 0
    _CEXA5 = 0
    _CEXA6 = 0
    _CEXA7 = 0
    _CPERC = 0
    _CMAX = 0
    _CMIN = 0
    _CIRAD = 0
    _FTAX = 0
    _FASS = 0
    _TWNBN = 0
    _ASS = String.Empty
    _CMVDC = String.Empty
    _CCM = String.Empty
    _RLST = 0
    _OID = String.Empty
    _SSNo = 0
    _SS2 = 0
    _TIN = String.Empty
    _FEC1 = String.Empty
    _FEC2 = String.Empty
    _FEC3 = String.Empty
    _FEC4 = String.Empty
    _FEC5 = String.Empty
    _FED1 = 0
    _FED2 = 0
    _FED3 = 0
    _FED4 = 0
    _FED5 = 0
    _ABAT = 0
    _ACD = String.Empty
    _DECD = String.Empty
    _INTY = String.Empty
    _INPCT = 0
    _ACCTN = String.Empty
    _ETC1 = String.Empty
    _ETC2 = String.Empty
    _ETC3 = String.Empty
    _ETC4 = String.Empty
    _ETC5 = String.Empty
    _ETC6 = String.Empty
    _ETC7 = String.Empty
    _ETC8 = String.Empty
    _ETC9 = String.Empty
    _ETCA = String.Empty
    _XDATE = 0
    _PRF = String.Empty
    _CHDATE = 0
    _CHTIME = 0
    _DEFERT = 0
    _DEFER1 = 0
    _DEFER2 = 0
    _DEFER3 = 0
    _DEFER4 = 0
    _CCINT30 = 0
  End Sub
  Public Sub GetOneRecordP(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrktype As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " and year = " & Wrkyear & " and type = " & "'" & Wrktype & "'"
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
  '----------------  added 6/3/25   KB    optimize the txa04 loading routine
  ' Public Sub GetOneTXA04RecShared(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrktype As String)
  Public Sub GetOneTXA04Rec(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrktype As String, ByVal Conn As SqlConnection)

    ' Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As New DataSet

    RecordNotFound = False

    StrSQL = "Select NAME, DIST, FED1, FED2, FED3, FED4, FED5, FEC1, FEC2, FEC3, FEC4, FEC5 " &
             "from " & cFileName &
             " where list# = " & Wrklistno &
             " and year = " & Wrkyear &
             " and type = '" & Wrktype & "'"

    Try
      ' Use the shared connection object
      '  Conn = MyDBConn.Open()

      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)

      If ds.Tables(0).Rows.Count = 0 Then
        RecordNotFound = True
        ClearFields()
      Else
        GetFieldsTxa04(ds)
      End If

      objCommand = Nothing
      ds.Clear()
      ds = Nothing

      ' DO NOT close the connection — let the main process control the connection lifecycle

    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  '--------------------------------------------------------------------------
  Public Sub GetOneRecordVIN(ByVal WrkVin As String, ByVal Wrkyear As Integer, ByVal Wrktype As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where imvid# = '" & WrkVin & "' and year = " & Wrkyear & " and type = " & "'" & Wrktype & "'"
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
  Public Function PosData(ByVal Wrklistno As Integer, ByVal Wrkyear As Integer, ByVal Wrktype As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list# = " & Wrklistno & " And year = " & Wrkyear & " And type >= " & "'" & Wrktype & "'" & " Or list# = " & Wrklistno & " And year > " & Wrkyear & " Or list# > " & Wrklistno & " Order by list#, year, type"
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
  Public Function GetAllListNo(ByVal WrkListNo As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where list#=" & WrkListNo
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
  Public Function GetAllListNoType(ByVal WrkListNo As Integer, WrkType As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " WHERE list# =" & WrkListNo & " AND  type = '" & WrkType & "' Order By list#,year,type"
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
  Public Sub DeleteListNo(ByVal wrklistno As Integer, ByVal wrkyear As Integer, ByVal wrktype As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Delete from " & cFileName & " WHERE list# = " & wrklistno & " AND year = " & wrkyear & " AND type = '" & wrktype & "'"

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    Result = objCommand.ExecuteNonQuery()
    objCommand = Nothing
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
  Public Sub InsertOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Const ca As String = "'" 'Alpha 
    Const caa As String = "','" 'Alpha Before/Alpha After
    Const can As String = "'," 'Alpha Before/Numeric After
    Const cna As String = ",'" 'Numeric Before/Alpha After
    Const cnn As String = "," 'Numeric Before/Numeric After

    StrSQL = "Insert into " & cFileName & " values(" & ca &
    _ICODE & can & _LISTNo & cnn & _YEAR & cna & _TYPE & caa & _NAME & caa &
    _SNAME & caa & _ADD1 & caa & _ADD2 & caa & _CITY & caa & _STATE & can &
    _ZIP5 & cnn & _ZIP4 & cnn & _DIST & cnn & _PDST & cnn & _TAXT & cnn &
    _TAX1 & cnn & _TAX2 & cnn & _TX3RD & cnn & _TX4TH & cnn & _PAYREC & cnn &
    _NEWPAY & cnn & _BALD & cnn & _GROSS & cnn & _TOTEXP & cnn & _NETASS & cna &
    _LOCNo & caa & _LOC & caa & _LIEN & caa & _SUSCD & can & _SUSDT & cnn &
    _CCNO & cnn & _CCETAX & cnn & _CCTX1 & cnn & _CCTX2 & cnn & _CCTX3 & cnn &
    _CCTX4 & cnn & _CGRS & cnn & _CCEXP & cnn & _CDATE & cna & _CCRSN & caa &
    _VOL & caa & _IPAGE & caa & _MAP & caa & _BKSR & caa & _BKCD & caa &
    _FRCD & can & _FRYR & cna & _PCD & can & _PHASE & cnn & _IPPCD1 & cnn &
    _IPPCD2 & cnn & _IPPCD3 & cnn & _IPPCD4 & cnn & _IPPCD5 & cnn & _IPPCD6 & cnn &
    _IPPCD7 & cnn & _IPPCD8 & cnn & _IPPCD9 & cnn & _IPPCDA & cna & _MAKE & can &
    _MVYR & cna & _MODEL & caa & _BODY & can & _CLASS & cna & _IMVIDNo & caa &
    _IMVREG & caa & _ILEASE & can & _DOB & cnn & _ICVGRS & cna & _ICVACD & caa &
    _ICVREG & caa & _ICVMKE & can & _ICVYR & cna & _ICVIDNo & caa & _ICVMOD & can &
    _ICVCLS & cna & _AGY & can & _ADATE & cna & _LETT & can & _INTPD & cnn &
    _LNPD & cnn & _RPD & cnn & _TXIDT & cnn & _PRPRI & cnn & _PRINT & cnn &
    _PRLIN & cnn & _TXINT & cnn & _PDAT & cna & _MVFLAG & caa & _CEODC & can &
    _BOND & cnn & _BONDP & cnn & _BONT & cna & _STCD1 & caa & _STCD2 & caa &
    _STCD3 & caa & _STCD4 & caa & _STCD5 & caa & _PINPD & can & _OAS1 & cnn &
    _OAS2 & cnn & _OAS3 & cnn & _OAS4 & cnn & _OAS5 & cnn & _OAS6 & cnn &
    _OAS7 & cnn & _OAS8 & cnn & _OAS9 & cnn & _OAS10 & cnn & _CASS1 & cnn &
    _CASS2 & cnn & _CASS3 & cnn & _CASS4 & cnn & _CASS5 & cnn & _CASS6 & cnn &
    _CASS7 & cnn & _CASS8 & cnn & _CASS9 & cnn & _CASS10 & cnn & _UNIT1 & cnn &
    _UNIT2 & cnn & _UNIT3 & cnn & _UNIT4 & cnn & _UNIT5 & cnn & _UNIT6 & cnn &
    _UNIT7 & cnn & _UNIT8 & cnn & _UNIT9 & cnn & _UNITA & cna & _EXCD1 & caa &
    _EXCD2 & caa & _EXCD3 & caa & _EXCD4 & caa & _EXCD5 & caa & _EXCD6 & caa &
    _EXCD7 & can & _EXAM1 & cnn & _EXAM2 & cnn & _EXAM3 & cnn & _EXAM4 & cnn &
    _EXAM5 & cnn & _EXAM6 & cnn & _EXAM7 & cna & _CCCD1 & caa & _CCCD2 & caa &
    _CCCD3 & caa & _CCCD4 & caa & _CCCD5 & caa & _CCCD6 & caa & _CCCD7 & can &
    _CEXA1 & cnn & _CEXA2 & cnn & _CEXA3 & cnn & _CEXA4 & cnn & _CEXA5 & cnn &
    _CEXA6 & cnn & _CEXA7 & cnn & _CPERC & cnn & _CMAX & cnn & _CMIN & cnn &
    _CIRAD & cnn & _FTAX & cnn & _FASS & cnn & _TWNBN & cna & _ASS & caa &
    _CMVDC & caa & _CCM & can & _RLST & cna & _OID & can & _SSNo & cnn &
    _SS2 & cna & _TIN & caa & _FEC1 & caa & _FEC2 & caa & _FEC3 & caa &
    _FEC4 & caa & _FEC5 & can & _FED1 & cnn & _FED2 & cnn & _FED3 & cnn &
    _FED4 & cnn & _FED5 & cnn & _ABAT & cna & _ACD & caa & _DECD & caa &
    _INTY & can & _INPCT & cna & _ACCTN & caa & _ETC1 & caa & _ETC2 & caa &
    _ETC3 & caa & _ETC4 & caa & _ETC5 & caa & _ETC6 & caa & _ETC7 & caa &
    _ETC8 & caa & _ETC9 & caa & _ETCA & can & _XDATE & cna & _PRF & can &
    _CHDATE & cnn & _CHTIME & cnn & _DEFERT & cnn & _DEFER1 & cnn & _DEFER2 & cnn &
    _DEFER3 & cnn & _DEFER4 & cnn & _CCINT30 & ")"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
      'Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
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
  Public Sub UpdateCCInt30(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
    ByVal DueDate As Integer)
    Dim sql As String = "UPDATE " & cFileName & " SET ccint30 = @ccint30 
      WHERE [list#] = @listNo AND [year] = @year AND [type] = @type"

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand(sql, conn)
        cmd.CommandTimeout = CTimeOut
        cmd.Parameters.AddWithValue("@ccint30", DueDate)
        cmd.Parameters.AddWithValue("@listNo", ListNo)
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@type", Type)
        cmd.ExecuteNonQuery()
      End Using
    End Using
  End Sub
  Public Sub UpdateIcode(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
    ByVal Icode As String)
    Dim sql As String = "UPDATE " & cFileName & " SET icode = @icode 
      WHERE [list#] = @listNo AND [year] = @year AND [type] = @type"

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand(sql, conn)
        cmd.CommandTimeout = CTimeOut
        cmd.Parameters.AddWithValue("@icode", Icode)
        cmd.Parameters.AddWithValue("@listNo", ListNo)
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@type", Type)
        cmd.ExecuteNonQuery()
      End Using
    End Using
  End Sub
  Public Sub UpdateMVFlag(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
    ByVal MVFlag As String)
    Dim sql As String = "UPDATE " & cFileName & " SET mvflag = @mvflag 
      WHERE [list#] = @listNo AND [year] = @year AND [type] = @type"

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand(sql, conn)
        cmd.CommandTimeout = CTimeOut
        cmd.Parameters.AddWithValue("@mvflag", MVFlag)
        cmd.Parameters.AddWithValue("@listNo", ListNo)
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@type", Type)
        cmd.ExecuteNonQuery()
      End Using
    End Using
  End Sub
  Public Sub UpdateMVFlag_OID(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
    ByVal MVFlag As String, ByVal OID As String)
    Dim sql As String = "UPDATE " & cFileName & " SET mvflag = @mvflag, oid = @oid 
      WHERE [list#] = @listNo AND [year] = @year AND [type] = @type"

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand(sql, conn)
        cmd.CommandTimeout = CTimeOut
        cmd.Parameters.AddWithValue("@mvflag", MVFlag)
        cmd.Parameters.AddWithValue("@oid", OID)
        cmd.Parameters.AddWithValue("@listNo", ListNo)
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@type", Type)
        cmd.ExecuteNonQuery()
      End Using
    End Using
  End Sub
  Public Sub UpdateNewpayBont(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String,
    ByVal Newpay As Decimal, Bont As Decimal)
    Dim sql As String = "UPDATE " & cFileName & " SET newpay = @newpay, bont = @bont 
      WHERE [list#] = @listNo AND [year] = @year AND [type] = @type"

    Using conn As SqlConnection = MyDBConn.Open()
      Using cmd As New SqlCommand(sql, conn)
        cmd.CommandTimeout = CTimeOut
        cmd.Parameters.AddWithValue("@newpay", Newpay)
        cmd.Parameters.AddWithValue("@bont", Bont)
        cmd.Parameters.AddWithValue("@listNo", ListNo)
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@type", Type)
        cmd.ExecuteNonQuery()
      End Using
    End Using
  End Sub
  Public Sub RunUpdateQuery(ByVal Wrkset As String, ByVal wrkwhere As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim Result As Integer

    StrSQL = "Update " & cFileName & " " & Wrkset & " " & wrkwhere

    RecordNotFound = False
    IsEOF = False
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    objCommand.CommandTimeout = 120
    Result = objCommand.ExecuteNonQuery()
    Conn.Close()
    objCommand = Nothing
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
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
      _PDST = .Item("PDST")
      _TAXT = .Item("TAXT")
      _TAX1 = .Item("TAX1")
      _TAX2 = .Item("TAX2")
      _TX3RD = .Item("TX3RD")
      _TX4TH = .Item("TX4TH")
      _PAYREC = .Item("PAYREC")
      _NEWPAY = .Item("NEWPAY")
      _BALD = .Item("BALD")
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
      _CCTX3 = .Item("CCTX3")
      _CCTX4 = .Item("CCTX4")
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
      _DOB = .Item("DOB")
      _ICVGRS = .Item("ICVGRS")
      _ICVACD = .Item("ICVACD")
      _ICVREG = .Item("ICVREG")
      _ICVMKE = .Item("ICVMKE")
      _ICVYR = .Item("ICVYR")
      _ICVIDNo = .Item("ICVID#")
      _ICVMOD = .Item("ICVMOD")
      _ICVCLS = .Item("ICVCLS")
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
      _PINPD = .Item("PINPD")
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
      _PRF = .Item("PRF")
      _CHDATE = .Item("CHDATE")
      _CHTIME = .Item("CHTIME")
      _DEFERT = .Item("DEFERT")
      _DEFER1 = .Item("DEFER1")
      _DEFER2 = .Item("DEFER2")
      _DEFER3 = .Item("DEFER3")
      _DEFER4 = .Item("DEFER4")
      _CCINT30 = .Item("CCINT30")
    End With
  End Sub
  '------------------------- added a version for txa04
  Public Sub GetFieldsTxa04(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _NAME = .Item("NAME")
      _DIST = .Item("DIST")
      _FED1 = .Item("FED1")
      _FED2 = .Item("FED2")
      _FED3 = .Item("FED3")
      _FED4 = .Item("FED4")
      _FED5 = .Item("FED5")
      _FEC1 = .Item("FEC1")
      _FEC2 = .Item("FEC2")
      _FEC3 = .Item("FEC3")
      _FEC4 = .Item("FEC4")
      _FEC5 = .Item("FEC5")
    End With
  End Sub

  '-----------------------------------------
  Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("ICODE") = _ICODE
      .Item("LIST#") = _LISTNo
      .Item("YEAR") = _YEAR
      .Item("TYPE") = _TYPE
      .Item("NAME") = _NAME
      .Item("SNAME") = _SNAME
      .Item("ADD1") = _ADD1
      .Item("ADD2") = _ADD2
      .Item("CITY") = _CITY
      .Item("STATE") = _STATE
      .Item("ZIP5") = _ZIP5
      .Item("ZIP4") = _ZIP4
      .Item("DIST") = _DIST
      .Item("PDST") = _PDST
      .Item("TAXT") = _TAXT
      .Item("TAX1") = _TAX1
      .Item("TAX2") = _TAX2
      .Item("TX3RD") = _TX3RD
      .Item("TX4TH") = _TX4TH
      .Item("PAYREC") = _PAYREC
      .Item("NEWPAY") = _NEWPAY
      .Item("BALD") = _BALD
      .Item("GROSS") = _GROSS
      .Item("TOTEXP") = _TOTEXP
      .Item("NETASS") = _NETASS
      .Item("LOC#") = _LOCNo
      .Item("LOC") = _LOC
      .Item("LIEN") = _LIEN
      .Item("SUSCD") = _SUSCD
      .Item("SUSDT") = _SUSDT
      .Item("CCNO") = _CCNO
      .Item("CCETAX") = _CCETAX
      .Item("CCTX1") = _CCTX1
      .Item("CCTX2") = _CCTX2
      .Item("CCTX3") = _CCTX3
      .Item("CCTX4") = _CCTX4
      .Item("CGRS") = _CGRS
      .Item("CCEXP") = _CCEXP
      .Item("CDATE") = _CDATE
      .Item("CCRSN") = _CCRSN
      .Item("VOL") = _VOL
      .Item("IPAGE") = _IPAGE
      .Item("MAP") = _MAP
      .Item("BKSR") = _BKSR
      .Item("BKCD") = _BKCD
      .Item("FRCD") = _FRCD
      .Item("FRYR") = _FRYR
      .Item("PCD") = _PCD
      .Item("PHASE") = _PHASE
      .Item("IPPCD1") = _IPPCD1
      .Item("IPPCD2") = _IPPCD2
      .Item("IPPCD3") = _IPPCD3
      .Item("IPPCD4") = _IPPCD4
      .Item("IPPCD5") = _IPPCD5
      .Item("IPPCD6") = _IPPCD6
      .Item("IPPCD7") = _IPPCD7
      .Item("IPPCD8") = _IPPCD8
      .Item("IPPCD9") = _IPPCD9
      .Item("IPPCDA") = _IPPCDA
      .Item("MAKE") = _MAKE
      .Item("MVYR") = _MVYR
      .Item("MODEL") = _MODEL
      .Item("BODY") = _BODY
      .Item("CLASS") = _CLASS
      .Item("IMVID#") = _IMVIDNo
      .Item("IMVREG") = _IMVREG
      .Item("ILEASE") = _ILEASE
      .Item("DOB") = _DOB
      .Item("ICVGRS") = _ICVGRS
      .Item("ICVACD") = _ICVACD
      .Item("ICVREG") = _ICVREG
      .Item("ICVMKE") = _ICVMKE
      .Item("ICVYR") = _ICVYR
      .Item("ICVID#") = _ICVIDNo
      .Item("ICVMOD") = _ICVMOD
      .Item("ICVCLS") = _ICVCLS
      .Item("AGY") = _AGY
      .Item("ADATE") = _ADATE
      .Item("LETT") = _LETT
      .Item("INTPD") = _INTPD
      .Item("LNPD") = _LNPD
      .Item("RPD") = _RPD
      .Item("TXIDT") = _TXIDT
      .Item("PRPRI") = _PRPRI
      .Item("PRINT") = _PRINT
      .Item("PRLIN") = _PRLIN
      .Item("TXINT") = _TXINT
      .Item("PDAT") = _PDAT
      .Item("MVFLAG") = _MVFLAG
      .Item("CEODC") = _CEODC
      .Item("BOND") = _BOND
      .Item("BONDP") = _BONDP
      .Item("BONT") = _BONT
      .Item("STCD1") = _STCD1
      .Item("STCD2") = _STCD2
      .Item("STCD3") = _STCD3
      .Item("STCD4") = _STCD4
      .Item("STCD5") = _STCD5
      .Item("PINPD") = _PINPD
      .Item("OAS1") = _OAS1
      .Item("OAS2") = _OAS2
      .Item("OAS3") = _OAS3
      .Item("OAS4") = _OAS4
      .Item("OAS5") = _OAS5
      .Item("OAS6") = _OAS6
      .Item("OAS7") = _OAS7
      .Item("OAS8") = _OAS8
      .Item("OAS9") = _OAS9
      .Item("OAS10") = _OAS10
      .Item("CASS1") = _CASS1
      .Item("CASS2") = _CASS2
      .Item("CASS3") = _CASS3
      .Item("CASS4") = _CASS4
      .Item("CASS5") = _CASS5
      .Item("CASS6") = _CASS6
      .Item("CASS7") = _CASS7
      .Item("CASS8") = _CASS8
      .Item("CASS9") = _CASS9
      .Item("CASS10") = _CASS10
      .Item("UNIT1") = _UNIT1
      .Item("UNIT2") = _UNIT2
      .Item("UNIT3") = _UNIT3
      .Item("UNIT4") = _UNIT4
      .Item("UNIT5") = _UNIT5
      .Item("UNIT6") = _UNIT6
      .Item("UNIT7") = _UNIT7
      .Item("UNIT8") = _UNIT8
      .Item("UNIT9") = _UNIT9
      .Item("UNITA") = _UNITA
      .Item("EXCD1") = _EXCD1
      .Item("EXCD2") = _EXCD2
      .Item("EXCD3") = _EXCD3
      .Item("EXCD4") = _EXCD4
      .Item("EXCD5") = _EXCD5
      .Item("EXCD6") = _EXCD6
      .Item("EXCD7") = _EXCD7
      .Item("EXAM1") = _EXAM1
      .Item("EXAM2") = _EXAM2
      .Item("EXAM3") = _EXAM3
      .Item("EXAM4") = _EXAM4
      .Item("EXAM5") = _EXAM5
      .Item("EXAM6") = _EXAM6
      .Item("EXAM7") = _EXAM7
      .Item("CCCD1") = _CCCD1
      .Item("CCCD2") = _CCCD2
      .Item("CCCD3") = _CCCD3
      .Item("CCCD4") = _CCCD4
      .Item("CCCD5") = _CCCD5
      .Item("CCCD6") = _CCCD6
      .Item("CCCD7") = _CCCD7
      .Item("CEXA1") = _CEXA1
      .Item("CEXA2") = _CEXA2
      .Item("CEXA3") = _CEXA3
      .Item("CEXA4") = _CEXA4
      .Item("CEXA5") = _CEXA5
      .Item("CEXA6") = _CEXA6
      .Item("CEXA7") = _CEXA7
      .Item("CPERC") = _CPERC
      .Item("CMAX") = _CMAX
      .Item("CMIN") = _CMIN
      .Item("CIRAD") = _CIRAD
      .Item("FTAX") = _FTAX
      .Item("FASS") = _FASS
      .Item("TWNBN") = _TWNBN
      .Item("ASS") = _ASS
      .Item("CMVDC") = _CMVDC
      .Item("CCM") = _CCM
      .Item("RLST") = _RLST
      .Item("OID") = _OID
      .Item("SS#") = _SSNo
      .Item("SS2") = _SS2
      .Item("TIN") = _TIN
      .Item("FEC1") = _FEC1
      .Item("FEC2") = _FEC2
      .Item("FEC3") = _FEC3
      .Item("FEC4") = _FEC4
      .Item("FEC5") = _FEC5
      .Item("FED1") = _FED1
      .Item("FED2") = _FED2
      .Item("FED3") = _FED3
      .Item("FED4") = _FED4
      .Item("FED5") = _FED5
      .Item("ABAT") = _ABAT
      .Item("ACD") = _ACD
      .Item("DECD") = _DECD
      .Item("INTY") = _INTY
      .Item("INPCT") = _INPCT
      .Item("ACCTN") = _ACCTN
      .Item("ETC1") = _ETC1
      .Item("ETC2") = _ETC2
      .Item("ETC3") = _ETC3
      .Item("ETC4") = _ETC4
      .Item("ETC5") = _ETC5
      .Item("ETC6") = _ETC6
      .Item("ETC7") = _ETC7
      .Item("ETC8") = _ETC8
      .Item("ETC9") = _ETC9
      .Item("ETCA") = _ETCA
      .Item("XDATE") = _XDATE
      .Item("PRF") = _PRF
      .Item("CHDATE") = _CHDATE
      .Item("CHTIME") = _CHTIME
      .Item("DEFERT") = _DEFERT
      .Item("DEFER1") = _DEFER1
      .Item("DEFER2") = _DEFER2
      .Item("DEFER3") = _DEFER3
      .Item("DEFER4") = _DEFER4
      .Item("CCINT30") = _CCINT30
    End With
  End Sub
#End Region


#Region "Properties: Fields"

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

  Dim mPDST As Integer
  Public Property _PDST As Integer
    Get
      Return mPDST
    End Get
    Set(ByVal value As Integer)
      mPDST = value
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

  Dim mBALD As Decimal
  Public Property _BALD As Decimal
    Get
      Return mBALD
    End Get
    Set(ByVal value As Decimal)
      mBALD = value
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

  Dim mDOB As Integer
  Public Property _DOB As Integer
    Get
      Return mDOB
    End Get
    Set(ByVal value As Integer)
      mDOB = value
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

  Dim mICVIDNo As String
  Public Property _ICVIDNo As String
    Get
      Return mICVIDNo
    End Get
    Set(ByVal value As String)
      mICVIDNo = value
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

  Dim mPINPD As String
  Public Property _PINPD As String
    Get
      Return mPINPD
    End Get
    Set(ByVal value As String)
      mPINPD = value
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

  Dim mEXAM1 As Long
  Public Property _EXAM1 As Long
    Get
      Return mEXAM1
    End Get
    Set(ByVal value As Long)
      mEXAM1 = value
    End Set
  End Property

  Dim mEXAM2 As Long
  Public Property _EXAM2 As Long
    Get
      Return mEXAM2
    End Get
    Set(ByVal value As Long)
      mEXAM2 = value
    End Set
  End Property

  Dim mEXAM3 As Long
  Public Property _EXAM3 As Long
    Get
      Return mEXAM3
    End Get
    Set(ByVal value As Long)
      mEXAM3 = value
    End Set
  End Property

  Dim mEXAM4 As Long
  Public Property _EXAM4 As Long
    Get
      Return mEXAM4
    End Get
    Set(ByVal value As Long)
      mEXAM4 = value
    End Set
  End Property

  Dim mEXAM5 As Long
  Public Property _EXAM5 As Long
    Get
      Return mEXAM5
    End Get
    Set(ByVal value As Long)
      mEXAM5 = value
    End Set
  End Property

  Dim mEXAM6 As Long
  Public Property _EXAM6 As Long
    Get
      Return mEXAM6
    End Get
    Set(ByVal value As Long)
      mEXAM6 = value
    End Set
  End Property

  Dim mEXAM7 As Long
  Public Property _EXAM7 As Long
    Get
      Return mEXAM7
    End Get
    Set(ByVal value As Long)
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

  Dim mCEXA1 As Long
  Public Property _CEXA1 As Long
    Get
      Return mCEXA1
    End Get
    Set(ByVal value As Long)
      mCEXA1 = value
    End Set
  End Property

  Dim mCEXA2 As Long
  Public Property _CEXA2 As Long
    Get
      Return mCEXA2
    End Get
    Set(ByVal value As Long)
      mCEXA2 = value
    End Set
  End Property

  Dim mCEXA3 As Long
  Public Property _CEXA3 As Long
    Get
      Return mCEXA3
    End Get
    Set(ByVal value As Long)
      mCEXA3 = value
    End Set
  End Property

  Dim mCEXA4 As Long
  Public Property _CEXA4 As Long
    Get
      Return mCEXA4
    End Get
    Set(ByVal value As Long)
      mCEXA4 = value
    End Set
  End Property

  Dim mCEXA5 As Long
  Public Property _CEXA5 As Long
    Get
      Return mCEXA5
    End Get
    Set(ByVal value As Long)
      mCEXA5 = value
    End Set
  End Property

  Dim mCEXA6 As Long
  Public Property _CEXA6 As Long
    Get
      Return mCEXA6
    End Get
    Set(ByVal value As Long)
      mCEXA6 = value
    End Set
  End Property

  Dim mCEXA7 As Long
  Public Property _CEXA7 As Long
    Get
      Return mCEXA7
    End Get
    Set(ByVal value As Long)
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

  Dim mOID As String
  Public Property _OID As String
    Get
      Return mOID
    End Get
    Set(ByVal value As String)
      mOID = value
    End Set
  End Property

  Dim mSSNo As Long
  Public Property _SSNo As Long
    Get
      Return mSSNo
    End Get
    Set(ByVal value As Long)
      mSSNo = value
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


