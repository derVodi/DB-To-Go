Imports DbToGo.Data

Public Class MainPanel

	Public Property EventsActivated As Boolean

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		gTopPanel.BackColor = ColorsByVodi.ToolStrips
		'gCustomPanel.ForeColor = ColorsByVodi.TextForeground
		'gMenuButton.ForeColor = ColorsByVodi.TextForeground
		'gNavTree.BackColor = ColorsByVodi.Text
		gThumbsPanel.BackColor = ColorsByVodi.Text
		gProperties.BackColor = ColorsByVodi.Text

		gThumbsVsProperties.SplitterWidth = 10

		State.WireUp()

		Database.Load()

		DbToGo.IniAccessor.ForEachLineOfSection("Structures", Sub(s) gStructure.Items.Add(s))

		'gTreeVsThumbs.SplitterDistance = My.Settings.NavPanelWidth

		SyncPictureIsAnimated = False

		gCustomPanel.PlaceholderResolver = AddressOf MainPlaceHolderResolver.Resolve

	End Sub

	Public Property SyncPictureIsAnimated() As Boolean
		Get
			Return False
		End Get
		Set(value As Boolean)
			If (value) Then
				gSyncPicture.Image = Image.FromStream(Me.GetType.Assembly.GetManifestResourceStream("DbToGo.sync_on.gif"))
			Else
				If (Syncer.IsOffline) Then
					gSyncPicture.Image = Image.FromStream(Me.GetType.Assembly.GetManifestResourceStream("DbToGo.sync_off.gif"))
				Else
					gSyncPicture.Image = Image.FromStream(Me.GetType.Assembly.GetManifestResourceStream("DbToGo.sync_off_bright.gif"))
				End If
			End If
		End Set
	End Property

	Private _Hierarchy() As String = {"Genre", "Jahr"}

	Private Sub GSplitContainer_SplitterMoved(sender As Object, e As SplitterEventArgs)
		If (Me.EventsActivated) Then
			'My.Settings.NavPanelWidth = gTreeVsThumbs.SplitterDistance
			My.Settings.Save()
		End If
	End Sub

	Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

		Select Case True

			Case (e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.E)
				gSearch.Focus()
				e.Handled = True
				e.SuppressKeyPress = True

			Case (e.KeyCode = Keys.F5)
				InteractionBroker.Send(InteractionCatalog.Sync)
				e.Handled = True
		End Select

	End Sub

	Public Sub InitializeFocus()
		gSearch.Focus()
	End Sub

	Private Sub GSearch_TextChanged(sender As Object, e As EventArgs) Handles gSearch.TextChanged
		If (gSearch.Focused) Then
			gTimer.Enabled = False
			gTimer.Enabled = True
		End If
	End Sub

	Private Sub DoSearchAction()
		gThumbsPanel.PopulateBySearch(gSearch.Text)
		gNavTree.SelectedNode = Nothing
	End Sub

	Private Sub GTree_GotFocus(sender As Object, e As EventArgs)
		'TreeNavigated(gNavTree.SelectedNode)
	End Sub

	Private Sub GSyncPicture_Click(sender As Object, e As EventArgs) Handles gSyncPicture.Click
		InteractionBroker.Send(InteractionCatalog.Sync)
	End Sub

	Private Sub gStructureContextMenu_Click(sender As Object, e As ToolStripItemClickedEventArgs) Handles gMenu.ItemClicked
		InteractionBroker.Send(DirectCast(e.ClickedItem.Tag, String))
	End Sub

	Private Sub gBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles gBackgroundWorker.DoWork
		TagChooser.DropInstance()
		Syncer.TrySync()
		Database.Load()
	End Sub

	Private Sub gBackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles gBackgroundWorker.RunWorkerCompleted
		gNavTree.BindData(gStructure.Text, True)
		If (Not String.IsNullOrWhiteSpace(gSearch.Text)) Then
			Me.DoSearchAction()
		Else

		End If
		Me.SyncPictureIsAnimated = False
	End Sub

	Private Sub gTimer_Tick(sender As Object, e As EventArgs) Handles gTimer.Tick
		gTimer.Enabled = False
		DoSearchAction()
	End Sub

	Private Sub GMenuButton_Click(sender As Object, e As EventArgs) Handles gMenuButton.Click
		gMenu.Show(gMenuButton, New Point(gMenuButton.Width - gMenu.Width, gMenuButton.Height))
	End Sub

End Class
