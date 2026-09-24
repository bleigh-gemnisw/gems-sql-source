Module ImportData
  Dim WrkGLYear As Integer
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVAQ As TXMVAQ.myData
  Dim myTXMVA As TXMVA.myData
  Dim myTXMVDQ As TXMVDQ.myData
  Dim myTXMVD As TXMVD.myData
  Dim myTXMVDCQ As TXMVDCQ.myData
  Dim myTXMVDC As TXMVDC.myData

  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    WrkGLYear = MyFrmFixB.TxtYear.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVD = New TXMVD.MyData(myDBConnect)
    'GetTXMVD()

    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXMVDC = New TXMVDC.MyData(myDBConnect)
    'GetTXMVDC()

    myTXMVAQ = New TXMVAQ.MyData(myDBConnect)
    myTXMVA = New TXMVA.MyData(myDBConnect)
    GetTXMVA()
    MyFrmFix.Close()

  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub GetTXMVA()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "TXYEAR=" & WrkGLYear
    WrkSort = ""

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing TXMVA"
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTXMVAQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXMVAQ.ReadQry()
    If Not myTXMVAQ.IsEOF Then
      With myTXMVAQ
        Counter = Counter + 1
        ProcessTXMVA()
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
    myTXMVAQ.CloseFile()

  End Sub
  Private Sub ProcessTXMVA()
    Dim WrkRad1 As String
    Dim WrkAdd1 As String
    Dim Pos As Integer
    myTXMVA.GetOneRecordP(myTXMVAQ._LISTNo, myTXMVAQ._TXYEAR)
    If myTXMVA.RecordNotFound Then Exit Sub
    '    If myTXMVAQ._LISTNo = 101100 Then
    '    Exit Sub
    '   End If

    With myTXMVA
      WrkRad1 = Trim(myTXMVAQ._RAD1)
      WrkAdd1 = Trim(myTXMVAQ._ADD1)
      Pos = InStr(WrkRad1, " ", CompareMethod.Text)
      If WrkRad1 <> "" Then
        If Pos > 0 Then
          ._LOC = Mid(WrkRad1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkRad1, 1, Pos - 1), 7)
        End If
      Else
        Pos = InStr(WrkAdd1, " ", CompareMethod.Text)
        If Pos > 0 Then
          ._LOC = Mid(WrkAdd1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkAdd1, 1, Pos - 1), 7)
        End If
      End If
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub GetTXMVD()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = ""

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing TXMVD"
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTXMVDQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXMVDQ.ReadQry()
    If Not myTXMVDQ.IsEOF Then
      With myTXMVDQ
        Counter = Counter + 1
        ProcessTXMVD()
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
    myTXMVDQ.CloseFile()

  End Sub
  Private Sub ProcessTXMVD()
    Dim WrkRad1 As String
    Dim WrkAdd1 As String
    Dim Pos As Integer
    myTXMVD.GetOneRecordP(myTXMVDQ._LISTNo)
    If myTXMVD.RecordNotFound Then Exit Sub

    With myTXMVD
      WrkRad1 = Trim(myTXMVDQ._RAD1)
      WrkAdd1 = Trim(myTXMVDQ._ADD1)
      Pos = InStr(WrkRad1, " ", CompareMethod.Text)
      If WrkRad1 <> "" Then
        If Pos > 0 Then
          ._LOC = Mid(WrkRad1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkRad1, 1, Pos - 1), 7)
        End If
      Else
        Pos = InStr(WrkAdd1, " ", CompareMethod.Text)
        If Pos > 0 Then
          ._LOC = Mid(WrkAdd1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkAdd1, 1, Pos - 1), 7)
        End If
      End If
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub GetTXMVDC()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = ""
    WrkSort = ""

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Text = "Processing TXMVDC"
    myFrmProgress.Refresh()
    Application.DoEvents()

    myTXMVDCQ.OpenQry(WrkSort, WrkQry)

ReadNext:
    myTXMVDCQ.ReadQry()
    If Not myTXMVDCQ.IsEOF Then
      With myTXMVDCQ
        Counter = Counter + 1
        ProcessTXMVDC()
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
    myTXMVDCQ.CloseFile()

  End Sub
  Private Sub ProcessTXMVDC()
    Dim WrkRad1 As String
    Dim WrkAdd1 As String
    Dim Pos As Integer
    myTXMVDC.GetOneRecordP(myTXMVDCQ._LISTNO)
    If myTXMVDC.RecordNotFound Then Exit Sub

    With myTXMVDC
      WrkRad1 = Trim(myTXMVDCQ._RAD1)
      WrkAdd1 = Trim(myTXMVDCQ._ADD1)
      Pos = InStr(WrkRad1, " ", CompareMethod.Text)
      If WrkRad1 <> "" Then
        If Pos > 0 Then
          ._LOC = Mid(WrkRad1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkRad1, 1, Pos - 1), 7)
        End If
      Else
        Pos = InStr(WrkAdd1, " ", CompareMethod.Text)
        If Pos > 0 Then
          ._LOC = Mid(WrkAdd1, Pos + 1, 25)
          ._LOCNO = JustifyRight(Mid(WrkAdd1, 1, Pos - 1), 7)
        End If
      End If
      .UpdateOneRecordP()
    End With
  End Sub
End Module
