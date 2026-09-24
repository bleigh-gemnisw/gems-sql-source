Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXPPRPC As TXPPRPC.MyData
  Dim myTXMVDC As TXMVDC.MyData
  Dim myTXSUPP As TXSupp.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkPost As Boolean
  Dim WrkIntDate As Date
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkSortBy As String
  Dim WrkMaxRecs As Integer
  'BUffer MV/SUPP
  Dim WrkList(100000) As Integer
  Dim WrkPCust(100000) As Integer
  Dim WrkSCust(100000) As Integer
  Dim WrkDesc(100000) As String
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXMVDC = New TXMVDC.MyData(myDBConnect)
    myTXPPRPC = New TXPPRPC.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXSUPP = New TXSupp.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTXE15B
      If .RbMV.Checked Then WrkType = "M"
      If .RbPP.Checked Then WrkType = "P"
      If .RbRE.Checked Then WrkType = "R"
      If .RbSU.Checked Then WrkType = "S"
      MyType = WrkType
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkPost = .Chkupdatebacktax.Checked
      WrkIntDate = .DtPckInt.Value
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    If WrkType = "M" Then
      BufferMvdCustID()
    End If
    If WrkType = "S" Then
      BufferSuppCustID()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Mlistno", Type.GetType("System.Int32"))

    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkListNo As Integer
    Dim WrkCustID As Integer
    Dim WrkInterest As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkFee As Decimal
    Dim WrkBond As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal
    Dim SaveQry As String
    Dim SaveListNo As Integer
    Dim SaveCustID As Integer
    Dim SaveRegNo As String

    Counter = 0
    WrkSortBy = "Name"
    SaveListNo = 0
    SaveRegNo = ""
    MyTypeD = GetTXTypeDesc(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = ""
    Select Case WrkType
      Case "R", "P"
        WrkSort = "LIST#"
      Case "M", "S"
        WrkSort = "SS#"
    End Select

    WrkQry = "icode<>'I'" & WrkAnd & "BALD > 0"
    WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear
    If WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR <= " & WrkToYear
    End If
    If WrkType = "M" Or WrkType = "S" Then
      SaveQry = WrkQry
      WrkQry = SaveQry & WrkAnd & "SS# > 0"
    Else
      WrkQry = WrkQry & WrkAnd & "TYPE =" & MyUtils.Quo(WrkType)
    End If


    'MsgBox(WrkQry, MsgBoxStyle.Information, "")
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        WrkDue = 0
        Counter = Counter + 1
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkInterestPaid,
      WrkFee, WrkLien, WrkBond, WrkTax, WrkDue)
        'Filter - Omit no amount due 
        If WrkDue = 0 Then
          GoTo NextRec
        End If

        WrkListNo = ._LISTNo
        WrkCustID = ._SSNo
      End With

      Select Case WrkType
        Case "R"
          If WrkListNo <> SaveListNo Then
            myTXREALC.GetOneRecordP(WrkListNo)
            If Not myTXREALC.RecordNotFound Then
              WriteDs(0, "")
              If WrkPost = True Then
                myTXREALC._BTC = "BT"
                myTXREALC.UpdateOneRecordP()
              End If
            End If
            SaveListNo = WrkListNo
          End If
        Case "M"
          If WrkCustID <> SaveCustID Then
            GET_mv()
          End If
          SaveCustID = WrkCustID
        Case "P"
          If WrkListNo <> SaveListNo Then
            myTXPPRPC.GetOneRecordP(WrkListNo)
            If Not myTXPPRPC.RecordNotFound Then
              WriteDs(0, "")
              If WrkPost = True Then
                myTXPPRPC._BTC = "BT"
                myTXPPRPC.UpdateOneRecordP()
              End If
            End If
          End If
        Case "S"
          If WrkCustID <> SaveCustID Then
            GET_sup()
          End If
          SaveCustID = WrkCustID
      End Select

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
    myTXINVQ.CloseFile()

  End Sub

  Private Sub WriteDs(ByVal MListNo As Integer, MDesc As String)
    Dim WrkType As String

    With myTXINVQ
      WrkType = ._TYPE
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("name") = ._NAME
      If WrkType = "R" Or WrkType = "P" Then
        dr.Item("Desc") = Trim(._LOCNo) + " " + Trim(._LOC)
      Else
        dr.Item("Desc") = Trim(MDesc)
      End If
      dr.Item("mlistno") = MListNo
    End With

    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub GET_mv()
    Dim I As Integer

    For I = 0 To WrkPCust.GetUpperBound(0)
      If WrkPCust(I) = 0 Then Exit For
      If WrkPCust(I) = myTXINVQ._SSNo Or WrkPCust(I) = myTXINVQ._SS2 Or
   (WrkSCust(I) > 0 And WrkSCust(I) = myTXINVQ._SSNo) Or (WrkSCust(I) > 0 And WrkSCust(I) = myTXINVQ._SS2) Then
        myTXMVDC.GetOneRecordP(WrkList(I))
        If Not myTXMVDC.RecordNotFound Then
          WriteDs(WrkList(I), WrkDesc(I))
          If WrkPost = True Then
            myTXMVDC._BTC = "BT"
            myTXMVDC.UpdateOneRecordP()
          End If
        End If
      End If
    Next
  End Sub
  Private Sub GET_sup()
    Dim I As Integer

    For I = 0 To WrkPCust.GetUpperBound(0)
      If WrkPCust(I) = 0 Then Exit For
      If WrkPCust(I) = myTXINVQ._SSNo Or WrkPCust(I) = myTXINVQ._SS2 Or
   (WrkSCust(I) > 0 And WrkSCust(I) = myTXINVQ._SSNo) Or (WrkSCust(I) > 0 And WrkSCust(I) = myTXINVQ._SS2) Then
        myTXSUPP.GetOneRecordP(WrkList(I))
        If Not myTXSUPP.RecordNotFound Then
          WriteDs(WrkList(I), WrkDesc(I))
          If WrkPost = True Then
            myTXSUPP._BTC = "BT"
            myTXSUPP.UpdateOneRecordP()
          End If
        End If
      End If
    Next
  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
    ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
    End With
  End Sub
  Private Sub BufferMvdCustID()
    Dim I As Integer
    Dim J As Integer

    Dim myTXMVDC As TXMVDC.MyData
    Dim ds2 As DataSet = New DataSet

    myTXMVDC = New TXMVDC.MyData(myDBConnect)

    ds2 = myTXMVDC.PosData(0)
    WrkMaxRecs = ds.Tables(0).Rows.Count
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("ss#") > 0 And Trim(.Item("lease")) = "" Then
          WrkList(J) = .Item("list#")
          WrkPCust(J) = .Item("ss#")
          WrkSCust(J) = .Item("ss2")
          WrkDesc(J) = .Item("regno") & " " & .Item("name") & " " & .Item("vinno")
          J = J + 1
        End If
      End With
    Next

  End Sub
  Private Sub BufferSuppCustID()
    Dim I As Integer
    Dim J As Integer

    Dim myTXSUPP As TXSupp.MyData
    Dim ds2 As DataSet = New DataSet

    myTXSUPP = New TXSupp.MyData(myDBConnect)
    ds2 = myTXSUPP.PosData(0)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("ss#") > 0 Then
          WrkList(J) = .Item("list#")
          WrkPCust(J) = .Item("ss#")
          WrkSCust(J) = .Item("ss2")
          WrkDesc(J) = .Item("regno") & " " & .Item("name") & " " & .Item("vinno")
          J = J + 1
        End If
      End With
    Next

  End Sub
End Module






