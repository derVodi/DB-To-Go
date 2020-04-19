Public Class Attrib
	Implements IComparable(Of Attrib)

	Public Property TypeName As String

	Public Property Value As String

	Public Sub New()
	End Sub

	Public Sub New(ByRef typeName As String, ByRef value As String)
		Me.TypeName = typeName
		Me.Value = value
	End Sub

	Public Function CompareTo(other As Attrib) As Integer Implements IComparable(Of Attrib).CompareTo
		Dim balance As Integer = Me.TypeName.CompareTo(other.TypeName)
		If (balance <> 0) Then
			Return balance
		End If
		Return Me.Value.CompareTo(other.Value)
	End Function

End Class
