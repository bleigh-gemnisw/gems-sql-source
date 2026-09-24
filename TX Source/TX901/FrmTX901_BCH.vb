Public Class FrmTX901_BCH
    Inherits System.Windows.Forms.Form
		Dim myBCHHDR As BCHHDR.myData
'    Dim dsBCHHDR As DataSet = New DataSet
		Dim myTSPBCH As TSPBCH.myData
 '   Dim dsTSPBCH As DataSet = New DataSet
    Friend WrkBatch As String
    Friend WrkBatchNo As Integer

    Dim SavedBatch As Boolean
    Dim AddMode As Boolean
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblBatchNo As System.Windows.Forms.Label
Friend WithEvents PrtDialog As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.Label1 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.LblBatchNo = New System.Windows.Forms.Label
Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.PrtDialog = New System.Windows.Forms.PrintDialog
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(32, 24)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 16)
Me.Label1.TabIndex = 0
Me.Label1.Text = "Batch #"
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(35, 55)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(92, 16)
Me.Label4.TabIndex = 3
Me.Label4.Text = "Posting Date"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(131, 55)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
Me.DtPckPost.TabIndex = 4
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
'FrmTX901_BCH
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(258, 101)
Me.Controls.Add(Me.LblBatchNo)
Me.Controls.Add(Me.DtPckPost)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmTX901_BCH"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Suspense Create/Change Batch"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub

#End Region

  Private Sub FrmTX901_BCH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTSPBCH = New TSPBCH.mydata(MyDBConnect)

    With MyFrmTX901
      .TBarChange.Enabled = False
      .TBarDelete.Enabled = False
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With

    If WrkBatchNo = 0 Then
      AddMode = True
      NewData()
    Else
			myBCHHDR.GetOneRecordP(WrkBatch, WrkBatchNo)
			If Not myBCHHDR.RecordNotFound Then
				With myBCHHDR
          DtPckPost.Value = MyUtils.GetDBDate(._PSDT)
				End With
			End If
    End If

    LblBatchNo.Text = WrkBatchNo
  End Sub

  Private Sub FrmTX901_BCH_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX901.SbpScreen.Text = "TX901_BCH"
    MyUtils.CenterForm(Me.ParentForm, Me)
    With MyFrmTX901
      .HelpProvider1.SetHelpNavigator(Me, HelpNavigator.KeywordIndex)
      .HelpProvider1.SetHelpKeyword(Me, .SbpScreen.Text)
    End With
  End Sub

  Private Sub FrmTX901_BCH_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    If AddMode Then
      If Not SavedBatch Then
        MyFrmTX901.TBarNew.Enabled = True
        MyFrmTX901.TBarSave.Enabled = False
        MyFrmTX901B.Show()
        GoTo Cleanup
      End If
      With MyFrmTX901
        .TBarChange.Enabled = False
        .TBarSave.Enabled = False
        .TBarPrtEdits.Enabled = False
        .TBarPost.Enabled = False
      End With
      MyFrmTX901C = New FrmTX901C
      MyFrmTX901C.MdiParent = Me.ParentForm
      MyFrmTX901C.WrkBatchNo = WrkBatchNo
      MyFrmTX901C.Show()
    Else
      With MyFrmTX901
        .TBarChange.Enabled = True
        .TBarSave.Enabled = False
        .TBarPrtEdits.Enabled = True
        .TBarPost.Enabled = True
      End With
      MyFrmTX901B.FormatGrid()
      MyFrmTX901B.Show()
    End If

Cleanup:
  'Memory Cleanup
  myBCHHDR = Nothing
  myTSPBCH = Nothing
  End Sub
  Public Sub SaveData()
		Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

		myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)

    MoveToFile()
		If IsNothing(ErrorMsg(0)) Then
			myBCHHDR.UpdateOneRecordP()
		Else
			ShowError(ErrorField, ErrorMsg)
			Exit Sub
		End If

    SavedBatch = True
    Me.Close()

  End Sub
Private Sub MoveToFile()

		With myBCHHDR
      ._PSDT = MyUtils.SetDBDate(DtPckPost.Value)
		End With

    End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblBatchNo, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "kbtch#"
        ErrProv.SetError(LblBatchNo, ErrorMsg(I))
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub
Public Sub NewData()
	Dim WrkNextBatch As Integer
  
	myBCHHDR.GetOneRecordP(MyBatch, 0)
	If myBCHHDR.RecordNotFound Then
		With myBCHHDR
			._APPID = MyBatch
			._BCHNO = 0
		End With
		myBCHHDR.AddOneRecordP()
	End If

	WrkNextBatch = myBCHHDR.AutoGenKey(MyBatch)
	myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
	If myBCHHDR.RecordNotFound Then
		With myBCHHDR
			._APPID = MyBatch
			._BCHNO = WrkNextBatch
			._ORGUS = "GEMSNET"
			._STATS = "S"
			._SUBST = "S"
      ._PSDT = MyUtils.SetDBDate(Date.Today)
		End With
		myBCHHDR.AddOneRecordP()

		myBCHHDR.GetOneRecordP(MyBatch, 0)
		If Not myBCHHDR.RecordNotFound Then
			With myBCHHDR
				._LSBCH = WrkNextBatch
			End With
			myBCHHDR.UpdateOneRecordP()
		End If
	End If

  WrkBatchNo = WrkNextBatch
End Sub
End Class






