<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01DEP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP01DEP))
    Me.TxtLtr = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.BtnShow = New System.Windows.Forms.Button()
    Me.LnkCode = New System.Windows.Forms.LinkLabel()
    Me.TxtCode = New System.Windows.Forms.TextBox()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.LblSummary = New System.Windows.Forms.Label()
    Me.LblTxtSummary = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtLtr
    '
    Me.TxtLtr.Location = New System.Drawing.Point(140, 41)
    Me.TxtLtr.MaxLength = 1
    Me.TxtLtr.Name = "TxtLtr"
    Me.TxtLtr.Size = New System.Drawing.Size(22, 20)
    Me.TxtLtr.TabIndex = 1
    '
    'Label24
    '
    Me.Label24.Location = New System.Drawing.Point(116, 43)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(22, 17)
    Me.Label24.TabIndex = 210
    Me.Label24.Text = "Ltr"
    '
    'BtnShow
    '
    Me.BtnShow.Location = New System.Drawing.Point(178, 39)
    Me.BtnShow.Name = "BtnShow"
    Me.BtnShow.Size = New System.Drawing.Size(46, 21)
    Me.BtnShow.TabIndex = 2
    Me.BtnShow.Text = "Show"
    Me.BtnShow.UseVisualStyleBackColor = True
    '
    'LnkCode
    '
    Me.LnkCode.Location = New System.Drawing.Point(12, 40)
    Me.LnkCode.Name = "LnkCode"
    Me.LnkCode.Size = New System.Drawing.Size(37, 20)
    Me.LnkCode.TabIndex = 3
    Me.LnkCode.TabStop = True
    Me.LnkCode.Text = "Code"
    '
    'TxtCode
    '
    Me.TxtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode.Location = New System.Drawing.Point(69, 40)
    Me.TxtCode.MaxLength = 3
    Me.TxtCode.Name = "TxtCode"
    Me.TxtCode.Size = New System.Drawing.Size(32, 20)
    Me.TxtCode.TabIndex = 0
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(191, 9)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(33, 18)
    Me.LblYear.TabIndex = 203
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblListNo
    '
    Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblListNo.Location = New System.Drawing.Point(69, 9)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(69, 18)
    Me.LblListNo.TabIndex = 202
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(12, 10)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(51, 17)
    Me.Label30.TabIndex = 205
    Me.Label30.Text = "List No"
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(154, 10)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(35, 17)
    Me.Label29.TabIndex = 204
    Me.Label29.Text = "Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColMove = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FetchRowStyles = True
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(12, 67)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.RowHeight = 16
    Me.C1DataGrdList.Size = New System.Drawing.Size(364, 226)
    Me.C1DataGrdList.TabIndex = 212
    '
    'LblSummary
    '
    Me.LblSummary.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.LblSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSummary.Location = New System.Drawing.Point(298, 37)
    Me.LblSummary.Name = "LblSummary"
    Me.LblSummary.Size = New System.Drawing.Size(78, 18)
    Me.LblSummary.TabIndex = 213
    Me.LblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.LblSummary.Visible = False
    '
    'LblTxtSummary
    '
    Me.LblTxtSummary.Location = New System.Drawing.Point(298, 9)
    Me.LblTxtSummary.Name = "LblTxtSummary"
    Me.LblTxtSummary.Size = New System.Drawing.Size(78, 18)
    Me.LblTxtSummary.TabIndex = 214
    Me.LblTxtSummary.Text = "Summary"
    Me.LblTxtSummary.TextAlign = System.Drawing.ContentAlignment.TopRight
    Me.LblTxtSummary.Visible = False
    '
    'FrmTAP01DEP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(388, 304)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblTxtSummary)
    Me.Controls.Add(Me.LblSummary)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.TxtLtr)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.BtnShow)
    Me.Controls.Add(Me.LnkCode)
    Me.Controls.Add(Me.TxtCode)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01DEP"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Depreciated Codes"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents TxtLtr As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnShow As System.Windows.Forms.Button
    Friend WithEvents LnkCode As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblTxtSummary As System.Windows.Forms.Label
    Friend WithEvents LblSummary As System.Windows.Forms.Label
End Class






