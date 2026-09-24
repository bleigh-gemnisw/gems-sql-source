Imports System.IO
Public Class AppSettings

    Private m_PrintOrient As String
    Public Property PrintOrient() As String
        Get
            Return m_PrintOrient
        End Get
        Set(ByVal Value As String)
            m_PrintOrient = Value
        End Set
    End Property
End Class

