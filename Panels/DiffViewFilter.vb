Imports System.Runtime.CompilerServices

Public Enum DiffViewFilter
	All
	Differences
	LeftOnly
	RightOnly
End Enum

Module DiffViewFilterExtensions

	<Extension>
	Public Function Matches(extendee As DiffViewFilter, balance As Integer) As Boolean
		Select Case extendee
			Case DiffViewFilter.All
				Return True
			Case DiffViewFilter.Differences
				Return (balance <> 0)
			Case DiffViewFilter.LeftOnly
				Return (balance = -1)
			Case DiffViewFilter.RightOnly
				Return (balance = 1)
		End Select
		Return False
	End Function

End Module