Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPERCN As APERCN.MyData
  Dim myVENDOR As VENDOR.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow

  Dim WrkBank As String
  Dim WrkFormat As String
  Dim WrkPost As Boolean
  Dim strBuffer As String

  Dim WrkChkNo As Integer
  Dim WrkAmount As Decimal
  Dim WrkName As String
  Dim WrkChkPaidDt As Integer
  Public Sub PrtReport()

    myAPERCN = New APERCN.MyData()
    myAPERCN.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP530B
      WrkBank = .TxtBank.Text
      WrkFormat = ""
      If .RbAP.Checked Then
        WrkFormat = "Normal"
      End If
      If .RbWebster.Checked Then
        WrkFormat = "Webster"
      End If
      WrkPost = .ChkUpdate.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    GetDetailAP()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkBank = WrkBank
      .WrkPost = WrkPost
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CheckNo", Type.GetType("System.Int32"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Date", Type.GetType("System.DateTime"))
      .Columns.Add("Msg", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetailAP()
    Dim WrkStream As FileStream = New FileStream(MyFrmAP530B.LblFilePath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkMsg As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo CloseFiles
      Exit Sub
    End If

    I = I + strBuffer.Length
    WrkMsg = ""
    With myAPERCN
      Select Case WrkFormat
        Case "Normal"
          ReadFile()
        Case "Webster"
          ReadWebster()
      End Select
      .GetOneRecordP(WrkBank, WrkChkNo)
      If .RecordNotFound Then
        WrkMsg = "*** Check not found ***"
      Else
        myVENDOR.GetOneRecordP(._VNDNR)
        If myVENDOR.RecordNotFound Then
          WrkMsg = "*** Vendor not found ***"
        Else
          If WrkName <> "" And Trim(myVENDOR._VENNM) <> WrkName Then
            WrkMsg = "*** Name is different ***"
          Else
            WrkName = Trim(myVENDOR._VENNM)
          End If
        End If
        If ._PAYAM <> WrkAmount Then
          WrkMsg = "*** Amount <> " & ._PAYAM & " ***"
        End If
        If ._RCCDE = "R" Then
          WrkMsg = "*** Already reconciled ***"
        End If
      End If
      If WrkPost And WrkMsg = "" Then
        ._RCCDE = "R"
        ._PAYC8 = WrkChkPaidDt
        .UpdateOneRecordP()
      End If

      'Create Report
      dr = ds.Tables(0).NewRow
      dr.Item("checkno") = WrkChkNo
      dr.Item("amount") = WrkAmount
      dr.Item("name") = WrkName
      dr.Item("date") = MyUtils.GetDBDate(WrkChkPaidDt)
      dr.Item("msg") = WrkMsg
      ds.Tables(0).Rows.Add(dr)
    End With

NextRec:
    With myFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

CloseFiles:
    sr.Close()
    myFrmProgress.Close()
    myAPERCN.CloseFile()

  End Sub
  Private Sub ReadFile()
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 1, 10))
    WrkAmount = MyUtils.CnvSng(Mid(strBuffer, 11, 11)) / 100
    WrkName = Mid(strBuffer, 47, 30)
    WrkChkPaidDt = "20" & MyUtils.CnvSng(Mid(strBuffer, 28, 6)) 'YYYYMMDD
  End Sub
  Private Sub ReadWebster()
    WrkChkNo = MyUtils.CnvSng(Mid(strBuffer, 22, 10))
    WrkAmount = MyUtils.CnvSng(Mid(strBuffer, 51, 10)) / 100
    WrkName = ""
    WrkChkPaidDt = "20" & Mid(strBuffer, 42, 2) & Mid(strBuffer, 38, 2) & Mid(strBuffer, 40, 2) 'YYYYMMDD
  End Sub
End Module