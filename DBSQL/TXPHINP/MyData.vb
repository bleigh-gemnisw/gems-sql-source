Imports System.Data
Imports System.Data.SqlClient
Public Class MyData
  Dim MyDBConn As SQLConnect.DBConnection
  Dim StrSQL As String
	Dim da As SqlDataAdapter
  Const cFileName As String = "TXPHINP"
#Region "Constructors"

  Public Sub New(DBConn As SQLConnect.DBConnection)
    MyDBConn = DBConn
  End Sub

#End Region

#Region "Methods: File Access Routines"
Public Sub ClearFields
_PLISTNo  = 0
_CAPGRS  = 0
_CAPA1  = 0
_CAPA2  = 0
_CAPA3  = 0
_CAPA4  = 0
_CAPA5  = 0
_CAPA6  = 0
_CAPA7  = 0
_CAPC1  = 0
_CAPC2  = 0
_CAPC3  = 0
_CAPC4  = 0
_CAPC5  = 0
_CAPC6  = 0
_CAPC7  = 0
_FULGRS  = 0
_FULA1  = 0
_FULA2  = 0
_FULA3  = 0
_FULA4  = 0
_FULA5  = 0
_FULA6  = 0
_FULA7  = 0
_FULC1  = 0
_FULC2  = 0
_FULC3  = 0
_FULC4  = 0
_FULC5  = 0
_FULC6  = 0
_FULC7  = 0
_ADJGRS  = 0
_ADJA1  = 0
_ADJA2  = 0
_ADJA3  = 0
_ADJA4  = 0
_ADJA5  = 0
_ADJA6  = 0
_ADJA7  = 0
_ADJC1  = 0
_ADJC2  = 0
_ADJC3  = 0
_ADJC4  = 0
_ADJC5  = 0
_ADJC6  = 0
_ADJC7  = 0

End Sub
  Public Sub GetOneRecordP(ByVal Wrkplistno As integer)
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

  RecordNotFound = False
    StrSQL = "Select * from " & cFileName & " where plistno = " & Wrkplistno
    Try
    Conn = MyDBConn.Open
    objCommand = New SqlCommand(StrSQL, Conn)
    'Fill the dataset with the data
    da = New SqlDataAdapter
    da.SelectCommand = objCommand
    da.Fill(ds, cFileName)
    If ds.Tables(0).Rows.Count = 0 Then
      RecordNotFound = True
 ClearFields 
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
Public Function PosData(ByVal Wrkplistno As integer) As DataSet
  Dim Conn As SqlConnection
  Dim objCommand As SqlCommand
  Dim ds As DataSet = New DataSet

    StrSQL = "Select * from " & cFileName & " where plistno >= " & Wrkplistno & " Order by plistno"
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
  _PLISTNo  = .Item("PLIST#")
  _CAPGRS   = .Item("CAPGRS")
  _CAPA1    = .Item("CAPA1")
  _CAPA2    = .Item("CAPA2")
  _CAPA3    = .Item("CAPA3")
  _CAPA4    = .Item("CAPA4")
  _CAPA5    = .Item("CAPA5")
  _CAPA6    = .Item("CAPA6")
  _CAPA7    = .Item("CAPA7")
  _CAPC1    = .Item("CAPC1")
  _CAPC2    = .Item("CAPC2")
  _CAPC3    = .Item("CAPC3")
  _CAPC4    = .Item("CAPC4")
  _CAPC5    = .Item("CAPC5")
  _CAPC6    = .Item("CAPC6")
  _CAPC7    = .Item("CAPC7")
  _FULGRS   = .Item("FULGRS")
  _FULA1    = .Item("FULA1")
  _FULA2    = .Item("FULA2")
  _FULA3    = .Item("FULA3")
  _FULA4    = .Item("FULA4")
  _FULA5    = .Item("FULA5")
  _FULA6    = .Item("FULA6")
  _FULA7    = .Item("FULA7")
  _FULC1    = .Item("FULC1")
  _FULC2    = .Item("FULC2")
  _FULC3    = .Item("FULC3")
  _FULC4    = .Item("FULC4")
  _FULC5    = .Item("FULC5")
  _FULC6    = .Item("FULC6")
  _FULC7    = .Item("FULC7")
  _ADJGRS   = .Item("ADJGRS")
  _ADJA1    = .Item("ADJA1")
  _ADJA2    = .Item("ADJA2")
  _ADJA3    = .Item("ADJA3")
  _ADJA4    = .Item("ADJA4")
  _ADJA5    = .Item("ADJA5")
  _ADJA6    = .Item("ADJA6")
  _ADJA7    = .Item("ADJA7")
  _ADJC1    = .Item("ADJC1")
  _ADJC2    = .Item("ADJC2")
  _ADJC3    = .Item("ADJC3")
  _ADJC4    = .Item("ADJC4")
  _ADJC5    = .Item("ADJC5")
  _ADJC6    = .Item("ADJC6")
  _ADJC7    = .Item("ADJC7")

    End With
  End Sub
Public Sub PutFields(ByVal ds As DataSet)
    With ds.Tables(0).Rows(0)
.Item("PLIST#") =   _PLISTNo 
.Item("CAPGRS") =   _CAPGRS  
.Item("CAPA1") =   _CAPA1   
.Item("CAPA2") =   _CAPA2   
.Item("CAPA3") =   _CAPA3   
.Item("CAPA4") =   _CAPA4   
.Item("CAPA5") =   _CAPA5   
.Item("CAPA6") =   _CAPA6   
.Item("CAPA7") =   _CAPA7   
.Item("CAPC1") =   _CAPC1   
.Item("CAPC2") =   _CAPC2   
.Item("CAPC3") =   _CAPC3   
.Item("CAPC4") =   _CAPC4   
.Item("CAPC5") =   _CAPC5   
.Item("CAPC6") =   _CAPC6   
.Item("CAPC7") =   _CAPC7   
.Item("FULGRS") =   _FULGRS  
.Item("FULA1") =   _FULA1   
.Item("FULA2") =   _FULA2   
.Item("FULA3") =   _FULA3   
.Item("FULA4") =   _FULA4   
.Item("FULA5") =   _FULA5   
.Item("FULA6") =   _FULA6   
.Item("FULA7") =   _FULA7   
.Item("FULC1") =   _FULC1   
.Item("FULC2") =   _FULC2   
.Item("FULC3") =   _FULC3   
.Item("FULC4") =   _FULC4   
.Item("FULC5") =   _FULC5   
.Item("FULC6") =   _FULC6   
.Item("FULC7") =   _FULC7   
.Item("ADJGRS") =   _ADJGRS  
.Item("ADJA1") =   _ADJA1   
.Item("ADJA2") =   _ADJA2   
.Item("ADJA3") =   _ADJA3   
.Item("ADJA4") =   _ADJA4   
.Item("ADJA5") =   _ADJA5   
.Item("ADJA6") =   _ADJA6   
.Item("ADJA7") =   _ADJA7   
.Item("ADJC1") =   _ADJC1   
.Item("ADJC2") =   _ADJC2   
.Item("ADJC3") =   _ADJC3   
.Item("ADJC4") =   _ADJC4   
.Item("ADJC5") =   _ADJC5   
.Item("ADJC6") =   _ADJC6   
.Item("ADJC7") =   _ADJC7   

    End With
  End Sub
#End Region


#Region "Properties: Fields"

Dim mPLISTNo  as integer 
Public Property _PLISTNo  as integer   
    Get
        Return mPLISTNo
    End Get
    set(byval value as integer)
        mPLISTNO = value
    End Set
End Property

Dim mCAPGRS  as long
Public Property _CAPGRS  as long  
    Get
        Return mCAPGRS
    End Get
    set(byval value as long)
        mCAPGRS = value
    End Set
End Property

Dim mCAPA1  as long
Public Property _CAPA1  as long  
    Get
        Return mCAPA1
    End Get
    set(byval value as long)
        mCAPA1 = value
    End Set
End Property

Dim mCAPA2  as long
Public Property _CAPA2  as long  
    Get
        Return mCAPA2
    End Get
    set(byval value as long)
        mCAPA2 = value
    End Set
End Property

Dim mCAPA3  as long
Public Property _CAPA3  as long  
    Get
        Return mCAPA3
    End Get
    set(byval value as long)
        mCAPA3 = value
    End Set
End Property

Dim mCAPA4  as long
Public Property _CAPA4  as long  
    Get
        Return mCAPA4
    End Get
    set(byval value as long)
        mCAPA4 = value
    End Set
End Property

Dim mCAPA5  as long
Public Property _CAPA5  as long  
    Get
        Return mCAPA5
    End Get
    set(byval value as long)
        mCAPA5 = value
    End Set
End Property

Dim mCAPA6  as long
Public Property _CAPA6  as long  
    Get
        Return mCAPA6
    End Get
    set(byval value as long)
        mCAPA6 = value
    End Set
End Property

Dim mCAPA7  as long
Public Property _CAPA7  as long  
    Get
        Return mCAPA7
    End Get
    set(byval value as long)
        mCAPA7 = value
    End Set
End Property

Dim mCAPC1  as integer 
Public Property _CAPC1  as integer   
    Get
        Return mCAPC1
    End Get
    set(byval value as integer)
        mCAPC1 = value
    End Set
End Property

Dim mCAPC2  as integer 
Public Property _CAPC2  as integer   
    Get
        Return mCAPC2
    End Get
    set(byval value as integer)
        mCAPC2 = value
    End Set
End Property

Dim mCAPC3  as integer 
Public Property _CAPC3  as integer   
    Get
        Return mCAPC3
    End Get
    set(byval value as integer)
        mCAPC3 = value
    End Set
End Property

Dim mCAPC4  as integer 
Public Property _CAPC4  as integer   
    Get
        Return mCAPC4
    End Get
    set(byval value as integer)
        mCAPC4 = value
    End Set
End Property

Dim mCAPC5  as integer 
Public Property _CAPC5  as integer   
    Get
        Return mCAPC5
    End Get
    set(byval value as integer)
        mCAPC5 = value
    End Set
End Property

Dim mCAPC6  as integer 
Public Property _CAPC6  as integer   
    Get
        Return mCAPC6
    End Get
    set(byval value as integer)
        mCAPC6 = value
    End Set
End Property

Dim mCAPC7  as integer 
Public Property _CAPC7  as integer   
    Get
        Return mCAPC7
    End Get
    set(byval value as integer)
        mCAPC7 = value
    End Set
End Property

Dim mFULGRS  as long
Public Property _FULGRS  as long  
    Get
        Return mFULGRS
    End Get
    set(byval value as long)
        mFULGRS = value
    End Set
End Property

Dim mFULA1  as long
Public Property _FULA1  as long  
    Get
        Return mFULA1
    End Get
    set(byval value as long)
        mFULA1 = value
    End Set
End Property

Dim mFULA2  as long
Public Property _FULA2  as long  
    Get
        Return mFULA2
    End Get
    set(byval value as long)
        mFULA2 = value
    End Set
End Property

Dim mFULA3  as long
Public Property _FULA3  as long  
    Get
        Return mFULA3
    End Get
    set(byval value as long)
        mFULA3 = value
    End Set
End Property

Dim mFULA4  as long
Public Property _FULA4  as long  
    Get
        Return mFULA4
    End Get
    set(byval value as long)
        mFULA4 = value
    End Set
End Property

Dim mFULA5  as long
Public Property _FULA5  as long  
    Get
        Return mFULA5
    End Get
    set(byval value as long)
        mFULA5 = value
    End Set
End Property

Dim mFULA6  as long
Public Property _FULA6  as long  
    Get
        Return mFULA6
    End Get
    set(byval value as long)
        mFULA6 = value
    End Set
End Property

Dim mFULA7  as long
Public Property _FULA7  as long  
    Get
        Return mFULA7
    End Get
    set(byval value as long)
        mFULA7 = value
    End Set
End Property

Dim mFULC1  as integer 
Public Property _FULC1  as integer   
    Get
        Return mFULC1
    End Get
    set(byval value as integer)
        mFULC1 = value
    End Set
End Property

Dim mFULC2  as integer 
Public Property _FULC2  as integer   
    Get
        Return mFULC2
    End Get
    set(byval value as integer)
        mFULC2 = value
    End Set
End Property

Dim mFULC3  as integer 
Public Property _FULC3  as integer   
    Get
        Return mFULC3
    End Get
    set(byval value as integer)
        mFULC3 = value
    End Set
End Property

Dim mFULC4  as integer 
Public Property _FULC4  as integer   
    Get
        Return mFULC4
    End Get
    set(byval value as integer)
        mFULC4 = value
    End Set
End Property

Dim mFULC5  as integer 
Public Property _FULC5  as integer   
    Get
        Return mFULC5
    End Get
    set(byval value as integer)
        mFULC5 = value
    End Set
End Property

Dim mFULC6  as integer 
Public Property _FULC6  as integer   
    Get
        Return mFULC6
    End Get
    set(byval value as integer)
        mFULC6 = value
    End Set
End Property

Dim mFULC7  as integer 
Public Property _FULC7  as integer   
    Get
        Return mFULC7
    End Get
    set(byval value as integer)
        mFULC7 = value
    End Set
End Property

Dim mADJGRS  as long
Public Property _ADJGRS  as long  
    Get
        Return mADJGRS
    End Get
    set(byval value as long)
        mADJGRS = value
    End Set
End Property

Dim mADJA1  as long
Public Property _ADJA1  as long  
    Get
        Return mADJA1
    End Get
    set(byval value as long)
        mADJA1 = value
    End Set
End Property

Dim mADJA2  as long
Public Property _ADJA2  as long  
    Get
        Return mADJA2
    End Get
    set(byval value as long)
        mADJA2 = value
    End Set
End Property

Dim mADJA3  as long
Public Property _ADJA3  as long  
    Get
        Return mADJA3
    End Get
    set(byval value as long)
        mADJA3 = value
    End Set
End Property

Dim mADJA4  as long
Public Property _ADJA4  as long  
    Get
        Return mADJA4
    End Get
    set(byval value as long)
        mADJA4 = value
    End Set
End Property

Dim mADJA5  as long
Public Property _ADJA5  as long  
    Get
        Return mADJA5
    End Get
    set(byval value as long)
        mADJA5 = value
    End Set
End Property

Dim mADJA6  as long
Public Property _ADJA6  as long  
    Get
        Return mADJA6
    End Get
    set(byval value as long)
        mADJA6 = value
    End Set
End Property

Dim mADJA7  as long
Public Property _ADJA7  as long  
    Get
        Return mADJA7
    End Get
    set(byval value as long)
        mADJA7 = value
    End Set
End Property

Dim mADJC1  as integer 
Public Property _ADJC1  as integer   
    Get
        Return mADJC1
    End Get
    set(byval value as integer)
        mADJC1 = value
    End Set
End Property

Dim mADJC2  as integer 
Public Property _ADJC2  as integer   
    Get
        Return mADJC2
    End Get
    set(byval value as integer)
        mADJC2 = value
    End Set
End Property

Dim mADJC3  as integer 
Public Property _ADJC3  as integer   
    Get
        Return mADJC3
    End Get
    set(byval value as integer)
        mADJC3 = value
    End Set
End Property

Dim mADJC4  as integer 
Public Property _ADJC4  as integer   
    Get
        Return mADJC4
    End Get
    set(byval value as integer)
        mADJC4 = value
    End Set
End Property

Dim mADJC5  as integer 
Public Property _ADJC5  as integer   
    Get
        Return mADJC5
    End Get
    set(byval value as integer)
        mADJC5 = value
    End Set
End Property

Dim mADJC6  as integer 
Public Property _ADJC6  as integer   
    Get
        Return mADJC6
    End Get
    set(byval value as integer)
        mADJC6 = value
    End Set
End Property

Dim mADJC7  as integer 
Public Property _ADJC7  as integer   
    Get
        Return mADJC7
    End Get
    set(byval value as integer)
        mADJC7 = value
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


