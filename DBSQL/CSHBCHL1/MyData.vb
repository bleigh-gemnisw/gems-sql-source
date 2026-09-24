Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "CSHBCH"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Function GetBatchTot(ByVal WrkBchno As Integer) As Decimal
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkAmount As Decimal

  RecordNotFound = False
  StrSQL = "Select sum(amtcs) as sumamt from " & cFileName _
    & " where bchno=" & WrkBchno
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
Public Function GetViewbyBatch(ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet
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
  StrSQL = "Select " & WrkTop & "recno,fdnbr,sfund,dpnbr,obnbr,fnpgm,subfn,dsctx,amtcs,trndt from " & cFileName _
    & " where bchno=" & WrkBchno
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    ds2 = ReplaceDS(ds)
    objCommand = Nothing
    Conn.Close()
    ds = Nothing
    objCommand = Nothing
    Return ds2
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
End Function
Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim WrkAcct As String
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("recno", Type.GetType("System.Int32"))
      .Columns.Add("trndt", Type.GetType("System.Int32"))
      .Columns.Add("dsctx", Type.GetType("System.String"))
      .Columns.Add("acct", Type.GetType("System.String"))
      .Columns.Add("amtcs", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      dr = ds2.Tables(0).NewRow
      dr.Item("recno") = .Item("recno")
      dr.Item("trndt") = GetDBDateInt(.Item("trndt"))
      dr.Item("dsctx") = .Item("dsctx")
      WrkAcct = BuildAcct(.Item("fdnbr"), .Item("sfund"), .Item("dpnbr"), .Item("obnbr"), _
       .Item("fnpgm"), .Item("subfn"))
      dr.Item("acct") = WrkAcct
      dr.Item("amtcs") = .Item("amtcs")
      ds2.Tables(0).Rows.Add(dr)
    End With
  Next

    Return ds2
End Function
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 If Fund > 0 Then
  sb.Append(Format(Fund, "000"))
  sb.Append("-")
  sb.Append(Format(SFund, "000"))
  sb.Append("-")
  sb.Append(Format(Dept, "0000"))
  sb.Append("-")
  sb.Append(Format(Obj, "000"))
  sb.Append("-")
  sb.Append(Format(Func, "0000"))
  sb.Append("-")
  sb.Append(Format(SFunc, "0000"))
 Else
  sb.Append(String.Empty)
 End If
 Return sb.ToString
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
Public Function GetBatchCount(ByVal WrkBchno As Integer) As Integer
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim WrkCount As Integer

  RecordNotFound = False
  StrSQL = "Select count(recno) from " & cFileName & " where bchno=" & WrkBchno
  Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    WrkCount = ds.Tables(0).Rows(0).Item(0)
    objCommand = Nothing
    ds = Nothing
    Return WrkCount
  Catch ex As Exception
    ErrMsg = ex.ToString()
    Return Nothing
  End Try
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
    _TRNDT = .Item("TRNDT")
    _FDNBR = .Item("FDNBR")
    _SFUND = .Item("SFUND")
    _DPNBR = .Item("DPNBR")
    _OBNBR = .Item("OBNBR")
    _FNPGM = .Item("FNPGM")
    _SUBFN = .Item("SUBFN")
    _DSCTX = .Item("DSCTX")
    _AMTCS = .Item("AMTCS")
    _REFNO = .Item("REFNO")
    _FDNBD = .Item("FDNBD")
    _SFUDD = .Item("SFUDD")
    _DPNBD = .Item("DPNBD")
    _OBNBD = .Item("OBNBD")
    _FNPGD = .Item("FNPGD")
    _SUBFD = .Item("SUBFD")
    _ARPST = .Item("ARPST")
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
Dim mBCHNO As Integer
Public Property _BCHNO As Integer
    Get
        Return mBCHNO
    End Get
    Set(ByVal value As Integer)
        mBCHNO = value
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
Dim mTRNDT As Integer
Public Property _TRNDT As Integer
    Get
        Return mTRNDT
    End Get
    Set(ByVal value As Integer)
        mTRNDT = value
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
Dim mDSCTX As String
Public Property _DSCTX As String
    Get
        Return mDSCTX
    End Get
    Set(ByVal value As String)
        mDSCTX = value
    End Set
End Property
Dim mAMTCS As Decimal
Public Property _AMTCS As Decimal
    Get
        Return mAMTCS
    End Get
    Set(ByVal value As Decimal)
        mAMTCS = value
    End Set
End Property
Dim mREFNO As Integer
Public Property _REFNO As Integer
    Get
        Return mREFNO
    End Get
    Set(ByVal value As Integer)
        mREFNO = value
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
Dim mARPST As Integer
Public Property _ARPST As Integer
    Get
        Return mARPST
    End Get
    Set(ByVal value As Integer)
        mARPST = value
    End Set
End Property
#End Region

End Class

