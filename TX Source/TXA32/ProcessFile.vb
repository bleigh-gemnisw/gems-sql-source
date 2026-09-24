Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTAXCOMQ As TAXCOMQ.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myTXINV As TXINV.MyData
  Dim dsFile As DataSet = New DataSet
  Dim ds As DataSet = New DataSet
  Dim dserr As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen
  Dim WrkType As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkPost As Boolean
  Public Sub ProcFile()
    myTAXCOMQ = New TAXCOMQ.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXA32B
      WrkType = .TxtType.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
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
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim SaveList As Integer
    Dim WrkFlds As String
    Dim WrkQry As String
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkAnd As String

    Counter = 0
    WrkAnd = " and "
    WrkQry = "year=" & WrkFromYear
    If WrkType <> "" Then
      WrkQry = WrkQry & WrkAnd & "type=" & MyUtils.Quo(WrkType)
    End If
    WrkFlds = "LIST#"

    dsFile = myTAXCOMQ.GetQry(WrkFlds, WrkQry, 0)
    If dsFile.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
      With dsFile.Tables(0).Rows(I)
        Counter = Counter + 1
        If SaveList <> .Item("list#") Then
          myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
          If Not myTXINV.RecordNotFound Then
            WriteTAXCOM(.Item("list#"), .Item("type"), .Item("year"))
            dr = ds.Tables(0).NewRow
            dr.Item("listno") = .Item("list#")
            dr.Item("year") = .Item("year")
            dr.Item("type") = .Item("type")
            dr.Item("name") = Trim(myTXINV._NAME)
            ds.Tables(0).Rows.Add(dr)
          End If
          SaveList = .Item("list#")
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
    myTAXCOMQ.CloseFile()
    myTAXCOM.CloseFile()
  End Sub
  Private Sub WriteTAXCOM(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer)
    With myTAXCOM
      Dim dsCom As DataSet = New DataSet
      Dim I As Integer
      Dim WrkStr As String

      myTAXCOM.DeleteKeyComment(WrkListNo, WrkType, WrkYear + 1)
      dsCom = myTAXCOM.Getcomments(WrkListNo, WrkType, WrkYear)
      WrkStr = String.Empty
      For I = 0 To dsCom.Tables(0).Rows.Count - 1
        If WrkPost Then
          With myTAXCOM
            .GetOneRecordP(WrkListNo, WrkType, WrkYear + 1, I + 1)
            ._CMNT = dsCom.Tables(0).Rows(I).Item("cmnt")
            ._CSEQ = I + 1
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear + 1
            .AddOneRecordP()
          End With
        End If
      Next
    End With
  End Sub
End Module