Imports System.Text
Module PrintReport
  Public Sub PrtReport(ByVal dsSel As DataSet)
    Dim ds As DataSet = New DataSet
    Dim dsErr As DataSet = New DataSet
    Dim dr As Data.DataRow
    Dim WrkBal As Decimal
    Dim SaveVndnr As String
    Dim SaveVennm As String
    Dim I As Integer

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      dsErr = ds.Clone
    Else
      ds.Clear()
      dsErr.Clear()
    End If

    WrkBal = 0
    SaveVndnr = ""
    SaveVennm = ""
    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (dsSel.Tables(0).Rows.Count - 1)
      With dsSel.Tables(0).Rows(I)
        If .Item("wsel") Then
          dr = ds.Tables(0).NewRow()
          dr.Item("vndnr") = .Item("vndnr")
          dr.Item("vennm") = .Item("vennm")
          dr.Item("invno") = .Item("invno")
          dr.Item("invdt") = MyUtils.GetDBDateMDY(.Item("invdt"))
          dr.Item("duedt") = MyUtils.GetDBDateMDY(.Item("duedt"))
          dr.Item("amtop") = .Item("amtop")
          ds.Tables(0).Rows.Add(dr)
          If SaveVndnr <> "" And SaveVndnr <> Trim(.Item("vndnr")) Then
            If WrkBal < 0 Then
              dr = dsErr.Tables(0).NewRow()
              dr.Item("vndnr") = SaveVndnr
              dr.Item("vennm") = SaveVennm
              dr.Item("invno") = "Negative Balance"
              dr.Item("invdt") = Date.Today
              dr.Item("duedt") = Date.Today
              dr.Item("amtop") = WrkBal
              dsErr.Tables(0).Rows.Add(dr)
            End If
            WrkBal = 0
          End If
          WrkBal = WrkBal + .Item("amtop")
          SaveVndnr = Trim(.Item("vndnr"))
          SaveVennm = Trim(.Item("vennm"))
        End If
      End With
    Next
    Windows.Forms.Cursor.Current = Cursors.Default

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdsErr = dsErr
    MyCrViewer.Show()
  End Sub
  Public Sub SetFlag(ByVal dsSel As DataSet)
    Dim ds2 As DataSet = New DataSet
    Dim myAPEOPN As APEOPN.MyData
    Dim myAPEOPNL1 As APEOPNL1.MyData
    Dim I As Integer
    Dim J As Integer
    myAPEOPN = New APEOPN.MyData()
    myAPEOPN.MyDBConn = myDBConnect
    myAPEOPNL1 = New APEOPNL1.MyData()
    myAPEOPNL1.MyDBConn = myDBConnect

    Windows.Forms.Cursor.Current = Cursors.WaitCursor()
    For I = 0 To (dsSel.Tables(0).Rows.Count - 1)
      ds2 = myAPEOPNL1.GetAllInvnoL1(dsSel.Tables(0).Rows(I).Item("vndnr"), dsSel.Tables(0).Rows(I).Item("invno"))
      For J = 0 To ds2.Tables(0).Rows.Count - 1
        With ds2.Tables(0).Rows(J)
          If dsSel.Tables(0).Rows(I).Item("wsel") And Trim(.Item("sltpy")) = "" Then
            myAPEOPN.GetOneRecordP(.Item("vndnr"), .Item("invno"), .Item("recno"))
            myAPEOPN._SLTPY = "1"
            myAPEOPN.UpdateOneRecordP()
          End If
          If dsSel.Tables(0).Rows(I).Item("wsel") = 0 And Trim(.Item("sltpy")) = "1" Then
            myAPEOPN.GetOneRecordP(.Item("vndnr"), .Item("invno"), .Item("recno"))
            myAPEOPN._SLTPY = ""
            myAPEOPN.UpdateOneRecordP()
          End If
        End With
      Next
    Next
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
End Module
