Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXMVD As TXMVD.myData
Dim myTXMVDCL1 As TXMVDCL1.myData

Dim ds As DataSet = New DataSet
Dim dsErr As DataSet = New DataSet
Dim DsTXMVD As DataSet = New DataSet
Dim DsTXMVDC As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
  myTXMVD = New TXMVD.mydata(MyDBConnect)
  myTXMVDCL1 = New TXMVDCL1.mydata(MyDBConnect)

  With MyFrmTA404B
    If .ChkPost.Checked Then WrkPost = True
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
    dsErr = ds.Clone
  Else
    ds.Clear()
    dsErr.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkdsErr = dsErr
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("PrevListNo", Type.GetType("System.Int32"))
      .Columns.Add("Excd1", Type.GetType("System.String"))
      .Columns.Add("Excd2", Type.GetType("System.String"))
      .Columns.Add("Excd3", Type.GetType("System.String"))
      .Columns.Add("Excd4", Type.GetType("System.String"))
      .Columns.Add("Excd5", Type.GetType("System.String"))
      .Columns.Add("Exam1", Type.GetType("System.Int32"))
      .Columns.Add("Exam2", Type.GetType("System.Int32"))
      .Columns.Add("Exam3", Type.GetType("System.Int32"))
      .Columns.Add("Exam4", Type.GetType("System.Int32"))
      .Columns.Add("Exam5", Type.GetType("System.Int32"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkNet As Integer
    Dim WrkExam As Integer
    Dim WrkErrMsg As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkSort = ""
    WrkQry = "CAT <> '2'"

    DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXMVD.Tables(0).Rows(I)
        WrkErrMsg = ""
        myTXMVDCL1.GetOneRecordP(Trim(.Item("vinno")))
        If Not myTXMVDCL1.RecordNotFound Then
          With myTXMVDCL1
            If ._CCNO > 0 Then
              WrkNet = ._VALUE - ._CEXA1 - ._CEXA2 - ._CEXA3 - ._CEXA4 - ._CEXA5
              WrkExam = ._CEXA1 + ._CEXA2 + ._CEXA3 + ._CEXA4 + ._CEXA5
            Else
              WrkNet = ._VALUE - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
              WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
            End If
            If WrkNet < 0 Then
              WrkErrMsg = "*** Exemption total is more than value ***"
            End If
            If Trim(DsTXMVD.Tables(0).Rows(I).Item("regno")) <> Trim(._REGNO) Then
              WrkErrMsg = "*** Plate is different: " & Trim(._REGNO) & " ***"
            End If
            If DsTXMVD.Tables(0).Rows(I).Item("dob") = 0 Then
              If Trim(DsTXMVD.Tables(0).Rows(I).Item("name")) <> Trim(._NAME) Then
                WrkErrMsg = "*** Name is different: " & Trim(._NAME) & " ***"
              End If
            Else
              If DsTXMVD.Tables(0).Rows(I).Item("dob") <> ._DOB Then
                WrkErrMsg = "*** DOB is different: " & Trim(._NAME) & " ***"
              End If
            End If
          End With
        Else
          WrkErrMsg = "*** Record not found ***"
        End If
        If WrkErrMsg = "" Then
          dr = ds.Tables(0).NewRow
        Else
          dr = dsErr.Tables(0).NewRow
        End If
        dr.Item("name") = .Item("name")
        dr.Item("vinno") = .Item("vinno")
        dr.Item("regno") = .Item("regno")
        dr.Item("listno") = .Item("list#")
        dr.Item("prevlistno") = 0
        dr.Item("errmsg") = WrkErrMsg

        If Not myTXMVDCL1.RecordNotFound Then
          With myTXMVDCL1
            If WrkExam > 0 Then
              dr.Item("prevlistno") = ._LISTNO
              If ._CCNO > 0 Then
                dr.Item("excd1") = ._CCCD1
                dr.Item("excd2") = ._CCCD2
                dr.Item("excd3") = ._CCCD3
                dr.Item("excd4") = ._CCCD4
                dr.Item("excd5") = ._CCCD5
                dr.Item("exam1") = ._CEXA1
                dr.Item("exam2") = ._CEXA2
                dr.Item("exam3") = ._CEXA3
                dr.Item("exam4") = ._CEXA4
                dr.Item("exam5") = ._CEXA5
              Else
                dr.Item("excd1") = ._EXCD1
                dr.Item("excd2") = ._EXCD2
                dr.Item("excd3") = ._EXCD3
                dr.Item("excd4") = ._EXCD4
                dr.Item("excd5") = ._EXCD5
                dr.Item("exam1") = ._EXAM1
                dr.Item("exam2") = ._EXAM2
                dr.Item("exam3") = ._EXAM3
                dr.Item("exam4") = ._EXAM4
                dr.Item("exam5") = ._EXAM5
              End If
              If WrkErrMsg = "" Then
                ds.Tables(0).Rows.Add(dr)
              Else
                dsErr.Tables(0).Rows.Add(dr)
              End If
            End If
          End With
        End If

        If WrkPost And dr.Item("prevlistno") > 0 And WrkErrMsg = String.Empty Then
          UpdateTXMVD(.Item("list#"))
        End If
      End With
NextRec:
      With myFrmProgress
        If DsTXMVD.Tables(0).Rows.Count > 1 Then
          WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
          If SavePct <> WrkPct Then
            .ProgBar1.Value = WrkPct
            .Refresh()
            SavePct = WrkPct
            Application.DoEvents()
          End If
        End If
      End With
    Next

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
    myTXMVD.CloseFile()

  End Sub
  Private Sub UpdateTXMVD(ByVal List As Integer)
  myTXMVD.GetOneRecordP(List)
  With myTXMVD
    If myTXMVDCL1._CCNO > 0 Then
      ._EXCD1 = myTXMVDCL1._CCCD1
      ._EXCD2 = myTXMVDCL1._CCCD2
      ._EXCD3 = myTXMVDCL1._CCCD3
      ._EXCD4 = myTXMVDCL1._CCCD4
      ._EXCD5 = myTXMVDCL1._CCCD5
      ._EXAM1 = myTXMVDCL1._CEXA1
      ._EXAM2 = myTXMVDCL1._CEXA2
      ._EXAM3 = myTXMVDCL1._CEXA3
      ._EXAM4 = myTXMVDCL1._CEXA4
      ._EXAM5 = myTXMVDCL1._CEXA5
    Else
      ._EXCD1 = myTXMVDCL1._EXCD1
      ._EXCD2 = myTXMVDCL1._EXCD2
      ._EXCD3 = myTXMVDCL1._EXCD3
      ._EXCD4 = myTXMVDCL1._EXCD4
      ._EXCD5 = myTXMVDCL1._EXCD5
      ._EXAM1 = myTXMVDCL1._EXAM1
      ._EXAM2 = myTXMVDCL1._EXAM2
      ._EXAM3 = myTXMVDCL1._EXAM3
      ._EXAM4 = myTXMVDCL1._EXAM4
      ._EXAM5 = myTXMVDCL1._EXAM5
    End If
  End With
  myTXMVD.UpdateOneRecordP()
End Sub
End Module






