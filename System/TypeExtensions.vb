Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Module TypeExtensions

	<Extension>
	Public Sub ForEachMethodOfAttribute(Of T As Attribute)(extendee As Type, onMethodFoundFunction As Func(Of MethodInfo, T, Boolean))
		Dim methodInfos As MethodInfo()
		methodInfos = extendee.GetMethods()
		For Each methodInfo In methodInfos
			If methodInfo.IsDefined(GetType(T)) Then
				Dim attributes As IEnumerable(Of T) = methodInfo.GetCustomAttributes(Of T)()
				Dim e = attributes.GetEnumerator()
				e.MoveNext()
				Dim attribute As T = e.Current
				Dim cancel As Boolean = onMethodFoundFunction.Invoke(methodInfo, attribute)
				If (cancel) Then
					Exit For
				End If
			End If
		Next
	End Sub

End Module
