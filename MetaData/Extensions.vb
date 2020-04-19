Imports System.Runtime.CompilerServices
Imports System.Windows.Media.Imaging

Namespace MetaData

	Module Extensions

		<Extension>
		Function CloneSelectively(extendee As BitmapMetadata, ParamArray queries() As String) As BitmapMetadata
			Dim m As New BitmapMetadata("jpg")
			For Each query In queries
				Dim sourceValue = extendee.GetQuery(query)
				If (sourceValue IsNot Nothing) Then
					m.SetQuery(query, sourceValue)
				End If
			Next
			Return m
		End Function

	End Module

End Namespace
