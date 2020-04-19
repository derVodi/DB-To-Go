Public Class PathChooser

	Public Shared Function PopUp(owner As IWin32Window) As String

		Dim result As DialogResult
		Dim path As String

		Using dialog = New FolderBrowserDialog
			result = dialog.ShowDialog(owner)
			path = dialog.SelectedPath
		End Using

		If (Not result = Windows.Forms.DialogResult.OK) Then
			Return Nothing
		End If

		Return path

	End Function

End Class
