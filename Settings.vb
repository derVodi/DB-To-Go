Partial Friend NotInheritable Class Settings

	Private Shared _Settings As Dictionary(Of String, String)

	Public ReadOnly Property LinkedPathClickAction As String
		Get
			Return GetValue("LinkedPathClickAction")
		End Get
	End Property

	Public ReadOnly Property NameClickAction As String
		Get
			Return GetValue("NameClickAction")
		End Get
	End Property

	Public ReadOnly Property OptimizeMetadata As Boolean
		Get
			Return TryParseBoolean(GetValue("OptimizeMetadata"), True)
		End Get
	End Property

	Public ReadOnly Property ThumbnailHeight As Integer
		Get
			Return TryParseInteger(GetValue("ThumbnailHeight"), 268)
		End Get
	End Property

	Public ReadOnly Property ThumbnailDoubleClickAction As String
		Get
			Return GetValue("ThumbnailDoubleClickAction")
		End Get
	End Property

	Public ReadOnly Property UseEmbeddedThumbnails As Boolean
		Get
			Return TryParseBoolean(GetValue("UseEmbeddedThumbnails"), False)
		End Get
	End Property

	Public ReadOnly Property SyncDir As String
		Get
			Return GetValue("SyncDir")
		End Get
	End Property

	Private Function GetValue(key As String) As String
		If (_Settings Is Nothing) Then
			_Settings = New Dictionary(Of String, String)
			DbToGo.IniAccessor.ForEachLineOfSection(
				"Settings",
				Sub(line)
					Dim n As String = Nothing
					Dim v As String = Nothing
					If (line.TryGetNameValue(n, v)) Then _Settings.Add(n, v)
				End Sub
			)
		End If
		Dim value As String = Nothing
		_Settings.TryGetValue(key, value)
		Return value
	End Function

End Class
