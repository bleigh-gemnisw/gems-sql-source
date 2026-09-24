Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Dim objReader As SqlDataReader

  Const cFileName As String = "APEOPN"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub GetOneRecordP(ByVal WrkVndnr As String, ByVal WrkInvno As String, _
 ByVal WrkRecno As Integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
  StrSQL = "Select * from " & cFileName & " where vndnr='" & WrkVndnr & _
   "' and invno='" & WrkInvno & "' and recno = " & WrkRecno
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
  Public Sub DeleteVendorInvoice(WrkVndnr As String, WrkInvno As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand

  StrSQL = "Delete from " & cFileName & " where vndnr='" & WrkVndnr & _
   "' and invno='" & WrkInvno & "'"

  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  objReader = objCommand.ExecuteReader()
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
  Public Sub clrselectQry()
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand

  StrSQL = "UPDATE " & cFileName & " SET SLTPY = '',PAYPD = 0,payam = 0,payck = 0,paybn = 0 WHERE SLTPY = '1'"
  
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)
  objReader = objCommand.ExecuteReader()
End Sub
  Public Sub OpenFile()
  End Sub
	Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    _VNDNR = .Item("VNDNR")
    _INVNO = .Item("INVNO")
    _RECNO = .Item("RECNO")
    _AMTGR = .Item("AMTGR")
    _AMTDS = .Item("AMTDS")
    _AMTSH = .Item("AMTSH")
    _AMTNT = .Item("AMTNT")
    _DSCTX = .Item("DSCTX")
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
    _BCHNO = .Item("BCHNO")
    _AMTOP = .Item("AMTOP")
    _LSTPD = .Item("LSTPD")
    _AMTPD = .Item("AMTPD")
    _CHKPD = .Item("CHKPD")
    _BNKCD = .Item("BNKCD")
    _CSHYN = .Item("CSHYN")
    _SLTPY = .Item("SLTPY")
    _PAYPD = .Item("PAYPD")
    _PAYAM = .Item("PAYAM")
    _PAYCK = .Item("PAYCK")
    _PAYBN = .Item("PAYBN")
    _FSCYR = .Item("FSCYR")
    _HINV = .Item("HINV")
    _VNCAT = .Item("VNCAT")
    _VSORT = .Item("VSORT")
    _RPRF = .Item("RPRF")
    _OTIME = .Item("OTIME")
    _FA = .Item("FA")
    _INVD8 = .Item("INVD8")
    _DUED8 = .Item("DUED8")
    _PPDT8 = .Item("PPDT8")
    _LSTP8 = .Item("LSTP8")
    _PRJ = .Item("PRJ")
    _APPST = .Item("APPST")
  End With
End Sub
Public Sub PutFields(ByVal ds As DataSet)
	With ds.Tables(0).Rows(0)
    .Item("VNDNR") = _VNDNR
    .Item("INVNO") = _INVNO
    .Item("RECNO") = _RECNO
    .Item("AMTGR") = _AMTGR
    .Item("AMTDS") = _AMTDS
    .Item("AMTSH") = _AMTSH
    .Item("AMTNT") = _AMTNT
    .Item("DSCTX") = _DSCTX
    .Item("PONBR") = _PONBR
    .Item("F1099") = _F1099
    .Item("LEOPN") = _LEOPN
    .Item("FDNBR") = _FDNBR
    .Item("SFUND") = _SFUND
    .Item("DPNBR") = _DPNBR
    .Item("OBNBR") = _OBNBR
    .Item("FNPGM") = _FNPGM
    .Item("SUBFN") = _SUBFN
    .Item("VENNM") = _VENNM
    .Item("BCHNO") = _BCHNO
    .Item("AMTOP") = _AMTOP
    .Item("LSTPD") = _LSTPD
    .Item("AMTPD") = _AMTPD
    .Item("CHKPD") = _CHKPD
    .Item("BNKCD") = _BNKCD
    .Item("CSHYN") = _CSHYN
    .Item("SLTPY") = _SLTPY
    .Item("PAYPD") = _PAYPD
    .Item("PAYAM") = _PAYAM
    .Item("PAYCK") = _PAYCK
    .Item("PAYBN") = _PAYBN
    .Item("FSCYR") = _FSCYR
    .Item("HINV") = _HINV
    .Item("VNCAT") = _VNCAT
    .Item("VSORT") = _VSORT
    .Item("RPRF") = _RPRF
    .Item("OTIME") = _OTIME
    .Item("FA") = _FA
    .Item("INVD8") = _INVD8
    .Item("DUED8") = _DUED8
    .Item("PPDT8") = _PPDT8
    .Item("LSTP8") = _LSTP8
    .Item("PRJ") = _PRJ
    .Item("APPST") = _APPST
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
Dim mAMTOP As Decimal
Public Property _AMTOP As Decimal
    Get
        Return mAMTOP
    End Get
    Set(ByVal value As Decimal)
        mAMTOP = value
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
Dim mSLTPY As String
Public Property _SLTPY As String
    Get
        Return mSLTPY
    End Get
    Set(ByVal value As String)
        mSLTPY = value
    End Set
End Property
Dim mPAYPD As Integer
Public Property _PAYPD As Integer
    Get
        Return mPAYPD
    End Get
    Set(ByVal value As Integer)
        mPAYPD = value
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
Dim mPAYCK As Integer
Public Property _PAYCK As Integer
    Get
        Return mPAYCK
    End Get
    Set(ByVal value As Integer)
        mPAYCK = value
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
Dim mFSCYR As Integer
Public Property _FSCYR As Integer
    Get
        Return mFSCYR
    End Get
    Set(ByVal value As Integer)
        mFSCYR = value
    End Set
End Property
Dim mHINV As String
Public Property _HINV As String
    Get
        Return mHINV
    End Get
    Set(ByVal value As String)
        mHINV = value
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
Dim mRPRF As String
Public Property _RPRF As String
    Get
        Return mRPRF
    End Get
    Set(ByVal value As String)
        mRPRF = value
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

