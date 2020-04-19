Imports System.ComponentModel
Imports DbToGo.Data

Public Class TagChooser

	Private Shared _Instance As TagChooser

	Private _LastSelectedValueIndexPerType As New Dictionary(Of String, Integer)

	Property LastSelectedValueIndexPerType(typeName As String) As Integer
		Get
			Dim value As Integer
			If (Not _LastSelectedValueIndexPerType.TryGetValue(typeName, value)) Then
				value = -1
			End If
			Return value
		End Get
		Set(value As Integer)
			_LastSelectedValueIndexPerType(typeName) = value
		End Set
	End Property

	Public Shared ReadOnly Property Instance As TagChooser
		Get
			If (_Instance Is Nothing) Then
				_Instance = New TagChooser
			End If
			_Instance.gTypeNames.Datasource = Nothing
			_Instance.gTypeNames.Datasource = Database.AttribRepository.AllTypeNames
			Return _Instance
		End Get
	End Property

	Public Shared Sub DropInstance()
		_Instance = Nothing
	End Sub

	Private _AssignedAttribs As AttribAssignmentSet

	Public Property AssignedAttribs As AttribAssignmentSet
		Get
			Return _AssignedAttribs
		End Get
		Set(value As AttribAssignmentSet)
			If (value Is _AssignedAttribs) Then
				Exit Property
			End If
			_AssignedAttribs = value
			Instance.gAssignedAttributes.DataSource = value
		End Set
	End Property

	Private Sub GOfferedValues_DoubleClick(sender As Object, e As EventArgs) Handles gOfferedValues.DoubleClick
		AssignAttrib()
	End Sub

	Private Sub GTypeNames_KeyDown(sender As Object, e As KeyEventArgs) Handles gTypeNames.KeyDown

		Select Case e.KeyCode
			Case Keys.Left
				gAssignedAttributes.Focus()
				e.Handled = True
			Case Keys.Right, Keys.Space
				gOfferedValues.Focus()
				e.Handled = True
			Case Keys.Insert
				gTypeNameTextBox.Focus()
				e.Handled = True
		End Select

	End Sub

	Private Sub GOfferedValues_KeyDown(sender As Object, e As KeyEventArgs) Handles gOfferedValues.KeyDown

		Select Case e.KeyCode
			Case Keys.Left
				gTypeNames.Focus()
				e.Handled = True
			Case Keys.Right
				gAssignedAttributes.Focus()
				e.Handled = True
			Case Keys.Space
				AssignAttrib()
				e.Handled = True
			Case Keys.Return
				AssignAttrib(True)
				e.Handled = True
			Case Keys.Insert
				gValueTextBox.Focus()
				e.Handled = True
		End Select

	End Sub

	Private Sub GAssignedAttributes_KeyDown(sender As Object, e As KeyEventArgs) Handles gAssignedAttributes.KeyDown
		Select Case e.KeyCode
			Case Keys.Left
				gOfferedValues.Focus()
				e.Handled = True
			Case Keys.Right
				gTypeNames.Focus()
				e.Handled = True
		End Select
	End Sub

	Private Sub AssignAttrib(Optional orClose As Boolean = False)

		Dim s = Me.SelectedAttrib
		If s Is Nothing Then
			Exit Sub
		End If

		For Each existingAttrib In _AssignedAttribs
			If (existingAttrib Is SelectedAttrib) Then
				If (orClose) Then
					DirectCast(Me.Parent.Parent, Form).DialogResult = DialogResult.OK
				End If
			End If
			If (existingAttrib.TypeName.ToLower = SelectedTypeName.ToLower) Then
				_AssignedAttribs.Remove(existingAttrib)
				Exit For
			End If
		Next

		_AssignedAttribs.Add(s)

	End Sub

	ReadOnly Property SelectedAttrib As Attrib
		Get
			Return Database.AttribRepository.FindAttrib(SelectedTypeName, SelectedValue)
		End Get
	End Property

	ReadOnly Property SelectedTypeName As String
		Get
			Return DirectCast(gTypeNames.SelectedItem, String)
		End Get
	End Property

	ReadOnly Property SelectedValue As String
		Get
			Return DirectCast(gOfferedValues.SelectedItem, String)
		End Get
	End Property

	Private Sub GTypeNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gTypeNames.SelectedIndexChanged
		If (SelectedTypeName Is Nothing) Then
			Exit Sub
		End If
		gOfferedValues.Datasource = Database.AttribRepository.GetValues(SelectedTypeName)
		gOfferedValues.SelectedIndex = Me.LastSelectedValueIndexPerType(SelectedTypeName)
	End Sub

	Private Sub GOfferedValues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gOfferedValues.SelectedIndexChanged
		Me.LastSelectedValueIndexPerType(SelectedTypeName) = gOfferedValues.SelectedIndex
	End Sub

	Private Sub GTypeNameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles gTypeNameTextBox.KeyDown
		Select Case e.KeyCode
			Case Keys.Down
				gTypeNames.Focus()
				e.Handled = True
			Case Keys.Return
				Dim tagNames = Database.AttribRepository.AllTypeNames
				If (Not tagNames.Contains(gTypeNameTextBox.Text)) Then
					tagNames.Add(gTypeNameTextBox.Text)
					tagNames.Sort()
					gTypeNames.Datasource = Nothing
					gTypeNames.Datasource = tagNames
					gTypeNames.SelectedItem = gTypeNameTextBox.Text
					gTypeNameTextBox.Clear()
					gTypeNames.Focus()
				End If
				e.Handled = True
				e.SuppressKeyPress = True
		End Select
	End Sub

	Private Sub GValueTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles gValueTextBox.KeyDown
		Select Case e.KeyCode
			Case Keys.Down
				gOfferedValues.Focus()
				e.Handled = True
			Case Keys.Return
				Database.AttribRepository.GetOrAddItem(SelectedTypeName, gValueTextBox.Text)
				Database.AttribRepository.Sort()
				gOfferedValues.Datasource = Nothing
				gOfferedValues.Datasource = Database.AttribRepository.GetValues(SelectedTypeName)
				gOfferedValues.SelectedItem = gValueTextBox.Text
				e.Handled = True
				e.SuppressKeyPress = True
				gValueTextBox.Clear()
				gOfferedValues.Focus()
		End Select
	End Sub

	Private Sub GAssignedAttributes_DoubleClick(sender As Object, e As EventArgs) Handles gAssignedAttributes.DoubleClick
		_AssignedAttribs.Remove(DirectCast(gAssignedAttributes.CurrentRow.DataBoundItem, Attrib))
	End Sub
End Class
