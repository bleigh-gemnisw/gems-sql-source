Imports System.Text
Public Class ImportFile
  Private m_StrBuffer As String
  Private m_Fdnbr As Integer
  Private m_Sfund As Integer
  Private m_Dpnbr As Integer
  Private m_Obnbr As Integer
  Private m_Fnpgm As Integer
  Private m_Subfn As Integer
  Private m_Trntyp As String
  Private m_Amt As Decimal
  Private m_Amttyp As String
  Private m_Mapped As Boolean
  Private m_TotCR As Decimal
  Private m_TotDR As Decimal
  Private m_Jact8 As Integer
  Private m_Jent8 As Integer
  Private m_Jrnseq As Integer
  Private m_Refno As Integer
  Private m_Descr As String
  Public Sub ReadJournal(ByVal WrkBatchType As String)
    Dim sArray As String()
    Dim WrkFund As Integer
    Dim WrkSFund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim WrkDbDate As Integer
    Dim Pos As Integer
    Dim WrkStr As String

    If Trim(StrBuffer) = "" Then
      Amt = 0
      Exit Sub
    End If

    sArray = Parse(StrBuffer, ",")
    If Trim(StrBuffer) = "" Or MyUtils.CnvSng(sArray(2)) = 0 And MyUtils.CnvSng(sArray(3)) = 0 Then
      Amt = 0
      Exit Sub
    End If

    BreakAcct(sArray(0), WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    Fdnbr = WrkFund
    Sfund = WrkSFund
    Dpnbr = WrkDpnbr
    Obnbr = WrkObnbr
    Fnpgm = WrkFnpgm
    Subfn = WrkSubfn
    If WrkBatchType = "GL" Then
      Trntyp = "X"
    Else
      Trntyp = "B"
    End If
    Descr = Mid(sArray(1), 1, 20) & ""
    Descr = Replace(Descr, "'", "")
    If MyUtils.CnvSng(sArray(2)) > 0 Then
      Amt = MyUtils.CnvSng(sArray(2))
      Amttyp = "D"
      TotCR = 0
      TotDR = MyUtils.CnvSng(sArray(2))
    Else
      Amt = MyUtils.CnvSng(sArray(3))
      Amttyp = "C"
      TotCR = MyUtils.CnvSng(sArray(3))
      TotDR = 0
    End If
    Pos = InStr(sArray(4), "/")
    If Pos = 0 Then
      WrkStr = Mid(sArray(4), 1, 2) & "/" & Mid(sArray(4), 3, 2) & "/" & Mid(sArray(4), 5, 4)
    Else
      WrkStr = sArray(4)
    End If
    If IsDate(WrkStr) Then
      WrkDbDate = MyUtils.SetDBDate(WrkStr)
    Else
      WrkDbDate = MyUtils.SetDBDate(Date.Today)
    End If
    Jact8 = WrkDbDate
    Jent8 = WrkDbDate
    Jrnseq = 0
    Refno = 0
  End Sub
  Public Sub ReadPayroll()
    Dim sArray As String()
    Dim WrkDate As String

    sArray = Parse(StrBuffer, ",")
    If MyUtils.CnvSng(sArray(7)) = 0 And MyUtils.CnvSng(sArray(8)) = 0 Then
      Amt = 0
      Exit Sub
    End If
    Fdnbr = sArray(2)
    Sfund = 0
    Dpnbr = sArray(3)
    Obnbr = sArray(4)
    Fnpgm = sArray(5)
    Subfn = sArray(6)
    Trntyp = "X"
    Descr = sArray(10)
    Descr = Replace(Descr, "'", "")
    If sArray(7) > 0 Then
      Amt = sArray(7)
      Amttyp = "D"
      TotCR = 0
      TotDR = sArray(7)
    Else
      Amt = sArray(8)
      Amttyp = "C"
      TotCR = sArray(8)
      TotDR = 0
    End If
    If Len(sArray(1)) = 5 Then
      WrkDate = "20" & Mid(sArray(1), 4, 2) & "0" & Mid(sArray(1), 1, 3)
    Else
      WrkDate = "20" & Mid(sArray(1), 5, 2) & Mid(sArray(1), 1, 4)
    End If
    Jact8 = WrkDate
    Jent8 = WrkDate
    Jrnseq = sArray(0)
    Refno = sArray(9)
  End Sub
  Public Sub ReadPayrollPaycor()
    Dim sArray As String()
    Dim WrkFund As Integer
    Dim WrkSFund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim WrkDbDate As Integer

    sArray = Parse(StrBuffer, ",")
    If MyUtils.CnvSng(sArray(2)) = 0 And MyUtils.CnvSng(sArray(3)) = 0 Then
      Amt = 0
      Exit Sub
    End If
    BreakAcct(sArray(0), WrkFund, WrkSFund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    Fdnbr = WrkFund
    Sfund = WrkSFund
    Dpnbr = WrkDpnbr
    Obnbr = WrkObnbr
    Fnpgm = WrkFnpgm
    Subfn = WrkSubfn
    Trntyp = "X"
    Descr = Mid(sArray(1), 1, 20)
    Descr = Replace(Descr, "'", "")
    If MyUtils.CnvSng(sArray(2)) > 0 Then
      Amt = MyUtils.CnvSng(sArray(2))
      Amttyp = "D"
      TotCR = 0
      TotDR = MyUtils.CnvSng(sArray(2))
    Else
      Amt = MyUtils.CnvSng(sArray(3))
      Amttyp = "C"
      TotCR = MyUtils.CnvSng(sArray(3))
      TotDR = 0
    End If
    WrkDbDate = MyUtils.SetDBDate(sArray(4))
    Jact8 = WrkDbDate
    Jent8 = WrkDbDate
    Jrnseq = 0
    Refno = 0
  End Sub
  Public Property StrBuffer() As String
    Get
      Return m_StrBuffer
    End Get
    Set(ByVal Value As String)
      m_StrBuffer = Value
    End Set
  End Property
  Public Property Fdnbr() As Integer
    Get
      Return m_Fdnbr
    End Get
    Set(ByVal Value As Integer)
      m_Fdnbr = Value
    End Set
  End Property
  Public Property Sfund() As Integer
    Get
      Return m_Sfund
    End Get
    Set(ByVal Value As Integer)
      m_Sfund = Value
    End Set
  End Property
  Public Property Dpnbr() As Integer
    Get
      Return m_Dpnbr
    End Get
    Set(ByVal Value As Integer)
      m_Dpnbr = Value
    End Set
  End Property
  Public Property Obnbr() As Integer
    Get
      Return m_Obnbr
    End Get
    Set(ByVal Value As Integer)
      m_Obnbr = Value
    End Set
  End Property
  Public Property Fnpgm() As Integer
    Get
      Return m_Fnpgm
    End Get
    Set(ByVal Value As Integer)
      m_Fnpgm = Value
    End Set
  End Property
  Public Property Subfn() As Integer
    Get
      Return m_Subfn
    End Get
    Set(ByVal Value As Integer)
      m_Subfn = Value
    End Set
  End Property
  Public Property Mapped() As Boolean
    Get
      Return m_Mapped
    End Get
    Set(ByVal Value As Boolean)
      m_Mapped = Value
    End Set
  End Property
  Public Property Trntyp() As String
    Get
      Return m_Trntyp
    End Get
    Set(ByVal Value As String)
      m_Trntyp = Value
    End Set
  End Property
  Public Property Amt() As Decimal
    Get
      Return m_Amt
    End Get
    Set(ByVal Value As Decimal)
      m_Amt = Value
    End Set
  End Property
  Public Property Amttyp() As String
    Get
      Return m_Amttyp
    End Get
    Set(ByVal Value As String)
      m_Amttyp = Value
    End Set
  End Property
  Public Property TotCR() As Decimal
    Get
      Return m_TotCR
    End Get
    Set(ByVal Value As Decimal)
      m_TotCR = Value
    End Set
  End Property
  Public Property TotDR() As Decimal
    Get
      Return m_TotDR
    End Get
    Set(ByVal Value As Decimal)
      m_TotDR = Value
    End Set
  End Property
  Public Property Jact8() As Integer
    Get
      Return m_Jact8
    End Get
    Set(ByVal Value As Integer)
      m_Jact8 = Value
    End Set
  End Property
  Public Property Jent8() As Integer
    Get
      Return m_Jent8
    End Get
    Set(ByVal Value As Integer)
      m_Jent8 = Value
    End Set
  End Property
  Public Property Jrnseq() As Integer
    Get
      Return m_Jrnseq
    End Get
    Set(ByVal Value As Integer)
      m_Jrnseq = Value
    End Set
  End Property
  Public Property Refno() As Integer
    Get
      Return m_Refno
    End Get
    Set(ByVal Value As Integer)
      m_Refno = Value
    End Set
  End Property
  Public Property Descr() As String
    Get
      Return m_Descr
    End Get
    Set(ByVal Value As String)
      m_Descr = Value
    End Set
  End Property
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder

    If Len(In_Acct) = 26 Then
      Out_Fund = Mid(In_Acct, 1, 3)
      Out_SFund = Mid(In_Acct, 5, 3)
      Out_Dept = Mid(In_Acct, 9, 4)
      Out_Obj = Mid(In_Acct, 14, 3)
      Out_Func = Mid(In_Acct, 18, 4)
      Out_Subfn = Mid(In_Acct, 23, 4)
    Else
      Out_Fund = 0
      Out_SFund = 0
      Out_Dept = 0
      Out_Obj = 0
      Out_Func = 0
      Out_Subfn = 0
    End If
  End Sub
  Public Sub CheckGlMap()
    Dim ds2 As DataSet = New DataSet
    Dim WrkDescr As String
    Dim myPRGLMAP As PRGLMAP.MyData
    myPRGLMAP = New PRGLMAP.MyData(myDBConnect)

    Mapped = False
    ds2 = myPRGLMAP.GetAcctAll(Fdnbr, Sfund, Dpnbr, Obnbr, Fnpgm, Subfn)
    WrkDescr = Descr
    If ds2.Tables(0).Rows.Count = 1 Then
      WrkDescr = ""
    End If
    myPRGLMAP.GetOneRecordP(Fdnbr, Sfund, Dpnbr, Obnbr, Fnpgm, Subfn, WrkDescr)

    If Not myPRGLMAP.RecordNotFound Then
      Mapped = True
      With myPRGLMAP
        If Amttyp = "D" Then
          Fdnbr = ._DFUND
          Sfund = ._DSFUND
          Dpnbr = ._DDEPT
          Obnbr = ._DOBJ
          Fnpgm = ._DFUNC
          Subfn = ._DSFUNC
        Else
          Fdnbr = ._CFUND
          Sfund = ._CSFUND
          Dpnbr = ._CDEPT
          Obnbr = ._COBJ
          Fnpgm = ._CFUNC
          Subfn = ._CSFUNC
        End If
      End With
    End If

  End Sub
End Class
