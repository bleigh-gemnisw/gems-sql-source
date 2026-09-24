<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSelLease
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSelLease))
        Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFind = New System.Windows.Forms.Button()
        Me.TxtPos = New System.Windows.Forms.TextBox()
        Me.LblCurrent = New System.Windows.Forms.Label()
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1DataGrdList
        '
        Me.C1DataGrdList.AlternatingRows = True
        Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
        Me.C1DataGrdList.Location = New System.Drawing.Point(12, 40)
        Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
        Me.C1DataGrdList.Name = "C1DataGrdList"
        Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
        Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
        Me.C1DataGrdList.Size = New System.Drawing.Size(551, 300)
        Me.C1DataGrdList.TabIndex = 177
        Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "Position To"
        '
        'BtnFind
        '
        Me.BtnFind.Location = New System.Drawing.Point(129, 10)
        Me.BtnFind.Name = "BtnFind"
        Me.BtnFind.Size = New System.Drawing.Size(53, 24)
        Me.BtnFind.TabIndex = 179
        Me.BtnFind.Text = "&Find"
        '
        'TxtPos
        '
        Me.TxtPos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPos.Location = New System.Drawing.Point(92, 12)
        Me.TxtPos.MaxLength = 2
        Me.TxtPos.Name = "TxtPos"
        Me.TxtPos.Size = New System.Drawing.Size(31, 20)
        Me.TxtPos.TabIndex = 178
        '
        'LblCurrent
        '
        Me.LblCurrent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblCurrent.Location = New System.Drawing.Point(209, 16)
        Me.LblCurrent.Name = "LblCurrent"
        Me.LblCurrent.Size = New System.Drawing.Size(248, 16)
        Me.LblCurrent.TabIndex = 181
        '
        'FrmSelLease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 352)
        Me.Controls.Add(Me.LblCurrent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnFind)
        Me.Controls.Add(Me.TxtPos)
        Me.Controls.Add(Me.C1DataGrdList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSelLease"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Leasing Company"
        CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFind As Button
    Friend WithEvents TxtPos As TextBox
    Friend WithEvents LblCurrent As Label
End Class
