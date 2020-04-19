Imports System.IO
Imports System.Text
Imports DbToGo.IO.ImageFile

Public Class Thumbnail
	Inherits PictureBox

	Property SourceFile As String

	Private Shared _ProposedHeight As Integer

	Private _IsSelected As Boolean

	Private Shared _UseEmbeddedThumbnails As Integer

	Public Property IsSelected As Boolean
		Get
			Return _IsSelected
		End Get
		Set(value As Boolean)
			If (value = _IsSelected) Then
				Exit Property
			End If
			_IsSelected = value
			Me.Invalidate()
		End Set
	End Property

	Public ReadOnly Property FileName As String
		Get
			Return System.IO.Path.GetFileName(Me.SourceFile)
		End Get
	End Property

	Public ReadOnly Property FileNameWithoutExt() As String
		Get
			Return System.IO.Path.GetFileNameWithoutExtension(Me.FileName)
		End Get
	End Property

	Private Function GetThumbnailImage(file As String) As Bitmap
		Using fs As FileStream = New FileStream(file, FileMode.Open)
			Using img As Image = Image.FromStream(fs, True, False)
				Return CType(img.GetThumbnailImage(CInt((img.Width / img.Height * 268)), 268, Nothing, IntPtr.Zero), Bitmap)
			End Using
		End Using
	End Function

	Public Sub New(imageFile As String)

		If (_ProposedHeight = 0) Then
			_ProposedHeight = My.Settings.ThumbnailHeight
		End If

		If (_UseEmbeddedThumbnails = 0) Then
			If My.Settings.UseEmbeddedThumbnails Then
				_UseEmbeddedThumbnails = 1
			Else
				_UseEmbeddedThumbnails = -1
			End If
		End If

		Me.SetStyle(ControlStyles.Selectable, True)
		Me.TabStop = True

		Me.SourceFile = imageFile

		If (_UseEmbeddedThumbnails = 1) Then
			Me.Image = GetThumbnailImage(imageFile)
		Else
			Me.ImageLocation = imageFile
		End If

		Dim s = imageFile.GetImageSize()
		Me.SizeMode = PictureBoxSizeMode.StretchImage
		Me.Width = CInt(_ProposedHeight / s.Height * s.Width)
		Me.Height = _ProposedHeight

	End Sub

	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		Me.Focus()
		MyBase.OnMouseDown(e)
	End Sub

	Protected Overrides Sub OnEnter(e As EventArgs)
		Me.Invalidate()
		MyBase.OnEnter(e)
		RaiseEvent Activated(Me)
	End Sub

	Public Shared Event Activated(sender As Thumbnail)

	Protected Overrides Sub OnLeave(e As EventArgs)
		Me.Invalidate()
		MyBase.OnLeave(e)
	End Sub

	Protected Overrides Sub OnPaint(pe As PaintEventArgs)
		MyBase.OnPaint(pe)
		If (Me.IsSelected) Then
			Dim rc = Me.ClientRectangle
			ControlPaint.DrawBorder(pe.Graphics, rc, Color.Yellow, ButtonBorderStyle.Solid)
		End If
		If (Me.Focused) Then
			Dim rc = Me.ClientRectangle
			rc.Inflate(-2, -2)
			ControlPaint.DrawFocusRectangle(pe.Graphics, rc, Color.White, Color.Black)
		End If
	End Sub

	Protected Overrides Sub OnDoubleClick(e As EventArgs)
		MyBase.OnDoubleClick(e)
		Dim errorText As New StringBuilder
		ShellHelper.Execute(My.Settings.ThumbnailDoubleClickAction, AddressOf MainPlaceHolderResolver.Resolve, errorText)
		AlertError(errorText)
	End Sub

End Class
