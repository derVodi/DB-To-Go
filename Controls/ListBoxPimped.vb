Public Class ListBoxPimped
	Inherits ListBox

	Private _DataSourceChanging As Boolean

	Shadows Property Datasource As Object
		Get
			Return MyBase.DataSource
		End Get
		Set(value As Object)
			_DataSourceChanging = True
			MyBase.DataSource = value
			_DataSourceChanging = False
		End Set
	End Property

	Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
		If (Not _DataSourceChanging) Then
			MyBase.OnSelectedIndexChanged(e)
		End If
	End Sub

	Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
		'MyBase.OnDrawItem(e)

		If (e.Index < 0 OrElse e.Index >= Me.Items.Count) Then
			Exit Sub
		End If

		If ((e.State And DrawItemState.Selected) = DrawItemState.Selected) Then
			If Me.ContainsFocus Then
				e = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State Xor DrawItemState.Selected, Color.Black, Color.Gold)
			Else
				e = New DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State Xor DrawItemState.Selected, Color.Black, ColorsByVodi.GreyText)
			End If
		End If

		e.DrawBackground()

		e.Graphics.DrawString(Me.Items(e.Index).ToString(), e.Font, New SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault)

	End Sub

End Class
