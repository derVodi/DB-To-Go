Public Class ModalForm

	Public Shared Function PopUp(userControl As UserControl, caption As String) As DialogResult
		Dim instance = New ModalForm
		instance.Text = caption
		instance.gPanel.Controls.Add(userControl)
		userControl.Dock = DockStyle.Fill

		Return instance.ShowDialog()

	End Function

End Class