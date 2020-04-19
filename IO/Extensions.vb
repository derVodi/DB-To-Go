Imports System.Runtime.CompilerServices
Imports System.IO
Imports System.Text

Namespace FileSystem

	Module Extensions

		Public Function ResolveDriveAlias(unresolvedPath As String, errorText As StringBuilder) As String
			Dim right As Integer = unresolvedPath.IndexOf(":")
			If (right < 2) Then
				Return unresolvedPath
			End If
			Dim name As String = unresolvedPath.Substring(0, right)
			For Each d In DriveInfo.GetDrives()
				If (d.IsReady AndAlso d.VolumeLabel = name) Then
					Return Path.Combine(d.RootDirectory.Name, unresolvedPath.Substring(right + 2))
					Exit For
				End If
			Next
			errorText.AppendLine(String.Format("Volume '{0}' not found. Please connect it before using that function.", name))
			Return unresolvedPath
		End Function

		Private Class FileNameComparer
			Implements System.Collections.IComparer

			Public Function Compare(ByVal info1 As Object, ByVal info2 As Object) As Integer Implements System.Collections.IComparer.Compare
				Dim fileInfo1 As System.IO.FileInfo = DirectCast(info1, System.IO.FileInfo)
				Dim fileInfo2 As System.IO.FileInfo = DirectCast(info2, System.IO.FileInfo)
				Return fileInfo1.Name.CompareTo(fileInfo2.Name)
			End Function
		End Class

		<Extension>
		Sub Sort(extendee As FileInfo())
			Array.Sort(extendee, New FileNameComparer)
		End Sub

		<Extension>
		Sub Recurse(extendee As DirectoryInfo, fileTypes As String(), ignorePrefix As String, callback As Action(Of FileInfo))
			Try
				Dim subDirectories = extendee.GetDirectories()
				For Each subDirectory In subDirectories
					If (Not ignorePrefix Is Nothing AndAlso subDirectory.Name.StartsWith(ignorePrefix)) Then
						Continue For
					End If
					subDirectory.Recurse(fileTypes, ignorePrefix, callback)
				Next
				Dim files = extendee.GetFiles()
				For Each file In files
					If (fileTypes Is Nothing OrElse Array.Exists(fileTypes, Function(peek) peek.Equals(System.IO.Path.GetExtension(file.Name)))) Then
						callback(file)
					End If
				Next
			Catch ex As Exception
			End Try
		End Sub
	End Module

End Namespace
