Imports DbToGo.IO.ImageFile
Imports System.IO
Imports DbToGo.Data

Public Class ThumbsPanel
	Inherits FlowLayoutPanel

	Private _SelectedThumbnail As Thumbnail

	Public Sub New()
		AddHandler Thumbnail.Activated, AddressOf Me.AnyThumbnail_Activated
	End Sub

	Public Sub Clear()
		Me.Controls.Clear()
	End Sub

	Public Sub PopulateBySearch(text As String)
		Me.Clear()
		Select Case text.ToLower
			Case "#size"
				Dim proposedHeight = My.Settings.ThumbnailHeight
				Database.Dir.ForEachImageFileInDirectory(proposedHeight, Sub(s) Me.Controls.Add(New Thumbnail(s)))
			Case Else
				Database.ForEachPictureEntryOfSubString(text, Sub(s As String) Me.Controls.Add(New Thumbnail(Path.Combine(Database.Dir, s + ".jpg"))))
		End Select
	End Sub

	Public Sub PopulateByDates(year As Integer, month As Integer)
		Me.Clear()
		Database.ForEachPictureEntryOfYearMonth(year, month, Sub(s) Me.Controls.Add(New Thumbnail(s)))
	End Sub

	Public Sub PopulateByTags(criteria As Attrib())
		Me.Clear()
		Database.ForEachPictureEntry(
			criteria,
			Function(s As String)
				Me.Controls.Add(New Thumbnail(Path.Combine(Database.Dir, s + ".jpg")))
				Return True
			End Function
		)
	End Sub

	Private Sub AnyThumbnail_Activated(thumbnail As Thumbnail)

		If (_SelectedThumbnail Is thumbnail) Then
			Exit Sub
		End If

		If (_SelectedThumbnail IsNot Nothing) Then
			_SelectedThumbnail.IsSelected = False
		End If

		_SelectedThumbnail = thumbnail
		_SelectedThumbnail.IsSelected = True

	End Sub

End Class
