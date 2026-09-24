Imports CrystalDecisions.Shared.Json

Public Class FrmTXA09View
  Inherits System.Windows.Forms.Form
  Dim myTXBATCHL1 As TXBATCHL1.MyData
  Dim myTBATCH As TBATCH.MyData
  Dim myTXBATCHReceipt As TXBATCH.MyData
  Dim ds As DataSet = New DataSet
  Friend WrkBatch As String
  Friend WrkBatchNo As Integer
  Friend WrkBackScreen As String
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblBond As System.Windows.Forms.Label
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblLien As System.Windows.Forms.Label
  Friend WithEvents LblInterest As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents label27 As System.Windows.Forms.Label
  Friend WithEvents label26 As System.Windows.Forms.Label
  Friend WithEvents label25 As System.Windows.Forms.Label
  Friend WithEvents label24 As System.Windows.Forms.Label
  Friend WithEvents LblPrincipal As System.Windows.Forms.Label
  Friend WithEvents LblFee As System.Windows.Forms.Label
  Friend WithEvents BtnReprintReceipt As Button
  Friend WrkCloseScreen As Boolean
    Friend WithEvents BtnResetPrint As Button
    Dim dsReprint As DataSet = New DataSet     ''' Lou reprint 


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblCash As System.Windows.Forms.Label
    Friend WithEvents LblCheck As System.Windows.Forms.Label
    Friend WithEvents LblCredit As System.Windows.Forms.Label
    Friend WithEvents LblEnd As System.Windows.Forms.Label
    Friend WithEvents LblStart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXA09View))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblStart = New System.Windows.Forms.Label()
    Me.LblCash = New System.Windows.Forms.Label()
    Me.LblCheck = New System.Windows.Forms.Label()
    Me.LblCredit = New System.Windows.Forms.Label()
    Me.LblEnd = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblBond = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.LblLien = New System.Windows.Forms.Label()
    Me.LblInterest = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.label27 = New System.Windows.Forms.Label()
    Me.label26 = New System.Windows.Forms.Label()
    Me.label25 = New System.Windows.Forms.Label()
    Me.label24 = New System.Windows.Forms.Label()
    Me.LblPrincipal = New System.Windows.Forms.Label()
    Me.LblFee = New System.Windows.Forms.Label()
    Me.BtnReprintReceipt = New System.Windows.Forms.Button()
    Me.BtnResetPrint = New System.Windows.Forms.Button()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(4, 80)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.Size = New System.Drawing.Size(768, 288)
    Me.C1DataGrdList.TabIndex = 6
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(616, 36)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(68, 16)
    Me.Label6.TabIndex = 26
    Me.Label6.Text = "Ending Total"
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(325, 17)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(36, 16)
    Me.Label9.TabIndex = 22
    Me.Label9.Text = "Cash"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(325, 61)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(36, 16)
    Me.Label4.TabIndex = 20
    Me.Label4.Text = "Credit"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(325, 37)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 16)
    Me.Label3.TabIndex = 18
    Me.Label3.Text = "Check"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 32)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(76, 16)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "Starting Total"
    '
    'LblStart
    '
    Me.LblStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStart.Location = New System.Drawing.Point(84, 28)
    Me.LblStart.Name = "LblStart"
    Me.LblStart.Size = New System.Drawing.Size(80, 20)
    Me.LblStart.TabIndex = 166
    Me.LblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCash
    '
    Me.LblCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCash.Location = New System.Drawing.Point(369, 9)
    Me.LblCash.Name = "LblCash"
    Me.LblCash.Size = New System.Drawing.Size(80, 20)
    Me.LblCash.TabIndex = 167
    Me.LblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCheck
    '
    Me.LblCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCheck.Location = New System.Drawing.Point(369, 33)
    Me.LblCheck.Name = "LblCheck"
    Me.LblCheck.Size = New System.Drawing.Size(80, 20)
    Me.LblCheck.TabIndex = 168
    Me.LblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(369, 57)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(80, 20)
    Me.LblCredit.TabIndex = 169
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblEnd
    '
    Me.LblEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEnd.Location = New System.Drawing.Point(692, 32)
    Me.LblEnd.Name = "LblEnd"
    Me.LblEnd.Size = New System.Drawing.Size(80, 20)
    Me.LblEnd.TabIndex = 170
    Me.LblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label11
    '
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(521, 371)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(56, 16)
    Me.Label11.TabIndex = 190
    Me.Label11.Text = "Bond Int"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblBond
    '
    Me.LblBond.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblBond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblBond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBond.Location = New System.Drawing.Point(505, 388)
    Me.LblBond.Name = "LblBond"
    Me.LblBond.Size = New System.Drawing.Size(72, 20)
    Me.LblBond.TabIndex = 191
    Me.LblBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(586, 388)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(72, 20)
    Me.LblTotal.TabIndex = 189
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblLien
    '
    Me.LblLien.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblLien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblLien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLien.Location = New System.Drawing.Point(348, 388)
    Me.LblLien.Name = "LblLien"
    Me.LblLien.Size = New System.Drawing.Size(72, 20)
    Me.LblLien.TabIndex = 188
    Me.LblLien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblInterest
    '
    Me.LblInterest.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblInterest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblInterest.Location = New System.Drawing.Point(267, 388)
    Me.LblInterest.Name = "LblInterest"
    Me.LblInterest.Size = New System.Drawing.Size(72, 20)
    Me.LblInterest.TabIndex = 186
    Me.LblInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(610, 371)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(48, 16)
    Me.Label21.TabIndex = 184
    Me.Label21.Text = "Total"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label27
    '
    Me.label27.BackColor = System.Drawing.SystemColors.Control
    Me.label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label27.Location = New System.Drawing.Point(372, 371)
    Me.label27.Name = "label27"
    Me.label27.Size = New System.Drawing.Size(48, 16)
    Me.label27.TabIndex = 183
    Me.label27.Text = "Lien"
    Me.label27.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label26
    '
    Me.label26.BackColor = System.Drawing.SystemColors.Control
    Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label26.Location = New System.Drawing.Point(442, 371)
    Me.label26.Name = "label26"
    Me.label26.Size = New System.Drawing.Size(56, 16)
    Me.label26.TabIndex = 182
    Me.label26.Text = "Fee"
    Me.label26.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label25
    '
    Me.label25.BackColor = System.Drawing.SystemColors.Control
    Me.label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label25.Location = New System.Drawing.Point(291, 371)
    Me.label25.Name = "label25"
    Me.label25.Size = New System.Drawing.Size(48, 16)
    Me.label25.TabIndex = 181
    Me.label25.Text = "Interest"
    Me.label25.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'label24
    '
    Me.label24.BackColor = System.Drawing.SystemColors.Control
    Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label24.Location = New System.Drawing.Point(210, 371)
    Me.label24.Name = "label24"
    Me.label24.Size = New System.Drawing.Size(48, 16)
    Me.label24.TabIndex = 180
    Me.label24.Text = "Principal"
    '
    'LblPrincipal
    '
    Me.LblPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPrincipal.Location = New System.Drawing.Point(186, 388)
    Me.LblPrincipal.Name = "LblPrincipal"
    Me.LblPrincipal.Size = New System.Drawing.Size(72, 20)
    Me.LblPrincipal.TabIndex = 185
    Me.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFee
    '
    Me.LblFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFee.Location = New System.Drawing.Point(426, 388)
    Me.LblFee.Name = "LblFee"
    Me.LblFee.Size = New System.Drawing.Size(72, 20)
    Me.LblFee.TabIndex = 187
    Me.LblFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnReprintReceipt
    '
    Me.BtnReprintReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnReprintReceipt.Location = New System.Drawing.Point(12, 374)
    Me.BtnReprintReceipt.Name = "BtnReprintReceipt"
    Me.BtnReprintReceipt.Size = New System.Drawing.Size(79, 36)
    Me.BtnReprintReceipt.TabIndex = 201
    Me.BtnReprintReceipt.TabStop = False
    Me.BtnReprintReceipt.Text = "Reprint Receipt"
    '
    'BtnResetPrint
    '
    Me.BtnResetPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnResetPrint.Location = New System.Drawing.Point(97, 374)
    Me.BtnResetPrint.Name = "BtnResetPrint"
    Me.BtnResetPrint.Size = New System.Drawing.Size(78, 36)
    Me.BtnResetPrint.TabIndex = 206
    Me.BtnResetPrint.Text = "Reset Validator"
    '
    'FrmTXA09View
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(784, 416)
    Me.Controls.Add(Me.BtnResetPrint)
    Me.Controls.Add(Me.BtnReprintReceipt)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.LblBond)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.LblLien)
    Me.Controls.Add(Me.LblInterest)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.label27)
    Me.Controls.Add(Me.label26)
    Me.Controls.Add(Me.label25)
    Me.Controls.Add(Me.label24)
    Me.Controls.Add(Me.LblPrincipal)
    Me.Controls.Add(Me.LblFee)
    Me.Controls.Add(Me.LblEnd)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.LblCheck)
    Me.Controls.Add(Me.LblCash)
    Me.Controls.Add(Me.LblStart)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09View"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "View Batch"
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region
  Private Sub FrmTXA09View_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WrkStatus As String
        Dim WrkStatusCd As String

        With MyFrmTXA09
            .TBarDelete.Enabled = False
            .TBarNew.Enabled = False
            .TBarView.Enabled = False
            .TBarSettings.Enabled = False
            .TBarClose.Enabled = True
            .TBarChange.Enabled = True
            .TBarPrtEdits.Enabled = True
            If s_full Or s_post Then
                .TBarPost.Enabled = True
            End If
        End With

        myTBATCH = New TBATCH.MyData(myDBConnect)
        myTXBATCHL1 = New TXBATCHL1.MyData(myDBConnect)
        myTBATCH.GetOneRecordP(WrkBatch, WrkBatchNo)
        If myTBATCH.RecordNotFound Then Exit Sub

        With myTBATCH
            WrkStatusCd = ._KBSTAT
            WrkStatus = ""
            Select Case WrkStatusCd
                Case "C"
                    WrkStatus = "Closed"
                Case "O"
                    WrkStatus = "Open"
                Case "P"
                    WrkStatus = "Posting"
                    With MyFrmTXA09
                        .TBarChange.Enabled = False
                        .TBarPrtEdits.Enabled = False
                    End With
            End Select
            If WrkBatch <> "P" Then 'Not a PC Batch
                With MyFrmTXA09
                    .TBarClose.Enabled = False
                    .TBarChange.Enabled = False
                    .TBarPrtEdits.Enabled = False
                    .TBarPost.Enabled = False
                End With
            End If
        End With

        Me.Text = Me.Text & Str$(WrkBatchNo) & "-" & WrkStatus
        If WrkStatus = "Closed" Then
            MyFrmTXA09.TBarClose.Enabled = False
        End If

        Call FormatGrid()

    End Sub
    Public Sub FormatGrid()

        Call ShowGrid()

        With C1DataGrdList
            .Rebind(True)
            .FetchRowStyles = True
            .Columns(0).ValueItems.Values.Clear()
            .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("B", "Back Tx"))
            .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("S", "Susp"))
            .Columns(0).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("V", "Void"))
            .Columns(0).ValueItems.Translate = True
            .Columns(0).Caption = "Status"
            .Splits(0).DisplayColumns(0).Width = 50
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Columns(1).Caption = "List No"
            .Splits(0).DisplayColumns(1).Width = 50
            .Columns(2).Caption = "Year"
            .Splits(0).DisplayColumns(2).Width = 30
            .Columns(3).Caption = "Type"
            .Splits(0).DisplayColumns(3).Width = 30
            .Columns(4).Caption = "Payment"
            .Splits(0).DisplayColumns(4).Width = 70
            .Columns(5).Caption = "Interest"
            .Splits(0).DisplayColumns(5).Width = 50
            .Columns(6).Caption = "Liens"
            .Splits(0).DisplayColumns(6).Width = 50
            .Columns(7).Caption = "Fees"
            .Splits(0).DisplayColumns(7).Width = 50
            .Splits(0).DisplayColumns(8).Visible = False
            .Splits(0).DisplayColumns(9).Visible = False
            .Splits(0).DisplayColumns(10).Visible = False
            .Splits(0).DisplayColumns(11).Visible = False
            .Columns(12).Caption = "Adj"
            .Columns(12).ValueItems.Values.Clear()
            .Columns(12).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("A", "Adjust"))
            .Columns(12).ValueItems.Values.Add(New C1.Win.C1TrueDBGrid.ValueItem("R", "Refund"))
            .Columns(12).ValueItems.Translate = True
            .Splits(0).DisplayColumns(12).Width = 50
            .Columns(13).Caption = "Seq #"
            .Splits(0).DisplayColumns(13).Width = 40
            .Splits(0).DisplayColumns(14).Visible = False
            .Splits(0).DisplayColumns(15).Visible = False
            .Splits(0).DisplayColumns(16).Visible = False
            .Splits(0).DisplayColumns(17).Visible = False
            .Splits(0).DisplayColumns(18).Visible = False
            .Columns(19).Caption = "Name"
            .Splits(0).DisplayColumns(19).Width = 200
            .Splits(0).DisplayColumns(20).Visible = False
            .Splits(0).DisplayColumns(21).Visible = False
            .Splits(0).DisplayColumns(22).Visible = False
            .Splits(0).DisplayColumns(23).Visible = False
            .Columns(24).Caption = "Fee Cd"
            .Splits(0).DisplayColumns(24).Width = 50
            .Splits(0).DisplayColumns(25).Visible = False
            .Splits(0).DisplayColumns(26).Visible = False
            .Splits(0).DisplayColumns(27).Visible = False
            .Splits(0).DisplayColumns(28).Visible = False
            .Splits(0).DisplayColumns(29).Visible = False
            .Splits(0).DisplayColumns(30).Visible = False
            .Splits(0).DisplayColumns(31).Visible = False
            .Splits(0).DisplayColumns(32).Visible = False
            .Splits(0).DisplayColumns(33).Visible = False
            .Splits(0).DisplayColumns(34).Visible = False
            .Splits(0).DisplayColumns(35).Visible = False
            .Splits(0).DisplayColumns(36).Visible = False
            .Splits(0).DisplayColumns(37).Visible = False
            .Splits(0).DisplayColumns(38).Visible = False
            .Splits(0).DisplayColumns(39).Visible = False
            .Splits(0).DisplayColumns(40).Visible = False
            .Splits(0).DisplayColumns(41).Visible = False
            .Splits(0).DisplayColumns(42).Visible = False
        End With

    End Sub
    Public Sub ShowGrid()
        ds = myTXBATCHL1.GetViewByBatch(WrkBatch, WrkBatchNo, 2000)
        C1DataGrdList.DataSource = ds.Tables(0)
        C1DataGrdList.Refresh()
        CalcBatchTotals()
        CalcTotals()
    End Sub
    Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick

        If C1DataGrdList.Item(C1DataGrdList.Row, 0) = "V" Then
            MsgBox("Cannot void transaction", MsgBoxStyle.Exclamation, "Transaction already voided")
            Exit Sub
        End If

        If WrkBatch <> "P" Then 'AS/400 Batch
            MsgBox("Cannot void transaction", MsgBoxStyle.Exclamation, "Cannot change AS/400 Batch")
            Exit Sub
        End If

        MyFrmTXA09Void = New FrmTXA09Void
        MyFrmTXA09Void.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 13)
        MyFrmTXA09Void.ShowDialog()
        FormatGrid()
        CalcBatchTotals()
    End Sub
    Private Sub FrmTXA09View_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MyFrmTXA09.SbpScreen.Text = "TXA09View"
        With MyFrmTXA09
            .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
            .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
        End With
    End Sub
    Private Sub FrmTXA09View_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ds.Clear()
        ds = Nothing

        'Memory Cleanup
        myTXBATCHL1.CloseFile()
        myTXBATCHL1 = Nothing
        myTBATCH.CloseFile()
        myTBATCH = Nothing
        MyFrmTXA09View = Nothing

        CloseScreen(WrkCloseScreen)
    End Sub
    Public Sub CloseScreen(ByVal CloseBatch As Boolean)
        With MyFrmTXA09
            .TBarView.Enabled = True
            .TBarDelete.Enabled = False
            .TBarChange.Enabled = False
            .TBarClose.Enabled = False
            .TBarPrtEdits.Enabled = False
            .TBarPost.Enabled = False
        End With

        Select Case WrkBackScreen
            Case Is = "TXA091"
                MyFrmTXA09.TBarNew.Enabled = True
                MyFrmTXA091.FormatGrid()
                MyFrmTXA091.Show()
            Case Is = "TXA094"
                If CloseBatch Then
                    MyBatchNo = 0
                    MyFrmTXA09.TBarNew.Enabled = True
                    MyFrmTXA09.TBarView.Enabled = True
                    MyFrmTXA091.FormatGrid()
                    MyFrmTXA091.Show()
                Else
                    If MyScanOnly Then
                        MyFrmTXA094.FormatGrid(False, False, True)
                    Else
                        MyFrmTXA094.FormatGrid(True, True, False)
                    End If
                    MyFrmTXA094.Show()
                End If
        End Select
    End Sub

    Sub CalcBatchTotals()
        Dim I As Integer
        Dim FoundVoid As Boolean
        Dim TotalCash As Decimal
        Dim TotalCheck As Decimal
        Dim TotalCredit As Decimal

        For I = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(I)
                If .Item("jstat") <> "V" Then
                    TotalCash = TotalCash + .Item("cash")
                    TotalCheck = TotalCheck + .Item("check")
                    TotalCredit = TotalCredit + .Item("credit")
                Else
                    FoundVoid = True
                End If
            End With
        Next

        LblCash.Text = Format(TotalCash, "Fixed")
        LblCheck.Text = Format(TotalCheck, "Fixed")
        LblCredit.Text = Format(TotalCredit, "Fixed")

        myTBATCH.GetOneRecordP(WrkBatch, WrkBatchNo)
        If myTBATCH.RecordNotFound Then Exit Sub
        With myTBATCH
            If (TotalCash + TotalCheck + TotalCredit) <> ._KBEND - ._KBCASH Then 'Fix if Total not equal to detail
                ._KBEND = ._KBCASH + TotalCash + TotalCheck + TotalCredit
                .UpdateOneRecordP()
            End If
            LblStart.Text = ._KBCASH
            LblEnd.Text = ._KBEND
        End With

        If (TotalCash + TotalCheck + TotalCredit) = 0 And Not FoundVoid Then
            If MyFrmTXA09.TBarChange.Enabled Then
                MyFrmTXA09.TBarDelete.Enabled = True
            End If
        End If

    End Sub
    Public Sub DeleteData(ByRef Cancel As Boolean)
        Dim Answer As Integer
        Cancel = True
        Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
        If Answer = vbNo Then Exit Sub

        Cancel = False
        myTBATCH.DeleteOneRecordP()

        WrkCloseScreen = True
        Me.Close()
    End Sub
    Private Sub C1DataGrdList_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles C1DataGrdList.FetchRowStyle
        If C1DataGrdList.Columns("jstat").CellValue(e.Row) = "V" Then
            e.CellStyle.BackColor = System.Drawing.Color.Pink
        End If
    End Sub
    Private Sub CalcTotals()
        Dim I As Integer
        Dim WrkPrincipal As Decimal
        Dim WrkInterest As Decimal
        Dim WrkFee As Decimal
        Dim WrkBond As Decimal
        Dim WrkLien As Decimal
        Dim WrkTotal As Decimal

        For I = 0 To (C1DataGrdList.Splits(0).Rows.Count - 1)
            If C1DataGrdList.Item(I, 0) = "V" Then Continue For
            WrkPrincipal = WrkPrincipal + C1DataGrdList.Item(I, 4)
            WrkInterest = WrkInterest + C1DataGrdList.Item(I, 5)
            If C1DataGrdList.Item(I, 24) = "BI" Then
                WrkBond = WrkBond + C1DataGrdList.Item(I, 7)
            Else
                WrkFee = WrkFee + C1DataGrdList.Item(I, 7)
            End If
            WrkLien = WrkLien + C1DataGrdList.Item(I, 6)
        Next

        WrkTotal = WrkPrincipal + WrkInterest + WrkFee + WrkBond + WrkLien
        LblPrincipal.Text = Format(WrkPrincipal, "Fixed")
        LblInterest.Text = Format(WrkInterest, "Fixed")
        LblFee.Text = Format(WrkFee, "Fixed")
        LblLien.Text = Format(WrkLien, "Fixed")
        LblBond.Text = Format(WrkBond, "Fixed")
        LblTotal.Text = Format(WrkTotal, "Fixed")

    End Sub

    Private Sub BtnReprintReceipt_Click(sender As Object, e As EventArgs) Handles BtnReprintReceipt.Click



        If C1DataGrdList.Item(C1DataGrdList.Row, 0) = "V" Then
            MsgBox("Cannot reprint a void transaction", MsgBoxStyle.Exclamation, "Transaction is voided")
            Exit Sub
        End If

        If WrkBatch <> "P" Then 'AS/400 Batch
            MsgBox("Cannot reprint an AS/00 transaction", MsgBoxStyle.Exclamation, "This is an AS/400 Batch")
            Exit Sub
        End If


        If C1DataGrdList.Splits(0).Rows.Count = 0 Then
            MsgBox("There are no receipts available to reprint", MsgBoxStyle.Exclamation, "Click OK")
            Exit Sub
        End If

        RunPrintForms()

    End Sub

    Private Sub RunPrintForms()
        BuildDS()
        AddOneRecord()
        PrintForms()
    End Sub

    Private Sub PrintForms()
        If MyAppSettings.AdvDriver Then
            PrtReceiptDirect(dsReprint, False, True)
        Else
            PrtReceipt(dsReprint, False, True)
        End If

        dsReprint.Clear()
        dsReprint = Nothing
    End Sub

    Private Sub BuildDS()
        Dim myTable As New DataTable
        dsReprint = New DataSet
        With myTable
            .TableName = "mytable"
            .Columns.Add("Sortdata", Type.GetType("System.String"))
            .Columns.Add("ListNo", Type.GetType("System.Int32"))
            .Columns.Add("Type", Type.GetType("System.String"))
            .Columns.Add("TypeDesc", Type.GetType("System.String"))
            .Columns.Add("Year", Type.GetType("System.Int32"))
            .Columns.Add("Name", Type.GetType("System.String"))
            .Columns.Add("SName", Type.GetType("System.String"))
            .Columns.Add("PropDesc", Type.GetType("System.String"))
            .Columns.Add("PropDesc2", Type.GetType("System.String"))
            .Columns.Add("Seq", Type.GetType("System.Int32"))
            .Columns.Add("Principal", Type.GetType("System.Decimal"))
            .Columns.Add("Interest", Type.GetType("System.Decimal"))
            .Columns.Add("Liens", Type.GetType("System.Decimal"))
            .Columns.Add("Fees", Type.GetType("System.Decimal"))
            .Columns.Add("Bond", Type.GetType("System.Decimal"))
            .Columns.Add("Total", Type.GetType("System.Decimal"))
            .Columns.Add("Cash", Type.GetType("System.Decimal"))
            .Columns.Add("Check", Type.GetType("System.Decimal"))
            .Columns.Add("Credit", Type.GetType("System.Decimal"))
            .Columns.Add("Batch", Type.GetType("System.String"))
            .Columns.Add("BatchNo", Type.GetType("System.Int32"))
            .Columns.Add("RecDt", Type.GetType("System.DateTime"))
            .Columns.Add("Refe", Type.GetType("System.String"))
        End With
        dsReprint.Tables.Add(myTable)
    End Sub
    Sub AddOneRecord()
        Dim myDr As Data.DataRow
        myDr = dsReprint.Tables(0).NewRow

        myTXBATCHReceipt = New TXBATCH.MyData(myDBConnect)

        Dim SeqNoReceipt As Integer = C1DataGrdList.Item(C1DataGrdList.Row, 13)

        myTXBATCHReceipt.GetOneRecordP(MyBatch, MyBatchNo, SeqNoReceipt)
        With myTXBATCHReceipt

            'LblName.Text = Trim(._NAME)
            'LblPrincipal.Text = ._PAMT * -1
            'LblInterest.Text = ._IAMT * -1
            'LblLien.Text = ._LAMT * -1
            'LblFee.Text = ._TCAMT * -1
            'LblUnposted.Text = ._PAMT * -1
            'If ._ADJCD = "A" Then
            '  LblAdjust.Text = "Adjust"
            'End If
            'If ._ADJCD = "R" Then
            '  LblAdjust.Text = "Refund"
            'End If

            myDr("ListNo") = ._LISTNo
            myDr("Type") = ._TYPE
            myDr("TypeDesc") = GetTXTypeDesc(._TYPE)
            myDr("Year") = ._YEAR
            myDr("seq") = SeqNoReceipt
            myDr("Name") = Trim(._NAME)
            myDr("SName") = "" '' LblSname.Text""
            myDr("PropDesc") = "" '' LblProperty.Text
            myDr("PropDesc2") = "" '' LblProperty2.Text
            myDr("Principal") = ._PAMT
            myDr("Interest") = ._IAMT
            myDr("Liens") = ._LAMT
            myDr("Fees") = ._TCAMT
            myDr("Bond") = 0 '' MyUtils.CnvSng(TxtBond.Text)
            myDr("Total") = 0 '' MyUtils.CnvSng(LblAmt.Text)
            myDr("Cash") = ._CASH
            myDr("Check") = ._CHECK
            myDr("Credit") = ._CREDIT
            myDr("batch") = MyBatch
            myDr("batchno") = MyBatchNo
            myDr("recdt") = MyReceiptDate.Date
            myDr("refe") = "" '' Trim(TxtCheckNo.Text)
            dsReprint.Tables(0).Rows.Add(myDr)
        End With
    End Sub

    Private Sub BtnResetPrint_Click(sender As Object, e As EventArgs) Handles BtnResetPrint.Click
    Dim Good As Boolean
    Good = ResetTMU675()
  End Sub
End Class






