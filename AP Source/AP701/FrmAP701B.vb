Public Class FrmAP701B
  Inherits System.Windows.Forms.Form
 Dim myAPCTRL As APCTRL.myData
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtFName As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents TxtFadd1 As System.Windows.Forms.TextBox
Friend WithEvents TxtFadd2 As System.Windows.Forms.TextBox
Friend WithEvents TxtFcity As System.Windows.Forms.TextBox
Friend WithEvents TxtFZip As System.Windows.Forms.TextBox
Friend WithEvents TxtFedid As System.Windows.Forms.TextBox
Friend WithEvents LblTownbr As System.Windows.Forms.Label
Friend WithEvents TxtSteid As System.Windows.Forms.TextBox
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents TxtFstate As System.Windows.Forms.TextBox
Friend WithEvents TxtYlim As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtCpst As System.Windows.Forms.TextBox
Friend WithEvents Label14 As System.Windows.Forms.Label
Friend WithEvents TxtTstind As System.Windows.Forms.TextBox
Friend WithEvents Label17 As System.Windows.Forms.Label
Friend WithEvents TxtLstfil As System.Windows.Forms.TextBox
Friend WithEvents Label16 As System.Windows.Forms.Label
Friend WithEvents TxtTCC As System.Windows.Forms.TextBox
Friend WithEvents Label15 As System.Windows.Forms.Label
Friend WithEvents TxtGldist As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtVndnx As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtCtel As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtCname As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtPtel As System.Windows.Forms.TextBox
Friend WithEvents Label18 As System.Windows.Forms.Label
Friend WithEvents TxtPcnam As System.Windows.Forms.TextBox
Friend WithEvents Label19 As System.Windows.Forms.Label
Friend WithEvents Label12 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.label3 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.TxtFName = New System.Windows.Forms.TextBox
Me.TxtFadd1 = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.TxtFadd2 = New System.Windows.Forms.TextBox
Me.Label4 = New System.Windows.Forms.Label
Me.TxtFcity = New System.Windows.Forms.TextBox
Me.Label5 = New System.Windows.Forms.Label
Me.TxtFZip = New System.Windows.Forms.TextBox
Me.TxtFedid = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.LblTownbr = New System.Windows.Forms.Label
Me.TxtSteid = New System.Windows.Forms.TextBox
Me.Label13 = New System.Windows.Forms.Label
Me.TxtFstate = New System.Windows.Forms.TextBox
Me.TxtYlim = New System.Windows.Forms.TextBox
Me.Label6 = New System.Windows.Forms.Label
Me.TxtCpst = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.TxtTCC = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.TxtLstfil = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.TxtTstind = New System.Windows.Forms.TextBox
Me.Label17 = New System.Windows.Forms.Label
Me.TxtGldist = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.TxtVndnx = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.TxtCname = New System.Windows.Forms.TextBox
Me.Label10 = New System.Windows.Forms.Label
Me.TxtCtel = New System.Windows.Forms.TextBox
Me.Label11 = New System.Windows.Forms.Label
Me.TxtPtel = New System.Windows.Forms.TextBox
Me.Label18 = New System.Windows.Forms.Label
Me.TxtPcnam = New System.Windows.Forms.TextBox
Me.Label19 = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'label3
'
Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label3.Location = New System.Drawing.Point(-100, 74)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(100, 23)
Me.label3.TabIndex = 6
Me.label3.Text = "New file name"
Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 81)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(100, 16)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Name"
'
'TxtFName
'
Me.TxtFName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFName.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFName.Location = New System.Drawing.Point(112, 77)
Me.TxtFName.MaxLength = 30
Me.TxtFName.Name = "TxtFName"
Me.TxtFName.Size = New System.Drawing.Size(248, 22)
Me.TxtFName.TabIndex = 2
'
'TxtFadd1
'
Me.TxtFadd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFadd1.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFadd1.Location = New System.Drawing.Point(112, 103)
Me.TxtFadd1.MaxLength = 30
Me.TxtFadd1.Name = "TxtFadd1"
Me.TxtFadd1.Size = New System.Drawing.Size(248, 22)
Me.TxtFadd1.TabIndex = 3
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(8, 107)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(100, 16)
Me.Label2.TabIndex = 9
Me.Label2.Text = "Address 1"
'
'TxtFadd2
'
Me.TxtFadd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFadd2.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFadd2.Location = New System.Drawing.Point(112, 128)
Me.TxtFadd2.MaxLength = 30
Me.TxtFadd2.Name = "TxtFadd2"
Me.TxtFadd2.Size = New System.Drawing.Size(248, 22)
Me.TxtFadd2.TabIndex = 4
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(8, 132)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(100, 16)
Me.Label4.TabIndex = 11
Me.Label4.Text = "Address 2"
'
'TxtFcity
'
Me.TxtFcity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFcity.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFcity.Location = New System.Drawing.Point(112, 154)
Me.TxtFcity.MaxLength = 20
Me.TxtFcity.Name = "TxtFcity"
Me.TxtFcity.Size = New System.Drawing.Size(204, 22)
Me.TxtFcity.TabIndex = 5
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(8, 158)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(100, 16)
Me.Label5.TabIndex = 13
Me.Label5.Text = "City/ST/Zip"
'
'TxtFZip
'
Me.TxtFZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFZip.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFZip.Location = New System.Drawing.Point(351, 154)
Me.TxtFZip.MaxLength = 9
Me.TxtFZip.Name = "TxtFZip"
Me.TxtFZip.Size = New System.Drawing.Size(90, 22)
Me.TxtFZip.TabIndex = 7
'
'TxtFedid
'
Me.TxtFedid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFedid.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFedid.Location = New System.Drawing.Point(112, 26)
Me.TxtFedid.MaxLength = 10
Me.TxtFedid.Name = "TxtFedid"
Me.TxtFedid.Size = New System.Drawing.Size(92, 22)
Me.TxtFedid.TabIndex = 0
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 30)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(100, 16)
Me.Label7.TabIndex = 17
Me.Label7.Text = "Federal ID"
'
'Label12
'
Me.Label12.Location = New System.Drawing.Point(8, 9)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(78, 14)
Me.Label12.TabIndex = 27
Me.Label12.Text = "Town Number"
'
'LblTownbr
'
Me.LblTownbr.Location = New System.Drawing.Point(112, 9)
Me.LblTownbr.Name = "LblTownbr"
Me.LblTownbr.Size = New System.Drawing.Size(38, 14)
Me.LblTownbr.TabIndex = 28
'
'TxtSteid
'
Me.TxtSteid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtSteid.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtSteid.Location = New System.Drawing.Point(112, 52)
Me.TxtSteid.MaxLength = 10
Me.TxtSteid.Name = "TxtSteid"
Me.TxtSteid.Size = New System.Drawing.Size(92, 22)
Me.TxtSteid.TabIndex = 1
'
'Label13
'
Me.Label13.Location = New System.Drawing.Point(8, 56)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(100, 16)
Me.Label13.TabIndex = 30
Me.Label13.Text = "State ID"
'
'TxtFstate
'
Me.TxtFstate.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFstate.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtFstate.Location = New System.Drawing.Point(322, 154)
Me.TxtFstate.MaxLength = 2
Me.TxtFstate.Name = "TxtFstate"
Me.TxtFstate.Size = New System.Drawing.Size(23, 22)
Me.TxtFstate.TabIndex = 6
'
'TxtYlim
'
Me.TxtYlim.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtYlim.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtYlim.Location = New System.Drawing.Point(112, 181)
Me.TxtYlim.MaxLength = 10
Me.TxtYlim.Name = "TxtYlim"
Me.TxtYlim.Size = New System.Drawing.Size(92, 22)
Me.TxtYlim.TabIndex = 8
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(8, 185)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(100, 16)
Me.Label6.TabIndex = 33
Me.Label6.Text = "Year Limit"
'
'TxtCpst
'
Me.TxtCpst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCpst.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCpst.Location = New System.Drawing.Point(112, 208)
Me.TxtCpst.MaxLength = 1
Me.TxtCpst.Name = "TxtCpst"
Me.TxtCpst.Size = New System.Drawing.Size(18, 22)
Me.TxtCpst.TabIndex = 9
'
'Label14
'
Me.Label14.Location = New System.Drawing.Point(8, 212)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(100, 16)
Me.Label14.TabIndex = 35
Me.Label14.Text = "Check Posted"
'
'TxtTCC
'
Me.TxtTCC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTCC.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtTCC.Location = New System.Drawing.Point(277, 208)
Me.TxtTCC.MaxLength = 5
Me.TxtTCC.Name = "TxtTCC"
Me.TxtTCC.Size = New System.Drawing.Size(50, 22)
Me.TxtTCC.TabIndex = 10
'
'Label15
'
Me.Label15.Location = New System.Drawing.Point(149, 214)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(122, 16)
Me.Label15.TabIndex = 37
Me.Label15.Text = "Transmitter Code TCC"
'
'TxtLstfil
'
Me.TxtLstfil.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtLstfil.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtLstfil.Location = New System.Drawing.Point(112, 234)
Me.TxtLstfil.MaxLength = 1
Me.TxtLstfil.Name = "TxtLstfil"
Me.TxtLstfil.Size = New System.Drawing.Size(18, 22)
Me.TxtLstfil.TabIndex = 11
'
'Label16
'
Me.Label16.Location = New System.Drawing.Point(8, 238)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(100, 16)
Me.Label16.TabIndex = 39
Me.Label16.Text = "Last Filing Ind"
'
'TxtTstind
'
Me.TxtTstind.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTstind.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtTstind.Location = New System.Drawing.Point(277, 234)
Me.TxtTstind.MaxLength = 1
Me.TxtTstind.Name = "TxtTstind"
Me.TxtTstind.Size = New System.Drawing.Size(18, 22)
Me.TxtTstind.TabIndex = 12
'
'Label17
'
Me.Label17.Location = New System.Drawing.Point(149, 238)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(100, 16)
Me.Label17.TabIndex = 41
Me.Label17.Text = "Test Ind 1099"
'
'TxtGldist
'
Me.TxtGldist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtGldist.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtGldist.Location = New System.Drawing.Point(112, 260)
Me.TxtGldist.MaxLength = 1
Me.TxtGldist.Name = "TxtGldist"
Me.TxtGldist.Size = New System.Drawing.Size(18, 22)
Me.TxtGldist.TabIndex = 13
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(8, 264)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(100, 16)
Me.Label8.TabIndex = 43
Me.Label8.Text = "Allocate G/L"
'
'TxtVndnx
'
Me.TxtVndnx.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtVndnx.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtVndnx.Location = New System.Drawing.Point(277, 260)
Me.TxtVndnx.MaxLength = 5
Me.TxtVndnx.Name = "TxtVndnx"
Me.TxtVndnx.Size = New System.Drawing.Size(50, 22)
Me.TxtVndnx.TabIndex = 14
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(149, 266)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(100, 16)
Me.Label9.TabIndex = 45
Me.Label9.Text = "Vendor Number"
'
'TxtCname
'
Me.TxtCname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCname.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCname.Location = New System.Drawing.Point(112, 286)
Me.TxtCname.MaxLength = 40
Me.TxtCname.Name = "TxtCname"
Me.TxtCname.Size = New System.Drawing.Size(329, 22)
Me.TxtCname.TabIndex = 15
'
'Label10
'
Me.Label10.Location = New System.Drawing.Point(8, 290)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(100, 16)
Me.Label10.TabIndex = 47
Me.Label10.Text = "Contact Name"
'
'TxtCtel
'
Me.TxtCtel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtCtel.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtCtel.Location = New System.Drawing.Point(112, 314)
Me.TxtCtel.MaxLength = 15
Me.TxtCtel.Name = "TxtCtel"
Me.TxtCtel.Size = New System.Drawing.Size(126, 22)
Me.TxtCtel.TabIndex = 16
'
'Label11
'
Me.Label11.Location = New System.Drawing.Point(8, 318)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(100, 16)
Me.Label11.TabIndex = 49
Me.Label11.Text = "Contact Tel#"
'
'TxtPtel
'
Me.TxtPtel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPtel.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtPtel.Location = New System.Drawing.Point(112, 342)
Me.TxtPtel.MaxLength = 15
Me.TxtPtel.Name = "TxtPtel"
Me.TxtPtel.Size = New System.Drawing.Size(126, 22)
Me.TxtPtel.TabIndex = 17
'
'Label18
'
Me.Label18.Location = New System.Drawing.Point(8, 346)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(100, 16)
Me.Label18.TabIndex = 51
Me.Label18.Text = "Payer Tel#"
'
'TxtPcnam
'
Me.TxtPcnam.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtPcnam.ImeMode = System.Windows.Forms.ImeMode.NoControl
Me.TxtPcnam.Location = New System.Drawing.Point(366, 342)
Me.TxtPcnam.MaxLength = 15
Me.TxtPcnam.Name = "TxtPcnam"
Me.TxtPcnam.Size = New System.Drawing.Size(41, 22)
Me.TxtPcnam.TabIndex = 18
'
'Label19
'
Me.Label19.Location = New System.Drawing.Point(247, 344)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(113, 18)
Me.Label19.TabIndex = 53
Me.Label19.Text = "Payer Name Control" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
'
'FrmAP701B
'
Me.AllowDrop = True
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(455, 376)
Me.ControlBox = False
Me.Controls.Add(Me.TxtPcnam)
Me.Controls.Add(Me.Label19)
Me.Controls.Add(Me.TxtPtel)
Me.Controls.Add(Me.Label18)
Me.Controls.Add(Me.TxtCtel)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.TxtCname)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.TxtVndnx)
Me.Controls.Add(Me.Label9)
Me.Controls.Add(Me.TxtGldist)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.TxtTstind)
Me.Controls.Add(Me.Label17)
Me.Controls.Add(Me.TxtLstfil)
Me.Controls.Add(Me.Label16)
Me.Controls.Add(Me.TxtTCC)
Me.Controls.Add(Me.Label15)
Me.Controls.Add(Me.TxtCpst)
Me.Controls.Add(Me.Label14)
Me.Controls.Add(Me.TxtYlim)
Me.Controls.Add(Me.Label6)
Me.Controls.Add(Me.TxtFstate)
Me.Controls.Add(Me.TxtSteid)
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.LblTownbr)
Me.Controls.Add(Me.Label12)
Me.Controls.Add(Me.TxtFedid)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.TxtFZip)
Me.Controls.Add(Me.TxtFcity)
Me.Controls.Add(Me.TxtFadd2)
Me.Controls.Add(Me.TxtFadd1)
Me.Controls.Add(Me.TxtFName)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.label3)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmAP701B"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

  Private Sub AP701B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myAPCTRL = New APCTRL.MyData(myDBConnect)
    With MyFrmAP701
      .TBarNew.Visible = False
      .TBarSave.Visible = True
      .TBarPrint.Visible = False
      .TBarDelete.Visible = False
    End With
    If s_chg = False And s_full = False Then    '#sec
      MyFrmAP701.TBarSave.Visible = False
    End If

    myAPCTRL.GetOneRecordP(1)
    If myAPCTRL.RecordNotFound Then
      LblTownbr.Text = myTOWN._TOWNBR
      Exit Sub
    End If
    With myAPCTRL
      LblTownbr.Text = ._TNBR
      TxtCname.Text = Trim(._CNAME)
      TxtCpst.Text = Trim(._CPST)
      TxtCtel.Text = Trim(._CTEL)
      TxtFadd1.Text = Trim(._FADD1)
      TxtFadd2.Text = Trim(._FADD2)
      TxtFcity.Text = Trim(._FCITY)
      TxtFedid.Text = ._FEDID
      TxtFName.Text = Trim(._FNAME)
      TxtFstate.Text = Trim(._FSTATE)
      If ._FZIP > 99999 Then
        TxtFZip.Text = Format(._FZIP, "000000000")
      Else
        TxtFZip.Text = Format(._FZIP, "000000")
      End If
      TxtGldist.Text = Trim(._GLDIST)
      TxtLstfil.Text = Trim(._LSTFIL)
      TxtPcnam.Text = Trim(._PCNAM)
      TxtPtel.Text = Trim(._PTEL)
      TxtSteid.Text = ._STEID
      TxtTCC.Text = Trim(._TCC)
      TxtTstind.Text = Trim(._TSTIND)
      TxtVndnx.Text = Trim(._VNDNX)
      TxtYlim.Text = ._YLIM
    End With
  End Sub
  Private Sub AP701B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmAP701.SbpScreen.Text = "AP701B"
 MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Public Sub SaveData()
 Dim ErrorField(25) As String
 Dim ErrorMsg(25) As String
 myAPCTRL.GetOneRecordP(1)
 MovetoFile()
 EditChecks(ErrorField, ErrorMsg)
 If IsNothing(ErrorMsg(0)) Then
  If myAPCTRL.RecordNotFound Then
   myAPCTRL.AddOneRecordP()
  Else
   myAPCTRL.UpdateOneRecordP()
  End If
 Else
  ShowError(ErrorField, ErrorMsg)
  Exit Sub
 End If
  Application.Exit()
  End Sub
Private Sub MovetoFile()
 With myAPCTRL
  ._TNBR = MyUtils.CnvSng(LblTownbr.Text)
  ._CNAME = TxtCname.Text
  ._CPST = TxtCpst.Text
  ._CTEL = TxtCtel.Text
  ._FADD1 = TxtFadd1.Text
  ._FADD2 = TxtFadd2.Text
  ._FCITY = TxtFcity.Text
  ._FEDID = MyUtils.CnvSng(TxtFedid.Text)
  ._FNAME = TxtFName.Text
  ._FSTATE = TxtFstate.Text
  ._FZIP = MyUtils.CnvSng(TxtFZip.Text)
  ._GLDIST = TxtGldist.Text
  ._LSTFIL = TxtLstfil.Text
  ._PCNAM = TxtPcnam.Text
  ._PTEL = TxtPtel.Text
  ._STEID = MyUtils.CnvSng(TxtSteid.Text)
  ._TCC = TxtTCC.Text
  ._TSTIND = TxtTstind.Text
  ._VNDNX = TxtVndnx.Text
  ._YLIM = MyUtils.CnvSng(TxtYlim.Text)
 End With
End Sub
 Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer

  For I = 0 To ErrorField.GetUpperBound(0)
   If IsNothing(ErrorField(I)) Then
    Exit For
   End If
  Next


  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub TxtFedid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFedid.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtSteid_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSteid.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYlim_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYlim.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class
