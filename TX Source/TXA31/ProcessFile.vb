Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINVTo As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim dsFile As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dserr As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkStcd(4) As String
  Dim GoodStatus As Boolean

  'Screen
  Dim WrkFromType As String
  Dim WrkToType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkStatus As String
  Dim WrkPost As Boolean
  Public Sub ProcFile()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINVTo = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)

    With MyFrmTXA31B
      WrkFromType = .TxtFromType.Text
      WrkToType = .TxtToType.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkStatus = .TxtStatus.Text
      WrkPost = .ChkPost.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      dserr = ds.Clone
    Else
      ds.Clear()
      dserr.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdserr = dserr
    MyCrViewer.Show()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Status", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkFlds As String
    Dim WrkQry As String
    Dim Good As Boolean
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkAnd As String

    Counter = 0
    WrkAnd = " and "
    WrkQry = "year=" & WrkFromYear
    If WrkFromType <> "" Then
      WrkQry = WrkQry & WrkAnd & "type=" & MyUtils.Quo(WrkFromType)
    End If
    WrkFlds = "NAME, LIST#"

    dsFile = myTXINVQ.GetQry(WrkFlds, WrkQry, 0)
    If dsFile.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
      With dsFile.Tables(0).Rows(I)
        Counter = Counter + 1
        If Trim(WrkStatus) > "" Then
          Good = False
          'Filter - Include Status Codes
          If WrkStatus = String.Empty Then
            Good = True
          End If
          If Not Good And Trim(.Item("STCD1")) <> String.Empty Then
            If InStr(WrkStatus, Trim(.Item("STCD1"))) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(.Item("STCD2")) <> String.Empty Then
            If InStr(WrkStatus, Trim(.Item("STCD2"))) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(.Item("STCD3")) <> String.Empty Then
            If InStr(WrkStatus, Trim(.Item("STCD3"))) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(.Item("STCD4")) <> String.Empty Then
            If InStr(WrkStatus, Trim(.Item("STCD4"))) > 0 Then
              Good = True
            End If
          End If
          If Not Good And Trim(.Item("STCD5")) <> String.Empty Then
            If InStr(WrkStatus, Trim(.Item("STCD5"))) > 0 Then
              Good = True
            End If
          End If
          If Not Good Then GoTo NextRec
        End If

        myTXINVTo.GetOneRecordP(.Item("list#"), WrkToYear, WrkToType)
        If myTXINVTo.RecordNotFound Then GoTo NextRec

        WriteTXINV(.Item("list#"), WrkToYear, WrkToType)
        If GoodStatus Then
          dr = ds.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("year") = .Item("year")
          dr.Item("type") = .Item("type")
          dr.Item("name") = Trim(.Item("name"))
          dr.Item("status") = WrkStcd(0) & " " & WrkStcd(1) & " " & WrkStcd(2) & " " & WrkStcd(3) & " " & WrkStcd(4)
          ds.Tables(0).Rows.Add(dr)
        Else
          dr = dserr.Tables(0).NewRow
          dr.Item("listno") = .Item("list#")
          dr.Item("year") = .Item("year")
          dr.Item("type") = .Item("type")
          dr.Item("name") = Trim(.Item("name"))
          dr.Item("status") = "Status code exists or no room for code"
          dserr.Tables(0).Rows.Add(dr)
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
    Next

CloseFiles:
    myFrmProgress.Close()
    myTXINVQ.CloseFile()
    myTXINVTo.CloseFile()
  End Sub
  Private Sub WriteTXINV(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
    With myTXINVTo
      WrkStcd(0) = Trim(._STCD1)
      WrkStcd(1) = Trim(._STCD2)
      WrkStcd(2) = Trim(._STCD3)
      WrkStcd(3) = Trim(._STCD4)
      WrkStcd(4) = Trim(._STCD5)
      GoodStatus = UpdateStatusCD(WrkStcd)
      If GoodStatus Then
        ._STCD1 = WrkStcd(0)
        ._STCD2 = WrkStcd(1)
        ._STCD3 = WrkStcd(2)
        ._STCD4 = WrkStcd(3)
        ._STCD5 = WrkStcd(4)
        If WrkPost Then
          .UpdateOneRecordP()
          WriteHistory(WrkListNo, WrkYear, WrkType)
        End If
      End If
    End With
  End Sub
  Public Sub WriteHistory(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
    Dim WrkRecID As Integer
    Dim WrkPostDate As Integer
    WrkPostDate = MyUtils.SetDBDate(Date.Now.Date)
    With myTXHST
      WrkRecID = .AutoGenKey()
      .GetOneRecordP(WrkRecID)
      ._RECID = WrkRecID
      ._RCODE = "I"
      ._LISTNO = WrkListNo
      ._YEAR = WrkToYear
      ._TYPE = WrkType
      ._PAMT = 0
      ._IAMT = 0
      ._PCAMT = 0
      ._COMM = "COPY FROM " & WrkFromYear & ": " & WrkStatus
      ._REF = "Status"
      ._ADJCD = ""
      ._PDATE = WrkPostDate
      ._CDATE = WrkPostDate
      ._PRF = "TXA31"
      ._CHDATE = WrkPostDate
      ._CHTIME = MyUtils.SetDBTime(Date.Now)
      .AddOneRecordP()
    End With
  End Sub
  Private Function UpdateStatusCD(ByRef WrkStCd() As String) As Boolean

    Dim J As Integer

    For J = 0 To 4
      If WrkStCd(J) = WrkStatus Then Return False 'Already there 
      If WrkStCd(J) = "" Then
        WrkStCd(J) = WrkStatus
        Return True
      End If
    Next
    Return False
  End Function

End Module