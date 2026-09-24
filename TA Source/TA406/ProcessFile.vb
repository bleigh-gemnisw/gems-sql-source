Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXMVDCQ As TXMVDCQ.MyData

Dim ds As DataSet = New DataSet
Dim DsTXMVDQ As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkClass As Integer
Dim WrkMake As String
Dim PrevMake As String
  Public Function BuildFile(ByVal Process As Boolean) As DataSet

  myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
  myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)

  With MyFrmTA406B
    WrkClass = MyUtils.CnvSng(.TxtFindClass.Text)
    WrkMake = .TxtFindMake.Text
  End With

  If Not Process Then
    BuildDS(ds)
    BufferPrevMVD()
  Else
    ds.Clear()
  End If
  GetDetail()

  Return ds

  End Function
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAnd As String
Dim WrkOr As String
Dim Counter As Integer
Dim K As Integer

WrkSort = "CLASS, MAKE, YEAR, VINNO, MODEL"

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkQry = "CAT = '1'" & WrkAnd & "VALUE=0"
If WrkClass > 0 Then
  WrkQry = WrkQry & WrkAnd & "CLASS=" & WrkClass
End If
If WrkMake <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "MAKE=" & MyUtils.Quo(WrkMake)
End If

myTXMVDQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	 myTXMVDQ.ReadQry()
	 If Not myTXMVDQ.IsEOF Then
		 With myTXMVDQ
			 Counter = Counter + 1
			 dr = ds.Tables(0).NewRow
			 dr.Item("listno") = ._LISTNo
			 dr.Item("Oname") = Trim(._NAME)
			 dr.Item("class") = ._CLASS
			 dr.Item("year") = ._YEAR
			 dr.Item("make") = Trim(._MAKE)
			 dr.Item("model") = Trim(._MODEL)
			 dr.Item("body") = Trim(._BODY)
			 dr.Item("idno") = Trim(._VINNO)
			 dr.Item("nada") = Trim(._NADA)
			 dr.Item("msrp") = ._MSRP
       K = LookupPrevMVD(._CLASS, ._YEAR, Trim(._MAKE), Trim(._MODEL))
       If K >= 0 Then
         dr.Item("lstyrval") = WrkOValue(K)
       Else
         dr.Item("lstyrval") = 0
       End If
       ds.Tables(0).Rows.Add(dr)
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
  Friend Sub BufferPrevMVD()
    'Buffer MV file. Create one record per Class/Year/Make/Model 
    Dim myTXMVDCQ As TXMVDCQ.MyData
    Dim dsMV As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim Counter As Integer
    Dim SaveClass As Integer
    Dim SaveYear As Integer
    Dim SaveMake As String
    Dim SaveModel As String
    Dim J As Integer

    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)

    Array.Clear(WrkOClass, 0, 25000)
    Array.Clear(WrkOYear, 0, 25000)
    Array.Clear(WrkOMake, 0, 25000)
    Array.Clear(WrkOModel, 0, 25000)
    Array.Clear(WrkOValue, 0, 25000)
    Array.Clear(WrkOMSRP, 0, 25000)

    SaveClass = 0
    SaveYear = 0
    SaveMake = String.Empty
    SaveModel = String.Empty

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "CAT = '1'" & WrkAnd & "VALUE>0"
    WrkSort = "CLASS, YEAR, MAKE, MODEL"
    myTXMVDCQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Buffering Last year's values..."
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXMVDCQ.ReadQry()
    If Not myTXMVDCQ.IsEOF Then
      With myTXMVDCQ
        Counter = Counter + 1
        If SaveClass <> ._CLASS Or
         SaveYear <> ._YEAR Or
         SaveMake <> Trim(._MAKE) Or
         SaveModel <> Trim(._MODEL) Then
          If ._VALUE > 0 Then
            WrkOClass(J) = ._CLASS
            WrkOYear(J) = ._YEAR
            WrkOMake(J) = Trim(._MAKE)
            WrkOModel(J) = Trim(._MODEL)
            WrkOValue(J) = ._VALUE
            WrkOMSRP(J) = ._MSRP
            J = J + 1
          End If
        End If
        SaveClass = ._CLASS
        SaveYear = ._YEAR
        SaveMake = Trim(._MAKE)
        SaveModel = Trim(._MODEL)
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
  Friend Function LookupPrevMVD(ByVal pClass As Integer, ByVal PYear As Integer, _
  ByVal pMake As String, ByVal pModel As String) As Integer
     Dim I As Integer

     For I = 0 To WrkOClass.GetUpperBound(0)
      If WrkOClass(I) = 0 And Trim(WrkOMake(I)) & "" = String.Empty Then
        Return -1
      End If
      If pClass = WrkOClass(I) And PYear = WrkOYear(I) And
        Trim(pMake) = Trim(WrkOMake(I)) And Trim(pModel) = Trim(WrkOModel(I)) Then
        Return I
      End If
    Next

End Function
End Module






