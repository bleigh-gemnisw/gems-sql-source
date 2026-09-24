Public Class Common2

  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData
  Dim myDEPSEC As DEPSEC.MyData

  Public Function GetDepSec(ByVal WrkFund As Integer, WrkSfund As Integer, WrkDept As Integer) As Boolean
    myDEPSEC = New DEPSEC.MyData()
    myDEPSEC.MyDBConn = myDBConnect
    With myDEPSEC
      .GetOneRecordP(MyUserID, 0, 0, 0)
      If .RecordNotFound Then
        .GetOneRecordP(MyUserID, WrkFund, WrkSfund, 0)
        If .RecordNotFound Then
          .GetOneRecordP(MyUserID, WrkFund, WrkSfund, WrkDept)
        End If
      End If
      If .RecordNotFound Then
        Return False
      Else
        Return True
      End If
    End With
  End Function
  Public Function GetLedger(ByVal IsLedger As Boolean, ByVal GLType As String, ByVal Fdnbr As Integer, ByVal Sfund As Integer,
   ByVal Dpnbr As Integer, ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer, ByVal Strdt As Integer,
   ByVal Enddt As Integer) As DataSet

    Dim ds As DataSet = New DataSet
    Dim dsDetail As DataSet = New DataSet
    Dim dr As DataRow
    Dim Tramt As Decimal
    Dim Encumbered As Decimal
    Dim LiqEnc As Decimal
    Dim WrkBalance As Decimal
    Dim I As Integer

    If IsLedger Then
      myLEDGERL1 = New LEDGERL1.MyData()
      myLEDGERL1.MyDBConn = myDBConnect
    Else
      myLEDHSTL1 = New LEDHSTL1.MyData()
      myLEDHSTL1.MyDBConn = myDBConnect
    End If

    If dsDetail.Tables.Count = 0 Then
      BuildDS(dsDetail)
    Else
      dsDetail.Clear()
    End If

    WrkBalance = 0
    Budget = 0
    Expenses = 0
    Encumbered = 0
    LiqEnc = 0
    If IsLedger Then
      ds = myLEDGERL1.GetAllAcct(Fdnbr, Sfund, Dpnbr, Obnbr, Fnpgm, Subfn, Strdt, Enddt)
    Else
      ds = myLEDHSTL1.GetAllAcct(Fdnbr, Sfund, Dpnbr, Obnbr, Fnpgm, Subfn, Strdt, Enddt)
    End If

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If .Item("amtyp") = "D" Then
          Tramt = .Item("tramt")
        Else
          Tramt = .Item("tramt") * -1
        End If
        Select Case .Item("trtyp")
          Case "B"
            Budget = Budget + Tramt
          Case "E"
            If .Item("amtyp") = "D" Then
              Encumbered = Encumbered + .Item("tramt")
            Else
              LiqEnc = LiqEnc + .Item("tramt")
            End If
          Case "X"
            Expenses = Expenses + Tramt
        End Select

        dr = dsDetail.Tables(0).NewRow
        dr.Item("date") = MyUtils.GetDBDate(.Item("pstdt"))
        dr.Item("description") = .Item("tdesc")
        dr.Item("ref") = .Item("refno")
        Select Case .Item("srcde")
          Case "1"
            dr.Item("source") = "A/P"
            dr.Item("lookupkey") = .Item("invnr")
          Case "2"
            dr.Item("source") = "J/E"
            dr.Item("lookupkey") = .Item("trnbr")
          Case "3"
            dr.Item("source") = "A/R"
            dr.Item("lookupkey") = .Item("bchno")
            dr.Item("prf") = .Item("prf")
          Case "4"
            dr.Item("source") = "P/O"
            dr.Item("lookupkey") = .Item("ponbr")
          Case "5"
            dr.Item("source") = "P/R"
            dr.Item("lookupkey") = .Item("bchno")
          Case "6"
            dr.Item("source") = "Tax"
            dr.Item("lookupkey") = .Item("bchno")
        End Select
        Select Case .Item("trtyp")
          Case "B"
            WrkBalance = WrkBalance + Tramt
          Case "E"
            dr.Item("encumbrance") = Tramt
            WrkBalance = WrkBalance - Tramt
          Case "X"
            dr.Item("expended") = Tramt
            If GLType = "A" Or GLType = "L" Then
              WrkBalance = WrkBalance + Tramt
            Else
              WrkBalance = WrkBalance - Tramt
            End If
        End Select
        dr.Item("balance") = WrkBalance
        dr.Item("bchno") = .Item("bchno")
        dsDetail.Tables(0).Rows.Add(dr)
      End With
    Next

    Select Case GLType
      Case "Revenue"
        Unencumbered = Budget - Expenses
        UnliqEnc = 0
      Case Else
        UnliqEnc = Encumbered - LiqEnc
        Unencumbered = Budget - UnliqEnc - Expenses
    End Select
    Return dsDetail
  End Function
  Friend Sub BuildDS(ByRef ds As DataSet)
 Dim myTable As New DataTable

 With myTable
  .TableName = "mytable"
  .Columns.Add("Date", Type.GetType("System.DateTime"))
  .Columns.Add("Description", Type.GetType("System.String"))
  .Columns.Add("Ref", Type.GetType("System.Int32"))
  .Columns.Add("Source", Type.GetType("System.String"))
  .Columns.Add("Encumbrance", Type.GetType("System.Decimal"))
  .Columns.Add("Expended", Type.GetType("System.Decimal"))
  .Columns.Add("Balance", Type.GetType("System.Decimal"))
  .Columns.Add("LookupKey", Type.GetType("System.String"))
  .Columns.Add("Prf", Type.GetType("System.String"))
  .Columns.Add("Bchno", Type.GetType("System.Int32"))
 End With
 ds.Tables.Add(myTable)
End Sub
 Private mvarBudget As Decimal
 Public Property Budget() As Decimal
  Get
   Budget = mvarBudget
  End Get
  Set(ByVal Value As Decimal)
   mvarBudget = Value
  End Set
 End Property
 Private mvarExpenses As Decimal
 Public Property Expenses() As Decimal
  Get
   Expenses = mvarExpenses
  End Get
  Set(ByVal Value As Decimal)
   mvarExpenses = Value
  End Set
 End Property
 Private mvarUnencumbered As Decimal
 Public Property Unencumbered() As Decimal
  Get
   Unencumbered = mvarUnencumbered
  End Get
  Set(ByVal Value As Decimal)
   mvarUnencumbered = Value
  End Set
 End Property
 Private mvarUnliqEnc As Decimal
 Public Property UnliqEnc() As Decimal
  Get
   UnliqEnc = mvarUnliqEnc
  End Get
  Set(ByVal Value As Decimal)
   mvarUnliqEnc = Value
  End Set
 End Property
End Class
