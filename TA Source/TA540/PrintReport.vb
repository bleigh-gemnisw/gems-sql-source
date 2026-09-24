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
  Dim myTXSUPP As New TXSUPP.MyData(myDBConnect)
  Dim myTXMSRP As New TXMSRP.MyData(myDBConnect)
  Public Sub PrtReport(ByVal ds As DataSet, ByVal WrkClassDesc As String)

    If ds Is Nothing OrElse ds.Tables.Count = 0 Then
      MessageBox.Show("The Data Grid is empty or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return
    End If

    With MyFrmTA540B
      WrkClass = MyUtils.CnvSng(.TxtClass.Text)
      Wrkmake = UCase(.TxtMake.Text)
      If .RbSortList.Checked Then WrkSortby = "List"
      If .RbSortName.Checked Then WrkSortby = "Name"
      If .RbSortMake.Checked Then WrkSortby = "Make"
    End With

    If MyFrmTA540C.ChkPost.Checked Then
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
  ' Post change to TXSUPP and TXMSRP
  Public Sub PostDataSet(ds As DataSet)
    Dim I As Integer
    For I = 0 To (MyFrmTA540C.C1TrueDBGrid1.Splits(0).Rows.Count - 1)
      WrkListNo = MyFrmTA540C.C1TrueDBGrid1.Item(I, "listno")
      SaveData()
    Next
  End Sub
  Public Sub SaveData()
    myTXSUPP.GetOneRecordP(WrkListNo)
    MoveToFile()
    myTXSUPP.UpdateOneRecordP()
    'Save to MSRP File
    With myTXMSRP
      .GetOneRecordP(Trim(myTXSUPP._VINNO))
      ._NONTAX = "Y"
      If .RecordNotFound Then
        ._VINNO = Trim(myTXSUPP._VINNO)
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  End Sub
  Private Sub MoveToFile()
    With myTXSUPP
      ._CAT = "2"
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With
  End Sub
End Module







