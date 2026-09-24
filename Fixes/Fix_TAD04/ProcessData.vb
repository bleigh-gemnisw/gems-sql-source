Imports System.Text
Module ProcessData
  Public Sub ProcData()
    Dim WrkRE As String
    Dim WrkPP As String
    Dim WrkMV As String
    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    MyArchived = False
    WrkRE = "Archived"
    WrkPP = "Archived"
    WrkMV = "Archived"
    If MyFrmFix_TAD04B.RbRE.Checked Then
      MyFrmFix_TAD04B.GrpFreeze.Visible = True
      ProcRE()
      If MyArchived Then
        WrkRE = "Skipped"
      End If
      MyArchived = False
      ProcPP()
      If MyArchived Then
        WrkPP = "Skipped"
      End If
      MyArchived = False
      ProcMV()
      If MyArchived Then
        WrkMV = "Skipped"
      End If
      Application.DoEvents()
      Windows.Forms.Cursor.Current = Cursors.Default
      MsgBox("RE " & WrkRE & vbCr & "PP " & WrkPP & vbCr & "MV " & WrkMV, MsgBoxStyle.Information, "Process Completed")
      MyFrmFix_TAD04B.LblMsg.Text = "Done!"
      MyFrmFix_TAD04B.GrpFreeze.Visible = False
    End If
    If MyFrmFix_TAD04B.RbSU.Checked Then
      ProcSU()
    End If
    If MyFrmFix_TAD04B.RbPro.Checked Then
      ProcProrate()
    End If
    Application.DoEvents()
    Windows.Forms.Cursor.Current = Cursors.Default
    If Not MyArchived Then
      MsgBox("File has been Archived", MsgBoxStyle.Information, "Process Completed")
      MyFrmFix_TAD04B.LblMsg.Text = "Done!"
    Else
      MsgBox("File has been already been Archived", MsgBoxStyle.Exclamation, "Process Skipped")
      MyFrmFix_TAD04B.LblMsg.Text = ""
    End If

  End Sub
End Module







