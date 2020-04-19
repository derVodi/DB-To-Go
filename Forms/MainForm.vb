Partial Public Class MainForm

	Private _MainController As MainController

	Private _MainPanel As MainPanel

	Private _ModalPanel As ModalPanel

	Public Sub New()
		ColorsByVodi.Theme = "Black"

		' This call is required by the designer.
		Me.InitializeComponent()

		Me.Visible = False

		Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)

		Me.Text = Versioning.Constants.AppName

	End Sub

	Protected Overrides Sub OnShown(e As EventArgs)
		MyBase.OnShown(e)

		Select Case True
			Case Versioning.Updater.IsUpdateMode()
				Debug.Print("Update Mode")
				Me.ControlBox = False
				Me.Text += " - Updating..."
				Dim m = New ProgressPanel
				Me.ClientSize = m.Size
				m.Dock = DockStyle.Fill
				Me.Controls.Add(m)
				Versioning.Updater.ProgressPanel = m
				Versioning.Updater.DownloadAndUpdate()

			Case Else

				Versioning.Updater.CleanUpOldStuff()

				Dim m = New MainPanel
				Me.ClientSize = m.Size
				m.Dock = DockStyle.Fill
				Me.Controls.Add(m)
				_MainPanel = m
				_MainController = New MainController With {.View = _MainPanel}
				_MainController.Run()
		End Select

		Me.CenterToScreen()
		Me.Visible = True

	End Sub

	Public Sub ShowModal(htmlText As String)
		_MainPanel.Visible = False
		If (_ModalPanel Is Nothing) Then
			_ModalPanel = New ModalPanel With {.Dock = DockStyle.Fill}
			Me.Controls.Add(_ModalPanel)
		End If
		_ModalPanel.DocumentText = htmlText
		_ModalPanel.Visible = True
	End Sub

	Public Sub CloseModal()
		_ModalPanel.Visible = False
		_MainPanel.Visible = True
	End Sub

End Class
