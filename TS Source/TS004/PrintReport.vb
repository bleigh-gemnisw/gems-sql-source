Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myMFTRAN As MFTRAN.myData

Dim ds1 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim ds As DataSet = New DataSet

Friend wrkmfyear As Integer
Friend wrkmfnam As String
Friend wrkmfcatg As String
Friend wrkmfadd1 As String
Friend wrkstampd As Double
Friend wrkstampt As Double


Public Sub PrtReport()
  
  myMFTRAN = New MFTRAN.mydata(MyDBConnect)
  If ds1.Tables.Count = 0 Then
    BuildDS(ds1)
  Else
    ds1.Clear()
  End If

 myMFTRAN.GetOneRecordP(wrkmfyear, wrkmfcatg, wrkmfnam, wrkmfadd1, wrkstampd, wrkstampt)
  If myMFTRAN.RecordNotFound Then Exit Sub
  

  
  With myMFTRAN
    dr = ds1.Tables(0).NewRow
    dr.Item("mfnam") = Trim(._MFNAM)
    dr.Item("addl1") = Trim(._MFADD1)
    If Trim(._MFADD2) > "" Then
    dr.Item("addl2") = Trim(._MFADD2)
    dr.Item("addl3") = Trim(._MFCITY) + " " + Trim(._MFST) + " " + Format$(._MFZIP5, "00000") + " " + Format$(._MFZIP4, "0000")

    Else
    dr.Item("addl2") = Trim(._MFCITY) + " " + Trim(._MFST) + " " + Format$(._MFZIP5, "00000") + " " + Format$(._MFZIP4, "0000")
    dr.Item("addl3") = ""
    End If
    
    dr.Item("phone") = ._MFTEL.ToString("###-###-####")



    dr.Item("mfcyr") = ._MFCYR
    dr.Item("mfmake") = Trim(._MFMAKE)
    dr.Item("mfmod") = Trim(._MFMOD)
    dr.Item("mfcolr") = Trim(._MFCOLR)
    dr.Item("mfcap") = Trim(._MFCAP)
    dr.Item("mflic") = Trim(._MFLIC)
    dr.Item("mfregno") = Trim(._MFREGNo)
    dr.Item("mfvinno") = Trim(._MFVINNo)
		dr.Item("fyr") = wrkmfyear
		dr.Item("tyr") = wrkmfyear + 1
  End With
    ds1.Tables(0).Rows.Add(dr)

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1


  MyCrViewer.Show()

End Sub

  Private Sub BuildDS(ByRef ds1 As DataSet)
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Mfnam", Type.GetType("System.String"))
      .Columns.Add("addl1", Type.GetType("System.String"))
      .Columns.Add("addl2", Type.GetType("System.String"))
      .Columns.Add("addl3", Type.GetType("System.String"))
      .Columns.Add("phone", Type.GetType("System.String"))
      .Columns.Add("mfcyr", Type.GetType("System.Int32"))
      .Columns.Add("mfmake", Type.GetType("System.String"))
      .Columns.Add("mfmod", Type.GetType("System.String"))
      .Columns.Add("mfcolr", Type.GetType("System.String"))
      .Columns.Add("mfcap", Type.GetType("System.Double"))
      .Columns.Add("mflic", Type.GetType("System.String"))
      .Columns.Add("mfregno", Type.GetType("System.String"))
      .Columns.Add("mfvinno", Type.GetType("System.String"))
      .Columns.Add("fyr", Type.GetType("System.Int32"))
      .Columns.Add("tyr", Type.GetType("System.Int32"))

    End With
    ds1.Tables.Add(myTable)



  End Sub

  

End Module






