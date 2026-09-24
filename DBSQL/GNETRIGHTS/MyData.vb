Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Public MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileNamePgm As String = "GNETPGM"
  Const cFileNameUser As String = "GNETUSER"
  Const cFileNameGroup As String = "GNETGROUP"
  Const cFileNameSec As String = "GNETSEC"
#Region "Constructors"

  Public Sub New()
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub Get_Rights(ByVal UserID As String, ByVal PgmID As String)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet
  Dim Group As String

  RecordNotFound = False
  ErrorMsg = ""
  StrSQL = "Select * from " & cFileNameUser & " where guser='" & Trim(UserID) & "'"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(ds, cFileNameUser)

  If ds.Tables(0).Rows.Count = 0 Then
    RecordNotFound = True
    ErrorMsg = "User not found"
    Group = UserID
  Else
    Group = ds.Tables(0).Rows(0).Item("ggroup")
  End If

  objCommand = Nothing
  ds.Clear()
  ds = Nothing
  Conn.Close()

  SetRights(Group, PgmID)
End Sub
Public Function Get_user_pgms(ByVal UserID As String) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim myTable As New DataTable
  Dim dr As DataRow
  Dim ds As DataSet = New DataSet
  Dim dsPgm As DataSet = New DataSet
  Dim dsUser As DataSet = New DataSet
  Dim dsGroup As DataSet = New DataSet
  Dim dsSec As DataSet = New DataSet
  Dim Group As String
  Dim myfull As String
  Dim WrkPgmID As String
  Dim Pos As Integer
  Dim I As Integer

  With myTable
    .TableName = "mytable"
    .Columns.Add("Code", Type.GetType("System.String"))
    .Columns.Add("Description", Type.GetType("System.String"))
    .Columns.Add("Pgmexe", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)

  StrSQL = "Select * from " & cFileNamePgm & " order by pgmid"
  Conn = MyDBConn.Open
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(dsPgm, cFileNameUser)

  objCommand = Nothing
  StrSQL = "Select * from " & cFileNameUser & " where guser='" & Trim(UserID) & "'"
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(dsUser, cFileNameUser)

  If dsUser.Tables(0).Rows.Count = 0 Then
    RecordNotFound = True
    ErrorMsg = "User not found"
    Group = UserID
  Else
    Group = dsUser.Tables(0).Rows(0).Item("ggroup")
  End If

  objCommand = Nothing
  StrSQL = "Select * from " & cFileNameGroup & " where ggroup='" & Trim(Group) & "'"
  objCommand = New SqlCommand(StrSQL, Conn)

  'Fill the dataset with the data
  da = New SqlDataAdapter
  da.SelectCommand = objCommand
  da.Fill(dsGroup, cFileNameUser)

  myfull = ""
  If dsGroup.Tables(0).Rows.Count > 0 Then
    myfull = dsGroup.Tables(0).Rows(0).Item("gright")
  End If

  For I = 0 To dsPgm.Tables(0).Rows.Count - 1
    s_sec = False
    WrkPgmID = dsPgm.Tables(0).Rows(I).Item("pgmid")
    'check to see if they have full rights from group..
    Pos = InStr(myfull, Mid(WrkPgmID, 1, 2))
    If Pos > 0 Then
      s_sec = True
    End If

    If Not s_sec Then
      'check option security 
      objCommand = Nothing
      StrSQL = "Select * from " & cFileNameSec & " where grpid='" & Trim(Group) & _
       "' and pgmid='" & Trim(WrkPgmID) & "'"
      objCommand = New SqlCommand(StrSQL, Conn)

      'Fill the dataset with the data
      da = New SqlDataAdapter
      da.SelectCommand = objCommand
      da.Fill(dsSec, cFileNameSec)
      If dsSec.Tables(0).Rows.Count > 0 Then
        If Trim(dsSec.Tables(0).Rows(0).Item("rights")) <> "" Then
          s_sec = True
        End If
      End If
    End If
    'Full rights to all apps or rights to program
    If myfull = "**" Or s_sec Then
      dr = ds.Tables(0).NewRow
      dr("Code") = WrkPgmID
      dr("Description") = dsPgm.Tables(0).Rows(I).Item("pgmdesc")
      dr("Pgmexe") = dsPgm.Tables(0).Rows(I).Item("pgmexe")
      ds.Tables(0).Rows.Add(dr)
    End If
  Next

  Return ds
End Function
  Private Sub SetRights(ByVal Group As String, ByVal PgmID As String)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim ds2 As DataSet = New DataSet
    Dim myrights As String
    Dim myfull As String
    Dim Pos As Integer

    RecordNotFound = False
    ErrorMsg = ""
    StrSQL = "Select * from " & cFileNameGroup & " where ggroup='" & Trim(Group) & "'"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileNameGroup)

    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
      ErrorMsg = "Group not found"
      myfull = ""
    Else
      myfull = Trim(ds.Tables(0).Rows(0).Item("gright"))
    End If
    objCommand = Nothing
    Conn.Close()

    'check to see if they have full rights to all apps (Admin group)
    s_group = Group
    s_rights = myfull
    If Trim(Group) = "Admin" And myfull = "**" Then
      s_full = True
      s_sec = True
      GoTo end_Set
    End If

    'check to see if they have full rights to all apps except IA
    If Mid(PgmID, 1, 2) <> "IA" And myfull = "**" Then
      s_rights = "++"
      s_full = True
      s_sec = True
      GoTo end_Set
    End If

    'check to see if they have full rights from group..
    Pos = InStr(myfull, Mid(PgmID, 1, 2))
    If Pos > 0 Then
      s_full = True
      s_sec = True
      GoTo end_Set
    End If

    'check option security 
    RecordNotFound = False
    ErrorMsg = ""
    StrSQL = "Select * from " & cFileNameSec & " where grpid='" & Trim(Group) &
   "' and pgmid='" & Trim(PgmID) & "'"
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds2, cFileNameSec)

    If ds2.Tables(0).Rows.Count = 0 Then
      myrights = ""
      '    s_rights = ""
      s_sec = False
    Else
      myrights = ds2.Tables(0).Rows(0).Item("rights")
      s_rights = myfull & ":" & ds2.Tables(0).Rows(0).Item("rights")
    End If

    objCommand = Nothing
    ds2.Clear()
    ds2 = Nothing
    Conn.Close()

    'set the rights
    Pos = InStr(myrights, "*", CompareMethod.Text)
    If Pos > 0 Then
      s_full = True
    End If
    Pos = InStr(myrights, "A", CompareMethod.Text)
    If Pos > 0 Then
      s_add = True
    End If
    Pos = InStr(myrights, "D", CompareMethod.Text)
    If Pos > 0 Then
      s_del = True
    End If
    Pos = InStr(myrights, "C", CompareMethod.Text)
    If Pos > 0 Then
      s_chg = True
    End If
    Pos = InStr(myrights, "I", CompareMethod.Text)
    If Pos > 0 Then
      s_inq = True
    End If
    Pos = InStr(myrights, "E", CompareMethod.Text)
    If Pos > 0 Then
      s_edit = True
    End If
    Pos = InStr(myrights, "P", CompareMethod.Text)
    If Pos > 0 Then
      s_post = True
    End If

    If s_add Or s_chg Or s_del Or s_edit Or s_full Or s_inq Or s_post Then
      s_sec = True
    End If
end_Set:
  End Sub
  Public Sub OpenFile()
  End Sub
  Public Sub CloseFile()
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
Dim mErrorMsg As String
Public Property ErrorMsg As String
  Set(ByVal value As String)
    mErrorMsg = value
  End Set
  Get
    Return mErrorMsg
  End Get
End Property
  Dim mgroup As String
  Public Property s_group As String
    Set(ByVal value As String)
      mgroup = value
    End Set
    Get
      Return mgroup
    End Get
  End Property
  Dim mrights As String
  Public Property s_rights As String
    Get
        Return mrights
    End Get
    Set(ByVal value As String)
        mrights = value
    End Set
End Property
Dim mfull As Boolean
Public Property s_full As Boolean
  Set(ByVal value As Boolean)
    mfull = value
  End Set
  Get
    Return mfull
  End Get
End Property
Dim madd As Boolean
Public Property s_add As Boolean
  Set(ByVal value As Boolean)
    madd = value
  End Set
  Get
    Return madd
  End Get
End Property
Dim mdel As Boolean
Public Property s_del As Boolean
  Set(ByVal value As Boolean)
    mdel = value
  End Set
  Get
    Return mdel
  End Get
End Property
Dim mchg As Boolean
Public Property s_chg As Boolean
  Set(ByVal value As Boolean)
    mchg = value
  End Set
  Get
    Return mchg
  End Get
End Property
Dim minq As Boolean
Public Property s_inq As Boolean
  Set(ByVal value As Boolean)
    minq = value
  End Set
  Get
    Return minq
  End Get
End Property
Dim medit As Boolean
Public Property s_edit As Boolean
  Set(ByVal value As Boolean)
    medit = value
  End Set
  Get
    Return medit
  End Get
End Property
Dim mpost As Boolean
Public Property s_post As Boolean
  Set(ByVal value As Boolean)
    mpost = value
  End Set
  Get
    Return mpost
  End Get
End Property
Dim msec As Boolean
Public Property s_sec As Boolean
  Set(ByVal value As Boolean)
    msec = value
  End Set
  Get
    Return msec
  End Get
End Property
#End Region
End Class

