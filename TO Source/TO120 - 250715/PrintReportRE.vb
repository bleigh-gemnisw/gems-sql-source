Imports System.Text
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkFrozenFile As Boolean

  Dim WrkExcd(6) As String
  Dim WrkExam(6) As Integer
  Public Sub PrtReportRE()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)

    With MyFrmTO120B
      WrkType = "R"
      WrkYear = .TxtGLYear.Text
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
    End With

    GetDetail()

  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkEx As Integer
    Dim WrkLetter As String
    Dim WrkGroup As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim Good As Boolean
    Dim Used As Boolean

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = ""
    WrkQry = "CAT = '1'"
    If Not WrkFrozenFile Then
      DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing Real Estate data..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      With DsTXREAL.Tables(0).Rows(I)
        Used = False
        WrkExcd(0) = Trim(.Item("excd1"))
        WrkExcd(1) = Trim(.Item("excd2"))
        WrkExcd(2) = Trim(.Item("excd3"))
        WrkExcd(3) = Trim(.Item("excd4"))
        WrkExcd(4) = Trim(.Item("excd5"))
        WrkExcd(5) = Trim(.Item("excd6"))
        WrkExcd(6) = Trim(.Item("excd7"))
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")
        WrkExam(5) = .Item("exam6")
        WrkExam(6) = .Item("exam7")

        'Add Exemption Letter groups
        For J = 0 To 6
          WrkEx = 0
          If Trim(WrkExcd(J)) <> "" Then
            Good = FilterCodes(WrkExcd(J))
            If Not Good Then Continue For
            K = LookupExem(WrkExcd(J))
            If WrkExam(J) = 0 Then
              WrkEx = WrkExFixedAmt(K)
            Else
              WrkEx = WrkExam(J)
            End If
            WrkLetter = WrkExLetter(K)
            K = -1
            WrkGroup = ""
            Select Case WrkLetter
              'MK 7/14/25 Begin
              'Case "A"
              Case "A", "C"
                'MK 7/14/25 End
                K = 0
                WrkGroup = "Regular"
              'MK 7/14/25 Begin
              'Case "B", "C"
              Case "B"
                'MK 7/14/25 End
                K = 1
                WrkGroup = "Addl"
              Case "D"
                K = 2
                WrkGroup = "Local"
            End Select
            If K >= 0 Then
              If Not Used Then
                WrkTExREAccts(K) = WrkTExREAccts(K) + 1
                Used = True
              End If
              WrkTExCode(K) = WrkLetter
              WrkTExRECount(K) = WrkTExRECount(K) + 1
              WrkTExRE(K) = WrkTExRE(K) + WrkEx
              WriteDVAFile(.Item("name"), .Item("sname"), .Item("add1"), .Item("city"),
            .Item("state"), .Item("zip5"), WrkExcd(J), WrkEx)
              'Write to detail report
              dr = ds2.Tables(0).NewRow
              dr.Item("listno") = .Item("list#")
              dr.Item("type") = .Item("type")
              dr.Item("name") = .Item("name")
              dr.Item("code") = WrkExcd(J)
              dr.Item("exam") = WrkEx
              dr.Item("group") = WrkGroup
              ds2.Tables(0).Rows.Add(dr)
            End If
          End If
        Next J
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    Application.DoEvents()
    myTXREALQ.CloseFile()
    myTXREALCQ.CloseFile()

  End Sub
End Module






