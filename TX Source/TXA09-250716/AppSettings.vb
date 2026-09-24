Imports System.IO
Public Class AppSettings

		Private m_ValidatePrinter As String
		Private m_ValidateModel As String
    Private m_ValidateFont As String
    Private m_ReceiptPrinter As String
		Private m_AdvDriver As Boolean
		Private m_DupBillPrinter As String
    Private m_PDFBillPrinter As String
    Private m_Receipt As Boolean
		Private m_PrinterOrient As String
		Private m_CheckSort As String
		Private m_ValidateTotal As Boolean
		Private m_StatusColor As Boolean
		Private m_ForeclosureColor As Boolean
		Private m_DupBillPublicData As Boolean
		Private m_DupBillPublicUser As Boolean
    Public Property ValidatePrinter() As String
        Get
            Return m_ValidatePrinter
        End Get
        Set(ByVal Value As String)
            m_ValidatePrinter = Value
        End Set
    End Property
		Public Property ValidateModel() As String
				Get
						Return m_ValidateModel
				End Get
				Set(ByVal Value As String)
						m_ValidateModel = Value
				End Set
		End Property
    Public Property ValidateFont() As String
        Get
            Return m_ValidateFont
        End Get
        Set(ByVal Value As String)
            m_ValidateFont = Value
        End Set
    End Property
    Public Property ReceiptPrinter() As String
        Get
            Return m_ReceiptPrinter
        End Get
        Set(ByVal Value As String)
            m_ReceiptPrinter = Value
        End Set
    End Property
		Public Property AdvDriver() As Boolean
				Get
						Return m_AdvDriver
				End Get
				Set(ByVal Value As Boolean)
						m_AdvDriver = Value
				End Set
		End Property
		Public Property DupBillPrinter() As String
				Get
						Return m_DupBillPrinter
				End Get
				Set(ByVal Value As String)
						m_DupBillPrinter = Value
				End Set
		End Property
    Public Property PDFBillPrinter() As String
        Get
            Return m_PDFBillPrinter
        End Get
        Set(ByVal Value As String)
            m_PDFBillPrinter = Value
        End Set
    End Property
    Public Property Receipt() As Boolean
        Get
            Return m_Receipt
        End Get
        Set(ByVal Value As Boolean)
            m_Receipt = Value
        End Set
    End Property
		Public Property PrinterOrient() As String
				Get
						Return m_PrinterOrient
				End Get
				Set(ByVal Value As String)
						m_PrinterOrient = Value
				End Set
		End Property
		Public Property CheckSort() As String
				Get
						Return m_CheckSort
				End Get
				Set(ByVal Value As String)
						m_CheckSort = Value
				End Set
		End Property
		Public Property ValidateTotal() As Boolean
				Get
						Return m_ValidateTotal
				End Get
				Set(ByVal Value As Boolean)
						m_ValidateTotal = Value
				End Set
		End Property
		Public Property StatusColor() As Boolean
				Get
						Return m_StatusColor
				End Get
				Set(ByVal Value As Boolean)
						m_StatusColor = Value
				End Set
		End Property
		Public Property ForeclosureColor() As Boolean
				Get
						Return m_ForeclosureColor
				End Get
				Set(ByVal Value As Boolean)
						m_ForeclosureColor = Value
				End Set
		End Property
		Public Property DupBillPublicData() As Boolean
				Get
						Return m_DupBillPublicData
				End Get
				Set(ByVal Value As Boolean)
						m_DupBillPublicData = Value
				End Set
		End Property
		Public Property DupBillPublicUser() As Boolean
				Get
						Return m_DupBillPublicUser
				End Get
				Set(ByVal Value As Boolean)
						m_DupBillPublicUser = Value
				End Set
		End Property
End Class







