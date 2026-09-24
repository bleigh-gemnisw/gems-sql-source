Module PrintEdits
  Dim myMRBCH As MRBCH.MyData
  Dim myMRBCHD As MRBCHD.MyData
  Dim myMRCODE As MRCODE.MyData
  Dim ds As DataSet = New DataSet
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim Errors As Boolean
  Public Function PrtEdits(ByVal BatchNo As Integer,
  ByVal ReceiptDate As Date, ByVal Post As Boolean) As Boolean

    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRBCHD = New MRBCHD.MyData()
    myMRBCHD.MyDBConn = myDBConnect
    myMRCODE = New MRCODE.MyData()
    myMRCODE.MyDBConn = myDBConnect

    Errors = False
    If ds.Tables.Count = 0 Then
      BuildPrtDS()
    Else
      ds.Clear()
    End If
    AddRecords(BatchNo, Post)
    If myMRBCH._TCASH + myMRBCH._TCHECK + myMRBCH._TCREDIT <> myMRBCH._TAMT Then
      Errors = True
    End If
    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.WrkTCash = myMRBCH._TCASH
    MyFrmCr_PrtEdits.WrkTCheck = myMRBCH._TCHECK
    MyFrmCr_PrtEdits.WrkTCredit = myMRBCH._TCREDIT
    MyFrmCr_PrtEdits.WrkTTotal = myMRBCH._TAMT
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkErrors = Errors
    MyFrmCr_PrtEdits.ShowDialog()
    'Memory Cleanup
    myMRBCHD = Nothing
    Return Errors

  End Function
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.Int32"))
      .Columns.Add("BatchDesc", Type.GetType("System.String"))
      .Columns.Add("RecDt", Type.GetType("System.DateTime"))
      .Columns.Add("StrDt", Type.GetType("System.DateTime"))
      .Columns.Add("EndDt", Type.GetType("System.DateTime"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Sub AddRecords(ByVal BatchNo As Integer, ByVal Post As Boolean)
    Dim I As Integer
    Dim dr As Data.DataRow

    myFrmProgress = New FrmProgress
    If Post Then
      myFrmProgress.Text = "Creating Posting Reports"
    Else
      myFrmProgress.Text = "Creating Edit Reports"
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myMRBCHD.SetRange(BatchNo)
    Do While Not myMRBCHD.IsEOF
      myMRBCHD.ReadFileE()
      If myMRBCHD.IsEOF Then Exit Do
      dr = ds.Tables(0).NewRow
      dr("batch") = BatchNo
      myMRBCH.GetOneRecordP(BatchNo)
      With myMRBCH
        dr("batchdesc") = ._DESCR
        dr("recdt") = MyUtils.GetDBDate(._RECDT)
        dr("strdt") = MyUtils.GetDBDate(._STRDT)
        dr("enddt") = MyUtils.GetDBDate(._ENDDT)
      End With
      myMRCODE.GetOneRecordP(myMRBCHD._CODE)
      If Not myMRCODE.RecordNotFound Then
        dr("acctno") = myMRCODE._ACCT
        dr("description") = myMRCODE._DESCR
      End If
      With myMRBCHD
        dr("code") = ._CODE
        dr("total") = ._TOTAL
      End With
      ds.Tables(0).Rows.Add(dr)

      With myFrmProgress
        WrkPct = (I / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & I
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Loop

    'Create a Report record only if no detail found
    If ds.Tables(0).Rows.Count = 0 Then
      dr = ds.Tables(0).NewRow
      dr("batch") = BatchNo
      myMRBCH.GetOneRecordP(BatchNo)
      With myMRBCH
        dr("batchdesc") = ._DESCR
        dr("recdt") = MyUtils.GetDBDate(._RECDT)
        dr("strdt") = MyUtils.GetDBDate(._STRDT)
        dr("enddt") = MyUtils.GetDBDate(._ENDDT)
      End With
      dr("acctno") = String.Empty
      dr("description") = String.Empty
      dr("code") = String.Empty
      dr("total") = 0
      ds.Tables(0).Rows.Add(dr)
    End If

    myFrmProgress.Close()
    Application.DoEvents()

  End Sub
End Module
