Imports System.IO
Public Class AppSettings

    Private m_Printer As String
    Private m_PrintOrient As String
    Private m_PrtscrnBW As Boolean
    Public Property Printer() As String
        Get
            Return m_Printer
        End Get
        Set(ByVal Value As String)
            m_Printer = Value
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
    Public Property PrtscrnBW() As Boolean
        Get
            Return m_PrtscrnBW
        End Get
        Set(ByVal Value As Boolean)
            m_PrtscrnBW = Value
        End Set
    End Property
End Class

