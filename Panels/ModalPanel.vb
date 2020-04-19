Public Class ModalPanel

	Public Const Home = "ModalPanel.Home"

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		'gWebBrowser.ObjectForScripting = Me
		gTopPanel.BackColor = ColorsByVodi.ToolStrips

	End Sub

	Private Sub GHomeButton_Click(sender As Object, e As EventArgs) Handles gHomeButton.Click
		InteractionBroker.Send(Home)
	End Sub

	Public Property DocumentText As String
		Get
			Return gWebBrowser.DocumentText
		End Get
		Set(value As String)
			gWebBrowser.DocumentText = "<style type='text/css'>body{font-family:'Segoe UI';font-size:10pt;}</style>" + value
		End Set
	End Property

	Private _NavigatingWasCalled As Boolean

	Private Sub gWebBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles gWebBrowser.Navigating

		Select Case True
			Case e.Url.AbsoluteUri = "about:blank"
				'Do nothing
			Case (e.Url.AbsoluteUri.Contains("http://local/"))
				Dim c As String = e.Url.AbsoluteUri.Replace("http://local/", "file://" + Versioning.Updater.ExecutingDirectory + "/")
				gWebBrowser.Url = New Uri(c)
				e.Cancel = True
			Case e.Url.AbsoluteUri.StartsWith("file:///")
				'Do nothing
			Case Else
				e.Cancel = True
				Dim p = New System.Diagnostics.Process
				p.StartInfo.FileName = e.Url.AbsoluteUri
				p.Start()
		End Select

	End Sub

	'onclick=""window.external.Go('VersionHistory.txt')""

	Public Sub Go(text As String)
		gWebBrowser.Url = New Uri(text)
	End Sub

End Class
