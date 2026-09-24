Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myMFTRANQ As MFTRANQ.myData
Dim MyMFTCLS As MFTCLS.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsMFTRNH As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow
Dim ds As DataSet = New DataSet
Dim WrkSortby As String
Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSelection As String

Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTFee As Decimal

Public Sub PrtReport()

  myMFTRANQ = New MFTRANQ.mydata(MyDBConnect)
  MyMFTCLS = New MFTCLS.mydata(MyDBConnect)

  With MyFrmTS006B
    
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    

  End With

  If ds1.Tables.Count = 0 Then
    BuildDS(ds1)
    BuildDS2(ds2)
  Else
    ds1.Clear()
    ds2.Clear()

  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  MyCrViewer.wrkds2 = ds2

  MyCrViewer.Show()

End Sub

  Private Sub BuildDS(ByRef ds1 As DataSet)
    Dim mylist As New DataTable
   
    With mylist
'mftdat/mfttim/mfyear/mfcatg/mfnam.mfadd1/mfperno/mflfee
      .TableName = "myList"
      .Columns.Add("Sortby", Type.GetType("System.String"))
      .Columns.Add("MfLiss", Type.GetType("System.DateTime"))
      .Columns.Add("Mfliss", Type.GetType("System.DateTime"))
      .Columns.Add("Mfyear", Type.GetType("System.Int32"))
      .Columns.Add("Mfcls", Type.GetType("System.String"))
      .Columns.Add("Mfnam", Type.GetType("System.String"))
      .Columns.Add("Mfadd1", Type.GetType("System.String"))
      .Columns.Add("Mfperno", Type.GetType("System.Int32"))
      .Columns.Add("Mflfee", Type.GetType("System.Double"))
      .Columns.Add("Mfcolr", Type.GetType("System.String"))
      .Columns.Add("Mfmake", Type.GetType("System.String"))
      .Columns.Add("Mfmod", Type.GetType("System.String"))
      .Columns.Add("Mfvinno", Type.GetType("System.String"))
      .Columns.Add("Mfregno", Type.GetType("System.String"))
      .Columns.Add("Mfcyr", Type.GetType("System.Int32"))
      .Columns.Add("Mflic", Type.GetType("System.String"))
      .Columns.Add("mfcap", Type.GetType("System.Double"))

       

    End With
    ds1.Tables.Add(mylist)



  End Sub
Private Sub BuildDS2(ByRef ds2 As DataSet)
    Dim myTable As New DataTable

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
    ds2.Tables.Add(myTable)


  End Sub

Private Sub GetDetail()

Dim WrkSort As String
Dim WrkQry As String

Dim Counter As Integer
Dim SaveSortData As String
If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "MFYEAR = " & WrkFromGLYear

WrkSort = "MFNAM"

myMFTRANQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()


SaveSortData = ""
ReadNext:
  myMFTRANQ.ReadQry()
  If Not myMFTRANQ.IsEOF Then
    Counter = Counter + 1
    With myMFTRANQ

    dr = ds1.Tables(0).NewRow

    dr.Item("MfLiss") = MyUtils.GetDBDate(._MFLISS)
    dr.Item("mfyear") = ._MFYEAR
    dr.Item("mfcls") = ._MFCLS
    dr.Item("mfnam") = ._MFNAM
    dr.Item("mfadd1") = ._MFADD1
    dr.Item("mfperno") = ._MFPERNo

    dr.Item("Mfcolr") = Trim(._MFCOLR)
    dr.Item("Mfmake") = Trim(._MFMAKE)
    dr.Item("Mfmod") = Trim(._MFMOD)
    dr.Item("Mfvinno") = Trim(._MFVINNo)
    dr.Item("Mfregno") = Trim(._MFREGNo)
    dr.Item("Mfcyr") = ._MFCYR
    dr.Item("Mflic") = Trim(._MFLIC)
    dr.Item("mfcap") = ._MFCAP

   '====================== get fee
    MyMFTCLS.GetOneRecordP(Trim(._MFCLS))
    If Not MyMFTCLS.RecordNotFound Then
      dr.Item("mflfee") = MyMFTCLS._MFTFEE
    Else
      dr.Item("mflfee") = 0
    End If
        '======================
'===============================
    dr2 = ds2.Tables(0).NewRow
    dr2.Item("mfnam") = Trim(._MFNAM)
    dr2.Item("addl1") = Trim(._MFADD1)
    If Trim(._MFADD2) > "" Then
    dr2.Item("addl2") = Trim(._MFADD2)
    dr2.Item("addl3") = Trim(._MFCITY) + " " + Trim(._MFST) + " " + Format$(._MFZIP5, "00000") + " " + Format$(._MFZIP4, "0000")

    Else
    dr2.Item("addl2") = Trim(._MFCITY) + " " + Trim(._MFST) + " " + Format$(._MFZIP5, "00000") + " " + Format$(._MFZIP4, "0000")
    dr2.Item("addl3") = ""
    End If

    dr2.Item("phone") = ._MFTEL.ToString("###-###-####")



    dr2.Item("mfcyr") = ._MFCYR
    dr2.Item("mfmake") = Trim(._MFMAKE)
    dr2.Item("mfmod") = Trim(._MFMOD)
    dr2.Item("mfcolr") = Trim(._MFCOLR)
    dr2.Item("mfcap") = Trim(._MFCAP)
    dr2.Item("mflic") = Trim(._MFLIC)
    dr2.Item("mfregno") = Trim(._MFREGNo)
    dr2.Item("mfvinno") = Trim(._MFVINNo)
    dr2.Item("fyr") = WrkFromGLYear + 1
    dr2.Item("tyr") = WrkFromGLYear + 2


'===============================

  End With

  WrkTCount = WrkTCount + 1
  ds1.Tables(0).Rows.Add(dr)
  ds2.Tables(0).Rows.Add(dr2)
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
  End If



myFrmProgress.Close()

myMFTRANQ.CloseFile()



End Sub

  
  

End Module






