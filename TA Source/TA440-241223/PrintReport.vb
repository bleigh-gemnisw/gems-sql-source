Imports System.Net.NetworkInformation
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkClass As Integer
  Dim Wrkmake As String
  Dim Wrkpost As String
  Dim WrkSortby As String
  Dim WrkListNo As Integer
  Dim mytxmvd As New TXMVD.MyData(myDBConnect)
  Dim mytxmsrp As New TXMSRP.MyData(myDBConnect)
  Public Sub PrtReport(ByVal ds As DataSet, ByVal WrkClassDesc As String)

    If ds Is Nothing OrElse ds.Tables.Count = 0 Then
      MessageBox.Show("The Data Grid is empty or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If



    With MyFrmTA440B
      WrkClass = MyUtils.CnvSng(.TxtClass.Text)
      Wrkmake = UCase(.TxtMake.Text)
      If .RbSortList.Checked Then WrkSortby = "List"
      If .RbSortName.Checked Then WrkSortby = "Name"
    End With
    If MyFrmTA440C.ChkPost.Checked Then
      Wrkpost = "**Posted**"
      PostDataSet(ds)
      MsgBox("Posted - Records Changed to Non Tax")
    Else
      Wrkpost = ""
    End If



Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkFromClass = WrkClass
    MyCrViewer.WrkFromClassDesc = WrkClassDesc
    MyCrViewer.WrkMake = Wrkmake
    MyCrViewer.WrkPost = Wrkpost

    MyCrViewer.Show()
  End Sub




  '=============================================================================================
  ' Post change to TXMVD and TXMSRP
  ' maybe to log file
  '=============================================================================================

  Public Sub PostDataSet(ds As DataSet)


    ' Get the first table in the dataset
    Dim table As DataTable = ds.Tables(0)


    ' Iterate through each row in the table
    For Each row As DataRow In table.Rows
      ' Skip deleted rows
      If row.RowState = DataRowState.Deleted Then Continue For

      ' Get the value of the "Listno" field
      ' Assign the value of the "Listno" field to the global variable wrklistno
      WrkListNo = If(IsDBNull(row("Listno")), 0, Convert.ToInt32(row("Listno")))
      If WrkListNo = 0 Then Continue For
      ' Call SaveData with the value of wrklistno
      SaveData()
    Next
  End Sub


  Public Sub SaveData()
    mytxmvd.GetOneRecordP(WrkListNo)
    MoveToFile()
    mytxmvd.UpdateOneRecordP()
    'Save to MSRP File
    With mytxmsrp
      .GetOneRecordP(Trim(mytxmvd._VINNO))
      ._NONTAX = "Y"
      If .RecordNotFound Then
        ._VINNO = Trim(mytxmvd._VINNO)
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  End Sub


  Private Sub MoveToFile()

    With mytxmvd

      ._CAT = "2"
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With
  End Sub


End Module






