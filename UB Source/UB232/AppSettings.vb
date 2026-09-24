Public Class AppSettings

    Private m_PrintOrient As String
    Private m_Commercial As String
    Private m_Mixed As String
    Private m_MultiFamily As String
    Private m_Residential As String
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
    Public Property Commercial() As String
        Get
            Return m_Commercial
        End Get
        Set(ByVal Value As String)
            m_Commercial = Value
        End Set
    End Property
    Public Property Mixed() As String
        Get
            Return m_Mixed
        End Get
        Set(ByVal Value As String)
            m_Mixed = Value
        End Set
    End Property
    Public Property MultiFamily() As String
        Get
            Return m_MultiFamily
        End Get
        Set(ByVal Value As String)
            m_MultiFamily = Value
        End Set
    End Property
    Public Property Residential() As String
        Get
            Return m_Residential
        End Get
        Set(ByVal Value As String)
            m_Residential = Value
        End Set
    End Property
End Class






