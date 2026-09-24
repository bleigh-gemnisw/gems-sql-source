Public Class AppSettings

    Private m_PrintOrient As String
    Private m_PrintDouble As Boolean
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
    Public Property PrintDouble() As Boolean
        Get
            Return m_PrintDouble
        End Get
        Set(ByVal Value As Boolean)
            m_PrintDouble = Value
        End Set
    End Property
End Class






