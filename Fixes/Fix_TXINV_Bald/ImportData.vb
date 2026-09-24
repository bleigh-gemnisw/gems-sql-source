Imports System.IO
Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim WrkYear As Integer
  Dim WrkType As String
  Dim WrkUseHist As Boolean
  Dim WrkUpdate As Boolean
  Dim ds As DataSet = New DataSet
  Dim sw As StreamWriter
  Dim WrkBal As Decimal
  Dim OldBal As Decimal
  Dim OldBondp As Decimal
  Dim WrkBondPaid As Decimal
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmFixB
      WrkType = .TxtType.Text
      WrkYear = CnvSng(.TxtYear.Text)
      WrkUseHist = .ChkHist.Checked
      WrkUpdate = .ChkUpdate.Checked
    End With
    GetDetail()

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
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkQry = "iCODE<>'I'"
    If WrkType <> "" Then
      WrkQry = WrkQry & " and TYPE='" & WrkType & "'"
    End If
    If WrkYear > 0 Then
      WrkQry = WrkQry & " and YEAR = " & WrkYear
    End If
    WrkSort = ""
    Counter = 0

    myTXINVQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If MyFrmFixB.LblFilePath.Text <> "" Then
      sw = New StreamWriter(MyFrmFixB.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      Counter = Counter + 1
      updatefile()
      If MyFrmFixB.LblFilePath.Text <> "" Then
        If WrkBal <> OldBal Or WrkBondPaid <> OldBondp Then
          sw.WriteLine(DownloadCSV)
        End If
      End If

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

    If MyFrmFixB.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()

  End Sub
  Private Sub updatefile()
    Dim ds2 As DataSet = New DataSet
    Dim WrkPaid As Decimal
    Dim I As Integer

    If Not myTXINV.RecordNotFound Then
      With myTXINV
        .GetOneRecordP(myTXINVQ._LISTNo, myTXINVQ._YEAR, myTXINVQ._TYPE)
        OldBal = ._BALD
        WrkBal = ._BALD
        OldBondp = ._BONDP
        WrkBondPaid = ._BONDP
        If WrkUseHist Then
          WrkPaid = 0
          WrkBondPaid = 0
          ds2 = myTXHSTL4.GetViewbyList(._LISTNo, ._YEAR, ._TYPE, 0, 100)
          If ds2.Tables(0).Rows.Count = 0 Then Exit Sub
          For I = 0 To ds2.Tables(0).Rows.Count - 1
            If ds2.Tables(0).Rows(I).Item("rcode") <> "V" And ds2.Tables(0).Rows(I).Item("rcode") <> "I" Then
              WrkPaid = WrkPaid + ds2.Tables(0).Rows(I).Item("pamt")
              If ds2.Tables(0).Rows(I).Item("pencd") = "BI" Then
                WrkBondPaid = WrkBondPaid + ds2.Tables(0).Rows(I).Item("pcamt")
              End If
            End If
          Next
          ._PAYREC = WrkPaid
          If ._CCNO > 0 Then
            WrkBal = ._CCETAX - WrkPaid
          Else
            WrkBal = ._TAXT - WrkPaid
          End If
          ._BALD = WrkBal
        Else
          If ._CCNO > 0 Then
            WrkBal = ._CCETAX - ._PAYREC
          Else
            WrkBal = ._TAXT - ._PAYREC
            ._BALD = WrkBal
          End If
        End If
        ._PRF = "FixBald"
        If WrkUpdate And WrkBal <> OldBal Then
          .UpdateOneRecordP()
        End If
      End With
    End If

  End Sub
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXINVQ
      sb = New StringBuilder
      sb.Append("ListNo")
      sb.Append(CComma)
      sb.Append("Type")
      sb.Append(CComma)
      sb.Append("Year")
      sb.Append(CComma)
      sb.Append("Name")
      sb.Append(CComma)
      sb.Append("Old Bald")
      sb.Append(CComma)
      sb.Append("New Bald")
      sb.Append(CComma)
      sb.Append("Diff Bald")
      sb.Append(CComma)
      sb.Append("Inv Bondp")
      sb.Append(CComma)
      sb.Append("Hist Bondp")
      sb.Append(CComma)
      sb.Append("Diff Bondp")
    End With
    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","

    With myTXINVQ
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(._TYPE)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(Trim(._NAME))
      sb.Append(CComma)
      sb.Append(OldBal)
      sb.Append(CComma)
      sb.Append(WrkBal)
      sb.Append(CComma)
      sb.Append(WrkBal - OldBal)
      sb.Append(CComma)
      sb.Append(OldBondp)
      sb.Append(CComma)
      sb.Append(WrkBondPaid)
      sb.Append(CComma)
      sb.Append(WrkBondPaid - OldBondp)
    End With
    Return sb.ToString
  End Function
End Module
