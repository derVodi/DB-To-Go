Imports DbToGo.IO.ImageFile.Extensions
Imports System.IO

Namespace Data

	Public Class Database

		Private Shared _AttribRepository As New AttribRepository

		Private Shared _PictureEntries As New Dictionary(Of String, AttribAssignmentSet)

		''' <summary> Main Collection of Records. </summary>
		''' <returns> Key: Unique file name (without extension) of picture. Value: Assigned attributes.</returns>
		Public Shared ReadOnly Property PictureEntries As Dictionary(Of String, AttribAssignmentSet)
			Get
				Return _PictureEntries
			End Get
		End Property

		Public Shared ReadOnly Property AttribRepository As AttribRepository
			Get
				Return _AttribRepository
			End Get
		End Property

		Public Shared Function GetFullPathOfPictureFile(fileNameWothoutExt As String) As String
			Return Path.Combine(Database.Dir, fileNameWothoutExt + ".jpg")
		End Function

		Public Shared ReadOnly Property Dir As String
			Get
				Return State.LocalPictureDir
			End Get
		End Property

		Public Shared Sub Load()
			_AttribRepository.Clear()
			_PictureEntries.Clear()
			Database.Dir.ForEachImageFileInDirectory(AddressOf LoadPictureFile)
			_AttribRepository.Sort()
		End Sub

		Private Shared Sub LoadPictureFile(fileNameWithoutExt As String)
			Dim tagsOfEntry = New AttribAssignmentSet(fileNameWithoutExt)
			tagsOfEntry.ReloadLoadFromFile()
			_PictureEntries.Add(fileNameWithoutExt, tagsOfEntry)
		End Sub

		Public Shared Sub ReloadPictureFile(fileNameWithoutExt As String)
			Dim tagsOfEntry As AttribAssignmentSet = Nothing
			_PictureEntries.TryGetValue(fileNameWithoutExt, tagsOfEntry)
			If (tagsOfEntry Is Nothing) Then
				Throw New ArgumentException("Does not exist in _PictureEntries!", "fileNameWithoutExt")
			End If
			tagsOfEntry.ReloadLoadFromFile()
		End Sub

		Public Shared Sub SavePictureFile(fileNameWithoutExt As String)
			Dim tagsOfEntry As AttribAssignmentSet = Nothing
			_PictureEntries.TryGetValue(fileNameWithoutExt, tagsOfEntry)
			If (tagsOfEntry Is Nothing) Then
				Throw New ArgumentException("Does not exist in _PictureEntries!", "fileNameWithoutExt")
			End If
			tagsOfEntry.SaveToFile()
		End Sub

		Public Shared Function ExistsPictureEntry(matchingAttribs() As Attrib) As Boolean
			Dim found As Boolean
			Database.ForEachPictureEntry(
				matchingAttribs,
				Function(s As String)
					found = True
					Return False
				End Function
			)
			Return found
		End Function

		Public Shared Sub ForEachPictureEntry(matchingAttribs() As Attrib, callback As Func(Of String, Boolean))
			For Each pictureEntry In _PictureEntries

				Dim assignedAttributes As AttribAssignmentSet = pictureEntry.Value
				Dim match As Boolean = True
				For Each attrib In matchingAttribs
					If (attrib.Value = "?") Then
						If (assignedAttributes.ContainsType(attrib.TypeName)) Then
							match = False
							Exit For
						End If
					Else
						If (Not assignedAttributes.Contains(attrib)) Then
							match = False
							Exit For
						End If
					End If
				Next

				If (match) Then
					Dim goOn As Boolean = callback.Invoke(pictureEntry.Key)
					If (Not goOn) Then
						Exit Sub
					End If
				End If
			Next
		End Sub

		Public Shared Sub ForEachPictureEntryOfSubString(subString As String, callback As Action(Of String))
			subString = subString.ToLower
			For Each kvp In _PictureEntries
				If (subString = "?") Then
					If (kvp.Value.Count = 0) Then
						callback.Invoke(kvp.Key)
					End If
				Else
					If (kvp.Key.ToLower.Contains(subString)) Then
						callback.Invoke(kvp.Key)
						Continue For
					End If
					For Each tag In kvp.Value
						If (tag.Value.ToLower.Contains(subString)) Then
							callback.Invoke(kvp.Key)
						End If
					Next
				End If
			Next
		End Sub

		Public Shared Sub ForEachPictureEntryOfYearMonth(year As Integer, month As Integer, callback As Action(Of String))

			For Each pictureWithTags In _PictureEntries
				Dim d = pictureWithTags.Value.LinkedFileInfo.CreationTime
				If (d = Date.MinValue) Then Continue For
				If (month <> 0 AndAlso d.Month <> month) Then Continue For
				If (d.Year <> year) Then Continue For
				callback.Invoke(GetFullPathOfPictureFile(pictureWithTags.Key))
			Next

		End Sub

		Public Shared Sub GetMinMaxYear(ByRef maxYear As Integer, ByRef minYear As Integer)
			maxYear = Integer.MinValue
			minYear = Integer.MaxValue

			For Each pictureWithTags In _PictureEntries
				Dim d = pictureWithTags.Value.LinkedFileInfo.CreationTime
				If (d = Date.MinValue) Then Continue For
				Dim year As Integer = d.Year
				If (year > maxYear) Then
					maxYear = year
				End If
				If (year < minYear) Then
					minYear = year
				End If
			Next

		End Sub

	End Class

End Namespace

