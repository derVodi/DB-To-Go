Imports System.IO

Public Class State

	Public Const IniFileName As String = "!DB-To-Go.d2g"

	Public Shared Sub WireUp()
		AddHandler Thumbnail.Activated, AddressOf AnyThumbnail_Activated
	End Sub

	Private Shared Sub AnyThumbnail_Activated(thumbnail As Thumbnail)
		ActiveThumbnail = thumbnail
	End Sub

	Shared _ActiveThumbnail As Thumbnail

	Public Shared Property ActiveThumbnail As Thumbnail
		Get
			Return _ActiveThumbnail
		End Get
		Set(value As Thumbnail)
			If (value Is _ActiveThumbnail) Then
				Exit Property
			End If
			_ActiveThumbnail = value
			RaiseEvent ActiveThumbnailChanged()
		End Set
	End Property

	Public Shared Event ActiveThumbnailChanged()

	Public Shared ReadOnly Property LocalPictureDir As String
		Get
			Dim args = Environment.GetCommandLineArgs()
			If (args.Length > 1) Then
				Return args(1)
			Else
				Return Path.Combine(My.Application.Info.DirectoryPath, "Database")
			End If
		End Get
	End Property

End Class
