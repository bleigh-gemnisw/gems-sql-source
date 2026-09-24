Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myGLBUDGETQ As GLBUDGETQ.MyData
  Dim myGLBUDGET As GLBUDGET.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim SaveFund As Integer
  Dim SaveDept As Integer
  Dim SaveGltyp As String
  'GL5091
  Dim WrkExcludeTot As Boolean
  Dim WrkReportFmt As String
  Dim WrkActual2Yr As Integer
  Dim WrkActual1Yr As Integer
  Dim WrkExpend As Integer
  Dim WrkAmended As Integer
  Dim WrkDeptProp As Integer
  Dim WrkMayorProp As Integer
  Dim WrkTownConProp As Integer
  Dim WrkAdopted As Integer
  Public Sub ProcFile()

    myGLBUDGETQ = New GLBUDGETQ.MyData()
    myGLBUDGETQ.MyDBConn = myDBConnect
    myGLBUDGET = New GLBUDGET.MyData()
    myGLBUDGET.MyDBConn = myDBConnect
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkSelFund As Integer
    Dim WrkSelsfund As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim fromcol As Integer
    Dim tocol As Integer

    fromcol = 0
    tocol = 0
    With MyFrmGL509B
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelsfund = MyUtils.CnvSng(.TxtSfund.Text)
      If .rb1.Checked Then fromcol = 1
      If .rb2.Checked Then fromcol = 2
      If .rb3.Checked Then fromcol = 3
      If .rb4.Checked Then fromcol = 4
      If .rbt1.Checked Then tocol = 1
      If .rbt2.Checked Then tocol = 2
      If .rbt3.Checked Then tocol = 3
      If .rbt4.Checked Then tocol = 4
    End With

    WrkAnd = " and "
    WrkOr = " or "

    WrkSort = "FUND, SFUND"
    WrkQry = "FUND=" & WrkSelFund & WrkAnd & "SFUND=" & WrkSelsfund

    myGLBUDGETQ.OpenQry(WrkSort, WrkQry)


    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myGLBUDGETQ.ReadQry()
    If Not myGLBUDGETQ.IsEOF Then
      With myGLBUDGETQ
        Counter = Counter + 1

        SaveFund = ._FUND
        SaveDept = ._DEPT
        SaveGltyp = ._GLTYP
        ' get value to be moved

        myGLBUDGET.GetOneRecordP(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
      End With 'myGLBUDGETQ

      With myGLBUDGET
        If fromcol = 1 Then
          Select Case tocol
            Case 1
              ._BAMT2 = ._BAMT1
            Case 2
              ._BAMT3 = ._BAMT1
            Case 3
              ._BAMT4 = ._BAMT1
            Case 4
              ._ADOPTD = ._BAMT1
          End Select
        End If
        If fromcol = 2 Then
          Select Case tocol
            Case 2
              ._BAMT3 = ._BAMT2
            Case 3
              ._BAMT4 = ._BAMT2
            Case 4
              ._ADOPTD = ._BAMT2
          End Select
        End If
        If fromcol = 3 Then
          Select Case tocol
            Case 3
              ._BAMT4 = ._BAMT3
            Case 4
              ._ADOPTD = ._BAMT3
          End Select
        End If
        If fromcol = 4 Then
          Select Case tocol
            Case 4
              ._ADOPTD = ._BAMT4
          End Select
        End If
        .UpdateOneRecordP()
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

    'WriteTotal()
    myFrmProgress.Close()
    myGLBUDGETQ.CloseFile()
    myGLBUDGET.CloseFile()
    MsgBox("Column Copied")
  End Sub


End Module
