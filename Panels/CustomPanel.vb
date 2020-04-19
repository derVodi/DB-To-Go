Imports DbToGo.MainPlaceHolderResolver
Imports System.Text

Public Class CustomPanel
	Inherits FlowLayoutPanel

	Private _IniSection As String

	Public Property IniSection As String
		Get
			Return _IniSection
		End Get
		Set(value As String)
			_IniSection = value
		End Set
	End Property

	Private Sub AddButton(configLine As String)
		Dim label As String = Nothing
		Dim command As String = Nothing
		If (Not configLine.TryGetNameValue(label, command)) Then
			Exit Sub
		End If
		Dim button As New Button
		button.Text = label
		button.Tag = command
		button.FlatStyle = FlatStyle.Flat
		'button.ForeColor = Me.ForeColor
		button.AutoSize = True
		AddHandler button.Click, AddressOf AnyButton_Clicked
		Me.Controls.Add(button)
	End Sub

	Public Property PlaceholderResolver As PlaceHolderResolvingFunction

	Public Sub AnyButton_Clicked(sender As Object, e As EventArgs)
		Dim button As Button = DirectCast(sender, Button)
		Dim commandLine As String = DirectCast(button.Tag, String)
		Dim errorText As New StringBuilder
		ShellHelper.Execute(commandLine, Me.PlaceholderResolver, errorText)
		AlertError(errorText)
	End Sub

	Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
		MyBase.OnControlAdded(e)
	End Sub

	Private _Foo As Boolean

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		MyBase.OnPaint(e)
		If (Not _Foo) Then
			_Foo = True
			IniAccessor.ForEachLineOfSection(_IniSection, AddressOf AddButton)
		End If
	End Sub

End Class
