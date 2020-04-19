Imports System.Reflection

Public Class ColorsByVodi

	Private Shared _Theme As String

	Shared Sub New()
		Theme = "Black"
	End Sub

	Public Shared Property Theme As String
		Get
			Return _Theme
		End Get
		Set(value As String)
			_Theme = value
			Select Case value
				Case "Black"
					Window = Color.FromArgb(16, 16, 16)

					Tabs = Color.FromArgb(159, 159, 159)
					TabsSelected = Color.FromArgb(199, 199, 199)

					ItemsSelectedWithFocus = Color.FromArgb(134, 134, 134)
					ItemsSelected = Color.FromArgb(206, 206, 206)

					ToolStrips = Color.FromArgb(45, 45, 45)

					TextSelected = Color.FromArgb(224, 224, 224)
					Text = Color.FromArgb(30, 30, 30)
					TextForeground = Color.FromArgb(165, 165, 165)

					Titles = Color.FromArgb(94, 94, 94)
					TitleBackground = Color.FromArgb(77, 96, 130)
					TitleBackgroundWithFocus = Color.FromArgb(255, 242, 157)
					TitleForeground = Color.White
					TitleForegroundInactive = Color.Gray
					TitleForegroundWithFocus = Color.Black

					Head = Color.FromArgb(39, 39, 39)
					HeadForeground = TextForeground
					DataForeground = Color.FromArgb(241, 241, 241)

				Case Else
					Window = Color.FromArgb(41, 57, 84)

					Tabs = Color.FromArgb(141, 163, 193)
					TabsSelected = Color.FromArgb(176, 203, 241) 'Light Yellow

					ItemsSelectedWithFocus = Color.FromArgb(51, 153, 255)
					ItemsSelected = Color.FromArgb(204, 206, 219)

					ToolStrips = Color.FromArgb(214, 219, 233)

					Text = Color.FromArgb(255, 255, 255)
					TextSelected = Color.FromArgb(153, 201, 239)

					TextForeground = Color.Black

					Titles = Color.FromArgb(77, 96, 130)
					TitleBackground = Color.FromArgb(77, 96, 130)
					TitleBackgroundWithFocus = Color.FromArgb(255, 242, 157)
					TitleForeground = Color.White
					TitleForegroundInactive = Color.Gray
					TitleForegroundWithFocus = Color.Black

					Head = Color.FromArgb(247, 247, 247)
					HeadForeground = Color.FromArgb(76, 96, 122)
					DataForeground = TextForeground

			End Select


			ItemsSelectedBrush = New SolidBrush(ItemsSelected)
			ItemsSelectedWithFocusBrush = New SolidBrush(ItemsSelectedWithFocus)
			TextBrush = New SolidBrush(Text)

		End Set
	End Property

	Public Shared Property Window As Color 'Darkest, inverse

	<Obsolete("Use TitleBackground!")>
	Public Shared Property Titles As Color 'Dark, inverse

	Public Shared Property Tabs As Color 'Medium Dark
	Public Shared Property TabsSelected As Color 'Medium Light

	Public Shared Property TitleBackground As Color
	Public Shared Property TitleBackgroundWithFocus As Color
	Public Shared Property TitleForeground As Color
	Public Shared Property TitleForegroundInactive As Color
	Public Shared Property TitleForegroundWithFocus As Color

	Public Shared Property ItemsSelectedWithFocus As Color 'inverse!
	Public Shared Property ItemsSelectedWithFocusBrush As Brush 'inverse!
	Public Shared Property ItemsSelected As Color 'Not inverse
	Public Shared Property ItemsSelectedBrush As Brush 'Not inverse

	Public Shared Property ToolStrips As Color

	Public Shared Property TextSelected As Color 'Not inverse, lighter than ItemSelected!
	Public Shared Property Text As Color 'White
	Public Shared Property Head As Color 'White
	Public Shared Property HeadForeground As Color 'White
	Public Shared Property TextForeground As Color 'White
	Public Shared Property DataForeground As Color 'White
	Public Shared Property TextBrush As Brush 'White

	Public Shared ReadOnly Property BlackPanel As Color
		Get
			Return Color.FromArgb(29, 29, 29)
		End Get
	End Property

	Public Shared ReadOnly Property BlackImportantCell As Color
		Get
			Return Color.FromArgb(37, 37, 37)
		End Get
	End Property

	Public Shared ReadOnly Property BackgroundMedium As Color 'Toolbars
		Get
			Return Color.FromArgb(45, 45, 45)
		End Get
	End Property

	Public Shared ReadOnly Property GreyGrid As Color
		Get
			Return Color.FromArgb(54, 54, 54)
		End Get
	End Property

	Public Shared ReadOnly Property GreyText As Color
		Get
			Return Color.FromArgb(161, 161, 161)
		End Get
	End Property

	Public Shared Function GetFromName(name As String, Optional fallBackColor As Color = Nothing) As Color

		Dim pi As PropertyInfo = GetType(Color).GetProperty(name)
		If (pi IsNot Nothing) Then
			Return DirectCast(pi.GetValue(Nothing), Color)
		End If

		Return fallBackColor
	End Function

End Class
