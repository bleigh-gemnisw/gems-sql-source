Imports System.IO
Public Class AppSettings

    Private m_DBName As String
    Private m_IsRPM As Boolean
    Private m_REFile As String
    Private m_PPFile As String
    Private m_MVFile As String
    Private m_MSFile As String
    Private m_NCOAFile As String
    Private m_ExportFile As String
    Private m_DueDate1 As Date
    Private m_DueDate2 As Date
    Private m_GraceDate1 As Date
    Private m_GraceDate2 As Date
    Private m_TownName As String
    Private m_PayTo As String
    Private m_Line1 As String
    Private m_Line2 As String
    Private m_Line3 As String
    Private m_Line4 As String
    Private m_Line5 As String
    Private m_Online As String
    Private m_AssrPhone As String
    Private m_StateMillRate As String
    Private m_StateMoney As String
    Public Property DBName() As String
        Get
            Return m_DBName
        End Get
        Set(ByVal Value As String)
            m_DBName = Value
        End Set
    End Property
    Public Property IsRPM() As Boolean
        Get
            Return m_IsRPM
        End Get
        Set(ByVal Value As Boolean)
            m_IsRPM = Value
        End Set
    End Property
    Public Property REFile() As String
        Get
            Return m_REFile
        End Get
        Set(ByVal Value As String)
            m_REFile = Value
        End Set
    End Property
    Public Property PPFile() As String
        Get
            Return m_PPFile
        End Get
        Set(ByVal Value As String)
            m_PPFile = Value
        End Set
    End Property
    Public Property MVFile() As String
        Get
            Return m_MVFile
        End Get
        Set(ByVal Value As String)
            m_MVFile = Value
        End Set
    End Property
    Public Property MSFile() As String
        Get
            Return m_MSFile
        End Get
        Set(ByVal Value As String)
            m_MSFile = Value
        End Set
    End Property
    Public Property NCOAFile() As String
        Get
            Return m_NCOAFile
        End Get
        Set(ByVal Value As String)
            m_NCOAFile = Value
        End Set
    End Property
    Public Property ExportFile() As String
        Get
            Return m_ExportFile
        End Get
        Set(ByVal Value As String)
            m_ExportFile = Value
        End Set
    End Property
  Public Property DueDate1() As Date
    Get
      Return m_DueDate1
    End Get
    Set(ByVal Value As Date)
      m_DueDate1 = Value
    End Set
  End Property
  Public Property DueDate2() As Date
    Get
      Return m_DueDate2
    End Get
    Set(ByVal Value As Date)
      m_DueDate2 = Value
    End Set
  End Property
  Public Property GraceDate1() As Date
    Get
      Return m_GraceDate1
    End Get
    Set(ByVal Value As Date)
      m_GraceDate1 = Value
    End Set
  End Property
  Public Property GraceDate2() As Date
    Get
      Return m_GraceDate2
    End Get
    Set(ByVal Value As Date)
      m_GraceDate2 = Value
    End Set
  End Property
    Public Property TownName() As String
        Get
            Return m_TownName
        End Get
        Set(ByVal Value As String)
            m_TownName = Value
        End Set
    End Property
    Public Property PayTo() As String
        Get
            Return m_PayTo
        End Get
        Set(ByVal Value As String)
            m_PayTo = Value
        End Set
    End Property
    Public Property Line1() As String
        Get
            Return m_Line1
        End Get
        Set(ByVal Value As String)
            m_Line1 = Value
        End Set
    End Property
    Public Property Line2() As String
        Get
            Return m_Line2
        End Get
        Set(ByVal Value As String)
            m_Line2 = Value
        End Set
    End Property
    Public Property Line3() As String
        Get
            Return m_Line3
        End Get
        Set(ByVal Value As String)
            m_Line3 = Value
        End Set
    End Property
    Public Property Line4() As String
        Get
            Return m_Line4
        End Get
        Set(ByVal Value As String)
            m_Line4 = Value
        End Set
    End Property
    Public Property Line5() As String
        Get
            Return m_Line5
        End Get
        Set(ByVal Value As String)
            m_Line5 = Value
        End Set
    End Property
    Public Property Online() As String
        Get
            Return m_Online
        End Get
        Set(ByVal Value As String)
            m_Online = Value
        End Set
    End Property
    Public Property AssrPhone() As String
        Get
            Return m_AssrPhone
        End Get
        Set(ByVal Value As String)
            m_AssrPhone = Value
        End Set
    End Property
    Public Property StateMillRate() As String
        Get
            Return m_StateMillRate
        End Get
        Set(ByVal Value As String)
            m_StateMillRate = Value
        End Set
    End Property
    Public Property StateMoney() As String
        Get
            Return m_StateMoney
        End Get
        Set(ByVal Value As String)
            m_StateMoney = Value
        End Set
    End Property
End Class
