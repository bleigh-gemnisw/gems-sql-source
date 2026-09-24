Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myPKTICKQ As PKTICKQ.MyData
  Dim myPKOFCR As PKOFCR.MyData
  Dim myPKVIOL As PKVIOL.MyData

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkOffcno As String
  Dim WrkViol As Integer
  Dim WrkRegNo As String
  Dim WrkStreet As String
  Dim WrkName As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Public Sub PrtReport()

    myPKTICKQ = New PKTICKQ.MyData(myDBConnect)
    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    With MyFrmPK220B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkOffcno = Trim(.TxtOffcno.Text)
      WrkViol = MyUtils.CnvSng(.TxtViol.Text)
      WrkRegNo = Trim(.TxtRegNo.Text)
      WrkStreet = Trim(.TxtStreet.Text)
      WrkName = Trim(.TxtName.Text)
      If .RbDateViol.Checked Then
        WrkViol = True
      Else
        WrkViol = False
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("TickNo", Type.GetType("System.Int32"))
      .Columns.Add("OfcrName", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Regst", Type.GetType("System.String"))
      .Columns.Add("Vehtyp", Type.GetType("System.String"))
      .Columns.Add("Vdate", Type.GetType("System.DateTime"))
      .Columns.Add("Vtime", Type.GetType("System.String"))
      .Columns.Add("Ampm", Type.GetType("System.String"))
      .Columns.Add("Street", Type.GetType("System.String"))
      .Columns.Add("ViolDesc1", Type.GetType("System.String"))
      .Columns.Add("ViolDesc2", Type.GetType("System.String"))
      .Columns.Add("ViolDesc3", Type.GetType("System.String"))
      .Columns.Add("ViolDesc4", Type.GetType("System.String"))
      .Columns.Add("ViolDesc5", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Addr", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip", Type.GetType("System.String"))
      .Columns.Add("AmtTick", Type.GetType("System.Decimal"))
      .Columns.Add("AmtPaid", Type.GetType("System.Decimal"))
      .Columns.Add("AmtVoid", Type.GetType("System.Decimal"))
      .Columns.Add("AmtLeft", Type.GetType("System.Decimal"))
      .Columns.Add("DtPaid", Type.GetType("System.String"))
      .Columns.Add("PeriodPaid", Type.GetType("System.Decimal"))
      .Columns.Add("Override", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim SaveQry As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    SaveQry = ""
    If WrkOffcno <> "" Then
      If SaveQry = "" Then
        SaveQry = "OFFCNO=" & MyUtils.Quo(WrkOffcno)
      Else
        SaveQry = SaveQry & WrkAnd & "OFFCNO=" & MyUtils.Quo(WrkOffcno)
      End If
    End If

    If WrkRegNo <> "" Then
      If SaveQry = "" Then
        SaveQry = "REGNO=" & MyUtils.Quo(WrkRegNo)
      Else
        SaveQry = SaveQry & WrkAnd & "REGNO=" & MyUtils.Quo(WrkRegNo)
      End If
    End If

    If WrkStreet <> "" Then
      If SaveQry = "" Then
        SaveQry = "STREET=" & MyUtils.Quo(WrkStreet)
      Else
        SaveQry = SaveQry & WrkAnd & "STREET=" & MyUtils.Quo(WrkStreet)
      End If
    End If

    If WrkName <> "" Then
      If SaveQry = "" Then
        SaveQry = "NAME=" & MyUtils.Quo(WrkName)
      Else
        SaveQry = SaveQry & WrkAnd & "NAME=" & MyUtils.Quo(WrkName)
      End If
    End If

    If MyFrmPK220B.RbStatusActive.Checked Then
      If SaveQry = "" Then
        SaveQry = "STATUS<>'L'" & WrkAnd & "STATUS<>'P'" & WrkAnd & "STATUS<>'V'"
      Else
        SaveQry = SaveQry & WrkAnd & "STATUS<>'L'" & WrkAnd & "STATUS<>'P'" & WrkAnd & "STATUS<>'V'"
      End If
    End If

    If MyFrmPK220B.RbDateViol.Checked Then
      If SaveQry <> "" Then
        WrkQry = SaveQry & WrkAnd & "VDATE >= " & WrkFrom & WrkAnd & "VDATE <=" & WrkTo
      Else
        WrkQry = "VDATE >= " & WrkFrom & WrkAnd & "VDATE <=" & WrkTo
      End If
    Else
      If SaveQry <> "" Then
        WrkQry = SaveQry & WrkAnd & "DATE1 >= " & WrkFrom & WrkAnd & "DATE1 <=" & WrkTo &
     WrkOr & SaveQry & WrkAnd & "DATE2 >= " & WrkFrom & WrkAnd & "DATE2 <=" & WrkTo &
     WrkOr & SaveQry & WrkAnd & "DATE3 >= " & WrkFrom & WrkAnd & "DATE3 <=" & WrkTo
      Else
        WrkQry = "DATE1 >= " & WrkFrom & WrkAnd & "DATE1 <=" & WrkTo &
     WrkOr & "DATE2 >= " & WrkFrom & WrkAnd & "DATE2 <=" & WrkTo &
     WrkOr & "DATE3 >= " & WrkFrom & WrkAnd & "DATE3 <=" & WrkTo
      End If
    End If

    WrkSort = ""
    If MyFrmPK220B.RbSortDate.Checked Then
      WrkSort = "VDATE, VTIME"
    End If
    If MyFrmPK220B.RbSortOffcno.Checked Then
      WrkSort = "OFFCNO, VDATE, VTIME"
    End If
    If MyFrmPK220B.RbSortRegNo.Checked Then
      WrkSort = "REGNO, REGST, VDATE, VTIME"
    End If
    If MyFrmPK220B.RbSortStreet.Checked Then
      WrkSort = "STREET, VDATE, VTIME"
    End If
    If MyFrmPK220B.RbSortTickNo.Checked Then
      WrkSort = "TICKNO"
    End If
    If MyFrmPK220B.RbSortViolNo.Checked Then
      WrkSort = "VIOL1, VDATE, VTIME"
    End If
    myPKTICKQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myPKTICKQ.ReadQry()
    If Not myPKTICKQ.IsEOF Then
      With myPKTICKQ
        Counter = Counter + 1
        If WrkViol > 0 Then
          If ._VIOL1 <> WrkViol And ._VIOL2 <> WrkViol And ._VIOL3 <> WrkViol And ._VIOL4 <> WrkViol And ._VIOL5 <> WrkViol Then
            GoTo ReadNext
          End If
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("tickno") = ._TICKNO
        dr.Item("ofcrname") = GetOffcName(._OFFCNO)
        dr.Item("regno") = Trim(._REGNO)
        dr.Item("regst") = Trim(._REGST)
        dr.Item("vehtyp") = Trim(._VEHTYP)
        dr.Item("vdate") = MyUtils.GetDBDate(._VDATE)
        dr.Item("vtime") = Format(._VTIME, "##:##")
        dr.Item("ampm") = Trim(._AMPM)
        dr.Item("street") = Trim(._STREET)
        If WrkViol = 0 Then
          dr.Item("violdesc1") = GetViolDesc(._VIOL1)
          dr.Item("violdesc2") = GetViolDesc(._VIOL2)
          dr.Item("violdesc3") = GetViolDesc(._VIOL3)
          dr.Item("violdesc4") = GetViolDesc(._VIOL4)
          dr.Item("violdesc5") = GetViolDesc(._VIOL5)
        Else
          If WrkViol = ._VIOL1 Then
            dr.Item("violdesc1") = GetViolDesc(._VIOL1)
          End If
          If WrkViol = ._VIOL2 Then
            dr.Item("violdesc1") = GetViolDesc(._VIOL2)
          End If
          If WrkViol = ._VIOL3 Then
            dr.Item("violdesc1") = GetViolDesc(._VIOL3)
          End If
          If WrkViol = ._VIOL4 Then
            dr.Item("violdesc1") = GetViolDesc(._VIOL4)
          End If
          If WrkViol = ._VIOL5 Then
            dr.Item("violdesc1") = GetViolDesc(._VIOL5)
          End If
          dr.Item("violdesc2") = ""
          dr.Item("violdesc3") = ""
          dr.Item("violdesc4") = ""
          dr.Item("violdesc5") = ""
        End If
        dr.Item("name") = Trim(._NAME)
        dr.Item("addr") = Trim(._ADDR)
        dr.Item("city") = Trim(._CITY)
        dr.Item("state") = Trim(._STATE)
        If ._ZIP <> "00000" Then
          dr.Item("zip") = Trim(._ZIP)
        End If
        dr.Item("amttick") = CalcAmtTick()
        dr.Item("amtpaid") = ._AMT1 + ._AMT2 + ._AMT3
        dr.Item("amtvoid") = CalcAmtVoid()
        dr.Item("amtleft") = dr.Item("amttick") - dr.Item("amtpaid") - dr.Item("amtvoid")
        If ._DATE1 > 0 Then
          dr.Item("dtpaid") = Format(MyUtils.GetDBDate(._DATE1).Date, "M/dd/yy")
        Else
          dr.Item("dtpaid") = ""
        End If
        dr.Item("periodpaid") = 0
        If MyFrmPK220B.RbDateRec.Checked Then
          If ._DATE1 >= WrkFrom And ._DATE1 <= WrkTo Then
            dr.Item("periodpaid") = ._AMT1
          End If
          If ._DATE2 >= WrkFrom And ._DATE2 <= WrkTo Then
            dr.Item("periodpaid") = dr.Item("periodpaid") & ._AMT2
          End If
          If ._DATE3 >= WrkFrom And ._DATE3 <= WrkTo Then
            dr.Item("periodpaid") = dr.Item("periodpaid") & ._AMT3
          End If
        End If
        Select Case Trim(._STATUS)
          Case "L"
            dr.Item("override") = "Override Late"
          Case "O"
            dr.Item("override") = "Orig Paid"
          Case "V"
            dr.Item("override") = "Void"
          Case Else
            dr.Item("override") = ""
        End Select
        ds.Tables(0).Rows.Add(dr)
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

    myFrmProgress.Close()
    myPKTICKQ.CloseFile()

  End Sub
  Public Function GetOffcName(ByVal Code As String) As String
    Dim myPKOFCR As PKOFCR.MyData

    myPKOFCR = New PKOFCR.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myPKOFCR.GetOneRecordP(Code)
    If Not myPKOFCR.RecordNotFound Then
      GetOffcName = Trim(myPKOFCR._OFNAM)
    Else
      GetOffcName = ""
    End If
    Return GetOffcName

  End Function
  Public Function GetViolDesc(ByVal Code As Integer) As String
    Dim myPKVIOL As PKVIOL.MyData

    myPKVIOL = New PKVIOL.MyData(myDBConnect)
    If IsNothing(Code) Or Code = 0 Then
      Return ""
    End If

    myPKVIOL.GetOneRecordP(Code)
    If Not myPKVIOL.RecordNotFound Then
      GetViolDesc = Trim(myPKVIOL._DESCR)
    Else
      GetViolDesc = Code & "-" & "*** Unknown ***"
    End If
    Return GetViolDesc
  End Function
  Private Function CalcAmtTick() As Decimal
    Dim WrkAmt As Decimal
    Dim WrkDays As Integer

    WrkAmt = myPKTICKQ._VIAMT
    If myPKTICKQ._DATE1 > 0 Then
      WrkDays = DateDiff(DateInterval.Day, MyUtils.GetDBDate(myPKTICKQ._VDATE), MyUtils.GetDBDate(myPKTICKQ._DATE1))
    Else
      WrkDays = DateDiff(DateInterval.Day, MyUtils.GetDBDate(myPKTICKQ._VDATE), Date.Now)
    End If
    If myPKTICKQ._STATUS <> "V" Then
      If WrkDays >= 7 Then
        WrkAmt = WrkAmt * 2
      End If
    End If
    Return WrkAmt
  End Function
  Private Function CalcAmtVoid() As Decimal
    Dim WrkAmt As Decimal
    Dim WrkDays As Integer

    WrkAmt = myPKTICKQ._VIAMT
    If myPKTICKQ._DATE1 > 0 Then
      WrkDays = DateDiff(DateInterval.Day, MyUtils.GetDBDate(myPKTICKQ._VDATE), MyUtils.GetDBDate(myPKTICKQ._DATE1))
    Else
      WrkDays = DateDiff(DateInterval.Day, MyUtils.GetDBDate(myPKTICKQ._VDATE), Date.Now)
    End If
    Select Case Trim(myPKTICKQ._STATUS)
      Case "V"
      Case "L"
        If WrkDays >= 7 Then
          WrkAmt = WrkAmt * 2
        End If
        WrkAmt = WrkAmt - myPKTICKQ._AMT1 - -myPKTICKQ._AMT2 - myPKTICKQ._AMT3
      Case Else
        WrkAmt = 0
    End Select
    Return WrkAmt
  End Function

End Module
