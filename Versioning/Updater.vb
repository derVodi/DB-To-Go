Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Reflection

Namespace Versioning

	<InteractionSubscriber>
	Public Class Updater

		Public Const CheckForUpdate = "Updater.CheckForUpdate"

		Private Shared _Instance As Updater

		Public Shared Function GetInstance() As Updater
			If (_Instance Is Nothing) Then
				_Instance = New Updater
			End If
			Return _Instance
		End Function

		Public Shared ReadOnly Property IsUpdateMode() As Boolean
			Get
#If DEBUG Then
				Return (DebugHelper.SimulationMode = DebugHelper.SimulationModeValue.Updater)
#End If
				Return (Path.GetFileName(Assembly.GetExecutingAssembly().Location) = "Updater.exe")
			End Get
		End Property

		Private _ProductName As String

		Public ReadOnly Property ProductName As String
			Get
				If (_ProductName Is Nothing) Then
					Dim assembly As Assembly = Assembly.GetExecutingAssembly()
					Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location)
					_ProductName = fileVersionInfo.ProductName
				End If

				Return _ProductName
			End Get
		End Property

		Public Shared ReadOnly Property VersionAsString As String
			Get
				Dim assembly As Assembly = Assembly.GetExecutingAssembly()
				Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location)
				Return fileVersionInfo.FileMajorPart.ToString + "." + fileVersionInfo.FileMinorPart.ToString + "." + fileVersionInfo.FileBuildPart.ToString
			End Get
		End Property

		Public Function GetVersionFromWeb() As String
			Dim versionAsString As String = Nothing
			Try
				Dim r = HttpWebRequest.Create(Versioning.Constants.VersionFileUrl)
				Dim a = r.GetResponse()
				Dim s = a.GetResponseStream()
				Dim d = New StreamReader(s)
				versionAsString = d.ReadToEnd()
				d.Close()
				a.Close()
			Catch ex As Exception
				'Do nothing
			End Try
			Return versionAsString
		End Function

		<InteractionListener(Updater.CheckForUpdate)>
		Public Sub CheckForUpdate_Requested()

			Dim w = GetVersionFromWeb()
			If (w Is Nothing OrElse w = VersionAsString) Then
				MessageBox.Show(
				"The version is up to date.",
				"Version checked",
				MessageBoxButtons.OK,
				MessageBoxIcon.None
			)
			Else
				Dim r = MessageBox.Show(
				"A newer version is available." + Environment.NewLine + "Do you want to update now?",
				"Version checked",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
			)
				If (r = DialogResult.Yes) Then
					CopyMyselfAndRun()
				End If
			End If
		End Sub

		Public Shared ReadOnly Property UpdaterExeFile() As String
			Get
				Return Path.Combine(ExecutingDirectory, "Updater.exe")
			End Get
		End Property

		Private Sub CopyMyselfAndRun()
			Dim updaterexeFile = Updater.UpdaterExeFile
			File.Delete(updaterexeFile)
			File.Copy(ExecutingFile, updaterexeFile)
			Dim p = New System.Diagnostics.Process
			p.StartInfo.FileName = updaterexeFile
			p.Start()
			Application.Exit()
		End Sub

		Public Shared Property ProgressPanel As ProgressPanel

		Public Shared Sub DownloadAndUpdate()

			IsFinished = False

			' Preconditions

			Updater.ProgressPanel.AddStep("Downloading update")
			Updater.ProgressPanel.AddStep("Deleting old files")
			Updater.ProgressPanel.AddStep("Unpacking")
			Updater.ProgressPanel.AddButton("Exit", True, AddressOf ExitRequested)
			Updater.ProgressPanel.AddButton("Run Program", False, AddressOf RunNewVersionRequested)

			' Download
			Updater.ProgressPanel.StepForward()
			Updater.Download()

			'Update will be called indirectly via DownloadCompleted event

		End Sub

		Private Shared Sub Update()

			' Delete

			ProgressPanel.StepForward()

			Dim oldFileFullName = Updater.FindProductExeFileFullName()
			If (Not oldFileFullName.EndsWith(".exe")) Then
				Updater.ProgressPanel.SetErrorTextForActiveStep(oldFileFullName)
				Exit Sub
			End If

			File.Delete(oldFileFullName)

			Updater.ProgressPanel.StepForward()

			' Unpack
			Dim executingDirectory = Updater.ExecutingDirectory
			Dim zipFileFullName As String = Updater.ZipFileFullName

			Try
				Using zipFileReader = Compression.ZipFile.OpenRead(zipFileFullName)
					Dim max = zipFileReader.Entries.Count
					ProgressPanel.Maximum = max
					Dim counter As Integer
					For Each entry As ZipArchiveEntry In zipFileReader.Entries
						entry.ExtractToFile(Path.Combine(executingDirectory, entry.Name), True)
						counter += 1
						Updater.ProgressPanel.Value = counter
					Next
				End Using
			Catch ex As Exception
				ProgressPanel.SetErrorTextForActiveStep(ex.Message)
				IsFinished = True
				Exit Sub
			End Try

			File.Delete(zipFileFullName)

			Updater.ProgressPanel.StepForward()

			IsFinished = True
			Updater.ProgressPanel.EnableStateOfButton(1) = True
			Updater.ProgressPanel.FocusOnButton(1)

		End Sub

		Private Shared Sub ExitRequested()
			If (Not IsFinished) Then
				Dim result1 As DialogResult = MessageBox.Show("Operation not yet finished!", "Do you really want to exit now?", MessageBoxButtons.YesNo)
				If (result1 <> DialogResult.Yes) Then
					Exit Sub
				End If
			End If
			Application.Exit()
		End Sub

		Private Shared Sub RunNewVersionRequested()
			Dim newEntryExeFile = FindProductExeFileFullName()
			If (Not newEntryExeFile.EndsWith(".exe")) Then
				MessageBox.Show(newEntryExeFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End If
			Dim p = New System.Diagnostics.Process
			p.StartInfo.FileName = newEntryExeFile
			p.Start()
			Application.Exit()
		End Sub

		Private Shared IsFinished As Boolean

		Private Shared ReadOnly Property ExecutingFile As String
			Get
				If (DebugHelper.SimulationMode = DebugHelper.SimulationModeValue.Updater) Then
					Return Path.Combine(ExecutingDirectory, "Updater.exe")
				Else
					Return Assembly.GetExecutingAssembly().Location
				End If
			End Get
		End Property

		Public Shared ReadOnly Property ExecutingDirectory As String
			Get
				Return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
			End Get
		End Property

		Private Shared Function FindProductExeFileFullName() As String
			Dim executingFile = Updater.ExecutingFile
			Dim foundFile As String = Nothing
			Dim counter As Integer
			For Each fileFullName In Directory.GetFiles(Updater.ExecutingDirectory, "*.exe")
				If (fileFullName.Contains("_DEBUG") OrElse fileFullName.Contains("Updater")) Then
					Continue For
				End If
				If (fileFullName <> executingFile) Then
					counter += 1
					foundFile = fileFullName
				End If
			Next
			If (counter = 0) Then
				Return "No .exe file found in updating directory!"
			End If
			If (counter > 1) Then
				Return "More than one .exe found in updating directory!"
			End If
			Return foundFile
		End Function

		Private Shared ReadOnly Property ZipFileFullName As String
			Get
				Return Path.Combine(Updater.ExecutingDirectory, Constants.AppName + ".zip")
			End Get
		End Property

		Private Shared Sub Download()
			Dim targetFile As String = ZipFileFullName
			File.Delete(targetFile)
			Using wc As New WebClient
				AddHandler wc.DownloadProgressChanged, AddressOf DownloadProgressChanged
				AddHandler wc.DownloadFileCompleted, AddressOf DownloadCompleted
				wc.DownloadFileAsync(New Uri(Versioning.Constants.UpdaterZipFileUrl), targetFile)
			End Using
		End Sub

		Private Shared Sub DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
			ProgressPanel.Value = e.ProgressPercentage
		End Sub

		Private Shared Sub DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs)
			If (e.Error IsNot Nothing) Then
				ProgressPanel.SetErrorTextForActiveStep(e.Error.Message)
				IsFinished = True
				Exit Sub
			End If
			Update()
		End Sub

		Public Shared Sub CleanUpOldStuff()
			File.Delete(UpdaterExeFile)
		End Sub

	End Class

End Namespace
