Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class ApiVIN
  Dim mmodelId As Integer
  Dim mmodelName As String
  Dim mmodelAliases As IList
  Dim mmanufacturerId As Integer
  Dim mmanufacturerName As String
  Dim mmanufacturerAliases As IList
  Dim mclassificationId As Integer
  Dim mclassificationName As String
  Dim mcategoryId As Integer
  Dim mcategoryName As String
  Dim msubtypeId As Integer
  Dim msubtypeName As String
  Dim msizeClassId As Integer
  Dim msizeClassName As String
  Dim msizeClassMin As Integer
  Dim msizeClassMax As Integer
  Dim msizeClassUom As String
  Dim mconfigurationId As String
  Dim mvinModelNumber As String
  Dim mmodelYear As String
  Dim mvinManufacturerCode As String
  Dim mvinYearCode As String
  Dim mshortVin As String
  Dim mcicCode As String
  Dim mbrand As String
  Dim misError As Boolean
  Public Sub GetApiVIN(ByVal Vinno As String)
    Dim apiUrl As String
    Dim client As WebClient
    Dim ExportJson As String

    If Len(Trim(Vinno)) < 17 Then
      IsError = True
      Exit Sub
    End If
    System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
    apiUrl = "https://pricedigestsapi.com/v1/verification/vin/" & Vinno
    client = New WebClient()
    client.Headers("Content-type") = "application/json"
    client.Headers.Add("x-api-key", "3374f555f43d4a21961baab9a19a972d")
    client.Encoding = Encoding.UTF8
    Try
      ExportJson = client.DownloadString(apiUrl)
    Catch ex As Exception
      IsError = True
      Exit Sub
    End Try
    ' Parse JSON
    Dim jsonObject As Object = JsonConvert.DeserializeObject(ExportJson)
    If TypeOf jsonObject Is JArray Then
      Dim jsonArray As JArray = CType(jsonObject, JArray)
      ' Loop through the array
      For Each item As JObject In jsonArray
        ' Access properties of each item
        brand = item("brand").ToString()
        configurationId = item("configurationId").ToString()
        categoryId = CInt(item("categoryId"))
        categoryName = item("categoryName").ToString()
        cicCode = item("cicCode").ToString()
        classificationId = CInt(item("classificationId"))
        classificationName = item("classificationName").ToString()
        manufacturerAliases = item("manufacturerAliases")
        manufacturerId = CInt(item("manufacturerId"))
        manufacturerName = item("manufacturerName").ToString()
        modelAliases = item("modelAliases")
        modelId = CInt(item("modelId"))
        modelName = item("modelName").ToString()
        modelYear = item("modelYear").ToString()
        shortVin = item("shortVin").ToString()
        sizeClassId = CInt(item("sizeClassId"))
        sizeClassMax = CInt(item("sizeClassMax"))
        sizeClassMin = CInt(item("sizeClassMin"))
        sizeClassName = item("sizeClassName").ToString()
        sizeClassUom = item("sizeClassUom").ToString()
        subtypeId = CInt(item("subtypeId"))
        subtypeName = item("subtypeName").ToString()
        vinManufacturerCode = item("vinManufacturerCode").ToString()
        vinModelNumber = item("vinModelNumber").ToString()
        vinYearCode = item("vinYearCode").ToString()
      Next
    End If
  End Sub
  Public Property modelId As Integer
    Get
      modelId = mmodelId
    End Get
    Set(ByVal Value As Integer)
      mmodelId = Value
    End Set
  End Property
  Public Property modelName As String
    Get
      modelName = mmodelName
    End Get
    Set(ByVal Value As String)
      mmodelName = Value
    End Set
  End Property
  Public Property modelAliases As IList
    Get
      modelAliases = mmodelAliases
    End Get
    Set(ByVal Value As IList)
      mmodelAliases = Value
    End Set
  End Property
  Public Property manufacturerId As Integer
    Get
      manufacturerId = mmanufacturerId
    End Get
    Set(ByVal Value As Integer)
      mmanufacturerId = Value
    End Set
  End Property
  Public Property manufacturerName As String
    Get
      manufacturerName = mmanufacturerName
    End Get
    Set(ByVal Value As String)
      mmanufacturerName = Value
    End Set
  End Property
  Public Property manufacturerAliases As IList
    Get
      manufacturerAliases = mmanufacturerAliases
    End Get
    Set(ByVal Value As IList)
      mmanufacturerAliases = Value
    End Set
  End Property
  Public Property classificationId As Integer
    Get
      classificationId = mclassificationId
    End Get
    Set(ByVal Value As Integer)
      mclassificationId = Value
    End Set
  End Property
  Public Property classificationName As String
    Get
      classificationName = mclassificationName
    End Get
    Set(ByVal Value As String)
      mclassificationName = Value
    End Set
  End Property
  Public Property categoryId As Integer
    Get
      categoryId = mcategoryId
    End Get
    Set(ByVal Value As Integer)
      mcategoryId = Value
    End Set
  End Property
  Public Property categoryName As String
    Get
      categoryName = mcategoryName
    End Get
    Set(ByVal Value As String)
      mcategoryName = Value
    End Set
  End Property
  Public Property subtypeId As Integer
    Get
      subtypeId = msubtypeId
    End Get
    Set(ByVal Value As Integer)
      msubtypeId = Value
    End Set
  End Property
  Public Property subtypeName As String
    Get
      subtypeName = msubtypeName
    End Get
    Set(ByVal Value As String)
      msubtypeName = Value
    End Set
  End Property
  Public Property sizeClassId As Integer
    Get
      sizeClassId = msizeClassId
    End Get
    Set(ByVal Value As Integer)
      msizeClassId = Value
    End Set
  End Property
  Public Property sizeClassName As String
    Get
      sizeClassName = msizeClassName
    End Get
    Set(ByVal Value As String)
      msizeClassName = Value
    End Set
  End Property
  Public Property sizeClassMin As Integer
    Get
      sizeClassMin = msizeClassMin
    End Get
    Set(ByVal Value As Integer)
      msizeClassMin = Value
    End Set
  End Property
  Public Property sizeClassMax As Integer
    Get
      sizeClassMax = msizeClassMax
    End Get
    Set(ByVal Value As Integer)
      msizeClassMax = Value
    End Set
  End Property
  Public Property sizeClassUom As String
    Get
      sizeClassUom = msizeClassUom
    End Get
    Set(ByVal Value As String)
      msizeClassUom = Value
    End Set
  End Property
  Public Property configurationId As String
    Get
      configurationId = mconfigurationId
    End Get
    Set(ByVal Value As String)
      mconfigurationId = Value
    End Set
  End Property
  Public Property vinModelNumber As String
    Get
      vinModelNumber = mvinModelNumber
    End Get
    Set(ByVal Value As String)
      mvinModelNumber = Value
    End Set
  End Property
  Public Property modelYear As String
    Get
      modelYear = mmodelYear
    End Get
    Set(ByVal Value As String)
      mmodelYear = Value
    End Set
  End Property
  Public Property vinManufacturerCode As String
    Get
      vinManufacturerCode = mvinManufacturerCode
    End Get
    Set(ByVal Value As String)
      mvinManufacturerCode = Value
    End Set
  End Property
  Public Property vinYearCode As String
    Get
      vinYearCode = mvinYearCode
    End Get
    Set(ByVal Value As String)
      mvinYearCode = Value
    End Set
  End Property
  Public Property shortVin As String
    Get
      shortVin = mshortVin
    End Get
    Set(ByVal Value As String)
      mshortVin = Value
    End Set
  End Property
  Public Property cicCode As String
    Get
      cicCode = mcicCode
    End Get
    Set(ByVal Value As String)
      mcicCode = Value
    End Set
  End Property
  Public Property brand As String
    Get
      brand = mbrand
    End Get
    Set(ByVal Value As String)
      mbrand = Value
    End Set
  End Property
  Public Property IsError As Boolean
    Get
      IsError = miserror
    End Get
    Set(ByVal Value As Boolean)
      miserror = Value
    End Set
  End Property
End Class
