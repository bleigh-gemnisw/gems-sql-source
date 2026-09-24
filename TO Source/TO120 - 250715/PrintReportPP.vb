Imports System.Text
Module PrintReportPP

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim DsTXPPRP As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkFrozenFile As Boolean

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer

  Public Sub PrtReportPP()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)

    With MyFrmTO120B
      WrkType = "P"
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
    WrkQry = "CAT = '5'"

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing Personal property data..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If Not WrkFrozenFile Then
      DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
      With DsTXPPRP.Tables(0).Rows(I)
        Used = False
        WrkExcd(0) = Trim(.Item("excd1"))
        WrkExcd(1) = Trim(.Item("excd2"))
        WrkExcd(2) = Trim(.Item("excd3"))
        WrkExcd(3) = Trim(.Item("excd4"))
        WrkExcd(4) = Trim(.Item("excd5"))
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")

        'Add Exemption Letter groups
        For J = 0 To 4
          WrkEx = 0
          If WrkExcd(J) <> "" Then
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
                WrkTExPPAccts(K) = WrkTExPPAccts(K) + 1
                Used = True
              End If
              WrkTExCode(K) = WrkLetter
              WrkTExPPCount(K) = WrkTExPPCount(K) + 1
              WrkTExPP(K) = WrkTExPP(K) + WrkEx
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
        WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
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
    myTXPPRPQ.CloseFile()
    myTXPPRPCQ.CloseFile()

  End Sub
End Module






