Imports DbToGo.IO.ImageFile
Imports System.ComponentModel

Namespace Data

	Public Class AttribAssignmentSet
		Inherits BindingList(Of Attrib)

		Private _IsDirty As Boolean

		Private _FileNameWithoutExt As String

		Public Sub New(fileNameWithoutExt As String)
			_FileNameWithoutExt = fileNameWithoutExt
		End Sub

		Public Property IsDirty As Boolean
			Get
				Return (_IsDirty Or Me.LinkedFileInfo.IsDirty)
			End Get
			Private Set(value As Boolean)
				_IsDirty = False
				Me.LinkedFileInfo.IsDirty = False
			End Set
		End Property

		Public Property LinkedFileInfo As New LinkedFileInfo

		''' <summary> Haupteinstiegsmethode. Fügt den Eintrag in alle Listen ein. </summary>
		Public Sub SetAttrib(tagName As String, tagValue As String)
			Dim tag As Attrib = Database.AttribRepository.GetOrAddItem(tagName, tagValue)
			Me.Add(tag)
		End Sub

		Public Sub ReloadLoadFromFile()
			Me.Clear()
			Dim pictureFile = Database.GetFullPathOfPictureFile(_FileNameWithoutExt)
			MetaDataAdapter.Load(pictureFile, Me)
			Me.IsDirty = False
		End Sub

		Public Sub SaveToFile()
			If (Not Me.IsDirty) Then Exit Sub
			Dim pictureFile = Database.GetFullPathOfPictureFile(_FileNameWithoutExt)
			MetaDataAdapter.Save(pictureFile, Me)
			Me.IsDirty = False
		End Sub

		Protected Overrides Sub OnListChanged(e As ListChangedEventArgs)
			MyBase.OnListChanged(e)
			_IsDirty = True
		End Sub

		Function ToStringArray() As String()
			Dim tagsAsStrings(Me.Count - 1) As String
			For i As Integer = 0 To Me.Count - 1
				tagsAsStrings(i) = Me(i).TypeName + "=" + Me(i).Value
			Next
			Return tagsAsStrings
		End Function

	End Class

End Namespace
