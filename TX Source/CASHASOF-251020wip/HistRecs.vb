Public Class HistRecs
  Public Sub New()
  End Sub
  Private mTotRec As Decimal
  Public Property TotRec() As Decimal
    Get
      Return mTotRec
    End Get
    Set(ByVal value As Decimal)
      mTotRec = value
    End Set
  End Property

  Private mTotBondRec As Decimal
  Public Property TotBondRec() As Decimal
    Get
      Return mTotBondRec
    End Get
    Set(ByVal value As Decimal)
      mTotBondRec = value
    End Set
  End Property

  Private mTotIntPaid As Decimal
  Public Property TotIntPaid() As Decimal
    Get
      Return mTotIntPaid
    End Get
    Set(ByVal value As Decimal)
      mTotIntPaid = value
    End Set
  End Property

  Private mLienPaid As Decimal
  Public Property LienPaid() As Decimal
    Get
      Return mLienPaid
    End Get
    Set(ByVal value As Decimal)
      mLienPaid = value
    End Set
  End Property

  Private mIntPartialPaid As Decimal
  Public Property IntPartialPaid() As Decimal
    Get
      Return mIntPartialPaid
    End Get
    Set(ByVal value As Decimal)
      mIntPartialPaid = value
    End Set
  End Property

  ' Arrays for dates and flags
  Private mIntDate(3) As Date
  Public Property IntDate() As Date()
    Get
      Return mIntDate
    End Get
    Set(ByVal value As Date())
      mIntDate = value
    End Set
  End Property

  Private mPrinPd(3) As Boolean
  Public Property PrinPd() As Boolean()
    Get
      Return mPrinPd
    End Get
    Set(ByVal value As Boolean())
      mPrinPd = value
    End Set
  End Property

  Private mIntCollect(3) As Boolean
  Public Property IntCollect() As Boolean()
    Get
      Return mIntCollect
    End Get
    Set(ByVal value As Boolean())
      mIntCollect = value
    End Set
  End Property
  Private mAdjFnd As Boolean
  Public Property AdjFnd() As Boolean
    Get
      Return mAdjFnd
    End Get
    Set(ByVal value As Boolean)
      mAdjFnd = value
    End Set
  End Property
  Private mAdjAmt As Decimal
  Public Property AdjAmt() As Decimal
    Get
      Return mAdjAmt
    End Get
    Set(ByVal value As Decimal)
      mAdjAmt = value
    End Set
  End Property

  Private mMethod As String
  Public Property Method() As String
    Get
      Return mMethod
    End Get
    Set(ByVal value As String)
      mMethod = value
    End Set
  End Property

  Private mOutIntDate As Date
  Public Property OutIntDate() As Date
    Get
      Return mOutIntDate
    End Get
    Set(ByVal value As Date)
      mOutIntDate = value
    End Set
  End Property
End Class

