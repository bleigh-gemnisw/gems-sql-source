Public Class AppSettings

    Private m_PrintOrient As String
    Private m_Printer As String
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
    Public Property Printer() As String
        Get
            Return m_Printer
        End Get
        Set(ByVal Value As String)
            m_Printer = Value
        End Set
    End Property
End Class
