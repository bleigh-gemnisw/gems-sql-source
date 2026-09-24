'Command line for DEMO Mode (MySecGroup): <dbname> <userid> DEMO
Imports System.Diagnostics
Module Main
  Public MySecGroup As String
  Public MyFrmMain As FrmMain
  Public MyFrmMenu As FrmMenu
  Public MyFrmMenuAP As FrmMenuAP
  Public MyFrmMenuAR As FrmMenuAR
  Public MyFrmMenuBD As FrmMenuBD
  Public MyFrmMenuGL As FrmMenuGL
  Public MyFrmMenuFA As FrmMenuFA
  Public MyFrmMenuFI As FrmMenuFI
  Public MyFrmMenuMR As FrmMenuMR
  Public MyFrmMenuPK As FrmMenuPK
  Public MyFrmMenuPO As FrmMenuPO
  Public MyFrmMenuPR As FrmMenuPR
  Public MyFrmMenuPS As FrmMenuPS
  Public MyFrmMenuTA As FrmMenuTA
  Public MyFrmMenuTS As FrmMenuTS
  Public MyFrmMenuTX As FrmMenuTX
  Public MyFrmMenuUB As FrmMenuUB
  Public MyFrmFastPath As FrmFastPath
  Public DataPath As String
	Public MyPhaseIn As Boolean
  Public MyTXGL As Boolean
  Public MyLocEld As String
  Public MyNoFin As Boolean
  Sub Main()
    Dim TestCmd() As String
    Dim WrkProgName As String

    StartUp()

    If myTOWN._TOWNBR = 37 Then 'Derby
      If Date.Today > "06/30/23" Then
        MsgBox("Software license has expired. Contact Gemni Software")
        End
      End If
    End If

    If myTOWN._TOWNBR = 99 Then 'North Branford
      If Date.Today > "06/30/25" Then
        MsgBox("Software license has expired. Contact Gemni Software")
        End
      End If
    End If

    WrkProgName = MyUtils.GetProgramName()
    'If the length is greater than 1, then we know the process is already running under that name
    If (Process.GetProcessesByName(WrkProgName).Length > 1) Then
      MsgBox("Gems Menus is already running!")
      'Stop this newly launched application
      End
    End If

    MySecGroup = ""
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If Trim(TestCmd(2)) > "" Then
        MySecGroup = TestCmd(2)
      End If
      If UBound(TestCmd) > 2 Then
        If Trim(TestCmd(3)) > "" Then
          MySecGroup = MySecGroup & " " & TestCmd(3)
        End If
      End If
    End If

    DataPath = MyUtils.GetDataPath()
    If GetGNET("PHASE") = "Y" Then MyPhaseIn = True
    If GetGNET("TXGL") = "Y" Then MyTXGL = True
    If GetGNET("LECOV") = "Y" Then MyLocEld = "032"
    If GetGNET("LEDAR") = "Y" Then MyLocEld = "035"
    If GetGNET("LEEL") = "Y" Then MyLocEld = "045"
    If GetGNET("LEFRM") = "Y" Then MyLocEld = "084"
    If GetGNET("NOFIN") = "Y" Then MyNoFin = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmMain = New FrmMain
    Application.Run(MyFrmMain)
  End Sub
  Public Sub LaunchEXE(ByVal WrkBtnName As String, Optional ByVal WrkParm As String = "")
  Dim WrkProgName As String
  Dim WrkEXE As String
  Dim WrkVal As Integer
  Dim Pos As Integer

  WrkProgName = Replace(WrkBtnName, "btn", "", , , CompareMethod.Text)
  Pos = InStr(WrkProgName, ".exe", CompareMethod.Text)
  If Pos = 0 Then
    WrkProgName = WrkProgName & ".exe"
  End If
  WrkEXE = DataPath & WrkProgName & " " & MyDBName & " " & _
    MyUserID & " " & WrkParm

  Try
    WrkVal = Shell(WrkEXE, AppWinStyle.NormalFocus)
    If WrkVal = 0 Then
      MsgBox("Error running program " & WrkEXE & ". Please contact Hotline", MsgBoxStyle.Critical, "Program error")
    End If
  Catch
    MsgBox("Error running program " & WrkEXE & " .Please contact Hotline", MsgBoxStyle.Critical, "Program error")
  End Try
End Sub
Private Function GetGNET(ByVal Key As String) As String
	Dim myGNET As GNET.myData

  myGNET = New GNET.MyData()
  myGNET.MyDBConn = myDBConnect
  myGNET.GetOneRecordP(Key)
	With myGNET
		If .RecordNotFound Then Return String.Empty
		Return ._VALUE
	End With

End Function
End Module
