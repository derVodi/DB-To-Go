Imports System.IO

Public Class Syncer

	Private Shared _IsOffline As Integer = 0

	Public Shared ReadOnly Property IsOffline As Boolean
		Get
			If (_IsOffline = 0) Then
				Dim syncDir = My.Settings.SyncDir
				If ((syncDir IsNot Nothing) AndAlso Directory.Exists(syncDir)) Then
					_IsOffline = -1
				Else
					_IsOffline = 1
				End If
			End If
			Return (_IsOffline = 1)
		End Get
	End Property

	Public Shared Function TrySync() As Boolean
		If (IsOffline) Then
			Return False
		End If
		Return TrySyncInternal()
	End Function

	Private Shared Function TrySyncInternal() As Boolean
		Dim syncDir = My.Settings.SyncDir
		Dim syncCache = CreateDirectoryCache(syncDir)

		Dim localCache = CreateDirectoryCache(State.LocalPictureDir)

		For Each kvp In syncCache
			Dim mustCopy As Boolean = False
			If (localCache.ContainsKey(kvp.Key)) Then
				If (kvp.Value > localCache(kvp.Key)) Then
					mustCopy = True
				End If
			Else
				mustCopy = True
			End If
			If (mustCopy) Then
				Copy(Path.Combine(syncDir, kvp.Key), Path.Combine(State.LocalPictureDir, kvp.Key))
			End If
		Next

		For Each kvp In localCache
			Dim mustCopy As Boolean = False
			If (syncCache.ContainsKey(kvp.Key)) Then
				If (kvp.Value > syncCache(kvp.Key)) Then
					Copy(Path.Combine(State.LocalPictureDir, kvp.Key), Path.Combine(syncDir, kvp.Key))
				End If
			Else
				File.Delete(Path.Combine(State.LocalPictureDir, kvp.Key))
			End If
			
		Next

		Return True
	End Function

	Private Shared Sub Copy(source As String, destination As String)
		File.Delete(destination)
		File.Copy(source, destination)
	End Sub

	Private Shared Function CreateDirectoryCache(directory As String) As Dictionary(Of String, DateTime)
		Dim cache As New Dictionary(Of String, DateTime)

		Dim directoryInfo = New DirectoryInfo(directory)
		For Each fileInfo In directoryInfo.GetFiles()
			Dim fileName = Path.ChangeExtension(fileInfo.Name, fileInfo.Extension.ToLower)
			If (IsOnBlacklist(fileName)) Then
				Continue For
			End If
			cache.Add(fileName, fileInfo.LastWriteTimeUtc.TruncateTicks)
		Next
		Return cache
	End Function

	Private Shared Function IsOnBlacklist(fileName As String) As Boolean
		Select Case fileName
			Case "!db-to-go.exe"
			Case State.IniFileName
			Case Else
				Return False
		End Select
		Return True
	End Function

	Private Shared Sub UpdateOrDeleteIfNecessary(fileInfo As FileInfo)
		Dim destinationFile = Path.Combine(My.Settings.SyncDir, fileInfo.Name)
		If (File.Exists(destinationFile)) Then
			Dim destinationFileInfo = New FileInfo(destinationFile)
			destinationFileInfo.LastWriteTimeUtc.TruncateTicks()
			fileInfo.LastWriteTimeUtc.TruncateTicks()
			If (destinationFileInfo.LastWriteTimeUtc < fileInfo.LastWriteTimeUtc) Then
				File.Delete(destinationFile)
				File.Copy(fileInfo.FullName, destinationFile)
			End If
		Else
			File.Delete(fileInfo.FullName)
		End If
	End Sub

End Class
