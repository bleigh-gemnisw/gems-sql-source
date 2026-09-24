Imports System.Drawing.Printing
Module PrintDirect
   Private WithEvents pdReceipt As PrintDocument
   Private WithEvents pdEndorse As PrintDocument
   Dim myBDENDRS As BDENDRS.myData
   Dim WrkHeading As String
   Dim WrkHeading2 As String
   Dim WrkReceiptHeading As String
   Dim WrkReceiptHeading2 As String
   Dim WrkFont As Font
   Dim WrkTrDate As Date
   Dim WrkName As String
   Dim WrkPropLoc As String
   Dim WrkFee As Decimal
   Dim WrkMischg As Decimal
   Dim WrkTotal As Decimal
   Dim WrkPayType As String
   Dim WrkPermitType As String
   Dim WrkPermitNo As String
  Private Sub SetFonts()
   If MyAppSettings.ValidateFont = "Arial-10" Then
     WrkFont = New Font("Arial", 10)
   Else
     WrkFont = New Font("Courier New", 9)
   End If

  End Sub

  Public Sub PrtReceiptDirect(ByVal pTrDate As Date, ByVal pName As String, ByVal pPropLoc As String, _
    ByVal pFee As Decimal, ByVal pMischg As Decimal, ByVal pTotal As Decimal, ByVal pPermitType As String, _
    ByVal pPermitNo As String, ByVal pPayType As String)

   SetFonts()
   WrkHeading = Trim(Replace(myTOWN._TOWN, "TOWN OF ", String.Empty, 1, -1, CompareMethod.Text))
   WrkHeading = Trim(Replace(myTOWN._TOWN, "CITY OF ", String.Empty, 1, -1, CompareMethod.Text))
   WrkHeading = WrkHeading & " Building Dept"
   WrkHeading2 = ""
   WrkReceiptHeading = WrkHeading
   WrkReceiptHeading2 = WrkHeading2

   WrkTrDate = pTrDate
   WrkName = pName
   WrkPropLoc = pPropLoc
   WrkFee = pFee
   WrkTotal = pTotal
   WrkMischg = pMischg
   WrkPermitType = pPermitType
   WrkPermitNo = pPermitNo
   WrkPayType = pPayType
   pdReceipt = New PrintDocument
   ' Change the printer to the indicated printer
   pdReceipt.PrinterSettings.PrinterName = MyAppSettings.ReceiptPrinter
   If pdReceipt.PrinterSettings.IsValid Then
     pdReceipt.DocumentName = "Receipt"
     ' Start printing
     pdReceipt.Print()
   End If
End Sub
    Private Sub pdReceipt_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdReceipt.PrintPage
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
          e.Graphics.DrawString(WrkHeading2, WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(WrkName, WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(WrkPropLoc, WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Format(WrkTrDate, "M/d/yyyy"), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString("Fee:    " & Format(WrkFee, "fixed"), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString("Mischg: " & Format(WrkMischg, "fixed"), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString("Total:  " & Format(WrkTotal, "fixed"), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(WrkPermitNo & "-" & WrkPermitType & " " & WrkPayType, WrkFont, Brushes.Black, X, Y)
        End If
        e.HasMorePages = False
    End Sub
Private Function JustifyFixed(ByVal WrkNumber As Decimal, ByVal WrkSize As Integer) As String
  JustifyFixed = MyUtils.JustifyRight(Format(WrkNumber, "fixed"), WrkSize)
End Function
  Public Sub PrtEndorseDirect(ByVal pTrDate As Date)
    myBDENDRS = New BDENDRS.mydata(MyDBConnect)
    myBDENDRS.GetOneRecordP("")
    SetFonts()
    WrkTrDate = pTrDate
    pdEndorse = New PrintDocument
    ' Change the printer to the indicated printer
    pdEndorse.PrinterSettings.PrinterName = MyAppSettings.ValidatePrinter

    If pdEndorse.PrinterSettings.IsValid Then
        pdEndorse.DocumentName = "Endorse"
        ' Start printing
        pdEndorse.Print()
    End If
    myBDENDRS.CloseFile()
    myBDENDRS = Nothing
End Sub
    Private Sub pdEndorse_Print(ByVal sender As System.Object, ByVal e As PrintPageEventArgs) Handles pdEndorse.PrintPage
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
          e.Graphics.DrawString(Trim(myBDENDRS._EL1), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Trim(myBDENDRS._EL2), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Trim(myBDENDRS._EL3), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Trim(myBDENDRS._EL4), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Trim(myBDENDRS._EL5), WrkFont, Brushes.Black, X, Y)
          Y += LineOffset
          e.Graphics.DrawString(Format(WrkTrDate, "M/d/yyyy"), WrkFont, Brushes.Black, X, Y)
        End If
    End Sub
End Module






