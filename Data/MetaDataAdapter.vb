Imports DbToGo.MetaData
Imports System.Globalization

Namespace Data

	Public Class MetaDataAdapter

		Public Shared Function ToDictionary(tagsOfAPicture As AttribAssignmentSet) As Dictionary(Of String, Object)
			Dim queryPathsAndData As New Dictionary(Of String, Object)

			queryPathsAndData.Add(QueryPaths.ImageDescription, tagsOfAPicture.LinkedFileInfo.FullPath)
			queryPathsAndData.Add(QueryPaths.Copyright, tagsOfAPicture.LinkedFileInfo.FileSize.ToString())
			queryPathsAndData.Add(QueryPaths.DateTimeDigitized, tagsOfAPicture.LinkedFileInfo.CreationTime.ToString("yyyy:MM:dd HH:mm:ss"))

			queryPathsAndData.Add(QueryPaths.Keywords, tagsOfAPicture.ToStringArray)

			Return queryPathsAndData
		End Function

		Public Shared Sub Save(pictureFile As String, tagsOfAPicture As AttribAssignmentSet)
			MetaDataAccessor.SaveMetadata(pictureFile, ToDictionary(tagsOfAPicture), True)
		End Sub

		Public Shared Sub Load(pictureFile As String, tagsOfAPicture As AttribAssignmentSet)

			Dim dataFromFile As New Dictionary(Of String, Object)
			dataFromFile.Add(QueryPaths.ImageDescription, Nothing)
			dataFromFile.Add(QueryPaths.Copyright, Nothing)
			dataFromFile.Add(QueryPaths.DateTimeDigitized, Nothing)
			dataFromFile.Add(QueryPaths.Keywords, Nothing)

			MetaDataAccessor.LoadMetaData(pictureFile, dataFromFile)

			tagsOfAPicture.LinkedFileInfo.FullPath = DirectCast(dataFromFile(QueryPaths.ImageDescription), String)

			If (Not Long.TryParse(DirectCast(dataFromFile(QueryPaths.Copyright), String), tagsOfAPicture.LinkedFileInfo.FileSize)) Then
				tagsOfAPicture.LinkedFileInfo.FileSize = -1
			End If

			DateTime.TryParseExact(
				DirectCast(dataFromFile(QueryPaths.DateTimeDigitized), String),
				"yyyy:MM:dd HH:mm:ss",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				tagsOfAPicture.LinkedFileInfo.CreationTime
			)

			If (dataFromFile(QueryPaths.Keywords) IsNot Nothing) Then
				For Each s In DirectCast(dataFromFile(QueryPaths.Keywords), String())
					Dim splitTag() As String = s.Split("="c)
					If (splitTag.GetUpperBound(0) = 1) Then
						Dim tag As Attrib = Database.AttribRepository.GetOrAddItem(splitTag(0), splitTag(1))
						tagsOfAPicture.Add(tag)
					End If
				Next
			End If

		End Sub

	End Class

End Namespace
