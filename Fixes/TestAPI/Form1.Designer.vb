<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.BtnCheck = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtAcctID = New System.Windows.Forms.TextBox()
    Me.LblAmount = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblAddr = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTownNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnCheck
        '
        Me.BtnCheck.Location = New System.Drawing.Point(194, 45)
        Me.BtnCheck.Name = "BtnCheck"
        Me.BtnCheck.Size = New System.Drawing.Size(107, 20)
        Me.BtnCheck.TabIndex = 0
        Me.BtnCheck.Text = "Check Account"
        Me.BtnCheck.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "AcctID"
        '
        'TxtAcctID
        '
        Me.TxtAcctID.Location = New System.Drawing.Point(96, 45)
        Me.TxtAcctID.Name = "TxtAcctID"
        Me.TxtAcctID.Size = New System.Drawing.Size(92, 20)
        Me.TxtAcctID.TabIndex = 2
        '
        'LblAmount
        '
        Me.LblAmount.AutoSize = True
        Me.LblAmount.Location = New System.Drawing.Point(93, 77)
        Me.LblAmount.Name = "LblAmount"
        Me.LblAmount.Size = New System.Drawing.Size(55, 13)
        Me.LblAmount.TabIndex = 3
        Me.LblAmount.Text = "<Amount>"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Location = New System.Drawing.Point(93, 100)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(47, 13)
        Me.LblName.TabIndex = 4
        Me.LblName.Text = "<Name>"
        '
        'LblAddr
        '
        Me.LblAddr.AutoSize = True
        Me.LblAddr.Location = New System.Drawing.Point(93, 122)
        Me.LblAddr.Name = "LblAddr"
        Me.LblAddr.Size = New System.Drawing.Size(57, 13)
        Me.LblAddr.TabIndex = 5
        Me.LblAddr.Text = "<Address>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Town No"
        '
        'TxtTownNo
        '
        Me.TxtTownNo.Location = New System.Drawing.Point(96, 19)
        Me.TxtTownNo.Name = "TxtTownNo"
        Me.TxtTownNo.Size = New System.Drawing.Size(30, 20)
        Me.TxtTownNo.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "(3 digits)"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 183)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTownNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblAddr)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblAmount)
        Me.Controls.Add(Me.TxtAcctID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCheck)
        Me.Name = "Form1"
        Me.Text = "Webpay API Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCheck As Button
  Friend WithEvents Label1 As Label
  Friend WithEvents TxtAcctID As TextBox
  Friend WithEvents LblAmount As Label
  Friend WithEvents LblName As Label
  Friend WithEvents LblAddr As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtTownNo As TextBox
    Friend WithEvents Label3 As Label
End Class
