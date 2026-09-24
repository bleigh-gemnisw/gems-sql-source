Module Common2
  Dim myGLFUND As GLFUND.myData
  Dim myGLACCT As GLACCT.myData
  Public Sub InitFiles()
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
  End Sub
  Public Function GetFundDesc(ByVal Fund As Integer, ByVal InactiveRpt As Boolean) As String
     myGLFUND.GetOneRecordP(Fund, 0)
     If Not myGLFUND.RecordNotFound Then
       If Trim(myGLFUND._ACREC) = "" Or InactiveRpt Then
         GetFundDesc = Format(Fund, "000") & " " & Trim(myGLFUND._FNDSC)
       Else
         GetFundDesc = ""
       End If
     Else
      GetFundDesc = Format(Fund, "000") & " *** Unknown ***"
    End If
     Return GetFundDesc
  End Function
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Dept As Integer, ByVal Obj As Integer, _
    ByVal Func As Integer, Sfunc As Integer) As String
     myGLACCT.GetOneRecordP(Fund, 0, Dept, Obj, Func, Sfunc)
     If Not myGLACCT.RecordNotFound Then
       GetAcctDesc = Trim(myGLACCT._GLDSC)
     Else
       GetAcctDesc = "*** Unknown ***"
     End If
     Return GetAcctDesc
  End Function
  Public Function GetGlTypDesc(ByVal GlType As String) As String
     Dim WrkDesc As String
     WrkDesc = ""
     Select Case GlType
     Case "A"
       WrkDesc = "ASSETS"
     Case "L"
       WrkDesc = "LIABILITY"
     Case "Q"
       WrkDesc = "EQUITY"
     End Select
     Return WrkDesc
  End Function
End Module
