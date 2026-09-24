Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myGLACCTQ As GLACCTQ.MyData
  Dim myGLBUDGET As GLBUDGET.MyData

  'Screen  
  Dim WrkSelFund As Integer
  Dim WrkSelsfund As Integer
  'General
  Dim SaveGltyp As String
  Public Sub ProcFile()
    myGLACCTQ = New GLACCTQ.MyData()
    myGLACCTQ.MyDBConn = myDBConnect
    myGLBUDGET = New GLBUDGET.MyData()
    myGLBUDGET.MyDBConn = myDBConnect

    With MyFrmGL531B
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
    End With

    UpdateAccts(WrkSelFund)
    MsgBox("Process Completed", MsgBoxStyle.Information, "Budget File Refreshed")
  End Sub
  Private Sub UpdateAccts(ByVal WrkFund As Integer)
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "ACREC=''" & WrkAnd & "GLTYP in ('R','X')"
    If WrkFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR=" & WrkFund
    End If
    WrkSort = ""
    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Update accounts"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    myGLACCTQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myGLACCTQ.ReadQry()
    If Not myGLACCTQ.IsEOF Then
      With myGLACCTQ
        Counter = Counter + 1
        myGLBUDGET.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        If myGLBUDGET.RecordNotFound Then
          myGLBUDGET._ACT1 = 0
          myGLBUDGET._ACT2 = 0
          myGLBUDGET._ACT3 = 0
          myGLBUDGET._ACT4 = 0
          myGLBUDGET._ACT5 = 0
          myGLBUDGET._ADOPTD = 0
          myGLBUDGET._BAMT1 = 0
          myGLBUDGET._BAMT2 = 0
          myGLBUDGET._BAMT3 = 0
          myGLBUDGET._BAMT4 = 0
          myGLBUDGET._BAMT5 = 0
          myGLBUDGET._CURR = 0
          myGLBUDGET._DCODE = ""
          myGLBUDGET._DEPT = ._DPNBR
          myGLBUDGET._DESCD = ._GLDSC
          myGLBUDGET._EXP = 0
          myGLBUDGET._FORCST = 0
          myGLBUDGET._FUNC = ._FNPGM
          myGLBUDGET._FUND = ._FDNBR
          myGLBUDGET._GLTYP = ._GLTYP
          myGLBUDGET._OBJ = ._OBNBR
          myGLBUDGET._ORIG = 0
          myGLBUDGET._PROP = 0
          myGLBUDGET._REV = ""
          myGLBUDGET._SFUNC = ._SUBFN
          myGLBUDGET._SFUND = ._SFUND
          myGLBUDGET.AddOneRecordP()
        Else
          myGLBUDGET._DESCD = ._GLDSC
          myGLBUDGET.UpdateOneRecordP()
        End If
      End With

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
    myGLACCTQ.CloseFile()
  End Sub
End Module
