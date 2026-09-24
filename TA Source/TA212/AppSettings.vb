Public Class AppSettings

    Private m_PrintOrient As String
    Private m_PrinterTopMargin As Integer
    Private m_PrinterLeftMargin As Integer
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
    Public Property PrinterTopMargin() As Integer
        Get
            Return m_PrinterTopMargin
        End Get
        Set(ByVal Value As Integer)
            m_PrinterTopMargin = Value
        End Set
    End Property
    Public Property PrinterLeftMargin() As Integer
        Get
            Return m_PrinterLeftMargin
        End Get
        Set(ByVal Value As Integer)
            m_PrinterLeftMargin = Value
        End Set
    End Property
End Class






