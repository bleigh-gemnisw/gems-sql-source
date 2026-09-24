<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.BtnCheck = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtVIN = New System.Windows.Forms.TextBox()
        Me.LblTradeIn = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LblWholesale = New System.Windows.Forms.Label()
        Me.LblRetail = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblClassMax = New System.Windows.Forms.Label()
        Me.LblClassMin = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblSubType = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblClassification = New System.Windows.Forms.Label()
        Me.LblClassificationHdr = New System.Windows.Forms.Label()
        Me.LblCatName = New System.Windows.Forms.Label()
        Me.LblCatNameHdr = New System.Windows.Forms.Label()
        Me.LblMfgName = New System.Windows.Forms.Label()
        Me.LblMfgNameHdr = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblMSRP = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblComplete = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnCheck
        '
        Me.BtnCheck.Location = New System.Drawing.Point(213, 21)
        Me.BtnCheck.Name = "BtnCheck"
        Me.BtnCheck.Size = New System.Drawing.Size(107, 20)
        Me.BtnCheck.TabIndex = 0
        Me.BtnCheck.Text = "Check VIN"
        Me.BtnCheck.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "VIN"
        '
        'TxtVIN
        '
        Me.TxtVIN.Location = New System.Drawing.Point(80, 22)
        Me.TxtVIN.MaxLength = 17
        Me.TxtVIN.Name = "TxtVIN"
        Me.TxtVIN.Size = New System.Drawing.Size(127, 20)
        Me.TxtVIN.TabIndex = 2
        '
        'LblTradeIn
        '
        Me.LblTradeIn.AutoSize = True
        Me.LblTradeIn.Location = New System.Drawing.Point(147, 160)
        Me.LblTradeIn.Name = "LblTradeIn"
        Me.LblTradeIn.Size = New System.Drawing.Size(59, 13)
        Me.LblTradeIn.TabIndex = 314
        Me.LblTradeIn.Text = "<Trade In>"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(77, 160)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 13)
        Me.Label24.TabIndex = 313
        Me.Label24.Text = "Trade In"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(77, 147)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 312
        Me.Label23.Text = "Wholesale"
        '
        'LblWholesale
        '
        Me.LblWholesale.AutoSize = True
        Me.LblWholesale.Location = New System.Drawing.Point(147, 147)
        Me.LblWholesale.Name = "LblWholesale"
        Me.LblWholesale.Size = New System.Drawing.Size(69, 13)
        Me.LblWholesale.TabIndex = 311
        Me.LblWholesale.Text = "<Wholesale>"
        '
        'LblRetail
        '
        Me.LblRetail.AutoSize = True
        Me.LblRetail.Location = New System.Drawing.Point(147, 134)
        Me.LblRetail.Name = "LblRetail"
        Me.LblRetail.Size = New System.Drawing.Size(46, 13)
        Me.LblRetail.TabIndex = 310
        Me.LblRetail.Text = "<Retail>"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(77, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 309
        Me.Label6.Text = "Class Max"
        '
        'LblClassMax
        '
        Me.LblClassMax.AutoSize = True
        Me.LblClassMax.Location = New System.Drawing.Point(147, 120)
        Me.LblClassMax.Name = "LblClassMax"
        Me.LblClassMax.Size = New System.Drawing.Size(67, 13)
        Me.LblClassMax.TabIndex = 308
        Me.LblClassMax.Text = "<Class Max>"
        '
        'LblClassMin
        '
        Me.LblClassMin.AutoSize = True
        Me.LblClassMin.Location = New System.Drawing.Point(147, 107)
        Me.LblClassMin.Name = "LblClassMin"
        Me.LblClassMin.Size = New System.Drawing.Size(64, 13)
        Me.LblClassMin.TabIndex = 307
        Me.LblClassMin.Text = "<Class Min>"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(77, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 306
        Me.Label5.Text = "Class Min"
        '
        'LblSubType
        '
        Me.LblSubType.AutoSize = True
        Me.LblSubType.Location = New System.Drawing.Point(147, 94)
        Me.LblSubType.Name = "LblSubType"
        Me.LblSubType.Size = New System.Drawing.Size(62, 13)
        Me.LblSubType.TabIndex = 305
        Me.LblSubType.Text = "<SubType>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 304
        Me.Label3.Text = "SubType"
        '
        'LblClassification
        '
        Me.LblClassification.AutoSize = True
        Me.LblClassification.Location = New System.Drawing.Point(147, 81)
        Me.LblClassification.Name = "LblClassification"
        Me.LblClassification.Size = New System.Drawing.Size(80, 13)
        Me.LblClassification.TabIndex = 303
        Me.LblClassification.Text = "<Classification>"
        '
        'LblClassificationHdr
        '
        Me.LblClassificationHdr.AutoSize = True
        Me.LblClassificationHdr.Location = New System.Drawing.Point(77, 81)
        Me.LblClassificationHdr.Name = "LblClassificationHdr"
        Me.LblClassificationHdr.Size = New System.Drawing.Size(68, 13)
        Me.LblClassificationHdr.TabIndex = 302
        Me.LblClassificationHdr.Text = "Classification"
        '
        'LblCatName
        '
        Me.LblCatName.AutoSize = True
        Me.LblCatName.Location = New System.Drawing.Point(147, 68)
        Me.LblCatName.Name = "LblCatName"
        Me.LblCatName.Size = New System.Drawing.Size(61, 13)
        Me.LblCatName.TabIndex = 301
        Me.LblCatName.Text = "<Category>"
        '
        'LblCatNameHdr
        '
        Me.LblCatNameHdr.AutoSize = True
        Me.LblCatNameHdr.Location = New System.Drawing.Point(77, 68)
        Me.LblCatNameHdr.Name = "LblCatNameHdr"
        Me.LblCatNameHdr.Size = New System.Drawing.Size(52, 13)
        Me.LblCatNameHdr.TabIndex = 300
        Me.LblCatNameHdr.Text = "Category "
        '
        'LblMfgName
        '
        Me.LblMfgName.AutoSize = True
        Me.LblMfgName.Location = New System.Drawing.Point(147, 55)
        Me.LblMfgName.Name = "LblMfgName"
        Me.LblMfgName.Size = New System.Drawing.Size(68, 13)
        Me.LblMfgName.TabIndex = 299
        Me.LblMfgName.Text = "<Mfg Name>"
        '
        'LblMfgNameHdr
        '
        Me.LblMfgNameHdr.AutoSize = True
        Me.LblMfgNameHdr.Location = New System.Drawing.Point(77, 55)
        Me.LblMfgNameHdr.Name = "LblMfgNameHdr"
        Me.LblMfgNameHdr.Size = New System.Drawing.Size(64, 13)
        Me.LblMfgNameHdr.TabIndex = 298
        Me.LblMfgNameHdr.Text = "Manfacturer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 315
        Me.Label2.Text = "Retail"
        '
        'LblMSRP
        '
        Me.LblMSRP.AutoSize = True
        Me.LblMSRP.Location = New System.Drawing.Point(147, 183)
        Me.LblMSRP.Name = "LblMSRP"
        Me.LblMSRP.Size = New System.Drawing.Size(50, 13)
        Me.LblMSRP.TabIndex = 316
        Me.LblMSRP.Text = "<MSRP>"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(77, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "MSRP"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(77, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 318
        Me.Label7.Text = "Complete"
        '
        'LblComplete
        '
        Me.LblComplete.AutoSize = True
        Me.LblComplete.Location = New System.Drawing.Point(147, 196)
        Me.LblComplete.Name = "LblComplete"
        Me.LblComplete.Size = New System.Drawing.Size(63, 13)
        Me.LblComplete.TabIndex = 319
        Me.LblComplete.Text = "<Complete>"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 221)
        Me.Controls.Add(Me.LblComplete)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblMSRP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblTradeIn)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.LblWholesale)
        Me.Controls.Add(Me.LblRetail)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblClassMax)
        Me.Controls.Add(Me.LblClassMin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblSubType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblClassification)
        Me.Controls.Add(Me.LblClassificationHdr)
        Me.Controls.Add(Me.LblCatName)
        Me.Controls.Add(Me.LblCatNameHdr)
        Me.Controls.Add(Me.LblMfgName)
        Me.Controls.Add(Me.LblMfgNameHdr)
        Me.Controls.Add(Me.TxtVIN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCheck)
        Me.Name = "Form1"
        Me.Text = "Price Digest API Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCheck As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtVIN As TextBox
    Friend WithEvents LblTradeIn As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents LblWholesale As Label
    Friend WithEvents LblRetail As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblClassMax As Label
    Friend WithEvents LblClassMin As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblSubType As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblClassification As Label
    Friend WithEvents LblClassificationHdr As Label
    Friend WithEvents LblCatName As Label
    Friend WithEvents LblCatNameHdr As Label
    Friend WithEvents LblMfgName As Label
    Friend WithEvents LblMfgNameHdr As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblMSRP As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblComplete As Label
End Class
