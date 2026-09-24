'Imports System.Drawing.Imaging
'Imports System.Drawing.Printing

Public Class FrmPS001C
  Inherits System.Windows.Forms.Form
  Dim myMFPCAT As MFPCAT.myData
  Dim ds As DataSet = New DataSet
  Friend wrkmfpcod As String
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
  Friend wrkmfpdes As String
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
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents Txtmfpcod As System.Windows.Forms.TextBox
Friend WithEvents Txtmfpdes As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Txtmfpcod = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Txtmfpdes = New System.Windows.Forms.TextBox()
    Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
    Me.Button1 = New System.Windows.Forms.Button()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 37)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Category"
    '
    'Txtmfpcod
    '
    Me.Txtmfpcod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmfpcod.Location = New System.Drawing.Point(80, 33)
    Me.Txtmfpcod.MaxLength = 2
    Me.Txtmfpcod.Name = "Txtmfpcod"
    Me.Txtmfpcod.Size = New System.Drawing.Size(28, 20)
    Me.Txtmfpcod.TabIndex = 0
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(128, 35)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 16)
    Me.Label2.TabIndex = 28
    Me.Label2.Text = "Description"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Txtmfpdes
    '
    Me.Txtmfpdes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtmfpdes.Location = New System.Drawing.Point(203, 33)
    Me.Txtmfpdes.MaxLength = 50
    Me.Txtmfpdes.Name = "Txtmfpdes"
    Me.Txtmfpdes.Size = New System.Drawing.Size(373, 20)
    Me.Txtmfpdes.TabIndex = 2
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(457, 80)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 29
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'FrmPS001C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(598, 114)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Txtmfpdes)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Txtmfpcod)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPS001C"
    Me.Text = "Maintain Parking Sticker Category"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Private Sub FrmPS001C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  myMFPCAT = New MFPCAT.mydata(MyDBConnect)
  MyFrmPS001.TBarNew.Enabled = False
  MyFrmPS001.TBarSave.Enabled = True
  MyFrmPS001.TBarPrint.Enabled = False
  If wrkmfpcod <> "" Then
    MyFrmPS001.TBarDelete.Enabled = True
    MyUtils.SetTxtReadOnly(Txtmfpcod)
  End If
  If wrkmfpcod = "" Then
    Me.Text = "Add " & Me.Text
    MyFrmPS001.TBarDelete.Enabled = False
    Exit Sub
    End If
  myMFPCAT.GetOneRecordP(wrkmfpcod)
  If myMFPCAT.RecordNotFound Then Exit Sub
  Txtmfpcod.Text = wrkmfpcod

  If s_chg = False And s_full = False Then    '#sec
    MyFrmPS001.TBarSave.Visible = False
  End If

  With myMFPCAT
    Txtmfpdes.Text = Trim(._MFPDES)
  End With
' create an instance of the PrintDocument component
      pd = New Printing.PrintDocument
      Me.StartPosition = FormStartPosition.CenterScreen

End Sub
Private Sub FrmPS001C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmPS001.SbpScreen.Text = "PS001C"
  MyUtils.CenterForm(Me.ParentForm, Me)

End Sub
Private Sub FrmPS001C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmPS001.TBarNew.Enabled = True
  MyFrmPS001.TBarDelete.Enabled = False
  MyFrmPS001.TBarSave.Enabled = False
  MyFrmPS001.TBarPrint.Enabled = False
  MyFrmPS001B.FormatGrid()
  MyFrmPS001B.Show()
End Sub
Public Sub DeleteData(ByRef Cancel As Boolean)
  Dim Answer As Integer
  Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
  myMFPCAT.DeleteOneRecordP()
End Sub
Public Sub SaveData()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
 myMFPCAT.GetOneRecordP(Txtmfpcod.Text)
  If wrkmfpcod = "" Then
    If myMFPCAT.RecordNotFound = False Then
      Me.ErrProv.SetError(Txtmfpcod, "Record already exists")
      Exit Sub
    End If
  End If
  If Not myMFPCAT.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFPCAT.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MovetoFile()
        myMFPCAT.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If
  Me.Close()
End Sub
Private Sub MovetoFile()
  With myMFPCAT
    ._MFPCOD = Trim(Txtmfpcod.Text)
    ._MFPDES = Trim(Txtmfpdes.Text)

  End With
End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
  Dim I As Integer
  ErrProv.SetError(Txtmfpcod, "")
  ErrProv.SetError(Txtmfpdes, "")
  For I = 0 To ErrorField.GetUpperBound(0)
    Select Case ErrorField(I)
    Case "mfpcod"
      ErrProv.SetError(Txtmfpcod, ErrorMsg(I))
    Case "mfpdes"
      ErrProv.SetError(Txtmfpdes, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  Next I
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

  If Txtmfpcod.Text = Trim("") Then
      ErrorField(I) = "mypcod"
      ErrorMsg(I) = "Category Required"
      I = I + 1
  End If

  If Txtmfpdes.Text = Trim("") Then
      ErrorField(I) = "mypdes"
      ErrorMsg(I) = "Description required"
      I = I + 1
  End If

End Sub

Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
 ' initiate the printdocument component
      GetFormImage()

      pd.Print()
End Sub

' create a printing component
   Private WithEvents pd As Printing.PrintDocument
   ' storage for form image
   Dim formImage As Bitmap
   ' create API prototype
   Private Declare Function BitBlt Lib "gdi32.dll" Alias _
      "BitBlt" (ByVal hdcDest As IntPtr, _
      ByVal nXDest As Integer, ByVal nYDest As _
      Integer, ByVal nWidth As Integer, _
      ByVal nHeight As Integer, ByVal _
      hdcSrc As IntPtr, ByVal nXSrc As Integer, _
      ByVal nYSrc As Integer, _
      ByVal dwRop As System.Int32) As Long

' Callback from PrintDocument component to 
   ' do the actual printing
   Private Sub pd_PrintPage(ByVal sender As Object, _
      ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
      Handles pd.PrintPage
      formImage = PureBW(formImage)
      e.Graphics.DrawImage(formImage, 100, 100)
   End Sub


Private Sub GetFormImage()
      Dim g As Graphics = Me.CreateGraphics()
      Dim s As Size = Me.Size
      formImage = New Bitmap(s.Width, s.Height, g)
      Dim mg As Graphics = Graphics.FromImage(formImage)
      Dim dc1 As IntPtr = g.GetHdc
      Dim dc2 As IntPtr = mg.GetHdc
      ' added code to compute and capture the form 
      ' title bar and borders 
      Dim widthDiff As Integer = _
         (Me.Width - Me.ClientRectangle.Width)
      Dim heightDiff As Integer = _
         (Me.Height - Me.ClientRectangle.Height)
      Dim borderSize As Integer = widthDiff \ 2
      Dim heightTitleBar As Integer = heightDiff - borderSize
      BitBlt(dc2, 0, 0, _
         Me.ClientRectangle.Width + widthDiff, _
         Me.ClientRectangle.Height + heightDiff, dc1, _
         0 - borderSize, 0 - heightTitleBar, 13369376)

      g.ReleaseHdc(dc1)
      mg.ReleaseHdc(dc2)
   End Sub
  'addon crap
  Public Function PureBW(ByVal image As System.Drawing.Bitmap, Optional ByVal Mode As BWMode = BWMode.By_Lightness, Optional ByVal tolerance As Single = 0) As System.Drawing.Bitmap
        Dim x As Integer
        Dim y As Integer
        If tolerance > 1 Or tolerance < -1 Then
            Throw New ArgumentOutOfRangeException
            Exit Function
        End If
        For x = 0 To image.Width - 1 Step 1
            For y = 0 To image.Height - 1 Step 1
                Dim clr As Color = image.GetPixel(x, y)
                If Mode = BWMode.By_RGB_Value Then
                    If (CInt(clr.R) + CInt(clr.G) + CInt(clr.B)) > 383 - (tolerance * 383) Then
                        image.SetPixel(x, y, Color.White)
                    Else
                        image.SetPixel(x, y, Color.Black)
                    End If
                Else
                    If clr.GetBrightness > 0.5 - (tolerance / 2) Then
                        image.SetPixel(x, y, Color.White)
                    Else
                        image.SetPixel(x, y, Color.Black)
                    End If
                End If
            Next
        Next
        Return image
    End Function
    Enum BWMode
        By_Lightness
        By_RGB_Value
    End Enum
  ' end add on crap
End Class






