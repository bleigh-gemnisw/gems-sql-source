Public Class AppSettings

    Private m_Printer As String
    Private m_Copies As Integer
    Public Property Printer() As String
        Get
            Return m_Printer
        End Get
        Set(ByVal Value As String)
            m_Printer = Value
        End Set
    End Property
    Public Property Copies() As Integer
        Get
            Return m_Copies
        End Get
        Set(ByVal Value As Integer)
            m_Copies = Value
        End Set
    End Property
End Class






