Public Class GetTXMVPCT
  Private m_Type As String
  Private m_Code As String
  Private m_Pct As Decimal
  Private m_Month As Integer

  Public Sub GetTXMVPCT(ByVal In_Type As String, ByVal In_Code As String)
    Dim myTXMVPCT As TXMVPCT.MyData

    myTXMVPCT = New TXMVPCT.MyData(myDBConnect)
    myTXMVPCT.GetOneRecordP(In_Type, In_Code)
    Pct = 0
    Month = 0
    If Not myTXMVPCT.RecordNotFound Then
      With myTXMVPCT
        If ._PCT > 0 Then
          Pct = Format(._PCT, ".###")
        Else
          Pct = 0
        End If
        Month = ._MONTH
      End With
    End If
  End Sub
  Public Property Type() As String
    Get
      Return m_Type
    End Get
    Set(ByVal Value As String)
      m_Type = Value
    End Set
  End Property
  Public Property Code() As String
    Get
      Return m_Code
    End Get
    Set(ByVal Value As String)
      m_Code = Value
    End Set
  End Property
  Public Property Pct() As Decimal
    Get
      Return m_Pct
    End Get
    Set(ByVal Value As Decimal)
      m_Pct = Value
    End Set
  End Property
  Public Property Month() As Integer
    Get
      Return m_Month
    End Get
    Set(ByVal Value As Integer)
      m_Month = Value
    End Set
  End Property

End Class
