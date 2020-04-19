Imports System.Runtime.CompilerServices

Public Module AttribExtensions

	<Extension>
	Public Function ContainsType(extendee As IEnumerable(Of Attrib), typeName As String) As Boolean
		For Each attrib In extendee
			If (attrib.TypeName = typeName) Then
				Return True
			End If
		Next
		Return False
	End Function

End Module
