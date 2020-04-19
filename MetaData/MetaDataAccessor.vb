Imports System.IO
Imports System.Windows.Media.Imaging

Namespace MetaData

	Public Class MetaDataAccessor

		Public Shared Function LoadAllMetaData(file As String) As BitmapMetadata
			Dim md As BitmapMetadata
			Using stream = New FileStream(file, FileMode.Open, FileAccess.Read)
				Dim bs As BitmapSource = BitmapFrame.Create(stream)
				md = DirectCast(bs.Metadata, BitmapMetadata)
			End Using
			Return md
		End Function

		Public Shared Sub LoadMetaData(fileName As String, queryPathsAndData As Dictionary(Of String, Object))
			Using bitmapStream As Stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read)
				Dim decoder = BitmapDecoder.Create(bitmapStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None)
				If (decoder.Frames(0) Is Nothing OrElse decoder.Frames(0).Metadata Is Nothing) Then
					Exit Sub
				End If
				Dim md = DirectCast(decoder.Frames(0).Metadata, BitmapMetadata)
				Dim keys As New List(Of String)(queryPathsAndData.Keys)	'One cannot iterate and change a Dictionary simultaneously
				For Each key As String In keys
					queryPathsAndData(key) = md.GetQuery(key)
				Next
			End Using
		End Sub

		Public Shared Sub SaveMetadata(filename As String, queryPathsAndData As Dictionary(Of String, Object), optimize As Boolean)

			Dim fileSaved As Boolean

			Using bitmapStream As Stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read)

				' create the decoder for the original file.  The BitmapCreateOptions and BitmapCacheOption denote
				' a lossless transocde.  We want to preserve the pixels and cache it on load.  Otherwise, we will lose
				' quality or even not have the file ready when we save, resulting in 0b of data written

				Dim decoder = BitmapDecoder.Create(bitmapStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None)
				If (decoder.Frames(0) Is Nothing OrElse decoder.Frames(0).Metadata Is Nothing) Then
					Exit Sub
				End If

				Dim frameCopy = DirectCast(decoder.Frames(0).Clone(), BitmapFrame)
				Dim originalMetaData = DirectCast(decoder.Frames(0).Metadata, BitmapMetadata)

				Dim metadata As BitmapMetadata
				If (optimize) Then
					metadata = originalMetaData.CloneSelectively(QueryPaths.Keywords, QueryPaths.ImageDescription)
				Else
					' Because the file is in use, the BitmapMetadata object is frozen. So, we clone the object 
					metadata = originalMetaData.Clone()
				End If

				For Each kvp In queryPathsAndData
					If (kvp.Value IsNot Nothing) Then
						metadata.SetQuery(kvp.Key, kvp.Value)
					End If
				Next

				Dim encoder As JpegBitmapEncoder = New JpegBitmapEncoder()

				encoder.Frames.Add(BitmapFrame.Create(frameCopy, frameCopy.Thumbnail, metadata, frameCopy.ColorContexts))

				Using outputFile As Stream = System.IO.File.Open(filename + ".tmp", FileMode.Create, FileAccess.Write)
					encoder.Save(outputFile)
					fileSaved = True
				End Using

			End Using

			If (fileSaved) Then
				File.Delete(filename)
				File.Move(filename + ".tmp", filename)
			End If

		End Sub

	End Class

End Namespace
