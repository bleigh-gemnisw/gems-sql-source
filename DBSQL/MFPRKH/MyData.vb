Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "MFPRKH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _MFCATG = String.Empty
    _MFNAM = String.Empty
    _MFADD1 = String.Empty
    _MFYEAR = 0
    _MFPERNo = 0
    _MFLISS = 0
    _MFTDAT = 0
    _MFTTIM = 0
    _MFLFEE = 0
    _MFCOMM = String.Empty
    _STAMPD = 0
    _STAMPT = 0
  End Sub
  Public Sub GetOneRecordP(ByVal WrkYear As Integer, ByVal WrkCat As String, ByVal WrkName As String,
   ByVal WrkAdd1 As String, ByVal WrkStampd As Integer, ByVal WrkStampt As Integer, ByVal WrkTdat As Integer,
   ByVal WrkTtim As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where mfyear=" & WrkYear & " and mfcatg='" & WrkCat _
     & "' and mfnam='" & WrkName & "' and mfadd1 ='" & WrkAdd1 & "' and stampd=" & WrkStampd & " and stampt=" & WrkStampt _
     & " and mftdat=" & WrkTdat & " and mfttim=" & WrkTtim
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
  Public Function GetViewbyPerson(ByVal WrkYear As Integer, ByVal WrkCat As String, ByVal WrkName As String,
   ByVal WrkAdd1 As String, ByVal WrkStampd As Integer, ByVal WrkStampt As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    RecordNotFound = False
    StrSQL = "Select mftdat,mfper#,mfliss,mflfee,mfcomm from " & cFileName & " where mfyear=" & WrkYear &
     " and mfcatg='" & WrkCat & "' and mfnam='" & WrkName & "' and mfadd1 ='" & WrkAdd1 &
     "' and stampd=" & WrkStampd & " and stampt=" & WrkStampt & " order by mftdat desc, mfttim desc"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

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

  Public Function ReplaceDS(ByVal ds As DataSet) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("wkdate", Type.GetType("System.Int32"))
      .Columns.Add("mftdat", Type.GetType("System.Int32"))
      .Columns.Add("mfper#", Type.GetType("System.Int32"))
      .Columns.Add("mfliss", Type.GetType("System.Int32"))
      .Columns.Add("mflfee", Type.GetType("System.Decimal"))
      .Columns.Add("mfcomm", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("wkdate") = GetDBDateInt(.Item("mftdat"))
        dr.Item("mftdat") = .Item("mftdat")
        dr.Item("mfper#") = .Item("mfper#")
        dr.Item("mfliss") = .Item("mfliss")
        dr.Item("mflfee") = .Item("mflfee")
        dr.Item("mfcomm") = .Item("mfcomm")
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

#Region "Properties: Get/Put"
Public Sub GetFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      _MFCATG = .Item("MFCATG")
      _MFNAM = .Item("MFNAM")
      _MFADD1 = .Item("MFADD1")
      _MFYEAR = .Item("MFYEAR")
      _MFPERNo = .Item("MFPER#")
      _MFLISS = .Item("MFLISS")
      _MFTDAT = .Item("MFTDAT")
      _MFTTIM = .Item("MFTTIM")
      _MFLFEE = .Item("MFLFEE")
      _MFCOMM = .Item("MFCOMM")
      _STAMPD = .Item("STAMPD")
      _STAMPT = .Item("STAMPT")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("MFCATG") = _MFCATG
      .Item("MFNAM") = _MFNAM
      .Item("MFADD1") = _MFADD1
      .Item("MFYEAR") = _MFYEAR
      .Item("MFPER#") = _MFPERNo
      .Item("MFLISS") = _MFLISS
      .Item("MFTDAT") = _MFTDAT
      .Item("MFTTIM") = _MFTTIM
      .Item("MFLFEE") = _MFLFEE
      .Item("MFCOMM") = _MFCOMM
      .Item("STAMPD") = _STAMPD
      .Item("STAMPT") = _STAMPT
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
  Dim mMFCATG As String
  Public Property _MFCATG As String
    Get
      Return mMFCATG
    End Get
    Set(ByVal value As String)
      mMFCATG = value
    End Set
  End Property

  Dim mMFNAM As String
  Public Property _MFNAM As String
    Get
      Return mMFNAM
    End Get
    Set(ByVal value As String)
      mMFNAM = value
    End Set
  End Property

  Dim mMFADD1 As String
  Public Property _MFADD1 As String
    Get
      Return mMFADD1
    End Get
    Set(ByVal value As String)
      mMFADD1 = value
    End Set
  End Property

  Dim mMFYEAR As Integer
  Public Property _MFYEAR As Integer
    Get
      Return mMFYEAR
    End Get
    Set(ByVal value As Integer)
      mMFYEAR = value
    End Set
  End Property

  Dim mMFPERNo As Integer
  Public Property _MFPERNo As Integer
    Get
      Return mMFPERNo
    End Get
    Set(ByVal value As Integer)
      mMFPERNo = value
    End Set
  End Property

  Dim mMFLISS As Integer
  Public Property _MFLISS As Integer
    Get
      Return mMFLISS
    End Get
    Set(ByVal value As Integer)
      mMFLISS = value
    End Set
  End Property

  Dim mMFTDAT As Integer
  Public Property _MFTDAT As Integer
    Get
      Return mMFTDAT
    End Get
    Set(ByVal value As Integer)
      mMFTDAT = value
    End Set
  End Property

  Dim mMFTTIM As Integer
  Public Property _MFTTIM As Integer
    Get
      Return mMFTTIM
    End Get
    Set(ByVal value As Integer)
      mMFTTIM = value
    End Set
  End Property

  Dim mMFLFEE As Decimal
  Public Property _MFLFEE As Decimal
    Get
      Return mMFLFEE
    End Get
    Set(ByVal value As Decimal)
      mMFLFEE = value
    End Set
  End Property

  Dim mMFCOMM As String
  Public Property _MFCOMM As String
    Get
      Return mMFCOMM
    End Get
    Set(ByVal value As String)
      mMFCOMM = value
    End Set
  End Property

  Dim mSTAMPD As Integer
  Public Property _STAMPD As Integer
    Get
      Return mSTAMPD
    End Get
    Set(ByVal value As Integer)
      mSTAMPD = value
    End Set
  End Property

  Dim mSTAMPT As Integer
  Public Property _STAMPT As Integer
    Get
      Return mSTAMPT
    End Get
    Set(ByVal value As Integer)
      mSTAMPT = value
    End Set
  End Property
#End Region
End Class

