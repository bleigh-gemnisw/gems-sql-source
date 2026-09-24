Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPERCNQ As APERCNQ.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myAPEBNK As APEBNK.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBank As String
  Dim WrkPrData As String
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPERCNQ = New APERCNQ.MyData()
    myAPERCNQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect

    With MyFrmAP502B
      WrkFrom = MyUtils.SetDBDate(.DtPckcdate.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckpdate.Value)
      WrkBank = .TxtBank.Text

    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    GetDetailAP()


Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .TabCtl1.TabPages.RemoveAt(1)
      .mycheckdate = MyFrmAP502B.DtPckcdate.Value
      .mypostingdate = MyFrmAP502B.DtPckpdate.Value
      .plistonly = "Y"
      .ds = ds
      .Show()
    End With
  End Sub
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("PAYBN", Type.GetType("System.String"))
      .Columns.Add("BANKNAME", Type.GetType("System.String"))
      .Columns.Add("CHECKNO", Type.GetType("System.Int32"))
      .Columns.Add("CHECKDATE", Type.GetType("System.DateTime"))
      .Columns.Add("VOIDDATE", Type.GetType("System.DateTime"))
      .Columns.Add("AMOUNT", Type.GetType("System.Decimal"))
      .Columns.Add("VNAME", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailAP()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "

    WrkQry = "RCCDE = 'V' and PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd _
  & "PAYC8 >= " & WrkFrom & WrkAnd & "PAYC8 <= " & WrkTo

    WrkSort = "PAYBN, PAYC8"
    Counter = 0
    myAPERCNQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myAPERCNQ.ReadQry()
    If Not myAPERCNQ.IsEOF Then
      Counter = Counter + 1
      'Create Report
      With myAPERCNQ
        dr = ds.Tables(0).NewRow
        dr.Item("PAYBN") = Trim(._PAYBN)
        myAPEBNK.GetOneRecordP(._PAYBN)
        If Not myAPEBNK.RecordNotFound Then
          dr.Item("BANKNAME") = Trim(myAPEBNK._BNKNM)
        Else
          dr.Item("BANKNAME") = " "
        End If
        dr.Item("CHECKNO") = ._PAYCK
        dr.Item("CHECKDATE") = MyUtils.GetDBDate(._PAYP8)
        dr.Item("VOIDDATE") = MyUtils.GetDBDate(._PAYC8)
        dr.Item("AMOUNT") = ._PAYAM
        myVENDOR.GetOneRecordP(._VNDNR)
        If Not myVENDOR.RecordNotFound Then
          dr.Item("VNAME") = Trim(myVENDOR._VENNM)
        Else
          dr.Item("VNAME") = Trim(._VNDNR)
        End If
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
    End If ' record not found

    myFrmProgress.Close()
    myAPERCNQ.CloseFile()
    myVENDOR.CloseFile()
    myAPEBNK.CloseFile()
  End Sub
End Module
