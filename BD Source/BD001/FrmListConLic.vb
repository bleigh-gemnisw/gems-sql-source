Public Class FrmListConLic
  Friend WrkFormID As String
  Friend WrkLic1 As String
  Friend WrkLic2 As String
  Friend WrkLic3 As String
  Friend WrkLic4 As String
  Friend WrkLic5 As String
Private Sub FrmListConLic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim ds As DataSet = New DataSet
    Dim dr As DataRow
    Dim myTable As New DataTable
    Dim I As Integer
    With myTable
      .TableName = "mytable"
      .Columns.Add("License", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

    For I = 0 To 4
      dr = ds.Tables(0).NewRow
      Select Case I
      Case 0
        dr("license") = WrkLic1
      Case 1
        dr("license") = WrkLic2
      Case 2
        dr("license") = WrkLic3
      Case 3
        dr("license") = WrkLic4
      Case 4
        dr("license") = WrkLic5
      End Select
      If dr("license") <> "" Then
        ds.Tables(0).Rows.Add(dr)
      End If
    Next

    With DataGrdView
      .DataSource = ds.Tables(0)
      .Refresh()
    End With
  End Sub
  Private Sub DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    Select Case WrkFormID
      Case "CD"
        With MyFrmBD001CD
          .TxtCoLic.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        End With
      Case "CE"
        With MyFrmBD001CE
          .TxtCoLic.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        End With
      Case "CH"
        With MyFrmBD001CH
          .TxtCoLic.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        End With
      Case Else
        With MyFrmBD001C
          .TxtCoLic.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
        End With
    End Select
    Me.Close()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub FrmListConLic_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmBD001.TBarAuth.Enabled = True
  Select Case WrkFormID
  Case "CD"
    If MyFrmBD001CD.WrkRecID > 0 Then
      MyFrmBD001.TBarDelete.Enabled = True
    End If
    MyFrmBD001.TBarSave.Enabled = True
    With MyFrmBD001CD
      .Show()
    End With
  Case "CE"
    If MyFrmBD001CE.WrkRecID > 0 Then
      MyFrmBD001.TBarDelete.Enabled = True
    End If
    MyFrmBD001.TBarSave.Enabled = True
    With MyFrmBD001CE
      .Show()
    End With
  Case "CH"
    If MyFrmBD001CH.WrkRecID > 0 Then
      MyFrmBD001.TBarDelete.Enabled = True
    End If
    MyFrmBD001.TBarSave.Enabled = True
    With MyFrmBD001CH
      .Show()
    End With
  Case Else
    If MyFrmBD001C.WrkRecID > 0 Then
      MyFrmBD001.TBarDelete.Enabled = True
    End If
    MyFrmBD001.TBarSave.Enabled = True
    With MyFrmBD001C
      .Show()
    End With
  End Select
  'Memory Cleanup
  MyFrmListConLic = Nothing

End Sub
End Class





