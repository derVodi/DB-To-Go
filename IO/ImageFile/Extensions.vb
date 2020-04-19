Imports DbToGo.FileSystem
Imports DbToGo.MetaData
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports System.Windows.Media.Imaging

Namespace IO.ImageFile

	Module Extensions

		<Extension>
		Public Sub ForEachImageFileInDirectory(dir As String, callback As Action(Of String))
			Dim fileInfos = New DirectoryInfo(dir).GetFiles()
			fileInfos.Sort()
			For Each fileInfo In fileInfos
				Dim ext As String = fileInfo.Extension.ToLower
				If (ext = ".jpg") Then
					callback.Invoke(System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name))
				End If
			Next
		End Sub

		<Extension>
		Public Sub ForEachImageFileInDirectory(dir As String, height As Integer, callback As Action(Of String))
			For Each fileInfo In New DirectoryInfo(dir).GetFiles
				Dim ext As String = fileInfo.Extension.ToLower
				If (ext = ".jpg") Then
					Dim actualHeight As Integer = fileInfo.FullName.GetImageSize().Height
					If (actualHeight <> height) Then
						callback.Invoke(fileInfo.FullName)
					End If
				End If
			Next
		End Sub

		<Extension>
		Public Function GetImageSize(file As String) As Size
			Using fs As FileStream = New FileStream(file, FileMode.Open)
				Using img As Image = Image.FromStream(fs, True, False)
					Return img.Size
				End Using
			End Using
		End Function

	End Module

End Namespace
