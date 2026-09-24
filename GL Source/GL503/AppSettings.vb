Public Class AppSettings

    Private m_Selection As Integer
    Private m_PrintOrient As String
    Public Property Selection() As Integer
        Get
            Return m_Selection
        End Get
        Set(ByVal Value As Integer)
            m_Selection = Value
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
