Public Class Buffer_TXTYPE
Dim mvarIn_Type As String
Dim mvarOut_Desc As String
Dim mvarOut_Family As String
Dim mvarOut_Rev As String

Dim WrkType(50) As String
Dim WrkDesc(50) As String
Dim WrkFamily(50) As String
Dim WrkRev(50) As String
Public Sub BufferFile()
		 Dim myTXTYPE As TXTYPE.myData
     Dim dsTXType As DataSet = New DataSet
     Dim I As Integer

		 myTXTYPE = New TXTYPE.mydata(MyDBConnect)

     dsTXType = myTXTYPE.GetAllData
     For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkType(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
        WrkRev(I) = .Item("txrev")
      End With
    Next

End Sub
Public Sub LookupType()
     Dim I As Integer

     Out_Desc = ""
     Out_Family = ""
     Out_Rev = ""

     For I = 0 To WrkType.GetUpperBound(0)
       If WrkType(I) = "" Then
         Exit Sub
       End If
       If In_Type = WrkType(I) Then
         Out_Desc = WrkDesc(I)
         Out_Family = WrkFamily(I)
         Out_Rev = WrkRev(I)
       End If
    Next
End Sub
#Region "Properties"

  Public Property In_Type() As String
    Get
      In_Type = mvarIn_Type
    End Get
    Set(ByVal Value As String)
      mvarIn_Type = Value
    End Set
  End Property
  Public Property Out_Desc() As String
    Get
      Out_Desc = mvarOut_desc
    End Get
    Set(ByVal Value As String)
      mvarOut_desc = Value
    End Set
  End Property
  Public Property Out_Family() As String
    Get
      Out_Family = mvarOut_Family
    End Get
    Set(ByVal Value As String)
      mvarOut_Family = Value
    End Set
  End Property
  Public Property Out_Rev() As String
    Get
      Out_Rev = mvarOut_Rev
    End Get
    Set(ByVal Value As String)
      mvarOut_Rev = Value
    End Set
  End Property
#End Region

End Class






