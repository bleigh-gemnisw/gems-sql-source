<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01SUM
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAP01SUM))
    Me.C1DataGrdSum = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblSubDeprValue = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblSubAssrNet = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LblExam = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.LblFinal = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblPenalty = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblApplyPenalty = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.C1DataGrdExm = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.LblOwname = New System.Windows.Forms.Label()
    Me.BtnApply = New System.Windows.Forms.Button()
    CType(Me.C1DataGrdSum, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdExm, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdSum
    '
    Me.C1DataGrdSum.AllowColSelect = False
    Me.C1DataGrdSum.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdSum.AlternatingRows = True
    Me.C1DataGrdSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdSum.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdSum.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdSum.Images.Add(CType(resources.GetObject("C1DataGrdSum.Images"), System.Drawing.Image))
    Me.C1DataGrdSum.Location = New System.Drawing.Point(15, 38)
    Me.C1DataGrdSum.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdSum.Name = "C1DataGrdSum"
    Me.C1DataGrdSum.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdSum.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdSum.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdSum.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdSum.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdSum.PropBag = resources.GetString("C1DataGrdSum.PropBag")
    Me.C1DataGrdSum.Size = New System.Drawing.Size(430, 343)
    Me.C1DataGrdSum.TabIndex = 208
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(179, 9)
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
    Me.LblListNo.Location = New System.Drawing.Point(60, 7)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(60, 18)
    Me.LblListNo.TabIndex = 202
    Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Location = New System.Drawing.Point(14, 10)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(40, 13)
    Me.Label30.TabIndex = 205
    Me.Label30.Text = "List No"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Location = New System.Drawing.Point(142, 10)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(29, 13)
    Me.Label29.TabIndex = 204
    Me.Label29.Text = "Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblSubDeprValue
    '
    Me.LblSubDeprValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSubDeprValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSubDeprValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSubDeprValue.Location = New System.Drawing.Point(290, 393)
    Me.LblSubDeprValue.Name = "LblSubDeprValue"
    Me.LblSubDeprValue.Size = New System.Drawing.Size(79, 18)
    Me.LblSubDeprValue.TabIndex = 209
    Me.LblSubDeprValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(145, 394)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(139, 15)
    Me.Label2.TabIndex = 210
    Me.Label2.Text = "Depr Value (w/o Penalty)"
    '
    'LblSubAssrNet
    '
    Me.LblSubAssrNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblSubAssrNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblSubAssrNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSubAssrNet.Location = New System.Drawing.Point(517, 393)
    Me.LblSubAssrNet.Name = "LblSubAssrNet"
    Me.LblSubAssrNet.Size = New System.Drawing.Size(79, 18)
    Me.LblSubAssrNet.TabIndex = 211
    Me.LblSubAssrNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(396, 396)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(118, 17)
    Me.Label3.TabIndex = 212
    Me.Label3.Text = "Assr Net (w/o Penalty)"
    '
    'LblExam
    '
    Me.LblExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExam.Location = New System.Drawing.Point(517, 429)
    Me.LblExam.Name = "LblExam"
    Me.LblExam.Size = New System.Drawing.Size(79, 18)
    Me.LblExam.TabIndex = 215
    Me.LblExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(396, 429)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(115, 18)
    Me.Label4.TabIndex = 216
    Me.Label4.Text = "Exemptions"
    '
    'LblFinal
    '
    Me.LblFinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFinal.Location = New System.Drawing.Point(517, 447)
    Me.LblFinal.Name = "LblFinal"
    Me.LblFinal.Size = New System.Drawing.Size(79, 18)
    Me.LblFinal.TabIndex = 217
    Me.LblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(396, 447)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(115, 18)
    Me.Label5.TabIndex = 218
    Me.Label5.Text = "Final Assessment"
    '
    'LblPenalty
    '
    Me.LblPenalty.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPenalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPenalty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPenalty.Location = New System.Drawing.Point(517, 411)
    Me.LblPenalty.Name = "LblPenalty"
    Me.LblPenalty.Size = New System.Drawing.Size(79, 18)
    Me.LblPenalty.TabIndex = 219
    Me.LblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(396, 414)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(115, 15)
    Me.Label6.TabIndex = 220
    Me.Label6.Text = "Penalty"
    '
    'LblApplyPenalty
    '
    Me.LblApplyPenalty.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblApplyPenalty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblApplyPenalty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblApplyPenalty.Location = New System.Drawing.Point(148, 451)
    Me.LblApplyPenalty.Name = "LblApplyPenalty"
    Me.LblApplyPenalty.Size = New System.Drawing.Size(79, 18)
    Me.LblApplyPenalty.TabIndex = 221
    Me.LblApplyPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(3, 452)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(138, 13)
    Me.Label7.TabIndex = 222
    Me.Label7.Text = "If Penalty, amount would be"
    '
    'C1DataGrdExm
    '
    Me.C1DataGrdExm.AllowColSelect = False
    Me.C1DataGrdExm.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdExm.AlternatingRows = True
    Me.C1DataGrdExm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdExm.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdExm.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdExm.Images.Add(CType(resources.GetObject("C1DataGrdExm.Images"), System.Drawing.Image))
    Me.C1DataGrdExm.Location = New System.Drawing.Point(491, 38)
    Me.C1DataGrdExm.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdExm.Name = "C1DataGrdExm"
    Me.C1DataGrdExm.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdExm.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdExm.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdExm.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdExm.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdExm.PropBag = resources.GetString("C1DataGrdExm.PropBag")
    Me.C1DataGrdExm.Size = New System.Drawing.Size(406, 343)
    Me.C1DataGrdExm.TabIndex = 223
    '
    'LblOwname
    '
    Me.LblOwname.AutoSize = True
    Me.LblOwname.Location = New System.Drawing.Point(239, 12)
    Me.LblOwname.Name = "LblOwname"
    Me.LblOwname.Size = New System.Drawing.Size(81, 13)
    Me.LblOwname.TabIndex = 224
    Me.LblOwname.Text = "<Owner Name>"
    '
    'BtnApply
    '
    Me.BtnApply.Location = New System.Drawing.Point(234, 447)
    Me.BtnApply.Name = "BtnApply"
    Me.BtnApply.Size = New System.Drawing.Size(50, 23)
    Me.BtnApply.TabIndex = 225
    Me.BtnApply.Text = "Apply"
    Me.BtnApply.UseVisualStyleBackColor = True
    '
    'FrmTAP01SUM
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(909, 472)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnApply)
    Me.Controls.Add(Me.LblOwname)
    Me.Controls.Add(Me.C1DataGrdExm)
    Me.Controls.Add(Me.LblApplyPenalty)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblPenalty)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LblFinal)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblExam)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.LblSubAssrNet)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblSubDeprValue)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.C1DataGrdSum)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP01SUM"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Summary/Exemptions"
    CType(Me.C1DataGrdSum, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdExm, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents C1DataGrdSum As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents LblSubDeprValue As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblSubAssrNet As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblExam As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblFinal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblPenalty As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblApplyPenalty As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents C1DataGrdExm As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblOwname As System.Windows.Forms.Label
    Friend WithEvents BtnApply As System.Windows.Forms.Button
End Class






