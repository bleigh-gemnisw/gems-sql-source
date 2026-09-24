Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXBATCH"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"

  Public Function GetByList(ByVal Wrklistno As Integer, ByVal wrkyear As Integer, ByVal wrktype As String, ByVal NumRecs As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & " * FROM " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR =" & wrkyear & "AND TYPE = '" & wrktype & "' order by list#"
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
  Public Function GetViewbyList(ByVal wrklistno As Integer, ByVal wrkyear As Integer,
 ByVal wrktype As String, ByVal NumRecs As Integer) As DataSet


    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "jstat,list#,year,type,pamt,iamt,tcamt,lamt,adjcd,cpencd,jseqno,jbatch from " & cFileName _
    & " where list# = " & wrklistno & " and year =" & wrkyear & " and type = '" & wrktype & "' order by list#, year,type"

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
  Public Function GetViewByBatch(ByVal WrkBatchCd As String, ByVal WrkBchno As Integer, ByVal NumRecs As Integer) As DataSet

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    RecordNotFound = False
    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & " * FROM " & cFileName _
     & " where jbtchc='" & WrkBatchCd & "' and jbatch=" & WrkBchno & " order by jseqno"
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
  Public Function CalcListFee(ByVal Wrklistno As Integer, ByVal wrkyear As Integer, ByVal wrktype As String, ByVal WrkPencd As String) As Decimal

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim WrkTop As String
    Dim WrkFee As Decimal
    WrkTop = String.Empty

    RecordNotFound = False
    WrkFee = 0
    StrSQL = "Select sum(tcamt) as amount FROM " & cFileName _
    & " where list# =" & Wrklistno & " AND YEAR =" & wrkyear & "AND TYPE = '" & wrktype & "' and cpencd='" & WrkPencd & "'"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      If ds.Tables(0).Rows.Count > 0 Then
        WrkFee = ds.Tables(0).Rows(0).Item("amount")
      End If
      objCommand = Nothing
      Conn.Close()
      Return WrkFee
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return 0
    End Try
  End Function

  Public Sub OpenFile()
  End Sub
	Public Sub CloseFile()
	End Sub
#End Region

#Region "Properties: Get/Put"

#End Region

#Region "Properties: Fields"
  Dim mRecordNotFound As Boolean
Public Property RecordNotFound() As Boolean
  Set(ByVal value as Boolean)
    mRecordNotFound = value
  End Set
  Get
    Return mRecordNotFound
  End Get
End Property
Dim mIsEOF As Boolean
Public Property IsEOF() As Boolean
  Set(ByVal value as Boolean)
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
    Set(ByVal value as String)
        mErrMsg = value
    End Set
End Property
#End Region
End Class


