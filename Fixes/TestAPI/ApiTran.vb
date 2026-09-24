Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Module ApiTran
  Dim mvarAcctID As String
  Dim mvarAmount As Decimal
  Dim mvarOwner_Name As String
  Dim mvarYear As Integer
  Dim mvarProperty_Full_Address As String
  Dim WrkTran As Transaction
  Public Function GetApiTran(ByVal TownNo As String, ByVal AcctID As String) As Transaction
    Dim apiUrl As String
    Dim client As WebClient
    Dim input As Object
    Dim inputJson As String
    Dim ExportJson As String

    apiUrl = "https://api.gemsnt.com/" & TownNo & "/api.php?acctID='" & AcctID & "'"
    input = ""
    inputJson = (New JavaScriptSerializer().Serialize(input))
    client = New WebClient()
    client.Headers("Content-type") = "application/json"
    client.Encoding = Encoding.UTF8
    Try
      client.UploadString(apiUrl, inputJson)
      ExportJson = client.DownloadString(apiUrl)
      WrkTran = New JavaScriptSerializer().Deserialize(Of Transaction)(ExportJson)
    Catch ex As Exception
      WrkTran = New Transaction
      WrkTran.AcctID = ""
      WrkTran.Owner_Name = ""
      WrkTran.Property_Full_Address = ""
    End Try
    Return WrkTran
  End Function
  Public Class Transaction
    Public Property AcctID As String
      Get
        AcctID = mvarAcctID
      End Get
      Set(ByVal Value As String)
        mvarAcctID = Value
      End Set
    End Property
    Public Property Amount As Decimal
      Get
        Amount = mvarAmount
      End Get
      Set(ByVal Value As Decimal)
        mvarAmount = Value
      End Set
    End Property
    Public Property Year As Integer
      Get
        Year = mvarYear
      End Get
      Set(ByVal Value As Integer)
        mvarYear = Value
      End Set
    End Property
    Public Property Owner_Name As String
      Get
        Owner_Name = mvarOwner_Name
      End Get
      Set(ByVal Value As String)
        mvarOwner_Name = Value
      End Set
    End Property
    Public Property Property_Full_Address As String
      Get
        Property_Full_Address = mvarProperty_Full_Address
      End Get
      Set(ByVal Value As String)
        mvarProperty_Full_Address = Value
      End Set
    End Property
  End Class
End Module
