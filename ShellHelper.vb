Imports DbToGo.MainPlaceHolderResolver
Imports System.Text

Public Class ShellHelper

	Public Shared Sub Execute(commandLine As String, placeholderResolver As PlaceHolderResolvingFunction, errorText As StringBuilder)
		commandLine = placeholderResolver.Invoke(commandLine, errorText)
		If (errorText.Length > 0) Then Exit Sub
		Dim command As String = Nothing
		Dim arguments As String = Nothing
		Dim success = TryParseCommand(commandLine, command, arguments)
		If (success) Then
			System.Diagnostics.Process.Start(command, arguments)
		End If
	End Sub

	Private Shared Function TryParseCommand(commandLine As String, ByRef command As String, ByRef arguments As String) As Boolean
		If (commandLine(0) <> """") Then
			Return False
		End If
		Dim rightPos As Integer = commandLine.IndexOf("""", 1)
		command = commandLine.Substring(1, rightPos - 1)
		command = command.Trim

		If (command = "") Then
			Return False
		End If

		If (rightPos = commandLine.Length - 1) Then
			arguments = ""
			Return True
		End If

		rightPos += 1
		If (commandLine(rightPos) = " ") Then
			rightPos += 1
		End If

		If (rightPos >= commandLine.Length - 1) Then
			arguments = ""
			Return True
		End If

		arguments = commandLine.Substring(rightPos)
		Return True

	End Function

End Class
