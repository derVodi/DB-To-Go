Imports DbToGo.Data
Imports System.Text

Public Class PropertiesPanel

	Private _FileNameWithoutExt As String

	Private _TagsOfFile As AttribAssignmentSet = Nothing

	Public Sub New()
		InitializeComponent()

		gFileName.ForeColor = ColorsByVodi.DataForeground
		gTags.BackgroundColor = ColorsByVodi.Text
		gTags.GridColor = ColorsByVodi.ItemsSelected
		gTags.DefaultCellStyle.ForeColor = ColorsByVodi.TextForeground
		gTags.DefaultCellStyle.BackColor = ColorsByVodi.Text

		AddHandler State.ActiveThumbnailChanged, AddressOf Synchronize
	End Sub

	Private ReadOnly Property File As String
		Get
			If (_FileNameWithoutExt Is Nothing) Then
				Return Nothing
			End If
			Return Database.GetFullPathOfPictureFile(_FileNameWithoutExt)
		End Get
	End Property

	Public Property FileName As String
		Get
			Return _FileNameWithoutExt + ".jpg"
		End Get
		Set(value As String)
			Dim valueWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(value)
			If (valueWithoutExtension = _FileNameWithoutExt) Then
				Exit Property
			End If
			_FileNameWithoutExt = valueWithoutExtension
			Database.PictureEntries.TryGetValue(_FileNameWithoutExt, _TagsOfFile)
			BindData()
		End Set
	End Property

	Private Sub Synchronize()
		Me.FileName = State.ActiveThumbnail.FileName
	End Sub

	Private Sub BindData()
		gFileName.Text = _FileNameWithoutExt
		gLinkedPath.Text = _TagsOfFile.LinkedFileInfo.FullPath
		gLinkedSize.Text = _TagsOfFile.LinkedFileInfo.FileSizeString
		gLinkedDate.Text = _TagsOfFile.LinkedFileInfo.CreationTimeString
		gTags.DataSource = _TagsOfFile
	End Sub

	Private Sub gTags_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles gTags.DataBindingComplete
		For i As Integer = 0 To gTags.Rows.Count - 1
			gTags.Rows(i).Cells(0).Style.BackColor = ColorsByVodi.Head
			gTags.Rows(i).Cells(0).Style.ForeColor = ColorsByVodi.HeadForeground
			gTags.Rows(i).Cells(1).Style.ForeColor = ColorsByVodi.DataForeground
		Next
		gTags.ClearSelection()
	End Sub

	Private Sub gTags_KeyDown(sender As Object, e As KeyEventArgs) Handles gTags.KeyDown
		Select Case e.KeyCode
			Case Keys.Insert
				PerformTagChooserAction()
				e.Handled = True
		End Select
	End Sub

	Private Sub PerformTagChooserAction()
		TagChooser.Instance.AssignedAttribs = _TagsOfFile

		Dim result = ModalForm.PopUp(TagChooser.Instance, "Select from existing tags")
		If (result = DialogResult.OK) Then
			Database.SavePictureFile(Me._FileNameWithoutExt)
		Else
			If (_FileNameWithoutExt IsNot Nothing) Then
				Database.ReloadPictureFile(_FileNameWithoutExt)
			End If
		End If
	End Sub

	Private Sub gFileName_Click(sender As Object, e As EventArgs) Handles gFileName.Click
		Dim errorText As New StringBuilder
		ShellHelper.Execute(My.Settings.NameClickAction, AddressOf MainPlaceHolderResolver.Resolve, errorText)
		AlertError(errorText)
	End Sub

	Private Sub gTags_Click(sender As Object, e As EventArgs) Handles gTags.Click
		PerformTagChooserAction()
	End Sub

	Private Sub gLinkedPath_Click(sender As Object, e As EventArgs) Handles gLinkedPath.Click
		Dim errorText As New StringBuilder
		ShellHelper.Execute(My.Settings.LinkedPathClickAction, AddressOf MainPlaceHolderResolver.Resolve, errorText)
		AlertError(errorText)
	End Sub

End Class
