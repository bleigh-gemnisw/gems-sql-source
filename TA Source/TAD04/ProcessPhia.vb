Imports System.Reflection

Module ProcessPhia
  Dim myTXPHIA As TXPHIA.MyData

  Dim WrkYear As Integer

  Public Sub ProcPhia()

    Dim WrkCount As Integer

    myTXPHIA = New TXPHIA.MyData(myDBConnect)
    With MyFrmTAD04B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    WrkCount = myTXPHIA.GetIsPosted(WrkYear)
    If WrkCount > 0 Then 'if already archived then abort
      MyArchived = True
      Exit Sub
    End If

    myTXPHIA.ArchiveQry(WrkYear)

    myTXPHIA.CloseFile()
  End Sub
End Module
