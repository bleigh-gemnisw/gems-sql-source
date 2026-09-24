' 7/10/19 Add recid to logicals (L1,L2,L3) 
Imports System.IO
Public Class AppSettings

		Private m_ValidatePrinter As String
		Private m_ValidateModel As String
    Private m_ValidateFont As String
    Private m_ReceiptPrinter As String
		Private m_AdvDriver As Boolean
    Private m_Receipt As Boolean
    Private m_PermitPrinter As String
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
    Public Property Receipt() As Boolean
        Get
            Return m_Receipt
        End Get
        Set(ByVal Value As Boolean)
            m_Receipt = Value
        End Set
    End Property
    Public Property PermitPrinter() As String
        Get
            Return m_PermitPrinter
        End Get
        Set(ByVal Value As String)
            m_PermitPrinter = Value
        End Set
    End Property
 End Class







