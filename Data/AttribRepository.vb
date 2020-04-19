Public Class AttribRepository
	Inherits List(Of Attrib)

	Private _AllTypeNames As New List(Of String)

	Private _AllValues As New List(Of String)

	Public Shadows Sub Clear()
		MyBase.Clear()
		_AllTypeNames.Clear()
		_AllValues.Clear()
	End Sub

	Public Shadows Sub Sort()
		MyBase.Sort()
		_AllTypeNames.Sort()
		_AllValues.Sort()
	End Sub

	Public ReadOnly Property AllTypeNames As List(Of String)
		Get
			Return _AllTypeNames
		End Get
	End Property

	Public Function GetOrAddItem(name As String, value As String) As Attrib
		If (name Is Nothing OrElse value Is Nothing) Then
			Throw New ArgumentException("Nothing ist not allowed!", "name/value")
			'Return Nothing
		End If
		Dim foundName As String = _AllTypeNames.Find(name)
		If (foundName Is Nothing) Then
			_AllTypeNames.Add(name)
			foundName = name
		End If
		Dim foundValue As String = _AllValues.Find(value)
		If (foundValue Is Nothing) Then
			_AllValues.Add(value)
			foundValue = value
		End If
		Dim foundTag As Attrib = Me.FindAttrib(foundName, foundValue)
		If (foundTag Is Nothing) Then
			foundTag = New Attrib(foundName, foundValue)
			Me.Add(foundTag)
		End If
		Return foundTag
	End Function

	Function FindAttrib(typeName As String, value As String) As Attrib
		For Each namedValue As Attrib In Me
			If (namedValue.TypeName Is typeName AndAlso namedValue.Value Is value) Then
				Return namedValue
			End If
		Next
		Return Nothing
	End Function

	Public Function GetValues(typeName As String) As List(Of String)
		Dim l As New List(Of String)
		For Each t As Attrib In Me
			If (t.TypeName Is typeName) Then
				l.Add(t.Value)
			End If
		Next
		Return l
	End Function

	Public Sub ForEachAttribOf(typeName As String, callback As Action(Of Attrib))
		For Each attrib As Attrib In Me
			If (attrib.TypeName.Equals(typeName)) Then
				callback(attrib)
			End If
		Next
	End Sub

End Class
