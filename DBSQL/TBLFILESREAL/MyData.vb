Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TBLFILESREAL"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
  Public Sub ClearFields()
    _RCDID = 0
    _MASTERTABLENAME = String.Empty
    _MASTERTABLEKEY = 0
    _FILESTORED = String.Empty
    _ATTACHDESC = String.Empty
    _KEYSTRING = String.Empty
    _ORIGINALFILE = String.Empty
  End Sub
  Public Sub GetOneRecordP(ByVal Wrkkey As Integer)
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where RCDID = " & Wrkkey
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

  Public Function GetAllData() As DataSet
    Dim ds As DataSet = New DataSet
    ds = PosData("", "", "")
    Return ds
  End Function
  Public Function PosData(ByVal Wrkkey As String, ByVal Wrkprogram As String,
   ByVal WrkDescription As String) As DataSet
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where KEYSTRING = '" & Wrkkey & "' AND MASTERTABLENAME = '" &
     Wrkprogram & "' and ATTACHDESC >= '" & WrkDescription & "' Order by KEYSTRING,ATTACHDATE DESC"

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
  Public Function getcount(ByVal Wrkkey As String, ByVal Wrkprogram As String) As Integer

    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Dim ds As DataSet = New DataSet
    Dim wrkcount As Integer
    StrSQL = "Select count(KEYSTRING) as rcount from " & cFileName & " where KEYSTRING = '" & Wrkkey & "' AND MASTERTABLENAME = '" &
     Wrkprogram & "'"


    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)

    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    objCommand = Nothing
    Conn.Close()
    wrkcount = ds.Tables(0).Rows(0)("rcount")

    Return wrkcount
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

  Public Sub InsertOneRecordP()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand
    Const caa As String = "','" 'Alpha Before/Alpha After
    Const can As String = "'," 'Alpha Before/Numeric After
    Const cna As String = ",'" 'Numeric Before/Alpha After
    Const cnn As String = "," 'Numeric Before/Numeric After


    StrSQL = "Insert into " & cFileName & "(MASTERTABLENAME, MASTERTABLEKEY, FILESTORED, ATTACHDESC, " &
   "ATTACHDATE, KEYSTRING,ORIGINALFILE )" &
   " values('" & _MASTERTABLENAME & can & _MASTERTABLEKEY & cna & _FILESTORED & caa &
    _ATTACHDESC & caa & _ATTACHDATE & caa & _KEYSTRING & caa & _ORIGINALFILE & "')"
    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
  End Sub
  Public Sub DeleteSQL()
    Dim Conn As SqlConnection
    Dim objCommand As SqlCommand

    StrSQL = "Delete From " & cFileName & " WHERE rcdid = " & _RCDID

    Try
      Conn = MyDBConn.Open
      objCommand = New SqlCommand(StrSQL, Conn)
      da = New SqlDataAdapter
      da.InsertCommand = objCommand
      da.InsertCommand.ExecuteNonQuery()
      objCommand = Nothing
      Conn.Close()
    Catch ex As Exception
      ErrMsg = ex.ToString()
    End Try
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
      _RCDID = .Item("RCDID")
      _MASTERTABLENAME = .Item("MASTERTABLENAME")
      _MASTERTABLEKEY = .Item("MASTERTABLEKEY")
      _FILESTORED = .Item("FILESTORED")
      _ATTACHDESC = .Item("ATTACHDESC")
      _ATTACHDATE = .Item("ATTACHDATE")
      _KEYSTRING = .Item("KEYSTRING")
      _ORIGINALFILE = .Item("ORIGINALFILE")
    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
      .Item("RCDID") = _RCDID
      .Item("MASTERTABLENAME") = _MASTERTABLENAME
      .Item("MASTERTABLEKEY") = _MASTERTABLEKEY
      .Item("FILESTORED") = _FILESTORED
      .Item("ATTACHDESC") = _ATTACHDESC
      .Item("ATTACHDATE") = _ATTACHDATE
      .Item("KEYSTRING") = _KEYSTRING
      .Item("ORIGINALFILE") = _ORIGINALFILE
    End With
  End Sub
#End Region


#Region "Properties: Fields"

  Dim mRCDID As Integer
  Public Property _RCDID As Integer
    Get
      Return mRCDID
    End Get
    Set(ByVal value As Integer)
      mRCDID = value
    End Set
  End Property

  Dim mMASTERTABLENAME As String
  Public Property _MASTERTABLENAME As String
    Get
      Return mMASTERTABLENAME
    End Get
    Set(ByVal value As String)
      mMASTERTABLENAME = value
    End Set
  End Property




  Dim mMASTERTABLEKEY As Integer
  Public Property _MASTERTABLEKEY As Integer
    Get
      Return mMASTERTABLEKEY
    End Get
    Set(ByVal value As Integer)
      mMASTERTABLEKEY = value
    End Set
  End Property
  Dim m_FILESTORED As String
  Public Property _FILESTORED As String
    Get
      Return m_FILESTORED
    End Get
    Set(ByVal value As String)
      m_FILESTORED = value
    End Set
  End Property
  Dim m_ATTACHDESC As String
  Public Property _ATTACHDESC As String
    Get
      Return m_ATTACHDESC
    End Get
    Set(ByVal value As String)
      m_ATTACHDESC = value
    End Set
  End Property
  Dim m_ATTACHDATE As Date
  Public Property _ATTACHDATE As Date
    Get
      Return m_ATTACHDATE
    End Get
    Set(ByVal value As Date)
      m_ATTACHDATE = value
    End Set
  End Property
  Dim m_KEYSTRING As String
  Public Property _KEYSTRING As String
    Get
      Return m_KEYSTRING
    End Get
    Set(ByVal value As String)
      m_KEYSTRING = value
    End Set
  End Property
  Dim m_ORIGINALFILE As String
  Public Property _ORIGINALFILE As String
    Get
      Return m_ORIGINALFILE
    End Get
    Set(ByVal value As String)
      m_ORIGINALFILE = value
    End Set
  End Property


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


