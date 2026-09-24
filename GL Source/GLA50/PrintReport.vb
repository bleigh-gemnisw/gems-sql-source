Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDGERQ As LEDGERQ.MyData
  Dim myGLACCT As GLACCT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkBatch As Integer
  Dim WrkBatchDate As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect

    With MyFrmGLA50B
      WrkBatch = MyUtils.CnvSng(.TxtBatch.Text)
      WrkPost = .ChkPost.Checked
      WrkBatchDate = MyUtils.SetDBDate(.DtPckBatch.Value)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.ShowDialog()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("Sfund", Type.GetType("System.Int32"))
      .Columns.Add("Dept", Type.GetType("System.Int32"))
      .Columns.Add("Obj", Type.GetType("System.Int32"))
      .Columns.Add("Func", Type.GetType("System.Int32"))
      .Columns.Add("Sfunc", Type.GetType("System.Int32"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("Refno", Type.GetType("System.Int32"))
      .Columns.Add("Amt", Type.GetType("System.Decimal"))
      .Columns.Add("Dated", Type.GetType("System.DateTime"))
      .Columns.Add("Tdesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkMult As Integer
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If

    MyBatchTotal = 0
    WrkQry = "BCHNO=" & WrkBatch & WrkAnd & "PSTDT=" & WrkBatchDate
    WrkSort = ""
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("fund") = ._FDNBR
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = ._GLTYP
        dr.Item("refno") = ._REFNO
        dr.Item("amt") = 0
        Select Case ._GLTYP
          Case "A", "L"
            If ._AMTYP = "D" Then
              dr.Item("amt") = ._TRAMT
            Else
              dr.Item("amt") = ._TRAMT * -1
            End If
          Case "Q"
            If ._AMTYP = "D" Then
              dr.Item("amt") = ._TRAMT
            Else
              dr.Item("amt") = ._TRAMT * -1
            End If
            MyBatchTotal = MyBatchTotal + dr("amt")
          Case "R", "X"
            If ._AMTYP = "D" Then
              WrkMult = 1
            Else
              WrkMult = -1
            End If
            dr.Item("amt") = ._TRAMT * WrkMult
            MyBatchTotal = MyBatchTotal + dr("amt")
        End Select
        dr.Item("tdesc") = Trim(._TDESC)
        dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
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
    myLEDGERQ.CloseFile()

  End Sub
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Sfund As Integer, Dept As Integer,
    ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer) As String
    myGLACCT.GetOneRecordP(Fund, Sfund, Dept, Obnbr, Fnpgm, Subfn)
    If Not myGLACCT.RecordNotFound Then
      GetAcctDesc = Format(Dept, "0000") & "-" & Format(Obnbr, "000") &
      "-" & Format(Fnpgm, "0000") & "-" & Format(Subfn, "0000") & " " & Trim(myGLACCT._GLDSC)
    Else
      GetAcctDesc = "*** Unknown ***"
    End If
    Return GetAcctDesc
  End Function
End Module
