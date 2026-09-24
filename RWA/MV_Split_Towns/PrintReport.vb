Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer

  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Public Sub PrtReport()

    If ds.Tables.Count = 0 Then
      BuildDs(ds)
    Else
      ds.Clear()
    End If

    If MyFrmDMVB.RbMV.Checked Then
      GetDetailCSV(25)
    End If
    If MyFrmDMVB.RbOther.Checked Then
      GetDetailCSV()
    End If
    If MyFrmDMVB.RbCOA.Checked Then
      GetDetail()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .Show()
    End With

  End Sub
  Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Townno", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int32"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStream As FileStream = New FileStream(MyFrmDMVB.LblFilePath.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sw As StreamWriter
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkTownNo As String
    Dim WrkCount As Integer
    Dim WrkTownFile As String
    Dim SaveTownNo As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCount = 0
    I = 0
    SaveTownNo = String.Empty

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    I = I + strBuffer.Length

    WrkTownNo = Mid(strBuffer, 41, 3)
    If SaveTownNo = String.Empty Then
      WrkTownFile = MyFrmDMVB.LblFilePath.Text & "-" & WrkTownNo & ".txt"
      sw = New StreamWriter(WrkTownFile, False)
    End If
    If SaveTownNo <> String.Empty And SaveTownNo <> WrkTownNo Then
      dr = ds.Tables(0).NewRow
      dr.Item("townno") = SaveTownNo
      dr.Item("count") = WrkCount
      ds.Tables(0).Rows.Add(dr)
      WrkCount = 0
      'Program Warning is OK here
      sw.Close()
      sw = Nothing
      WrkTownFile = MyFrmDMVB.LblFilePath.Text & "-" & WrkTownNo & ".txt"
      sw = New StreamWriter(WrkTownFile, False)
    End If

    WrkCount = WrkCount + 1
    sw.WriteLine(strBuffer)
    SaveTownNo = WrkTownNo

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With

    GoTo NextLine

End_of_file:
    If WrkCount > 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("townno") = SaveTownNo
      dr.Item("count") = WrkCount
      ds.Tables(0).Rows.Add(dr)
    End If

    sr.Close()
    sw.Close()
    myFrmProgress.Close()

  End Sub
  Private Sub GetDetailCSV(Optional ByVal WrkPos As Integer = -1)
    Dim WrkStream As FileStream = New FileStream(MyFrmDMVB.LblFilePath.Text, FileMode.Open)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sw As StreamWriter
    Dim strBuffer As String
    Dim HdrBuffer As String
    Dim SArray As String()
    Dim WrkFileSize As Integer
    Dim I As Integer
    Dim WrkTownNo As String
    Dim WrkCount As Integer
    Dim WrkTownFile As String
    Dim SaveTownNo As String

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    WrkCount = 0
    I = 0
    SaveTownNo = String.Empty
    HdrBuffer = sr.ReadLine
    If WrkPos < 0 Then
      SArray = Parse(HdrBuffer, ",")
      For I = 0 To SArray.GetUpperBound(0)
        If Mid(SArray(I), 1, 8) = "Tax Town" Then
          WrkPos = I
          Exit For
        End If
      Next
    End If

NextLine:
    strBuffer = sr.ReadLine
    If strBuffer Is Nothing Then
      GoTo End_of_file
      Exit Sub
    End If

    SArray = Parse(strBuffer, ",")
    I = I + strBuffer.Length

    WrkTownNo = 0
    If WrkPos >= 0 Then
      WrkTownNo = SArray(WrkPos)
    Else
      MsgBox("Unable to find field Tax Town. Rename field and rerun.", MsgBoxStyle.Exclamation, "Cannot process file")
      GoTo End_of_file
    End If

    If SaveTownNo = String.Empty Then
      WrkTownFile = MyFrmDMVB.LblFilePath.Text & "-" & WrkTownNo & ".csv"
      sw = New StreamWriter(WrkTownFile, False)
      sw.WriteLine(HdrBuffer)
    End If
    If SaveTownNo <> String.Empty And SaveTownNo <> WrkTownNo Then
      dr = ds.Tables(0).NewRow
      dr.Item("townno") = SaveTownNo
      dr.Item("count") = WrkCount
      ds.Tables(0).Rows.Add(dr)
      WrkCount = 0
      'Program Warning is OK here
      sw.Close()
      sw = Nothing
      WrkTownFile = MyFrmDMVB.LblFilePath.Text & "-" & WrkTownNo & ".csv"
      sw = New StreamWriter(WrkTownFile, False)
      sw.WriteLine(HdrBuffer)
    End If

    WrkCount = WrkCount + 1
    sw.WriteLine(strBuffer)
    SaveTownNo = WrkTownNo

NextRec:
    With myFrmProgress
      WrkPct = (I / WrkFileSize) * 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With

    GoTo NextLine

End_of_file:
    If WrkCount > 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("townno") = SaveTownNo
      dr.Item("count") = WrkCount
      ds.Tables(0).Rows.Add(dr)
    End If

    sr.Close()
    sw.Close()
    myFrmProgress.Close()

  End Sub


End Module
