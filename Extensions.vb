Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Reflection
Imports System.IO
Imports System.Windows.Media.Imaging
Imports System.Text

Module Extensions

	Public Sub AlertError(errorText As StringBuilder)
		If (errorText.Length = 0) Then Exit Sub
		MessageBox.Show(errorText.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
	End Sub

	<Extension>
	Function TruncateTicks(extendee As DateTime) As DateTime
		Return extendee.AddTicks(-(extendee.Ticks Mod TimeSpan.TicksPerSecond))
	End Function

	<Extension>
	Function Find(extendee As List(Of String), ByRef value As String) As String
		For Each s In extendee
			If (s.Equals(value)) Then
				Return s
			End If
		Next
		Return Nothing
	End Function

	<Extension>
	Function Find(extendee As BindingList(Of String), ByRef value As String) As String
		For Each s In extendee
			If (s.Equals(value)) Then
				Return s
			End If
		Next
		Return Nothing
	End Function

	<Extension>
	Sub ForEachParent(extendee As TreeNode, callback As Action(Of Integer, TreeNode))
		Dim parentNode As TreeNode = extendee
		Dim i As Integer
		Do
			callback.Invoke(i, parentNode)
			i += 1
			parentNode = parentNode.Parent
		Loop While parentNode IsNot Nothing
	End Sub

	<Extension>
	Function IsAnimating(extendee As PictureBox) As Boolean
		Dim fieldInfo = extendee.GetType.GetField("currentlyAnimatig")
		Return DirectCast(fieldInfo.GetValue(extendee), Boolean)
	End Function

	<Extension>
	Sub Animate(extendee As PictureBox, enable As Boolean)
		Dim animateFunction = extendee.GetType().GetMethod("Animate", BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(Boolean)}, Nothing)
		animateFunction.Invoke(extendee, New Object() {enable})
	End Sub

	<Extension>
	Function TryGetNameValue(extendee As String, ByRef name As String, ByRef value As String, Optional trimQuotes As Boolean = False) As Boolean
		Dim leftPos As Integer = extendee.IndexOf("="c)
		If (trimQuotes) Then
			leftPos = extendee.IndexOf(""""c, leftPos)
		End If
		If (leftPos < 1 OrElse leftPos = extendee.Length - 1) Then
			Return False
		End If
		Dim rightPos As Integer
		If (trimQuotes) Then
			rightPos = extendee.IndexOf(""""c, leftPos + 1)
			If (rightPos < 0) Then
				Return False
			End If
			name = extendee.Substring(0, leftPos - 1)
			value = extendee.Substring(leftPos + 1, rightPos - leftPos - 1)
		Else
			name = extendee.Substring(0, leftPos)
			value = extendee.Substring(leftPos + 1)
		End If
		Return True
	End Function

	Function TryParseInteger(value As String, defaultValue As Integer) As Integer
		Dim parsedValue As Integer
		If (Integer.TryParse(value, parsedValue)) Then
			Return parsedValue
		End If
		Return defaultValue
	End Function

	Function TryParseBoolean(value As String, defaultValue As Boolean) As Boolean
		Dim parsedValue As Boolean
		If (Boolean.TryParse(value, parsedValue)) Then
			Return parsedValue
		End If
		Return defaultValue
	End Function

End Module
