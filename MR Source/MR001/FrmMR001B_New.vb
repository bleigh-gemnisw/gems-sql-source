Public Class FrmMR001B_New
  Dim myMRBCH As MRBCH.MyData
  Dim myMRCNTL As MRCNTL.MyData
  Friend Create As Boolean

  Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
    Dim WrkNextBatch As Integer

    myMRCNTL.GetOneRecordP("")
    If Create Then
      If myMRCNTL.RecordNotFound Then
        With myMRCNTL
          ._LBCHNO = 1
          .AddOneRecordP()
          WrkNextBatch = ._LBCHNO
        End With
      Else
        With myMRCNTL
          ._LBCHNO = ._LBCHNO + 1
          .UpdateOneRecordP()
          WrkNextBatch = ._LBCHNO
        End With
      End If
    Else
      WrkNextBatch = MyFrmMR001B.DataGrdView.Item(0, MyFrmMR001B.DataGrdView.CurrentRow.Index).Value
    End If

    myMRBCH.GetOneRecordP(WrkNextBatch)
    With myMRBCH
      ._STATUS = "S"
      ._DESCR = TxtDescr.Text
      ._RECDT = MyUtils.SetDBDate(DtPckReceipt.Value)
      ._STRDT = MyUtils.SetDBDate(DtPckStart.Value)
      ._ENDDT = MyUtils.SetDBDate(DtPckEnd.Value)
      ._PRF = Mid(MyUserID, 1, 10)
      If Mid(LblCodes.Text, 1, 1) <> "*" Then
        ._CODES = LblCodes.Text
      Else
        ._CODES = String.Empty
      End If
      If Create Then
        ._BCHNO = WrkNextBatch
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With

    With MyFrmMR001
      .TBarNew.Enabled = True
      .TBarChange.Enabled = True
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmMR001B.FormatGrid()
    MyFrmMR001B.Show()
    If Create Then
      MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")
    End If
    Me.Close()

  End Sub
  Private Sub FrmMR001B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    MyFrmMR001.SbpScreen.Text = "MR001B_New"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmMR001_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkBatchNo As Integer
    myMRBCH = New MRBCH.MyData()
    myMRBCH.MyDBConn = myDBConnect
    myMRCNTL = New MRCNTL.MyData()
    myMRCNTL.MyDBConn = myDBConnect
    With MyFrmMR001
      .TBarNew.Enabled = False
      .TBarChange.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    If Create Then
      DtPckReceipt.Value = Today.Date
      DtPckStart.Value = Today.Date
      DtPckEnd.Value = Today.Date
      LblCodes.Text = "* ALL Codes *"
      MySelCodes = String.Empty
    Else
      Me.Text = "Change Batch"
      BtnCreate.Text = "Change Batch"
      WrkBatchNo = MyFrmMR001B.DataGrdView.Item(0, MyFrmMR001B.DataGrdView.CurrentRow.Index).Value
      With myMRBCH
        .GetOneRecordP(WrkBatchNo)
        DtPckReceipt.Value = MyUtils.GetDBDate(._RECDT)
        DtPckStart.Value = MyUtils.GetDBDate(._STRDT)
        DtPckEnd.Value = MyUtils.GetDBDate(._ENDDT)
        TxtDescr.Text = Trim(._DESCR)
        LblCodes.Text = RTrim(._CODES)
        MySelCodes = RTrim(._CODES)
      End With
    End If
  End Sub

  Private Sub BtnSelCodes_Click(sender As Object, e As EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    MyFrmSelCodes.ShowDialog()
    If MySelCodes = "" Then
      LblCodes.Text = "* ALL Codes *"
    Else
      LblCodes.Text = MySelCodes
    End If
  End Sub
End Class