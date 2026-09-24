Public Class AppSettings

    Private m_FilePath As String
    Private m_GLYear As Integer
    Private m_SuppSame As Boolean
    Private m_PrintOrient As String
    Public Property FilePath() As String
        Get
            Return m_FilePath
        End Get
        Set(ByVal Value As String)
            m_FilePath = Value
        End Set
    End Property
    Public Property GLYear() As Integer
        Get
            Return m_GLYear
        End Get
        Set(ByVal Value As Integer)
            m_GLYear = Value
        End Set
    End Property
    Public Property SuppSame() As Boolean
        Get
            Return m_SuppSame
        End Get
        Set(ByVal Value As Boolean)
            m_SuppSame = Value
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
