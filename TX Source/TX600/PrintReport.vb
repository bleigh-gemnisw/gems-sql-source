Imports System.Text
Imports System.IO
Module PrintReport

  'To do: Remove hard coding by adding sheriff credit/debit accts in MUNGL file
  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myNETGLBCH As NETGLBCHQ.MyData
  Dim myTXMRATE As TXMRATE.MyData
  Dim myMUNGL As MUNGL.myData
  Dim myDBUtils As DBUtils.Utils

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen
  Dim WrkCurrYear As Integer
  Dim WrkCurrYearSU As Integer
  Dim WrkBatch As Integer
  Dim WrkLockbox As Boolean
  Dim WrkFile As Boolean
  'Report
  Dim WrkPostDate As Date
  'Totals
  Dim WrkTCurrTax As Decimal
  Dim WrkTCurrTaxSU As Decimal
  Dim WrkTPriorTax As Decimal
  Dim WrkTSuspTax As Decimal
  Dim WrkTCurrIntLien As Decimal
  Dim WrkTPriorIntLien As Decimal
  Dim WrkTSuspInt As Decimal
  Dim WrkTFines As Decimal
  Dim WrkTSheriff As Decimal
  Dim WrkTFireTax As Decimal
  Dim WrkTCBPenalty As Decimal
  Dim WrkTAdvTax As Decimal
  Dim WrkTAdvSewer As Decimal
  Dim WrkTCurrSewer As Decimal
  Dim WrkTCurrSewerIntLien As Decimal
  Dim WrkTPriorSewer As Decimal
  Dim WrkTPriorSewerIntLien As Decimal
  'General
  Dim SaveYear As Integer
  Dim SaveType As String
  Dim SaveDist As Integer
  'File
  Dim sw As StreamWriter
  Public Sub PrtReport()

    myNETGLBCH = New NETGLBCHQ.MyData()
    myNETGLBCH.MyDBConn = myDBConnect
    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myMUNGL = New MUNGL.mydata(myDBConnect)

    With MyFrmTX600B
      WrkCurrYear = MyUtils.CnvSng(.TxtCurrYear.Text)
      WrkCurrYearSU = MyUtils.CnvSng(.TxtCurrYearSU.Text)
      WrkBatch = MyUtils.CnvSng(.TxtBatch.Text)
      WrkFile = .ChkFile.Checked
      WrkLockbox = .ChkLockbox.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    ClearTotals()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkPostDate = WrkPostDate
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RptGroup", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("CRAcct", Type.GetType("System.String"))
      .Columns.Add("DBAcct", Type.GetType("System.String"))
      .Columns.Add("Amt", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub ClearTotals()
    WrkTCurrTax = 0
    WrkTCurrTaxSU = 0
    WrkTPriorTax = 0
    WrkTSuspTax = 0
    WrkTCurrIntLien = 0
    WrkTPriorIntLien = 0
    WrkTSuspInt = 0
    WrkTFines = 0
    WrkTSheriff = 0
    WrkTFireTax = 0
    WrkTCBPenalty = 0
    WrkTAdvTax = 0
    WrkTAdvSewer = 0
    WrkTCurrSewer = 0
    WrkTCurrSewerIntLien = 0
    WrkTPriorSewer = 0
    WrkTPriorSewerIntLien = 0
  End Sub

  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkPamt As Decimal
    Dim WrkIamt As Decimal
    Dim WrkLamt As Decimal
    Dim WrkPCamt As Decimal
    Dim WrkPenCd As String
    Dim WrkFireAmt As Decimal
    Dim WrkSusp As Boolean
    Dim WrkFirePct As Decimal
    Dim WrkDistPct As Decimal
    Dim WrkAnd As String
    Dim WrkMsg As String
    Dim Counter As Integer

    SaveYear = 0
    SaveDist = 0
    Counter = 0

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = String.Empty
    WrkQry = "BATCH = " & WrkBatch

    myNETGLBCH.OpenQry(WrkSort, WrkQry)
    If WrkFile Then
      sw = New StreamWriter(MyFrmTX600B.LblFilePath.Text)
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myNETGLBCH.ReadQry()
    If Not myNETGLBCH.IsEOF Then
      With myNETGLBCH
        Counter = Counter + 1
        If WrkLockbox And ._STAT <> "L" Then GoTo NextRec
        If Not WrkLockbox And ._STAT = "L" Then GoTo NextRec
        WrkSusp = False
        If ._STAT = "S" Then
          WrkSusp = True
        End If
        If SaveDist <> ._DIST Or SaveYear <> ._YEAR Then
          WrkFirePct = 0
          WrkDistPct = 0
          myTXMRATE.GetOneRecordP(._YEAR, ._TYPE, ._DIST)
          If myTXMRATE.RecordNotFound Then
            myTXMRATE.GetOneRecordP(._YEAR, "", ._DIST)
          End If
          If Not myTXMRATE.RecordNotFound Then
            With myTXMRATE
              If ._MRRATE > 0 Then
                WrkFirePct = (._MRFIRE / ._MRRATE)
                WrkFirePct = MyUtils.Round(WrkFirePct, 6)
                WrkDistPct = 1 - WrkFirePct
              Else
                WrkMsg = "Sequence " & myNETGLBCH._SEQNO &
                " Fix record in NETGLBCH"
                MsgBox(WrkMsg, MsgBoxStyle.Exclamation, "Warning: Invalid district found")
                WrkFirePct = 0
                WrkDistPct = 1
              End If
            End With
          End If
        End If
        SaveYear = ._YEAR
        SaveDist = ._DIST

        WrkPenCd = Trim(._PENCD)
        If ._TYPE = "U" Then
          WrkPamt = ._PAMT
          WrkIamt = ._IAMT
          WrkLamt = ._LAMT
          WrkPCamt = ._PCAMT
          WrkFireAmt = 0
        Else
          WrkPamt = MyUtils.Round(._PAMT * WrkDistPct, 2)
          WrkIamt = MyUtils.Round(._IAMT * WrkDistPct, 2)
          WrkLamt = ._LAMT
          WrkPCamt = ._PCAMT
          WrkFireAmt = MyUtils.Round(._PAMT * WrkFirePct, 2) + MyUtils.Round(._IAMT * WrkFirePct, 2)
        End If

        If WrkSusp Then
          WrkTSuspTax = WrkTSuspTax + WrkPamt
          WrkTSuspInt = WrkTSuspInt + WrkIamt + WrkLamt
        Else
          If ._TYPE <> "S" And ._TYPE <> "T" Then
            If WrkCurrYear = SaveYear Then
              Select Case ._TYPE
                Case Is = "U"
                  WrkTCurrSewer = WrkTCurrSewer + WrkPamt
                  WrkTCurrSewerIntLien = WrkTCurrSewerIntLien + WrkIamt + WrkLamt
                Case Else
                  WrkTCurrTax = WrkTCurrTax + WrkPamt
                  WrkTCurrIntLien = WrkTCurrIntLien + WrkIamt + WrkLamt
              End Select
            Else
              If ._YEAR > WrkCurrYear Then
                Select Case ._TYPE
                  Case Is = "U"
                    WrkTAdvSewer = WrkTAdvSewer + WrkPamt
                  Case Else
                    WrkTAdvTax = WrkTAdvTax + WrkPamt
                End Select
              Else
                Select Case ._TYPE
                  Case Is = "U"
                    WrkTPriorSewer = WrkTPriorSewer + WrkPamt
                    WrkTPriorSewerIntLien = WrkTPriorSewerIntLien + WrkIamt + WrkLamt
                  Case Else
                    WrkTPriorTax = WrkTPriorTax + WrkPamt
                    WrkTPriorIntLien = WrkTPriorIntLien + WrkIamt + WrkLamt
                End Select
              End If
            End If
          Else
            If WrkCurrYearSU = SaveYear Then
              WrkTCurrTaxSU = WrkTCurrTaxSU + WrkPamt
              WrkTCurrIntLien = WrkTCurrIntLien + WrkIamt + WrkLamt
            Else
              If ._YEAR > WrkCurrYear Then
                WrkTAdvTax = WrkTAdvTax + WrkPamt
              Else
                WrkTPriorTax = WrkTPriorTax + WrkPamt
                WrkTPriorIntLien = WrkTPriorIntLien + WrkIamt + WrkLamt
              End If
            End If
          End If
        End If
      End With
      WrkTFireTax = WrkTFireTax + WrkFireAmt
      Select Case WrkPenCd
        Case "RC"
          WrkTFines = WrkTFines + WrkPCamt
        Case "SF"
          WrkTSheriff = WrkTSheriff + WrkPCamt
        Case Else
          WrkTCBPenalty = WrkTCBPenalty + WrkPCamt
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

    WrkPostDate = MyUtils.GetDBDate(myNETGLBCH._PAYDT)
    myMUNGL.GetOneRecordP("")
    With myMUNGL
      WriteMUNJE("1", "Current Year Tax Levy", ._CTAXC, ._CTAXD, WrkTCurrTax)
      WriteMUNJE("1", "Current Year MV Supplement", ._CSUC, ._CSUD, WrkTCurrTaxSU)
      WriteMUNJE("1", "Prior Years Tax Levy", ._PTAXC, ._PTAXD, WrkTPriorTax)
      WriteMUNJE("1", "Suspense Tax", ._STAXC, ._STAXD, WrkTSuspTax)
      WriteMUNJE("1", "Current Year Interest & Liens", ._CINTC, ._CINTD, WrkTCurrIntLien)
      WriteMUNJE("1", "Prior Years Interest & Liens", ._PINTC, ._PINTD, WrkTPriorIntLien)
      WriteMUNJE("1", "Suspense Interest", ._SINTC, ._SINTD, WrkTSuspInt)
      WriteMUNJE("1", "Fines & Penalities", ._PENC, ._PEND, WrkTFines)
      WriteMUNJE("2", "Fire District Payable", ._FTAXC, ._FTAXD, WrkTFireTax)
      WriteMUNJE("2", "CB Penalty Fee Payable", ._PENCBC, ._PENCBD, WrkTCBPenalty)
      WriteMUNJE("2", "Sheriff Fees & Penalities", "1010000025270", "1010000010035", WrkTSheriff)
      WriteMUNJE("2", "Taxes Collected Adv. (June)", ._ATAXC, ._ATAXD, WrkTAdvTax)
      WriteMUNJE("2", "Sewer Fee Collected Adv. (June)", ._ASWRC, ._ASWRD, WrkTAdvSewer)
      WriteMUNJE("2", "Current Sewer Fees", ._CSWRC, ._CSWRD, WrkTCurrSewer)
      WriteMUNJE("2", "Current Sewer Interest & Liens", ._CSWRIC, ._CSWRID, WrkTCurrSewerIntLien)
      WriteMUNJE("2", "Prior Years Sewer Fees", ._PSWRC, ._PSWRD, WrkTPriorSewer)
      WriteMUNJE("2", "Prior Sewer Interest & Liens", ._PSWRIC, ._PSWRID, WrkTPriorSewerIntLien)
    End With

    myFrmProgress.Close()
    myNETGLBCH.CloseFile()
    If WrkFile Then
      sw.Close()
    End If
  End Sub
  Private Sub WriteMUNJE(ByVal WrkGrp As String, ByVal WrkDesc As String, ByVal WrkCRAcct As String,
  ByVal WrkDBAcct As String, ByVal WrkAmt As Decimal)

    Dim WrkJEAcct1 As String
    Dim WrkJEAcct2 As String
    Dim sb As StringBuilder
    Dim wrkstring As String
    Dim wrklong As Long

    'Negative amount is reverse entry
    If WrkAmt > 0 Then
      WrkJEAcct1 = WrkCRAcct
      WrkJEAcct2 = WrkDBAcct
    Else
      WrkJEAcct1 = WrkDBAcct
      WrkJEAcct2 = WrkCRAcct
    End If

    If WrkFile Then
      'Credit JE Entry
      sb = New StringBuilder
      sb.Append(Mid(WrkJEAcct1, 1, 8)) 'Organization
      wrkstring = MyUtils.JustifyLeft(Mid(WrkJEAcct1, 9, 6), 6)
      sb.Append(wrkstring) 'Object
      wrkstring = MyUtils.JustifyLeft("", 5)
      sb.Append(wrkstring) 'Project
      wrkstring = MyUtils.JustifyLeft("", 35)
      '      wrkstring = MyUtils.JustifyLeft(WrkJEAcct1, 35)
      sb.Append(wrkstring) 'Full Account
      wrkstring = MyUtils.JustifyLeft(Mid(WrkDesc, 1, 30), 30)
      sb.Append(wrkstring) 'Comment
      wrkstring = MyUtils.JustifyLeft(WrkBatch, 10)
      sb.Append(wrkstring) 'Reference 2
      wrkstring = MyUtils.JustifyLeft("", 12)
      sb.Append(wrkstring) 'Reference 3
      sb.Append("C") 'Credit
      wrklong = Math.Abs(WrkAmt) * 100
      sb.Append(Format(wrklong, "0000000000000")) 'Amount
      sb.Append(" ") 'Encumb 
      wrklong = 0
      sb.Append(Format(wrklong, "0000000000000"))
      wrkstring = MyUtils.JustifyLeft("", 5)
      sb.Append(wrkstring) 'Allocation Code
      sb.Append("A") 'Transaction Type
      sw.WriteLine(sb.ToString)
      sb = Nothing

      'Debit Entry 2
      sb = New StringBuilder
      sb.Append(Mid(WrkJEAcct2, 1, 8)) 'Organization
      wrkstring = MyUtils.JustifyLeft(Mid(WrkJEAcct2, 9, 6), 6)
      sb.Append(wrkstring) 'Object
      wrkstring = MyUtils.JustifyLeft("", 5)
      sb.Append(wrkstring) 'Project
      wrkstring = MyUtils.JustifyLeft("", 35)
      '			wrkstring = MyUtils.JustifyLeft(WrkJEAcct2, 35)
      sb.Append(wrkstring) 'Full Account
      wrkstring = MyUtils.JustifyLeft(Mid(WrkDesc, 1, 30), 30)
      sb.Append(wrkstring) 'Comment
      wrkstring = MyUtils.JustifyLeft(WrkBatch, 10)
      sb.Append(wrkstring) 'Reference 2
      wrkstring = MyUtils.JustifyLeft("", 12)
      sb.Append(wrkstring) 'Reference 3
      sb.Append("D") 'Debit
      wrklong = Math.Abs(WrkAmt) * 100
      sb.Append(Format(wrklong, "0000000000000")) 'Amount
      sb.Append(" ") 'Encumb 
      wrklong = 0
      sb.Append(Format(wrklong, "0000000000000"))
      wrkstring = MyUtils.JustifyLeft("", 5)
      sb.Append(wrkstring) 'Allocation Code
      sb.Append("A") 'Transaction Type
      sw.WriteLine(sb.ToString)
      sb = Nothing
    End If

    BuildReport(WrkGrp, WrkDesc, WrkJEAcct1, WrkJEAcct2, WrkAmt)
  End Sub
  Private Sub GetMUNGL()
    Dim myMUNGL As MUNGL.myData

    myMUNGL = New MUNGL.mydata(myDBConnect)
    myMUNGL.GetOneRecordP(1)

  End Sub

  Private Sub BuildReport(ByVal WrkGrp As String, ByVal WrkDesc As String, ByVal WrkCRAcct As String,
  ByVal WrkDBAcct As String, ByVal WrkAmt As Decimal)
    dr = ds.Tables(0).NewRow
    dr.Item("RptGroup") = WrkGrp
    dr.Item("Desc") = WrkDesc
    dr.Item("CRAcct") = Mid(WrkCRAcct, 1, 8) & "-" & Mid(WrkCRAcct, 9, 6)
    dr.Item("DBAcct") = Mid(WrkDBAcct, 1, 8) & "-" & Mid(WrkDBAcct, 9, 6)
    dr.Item("Amt") = WrkAmt
    ds.Tables(0).Rows.Add(dr)
  End Sub
End Module






