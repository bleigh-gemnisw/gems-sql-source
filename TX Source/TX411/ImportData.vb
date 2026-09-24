Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALC As TXREALC.MyData
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXPPRPC As TXPPRPC.MyData
  Dim myTXPPRPQ As TXPPRPQ.MyData

  Dim ds As DataSet = New DataSet
  Dim dsFile As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkRE As Boolean
  Dim WrkListNo As Integer
  Dim WrkName As Boolean
  Dim WrkMap As Boolean
  Dim WrkDist As Boolean
  Dim WrkLoc As Boolean
  Dim WrkVol As Boolean
  Dim WrkCount As Integer


  Public Sub Impdata()
    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPC = New TXPPRPC.MyData(myDBConnect)

    With MyFrmTX411B
      If .RbRE.Checked Then
        WrkRE = True
      Else
        WrkRE = False
      End If
      If .ChkName.Checked = True Then WrkName = True
      If .ChkMap.Checked = True Then WrkMap = True
      If .ChkDist.Checked = True Then WrkDist = True
      If .ChkVol.Checked = True Then WrkVol = True
      If .ChkLoc.Checked = True Then WrkLoc = True
    End With

    GetDetail()
    MsgBox("Records Updated: " + WrkCount.ToString, MsgBoxStyle.Information, "Import From Assessors")
    MyFrmTX411.Close()

  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    ' this routine will retrieve the records and if selected and exists the transfer record.
    ' It will then update the Frozen file using the associated subroutines.
    ' Only the fields selected will be updated on an update. On an Add they all will be added

    myFrmProgress = New FrmProgress  ' moved this to here from below the if dsreal..
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkSort = ""
    WrkQry = ""

    If WrkRE Then
      dsFile = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
    Else
      dsFile = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If dsFile.Tables(0).Rows.Count = 0 Then
      myFrmProgress.Close()
      Exit Sub
    End If

    For I = 0 To (dsFile.Tables(0).Rows.Count - 1)
      With dsFile.Tables(0).Rows(I)
        WrkListNo = .Item("list#")
      End With

      If WrkRE Then
        myTXREALC.GetOneRecordP(WrkListNo)
        If Not myTXREALC.RecordNotFound Then
          UpdateTXREALC(I)
        End If
      Else
        myTXPPRPC.GetOneRecordP(WrkListNo)
        If Not myTXPPRPC.RecordNotFound Then
          UpdateTXPPRPC(I)
        End If
      End If

nextrecord:
      With myFrmProgress
        WrkPct = ((I + 1) / dsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    If WrkRE Then
      myTXREALQ.CloseFile()
    Else
      myTXPPRPQ.CloseFile()
    End If

  End Sub
  Private Sub UpdateTXREALC(ByVal I As Integer)
    With myTXREALC
      If WrkName = True Then
        If Trim(._NAME) <> Trim(dsFile.Tables(0).Rows(I).Item("name")) Then
          If My2NDNO Then
            ._SNAME = Mid(dsFile.Tables(0).Rows(I).Item("name"), 1, 31) & " N/O"
          Else
            ._SNAME = "N/O " & Mid(dsFile.Tables(0).Rows(I).Item("name"), 1, 31)
          End If
        Else
          If Trim(._SNAME) <> Trim(dsFile.Tables(0).Rows(I).Item("sname")) Then
            ._SNAME = dsFile.Tables(0).Rows(I).Item("sname")
          End If
        End If
        ._ADD1 = dsFile.Tables(0).Rows(I).Item("add1")
        ._ADD2 = dsFile.Tables(0).Rows(I).Item("add2")
        ._CITY = dsFile.Tables(0).Rows(I).Item("city")
        ._STATE = dsFile.Tables(0).Rows(I).Item("state")
        ._ZIP5 = dsFile.Tables(0).Rows(I).Item("zip5")
        ._ZIP4 = dsFile.Tables(0).Rows(I).Item("zip4")
      End If
      If WrkDist = True Then ._DIST = dsFile.Tables(0).Rows(I).Item("dist")
      If WrkLoc = True Then
        ._LOC = dsFile.Tables(0).Rows(I).Item("loc")
        ._LOCNO = dsFile.Tables(0).Rows(I).Item("loc#")
      End If
      If WrkMap = True Then ._MAP = dsFile.Tables(0).Rows(I).Item("map")
      If WrkVol = True Then
        ._VOL = dsFile.Tables(0).Rows(I).Item("vol")
        ._PGE = dsFile.Tables(0).Rows(I).Item("pge")
      End If
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

    WrkCount = WrkCount + 1
  End Sub
  Private Sub UpdateTXPPRPC(ByVal I As Integer)
    With myTXPPRPC
      If WrkName = True Then
        ._ADD1 = dsFile.Tables(0).Rows(I).Item("add1")
        ._ADD2 = dsFile.Tables(0).Rows(I).Item("add2")
        ._CITY = dsFile.Tables(0).Rows(I).Item("city")
        ._STATE = dsFile.Tables(0).Rows(I).Item("state")
        ._ZIP5 = dsFile.Tables(0).Rows(I).Item("zip5")
        ._ZIP4 = dsFile.Tables(0).Rows(I).Item("zip4")
      End If
      If WrkDist = True Then ._DIST = dsFile.Tables(0).Rows(I).Item("dist")
      If WrkLoc = True Then
        ._LOC = dsFile.Tables(0).Rows(I).Item("loc")
        ._LOCNO = dsFile.Tables(0).Rows(I).Item("loc#")
      End If
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Exit Sub
      End If
    End With

    WrkCount = WrkCount + 1
  End Sub
End Module






