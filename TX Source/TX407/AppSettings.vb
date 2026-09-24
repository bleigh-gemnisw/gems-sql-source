Public Class AppSettings

    Private m_PrintOrient As String
    Private m_DaysCheck As Integer
    Private m_DaysECheck As Integer
    Private m_DaysCredit As Integer
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
    Public Property DaysCheck() As Integer
        Get
            Return m_DaysCheck
        End Get
        Set(ByVal Value As Integer)
            m_DaysCheck = Value
        End Set
    End Property
    Public Property DaysECheck() As Integer
        Get
            Return m_DaysECheck
        End Get
        Set(ByVal Value As Integer)
            m_DaysECheck = Value
        End Set
    End Property
    Public Property DaysCredit() As Integer
        Get
            Return m_DaysCredit
        End Get
        Set(ByVal Value As Integer)
            m_DaysCredit = Value
        End Set
    End Property
End Class






