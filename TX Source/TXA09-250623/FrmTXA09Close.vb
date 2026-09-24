Imports System.Data
Public Class FrmTXA09Close
  Inherits System.Windows.Forms.Form
  Dim myTBATCH As TBATCH.myData
  Dim WrkCloseBatch As Boolean
  Friend WrkCash As Decimal
  Friend WrkCheck As Decimal
  Friend WrkCredit As Decimal
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblBatchNo As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents LblEnd As System.Windows.Forms.Label
  Friend WithEvents LblCredit As System.Windows.Forms.Label
  Friend WithEvents LblCheck As System.Windows.Forms.Label
  Friend WithEvents LblCash As System.Windows.Forms.Label
  Friend WithEvents LblStart As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.LblBatchNo = New System.Windows.Forms.Label
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider
    Me.Label9 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.BtnClose = New System.Windows.Forms.Button
    Me.LblEnd = New System.Windows.Forms.Label
    Me.LblCredit = New System.Windows.Forms.Label
    Me.LblCheck = New System.Windows.Forms.Label
    Me.LblCash = New System.Windows.Forms.Label
    Me.LblStart = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(32, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Batch/Drawer #"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(28, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(92, 16)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "Starting Total"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(28, 96)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(92, 16)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "Check"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(28, 116)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(92, 16)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "Credit"
    '
    'LblBatchNo
    '
    Me.LblBatchNo.Location = New System.Drawing.Point(128, 24)
    Me.LblBatchNo.Name = "LblBatchNo"
    Me.LblBatchNo.Size = New System.Drawing.Size(60, 16)
    Me.LblBatchNo.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(28, 76)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(92, 16)
    Me.Label9.TabIndex = 12
    Me.Label9.Text = "Cash"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(28, 140)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(80, 16)
    Me.Label6.TabIndex = 16
    Me.Label6.Text = "Ending Total"
    '
    'BtnClose
    '
    Me.BtnClose.Location = New System.Drawing.Point(80, 176)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(80, 32)
    Me.BtnClose.TabIndex = 169
    Me.BtnClose.Text = "Close Drawer"
    '
    'LblEnd
    '
    Me.LblEnd.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
    Me.LblEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblEnd.Location = New System.Drawing.Point(128, 136)
    Me.LblEnd.Name = "LblEnd"
    Me.LblEnd.Size = New System.Drawing.Size(80, 20)
    Me.LblEnd.TabIndex = 175
    Me.LblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCredit
    '
    Me.LblCredit.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
    Me.LblCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCredit.Location = New System.Drawing.Point(128, 112)
    Me.LblCredit.Name = "LblCredit"
    Me.LblCredit.Size = New System.Drawing.Size(80, 20)
    Me.LblCredit.TabIndex = 174
    Me.LblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCheck
    '
    Me.LblCheck.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
    Me.LblCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCheck.Location = New System.Drawing.Point(128, 92)
    Me.LblCheck.Name = "LblCheck"
    Me.LblCheck.Size = New System.Drawing.Size(80, 20)
    Me.LblCheck.TabIndex = 173
    Me.LblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblCash
    '
    Me.LblCash.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
    Me.LblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCash.Location = New System.Drawing.Point(128, 72)
    Me.LblCash.Name = "LblCash"
    Me.LblCash.Size = New System.Drawing.Size(80, 20)
    Me.LblCash.TabIndex = 172
    Me.LblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblStart
    '
    Me.LblStart.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
    Me.LblStart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblStart.Location = New System.Drawing.Point(128, 48)
    Me.LblStart.Name = "LblStart"
    Me.LblStart.Size = New System.Drawing.Size(80, 20)
    Me.LblStart.TabIndex = 171
    Me.LblStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'FrmTXA09Close
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(234, 220)
    Me.Controls.Add(Me.LblEnd)
    Me.Controls.Add(Me.LblCredit)
    Me.Controls.Add(Me.LblCheck)
    Me.Controls.Add(Me.LblCash)
    Me.Controls.Add(Me.LblStart)
    Me.Controls.Add(Me.BtnClose)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LblBatchNo)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXA09Close"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Cash Drawer Close"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmTXA09Close_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTBATCH = New TBATCH.mydata(MyDBConnect)

    With MyFrmTXA09
      .TBarChange.Enabled = False
      .TBarClose.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    If myTBATCH.RecordNotFound Then Exit Sub

    With myTBATCH
      LblBatchNo.Text = MyBatchNo
      LblStart.Text = MyUtils.FmtCurrency(._KBCASH)
      LblCash.Text = MyUtils.FmtCurrency(WrkCash)
      LblCheck.Text = MyUtils.FmtCurrency(WrkCheck)
      LblCredit.Text = MyUtils.FmtCurrency(WrkCredit)
      LblEnd.Text = MyUtils.FmtCurrency(._KBEND)
      If ._KBSTAT = "P" Then
        BtnClose.Enabled = False
        MsgBox("Repost batch to start automatic recovery mode for a partially posted batch.", MsgBoxStyle.Exclamation, "Batch cannot be closed.")
      End If
    End With

  End Sub

  Private Sub FrmTXA09Close_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTXA09.SbpScreen.Text = "TXA09Close"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTXA09
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub FrmTXA09Close_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    If Not WrkCloseBatch Then
      MyFrmTXA09.TBarChange.Enabled = True
      MyFrmTXA09.TBarClose.Enabled = True
      MyFrmTXA09View.Show()
      GoTo Cleanup
    End If

    With MyFrmTXA09
      .TBarNew.Enabled = True
      .TBarView.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With

    MyFrmTXA09View.CloseScreen(True)
    MyFrmTXA09View.Close()

Cleanup:
    'Memory Cleanup
    myTBATCH.CloseFile()
    myTBATCH = Nothing
    MyFrmTXA09Close = Nothing
  End Sub
  Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click

    WrkCloseBatch = True
    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    With myTBATCH
      ._KBSTAT = "C"
      .UpdateOneRecordP()
      .CloseFile()
    End With

    If Not IsNothing(MyFrmTXA094) Then
      MyFrmTXA094.CloseBatch(False, False)
    End If
    Me.Close()

  End Sub
End Class






