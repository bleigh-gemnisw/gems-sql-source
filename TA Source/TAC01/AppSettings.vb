Imports System.IO
Public Class AppSettings

    Private m_Company As String
    Private m_Name As Boolean
    Private m_Assmnt As Boolean
    Private m_Acreage As Boolean
    Private m_Exemption As Boolean
    Private m_Other As Boolean
    Private m_Category As Boolean
    Private m_Purchase As Boolean
    Private m_Address As Boolean
    Private m_Add As Boolean
    Private m_PrtDist As Boolean
    Private m_FilePath As String
    Public Property Company() As String
        Get
            Return m_Company
        End Get
        Set(ByVal Value As String)
            m_Company = Value
        End Set
    End Property
    Public Property Name() As Boolean
        Get
            Return m_Name
        End Get
        Set(ByVal Value As Boolean)
            m_Name = Value
        End Set
    End Property
    Public Property Assmnt() As Boolean
        Get
            Return m_Assmnt
        End Get
        Set(ByVal Value As Boolean)
            m_Assmnt = Value
        End Set
    End Property
    Public Property Acreage() As Boolean
        Get
            Return m_Acreage
        End Get
        Set(ByVal Value As Boolean)
            m_Acreage = Value
        End Set
    End Property
    Public Property Exemption() As Boolean
        Get
            Return m_Exemption
        End Get
        Set(ByVal Value As Boolean)
            m_Exemption = Value
        End Set
    End Property
    Public Property Other() As Boolean
        Get
            Return m_Other
        End Get
        Set(ByVal Value As Boolean)
            m_Other = Value
        End Set
    End Property
    Public Property Category() As Boolean
        Get
            Return m_Category
        End Get
        Set(ByVal Value As Boolean)
            m_Category = Value
        End Set
    End Property
    Public Property Purchase() As Boolean
        Get
            Return m_Purchase
        End Get
        Set(ByVal Value As Boolean)
            m_Purchase = Value
        End Set
    End Property
    Public Property Address() As Boolean
        Get
            Return m_Address
        End Get
        Set(ByVal Value As Boolean)
            m_Address = Value
        End Set
    End Property
    Public Property Add() As Boolean
        Get
            Return m_Add
        End Get
        Set(ByVal Value As Boolean)
            m_Add = Value
        End Set
    End Property
    Public Property PrtDist() As Boolean
        Get
            Return m_PrtDist
        End Get
        Set(ByVal Value As Boolean)
            m_PrtDist = Value
        End Set
    End Property
    Public Property FilePath() As String
        Get
            Return m_FilePath
        End Get
        Set(ByVal Value As String)
            m_FilePath = Value
        End Set
    End Property
End Class







