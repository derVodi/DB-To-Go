Public Class LinkedFileInfo

	Public Property IsDirty As Boolean

	Private _FullPath As String

	Public Property FullPath As String
		Get
			Return _FullPath
		End Get
		Set(value As String)
			If (value = _FullPath) Then Exit Property
			_FullPath = value
			Me.IsDirty = True
		End Set
	End Property

	Private _FileSize As Long = -1

	Public Property FileSize As Long
		Get
			Return _FileSize
		End Get
		Set(value As Long)
			If (value = _FileSize) Then Exit Property
			_FileSize = value
			Me.IsDirty = True
		End Set
	End Property

	Public ReadOnly Property FileSizeString As String
		Get
			If (Me.FileSize < 0) Then
				Return ""
			Else
				Dim k As Long = Me.FileSize \ 1024
				Dim mb As Long = k \ 1024
				Return mb.ToString("N0") + " MB" 'N0 provides a separator for thousands and no decimals, e.g. 1.234
			End If
		End Get
	End Property

	Private _CreationTime As DateTime

	Public Property CreationTime As DateTime
		Get
			Return _CreationTime
		End Get
		Set(value As DateTime)
			If (value = _CreationTime) Then Exit Property
			_CreationTime = value
		End Set
	End Property

	Public ReadOnly Property CreationTimeString As String
		Get
			If (Me.CreationTime = Date.MinValue) Then
				Return ""
			Else
				Return Me.CreationTime.ToString()
			End If
		End Get
	End Property

End Class
