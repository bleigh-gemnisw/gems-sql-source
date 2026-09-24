<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMainB
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMainB))
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.LblDescr = New System.Windows.Forms.Label()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowUpdate = False
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(3, 35)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(505, 332)
    Me.C1DataGrdList.TabIndex = 179
    Me.C1DataGrdList.Text = "C1TrueDBGrid1"
    '
    'LblDescr
    '
    Me.LblDescr.AutoSize = True
    Me.LblDescr.Location = New System.Drawing.Point(12, 9)
    Me.LblDescr.Name = "LblDescr"
    Me.LblDescr.Size = New System.Drawing.Size(47, 13)
    Me.LblDescr.TabIndex = 180
    Me.LblDescr.Text = "<Descr>"
    '
    'FrmMainB
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(520, 379)
    Me.Controls.Add(Me.LblDescr)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMainB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents LblDescr As System.Windows.Forms.Label
End Class
