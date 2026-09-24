Public Class AppSettings

    Private m_ImageDir As String
    Public Property ImageDir() As String
        Get
            Return m_ImageDir
        End Get
        Set(ByVal Value As String)
            m_ImageDir = Value
        End Set
    End Property
End Class
