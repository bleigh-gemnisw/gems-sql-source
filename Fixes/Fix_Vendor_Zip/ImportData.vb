Imports System.Text
Imports System.Text.RegularExpressions
Module ImportData

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myVENDORQ As VENDORQ.MyData
Dim myVENDOR As VENDOR.MyData
Dim Good As Boolean
Dim dr As DataRow
Dim ds As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Public Sub Impdata()

MyDBName = MyFrmFixB.TxtDBName.Text
myDBConnect = New SQLConnect.DBConnection(MyDBName)
  myDBConnect.Open()


myVENDORQ = New VENDORQ.MyData()
myVENDORQ.MyDBConn = myDBConnect
myVENDOR = New VENDOR.MyData()
myVENDOR.MyDBConn = myDBConnect


GetDetail()


End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.Int32"))
      .Columns.Add("SeqNo", Type.GetType("System.Int32"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Bald", Type.GetType("System.Decimal"))
      .Columns.Add("NPaid", Type.GetType("System.Decimal"))
      .Columns.Add("NBald", Type.GetType("System.Decimal"))
      .Columns.Add("Recid", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()

Dim SaveSeq As Integer
Dim WrkAnd As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim mystring As String
Dim myzip5 As String
Dim myzip4 As String
Dim mystringA As String
WrkAnd = " and "

With MyFrmFixB
  'WrkBatch = CnvSng(.TxtBatch.Text)
  
End With

WrkQry = ""
WrkSort = "VNDNR"
SaveSeq = 0
myVENDORQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myVENDORQ.ReadQry()
  If Not myVENDORQ.IsEOF Then
  With myVENDORQ
   'begin VADD 
    myzip5 = ""
    myzip4 = ""
    mystringA = ""
    mystring = ""
    myVENDOR.GetOneRecordP(._VNDNR)
    If Trim(._VADD4) > "" Then
      mystring = Trim(._VADD4)
    ElseIf Trim(._VADD3) > "" Then
       mystring = Trim(._VADD3)
     ElseIf Trim(._VADD2) > "" Then
          mystring = Trim(._VADD2)
           Else
          mystring = ""
    End If

    If mystring.Length > 0 Then
      mystringA = Trim(ExtractNumbers(mystring))
      If mystringA.Length >= 9 Then
        myzip5 = mystringA.Substring(0, 5)
        myzip4 = mystringA.Substring(5, 4)
        ElseIf mystringA.Length >= 5 Then
          myzip5 = mystringA.Substring(0, 5)
          myzip4 = ""
        Else
          myzip5 = ""
          myzip4 = ""
      End If
      mystringA = Removenumber(mystring)
    End If

    If myzip5.Length > 0 Then
     
       If Trim(._VADD4) > "" Then
        myVENDOR._VADD4 = mystringA
      ElseIf Trim(._VADD3) > "" Then
        myVENDOR._VADD3 = mystringA
      ElseIf Trim(._VADD2) > "" Then
          myVENDOR._VADD2 = mystringA
      End If
      If myzip5 = 9 Then
      myVENDOR._VZIP = myzip5
      myVENDOR._VZIPE = myzip4
      Else
       myVENDOR._VZIP = myzip5
      End If
  End If
   ' End VADD
   'begin ORAD
    myzip5 = ""
    myzip4 = ""
    mystringA = ""
    mystring = ""

    If Trim(._ORAD4) > "" Then
      mystring = Trim(._ORAD4)
    ElseIf Trim(._ORAD3) > "" Then
       mystring = Trim(._ORAD3)
     ElseIf Trim(._ORAD2) > "" Then
          mystring = Trim(._ORAD2)
           Else
          mystring = ""
    End If

    If mystring.Length > 0 Then
      mystringA = Trim(ExtractNumbers(mystring))
      If mystringA.Length >= 9 Then
        myzip5 = mystringA.Substring(0, 5)
        myzip4 = mystringA.Substring(5, 4)
        ElseIf mystringA.Length >= 5 Then
          myzip5 = mystringA.Substring(0, 5)
          myzip4 = ""
        Else
          myzip5 = ""
          myzip4 = ""
      End If
      mystringA = Removenumber(mystring)
    End If

    If myzip5.Length > 0 Then
      If Trim(._ORAD4) > "" Then
        myVENDOR._ORAD4 = mystringA
      ElseIf Trim(._ORAD3) > "" Then
        myVENDOR._ORAD3 = mystringA
      ElseIf Trim(._ORAD2) > "" Then
          myVENDOR._ORAD2 = mystringA
      End If
      If myzip5 = 9 Then
      myVENDOR._OZIP = myzip5
      myVENDOR._OZIPE = myzip4
      Else
       myVENDOR._OZIP = myzip5
      End If
  End If
   ' End OADD
   'begin PYAD
    myzip5 = ""
    myzip4 = ""
    mystringA = ""
    mystring = ""

    If Trim(._PYAD4) > "" Then
      mystring = Trim(._PYAD4)
    ElseIf Trim(._PYAD3) > "" Then
       mystring = Trim(._PYAD3)
     ElseIf Trim(._PYAD2) > "" Then
          mystring = Trim(._PYAD2)
           Else
          mystring = ""
    End If

    If mystring.Length > 0 Then
      mystringA = Trim(ExtractNumbers(mystring))
      If mystringA.Length >= 9 Then
        myzip5 = mystringA.Substring(0, 5)
        myzip4 = mystringA.Substring(5, 4)
        ElseIf mystringA.Length >= 5 Then
          myzip5 = mystringA.Substring(0, 5)
          myzip4 = ""
        Else
          myzip5 = ""
          myzip4 = ""
      End If
      mystringA = Removenumber(mystring)
    End If

    If myzip5.Length > 0 Then
      If Trim(._PYAD4) > "" Then
        myVENDOR._PYAD4 = mystringA
      ElseIf Trim(._PYAD3) > "" Then
        myVENDOR._PYAD3 = mystringA
      ElseIf Trim(._PYAD2) > "" Then
          myVENDOR._PYAD2 = mystringA
      End If
      If myzip5 = 9 Then
      myVENDOR._PYZIP = myzip5
      myVENDOR._PYZIPE = myzip4
      Else
       myVENDOR._PYZIP = myzip5
      End If
  End If
   ' End OADD


    myVENDOR.UpdateOneRecordP()


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
MsgBox("Fix of Zip code Complete")
End Sub

Public Function ExtractNumbers(ByVal expr As String) As String
        Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(expr, "[^\d]"))

    End Function
   Public Function Removenumber(ByVal expr As String) As String
        Return Regex.Replace(expr, "[\d-]", "")
    End Function
End Module
