Imports System.Drawing.Printing
Imports System.Reflection
Imports System.Runtime.InteropServices
Module PrintDirect
  Private WithEvents pdValidate As PrintDocument
  Private WithEvents pdReceipt As PrintDocument
  Private WithEvents pdTotals As PrintDocument
  Private WithEvents pdEndorse As PrintDocument
  Dim myTXENDRS As TXENDRS.MyData
  Dim WrkHeading As String
  Dim WrkHeading2 As String
  Dim WrkReceiptHeading As String
  Dim WrkReceiptHeading2 As String
  Dim ds As DataSet = New DataSet
  Dim WrkCash As Decimal
  Dim WrkCheck As Decimal
  Dim WrkCredit As Decimal
  Dim WrkTotal As Decimal
  Dim WrkReceived As Decimal
  Dim WrkChange As Decimal
  'Endorse
  Dim WrkBatchSeqNo As Integer
  Dim WrkTotCheck As Decimal
  'Fonts
  Dim WrkFont As Font
  Dim WrkFonta As Font
  Private Sub SetFonts()

    If MyAppSettings.ValidateFont = "Arial-10" Then
      WrkFont = New Font("Arial", 10)
      WrkFonta = New Font("Arial", 10)
    Else
      If MyAppSettings.ValidateModel = "TM-U325" Then
        WrkFont = New Font("Courier New", 8)
      Else
        WrkFont = New Font("Courier New", 9)
      End If
      WrkFonta = New Font("Arial", 9)
    End If

  End Sub

  Public Sub PrtReceiptDirect(ByVal Wrkds As DataSet, ByVal WrkValidation As Boolean, ByVal WrkReceipt As Boolean)

    SetFonts()
    WrkHeading = Trim(Replace(myTOWN._TOWN, "TOWN OF ", String.Empty, 1, -1, CompareMethod.Text))
    WrkHeading2 = String.Empty
    WrkReceiptHeading = WrkHeading
    WrkReceiptHeading2 = WrkHeading2

    'Salem
    If myTOWN._TOWNBR = 121 Then
      WrkReceiptHeading = Trim(myTOWN._TOWN)
      WrkReceiptHeading2 = "Retain for your records"
    End If

    ds = Wrkds.Copy
    If WrkValidation Then
      pdValidate = New PrintDocument
      ' Change the printer to the indicated printer
      pdValidate.PrinterSettings.PrinterName = MyAppSettings.ValidatePrinter

      If pdValidate.PrinterSettings.IsValid Then
        pdValidate.DocumentName = "Validation"
        ' Start printing
        pdValidate.Print()
      End If
    End If

    If WrkReceipt Then
      pdReceipt = New PrintDocument
      ' Change the printer to the indicated printer
      pdReceipt.PrinterSettings.PrinterName = MyAppSettings.ReceiptPrinter

      If pdReceipt.PrinterSettings.IsValid Then
        pdReceipt.DocumentName = "Receipt"
        ' Start printing
        pdReceipt.Print()
      End If
    End If

  End Sub
  Private Sub pdValidate_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdValidate.PrintPage
    Dim WrkRecDt As String
    Dim X As Integer = 60
    Dim Y As Integer = 10
    Dim LineOffset As Integer

    ' Instantiate font objects used in printing.
    e.Graphics.PageUnit = GraphicsUnit.Point
    LineOffset = WrkFont.GetHeight(e.Graphics) - 2

    ' Print the slip text
    With ds.Tables(0).Rows(0)
      WrkRecDt = Format(.Item("recdt"), "M/d/yyyy")
      If MyAppSettings.ValidateModel = "TM-U675" Then
        e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(WrkHeading2, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("TypeDesc"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("Name"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("PropDesc"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("PropDesc2"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset * 3
        e.Graphics.DrawString(Space(5) & .Item("ListNo") & "   " & WrkRecDt, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(5) & .Item("Type") & "   " & .Item("BatchNo") & "   " & .Item("Seq"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset * 2
        e.Graphics.DrawString(.Item("Year") & " TAX PAID " & JustifyFixed(.Item("Principal"), 11), WrkFont, Brushes.Black, X, Y)
        If .Item("Interest") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " INT PAID " & JustifyFixed(.Item("Interest"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Liens") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "LIEN PAID " & JustifyFixed(.Item("liens"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Fees") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " FEE PAID " & JustifyFixed(.Item("Fees"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Bond") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "BOND PAID " & JustifyFixed(.Item("Bond"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If MyAppSettings.ValidateTotal Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "    TOTAL" & JustifyFixed(.Item("Total"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        Y += LineOffset * 2
        e.Graphics.DrawString(Space(4) & "  CASH" & JustifyFixed(.Item("Cash"), 11), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(4) & " CHECK" & JustifyFixed(.Item("Check"), 11), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(4) & "CREDIT" & JustifyFixed(.Item("Credit"), 11), WrkFont, Brushes.Black, X, Y)
      Else
        e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(WrkHeading2, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(1) & .Item("ListNo") & "   " & WrkRecDt, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(1) & .Item("Type") & "   " & .Item("BatchNo") & "   " & .Item("Seq"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("Year") & " TAX PD " & JustifyFixed(.Item("Principal"), 11), WrkFont, Brushes.Black, X, Y)
        If .Item("Interest") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " INT PD " & JustifyFixed(.Item("Interest"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Liens") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "LIEN PD " & JustifyFixed(.Item("liens"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Fees") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " FEE PD " & JustifyFixed(.Item("Fees"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Bond") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " BOND PD " & JustifyFixed(.Item("Bond"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If MyAppSettings.ValidateTotal Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "  TOTAL " & JustifyFixed(.Item("Total"), 11), WrkFont, Brushes.Black, X, Y)
        End If
      End If
    End With
    e.HasMorePages = False
  End Sub
  Private Sub pdReceipt_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdReceipt.PrintPage
    Dim WrkRecDt As String
    Dim X As Integer = 60
    Dim Y As Integer = 10
    Dim LineOffset As Integer
    Dim LineOffseta As Integer

    ' Instantiate font objects used in printing.

    e.Graphics.PageUnit = GraphicsUnit.Point
    LineOffset = WrkFont.GetHeight(e.Graphics) - 2
    LineOffseta = WrkFonta.GetHeight(e.Graphics) - 2

    ' Print the slip text
    With ds.Tables(0).Rows(0)
      WrkRecDt = Format(.Item("recdt"), "M/d/yyyy")
      If MyAppSettings.ValidateModel = "TM-U675" Then
        e.Graphics.DrawString(WrkHeading, WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta
        e.Graphics.DrawString(WrkHeading2, WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta
        e.Graphics.DrawString(.Item("TypeDesc"), WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta
        e.Graphics.DrawString(.Item("Name"), WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta
        If .Item("Sname") <> String.Empty Then
          e.Graphics.DrawString(.Item("Sname"), WrkFonta, Brushes.Black, X, Y)
          Y += LineOffseta
        End If
        e.Graphics.DrawString(.Item("PropDesc"), WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta
        e.Graphics.DrawString(.Item("PropDesc2"), WrkFonta, Brushes.Black, X, Y)
        Y += LineOffseta * 3
        e.Graphics.DrawString(Space(1) & .Item("ListNo") & "   " & WrkRecDt, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(1) & .Item("Type") & "   " & .Item("BatchNo") & "   " & .Item("Seq"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset * 2
        e.Graphics.DrawString(.Item("Year") & " TAX PD " & JustifyFixed(.Item("Principal"), 11), WrkFont, Brushes.Black, X, Y)
        If .Item("Interest") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " INT PD " & JustifyFixed(.Item("Interest"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Liens") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "LIEN PD " & JustifyFixed(.Item("liens"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Fees") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " FEE PD " & JustifyFixed(.Item("Fees"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Bond") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "BOND PD " & JustifyFixed(.Item("Bond"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If MyAppSettings.ValidateTotal Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "  TOTAL" & JustifyFixed(.Item("Total"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        Y += LineOffset * 2
        e.Graphics.DrawString(Space(4) & "     CASH" & JustifyFixed(.Item("Cash"), 11), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(4) & "    CHECK" & JustifyFixed(.Item("Check"), 11), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(4) & "   CREDIT" & JustifyFixed(.Item("Credit"), 11), WrkFont, Brushes.Black, X, Y)
        If Trim(.Item("refe")) <> "" Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " CHECK No. " & Trim(.Item("refe")), WrkFont, Brushes.Black, X, Y)
        End If
      Else
        e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(WrkHeading2, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(1) & .Item("ListNo") & "   " & WrkRecDt, WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(Space(1) & .Item("Type") & "   " & .Item("BatchNo") & "   " & .Item("Seq"), WrkFont, Brushes.Black, X, Y)
        Y += LineOffset
        e.Graphics.DrawString(.Item("Year") & " TAX PD " & JustifyFixed(.Item("Principal"), 11), WrkFont, Brushes.Black, X, Y)
        If .Item("Interest") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " INT PD " & JustifyFixed(.Item("Interest"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Liens") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "LIEN PD " & JustifyFixed(.Item("liens"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Fees") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & " FEE PD " & JustifyFixed(.Item("Fees"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If .Item("Bond") <> 0 Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "BOND PD " & JustifyFixed(.Item("Bond"), 11), WrkFont, Brushes.Black, X, Y)
        End If
        If MyAppSettings.ValidateTotal Then
          Y += LineOffset
          e.Graphics.DrawString(Space(4) & "   TOTAL" & JustifyFixed(.Item("Total"), 11), WrkFont, Brushes.Black, X, Y)
        End If
      End If
    End With
    e.HasMorePages = False
  End Sub
  Public Sub PrtTotalsDirect(ByVal pCash As Decimal, ByVal pCheck As Decimal, ByVal pCredit As Decimal,
    ByVal pTotal As Decimal, ByVal pReceived As Decimal, ByVal pChange As Decimal)

    SetFonts()
    WrkHeading = Trim(Replace(myTOWN._TOWN, "TOWN OF ", String.Empty, 1, -1, CompareMethod.Text))
    WrkHeading2 = String.Empty
    WrkReceiptHeading = WrkHeading
    WrkReceiptHeading2 = WrkHeading2

    'Salem
    If myTOWN._TOWNBR = 121 Then
      WrkReceiptHeading = Trim(myTOWN._TOWN)
      WrkReceiptHeading2 = "Retain for your records"
    End If

    WrkCash = pCash
    WrkCheck = pCheck
    WrkCredit = pCredit
    WrkTotal = pTotal
    WrkReceived = pReceived
    WrkChange = pChange

    pdTotals = New PrintDocument
    ' Change the printer to the indicated printer
    pdTotals.PrinterSettings.PrinterName = MyAppSettings.ReceiptPrinter

    If pdTotals.PrinterSettings.IsValid Then
      pdTotals.DocumentName = "Totals"
      ' Start printing
      pdTotals.Print()
    End If
  End Sub
  Private Sub pdTotals_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdTotals.PrintPage
    Dim X As Integer = 60
    Dim Y As Integer = 10
    Dim LineOffset As Integer

    ' Instantiate font objects used in printing.
    e.Graphics.PageUnit = GraphicsUnit.Point
    LineOffset = WrkFont.GetHeight(e.Graphics) - 2

    ' Print the slip text
    If MyAppSettings.ValidateModel = "TM-U675" Then
      e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("TRANSACTION TOTALS", WrkFont, Brushes.Black, X, Y)
      Y += LineOffset * 2
      e.Graphics.DrawString("    CASH" & JustifyFixed(WrkCash, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("   CHECK" & JustifyFixed(WrkCheck, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("  CREDIT" & JustifyFixed(WrkCredit, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("   TOTAL" & JustifyFixed(WrkTotal, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset * 2
      e.Graphics.DrawString("AMT RCVD" & JustifyFixed(WrkReceived, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("  CHANGE" & JustifyFixed(WrkChange, 11), WrkFont, Brushes.Black, X, Y)
    Else
      e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("TRANSACTION TOTALS", WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("    CASH" & JustifyFixed(WrkCash, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("   CHECK" & JustifyFixed(WrkCheck, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("  CREDIT" & JustifyFixed(WrkCredit, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("   TOTAL" & JustifyFixed(WrkTotal, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset * 2
      e.Graphics.DrawString("AMT RCVD" & JustifyFixed(WrkReceived, 11), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("  CHANGE" & JustifyFixed(WrkChange, 11), WrkFont, Brushes.Black, X, Y)
    End If
    'Salem
    If myTOWN._TOWNBR = 121 Then
      Y += LineOffset * 2
      e.Graphics.DrawString("-", WrkFont, Brushes.Black, X, Y)
    End If
    e.HasMorePages = False
  End Sub
  Private Function JustifyFixed(ByVal WrkNumber As Decimal, ByVal WrkSize As Integer) As String
    JustifyFixed = MyUtils.JustifyRight(Format(WrkNumber, "fixed"), WrkSize)
  End Function
  Public Sub PrtEndorseDirect(ByVal pBatchSeqNo As Integer, ByVal pTotCheck As Decimal)

    SetFonts()
    WrkBatchSeqNo = pBatchSeqNo
    WrkTotCheck = pTotCheck

    pdEndorse = New PrintDocument
    ' Change the printer to the indicated printer
    pdEndorse.PrinterSettings.PrinterName = MyAppSettings.ValidatePrinter

    If pdEndorse.PrinterSettings.IsValid Then
      pdEndorse.DocumentName = "Endorse"
      ' Start printing
      pdEndorse.Print()
    End If
  End Sub
  Private Sub pdEndorse_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdEndorse.PrintPage
    Dim WrkDate As String
    Dim X As Integer = 60
    Dim Y As Integer = 10
    Dim LineOffset As Integer

    WrkDate = Format(MyReceiptDate, "M/d/yyyy")
    ' Instantiate font objects used in printing.
    e.Graphics.PageUnit = GraphicsUnit.Point
    LineOffset = WrkFont.GetHeight(e.Graphics) - 2

    ' Print the slip text
    If MyAppSettings.ValidateModel = "TM-U675" Then
      e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL1), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL2), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL3), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL4), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL5), WrkFont, Brushes.Black, X, Y)
      If Trim(myTXENDRS._EL6) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL6), WrkFont, Brushes.Black, X, Y)
      End If
      If Trim(myTXENDRS._EL7) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL7), WrkFont, Brushes.Black, X, Y)
      End If
      If Trim(myTXENDRS._EL8) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL8), WrkFont, Brushes.Black, X, Y)
      End If
      Y += LineOffset
      e.Graphics.DrawString(MyBatchNo & "-" & WrkBatchSeqNo & "-" & WrkDate, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("Total Paid: " & Format(WrkTotCheck, "fixed"), WrkFont, Brushes.Black, X, Y)
      e.HasMorePages = False
    Else
      e.Graphics.DrawString(WrkHeading, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL1), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL2), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL3), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL4), WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString(Trim(myTXENDRS._EL5), WrkFont, Brushes.Black, X, Y)
      If Trim(myTXENDRS._EL6) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL6), WrkFont, Brushes.Black, X, Y)
      End If
      If Trim(myTXENDRS._EL7) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL7), WrkFont, Brushes.Black, X, Y)
      End If
      If Trim(myTXENDRS._EL8) <> String.Empty Then
        Y += LineOffset
        e.Graphics.DrawString(Trim(myTXENDRS._EL8), WrkFont, Brushes.Black, X, Y)
      End If
      Y += LineOffset
      e.Graphics.DrawString(MyBatchNo & "-" & WrkBatchSeqNo & "-" & WrkDate, WrkFont, Brushes.Black, X, Y)
      Y += LineOffset
      e.Graphics.DrawString("Total Paid: " & Format(WrkTotCheck, "fixed"), WrkFont, Brushes.Black, X, Y)
      e.HasMorePages = False
    End If
  End Sub
  Public Sub GetEndorsementDirect(ByVal WrkBatchSeqNo As Integer, ByVal WrkTotCheck As Decimal)
    SetFonts()
    myTXENDRS = New TXENDRS.MyData(myDBConnect)
    myTXENDRS.GetOneRecordP(MyEndorseType)
    If myTXENDRS.RecordNotFound Then
      myTXENDRS.GetOneRecordP(String.Empty)
    End If
    PrtEndorseDirect(WrkBatchSeqNo, WrkTotCheck)
    myTXENDRS.CloseFile()
    myTXENDRS = Nothing
  End Sub
  <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
  Private Structure DOC_INFO_1

    <MarshalAs(UnmanagedType.LPWStr)>
    Public pDocName As String

    <MarshalAs(UnmanagedType.LPWStr)>
    Public pOutputFile As String

    <MarshalAs(UnmanagedType.LPWStr)>
    Public pDataType As String

  End Structure
  <DllImport("winspool.drv", EntryPoint:="OpenPrinterW", SetLastError:=True, CharSet:=CharSet.Unicode)>
  Private Function OpenPrinter(ByVal pPrinterName As String, ByRef phPrinter As IntPtr, ByVal pDefault As IntPtr) As Boolean
  End Function
  <DllImport("winspool.drv", EntryPoint:="ClosePrinter", SetLastError:=True)>
  Private Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
  End Function
  <DllImport("winspool.drv", EntryPoint:="StartDocPrinterW", SetLastError:=True, CharSet:=CharSet.Unicode)>
  Private Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal Level As Integer, ByRef pDocInfo As DOC_INFO_1) As Integer
  End Function
  <DllImport("winspool.drv", EntryPoint:="EndDocPrinter", SetLastError:=True)>
  Private Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
  End Function
  <DllImport("winspool.drv", EntryPoint:="StartPagePrinter", SetLastError:=True)>
  Private Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
  End Function
  <DllImport("winspool.drv", EntryPoint:="EndPagePrinter", SetLastError:=True)>
  Private Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
  End Function
  <DllImport("winspool.drv", EntryPoint:="WritePrinter", SetLastError:=True)>
  Private Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Integer, ByRef dwWritten As Integer) As Boolean
  End Function
  Public Function ResetTMU675() As Boolean

    Dim PrinterName As String
    PrinterName = MyAppSettings.ValidatePrinter
    If Trim(PrinterName) = String.Empty Then
      MsgBox("No validation printer is configured.", MsgBoxStyle.Exclamation, "Validator Reset")
      Return False
    End If

    If MyAppSettings.ValidateModel <> "TM-U675" Then
      MsgBox("The validation printer is not configured as a TM-U675.", MsgBoxStyle.Exclamation, "Validator Reset")
      Return False
    End If

    If MsgBox("Make sure the paper jam has been cleared and the printer mechanism is completely closed." & vbCrLf & vbCrLf & "Send reset command to " & PrinterName & "?",
      MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Reset Validator") <> MsgBoxResult.Yes Then
      Return False
    End If

    If SendTMU675Recovery(PrinterName) Then
      MsgBox("Reset command was sent to the Validator." & vbCrLf & vbCrLf & "Do not automatically reprint." & vbCrLf & "Retry the transaction only if needed.",
        MsgBoxStyle.Information, "Validator Reset")
      Return True
    Else
      MsgBox("The Validator reset command could not be sent." & vbCrLf & vbCrLf & "Windows error: " & Marshal.GetLastWin32Error().ToString(), MsgBoxStyle.Exclamation, "Validator Reset")
      Return False
    End If
  End Function
  Private Function SendTMU675Recovery(ByVal PrinterName As String) As Boolean

    Dim hPrinter As IntPtr = IntPtr.Zero
    Dim pBytes As IntPtr = IntPtr.Zero
    Dim DocInfo As DOC_INFO_1
    Dim DocStarted As Boolean = False
    Dim PageStarted As Boolean = False
    Dim BytesWritten As Integer = 0
    Dim Result As Boolean = False

    ' Epson DLE ENQ 2
    ' Hex bytes: 10 05 02
    Dim ResetCommand() As Byte = {&H10, &H5, &H2}

    Try
      If Not OpenPrinter(PrinterName, hPrinter, IntPtr.Zero) Then
        MsgBox("Cannot open validation printer." & vbCrLf & vbCrLf & "Printer name: [" & PrinterName & "]" & vbCrLf & "Windows error: " &
       Marshal.GetLastWin32Error().ToString(), MsgBoxStyle.Exclamation, "Validator Reset")
        Return False
      End If

      DocInfo.pDocName = "Validator Error Recovery"
      DocInfo.pOutputFile = Nothing
      DocInfo.pDataType = "RAW"

      If StartDocPrinter(hPrinter, 1, DocInfo) = 0 Then
        Return False
      End If

      DocStarted = True
      If Not StartPagePrinter(hPrinter) Then
        Return False
      End If
      PageStarted = True
      pBytes = Marshal.AllocCoTaskMem(ResetCommand.Length)
      Marshal.Copy(ResetCommand, 0, pBytes, ResetCommand.Length)
      Result = WritePrinter(hPrinter, pBytes, ResetCommand.Length, BytesWritten)
      If Not Result Then
        Return False
      End If
      If BytesWritten <> ResetCommand.Length Then
        Return False
      End If
      Return True
    Catch
      Return False
    Finally
      If pBytes <> IntPtr.Zero Then
        Marshal.FreeCoTaskMem(pBytes)
      End If
      If PageStarted Then
        EndPagePrinter(hPrinter)
      End If
      If DocStarted Then
        EndDocPrinter(hPrinter)
      End If
      If hPrinter <> IntPtr.Zero Then
        ClosePrinter(hPrinter)
      End If
    End Try
  End Function
End Module
