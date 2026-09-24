Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Text

Public Class ApiValue
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
  Dim mmodelYear As String
  Dim mrevisionDate As String
  Dim mMSRP As Integer
  Dim munadjustedLow As String
  Dim munadjustedHigh As String
  Dim munadjustedFinance As Integer
  Dim munadjustedRetail As Integer
  Dim munadjustedWholesale  As Integer
  Dim munadjustedTradeIn As Integer
  Public Sub GetApiValue(ByVal ConfigId As String)
    Dim apiUrl As String
    Dim client As WebClient
    Dim ExportJson As String
    Dim WrkError As Boolean

    WrkError = False
    System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
    apiUrl = "https://pricedigestsapi.com/v1/values/value/?configurationId=" & ConfigId
    client = New WebClient()
    client.Headers("Content-type") = "application/json"
    client.Headers.Add("x-api-key", "3374f555f43d4a21961baab9a19a972d")
    client.Encoding = Encoding.UTF8
    Try
      ExportJson = client.DownloadString(apiUrl)
    Catch ex As Exception
      WrkError = True
      Exit Sub
    End Try
    ' Parse JSON
    Dim jsonObject As Object = JsonConvert.DeserializeObject(ExportJson)
    If TypeOf jsonObject Is JObject Then
      Dim json As JObject = CType(jsonObject, JObject)
      configurationId = json("configurationId").ToString()
      categoryId = CInt(json("categoryId"))
      categoryName = json("categoryName").ToString()
      classificationId = CInt(json("classificationId"))
      classificationName = json("classificationName").ToString()
      manufacturerAliases = json("manufacturerAliases")
      manufacturerId = CInt(json("manufacturerId"))
      manufacturerName = json("manufacturerName").ToString()
      modelAliases = json("modelAliases")
      modelId = CInt(json("modelId"))
      modelName = json("modelName").ToString()
      modelYear = json("modelYear").ToString()
      sizeClassId = CInt(json("sizeClassId"))
      sizeClassMax = CInt(json("sizeClassMax"))
      sizeClassMin = CInt(json("sizeClassMin"))
      sizeClassName = json("sizeClassName").ToString()
      sizeClassUom = json("sizeClassUom").ToString()
      subtypeId = CInt(json("subtypeId"))
      subtypeName = json("subtypeName").ToString()
      revisionDate = json("revisionDate").ToString()
      Try
        MSRP = CInt(json("MSRP"))
      Catch ex As Exception
        MSRP = 0
      End Try
      Try
        unadjustedLow = json("unadjustedLow").ToString()
      Catch ex As Exception
        unadjustedLow = 0
      End Try
      Try
        unadjustedHigh = json("unadjustedHigh").ToString()
      Catch ex As Exception
        unadjustedHigh = 0
      End Try
      Try
        unadjustedFinance = CInt(json("unadjustedFinance"))
      Catch ex As Exception
        unadjustedFinance = 0
      End Try
      Try
        unadjustedRetail = CInt(json("unadjustedRetail"))
      Catch ex As Exception
        unadjustedRetail = 0
      End Try
      Try
        unadjustedWholesale = CInt(json("unadjustedWholesale"))
      Catch ex As Exception
        unadjustedWholesale = 0
      End Try
      Try
        unadjustedTradeIn = CInt(json("unadjustedTradeIn"))
      Catch ex As Exception
        unadjustedTradeIn = 0
      End Try
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
  Public Property modelYear As String
    Get
      modelYear = mmodelYear
    End Get
    Set(ByVal Value As String)
      mmodelYear = Value
    End Set
  End Property
  Public Property revisionDate As String
    Get
      revisionDate = mrevisionDate
    End Get
    Set(ByVal Value As String)
      mrevisionDate = Value
    End Set
  End Property
  Public Property MSRP As Integer
    Get
      MSRP = mMSRP
    End Get
    Set(ByVal Value As Integer)
      mMSRP = Value
    End Set
  End Property
  Public Property unadjustedLow As String
    Get
      unadjustedLow = munadjustedLow
    End Get
    Set(ByVal Value As String)
      munadjustedLow = Value
    End Set
  End Property
  Public Property unadjustedHigh As String
    Get
      unadjustedHigh = munadjustedHigh
    End Get
    Set(ByVal Value As String)
      munadjustedHigh = Value
    End Set
  End Property
  Public Property unadjustedFinance As Integer
    Get
      unadjustedFinance = munadjustedFinance
    End Get
    Set(ByVal Value As Integer)
      munadjustedFinance = Value
    End Set
  End Property
  Public Property unadjustedRetail As Integer
    Get
      unadjustedRetail = munadjustedRetail
    End Get
    Set(ByVal Value As Integer)
      munadjustedRetail = Value
    End Set
  End Property
  Public Property unadjustedWholesale As Integer
    Get
      unadjustedWholesale = munadjustedWholesale
    End Get
    Set(ByVal Value As Integer)
      munadjustedWholesale = Value
    End Set
  End Property
  Public Property unadjustedTradeIn As Integer
    Get
      unadjustedTradeIn = munadjustedTradeIn
    End Get
    Set(ByVal Value As Integer)
      munadjustedTradeIn = Value
    End Set
  End Property
End Class

