Module Common2
  Dim myGLFUND As GLFUND.myData
  Dim myGLACCT As GLACCT.myData
  Public Sub InitFiles()
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
  End Sub
  Public Function GetFundDesc(ByVal Fund As Integer) As String
     myGLFUND.GetOneRecordP(Fund, 0)
     If Not myGLFUND.RecordNotFound Then
       If Trim(myGLFUND._ACREC) = "" Then
         GetFundDesc = Format(Fund, "000") & " " & Trim(myGLFUND._FNDSC)
       Else
         GetFundDesc = ""
       End If
     Else
       GetFundDesc = "*** Unknown ***"
     End If
     Return GetFundDesc
  End Function
  Public Function GetDeptDesc(ByVal Fund As Integer, Dept As Integer) As String
     myGLACCT.GetOneRecordP(Fund, 0, Dept, 0, 0, 0)
     If Not myGLACCT.RecordNotFound Then
       GetDeptDesc = Trim(myGLACCT._GLDSC) & "  " & Format(Dept, "000")
     Else
       GetDeptDesc = "*** Unknown ***"
     End If
     Return GetDeptDesc
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
  Public Function GetGlTypDesc(ByVal GlType As String, ByVal IsHeader As Boolean) As String
     Dim WrkDesc As String
     WrkDesc = ""
     If IsHeader Then
       Select Case GlType
       Case "A"
         WrkDesc = "A S S E T"
       Case "L"
         WrkDesc = "L I A B I L I T Y"
       Case "Q"
         WrkDesc = "E Q U I T Y"
       Case "R"
         WrkDesc = "R E V E N U E"
       Case "X"
         WrkDesc = "A P P R O P R I A T I O N"
       End Select
       Return WrkDesc & "   S U M M A R Y"
     Else
       Select Case GlType
       Case "A"
         WrkDesc = "ASSET"
       Case "L"
         WrkDesc = "LIABILITY"
       Case "Q"
         WrkDesc = "EQUITY"
       Case "R"
         WrkDesc = "REVENUE"
       Case "X"
         WrkDesc = "APPROPRIATION"
       End Select
       Return WrkDesc & " TOTAL"
     End If
  End Function
End Module
