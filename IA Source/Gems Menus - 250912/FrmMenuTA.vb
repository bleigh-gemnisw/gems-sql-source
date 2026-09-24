Public Class FrmMenuTA
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents tab As System.Windows.Forms.TabControl
  Friend WithEvents tabdaily As System.Windows.Forms.TabPage
  Friend WithEvents label1 As System.Windows.Forms.Label
  Friend WithEvents btnTA001 As System.Windows.Forms.Button
  Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents btnTA811 As System.Windows.Forms.Button
  Friend WithEvents btnTA810 As System.Windows.Forms.Button
  Friend WithEvents btnta801 As System.Windows.Forms.Button
  Friend WithEvents label4 As System.Windows.Forms.Label
  Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents btnta110 As System.Windows.Forms.Button
  Friend WithEvents btnta109 As System.Windows.Forms.Button
  Friend WithEvents btnta108 As System.Windows.Forms.Button
  Friend WithEvents btnta107 As System.Windows.Forms.Button
  Friend WithEvents btnta106 As System.Windows.Forms.Button
  Friend WithEvents btnta105 As System.Windows.Forms.Button
  Friend WithEvents btnta104 As System.Windows.Forms.Button
  Friend WithEvents label3 As System.Windows.Forms.Label
  Friend WithEvents tabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents label5 As System.Windows.Forms.Label
  Friend WithEvents tabControl2 As System.Windows.Forms.TabControl
  Friend WithEvents tabListings As System.Windows.Forms.TabPage
  Friend WithEvents label11 As System.Windows.Forms.Label
  Friend WithEvents tabNotices As System.Windows.Forms.TabPage
  Friend WithEvents label12 As System.Windows.Forms.Label
  Friend WithEvents tabOPM As System.Windows.Forms.TabPage
  Friend WithEvents label13 As System.Windows.Forms.Label
  Friend WithEvents tabPage6 As System.Windows.Forms.TabPage
  Friend WithEvents label7 As System.Windows.Forms.Label
  Friend WithEvents tabPage8 As System.Windows.Forms.TabPage
  Friend WithEvents label8 As System.Windows.Forms.Label
  Friend WithEvents tabfilemaintenance As System.Windows.Forms.TabPage
  Friend WithEvents btntac01 As System.Windows.Forms.Button
  Friend WithEvents label2 As System.Windows.Forms.Label
  Friend WithEvents tabPage11 As System.Windows.Forms.TabPage
  Friend WithEvents BtnTAE02 As System.Windows.Forms.Button
  Friend WithEvents BtnTAE01 As System.Windows.Forms.Button
  Friend WithEvents label9 As System.Windows.Forms.Label
  Friend WithEvents imagelist_ta As System.Windows.Forms.ImageList
  Friend WithEvents BtnTA103 As System.Windows.Forms.Button
  Friend WithEvents BtnTA102 As System.Windows.Forms.Button
  Friend WithEvents BtnTA101 As System.Windows.Forms.Button
  Friend WithEvents BtnTA904 As System.Windows.Forms.Button
  Friend WithEvents BtnTA901 As System.Windows.Forms.Button
  Friend WithEvents BtnTA902 As System.Windows.Forms.Button
  Friend WithEvents BtnTA903 As System.Windows.Forms.Button
  Friend WithEvents btntaa01 As System.Windows.Forms.Button
  Friend WithEvents btntab02 As System.Windows.Forms.Button
  Friend WithEvents btnta215 As System.Windows.Forms.Button
  Friend WithEvents btntab03 As System.Windows.Forms.Button
  Friend WithEvents btnta203 As System.Windows.Forms.Button
  Friend WithEvents btnta226 As System.Windows.Forms.Button
  Friend WithEvents btnta212 As System.Windows.Forms.Button
  Friend WithEvents btnta213 As System.Windows.Forms.Button
  Friend WithEvents btnta314 As System.Windows.Forms.Button
  Friend WithEvents btnta204 As System.Windows.Forms.Button
  Friend WithEvents btnta205 As System.Windows.Forms.Button
  Friend WithEvents btntab01 As System.Windows.Forms.Button
  Friend WithEvents btnta216 As System.Windows.Forms.Button
  Friend WithEvents btnta207 As System.Windows.Forms.Button
  Friend WithEvents BtnTA209 As System.Windows.Forms.Button
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPgMain As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA222 As System.Windows.Forms.Button
  Friend WithEvents btnta220 As System.Windows.Forms.Button
  Friend WithEvents btntad01 As System.Windows.Forms.Button
  Friend WithEvents btntad02 As System.Windows.Forms.Button
  Friend WithEvents TabpgMV As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA402 As System.Windows.Forms.Button
  Friend WithEvents TabPgSuppl As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA403 As System.Windows.Forms.Button
  Friend WithEvents BtnTA421 As System.Windows.Forms.Button
  Friend WithEvents BtnTA420 As System.Windows.Forms.Button
  Friend WithEvents BtnTA406 As System.Windows.Forms.Button
  Friend WithEvents BtnTA404 As System.Windows.Forms.Button
  Friend WithEvents BtnTA523 As System.Windows.Forms.Button
  Friend WithEvents BtnTA509 As System.Windows.Forms.Button
  Friend WithEvents BtnTA519 As System.Windows.Forms.Button
  Friend WithEvents BtnTA506 As System.Windows.Forms.Button
  Friend WithEvents BtnTA504 As System.Windows.Forms.Button
  Friend WithEvents BtnTA503 As System.Windows.Forms.Button
  Friend WithEvents BtnTA502 As System.Windows.Forms.Button
  Friend WithEvents BtnTA518 As System.Windows.Forms.Button
  Friend WithEvents BtnTA520 As System.Windows.Forms.Button
  Friend WithEvents TabMV As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA4076 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4075 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4074 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4073 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4072 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4071 As System.Windows.Forms.Button
  Friend WithEvents BtnTA4077 As System.Windows.Forms.Button
  Friend WithEvents BtnTA414 As System.Windows.Forms.Button
  Friend WithEvents BtnTA408 As System.Windows.Forms.Button
  Friend WithEvents TabSuppl As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA5076 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5075 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5074 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5073 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5072 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5071 As System.Windows.Forms.Button
  Friend WithEvents BtnTA514 As System.Windows.Forms.Button
  Friend WithEvents BtnTA513 As System.Windows.Forms.Button
  Friend WithEvents btnta206 As System.Windows.Forms.Button
  Friend WithEvents TabPgRE As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA202 As System.Windows.Forms.Button
  Friend WithEvents btnta219 As System.Windows.Forms.Button
  Friend WithEvents btnta208 As System.Windows.Forms.Button
  Friend WithEvents BtnTA221 As System.Windows.Forms.Button
  Friend WithEvents TabPgPP As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA304 As System.Windows.Forms.Button
  Friend WithEvents BtnTA413 As System.Windows.Forms.Button
  Friend WithEvents TabPP As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA316 As System.Windows.Forms.Button
  Friend WithEvents BtnTA230 As System.Windows.Forms.Button
  Friend WithEvents BtnTA217 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5077 As System.Windows.Forms.Button
  Friend WithEvents BtnTA430 As System.Windows.Forms.Button
  Friend WithEvents BtnTA530 As System.Windows.Forms.Button
  Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
  Friend WithEvents BtnTO201 As System.Windows.Forms.Button
  Friend WithEvents BtnTO200 As System.Windows.Forms.Button
  Friend WithEvents BtnTO202 As System.Windows.Forms.Button
  Friend WithEvents BtnTO203 As System.Windows.Forms.Button
  Friend WithEvents BtnTO204 As System.Windows.Forms.Button
  Friend WithEvents BtnTA111 As System.Windows.Forms.Button
  Friend WithEvents BtnTO205 As System.Windows.Forms.Button
  Friend WithEvents BtnTA940 As System.Windows.Forms.Button
  Friend WithEvents TabPage20 As System.Windows.Forms.TabPage
  Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
  Friend WithEvents BtnTAP01 As System.Windows.Forms.Button
  Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
  Friend WithEvents BtnTAP02 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP03 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP16 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP15 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP14 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP13 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP12 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP11 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP10 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP20 As System.Windows.Forms.Button
  Friend WithEvents BtnTA521 As System.Windows.Forms.Button
  Friend WithEvents BtnTA130 As System.Windows.Forms.Button
  Friend WithEvents BtnTA431 As System.Windows.Forms.Button
  Friend WithEvents BtnTA531 As System.Windows.Forms.Button
  Friend WithEvents TabPhaseIn As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA232 As System.Windows.Forms.Button
  Friend WithEvents BtnTA233 As System.Windows.Forms.Button
  Friend WithEvents btnto116 As System.Windows.Forms.Button
  Friend WithEvents BtnTO120 As System.Windows.Forms.Button
  Friend WithEvents btnto114 As System.Windows.Forms.Button
  Friend WithEvents btnto113 As System.Windows.Forms.Button
  Friend WithEvents btnto112 As System.Windows.Forms.Button
  Friend WithEvents btnto111 As System.Windows.Forms.Button
  Friend WithEvents btnto105 As System.Windows.Forms.Button
  Friend WithEvents btnto104 As System.Windows.Forms.Button
  Friend WithEvents btnto103 As System.Windows.Forms.Button
  Friend WithEvents btnto109 As System.Windows.Forms.Button
  Friend WithEvents btnto106 As System.Windows.Forms.Button
  Friend WithEvents btnto102 As System.Windows.Forms.Button
  Friend WithEvents btnto101 As System.Windows.Forms.Button
  Friend WithEvents BtnTA234 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP21 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP17 As System.Windows.Forms.Button
  Friend WithEvents BtnTA941 As System.Windows.Forms.Button
  Friend WithEvents BtnTA131 As System.Windows.Forms.Button
  Friend WithEvents BtnTA132 As System.Windows.Forms.Button
  Friend WithEvents BtnTA235 As System.Windows.Forms.Button
  Friend WithEvents BtnTA133 As System.Windows.Forms.Button
  Friend WithEvents BtnTA236 As System.Windows.Forms.Button
  Friend WithEvents tabchglog As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA330 As System.Windows.Forms.Button
  Friend WithEvents BtnTA5078 As System.Windows.Forms.Button
  Friend WithEvents TabCustom As System.Windows.Forms.TabPage
  Friend WithEvents BtnTA600 As System.Windows.Forms.Button
  Friend WithEvents BtnTA331 As System.Windows.Forms.Button
  Friend WithEvents BtnTA134 As System.Windows.Forms.Button
  Friend WithEvents BtnTA135 As System.Windows.Forms.Button
  Friend WithEvents BtnTO301 As System.Windows.Forms.Button
  Friend WithEvents BtnTO300 As System.Windows.Forms.Button
  Friend WithEvents BtnTA231 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP22 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP23 As System.Windows.Forms.Button
  Friend WithEvents BtnTA524 As System.Windows.Forms.Button
  Friend WithEvents BtnTA237 As System.Windows.Forms.Button
  Friend WithEvents BtnTO207 As System.Windows.Forms.Button
  Friend WithEvents BtnTA136 As System.Windows.Forms.Button
  Friend WithEvents BtnTAP24 As System.Windows.Forms.Button
  Friend WithEvents btntad03 As System.Windows.Forms.Button
  Friend WithEvents btnto107 As System.Windows.Forms.Button
  Friend WithEvents TabArchive As System.Windows.Forms.TabPage
  Friend WithEvents BtnTAD05 As System.Windows.Forms.Button
  Friend WithEvents BtnTAD04 As System.Windows.Forms.Button
  Friend WithEvents BtnTA137 As System.Windows.Forms.Button
  Friend WithEvents BtnTO208 As System.Windows.Forms.Button
  Friend WithEvents BtnTA238 As System.Windows.Forms.Button
  Friend WithEvents BtnTA138 As System.Windows.Forms.Button
  Friend WithEvents btnto110 As System.Windows.Forms.Button
  Friend WithEvents BtnTAB04 As Button
  Friend WithEvents BtnTA525 As Button
  Friend WithEvents Label6 As Label
  Friend WithEvents BtnTAP25 As Button
  Friend WithEvents BtnTA601 As Button
  Friend WithEvents BtnTAP26 As Button
  Friend WithEvents BtnTAP27 As Button
  Friend WithEvents BtnTA139 As Button
  Friend WithEvents BtnTAD06 As Button
  Friend WithEvents BtnTAP28 As Button
  Friend WithEvents BtnTAP29 As Button
  Friend WithEvents BtnTO121 As Button
  Friend WithEvents BtnTA141 As Button
  Friend WithEvents BtnTA140 As Button
  Friend WithEvents BtnTA432 As Button
  Friend WithEvents TabPage10 As TabPage
  Friend WithEvents BtnTAP30 As Button
  Friend WithEvents BtnTO221 As Button
  Friend WithEvents BtnTO220 As Button
  Friend WithEvents BtnTA440 As Button
  Friend WithEvents BtnTA540 As Button
  Friend WithEvents btnta218 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuTA))
    Me.tab = New System.Windows.Forms.TabControl()
    Me.tabdaily = New System.Windows.Forms.TabPage()
    Me.label1 = New System.Windows.Forms.Label()
    Me.btntaa01 = New System.Windows.Forms.Button()
    Me.btnTA001 = New System.Windows.Forms.Button()
    Me.tabPage2 = New System.Windows.Forms.TabPage()
    Me.btnTA811 = New System.Windows.Forms.Button()
    Me.btnTA810 = New System.Windows.Forms.Button()
    Me.btnta801 = New System.Windows.Forms.Button()
    Me.label4 = New System.Windows.Forms.Label()
    Me.tabPage1 = New System.Windows.Forms.TabPage()
    Me.BtnTA141 = New System.Windows.Forms.Button()
    Me.BtnTA140 = New System.Windows.Forms.Button()
    Me.BtnTA139 = New System.Windows.Forms.Button()
    Me.BtnTA138 = New System.Windows.Forms.Button()
    Me.BtnTA137 = New System.Windows.Forms.Button()
    Me.BtnTA136 = New System.Windows.Forms.Button()
    Me.BtnTA134 = New System.Windows.Forms.Button()
    Me.BtnTA135 = New System.Windows.Forms.Button()
    Me.BtnTA133 = New System.Windows.Forms.Button()
    Me.BtnTA132 = New System.Windows.Forms.Button()
    Me.BtnTA131 = New System.Windows.Forms.Button()
    Me.BtnTA130 = New System.Windows.Forms.Button()
    Me.BtnTA111 = New System.Windows.Forms.Button()
    Me.btnta110 = New System.Windows.Forms.Button()
    Me.btnta109 = New System.Windows.Forms.Button()
    Me.btnta108 = New System.Windows.Forms.Button()
    Me.btnta107 = New System.Windows.Forms.Button()
    Me.btnta106 = New System.Windows.Forms.Button()
    Me.btnta105 = New System.Windows.Forms.Button()
    Me.btnta104 = New System.Windows.Forms.Button()
    Me.BtnTA103 = New System.Windows.Forms.Button()
    Me.BtnTA102 = New System.Windows.Forms.Button()
    Me.BtnTA101 = New System.Windows.Forms.Button()
    Me.label3 = New System.Windows.Forms.Label()
    Me.tabPage3 = New System.Windows.Forms.TabPage()
    Me.label5 = New System.Windows.Forms.Label()
    Me.tabControl2 = New System.Windows.Forms.TabControl()
    Me.tabListings = New System.Windows.Forms.TabPage()
    Me.BtnTAB04 = New System.Windows.Forms.Button()
    Me.BtnTA237 = New System.Windows.Forms.Button()
    Me.BtnTA234 = New System.Windows.Forms.Button()
    Me.BtnTA217 = New System.Windows.Forms.Button()
    Me.BtnTA230 = New System.Windows.Forms.Button()
    Me.btnta219 = New System.Windows.Forms.Button()
    Me.btnta208 = New System.Windows.Forms.Button()
    Me.BtnTA209 = New System.Windows.Forms.Button()
    Me.btnta216 = New System.Windows.Forms.Button()
    Me.btnta207 = New System.Windows.Forms.Button()
    Me.btnta226 = New System.Windows.Forms.Button()
    Me.btnta203 = New System.Windows.Forms.Button()
    Me.btnta218 = New System.Windows.Forms.Button()
    Me.btnta215 = New System.Windows.Forms.Button()
    Me.label11 = New System.Windows.Forms.Label()
    Me.btntab03 = New System.Windows.Forms.Button()
    Me.btntab02 = New System.Windows.Forms.Button()
    Me.tabNotices = New System.Windows.Forms.TabPage()
    Me.BtnTA235 = New System.Windows.Forms.Button()
    Me.btnta206 = New System.Windows.Forms.Button()
    Me.btntab01 = New System.Windows.Forms.Button()
    Me.btnta205 = New System.Windows.Forms.Button()
    Me.btnta204 = New System.Windows.Forms.Button()
    Me.label12 = New System.Windows.Forms.Label()
    Me.btnta314 = New System.Windows.Forms.Button()
    Me.btnta213 = New System.Windows.Forms.Button()
    Me.btnta212 = New System.Windows.Forms.Button()
    Me.tabOPM = New System.Windows.Forms.TabPage()
    Me.BtnTO121 = New System.Windows.Forms.Button()
    Me.btnto110 = New System.Windows.Forms.Button()
    Me.btnto107 = New System.Windows.Forms.Button()
    Me.btnto116 = New System.Windows.Forms.Button()
    Me.BtnTO120 = New System.Windows.Forms.Button()
    Me.btnto114 = New System.Windows.Forms.Button()
    Me.btnto113 = New System.Windows.Forms.Button()
    Me.btnto112 = New System.Windows.Forms.Button()
    Me.btnto111 = New System.Windows.Forms.Button()
    Me.btnto105 = New System.Windows.Forms.Button()
    Me.btnto104 = New System.Windows.Forms.Button()
    Me.btnto103 = New System.Windows.Forms.Button()
    Me.btnto109 = New System.Windows.Forms.Button()
    Me.btnto106 = New System.Windows.Forms.Button()
    Me.btnto102 = New System.Windows.Forms.Button()
    Me.btnto101 = New System.Windows.Forms.Button()
    Me.label13 = New System.Windows.Forms.Label()
    Me.TabPP = New System.Windows.Forms.TabPage()
    Me.BtnTA316 = New System.Windows.Forms.Button()
    Me.TabMV = New System.Windows.Forms.TabPage()
    Me.BtnTA430 = New System.Windows.Forms.Button()
    Me.BtnTA413 = New System.Windows.Forms.Button()
    Me.BtnTA414 = New System.Windows.Forms.Button()
    Me.BtnTA408 = New System.Windows.Forms.Button()
    Me.BtnTA4077 = New System.Windows.Forms.Button()
    Me.BtnTA4076 = New System.Windows.Forms.Button()
    Me.BtnTA4075 = New System.Windows.Forms.Button()
    Me.BtnTA4074 = New System.Windows.Forms.Button()
    Me.BtnTA4073 = New System.Windows.Forms.Button()
    Me.BtnTA4072 = New System.Windows.Forms.Button()
    Me.BtnTA4071 = New System.Windows.Forms.Button()
    Me.TabSuppl = New System.Windows.Forms.TabPage()
    Me.BtnTA525 = New System.Windows.Forms.Button()
    Me.BtnTA524 = New System.Windows.Forms.Button()
    Me.BtnTA5078 = New System.Windows.Forms.Button()
    Me.BtnTA521 = New System.Windows.Forms.Button()
    Me.BtnTA530 = New System.Windows.Forms.Button()
    Me.BtnTA5077 = New System.Windows.Forms.Button()
    Me.BtnTA514 = New System.Windows.Forms.Button()
    Me.BtnTA513 = New System.Windows.Forms.Button()
    Me.BtnTA5076 = New System.Windows.Forms.Button()
    Me.BtnTA5075 = New System.Windows.Forms.Button()
    Me.BtnTA5074 = New System.Windows.Forms.Button()
    Me.BtnTA5073 = New System.Windows.Forms.Button()
    Me.BtnTA5072 = New System.Windows.Forms.Button()
    Me.BtnTA5071 = New System.Windows.Forms.Button()
    Me.tabPage6 = New System.Windows.Forms.TabPage()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPgMain = New System.Windows.Forms.TabPage()
    Me.btntad03 = New System.Windows.Forms.Button()
    Me.BtnTO301 = New System.Windows.Forms.Button()
    Me.BtnTO300 = New System.Windows.Forms.Button()
    Me.BtnTA221 = New System.Windows.Forms.Button()
    Me.BtnTA222 = New System.Windows.Forms.Button()
    Me.btnta220 = New System.Windows.Forms.Button()
    Me.btntad01 = New System.Windows.Forms.Button()
    Me.btntad02 = New System.Windows.Forms.Button()
    Me.TabPgRE = New System.Windows.Forms.TabPage()
    Me.BtnTA238 = New System.Windows.Forms.Button()
    Me.BtnTA231 = New System.Windows.Forms.Button()
    Me.BtnTA236 = New System.Windows.Forms.Button()
    Me.BtnTA202 = New System.Windows.Forms.Button()
    Me.TabPgPP = New System.Windows.Forms.TabPage()
    Me.BtnTA304 = New System.Windows.Forms.Button()
    Me.TabpgMV = New System.Windows.Forms.TabPage()
    Me.BtnTA432 = New System.Windows.Forms.Button()
    Me.BtnTA431 = New System.Windows.Forms.Button()
    Me.BtnTA421 = New System.Windows.Forms.Button()
    Me.BtnTA420 = New System.Windows.Forms.Button()
    Me.BtnTA406 = New System.Windows.Forms.Button()
    Me.BtnTA404 = New System.Windows.Forms.Button()
    Me.BtnTA403 = New System.Windows.Forms.Button()
    Me.BtnTA402 = New System.Windows.Forms.Button()
    Me.TabPgSuppl = New System.Windows.Forms.TabPage()
    Me.BtnTA531 = New System.Windows.Forms.Button()
    Me.BtnTA520 = New System.Windows.Forms.Button()
    Me.BtnTA518 = New System.Windows.Forms.Button()
    Me.BtnTA523 = New System.Windows.Forms.Button()
    Me.BtnTA509 = New System.Windows.Forms.Button()
    Me.BtnTA519 = New System.Windows.Forms.Button()
    Me.BtnTA506 = New System.Windows.Forms.Button()
    Me.BtnTA504 = New System.Windows.Forms.Button()
    Me.BtnTA503 = New System.Windows.Forms.Button()
    Me.BtnTA502 = New System.Windows.Forms.Button()
    Me.label7 = New System.Windows.Forms.Label()
    Me.tabPage8 = New System.Windows.Forms.TabPage()
    Me.BtnTAP28 = New System.Windows.Forms.Button()
    Me.BtnTA941 = New System.Windows.Forms.Button()
    Me.BtnTA940 = New System.Windows.Forms.Button()
    Me.BtnTA904 = New System.Windows.Forms.Button()
    Me.BtnTA901 = New System.Windows.Forms.Button()
    Me.BtnTA902 = New System.Windows.Forms.Button()
    Me.BtnTA903 = New System.Windows.Forms.Button()
    Me.label8 = New System.Windows.Forms.Label()
    Me.tabfilemaintenance = New System.Windows.Forms.TabPage()
    Me.btntac01 = New System.Windows.Forms.Button()
    Me.label2 = New System.Windows.Forms.Label()
    Me.tabPage11 = New System.Windows.Forms.TabPage()
    Me.BtnTAE02 = New System.Windows.Forms.Button()
    Me.BtnTAE01 = New System.Windows.Forms.Button()
    Me.label9 = New System.Windows.Forms.Label()
    Me.TabPage4 = New System.Windows.Forms.TabPage()
    Me.BtnTO221 = New System.Windows.Forms.Button()
    Me.BtnTO220 = New System.Windows.Forms.Button()
    Me.BtnTAP29 = New System.Windows.Forms.Button()
    Me.BtnTO208 = New System.Windows.Forms.Button()
    Me.BtnTO207 = New System.Windows.Forms.Button()
    Me.BtnTO205 = New System.Windows.Forms.Button()
    Me.BtnTO204 = New System.Windows.Forms.Button()
    Me.BtnTO202 = New System.Windows.Forms.Button()
    Me.BtnTO203 = New System.Windows.Forms.Button()
    Me.BtnTO201 = New System.Windows.Forms.Button()
    Me.BtnTO200 = New System.Windows.Forms.Button()
    Me.TabPage20 = New System.Windows.Forms.TabPage()
    Me.TabControl3 = New System.Windows.Forms.TabControl()
    Me.TabPage5 = New System.Windows.Forms.TabPage()
    Me.BtnTAP02 = New System.Windows.Forms.Button()
    Me.BtnTAP03 = New System.Windows.Forms.Button()
    Me.BtnTAP01 = New System.Windows.Forms.Button()
    Me.TabPage7 = New System.Windows.Forms.TabPage()
    Me.BtnTAP17 = New System.Windows.Forms.Button()
    Me.BtnTAP16 = New System.Windows.Forms.Button()
    Me.BtnTAP15 = New System.Windows.Forms.Button()
    Me.BtnTAP14 = New System.Windows.Forms.Button()
    Me.BtnTAP13 = New System.Windows.Forms.Button()
    Me.BtnTAP12 = New System.Windows.Forms.Button()
    Me.BtnTAP11 = New System.Windows.Forms.Button()
    Me.BtnTAP10 = New System.Windows.Forms.Button()
    Me.TabPage9 = New System.Windows.Forms.TabPage()
    Me.BtnTAP27 = New System.Windows.Forms.Button()
    Me.BtnTAP26 = New System.Windows.Forms.Button()
    Me.BtnTAP25 = New System.Windows.Forms.Button()
    Me.BtnTAP24 = New System.Windows.Forms.Button()
    Me.BtnTAP23 = New System.Windows.Forms.Button()
    Me.BtnTAP22 = New System.Windows.Forms.Button()
    Me.BtnTAP21 = New System.Windows.Forms.Button()
    Me.BtnTAP20 = New System.Windows.Forms.Button()
    Me.TabPage10 = New System.Windows.Forms.TabPage()
    Me.BtnTAP30 = New System.Windows.Forms.Button()
    Me.TabPhaseIn = New System.Windows.Forms.TabPage()
    Me.BtnTA233 = New System.Windows.Forms.Button()
    Me.BtnTA232 = New System.Windows.Forms.Button()
    Me.tabchglog = New System.Windows.Forms.TabPage()
    Me.BtnTA331 = New System.Windows.Forms.Button()
    Me.BtnTA330 = New System.Windows.Forms.Button()
    Me.TabArchive = New System.Windows.Forms.TabPage()
    Me.BtnTAD06 = New System.Windows.Forms.Button()
    Me.BtnTAD05 = New System.Windows.Forms.Button()
    Me.BtnTAD04 = New System.Windows.Forms.Button()
    Me.TabCustom = New System.Windows.Forms.TabPage()
    Me.BtnTA601 = New System.Windows.Forms.Button()
    Me.BtnTA600 = New System.Windows.Forms.Button()
    Me.imagelist_ta = New System.Windows.Forms.ImageList(Me.components)
    Me.Label6 = New System.Windows.Forms.Label()
    Me.BtnTA440 = New System.Windows.Forms.Button()
    Me.BtnTA540 = New System.Windows.Forms.Button()
    Me.tab.SuspendLayout()
    Me.tabdaily.SuspendLayout()
    Me.tabPage2.SuspendLayout()
    Me.tabPage1.SuspendLayout()
    Me.tabPage3.SuspendLayout()
    Me.tabControl2.SuspendLayout()
    Me.tabListings.SuspendLayout()
    Me.tabNotices.SuspendLayout()
    Me.tabOPM.SuspendLayout()
    Me.TabPP.SuspendLayout()
    Me.TabMV.SuspendLayout()
    Me.TabSuppl.SuspendLayout()
    Me.tabPage6.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPgMain.SuspendLayout()
    Me.TabPgRE.SuspendLayout()
    Me.TabPgPP.SuspendLayout()
    Me.TabpgMV.SuspendLayout()
    Me.TabPgSuppl.SuspendLayout()
    Me.tabPage8.SuspendLayout()
    Me.tabfilemaintenance.SuspendLayout()
    Me.tabPage11.SuspendLayout()
    Me.TabPage4.SuspendLayout()
    Me.TabPage20.SuspendLayout()
    Me.TabControl3.SuspendLayout()
    Me.TabPage5.SuspendLayout()
    Me.TabPage7.SuspendLayout()
    Me.TabPage9.SuspendLayout()
    Me.TabPage10.SuspendLayout()
    Me.TabPhaseIn.SuspendLayout()
    Me.tabchglog.SuspendLayout()
    Me.TabArchive.SuspendLayout()
    Me.TabCustom.SuspendLayout()
    Me.SuspendLayout()
    '
    'tab
    '
    Me.tab.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tab.Controls.Add(Me.tabdaily)
    Me.tab.Controls.Add(Me.tabPage2)
    Me.tab.Controls.Add(Me.tabPage1)
    Me.tab.Controls.Add(Me.tabPage3)
    Me.tab.Controls.Add(Me.tabPage6)
    Me.tab.Controls.Add(Me.tabPage8)
    Me.tab.Controls.Add(Me.tabfilemaintenance)
    Me.tab.Controls.Add(Me.tabPage11)
    Me.tab.Controls.Add(Me.TabPage4)
    Me.tab.Controls.Add(Me.TabPage20)
    Me.tab.Controls.Add(Me.TabPhaseIn)
    Me.tab.Controls.Add(Me.tabchglog)
    Me.tab.Controls.Add(Me.TabArchive)
    Me.tab.Controls.Add(Me.TabCustom)
    Me.tab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tab.Location = New System.Drawing.Point(8, 56)
    Me.tab.Multiline = True
    Me.tab.Name = "tab"
    Me.tab.SelectedIndex = 0
    Me.tab.Size = New System.Drawing.Size(587, 455)
    Me.tab.TabIndex = 11
    '
    'tabdaily
    '
    Me.tabdaily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabdaily.Controls.Add(Me.label1)
    Me.tabdaily.Controls.Add(Me.btntaa01)
    Me.tabdaily.Controls.Add(Me.btnTA001)
    Me.tabdaily.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabdaily.Location = New System.Drawing.Point(4, 53)
    Me.tabdaily.Name = "tabdaily"
    Me.tabdaily.Size = New System.Drawing.Size(579, 398)
    Me.tabdaily.TabIndex = 0
    Me.tabdaily.Text = "Daily"
    Me.tabdaily.UseVisualStyleBackColor = True
    '
    'label1
    '
    Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label1.ForeColor = System.Drawing.Color.Maroon
    Me.label1.Image = CType(resources.GetObject("label1.Image"), System.Drawing.Image)
    Me.label1.Location = New System.Drawing.Point(-8, 0)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(544, 32)
    Me.label1.TabIndex = 5
    '
    'btntaa01
    '
    Me.btntaa01.Location = New System.Drawing.Point(144, 168)
    Me.btntaa01.Name = "btntaa01"
    Me.btntaa01.Size = New System.Drawing.Size(248, 24)
    Me.btntaa01.TabIndex = 1
    Me.btntaa01.Text = "Collectors Cash Register Inquiry"
    '
    'btnTA001
    '
    Me.btnTA001.Location = New System.Drawing.Point(144, 136)
    Me.btnTA001.Name = "btnTA001"
    Me.btnTA001.Size = New System.Drawing.Size(248, 24)
    Me.btnTA001.TabIndex = 0
    Me.btnTA001.Text = "Assessment Information"
    '
    'tabPage2
    '
    Me.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage2.Controls.Add(Me.btnTA811)
    Me.tabPage2.Controls.Add(Me.btnTA810)
    Me.tabPage2.Controls.Add(Me.btnta801)
    Me.tabPage2.Controls.Add(Me.label4)
    Me.tabPage2.Location = New System.Drawing.Point(4, 53)
    Me.tabPage2.Name = "tabPage2"
    Me.tabPage2.Size = New System.Drawing.Size(579, 398)
    Me.tabPage2.TabIndex = 3
    Me.tabPage2.Text = "Certificate of Correction"
    Me.tabPage2.UseVisualStyleBackColor = True
    Me.tabPage2.Visible = False
    '
    'btnTA811
    '
    Me.btnTA811.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnTA811.Location = New System.Drawing.Point(144, 159)
    Me.btnTA811.Name = "btnTA811"
    Me.btnTA811.Size = New System.Drawing.Size(248, 24)
    Me.btnTA811.TabIndex = 11
    Me.btnTA811.Text = "Maintain After Bills"
    '
    'btnTA810
    '
    Me.btnTA810.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnTA810.Location = New System.Drawing.Point(144, 129)
    Me.btnTA810.Name = "btnTA810"
    Me.btnTA810.Size = New System.Drawing.Size(248, 24)
    Me.btnTA810.TabIndex = 10
    Me.btnTA810.Text = "Maintain Before Bills"
    '
    'btnta801
    '
    Me.btnta801.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta801.Location = New System.Drawing.Point(144, 98)
    Me.btnta801.Name = "btnta801"
    Me.btnta801.Size = New System.Drawing.Size(248, 24)
    Me.btnta801.TabIndex = 7
    Me.btnta801.Text = "Print Register"
    '
    'label4
    '
    Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label4.ForeColor = System.Drawing.Color.Maroon
    Me.label4.Image = CType(resources.GetObject("label4.Image"), System.Drawing.Image)
    Me.label4.Location = New System.Drawing.Point(-8, 0)
    Me.label4.Name = "label4"
    Me.label4.Size = New System.Drawing.Size(544, 32)
    Me.label4.TabIndex = 6
    '
    'tabPage1
    '
    Me.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage1.Controls.Add(Me.BtnTA141)
    Me.tabPage1.Controls.Add(Me.BtnTA140)
    Me.tabPage1.Controls.Add(Me.BtnTA139)
    Me.tabPage1.Controls.Add(Me.BtnTA138)
    Me.tabPage1.Controls.Add(Me.BtnTA137)
    Me.tabPage1.Controls.Add(Me.BtnTA136)
    Me.tabPage1.Controls.Add(Me.BtnTA134)
    Me.tabPage1.Controls.Add(Me.BtnTA135)
    Me.tabPage1.Controls.Add(Me.BtnTA133)
    Me.tabPage1.Controls.Add(Me.BtnTA132)
    Me.tabPage1.Controls.Add(Me.BtnTA131)
    Me.tabPage1.Controls.Add(Me.BtnTA130)
    Me.tabPage1.Controls.Add(Me.BtnTA111)
    Me.tabPage1.Controls.Add(Me.btnta110)
    Me.tabPage1.Controls.Add(Me.btnta109)
    Me.tabPage1.Controls.Add(Me.btnta108)
    Me.tabPage1.Controls.Add(Me.btnta107)
    Me.tabPage1.Controls.Add(Me.btnta106)
    Me.tabPage1.Controls.Add(Me.btnta105)
    Me.tabPage1.Controls.Add(Me.btnta104)
    Me.tabPage1.Controls.Add(Me.BtnTA103)
    Me.tabPage1.Controls.Add(Me.BtnTA102)
    Me.tabPage1.Controls.Add(Me.BtnTA101)
    Me.tabPage1.Controls.Add(Me.label3)
    Me.tabPage1.Location = New System.Drawing.Point(4, 53)
    Me.tabPage1.Name = "tabPage1"
    Me.tabPage1.Size = New System.Drawing.Size(579, 398)
    Me.tabPage1.TabIndex = 2
    Me.tabPage1.Text = "Tables"
    Me.tabPage1.UseVisualStyleBackColor = True
    Me.tabPage1.Visible = False
    '
    'BtnTA141
    '
    Me.BtnTA141.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA141.Location = New System.Drawing.Point(8, 362)
    Me.BtnTA141.Name = "BtnTA141"
    Me.BtnTA141.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA141.TabIndex = 29
    Me.BtnTA141.Text = "MSRP Source Codes"
    '
    'BtnTA140
    '
    Me.BtnTA140.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA140.Location = New System.Drawing.Point(8, 335)
    Me.BtnTA140.Name = "BtnTA140"
    Me.BtnTA140.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA140.TabIndex = 28
    Me.BtnTA140.Text = "MSRP Depreciation"
    '
    'BtnTA139
    '
    Me.BtnTA139.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA139.Location = New System.Drawing.Point(272, 333)
    Me.BtnTA139.Name = "BtnTA139"
    Me.BtnTA139.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA139.TabIndex = 27
    Me.BtnTA139.Text = "Local Tax Limit and TRF Adjust"
    '
    'BtnTA138
    '
    Me.BtnTA138.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA138.Location = New System.Drawing.Point(8, 305)
    Me.BtnTA138.Name = "BtnTA138"
    Me.BtnTA138.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA138.TabIndex = 26
    Me.BtnTA138.Text = "M37 Land Only Codes"
    '
    'BtnTA137
    '
    Me.BtnTA137.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA137.Location = New System.Drawing.Point(272, 305)
    Me.BtnTA137.Name = "BtnTA137"
    Me.BtnTA137.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA137.TabIndex = 25
    Me.BtnTA137.Text = "Local Homeowners Income"
    '
    'BtnTA136
    '
    Me.BtnTA136.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA136.Location = New System.Drawing.Point(8, 275)
    Me.BtnTA136.Name = "BtnTA136"
    Me.BtnTA136.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA136.TabIndex = 24
    Me.BtnTA136.Text = "CIVILS Class Lookup"
    '
    'BtnTA134
    '
    Me.BtnTA134.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA134.Location = New System.Drawing.Point(272, 245)
    Me.BtnTA134.Name = "BtnTA134"
    Me.BtnTA134.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA134.TabIndex = 23
    Me.BtnTA134.Text = "Local Qualifying Income"
    '
    'BtnTA135
    '
    Me.BtnTA135.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA135.Location = New System.Drawing.Point(272, 275)
    Me.BtnTA135.Name = "BtnTA135"
    Me.BtnTA135.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA135.TabIndex = 22
    Me.BtnTA135.Text = "Local Exemption Income"
    '
    'BtnTA133
    '
    Me.BtnTA133.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA133.Location = New System.Drawing.Point(8, 185)
    Me.BtnTA133.Name = "BtnTA133"
    Me.BtnTA133.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA133.TabIndex = 21
    Me.BtnTA133.Text = "Homeowners Qualifying Income"
    '
    'BtnTA132
    '
    Me.BtnTA132.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA132.Location = New System.Drawing.Point(272, 215)
    Me.BtnTA132.Name = "BtnTA132"
    Me.BtnTA132.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA132.TabIndex = 20
    Me.BtnTA132.Text = "Elderly Adjusted Gross Codes"
    '
    'BtnTA131
    '
    Me.BtnTA131.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA131.Location = New System.Drawing.Point(8, 245)
    Me.BtnTA131.Name = "BtnTA131"
    Me.BtnTA131.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA131.TabIndex = 19
    Me.BtnTA131.Text = "State Forester Property Codes"
    '
    'BtnTA130
    '
    Me.BtnTA130.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA130.Location = New System.Drawing.Point(8, 215)
    Me.BtnTA130.Name = "BtnTA130"
    Me.BtnTA130.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA130.TabIndex = 18
    Me.BtnTA130.Text = "Tax Control File"
    '
    'BtnTA111
    '
    Me.BtnTA111.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA111.Location = New System.Drawing.Point(272, 185)
    Me.BtnTA111.Name = "BtnTA111"
    Me.BtnTA111.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA111.TabIndex = 17
    Me.BtnTA111.Text = "Local Benefit Codes"
    '
    'btnta110
    '
    Me.btnta110.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta110.Location = New System.Drawing.Point(272, 155)
    Me.btnta110.Name = "btnta110"
    Me.btnta110.Size = New System.Drawing.Size(248, 24)
    Me.btnta110.TabIndex = 16
    Me.btnta110.Text = "Owner Identification"
    '
    'btnta109
    '
    Me.btnta109.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta109.Location = New System.Drawing.Point(272, 125)
    Me.btnta109.Name = "btnta109"
    Me.btnta109.Size = New System.Drawing.Size(248, 24)
    Me.btnta109.TabIndex = 15
    Me.btnta109.Text = "Elderly Pro-Rate Percentages"
    '
    'btnta108
    '
    Me.btnta108.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta108.Location = New System.Drawing.Point(272, 95)
    Me.btnta108.Name = "btnta108"
    Me.btnta108.Size = New System.Drawing.Size(248, 24)
    Me.btnta108.TabIndex = 14
    Me.btnta108.Text = "Property Type"
    '
    'btnta107
    '
    Me.btnta107.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta107.Location = New System.Drawing.Point(272, 65)
    Me.btnta107.Name = "btnta107"
    Me.btnta107.Size = New System.Drawing.Size(248, 24)
    Me.btnta107.TabIndex = 13
    Me.btnta107.Text = "Business Type Codes"
    '
    'btnta106
    '
    Me.btnta106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta106.Location = New System.Drawing.Point(272, 35)
    Me.btnta106.Name = "btnta106"
    Me.btnta106.Size = New System.Drawing.Size(248, 24)
    Me.btnta106.TabIndex = 12
    Me.btnta106.Text = "C of C Reason Codes"
    '
    'btnta105
    '
    Me.btnta105.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta105.Location = New System.Drawing.Point(8, 155)
    Me.btnta105.Name = "btnta105"
    Me.btnta105.Size = New System.Drawing.Size(248, 24)
    Me.btnta105.TabIndex = 11
    Me.btnta105.Text = "Homeowners Percentages"
    '
    'btnta104
    '
    Me.btnta104.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta104.Location = New System.Drawing.Point(8, 125)
    Me.btnta104.Name = "btnta104"
    Me.btnta104.Size = New System.Drawing.Size(248, 24)
    Me.btnta104.TabIndex = 10
    Me.btnta104.Text = "NADA Book Value"
    '
    'BtnTA103
    '
    Me.BtnTA103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA103.Location = New System.Drawing.Point(8, 95)
    Me.BtnTA103.Name = "BtnTA103"
    Me.BtnTA103.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA103.TabIndex = 9
    Me.BtnTA103.Text = "Property  Class Codes"
    '
    'BtnTA102
    '
    Me.BtnTA102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA102.Location = New System.Drawing.Point(8, 67)
    Me.BtnTA102.Name = "BtnTA102"
    Me.BtnTA102.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA102.TabIndex = 8
    Me.BtnTA102.Text = "Exemption Codes"
    '
    'BtnTA101
    '
    Me.BtnTA101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA101.Location = New System.Drawing.Point(8, 35)
    Me.BtnTA101.Name = "BtnTA101"
    Me.BtnTA101.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA101.TabIndex = 7
    Me.BtnTA101.Text = "Exempt Real Property Codes"
    '
    'label3
    '
    Me.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.ForeColor = System.Drawing.Color.Maroon
    Me.label3.Image = CType(resources.GetObject("label3.Image"), System.Drawing.Image)
    Me.label3.Location = New System.Drawing.Point(0, 0)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(528, 32)
    Me.label3.TabIndex = 6
    '
    'tabPage3
    '
    Me.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage3.Controls.Add(Me.label5)
    Me.tabPage3.Controls.Add(Me.tabControl2)
    Me.tabPage3.Location = New System.Drawing.Point(4, 53)
    Me.tabPage3.Name = "tabPage3"
    Me.tabPage3.Size = New System.Drawing.Size(579, 398)
    Me.tabPage3.TabIndex = 4
    Me.tabPage3.Text = "Reports"
    Me.tabPage3.UseVisualStyleBackColor = True
    Me.tabPage3.Visible = False
    '
    'label5
    '
    Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label5.ForeColor = System.Drawing.Color.Maroon
    Me.label5.Image = CType(resources.GetObject("label5.Image"), System.Drawing.Image)
    Me.label5.Location = New System.Drawing.Point(-8, 0)
    Me.label5.Name = "label5"
    Me.label5.Size = New System.Drawing.Size(544, 32)
    Me.label5.TabIndex = 6
    '
    'tabControl2
    '
    Me.tabControl2.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.tabControl2.Controls.Add(Me.tabListings)
    Me.tabControl2.Controls.Add(Me.tabNotices)
    Me.tabControl2.Controls.Add(Me.tabOPM)
    Me.tabControl2.Controls.Add(Me.TabPP)
    Me.tabControl2.Controls.Add(Me.TabMV)
    Me.tabControl2.Controls.Add(Me.TabSuppl)
    Me.tabControl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabControl2.ItemSize = New System.Drawing.Size(62, 23)
    Me.tabControl2.Location = New System.Drawing.Point(8, 40)
    Me.tabControl2.Name = "tabControl2"
    Me.tabControl2.SelectedIndex = 0
    Me.tabControl2.Size = New System.Drawing.Size(556, 312)
    Me.tabControl2.TabIndex = 0
    '
    'tabListings
    '
    Me.tabListings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.tabListings.Controls.Add(Me.BtnTAB04)
    Me.tabListings.Controls.Add(Me.BtnTA237)
    Me.tabListings.Controls.Add(Me.BtnTA234)
    Me.tabListings.Controls.Add(Me.BtnTA217)
    Me.tabListings.Controls.Add(Me.BtnTA230)
    Me.tabListings.Controls.Add(Me.btnta219)
    Me.tabListings.Controls.Add(Me.btnta208)
    Me.tabListings.Controls.Add(Me.BtnTA209)
    Me.tabListings.Controls.Add(Me.btnta216)
    Me.tabListings.Controls.Add(Me.btnta207)
    Me.tabListings.Controls.Add(Me.btnta226)
    Me.tabListings.Controls.Add(Me.btnta203)
    Me.tabListings.Controls.Add(Me.btnta218)
    Me.tabListings.Controls.Add(Me.btnta215)
    Me.tabListings.Controls.Add(Me.label11)
    Me.tabListings.Controls.Add(Me.btntab03)
    Me.tabListings.Controls.Add(Me.btntab02)
    Me.tabListings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabListings.Location = New System.Drawing.Point(4, 27)
    Me.tabListings.Name = "tabListings"
    Me.tabListings.Size = New System.Drawing.Size(548, 281)
    Me.tabListings.TabIndex = 0
    Me.tabListings.Text = "Listings"
    Me.tabListings.UseVisualStyleBackColor = True
    '
    'BtnTAB04
    '
    Me.BtnTAB04.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAB04.Location = New System.Drawing.Point(260, 248)
    Me.BtnTAB04.Name = "BtnTAB04"
    Me.BtnTAB04.Size = New System.Drawing.Size(216, 24)
    Me.BtnTAB04.TabIndex = 68
    Me.BtnTAB04.Text = "Compare Exemptions"
    '
    'BtnTA237
    '
    Me.BtnTA237.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA237.Location = New System.Drawing.Point(260, 218)
    Me.BtnTA237.Name = "BtnTA237"
    Me.BtnTA237.Size = New System.Drawing.Size(216, 24)
    Me.BtnTA237.TabIndex = 67
    Me.BtnTA237.Text = "Local Elderly List"
    '
    'BtnTA234
    '
    Me.BtnTA234.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA234.Location = New System.Drawing.Point(25, 248)
    Me.BtnTA234.Name = "BtnTA234"
    Me.BtnTA234.Size = New System.Drawing.Size(216, 24)
    Me.BtnTA234.TabIndex = 66
    Me.BtnTA234.Text = "Compare Change of Assessment"
    '
    'BtnTA217
    '
    Me.BtnTA217.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA217.Location = New System.Drawing.Point(25, 218)
    Me.BtnTA217.Name = "BtnTA217"
    Me.BtnTA217.Size = New System.Drawing.Size(216, 24)
    Me.BtnTA217.TabIndex = 65
    Me.BtnTA217.Text = "Real Estate by Location"
    '
    'BtnTA230
    '
    Me.BtnTA230.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA230.Location = New System.Drawing.Point(260, 189)
    Me.BtnTA230.Name = "BtnTA230"
    Me.BtnTA230.Size = New System.Drawing.Size(216, 24)
    Me.BtnTA230.TabIndex = 64
    Me.BtnTA230.Text = "Local Tax Benefit List"
    '
    'btnta219
    '
    Me.btnta219.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta219.Location = New System.Drawing.Point(25, 189)
    Me.btnta219.Name = "btnta219"
    Me.btnta219.Size = New System.Drawing.Size(216, 24)
    Me.btnta219.TabIndex = 63
    Me.btnta219.Text = "Public 490 Report"
    '
    'btnta208
    '
    Me.btnta208.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta208.Location = New System.Drawing.Point(260, 160)
    Me.btnta208.Name = "btnta208"
    Me.btnta208.Size = New System.Drawing.Size(216, 24)
    Me.btnta208.TabIndex = 62
    Me.btnta208.Text = "State && Local Tax Credit"
    '
    'BtnTA209
    '
    Me.BtnTA209.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA209.Location = New System.Drawing.Point(25, 160)
    Me.BtnTA209.Name = "BtnTA209"
    Me.BtnTA209.Size = New System.Drawing.Size(216, 24)
    Me.BtnTA209.TabIndex = 61
    Me.BtnTA209.Text = "Transfers Information Listing"
    '
    'btnta216
    '
    Me.btnta216.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta216.Location = New System.Drawing.Point(260, 67)
    Me.btnta216.Name = "btnta216"
    Me.btnta216.Size = New System.Drawing.Size(216, 24)
    Me.btnta216.TabIndex = 60
    Me.btnta216.Text = "State Forester Report"
    '
    'btnta207
    '
    Me.btnta207.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta207.Location = New System.Drawing.Point(260, 131)
    Me.btnta207.Name = "btnta207"
    Me.btnta207.Size = New System.Drawing.Size(216, 24)
    Me.btnta207.TabIndex = 59
    Me.btnta207.Text = "Local Tax Credit Benefit "
    '
    'btnta226
    '
    Me.btnta226.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta226.Location = New System.Drawing.Point(260, 99)
    Me.btnta226.Name = "btnta226"
    Me.btnta226.Size = New System.Drawing.Size(216, 24)
    Me.btnta226.TabIndex = 58
    Me.btnta226.Text = "Exemption Report (Real Estate)"
    '
    'btnta203
    '
    Me.btnta203.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta203.Location = New System.Drawing.Point(260, 35)
    Me.btnta203.Name = "btnta203"
    Me.btnta203.Size = New System.Drawing.Size(216, 24)
    Me.btnta203.TabIndex = 57
    Me.btnta203.Text = "Highest Assessment List"
    '
    'btnta218
    '
    Me.btnta218.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta218.Location = New System.Drawing.Point(25, 99)
    Me.btnta218.Name = "btnta218"
    Me.btnta218.Size = New System.Drawing.Size(216, 24)
    Me.btnta218.TabIndex = 56
    Me.btnta218.Text = "Assessment Code Listing"
    '
    'btnta215
    '
    Me.btnta215.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta215.Location = New System.Drawing.Point(25, 67)
    Me.btnta215.Name = "btnta215"
    Me.btnta215.Size = New System.Drawing.Size(216, 24)
    Me.btnta215.TabIndex = 55
    Me.btnta215.Text = "Tax Exempt Property Listing"
    '
    'label11
    '
    Me.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
    Me.label11.ForeColor = System.Drawing.Color.Maroon
    Me.label11.Image = CType(resources.GetObject("label11.Image"), System.Drawing.Image)
    Me.label11.Location = New System.Drawing.Point(0, 0)
    Me.label11.Name = "label11"
    Me.label11.Size = New System.Drawing.Size(536, 32)
    Me.label11.TabIndex = 54
    '
    'btntab03
    '
    Me.btntab03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntab03.Location = New System.Drawing.Point(25, 131)
    Me.btntab03.Name = "btntab03"
    Me.btntab03.Size = New System.Drawing.Size(216, 24)
    Me.btntab03.TabIndex = 43
    Me.btntab03.Text = "Labels"
    '
    'btntab02
    '
    Me.btntab02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntab02.Location = New System.Drawing.Point(25, 35)
    Me.btntab02.Name = "btntab02"
    Me.btntab02.Size = New System.Drawing.Size(216, 24)
    Me.btntab02.TabIndex = 36
    Me.btntab02.Text = "Accounts With Exemptions"
    '
    'tabNotices
    '
    Me.tabNotices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.tabNotices.Controls.Add(Me.BtnTA235)
    Me.tabNotices.Controls.Add(Me.btnta206)
    Me.tabNotices.Controls.Add(Me.btntab01)
    Me.tabNotices.Controls.Add(Me.btnta205)
    Me.tabNotices.Controls.Add(Me.btnta204)
    Me.tabNotices.Controls.Add(Me.label12)
    Me.tabNotices.Controls.Add(Me.btnta314)
    Me.tabNotices.Controls.Add(Me.btnta213)
    Me.tabNotices.Controls.Add(Me.btnta212)
    Me.tabNotices.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabNotices.Location = New System.Drawing.Point(4, 27)
    Me.tabNotices.Name = "tabNotices"
    Me.tabNotices.Size = New System.Drawing.Size(548, 281)
    Me.tabNotices.TabIndex = 1
    Me.tabNotices.Text = "Notices/Grand Lists"
    Me.tabNotices.UseVisualStyleBackColor = True
    Me.tabNotices.Visible = False
    '
    'BtnTA235
    '
    Me.BtnTA235.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA235.Location = New System.Drawing.Point(129, 225)
    Me.BtnTA235.Name = "BtnTA235"
    Me.BtnTA235.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA235.TabIndex = 60
    Me.BtnTA235.Text = "Grand List Summary  "
    '
    'btnta206
    '
    Me.btnta206.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta206.Location = New System.Drawing.Point(129, 253)
    Me.btnta206.Name = "btnta206"
    Me.btnta206.Size = New System.Drawing.Size(248, 24)
    Me.btnta206.TabIndex = 59
    Me.btnta206.Text = "Board of Assessment Appeals"
    '
    'btntab01
    '
    Me.btntab01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntab01.Location = New System.Drawing.Point(129, 195)
    Me.btntab01.Name = "btntab01"
    Me.btntab01.Size = New System.Drawing.Size(248, 24)
    Me.btntab01.TabIndex = 58
    Me.btntab01.Text = "Tax Summary Final Report"
    '
    'btnta205
    '
    Me.btnta205.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta205.Location = New System.Drawing.Point(129, 163)
    Me.btnta205.Name = "btnta205"
    Me.btnta205.Size = New System.Drawing.Size(248, 24)
    Me.btnta205.TabIndex = 57
    Me.btnta205.Text = "Change Of Assessment Notices"
    '
    'btnta204
    '
    Me.btnta204.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta204.Location = New System.Drawing.Point(129, 131)
    Me.btnta204.Name = "btnta204"
    Me.btnta204.Size = New System.Drawing.Size(248, 24)
    Me.btnta204.TabIndex = 56
    Me.btnta204.Text = "B.A.A. Notices"
    '
    'label12
    '
    Me.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
    Me.label12.ForeColor = System.Drawing.Color.Maroon
    Me.label12.Image = CType(resources.GetObject("label12.Image"), System.Drawing.Image)
    Me.label12.Location = New System.Drawing.Point(0, 0)
    Me.label12.Name = "label12"
    Me.label12.Size = New System.Drawing.Size(536, 32)
    Me.label12.TabIndex = 55
    '
    'btnta314
    '
    Me.btnta314.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta314.Location = New System.Drawing.Point(129, 99)
    Me.btnta314.Name = "btnta314"
    Me.btnta314.Size = New System.Drawing.Size(248, 24)
    Me.btnta314.TabIndex = 29
    Me.btnta314.Text = "Penalty Notices"
    '
    'btnta213
    '
    Me.btnta213.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta213.Location = New System.Drawing.Point(129, 67)
    Me.btnta213.Name = "btnta213"
    Me.btnta213.Size = New System.Drawing.Size(248, 24)
    Me.btnta213.TabIndex = 28
    Me.btnta213.Text = "Letter Totals"
    '
    'btnta212
    '
    Me.btnta212.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta212.Location = New System.Drawing.Point(129, 35)
    Me.btnta212.Name = "btnta212"
    Me.btnta212.Size = New System.Drawing.Size(248, 24)
    Me.btnta212.TabIndex = 27
    Me.btnta212.Text = "Grand Lists"
    '
    'tabOPM
    '
    Me.tabOPM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.tabOPM.Controls.Add(Me.BtnTO121)
    Me.tabOPM.Controls.Add(Me.btnto110)
    Me.tabOPM.Controls.Add(Me.btnto107)
    Me.tabOPM.Controls.Add(Me.btnto116)
    Me.tabOPM.Controls.Add(Me.BtnTO120)
    Me.tabOPM.Controls.Add(Me.btnto114)
    Me.tabOPM.Controls.Add(Me.btnto113)
    Me.tabOPM.Controls.Add(Me.btnto112)
    Me.tabOPM.Controls.Add(Me.btnto111)
    Me.tabOPM.Controls.Add(Me.btnto105)
    Me.tabOPM.Controls.Add(Me.btnto104)
    Me.tabOPM.Controls.Add(Me.btnto103)
    Me.tabOPM.Controls.Add(Me.btnto109)
    Me.tabOPM.Controls.Add(Me.btnto106)
    Me.tabOPM.Controls.Add(Me.btnto102)
    Me.tabOPM.Controls.Add(Me.btnto101)
    Me.tabOPM.Controls.Add(Me.label13)
    Me.tabOPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabOPM.Location = New System.Drawing.Point(4, 27)
    Me.tabOPM.Name = "tabOPM"
    Me.tabOPM.Size = New System.Drawing.Size(548, 281)
    Me.tabOPM.TabIndex = 2
    Me.tabOPM.Text = "O.P.M."
    Me.tabOPM.UseVisualStyleBackColor = True
    Me.tabOPM.Visible = False
    '
    'BtnTO121
    '
    Me.BtnTO121.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO121.Location = New System.Drawing.Point(288, 62)
    Me.BtnTO121.Name = "BtnTO121"
    Me.BtnTO121.Size = New System.Drawing.Size(255, 25)
    Me.BtnTO121.TabIndex = 87
    Me.BtnTO121.Text = "M-46 Revenue Loss for Eligible Manfacturing"
    Me.BtnTO121.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto110
    '
    Me.btnto110.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto110.Location = New System.Drawing.Point(288, 94)
    Me.btnto110.Name = "btnto110"
    Me.btnto110.Size = New System.Drawing.Size(255, 25)
    Me.btnto110.TabIndex = 86
    Me.btnto110.Text = "M-59a  Rev Loss due to Addl. Vet Exemptions"
    Me.btnto110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto107
    '
    Me.btnto107.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto107.Location = New System.Drawing.Point(4, 221)
    Me.btnto107.Name = "btnto107"
    Me.btnto107.Size = New System.Drawing.Size(265, 25)
    Me.btnto107.TabIndex = 85
    Me.btnto107.Text = "M-37  State Owned Property and M37 C & H"
    Me.btnto107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnto107.UseMnemonic = False
    '
    'btnto116
    '
    Me.btnto116.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto116.Location = New System.Drawing.Point(288, 251)
    Me.btnto116.Name = "btnto116"
    Me.btnto116.Size = New System.Drawing.Size(255, 25)
    Me.btnto116.TabIndex = 84
    Me.btnto116.Text = "15a/15b/R-Exempt/ for Mfg. && Biotech "
    Me.btnto116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'BtnTO120
    '
    Me.BtnTO120.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO120.Location = New System.Drawing.Point(4, 253)
    Me.BtnTO120.Name = "BtnTO120"
    Me.BtnTO120.Size = New System.Drawing.Size(264, 25)
    Me.BtnTO120.TabIndex = 83
    Me.BtnTO120.Text = "DVA Veterans Exemptions File"
    Me.BtnTO120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto114
    '
    Me.btnto114.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto114.Location = New System.Drawing.Point(288, 222)
    Me.btnto114.Name = "btnto114"
    Me.btnto114.Size = New System.Drawing.Size(255, 25)
    Me.btnto114.TabIndex = 81
    Me.btnto114.Text = "M65a-MV MV/Supp Exempt Vehicles (NBB)"
    Me.btnto114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto113
    '
    Me.btnto113.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto113.Location = New System.Drawing.Point(288, 190)
    Me.btnto113.Name = "btnto113"
    Me.btnto113.Size = New System.Drawing.Size(255, 25)
    Me.btnto113.TabIndex = 80
    Me.btnto113.Text = "BAA Listing"
    Me.btnto113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto112
    '
    Me.btnto112.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto112.Location = New System.Drawing.Point(288, 158)
    Me.btnto112.Name = "btnto112"
    Me.btnto112.Size = New System.Drawing.Size(255, 25)
    Me.btnto112.TabIndex = 79
    Me.btnto112.Text = "Tax Credit for Per Prop Code (Computer)"
    Me.btnto112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto111
    '
    Me.btnto111.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto111.Location = New System.Drawing.Point(288, 126)
    Me.btnto111.Name = "btnto111"
    Me.btnto111.Size = New System.Drawing.Size(255, 25)
    Me.btnto111.TabIndex = 78
    Me.btnto111.Text = "M-65a  Revenue Loss due to New Machinery "
    Me.btnto111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto105
    '
    Me.btnto105.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto105.Location = New System.Drawing.Point(3, 160)
    Me.btnto105.Name = "btnto105"
    Me.btnto105.Size = New System.Drawing.Size(265, 25)
    Me.btnto105.TabIndex = 76
    Me.btnto105.Text = "M-36 Revenue Loss State Program Elderly Freeze"
    Me.btnto105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto104
    '
    Me.btnto104.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto104.Location = New System.Drawing.Point(3, 128)
    Me.btnto104.Name = "btnto104"
    Me.btnto104.Size = New System.Drawing.Size(265, 25)
    Me.btnto104.TabIndex = 75
    Me.btnto104.Text = "M-35p  Reduction to Owners Reimb"
    Me.btnto104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto103
    '
    Me.btnto103.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto103.Location = New System.Drawing.Point(3, 94)
    Me.btnto103.Name = "btnto103"
    Me.btnto103.Size = New System.Drawing.Size(265, 25)
    Me.btnto103.TabIndex = 74
    Me.btnto103.Text = "M-35b Revenue Loss Owners Program for Elderly"
    Me.btnto103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto109
    '
    Me.btnto109.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto109.Location = New System.Drawing.Point(288, 30)
    Me.btnto109.Name = "btnto109"
    Me.btnto109.Size = New System.Drawing.Size(255, 25)
    Me.btnto109.TabIndex = 73
    Me.btnto109.Text = "M-42b  Totally Disabled Program"
    Me.btnto109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto106
    '
    Me.btnto106.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto106.Location = New System.Drawing.Point(3, 192)
    Me.btnto106.Name = "btnto106"
    Me.btnto106.Size = New System.Drawing.Size(265, 25)
    Me.btnto106.TabIndex = 71
    Me.btnto106.Text = "M-36p  Reduction to Freeze Reimbursement"
    Me.btnto106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto102
    '
    Me.btnto102.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto102.Location = New System.Drawing.Point(3, 62)
    Me.btnto102.Name = "btnto102"
    Me.btnto102.Size = New System.Drawing.Size(265, 25)
    Me.btnto102.TabIndex = 70
    Me.btnto102.Text = "M-13a  Grand List of Tax Exempt Property"
    Me.btnto102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'btnto101
    '
    Me.btnto101.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnto101.Location = New System.Drawing.Point(3, 30)
    Me.btnto101.Name = "btnto101"
    Me.btnto101.Size = New System.Drawing.Size(265, 25)
    Me.btnto101.TabIndex = 69
    Me.btnto101.Text = "M-13  Grand List of Taxable Property"
    Me.btnto101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'label13
    '
    Me.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
    Me.label13.ForeColor = System.Drawing.Color.Maroon
    Me.label13.Image = CType(resources.GetObject("label13.Image"), System.Drawing.Image)
    Me.label13.Location = New System.Drawing.Point(0, 0)
    Me.label13.Name = "label13"
    Me.label13.Size = New System.Drawing.Size(544, 24)
    Me.label13.TabIndex = 68
    '
    'TabPP
    '
    Me.TabPP.Controls.Add(Me.BtnTA316)
    Me.TabPP.Location = New System.Drawing.Point(4, 27)
    Me.TabPP.Name = "TabPP"
    Me.TabPP.Size = New System.Drawing.Size(548, 281)
    Me.TabPP.TabIndex = 5
    Me.TabPP.Text = "Personal Property"
    Me.TabPP.UseVisualStyleBackColor = True
    '
    'BtnTA316
    '
    Me.BtnTA316.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA316.Location = New System.Drawing.Point(147, 17)
    Me.BtnTA316.Name = "BtnTA316"
    Me.BtnTA316.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA316.TabIndex = 29
    Me.BtnTA316.Text = "Business Types List"
    '
    'TabMV
    '
    Me.TabMV.Controls.Add(Me.BtnTA430)
    Me.TabMV.Controls.Add(Me.BtnTA413)
    Me.TabMV.Controls.Add(Me.BtnTA414)
    Me.TabMV.Controls.Add(Me.BtnTA408)
    Me.TabMV.Controls.Add(Me.BtnTA4077)
    Me.TabMV.Controls.Add(Me.BtnTA4076)
    Me.TabMV.Controls.Add(Me.BtnTA4075)
    Me.TabMV.Controls.Add(Me.BtnTA4074)
    Me.TabMV.Controls.Add(Me.BtnTA4073)
    Me.TabMV.Controls.Add(Me.BtnTA4072)
    Me.TabMV.Controls.Add(Me.BtnTA4071)
    Me.TabMV.Location = New System.Drawing.Point(4, 27)
    Me.TabMV.Name = "TabMV"
    Me.TabMV.Size = New System.Drawing.Size(548, 281)
    Me.TabMV.TabIndex = 3
    Me.TabMV.Text = "MV"
    Me.TabMV.UseVisualStyleBackColor = True
    '
    'BtnTA430
    '
    Me.BtnTA430.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA430.Location = New System.Drawing.Point(18, 165)
    Me.BtnTA430.Name = "BtnTA430"
    Me.BtnTA430.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA430.TabIndex = 39
    Me.BtnTA430.Text = "Print NADA Error List"
    '
    'BtnTA413
    '
    Me.BtnTA413.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA413.Location = New System.Drawing.Point(280, 135)
    Me.BtnTA413.Name = "BtnTA413"
    Me.BtnTA413.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA413.TabIndex = 38
    Me.BtnTA413.Text = "Print Selected Class List"
    '
    'BtnTA414
    '
    Me.BtnTA414.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA414.Location = New System.Drawing.Point(280, 106)
    Me.BtnTA414.Name = "BtnTA414"
    Me.BtnTA414.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA414.TabIndex = 36
    Me.BtnTA414.Text = "Print Duplicate Vin No."
    '
    'BtnTA408
    '
    Me.BtnTA408.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA408.Location = New System.Drawing.Point(280, 76)
    Me.BtnTA408.Name = "BtnTA408"
    Me.BtnTA408.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA408.TabIndex = 35
    Me.BtnTA408.Text = "Vehicle Capacity By Class "
    '
    'BtnTA4077
    '
    Me.BtnTA4077.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4077.Location = New System.Drawing.Point(280, 46)
    Me.BtnTA4077.Name = "BtnTA4077"
    Me.BtnTA4077.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA4077.TabIndex = 34
    Me.BtnTA4077.Text = "Selected Zip Code"
    '
    'BtnTA4076
    '
    Me.BtnTA4076.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4076.Location = New System.Drawing.Point(280, 16)
    Me.BtnTA4076.Name = "BtnTA4076"
    Me.BtnTA4076.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA4076.TabIndex = 33
    Me.BtnTA4076.Text = "Missing Zip Codes"
    '
    'BtnTA4075
    '
    Me.BtnTA4075.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4075.Location = New System.Drawing.Point(18, 136)
    Me.BtnTA4075.Name = "BtnTA4075"
    Me.BtnTA4075.Size = New System.Drawing.Size(235, 23)
    Me.BtnTA4075.TabIndex = 32
    Me.BtnTA4075.Text = "Unknown District"
    '
    'BtnTA4074
    '
    Me.BtnTA4074.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4074.Location = New System.Drawing.Point(18, 107)
    Me.BtnTA4074.Name = "BtnTA4074"
    Me.BtnTA4074.Size = New System.Drawing.Size(235, 23)
    Me.BtnTA4074.TabIndex = 31
    Me.BtnTA4074.Text = "Out of Town"
    '
    'BtnTA4073
    '
    Me.BtnTA4073.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4073.Location = New System.Drawing.Point(18, 78)
    Me.BtnTA4073.Name = "BtnTA4073"
    Me.BtnTA4073.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA4073.TabIndex = 30
    Me.BtnTA4073.Text = "Duplicate Registration"
    '
    'BtnTA4072
    '
    Me.BtnTA4072.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4072.Location = New System.Drawing.Point(18, 49)
    Me.BtnTA4072.Name = "BtnTA4072"
    Me.BtnTA4072.Size = New System.Drawing.Size(235, 23)
    Me.BtnTA4072.TabIndex = 29
    Me.BtnTA4072.Text = "Owner Name"
    '
    'BtnTA4071
    '
    Me.BtnTA4071.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA4071.Location = New System.Drawing.Point(18, 16)
    Me.BtnTA4071.Name = "BtnTA4071"
    Me.BtnTA4071.Size = New System.Drawing.Size(235, 24)
    Me.BtnTA4071.TabIndex = 28
    Me.BtnTA4071.Text = "Class/Make"
    '
    'TabSuppl
    '
    Me.TabSuppl.Controls.Add(Me.BtnTA525)
    Me.TabSuppl.Controls.Add(Me.BtnTA524)
    Me.TabSuppl.Controls.Add(Me.BtnTA5078)
    Me.TabSuppl.Controls.Add(Me.BtnTA521)
    Me.TabSuppl.Controls.Add(Me.BtnTA530)
    Me.TabSuppl.Controls.Add(Me.BtnTA5077)
    Me.TabSuppl.Controls.Add(Me.BtnTA514)
    Me.TabSuppl.Controls.Add(Me.BtnTA513)
    Me.TabSuppl.Controls.Add(Me.BtnTA5076)
    Me.TabSuppl.Controls.Add(Me.BtnTA5075)
    Me.TabSuppl.Controls.Add(Me.BtnTA5074)
    Me.TabSuppl.Controls.Add(Me.BtnTA5073)
    Me.TabSuppl.Controls.Add(Me.BtnTA5072)
    Me.TabSuppl.Controls.Add(Me.BtnTA5071)
    Me.TabSuppl.Location = New System.Drawing.Point(4, 27)
    Me.TabSuppl.Name = "TabSuppl"
    Me.TabSuppl.Size = New System.Drawing.Size(548, 281)
    Me.TabSuppl.TabIndex = 4
    Me.TabSuppl.Text = "Suppl MV"
    Me.TabSuppl.UseVisualStyleBackColor = True
    '
    'BtnTA525
    '
    Me.BtnTA525.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA525.Location = New System.Drawing.Point(281, 199)
    Me.BtnTA525.Name = "BtnTA525"
    Me.BtnTA525.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA525.TabIndex = 47
    Me.BtnTA525.Text = "Suppl. MV on Current MV List"
    '
    'BtnTA524
    '
    Me.BtnTA524.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA524.Location = New System.Drawing.Point(14, 199)
    Me.BtnTA524.Name = "BtnTA524"
    Me.BtnTA524.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA524.TabIndex = 46
    Me.BtnTA524.Text = "Suppl. MV on Previous MV List"
    '
    'BtnTA5078
    '
    Me.BtnTA5078.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5078.Location = New System.Drawing.Point(281, 46)
    Me.BtnTA5078.Name = "BtnTA5078"
    Me.BtnTA5078.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA5078.TabIndex = 45
    Me.BtnTA5078.Text = "Selected Zip Code"
    '
    'BtnTA521
    '
    Me.BtnTA521.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA521.Location = New System.Drawing.Point(281, 172)
    Me.BtnTA521.Name = "BtnTA521"
    Me.BtnTA521.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA521.TabIndex = 44
    Me.BtnTA521.Text = "Suppl. MV with C/C Number List"
    '
    'BtnTA530
    '
    Me.BtnTA530.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA530.Location = New System.Drawing.Point(14, 169)
    Me.BtnTA530.Name = "BtnTA530"
    Me.BtnTA530.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA530.TabIndex = 43
    Me.BtnTA530.Text = "Print NADA Error List"
    '
    'BtnTA5077
    '
    Me.BtnTA5077.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5077.Location = New System.Drawing.Point(281, 141)
    Me.BtnTA5077.Name = "BtnTA5077"
    Me.BtnTA5077.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA5077.TabIndex = 42
    Me.BtnTA5077.Text = "No Value List"
    '
    'BtnTA514
    '
    Me.BtnTA514.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA514.Location = New System.Drawing.Point(281, 79)
    Me.BtnTA514.Name = "BtnTA514"
    Me.BtnTA514.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA514.TabIndex = 41
    Me.BtnTA514.Text = "Print Duplicate Vin No."
    '
    'BtnTA513
    '
    Me.BtnTA513.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA513.Location = New System.Drawing.Point(281, 111)
    Me.BtnTA513.Name = "BtnTA513"
    Me.BtnTA513.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA513.TabIndex = 40
    Me.BtnTA513.Text = "Print Selected Class List"
    '
    'BtnTA5076
    '
    Me.BtnTA5076.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5076.Location = New System.Drawing.Point(281, 17)
    Me.BtnTA5076.Name = "BtnTA5076"
    Me.BtnTA5076.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA5076.TabIndex = 39
    Me.BtnTA5076.Text = "Missing Zip Codes"
    '
    'BtnTA5075
    '
    Me.BtnTA5075.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5075.Location = New System.Drawing.Point(14, 140)
    Me.BtnTA5075.Name = "BtnTA5075"
    Me.BtnTA5075.Size = New System.Drawing.Size(248, 23)
    Me.BtnTA5075.TabIndex = 38
    Me.BtnTA5075.Text = "Unknown District"
    '
    'BtnTA5074
    '
    Me.BtnTA5074.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5074.Location = New System.Drawing.Point(14, 109)
    Me.BtnTA5074.Name = "BtnTA5074"
    Me.BtnTA5074.Size = New System.Drawing.Size(248, 23)
    Me.BtnTA5074.TabIndex = 37
    Me.BtnTA5074.Text = "Out of Town"
    '
    'BtnTA5073
    '
    Me.BtnTA5073.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5073.Location = New System.Drawing.Point(14, 79)
    Me.BtnTA5073.Name = "BtnTA5073"
    Me.BtnTA5073.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA5073.TabIndex = 36
    Me.BtnTA5073.Text = "Duplicate Registration"
    '
    'BtnTA5072
    '
    Me.BtnTA5072.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5072.Location = New System.Drawing.Point(14, 46)
    Me.BtnTA5072.Name = "BtnTA5072"
    Me.BtnTA5072.Size = New System.Drawing.Size(248, 23)
    Me.BtnTA5072.TabIndex = 35
    Me.BtnTA5072.Text = "Owner Name"
    '
    'BtnTA5071
    '
    Me.BtnTA5071.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA5071.Location = New System.Drawing.Point(14, 17)
    Me.BtnTA5071.Name = "BtnTA5071"
    Me.BtnTA5071.Size = New System.Drawing.Size(248, 23)
    Me.BtnTA5071.TabIndex = 34
    Me.BtnTA5071.Text = "Class/Make"
    '
    'tabPage6
    '
    Me.tabPage6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage6.Controls.Add(Me.TabControl1)
    Me.tabPage6.Controls.Add(Me.label7)
    Me.tabPage6.Location = New System.Drawing.Point(4, 53)
    Me.tabPage6.Name = "tabPage6"
    Me.tabPage6.Size = New System.Drawing.Size(579, 398)
    Me.tabPage6.TabIndex = 7
    Me.tabPage6.Text = "Utilities"
    Me.tabPage6.UseVisualStyleBackColor = True
    Me.tabPage6.Visible = False
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPgMain)
    Me.TabControl1.Controls.Add(Me.TabPgRE)
    Me.TabControl1.Controls.Add(Me.TabPgPP)
    Me.TabControl1.Controls.Add(Me.TabpgMV)
    Me.TabControl1.Controls.Add(Me.TabPgSuppl)
    Me.TabControl1.Location = New System.Drawing.Point(30, 35)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(542, 319)
    Me.TabControl1.TabIndex = 19
    '
    'TabPgMain
    '
    Me.TabPgMain.Controls.Add(Me.btntad03)
    Me.TabPgMain.Controls.Add(Me.BtnTO301)
    Me.TabPgMain.Controls.Add(Me.BtnTO300)
    Me.TabPgMain.Controls.Add(Me.BtnTA221)
    Me.TabPgMain.Controls.Add(Me.BtnTA222)
    Me.TabPgMain.Controls.Add(Me.btnta220)
    Me.TabPgMain.Controls.Add(Me.btntad01)
    Me.TabPgMain.Controls.Add(Me.btntad02)
    Me.TabPgMain.Location = New System.Drawing.Point(4, 24)
    Me.TabPgMain.Name = "TabPgMain"
    Me.TabPgMain.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPgMain.Size = New System.Drawing.Size(534, 291)
    Me.TabPgMain.TabIndex = 0
    Me.TabPgMain.Text = "Main"
    Me.TabPgMain.UseVisualStyleBackColor = True
    '
    'btntad03
    '
    Me.btntad03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntad03.Location = New System.Drawing.Point(38, 62)
    Me.btntad03.Name = "btntad03"
    Me.btntad03.Size = New System.Drawing.Size(334, 24)
    Me.btntad03.TabIndex = 39
    Me.btntad03.Text = "Update Freeze with BAA"
    '
    'BtnTO301
    '
    Me.BtnTO301.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO301.ForeColor = System.Drawing.Color.Black
    Me.BtnTO301.Location = New System.Drawing.Point(38, 210)
    Me.BtnTO301.Name = "BtnTO301"
    Me.BtnTO301.Size = New System.Drawing.Size(334, 24)
    Me.BtnTO301.TabIndex = 38
    Me.BtnTO301.Text = "Maintain DMV Vehicle Data"
    '
    'BtnTO300
    '
    Me.BtnTO300.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO300.ForeColor = System.Drawing.Color.Black
    Me.BtnTO300.Location = New System.Drawing.Point(38, 180)
    Me.BtnTO300.Name = "BtnTO300"
    Me.BtnTO300.Size = New System.Drawing.Size(334, 24)
    Me.BtnTO300.TabIndex = 37
    Me.BtnTO300.Text = "Maintain DMV Customer Data"
    '
    'BtnTA221
    '
    Me.BtnTA221.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA221.Location = New System.Drawing.Point(38, 121)
    Me.BtnTA221.Name = "BtnTA221"
    Me.BtnTA221.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA221.TabIndex = 23
    Me.BtnTA221.Text = "Save/Delete Transfers"
    '
    'BtnTA222
    '
    Me.BtnTA222.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA222.Location = New System.Drawing.Point(38, 150)
    Me.BtnTA222.Name = "BtnTA222"
    Me.BtnTA222.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA222.TabIndex = 22
    Me.BtnTA222.Text = "Clear BTR data for Informal Notice"
    '
    'btnta220
    '
    Me.btnta220.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnta220.Location = New System.Drawing.Point(38, 92)
    Me.btnta220.Name = "btnta220"
    Me.btnta220.Size = New System.Drawing.Size(334, 24)
    Me.btnta220.TabIndex = 21
    Me.btnta220.Text = "Merge Transfers"
    '
    'btntad01
    '
    Me.btntad01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntad01.Location = New System.Drawing.Point(38, 32)
    Me.btntad01.Name = "btntad01"
    Me.btntad01.Size = New System.Drawing.Size(334, 24)
    Me.btntad01.TabIndex = 20
    Me.btntad01.Text = "Freeze"
    '
    'btntad02
    '
    Me.btntad02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btntad02.Location = New System.Drawing.Point(38, 6)
    Me.btntad02.Name = "btntad02"
    Me.btntad02.Size = New System.Drawing.Size(334, 24)
    Me.btntad02.TabIndex = 19
    Me.btntad02.Text = "Soft Freeze (Before B.A.A. Changes)"
    '
    'TabPgRE
    '
    Me.TabPgRE.Controls.Add(Me.BtnTA238)
    Me.TabPgRE.Controls.Add(Me.BtnTA231)
    Me.TabPgRE.Controls.Add(Me.BtnTA236)
    Me.TabPgRE.Controls.Add(Me.BtnTA202)
    Me.TabPgRE.Location = New System.Drawing.Point(4, 22)
    Me.TabPgRE.Name = "TabPgRE"
    Me.TabPgRE.Size = New System.Drawing.Size(534, 293)
    Me.TabPgRE.TabIndex = 3
    Me.TabPgRE.Text = "Real Estate"
    Me.TabPgRE.UseVisualStyleBackColor = True
    '
    'BtnTA238
    '
    Me.BtnTA238.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA238.Location = New System.Drawing.Point(47, 104)
    Me.BtnTA238.Name = "BtnTA238"
    Me.BtnTA238.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA238.TabIndex = 25
    Me.BtnTA238.Text = "Apply Penalty"
    '
    'BtnTA231
    '
    Me.BtnTA231.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA231.Location = New System.Drawing.Point(47, 44)
    Me.BtnTA231.Name = "BtnTA231"
    Me.BtnTA231.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA231.TabIndex = 24
    Me.BtnTA231.Text = "Mass Remove Elderly State Benefit"
    '
    'BtnTA236
    '
    Me.BtnTA236.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA236.Location = New System.Drawing.Point(47, 74)
    Me.BtnTA236.Name = "BtnTA236"
    Me.BtnTA236.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA236.TabIndex = 23
    Me.BtnTA236.Text = "Mass Update or Recalc Local Benefit"
    '
    'BtnTA202
    '
    Me.BtnTA202.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA202.Location = New System.Drawing.Point(47, 14)
    Me.BtnTA202.Name = "BtnTA202"
    Me.BtnTA202.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA202.TabIndex = 21
    Me.BtnTA202.Text = "Maintain Elderly/Local Benefits"
    '
    'TabPgPP
    '
    Me.TabPgPP.Controls.Add(Me.BtnTA304)
    Me.TabPgPP.Location = New System.Drawing.Point(4, 22)
    Me.TabPgPP.Name = "TabPgPP"
    Me.TabPgPP.Size = New System.Drawing.Size(534, 293)
    Me.TabPgPP.TabIndex = 4
    Me.TabPgPP.Text = "Personal Property"
    Me.TabPgPP.UseVisualStyleBackColor = True
    '
    'BtnTA304
    '
    Me.BtnTA304.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA304.Location = New System.Drawing.Point(47, 14)
    Me.BtnTA304.Name = "BtnTA304"
    Me.BtnTA304.Size = New System.Drawing.Size(334, 24)
    Me.BtnTA304.TabIndex = 22
    Me.BtnTA304.Text = "Apply Penalty"
    '
    'TabpgMV
    '
    Me.TabpgMV.Controls.Add(Me.BtnTA440)
    Me.TabpgMV.Controls.Add(Me.BtnTA432)
    Me.TabpgMV.Controls.Add(Me.BtnTA431)
    Me.TabpgMV.Controls.Add(Me.BtnTA421)
    Me.TabpgMV.Controls.Add(Me.BtnTA420)
    Me.TabpgMV.Controls.Add(Me.BtnTA406)
    Me.TabpgMV.Controls.Add(Me.BtnTA404)
    Me.TabpgMV.Controls.Add(Me.BtnTA403)
    Me.TabpgMV.Controls.Add(Me.BtnTA402)
    Me.TabpgMV.Location = New System.Drawing.Point(4, 24)
    Me.TabpgMV.Name = "TabpgMV"
    Me.TabpgMV.Padding = New System.Windows.Forms.Padding(3)
    Me.TabpgMV.Size = New System.Drawing.Size(534, 291)
    Me.TabpgMV.TabIndex = 1
    Me.TabpgMV.Text = "MV"
    Me.TabpgMV.UseVisualStyleBackColor = True
    '
    'BtnTA432
    '
    Me.BtnTA432.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA432.Location = New System.Drawing.Point(21, 121)
    Me.BtnTA432.Name = "BtnTA432"
    Me.BtnTA432.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA432.TabIndex = 30
    Me.BtnTA432.Text = "Price using MSRP from Price Digest"
    '
    'BtnTA431
    '
    Me.BtnTA431.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA431.Location = New System.Drawing.Point(21, 181)
    Me.BtnTA431.Name = "BtnTA431"
    Me.BtnTA431.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA431.TabIndex = 29
    Me.BtnTA431.Text = "Round priced values"
    '
    'BtnTA421
    '
    Me.BtnTA421.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA421.Location = New System.Drawing.Point(287, 6)
    Me.BtnTA421.Name = "BtnTA421"
    Me.BtnTA421.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA421.TabIndex = 27
    Me.BtnTA421.Text = "List/Purge Transfers"
    '
    'BtnTA420
    '
    Me.BtnTA420.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA420.Location = New System.Drawing.Point(21, 151)
    Me.BtnTA420.Name = "BtnTA420"
    Me.BtnTA420.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA420.TabIndex = 26
    Me.BtnTA420.Text = "Auto Pricing of Unpriced Vehicles "
    '
    'BtnTA406
    '
    Me.BtnTA406.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA406.Location = New System.Drawing.Point(21, 91)
    Me.BtnTA406.Name = "BtnTA406"
    Me.BtnTA406.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA406.TabIndex = 25
    Me.BtnTA406.Text = "Unpriced List"
    '
    'BtnTA404
    '
    Me.BtnTA404.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA404.Location = New System.Drawing.Point(21, 61)
    Me.BtnTA404.Name = "BtnTA404"
    Me.BtnTA404.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA404.TabIndex = 23
    Me.BtnTA404.Text = "Update Exemptions"
    '
    'BtnTA403
    '
    Me.BtnTA403.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA403.Location = New System.Drawing.Point(21, 32)
    Me.BtnTA403.Name = "BtnTA403"
    Me.BtnTA403.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA403.TabIndex = 22
    Me.BtnTA403.Text = "Resequence List Numbers"
    '
    'BtnTA402
    '
    Me.BtnTA402.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA402.Location = New System.Drawing.Point(21, 6)
    Me.BtnTA402.Name = "BtnTA402"
    Me.BtnTA402.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA402.TabIndex = 21
    Me.BtnTA402.Text = "Install New MVD File"
    '
    'TabPgSuppl
    '
    Me.TabPgSuppl.Controls.Add(Me.BtnTA540)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA531)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA520)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA518)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA523)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA509)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA519)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA506)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA504)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA503)
    Me.TabPgSuppl.Controls.Add(Me.BtnTA502)
    Me.TabPgSuppl.Location = New System.Drawing.Point(4, 24)
    Me.TabPgSuppl.Name = "TabPgSuppl"
    Me.TabPgSuppl.Size = New System.Drawing.Size(534, 291)
    Me.TabPgSuppl.TabIndex = 2
    Me.TabPgSuppl.Text = "Suppl MV"
    Me.TabPgSuppl.UseVisualStyleBackColor = True
    '
    'BtnTA531
    '
    Me.BtnTA531.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA531.Location = New System.Drawing.Point(23, 236)
    Me.BtnTA531.Name = "BtnTA531"
    Me.BtnTA531.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA531.TabIndex = 38
    Me.BtnTA531.Text = "Round priced values"
    '
    'BtnTA520
    '
    Me.BtnTA520.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA520.Location = New System.Drawing.Point(287, 3)
    Me.BtnTA520.Name = "BtnTA520"
    Me.BtnTA520.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA520.TabIndex = 37
    Me.BtnTA520.Text = "List/Purge Transfers "
    '
    'BtnTA518
    '
    Me.BtnTA518.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA518.Location = New System.Drawing.Point(23, 206)
    Me.BtnTA518.Name = "BtnTA518"
    Me.BtnTA518.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA518.TabIndex = 36
    Me.BtnTA518.Text = "Unpriced or All Assessment Codes N-W "
    '
    'BtnTA523
    '
    Me.BtnTA523.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA523.Location = New System.Drawing.Point(23, 176)
    Me.BtnTA523.Name = "BtnTA523"
    Me.BtnTA523.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA523.TabIndex = 35
    Me.BtnTA523.Text = "Price Unpriced using MSRP"
    '
    'BtnTA509
    '
    Me.BtnTA509.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA509.Location = New System.Drawing.Point(23, 147)
    Me.BtnTA509.Name = "BtnTA509"
    Me.BtnTA509.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA509.TabIndex = 34
    Me.BtnTA509.Text = "Unpriced List"
    '
    'BtnTA519
    '
    Me.BtnTA519.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA519.Location = New System.Drawing.Point(23, 118)
    Me.BtnTA519.Name = "BtnTA519"
    Me.BtnTA519.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA519.TabIndex = 33
    Me.BtnTA519.Text = "Auto Pricing of Unpriced Vehicles "
    '
    'BtnTA506
    '
    Me.BtnTA506.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA506.Location = New System.Drawing.Point(23, 89)
    Me.BtnTA506.Name = "BtnTA506"
    Me.BtnTA506.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA506.TabIndex = 32
    Me.BtnTA506.Text = "Unpriced Credit Vehicles"
    '
    'BtnTA504
    '
    Me.BtnTA504.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA504.Location = New System.Drawing.Point(23, 59)
    Me.BtnTA504.Name = "BtnTA504"
    Me.BtnTA504.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA504.TabIndex = 30
    Me.BtnTA504.Text = "Change Assessment Code K && L to A"
    '
    'BtnTA503
    '
    Me.BtnTA503.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA503.Location = New System.Drawing.Point(23, 30)
    Me.BtnTA503.Name = "BtnTA503"
    Me.BtnTA503.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA503.TabIndex = 29
    Me.BtnTA503.Text = "Resequence List Numbers"
    '
    'BtnTA502
    '
    Me.BtnTA502.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA502.Location = New System.Drawing.Point(23, 3)
    Me.BtnTA502.Name = "BtnTA502"
    Me.BtnTA502.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA502.TabIndex = 22
    Me.BtnTA502.Text = "Install New MVD File"
    '
    'label7
    '
    Me.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label7.ForeColor = System.Drawing.Color.Maroon
    Me.label7.Image = CType(resources.GetObject("label7.Image"), System.Drawing.Image)
    Me.label7.Location = New System.Drawing.Point(0, 0)
    Me.label7.Name = "label7"
    Me.label7.Size = New System.Drawing.Size(528, 32)
    Me.label7.TabIndex = 6
    '
    'tabPage8
    '
    Me.tabPage8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage8.Controls.Add(Me.BtnTAP28)
    Me.tabPage8.Controls.Add(Me.BtnTA941)
    Me.tabPage8.Controls.Add(Me.BtnTA940)
    Me.tabPage8.Controls.Add(Me.BtnTA904)
    Me.tabPage8.Controls.Add(Me.BtnTA901)
    Me.tabPage8.Controls.Add(Me.BtnTA902)
    Me.tabPage8.Controls.Add(Me.BtnTA903)
    Me.tabPage8.Controls.Add(Me.label8)
    Me.tabPage8.Location = New System.Drawing.Point(4, 53)
    Me.tabPage8.Name = "tabPage8"
    Me.tabPage8.Size = New System.Drawing.Size(579, 398)
    Me.tabPage8.TabIndex = 9
    Me.tabPage8.Text = "Extracts"
    Me.tabPage8.UseVisualStyleBackColor = True
    Me.tabPage8.Visible = False
    '
    'BtnTAP28
    '
    Me.BtnTAP28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP28.Location = New System.Drawing.Point(144, 206)
    Me.BtnTAP28.Name = "BtnTAP28"
    Me.BtnTAP28.Size = New System.Drawing.Size(272, 24)
    Me.BtnTAP28.TabIndex = 15
    Me.BtnTAP28.Text = "Personal Property Declarations File"
    '
    'BtnTA941
    '
    Me.BtnTA941.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA941.Location = New System.Drawing.Point(144, 266)
    Me.BtnTA941.Name = "BtnTA941"
    Me.BtnTA941.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA941.TabIndex = 14
    Me.BtnTA941.Text = "Import VIN Decoder Values"
    '
    'BtnTA940
    '
    Me.BtnTA940.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA940.Location = New System.Drawing.Point(144, 236)
    Me.BtnTA940.Name = "BtnTA940"
    Me.BtnTA940.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA940.TabIndex = 13
    Me.BtnTA940.Text = "Create VIN Decoder File"
    '
    'BtnTA904
    '
    Me.BtnTA904.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA904.Location = New System.Drawing.Point(144, 176)
    Me.BtnTA904.Name = "BtnTA904"
    Me.BtnTA904.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA904.TabIndex = 12
    Me.BtnTA904.Text = "Supplemental MV Grand List File"
    '
    'BtnTA901
    '
    Me.BtnTA901.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA901.Location = New System.Drawing.Point(144, 86)
    Me.BtnTA901.Name = "BtnTA901"
    Me.BtnTA901.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA901.TabIndex = 11
    Me.BtnTA901.Text = "Real Estate Grand List File"
    '
    'BtnTA902
    '
    Me.BtnTA902.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA902.Location = New System.Drawing.Point(144, 116)
    Me.BtnTA902.Name = "BtnTA902"
    Me.BtnTA902.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA902.TabIndex = 10
    Me.BtnTA902.Text = "Personal Property Grand List File"
    '
    'BtnTA903
    '
    Me.BtnTA903.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA903.Location = New System.Drawing.Point(144, 146)
    Me.BtnTA903.Name = "BtnTA903"
    Me.BtnTA903.Size = New System.Drawing.Size(272, 24)
    Me.BtnTA903.TabIndex = 7
    Me.BtnTA903.Text = "Motor Vehicle Grand List File"
    '
    'label8
    '
    Me.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label8.ForeColor = System.Drawing.Color.Maroon
    Me.label8.Image = CType(resources.GetObject("label8.Image"), System.Drawing.Image)
    Me.label8.Location = New System.Drawing.Point(0, 0)
    Me.label8.Name = "label8"
    Me.label8.Size = New System.Drawing.Size(536, 32)
    Me.label8.TabIndex = 6
    '
    'tabfilemaintenance
    '
    Me.tabfilemaintenance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabfilemaintenance.Controls.Add(Me.btntac01)
    Me.tabfilemaintenance.Controls.Add(Me.label2)
    Me.tabfilemaintenance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tabfilemaintenance.Location = New System.Drawing.Point(4, 53)
    Me.tabfilemaintenance.Name = "tabfilemaintenance"
    Me.tabfilemaintenance.Size = New System.Drawing.Size(579, 398)
    Me.tabfilemaintenance.TabIndex = 1
    Me.tabfilemaintenance.Text = "Cama Interface"
    Me.tabfilemaintenance.UseVisualStyleBackColor = True
    Me.tabfilemaintenance.Visible = False
    '
    'btntac01
    '
    Me.btntac01.ForeColor = System.Drawing.Color.Black
    Me.btntac01.Location = New System.Drawing.Point(142, 146)
    Me.btntac01.Name = "btntac01"
    Me.btntac01.Size = New System.Drawing.Size(248, 24)
    Me.btntac01.TabIndex = 8
    Me.btntac01.Text = "Import Cama Data"
    '
    'label2
    '
    Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label2.ForeColor = System.Drawing.Color.Maroon
    Me.label2.Image = CType(resources.GetObject("label2.Image"), System.Drawing.Image)
    Me.label2.Location = New System.Drawing.Point(0, 0)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(528, 32)
    Me.label2.TabIndex = 6
    '
    'tabPage11
    '
    Me.tabPage11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.tabPage11.Controls.Add(Me.BtnTAE02)
    Me.tabPage11.Controls.Add(Me.BtnTAE01)
    Me.tabPage11.Controls.Add(Me.label9)
    Me.tabPage11.Location = New System.Drawing.Point(4, 53)
    Me.tabPage11.Name = "tabPage11"
    Me.tabPage11.Size = New System.Drawing.Size(579, 398)
    Me.tabPage11.TabIndex = 10
    Me.tabPage11.Text = "Prorations"
    Me.tabPage11.UseVisualStyleBackColor = True
    Me.tabPage11.Visible = False
    '
    'BtnTAE02
    '
    Me.BtnTAE02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAE02.Location = New System.Drawing.Point(144, 192)
    Me.BtnTAE02.Name = "BtnTAE02"
    Me.BtnTAE02.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAE02.TabIndex = 23
    Me.BtnTAE02.Text = "Print Prorations"
    '
    'BtnTAE01
    '
    Me.BtnTAE01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAE01.Location = New System.Drawing.Point(144, 160)
    Me.BtnTAE01.Name = "BtnTAE01"
    Me.BtnTAE01.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAE01.TabIndex = 22
    Me.BtnTAE01.Text = "Maintain Prorations"
    '
    'label9
    '
    Me.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label9.ForeColor = System.Drawing.Color.Maroon
    Me.label9.Image = CType(resources.GetObject("label9.Image"), System.Drawing.Image)
    Me.label9.Location = New System.Drawing.Point(8, 8)
    Me.label9.Name = "label9"
    Me.label9.Size = New System.Drawing.Size(536, 32)
    Me.label9.TabIndex = 6
    '
    'TabPage4
    '
    Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TabPage4.Controls.Add(Me.BtnTO221)
    Me.TabPage4.Controls.Add(Me.BtnTO220)
    Me.TabPage4.Controls.Add(Me.BtnTAP29)
    Me.TabPage4.Controls.Add(Me.BtnTO208)
    Me.TabPage4.Controls.Add(Me.BtnTO207)
    Me.TabPage4.Controls.Add(Me.BtnTO205)
    Me.TabPage4.Controls.Add(Me.BtnTO204)
    Me.TabPage4.Controls.Add(Me.BtnTO202)
    Me.TabPage4.Controls.Add(Me.BtnTO203)
    Me.TabPage4.Controls.Add(Me.BtnTO201)
    Me.TabPage4.Controls.Add(Me.BtnTO200)
    Me.TabPage4.Location = New System.Drawing.Point(4, 53)
    Me.TabPage4.Name = "TabPage4"
    Me.TabPage4.Size = New System.Drawing.Size(579, 398)
    Me.TabPage4.TabIndex = 11
    Me.TabPage4.Text = "OPM"
    Me.TabPage4.UseVisualStyleBackColor = True
    '
    'BtnTO221
    '
    Me.BtnTO221.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO221.Location = New System.Drawing.Point(152, 341)
    Me.BtnTO221.Name = "BtnTO221"
    Me.BtnTO221.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO221.TabIndex = 11
    Me.BtnTO221.Text = "Maintain Local Freeze"
    '
    'BtnTO220
    '
    Me.BtnTO220.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO220.Location = New System.Drawing.Point(152, 311)
    Me.BtnTO220.Name = "BtnTO220"
    Me.BtnTO220.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO220.TabIndex = 10
    Me.BtnTO220.Text = "Maintain Local Deferral"
    '
    'BtnTAP29
    '
    Me.BtnTAP29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP29.Location = New System.Drawing.Point(152, 191)
    Me.BtnTAP29.Name = "BtnTAP29"
    Me.BtnTAP29.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP29.TabIndex = 9
    Me.BtnTAP29.Text = "Remove Local Benefits"
    '
    'BtnTO208
    '
    Me.BtnTO208.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO208.Location = New System.Drawing.Point(152, 281)
    Me.BtnTO208.Name = "BtnTO208"
    Me.BtnTO208.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO208.TabIndex = 8
    Me.BtnTO208.Text = "Print M59A Forms"
    '
    'BtnTO207
    '
    Me.BtnTO207.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO207.Location = New System.Drawing.Point(152, 251)
    Me.BtnTO207.Name = "BtnTO207"
    Me.BtnTO207.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO207.TabIndex = 7
    Me.BtnTO207.Text = "Create M59A Electronic File"
    '
    'BtnTO205
    '
    Me.BtnTO205.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO205.Location = New System.Drawing.Point(152, 161)
    Me.BtnTO205.Name = "BtnTO205"
    Me.BtnTO205.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO205.TabIndex = 6
    Me.BtnTO205.Text = "Recalc M35H Benefit or Print forms"
    '
    'BtnTO204
    '
    Me.BtnTO204.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO204.Location = New System.Drawing.Point(152, 221)
    Me.BtnTO204.Name = "BtnTO204"
    Me.BtnTO204.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO204.TabIndex = 5
    Me.BtnTO204.Text = "Maintain M59A - Addl. Veteran's"
    '
    'BtnTO202
    '
    Me.BtnTO202.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO202.Location = New System.Drawing.Point(152, 131)
    Me.BtnTO202.Name = "BtnTO202"
    Me.BtnTO202.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO202.TabIndex = 4
    Me.BtnTO202.Text = "Create M35H Electronic File"
    '
    'BtnTO203
    '
    Me.BtnTO203.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO203.Location = New System.Drawing.Point(152, 101)
    Me.BtnTO203.Name = "BtnTO203"
    Me.BtnTO203.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO203.TabIndex = 3
    Me.BtnTO203.Text = "Maintain M35H - Exemption Breakout"
    '
    'BtnTO201
    '
    Me.BtnTO201.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO201.Location = New System.Drawing.Point(152, 71)
    Me.BtnTO201.Name = "BtnTO201"
    Me.BtnTO201.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO201.TabIndex = 2
    Me.BtnTO201.Text = "Maintain M35H - Elderly Homeowner"
    '
    'BtnTO200
    '
    Me.BtnTO200.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTO200.Location = New System.Drawing.Point(152, 41)
    Me.BtnTO200.Name = "BtnTO200"
    Me.BtnTO200.Size = New System.Drawing.Size(248, 24)
    Me.BtnTO200.TabIndex = 1
    Me.BtnTO200.Text = "Maintain OPM Contact Info"
    '
    'TabPage20
    '
    Me.TabPage20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.TabPage20.Controls.Add(Me.TabControl3)
    Me.TabPage20.Location = New System.Drawing.Point(4, 53)
    Me.TabPage20.Name = "TabPage20"
    Me.TabPage20.Size = New System.Drawing.Size(579, 398)
    Me.TabPage20.TabIndex = 12
    Me.TabPage20.Text = "PP Declaration"
    Me.TabPage20.UseVisualStyleBackColor = True
    '
    'TabControl3
    '
    Me.TabControl3.Appearance = System.Windows.Forms.TabAppearance.Buttons
    Me.TabControl3.Controls.Add(Me.TabPage5)
    Me.TabControl3.Controls.Add(Me.TabPage7)
    Me.TabControl3.Controls.Add(Me.TabPage9)
    Me.TabControl3.Controls.Add(Me.TabPage10)
    Me.TabControl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabControl3.ItemSize = New System.Drawing.Size(62, 23)
    Me.TabControl3.Location = New System.Drawing.Point(16, 37)
    Me.TabControl3.Name = "TabControl3"
    Me.TabControl3.SelectedIndex = 0
    Me.TabControl3.Size = New System.Drawing.Size(556, 315)
    Me.TabControl3.TabIndex = 11
    '
    'TabPage5
    '
    Me.TabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TabPage5.Controls.Add(Me.BtnTAP02)
    Me.TabPage5.Controls.Add(Me.BtnTAP03)
    Me.TabPage5.Controls.Add(Me.BtnTAP01)
    Me.TabPage5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabPage5.Location = New System.Drawing.Point(4, 27)
    Me.TabPage5.Name = "TabPage5"
    Me.TabPage5.Size = New System.Drawing.Size(548, 284)
    Me.TabPage5.TabIndex = 0
    Me.TabPage5.Text = "Forms"
    Me.TabPage5.UseVisualStyleBackColor = True
    '
    'BtnTAP02
    '
    Me.BtnTAP02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP02.Location = New System.Drawing.Point(154, 52)
    Me.BtnTAP02.Name = "BtnTAP02"
    Me.BtnTAP02.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP02.TabIndex = 11
    Me.BtnTAP02.Text = "Maintain Mfg & Equip (M-65)"
    Me.BtnTAP02.UseMnemonic = False
    '
    'BtnTAP03
    '
    Me.BtnTAP03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP03.Location = New System.Drawing.Point(154, 82)
    Me.BtnTAP03.Name = "BtnTAP03"
    Me.BtnTAP03.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP03.TabIndex = 10
    Me.BtnTAP03.Text = "Maintain Motor Vehicle"
    '
    'BtnTAP01
    '
    Me.BtnTAP01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP01.Location = New System.Drawing.Point(154, 22)
    Me.BtnTAP01.Name = "BtnTAP01"
    Me.BtnTAP01.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP01.TabIndex = 7
    Me.BtnTAP01.Text = "Maintain PP Declaration"
    '
    'TabPage7
    '
    Me.TabPage7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TabPage7.Controls.Add(Me.BtnTAP17)
    Me.TabPage7.Controls.Add(Me.BtnTAP16)
    Me.TabPage7.Controls.Add(Me.BtnTAP15)
    Me.TabPage7.Controls.Add(Me.BtnTAP14)
    Me.TabPage7.Controls.Add(Me.BtnTAP13)
    Me.TabPage7.Controls.Add(Me.BtnTAP12)
    Me.TabPage7.Controls.Add(Me.BtnTAP11)
    Me.TabPage7.Controls.Add(Me.BtnTAP10)
    Me.TabPage7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabPage7.Location = New System.Drawing.Point(4, 27)
    Me.TabPage7.Name = "TabPage7"
    Me.TabPage7.Size = New System.Drawing.Size(548, 284)
    Me.TabPage7.TabIndex = 1
    Me.TabPage7.Text = "Tables"
    Me.TabPage7.UseVisualStyleBackColor = True
    Me.TabPage7.Visible = False
    '
    'BtnTAP17
    '
    Me.BtnTAP17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP17.Location = New System.Drawing.Point(284, 105)
    Me.BtnTAP17.Name = "BtnTAP17"
    Me.BtnTAP17.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP17.TabIndex = 18
    Me.BtnTAP17.Text = "Maintain MV Property Codes"
    '
    'BtnTAP16
    '
    Me.BtnTAP16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP16.Location = New System.Drawing.Point(284, 76)
    Me.BtnTAP16.Name = "BtnTAP16"
    Me.BtnTAP16.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP16.TabIndex = 17
    Me.BtnTAP16.Text = "Maintain Mfg & Equip - Depreciation"
    Me.BtnTAP16.UseMnemonic = False
    '
    'BtnTAP15
    '
    Me.BtnTAP15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP15.Location = New System.Drawing.Point(284, 45)
    Me.BtnTAP15.Name = "BtnTAP15"
    Me.BtnTAP15.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP15.TabIndex = 16
    Me.BtnTAP15.Text = "Maintain Mfg & Equip - Property Codes"
    Me.BtnTAP15.UseMnemonic = False
    '
    'BtnTAP14
    '
    Me.BtnTAP14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP14.Location = New System.Drawing.Point(284, 15)
    Me.BtnTAP14.Name = "BtnTAP14"
    Me.BtnTAP14.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP14.TabIndex = 15
    Me.BtnTAP14.Text = "Maintain Mfg & Equip - Lessors"
    Me.BtnTAP14.UseMnemonic = False
    '
    'BtnTAP13
    '
    Me.BtnTAP13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP13.Location = New System.Drawing.Point(12, 15)
    Me.BtnTAP13.Name = "BtnTAP13"
    Me.BtnTAP13.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP13.TabIndex = 14
    Me.BtnTAP13.Text = "Maintain Default Form Information"
    '
    'BtnTAP12
    '
    Me.BtnTAP12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP12.Location = New System.Drawing.Point(12, 105)
    Me.BtnTAP12.Name = "BtnTAP12"
    Me.BtnTAP12.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP12.TabIndex = 13
    Me.BtnTAP12.Text = "Maintain Exemptions"
    '
    'BtnTAP11
    '
    Me.BtnTAP11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP11.Location = New System.Drawing.Point(12, 75)
    Me.BtnTAP11.Name = "BtnTAP11"
    Me.BtnTAP11.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP11.TabIndex = 12
    Me.BtnTAP11.Text = "Maintain Depreciation"
    '
    'BtnTAP10
    '
    Me.BtnTAP10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP10.Location = New System.Drawing.Point(12, 45)
    Me.BtnTAP10.Name = "BtnTAP10"
    Me.BtnTAP10.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP10.TabIndex = 11
    Me.BtnTAP10.Text = "Maintain Property Codes"
    '
    'TabPage9
    '
    Me.TabPage9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TabPage9.Controls.Add(Me.BtnTAP27)
    Me.TabPage9.Controls.Add(Me.BtnTAP26)
    Me.TabPage9.Controls.Add(Me.BtnTAP25)
    Me.TabPage9.Controls.Add(Me.BtnTAP24)
    Me.TabPage9.Controls.Add(Me.BtnTAP23)
    Me.TabPage9.Controls.Add(Me.BtnTAP22)
    Me.TabPage9.Controls.Add(Me.BtnTAP21)
    Me.TabPage9.Controls.Add(Me.BtnTAP20)
    Me.TabPage9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TabPage9.Location = New System.Drawing.Point(4, 27)
    Me.TabPage9.Name = "TabPage9"
    Me.TabPage9.Size = New System.Drawing.Size(548, 284)
    Me.TabPage9.TabIndex = 2
    Me.TabPage9.Text = "Utilities"
    Me.TabPage9.UseVisualStyleBackColor = True
    Me.TabPage9.Visible = False
    '
    'BtnTAP27
    '
    Me.BtnTAP27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP27.Location = New System.Drawing.Point(155, 134)
    Me.BtnTAP27.Name = "BtnTAP27"
    Me.BtnTAP27.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP27.TabIndex = 16
    Me.BtnTAP27.Text = "Print Depreciated Codes by Year"
    '
    'BtnTAP26
    '
    Me.BtnTAP26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP26.Location = New System.Drawing.Point(155, 104)
    Me.BtnTAP26.Name = "BtnTAP26"
    Me.BtnTAP26.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP26.TabIndex = 15
    Me.BtnTAP26.Text = "Print Year to Year Codes"
    '
    'BtnTAP25
    '
    Me.BtnTAP25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP25.Location = New System.Drawing.Point(155, 224)
    Me.BtnTAP25.Name = "BtnTAP25"
    Me.BtnTAP25.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP25.TabIndex = 14
    Me.BtnTAP25.Text = "Apply Penalty"
    '
    'BtnTAP24
    '
    Me.BtnTAP24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP24.Location = New System.Drawing.Point(155, 194)
    Me.BtnTAP24.Name = "BtnTAP24"
    Me.BtnTAP24.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP24.TabIndex = 13
    Me.BtnTAP24.Text = "Print Declarations List"
    '
    'BtnTAP23
    '
    Me.BtnTAP23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP23.Location = New System.Drawing.Point(155, 164)
    Me.BtnTAP23.Name = "BtnTAP23"
    Me.BtnTAP23.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP23.TabIndex = 12
    Me.BtnTAP23.Text = "Create Mail Merge File"
    '
    'BtnTAP22
    '
    Me.BtnTAP22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP22.Location = New System.Drawing.Point(155, 74)
    Me.BtnTAP22.Name = "BtnTAP22"
    Me.BtnTAP22.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP22.TabIndex = 11
    Me.BtnTAP22.Text = "Print Summary vs. Detail"
    '
    'BtnTAP21
    '
    Me.BtnTAP21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP21.Location = New System.Drawing.Point(155, 44)
    Me.BtnTAP21.Name = "BtnTAP21"
    Me.BtnTAP21.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP21.TabIndex = 10
    Me.BtnTAP21.Text = "Copy Tables to New Year"
    '
    'BtnTAP20
    '
    Me.BtnTAP20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP20.Location = New System.Drawing.Point(155, 14)
    Me.BtnTAP20.Name = "BtnTAP20"
    Me.BtnTAP20.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP20.TabIndex = 9
    Me.BtnTAP20.Text = "Update Personal Property File"
    '
    'TabPage10
    '
    Me.TabPage10.Controls.Add(Me.BtnTAP30)
    Me.TabPage10.Location = New System.Drawing.Point(4, 27)
    Me.TabPage10.Name = "TabPage10"
    Me.TabPage10.Size = New System.Drawing.Size(548, 284)
    Me.TabPage10.TabIndex = 3
    Me.TabPage10.Text = "Import"
    Me.TabPage10.UseVisualStyleBackColor = True
    '
    'BtnTAP30
    '
    Me.BtnTAP30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAP30.Location = New System.Drawing.Point(140, 19)
    Me.BtnTAP30.Name = "BtnTAP30"
    Me.BtnTAP30.Size = New System.Drawing.Size(248, 24)
    Me.BtnTAP30.TabIndex = 10
    Me.BtnTAP30.Text = "Import Personal Property Declarations"
    '
    'TabPhaseIn
    '
    Me.TabPhaseIn.Controls.Add(Me.BtnTA233)
    Me.TabPhaseIn.Controls.Add(Me.BtnTA232)
    Me.TabPhaseIn.Location = New System.Drawing.Point(4, 53)
    Me.TabPhaseIn.Name = "TabPhaseIn"
    Me.TabPhaseIn.Size = New System.Drawing.Size(579, 398)
    Me.TabPhaseIn.TabIndex = 13
    Me.TabPhaseIn.Text = "Phase In"
    Me.TabPhaseIn.UseVisualStyleBackColor = True
    '
    'BtnTA233
    '
    Me.BtnTA233.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA233.Location = New System.Drawing.Point(155, 101)
    Me.BtnTA233.Name = "BtnTA233"
    Me.BtnTA233.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA233.TabIndex = 2
    Me.BtnTA233.Text = "Apply Phase In"
    '
    'BtnTA232
    '
    Me.BtnTA232.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA232.Location = New System.Drawing.Point(155, 71)
    Me.BtnTA232.Name = "BtnTA232"
    Me.BtnTA232.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA232.TabIndex = 1
    Me.BtnTA232.Text = "Load Assessments to Full Phase In"
    '
    'tabchglog
    '
    Me.tabchglog.Controls.Add(Me.BtnTA331)
    Me.tabchglog.Controls.Add(Me.BtnTA330)
    Me.tabchglog.Location = New System.Drawing.Point(4, 53)
    Me.tabchglog.Name = "tabchglog"
    Me.tabchglog.Size = New System.Drawing.Size(579, 398)
    Me.tabchglog.TabIndex = 14
    Me.tabchglog.Text = "Change Log"
    Me.tabchglog.UseVisualStyleBackColor = True
    '
    'BtnTA331
    '
    Me.BtnTA331.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA331.Location = New System.Drawing.Point(156, 99)
    Me.BtnTA331.Name = "BtnTA331"
    Me.BtnTA331.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA331.TabIndex = 3
    Me.BtnTA331.Text = "Print Master Files Change Log"
    '
    'BtnTA330
    '
    Me.BtnTA330.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA330.Location = New System.Drawing.Point(156, 69)
    Me.BtnTA330.Name = "BtnTA330"
    Me.BtnTA330.Size = New System.Drawing.Size(248, 24)
    Me.BtnTA330.TabIndex = 2
    Me.BtnTA330.Text = "View Master Files Change Log"
    '
    'TabArchive
    '
    Me.TabArchive.Controls.Add(Me.BtnTAD06)
    Me.TabArchive.Controls.Add(Me.BtnTAD05)
    Me.TabArchive.Controls.Add(Me.BtnTAD04)
    Me.TabArchive.Location = New System.Drawing.Point(4, 53)
    Me.TabArchive.Name = "TabArchive"
    Me.TabArchive.Size = New System.Drawing.Size(579, 398)
    Me.TabArchive.TabIndex = 16
    Me.TabArchive.Text = "Archive"
    Me.TabArchive.UseVisualStyleBackColor = True
    '
    'BtnTAD06
    '
    Me.BtnTAD06.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAD06.Location = New System.Drawing.Point(151, 82)
    Me.BtnTAD06.Name = "BtnTAD06"
    Me.BtnTAD06.Size = New System.Drawing.Size(248, 26)
    Me.BtnTAD06.TabIndex = 13
    Me.BtnTAD06.Text = "Archive Prorations Lookup"
    '
    'BtnTAD05
    '
    Me.BtnTAD05.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAD05.Location = New System.Drawing.Point(151, 50)
    Me.BtnTAD05.Name = "BtnTAD05"
    Me.BtnTAD05.Size = New System.Drawing.Size(248, 26)
    Me.BtnTAD05.TabIndex = 12
    Me.BtnTAD05.Text = "Archive Master Lookup"
    '
    'BtnTAD04
    '
    Me.BtnTAD04.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTAD04.Location = New System.Drawing.Point(151, 18)
    Me.BtnTAD04.Name = "BtnTAD04"
    Me.BtnTAD04.Size = New System.Drawing.Size(248, 26)
    Me.BtnTAD04.TabIndex = 11
    Me.BtnTAD04.Text = "Archive Assessor File(s)"
    '
    'TabCustom
    '
    Me.TabCustom.Controls.Add(Me.BtnTA601)
    Me.TabCustom.Controls.Add(Me.BtnTA600)
    Me.TabCustom.Location = New System.Drawing.Point(4, 53)
    Me.TabCustom.Name = "TabCustom"
    Me.TabCustom.Size = New System.Drawing.Size(579, 398)
    Me.TabCustom.TabIndex = 15
    Me.TabCustom.Text = "Custom"
    Me.TabCustom.UseVisualStyleBackColor = True
    '
    'BtnTA601
    '
    Me.BtnTA601.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA601.Location = New System.Drawing.Point(142, 31)
    Me.BtnTA601.Name = "BtnTA601"
    Me.BtnTA601.Size = New System.Drawing.Size(248, 26)
    Me.BtnTA601.TabIndex = 11
    Me.BtnTA601.Text = "Import Admins Elderly"
    '
    'BtnTA600
    '
    Me.BtnTA600.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA600.Location = New System.Drawing.Point(331, 232)
    Me.BtnTA600.Name = "BtnTA600"
    Me.BtnTA600.Size = New System.Drawing.Size(248, 26)
    Me.BtnTA600.TabIndex = 10
    Me.BtnTA600.Text = "Create Fire District Real Estate File"
    Me.BtnTA600.Visible = False
    '
    'imagelist_ta
    '
    Me.imagelist_ta.ImageStream = CType(resources.GetObject("imagelist_ta.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imagelist_ta.TransparentColor = System.Drawing.Color.Transparent
    Me.imagelist_ta.Images.SetKeyName(0, "")
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label6.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.ForeColor = System.Drawing.Color.Black
    Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label6.ImageIndex = 4
    Me.Label6.Location = New System.Drawing.Point(40, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(510, 40)
    Me.Label6.TabIndex = 15
    Me.Label6.Text = "Assessor"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnTA440
    '
    Me.BtnTA440.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA440.Location = New System.Drawing.Point(21, 211)
    Me.BtnTA440.Name = "BtnTA440"
    Me.BtnTA440.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA440.TabIndex = 41
    Me.BtnTA440.Text = "Make and Class Update for Non Tax"
    '
    'BtnTA540
    '
    Me.BtnTA540.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnTA540.Location = New System.Drawing.Point(23, 264)
    Me.BtnTA540.Name = "BtnTA540"
    Me.BtnTA540.Size = New System.Drawing.Size(244, 24)
    Me.BtnTA540.TabIndex = 42
    Me.BtnTA540.Text = "Make and Class Update for Non Tax"
    '
    'FrmMenuTA
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(599, 510)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.tab)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmMenuTA"
    Me.tab.ResumeLayout(False)
    Me.tabdaily.ResumeLayout(False)
    Me.tabPage2.ResumeLayout(False)
    Me.tabPage1.ResumeLayout(False)
    Me.tabPage3.ResumeLayout(False)
    Me.tabControl2.ResumeLayout(False)
    Me.tabListings.ResumeLayout(False)
    Me.tabNotices.ResumeLayout(False)
    Me.tabOPM.ResumeLayout(False)
    Me.TabPP.ResumeLayout(False)
    Me.TabMV.ResumeLayout(False)
    Me.TabSuppl.ResumeLayout(False)
    Me.tabPage6.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.TabPgMain.ResumeLayout(False)
    Me.TabPgRE.ResumeLayout(False)
    Me.TabPgPP.ResumeLayout(False)
    Me.TabpgMV.ResumeLayout(False)
    Me.TabPgSuppl.ResumeLayout(False)
    Me.tabPage8.ResumeLayout(False)
    Me.tabfilemaintenance.ResumeLayout(False)
    Me.tabPage11.ResumeLayout(False)
    Me.TabPage4.ResumeLayout(False)
    Me.TabPage20.ResumeLayout(False)
    Me.TabControl3.ResumeLayout(False)
    Me.TabPage5.ResumeLayout(False)
    Me.TabPage7.ResumeLayout(False)
    Me.TabPage9.ResumeLayout(False)
    Me.TabPage10.ResumeLayout(False)
    Me.TabPhaseIn.ResumeLayout(False)
    Me.tabchglog.ResumeLayout(False)
    Me.TabArchive.ResumeLayout(False)
    Me.TabCustom.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FrmMenuTA_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "MenuTA"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenuTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler btnTA001.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA101.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA102.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA103.MouseDown, AddressOf DoMouseDown
    AddHandler btnta104.MouseDown, AddressOf DoMouseDown
    AddHandler btnta105.MouseDown, AddressOf DoMouseDown
    AddHandler btnta106.MouseDown, AddressOf DoMouseDown
    AddHandler btnta107.MouseDown, AddressOf DoMouseDown
    AddHandler btnta108.MouseDown, AddressOf DoMouseDown
    AddHandler btnta109.MouseDown, AddressOf DoMouseDown
    AddHandler btnta110.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA111.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA130.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA131.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA132.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA133.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA134.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA135.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA136.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA137.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA138.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA139.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA140.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA141.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA202.MouseDown, AddressOf DoMouseDown
    AddHandler btnta203.MouseDown, AddressOf DoMouseDown
    AddHandler btnta204.MouseDown, AddressOf DoMouseDown
    AddHandler btnta205.MouseDown, AddressOf DoMouseDown
    AddHandler btnta206.MouseDown, AddressOf DoMouseDown
    AddHandler btnta207.MouseDown, AddressOf DoMouseDown
    AddHandler btnta208.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA209.MouseDown, AddressOf DoMouseDown
    AddHandler btnta212.MouseDown, AddressOf DoMouseDown
    AddHandler btnta213.MouseDown, AddressOf DoMouseDown
    AddHandler btnta215.MouseDown, AddressOf DoMouseDown
    AddHandler btnta216.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA217.MouseDown, AddressOf DoMouseDown
    AddHandler btnta218.MouseDown, AddressOf DoMouseDown
    AddHandler btnta219.MouseDown, AddressOf DoMouseDown
    AddHandler btnta220.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA221.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA222.MouseDown, AddressOf DoMouseDown
    AddHandler btnta226.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA230.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA231.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA232.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA233.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA234.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA235.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA236.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA237.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA238.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA304.MouseDown, AddressOf DoMouseDown
    AddHandler btnta314.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA316.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA330.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA331.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA402.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA403.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA404.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA406.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4071.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4072.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4073.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4074.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4075.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4076.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA4077.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA408.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA413.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA414.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA420.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA421.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA430.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA431.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA432.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA440.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA502.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA503.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA504.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA506.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5071.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5072.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5073.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5074.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5075.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5076.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5077.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA5078.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA509.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA513.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA514.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA518.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA519.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA520.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA521.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA523.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA524.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA525.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA530.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA531.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA540.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA600.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA601.MouseDown, AddressOf DoMouseDown
    AddHandler btnta801.MouseDown, AddressOf DoMouseDown
    AddHandler btnTA810.MouseDown, AddressOf DoMouseDown
    AddHandler btnTA811.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA901.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA902.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA903.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA904.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA940.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTA941.MouseDown, AddressOf DoMouseDown
    AddHandler btntaa01.MouseDown, AddressOf DoTXA09I
    AddHandler btntab01.MouseDown, AddressOf DoMouseDown
    AddHandler btntab02.MouseDown, AddressOf DoMouseDown
    AddHandler btntab03.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAB04.MouseDown, AddressOf DoMouseDown
    AddHandler btntac01.MouseDown, AddressOf DoMouseDown
    AddHandler btntad01.MouseDown, AddressOf DoMouseDown
    AddHandler btntad02.MouseDown, AddressOf DoMouseDown
    AddHandler btntad03.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAD04.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAD05.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAD06.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAE01.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAE02.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP01.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP02.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP03.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP10.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP11.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP12.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP13.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP14.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP15.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP16.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP17.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP20.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP21.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP22.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP23.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP24.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP25.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP26.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP27.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP28.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP29.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTAP30.MouseDown, AddressOf DoMouseDown
    AddHandler btnto101.MouseDown, AddressOf DoMouseDown
    AddHandler btnto102.MouseDown, AddressOf DoMouseDown
    AddHandler btnto103.MouseDown, AddressOf DoMouseDown
    AddHandler btnto104.MouseDown, AddressOf DoMouseDown
    AddHandler btnto105.MouseDown, AddressOf DoMouseDown
    AddHandler btnto106.MouseDown, AddressOf DoMouseDown
    AddHandler btnto107.MouseDown, AddressOf DoMouseDown
    AddHandler btnto109.MouseDown, AddressOf DoMouseDown
    AddHandler btnto110.MouseDown, AddressOf DoMouseDown
    AddHandler btnto111.MouseDown, AddressOf DoMouseDown
    AddHandler btnto112.MouseDown, AddressOf DoMouseDown
    AddHandler btnto113.MouseDown, AddressOf DoMouseDown
    AddHandler btnto114.MouseDown, AddressOf DoMouseDown
    AddHandler btnto116.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO120.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO121.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO200.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO201.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO202.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO203.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO204.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO205.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO207.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO208.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO220.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO221.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO300.MouseDown, AddressOf DoMouseDown
    AddHandler BtnTO301.MouseDown, AddressOf DoMouseDown

    If MyLocEld <> "" Then 'Local Elderly Listing
      BtnTA237.Visible = False
    End If

    If MyLocEld <> "045" Then 'Local Homeowners Qualifying Income
      BtnTA137.Visible = False
    End If

    If MyLocEld <> "035" And MyLocEld <> "084" Then 'Maintain Qualifying Elderly Income
      BtnTA134.Visible = False
    End If

    If MyLocEld <> "035" Then 'Maintain Defer Max Tax
      BtnTA139.Visible = False
    End If

    If MyLocEld <> "045" And MyLocEld <> "084" And MyLocEld <> "162" Then 'Maintain Local Exemption Income
      BtnTA135.Visible = False
    End If

    If Not MyPhaseIn Then
      tab.TabPages.Remove(TabPhaseIn)
    End If

  End Sub
  Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Handles all button Mouse Clicks on form
    If e.Clicks = 1 Then
      LaunchEXE(Me.ActiveControl.Name)
    End If
  End Sub
  Public Sub DoTXA09I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Clicks = 1 Then
      LaunchEXE("TXA09", "inquiry")
    End If
  End Sub
  Private Sub FrmMenuTA_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmMenu.Show()
  End Sub
  Private Sub FrmMenuTA_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    If Me.WindowState = FormWindowState.Minimized Then
      Me.Text = "TA"
    Else
      Me.Text = ""
    End If
  End Sub
  Private Sub FrmMenuTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub

  Private Sub TabSuppl_Click(sender As Object, e As EventArgs) Handles TabSuppl.Click

  End Sub

  Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

  End Sub

  Private Sub tabOPM_Click(sender As Object, e As EventArgs) Handles tabOPM.Click

  End Sub

  Private Sub label10_Click(sender As Object, e As EventArgs)

  End Sub

  Private Sub tabPage1_Click(sender As Object, e As EventArgs) Handles tabPage1.Click

  End Sub

  Private Sub TabPage20_Click(sender As Object, e As EventArgs) Handles TabPage20.Click

  End Sub
End Class
