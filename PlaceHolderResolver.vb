Imports DbToGo.Data
Imports DbToGo.MetaData
Imports System.Text
Imports System.IO

Public Class MainPlaceHolderResolver

	Public Delegate Function PlaceHolderResolvingFunction(source As String, errorText As StringBuilder) As String

	Public Shared Function Resolve(source As String, errorText As StringBuilder) As String

		Dim fileName = State.ActiveThumbnail.FileName
		Dim fileNameWithoutExt = State.ActiveThumbnail.FileNameWithoutExt
		Dim linkedUrl As String = Database.PictureEntries(fileNameWithoutExt).LinkedFileInfo.FullPath

		If (source.Contains("{LinkedFile}") AndAlso linkedUrl IsNot Nothing) Then
			linkedUrl = FileSystem.Extensions.ResolveDriveAlias(linkedUrl, errorText)
		End If

		source = source.Replace("{LinkedFile}", linkedUrl)
		source = source.Replace("{FileNameWithoutExtension}", Path.GetFileNameWithoutExtension(State.ActiveThumbnail.SourceFile))
		source = source.Replace("{FileName}", fileName)
		source = source.Replace("{File}", State.ActiveThumbnail.SourceFile)

		Return source
	End Function

End Class
