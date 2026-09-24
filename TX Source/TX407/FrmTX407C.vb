Imports System.IO
Imports System.Text
Public Class FrmTX407C
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINV As TXINV.MyData
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVLC As TXINVLC.MyData
  Dim myTXINVLM As TXINVLM.MyData
  Dim myTXINVLN As TXINVLN.MyData
  Dim sw As StreamWriter
  Dim dr As Data.DataRow
  Dim WrkPost As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Private Sub FrmTX407C_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    MyFrmTX407.TBarProcess.Enabled = True
    MyFrmTX407.TBarContinue.Enabled = False
    MyFrmTX407.TBarPrint.Enabled = False
  End Sub
  Private Sub FrmTX407C_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINVLC = New TXINVLC.MyData(myDBConnect)
    myTXINVLM = New TXINVLM.MyData(myDBConnect)
    myTXINVLN = New TXINVLN.MyData(myDBConnect)

    MyFrmTX407.TBarProcess.Enabled = False
    MyFrmTX407.TBarContinue.Enabled = True
    MyFrmTX407.TBarPrint.Enabled = True

    FormatGrid()

  End Sub
  Public Sub PrintData()
    MyCrViewer2 = New FrmCrViewer2
    MyCrViewer2.wrkds = mydsDMV.Copy
    MyCrViewer2.Show()
  End Sub
  Public Sub FormatGrid()

    With C1DataGrdList
      .DataSource = mydsDMV.Tables(0)
      .Refresh()
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Width = 30
      .Columns(0).Caption = "Sel"
      .Splits(0).DisplayColumns(1).Width = 30
      .Columns(1).Caption = "Days"
      .Splits(0).DisplayColumns(2).Width = 55
      .Columns(2).ValueItems.Values.Clear()
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(1, "Cash"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(2, "Check"))
      .Columns(2).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem(3, "Credit"))
      .Columns(2).ValueItems.Translate = True
      .Columns(2).Caption = "Method"
      .Columns(3).Caption = "List #"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Type"
      .Splits(0).DisplayColumns(4).Width = 35
      .Columns(5).Caption = "Year"
      .Splits(0).DisplayColumns(5).Width = 35
      .Columns(6).Caption = "CustID"
      .Splits(0).DisplayColumns(6).Width = 60
      .Columns(7).Caption = "VehID"
      .Splits(0).DisplayColumns(7).Width = 60
      .Columns(8).Caption = "Name"
      .Splits(0).DisplayColumns(8).Width = 150
      .Columns(9).Caption = "Address"
      .Splits(0).DisplayColumns(9).Width = 150
      .Columns(10).Caption = "City"
      .Splits(0).DisplayColumns(10).Width = 100
      .Columns(11).Caption = "State"
      .Splits(0).DisplayColumns(11).Width = 30
      .Splits(0).DisplayColumns(12).Visible = False 'Zip
      .Splits(0).DisplayColumns(13).Visible = False 'Name'
      .Splits(0).DisplayColumns(14).Visible = False 'Add1 
      .Splits(0).DisplayColumns(15).Visible = False 'City
      .Splits(0).DisplayColumns(16).Visible = False 'DOB
      .Splits(0).DisplayColumns(17).Visible = False 'Lease
      .Splits(0).DisplayColumns(18).Visible = False 'Message
    End With

  End Sub
  Private Sub FrmTX407B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX407.SbpScreen.Text = "TX407C"
  End Sub
  Public Sub ProcessMV()
    With MyFrmTX407C
      WrkPost = .ChkPost.Checked
    End With

    WriteTakeoffFile()
    FlagTakeoffs()
    GetMissing()

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkPost = WrkPost
      .wrkds = mydsDMV
      .wrkds3 = mydsStatus
      .WrkRpt = "Takeoff"
      .ShowDialog()
    End With

    If WrkPost Then
      MyFrmTX407C.Close()
      MyFrmTX407B.Show()
    End If
  End Sub
  Private Sub FlagTakeoffs()
    Dim ds2 As DataSet = New DataSet
    Dim drSel() As DataRow
    Dim WrkSelect As String
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim I As Integer
    Dim J As Integer

    For I = 0 To mydsDMV.Tables(0).Rows.Count - 1
      If Not mydsDMV.Tables(0).Rows(I).Item("sel") Then
        Continue For
      End If
      'Primary
      ds2 = myTXINVLM.GetAllSSNo(mydsDMV.Tables(0).Rows(I).Item("pcust"), 5000, False)
      For J = 0 To ds2.Tables(0).Rows.Count - 1
        With myTXINV
          If ds2.Tables(0).Rows(J).Item("mvflag") <> "Y" And ds2.Tables(0).Rows(J).Item("mvflag") <> "P" Then
            Continue For
          End If
          WrkListNo = ds2.Tables(0).Rows(J).Item("list#")
          WrkYear = ds2.Tables(0).Rows(J).Item("year")
          WrkType = ds2.Tables(0).Rows(J).Item("type")
          .GetOneRecordP(wrklistno, wrkyear, wrktype)
          WrkSelect = "regno='" & Trim(._IMVREG) & "'"
          drSel = mydsStatus.Tables(0).Select(WrkSelect)
          If drSel.GetUpperBound(0) = -1 Then
            WriteDetail(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, "Takeoff")
          End If
          If WrkPost Then
            ._MVFLAG = ""
            .UpdateMVFlag(WrkListNo, WrkYear, WrkType, ._MVFLAG)
          End If
        End With
      Next

      'Secondary
      ds2 = myTXINVLN.GetAllSS2(mydsDMV.Tables(0).Rows(I).Item("pcust"), 5000, False)
      For J = 0 To ds2.Tables(0).Rows.Count - 1
        With myTXINV
          If ds2.Tables(0).Rows(J).Item("mvflag") <> "Y" And ds2.Tables(0).Rows(J).Item("mvflag") <> "P" Then
            Continue For
          End If
          WrkListNo = ds2.Tables(0).Rows(J).Item("list#")
          WrkYear = ds2.Tables(0).Rows(J).Item("year")
          WrkType = ds2.Tables(0).Rows(J).Item("type")
          .GetOneRecordP(WrkListNo, WrkYear, WrkType)
          WrkSelect = "regno='" & Trim(._IMVREG) & "'"
          drSel = mydsStatus.Tables(0).Select(WrkSelect)
          If drSel.GetUpperBound(0) = -1 Then
            WriteDetail(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, "Takeoff")
          End If
          If WrkPost Then
            ._MVFLAG = ""
            .UpdateMVFlag(WrkListNo, WrkYear, WrkType, ._MVFLAG)
          End If
        End With
      Next
    Next
    ds2 = Nothing
  End Sub
  Private Sub GetMissing()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkBalance As Boolean
    Dim WrkDue As Decimal
    Dim WrkGracePeriod As Boolean
    Dim Counter As Integer
    Dim SaveReg As String

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

    WrkQry = "mvflag='M'" & WrkOr & "mvflag='P'" & WrkAnd & "ss#=0"
    WrkSort = "IMVREG, YEAR"

    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveReg = ""
    Counter = 0

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If SaveReg <> "" And SaveReg <> Trim(._IMVREG) Then
          If Not WrkBalance Then
            FlagTakeoffReg(SaveReg)
          End If
          WrkBalance = False
        End If
        SaveReg = Trim(._IMVREG)
        If WrkBalance Then
          GoTo NextRec
        End If

        CalcDue(._LISTNo, ._TYPE, ._YEAR, 0, 0, 0, 0, WrkDue, WrkGracePeriod, 0, "")
        If WrkDue > 0 And Not WrkGracePeriod Then
          WrkBalance = True
        End If
        If WrkDue <= 0 And SaveReg = "" Then
          SaveReg = Trim(._IMVREG)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed(2/2): " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
        GoTo ReadNext
      End With
    End If

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub WriteTakeoffFile()
    Dim sb As StringBuilder
    Dim I As Integer

    sw = New StreamWriter(MyFrmTX407B.LblFilePath.Text)
    For I = 0 To mydsDMV.Tables(0).Rows.Count - 1
      sb = Nothing
      If mydsDMV.Tables(0).Rows(I).Item("sel") Then
        sb = New StringBuilder
        sb.Append(Date.Today.Year)
        sb.Append(Format(Date.Today.Month, "00"))
        sb.Append(Format(Date.Today.Day, "00"))
        sb.Append("D") 'Delete
        sb.Append(Format(mydsDMV.Tables(0).Rows(I).Item("pcust"), "0000000000"))
        sb.Append(mydsDMV.Tables(0).Rows(I).Item("lease"))
        sb.Append(Format(mydsDMV.Tables(0).Rows(I).Item("vehid"), "000000000"))
        sb.Append(Format(myTOWN._TOWNBR, "000"))
        sw.WriteLine(sb.ToString)
      End If
    Next
    sw.Close()

  End Sub
  Private Sub WriteDetail(ByVal WrkRegno As String, ByVal WrkList As Integer, ByVal WrkType As String,
  ByVal WrkYear As Integer, ByVal WrkName As String, ByVal WrkMsg As String)
    'Write Report/Review
    dr = mydsStatus.Tables(0).NewRow
    dr.Item("regno") = WrkRegno
    dr.Item("list") = WrkList
    dr.Item("type") = WrkType
    dr.Item("year") = WrkYear
    dr.Item("name") = WrkName
    dr.Item("msg") = WrkMsg
    mydsStatus.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub FlagTakeoffReg(ByVal WrkReg As String)
    Dim ds2 As DataSet = New DataSet
    Dim drSel() As DataRow
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkSelect As String
    Dim J As Integer

    ds2 = myTXINVLC.GetAllRegNo(WrkReg, 999, MyBlocking)
    For J = 0 To ds2.Tables(0).Rows.Count - 1
      With myTXINV
        WrkListNo = ds2.Tables(0).Rows(J).Item("list#")
        WrkYear = ds2.Tables(0).Rows(J).Item("year")
        WrkType = ds2.Tables(0).Rows(J).Item("type")
        .GetOneRecordP(WrkListNo, WrkYear, WrkType)
        If ._MVFLAG <> "P" And ._MVFLAG <> "M" Then
          Continue For
        End If
        If WrkPost Then
          ._MVFLAG = ""
          .UpdateMVFlag(WrkListNo, WrkYear, WrkType, ._MVFLAG)
        End If
        WrkSelect = "regno='" & WrkReg & "'"
        drSel = mydsStatus.Tables(0).Select(WrkSelect)
        If drSel.GetUpperBound(0) = -1 Then
          WriteDetail(._IMVREG, ._LISTNo, ._TYPE, ._YEAR, ._NAME, "Missing")
        End If
      End With
    Next
    ds2 = Nothing
  End Sub

  Private Sub ChkPost_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPost.CheckedChanged

  End Sub
End Class





