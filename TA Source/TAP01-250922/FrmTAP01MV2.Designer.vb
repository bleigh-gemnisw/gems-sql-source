<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01MV2
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
    Me.LblYear = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtVYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtLength = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtWeight = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtPurvl = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtMSRP = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.DtPckPurDt = New System.Windows.Forms.DateTimePicker()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnPriceDigest = New System.Windows.Forms.Button()
        Me.LblNoData = New System.Windows.Forms.Label()
        Me.TxtValue = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblYear
        '
        Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.Location = New System.Drawing.Point(191, 8)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(33, 18)
        Me.LblYear.TabIndex = 211
        Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblListNo
        '
        Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblListNo.Location = New System.Drawing.Point(69, 8)
        Me.LblListNo.Name = "LblListNo"
        Me.LblListNo.Size = New System.Drawing.Size(62, 18)
        Me.LblListNo.TabIndex = 210
        Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(12, 9)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 17)
        Me.Label30.TabIndex = 213
        Me.Label30.Text = "List No"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(154, 9)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(35, 17)
        Me.Label29.TabIndex = 212
        Me.Label29.Text = "Year"
        '
        'TxtVYear
        '
        Me.TxtVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVYear.Location = New System.Drawing.Point(8, 59)
        Me.TxtVYear.MaxLength = 4
        Me.TxtVYear.Name = "TxtVYear"
        Me.TxtVYear.Size = New System.Drawing.Size(38, 20)
        Me.TxtVYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Year"
        '
        'TxtMake
        '
        Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMake.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMake.Location = New System.Drawing.Point(52, 59)
        Me.TxtMake.MaxLength = 5
        Me.TxtMake.Name = "TxtMake"
        Me.TxtMake.Size = New System.Drawing.Size(58, 20)
        Me.TxtMake.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "Make"
        '
        'TxtModel
        '
        Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModel.Location = New System.Drawing.Point(116, 59)
        Me.TxtModel.MaxLength = 8
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(61, 20)
        Me.TxtModel.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(122, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 219
        Me.Label3.Text = "Model"
        '
        'TxtVIN
        '
        Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVIN.Location = New System.Drawing.Point(183, 59)
        Me.TxtVIN.MaxLength = 17
        Me.TxtVIN.Name = "TxtVIN"
        Me.TxtVIN.Size = New System.Drawing.Size(137, 20)
        Me.TxtVIN.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "Identification Number"
        '
        'TxtLength
        '
        Me.TxtLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLength.Location = New System.Drawing.Point(327, 59)
        Me.TxtLength.MaxLength = 3
        Me.TxtLength.Name = "TxtLength"
        Me.TxtLength.Size = New System.Drawing.Size(28, 20)
        Me.TxtLength.TabIndex = 4
        Me.TxtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 223
        Me.Label5.Text = "Length"
        '
        'TxtWeight
        '
        Me.TxtWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWeight.Location = New System.Drawing.Point(383, 59)
        Me.TxtWeight.MaxLength = 6
        Me.TxtWeight.Name = "TxtWeight"
        Me.TxtWeight.Size = New System.Drawing.Size(50, 20)
        Me.TxtWeight.TabIndex = 5
        Me.TxtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(381, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Weight"
        '
        'TxtPurvl
        '
        Me.TxtPurvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPurvl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurvl.Location = New System.Drawing.Point(442, 59)
        Me.TxtPurvl.MaxLength = 9
        Me.TxtPurvl.Name = "TxtPurvl"
        Me.TxtPurvl.Size = New System.Drawing.Size(70, 20)
        Me.TxtPurvl.TabIndex = 6
        Me.TxtPurvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(451, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "Purchase $"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(528, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 229
        Me.Label8.Text = "Date"
        '
        'TxtMSRP
        '
        Me.TxtMSRP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMSRP.Location = New System.Drawing.Point(702, 59)
        Me.TxtMSRP.MaxLength = 9
        Me.TxtMSRP.Name = "TxtMSRP"
        Me.TxtMSRP.Size = New System.Drawing.Size(73, 20)
        Me.TxtMSRP.TabIndex = 9
        Me.TxtMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(641, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 231
        Me.Label9.Text = "Value"
        '
        'DtPckPurDt
        '
        Me.DtPckPurDt.Checked = False
        Me.DtPckPurDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPurDt.Location = New System.Drawing.Point(518, 59)
        Me.DtPckPurDt.Name = "DtPckPurDt"
        Me.DtPckPurDt.ShowCheckBox = True
        Me.DtPckPurDt.Size = New System.Drawing.Size(97, 20)
        Me.DtPckPurDt.TabIndex = 7
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(718, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 234
        Me.Label11.Text = "MSRP"
        '
        'BtnPriceDigest
        '
        Me.BtnPriceDigest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPriceDigest.Location = New System.Drawing.Point(702, 5)
        Me.BtnPriceDigest.Name = "BtnPriceDigest"
        Me.BtnPriceDigest.Size = New System.Drawing.Size(74, 24)
        Me.BtnPriceDigest.TabIndex = 280
        Me.BtnPriceDigest.Text = "Price Digest"
        '
        'LblNoData
        '
        Me.LblNoData.AutoSize = True
        Me.LblNoData.Location = New System.Drawing.Point(627, 11)
        Me.LblNoData.Name = "LblNoData"
        Me.LblNoData.Size = New System.Drawing.Size(69, 13)
        Me.LblNoData.TabIndex = 281
        Me.LblNoData.Text = "** No Data **"
        '
        'TxtValue
        '
        Me.TxtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValue.Location = New System.Drawing.Point(623, 59)
        Me.TxtValue.MaxLength = 9
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.Size = New System.Drawing.Size(73, 20)
        Me.TxtValue.TabIndex = 8
        Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(681, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "- OR -"
        '
        'FrmTAP01MV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 87)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtValue)
        Me.Controls.Add(Me.LblNoData)
        Me.Controls.Add(Me.BtnPriceDigest)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DtPckPurDt)
        Me.Controls.Add(Me.TxtMSRP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtPurvl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtWeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtLength)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtVIN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtModel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtMake)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtVYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTAP01MV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain MV"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxtVYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMake As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtModel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtLength As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPurvl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtMSRP As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtPckPurDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnPriceDigest As Button
    Friend WithEvents LblNoData As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtValue As TextBox
End Class






