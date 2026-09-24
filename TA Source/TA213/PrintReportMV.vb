Imports System.Text
Module PrintReportMV

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim dsTot As DataSet = New DataSet
  Dim DsTXMVD As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkFrozenFile As Boolean
  Dim WrkBTR As Boolean
  Dim WrkCat As String

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  'Report fields
  Dim WrkLetter(40) As String
  Dim WrkLetterCount(40) As Integer
  Dim WrkLetterGross(40) As Long
  Dim WrkLetterExam(40) As Long
  Dim WrkLetterNet(40) As Long

  Public Sub PrtReportMV()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)

    With MyFrmTA213B
      WrkType = "M"
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
      If .ChkNonExempt.Checked Then
        WrkCat = "1"
      Else
        WrkCat = "3"
      End If
    End With

    If dsTot.Tables.Count = 0 Then
      BuildDS(dsTot)
    Else
      dsTot.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .WrkdsTot = dsTot
      .WrkType = WrkType
      .WrkBTR = WrkBTR
      .Show()
    End With

  End Sub
  Private Sub ClearTotals()
    ReDim WrkLetter(40)
    ReDim WrkLetterCount(40)
    ReDim WrkLetterGross(40)
    ReDim WrkLetterExam(40)
    ReDim WrkLetterNet(40)
  End Sub
  Private Sub GetDetail()
    Dim WrkTypeDesc As String
    Dim WrkTypeFamily As String
    Dim WrkQry As String
    Dim WrkExempt As Integer
    Dim WrkLet As String
    Dim WrkTotBTR As Decimal
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "CAT = " & MyUtils.Quo(WrkCat)
    If Not WrkDistAll Then
      If Not WrkPrintDist Then
        WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
      Else
        WrkQry = WrkQry & WrkAnd & "pdst=" & WrkDist
      End If
    End If

    If Not WrkFrozenFile Then
      DsTXMVD = myTXMVDQ.GetQry("NAME", WrkQry, 0)
    Else
      DsTXMVD = myTXMVDCQ.GetQry("NAME", WrkQry, 0)
    End If
    If DsTXMVD.Tables(0).Rows.Count = 0 Then
      If Not WrkFrozenFile Then
        myTXMVDQ.CloseFile()
      Else
        myTXMVDCQ.CloseFile()
      End If
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    WrkTypeFamily = GetTXTypeFamily(WrkType)

    For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
      With DsTXMVD.Tables(0).Rows(I)
        WrkExcd(0) = .Item("excd1")
        WrkExcd(1) = .Item("excd2")
        WrkExcd(2) = .Item("excd3")
        WrkExcd(3) = .Item("excd4")
        WrkExcd(4) = .Item("excd5")
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")

        'Combine into Letter groups
        WrkExempt = 0
        For J = 0 To 4
          If WrkExcd(J) <> "" Then
            K = LookupExem(WrkExcd(J))
            If WrkExam(J) = 0 Then
              WrkExempt = WrkExempt + WrkExFixedAmt(K)
            Else
              WrkExempt = WrkExempt + WrkExam(J)
            End If
          End If
        Next

        'Add Exemption groups
        WrkLet = .Item("lett")
        K = LookupWrkLetter(WrkLet)
        WrkLetter(K) = WrkLet
        WrkLetterCount(K) = WrkLetterCount(K) + 1
        WrkLetterGross(K) = WrkLetterGross(K) + .Item("value")
        WrkLetterExam(K) = WrkLetterExam(K) + WrkExempt
        WrkLetterNet(K) = WrkLetterNet(K) + .Item("value") - WrkExempt

        If WrkBTR Then
          If Not WrkFrozenFile Then
            myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTR.RecordNotFound Then
              With myTXBTR
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
                WrkLetterGross(K) = WrkLetterGross(K) + WrkTotBTR
                WrkLetterNet(K) = WrkLetterNet(K) + WrkTotBTR
              End With
            End If
          Else
            myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTRC.RecordNotFound Then
              With myTXBTRC
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
                WrkLetterGross(K) = WrkLetterGross(K) + WrkTotBTR
                WrkLetterNet(K) = WrkLetterNet(K) + WrkTotBTR
              End With
            End If
          End If
        End If

      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
        End If
      End With
    Next

    'Totals
    For I = 0 To 40
      If WrkLetter(I) = Nothing Then Exit For
      dr = dsTot.Tables(0).NewRow
      dr.Item("totletter") = WrkLetter(I)
      dr.Item("totcount") = WrkLetterCount(I)
      dr.Item("totgross") = WrkLetterGross(I)
      dr.Item("totexam") = WrkLetterExam(I)
      dr.Item("totnet") = WrkLetterNet(I)
      dsTot.Tables(0).Rows.Add(dr)
    Next

    myFrmProgress.Close()
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()

  End Sub
  Private Function LookupWrkLetter(ByVal Letter As String) As Integer
    Dim I As Integer

    For I = 0 To WrkLetter.GetUpperBound(0)
      If Trim(WrkLetter(I)) = "" Then
        Return I
      End If
      If Trim(Letter) = Trim(WrkLetter(I)) Then
        Return I
      End If
    Next

  End Function
End Module






