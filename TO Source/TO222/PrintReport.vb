Imports System.text
Module PrintReport

Dim Ds As DataSet = New DataSet
Public Sub PrtReport(ByVal WrkPgm As String)
  Dim MyCRViewer As FrmCrViewer
  If Ds.Tables.Count = 0 Then
    BuildDS()
  Else
    Ds.Clear()
  End If
    Select Case WrkPgm
      Case "State"
        GetDetail(WrkPgm)
      Case "Blank"
        GetBlank(WrkPgm)
    End Select
Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkds = Ds
  MyCRViewer.WrkPgm = WrkPgm
  MyCRViewer.ShowDialog()
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("ASSN", Type.GetType("System.String"))
      .Columns.Add("MADDR", Type.GetType("System.String"))
      .Columns.Add("MCITY", Type.GetType("System.String"))
      .Columns.Add("MSTATE", Type.GetType("System.String"))
      .Columns.Add("MZIP", Type.GetType("System.String"))
      .Columns.Add("PHONE", Type.GetType("System.String"))
      .Columns.Add("ADOB", Type.GetType("System.String"))
      .Columns.Add("PROOFE", Type.GetType("System.String"))
      .Columns.Add("PROOFT", Type.GetType("System.String"))
      .Columns.Add("PROOFA", Type.GetType("System.String"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDATE", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
      .Columns.Add("ASSESDATE", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetBlank(ByVal WrkPgm As String)
    Dim dr As Data.DataRow


   
      dr = Ds.Tables(0).NewRow

      dr.Item("alname") = " "
      dr.Item("afname") = " "
    dr.Item("ainit") = " "
    dr.Item("assn") = " "

      dr.Item("maddr") = " "
      dr.Item("mcity") = " "
      dr.Item("mstate") = " "
      dr.Item("mzip") = " "
    dr.Item("ProofE") = " "


    dr.Item("ProofT") = " "


    dr.Item("ProofA") = " "
     

      dr.Item("signedmo") = " "
      dr.Item("signedday") = " "
      dr.Item("signedyear") = " "
    dr.Item("signeddate") = " "
    dr.Item("assrmo") = " "
      dr.Item("assrday") = " "
      dr.Item("assryear") = " "
      dr.Item("phone") = " "
    dr.Item("assesdate") = " "

    Ds.Tables(0).Rows.Add(dr)
   
  End Sub
  Private Sub GetDetail(ByVal WrkPgm As String)
Dim dr As Data.DataRow
Dim sb As StringBuilder
    Dim wrkdobm As String
    Dim wrkdobd As String
    Dim wrkdoby As String

    With MyFrmTO222C
  dr = Ds.Tables(0).NewRow

      dr.Item("alname") = .TxtALName.Text
  dr.Item("afname") = .TxtAFName.Text
  dr.Item("ainit") = .TxtAInit.Text
  sb = New StringBuilder
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 1, 3)), "000"))
  sb.Append("  -  ")
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 4, 2)), "00"))
  sb.Append("  -  ")
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 6, 4)), "0000"))
  dr.Item("assn") = sb.ToString
  sb = Nothing
      dr.Item("maddr") = .TxtMAddr.Text
      dr.Item("mcity") = .TxtMCity.Text
  dr.Item("mstate") = .TxtMState.Text
  If .TxtMZip.Text <> "" Then
    dr.Item("mzip") = Format(MyUtils.CnvSng(.TxtMZip.Text), "00000")
  End If

      If .ChkProofE.Checked Then
        dr.Item("ProofE") = "X"
      End If
      If .ChkProofT.Checked Then
        dr.Item("ProofT") = "X"
      End If
      If .ChkProofA.Checked Then
        dr.Item("ProofA") = "X"
      End If

      dr.Item("signedmo") = Format(.DtPckSigned.Value.Month, "00")
      dr.Item("signedday") = Format(.DtPckSigned.Value.Day, "00")
      dr.Item("signedyear") = .DtPckSigned.Value.Year

      wrkdobm = Format(.DtPckDob.Value.Month, "00")
      If wrkdobm > "" Then
        dr.Item("adob") = Format(.DtPckDob.Value.Month, "00") & "/" &
                        Format(.DtPckDob.Value.Day, "00") & "/" &
                        .DtPckDob.Value.Year
      End If

      If dr.Item("signedmo") > "" Then
        dr.Item("signeddate") = Format(.DtPckSigned.Value.Month, "00") & "/" &
                        Format(.DtPckSigned.Value.Day, "00") & "/" &
                        .DtPckSigned.Value.Year
      End If

      If .DtPckAssr.Checked Then
        dr.Item("assrmo") = Format(.DtPckAssr.Value.Month, "00")
        dr.Item("assrday") = Format(.DtPckAssr.Value.Day, "00")
        dr.Item("assryear") = .DtPckAssr.Value.Year
      End If
      If dr.Item("assrmo") > " " Then
        dr.Item("assesdate") = dr.Item("assrmo") & "/" &
                      dr.Item("assrday") & "/" &
                      dr.Item("assryear")
      End If

      If MyUtils.CnvSng(.TxtPhone.Text) > 0 Then
    dr.Item("phone") = Format(MyUtils.CnvSng(.TxtPhone.Text), "(###) ###-0000")
  End If

      Ds.Tables(0).Rows.Add(dr)
End With
End Sub

End Module






