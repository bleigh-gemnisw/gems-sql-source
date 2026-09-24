Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "APEHST"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyVndnrL1(ByVal WrkVndnr As String, ByVal WrkInvd8 As Integer,
 ByVal WrkInvno As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr,ppdt8,invd8,chkpd,invno,amtnt,avoid from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and invd8 =" & WrkInvd8 & " and recno=0" _
    & " where vndnr='" & WrkVndnr & "' and right(invd8,4)=" & Right(WrkInvd8, 4) & " and invd8 <=" & WrkInvd8 & " and recno = 0" _
    & " or vndnr='" & WrkVndnr & "' and right(invd8,4)<" & Right(WrkInvd8, 4) & " and recno=0" _
    & " order by right(invd8,4) desc, invd8 desc, invno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewbyVndnrL2(ByVal WrkVndnr As String, ByVal WrkLstp8 As Integer,
 ByVal WrkInvno As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr,ppdt8,invd8,chkpd,invno,ponbr,amtnt,avoid from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and lstp8 =" & WrkLstp8 & " and invno>='" & WrkInvno & "' and recno=0 or " _
    & "vndnr='" & WrkVndnr & "' and lstp8 <" & WrkLstp8 & " and recno=0 order by lstp8 desc,invno,recno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewbyVndnrL3(ByVal WrkVndnr As String, ByVal WrkInvno As String,
 ByVal WrkInvd8 As Integer, ByVal WrkChkpd As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr,ppdt8,invd8,chkpd,invno,ponbr,amtnt,avoid from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and invno >='" & WrkInvno & "' and recno=0" _
    & " order by invno,right(invd8,4) desc, invd8 desc,chkpd,recno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewbyVndnrLB(ByVal WrkVndnr As String, ByVal WrkInvd8 As Integer,
 ByVal WrkInvno As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr,ppdt8,invd8,chkpd,invno,ponbr,amtnt,avoid from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and right(invd8,4)=" & Right(WrkInvd8, 4) & " and invd8 <=" & WrkInvd8 & " and recno = 0" _
    & " or vndnr='" & WrkVndnr & "' and right(invd8,4)<" & Right(WrkInvd8, 4) & " and recno=0" _
    & " order by right(invd8,4) desc, invd8 desc, invno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetVndnrInvL4(ByVal WrkVndnr As String, ByVal WrkInvno As String,
 ByVal WrkChkpd As Integer, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "vndnr,invno,chkpd,amtgr,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and invno ='" & WrkInvno _
    & "' and chkpd =" & WrkChkpd & " and recno>0 order by invno,chkpd,invd8,recno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetVndnrFTDYTD(ByVal WrkVndnr As String, ByVal IsPayments As Boolean,
 ByVal IsYTD As Boolean) As Decimal
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkFromDt As Integer
    Dim WrkAmount As Decimal
    Dim WrkField As String

    RecordNotFound = False
    If IsPayments Then
      WrkField = "amtpd"
    Else
      WrkField = "amtnt"
    End If
    If IsYTD Then
      WrkFromDt = Date.Now.Year & "0101"
    Else
      If Date.Now.Month >= 7 Then
        WrkFromDt = Date.Now.Year & "0701"
      Else
        WrkFromDt = Date.Now.Year - 1 & "0701"
      End If
    End If
    StrSQL = "Select COALESCE(SUM(" & WrkField & "),0) from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and ppdt8 >=" & WrkFromDt _
    & " and recno=0 and avoid<>'V'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      WrkAmount = ds.Tables(0).Rows(0).Item(0)
      objCommand = Nothing
      ds = Nothing
      Conn.Close()
      Return WrkAmount
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetVndnrChkInv(ByVal WrkVndnr As String, ByVal WrkChkNo As Integer,
 ByVal WrkChkDt As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    StrSQL = "Select invno,amtgr,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and chkpd =" & WrkChkNo _
    & " and ppdt8 =" & WrkChkDt & " and recno>0 order by invno,recno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      objCommand = Nothing
      Conn.Close()
      Return ds
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetVndnrChk(ByVal WrkVndnr As String, ByVal WrkChkNo As Integer,
 ByVal WrkChkDt As Integer) As Decimal
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkAmount As Decimal

    RecordNotFound = False
    StrSQL = "Select sum(amtpd) As wrksum from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and ppdt8 =" & WrkChkDt & " and chkpd=" & WrkChkNo _
    & " and recno=0"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      WrkAmount = ds.Tables(0).Rows(0).Item(0)
      objCommand = Nothing
      ds = Nothing
      Conn.Close()
      Return WrkAmount
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetLedgerDescr(ByVal WrkInvno As String, ByVal WrkChkNo As Integer) As String
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkDescr As String

    RecordNotFound = False
    StrSQL = "Select top 1 amtgr,dsctx from " & cFileName _
    & " where invno='" & WrkInvno & "' and chkpd =" & WrkChkNo & " and recno=0"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      WrkDescr = Trim(ds.Tables(0).Rows(0).Item("dsctx"))
      objCommand = Nothing
      Conn.Close()
      Return WrkDescr
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetLedgerVend(ByVal WrkInvno As String, ByVal WrkChkNo As Integer) As String
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkVennm As String

    RecordNotFound = False
    StrSQL = "Select top 1 amtgr,vennm from " & cFileName _
    & " where invno='" & WrkInvno & "' and chkpd =" & WrkChkNo & " and recno=0"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      WrkVennm = Trim(ds.Tables(0).Rows(0).Item("vennm"))
      objCommand = Nothing
      Conn.Close()
      Return WrkVennm
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function GetViewbyPO(ByVal WrkFscyr As Integer, ByVal WrkPoNbr As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select vndnr,ppdt8,invd8,chkpd,invno,ponbr,amtnt,avoid from " & cFileName _
    & " where fscyr=" & WrkFscyr & " and ponbr=" & WrkPoNbr & " order by ppdt8"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function IsCheckUsed(ByVal WrkBankCd As String, WrkChkNo As Integer, ByVal WrkChkDt As Integer) As Boolean
    'Check for same check number used within last 3 years
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkChkDt3Yrs As Integer
    Dim WrkFound As Boolean

    RecordNotFound = False
    WrkFound = False
    WrkChkDt3Yrs = WrkChkDt - 30000 '3 Years ago
    StrSQL = "Select vndnr,chkpd,ppdt8 from " & cFileName _
    & " where ppdt8 >=" & WrkChkDt3Yrs & "and bnkcd='" & WrkBankCd & "' and chkpd=" & WrkChkNo _
    & " and recno=0"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count > 0 Then
        WrkFound = True
      End If
      objCommand = Nothing
      ds = Nothing
      Conn.Close()
      Return WrkFound
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function IsInvnoPaid(ByVal WrkVndnr As String, WrkInvno As String) As Boolean
    'Check for same check number used within last 3 years
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkFound As Boolean

    RecordNotFound = False
    WrkFound = False
    StrSQL = "Select vndnr,invno,ppdt8 from " & cFileName _
    & " where vndnr='" & WrkVndnr & "' and invno='" & WrkInvno & "'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count > 0 Then
        WrkFound = True
      End If
      objCommand = Nothing
      ds = Nothing
      Conn.Close()
      Return WrkFound
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("vndnr", Type.GetType("System.String"))
      .Columns.Add("chkdate", Type.GetType("System.Int32"))
      .Columns.Add("invd8", Type.GetType("System.Int32"))
      .Columns.Add("chkpd", Type.GetType("System.Int32"))
      .Columns.Add("invno", Type.GetType("System.String"))
      .Columns.Add("ponbr", Type.GetType("System.Int32"))
      .Columns.Add("amtnt", Type.GetType("System.Decimal"))
      .Columns.Add("avoid", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item(0) = .Item(0)
        dr.Item(1) = GetDBDateInt(.Item(1))
        dr.Item(2) = .Item(2)
        dr.Item(3) = .Item(3)
        dr.Item(4) = .Item(4)
        dr.Item(5) = .Item(5)
        dr.Item(6) = .Item(6)
        dr.Item(7) = .Item(7)
        ds2.Tables(0).Rows.Add(dr)
      End With
    Next

    Return ds2
  End Function
  Public Function GetDBDateInt(ByVal DateIn As Integer) As Integer
    Dim WrkDate As Integer
    Dim StrDate As String

    If DateIn > 0 Then
      StrDate = Trim$(Str(DateIn))
      Try
        WrkDate = Right$(StrDate, 4) & Left$(StrDate, 4)
      Catch
      End Try
    End If
    Return WrkDate
  End Function
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
  End Sub
#End Region

#Region "Properties: Get/Put"
  Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _BCHNO = .Item("BCHNO")
      _RECNO = .Item("RECNO")
      _INVNO = .Item("INVNO")
      _AMTGR = .Item("AMTGR")
      _AMTDS = .Item("AMTDS")
      _AMTSH = .Item("AMTSH")
      _AMTNT = .Item("AMTNT")
      _DSCTX = .Item("DSCTX")
      _VNDNR = .Item("VNDNR")
      _PONBR = .Item("PONBR")
      _F1099 = .Item("F1099")
      _LEOPN = .Item("LEOPN")
      _FDNBR = .Item("FDNBR")
      _SFUND = .Item("SFUND")
      _DPNBR = .Item("DPNBR")
      _OBNBR = .Item("OBNBR")
      _FNPGM = .Item("FNPGM")
      _SUBFN = .Item("SUBFN")
      _VENNM = .Item("VENNM")
      _BNKCD = .Item("BNKCD")
      _CSHYN = .Item("CSHYN")
      _FSCYR = .Item("FSCYR")
      _FA = .Item("FA")
      _INVD8 = .Item("INVD8")
      _DUED8 = .Item("DUED8")
      _PPDT8 = .Item("PPDT8")
      _PRJ = .Item("PRJ")
      _APPST = .Item("APPST")
      _LSTPD = .Item("LSTPD")
      _AMTPD = .Item("AMTPD")
      _CHKPD = .Item("CHKPD")
      _MANUL = .Item("MANUL")
      _AVOID = .Item("AVOID")
      _VNCAT = .Item("VNCAT")
      _OTIME = .Item("OTIME")
      _LSTP8 = .Item("LSTP8")
      _VSORT = .Item("VSORT")
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
  Dim mVNDNR As String
  Public Property _VNDNR As String
    Get
      Return mVNDNR
    End Get
    Set(ByVal value As String)
      mVNDNR = value
    End Set
  End Property
  Dim mINVNO As String
  Public Property _INVNO As String
    Get
      Return mINVNO
    End Get
    Set(ByVal value As String)
      mINVNO = value
    End Set
  End Property
  Dim mRECNO As Integer
  Public Property _RECNO As Integer
    Get
      Return mRECNO
    End Get
    Set(ByVal value As Integer)
      mRECNO = value
    End Set
  End Property
  Dim mAMTGR As Decimal
  Public Property _AMTGR As Decimal
    Get
      Return mAMTGR
    End Get
    Set(ByVal value As Decimal)
      mAMTGR = value
    End Set
  End Property
  Dim mAMTDS As Decimal
  Public Property _AMTDS As Decimal
    Get
      Return mAMTDS
    End Get
    Set(ByVal value As Decimal)
      mAMTDS = value
    End Set
  End Property
  Dim mAMTSH As Decimal
  Public Property _AMTSH As Decimal
    Get
      Return mAMTSH
    End Get
    Set(ByVal value As Decimal)
      mAMTSH = value
    End Set
  End Property

  Dim mAMTNT As Decimal
  Public Property _AMTNT As Decimal
    Get
      Return mAMTNT
    End Get
    Set(ByVal value As Decimal)
      mAMTNT = value
    End Set
  End Property
  Dim mDSCTX As String
  Public Property _DSCTX As String
    Get
      Return mDSCTX
    End Get
    Set(ByVal value As String)
      mDSCTX = value
    End Set
  End Property
  Dim mPONBR As Integer
  Public Property _PONBR As Integer
    Get
      Return mPONBR
    End Get
    Set(ByVal value As Integer)
      mPONBR = value
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
  Dim mLEOPN As String
  Public Property _LEOPN As String
    Get
      Return mLEOPN
    End Get
    Set(ByVal value As String)
      mLEOPN = value
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
  Dim mVENNM As String
  Public Property _VENNM As String
    Get
      Return mVENNM
    End Get
    Set(ByVal value As String)
      mVENNM = value
    End Set
  End Property
  Dim mBCHNO As Integer
  Public Property _BCHNO As Integer
    Get
      Return mBCHNO
    End Get
    Set(ByVal value As Integer)
      mBCHNO = value
    End Set
  End Property
  Dim mLSTPD As Integer
  Public Property _LSTPD As Integer
    Get
      Return mLSTPD
    End Get
    Set(ByVal value As Integer)
      mLSTPD = value
    End Set
  End Property
  Dim mAMTPD As Decimal
  Public Property _AMTPD As Decimal
    Get
      Return mAMTPD
    End Get
    Set(ByVal value As Decimal)
      mAMTPD = value
    End Set
  End Property
  Dim mCHKPD As Integer
  Public Property _CHKPD As Integer
    Get
      Return mCHKPD
    End Get
    Set(ByVal value As Integer)
      mCHKPD = value
    End Set
  End Property
  Dim mBNKCD As String
  Public Property _BNKCD As String
    Get
      Return mBNKCD
    End Get
    Set(ByVal value As String)
      mBNKCD = value
    End Set
  End Property
  Dim mCSHYN As String
  Public Property _CSHYN As String
    Get
      Return mCSHYN
    End Get
    Set(ByVal value As String)
      mCSHYN = value
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
  Dim mFSCYR As Integer
  Public Property _FSCYR As Integer
    Get
      Return mFSCYR
    End Get
    Set(ByVal value As Integer)
      mFSCYR = value
    End Set
  End Property
  Dim mAVOID As String
  Public Property _AVOID As String
    Get
      Return mAVOID
    End Get
    Set(ByVal value As String)
      mAVOID = value
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
  Dim mOTIME As String
  Public Property _OTIME As String
    Get
      Return mOTIME
    End Get
    Set(ByVal value As String)
      mOTIME = value
    End Set
  End Property
  Dim mFA As String
  Public Property _FA As String
    Get
      Return mFA
    End Get
    Set(ByVal value As String)
      mFA = value
    End Set
  End Property
  Dim mINVD8 As Integer
  Public Property _INVD8 As Integer
    Get
      Return mINVD8
    End Get
    Set(ByVal value As Integer)
      mINVD8 = value
    End Set
  End Property
  Dim mDUED8 As Integer
  Public Property _DUED8 As Integer
    Get
      Return mDUED8
    End Get
    Set(ByVal value As Integer)
      mDUED8 = value
    End Set
  End Property
  Dim mPPDT8 As Integer
  Public Property _PPDT8 As Integer
    Get
      Return mPPDT8
    End Get
    Set(ByVal value As Integer)
      mPPDT8 = value
    End Set
  End Property
  Dim mLSTP8 As Integer
  Public Property _LSTP8 As Integer
    Get
      Return mLSTP8
    End Get
    Set(ByVal value As Integer)
      mLSTP8 = value
    End Set
  End Property
  Dim mPRJ As Long
  Public Property _PRJ As Long
    Get
      Return mPRJ
    End Get
    Set(ByVal value As Long)
      mPRJ = value
    End Set
  End Property
  Dim mAPPST As Integer
  Public Property _APPST As Integer
    Get
      Return mAPPST
    End Get
    Set(ByVal value As Integer)
      mAPPST = value
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
#End Region
End Class

