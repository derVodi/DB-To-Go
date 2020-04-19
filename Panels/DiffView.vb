Imports System.IO
Imports System.Text
Imports DbToGo.Data
Imports DbToGo.FileSystem

Public Class DiffView

	Private Shared _Instance As DiffView

	Public Sub New()
		InitializeComponent()
		gFilterChooser.DataSource = System.Enum.GetValues(GetType(DiffViewFilter))
		gFilterChooser.SelectedIndex = DiffViewFilter.Differences

		gCustomPanel.PlaceholderResolver = AddressOf ResolvePlaceholders

	End Sub

	Private Function ResolvePlaceholders(source As String, errorText As StringBuilder) As String

		source = source.Replace("{FileNameWithoutExtension}", System.IO.Path.GetFileNameWithoutExtension(SelectedFileNameWithoutExtension))
		source = source.Replace("{FileName}", SelectedFileName)
		source = source.Replace("{File}", SelectedFile)

		Clipboard.SetText(SelectedFileNameWithoutExtension)

		Return source
	End Function

	Public ReadOnly Property SelectedExtension As String
		Get
			Return gListView.SelectedItems(0).SubItems(3).Text
		End Get
	End Property

	Public ReadOnly Property SelectedFile As String
		Get
			Return System.IO.Path.Combine(SelectedPath, SelectedFileName)
		End Get
	End Property

	Public ReadOnly Property SelectedFileName As String
		Get
			Return SelectedFileNameWithoutExtension + SelectedExtension
		End Get
	End Property

	Public ReadOnly Property SelectedFileNameWithoutExtension As String
		Get
			Return gListView.SelectedItems(0).SubItems(0).Text
		End Get
	End Property

	Public ReadOnly Property SelectedPath As String
		Get
			Return gListView.SelectedItems(0).SubItems(2).Text
		End Get
	End Property

	Public ReadOnly Property IgnorePrefix As String
		Get
			If (String.IsNullOrWhiteSpace(gIgnorePrefix.Text)) Then
				Return Nothing
			End If
			Return gIgnorePrefix.Text
		End Get
	End Property

	Public ReadOnly Property Types As String()
		Get
			If (gTypes.Text = "") Then
				Return Nothing
			End If
			Return gTypes.Text.Split(","c)
		End Get
	End Property

	Public Shared ReadOnly Property Instance As DiffView
		Get
			If (_Instance Is Nothing) Then
				_Instance = New DiffView
			End If
			Return _Instance
		End Get
	End Property

	Public ReadOnly Property Filter As DiffViewFilter
		Get
			Return DirectCast(gFilterChooser.SelectedIndex, DiffViewFilter)
		End Get
	End Property

	Private Sub Reload()

		gListView.Items.Clear()

		If (Not Directory.Exists(Me.Path)) Then
			Exit Sub
		End If

		Dim volumeLabel As String = New DriveInfo(Me.Path).VolumeLabel

		Dim balance As Integer
		Dim i As New DirectoryInfo(Me.Path)
		i.Recurse(
			Types,
			IgnorePrefix,
			Sub(fileInfo)
				Dim nameWithoutExt As String = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name)
				Dim tagsOfPicture As AttribAssignmentSet = Nothing
				Database.PictureEntries.TryGetValue(nameWithoutExt, tagsOfPicture)
				If (tagsOfPicture IsNot Nothing) Then
					balance = 0
					tagsOfPicture.LinkedFileInfo.FullPath = volumeLabel + fileInfo.FullName.Substring(1)
					tagsOfPicture.LinkedFileInfo.FileSize = fileInfo.Length
					tagsOfPicture.LinkedFileInfo.CreationTime = fileInfo.CreationTime
					Database.SavePictureFile(nameWithoutExt)
				Else
					balance = -1
				End If
				If (Filter.Matches(balance)) Then
					Dim cells() As String = {
						nameWithoutExt,
						BalanceToString(balance),
						System.IO.Path.GetDirectoryName(fileInfo.FullName),
						System.IO.Path.GetExtension(fileInfo.FullName)
					}
					Dim row As New ListViewItem(cells)
					gListView.Items.Add(row)
				End If
			End Sub
		)
	End Sub

	Private Function BalanceToString(balance As Integer) As String
		If (balance = 0) Then
			Return "="
		Else
			Return "<missing>"
		End If
	End Function

	Public Property Path As String
		Get
			Return gPath.Text
		End Get
		Set(value As String)
			If (gPath.Text = value) Then
				Exit Property
			End If
			gPath.Text = value
			Reload()
		End Set
	End Property

	Private Sub gPathButton_Click(sender As Object, e As EventArgs) Handles gPathButton.Click
		Dim path = PathChooser.PopUp(Me)
		If (path Is Nothing) Then
			Exit Sub
		End If
		Me.Path = path
	End Sub

	Private Sub gReloadButton_Click(sender As Object, e As EventArgs) Handles gReloadButton.Click
		Reload()
	End Sub

	Private Sub gFilterChooser_SelectedValueChanged(sender As Object, e As EventArgs) Handles gFilterChooser.SelectedValueChanged
		Reload()
	End Sub

	Private Sub gTypes_Validated(sender As Object, e As EventArgs) Handles gTypes.Validated
		gTypes.Text = gTypes.Text.ToLower.Replace(" "c, "")
		Reload()
	End Sub

	Private _SortColumn As Integer

	Private Sub gListView_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles gListView.ColumnClick
		' Determine whether the column is the same as the last column clicked.
		If e.Column <> _SortColumn Then
			' Set the sort column to the new column.
			_SortColumn = e.Column
			' Set the sort order to ascending by default.
			gListView.Sorting = SortOrder.Ascending
		Else
			' Determine what the last sort order was and change it.
			If gListView.Sorting = SortOrder.Ascending Then
				gListView.Sorting = SortOrder.Descending
			Else
				gListView.Sorting = SortOrder.Ascending
			End If
		End If
		' Call the sort method to manually sort.
		gListView.Sort()
		' Set the ListViewItemSorter property to a new ListViewItemComparer
		' object.
		gListView.ListViewItemSorter = New ListViewItemComparer(e.Column, gListView.Sorting)
	End Sub

End Class
