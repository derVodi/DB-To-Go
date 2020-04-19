Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

	Partial Class MyApplication

		Public Sub New()
			MyBase.New(AuthenticationMode.Windows)
			Me.IsSingleInstance = False
			Me.EnableVisualStyles = True
			Me.SaveMySettingsOnExit = True
			Me.ShutdownStyle = ShutdownMode.AfterMainFormCloses
		End Sub

		Protected Overrides Sub OnCreateMainForm()
			Me.MainForm = My.Forms.MainForm
		End Sub

	End Class

End Namespace
