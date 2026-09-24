Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.myData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkCount As Integer
  Dim WrkSortBy As String
  Dim WrkAnd As String
  Dim WrkOr As String
  'General

  Public Sub PrtReport()
    myTXREALQ = New TXREALQ.mydata(MyDBConnect)

    With MyFrmTX801B
      WrkGLYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    GetDetail()
    MyFrmTX801B.lblcount.Text = "Total number of records Transmitted:   " + Format(Val(WrkCount), "###,###,##0")
    MyFrmTX801B.lblcount.Visible = True
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter = New StreamWriter(MyFrmTX801B.LblFilePath.Text)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkStr As String

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = "LIST#"
    myTXREALQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myTXREALQ.ReadQry()
    If Not myTXREALQ.IsEOF Then
      With myTXREALQ
        Counter = Counter + 1
        'Write all fields to text file
        WrkStr = BuildOrig()
        sw.WriteLine(WrkStr)
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
        GoTo ReadNext
      End With
    End If

    WrkCount = Counter
    sw.Close()
    myFrmProgress.Close()
    myTXREALQ.CloseFile()

  End Sub
  Private Function BuildOrig() As String
    Dim sb As StringBuilder
    Dim WrkYear As Integer

    WrkYear = Right(MyFrmTX801B.TxtYear.Text, 2)
    With myTXREALQ
      sb = New StringBuilder
      sb.Append(Format(._LISTNO, "000000"))
      sb.Append(Format(WrkYear, "00"))
      sb.Append("R")
      sb.Append(MyUtils.JustifyLeft(._BKCD, 2))
      sb.Append(Format(myTOWN._TOWNBR, "000"))
      sb.Append(MyUtils.JustifyLeft(._NAME, 35))
      sb.Append(MyUtils.JustifyLeft(._LOC, 25))
      sb.Append(MyUtils.JustifyLeft(._LOCNO, 7))
      sb.Append(MyUtils.JustifyLeft(._MAP, 17))
      sb.Append(MyUtils.JustifyLeft(._VOL, 5))
      sb.Append(MyUtils.JustifyLeft(._PGE, 5))
      sb.Append(Format(._GROSS, "000000000"))
      sb.Append(Format(._NET, "000000000"))
    End With
    Return sb.ToString
  End Function
End Module






