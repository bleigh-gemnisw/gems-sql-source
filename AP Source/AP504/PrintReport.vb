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
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPERCNQ = New APERCNQ.MyData()
    myAPERCNQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect

    With MyFrmAP504B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
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
      .ds = ds
      .Show()
    End With
  End Sub
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("ChkDate", Type.GetType("System.DateTime"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
      .Columns.Add("RecDate", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailAP()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim Good As Boolean

    WrkAnd = " and "
    WrkOr = " or "

    If MyFrmAP504B.TxtChkFrom.Text <> String.Empty Then
      WrkQry = "PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd & "PAYCK >=" & MyUtils.CnvSng(MyFrmAP504B.TxtChkFrom.Text) &
      WrkAnd & "PAYCK <=" & MyUtils.CnvSng(MyFrmAP504B.TxtChkTo.Text)
    Else
      WrkQry = "PAYBN = " & MyUtils.Quo(WrkBank) & WrkAnd & "PAYP8 >= " & WrkFrom & WrkAnd & "PAYP8 <=" & WrkTo
    End If

    If MyFrmAP504B.ChkRecon.Checked Then
      WrkSort = "PAYBN, PAYC8, PAYCK"
    Else
      WrkSort = "PAYBN, PAYP8, PAYCK"
    End If
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
        dr.Item("checkno") = ._PAYCK
        dr.Item("chkdate") = MyUtils.GetDBDate(._PAYP8)
        dr.Item("amount") = ._PAYAM
        myVENDOR.GetOneRecordP(._VNDNR)
        If Not myVENDOR.RecordNotFound Then
          dr.Item("name") = Trim(myVENDOR._VENNM)
        Else
          dr.Item("name") = Trim(._VNDNR)
        End If
        Good = False
        Select Case Trim(._RCCDE)
          Case "R"
            dr.Item("status") = "Reconciled"
            dr.Item("recdate") = MyUtils.GetDBDate(._PAYC8)
            If MyFrmAP504B.ChkRecon.Checked And ._PAYC8 <= WrkTo Then
              Good = True
            End If
            If MyFrmAP504B.ChkOpen.Checked And ._PAYC8 > WrkTo Then
              dr.Item("status") = "Open"
              Good = True
            End If
          Case "", "A"
            dr.Item("status") = "Open"
            If MyFrmAP504B.ChkOpen.Checked Then
              Good = True
            End If
          Case Else
            dr.Item("status") = ""
        End Select
        If Good Then
          ds.Tables(0).Rows.Add(dr)
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
    End If ' record not found

    myFrmProgress.Close()
    myAPERCNQ.CloseFile()
    myVENDOR.CloseFile()
    myAPEBNK.CloseFile()
  End Sub
End Module
