Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
  Dim da As SqlDataAdapter
  Const cFileName As String = "BCHHDR"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Function GetViewbyAppID(ByVal WrkAppID As String, ByVal NumRecs As Integer) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim WrkTop As String
    WrkTop = String.Empty

    If NumRecs > 0 Then
      WrkTop = "TOP " & NumRecs & " "
    End If
    StrSQL = "Select " & WrkTop & "appid,bchno,stats,subst,orgus,lstus,lstdv,strdt," &
   "enddt,nbrrc,nbrer,headg,entpm,edtpm,pstpm,lsbch,psdt from " & cFileName _
    & " where appid='" & WrkAppID & "' and bchno>0 order by bchno"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(ds, cFileName)
      ds2 = ReplaceDS(ds, WrkAppID)
      ds = Nothing
      objCommand = Nothing
      Conn.Close()
      Return ds2
    Catch ex As Exception
      ErrMsg = ex.ToString()
      Return Nothing
    End Try
  End Function
  Public Function ReplaceDS(ByVal ds As DataSet, ByVal WrkAppID As String) As DataSet
    Dim ds2 As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim WrkNum As Integer
    Dim I As Integer
    With myTable
      .TableName = "mytable" 'ds.Tables(0).TableName
      .Columns.Add("appid", Type.GetType("System.String"))
      .Columns.Add("bchno", Type.GetType("System.Int16"))
      .Columns.Add("stats", Type.GetType("System.String"))
      .Columns.Add("subst", Type.GetType("System.String"))
      .Columns.Add("orgus", Type.GetType("System.String"))
      .Columns.Add("lstus", Type.GetType("System.String"))
      .Columns.Add("lstdv", Type.GetType("System.String"))
      .Columns.Add("strdt", Type.GetType("System.Int32"))
      .Columns.Add("enddt", Type.GetType("System.Int32"))
      .Columns.Add("nbrrc", Type.GetType("System.Int16"))
      .Columns.Add("nbrer", Type.GetType("System.Int16"))
      .Columns.Add("headg", Type.GetType("System.String"))
      .Columns.Add("entpm", Type.GetType("System.String"))
      .Columns.Add("edtpm", Type.GetType("System.String"))
      .Columns.Add("pstpm", Type.GetType("System.String"))
      .Columns.Add("lsbch", Type.GetType("System.Int16"))
      .Columns.Add("psdt", Type.GetType("System.Int32"))
      .Columns.Add("postdt", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable)

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        dr = ds2.Tables(0).NewRow
        dr.Item("appid") = .Item("appid")
        dr.Item("bchno") = .Item("bchno")
        dr.Item("stats") = .Item("stats")
        dr.Item("subst") = .Item("subst")
        dr.Item("orgus") = .Item("orgus")
        dr.Item("lstus") = .Item("lstus")
        dr.Item("lstdv") = .Item("lstdv")
        dr.Item("strdt") = .Item("strdt")
        dr.Item("enddt") = .Item("enddt")
        dr.Item("nbrrc") = .Item("nbrrc")
        dr.Item("nbrer") = .Item("nbrer")
        dr.Item("headg") = .Item("headg")
        dr.Item("entpm") = .Item("entpm")
        dr.Item("edtpm") = .Item("edtpm")
        dr.Item("pstpm") = .Item("pstpm")
        dr.Item("lsbch") = .Item("lsbch")
        dr.Item("psdt") = .Item("psdt")
        Select Case WrkAppID
          Case "PTC", "PTS"
            WrkNum = GetDBDateInt(.Item("psdt"))
            dr.Item("postdt") = Format(WrkNum, "##/##/####")
          Case Else
            dr.Item("postdt") = GetDBDateInt(.Item("psdt"))
        End Select
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
    End With
  End Sub
#End Region

#Region "Properties: Fields"
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

