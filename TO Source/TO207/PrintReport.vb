Imports System.io
Imports System.Text
Imports System.Xml
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXM59AQ As TXM59AQ.MyData
  Dim myTXMRATE As TXMRATE.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTPAYMNT As TPAYMNT.MyData
  Dim myTXOPM As TXOPM.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dsVets As dsAddVets

  Dim MyAppSettings As AppSettings
  Dim WrkGLYear As Integer
  Dim WrkMillRate As Decimal
  Dim WrkMillRateMV As Decimal
  Dim WrkMillRateSU As Decimal
  Dim WrkTaxLoss As Decimal
  Dim WrkNewCount As Integer
  Dim WrkNewTotal As Integer
  Dim WrkRenewCount As Integer
  Dim WrkRenewTotal As Integer
  'OPM Form 
  Public MyCurAccts As Integer
  Public MyMVAccts As Integer
  Public MyPrvAccts As Integer
  Public MyCurAmt As Integer
  Public MyMVAmt As Integer
  Public MyPrvAmt As Integer
  Public MyCurRevLoss As Decimal
  Public MyMVRevLoss As Decimal
  Public MyPrvRevLoss As Decimal
  Public WrkTown As String
  Public WrkAssrPhone As String
  Public WrkCollPhone As String
  Public WrkAssrEmail As String
  Public WrkCollEmail As String
  Dim WrkPrev As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXM59AQ = New TXM59AQ.MyData(myDBConnect)
    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    myTXOPM = New TXOPM.MyData(myDBConnect)

    With MyFrmTO207B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkPrev = .RbPrev.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetOPMAssr()
    GetOPMColl()
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .Wrkds = ds
      .WrkCurMillRt = WrkMillRate
      .WrkMVMillRt = WrkMillRateMV
      .WrkPrvMillRt = WrkMillRateSU
      .Show()
    End With

  End Sub
  Friend Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("listno", Type.GetType("System.Int32"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("type", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("exemptvet", Type.GetType("System.Int32"))
      .Columns.Add("taxlossvet", Type.GetType("System.Decimal"))
      .Columns.Add("exemptaddl", Type.GetType("System.Int32"))
      .Columns.Add("taxlossaddl", Type.GetType("System.Decimal"))
      .Columns.Add("apptype", Type.GetType("System.String"))
      .Columns.Add("assn", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkYear1 As Integer
    Dim WrkYear2 As Integer
    Dim WrkIsNew As Boolean
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkYear1 = WrkGLYear - 1
    WrkYear2 = WrkGLYear - 2
    If Not WrkPrev Then
      WrkQry = "year = " & WrkGLYear & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE<>'S'"
      WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE='S'"
    Else
      WrkQry = "year = " & WrkGLYear & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE<>'S'"
      WrkQry = WrkQry & WrkOr & "year = " & WrkYear1 & WrkAnd & "ALLOW='Y'"
      WrkQry = WrkQry & WrkOr & "year = " & WrkYear2 & WrkAnd & "ALLOW='Y'" & WrkAnd & "TYPE='S'"
    End If
    WrkSort = "YEAR desc,ALNAME,AFNAME"

    Counter = 0
    'OPM Form
    MyCurAccts = 0
    MyPrvAccts = 0
    MyMVAccts = 0
    MyCurAmt = 0
    MyPrvAmt = 0
    MyMVAmt = 0
    MyCurRevLoss = 0
    MyMVRevLoss = 0
    MyPrvRevLoss = 0
    'Electronic File
    WrkNewCount = 0
    WrkNewTotal = 0
    WrkRenewCount = 0
    WrkRenewTotal = 0
    WrkMillRate = 0
    WrkMillRateMV = 0
    WrkMillRateSU = 0
    WrkTaxLoss = 0

    dsVets = New dsAddVets

    myTXM59AQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTXMRATE.GetOneRecordP(WrkGLYear, "R", 0)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear, "", 0)
    End If
    If Not myTXMRATE.RecordNotFound Then
      WrkMillRate = myTXMRATE._MRRATE * 1000
    End If

    myTXMRATE.GetOneRecordP(WrkGLYear, "M", 0)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear, "", 0)
    End If
    If Not myTXMRATE.RecordNotFound Then
      WrkMillRateMV = myTXMRATE._MRRATE * 1000
    End If

    myTXMRATE.GetOneRecordP(WrkGLYear - 1, "S", 0)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkGLYear - 1, "", 0)
    End If
    If Not myTXMRATE.RecordNotFound Then
      WrkMillRateSU = myTXMRATE._MRRATE * 1000
    End If

ReadNext:
    myTXM59AQ.ReadQry()
    If Not myTXM59AQ.IsEOF Then
      With myTXM59AQ
        If WrkGLYear = myTXM59AQ._YEAR Or (WrkGLYear - 1 = myTXM59AQ._YEAR) And myTXM59AQ._TYPE = "S" Then
          WrkIsNew = True
        Else
          WrkIsNew = False
        End If
        If ._XADDL > 0 Or ._XVET > 0 Then
          If Not WrkIsNew Then
            If CheckDupList("assn=" & ._ASSN) Then
              GoTo NextRec
            End If
          End If
          Counter = Counter + 1
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = ._LISTNO
          dr.Item("year") = ._YEAR
          dr.Item("type") = ._TYPE
          sb = New StringBuilder
          sb.Append(Trim(._ALNAME))
          sb.Append(" ")
          sb.Append(Trim(._AFNAME))
          dr.Item("name") = sb.ToString
          sb = Nothing
          dr.Item("exemptvet") = ._XVET
          dr.Item("taxlossvet") = CalcTaxLoss(._XVET)
          dr.Item("exemptaddl") = ._XADDL
          dr.Item("taxlossaddl") = CalcTaxLoss(._XADDL)
          If WrkIsNew Then
            dr.Item("apptype") = "NEW"
          Else
            dr.Item("apptype") = "RENEWAL"
          End If
          dr.Item("assn") = ._ASSN
          ds.Tables(0).Rows.Add(dr)
          BuildFile(Counter, WrkIsNew)
          'OPM Form
          Select Case Trim(._TYPE)
            Case "R"
              MyCurAccts = MyCurAccts + 1
              MyCurAmt = MyCurAmt + ._XADDL
              MyCurRevLoss = MyCurRevLoss + dr.Item("taxlossaddl")
            Case "M"
              MyMVAccts = MyMVAccts + 1
              MyMVAmt = MyMVAmt + ._XADDL
              MyMVRevLoss = MyMVRevLoss + dr.Item("taxlossaddl")
            Case "S"
              MyPrvAccts = MyPrvAccts + 1
              MyPrvAmt = MyPrvAmt + ._XADDL
              MyPrvRevLoss = MyPrvRevLoss + dr.Item("taxlossaddl")
          End Select
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    If dsVets.Tables("document").Rows.Count > 0 Then
      With dsVets.Tables("document").Rows(0)
        If WrkMillRate > 0 Then
          .Item("millrate") = Format(WrkMillRate, "###.###")
        Else
          .Item("millrate") = 0
        End If
        If WrkMillRate > 0 Then
          .Item("millrate_mv") = Format(WrkMillRateMV, "###.###")
        Else
          .Item("millrate_mv") = 0
        End If
        .Item("new_count") = WrkNewCount
        .Item("new_total") = WrkNewTotal
        .Item("renewal_count") = WrkRenewCount
        .Item("renewal_total") = WrkRenewTotal
        .Item("taxloss") = Format(WrkTaxLoss, "Fixed")
        .Item("towncode") = myTOWN._TOWNBR
      End With
      dsVets.WriteXml(MyFrmTO207B.LblFilePath.Text)
    End If

    myFrmProgress.Close()
    myTXM59AQ.CloseFile()

  End Sub
  Private Function CalcTotal(ByVal Income As Decimal, ByVal Interest As Decimal, ByVal SSRR As Decimal,
  ByVal Other As Decimal)
    Dim WrkTotal As Decimal

    WrkTotal = Income + Interest + SSRR + Other
    Return WrkTotal

  End Function
  Public Sub BuildFile(ByVal Counter As Integer, WrkIsNew As Boolean)
    Dim drDocument As dsAddVets.DocumentRow
    Dim drApp As dsAddVets.AppRow
    Dim drApplicant As dsAddVets.ApplicantRow
    Dim drSpouse As dsAddVets.SpouseRow
    Dim drProperty As dsAddVets._PropertyRow
    Dim drMailing As dsAddVets.MailingRow
    Dim drGeneral As dsAddVets.GeneralRow
    Dim drIncome As dsAddVets.IncomeRow
    Dim drExemption As dsAddVets.ExemptionRow

    If Counter = 1 Then
      drDocument = dsVets.Document.NewDocumentRow
      With drDocument
        .Document_Id = 1
        .millrate = 0
        .millrate_mv = 0
        .new_count = 0
        .new_total = 0
        .renewal_count = 0
        .renewal_total = 0
        .taxloss = 0
        .towncode = 0
        dsVets.Document.AddDocumentRow(drDocument)
      End With
    End If

    If WrkIsNew Then
      WrkNewCount = WrkNewCount + 1
      WrkNewTotal = WrkNewTotal + myTXM59AQ._XADDL
    Else
      WrkRenewCount = WrkRenewCount + 1
      WrkRenewTotal = WrkRenewTotal + myTXM59AQ._XADDL
    End If
    WrkTaxLoss = WrkTaxLoss + CalcTaxLoss(myTXM59AQ._XADDL)

    drApp = dsVets.App.NewAppRow()
    With drApp
      .App_Id = Counter
      .ApplicationYear = myTXM59AQ._YEAR
      .Document_Id = 1
      .GrandListYear = WrkGLYear
      dsVets.App.AddAppRow(drApp)
    End With

    drApplicant = dsVets.Applicant.NewApplicantRow()
    With drApplicant
      .LastName = Trim(myTXM59AQ._ALNAME)
      .FirstName = Trim(myTXM59AQ._AFNAME)
      .Initial = Trim(myTXM59AQ._AINIT)
      .SSN = Format(myTXM59AQ._ASSN, "000000000")
      .App_Id = Counter
      dsVets.Applicant.AddApplicantRow(drApplicant)
    End With

    drSpouse = dsVets.Spouse.NewSpouseRow()
    With drSpouse
      .LastName = Trim(myTXM59AQ._SLNAME)
      .FirstName = Trim(myTXM59AQ._SFNAME)
      .Initial = Trim(myTXM59AQ._SINIT)
      If myTXM59AQ._SSSN > 0 Then
        .SSN = Format(myTXM59AQ._SSSN, "000000000")
      Else
        .SSN = ""
      End If
      .App_Id = Counter
      dsVets.Spouse.AddSpouseRow(drSpouse)
    End With

    drProperty = dsVets._Property.New_PropertyRow()
    With drProperty
      If Trim(myTXM59AQ._LOC) = "" Then
        .Address = Trim(myTXM59AQ._MADDR)
        .City = Trim(myTXM59AQ._MCITY)
        .State = Trim(myTXM59AQ._MSTATE)
        .Zip = Format(myTXM59AQ._MZIP, "00000")
      Else
        .Address = Trim(myTXM59AQ._LOCNO) & " " & Trim(myTXM59AQ._LOC)
        .City = Trim(myTXM59AQ._CITY)
        .State = Trim(myTXM59AQ._STATE)
        .Zip = Format(myTXM59AQ._ZIP, "00000")
      End If
      .App_Id = Counter
      dsVets._Property.Add_PropertyRow(drProperty)
    End With

    drMailing = dsVets.Mailing.NewMailingRow()
    With drMailing
      .Address = Trim(myTXM59AQ._MADDR)
      .City = Trim(myTXM59AQ._MCITY)
      .State = Trim(myTXM59AQ._MSTATE)
      .Zip = Format(myTXM59AQ._MZIP, "00000")
      .App_Id = Counter
      dsVets.Mailing.AddMailingRow(drMailing)
    End With

    drGeneral = dsVets.General.NewGeneralRow()
    With drGeneral
      .ApplicantSigniture = ""
      .ApplicantSignDate = MyUtils.GetDBDate(myTXM59AQ._DTSIGN)
      .AssessorSigniture = ""
      .AssessorSignDate = MyUtils.GetDBDate(myTXM59AQ._DTASSR)
      If myTXM59AQ._RATING = "Y" Then
        .FullyDisabled = True
      Else
        .FullyDisabled = False
      End If
      .MaritalStatus = Trim(myTXM59AQ._FILING)
      .App_Id = Counter
      dsVets.General.AddGeneralRow(drGeneral)
    End With

    drIncome = dsVets.Income.NewIncomeRow()
    With drIncome
      .Gross = myTXM59AQ._INCOME
      ._Non_Taxable = myTXM59AQ._INT
      .Other = myTXM59AQ._OTHER
      .SSRR = myTXM59AQ._SSRR
      .Total = myTXM59AQ._INCOME + myTXM59AQ._INT + myTXM59AQ._OTHER + myTXM59AQ._SSRR
      .App_Id = Counter
      dsVets.Income.AddIncomeRow(drIncome)
    End With

    drExemption = dsVets.Exemption.NewExemptionRow()
    With drExemption
      Select Case myTXM59AQ._TYPE
        Case "M"
          .ExemptionAppliedTo = "Motor_Vehicle"
        Case "R"
          .ExemptionAppliedTo = "Real_Estate"
        Case "S"
          .ExemptionAppliedTo = "Supp_Motor_Vehicle"
      End Select
      .CodeA = myTXM59AQ._XVET
      If myTOWN._TOWNBR = 84 Then 'Milford 
        If myTXM59AQ._XFULL > 0 Or myTXM59AQ._XFULLO > 0 Then
          .Full = myTXM59AQ._XFULL + myTXM59AQ._XFULLO
        Else
          .Full = myTXM59AQ._XADDL + myTXM59AQ._XLOCAL
        End If
        .Used = myTXM59AQ._XADDL + myTXM59AQ._XLOCAL
      Else
        If myTXM59AQ._XFULL > 0 Then
          .Full = myTXM59AQ._XFULL
        Else
          .Full = myTXM59AQ._XADDL
        End If
        .Used = myTXM59AQ._XADDL
      End If
      .App_Id = Counter
      dsVets.Exemption.AddExemptionRow(drExemption)
    End With
  End Sub
  Private Function CalcTaxLoss(ByVal WrkExemption As Decimal) As Decimal
    Dim WrkAmount As Decimal
    Dim WrkTax As Decimal

    Select Case myTXM59AQ._TYPE
      Case "M"
        WrkAmount = WrkExemption * (WrkMillRateMV / 1000)
      Case "R"
        WrkAmount = WrkExemption * (WrkMillRate / 1000)
      Case "S"
        WrkAmount = WrkExemption * (WrkMillRateSU / 1000)
    End Select
    With myTPAYMNT
      .In_Year = myTXM59AQ._YEAR
      .In_Type = myTXM59AQ._TYPE
      .In_Dst = 0
      .In_Phs = ""
      .In_TaxT = WrkAmount
      .CalcPaySplit()
      WrkTax = .Out_TaxT + .Out_Waivered
    End With

    Return WrkTax
  End Function
  Private Function CheckDupList(WrkSelect) As Boolean
    Dim drSel() As DataRow
    drSel = ds.Tables(0).Select(WrkSelect)
    If drSel.GetUpperBound(0) = -1 Then
      Return False
    End If

    Return True
  End Function
  Public Sub GetOPMAssr()

    Dim sb As StringBuilder = New StringBuilder

    WrkAssrPhone = ""
    WrkAssrEmail = ""
    WrkTown = ""
    myTXOPM.GetOneRecordP("A")
    If myTXOPM.RecordNotFound Then Exit Sub

    WrkAssrPhone = Format(myTXOPM._PHONE, "###-###-####")
    If myTXOPM._PHONEX > 0 Then
      WrkAssrPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
    End If

    sb.Append(Trim(myTOWN._TOWN))
    sb.Append(",")
    sb.Append(Trim(myTXOPM._ADDR1))
    sb.Append(",")
    sb.Append(Trim(myTXOPM._CITY))
    sb.Append(",")
    sb.Append(Trim(myTXOPM._STATE))
    sb.Append(" ")
    sb.Append(Format(myTXOPM._ZIP, "00000"))
    If myTXOPM._ZIP4 > 0 Then
      sb.Append("-")
      sb.Append(Format(myTXOPM._ZIP4, "0000"))
    End If
    WrkAssrEmail = Trim(myTXOPM._EMAIL)
    WrkTown = sb.ToString
    sb = Nothing

  End Sub
  Public Sub GetOPMColl()

    Dim sb As StringBuilder = New StringBuilder

    WrkCollPhone = ""
    WrkCollEmail = ""
    myTXOPM.GetOneRecordP("C")
    If myTXOPM.RecordNotFound Then Exit Sub

    WrkCollPhone = Format(myTXOPM._PHONE, "###-###-####")
    If myTXOPM._PHONEX > 0 Then
      WrkCollPhone = WrkAssrPhone & " ext " & myTXOPM._PHONEX
    End If
    WrkCollEmail = Trim(myTXOPM._EMAIL)
  End Sub
End Module






