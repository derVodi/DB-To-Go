Imports System.IO

Public Class IniAccessor

	Public Shared Sub ForEachLineOfSection(section As String, callback As Action(Of String))
		Dim foundSection As String = Nothing

		Dim iniFile As String = Path.Combine(State.LocalPictureDir, State.IniFileName)

		Using fs = System.IO.File.OpenText(iniFile)
			While Not fs.EndOfStream
				Dim line = fs.ReadLine.Trim
				If (line.Length > 0 AndAlso line(0) <> ";") Then
					If (line(0) = "[") Then
						If (foundSection IsNot Nothing) Then
							Exit Sub
						End If
						Dim rightPos As Integer = line.IndexOf("]")
						If (rightPos > 1) Then
							foundSection = line.Substring(1, rightPos - 1)
							If (foundSection <> section) Then
								foundSection = Nothing
							End If
							Continue While
						End If
					End If
					If (foundSection IsNot Nothing) Then
						callback.Invoke(line)
					End If
				End If
			End While
		End Using
	End Sub

End Class
