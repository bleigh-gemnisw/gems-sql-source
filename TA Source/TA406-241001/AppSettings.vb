Public Class AppSettings

    Private m_DoubleSpace As Boolean
    Private m_PrintOrient As String
    Public Property DoubleSpace() As Boolean
        Get
            Return m_DoubleSpace
        End Get
        Set(ByVal Value As Boolean)
            m_DoubleSpace = Value
        End Set
    End Property
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
End Class






