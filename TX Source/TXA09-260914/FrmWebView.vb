Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports System.Globalization
Imports Microsoft.Web.WebView2.Core

Public Class FrmWebView

  Friend WrkEmail As String
  Friend WrkAcct() As String
  Friend WrkAmount() As String

  Private myTXPAYCR As TXPAYCR.MyData
  Private myTXPAYID As TXPAYID.MyData
  Private WebViewUserDataFolder As String = Nothing

  Private Sub FrmWeb_Activated(
      ByVal sender As Object,
      ByVal e As System.EventArgs
  ) Handles Me.Activated

    MyFrmTXA09.SbpScreen.Text = "WebView2"

  End Sub

  Private Async Sub FrmWebView2_Load(
      ByVal sender As System.Object,
      ByVal e As System.EventArgs
  ) Handles MyBase.Load

    Dim sb As New StringBuilder()
    Dim cQuote As Char = Chr(34)

    Dim WrkUrl As String = ""
    Dim WrkType As String
    Dim WrkProdID As Integer
    Dim I As Integer

    Try

      myTXPAYCR = New TXPAYCR.MyData(myDBConnect)
      myTXPAYID = New TXPAYID.MyData(myDBConnect)

      '----------------------------------------------------------
      ' Get payment configuration
      '----------------------------------------------------------
      With myTXPAYCR

        .GetOneRecordP("PP")

        If .RecordNotFound Then

          MsgBox(
              "Missing Pay Credit ID's (TXPAYCR). Please contact hotline.",
              MsgBoxStyle.Exclamation,
              "Setup is not completed"
          )

          Return

        End If

        WrkUrl = Trim(._URL)

      End With

      If String.IsNullOrWhiteSpace(WrkUrl) Then

        MsgBox(
            "Payment URL is missing.",
            MsgBoxStyle.Exclamation,
            "Setup is not completed"
        )

        Return

      End If

      Me.Text = "Cash Register - Batch " & Str$(MyBatchNo) & " (WebView)"

      '----------------------------------------------------------
      ' Build POST form
      '----------------------------------------------------------
      sb.AppendLine("<!DOCTYPE html>")
      sb.AppendLine("<html>")
      sb.AppendLine("<head>")
      sb.AppendLine("<meta charset=""utf-8"">")
      sb.AppendLine("</head>")
      sb.AppendLine("<body>")

      sb.AppendLine(
          "<form action=" & cQuote &
          System.Net.WebUtility.HtmlEncode(WrkUrl) &
          cQuote &
          " method=" & cQuote &
          "post" &
          cQuote & ">"
      )

      sb.AppendLine("<p>Next screen will be an external Website</p>")

      '----------------------------------------------------------
      ' Partner code
      '----------------------------------------------------------
      sb.AppendLine(
          "<input type=""hidden"" name=""PartnerCD"" value=""" &
          System.Net.WebUtility.HtmlEncode(
              Trim(myTXPAYCR._PARTNR)
          ) &
          """>"
      )

      '----------------------------------------------------------
      ' Return URL
      '----------------------------------------------------------
      sb.AppendLine(
          "<input type=""hidden"" name=""ReturnURL"" value="""">"
      )

      '----------------------------------------------------------
      ' Cancel URL
      '----------------------------------------------------------
      sb.AppendLine(
          "<input type=""hidden"" name=""CancelURL"" value="""">"
      )

      '----------------------------------------------------------
      ' XML parameters
      '----------------------------------------------------------
      sb.AppendLine(
          "<textarea name=""paramXML"" " &
          "style=""display:none;"">"
      )

      If Not String.IsNullOrWhiteSpace(WrkEmail) Then

        sb.AppendLine(
            "<params Email=" & cQuote &
            System.Security.SecurityElement.Escape(
                Trim(WrkEmail)
            ) &
            cQuote & ">"
        )

      Else

        sb.AppendLine("<params>")

      End If

      '----------------------------------------------------------
      ' Products
      '----------------------------------------------------------
      If WrkAcct IsNot Nothing Then

        Dim MaxItems As Integer =
            Math.Min(24, WrkAcct.Length - 1)

        For I = 0 To MaxItems

          If String.IsNullOrWhiteSpace(WrkAcct(I)) Then
            Exit For
          End If

          WrkType = Mid(WrkAcct(I), 3, 1)

          '--------------------------------------------------
          ' Find product ID
          '--------------------------------------------------
          WrkProdID = 0

          myTXPAYID.GetOneRecordP(WrkType)

          If myTXPAYID.RecordNotFound Then

            myTXPAYID.GetOneRecordP("")

          End If

          If Not myTXPAYID.RecordNotFound Then

            WrkProdID = myTXPAYID._PRODID

          End If

          '--------------------------------------------------
          ' Get amount safely
          '--------------------------------------------------
          Dim Amount As Decimal = 0D

          If WrkAmount IsNot Nothing AndAlso
             I < WrkAmount.Length Then

            If Not Decimal.TryParse(
                WrkAmount(I),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                Amount
            ) Then

              If Not Decimal.TryParse(
                  WrkAmount(I),
                  Amount
              ) Then

                MessageBox.Show(
                    "Invalid payment amount: " &
                    WrkAmount(I),
                    "Payment Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )

                Return

              End If

            End If

          End If

          Dim AccountID As String =
              System.Security.SecurityElement.Escape(
                  WrkAcct(I)
              )

          Dim TaxType As String =
              System.Security.SecurityElement.Escape(
                  GetTXTypeDesc(WrkType)
              )

          '--------------------------------------------------
          ' Add Product XML
          '--------------------------------------------------
          sb.AppendLine(
              "<Product ID=" & cQuote &
              WrkProdID.ToString(
                  CultureInfo.InvariantCulture
              ) &
              cQuote &
              " AccountID=" & cQuote &
              AccountID &
              cQuote &
              " TaxType=" & cQuote &
              TaxType &
              cQuote &
              " Amount=" & cQuote &
              Amount.ToString(
                  "0.00",
                  CultureInfo.InvariantCulture
              ) &
              cQuote &
              "/>"
          )

        Next

      End If

      sb.AppendLine("</params>")
      sb.AppendLine("</textarea>")

      '----------------------------------------------------------
      ' Submit button
      '----------------------------------------------------------
      sb.AppendLine(
          "<input type=""submit"" id=""submit"" " &
          "value=""Submit"">"
      )

      sb.AppendLine("</form>")
      sb.AppendLine("</body>")
      sb.AppendLine("</html>")

      '----------------------------------------------------------
      ' Initialize private WebView2
      '----------------------------------------------------------
      Await InitializeInPrivateWebView(sb.ToString())

    Catch ex As Exception

      MessageBox.Show(
          "Unable to initialize payment screen:" &
          Environment.NewLine &
          ex.ToString(),
          "Payment Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
      )

    End Try

  End Sub

  Private Async Function InitializeInPrivateWebView(
      ByVal WrkStr As String
  ) As Task

    Try

      '----------------------------------------------------------
      ' Create a unique temporary user-data directory.
      '
      ' This prevents this payment session from using the
      ' application's normal WebView2 profile.
      '----------------------------------------------------------
      WebViewUserDataFolder =
          Path.Combine(
              MyUtils.GetDataPath,
              "TXA09_WebView_" & MyUserID & "_" &
              Guid.NewGuid().ToString("N"))

      Directory.CreateDirectory(WebViewUserDataFolder)

      '----------------------------------------------------------
      ' Create isolated WebView2 environment
      '----------------------------------------------------------
      Dim environment As CoreWebView2Environment =
          Await CoreWebView2Environment.CreateAsync(
              Nothing,
              WebViewUserDataFolder
          )

      '----------------------------------------------------------
      ' Create private controller options
      '----------------------------------------------------------
      Dim options As CoreWebView2ControllerOptions =
          environment.CreateCoreWebView2ControllerOptions()

      options.IsInPrivateModeEnabled = True

      '----------------------------------------------------------
      ' Initialize WebView2
      '----------------------------------------------------------
      Await WebView2.EnsureCoreWebView2Async(
          environment,
          options
      )

      '----------------------------------------------------------
      ' Diagnostics
      '----------------------------------------------------------
      AddHandler WebView2.CoreWebView2.NavigationStarting,
          AddressOf WebView_NavigationStarting

      AddHandler WebView2.CoreWebView2.NavigationCompleted,
          AddressOf WebView_NavigationCompleted

      '----------------------------------------------------------
      ' Load generated HTML
      '----------------------------------------------------------
      WebView2.CoreWebView2.NavigateToString(WrkStr)

    Catch ex As Exception

      MessageBox.Show(
          "WebView2 initialization failed:" &
          Environment.NewLine &
          ex.ToString(),
          "WebView2 Error",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
      )

    End Try

  End Function

  '==============================================================
  ' WebView2 navigation diagnostics
  '==============================================================

  Private Sub WebView_NavigationStarting(
      ByVal sender As Object,
      ByVal e As CoreWebView2NavigationStartingEventArgs
  )

    Debug.WriteLine(
        "WebView2 NavigationStarting: " &
        e.Uri
    )

  End Sub

  Private Sub WebView_NavigationCompleted(
      ByVal sender As Object,
      ByVal e As CoreWebView2NavigationCompletedEventArgs
  )

    Debug.WriteLine(
        "WebView2 NavigationCompleted: Success=" &
        e.IsSuccess.ToString() &
        " Status=" &
        e.WebErrorStatus.ToString()
    )

  End Sub

  '==============================================================
  ' Form closing / WebView2 cleanup
  '==============================================================

  Private Async Sub FrmWeb_FormClosed(
      ByVal sender As Object,
      ByVal e As System.Windows.Forms.FormClosedEventArgs
  ) Handles Me.FormClosed

    Try

      '----------------------------------------------------------
      ' Clear all WebView2 browsing data.
      '----------------------------------------------------------
      If WebView2.CoreWebView2 IsNot Nothing Then

        Await WebView2.CoreWebView2.Profile.ClearBrowsingDataAsync(
            CoreWebView2BrowsingDataKinds.DiskCache Or
            CoreWebView2BrowsingDataKinds.Cookies Or
            CoreWebView2BrowsingDataKinds.LocalStorage Or
            CoreWebView2BrowsingDataKinds.WebSql Or
            CoreWebView2BrowsingDataKinds.IndexedDb Or
            CoreWebView2BrowsingDataKinds.FileSystems Or
            CoreWebView2BrowsingDataKinds.ServiceWorkers Or
            CoreWebView2BrowsingDataKinds.CacheStorage
        )
      End If

    Catch ex As Exception

      Debug.WriteLine(
          "WebView2 ClearBrowsingData error: " &
          ex.Message
      )

    Finally

      '----------------------------------------------------------
      ' Dispose WebView2.
      '----------------------------------------------------------
      Try

        If WebView2 IsNot Nothing Then
          WebView2.Dispose()
        End If

      Catch ex As Exception

        Debug.WriteLine(
            "WebView2 Dispose error: " &
            ex.Message
        )

      End Try

      '----------------------------------------------------------
      ' Try to remove the temporary user-data directory.
      '
      ' WebView2/Edge may still have files locked briefly, so
      ' this may require more than one attempt.
      '----------------------------------------------------------
      If Not String.IsNullOrWhiteSpace(
          WebViewUserDataFolder
      ) Then

        DeleteWebViewUserDataFolder(
            WebViewUserDataFolder
        )

      End If

      MyFrmTXA09.TBarContinue.Visible = False
      MyFrmTXA094.Show()

    End Try

  End Sub

  '==============================================================
  ' Delete temporary WebView2 profile
  '==============================================================

  Private Sub DeleteWebViewUserDataFolder(
      ByVal FolderName As String
  )

    Try

      If Not Directory.Exists(FolderName) Then
        Return
      End If

      ' First attempt
      Try

        Directory.Delete(FolderName, True)

      Catch

        ' WebView2 may still have a file locked.
        ' Wait briefly and try again.

        System.Threading.Thread.Sleep(250)

        Try
          Directory.Delete(FolderName, True)
        Catch
          ' Leave it for the operating system/temp cleanup.
        End Try

      End Try

    Catch ex As Exception

      Debug.WriteLine(
          "Unable to delete WebView2 temporary folder: " &
          ex.Message
      )

    End Try

  End Sub

End Class
